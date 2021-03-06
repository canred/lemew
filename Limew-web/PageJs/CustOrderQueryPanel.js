/*全局變量*/
var WS_CUSTORDERQUERYPANEL;
/*WS.SupplierQueryPanel物件類別*/
/*TODO*/
/*
1.Model 要集中                                 [YES]
2.panel 的title要換成icon , title的方式        [YES]
3.add 的icon要換成icon , title的方式           [YES]
4.自動Query 資料                               [YES]
*/
/*columns 使用default*/
Ext.define('WS.CustOrderQueryPanel', {
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
        vcustorder: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: 'V_CUST_ORDER',
            pageSize: 10,
            remoteSort: true,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadVCustOrder
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'pCustOrderType', 'pCompanyUuid', 'pCustUuid', 'pCustOrderStatusUuid', 'pShippingStatusUuid', 'pPayStatusUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pCustOrderType: '',
                    pCompanyUuid: '',
                    pCustUuid: '',
                    pCustOrderStatusUuid: '',
                    pShippingStatusUuid: 'SS_INIT',
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
                property: 'CUST_ORDER_CR',
                direction: 'DESC'
            }]
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
            pageSize: 9999,
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
            pageSize: 9999,
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
            title: '訂單查詢',
            icon: SYSTEM_URL_ROOT + '/css/custimages/order16x16.png',
            frame: true,
            border: false,
            height: $(document).height() - 130,
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
                    xtype: 'combo',
                    fieldLabel: '客戶',
                    itemId: 'cmbCust',
                    margin: '0 0 0 20',
                    labelWidth: 30,
                    displayField: 'CUST_NAME',
                    valueField: 'CUST_UUID',
                    padding: 5,
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
                    labelWidth: 80,
                    width: 200,
                    editable: false,
                    hidden: false,
                    value: 'SS_INIT',
                    store: this.myStore.shippingStatus,
                    editable: false
                }, {
                    xtype: 'textfield',
                    fieldLabel: '關鍵字',
                    margin: '0 0 0 20',
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
                    margin: '0 0 0 20',
                    itemId: 'btnQuery',
                    width: 80,
                    handler: function() {
                        var store = this.up('panel').down("#grdVCustOrder").getStore(),
                            doSomeghing = function(obj, pl) {
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
                    width: 80,
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
                store: this.myStore.vcustorder,
                itemId: 'grdVCustOrder',
                border: true,
                height: $(document).height() - 200,
                padding: '5 15 5 5',
                selModel: new Ext.selection.CheckboxModel({
                    mode: 'MULTI',
                    checkOnly: true,
                    renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
                        if (record.data.SHIPPING_STATUS_UUID == "SS_INIT") {
                            return '<div class="x-grid-row-checker" role="presentation">&nbsp;</div>';
                        } else {
                            return "";
                        };
                    }
                }),
                listeners: {

                },
                columns: [{
                        header: '製單日期',
                        dataIndex: 'CUST_ORDER_REPORT_DATE',
                        align: 'left',
                        hidden: false,
                        width: 100
                    }, {
                        header: "訂單編號",
                        dataIndex: 'CUST_ORDER_ID',
                        align: 'left',
                        width: 110
                    }, {
                        header: "客戶名稱",
                        dataIndex: 'CUST_NAME',
                        align: 'left',
                        minWidth: 150,
                        flex:1
                    }, {
                        header: "單位",
                        dataIndex: 'CUST_ORDER_DEPT',
                        align: 'left',
                        width: 150
                    }, {
                        header: '採購人員',
                        dataIndex: 'CUST_ORG_SALES_NAME',
                        align: 'left',
                        width: 70
                    }, {
                        header: '聯絡電話',
                        dataIndex: 'CUST_ORG_SALES_PHONE',
                        align: 'left',
                        width: 70,
                        hidden: false
                    }, {
                        header: '金額',
                        dataIndex: 'CUST_ORDER_TOTAL_PRICE',
                        align: 'right',
                        width: 80,
                        renderer: function (value,r) {                            
                            return Ext.String.format('${0}', value);
                        }                
                    }, {
                        header: "請示單號",
                        dataIndex: 'CUST_ORDER_PS_NUMBER',
                        align: 'left',
                        width: 80
                    }, {
                        xtype: 'templatecolumn',
                        header: '報價公司',
                        dataIndex: 'COMPANY_C_NAME',
                        align: 'right',
                        tpl: new Ext.XTemplate(
                            "<tpl >",
                            '{[this.fnShowName(values)]}',
                            "</tpl>", {
                                fnShowName: function(values) {
                                    return values.COMPANY_C_NAME.substr(0,2);
                                }
                            }),
                        minWidth:70,
                        maxWidth:100,
                        flex: 1
                    },
                    {
                         header: "製單人",
                        dataIndex: 'CUST_ORDER_REPORT_ATTENDANT_C_NAME',
                        align: 'left',
                        width: 70
                    },
                    // {
                    //     text: "編輯",
                    //     xtype: 'actioncolumn',
                    //     dataIndex: 'UUID',
                    //     align: 'center',
                    //     minWidth: 60,
                    //     flex: 1,
                    //     items: [{
                    //         tooltip: '*編輯',
                    //         icon: SYSTEM_URL_ROOT + '/css/images/edit16x16.png',
                    //         handler: function(grid, rowIndex, colIndex) {

                    //         }
                    //     }],
                    //     sortable: false,
                    //     hideable: false
                    // },
                    {
                        xtype: 'templatecolumn',
                        text: '編輯',
                        width: 60,
                        tpl: new Ext.XTemplate(
                            "<tpl >",
                            '{[this.fnInit()]}<input type="button" style="width:50px" value="編輯" onclick="CustOrderQueryPanelFnEdit(\'{CUST_ORDER_UUID}\',\'{CUST_UUID}\')"/>',
                            "</tpl>", {
                                fnInit: function() {
                                    if (!document.CustOrderQueryPanelFnEdit) {
                                        document.CustOrderQueryPanelFnEdit = function(CUST_ORDER_UUID, CUST_UUID) {
                                            var main = WS_CUSTORDERQUERYPANEL;

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

                                            subWin.on('closeEvent', function(obj) {
                                                main.down("#grdVCustOrder").getStore().load();
                                            }, main);

                                            subWin.param.custOrderUuid = CUST_ORDER_UUID;
                                            subWin.param.custUuid = CUST_UUID;
                                            subWin.show();
                                        }
                                    }

                                }
                            }),

                    }, {
                        xtype: 'templatecolumn',
                        text: '報價單',
                        width: 60,
                        tpl: new Ext.XTemplate(
                            "<tpl >",
                            '{[this.fnInit()]}<input type="button" style="width:50px" value="列印" onclick="CustOrderQueryPanelFnPrintOrder(\'{COMPANY_C_NAME}\',\'{CUST_ORDER_UUID}\')"/>',
                            "</tpl>", {
                                fnInit: function() {
                                    if (!document.CustOrderQueryPanelFnPrintOrder) {
                                        document.CustOrderQueryPanelFnPrintOrder = function(COMPANY_C_NAME, CUST_ORDER_UUID) {
                                            if (COMPANY_C_NAME == '利旻禮品文具有限公司') {

                                                WS.CustAction.pdfLimew(CUST_ORDER_UUID, function(obj, jsonObj) {
                                                    if (jsonObj.result.success) {
                                                        var downloadUrl = SYSTEM_URL_ROOT + '/upload/custOrder/' + jsonObj.result.file;
                                                        window.open(downloadUrl);
                                                    }
                                                });
                                            } else if (COMPANY_C_NAME == '韋成企業商行') {
                                                WS.CustAction.pdfW(CUST_ORDER_UUID, function(obj, jsonObj) {
                                                    if (jsonObj.result.success) {
                                                        var downloadUrl = SYSTEM_URL_ROOT + '/upload/custOrder/' + jsonObj.result.file;
                                                        window.open(downloadUrl);
                                                    }
                                                });
                                            } else if (COMPANY_C_NAME == '裕寶企業商行') {
                                                WS.CustAction.pdfU(CUST_ORDER_UUID, function(obj, jsonObj) {
                                                    if (jsonObj.result.success) {
                                                        var downloadUrl = SYSTEM_URL_ROOT + '/upload/custOrder/' + jsonObj.result.file;
                                                        window.open(downloadUrl);
                                                    }
                                                });
                                            }
                                        }
                                    }
                                }
                            })

                    }, {
                        xtype: 'templatecolumn',
                        text: '出貨單',
                        width: 60,
                        tpl: new Ext.XTemplate(
                            "<tpl >",
                            '{[this.fnInit()]}<input type="button" style="width:50px" value="列印" onclick="CustOrderQueryPanelFnPrintShipping(\'{CUST_ORDER_UUID}\')"/>',
                            "</tpl>", {
                                fnInit: function() {
                                    if (!document.CustOrderQueryPanelFnPrintShipping) {
                                        document.CustOrderQueryPanelFnPrintShipping = function(CUST_ORDER_UUID) {
                                            WS.CustAction.pdfShipping(CUST_ORDER_UUID, function(obj, jsonObj) {
                                                if (jsonObj.result.success) {
                                                    var downloadUrl = SYSTEM_URL_ROOT + '/upload/shipping/' + jsonObj.result.file;
                                                    window.open(downloadUrl);
                                                }
                                            });
                                        }
                                    }
                                }
                            })
                    }, {
                        header: "出貨編號",
                        dataIndex: 'CUST_ORDER_SHIPPING_NUMBER',
                        align: 'left',
                        width: 150,
                        hidden: true
                    }, {
                        header: "出貨地址",
                        dataIndex: 'SHIPPING_ADDRESS',
                        align: 'left',
                        width: 150,
                        hidden: true
                    }, {
                        header: "公司電話",
                        align: 'left',
                        dataIndex: 'CUST_TEL',
                        width: 120,
                        hidden: true
                    }, {
                        header: "傳真",
                        dataIndex: 'CUST_FAX',
                        align: 'left',
                        flex: 1,
                        hidden: true
                    }, {
                        header: '地址',
                        dataIndex: 'CUST_ADDRESS',
                        align: 'left',
                        width: 150,
                        hidden: true
                    }, {
                        header: '採購員email',
                        dataIndex: 'CUST_SALES_EMAIL',
                        align: 'left',
                        width: 120,
                        hidden: true
                    }, {
                        header: '備註',
                        dataIndex: 'CUST_ORDER_PS',
                        align: 'left',
                        width: 200,
                        hidden: true

                    }, {
                        header: '等級',
                        dataIndex: 'CUST_LEVEL',
                        align: 'center',
                        flex: 1,
                        hidden: true
                    }, {
                        header: '最近採購日',
                        dataIndex: 'CUST_LAST_BUY',
                        align: 'left',
                        flex: 1,
                        hidden: true
                    }
                ],
                tbarCfg: {
                    buttonAlign: 'right'
                },
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.vcustorder,
                    displayInfo: true,
                    displayMsg: '第{0}~{1}資料/共{2}筆',
                    emptyMsg: "無資料顯示"
                }),
                tbar: [{
                    icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                    text: '新增(報價單)',
                    handler: function() {
                        var main = this.up('panel').up('panel').up('panel');
                        if (!main.fnCheckSubWindowns()) {
                            Ext.MessageBox.show({
                                title: '系統訊息',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                msg: '未實現 subWinCustOrder 物件,無法進行編輯操作!'
                            });
                            return false;
                        };

                        WS.CustAction.createCustOrder(function(obj, jsonObj) {
                            if (jsonObj.result.success && jsonObj.result.CUST_ORDER_UUID) {
                                var subWin = Ext.create(main.subWinCustOrder, {
                                    param: {
                                        custOrderUuid: jsonObj.result.CUST_ORDER_UUID,
                                        custUuid: undefined,
                                        parentObj: this
                                    }
                                });

                                subWin.on('closeEvent', function(obj) {
                                    main.down("#grdVCustOrder").getStore().load();

                                }, this);
                                subWin.show();
                            }
                        }, main);

                        /*註冊事件*/

                    }
                }, {
                    xtype: 'tbfill'
                }, {
                    icon: SYSTEM_URL_ROOT + '/css/images/okA16x16.png',
                    text: '出貨處理',
                    handler: function() {
                        var main = this.up('panel').up('panel').up('panel'),
                            grid = main.down('#grdVCustOrder'),
                            selectRecord = grid.getSelection();

                        //console.log( main.down('#grdVCustOrder').getSelection() );

                        if (selectRecord.length == 0) {
                            Ext.MessageBox.show({
                                title: '操作提示',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                msg: '請先選擇預出貨的訂單。'
                            });
                        } else {

                            /*canred要先檢查出貨地址是否有維護*/
                            var postData = '';
                            //var hasAddressEmpty = false;
                            Ext.each(selectRecord, function(item) {
                                //if (!Ext.isEmpty(item.data.SHIPPING_ADDRESS)) {
                                postData += item.data.CUST_ORDER_UUID + "|";
                                //} else {                                  
                                //    hasAddressEmpty = true;
                                //};
                            });

                            // if (hasAddressEmpty == true) {
                            //     Ext.MessageBox.show({
                            //         title: '操作提示',
                            //         icon: Ext.MessageBox.INFO,
                            //         buttons: Ext.Msg.OK,
                            //         msg: '請檢查訂單出貨地址，發現有空的出貨地址!'
                            //     });
                            //     return;
                            // };

                            WS.CustAction.shippingInProcessCustOrder(postData, function(obj, jsonObj) {
                                if (jsonObj.result.success && jsonObj.result.success == true) {
                                    var shippCount = jsonObj.result.shippingCount;
                                    if (shippCount > 0) {
                                        Ext.MessageBox.show({
                                            title: '完成出貨處理',
                                            icon: Ext.MessageBox.INFO,
                                            buttons: Ext.Msg.OK,
                                            msg: '完成' + shippCount + '筆訂單完成出貨處理。',
                                            scope: this,
                                            fn: function() {
                                                this.myStore.vcustorder.reload();
                                            }
                                        });
                                    }
                                }
                            }, main);
                        };


                        /*註冊事件*/

                    }
                }]
            }]

        }];
        this.callParent(arguments);
    },
    listeners: {
        afterrender: function(obj, eOpts) {
            this.myStore.cust.load({
                scope: this
            });

            this.myStore.vcustorder.load({
                scope: this
            });

            this.myStore.company.load({
                scope: this
            });

            this.myStore.custOrderStatus.load({
                scope: this
            });

            this.myStore.shippingStatus.load({
                scope: this
            });

        }
    }
});
