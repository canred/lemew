/*全局變量*/
var WS_MYORDERQUERYPANEL;
/*WS.SupplierQueryPanel物件類別*/
/*TODO*/
/*
1.Model 要集中                                 [YES]
2.panel 的title要換成icon , title的方式        [YES]
3.add 的icon要換成icon , title的方式           [YES]
4.自動Query 資料                               [YES]
*/
/*columns 使用default*/
Ext.define('WS.MyOrderQueryPanel', {
    extend: 'Ext.panel.Panel',
    closeAction: 'destroy',
    subWinMyOrder: undefined,
    /*語言擴展*/
    lan: {},
    /*值擴展*/
    val: {},
    /*物件會用到的Store物件*/
    myStore: {
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
            sorters: [{
                property: 'MY_ORDER_DATE',
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
    rowEditing: Ext.create('Ext.grid.plugin.RowEditing', {
        clicksToMoveEditor: 1,
        autoCancel: true,
        listeners: {
            edit: function(editor, e) {
                var mainPanel = editor.grid.up('panel');
                var store = mainPanel.down('#grdMyOrderQuery').getStore();
                Ext.each(store.getModifiedRecords(), function(item) {
                    var my_order_uuid = item.data.MY_ORDER_UUID;
                    var my_order_date = item.data.MY_ORDER_DATE;
                    var my_order_supplier_name = item.data.MY_ORDER_SUPPLIER_NAME;
                    var my_order_supplier_tel = item.data.MY_ORDER_SUPPLIER_TEL;
                    var my_order_supplier_man = item.data.MY_ORDER_SUPPLIER_MAN;
                    var my_order_goods_name = item.data.MY_ORDER_GOODS_NAME;
                    var my_order_goods_count = item.data.MY_ORDER_GOODS_COUNT;
                    var my_order_price = item.data.MY_ORDER_PRICE;
                    var my_order_total_price = item.data.MY_ORDER_TOTAL_PRICE;
                    var my_order_ps = item.data.MY_ORDER_PS;
                    var my_order_is_finish = item.data.MY_ORDER_IS_FINISH;
                    var my_order_pay_method = item.data.MY_ORDER_PAY_METHOD;
                    var my_order_is_active = item.data.MY_ORDER_IS_ACTIVE;
                    var my_order_attendant_uuid = item.data.MY_ORDER_ATTENDANT_UUID;

                    WS.MyOrderAction.quickEdit(
                        my_order_uuid,
                        my_order_date,
                        my_order_supplier_name,
                        my_order_supplier_tel,
                        my_order_supplier_man,
                        my_order_goods_name,
                        my_order_goods_count,
                        my_order_price,
                        my_order_total_price,
                        my_order_ps,
                        my_order_is_finish,
                        my_order_pay_method,
                        my_order_is_active,
                        my_order_attendant_uuid,
                        function(obj, jsonObj) {

                        }
                    );
                });
                mainPanel.up('panel').myStore.myOrder.reload();
            }
        }
    }),
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
            height: $(document).height() - 150,
            autoWidth: true,
            padding: '5 0 5 5',
            items: [{
                xtype: 'container',
                layout: 'hbox',
                margin: '5 0 0 5',
                items: [{
                    xtype: 'textfield',
                    fieldLabel: '關鍵字',
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
                        var store = this.up('panel').down("#grdMyOrderQuery").getStore(),
                            doSomeghing = function(obj, pl) {
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
                    }
                }]
            }, {
                xtype: 'gridpanel',
                store: this.myStore.myOrder,
                plugins: [this.rowEditing],
                itemId: 'grdMyOrderQuery',
                border: true,
                height: $(document).height() - 240,
                padding: '5 15 5 5',
                columns: [{
                    text: "編輯",
                    xtype: 'actioncolumn',
                    dataIndex: 'MY_ORDER_UUID',
                    align: 'center',
                    width: 60,
                    items: [{
                        tooltip: '*覆製',
                        icon: SYSTEM_URL_ROOT + '/css/custimages/clone16x16.png',
                        handler: function(grid, rowIndex, colIndex) {
                            var main = grid.up('panel').up('panel').up('panel');

                            WS.MyOrderAction.cloneMyOrder(grid.getStore().getAt(rowIndex).data.MY_ORDER_UUID, function(obj, jsonObj) {
                                if (jsonObj.result.success) {
                                    main.myStore.myOrder.reload();
                                }
                            }, main);
                        }
                    }, {
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
                                subWinMyOrderOrder: 'WS.MyOrderWindow'
                            });
                            subWin.on('closeEvent', function(obj) {
                                main.down("#grdMyOrderQuery").getStore().load();
                            }, main);
                            subWin.param.myOrderUuid = grid.getStore().getAt(rowIndex).data.MY_ORDER_UUID;
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
                    }, ],
                    sortable: false,
                    hideable: false
                }, {
                    header: "訂貨日期",
                    dataIndex: 'MY_ORDER_DATE',
                    align: 'left',
                    width: 120,
                    renderer: function(value, r) {
                        return value.split(' ')[0];
                    },
                    editor: {
                        xtype: 'datefield',
                        format: 'Y/m/d',
                        allowBlank: false,
                        listeners: {
                            render: function(obj, eOpts) {
                                //return new Date();
                            }
                        }
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
                    dataIndex: 'MY_ORDER_SUPPLIER_MAN',
                    align: 'left',
                    flex: 1,
                    editor: {
                        xtype: 'textfield',
                        allowBlank: false
                    }
                }, {
                    header: '貨品名稱',
                    dataIndex: 'MY_ORDER_GOODS_NAME',
                    align: 'left',
                    width: 150,
                    editor: {
                        xtype: 'textfield',
                        allowBlank: false
                    }
                }, {
                    header: '數量',
                    dataIndex: 'MY_ORDER_GOODS_COUNT',
                    align: 'right',
                    width: 80,
                    editor: {
                        xtype: 'numberfield',
                        allowBlank: false
                    }
                }, {
                    header: '單價',
                    dataIndex: 'MY_ORDER_PRICE',
                    align: 'right',
                    width: 80,
                    editor: {
                        xtype: 'numberfield',
                        allowBlank: false
                    }
                }, {
                    header: '總價',
                    dataIndex: 'MY_ORDER_TOTAL_PRICE',
                    align: 'right',
                    width: 100
                }, {
                    header: '完成',
                    dataIndex: 'MY_ORDER_IS_FINISH',
                    align: 'center',
                    widht: 40,
                    renderer: this.fnActiveRender
                }, {
                    header: '備住',
                    dataIndex: 'MY_ORDER_PS',
                    align: 'center',
                    flex: 1,
                    editor: {
                        xtype: 'textfield',
                        allowBlank: true
                    }
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
                }]
            }]
        }];
        this.callParent(arguments);
    },
    listeners: {
        afterrender: function(obj, eOpts) {
            this.myStore.myOrder.load({
                scope: this
            });
        }
    }
});
