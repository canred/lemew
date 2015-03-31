/*全局變量*/
var WS_GCATEGORYQUERYPANEL;
/*WS.CompanyQueryPanel物件類別*/
/*TODO*/
/*
1.Model 要集中                                 [YES]
2.panel 的title要換成icon , title的方式        [YES]
3.add 的icon要換成icon , title的方式           [YES]
4.不可以有 getCmp                              [YES]
5.有一段程式碼不確定 line 69
6. tree 要改變一次顯示                         [YES]
7. 如果menu不是有效要表現出來                  [YES]
8. 新增子節點的功能未完成                      [YES]
9. 子視窗的功能未完成                          [YES]  
10.新增畫面開啟後自動選擇系統                  [YES]  
11.加上一個LoadMask當資料正在讀取時            [NO] 
*/
/*columns 使用default*/
Ext.define('WS.GcategoryQueryPanel', {
    extend: 'Ext.panel.Panel',
    closeAction: 'destroy',
    subWinGcategoryWindow: undefined,
    /*語言擴展*/
    lan: {},
    /*參數擴展*/
    param: {
        gcategoryUuid: undefined
    },
    /*值擴展*/
    val: {},
    /*物件會用到的Store物件*/
    myStore: {
        tree: undefined
    },
    fnCallBackCloseEvent: function() {
        this.fnQuery(this);
    },
    fnQuery: function(obj) {
        /*obj要是主體*/
        WS.GcategoryAction.loadGcagegoryTree(function(data) {
            if (data[0].GCATEGORY_UUID != undefined) {
                var store = this.myStore.tree,
                    proxy = store.getProxy();
                proxy.setExtraParam('pGcategoryParentUuid', data[0].GCATEGORY_UUID);
                this.myStore.tree.load({
                    params: {
                        'pGcategoryParentUuid': data[0].GCATEGORY_UUID
                    },
                    callback: function() {
                        this.down('#trp').expandAll();
                    },
                    scope: this
                });
            };
        }, obj);
    },
    fnActiveRender: function(value, id, r) {
        var html = "<img src='" + SYSTEM_URL_ROOT;
        return value === "1" ? html + "/css/custimages/active03.png'>" : html + "/css/custimages/unactive03.png'>";
    },
    fnCheckSubComponent: function() {
        /*要把scope變成SitemapQueryPanel主體*/
        if (Ext.isEmpty(this.subWinGcategoryWindow)) {
            Ext.MessageBox.show({
                title: '系統提示',
                icon: Ext.MessageBox.WARNING,
                buttons: Ext.Msg.OK,
                msg: '未指定 subWinGcategoryWindow ,無法進行編輯操作!'
            });
            return false;
        };
        return true;
    },
    fnEditGcategory: function(menuUuid) {
        /*要把scope變成SitemapQueryPanel主體*/
        if (!this.fnCheckSubComponent()) {
            return false;
        };
        this.param.gcategoryUuid = menuUuid;
        var subWin = Ext.create(this.subWinGcategoryWindow, {
            param: {
                gcategoryUuid: menuUuid
            }
        });
        /*註冊事件*/
        subWin.on('closeEvent', this.fnCallBackCloseEvent, this);
        /*設定參數*/
        subWin.show();
    },
    fnAddGcategoryChild: function(parentMenuUuid) {
        /*要把scope變成SitemapQueryPanel主體*/
        if (!this.fnCheckSubComponent()) {
            return false;
        };
        this.param.gcategoryUuid = parentMenuUuid;
        var subWin = Ext.create(this.subWinGcategoryWindow, {
            param: {
                gcategoryUuid: undefined,
                gcategoryParentUuid: parentMenuUuid
            }
        });
        subWin.on('closeEvent', this.fnCallBackCloseEvent, this);
        subWin.show();
    },
    fnRemoveGcategory: function(mainPanel, gcategoryUuid) {
        Ext.Msg.show({
            title: '刪除節點操作',
            msg: '確定執行刪除動作?',
            buttons: Ext.Msg.YESNO,
            fn: function(btn) {
                if (btn == "yes") {
                    WS.GcategoryAction.deleteGcategory(gcategoryUuid, function(json) {
                        mainPanel.fnQuery(mainPanel);
                    });
                };
            }
        });
    },
    initComponent: function() {
        this.myStore.tree = Ext.create('WS.GcategoryTreeStore', {});
        if (!this.fnCheckSubComponent()) {
            return false;
        };
        this.items = [{
            xtype: 'panel',
            title: '商品類別',
            icon: SYSTEM_URL_ROOT + '/css/images/menu16x16.png',
            frame: true,
            minHeight: $(document).height() - 150,
            autoHeight: true,
            autoWidth: true,
            items: [{
                xtype: 'button',
                margin: '5 0 0 5',
                text: '新增商品類別節點',
                icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                handler: function() {
                    var mainPanel = this.up('panel').up('panel');
                    WS.GcategoryAction.loadTreeRoot(function(data) {
                        var gcategoryUuid = data.GCATEGORY_UUID;
                        //alert(data.GCATEGORY_UUID);
                        if (!this.fnCheckSubComponent()) {
                            return false;
                        };
                        this.param.gcategoryUuid = gcategoryUuid;

                        var subWin = Ext.create(this.subWinGcategoryWindow, {
                            param: {
                                gcategoryUuid: undefined,
                                gcategoryParentUuid: gcategoryUuid
                            }
                        });

                        /*註冊事件*/
                        subWin.on('closeEvent', this.fnCallBackCloseEvent, this);
                        /*設定參數*/
                        subWin.show();
                    }, mainPanel);
                }
            }, {
                xtype: 'treepanel',
                itemId: 'trp',
                padding: 5,
                border: true,
                autoWidth: true,
                autoHeight: true,
                minHeight: $(document).height() - 230,
                store: this.myStore.tree,
                multiSelect: true,
                rootVisible: false,
                columns: [{
                    xtype: 'treecolumn',
                    text: '類別',
                    flex: 2,
                    sortable: false,
                    dataIndex: 'GCATEGORY_NAME'
                }, {
                    text: '有效',
                    flex: .5,
                    dataIndex: 'GCATEGORY_IS_ACTIVE',
                    align: 'center',
                    sortable: false,
                    hidden: false,
                    renderer: this.fnActiveRender
                }, {
                    text: "維護",
                    xtype: 'actioncolumn',
                    dataIndex: 'GCATEGORY_UUID',
                    align: 'center',
                    sortable: false,
                    flex: 1,
                    items: [{
                        tooltip: '*編輯',
                        icon: SYSTEM_URL_ROOT + '/css/images/edit16x16.png',
                        handler: function(grid, rowIndex, colIndex) {
                            var mainPanel = grid.up('panel').up('panel').up('panel'),
                                gcategoryUuid = grid.getStore().getAt(rowIndex).data.GCATEGORY_UUID;
                            mainPanel.fnEditGcategory(gcategoryUuid);
                        }
                    }, {
                        tooltip: '*新增子節點',
                        icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                        handler: function(grid, rowIndex, colIndex) {
                            var mainPanel = grid.up('panel').up('panel').up('panel'),
                                gcategoryUuid = grid.getStore().getAt(rowIndex).data.GCATEGORY_UUID;
                            mainPanel.fnAddGcategoryChild(gcategoryUuid);
                        }
                    }, {
                        tooltip: '*刪除',
                        icon: SYSTEM_URL_ROOT + '/css/images/delete16x16.png',
                        margin: '0 0 0 40',
                        handler: function(grid, rowIndex, colIndex) {
                            var mainPanel = grid.up('panel').up('panel').up('panel'),
                                gcategoryUuid = grid.getStore().getAt(rowIndex).data.GCATEGORY_UUID;;
                            mainPanel.fnRemoveGcategory(mainPanel, gcategoryUuid);
                        }
                    }],
                    hideable: false
                }]
            }]
        }];
        this.callParent(arguments);
    },
    listeners: {
        'afterrender': function(obj, eOpts) {
            this.fnQuery(obj);
        }
    }
});
