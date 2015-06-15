/*全局變量*/
var WS_ORDERSEARCHQUERYPANEL;
/*WS.SupplierQueryPanel物件類別*/
/*TODO*/
/*
1.Model 要集中                                 [YES]
2.panel 的title要換成icon , title的方式        [YES]
3.add 的icon要換成icon , title的方式           [YES]
4.自動Query 資料                               [YES]
*/
/*columns 使用default*/
Ext.define('WS.OrderSearchQueryPanel', {
    extend: 'Ext.panel.Panel',
    closeAction: 'destroy',
    subWinCustOrder: undefined,
    /*語言擴展*/
    lan: {},
    /*參數擴展*/
    param: {
        showADSync: true
    },
    /*值擴展*/
    val: {},
    /*物件會用到的Store物件*/
    myStore: {
        cust: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'CUST',
            pageSize: 9999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadCust
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'pCustIsActive', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pCustIsActive: '1|0'
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        Ext.MessageBox.show({
                            title: 'Warning',
                            msg: response.result.message,
                            icon: Ext.MessageBox.ERROR,
                            buttons: Ext.Msg.OK
                        });
                    }
                }
            },
            remoteSort: true,
            listeners: {
                load: function(store, records, sucessful, eOpts) {
                    store.insert(0, {
                        'CUST_UUID': '',
                        'CUST_NAME': '全部'
                    });
                }
            },
            sorters: [{
                property: 'CUST_NAME',
                direction: 'ASC'
            }]
        }),
        vcustordersearch: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: 'V_CUST_ORDER_SEARCH',
            pageSize: 200,
            remoteSort: true,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadVCustOrderSearch
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['dtStart', 'dtEnd', 'pKeyword', 'pCustOrderType', 'pCompanyUuid', 'pCustUuid', 'pCustOrderStatusUuid', 'pShippingStatusUuid', 'pPayStatusUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    dtStart: '',
                    dtEnd: '',
                    pKeyword: '',
                    pCustOrderType: '',
                    pCompanyUuid: '',
                    pCustUuid: '',
                    pCustOrderStatusUuid: '',
                    pShippingStatusUuid: 'SS_FINISH',
                    pPayStatusUuid: ''
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        Ext.MessageBox.show({
                            title: 'REMOTE EXCEPTON A',
                            msg: operation.getError(),
                            icon: Ext.MessageBox.ERROR,
                            buttons: Ext.Msg.OK
                        });
                    }
                }
            },
            sorters: [{
                property: 'CUST_ORDER_ID',
                direction: 'DESC'
            }],
            grouper: Ext.create('Ext.util.Grouper', {
                property: 'CUST_ORDER_ID',
                direction: 'DESC'
            })
        }),
        company: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'CUST',
            pageSize: 9999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.AdminCompanyAction.loadCompany
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'pIsActive', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pIsActive: 'Y'
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        Ext.MessageBox.show({
                            title: 'Warning',
                            msg: response.result.message,
                            icon: Ext.MessageBox.ERROR,
                            buttons: Ext.Msg.OK
                        });
                    }
                }
            },
            listeners: {
                load: function(store, records, sucessful, eOpts) {
                    store.insert(0, {
                        'UUID': '',
                        'C_NAME': '全部'
                    });
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'C_NAME',
                direction: 'ASC'
            }]
        }),
        custOrderStatus: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'CUST_ORDER_STATUS',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustOrderStatusAction.loadCustOrderStatus
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['keyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    keyword: ''
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        if (!response.result.success) {
                            Ext.MessageBox.show({
                                title: 'Warning',
                                icon: Ext.MessageBox.WARNING,
                                buttons: Ext.Msg.OK,
                                msg: response.result.message
                            });
                        }
                    }
                }
            },
            remoteSort: true,
            listeners: {
                load: function(store, records, sucessful, eOpts) {
                    store.insert(0, {
                        'CUST_ORDER_STATUS_UUID': '',
                        'CUST_ORDER_STATUS_NAME': '全部'
                    });
                }
            },
            sorters: [{
                property: 'CUST_ORDER_STATUS_ORD',
                direction: 'ASC'
            }]
        }),
        shippingStatus: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'SHIPPING_STATUS',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.ShippingStatusAction.loadShippingStatus
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['keyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    keyword: ''
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        if (!response.result.success) {
                            Ext.MessageBox.show({
                                title: 'Warning',
                                icon: Ext.MessageBox.WARNING,
                                buttons: Ext.Msg.OK,
                                msg: response.result.message
                            });
                        }
                    }
                }
            },
            listeners: {
                load: function(store, records, sucessful, eOpts) {
                    store.insert(0, {
                        'SHIPPING_STATUS_UUID': '',
                        'SHIPPING_STATUS_NAME': '全部'
                    });
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'SHIPPING_STATUS_ORD',
                direction: 'ASC'
            }]
        })
    },
    fnActiveRender: function isActiveRenderer(value, id, r) {
        var html = "<img src='" + SYSTEM_URL_ROOT;
        return value === "Y" ? html + "/css/custimages/active03.png'>" : html + "/css/custimages/unactive03.png'>";
    },
    fnCheckSubWindowns: function() {

        if (Ext.isEmpty(this.subWinCustOrder)) {
            Ext.MessageBox.show({
                title: '系統提示',
                icon: Ext.MessageBox.WARNING,
                buttons: Ext.Msg.OK,
                msg: '未實現 subWinCustOrder 物件,無法進行編輯操作!'
            });
            return false;
        };
        return true;
    },
    initComponent: function() {
        if (!this.fnCheckSubWindowns()) {
            return false;
        };
        this.items = [{
            xtype: 'panel',
            title: '訂單搜尋',
            icon: SYSTEM_URL_ROOT + '/css/custimages/search16x16.png',
            frame: true,
            border: false,
            autoHeight: true,
            minHeight: $(document).height() - 130,
            autoWidth: true,
            padding: '5 0 5 5',
            items: [{
                xtype: 'container',
                layout: 'hbox',
                margin: '0 0 0 5',
                defaults: {
                    labelAlign: 'right'
                },
                items: [{
                    xtype: 'combo',
                    fieldLabel: '類型',
                    queryMode: 'local',
                    itemId: 'cmbCustOrderType',
                    displayField: 'text',
                    valueField: 'value',
                    labelWidth: 60,
                    width: 150,
                    editable: false,
                    hidden: false,
                    value: '',
                    store: new Ext.data.ArrayStore({
                        fields: ['text', 'value'],
                        data: [
                            ['全部', ''],
                            ['報價單', '0'],
                            ['訂單', '1']
                        ]
                    }),
                    editable: false,
                    hidden: true
                }, {
                    xtype: 'combo',
                    fieldLabel: '開單公司',
                    labelWidth: 80,
                    itemId: 'cmbCompany',
                    displayField: 'C_NAME',
                    labelAlign: 'right',
                    valueField: 'UUID',
                    editable: false,
                    hidden: true,
                    store: this.myStore.company,
                    value: '',
                }, {
                    xtype: 'datefield',
                    labelWidth: 60,
                    fieldLabel: '日期區間',
                    //value: new Date(),
                    format: 'Y/m/d',
                    submitFormat: 'Y/m/d',
                    labelAlign: 'right',
                    itemId: 'dfStart',
                    allowBlank: false,
                    width: 170
                }, {
                    html: '~'
                }, {
                    xtype: 'datefield',
                    //value: new Date(),
                    format: 'Y/m/d',
                    submitFormat: 'Y/m/d',
                    labelAlign: 'right',
                    itemId: 'dfEnd',
                    allowBlank: false,
                    width: 110
                }, {
                    xtype: 'combo',
                    fieldLabel: '客戶',
                    itemId: 'cmbCust',
                    margin: '0 0 0 5',
                    labelWidth: 30,
                    displayField: 'CUST_NAME',
                    valueField: 'CUST_UUID',

                    editable: false,
                    hidden: false,
                    value: '',
                    store: this.myStore.cust,
                    editable: false
                }, {
                    xtype: 'combo',
                    fieldLabel: '訂單狀態',
                    labelWidth: 80,
                    itemId: 'cmbOrderStatus',
                    displayField: 'CUST_ORDER_STATUS_NAME',
                    valueField: 'CUST_ORDER_STATUS_UUID',
                    editable: false,
                    hidden: true,
                    store: this.myStore.custOrderStatus,
                    value: '',
                    width: 160
                }, {
                    xtype: 'combo',
                    fieldLabel: '出貨狀態',
                    queryMode: 'local',
                    itemId: 'cmbShippingStatus',
                    displayField: 'SHIPPING_STATUS_NAME',
                    valueField: 'SHIPPING_STATUS_UUID',
                    labelWidth: 60,
                    width: 160,
                    editable: false,
                    hidden: false,
                    //value: 'SS_FINISH',
                    value: '',
                    store: this.myStore.shippingStatus,
                    editable: false
                }, {
                    xtype: 'textfield',
                    fieldLabel: '關鍵字',
                    margin: '0 0 0 5',
                    itemId: 'txt_search',
                    labelWidth: 50,
                    width: 150,
                    enableKeyEvents: true,
                    listeners: {
                        keyup: function(e, t, eOpts) {
                            var keyCode = t.keyCode;
                            if (keyCode == Ext.event.Event.ENTER) {
                                this.up('panel').down("#btnQuery").handler();
                            };
                        }
                    }
                }, {
                    xtype: 'button',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/find.png',
                    text: '查詢',
                    margin: '0 0 0 5',
                    itemId: 'btnQuery',
                    width: 60,
                    handler: function() {
                        var store = this.up('panel').down("#grdVCustOrder").getStore(),
                            doSomeghing = function(obj, pl) {
                                if (pl.down("#dfStart").isValid() == false || pl.down("#dfEnd").isValid() == false) {
                                    Ext.MessageBox.show({
                                        title: '操作提示',
                                        icon: Ext.MessageBox.INFO,
                                        buttons: Ext.Msg.OK,
                                        msg: '日期區間格式錯誤!'
                                    });
                                    return;
                                };


                                obj.getProxy().setExtraParam('dtStart', pl.down("#dfStart").getValue());
                                obj.getProxy().setExtraParam('dtEnd', pl.down("#dfEnd").getValue());
                                obj.getProxy().setExtraParam('pCustOrderType', pl.down("#cmbCustOrderType").getValue());
                                obj.getProxy().setExtraParam('pCustUuid', pl.down("#cmbCust").getValue());
                                obj.getProxy().setExtraParam('pKeyword', pl.down("#txt_search").getValue());
                                obj.getProxy().setExtraParam('pCompanyUuid', pl.down("#cmbCompany").getValue());
                                obj.getProxy().setExtraParam('pCustOrderStatusUuid', pl.down("#cmbOrderStatus").getValue());
                                obj.getProxy().setExtraParam('pShippingStatusUuid', pl.down("#cmbShippingStatus").getValue());
                                obj.getProxy().setExtraParam('pPayStatusUuid', '');
                                obj.loadPage(1);
                            }(store, this.up('panel'));
                    }
                }, {
                    xtype: 'button',
                    width: 60,
                    margin: '0 0 0 5',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/clear.png',
                    text: '清除',
                    tooltip: '*清除目前所有的條件查詢',
                    handler: function() {
                        var mainPanel = this.up('panel');
                        mainPanel.down("#txt_search").setValue('');
                        mainPanel.down("#cmbCustOrderType").setValue('');
                        mainPanel.down("#cmbCust").setValue('');
                        mainPanel.down("#cmbCompany").setValue('');
                        mainPanel.down("#cmbOrderStatus").setValue('');
                        mainPanel.down("#cmbShippingStatus").setValue('');
                    }
                }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                margin: '5 0 0 5',
                hidden: true,
                defaults: {
                    labelAlign: 'right'
                },
                items: []
            }, {
                xtype: 'gridpanel',
                store: this.myStore.vcustordersearch,
                itemId: 'grdVCustOrder',
                border: true,
                minHeight: $(document).height() - 200,
                autoHeight: true,
                padding: '5 15 5 5',
                features: [{
                    ftype: 'groupingsummary',
                    groupHeaderTpl: new Ext.create('Ext.XTemplate',
                        '訂單編號:{name} ，{rows:this.getCustName}/{rows:this.getCustOrgSalesName}{rows:this.getCustOrgSalesPhone}{rows:this.getCustOrderTotalPrice}',
                        '</span>', {
                            getCustName: function(rows) {
                                return "<span style='color:blue'>" + rows[0].data.CUST_NAME + "</span>";
                            },
                            getCustOrgSalesName: function(rows) {
                                return "<span>" + rows[0].data.CUST_ORG_SALES_NAME + "</span>";
                            },
                            getCustOrgSalesPhone: function(rows) {
                                var ret = rows[0].data.CUST_ORG_SALES_PHONE;
                                if (ret.length > 0) {
                                    ret = "(" + ret + ")";
                                }
                                return ret;
                            },
                            getCustOrderTotalPrice: function(rows) {

                                if (rows[0].data.CUST_ORDER_HAS_TAX == 1) {
                                    ret = "訂單總計:$";
                                } else {
                                    ret = "訂單總計(<span style='color:red;font-weight: bold;'>稅後</span>):$";
                                }
                                ret = ret + rows[0].data.CUST_ORDER_TOTAL_PRICE;
                                return "<div style='float:right;'>" + ret + "<div>";
                                //return "";
                            }
                        }),
                    showSummaryRow: true,
                    hideGroupedHeader: false,
                    enableGroupingMenu: false
                }

                // , {
                //     ftype: 'rowbody',
                //     setupRowData: function(record, rowIndex, rowValues) {
                //         var headerCt = this.view.headerCt,
                //             colspan = headerCt.getColumnCount();

                //         // Usually you would style the my-body-class in CSS file
                //         Ext.apply(rowValues, {
                //             rowBody: '<div style="padding: 1em">' + record.get("CUST_ORDER_TOTAL_PRICE") + '</div>',
                //             rowBodyCls: "my-body-class",
                //             rowBodyColspan: colspan
                //         });
                //     }
                // }

                ],
                sortableColumns: false,
                columns: [{
                        xtype: 'templatecolumn',
                        text: '查看',
                        width: 70,
                        sortable: false,
                        hideable: false,
                        tpl: new Ext.XTemplate(
                            "<tpl >",
                            '{[this.fnInit()]}<input type="button" style="width:60px" value="查看" onclick="OrderSearchQueryPanelFnView(\'{CUST_ORDER_UUID}\',\'{CUST_UUID}\')"/>',
                            "</tpl>", {
                                scope: this,
                                fnInit: function() {
                                    document.OrderSearchQueryPanel = this.scope;
                                    if (!document.OrderSearchQueryPanelFnView) {
                                        document.OrderSearchQueryPanelFnView = function(CUST_ORDER_UUID, CUST_UUID) {
                                            var main = document.OrderSearchQueryPanel;
                                            if (!main.subWinCustOrder) {
                                                Ext.MessageBox.show({
                                                    title: '系統訊息',
                                                    icon: Ext.MessageBox.INFO,
                                                    buttons: Ext.Msg.OK,
                                                    msg: '未實現 subWinCustOrder 物件,無法進行編輯操作!'
                                                });
                                                return false;
                                            };
                                            var subWin = Ext.create(main.subWinCustOrder, {});
                                            subWin.on('closeEvent', function(obj) {}, main);
                                            subWin.param.custOrderUuid = CUST_ORDER_UUID;
                                            subWin.param.custUuid = CUST_UUID;
                                            subWin.show();

                                        }
                                    }

                                }
                            })
                    }, {
                        header: "出貨日期",
                        dataIndex: 'CUST_ORDER_SHIPPING_DATE',
                        align: 'left',
                        width: 80,
                        renderer: function(value, r) {
                            var text = '';
                            if (value != '' && value.indexOf(' ') != -1) {
                                text = value.split(' ')[0];
                            }
                            return Ext.String.format('<div style="font-size:10px;">{0}</div>', text);
                        },
                        summaryType: 'count',
                        summaryRenderer: function(value) {
                            return Ext.String.format('共{0}筆', value);
                        }
                    }, {
                        header: "出貨編號",
                        dataIndex: 'CUST_ORDER_SHIPPING_NUMBER',
                        align: 'left',
                        flex: 1,
                        hidden: true
                    }, {
                        header: '出貨狀態',
                        dataIndex: 'SHIPPING_STATUS_NAME',
                        align: 'center',
                        width: 120,
                        renderer: function(value, r) {
                            var text = "";
                            text = r.record.data.SHIPPING_STATUS_NAME;
                            if (r.record.data.PAY_STATUS_NAME != '') {
                                text += '(' + r.record.data.PAY_STATUS_NAME + ')';
                            }
                            return Ext.String.format('<div style="font-size:10px;">{0}</div>', text);
                        }
                    }, {
                        header: '商品名稱',
                        dataIndex: 'CUST_ORDER_DETAIL_GOODS_NAME',
                        align: 'left',
                        flex: 1
                    }, {
                        xtype: 'booleancolumn',
                        header: '客製',
                        dataIndex: 'CUST_ORDER_DETAIL_CUSTOMIZED',
                        align: 'center',
                        trueText: '是',
                        falseText: '否',
                        hidden: true,
                        width: 80,
                    },

                    {
                        header: '數量',
                        dataIndex: 'CUST_ORDER_DETAIL_COUNT',
                        align: 'right',
                        width: 80
                    }, {
                        header: '單位',
                        dataIndex: 'CUST_ORDER_DETAIL_UNIT_NAME',
                        align: 'center',
                        width: 80
                    }, {
                        header: '單價',
                        dataIndex: 'CUST_ORDER_DETAIL_PRICE',
                        align: 'right',
                        width: 150,
                        renderer: function(value, r) {
                                return Ext.String.format('${0}', value);
                            }
                            // summaryType: 'sum',
                            // summaryRenderer: function(value) {
                            //     return Ext.String.format('單價合計：{0}', value);
                            // }
                    }, {
                        header: '備註',
                        dataIndex: 'CUST_ORDER_PS',
                        align: 'left',
                        flex: 1,
                        hidden: true
                    }
                ],

                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.vcustordersearch,
                    displayInfo: true,
                    displayMsg: '第{0}~{1}資料/共{2}筆',
                    emptyMsg: "無資料顯示"
                })
            }]

        }];
        this.callParent(arguments);
    },
    listeners: {
        afterrender: function(obj, eOpts) {
            var today = new Date();
            var startDate = today.getFullYear() + "/1/1";
            var endDate = today.getFullYear() + "/12/31";

            this.down('#dfStart').setValue(new Date(startDate));
            this.down('#dfEnd').setValue(new Date(endDate));

            this.myStore.cust.load({
                scope: this
            });

            // this.myStore.vcustordersearch.load({
            //     scope: this
            // });

            this.myStore.company.load({
                scope: this
            });

            this.myStore.custOrderStatus.load({
                scope: this
            });

            this.myStore.shippingStatus.load({
                scope: this
            });

            this.down("#btnQuery").handler();
        }
    }
});
