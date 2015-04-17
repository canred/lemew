/*全局變量*/
var WS_CUSTORDERINVOICEQUERYPANEL;
/*WS.SupplierQueryPanel物件類別*/
/*TODO*/
/*
1.Model 要集中                                 [YES]
2.panel 的title要換成icon , title的方式        [YES]
3.add 的icon要換成icon , title的方式           [YES]
4.自動Query 資料                               [YES]
*/
/*columns 使用default*/
Ext.define('WS.CustOrderInvoiceQueryPanel', {
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
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadCust
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: ''
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
                // paramOrder: ['pCustOrderStatus', 'pCustUuid', 'pKeyword', 'page', 'limit', 'sort', 'dir'],
                // extraParams: {
                //     'pCustOrderStatus': '',
                //     'pCustUuid': '',
                //     'pKeyword': ''
                // },
                paramOrder: ['pKeyword', 'pCustOrderType', 'pCompanyUuid', 'pCustUuid', 'pCustOrderStatusUuid', 'pShippingStatusUuid', 'pPayStatusUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pCustOrderType: '',
                    pCompanyUuid: '',
                    pCustUuid: '',
                    pCustOrderStatusUuid: '',
                    pShippingStatusUuid: '',
                    pPayStatusUuid: 'pay_status_1'
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
        }),
        payMethod: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: true,
            model: 'PAY_METHOD',
            remoteSort: true,
            pageSize: 10,
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
            pageSize: 10,
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
            title: '款項訂單查詢',
            icon: SYSTEM_URL_ROOT + '/css/custimages/order16x16.png',
            frame: true,
            border: false,
            height: $(document).height() - 150,
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
                    labelWidth: 60,
                    width: 150,
                    editable: false,
                    hidden: true,
                    store: this.myStore.shippingStatus,
                    editable: false
                }, {
                    xtype: 'combo',
                    fieldLabel: '付款狀態',
                    queryMode: 'local',
                    itemId: 'cmbPayStatus',
                    displayField: 'PAY_STATUS_NAME',
                    valueField: 'PAY_STATUS_UUID',
                    labelWidth: 80,
                    width: 180,
                    editable: false,
                    hidden: false,
                    value: 'pay_status_1',
                    store: this.myStore.payStatus,
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


                                obj.getProxy().setExtraParam('pShippingStatusUuid', '');
                                obj.getProxy().setExtraParam('pPayStatusUuid', pl.down("#cmbPayStatus").getValue());
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
                        mainPanel.down("#cmbPayStatus").setValue('');

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
                plugins: {
                    ptype: 'cellediting',
                    clicksToEdit: 1,
                    listeners: {
                        beforeedit: function(editor, context, eOpts) {
                            var mainPanel = context.grid.up('panel').up('panel');
                            mainPanel.param.editRecord = context.record;
                            mainPanel.param.editRowIdx = context.rowIdx;
                            mainPanel.param.editColIdx = context.colIdx;
                            //c/onsole.log(mainPanel.param);
                        },
                        edit: function(editor, context, eOpts) {
                            var mainPanel = context.grid.up('panel').up('panel');
                            //mainPanel.param.editRecord = context.record;
                            mainPanel.param.editRowIdx = context.rowIdx;
                            mainPanel.param.editColIdx = context.colIdx;
                            //mainPanel.fnCal(mainPanel);
                        }
                    }
                },
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
                height: $(document).height() - 240,
                padding: '5 15 5 5',
                columns: [{
                    text: "",
                    xtype: 'actioncolumn',
                    dataIndex: 'UUID',
                    align: 'center',
                    width: 30,
                    items: [{
                        tooltip: '*查看',
                        icon: SYSTEM_URL_ROOT + '/css/custimages/view16x16.png',
                        handler: function(grid, rowIndex, colIndex) {
                            var main = grid.up('panel').up('panel').up('panel');
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
                            subWin.param.custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                            subWin.param.custUuid = grid.getStore().getAt(rowIndex).data.CUST_UUID;
                            subWin.show();
                        }
                    }],
                    sortable: false,
                    hideable: false
                }, {
                    text: "",
                    xtype: 'actioncolumn',
                    dataIndex: 'UUID',
                    align: 'center',
                    width: 30,
                    items: [{
                        tooltip: '*退回到出貨狀態',
                        icon: SYSTEM_URL_ROOT + '/css/custimages/back16x16.png',
                        handler: function(grid, rowIndex, colIndex) {
                            var main = grid.up('panel').up('panel').up('panel');
                            var custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                            Ext.MessageBox.confirm('請確認', '將此單退回到出貨狀態?', function(result) {
                                if (result == 'yes') {
                                    WS.CustAction.backToShipping(custOrderUuid, function(obj, jsonObj) {
                                        //alert(jsonObj.result.CUST_ORDER_UUID);
                                        var findData = this.myStore.vcustorder.findRecord("CUST_ORDER_UUID", jsonObj.result.CUST_ORDER_UUID);
                                        this.myStore.vcustorder.remove(findData);
                                    }, this);
                                }
                            }, main);


                        }
                    }],
                    sortable: false,
                    hideable: false
                }, {
                    header: '建立日期',
                    dataIndex: 'CUST_ORDER_CR',
                    align: 'left',
                    width: 100
                }, {
                    header: "公司名稱",
                    dataIndex: 'CUST_NAME',
                    align: 'left',
                    width: 150
                }, {
                    header: "單位",
                    dataIndex: 'CUST_ORDER_DEPT',
                    align: 'left',
                    width: 150,
                    hidden: true
                }, {
                    header: "公司電話",
                    align: 'left',
                    dataIndex: 'CUST_TEL',
                    width: 120
                }, {
                    header: '採購員',
                    dataIndex: 'CUST_ORG_SALES_NAME',
                    align: 'left',
                    width: 80
                }, {
                    header: '聯絡電話',
                    dataIndex: 'CUST_ORG_SALES_PHONE',
                    align: 'left',
                    width: 120,
                    hidden: false
                }, {
                    header: '金額',
                    dataIndex: 'CUST_ORDER_TOTAL_PRICE',
                    align: 'right',
                    width: 80
                }, {
                    header: '付款狀態',
                    dataIndex: 'PAY_STATUS_NAME'
                }, {
                    //xtype:'combo',
                    header: '款項方式',
                    width: 100,
                    dataIndex: 'PAY_METHOD_UUID',
                    renderer: function(value, r) {
                        return r.record.data.PAY_METHOD_NAME;
                    },
                    editor: {
                        xtype: 'combo',
                        allowBlank: false,
                        displayField: 'PAY_METHOD_NAME',
                        valueField: 'PAY_METHOD_UUID',
                        store: this.myStore.payMethod,
                        editable: false,
                        hidden: false,
                        listeners: {
                            change: function(obj, newValue, oldValue, eOpts) {
                                var mainPanel = obj.up('panel').up('panel').up('panel');
                                if (Ext.isEmpty(newValue)) {
                                    return true;
                                };
                                var dr = obj.getStore().findRecord("PAY_METHOD_UUID", newValue).data;
                                mainPanel.param.editRecord.data.PAY_METHOD_NAME = dr.PAY_METHOD_NAME;
                            }
                        }
                    }
                }, {
                    xtype: 'templatecolumn',
                    header: '發票號碼',
                    dataIndex: 'CUST_ORDER_INVOICE_NUMBER',
                    align: 'right',
                    width: 140,
                    layout: 'hbox',
                    tpl: '<input type="text" readonly style="width:130px" value="{CUST_ORDER_INVOICE_NUMBER}"/>',
                    // tpl: new Ext.XTemplate(
                    // "<tpl if='SHIPPING_STATUS_UUID == \"SS_INPROCESS\"'>",
                    // '<input type="text" style="width:130px" value="{CUST_ORDER_INVOICE_NUMBER}"/>'),
                    // "<tpl else>",
                    // '{CUST_ORDER_INVOICE_NUMBER}',
                    // "</tpl>"),                               
                    editor: {
                        xtype: 'textfield',
                        flex: 1,
                        listeners: {
                            focus: function(obj, eOpts) {
                                var mainPanel = obj.up('panel').up('panel').up('panel');


                                // if (mainPanel.param.editRecord.data.SHIPPING_STATUS_UUID != "SS_INPROCESS") {
                                //     obj.setReadOnly(true);
                                // } else {
                                //     obj.setReadOnly(false);
                                // }
                            }
                        }
                    }
                }, {
                    header: "訂單編號",
                    dataIndex: 'CUST_ORDER_ID',
                    align: 'left',
                    width: 150
                }, {
                    header: "出貨編號",
                    dataIndex: 'CUST_ORDER_SHIPPING_NUMBER',
                    align: 'left',
                    width: 150
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
                    flex: 1
                }, {
                    header: '備註',
                    dataIndex: 'CUST_ORDER_PS',
                    align: 'left',
                    flex: 1,
                    renderer: function (value,r) {
                        var id = Ext.id();
                        var mainPanel = this.up('panel').up('panel');

                        Ext.defer(function () {    
                            var s = {};
                            if(r.record.data.CUST_ORDER_PS.length>0){
                                s = {
                                    'background-color':'red'
                                }
                            };
                            Ext.widget('button', {
                                renderTo: id,
                                style:s,
                                text: '備註',
                                width: 50,
                                handler: function () {
                                    var subWin = Ext.create('WS.CustOrderPsWindow',{
                                        param:{
                                            custOrderUuid:r.record.data.CUST_ORDER_UUID,
                                            parentObj:mainPanel
                                        }
                                    });
                                    subWin.on('closeEvent',function(obj){
                                        obj.param.parentObj.myStore.vcustorder.reload();
                                    });
                                    subWin.show();
                                }
                            });  
                        }, 50);
                        return Ext.String.format('<div id="{0}"></div>', id);
                    }                
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
                }],
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
                    text: '全部儲存',
                    handler: function() {
                        var mainPanel = this.up('panel').up('panel').up('panel');
                        var updateData = "";
                        Ext.each(mainPanel.myStore.vcustorder.data.items, function(item) {
                            updateData += item.data.CUST_ORDER_UUID + "," + item.data.PAY_METHOD_UUID + "," + item.data.CUST_ORDER_INVOICE_NUMBER + "|";
                        });

                        WS.CustAction.batchUpdateCustOrderInvoice(updateData, function(obj, jsonObj) {
                            mainPanel.myStore.vcustorder.reload();
                        }, mainPanel);
                    }
                }, {
                    xtype: 'tbfill'
                }, {
                    xtype: 'button',
                    text: '付款完成',
                    icon: SYSTEM_URL_ROOT + '/css/images/okA16x16.png',
                    handler: function(handler, scope) {
                        var main = this.up('panel').up('panel').up('panel'),
                            grid = main.down('#grdVCustOrder'),
                            selectRecord = grid.getSelection();



                        //console.log( main.down('#grdVCustOrder').getSelection() );

                        if (selectRecord.length == 0) {
                            Ext.MessageBox.show({
                                title: '操作提示',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                msg: '請先選擇預訂單。'
                            });
                        } else {
                            //canred 要先檢查每一筆的付款方式，與發票號碼都不可以為空
                            if (main.myStore.vcustorder.getModifiedRecords().length > 0) {

                                var updateData = "";
                                Ext.each(main.myStore.vcustorder.data.items, function(item) {
                                    updateData += item.data.CUST_ORDER_UUID + "," + item.data.PAY_METHOD_UUID + "," + item.data.CUST_ORDER_INVOICE_NUMBER + "|";
                                });

                                WS.CustAction.batchUpdateCustOrderInvoice(updateData, function(obj, jsonObj) {
                                    var postData = '';
                                    var hasErrorData = false;
                                    Ext.each(selectRecord, function(item) {
                                        if (item.data.PAY_METHOD_UUID != "" && item.data.CUST_ORDER_INVOICE_NUMBER != "") {
                                            postData += item.data.CUST_ORDER_UUID + "|";
                                        } else {
                                            hasErrorData = true;
                                        }
                                    });

                                    if (hasErrorData) {
                                        Ext.MessageBox.show({
                                            title: '系統提示',
                                            icon: Ext.MessageBox.INFO,
                                            buttons: Ext.Msg.OK,
                                            msg: '有部份訂單的付款方式或發票號為空!'
                                        });
                                    };

                                    if (postData.length == 0) {
                                        return;
                                    };

                                    WS.CustAction.payCompleteCustOrder(postData, function(obj, jsonObj) {
                                        if (jsonObj.result.success && jsonObj.result.success == true) {
                                            var payCompleteCount = jsonObj.result.payCompleteCount;
                                            if (payCompleteCount > 0) {
                                                Ext.MessageBox.show({
                                                    title: '付款完成',
                                                    icon: Ext.MessageBox.INFO,
                                                    buttons: Ext.Msg.OK,
                                                    msg: payCompleteCount + '筆訂單付款完成。',
                                                    fn: function() {
                                                        this.myStore.vcustorder.reload();
                                                    },
                                                    scope: this
                                                });
                                            }
                                        }
                                    }, main);
                                    this.myStore.vcustorder.reload();
                                }, main);





                            } else {
                                var postData = '';
                                var hasErrorData = false;
                                Ext.each(selectRecord, function(item) {
                                    if (item.data.PAY_METHOD_UUID != "" && item.data.CUST_ORDER_INVOICE_NUMBER != "") {
                                        postData += item.data.CUST_ORDER_UUID + "|";
                                    } else {
                                        hasErrorData = true;
                                    }
                                });

                                if (hasErrorData) {
                                    Ext.MessageBox.show({
                                        title: '系統提示',
                                        icon: Ext.MessageBox.INFO,
                                        buttons: Ext.Msg.OK,
                                        msg: '有部份訂單的付款方式或發票號為空!'
                                    });
                                };

                                if (postData.length == 0) {
                                    return;
                                };

                                WS.CustAction.payCompleteCustOrder(postData, function(obj, jsonObj) {
                                    if (jsonObj.result.success && jsonObj.result.success == true) {
                                        var payCompleteCount = jsonObj.result.payCompleteCount;
                                        if (payCompleteCount > 0) {
                                            Ext.MessageBox.show({
                                                title: '付款完成',
                                                icon: Ext.MessageBox.INFO,
                                                buttons: Ext.Msg.OK,
                                                msg: payCompleteCount + '筆訂單付款完成。',
                                                fn: function() {
                                                    this.myStore.vcustorder.reload();
                                                },
                                                scope: this
                                            });
                                        }
                                    }
                                }, main);
                            }

                        };
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

            this.myStore.payStatus.load({
                scope: this
            });

        }
    }
});
