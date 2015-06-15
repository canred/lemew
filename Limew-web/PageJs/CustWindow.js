/*columns 使用default*/
Ext.define('WS.CustWindow', {
    extend: 'Ext.window.Window',
    title: '客戶維護',
    icon: SYSTEM_URL_ROOT + '/css/custimages/cust16x16.png',
    closeAction: 'destroy',
    closable: false,
    modal: true,
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
            pageSize: 9999,
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
                paramOrder: ['pCustUuid', 'pKeyword', 'pShowIsDefault', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    'pShowIsDefault': '0',
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
        payMethod: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: true,
            model: 'PAY_METHOD',
            remoteSort: true,
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.PayMethodAction.loadPayMethod
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
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
                property: 'PAY_METHOD_ORD',
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
                paramOrder: ['pKeyword', 'pCustOrderType', 'pCompanyUuid', 'pCustUuid', 'pCustOrderStatusUuid', 'pShippingStatusUuid', 'pPayStatusUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pCustOrderType: '',
                    pCompanyUuid: '',
                    pCustUuid: '',
                    pCustOrderStatusUuid: '',
                    pShippingStatusUuid: 'SS_INIT',
                    pPayStatusUuid: ''
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
                    read: WS.CustAction.loadVCustOrderShipping
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'pCustOrderType', 'pCompanyUuid', 'pCustUuid', 'pCustOrderStatusUuid', 'pShippingStatusUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pCustOrderType: '',
                    pCompanyUuid: '',
                    pCustUuid: '',
                    pCustOrderStatusUuid: '',
                    pShippingStatusUuid: 'SS_INPROCESS'
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
                paramOrder: ['pKeyword', 'pCustOrderType', 'pCompanyUuid', 'pCustUuid', 'pCustOrderStatusUuid', 'pShippingStatusUuid', 'pPayStatusUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pCustOrderType: '',
                    pCompanyUuid: '',
                    pCustUuid: '',
                    pCustOrderStatusUuid: '',
                    pShippingStatusUuid: '',
                    pPayStatusUuid: 'pay_status_1'
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
                paramOrder: ['pKeyword', 'pCustOrderType', 'pCompanyUuid', 'pCustUuid', 'pCustOrderStatusUuid', 'pShippingStatusUuid', 'pPayStatusUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pCustOrderType: '',
                    pCompanyUuid: '',
                    pCustUuid: '',
                    pCustOrderStatusUuid: '',
                    pShippingStatusUuid: 'SS_FINISH',
                    pPayStatusUuid: 'pay_status_2'
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
                        xtype: 'container',
                        layout: 'hbox',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '客戶名稱',
                            itemId: 'CUST_NAME',
                            name: 'CUST_NAME',
                            flex: 1,
                            maxLength: 33,
                            allowBlank: false,
                            labelAlign: 'right'
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '統一編號',
                            itemId: 'CUST_UNIFORM_NUM',
                            name: 'CUST_UNIFORM_NUM',
                            anchor: '0 0',
                            flex: 1,
                            maxLength: 33,
                            allowBlank: true,
                            labelAlign: 'right'
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        margin: '5 0 0 0',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '電話',
                            labelWidth: 100,
                            name: 'CUST_TEL',
                            flex: 1,
                            maxLength: 33,
                            allowBlank: false,
                            labelAlign: 'right'
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '傳真',
                            labelWidth: 100,
                            name: 'CUST_FAX',
                            flex: 1,
                            maxLength: 33,
                            labelAlign: 'right'
                        }]
                    }, {
                        fieldLabel: '地址',
                        labelWidth: 100,
                        margin: '5 0 0 0',
                        name: 'CUST_ADDRESS',
                        anchor: '0 0',
                        maxLength: 133,
                        labelAlign: 'right'
                    }, {
                        xtype: 'radiogroup',
                        labelAlign: 'right',
                        fieldLabel: '啟用',
                        layout: 'hbox',
                        defaults: {
                            margins: '0 10 0 0'
                        },
                        defaultType: 'radiofield',
                        itemId: 'CUST_IS_ACTIVE',
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
                    },
                    // {
                    //     xtype: 'fieldset',
                    //     border: true,
                    //     title: '公司採購人',
                    //     margin: '0 0 0 105',
                    //     width: 845,
                    //     defaults: {
                    //         anchor: '-10 ',
                    //         labelAlign: 'right'
                    //     },
                    //     items: [{
                    //         xtype: 'container',
                    //         layout: 'hbox',
                    //         padding: '0 0 5 0',
                    //         items: [{
                    //             xtype: 'textfield',
                    //             fieldLabel: '名稱',
                    //             name: 'CUST_SALES_NAME',
                    //             labelAlign: 'right'
                    //         }, {
                    //             xtype: 'textfield',
                    //             fieldLabel: '電話',
                    //             name: 'CUST_SALES_PHONE',
                    //             labelAlign: 'right'
                    //         }]
                    //     }, {
                    //         xtype: 'textfield',
                    //         fieldLabel: 'email',
                    //         name: 'CUST_SALES_EMAIL'
                    //     }]
                    // }, 
                    {
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
                        hidden: true,
                        queryMode: 'local',
                        itemId: 'CUST_LEVEL',
                        labelAlign: 'right',
                        displayField: 'text',
                        valueField: 'value',
                        name: 'CUST_LEVEL',
                        margin: '10 0 0 0',
                        value: '90',
                        editable: false,
                        store: new Ext.data.ArrayStore({
                            fields: ['text', 'value'],
                            data: [
                                ['高', '90'],
                                ['中', '50'],
                                ['低', '20']
                            ]
                        })
                    }
                ]
            }, {
                xtype: 'hidden',
                fieldLabel: 'CUST_UUID',
                name: 'CUST_UUID',
                anchor: '100%',
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
                columns: [

                    // {
                    //     text: "編輯",
                    //     xtype: 'actioncolumn',
                    //     dataIndex: 'CUST_ORG_UUID',
                    //     align: 'center',
                    //     width: 60,
                    //     items: [{
                    //         tooltip: '*編輯',
                    //         icon: SYSTEM_URL_ROOT + '/css/images/edit16x16.png',
                    //         handler: function(grid, rowIndex, colIndex) {
                    //             var main = grid.up('window');

                    //         }
                    //     }],
                    //     sortable: false,
                    //     hideable: false
                    // }, 

                    {
                        xtype: 'templatecolumn',
                        text: '編輯',
                        width: 60,
                        sortable: false,
                        hideable: false,
                        tpl: new Ext.XTemplate(
                            "<tpl >",
                            '{[this.fnInit()]}<input type="button" style="width:50px" value="編輯" onclick="CustWindowFnEditCustOrg(\'{CUST_ORG_UUID}\',\'{CUST_UUID}\')"/>',
                            "</tpl>", {
                                scope: this,
                                fnInit: function() {
                                    document.CustWindowFnEditCustOrgWin = this.scope;
                                    if (!document.CustWindowFnEditCustOrg) {
                                        document.CustWindowFnEditCustOrg = function(CUST_ORG_UUID, CUST_UUID) {
                                            var main = document.CustWindowFnEditCustOrgWin;
                                            var subWin = Ext.create('WS.CustOrgWindow', {
                                                param: {
                                                    custOrgUuid: CUST_ORG_UUID,
                                                    custUuid: CUST_UUID,
                                                    parentObj: main
                                                }
                                            });
                                            subWin.on('closeEvent', function(obj) {
                                                main.down("#grdCustOrg").getStore().load();
                                            }, main);
                                            subWin.show();
                                        }
                                    }

                                }
                            }),

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
                    }
                ],
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
                border: true,
                items: [{
                    title: '報價單/訂單',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/order16x16_1.png',
                    items: [{
                        xtype: 'gridpanel',
                        itemId: 'grdA',
                        selModel: new Ext.selection.CheckboxModel({
                            mode: 'MULTI',
                            checkOnly: true,
                            renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
                                if (record.data.SHIPPING_STATUS_UUID == "SS_INIT") {
                                    return '<div class="x-grid-row-checker" role="presentation">&nbsp;</div>';
                                } else {
                                    return "";
                                };
                            }
                        }),
                        autoScroll: true,
                        columns: [
                            // {
                            //     text: "編輯",
                            //     xtype: 'actioncolumn',
                            //     dataIndex: 'UUID',
                            //     align: 'center',
                            //     width: 60,
                            //     items: [{
                            //         tooltip: '*編輯',
                            //         icon: SYSTEM_URL_ROOT + '/css/images/edit16x16.png',
                            //         handler: function(grid, rowIndex, colIndex) {
                            //             var main = grid.up('window');
                            //             if (!main.subWinCustOrder) {
                            //                 Ext.MessageBox.show({
                            //                     title: '系統訊息',
                            //                     icon: Ext.MessageBox.INFO,
                            //                     buttons: Ext.Msg.OK,
                            //                     msg: '未實現 subWinCustOrder 物件,無法進行編輯操作!'
                            //                 });
                            //                 return false;
                            //             };
                            //             var subWin = Ext.create(main.subWinCustOrder, {});
                            //             subWin.on('closeEvent', function(obj) {
                            //                 main.down("#grdA").getStore().reload();
                            //             }, main);
                            //             subWin.param.custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                            //             subWin.param.custUuid = grid.getStore().getAt(rowIndex).data.CUST_UUID;
                            //             subWin.show();
                            //         }
                            //     }],
                            //     sortable: false,
                            //     hideable: false
                            // }
                            {
                                xtype: 'templatecolumn',
                                text: '編輯',
                                width: 60,
                                sortable: false,
                                hideable: false,
                                tpl: new Ext.XTemplate(
                                    "<tpl >",
                                    '{[this.fnInit()]}<input type="button" style="width:50px" value="編輯" onclick="CustWindowFnEditCustOrder1(\'{CUST_ORDER_UUID}\',\'{CUST_UUID}\')"/>',
                                    "</tpl>", {
                                        scope: this,
                                        fnInit: function() {
                                            document.CustWindow = this.scope;
                                            if (!document.CustWindowFnEditCustOrder1) {
                                                document.CustWindowFnEditCustOrder1 = function(CUST_ORDER_UUID, CUST_UUID) {
                                                    var main = document.CustWindow;
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
                                                    subWin.param.custOrderUuid = CUST_ORDER_UUID;
                                                    subWin.param.custUuid = CUST_UUID;
                                                    subWin.show();
                                                }
                                            }

                                        }
                                    }),

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
                                header: '金額',
                                dataIndex: 'CUST_ORDER_TOTAL_PRICE',
                                align: 'right',
                                width: 80,
                                renderer: function(value, r) {
                                    return Ext.String.format('${0}', value);
                                }
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
                            }
                        ],
                        height: 400,
                        store: this.myStore.vcustorderA,
                        tbar: [{
                            icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                            text: '新增(報價單)',
                            itemId: 'btnAddCustOrderDetail',
                            handler: function() {
                                var main = this.up('window');
                                WS.CustAction.createCustOrder(function(obj, jsonObj) {
                                    if (jsonObj.result.success && jsonObj.result.CUST_ORDER_UUID) {

                                        var subWin = Ext.create(main.subWinCustOrder, {
                                            param: {
                                                custOrderUuid: jsonObj.result.CUST_ORDER_UUID,
                                                custUuid: undefined,
                                                parentObj: this
                                            }
                                        });

                                        subWin.on('closeEvent', function(obj) {
                                            main.down("#grdA").getStore().load();
                                        }, this);
                                        subWin.show();
                                    }
                                }, main);
                            }
                        }, {
                            xtype: 'tbfill'
                        }, {
                            icon: SYSTEM_URL_ROOT + '/css/images/okA16x16.png',
                            text: '出貨處理',
                            itemId: 'btnShipping',
                            handler: function() {
                                var main = this.up('window'),
                                    grid = main.down('#grdA'),
                                    selectRecord = grid.getSelection();
                                if (selectRecord.length == 0) {
                                    Ext.MessageBox.show({
                                        title: '操作提示',
                                        icon: Ext.MessageBox.INFO,
                                        buttons: Ext.Msg.OK,
                                        msg: '請先選擇預出貨的訂單。'
                                    });
                                } else {
                                    var postData = '';
                                    //var hasAddressEmpty = false;
                                    Ext.each(selectRecord, function(item) {
                                        //if (!Ext.isEmpty(item.data.SHIPPING_ADDRESS)) {
                                        postData += item.data.CUST_ORDER_UUID + "|";
                                        // } else {
                                        //     hasAddressEmpty = true;
                                        // };
                                    });
                                    // if (hasAddressEmpty == true) {
                                    //     Ext.MessageBox.show({
                                    //         title: '操作提示',
                                    //         icon: Ext.MessageBox.INFO,
                                    //         buttons: Ext.Msg.OK,
                                    //         msg: '請檢查訂單出貨地址，發現有空的出貨地址!'
                                    //     });
                                    //     return;
                                    // };
                                    WS.CustAction.shippingInProcessCustOrder(postData, function(obj, jsonObj) {
                                        if (jsonObj.result.success && jsonObj.result.success == true) {
                                            var shippCount = jsonObj.result.shippingCount;
                                            if (shippCount > 0) {
                                                Ext.MessageBox.show({
                                                    title: '完成出貨處理',
                                                    icon: Ext.MessageBox.INFO,
                                                    buttons: Ext.Msg.OK,
                                                    msg: '完成' + shippCount + '筆訂單完成出貨處理。',
                                                    scope: this,
                                                    fn: function() {
                                                        this.myStore.vcustorderA.reload();
                                                    }
                                                });
                                            }
                                        }
                                    }, main);
                                };
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
                            item.up('window').down('#CustForm').scrollTo(0, 450, true);
                            if (this.param.custUuid) {
                                this.myStore.vcustorderA.getProxy().setExtraParam('pCustUuid', this.param.custUuid);
                                this.myStore.vcustorderA.reload();
                            }
                        },
                        scope: this
                    }
                }, {
                    title: '訂單(出貨)',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/order16x16_2.png',
                    items: [{
                        xtype: 'gridpanel',
                        itemId: 'grdB',
                        plugins: {
                            ptype: 'cellediting',
                            clicksToEdit: 1,
                            listeners: {
                                beforeedit: function(editor, context, eOpts) {
                                    var mainPanel = context.grid.up('window');
                                    mainPanel.param.editRecord = context.record;
                                    mainPanel.param.editRowIdx = context.rowIdx;
                                    mainPanel.param.editColIdx = context.colIdx;
                                },
                                edit: function(editor, context, eOpts) {
                                    var mainPanel = context.grid.up('window');
                                    mainPanel.param.editRowIdx = context.rowIdx;
                                    mainPanel.param.editColIdx = context.colIdx;
                                }
                            }
                        },
                        autoScroll: true,
                        selModel: new Ext.selection.CheckboxModel({
                            mode: 'MULTI',
                            checkOnly: true,
                            renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
                                if (record.data.SHIPPING_STATUS_UUID == "SS_INPROCESS") {
                                    return '<div class="x-grid-row-checker" role="presentation">&nbsp;</div>';
                                } else {
                                    return "";
                                };
                            }
                        }),
                        columns: [
                            // {
                            //     text: "",
                            //     xtype: 'actioncolumn',
                            //     dataIndex: 'UUID',
                            //     align: 'center',
                            //     width: 30,
                            //     items: [{
                            //         tooltip: '*查看',
                            //         icon: SYSTEM_URL_ROOT + '/css/custimages/view16x16.png',
                            //         handler: function(grid, rowIndex, colIndex) {
                            //             var main = grid.up('window');
                            //             var subWin = Ext.create('WS.CustOrderStep1ViewWindow', {});
                            //             subWin.on('closeEvent', function(obj) {}, main);
                            //             subWin.param.custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                            //             subWin.param.custUuid = grid.getStore().getAt(rowIndex).data.CUST_UUID;
                            //             subWin.show();
                            //         }
                            //     }],
                            //     sortable: false,
                            //     hideable: false
                            // },
                            {
                                xtype: 'templatecolumn',
                                text: '查看',
                                width: 60,
                                sortable: false,
                                hideable: false,
                                tpl: new Ext.XTemplate(
                                    "<tpl >",
                                    '{[this.fnInit()]}<input type="button" style="width:50px" value="查看" onclick="CustWindowFnView(\'{CUST_ORDER_UUID}\',\'{CUST_UUID}\')"/>',
                                    "</tpl>", {
                                        scope: this,
                                        fnInit: function() {
                                            document.CustWindow = this.scope;
                                            if (!document.CustWindowFnView) {
                                                document.CustWindowFnView = function(CUST_ORDER_UUID, CUST_UUID) {
                                                    var main = document.CustWindow;
                                                    var subWin = Ext.create('WS.CustOrderStep1ViewWindow', {});
                                                    subWin.on('closeEvent', function(obj) {}, main);
                                                    subWin.param.custOrderUuid = CUST_ORDER_UUID;
                                                    subWin.param.custUuid = CUST_UUID;
                                                    subWin.show();
                                                }
                                            }

                                        }
                                    }),

                            },
                            // {
                            //     text: "",
                            //     xtype: 'actioncolumn',
                            //     dataIndex: 'UUID',
                            //     align: 'center',
                            //     width: 30,
                            //     items: [{
                            //         tooltip: '*退回到訂單狀態',
                            //         icon: SYSTEM_URL_ROOT + '/css/custimages/back16x16.png',
                            //         handler: function(grid, rowIndex, colIndex) {
                            //             var main = grid.up('window');
                            //             var custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                            //             Ext.MessageBox.confirm('請確認', '將此單退回到訂單狀態?', function(result) {
                            //                 if (result == 'yes') {
                            //                     WS.CustAction.backToOrder(custOrderUuid, function(obj, jsonObj) {
                            //                         var findData = this.myStore.vcustorderB.findRecord("CUST_ORDER_UUID", jsonObj.result.CUST_ORDER_UUID);
                            //                         this.myStore.vcustorderB.remove(findData);
                            //                     }, this);
                            //                 }
                            //             }, main);
                            //         }
                            //     }],
                            //     sortable: false,
                            //     hideable: false
                            // },
                            {
                                xtype: 'templatecolumn',
                                text: '退回',
                                width: 60,
                                sortable: false,
                                hideable: false,
                                tpl: new Ext.XTemplate(
                                    "<tpl >",
                                    '{[this.fnInit()]}<input type="button" style="width:50px" value="退回" onclick="CustWindowFnBack1(\'{CUST_ORDER_UUID}\',\'{CUST_UUID}\')"/>',
                                    "</tpl>", {
                                        scope: this,
                                        fnInit: function() {
                                            document.CustWindow = this.scope;
                                            if (!document.CustWindowFnBack1) {
                                                document.CustWindowFnBack1 = function(CUST_ORDER_UUID, CUST_UUID) {
                                                    var main = document.CustWindow;
                                                    var custOrderUuid = CUST_ORDER_UUID;
                                                    Ext.MessageBox.confirm('請確認', '將此單退回到訂單狀態?', function(result) {
                                                        if (result == 'yes') {
                                                            WS.CustAction.backToOrder(custOrderUuid, function(obj, jsonObj) {
                                                                var findData = this.myStore.vcustorderB.findRecord("CUST_ORDER_UUID", jsonObj.result.CUST_ORDER_UUID);
                                                                this.myStore.vcustorderB.remove(findData);
                                                            }, this);
                                                        }
                                                    }, main);
                                                }
                                            }

                                        }
                                    }),

                            }, {
                                header: "訂單編號",
                                dataIndex: 'CUST_ORDER_ID',
                                align: 'left',
                                width: 150
                            }, {
                                header: "單位",
                                dataIndex: 'CUST_ORDER_DEPT',
                                align: 'left',
                                width: 150
                            }, {
                                header: '採購員',
                                dataIndex: 'CUST_ORG_SALES_NAME',
                                align: 'left',
                                width: 80
                            }, {
                                header: '聯絡電話',
                                dataIndex: 'CUST_ORG_SALES_PHONE',
                                align: 'left',
                                width: 120,
                                hidden: false
                            }, {
                                header: '金額',
                                dataIndex: 'CUST_ORDER_TOTAL_PRICE',
                                align: 'right',
                                width: 80,
                                renderer: function(value, r) {
                                    return Ext.String.format('${0}', value);
                                }
                            }, {
                                xtype: 'templatecolumn',
                                header: '發票號碼',
                                dataIndex: 'CUST_ORDER_INVOICE_NUMBER',
                                align: 'right',
                                width: 150,
                                layout: 'hbox',
                                tpl: new Ext.XTemplate(
                                    "<tpl if='SHIPPING_STATUS_UUID == \"SS_INPROCESS\"'>",
                                    '<input readonly type="text" style="width:130px;background-color:#75D966" value="{CUST_ORDER_INVOICE_NUMBER}"/>',
                                    "<tpl else>",
                                    '{CUST_ORDER_INVOICE_NUMBER}',
                                    "</tpl>"),
                                editor: {
                                    xtype: 'textfield',
                                    flex: 1,
                                    listeners: {
                                        focus: function(obj, eOpts) {
                                            var mainPanel = obj.up('window');
                                            if (mainPanel.param.editRecord.data.SHIPPING_STATUS_UUID != "SS_INPROCESS") {
                                                obj.setReadOnly(true);
                                            } else {
                                                obj.setReadOnly(false);
                                            }
                                        }
                                    }
                                }
                            }, {
                                header: "出貨編號",
                                dataIndex: 'CUST_ORDER_SHIPPING_NUMBER',
                                align: 'left',
                                width: 150
                            }, {
                                header: "出貨地址",
                                dataIndex: 'SHIPPING_ADDRESS',
                                align: 'left',
                                width: 150
                            }, {
                                header: '採購員電話',
                                dataIndex: 'CUST_SALES_PHONE',
                                align: 'left',
                                flex: 1,
                                hidden: true
                            }, {
                                header: "傳真",
                                dataIndex: 'CUST_FAX',
                                align: 'left',
                                flex: 1,
                                hidden: true
                            }, {
                                header: '備註',
                                dataIndex: 'CUST_ORDER_PS',
                                align: 'left',
                                flex: 1
                            }
                        ],
                        height: 400,
                        store: this.myStore.vcustorderB,
                        tbar: [{
                            icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                            text: '儲存全部',
                            itemId: 'btnSaveAll',
                            handler: function() {
                                var mainPanel = this.up('window');
                                var updateData = "";
                                Ext.each(mainPanel.myStore.vcustorderB.data.items, function(item) {
                                    updateData += item.data.CUST_ORDER_UUID + "``" + item.data.CUST_ORDER_INVOICE_NUMBER + "`" + item.data.CUST_ORDER_PAY_PS + "|";
                                });
                                WS.CustAction.batchUpdateCustOrderInvoice(updateData, function(obj, jsonObj) {
                                    mainPanel.myStore.vcustorderB.reload();
                                }, mainPanel);
                            }
                        }, {
                            xtype: 'tbfill'
                        }, {
                            icon: SYSTEM_URL_ROOT + '/css/images/okA16x16.png',
                            text: '確定出貨',
                            itemId: 'btnShippingConfirm',
                            handler: function() {
                                var main = this.up('window'),
                                    grid = main.down('#grdB'),
                                    selectRecord = grid.getSelection();
                                if (selectRecord.length == 0) {
                                    Ext.MessageBox.show({
                                        title: '操作提示',
                                        icon: Ext.MessageBox.INFO,
                                        buttons: Ext.Msg.OK,
                                        msg: '請先選擇預出貨的訂單。'
                                    });
                                } else {
                                    if (main.myStore.vcustorderB.getModifiedRecords().length > 0) {
                                        var updateData = "";
                                        Ext.each(main.myStore.vcustorderB.data.items, function(item) {
                                            //updateData += item.data.CUST_ORDER_UUID + ",," + item.data.CUST_ORDER_INVOICE_NUMBER + "|";
                                            updateData += item.data.CUST_ORDER_UUID + "``" + item.data.CUST_ORDER_INVOICE_NUMBER + "`" + item.data.CUST_ORDER_PAY_PS + "|";
                                        });

                                        var hasErrorData = false;
                                        Ext.each(selectRecord, function(item) {
                                            if (item.data.CUST_ORDER_INVOICE_NUMBER == "") {
                                                hasErrorData = true;
                                            }
                                        });

                                        if (hasErrorData) {
                                            Ext.MessageBox.show({
                                                title: '系統提示',
                                                icon: Ext.MessageBox.INFO,
                                                buttons: Ext.Msg.OK,
                                                msg: '有部份訂單的發票號為空，所以停止操作!'
                                            });
                                            return;
                                        };

                                        WS.CustAction.batchUpdateCustOrderInvoice(updateData, function(obj, jsonObj) {
                                            var postData = '';
                                            // var hasAddressEmpty = false;
                                            Ext.each(selectRecord, function(item) {
                                                //if (!Ext.isEmpty(item.data.SHIPPING_ADDRESS)) {
                                                postData += item.data.CUST_ORDER_UUID + "|";
                                                // } else {
                                                //     hasAddressEmpty = true;
                                                // };
                                            });
                                            // if (hasAddressEmpty == true) {
                                            //     Ext.MessageBox.show({
                                            //         title: '操作提示',
                                            //         icon: Ext.MessageBox.INFO,
                                            //         buttons: Ext.Msg.OK,
                                            //         msg: '請檢查訂單出貨地址，發現有空的出貨地址!'
                                            //     });
                                            //     return;
                                            // };
                                            if (postData.length == 0) {
                                                return;
                                            };
                                            WS.CustAction.shippingCustOrder(postData, function(obj, jsonObj) {
                                                if (jsonObj.result.success && jsonObj.result.success == true) {
                                                    var shippCount = jsonObj.result.shippingCount;
                                                    if (shippCount > 0) {
                                                        Ext.MessageBox.show({
                                                            title: '完成出貨',
                                                            icon: Ext.MessageBox.INFO,
                                                            buttons: Ext.Msg.OK,
                                                            msg: '完成' + shippCount + '筆訂單出貨。',
                                                            fn: function() {
                                                                this.myStore.vcustorderB.reload();
                                                            },
                                                            scope: this
                                                        });
                                                    }
                                                }
                                            }, main);
                                        }, main);
                                    } else {
                                        var postData = '';
                                        //var hasAddressEmpty = false;
                                        Ext.each(selectRecord, function(item) {
                                            //if (!Ext.isEmpty(item.data.SHIPPING_ADDRESS)) {
                                            postData += item.data.CUST_ORDER_UUID + "|";
                                            // } else {
                                            //     hasAddressEmpty = true;
                                            // };
                                        });

                                        var hasErrorData = false;
                                        Ext.each(selectRecord, function(item) {
                                            if (item.data.CUST_ORDER_INVOICE_NUMBER == "") {
                                                hasErrorData = true;
                                            }
                                        });

                                        if (hasErrorData) {
                                            Ext.MessageBox.show({
                                                title: '系統提示',
                                                icon: Ext.MessageBox.INFO,
                                                buttons: Ext.Msg.OK,
                                                msg: '有部份訂單的發票號為空，所以停止操作!'
                                            });
                                            return;
                                        };

                                        // if (hasAddressEmpty == true) {
                                        //     Ext.MessageBox.show({
                                        //         title: '操作提示',
                                        //         icon: Ext.MessageBox.INFO,
                                        //         buttons: Ext.Msg.OK,
                                        //         msg: '請檢查訂單出貨地址，發現有空的出貨地址!'
                                        //     });
                                        //     return;
                                        // };
                                        if (postData.length == 0) {
                                            return;
                                        };
                                        WS.CustAction.shippingCustOrder(postData, function(obj, jsonObj) {
                                            if (jsonObj.result.success && jsonObj.result.success == true) {
                                                var shippCount = jsonObj.result.shippingCount;
                                                if (shippCount > 0) {
                                                    Ext.MessageBox.show({
                                                        title: '完成出貨',
                                                        icon: Ext.MessageBox.INFO,
                                                        buttons: Ext.Msg.OK,
                                                        msg: '完成' + shippCount + '筆訂單出貨。',
                                                        fn: function() {
                                                            this.myStore.vcustorderB.reload();
                                                        },
                                                        scope: this
                                                    });
                                                }
                                            }
                                        }, main);
                                    }
                                };
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
                            item.up('window').down('#CustForm').scrollTo(0, 450, true);
                            if (this.param.custUuid) {
                                this.myStore.vcustorderB.getProxy().setExtraParam('pCustUuid', this.param.custUuid);
                                this.myStore.vcustorderB.reload();
                            }
                        },
                        scope: this
                    }
                }, {
                    title: '訂單(款項)',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/order16x16_3.png',
                    items: [{
                        xtype: 'gridpanel',
                        itemId: 'grdC',
                        autoScroll: true,
                        plugins: {
                            ptype: 'cellediting',
                            clicksToEdit: 1,
                            listeners: {
                                beforeedit: function(editor, context, eOpts) {
                                    var mainPanel = context.grid.up('window');
                                    mainPanel.param.editRecord = context.record;
                                    mainPanel.param.editRowIdx = context.rowIdx;
                                    mainPanel.param.editColIdx = context.colIdx;
                                },
                                edit: function(editor, context, eOpts) {
                                    var mainPanel = context.grid.up('window');
                                    mainPanel.param.editRowIdx = context.rowIdx;
                                    mainPanel.param.editColIdx = context.colIdx;
                                }
                            }
                        },
                        selModel: new Ext.selection.CheckboxModel({
                            mode: 'MULTI',
                            checkOnly: true,
                            renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
                                if (record.data.PAY_STATUS_UUID != "pay_status_3") {
                                    return '<div class="x-grid-row-checker" role="presentation">&nbsp;</div>';
                                } else {
                                    return "";
                                };
                            }
                        }),
                        columns: [
                            // {
                            //     text: "",
                            //     xtype: 'actioncolumn',
                            //     dataIndex: 'UUID',
                            //     align: 'center',
                            //     width: 30,
                            //     items: [{
                            //         tooltip: '*查看',
                            //         icon: SYSTEM_URL_ROOT + '/css/custimages/view16x16.png',
                            //         handler: function(grid, rowIndex, colIndex) {
                            //             var main = grid.up('window');
                            //             var subWin = Ext.create('WS.CustOrderStep1ViewWindow', {});
                            //             subWin.on('closeEvent', function(obj) {}, main);
                            //             subWin.param.custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                            //             subWin.param.custUuid = grid.getStore().getAt(rowIndex).data.CUST_UUID;
                            //             subWin.show();
                            //         }
                            //     }],
                            //     sortable: false,
                            //     hideable: false
                            // }, 

                            {
                                xtype: 'templatecolumn',
                                text: '查看',
                                width: 60,
                                sortable: false,
                                hideable: false,
                                tpl: new Ext.XTemplate(
                                    "<tpl >",
                                    '{[this.fnInit()]}<input type="button" style="width:50px" value="查看" onclick="CustWindowFnView2(\'{CUST_ORDER_UUID}\',\'{CUST_UUID}\')"/>',
                                    "</tpl>", {
                                        scope: this,
                                        fnInit: function() {
                                            document.CustWindow = this.scope;
                                            if (!document.CustWindowFnView2) {
                                                document.CustWindowFnView2 = function(CUST_ORDER_UUID, CUST_UUID) {
                                                    var main = document.CustWindow;
                                                    var subWin = Ext.create('WS.CustOrderStep1ViewWindow', {});
                                                    subWin.on('closeEvent', function(obj) {}, main);
                                                    subWin.param.custOrderUuid = CUST_ORDER_UUID;
                                                    subWin.param.custUuid = CUST_UUID;
                                                    subWin.show();
                                                }
                                            }

                                        }
                                    }),

                            },
                            // {
                            //     text: "",
                            //     xtype: 'actioncolumn',
                            //     dataIndex: 'UUID',
                            //     align: 'center',
                            //     width: 30,
                            //     items: [{
                            //         tooltip: '*退回到出貨狀態',
                            //         icon: SYSTEM_URL_ROOT + '/css/custimages/back16x16.png',
                            //         handler: function(grid, rowIndex, colIndex) {
                            //             var main = grid.up('window');
                            //             var custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                            //             Ext.MessageBox.confirm('請確認', '將此單退回到出貨狀態?', function(result) {
                            //                 if (result == 'yes') {
                            //                     WS.CustAction.backToShipping(custOrderUuid, function(obj, jsonObj) {
                            //                         var findData = this.myStore.vcustorderC.findRecord("CUST_ORDER_UUID", jsonObj.result.CUST_ORDER_UUID);
                            //                         this.myStore.vcustorderC.remove(findData);
                            //                     }, this);
                            //                 }
                            //             }, main);
                            //         }
                            //     }],
                            //     sortable: false,
                            //     hideable: false
                            // }, 
                            {
                                xtype: 'templatecolumn',
                                text: '退回',
                                width: 60,
                                sortable: false,
                                hideable: false,
                                tpl: new Ext.XTemplate(
                                    "<tpl >",
                                    '{[this.fnInit()]}<input type="button" style="width:50px" value="退回" onclick="CustWindowFnBack2(\'{CUST_ORDER_UUID}\',\'{CUST_UUID}\')"/>',
                                    "</tpl>", {
                                        scope: this,
                                        fnInit: function() {
                                            document.CustWindow = this.scope;
                                            if (!document.CustWindowFnBack2) {
                                                document.CustWindowFnBack2 = function(CUST_ORDER_UUID, CUST_UUID) {
                                                    var main = document.CustWindow;
                                                    var custOrderUuid = CUST_ORDER_UUID;
                                                    Ext.MessageBox.confirm('請確認', '將此單退回到出貨狀態?', function(result) {
                                                        if (result == 'yes') {
                                                            WS.CustAction.backToShipping(custOrderUuid, function(obj, jsonObj) {
                                                                var findData = this.myStore.vcustorderC.findRecord("CUST_ORDER_UUID", jsonObj.result.CUST_ORDER_UUID);
                                                                this.myStore.vcustorderC.remove(findData);
                                                            }, this);
                                                        }
                                                    }, main);
                                                }
                                            }

                                        }
                                    }),

                            }, {
                                header: "訂單編號",
                                dataIndex: 'CUST_ORDER_ID',
                                align: 'left',
                                width: 150
                            }, {
                                header: "單位",
                                dataIndex: 'CUST_ORDER_DEPT',
                                align: 'left',
                                width: 150,
                                hidden: true
                            }, {
                                header: '採購員',
                                dataIndex: 'CUST_ORG_SALES_NAME',
                                align: 'left',
                                width: 80
                            }, {
                                header: '聯絡電話',
                                dataIndex: 'CUST_ORG_SALES_PHONE',
                                align: 'left',
                                width: 120,
                                hidden: false
                            }, {
                                header: '金額',
                                dataIndex: 'CUST_ORDER_TOTAL_PRICE',
                                align: 'right',
                                width: 80,
                                renderer: function(value, r) {
                                    return Ext.String.format('${0}', value);
                                }
                            }, {
                                header: '付款狀態',
                                dataIndex: 'PAY_STATUS_NAME',
                                width: 80,
                                renderer: function(value, r) {
                                    if (r.record.data.PAY_STATUS_UUID == 'pay_status_2') {
                                        return "<div style='background-color:#75D966;width:80px;'>&nbsp;" + r.record.data.PAY_STATUS_NAME + "</div>";
                                    } else {
                                        return "<div style='background-color:white;width:80px;'>&nbsp;" + r.record.data.PAY_STATUS_NAME + "</div>";
                                    }

                                }
                            }, {
                                header: '款項方式',
                                width: 100,
                                dataIndex: 'PAY_METHOD_UUID',
                                renderer: function(value, r) {
                                    if (r.record.data.PAY_STATUS_UUID == 'pay_status_2') {
                                        return "<div style='background-color:#75D966;width:80px;'>&nbsp;" + r.record.data.PAY_METHOD_NAME + "</div>";
                                    } else {
                                        return "<div style='background-color:white;width:80px;'>&nbsp;" + r.record.data.PAY_METHOD_NAME + "</div>";
                                    }

                                },
                                editor: {
                                    xtype: 'combo',
                                    allowBlank: false,
                                    displayField: 'PAY_METHOD_NAME',
                                    valueField: 'PAY_METHOD_UUID',
                                    store: this.myStore.payMethod,
                                    editable: false,
                                    hidden: false,
                                    listeners: {
                                        change: function(obj, newValue, oldValue, eOpts) {
                                            var mainPanel = obj.up('window');
                                            if (Ext.isEmpty(newValue)) {
                                                return true;
                                            };
                                            var dr = obj.getStore().findRecord("PAY_METHOD_UUID", newValue).data;
                                            mainPanel.param.editRecord.data.PAY_METHOD_NAME = dr.PAY_METHOD_NAME;
                                        }
                                    }
                                }
                            }, {
                                xtype: 'templatecolumn',
                                header: '款項備註',
                                dataIndex: 'CUST_ORDER_PAY_PS',
                                align: 'right',
                                width: 140,
                                layout: 'hbox',
                                tpl: '<input type="text" readonly style="width:130px;background-color:#75D966;" value="{CUST_ORDER_PAY_PS}"/>',
                                renderer: function(value, r) {
                                    if (r.record.data.PAY_STATUS_UUID == 'pay_status_2') {
                                        return '<input type="text" readonly style="width:130px;background-color:#75D966;" value="' + r.record.data.CUST_ORDER_PAY_PS + '"/>';
                                    } else {
                                        return '<input type="text" readonly style="width:130px;background-color:white;" value="' + r.record.data.CUST_ORDER_PAY_PS + '"/>';
                                    }

                                },
                                editor: {
                                    xtype: 'textfield',
                                    flex: 1,
                                    listeners: {
                                        focus: function(obj, eOpts) {
                                            var mainPanel = obj.up('window');
                                            if (mainPanel.param.editRecord.data.PAY_STATUS_UUID == 'pay_status_1') {
                                                obj.setReadOnly(false);
                                            } else {
                                                obj.setReadOnly(true);
                                            }
                                        }
                                    }
                                }
                            }, {
                                xtype: 'templatecolumn',
                                header: '發票號碼',
                                dataIndex: 'CUST_ORDER_INVOICE_NUMBER',
                                align: 'right',
                                width: 140,
                                layout: 'hbox',
                                tpl: '<input type="text" readonly style="width:130px;background-color:#75D966;" value="{CUST_ORDER_INVOICE_NUMBER}"/>',
                                renderer: function(value, r) {
                                    if (r.record.data.PAY_STATUS_UUID == 'pay_status_2') {
                                        return '<input type="text" readonly style="width:130px;background-color:#75D966;" value="' + r.record.data.CUST_ORDER_INVOICE_NUMBER + '"/>';
                                    } else {
                                        return '<input type="text" readonly style="width:130px;background-color:white;" value="' + r.record.data.CUST_ORDER_INVOICE_NUMBER + '"/>';
                                    }

                                },
                                editor: {
                                    xtype: 'textfield',
                                    flex: 1,
                                    listeners: {
                                        focus: function(obj, eOpts) {
                                            var mainPanel = obj.up('window');
                                        }
                                    }
                                }
                            }, {
                                header: "出貨編號",
                                dataIndex: 'CUST_ORDER_SHIPPING_NUMBER',
                                align: 'left',
                                width: 150
                            }, {
                                header: "出貨地址",
                                dataIndex: 'SHIPPING_ADDRESS',
                                align: 'left',
                                width: 150
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
                                header: '出貨狀態',
                                dataIndex: 'SHIPPING_STATUS_NAME',
                                align: 'left',
                                flex: 1
                            }, {
                                header: '備註',
                                dataIndex: 'CUST_ORDER_PS',
                                align: 'left',
                                flex: 1,
                                renderer: function(value, r) {
                                    var id = Ext.id();
                                    var mainPanel = this.up('window');
                                    Ext.defer(function() {
                                        var s = {};
                                        if (r.record.data.CUST_ORDER_PS.length > 0) {
                                            s = {
                                                'background-color': 'red'
                                            }
                                        };
                                        Ext.widget('button', {
                                            renderTo: id,
                                            style: s,
                                            text: '備註',
                                            width: 50,
                                            handler: function() {
                                                var subWin = Ext.create('WS.CustOrderPsWindow', {
                                                    param: {
                                                        custOrderUuid: r.record.data.CUST_ORDER_UUID,
                                                        parentObj: mainPanel
                                                    }
                                                });
                                                subWin.on('closeEvent', function(obj) {
                                                    obj.param.parentObj.myStore.vcustorderC.reload();
                                                });
                                                subWin.show();
                                            }
                                        });
                                    }, 50);
                                    return Ext.String.format('<div id="{0}"></div>', id);
                                }
                            }
                        ],
                        height: 400,
                        store: this.myStore.vcustorderC,
                        tbar: [{
                            icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                            text: '全部儲存',
                            itemId: 'btnSaveAll2',
                            handler: function() {
                                var mainPanel = this.up('window');
                                var updateData = "";
                                Ext.each(mainPanel.myStore.vcustorderC.data.items, function(item) {
                                    updateData += item.data.CUST_ORDER_UUID + "`" + item.data.PAY_METHOD_UUID + "`" + item.data.CUST_ORDER_INVOICE_NUMBER + "`" + item.data.CUST_ORDER_PAY_PS + "|";
                                    //updateData += item.data.CUST_ORDER_UUID + "``" + item.data.CUST_ORDER_INVOICE_NUMBER +"`"+item.data.CUST_ORDER_PAY_PS+ "|";
                                });
                                WS.CustAction.batchUpdateCustOrderInvoice(updateData, function(obj, jsonObj) {
                                    mainPanel.myStore.vcustorderC.reload();
                                }, mainPanel);
                            }
                        }, {
                            xtype: 'tbfill'
                        }, {
                            xtype: 'button',
                            text: '付款完成',
                            itemId: 'btnInvoiceComplete',
                            icon: SYSTEM_URL_ROOT + '/css/images/okA16x16.png',
                            handler: function(handler, scope) {
                                var main = this.up('window'),
                                    grid = main.down('#grdC'),
                                    selectRecord = grid.getSelection();
                                if (selectRecord.length == 0) {
                                    Ext.MessageBox.show({
                                        title: '操作提示',
                                        icon: Ext.MessageBox.INFO,
                                        buttons: Ext.Msg.OK,
                                        msg: '請先選擇預訂單。'
                                    });
                                } else {
                                    if (main.myStore.vcustorderC.getModifiedRecords().length > 0) {
                                        var updateData = "";
                                        Ext.each(main.myStore.vcustorderC.data.items, function(item) {
                                            //updateData += item.data.CUST_ORDER_UUID + "," + item.data.PAY_METHOD_UUID + "," + item.data.CUST_ORDER_INVOICE_NUMBER + "|";
                                            updateData += item.data.CUST_ORDER_UUID + "`" + item.data.PAY_METHOD_UUID + "`" + item.data.CUST_ORDER_INVOICE_NUMBER + "`" + item.data.CUST_ORDER_PAY_PS + "|";
                                        });
                                        WS.CustAction.batchUpdateCustOrderInvoice(updateData, function(obj, jsonObj) {
                                            var postData = '';
                                            var hasErrorData = false;
                                            Ext.each(selectRecord, function(item) {
                                                if (item.data.PAY_METHOD_UUID != "" && item.data.CUST_ORDER_INVOICE_NUMBER != "") {
                                                    postData += item.data.CUST_ORDER_UUID + "|";
                                                } else {
                                                    hasErrorData = true;
                                                }
                                            });
                                            if (hasErrorData) {
                                                Ext.MessageBox.show({
                                                    title: '系統提示',
                                                    icon: Ext.MessageBox.INFO,
                                                    buttons: Ext.Msg.OK,
                                                    msg: '有部份訂單的付款方式或發票號為空!'
                                                });
                                            };
                                            if (postData.length == 0) {
                                                return;
                                            };
                                            WS.CustAction.payCompleteCustOrder(postData, function(obj, jsonObj) {
                                                if (jsonObj.result.success && jsonObj.result.success == true) {
                                                    var payCompleteCount = jsonObj.result.payCompleteCount;
                                                    if (payCompleteCount > 0) {
                                                        Ext.MessageBox.show({
                                                            title: '付款完成',
                                                            icon: Ext.MessageBox.INFO,
                                                            buttons: Ext.Msg.OK,
                                                            msg: payCompleteCount + '筆訂單付款完成。',
                                                            fn: function() {
                                                                this.myStore.vcustorderC.reload();
                                                            },
                                                            scope: this
                                                        });
                                                    }
                                                }
                                            }, main);
                                            this.myStore.vcustorderC.reload();
                                        }, main);
                                    } else {
                                        var postData = '';
                                        var hasErrorData = false;
                                        Ext.each(selectRecord, function(item) {
                                            if (item.data.PAY_METHOD_UUID != "" && item.data.CUST_ORDER_INVOICE_NUMBER != "") {
                                                postData += item.data.CUST_ORDER_UUID + "|";
                                            } else {
                                                hasErrorData = true;
                                            }
                                        });
                                        if (hasErrorData) {
                                            Ext.MessageBox.show({
                                                title: '系統提示',
                                                icon: Ext.MessageBox.INFO,
                                                buttons: Ext.Msg.OK,
                                                msg: '有部份訂單的付款方式或發票號為空!'
                                            });
                                        };
                                        if (postData.length == 0) {
                                            return;
                                        };
                                        WS.CustAction.payCompleteCustOrder(postData, function(obj, jsonObj) {
                                            if (jsonObj.result.success && jsonObj.result.success == true) {
                                                var payCompleteCount = jsonObj.result.payCompleteCount;
                                                if (payCompleteCount > 0) {
                                                    Ext.MessageBox.show({
                                                        title: '付款完成',
                                                        icon: Ext.MessageBox.INFO,
                                                        buttons: Ext.Msg.OK,
                                                        msg: payCompleteCount + '筆訂單付款完成。',
                                                        fn: function() {
                                                            this.myStore.vcustorderC.reload();
                                                        },
                                                        scope: this
                                                    });
                                                }
                                            }
                                        }, main);
                                    }
                                };
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
                            item.up('window').down('#CustForm').scrollTo(0, 450, true);
                            if (this.param.custUuid) {
                                this.myStore.vcustorderC.getProxy().setExtraParam('pCustUuid', this.param.custUuid);
                                this.myStore.vcustorderC.reload();
                            }
                        },
                        scope: this
                    }
                }, {
                    title: '訂單(完成)',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/order16x16_3.png',
                    items: [{
                        xtype: 'gridpanel',
                        itemId: 'grdD',
                        autoScroll: true,
                        columns: [
                            // {
                            //     text: "查看",
                            //     xtype: 'actioncolumn',
                            //     dataIndex: 'UUID',
                            //     align: 'center',
                            //     width: 60,
                            //     items: [{
                            //         tooltip: '*查看',
                            //         icon: SYSTEM_URL_ROOT + '/css/custimages/view16x16.png',
                            //         handler: function(grid, rowIndex, colIndex) {
                            //             var main = grid.up('window');
                            //             var subWin = Ext.create('WS.CustOrderStep1ViewWindow', {});
                            //             subWin.on('closeEvent', function(obj) {}, main);
                            //             subWin.param.custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                            //             subWin.param.custUuid = grid.getStore().getAt(rowIndex).data.CUST_UUID;
                            //             subWin.show();
                            //         }
                            //     }],
                            //     sortable: false,
                            //     hideable: false
                            // },
                            {
                                xtype: 'templatecolumn',
                                text: '查看',
                                width: 60,
                                sortable: false,
                                hideable: false,
                                tpl: new Ext.XTemplate(
                                    "<tpl >",
                                    '{[this.fnInit()]}<input type="button" style="width:50px" value="查看" onclick="CustWindowFnView3(\'{CUST_ORDER_UUID}\',\'{CUST_UUID}\')"/>',
                                    "</tpl>", {
                                        scope: this,
                                        fnInit: function() {
                                            document.CustWindow = this.scope;
                                            if (!document.CustWindowFnView3) {
                                                document.CustWindowFnView3 = function(CUST_ORDER_UUID, CUST_UUID) {
                                                    var main = document.CustWindow;
                                                    var subWin = Ext.create('WS.CustOrderStep1ViewWindow', {});
                                                    subWin.on('closeEvent', function(obj) {}, main);
                                                    subWin.param.custOrderUuid = CUST_ORDER_UUID;
                                                    subWin.param.custUuid = CUST_UUID;
                                                    subWin.show();
                                                }
                                            }

                                        }
                                    }),

                            }, {
                                xtype: 'templatecolumn',
                                text: '轉未付款',
                                width: 80,
                                sortable: false,
                                hideable: false,
                                tpl: new Ext.XTemplate(
                                    "<tpl >",
                                    '{[this.fnInit()]}<input type="button" style="width:70px" value="轉未付款" onclick="custWindowFnComplete2Back(\'{CUST_ORDER_UUID}\',\'{CUST_UUID}\')"/>',
                                    "</tpl>", {
                                        scope: this,
                                        fnInit: function() {
                                            document.CustWindow = this.scope;
                                            if (!document.custWindowFnComplete2Back) {
                                                document.custWindowFnComplete2Back = function(CUST_ORDER_UUID, CUST_UUID) {
                                                    var main = document.CustWindow;
                                                    var custOrderUuid = CUST_ORDER_UUID;
                                                    Ext.MessageBox.confirm('請確認', '將此單的付款狀態轉成『未付款』?', function(result) {
                                                        if (result == 'yes') {
                                                            WS.CustAction.backToNotPay(custOrderUuid, function(obj, jsonObj) {

                                                                this.myStore.vcustorderD.reload();
                                                            }, this);
                                                        }
                                                    }, main);
                                                }
                                            }

                                        }
                                    }),

                            }, {
                                header: "訂單編號",
                                dataIndex: 'CUST_ORDER_ID',
                                align: 'left',
                                width: 130
                            }, {
                                header: "出貨編號",
                                dataIndex: 'CUST_ORDER_SHIPPING_NUMBER',
                                align: 'left',
                                width: 150,
                                hidden: true
                            }, {
                                header: "出貨地址",
                                dataIndex: 'SHIPPING_ADDRESS',
                                align: 'left',
                                width: 150,
                                hidden: true
                            }, {
                                header: "單位",
                                dataIndex: 'CUST_ORDER_DEPT',
                                align: 'left',
                                width: 100
                            }, {
                                header: '採購員',
                                dataIndex: 'CUST_ORG_SALES_NAME',
                                align: 'left',
                                width: 80
                            }, {
                                header: '聯絡電話',
                                dataIndex: 'CUST_ORG_SALES_PHONE',
                                align: 'left',
                                width: 120,
                                hidden: false
                            }, {
                                header: '金額',
                                dataIndex: 'CUST_ORDER_TOTAL_PRICE',
                                align: 'right',
                                width: 80,
                                renderer: function(value, r) {
                                    return Ext.String.format('${0}', value);
                                }
                            }, {
                                header: '付款狀態',
                                dataIndex: 'PAY_STATUS_NAME',
                                width: 80,
                                renderer: function(value, r) {
                                    if (r.record.data.PAY_STATUS_UUID == 'pay_status_2') {
                                        return "<div style='background-color:#75D966;width:80px;'>&nbsp;" + r.record.data.PAY_STATUS_NAME + "</div>";
                                    } else {
                                        return "<div style='background-color:white;width:80px;'>&nbsp;" + r.record.data.PAY_STATUS_NAME + "</div>";
                                    }

                                }
                            }, {
                                header: '款項方式',
                                width: 100,
                                dataIndex: 'PAY_METHOD_UUID',
                                renderer: function(value, r) {
                                    if (r.record.data.PAY_STATUS_UUID == 'pay_status_2') {
                                        return "<div style='background-color:#75D966;width:80px;'>&nbsp;" + r.record.data.PAY_METHOD_NAME + "</div>";
                                    } else {
                                        return "<div style='background-color:white;width:80px;'>&nbsp;" + r.record.data.PAY_METHOD_NAME + "</div>";
                                    }

                                }
                            }, {
                                xtype: 'templatecolumn',
                                header: '款項備註',
                                dataIndex: 'CUST_ORDER_PAY_PS',
                                align: 'right',
                                width: 140,
                                layout: 'hbox',
                                tpl: '<input type="text" readonly style="width:130px;background-color:#75D966;" value="{CUST_ORDER_PAY_PS}"/>',
                                renderer: function(value, r) {
                                    if (r.record.data.PAY_STATUS_UUID == 'pay_status_2') {
                                        return '<input type="text" readonly style="width:130px;background-color:#75D966;" value="' + r.record.data.CUST_ORDER_PAY_PS + '"/>';
                                    } else {
                                        return '<input type="text" readonly style="width:130px;background-color:white;" value="' + r.record.data.CUST_ORDER_PAY_PS + '"/>';
                                    }

                                }
                            }, {
                                xtype: 'templatecolumn',
                                header: '發票號碼',
                                dataIndex: 'CUST_ORDER_INVOICE_NUMBER',
                                align: 'right',
                                width: 140,
                                layout: 'hbox',
                                tpl: '<input type="text" readonly style="width:130px;background-color:#75D966;" value="{CUST_ORDER_INVOICE_NUMBER}"/>',
                                renderer: function(value, r) {
                                    if (r.record.data.PAY_STATUS_UUID == 'pay_status_2') {
                                        return '<input type="text" readonly style="width:130px;background-color:#75D966;" value="' + r.record.data.CUST_ORDER_INVOICE_NUMBER + '"/>';
                                    } else {
                                        return '<input type="text" readonly style="width:130px;background-color:white;" value="' + r.record.data.CUST_ORDER_INVOICE_NUMBER + '"/>';
                                    }

                                }
                            }, {
                                header: '報價公司',
                                dataIndex: 'COMPANY_C_NAME',
                                align: 'right',
                                minWidth: 80,
                                flex: 1
                            }
                        ],
                        height: 400,
                        store: this.myStore.vcustorderD,
                        bbar: Ext.create('Ext.toolbar.Paging', {
                            store: this.myStore.vcustorderD,
                            displayInfo: true,
                            displayMsg: '第{0}~{1}資料/共{2}筆',
                            emptyMsg: "無資料顯示"
                        })
                    }],
                    listeners: {
                        activate: function(item, eOpts) {
                            item.up('window').down('#CustForm').scrollTo(0, 450, true);
                            if (this.param.custUuid) {
                                this.myStore.vcustorderD.getProxy().setExtraParam('pCustUuid', this.param.custUuid);
                                this.myStore.vcustorderD.reload();
                            }
                        },
                        scope: this
                    }
                }]
            }],
            fbar: [{
                type: 'button',
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存',
                handler: function() {
                    var mainWindow = this.up('window');
                    var form = this.up('window').down("#CustForm").getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    WS.CustAction.loadCustOrgAll(mainWindow.param.custUuid, "", "1", "99999", "CUST_UUID", "ASC", function(obj, jsonObj) {
                        //alert(jsonObj.result.data.length);
                        if (jsonObj.result.data.length == 0) {
                            Ext.MessageBox.show({
                                title: '操作提示',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                msg: '單位採購人員至少設定一組!'
                            });
                            return;
                        };
                        var form = this.down("#CustForm").getForm();
                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                this.param.custUuid = action.result.CUST_UUID;
                                this.down("#CUST_UUID").setValue(action.result.CUST_UUID);

                                this.down('#btnAddCustOrderDetail').setDisabled(false);
                                this.down('#btnShipping').setDisabled(false);
                                this.down('#btnSaveAll').setDisabled(false);
                                this.down('#btnSaveAll2').setDisabled(false);
                                this.down('#btnShippingConfirm').setDisabled(false);
                                this.down('#btnInvoiceComplete').setDisabled(false);

                                Ext.MessageBox.show({
                                    title: '操作完成',
                                    msg: '操作完成',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK,
                                    fn: function() {
                                        //this.close();
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
                            scope: this
                        });


                    }, mainWindow);


                }
            }, {
                type: 'button',
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存&關閉',
                handler: function() {
                    var mainWindow = this.up('window');
                    var form = this.up('window').down("#CustForm").getForm();
                    if (form.isValid() == false) {
                        return;
                    };

                    WS.CustAction.loadCustOrgAll(mainWindow.param.custUuid, "", "1", "99999", "CUST_UUID", "ASC", function(obj, jsonObj) {
                        // alert(jsonObj.result.data.length);
                        if (jsonObj.result.data.length == 0) {
                            Ext.MessageBox.show({
                                title: '操作提示',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                msg: '單位採購人員至少設定一組!'
                            });
                            return;
                        };
                        var form = this.down("#CustForm").getForm();
                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                this.param.custUuid = action.result.CUST_UUID;
                                this.down("#CUST_UUID").setValue(action.result.CUST_UUID);

                                this.down('#btnAddCustOrderDetail').setDisabled(false);
                                this.down('#btnShipping').setDisabled(false);
                                this.down('#btnSaveAll').setDisabled(false);
                                this.down('#btnSaveAll2').setDisabled(false);
                                this.down('#btnShippingConfirm').setDisabled(false);
                                this.down('#btnInvoiceComplete').setDisabled(false);

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
                            scope: this
                        });


                    }, mainWindow);


                    // form.submit({
                    //     waitMsg: '更新中...',
                    //     success: function(form, action) {
                    //         this.param.custUuid = action.result.CUST_UUID;
                    //         this.down("#CUST_UUID").setValue(action.result.CUST_UUID);
                    //         Ext.MessageBox.show({
                    //             title: '操作完成',
                    //             msg: '操作完成',
                    //             icon: Ext.MessageBox.INFO,
                    //             buttons: Ext.Msg.OK,
                    //             fn: function() {
                    //                 this.close();
                    //             },
                    //             scope: this
                    //         });
                    //     },
                    //     failure: function(form, action) {
                    //         Ext.MessageBox.show({
                    //             title: 'Warning',
                    //             msg: action.result.message,
                    //             icon: Ext.MessageBox.ERROR,
                    //             buttons: Ext.Msg.OK
                    //         });
                    //     },
                    //     scope: this.up('window')
                    // });
                }
            }, {
                type: 'button',
                icon: SYSTEM_URL_ROOT + '/css/images/delete16x16.png',
                text: '刪除',
                handler: function() {
                    var mainWin = this.up('window');
                    Ext.MessageBox.confirm('刪除廠商操作', '確定要刪除這一個廠商資訊?刪除內容包含此客戶資料 、 客戶人員資料、訂單資料等。', function(result) {
                        if (result == 'yes') {
                            var custUuid = mainWin.param.custUuid;
                            WS.CustAction.fullDestoryCust(custUuid, function(obj, jsonObj) {
                                if (jsonObj.result.success) {
                                    this.close();
                                } else {

                                    Ext.MessageBox.show({
                                        title: '刪除廠商操作(1502221728)',
                                        icon: Ext.MessageBox.INFO,
                                        buttons: Ext.Msg.OK,
                                        msg: jsonObj.result.message,
                                    }, this);
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
            this.mask('資料準備中…');
            // if (this.param.custUuid != undefined) {
            this.down("#CustForm").getForm().load({
                params: {
                    'pCustUuid': this.param.custUuid == undefined ? "" : this.param.custUuid
                },
                success: function(response, a, b) {

                    if (a.result.data.CUST_IS_ACTIVE == '-1') {
                        this.down('#btnAddCustOrderDetail').setDisabled(true);
                        this.down('#btnShipping').setDisabled(true);
                        this.down('#btnSaveAll').setDisabled(true);
                        this.down('#btnSaveAll2').setDisabled(true);
                        this.down('#btnShippingConfirm').setDisabled(true);
                        this.down('#btnInvoiceComplete').setDisabled(true);
                    };

                    this.myStore.custOrg.getProxy().setExtraParam('pCustUuid', this.param.custUuid);
                    this.myStore.custOrg.loadPage(1);
                    if (this.param.custUuid) {
                        this.myStore.vcustorderA.getProxy().setExtraParam('pCustUuid', this.param.custUuid);
                        this.myStore.vcustorderA.loadPage(1);
                    }
                    this.unmask();
                },
                failure: function(response, jsonObj, b) {
                    if (!jsonObj.result.success) {
                        Ext.MessageBox.show({
                            title: 'Warning',
                            icon: Ext.MessageBox.WARNING,
                            buttons: Ext.Msg.OK,
                            msg: jsonObj.result.message
                        });
                    };
                },
                scope: this
            });

            // } 
            // else {
            //     this.down("#CustForm").getForm().reset();
            // };
        },
        'close': function() {
            this.myStore.vcustorderA.removeAll();
            this.myStore.vcustorderB.removeAll();
            this.myStore.vcustorderC.removeAll();
            this.myStore.vcustorderD.removeAll();
            this.myStore.custOrg.removeAll();
            this.myStore.payMethod.removeAll();
            this.closeEvent();
            this.down('form').reset();
        }
    }
});
