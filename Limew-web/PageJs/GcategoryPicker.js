Ext.define('WS.GcategoryPicker', {
    extend: 'Ext.window.Window',
    closeAction: 'destroy',
    title:'挑選類別',
    icon: SYSTEM_URL_ROOT + '/css/images/menu16x16.png',
    width:600,
    height:400,
    autoScroll:true,
    /*語言擴展*/
    lan: {},
    /*參數擴展*/
    param: {
        parentObj:undefined
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
                    }
                });
            };
        }, obj);
    },
    fnActiveRender: function(value, id, r) {
        var html = "<img src='" + SYSTEM_URL_ROOT;
        return value === "1" ? html + "/css/custimages/active03.png'>" : html + "/css/custimages/unactive03.png'>";
    },
    initComponent: function() {
        this.myStore.tree = Ext.create('WS.GcategoryTreeStore', {});
        this.items = [{
            xtype: 'panel',
            //title: '商品類別',
            //icon: SYSTEM_URL_ROOT + '/css/images/menu16x16.png',
            frame: false,
            //minHeight: $(document).height() - 150,
            autoHeight: true,
            autoWidth: true,
            items: [{
                
                xtype: 'treepanel',
                padding: 5,
                border: true,
                autoWidth: true,
                autoHeight: true,
                minHeight: $(document).height() - 230,
                store: this.myStore.tree,
                multiSelect: true,
                rootVisible: false,
                columns: [{
                    text: "選擇",
                    xtype: 'actioncolumn',
                    dataIndex: 'GCATEGORY_UUID',
                    align: 'center',
                    sortable: false,
                    flex: .5,
                    items: [{
                        tooltip: '*選擇',
                        icon: SYSTEM_URL_ROOT + '/css/images/mouseSelect16x16.png',
                        handler: function(grid, rowIndex, colIndex) {
                            var mainPanel = grid.up('window');
                            var gcategoryUuid = grid.getStore().getAt(rowIndex).data.GCATEGORY_UUID;
                            mainPanel.fireEvent('selected',mainPanel,grid.getStore().getAt(rowIndex).data);
                        }
                    }],
                    hideable: false
                }, {
                    xtype: 'treecolumn',
                    text: '類別',
                    flex: 3,
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
                }]
            }]
        }];
        this.callParent(arguments);
    },
    listeners: {
        'show': function(obj, eOpts) {
            if(this.param.parentObj){
                this.param.parentObj.mask();
            };
            this.fnQuery(obj);
        },
        'close':function(obj, eOpts) {
            if(this.param.parentObj){
                this.param.parentObj.unmask();
            };
        }
    }
});
