/*全局變量*/
var WS_MYORDERQUERYPANEL;
Ext.define('WS.MyOrderQueryPanel', {
    extend: 'Ext.panel.Panel',
    closeAction: 'destroy',
    subWinMyOrder: undefined,
    lan: {},
    val: {},
    myStore: {
        supplier: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: 'SUPPLIER',
            remoteSort: true,
            pageSize: 99999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.SupplierAction.loadSupplier
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword','pSupplierIsActive', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    'pKeyword': '',
                    pSupplierIsActive:'1|0'
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
                        'SUPPLIER_UUID': '',
                        'SUPPLIER_NAME': '全部'
                    });
                }
            },
            sorters: [{
                property: 'SUPPLIER_NAME',
                direction: 'ASC'
            }]
        }),
        myOrder: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'MY_ORDER',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.MyOrderAction.loadMyOrder
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'pSupplierUuid', 'pIsActive', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    'pKeyword': '',
                    'pSupplierUuid': '',
                    'pIsActive': '1'
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
                property: 'MY_ORDER_ID',
                direction: 'DESC'
            }]
        })
    },
    fnActiveRender: function isActiveRenderer(value, id, r) {
        var html = "<img src='" + SYSTEM_URL_ROOT;
        return value === "1" ? html + "/css/custimages/active03.png'>" : html + "/css/custimages/unactive03.png'>";
    },
    fnCheckSubWindowns: function() {
        if (Ext.isEmpty(this.subWinMyOrder)) {
            Ext.MessageBox.show({
                title: '系統提示',
                icon: Ext.MessageBox.WARNING,
                buttons: Ext.Msg.OK,
                msg: '未實現 subWinMyOrder 物件,無法進行編輯操作!'
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
            title: '訂貨查詢',
            icon: SYSTEM_URL_ROOT + '/css/custimages/Record16x16.png',
            frame: true,
            border: false,
            height: $(document).height() - 130,
            autoWidth: true,
            padding: '5 0 5 5',
            items: [{
                xtype: 'container',
                layout: 'hbox',
                margin: '5 0 0 5',
                items: [{
                    xtype: 'combo',
                    fieldLabel: '供應商名稱',
                    labelWidth: 70,
                    itemId: 'cmbSupplier',
                    displayField: 'SUPPLIER_NAME',
                    valueField: 'SUPPLIER_UUID',
                    editable: false,
                    hidden: false,
                    value: '',
                    store: this.myStore.supplier
                }, {
                    xtype: 'textfield',
                    fieldLabel: '關鍵字',
                    itemId: 'txt_search',
                    labelWidth: 50,
                    margin: '0 0 0 10',
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
                        var store = this.up('panel').down("#grdMyOrderQuery").getStore(),
                            doSomeghing = function(obj, pl) {
                                obj.getProxy().setExtraParam('pKeyword', pl.down("#txt_search").getValue());
                                obj.getProxy().setExtraParam('pSupplierUuid', pl.down("#cmbSupplier").getValue());
                                obj.loadPage(1);
                            }(store, this.up('panel').up('panel'));
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
                    }
                }]
            }, {
                xtype: 'gridpanel',
                store: this.myStore.myOrder,
                itemId: 'grdMyOrderQuery',
                border: true,
                height: $(document).height() - 200,
                padding: '5 15 5 5',
                columns: [{
                    text: "編輯",
                    xtype: 'actioncolumn',
                    dataIndex: 'MY_ORDER_UUID',
                    align: 'center',
                    width: 60,
                    items: [{
                        tooltip: '*編輯',
                        icon: SYSTEM_URL_ROOT + '/css/images/edit16x16.png',
                        handler: function(grid, rowIndex, colIndex) {
                            var main = grid.up('panel').up('panel').up('panel');
                            if (!main.subWinMyOrder) {
                                Ext.MessageBox.show({
                                    title: '系統訊息',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK,
                                    msg: '未實現 subWinMyOrder 物件,無法進行編輯操作!'
                                });
                                return false;
                            };
                            var subWin = Ext.create(main.subWinMyOrder, {
                                subWinMyOrderOrder: 'WS.MyOrderWindow',
                                param: {
                                    myOrderUuid: grid.getStore().getAt(rowIndex).data.MY_ORDER_UUID
                                }
                            });
                            subWin.on('closeEvent', function(obj) {
                                main.down("#grdMyOrderQuery").getStore().load();
                            }, main);
                            subWin.show();
                        }
                    }, {
                        tooltip: '*刪除',
                        icon: SYSTEM_URL_ROOT + '/css/custimages/delete16x16.png',
                        handler: function(grid, rowIndex, colIndex) {
                            var main = grid.up('panel').up('panel').up('panel');
                            Ext.MessageBox.confirm('刪除訂貨項目操作', '確定刪除這一個訂貨紀錄?', function(result) {
                                if (result == 'yes') {
                                    WS.MyOrderAction.destoryMyOrder(grid.getStore().getAt(rowIndex).data.MY_ORDER_UUID, function(obj, jsonObj) {
                                        if (jsonObj.result.success) {
                                            this.myStore.myOrder.reload();
                                        }
                                    }, this);
                                }
                            }, main);
                        }
                    }],
                    sortable: false,
                    hideable: false
                }, {
                    header: "訂貨編號",
                    dataIndex: 'MY_ORDER_ID',
                    align: 'left',
                    width: 140
                }, {
                    header: "訂貨日期",
                    dataIndex: 'MY_ORDER_CR',
                    align: 'left',
                    width: 120,
                    hidden: true,
                    renderer: function(value, r) {
                        return value.split(' ')[0];
                    }
                }, {
                    header: "供應商名稱",
                    dataIndex: 'MY_ORDER_SUPPLIER_NAME',
                    align: 'left',
                    width: 100,
                    editor: {
                        xtype: 'textfield',
                        allowBlank: false
                    }
                }, {
                    header: "電話",
                    align: 'left',
                    dataIndex: 'MY_ORDER_SUPPLIER_TEL',
                    flex: 1,
                    editor: {
                        xtype: 'textfield',
                        allowBlank: true
                    }
                }, {
                    header: "人員",
                    dataIndex: 'MY_ORDER_CONTACT_NAME',
                    align: 'left',
                    flex: 1,
                    editor: {
                        xtype: 'textfield',
                        allowBlank: false
                    }
                }, {
                    header: '備住',
                    dataIndex: 'MY_ORDER_PS',
                    align: 'right',
                    width: 100
                }],
                tbarCfg: {
                    buttonAlign: 'right'
                },
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.myOrder,
                    displayInfo: true,
                    displayMsg: '第{0}~{1}資料/共{2}筆',
                    emptyMsg: "無資料顯示"
                }),
                tbar: [{
                    icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                    text: '新增',
                    handler: function() {
                        var main = this.up('panel').up('panel').up('panel');
                        if (!main.fnCheckSubWindowns()) {
                            Ext.MessageBox.show({
                                title: '系統訊息',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                msg: '未實現 subWinMyOrder 物件,無法進行編輯操作!'
                            });
                            return false;
                        };
                        /*註冊事件*/
                        var subWin = Ext.create(main.subWinMyOrder, {
                            param: {
                                myOrderUuid: undefined
                            }
                        });
                        subWin.on('closeEvent', function(obj) {
                            main.down("#grdMyOrderQuery").getStore().load();
                        }, main);
                        subWin.show();
                    }
                }, {
                    xtype: 'tbfill'
                }, {
                    icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                    text: '展開查詢',
                    handler: function() {
                        location.href = './goodsRecordExpand.aspx'
                    }
                }]
            }]
        }];
        this.callParent(arguments);
    },
    listeners: {
        afterrender: function(obj, eOpts) {
            this.myStore.supplier.load();
            this.myStore.myOrder.load({
                scope: this
            });
        }
    }
});
