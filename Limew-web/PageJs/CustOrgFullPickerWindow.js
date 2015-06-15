/*:::Calss Name:::*/
/*columns 使用default*/
Ext.define('WS.CustOrgFullPickerWindow', {
    extend: 'Ext.window.Window',
    title: '挑選採購人員',
    icon: SYSTEM_URL_ROOT + '/css/images/manb16x16.png',
    closeAction: 'destroy',
    modal: true,
    myStore: {
        cust: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'CUST',
            pageSize: 9999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadCust
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'pCustIsActive', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pCustIsActive: '1|0'
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
                        'CUST_NAME': '全部'
                    });
                }
            },
            sorters: [{
                property: 'CUST_NAME',
                direction: 'ASC'
            }]
        }),
        custOrg: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'CUST_ORG',
            pageSize: 99999,
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
                property: 'CUST_NAME',
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
    width: 800,
    height: 550,
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

                        //alert(mainWin.param.custUuid);
                        // alert(mainWin.down('#cmbCust').getValue());
                        proxy.setExtraParam('pCustUuid', mainWin.down('#cmbCust').getValue());
                        proxy.setExtraParam('keyword', mainWin.down('#txtKeyword').getValue());
                        store.load();
                    }
                }]
            }, {
                xtype: 'gridpanel',
                store: this.myStore.custOrg,
                padding: 5,
                columns: [
                    // {
                    //     text: "挑選",
                    //     xtype: 'actioncolumn',
                    //     dataIndex: 'CUST_UUID',
                    //     align: 'center',
                    //     width: 80,
                    //     items: [{
                    //         tooltip: '*挑選',
                    //         icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                    //         handler: function(grid, rowIndex, colIndex) {
                    //             var mainWin = grid.up('window');
                    //             mainWin.selectedEvent(mainWin, grid.getStore().getAt(rowIndex).data);
                    //         }
                    //     }],
                    //     sortable: false,
                    //     hideable: false
                    // },

                    {
                        xtype: 'templatecolumn',
                        text: '挑選',
                        width: 100,
                        sortable: false,
                        hideable: false,
                        tpl: new Ext.XTemplate(
                            "<tpl >",
                            '{[this.fnInit()]}<input type="button" style="width:80px" value="挑選" onclick="CustOrgFullPickerWindowFnPickerHandler(\'{CUST_UUID}\',\'{CUST_ORG_UUID}\')"/>',
                            "</tpl>", {
                                scope: this,
                                fnInit: function() {
                                    document.CustOrgFullPickerWindow = this.scope;
                                    if (!document.CustOrgFullPickerWindowFnPickerHandler) {
                                        document.CustOrgFullPickerWindowFnPickerHandler = function(CUST_UUID, CUST_ORG_UUID) {
                                            var mainWin = document.CustOrgFullPickerWindow;
                                            mainWin.selectedEvent(mainWin, CUST_UUID, CUST_ORG_UUID);
                                        }
                                    }
                                }
                            })
                    }, {
                        text: "客戶",
                        dataIndex: 'CUST_NAME',
                        align: 'left',
                        width: 150
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
                    }
                ],
                //anchor: '95%',
                height: 490,
                // bbar: Ext.create('Ext.toolbar.Paging', {
                //     store: this.myStore.custOrg,
                //     displayInfo: true,
                //     displayMsg: '第{0}~{1}資料/共{2}筆',
                //     emptyMsg: "無資料顯示"
                // }),
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
    selectedEvent: function(obj, CUST_UUID, CUST_ORG_UUID) {
        this.fireEvent('selectedEvent', obj, CUST_UUID, CUST_ORG_UUID);
    },
    listeners: {
        'beforeshow': function() {
            var store = this.myStore.custOrg,
                proxy = store.getProxy();

            this.myStore.cust.load({
                scope: this
            });
            proxy.setExtraParam('pCustUuid', this.param.custUuid);
            proxy.setExtraParam('keyword', this.down('#txtKeyword').getValue());
            //store.load();
        },
        'close': function() {
            this.down('#txtKeyword').setValue('');
            this.myStore.custOrg.removeAll();
            this.closeEvent();
        }
    }
});
