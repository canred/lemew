/*:::Calss Name:::*/
/*columns 使用default*/
Ext.define('WS.CustPickerWindow', {
    extend: 'Ext.window.Window',
    title: '挑選客戶',
    icon: SYSTEM_URL_ROOT + '/css/images/manb16x16.png',
    closeAction: 'destroy',
	modal: true,
    myStore: {
        cust: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: true,
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
                paramOrder: [ 'keyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    keyword: ''
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        Ext.MessageBox.show({
                            title: 'REMOTE EXCEPTION',
                            msg: operation.getError(),
                            icon: Ext.MessageBox.ERROR,
                            buttons: Ext.Msg.OK
                        });
                    }
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'CUST_NAME',
                direction: 'ASC'
            }]
        })
    },
    param: {
        uuid: undefined,

        parentObj: undefined
    },
    iconSelectUrl: SYSTEM_URL_ROOT + '/css/custImages/mouse_select_left.gif',
    width: 750,
    height: 450,
    resizable: false,
    draggable: false,
    initComponent: function() {
        this.items = [Ext.create('Ext.form.Panel', {
            border: true,
            bodyPadding: 5,
            defaultType: 'textfield',
            buttonAlign: 'center',
            items: [{
                xtype: 'container',
                layout: 'hbox',
                items: [{
                    xtype: 'textfield',
                    fieldLabel: '關鍵字',
                    itemId: 'txtKeyword',
                    labelAlign: 'left',
                    labelWidth: 50,
                    margin: '0 0 0 5',
                    enableKeyEvents: true,
                    listeners: {
                        keyup: function(e, t, eOpts) {
                            var keyCode = t.keyCode,
                                mainPanel = this.up('panel');
                            if (keyCode == Ext.event.Event.ENTER) {
                                mainPanel.down("#btnQuery").handler();
                            };
                        }
                    }
                }, {
                    xtype: 'button',
                    text: '查詢',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/find.png',
                    itemId: 'btnQuery',
                    margin: '0 5 0 5',
                    handler: function() {
                        var mainWin = this.up('window'),
                            proxy = mainWin.myStore.cust.getProxy(),
                            store = mainWin.myStore.cust;
                        
                        proxy.setExtraParam('keyword', mainWin.down('#txtKeyword').getValue());
                        store.load();
                    }
                }]
            }, {
                xtype: 'gridpanel',
                store: this.myStore.cust,
                padding: 5,
                columns: [{
                    text: "挑選",
                    xtype: 'actioncolumn',
                    dataIndex: 'CUST_UUID',
                    align: 'center',
                    width: 80,
                    items: [{
                        tooltip: '*挑選',
                        icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                        handler: function(grid, rowIndex, colIndex) {
                            var mainWin = grid.up('window');
                            mainWin.selectedEvent(mainWin, grid.getStore().getAt(rowIndex).data);
                        }
                    }],
                    sortable: false,
                    hideable: false
                }, {
                    text: "客戶",
                    dataIndex: 'CUST_NAME',
                    align: 'left',
                    flex: 1
                }],
                anchor: '95%',
                height: 450,
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.cust,
                    displayInfo: true,
                    displayMsg: '第{0}~{1}資料/共{2}筆',
                    emptyMsg: "無資料顯示"
                }),
                tbarCfg: {
                    buttonAlign: 'right'
                }
            }],
            fbar: [{
                type: 'button',
                icon: SYSTEM_URL_ROOT + '/css/custimages/exit16x16.png',
                text: '關閉',
                handler: function() {
                    this.up('window').close();
                }
            }]
        })]
        this.callParent(arguments);
    },
    closeEvent: function() {
        this.fireEvent('closeEvent', this);
    },
    selectedEvent: function(obj, result ) {
        this.fireEvent('selectedEvent', obj, result);
    },
    listeners: {
        'beforeshow': function() {            
            var store = this.myStore.cust,
                proxy = store.getProxy();
            
            proxy.setExtraParam('keyword', this.down('#txtKeyword').getValue());
            store.load();
        },
        'close': function() {
            this.down('#txtKeyword').setValue('');
            this.closeEvent();
        }
    }
});
