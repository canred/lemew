/*columns 使用default*/
Ext.define('WS.CustWindow', {
    extend: 'Ext.window.Window',
    title: '客戶維護',
    icon: SYSTEM_URL_ROOT + '/css/custimages/cust16x16.png',
    closeAction: 'destroy',
    closable: false, modal: true,
    param: {
        custUuid: undefined
    },
    fnActiveRender: function(value, id, r) {
        var html = "<img src='" + SYSTEM_URL_ROOT;
        return value === "1" ? html + "/css/custimages/active03.png'>" : html + "/css/custimages/unactive03.png'>";
    },
    myStore: {
        custOrg: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: 'CUST_ORG',
            pageSize: 10,
            remoteSort: true,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadCustOrg
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pCustUuid', 'pKeyword','pShowIsDefault', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    'pShowIsDefault':'0',
                    'pCustUuid': '',
                    'pKeyword': ''
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
            sorters: [{
                property: 'CUST_ORG_NAME',
                direction: 'ASC'
            }]
        }),
        vcustorderA: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: 'V_CUST_ORDER',
            pageSize: 10,
            remoteSort: true,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadVCustOrder
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'pCustOrderType', 'pCompanyUuid', 'pCustUuid', 'pCustOrderStatusUuid', 'pShippingStatusUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pCustOrderType: '0',
                    pCompanyUuid: '',
                    pCustUuid: '',
                    pCustOrderStatusUuid: '',
                    pShippingStatusUuid: ''
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
            sorters: [{
                property: 'CUST_ORDER_CR',
                direction: 'DESC'
            }]
        }),
        vcustorderB: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: 'V_CUST_ORDER',
            pageSize: 10,
            remoteSort: true,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadVCustOrder
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'pCustOrderType', 'pCompanyUuid', 'pCustUuid', 'pCustOrderStatusUuid', 'pShippingStatusUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pCustOrderType: '1',
                    pCompanyUuid: '',
                    pCustUuid: '',
                    pCustOrderStatusUuid: '',
                    pShippingStatusUuid: ''
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
            sorters: [{
                property: 'CUST_ORDER_CR',
                direction: 'DESC'
            }]
        }),
        vcustorderC: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: 'V_CUST_ORDER',
            pageSize: 10,
            remoteSort: true,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadVCustOrder
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'pCustOrderType', 'pCompanyUuid', 'pCustUuid', 'pCustOrderStatusUuid', 'pShippingStatusUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pCustOrderType: '1',
                    pCompanyUuid: '',
                    pCustUuid: '',
                    pCustOrderStatusUuid: '',
                    pShippingStatusUuid: 'SS_FINISH'
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
            sorters: [{
                property: 'CUST_ORDER_CR',
                direction: 'DESC'
            }]
        }),
        vcustorderD: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: 'V_CUST_ORDER',
            pageSize: 10,
            remoteSort: true,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadVCustOrder
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'pCustOrderType', 'pCompanyUuid', 'pCustUuid', 'pCustOrderStatusUuid', 'pShippingStatusUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pCustOrderType: '1',
                    pCompanyUuid: '',
                    pCustUuid: '',
                    pCustOrderStatusUuid: 'COS_FINISH',
                    pShippingStatusUuid: ''
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
            sorters: [{
                property: 'CUST_ORDER_CR',
                direction: 'DESC'
            }]
        })
    },
    width: 1000,
    height: 650,
    layout: 'fit',
    resizable: false,
    draggable: false,
    initComponent: function() {
        this.items = [Ext.create('Ext.form.Panel', {
            api: {
                load: WS.CustAction.infoCust,
                submit: WS.CustAction.submitCust
            },
            itemId: 'CustForm',
            paramOrder: ['pCustUuid'],
            //autoScroll: true,
            overflowY: 'scroll',
            border: true,
            bodyPadding: 5,
            buttonAlign: 'center',
            items: [{
                xtype: 'container',
                layout: 'vbox',
                defaultType: 'textfield',
                defaults: {
                    width: 950
                },
                items: [{
                    xtype: 'textfield',
                    fieldLabel: '客戶名稱',
                    itemId: 'CUST_NAME',
                    name: 'CUST_NAME',

                    anchor: '0 0',
                    maxLength: 12,
                    allowBlank: false,
                    labelAlign: 'right'
                }, {
                    xtype: 'container',
                    layout: 'hbox',

                    items: [{
                        xtype: 'textfield',
                        fieldLabel: '電話',
                        labelWidth: 100,
                        name: 'CUST_TEL',
                        flex: 1,
                        maxLength: 84,
                        allowBlank: false,
                        labelAlign: 'right'
                    }, {
                        xtype: 'textfield',
                        fieldLabel: '傳真',
                        labelWidth: 100,
                        name: 'CUST_FAX',
                        flex: 1,
                        maxLength: 340,
                        labelAlign: 'right'
                    }]
                }, {
                    fieldLabel: '地址',
                    labelWidth: 100,
                    margin: '5 0 0 0',
                    name: 'CUST_ADDRESS',
                    anchor: '0 0',
                    labelAlign: 'right'
                }, {
                    xtype: 'fieldcontainer',
                    labelAlign: 'right',
                    fieldLabel: '啟用',
                    layout: 'hbox',
                    defaults: {
                        margins: '0 10 0 0'
                    },
                    defaultType: 'radiofield',
                    items: [{
                        xtype: 'radiofield',
                        boxLabel: '啟用',
                        inputValue: '1',
                        name: 'CUST_IS_ACTIVE',
                        checked: true,
                        flex: 2,
                    }, {
                        xtype: 'radiofield',
                        boxLabel: '不啟用',
                        inputValue: '0',
                        name: 'CUST_IS_ACTIVE',
                        flex: 2,
                    }]
                }, {
                    xtype: 'fieldset',
                    border: true,
                    title: '公司採購人',
                    margin: '0 0 0 105',
                    width: 845,
                    defaults: {
                        anchor: '-10 ',
                        labelAlign: 'right'
                    },
                    items: [{
                        xtype: 'container',
                        layout: 'hbox',
                        padding: '0 0 5 0',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '名稱',
                            name: 'CUST_SALES_NAME',
                            labelAlign: 'right'
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '電話',
                            name: 'CUST_SALES_PHONE',
                            labelAlign: 'right'
                        }]
                    }, {
                        xtype: 'textfield',
                        fieldLabel: 'email',
                        name: 'CUST_SALES_EMAIL'
                    }]
                }, {
                    xtype: 'textarea',
                    fieldLabel: '備註',
                    name: 'CUST_PS',
                    margin: '10 0 0 0',
                    anchor: '0 0',
                    labelAlign: 'right',
                    selectOnFocus: true,
                    grow: true
                }, {
                    xtype: 'combo',
                    fieldLabel: '等級',
                    queryMode: 'local',
                    itemId: 'CUST_LEVEL',
                    labelAlign: 'right',
                    displayField: 'text',
                    valueField: 'value',
                    name: 'CUST_LEVEL',
                    margin: '10 0 0 0',
                    value: '90',
                    editable: false,
                    hidden: false,
                    store: new Ext.data.ArrayStore({
                        fields: ['text', 'value'],
                        data: [
                            ['高', '90'],
                            ['中', '50'],
                            ['低', '20']
                        ]
                    })
                }]
            }, {
                xtype: 'hidden',
                fieldLabel: 'CUST_UUID',
                name: 'CUST_UUID',
                anchor: '100%',
                maxLength: 84,
                itemId: 'CUST_UUID'
            }, {
                xtype: 'gridpanel',
                store: this.myStore.custOrg,
                icon: SYSTEM_URL_ROOT + '/css/custimages/custOrg16x16.png',
                itemId: 'grdCustOrg',
                border: true,
                title: '單位採購人員',
                margin: '0 0 0 105',
                padding: '5 0 0 0',
                autoScroll: true,
                width: 845,
                columns: [{
                    text: "編輯",
                    xtype: 'actioncolumn',
                    dataIndex: 'CUST_ORG_UUID',
                    align: 'center',
                    width: 60,
                    items: [{
                        tooltip: '*編輯',
                        icon: SYSTEM_URL_ROOT + '/css/images/edit16x16.png',
                        handler: function(grid, rowIndex, colIndex) {
                            var main = grid.up('window');
                            var subWin = Ext.create('WS.CustOrgWindow', {
                                param: {
                                    custOrgUuid: grid.getStore().getAt(rowIndex).data.CUST_ORG_UUID,
                                    custUuid: main.param.custUuid,
                                    parentObj: main
                                }
                            });
                            subWin.on('closeEvent', function(obj) {
                                main.down("#grdCustOrg").getStore().load();
                            }, main);
                            subWin.show();
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
                    text: "人員名稱",
                    dataIndex: 'CUST_ORG_SALES_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    text: "電話",
                    dataIndex: 'CUST_ORG_SALES_PHONE',
                    align: 'left',
                    flex: 1
                }, {
                    text: "email",
                    dataIndex: 'CUST_ORG_SALES_EMAIL',
                    align: 'left',
                    flex: 1
                }, {
                    text: "備註",
                    dataIndex: 'CUST_ORG_PS',
                    align: 'left',
                    flex: 1
                }, {
                    text: "有效",
                    dataIndex: 'CUST_ORG_IS_ACTIVE',
                    align: 'center',
                    width: 60,
                    renderer: this.fnActiveRender
                }],
                height: 270,
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.custOrg,
                    displayInfo: true,
                    displayMsg: '第{0}~{1}資料/共{2}筆',
                    emptyMsg: "無資料顯示"
                }),
                tbar: [{
                    icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                    text: '新增採購人員',
                    handler: function() {
                        var main = this.up('window');
                        /*註冊事件*/
                        var subWin = Ext.create('WS.CustOrgWindow', {
                            param: {
                                custOrgUuid: undefined,
                                custUuid: main.param.custUuid,
                                parentObj: main
                            }
                        });
                        subWin.on('closeEvent', function(obj) {
                            main.down("#grdCustOrg").getStore().load();
                        }, main);
                        subWin.show();
                    }
                }]
            }, {
                xtype: 'tabpanel',
                padding: 10,
                maxWidth: 950,
                plain: false,
                items: [{
                    title: '報價單',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/order16x16_1.png',
                    items: [{
                        xtype: 'gridpanel',
                        itemId: 'grdA',
                        autoScroll: true,
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
                                    var main = grid.up('window');
                                    if (!main.subWinCustOrder) {
                                        Ext.MessageBox.show({
                                            title: '系統訊息',
                                            icon: Ext.MessageBox.INFO,
                                            buttons: Ext.Msg.OK,
                                            msg: '未實現 subWinCustOrder 物件,無法進行編輯操作!'
                                        });
                                        return false;
                                    };
                                    var subWin = Ext.create(main.subWinCustOrder, {});                                   
                                    subWin.on('closeEvent', function(obj) {
                                        main.down("#grdA").getStore().reload();
                                    }, main);
                                    subWin.param.custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                                    subWin.param.custUuid = grid.getStore().getAt(rowIndex).data.CUST_UUID;
                                    subWin.show();
                                }
                            }],
                            sortable: false,
                            hideable: false
                        }, {
                            header: "訂單編號",
                            dataIndex: 'CUST_ORDER_ID',
                            align: 'left',
                            width: 150
                        }, {
                            header: '採購員',
                            dataIndex: 'CUST_SALES_NAME',
                            align: 'left',
                            width: 80
                        }, {
                            header: '採購員電話',
                            dataIndex: 'CUST_SALES_PHONE',
                            align: 'left',
                            flex: 1,
                            hidden: true
                        }, {
                            header: '採購員email',
                            dataIndex: 'CUST_SALES_EMAIL',
                            align: 'left',
                            flex: 1,
                            hidden: true
                        }, {
                            header: '備註',
                            dataIndex: 'CUST_PS',
                            align: 'left',
                            flex: 1
                        }],
                        height: 400,
                        store: this.myStore.vcustorderA,
                        tbar: [{
                            xtype: 'tbfill'
                        }, {
                            icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                            text: '新增',
                            handler: function() {
                                var main = this.up('panel').up('panel').up('panel');
                                alert('未完成');

                            }
                        }],
                        bbar: Ext.create('Ext.toolbar.Paging', {
                            store: this.myStore.vcustorderA,
                            displayInfo: true,
                            displayMsg: '第{0}~{1}資料/共{2}筆',
                            emptyMsg: "無資料顯示"
                        })
                    }],
                    listeners: {
                        activate: function(item, eOpts) {
                            item.up('window').down('#CustForm').scrollTo(0, 450, true)
                        }
                    }
                }, {
                    title: '訂單',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/order16x16_2.png',
                    items: [{
                        xtype: 'gridpanel',
                        itemId: 'grdB',
                        autoScroll: true,
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
                                    var main = grid.up('window');
                                    if (!main.subWinCustOrder) {
                                        Ext.MessageBox.show({
                                            title: '系統訊息',
                                            icon: Ext.MessageBox.INFO,
                                            buttons: Ext.Msg.OK,
                                            msg: '未實現 subWinCustOrder 物件,無法進行編輯操作!'
                                        });
                                        return false;
                                    };
                                    var subWin = Ext.create(main.subWinCustOrder, {});
                                    subWin.on('closeEvent', function(obj) {
                                        main.down("#grdB").getStore().reload();
                                    }, main);
                                    subWin.param.custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                                    subWin.param.custUuid = grid.getStore().getAt(rowIndex).data.CUST_UUID;
                                    subWin.show();
                                }
                            }],
                            sortable: false,
                            hideable: false
                        }, {
                            header: "訂單編號",
                            dataIndex: 'CUST_ORDER_ID',
                            align: 'left',
                            width: 150
                        }, {
                            header: '採購員',
                            dataIndex: 'CUST_SALES_NAME',
                            align: 'left',
                            width: 80
                        }, {
                            header: '採購員電話',
                            dataIndex: 'CUST_SALES_PHONE',
                            align: 'left',
                            flex: 1,
                            hidden: true
                        }, {
                            header: '採購員email',
                            dataIndex: 'CUST_SALES_EMAIL',
                            align: 'left',
                            flex: 1,
                            hidden: true
                        }, {
                            header: '備註',
                            dataIndex: 'CUST_PS',
                            align: 'left',
                            flex: 1
                        }],
                        height: 400,
                        store: this.myStore.vcustorderB,
                        tbar: [{
                            xtype: 'tbfill'
                        }, {
                            icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                            text: '新增',
                            handler: function() {
                                var main = this.up('panel').up('panel').up('panel');
                                alert('未完成');

                            }
                        }],
                        bbar: Ext.create('Ext.toolbar.Paging', {
                            store: this.myStore.vcustorderB,
                            displayInfo: true,
                            displayMsg: '第{0}~{1}資料/共{2}筆',
                            emptyMsg: "無資料顯示"
                        })
                    }],
                    listeners: {
                        activate: function(item, eOpts) {
                            item.up('window').down('#CustForm').scrollTo(0, 450, true)
                        }
                    }
                }, {
                    title: '訂單(出貨)',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/order16x16_3.png',
                    items: [{
                        xtype: 'gridpanel',
                        itemId: 'grdC',
                        autoScroll: true,
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
                                    var main = grid.up('window');
                                    if (!main.subWinCustOrder) {
                                        Ext.MessageBox.show({
                                            title: '系統訊息',
                                            icon: Ext.MessageBox.INFO,
                                            buttons: Ext.Msg.OK,
                                            msg: '未實現 subWinCustOrder 物件,無法進行編輯操作!'
                                        });
                                        return false;
                                    };
                                    var subWin = Ext.create(main.subWinCustOrder, {});
                                    subWin.on('closeEvent', function(obj) {
                                        main.down("#grdC").getStore().reload();
                                    }, main);
                                    subWin.param.custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                                    subWin.param.custUuid = grid.getStore().getAt(rowIndex).data.CUST_UUID;
                                    subWin.show();
                                }
                            }],
                            sortable: false,
                            hideable: false
                        }, {
                            header: "訂單編號",
                            dataIndex: 'CUST_ORDER_ID',
                            align: 'left',
                            width: 150
                        }, {
                            header: '採購員',
                            dataIndex: 'CUST_SALES_NAME',
                            align: 'left',
                            width: 80
                        }, {
                            header: '採購員電話',
                            dataIndex: 'CUST_SALES_PHONE',
                            align: 'left',
                            flex: 1,
                            hidden: true
                        }, {
                            header: '採購員email',
                            dataIndex: 'CUST_SALES_EMAIL',
                            align: 'left',
                            flex: 1,
                            hidden: true
                        }, {
                            header: '備註',
                            dataIndex: 'CUST_PS',
                            align: 'left',
                            flex: 1
                        }],
                        height: 400,
                        store: this.myStore.vcustorderC,
                        tbar: [{
                            xtype: 'tbfill'
                        }, {
                            icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                            text: '新增',
                            handler: function() {
                                var main = this.up('panel').up('panel').up('panel');
                                alert('未完成');

                            }
                        }],
                        bbar: Ext.create('Ext.toolbar.Paging', {
                            store: this.myStore.vcustorderC,
                            displayInfo: true,
                            displayMsg: '第{0}~{1}資料/共{2}筆',
                            emptyMsg: "無資料顯示"
                        })
                    }],
                    listeners: {
                        activate: function(item, eOpts) {
                            item.up('window').down('#CustForm').scrollTo(0, 450, true)
                        }
                    }
                }, {
                    title: '訂單(完成)',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/order16x16_3.png',
                    items: [{
                        xtype: 'gridpanel',
                        itemId: 'grdD',
                        autoScroll: true,
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
                                    var main = grid.up('window');
                                    if (!main.subWinCustOrder) {
                                        Ext.MessageBox.show({
                                            title: '系統訊息',
                                            icon: Ext.MessageBox.INFO,
                                            buttons: Ext.Msg.OK,
                                            msg: '未實現 subWinCustOrder 物件,無法進行編輯操作!'
                                        });
                                        return false;
                                    };
                                    var subWin = Ext.create(main.subWinCustOrder, {});
                                    subWin.on('closeEvent', function(obj) {
                                        main.down("#grdD").getStore().reload();
                                    }, main);
                                    subWin.param.custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                                    subWin.param.custUuid = grid.getStore().getAt(rowIndex).data.CUST_UUID;
                                    subWin.show();
                                }
                            }],
                            sortable: false,
                            hideable: false
                        }, {
                            header: "訂單編號",
                            dataIndex: 'CUST_ORDER_ID',
                            align: 'left',
                            width: 150
                        }, {
                            header: '採購員',
                            dataIndex: 'CUST_SALES_NAME',
                            align: 'left',
                            width: 80
                        }, {
                            header: '採購員電話',
                            dataIndex: 'CUST_SALES_PHONE',
                            align: 'left',
                            flex: 1,
                            hidden: true
                        }, {
                            header: '採購員email',
                            dataIndex: 'CUST_SALES_EMAIL',
                            align: 'left',
                            flex: 1,
                            hidden: true
                        }, {
                            header: '備註',
                            dataIndex: 'CUST_PS',
                            align: 'left',
                            flex: 1
                        }],
                        height: 400,
                        store: this.myStore.vcustorderD,
                        tbar: [{
                            xtype: 'tbfill'
                        }, {
                            icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                            text: '新增',
                            handler: function() {
                                var main = this.up('panel').up('panel').up('panel');
                                alert('未完成');

                            }
                        }],
                        bbar: Ext.create('Ext.toolbar.Paging', {
                            store: this.myStore.vcustorderD,
                            displayInfo: true,
                            displayMsg: '第{0}~{1}資料/共{2}筆',
                            emptyMsg: "無資料顯示"
                        })
                    }],
                    listeners: {
                        activate: function(item, eOpts) {
                            item.up('window').down('#CustForm').scrollTo(0, 450, true)
                        }
                    }
                }]
            }],
            fbar: [{
                type: 'button',
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存',
                handler: function() {
                    var form = this.up('window').down("#CustForm").getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            this.param.custUuid = action.result.CUST_UUID;
                            this.down("#CUST_UUID").setValue(action.result.CUST_UUID);
                            Ext.MessageBox.show({
                                title: '操作完成',
                                msg: '操作完成',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                fn: function() {
                                    this.close();
                                },
                                scope: this
                            });
                        },
                        failure: function(form, action) {
                            Ext.MessageBox.show({
                                title: 'Warning',
                                msg: action.result.message,
                                icon: Ext.MessageBox.ERROR,
                                buttons: Ext.Msg.OK
                            });
                        },
                        scope: this.up('window')
                    });
                }
            }, {
                type: 'button',
                icon: SYSTEM_URL_ROOT + '/css/images/delete16x16.png',
                text: '刪除',
                handler: function() {
                    var mainWin = this.up('window');
                    Ext.MessageBox.confirm('刪除廠商操作', '確定要刪除這一個廠商資訊?', function(result) {
                        if (result == 'yes') {
                            var custUuid = mainWin.param.custUuid;
                            WS.CustAction.destoryCust(custUuid, function(obj, jsonObj) {
                                if (jsonObj.result.success) {
                                    this.close();
                                } else {
                                    Ext.MessageBox.show({
                                        title: '刪除廠商操作(1502221728)',
                                        icon: Ext.MessageBox.INFO,
                                        buttons: Ext.Msg.OK,
                                        msg: jsonObj.result.message
                                    });
                                }
                            }, mainWin);
                        }
                    });
                }
            }, {
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
    listeners: {
        'show': function() {
            if (this.param.custUuid != undefined) {
                this.down("#CustForm").getForm().load({
                    params: {
                        'pCustUuid': this.param.custUuid
                    },
                    success: function(response, a, b) {},
                    failure: function(response, jsonObj, b) {
                        if (!jsonObj.result.success) {
                            Ext.MessageBox.show({
                                title: 'Warning',
                                icon: Ext.MessageBox.WARNING,
                                buttons: Ext.Msg.OK,
                                msg: jsonObj.result.message
                            });
                        };
                    }
                });

                this.myStore.custOrg.getProxy().setExtraParam('pCustUuid', this.param.custUuid);
                this.myStore.custOrg.loadPage(1);

                this.myStore.vcustorderA.getProxy().setExtraParam('pCustUuid', this.param.custUuid);
                this.myStore.vcustorderA.loadPage(1);

                this.myStore.vcustorderB.getProxy().setExtraParam('pCustUuid', this.param.custUuid);
                this.myStore.vcustorderB.loadPage(1);

                this.myStore.vcustorderC.getProxy().setExtraParam('pCustUuid', this.param.custUuid);
                this.myStore.vcustorderC.loadPage(1);

                this.myStore.vcustorderD.getProxy().setExtraParam('pCustUuid', this.param.custUuid);
                this.myStore.vcustorderD.loadPage(1);

            } else {
                this.down("#CustForm").getForm().reset();
            };
        },
        'close': function() {
            this.closeEvent();
        }
    }
});
