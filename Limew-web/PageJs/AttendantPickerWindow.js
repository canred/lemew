/*:::Calss Name:::*/
/*columns 使用default*/
Ext.define('WS.AttendantPickerWindow', {
    extend: 'Ext.window.Window',
    title: '挑選人員',
    icon: SYSTEM_URL_ROOT + '/css/images/manb16x16.png',
    closeAction: 'destroy',
    myStore: {
        attendant: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: true,
            model: Ext.define('ATTEDNANTVV', {
                extend: 'Ext.data.Model',
                fields: [
                    'COMPANY_ID',
                    'COMPANY_C_NAME',
                    'COMPANY_E_NAME',
                    'DEPARTMENT_ID',
                    'DEPARTMENT_C_NAME',
                    'DEPARTMENT_E_NAME',
                    'SITE_ID',
                    'SITE_C_NAME',
                    'SITE_E_NAME',
                    'UUID',
                    'CREATE_DATE',
                    'UPDATE_DATE',
                    'IS_ACTIVE',
                    'COMPANY_UUID',
                    'ACCOUNT',
                    'C_NAME',
                    'E_NAME',
                    'EMAIL',
                    'PASSWORD',
                    'IS_SUPPER',
                    'IS_ADMIN',
                    'CODE_PAGE',
                    'DEPARTMENT_UUID',
                    'PHONE',
                    'SITE_UUID',
                    'GENDER',
                    'BIRTHDAY',
                    'HIRE_DATE',
                    'QUIT_DATE',
                    'IS_MANAGER',
                    'IS_DIRECT',
                    'GRADE',
                    'ID',
                    'IS_DEFAULT_PASS'
                ]
            }),
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.AttendantAction.load
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['company_uuid', 'keyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    company_uuid: '',
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
            listeners: {
                load: function() {}
            },
            remoteSort: true,
            sorters: [{
                property: 'C_NAME',
                direction: 'ASC'
            }]
        })
    },
    param: {
        uuid: undefined,
        companyUuid: undefined
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
                            if (t.button == 12) {
                                this.up('panel').down('#btnQuery').handler();
                            }
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
                            proxy = mainWin.myStore.attendant.getProxy(),
                            store = mainWin.myStore.attendant;
                        proxy.setExtraParam('company_uuid', mainWin.param.companyUuid);
                        proxy.setExtraParam('keyword', mainWin.down('#txtKeyword').getValue());
                        store.load();
                    }
                }]
            }, {
                xtype: 'gridpanel',
                store: this.myStore.attendant,
                padding: 5,
                columns: [{
                    text: "挑選",
                    xtype: 'actioncolumn',
                    dataIndex: 'UUID',
                    align: 'center',
                    width: 80,
                    items: [{
                        tooltip: '*挑選',
                        icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                        handler: function(grid, rowIndex, colIndex) {
                            var mainWin = grid.up('window');
                            mainWin.selectedEvent(grid.getStore().getAt(rowIndex).data);
                        }
                    }],
                    sortable: false,
                    hideable: false
                }, {
                    text: "中文姓名",
                    dataIndex: 'C_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    text: "英文姓名",
                    dataIndex: 'E_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    text: "帳號",
                    dataIndex: 'ACCOUNT',
                    align: 'left',
                    flex: 2
                }, {
                    text: "E-Mail",
                    dataIndex: 'EMAIL',
                    align: 'left',
                    flex: 2
                }],
                anchor: '95%',
                height: 450,
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.attendant,
                    displayInfo: true,
                    displayMsg: '第{0}~{1}資料/共{2}筆',
                    emptyMsg: "無資料顯示"
                }),
                listeners: {
                    'beforerender': function() {}
                },
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
    selectedEvent: function(result) {
        this.fireEvent('selectedEvent', result);
    },
    listeners: {
        'beforeshow': function() {
            Ext.getBody().mask();
            var store = this.myStore.attendant,
                proxy = store.getProxy();
            proxy.setExtraParam('company_uuid', this.param.companyUuid);
            proxy.setExtraParam('keyword', this.down('#txtKeyword').getValue());
            store.load();
        },
        'close': function() {
            Ext.getBody().unmask();
            this.down('#txtKeyword').setValue('');
            this.closeEvent();
        }
    }
});
