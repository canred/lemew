/*全局變量*/

/*WS.SupplierQueryPanel物件類別*/
/*TODO*/
/*
1.Model 要集中                                 [YES]
2.panel 的title要換成icon , title的方式        [YES]
3.add 的icon要換成icon , title的方式           [YES]
4.自動Query 資料                               [YES]
*/
/*columns 使用default*/
Ext.define('WS.CustOrderInInvoicePickerWindow', {
    extend: 'Ext.window.Window',
    closeAction: 'destroy',
    width: 800,
    height: 600,
    modal: true,
    lan: {},
    param: {
        custUuid: undefined,
        startDate: undefined,
        endDate: undefined
    },
    val: {},
    title: '挑選待付款訂單',
    icon: SYSTEM_URL_ROOT + '/css/custimages/moneyB16x16.png',
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
            pageSize: 99999,
            remoteSort: true,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadVCustOrderByDate
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'pCustOrderType', 'pCompanyUuid', 'pCustUuid', 'pCustOrderStatusUuid', 'pShippingStatusUuid', 'pPayStatusUuid', 'start_date', 'end_date', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pCustOrderType: '',
                    pCompanyUuid: '',
                    pCustUuid: '',
                    pCustOrderStatusUuid: '',
                    pShippingStatusUuid: '',
                    pPayStatusUuid: 'pay_status_1',
                    start_date: '',
                    end_date: ''
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


        payMethod: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: true,
            model: 'PAY_METHOD',
            remoteSort: true,
            pageSize: 9999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.PayMethodAction.loadPayMethod
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    'pKeyword': ''
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
                property: 'PAY_METHOD_ORD',
                direction: 'ASC'
            }]
        }),
        payStatus: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: Ext.define('VGhgFile', {
                extend: 'Ext.data.Model',
                /*:::欄位設定:::*/
                fields: ['COLUMN_A', 'COLUMN_B']
            }),
            remoteSort: true,
            pageSize: 9999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.PayStatusAction.loadPayStatus
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    'pKeyword': ''
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
            listeners: {
                load: function(store, records, sucessful, eOpts) {
                    store.insert(0, {
                        'PAY_STATUS_UUID': 'pay_status_1',
                        'PAY_STATUS_NAME': '--'
                    });
                }
            },
            sorters: [{
                property: 'PAY_STATUS_ORD',
                direction: 'ASC'
            }]
        })
    },
    fnActiveRender: function isActiveRenderer(value, id, r) {
        var html = "<img src='" + SYSTEM_URL_ROOT;
        return value === "Y" ? html + "/css/custimages/active03.png'>" : html + "/css/custimages/unactive03.png'>";
    },

    initComponent: function() {

        this.items = [{
            xtype: 'panel',

            frame: true,
            border: false,
            height: 600,
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
                        fieldLabel: '客戶',
                        itemId: 'cmbCust',
                        margin: '0 0 0 20',
                        labelWidth: 30,
                        displayField: 'CUST_NAME',
                        valueField: 'CUST_UUID',
                        padding: 5,
                        editable: false,
                        readOnly: true,
                        hidden: false,
                        value: '',
                        store: this.myStore.cust,
                        editable: false
                    },

                    {
                        xtype: 'datefield',
                        fieldLabel: '訂單期間',
                        value: new Date(),
                        labelWidth: 80,
                        width: 190,
                        format: 'Y/m/d',
                        submitFormat: 'Y/m/d',
                        readOnly:true,
                        //name: 'CUST_ORDER_REPORT_DATE',
                        itemId: 'dfStartDate',
                        labelAlign: 'right',
                        renderer: function(value, r) {
                            return '1999/01/01';
                        },
                        render: function() {
                            return '1998/01/01'
                        }
                    }, {
                        html: '~'
                    }, {
                        xtype: 'datefield',
                        value: new Date(),
                        width: 110,readOnly:true,
                        format: 'Y/m/d',
                        submitFormat: 'Y/m/d',
                        labelAlign: 'right',
                        itemId: 'dfEndDate',
                        renderer: function(value, r) {
                            return '1999/01/01';
                        },
                        render: function() {
                            return '1998/01/01'
                        }
                    },

                    {
                        xtype: 'textfield',
                        fieldLabel: '關鍵字',
                        margin: '0 0 0 20',
                        itemId: 'txt_search',
                        labelWidth: 50,
                        width: 130,
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
                                doSomeghing = function(obj, mainWindow) {
                                    obj.getProxy().setExtraParam('pCustOrderType', mainWindow.down("#cmbCustOrderType").getValue());
                                    obj.getProxy().setExtraParam('pCustUuid', mainWindow.down("#cmbCust").getValue());
                                    obj.getProxy().setExtraParam('pKeyword', mainWindow.down("#txt_search").getValue());
                                    obj.getProxy().setExtraParam('pPayStatusUuid', 'pay_status_1');

                                    obj.getProxy().setExtraParam('start_date', mainWindow.down('#dfStartDate').getValue());

                                    obj.getProxy().setExtraParam('end_date', mainWindow.down('#dfEndDate').getValue());
                                    obj.loadPage(1);
                                }(store, this.up('window'));
                        }
                    }
                ]
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
                selModel: new Ext.selection.CheckboxModel({
                    mode: 'MULTI',
                    checkOnly: true,
                    renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
                        if (record.data.PAY_STATUS_UUID != "pay_status_3") {
                            return '<div class="x-grid-row-checker" role="presentation">&nbsp;</div>';
                        } else {
                            return "";
                        };
                    },
                    listeners: {
                        selectionchange: function(selectionModel, selected, options) {}
                    }
                }),
                itemId: 'grdVCustOrder',
                border: true,
                height: 500,
                padding: '5 15 5 5',
                columns: [{
                    xtype: 'templatecolumn',
                    text: '查看',
                    width: 60,
                    sortable: false,
                    hideable: false,
                    tpl: new Ext.XTemplate(
                        "<tpl >",
                        '{[this.fnInit()]}<input type="button" style="width:50px" value="查看" onclick="CustWindowFnView2(\'{CUST_ORDER_UUID}\',\'{CUST_UUID}\')"/>',
                        "</tpl>", {
                            scope: this,
                            fnInit: function() {
                                document
                                    .CustWindow = this.scope;
                                if (!document.CustWindowFnView2) {
                                    document.CustWindowFnView2 = function(CUST_ORDER_UUID, CUST_UUID) {
                                        var main = document.CustWindow;
                                        var subWin = Ext.create('WS.CustOrderStep1ViewWindow', {});
                                        subWin.on('closeEvent', function(obj) {}, main);
                                        subWin.param.custOrderUuid = CUST_ORDER_UUID;
                                        subWin.param.custUuid = CUST_UUID;
                                        subWin.show();
                                    }
                                }

                            }
                        }),

                }, {
                    header: "訂單編號",
                    dataIndex: 'CUST_ORDER_ID',
                    align: 'left',
                    width: 110
                }, {
                    header: '製單日期',
                    dataIndex: 'CUST_ORDER_REPORT_DATE',
                    align: 'left',
                    width: 80
                }, {
                    header: "客戶名稱",
                    dataIndex: 'CUST_NAME',
                    align: 'left',
                    width: 150,hidden:true
                }, {
                    header: "單位",
                    dataIndex: 'CUST_ORDER_DEPT',
                    align: 'left',
                    width: 100,
                    hidden: false
                }, {
                    header: "客戶電話",
                    align: 'left',
                    hidden: true,
                    dataIndex: 'CUST_TEL',
                    width: 120
                }, {
                    header: '採購員',
                    dataIndex: 'CUST_ORG_SALES_NAME',
                    align: 'left',
                    width: 70
                }, {
                    header: '聯絡電話',
                    dataIndex: 'CUST_ORG_SALES_PHONE',
                    align: 'left',
                    width: 100,
                    hidden: true
                }, {
                    header: '金額',
                    dataIndex: 'CUST_ORDER_TOTAL_PRICE',
                    align: 'right',
                    width: 80,renderer: function (value,r) {                            
                            return Ext.String.format('${0}', value);
                        }  
                }, {
                    header: '付款狀態',
                    dataIndex: 'PAY_STATUS_NAME',
                    width: 80
                }, {
                    header: '款項方式',
                    width: 100,
                    dataIndex: 'PAY_METHOD_NAME',
                }, {
                    header: '款項備註',
                    dataIndex: 'CUST_ORDER_PAY_PS',
                    align: 'right',
                    width: 140,
                    layout: 'hbox',
                }, {
                    header: '發票號碼',
                    dataIndex: 'CUST_ORDER_INVOICE_NUMBER',
                    align: 'right',
                    width: 140,
                    layout: 'hbox',
                }, {
                    header: "出貨編號",
                    dataIndex: 'CUST_ORDER_SHIPPING_NUMBER',
                    align: 'left',
                    width: 120
                }, {
                    header: "出貨地址",
                    dataIndex: 'SHIPPING_ADDRESS',
                    align: 'left',
                    width: 150
                }, {
                    header: '採購員電話',
                    dataIndex: 'CUST_SALES_PHONE',
                    align: 'left',
                    flex: 1,
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
                    flex: 1,
                    hidden: true
                }, {
                    header: '出貨狀態',
                    dataIndex: 'SHIPPING_STATUS_NAME',
                    align: 'left',
                    flex: 1,
                    minWidth: 70
                }, {

                    header: '備註',
                    dataIndex: 'CUST_ORDER_PS',
                    align: 'left',
                    width: 140,
                    layout: 'hbox'
                }],
                fbar: [{
                    type: 'button',
                    text: '選擇確定',
                    handler: function() {
                        var mainWindow = this.up('window'),
                            grid = mainWindow.down("#grdVCustOrder");
                        if (grid.selModel.getSelection().length > 0) {
                            mainWindow.fireEvent('selectCustOrder', mainWindow, grid.selModel.getSelection());
                        } else {
                            Ext.MessageBox.show({
                                title: '系統提示',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                msg: '請先勾選訂單'
                            });
                        }

                        //grid.selModel.getSelection()
                    }
                }]
            }]

        }];
        this.callParent(arguments);
    },
    listeners: {

        afterrender: function(obj, eOpts) {

            if (Ext.isEmpty(this.param.custUuid)) {
                alert('參數錯誤');
            };

            this.myStore.cust.load({
                callback: function() {
                    if (!Ext.isEmpty(this.param.custUuid)) {
                        this.down('#cmbCust').setValue(this.param.custUuid);
                    };
                },
                scope: this
            });

            this.down('#dfStartDate').setValue(this.param.startDate);
            this.down('#dfEndDate').setValue(this.param.endDate);

            this.myStore.vcustorder.getProxy().setExtraParam('pCustUuid', this.param.custUuid);
            this.myStore.vcustorder.getProxy().setExtraParam('start_date', this.param.startDate);
            this.myStore.vcustorder.getProxy().setExtraParam('end_date', this.param.endDate);
            this.myStore.vcustorder.load({
                scope: this
            });

            this.myStore.payStatus.load({
                scope: this
            });

        }
    }
});
