/*全局變量*/
var WS_GOODSQUERYPANEL;
/*WS.SupplierQueryPanel物件類別*/
/*TODO*/
/*
1.Model 要集中                                 [YES]
2.panel 的title要換成icon , title的方式        [YES]
3.add 的icon要換成icon , title的方式           [YES]
4.自動Query 資料                               [YES]
*/
/*columns 使用default*/
Ext.define('WS.GoodsQueryPanel', {
    extend: 'Ext.panel.Panel',
    closeAction: 'destroy',
    subWinGoods: undefined,
    /*語言擴展*/
    lan: {},
    /*參數擴展*/
    /*值擴展*/
    val: {},
    /*物件會用到的Store物件*/
    myStore: {
        vgoods: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'V_GOODS',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.GoodsAction.loadVGoods
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
                property: 'GOODS_NAME',
                direction: 'ASC'
            }]
        })
    },
    fnActiveRender: function(value, id, r) {
        var html = "<img src='" + SYSTEM_URL_ROOT;
        return value === "1" ? html + "/css/custimages/active03.png'>" : html + "/css/custimages/unactive03.png'>";
    },
    fnCheckSubWindowns: function() {

        if (Ext.isEmpty(this.subWinGoods)) {
            Ext.MessageBox.show({
                title: '系統提示',
                icon: Ext.MessageBox.WARNING,
                buttons: Ext.Msg.OK,
                msg: '未實現 subWinGoods 物件,無法進行編輯操作!'
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
            title: '商品查詢',
            icon: SYSTEM_URL_ROOT + '/css/custimages/gift16x16.png',
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
                        var store = this.up('panel').down("#grdSupplierQuery").getStore(),
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
                store: this.myStore.vgoods,
                itemId: 'grdSupplierQuery',
                border: true,
                height: $(document).height() - 200,
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
                            if (!main.subWinGoods) {
                                Ext.MessageBox.show({
                                    title: '系統訊息',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK,
                                    msg: '未實現 subWinGoods 物件,無法進行編輯操作!'
                                });
                                return false;
                            };
                            var subWin = Ext.create(main.subWinGoods, {});
                            subWin.on('closeEvent', function(obj) {
                                main.down("#grdSupplierQuery").getStore().load();
                            }, main);
                            subWin.param.goodsUuid = grid.getStore().getAt(rowIndex).data.GOODS_UUID;
                            subWin.show();
                        }
                    }],
                    sortable: false,
                    hideable: false
                }, {
                    header: "名稱",
                    dataIndex: 'GOODS_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    header: '類別',
                    dataIndex: 'GCATEGORY_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    header: '類別(全)',
                    dataIndex: 'GCATEGORY_FULL_NAME',
                    align: 'left',
                    hidden: true,
                    flex: 1
                }, {
                    header: '商品(備註)',
                    dataIndex: 'GOODS_PS',
                    align: 'left',
                    flex: 1
                }, {
                    header: "序號",
                    align: 'left',
                    dataIndex: 'GOODS_SN',
                    flex: 1
                }, {
                    header: "售價",
                    dataIndex: 'GOODS_SALE',
                    align: 'right',
                    flex: 1
                }, {
                    header: '原價',
                    dataIndex: 'GOODS_PRICE',
                    align: 'right',
                    flex: 1
                }, {
                    header: '成本',
                    dataIndex: 'GOODS_COST',
                    align: 'right',
                    flex: 1
                }, {
                    header: '有效',
                    dataIndex: 'GOODS_IS_ACTIVE',
                    align: 'center',
                    flex: 1,
                    renderer: this.fnActiveRender
                }, {
                    header: '供應商',
                    dataIndex: 'SUPPLIER_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    header: '供應商備註',
                    dataIndex: 'SUPPLIER_PS',
                    align: 'left',
                    flex: 1
                }],
                tbarCfg: {
                    buttonAlign: 'right'
                },
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.vgoods,
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
                                msg: '未實現 subWinGoods 物件,無法進行編輯操作!'
                            });
                            return false;
                        };
                        /*註冊事件*/
                        var subWin = Ext.create(main.subWinGoods, {
                            param: {
                                goodsUuid: undefined
                            }
                        });
                        subWin.on('closeEvent', function(obj) {
                            main.down("#grdSupplierQuery").getStore().load();
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
            this.myStore.vgoods.load({
                scope: this
            });
        }
    }
});
