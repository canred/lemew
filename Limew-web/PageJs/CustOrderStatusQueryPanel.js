/*全局變量*/
var CUSTORDERSTATUSQUERYPANEL;
/*WS.CompanyQueryPanel物件類別*/
/*TODO*/
/*
1.Model 要集中                 [YES]
2.不可以有任何的 getCmp 字眼   [YES]
*/
/*columns 使用default*/
Ext.define('WS.CustOrderStatusQueryPanel', {
    extend: 'Ext.panel.Panel',
    closeAction: 'destroy',
    subWinCustOrderStatus: undefined,
    /*語言擴展*/
    lan: {},
    /*參數擴展*/
    param: {
    },
    /*值擴展*/
    val: {},
    /*物件會用到的Store物件*/
    myStore: {
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
                paramOrder: [ 'keyword', 'page', 'limit', 'sort', 'dir'],
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
            sorters: [{
                property: 'CUST_ORDER_STATUS_ORD',
                direction: 'ASC'
            }]
        })
    },
    fnActiveRender: function isActiveRenderer(value, id, r) {
        var html = "<img src='" + SYSTEM_URL_ROOT;
        return value === "1" ? html + "/css/custimages/active03.png'>" : html + "/css/custimages/unactive03.png'>";
    },
    initComponent: function() { 
        /*佈局設定*/
        this.items = [{
            xtype: 'panel',
            icon: SYSTEM_URL_ROOT + '/css/custimages/list16x16.png',
            title: '訂單狀態查詢',
            frame: true,
            height: $(document).height() - 150,
            items: [{
                xtype: 'container',
                layout: 'hbox',
                margin: '5 0 0 0',
                defaults: {
                    margin: '0 5 0 0',
                    labelAlign: 'right'
                },
                items: [{
                    xtype: 'textfield',
                    fieldLabel: '關鍵字',
                    labelWidth: 50,
                    itemId: 'txt_search',
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
                    width: 70,
                    icon: SYSTEM_URL_ROOT + '/css/custimages/find.png',
                    text: '查詢',
                    itemId: 'btnQuery',
                    handler: function() {
                        var _main = this.up('panel').up('panel'),
                            _txtSearch = _main.down("#txt_search").getValue();                       
                        _main.myStore.custOrderStatus.getProxy().setExtraParam('keyword', _txtSearch);
                        _main.myStore.custOrderStatus.loadPage(1);
                    }
                }, {
                    xtype: 'button',
                    width: 70,
                    icon: SYSTEM_URL_ROOT + '/css/custimages/clear.png',
                    text: '清除',
                    tooltip: '*清除目前所有的條件查詢',
                    handler: function() {
                        var _main = this.up('panel').up('panel');
                        _main.down("#txt_search").setValue('');
                    }
                }]
            }, {
                xtype: 'gridpanel',
                store: this.myStore.custOrderStatus,
                itemId: 'grdCustOrderStatusQuery',
                padding: 5,
                border: true,
                height: $(document).height() - 220,
                columns: {
                    defaults: {
                        align: 'left'
                    },
                    items: [{
                        text: "編輯",
                        xtype: 'actioncolumn',
                        dataIndex: 'CUST_ORDER_STATUS_UUID',
                        align: 'center',
                        width: 60,
                        items: [{
                            tooltip: '*編輯',
                            icon: SYSTEM_URL_ROOT+'/css/images/edit16x16.png',
                            handler: function(grid, rowIndex, colIndex) {
                                var main = grid.up('panel').up('panel').up('panel');
                                if (!main.subWinCustOrderStatus) {
                                    Ext.MessageBox.show({
                                        title: '系統訊息',
                                        icon: Ext.MessageBox.INFO,
                                        buttons: Ext.Msg.OK,
                                        msg: '未實現 subWinCustOrderStatus 物件,無法進行編輯操作!'
                                    });
                                    return false;
                                };
                                /*註冊事件*/
                                var subWin = Ext.create(main.subWinCustOrderStatus, {
                                    param: {
                                        custOrderStatusUuid: grid.getStore().getAt(rowIndex).data.CUST_ORDER_STATUS_UUID
                                    }
                                });
                                subWin.on('closeEvent', function(obj) {
                                    main.down("#grdCustOrderStatusQuery").getStore().load();
                                }, main);
                                subWin.show();
                            }
                        }],
                        sortable: false,
                        hideable: false
                    }, {
                        header: "狀態名稱",
                        dataIndex: 'CUST_ORDER_STATUS_NAME',
                        flex:1
                    }, {
                        header: "順序",
                        dataIndex: 'CUST_ORDER_STATUS_ORD',
                        width: 60,
                    }, {
                        header: '有效',
                        dataIndex: 'CUST_ORDER_STATUS_IS_ACTIVE',
                        align: 'center',
                        width: 60,
                        renderer: this.fnActiveRender
                    }]
                },
                tbarCfg: {
                    buttonAlign: 'right'
                },
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.unit,
                    displayInfo: true,
                    displayMsg: '第{0}~{1}資料/共{2}筆',
                    emptyMsg: "無資料顯示"
                }),
                tbar: [{
                    icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                    text: '新增',
                    handler: function() {
                        var main = this.up('panel').up('panel').up('panel');
                        if (!main.subWinCustOrderStatus) {
                            Ext.MessageBox.show({
                                title: '系統訊息',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                msg: '未實現 subWinCustOrderStatus 物件,無法進行編輯操作!'
                            });
                            return false;
                        };
                        var subWin = Ext.create(main.subWinCustOrderStatus, {
                            param: {
                                uuid: undefined
                            }
                        });
                        /*註冊事件*/
                        subWin.on('closeEvent', function(obj) {
                            main.down("#grdCustOrderStatusQuery").getStore().load();
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
            this.myStore.custOrderStatus.load({
                scope: this
            });
        }
    }
});
