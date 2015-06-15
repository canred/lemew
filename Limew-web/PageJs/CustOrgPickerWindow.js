/*:::Calss Name:::*/
/*columns 使用default*/
Ext.define('WS.CustOrgPickerWindow', {
    extend: 'Ext.window.Window',
    title: '挑選採購人員',
    icon: SYSTEM_URL_ROOT + '/css/images/manb16x16.png',
    closeAction: 'destroy',
    modal: true,
    myStore: {
        custOrg: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: true,
            model: 'CUST_ORG_V',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadCustOrgV
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pCustUuid', 'keyword','custIsActive', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pCustUuid: '',
                    keyword: '',
                    custIsActive:'1'
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
                property: 'CUST_ORG_SALES_NAME',
                direction: 'ASC'
            }]
        })
    },
    param: {
        uuid: undefined,
        custUuid: undefined,
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
                            proxy = mainWin.myStore.custOrg.getProxy(),
                            store = mainWin.myStore.custOrg;
                        proxy.setExtraParam('pCustUuid', mainWin.param.custUuid);
                        proxy.setExtraParam('keyword', mainWin.down('#txtKeyword').getValue());
                        store.load();
                    }
                }]
            }, {
                xtype: 'gridpanel',
                store: this.myStore.custOrg,
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
                    text: "單位",
                    dataIndex: 'CUST_ORG_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    text: "人員",
                    dataIndex: 'CUST_ORG_SALES_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    text: "電話",
                    dataIndex: 'CUST_ORG_SALES_PHONE',
                    align: 'left',
                    flex: 1
                }, {
                    text: "EMail",
                    dataIndex: 'CUST_ORG_SALES_EMAIL',
                    align: 'left',
                    flex: 1
                }, {
                    text: "備註",
                    dataIndex: 'CUST_ORG_PS',
                    align: 'left',
                    flex: 1
                }],
                anchor: '95%',
                height: 450,
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.custOrg,
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
    selectedEvent: function(obj, result) {
        this.fireEvent('selectedEvent', obj, result);
    },
    listeners: {
        'beforeshow': function() {
            var store = this.myStore.custOrg,
                proxy = store.getProxy();
            proxy.setExtraParam('pCustUuid', this.param.custUuid);
            proxy.setExtraParam('keyword', this.down('#txtKeyword').getValue());
            store.load();
        },
        'close': function() {
            this.down('#txtKeyword').setValue('');
            this.myStore.custOrg.removeAll();
            this.closeEvent();
        }
    }
});
