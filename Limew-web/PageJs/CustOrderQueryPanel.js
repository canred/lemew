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
                        'CUST_NAME': '---'
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
                paramOrder: ['pCustOrderStatus', 'pCustUuid', 'pKeyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    'pCustOrderStatus': '',
                    'pCustUuid': '',
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
                property: 'CUST_ORDER_CR',
                direction: 'DESC'
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
            height: $(document).height() - 150,
            autoWidth: true,
            padding: '5 0 5 5',
            items: [{
                xtype: 'container',
                layout: 'hbox',
                margin: '5 0 0 5',
                items: [{
                    xtype: 'combo',
                    fieldLabel: '訂單狀態',
                    queryMode: 'local',
                    itemId: 'cmbCustOrder',
                    displayField: 'text',
                    valueField: 'value',
                    labelWidth: 60,
                    padding: 5,
                    editable: false,
                    hidden: false,
                    value: '',
                    store: new Ext.data.ArrayStore({
                        fields: ['text', 'value'],
                        data: [
                            ['全部', ''],
                            ['報價單', 'A'],
                            ['訂單', 'B'],
                            ['訂單(出貨)', 'C'],
                            ['訂單(應收)', 'D'],
                            ['訂單(完成)', 'E']
                        ]
                    }),
                    editable: false
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
                    xtype: 'textfield',
                    fieldLabel: '關鍵字',
                    margin: '0 0 0 20',
                    itemId: 'txt_search',
                    labelWidth: 50,
                    enableKeyEvents: true,
                    listeners: {
                        keyup: function(e, t, eOpts) {
                            var keyCode = t.parentEvent.keyCode;
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
                                obj.getProxy().setExtraParam('pCustOrderStatus', pl.down("#cmbCustOrder").getValue());
                                obj.getProxy().setExtraParam('pCustUuid', pl.down("#cmbCust").getValue());
                                obj.getProxy().setExtraParam('pKeyword', pl.down("#txt_search").getValue());
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
                        mainPanel.down("#cmbCustOrder").setValue('');
                        mainPanel.down("#cmbCust").setValue('');
                    }
                }]
            }, {
                xtype: 'gridpanel',
                store: this.myStore.vcustorder,
                itemId: 'grdVCustOrder',
                border: true,
                height: $(document).height() - 240,
                padding: '5 15 5 5',
                columns: [{
                    text: "編輯",
                    xtype: 'actioncolumn',
                    dataIndex: 'UUID',
                    align: 'center',
                    width: 60,
                    items: [{
                        tooltip: '*編輯',
                        icon: SYSTEM_URL_ROOT + '/css/images/edit16x16.png',
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
                            Ext.getBody().mask();
                            subWin.on('closeEvent', function(obj) {
                                main.down("#grdVCustOrder").getStore().load();
                                Ext.getBody().unmask();
                            }, main);
                            subWin.param.custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                            subWin.param.custUuid = grid.getStore().getAt(rowIndex).data.CUST_UUID;
                            subWin.show();
                        }
                    }],
                    sortable: false,
                    hideable: false
                }, {
                    header: "訂單編號",
                    dataIndex: 'CUST_ORDER_ID',
                    align: 'left',
                    flex: 1
                }, {
                    header: "公司名稱",
                    dataIndex: 'CUST_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    header: "電話",
                    align: 'left',
                    dataIndex: 'CUST_TEL',
                    flex: 1
                }, {
                    header: "傳真",
                    dataIndex: 'CUST_FAX',
                    align: 'left',
                    flex: 1
                }, {
                    header: '地址',
                    dataIndex: 'CUST_ADDRESS',
                    align: 'center',
                    flex: 1
                }, {
                    header: '採購員',
                    dataIndex: 'CUST_SALES_NAME',
                    align: 'center',
                    flex: 1
                }, {
                    header: '採購員電話',
                    dataIndex: 'CUST_SALES_PHONE',
                    align: 'center',
                    flex: 1
                }, {
                    header: '採購員email',
                    dataIndex: 'CUST_SALES_EMAIL',
                    align: 'center',
                    flex: 1
                }, {
                    header: '備註',
                    dataIndex: 'CUST_PS',
                    align: 'center',
                    flex: 1
                }, {
                    header: '等級',
                    dataIndex: 'CUST_LEVEL',
                    align: 'center',
                    flex: 1
                }, {
                    header: '最近採購日',
                    dataIndex: 'CUST_LAST_BUY',
                    align: 'center',
                    flex: 1
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
                        /*註冊事件*/
                        var subWin = Ext.create(main.subWinCustOrder, {
                            param: {
                                custOrderUuid: undefined,
                                custUuid:undefined,
                                parentObj:main
                            }
                        });
                        Ext.getBody().mask();
                        subWin.on('closeEvent', function(obj) {
                            main.down("#grdVCustOrder").getStore().load();
                            Ext.getBody().unmask();
                        }, main);
                        subWin.show();
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

        }
    }
});
