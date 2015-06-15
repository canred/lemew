/*全局變量*/
var WS_REPORTORDERQUERYPANEL;
/*WS.SupplierQueryPanel物件類別*/
/*TODO*/
/*
1.Model 要集中                                 [YES]
2.panel 的title要換成icon , title的方式        [YES]
3.add 的icon要換成icon , title的方式           [YES]
4.自動Query 資料                               [YES]
*/
/*columns 使用default*/
Ext.define('WS.ReportOrderQueryPanel', {
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
                    for (var i = 0; i < store.getCount(); i++) {
                        if (store.getAt(i).get('C_NAME').length > 2) {
                            store.getAt(i).set('C_NAME', store.getAt(i).get('C_NAME').substr(0, 2));
                            store.getAt(i).commit();
                        }

                    }
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'C_NAME',
                direction: 'ASC'
            }]
        }),
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
            listeners: {
                load: function(store, records, sucessful, eOpts) {
                    store.insert(0, {
                        'CUST_UUID': '',
                        'CUST_NAME': '全部'
                    });
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'CUST_NAME',
                direction: 'ASC'
            }]
        }),
        vCustOrder: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'V_CUST_ORDER',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadVCustOrderForReport
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pStartDate', 'pEndDate', 'pIsGroup', 'pGroupType', 'pCompanyUuid', 'pCustUuid', 'pCustOrgUuid', 'pKeyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    'pStartDate': '',
                    'pEndDate': '',
                    'pIsGroup': '',
                    'pGroupType': '',
                    'pCompanyUuid': '',
                    'pCustUuid': '',
                    'pCustOrgUuid': '',
                    'pKeyword': ''
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
            sorters: [{
                property: 'CUST_ORDER_ID',
                direction: 'DESC'
            }]
        }),
        custOrg: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'V_CUST_ORDER',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadCustOrg
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pCustUuid', 'pKeyword', 'pShowIsDefault', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pCustUuid: '',
                    pKeyword: '',
                    pShowIsDefault: '0'
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
                        'CUST_ORG_UUID': '',
                        'CUST_ORG_NAME': '全部'
                    });
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'CUST_ORG_NAME',
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
            title: '銷售報告',
            icon: SYSTEM_URL_ROOT + '/css/custimages/reportA16x16.png',
            frame: true,

            border: false,
            height: $(document).height() - 130,
            autoWidth: true,
            padding: '5 0 5 5',
            items: [{
                xtype: 'container',
                layout: 'hbox',
                items: [{
                    xtype: 'datefield',
                    labelWidth: 40,
                    fieldLabel: '時間',
                    //value: new Date(),
                    format: 'Y/m/d',
                    submitFormat: 'Y/m/d',
                    labelAlign: 'right',
                    itemId: 'dfStart',
                    allowBlank: false,
                    width: 145
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
                    width: 100
                }, {
                    xtype: 'combo',
                    fieldLabel: '出貨公司',
                    labelAlign: 'right',
                    width: 130,
                    labelWidth: 60,
                    itemId: 'cmbCompany',
                    displayField: 'C_NAME',
                    valueField: 'UUID',
                    editable: false,
                    store: this.myStore.company,
                    value: '',
                    listeners: {
                        'select': function(combo, records, eOpts) {}
                    }
                }, {
                    xtype: 'combo',
                    fieldLabel: '客戶名稱',
                    displayField: 'CUST_NAME',
                    valueField: 'CUST_UUID',
                    itemId: 'cmbCust',
                    hidden: false,
                    editable: false,
                    readOnly: true,
                    store: this.myStore.cust,
                    value: '',
                    listeners: {
                        'select': function(combo, records, eOpts) {
                            var mainPanel = combo.up('panel').up('panel');
                            mainPanel.down('#cmbCustOrg').setValue('');
                            mainPanel.myStore.custOrg.getProxy().setExtraParam('pCustUuid', combo.getValue());
                            mainPanel.myStore.custOrg.load();

                        }
                    },
                    labelAlign: 'right',
                    width: 130,
                    labelWidth: 60
                }, {
                    xtype: 'button',
                    text: '選',
                    handler: function(handler, scope) {
                        var mainPanel = this.up('panel').up('panel');
                        var subWin = Ext.create('WS.CustPickerWindow', {
                            param: {
                                parentObj: mainPanel,
                                showAllBtn: true
                            }
                        });
                        subWin.on('selectedEvent', function(obj, selectRecord) {
                            obj.param.parentObj.down('#cmbCust').setValue(selectRecord.CUST_UUID);

                            obj.param.parentObj.down('#cmbCustOrg').setValue('');
                            obj.param.parentObj.myStore.custOrg.getProxy().setExtraParam('pCustUuid', selectRecord.CUST_UUID);
                            obj.param.parentObj.myStore.custOrg.load();

                            obj.close();

                        });
                        subWin.show();
                    }
                }, {
                    xtype: 'combo',
                    fieldLabel: '單位',
                    itemId: 'cmbCustOrg',
                    value: '',
                    displayField: 'CUST_ORG_NAME',
                    valueField: 'CUST_ORG_UUID',
                    labelAlign: 'right',
                    editable: false,
                    hidden: false,
                    store: this.myStore.custOrg,
                    width: 110,
                    labelWidth: 40
                }, {
                    xtype: 'textfield',
                    labelAlign: 'right',
                    fieldLabel: '關鍵字',
                    width: 130,
                    itemId: 'txt_search',
                    labelWidth: 50,
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
                        var store = this.up('panel').down("#grdSupplierQuery").getStore(),
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

                                var start = pl.down('#dfStart').getValue();
                                var end = pl.down('#dfEnd').getValue();

                                if (start != undefined && typeof start.getFullYear == 'function') {
                                    var month = (start.getMonth() + 1);
                                    var day = start.getDate();
                                    if (month < 10) {
                                        month = "0" + month;
                                    };
                                    if (day < 10) {
                                        day = "0" + day;
                                    };
                                    start = start.getFullYear() + '/' + month + "/" + day;
                                };

                                if (end != undefined && typeof end.getFullYear == 'function') {
                                    var month = (end.getMonth() + 1);
                                    var day = end.getDate();
                                    if (month < 10) {
                                        month = "0" + month;
                                    };
                                    if (day < 10) {
                                        day = "0" + day;
                                    };
                                    end = end.getFullYear() + '/' + month + "/" + day;
                                };


                                if (Ext.isEmpty(start)) {
                                    start = '';
                                };
                                if (Ext.isEmpty(end)) {
                                    end = '';
                                };
                                if (start != '' || end != '') {
                                    if (start == '' || end == '') {
                                        Ext.MessageBox.show({
                                            title: '操作提示',
                                            icon: Ext.MessageBox.INFO,
                                            buttons: Ext.Msg.OK,
                                            msg: '日期區間查詢，須要填寫開始日期、結束日期!'
                                        });
                                        return;
                                    }
                                };
                                var company = pl.down('#cmbCompany').getValue();
                                var cust = pl.down('#cmbCust').getValue();
                                var custOrg = pl.down('#cmbCustOrg').getValue();
                                var keyword = pl.down("#txt_search").getValue();

                                obj.getProxy().setExtraParam('pStartDate', start);
                                obj.getProxy().setExtraParam('pEndDate', end);
                                obj.getProxy().setExtraParam('pIsGroup', '');
                                obj.getProxy().setExtraParam('pGroupType', '');
                                obj.getProxy().setExtraParam('pCompanyUuid', company);
                                obj.getProxy().setExtraParam('pCustUuid', cust);
                                obj.getProxy().setExtraParam('pCustOrgUuid', custOrg);
                                obj.getProxy().setExtraParam('pKeyword', keyword);



                                obj.loadPage(1);
                                WS.CustAction.loadVCustOrderForReportSum(start, end, '', '', company, cust, custOrg, keyword, 1, 999999, "CUST_ORDER_ID", "ASC", function(obj, jsonObj) {
                                    if (jsonObj.result) {
                                        if (jsonObj.result.SUM) {
                                            this.down('#btnSum').show();
                                            this.down('#btnSum').setText("合計：$" + jsonObj.result.SUM);
                                        } else {
                                            this.down('#btnSum').hide();
                                        }
                                    }
                                }, pl);
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
                        mainPanel.down("#dfStart").setValue('');
                        mainPanel.down("#dfEnd").setValue('');
                        mainPanel.down("#cmbCompany").setValue('');
                        mainPanel.down("#cmbCust").setValue('');
                        mainPanel.down("#cmbCustOrg").setValue('');
                        mainPanel.down("#txt_search").setValue('');

                    }
                }]
            }, {
                xtype: 'gridpanel',
                store: this.myStore.vCustOrder,
                itemId: 'grdSupplierQuery',
                border: true,
                height: $(document).height() - 200,
                padding: '5 15 5 5',
                columns: [
                    // {
                    //     text: "查看",
                    //     xtype: 'actioncolumn',
                    //     dataIndex: 'UUID',
                    //     align: 'center',
                    //     width: 60,
                    //     items: [
                    //     {
                    //         tooltip: '*查看',
                    //         icon: SYSTEM_URL_ROOT + '/css/custimages/view16x16.png',
                    //         handler: function(grid, rowIndex, colIndex) {
                    //             var main = grid.up('panel').up('panel').up('panel');
                    //             if (!main.subWinCustOrder) {
                    //                 Ext.MessageBox.show({
                    //                     title: '系統訊息',
                    //                     icon: Ext.MessageBox.INFO,
                    //                     buttons: Ext.Msg.OK,
                    //                     msg: '未實現 subWinCustOrder 物件,無法進行編輯操作!'
                    //                 });
                    //                 return false;
                    //             };
                    //             var subWin = Ext.create(main.subWinCustOrder, {});
                    //             //Ext.getBody().mask();
                    //             subWin.on('closeEvent', function(obj) {
                    //                 //main.down("#grdVCustOrder").getStore().load();
                    //                 //Ext.getBody().unmask();
                    //             }, main);
                    //             subWin.param.custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                    //             subWin.param.custUuid = grid.getStore().getAt(rowIndex).data.CUST_UUID;
                    //             subWin.show();
                    //         }
                    //     }],
                    //     sortable: false,
                    //     hideable: false
                    // }, 
                    {
                        xtype: 'templatecolumn',
                        text: '查看',
                        width: 60,
                        sortable: false,
                        hideable: false,
                        tpl: new Ext.XTemplate(
                            "<tpl >",
                            '{[this.fnInit()]}<input type="button" style="width:50px" value="查看" onclick="ReportOrderQueryPanelFnView(\'{CUST_ORDER_UUID}\',\'{CUST_UUID}\')"/>',
                            "</tpl>", {
                                scope: this,
                                fnInit: function() {
                                    document.ReportOrderQueryPanel = this.scope;
                                    if (!document.ReportOrderQueryPanelFnView) {
                                        document.ReportOrderQueryPanelFnView = function(CUST_ORDER_UUID, CUST_UUID) {
                                            var main = document.ReportOrderQueryPanel;
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
                                            //Ext.getBody().mask();
                                            subWin.on('closeEvent', function(obj) {
                                                //main.down("#grdVCustOrder").getStore().load();
                                                //Ext.getBody().unmask();
                                            }, main);
                                            subWin.param.custOrderUuid = CUST_ORDER_UUID;
                                            subWin.param.custUuid = CUST_UUID;
                                            subWin.show();
                                        }
                                    }

                                }
                            }),

                    }, {
                        header: '訂單編號',
                        dataIndex: 'CUST_ORDER_ID',
                        width: 140,
                    }, {
                        header: "出貨日期",
                        dataIndex: 'CUST_ORDER_SHIPPING_DATE',
                        align: 'left',
                        flex: 1
                    }, {
                        header: "出貨公司",
                        align: 'left',
                        dataIndex: 'COMPANY_C_NAME',
                        flex: 1
                    }, {
                        header: "客戶名稱",
                        dataIndex: 'CUST_NAME',
                        align: 'left',
                        flex: 1
                    }, {
                        header: '單位',
                        dataIndex: 'CUST_ORG_NAME',
                        align: 'left',
                        flex: 1
                    }, {
                        header: '總銷售金額',
                        dataIndex: 'CUST_ORDER_TOTAL_PRICE',
                        align: 'right',
                        flex: 1,
                        renderer: function(value, r) {
                            return Ext.String.format('${0}', value);
                        }
                    }
                ],
                fbar: [{
                    type: 'button',
                    text: '合計：',
                    itemId: 'btnSum'
                }],
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.vCustOrder,
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

            this.myStore.company.load();
            // this.myStore.vCustOrder.load({
            //     scope: this
            // });
            this.myStore.cust.load();
            this.myStore.custOrg.load();

            this.down("#btnQuery").handler();
        }
    }
});
