Ext.define('WS.CustOrderStep1Window', {
    extend: 'Ext.window.Window',
    title: '單訂維護',
    icon: SYSTEM_URL_ROOT + '/css/custimages/order16x16.png',
    closeAction: 'destroy',
    closable: false,
    storeCount: 1,
    modal: true,
    param: {
        custOrderUuid: undefined,
        custUuid: undefined,
        parentObj: undefined
    },
    myStore: {
        attendant: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'ATTEDNANTVV',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.LimewAttendantAction.loadMyCompanyAttendant
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
                property: 'C_NAME',
                direction: 'ASC'
            }]
        }),
        company: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'CUST',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.AdminCompanyAction.loadCompany
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'pIsActive', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pIsActive: 'Y'
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
                property: 'C_NAME',
                direction: 'ASC'
            }]
        }),
        cust: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
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
                property: 'CUST_NAME',
                direction: 'ASC'
            }]
        }),
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
                property: 'CUST_ORDER_STATUS_ORD',
                direction: 'ASC'
            }]
        }),
        shippingStatus: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'CUST',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.ShippingStatusAction.loadShippingStatus
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
                property: 'SHIPPING_STATUS_ORD',
                direction: 'ASC'
            }]
        }),
        payMethod: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'CUST',
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
                property: 'PAY_METHOD_ORD',
                direction: 'ASC'
            }]
        }),
        payStatus: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'CUST',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.PayStatusAction.loadPayStatus
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
                property: 'PAY_STATUS_ORD',
                direction: 'ASC'
            }]
        }),
        unit: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: true,
            remoteSort: true,
            model: 'UNIT',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.UnitAction.loadUnit
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
                property: 'UNIT_NAME',
                direction: 'ASC'
            }]
        })

    },
    width: 1000,
    height: 660,
    //layout: 'vbox',
    layout: {
        type: 'border'
    },
    resizable: false,
    draggable: false,
    fnCal: function(mainWin) {
        var sum = 0,
            itemCount = 0,
            records = mainWin.myStore.vCustOrderDetail.data.items;

        Ext.each(records, function(item) {
            sum += parseFloat(item.data.CUST_ORDER_DETAIL_TOTAL_PRICE);
            itemCount++;
        });
        if (itemCount > 0) {
            WS.CustAction.infoCustOrder(records[0].data.CUST_ORDER_UUID, function(obj, jsonObj) {
                if (jsonObj.result.data.CUST_ORDER_HAS_TAX == "0") {
                    this.down('#btnMoney').show();
                    this.down('#btnMoney').setText('訂單項目明細    數量：' + itemCount + '筆,金額合計：' + sum + '元(未稅)')
                        //this.down('#grdVCustOrderDetail').setTitle('訂單項目明細    數量：' + itemCount + '筆,金額合計：' + sum + '元(未稅)');
                } else {
                    this.down('#btnMoney').show();
                    this.down('#btnMoney').setText('訂單項目明細    數量：' + itemCount + '筆,金額合計：' + sum + '元(含稅)')
                        //this.down('#grdVCustOrderDetail').setTitle('訂單項目明細    數量：' + itemCount + '筆,金額合計：' + sum + '元(含稅)');
                }
            }, this);
        };
    },
    fnCreateCustOrderDetailCustomize: function(createNumber) {
        WS.CustAction.createCustOrderDetailCustomize(this.param.custOrderUuid, createNumber, function(obj, jsonObj) {
            if(jsonObj.result.success){
                this.myStore.vCustOrderDetail.reload();
            };
        }, this);
    },
    initComponent: function() {
        this.myStore.vCustOrderDetail = Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'V_CUST_ORDER_DETAIL',
            pageSize: 9999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadVCustOrderDetail
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pCustOrderUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pCustOrderUuid: ''
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
            listeners: {
                load: function(self, records, successful, eOpts) {
                    var sum = 0,
                        itemCount = 0;
                    Ext.each(records, function(item) {
                        sum += parseFloat(item.data.CUST_ORDER_DETAIL_TOTAL_PRICE);
                        itemCount++;
                    });
                    if (itemCount > 0) {
                        WS.CustAction.infoCustOrder(records[0].data.CUST_ORDER_UUID, function(obj, jsonObj) {
                            if (jsonObj.result.data.CUST_ORDER_HAS_TAX == "0") {
                                this.down('#btnMoney').show();
                                this.down('#btnMoney').setText('訂單項目明細    數量：' + itemCount + '筆,金額合計：' + sum + '元(未稅)')
                                    //this.down('#grdVCustOrderDetail').setTitle('訂單項目明細    數量：' + itemCount + '筆,金額合計：' + sum + '元(未稅)');
                            } else {
                                this.down('#btnMoney').show();
                                this.down('#btnMoney').setText('訂單項目明細    數量：' + itemCount + '筆,金額合計：' + sum + '元(含稅)')
                                    //this.down('#grdVCustOrderDetail').setTitle('訂單項目明細    數量：' + itemCount + '筆,金額合計：' + sum + '元(含稅)');
                            }
                        }, this);
                    };


                },
                scope: this
            },
            remoteSort: true,
            sorters: [{
                property: 'CUST_ORDER_DETAIL_CR',
                direction: 'ASC'
            }]
        });
        this.myStore.custOrg = Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'CUST_ORG',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadCustOrgAll
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pCustUuid', 'pKeyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pCustUuid: '',
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
                property: 'CUST_ORG_NAME',
                direction: 'ASC'
            }],
            listeners: {
                scope: this,
                load: function(self, records, successful, eOpts) {
                    var mainWin = this;
                    var selectCustOrgUuid = mainWin.down('#CUST_ORG_UUID').getValue();
                    //alert(selectCustOrgUuid);
                    if (selectCustOrgUuid != null) {
                        var isExist = false;
                        for (var i = 0; i < records.length; i++) {
                            if (records[i].data.CUST_ORG_UUID == selectCustOrgUuid) {
                                isExist = true;
                            }
                        };
                        if (isExist == false) {
                            if (records.length > 0) {
                                mainWin.down('#CUST_ORG_UUID').setValue(records[0].data.CUST_ORG_UUID);
                            };
                        };
                    };
                }
            }
        });
        this.items = [
            Ext.create('Ext.form.Panel', {
                api: {
                    load: WS.CustAction.infoCustOrder,
                    submit: WS.CustAction.submitCustOrder
                },
                region: 'center',
                itemId: 'CustOrderForm',
                paramOrder: ['pCustOrderUuid'],
                autoScroll: true,
                border: true,
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
                        margin: '5 0 5 0',
                        items: [{
                                xtype: 'hiddenfield',
                                name: 'CUST_ORDER_TYPE',
                                itemId: 'CUST_ORDER_TYPE',
                                value: '0'
                            },
                            // {
                            //     xtype: 'radiogroup',
                            //     width: 250,
                            //     labelAlign: 'right',
                            //     fieldLabel: '訂單類型',
                            //     itemId: 'CUST_ORDER_TYPE',
                            //     layout: 'hbox',
                            //     defaults: {
                            //         margin: '0 10 0 0'
                            //     },
                            //     defaultType: 'radiofield',
                            //     items: [{
                            //         xtype: 'radiofield',
                            //         boxLabel: '報價',
                            //         inputValue: '0',
                            //         name: 'CUST_ORDER_TYPE',
                            //         checked: true
                            //     }, {
                            //         xtype: 'radiofield',
                            //         boxLabel: '訂單',
                            //         inputValue: '1',
                            //         name: 'CUST_ORDER_TYPE'
                            //     }]
                            // }, 
                            {
                                xtype: 'combo',
                                fieldLabel: '製單人員',
                                labelAlign: 'right',
                                name: 'CUST_ORDER_REPORT_ATTENDANT_UUID',
                                itemId: 'CUST_ORDER_REPORT_ATTENDANT_UUID',
                                displayField: 'C_NAME',
                                valueField: 'UUID',
                                //width: 300,
                                labelWidth: 100,
                                editable: false,
                                hidden: false,
                                store: this.myStore.attendant
                            }, {
                                xtype: 'datefield',
                                fieldLabel: '製單日期',
                                value: new Date(),
                                format: 'Y/m/d',
                                submitFormat: 'Y/m/d',
                                //width: 210,
                                //labelWidth: 90,
                                name: 'CUST_ORDER_REPORT_DATE',
                                itemId: 'CUST_ORDER_REPORT_DATE',
                                labelAlign: 'right',
                                renderer: function(value, r) {
                                    return '1999/01/01';
                                },
                                render: function() {
                                    return '1998/01/01'
                                }
                            }, {
                                xtype: 'textfield',
                                hidden: true,
                                //fieldLabel:'fieldLabel',
                                name: 'CUST_ORDER_IS_ACTIVE',
                                itemId: 'CUST_ORDER_IS_ACTIVE',
                                value: '0',
                                flex: 1

                            }, {
                                xtype: 'container',
                                layout: {
                                    type: 'hbox',
                                    pack: 'end'
                                },
                                items: [{
                                    xtype: 'button',
                                    text: '報價',
                                    icon: SYSTEM_URL_ROOT + '/css/custimages/print16x16.png',
                                    width: 80,
                                    arrowAlign: 'right',
                                    itemId: 'btnMenuOrderPerview',
                                    menu: []

                                }, {
                                    xtype: 'button',
                                    text: '出貨',
                                    icon: SYSTEM_URL_ROOT + '/css/custimages/print16x16.png',
                                    width: 80,
                                    margin: '0 0 0 10',
                                    itemId: 'btnMenuOrder',
                                    arrowAlign: 'right',
                                    handler: function() {
                                        var mainWin = this.up('window');
                                        WS.CustAction.pdfShipping(mainWin.param.custOrderUuid, function(obj, jsonObj) {
                                            if (jsonObj.result.success) {
                                                var downloadUrl = SYSTEM_URL_ROOT + '/upload/shipping/' + jsonObj.result.file;
                                                window.open(downloadUrl);
                                            }
                                        }, mainWin);
                                    }
                                }],
                                flex: 2
                            }
                        ]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '訂單編號',
                            itemId: 'CUST_ORDER_ID',
                            name: 'CUST_ORDER_ID',
                            maxLength: 20,
                            allowBlank: true,
                            labelAlign: 'right',
                            fieldStyle: 'background-color:#F2D49B'
                        }, {
                            xtype: 'combo',
                            fieldLabel: '開單公司',
                            labelAlign: 'right',
                            allowBlank: false,
                            itemId: 'COMPANY_UUID',
                            displayField: 'C_NAME',
                            valueField: 'UUID',
                            name: 'COMPANY_UUID',
                            editable: false,
                            hidden: false,
                            store: this.myStore.company
                        }, {
                            xtype: 'checkbox',
                            fieldLabel: '訂單含稅',
                            name: 'CUST_ORDER_HAS_TAX',
                            checked: true,
                            labelWidth: 90,
                            inputValue: '1',
                            labelAlign: 'right'
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        margin: '5 0 5 0',
                        items: [{
                            xtype: 'container',
                            layout: 'hbox',
                            items: [{
                                xtype: 'combo',
                                fieldLabel: '客戶',
                                labelAlign: 'right',
                                displayField: 'CUST_NAME',
                                valueField: 'CUST_UUID',
                                name: 'CUST_UUID',
                                itemId: 'CUST_UUID',
                                width: 255,
                                editable: false,
                                hidden: false,
                                store: this.myStore.cust,
                                allowBlank: false,
                                listeners: {
                                    'change': function(self) {
                                        var mainWin = this.up('window'),
                                            store = mainWin.myStore.custOrg,
                                            proxy = store.getProxy();
                                        proxy.setExtraParam('pCustUuid', this.getValue());
                                        store.loadPage(1);
                                    }
                                }
                            }, {
                                xtype: 'button',
                                text: '',
                                width: 20,
                                handler: function() {
                                    var mainWin = this.up('window');
                                    var subWin = Ext.create('WS.CustPickerWindow', {
                                        param: {
                                            parentObj: mainWin
                                        }
                                    });
                                    subWin.on('selectedEvent', function(obj, record) {
                                        obj.param.parentObj.down('#CUST_UUID').setValue(record.CUST_UUID);
                                        obj.close();
                                    });
                                    subWin.show();
                                }
                            }]
                        }, {
                            xtype: 'container',
                            layout: 'hbox',
                            items: [{
                                xtype: 'combo',
                                width: 350,
                                fieldLabel: '採購人員',
                                displayField: 'CUST_ORG_SALES_NAME',
                                valueField: 'CUST_ORG_UUID',
                                name: 'CUST_ORG_UUID',
                                itemId: 'CUST_ORG_UUID',
                                editable: false,
                                hidden: false,
                                store: this.myStore.custOrg,
                                allowBlank: false,
                                labelAlign: 'right',
                                tpl: Ext.create('Ext.XTemplate',
                                    '<tpl for=".">',
                                    '<div class="x-boundlist-item" style="dispaly:inline-block;line-height:40px">',
                                    '<div style="dispaly:table">',
                                    '<div style="display:table-row">',
                                    '<div style="display: table-cell">{CUST_ORG_NAME}</div>',
                                    '<div style="display: table-cell;padding-left:5px;">/ {CUST_ORG_SALES_NAME} </div>',
                                    '<div style="display: table-cell;padding-left:5px;">/ {CUST_ORG_SALES_PHONE} </div>',
                                    '</div>',
                                    '</div>',
                                    '</div>',
                                    '</tpl>'),
                                listeners: {
                                    change: function(obj, newValue, oldValue, eOpts) {

                                        var mainWin = obj.up('window'),
                                            record = mainWin.myStore.custOrg.findRecord('CUST_ORG_UUID', newValue),
                                            custOrderDept = mainWin.down('#CUST_ORDER_DEPT'),
                                            custOrderUserName = mainWin.down('#CUST_ORDER_USER_NAME'),
                                            custOrderUserPhone = mainWin.down('#CUST_ORDER_USER_PHONE');
                                        if (record) {
                                            custOrderDept.setValue(record.data.CUST_ORG_NAME)
                                        };
                                        if (record) {
                                            custOrderUserName.setValue(record.data.CUST_ORG_SALES_NAME)
                                        };
                                        if (record) {
                                            custOrderUserPhone.setValue(record.data.CUST_ORG_SALES_PHONE)
                                        };
                                    }
                                }
                            }, {
                                xtype: 'button',
                                text: '',
                                width: 20,
                                handler: function(handler, scope) {
                                    var mainWin = this.up('window');
                                    var subWin = Ext.create('WS.CustOrgPickerWindow', {
                                        param: {
                                            parentObj: mainWin,
                                            custUuid: mainWin.down('#CUST_UUID').getValue()
                                        }
                                    });
                                    subWin.on('selectedEvent', function(obj, record) {
                                        obj.param.parentObj.down('#CUST_ORG_UUID').setValue(record.CUST_ORG_UUID);
                                        obj.close();
                                    });
                                    subWin.show();
                                }
                            }]
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        padding: '0 0 0 0',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '出貨地址',
                            labelAlign: 'right',
                            flex: 1,
                            labelWidth: 100,
                            itemId: 'SHIPPING_ADDRESS',
                            name: 'SHIPPING_ADDRESS',
                        }, {
                            xtype: 'button',
                            text: '選擇',
                            margin: '0 0 0 5',
                            handler: function(handler, scope) {
                                var mainWin = this.up('window');
                                var subWin = Ext.create('WS.CustAddressPicker', {
                                    param: {
                                        custUuid: mainWin.down("#CUST_UUID").getValue(),
                                        custOrgUuid: mainWin.down("#CUST_ORG_UUID").getValue(),
                                        parentObj: mainWin
                                    }
                                });
                                subWin.on('closeEvent', function(obj, jsonObj) {
                                    obj.param.parentObj.down('#SHIPPING_ADDRESS').setValue(jsonObj);
                                });
                                subWin.show();
                            }
                        }]
                    }, {
                        xtype: 'fieldset',
                        title: '採購人員資訊',
                        border: true,
                        collapsible: true,
                        collapsed: true,
                        margin: '0 0 5 45',
                        width: 905,
                        items: [{
                            xtype: 'container',
                            layout: 'vbox',
                            items: [{
                                xtype: 'container',
                                layout: 'hbox',
                                defaults: {
                                    labelWidth: 60
                                },
                                items: [{
                                    xtype: 'textfield',
                                    fieldLabel: '單位',
                                    name: 'CUST_ORDER_DEPT',
                                    itemId: 'CUST_ORDER_DEPT',
                                    fieldStyle: 'background-color: #B2D0EA; ',
                                    flex: 1,
                                    readOnly: true,
                                    labelAlign: 'right'
                                }, {
                                    xtype: 'container',
                                    layout: 'vbox',
                                    flex: 1,
                                    defaults: {
                                        labelWidth: 60
                                    },
                                    items: [{
                                        xtype: 'textfield',
                                        fieldLabel: '名稱',
                                        name: 'CUST_ORDER_USER_NAME',
                                        itemId: 'CUST_ORDER_USER_NAME',
                                        fieldStyle: 'background-color: #B2D0EA; ',
                                        flex: 1,
                                        readOnly: true,
                                        labelAlign: 'right'
                                    }, {
                                        xtype: 'textfield',
                                        fieldLabel: '列印名稱',
                                        name: 'CUST_ORDER_PRINT_USER_NAME',
                                        flex: 1,
                                        labelAlign: 'right'
                                    }]
                                }, {
                                    xtype: 'textfield',
                                    fieldLabel: '電話',
                                    fieldStyle: 'background-color: #B2D0EA; ',
                                    name: 'CUST_ORDER_USER_PHONE',
                                    itemId: 'CUST_ORDER_USER_PHONE',
                                    flex: 1,
                                    readOnly: true,
                                    labelAlign: 'right'
                                }]
                            }]
                        }]
                    }]
                }, {
                    xtype: 'fieldset',
                    border: true,
                    title: '備註',
                    margin: '0 27 5 45',
                    height: 60,
                    items: [{
                        xtype: 'textareafield',
                        width: 885,
                        growMin: 35,
                        growMax: 35,
                        grow: true,
                        name: 'CUST_ORDER_PS'
                    }]
                }, {
                    xtype: 'hidden',
                    fieldLabel: 'CUST_ORDER_UUID',
                    name: 'CUST_ORDER_UUID',
                    maxLength: 84,
                    itemId: 'CUST_ORDER_UUID'
                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    flex: 1,
                    defaults: {
                        margin: '0 10 0 0',
                        width: 150,
                    }
                }, {
                    xtype: 'gridpanel',
                    title: '訂單項目明細',
                    store: this.myStore.vCustOrderDetail,
                    plugins: {
                        ptype: 'cellediting',
                        clicksToEdit: 1,
                        listeners: {
                            beforeedit: function(editor, context, eOpts) {
                                var mainWin = context.grid.up('window');
                                mainWin.param.editRecord = context.record;
                                mainWin.param.editRowIdx = context.rowIdx;
                                mainWin.param.editColIdx = context.colIdx;
                                //console.log(mainWin.param);
                            },
                            edit: function(editor, context, eOpts) {
                                var mainWin = context.grid.up('window');
                                //mainWin.param.editRecord = context.record;
                                mainWin.param.editRowIdx = context.rowIdx;
                                mainWin.param.editColIdx = context.colIdx;
                                mainWin.fnCal(mainWin);
                            }
                        }
                    },
                    itemId: 'grdVCustOrderDetail',
                    columns: [{
                        xtype: 'actioncolumn',
                        dataIndex: 'UUID',
                        align: 'center',
                        width: 60,
                        items: [{
                            tooltip: '*編輯',
                            icon: SYSTEM_URL_ROOT + '/css/custImages/edit.gif',
                            handler: function(grid, rowIndex, colIndex) {
                                var mainWin = grid.up('window'),
                                    custOrderUuid = mainWin.down('#CUST_ORDER_UUID').getValue();
                                if (grid.getStore().getAt(rowIndex).data.GOODS_UUID != "") {
                                    var subWin = Ext.create('WS.CustOrderDetailWindow', {
                                        param: {
                                            parentObj: mainWin,
                                            custOrderUuid: custOrderUuid,
                                            custOrderDetailUuid: grid.getStore().getAt(rowIndex).data.CUST_ORDER_DETAIL_UUID
                                        }
                                    });
                                    subWin.on('closeEvent', function() {
                                        mainWin.myStore.vCustOrderDetail.reload();
                                    });
                                    subWin.show();
                                } else if (grid.getStore().getAt(rowIndex).data.SUPPLIER_GOODS_UUID != "") {
                                    var subWin = Ext.create('WS.CustOrderDetailSupplierWindow', {
                                        param: {
                                            parentObj: mainWin,
                                            custOrderUuid: custOrderUuid,
                                            custOrderDetailUuid: grid.getStore().getAt(rowIndex).data.CUST_ORDER_DETAIL_UUID
                                        }
                                    });
                                    subWin.on('closeEvent', function() {
                                        mainWin.myStore.vCustOrderDetail.reload();
                                    });
                                    subWin.show();
                                } else {
                                    var subWin = Ext.create('WS.CustOrderDetailCustomizedWindow', {
                                        param: {
                                            parentObj: mainWin,
                                            custOrderUuid: custOrderUuid,
                                            custOrderDetailUuid: grid.getStore().getAt(rowIndex).data.CUST_ORDER_DETAIL_UUID
                                        }
                                    });
                                    subWin.on('closeEvent', function() {
                                        mainWin.myStore.vCustOrderDetail.reload();
                                    });
                                    subWin.show();
                                }
                            }
                        }, {
                            tooltip: '*刪除',
                            icon: SYSTEM_URL_ROOT + '/css/images/delete16x16.png',
                            handler: function(grid, rowIndex, colIndex) {
                                var mainWin = grid.up('window');
                                // Ext.MessageBox.confirm('刪除操作', '確定要刪除這一個訂單明細?', function(result) {
                                //     if (result == 'yes') {
                                var store = mainWin.down('#grdVCustOrderDetail').getStore();
                                var find = store.findRecord("CUST_ORDER_DETAIL_UUID",grid.getStore().getAt(rowIndex).data.CUST_ORDER_DETAIL_UUID);
                                


                                WS.CustAction.destoryCustOrderDetail(grid.getStore().getAt(rowIndex).data.CUST_ORDER_DETAIL_UUID, function(obj, jsonObj) {
                                            if (jsonObj.result.success) {
                                                var store = mainWin.down('#grdVCustOrderDetail').getStore(),
                                                    count = store.getCount();
                                                    store.remove(find);
                                                // if (count == 1) {
                                                //     if (store.currentPage > 1) {
                                                //         store.previousPage();
                                                //     } else {
                                                //         store.reload();
                                                //     };
                                                // } else {
                                                //     store.reload();
                                                // };

                                            };
                                        }, mainWin);       
                                //     };
                                // }, mainWin);
                            }
                        }],
                        sortable: false,
                        hideable: false
                    }, {
                        xtype: 'booleancolumn',
                        text: "客製",
                        enableColumnHide: false,
                        trueText: '是',
                        falseText: '否',
                        dataIndex: 'CUST_ORDER_DETAIL_CUSTOMIZED',
                        align: 'center',
                        width: 50
                    }, {
                        text: "商品",
                        dataIndex: 'CUST_ORDER_DETAIL_GOODS_NAME',
                        align: 'left',
                        flex: 2,
                        editor: {
                            xtype: 'textfield',
                            enableKeyEvents: true,
                            listeners: {
                                change: function(obj, newValue, oldValue, eOpts) {
                                    var mainWin = obj.up('window');
                                    if (mainWin.param.editRecord.data.CUST_ORDER_DETAIL_CUSTOMIZED == false) {
                                        CUST_ORDER_DETAIL_GOODS_NAME = oldValue;
                                        return;
                                    } else {
                                        mainWin.param.editRecord.data.CUST_ORDER_DETAIL_GOODS_NAME = newValue;
                                    }
                                    mainWin.param.editRecord.commit();
                                },
                                focus: function(obj, eOpts) {
                                    var mainWin = obj.up('window');
                                    if (mainWin.param.editRecord.data.CUST_ORDER_DETAIL_CUSTOMIZED == false) {
                                        obj.setReadOnly(true);
                                    } else {
                                        obj.setReadOnly(false);
                                    }
                                }
                            }
                        }
                    }, {
                        text: "單價",
                        dataIndex: 'CUST_ORDER_DETAIL_PRICE',
                        align: 'right',
                        flex: 1,
                        editor: {
                            xtype: 'numberfield',
                            listeners: {
                                change: function(obj, newValue, oldValue, eOpts) {
                                    var mainWin = obj.up('window');
                                    mainWin.param.editRecord.data.CUST_ORDER_DETAIL_TOTAL_PRICE = newValue * mainWin.param.editRecord.data.CUST_ORDER_DETAIL_COUNT;
                                    mainWin.param.editRecord.commit();

                                }
                            }
                        }
                    }, {
                        text: "數量",
                        dataIndex: 'CUST_ORDER_DETAIL_COUNT',
                        align: 'right',
                        flex: 1,
                        editor: {
                            xtype: 'numberfield',
                            listeners: {
                                change: function(obj, newValue, oldValue, eOpts) {
                                    var mainWin = obj.up('window');
                                    mainWin.param.editRecord.data.CUST_ORDER_DETAIL_TOTAL_PRICE = newValue * mainWin.param.editRecord.data.CUST_ORDER_DETAIL_PRICE;
                                    mainWin.param.editRecord.commit();

                                }
                            }
                        }
                    }, {
                        text: "單位",
                        dataIndex: 'CUST_ORDER_DETAIL_UNIT',
                        align: 'center',
                        width: 60,
                        renderer: function(value, r) {
                            return r.record.data.CUST_ORDER_DETAIL_UNIT_NAME;
                        },
                        editor: {
                            xtype: 'combo',
                            allowBlank: false,
                            displayField: 'UNIT_NAME',
                            valueField: 'UNIT_UUID',
                            store: this.myStore.unit,
                            editable: false,
                            hidden: false,
                            listeners: {
                                change: function(obj, newValue, oldValue, eOpts) {
                                    var mainWin = obj.up('window');
                                    var dr = obj.getStore().findRecord("UNIT_UUID", newValue).data;
                                    mainWin.param.editRecord.data.CUST_ORDER_DETAIL_UNIT_NAME = dr.UNIT_NAME;
                                }
                            }
                        }
                    }, {
                        text: "小計",
                        dataIndex: 'CUST_ORDER_DETAIL_TOTAL_PRICE',
                        align: 'right',
                        flex: 1
                    }, {
                        text: "備註",
                        dataIndex: 'CUST_ORDER_DETAIL_PS',
                        align: 'left',
                        flex: 1
                    }, {
                        text: "附件(個)",
                        dataIndex: 'FILE_COUNT',
                        align: 'center',
                        flex: 1
                    }],
                    minHeight:300,
                    autoHeight:true,
                    //height: 350,
                    // bbar: Ext.create('Ext.toolbar.Paging', {
                    //     store: this.myStore.vCustOrderDetail,
                    //     displayInfo: true,
                    //     displayMsg: '第{0}~{1}資料/共{2}筆',
                    //     emptyMsg: "無資料顯示"
                    // }),
                    tbar: [{
                        type: 'button',
                        text: '新增商品',
                        icon: SYSTEM_URL_ROOT + '/css/images/addC16x16.png',
                        handler: function() {
                            var mainWin = this.up('window'),
                                custOrderUuid = mainWin.down('#CUST_ORDER_UUID').getValue();
                            if (custOrderUuid && custOrderUuid != "") {
                                var mainWin = this.up('window');
                                var subWin = Ext.create('WS.CustOrderDetailWindow', {
                                    param: {
                                        parentObj: mainWin,
                                        custOrderUuid: custOrderUuid
                                    }
                                });
                                subWin.on('closeEvent', function() {
                                    mainWin.myStore.vCustOrderDetail.reload();
                                });
                                subWin.show();
                            } else {
                                Ext.MessageBox.show({
                                    title: '操作通知',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK,
                                    msg: '請先執行儲存操作，才可新增子項商品內容。'
                                });
                            }
                        }
                    }, {
                        type: 'button',
                        text: '新增客製服務',
                        icon: SYSTEM_URL_ROOT + '/css/images/addD16x16.png',
                        menu: [{
                            text: 'a'
                        }, {
                            text: '2'
                        }],
                        handler: function() {
                            var mainWin = this.up('window'),
                                custOrderUuid = mainWin.down('#CUST_ORDER_UUID').getValue();
                            if (custOrderUuid && custOrderUuid != "") {
                                var mainWin = this.up('window');
                                var subWin = Ext.create('WS.CustOrderDetailCustomizedWindow', {
                                    param: {
                                        parentObj: mainWin,
                                        custOrderUuid: custOrderUuid
                                    }
                                });
                                subWin.on('closeEvent', function() {
                                    mainWin.myStore.vCustOrderDetail.reload();
                                });
                                subWin.show();
                            } else {
                                Ext.MessageBox.show({
                                    title: '操作通知',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK,
                                    msg: '請先執行儲存操作，才可新增子項商品內容。'
                                });
                            }
                        }
                    }, {
                        xtype: 'button',
                        text: '連續新增',
                        icon: SYSTEM_URL_ROOT + '/css/images/addD16x16.png',
                        menu: [{
                            text: '1項',
                            handler: function() {
                                var mainWin = this.up('window');
                                mainWin.fnCreateCustOrderDetailCustomize(1);
                            }
                        }, {
                            text: '2項',
                            handler: function() {
                                var mainWin = this.up('window');
                                mainWin.fnCreateCustOrderDetailCustomize(2);
                            }
                        }, {
                            text: '3項',
                            handler: function() {
                                var mainWin = this.up('window');
                                mainWin.fnCreateCustOrderDetailCustomize(3);
                            }
                        }, {
                            text: '4項',
                            handler: function() {
                                var mainWin = this.up('window');
                                mainWin.fnCreateCustOrderDetailCustomize(4);
                            }
                        }, {
                            text: '5項',
                            handler: function() {
                                var mainWin = this.up('window');
                                mainWin.fnCreateCustOrderDetailCustomize(5);
                            }
                        }, {
                            text: '6項',
                            handler: function() {
                                var mainWin = this.up('window');
                                mainWin.fnCreateCustOrderDetailCustomize(6);
                            }
                        }, {
                            text: '7項',
                            handler: function() {
                                var mainWin = this.up('window');
                                mainWin.fnCreateCustOrderDetailCustomize(7);
                            }
                        }, {
                            text: '8項',
                            handler: function() {
                                var mainWin = this.up('window');
                                mainWin.fnCreateCustOrderDetailCustomize(8);
                            }
                        }, {
                            text: '9項',
                            handler: function() {
                                var mainWin = this.up('window');
                                mainWin.fnCreateCustOrderDetailCustomize(9);
                            }
                        }, {
                            text: '10項',
                            handler: function() {
                                var mainWin = this.up('window');
                                mainWin.fnCreateCustOrderDetailCustomize(10);
                            }
                        }, {
                            text: '20項',
                            handler: function() {
                                var mainWin = this.up('window');
                                mainWin.fnCreateCustOrderDetailCustomize(20);
                            }
                        }, {
                            text: '30項',
                            handler: function() {
                                var mainWin = this.up('window');
                                mainWin.fnCreateCustOrderDetailCustomize(30);
                            }
                        }]
                    }],
                    listeners: {
                        cellclick: function(iView, iCellEl, iColIdx, iRecord, iRowEl, iRowIdx, iEvent) {}
                    }
                }]
            }),
            Ext.create('Ext.panel.Panel', {
                region: 'south',

                layout: {
                    type: 'hbox',
                    align: 'right',
                    pack: 'end'
                },
                items: [{
                    xtype: 'button',
                    hidden: true,
                    padding: 5,
                    margin: 5,
                    itemId: 'btnMoney'
                }],
                fbar: [{
                    xtype: 'tbfill'
                }, {
                    xtype: 'button',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                    text: '儲存',
                    handler: function() {
                        var mainWin = this.up('window'),
                            form = this.up('window').down("#CustOrderForm").getForm();
                        if (form.isValid() == false) {
                            return;
                        };
                        var updateData = "";
                        Ext.each(mainWin.myStore.vCustOrderDetail.data.items, function(item) {
                            updateData += item.data.CUST_ORDER_DETAIL_UUID + "," + item.data.CUST_ORDER_DETAIL_GOODS_NAME + "," + item.data.CUST_ORDER_DETAIL_PRICE + "," + item.data.CUST_ORDER_DETAIL_COUNT + "|";
                        });

                        WS.CustAction.batchUpdateCustOrderDetail(updateData, function(obj, jsonObj) {
                            //alert(jsonObj.result.success);
                        });
                        mainWin.down('#CUST_ORDER_IS_ACTIVE').setValue('1');
                        /*資料檢查*/
                        // if (mainWin.down('#CUST_ORDER_STATUS_UUID').getValue() == 'COS_IN_PROCESS') {
                        if (mainWin.down('#CUST_ORDER_ID').getValue() == '') {
                            Ext.MessageBox.show({
                                title: '系統通知',
                                icon: Ext.MessageBox.WARNING,
                                buttons: Ext.Msg.OK,
                                msg: '訂單狀態為『處理中』，必須要填寫『訂單編號』欄位',
                                fn: function() {
                                    mainWin.down('#CUST_ORDER_ID').focus();
                                }
                            });

                            return;
                        };
                        //};
                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                this.param.custOrderUuid = action.result.CUST_ORDER_UUID;
                                this.down("#CUST_ORDER_UUID").setValue(action.result.CUST_ORDER_UUID);
                                //this.myStore.vCustOrderDetail.getProxy().setExtraParam('pCustOrderUuid', action.result.CUST_ORDER_UUID);
                                //this.myStore.vCustOrderDetail.reload();
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
                    xtype: 'button',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/exit16x16.png',
                    text: '關閉',
                    handler: function() {
                        this.up('window').close();
                    }
                }, {
                    xtype: 'tbfill'
                }]
            })
        ]
        this.callParent(arguments);
    },
    closeEvent: function() {
        this.fireEvent('closeEvent', this);
    },
    //1
    fnCompany: function(mainObj, cb) {
        this.myStore.company.load({
            callback: function() {
                var btnMenuOrderPerview = mainObj.down("#btnMenuOrderPerview");
                if (mainObj.myStore.company.getCount() > 0) {
                    var storeCompany = mainObj.myStore.company;
                    if (storeCompany.getCount() > 0) {
                        mainObj.down("#COMPANY_UUID").setValue(storeCompany.getAt(0).get('UUID'));
                    };
                };
                Ext.each(storeCompany.data.items, function(item) {
                    btnMenuOrderPerview.menu.add({
                        text: item.data.C_NAME,
                        handler: function(obj, a, b, c) {
                            var companyName = obj.text,
                                mainWin = obj.up('window');
                            if (mainWin.param.custOrderUuid == "" || mainWin.param.custOrderUuid == undefined) {
                                Ext.MessageBox.show({
                                    title: '通知',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK,
                                    msg: '請先確認是否已正確儲存!'
                                });
                                return;
                            }
                            if (companyName == '利旻禮品文具有限公司') {

                                WS.CustAction.pdfLimew(mainWin.param.custOrderUuid, function(obj, jsonObj) {
                                    if (jsonObj.result.success) {


                                        var downloadUrl = SYSTEM_URL_ROOT + '/upload/custOrder/' + jsonObj.result.file;
                                        window.open(downloadUrl);
                                    }
                                }, mainWin);
                            } else if (companyName == '韋成企業商行') {
                                WS.CustAction.pdfW(mainWin.param.custOrderUuid, function(obj, jsonObj) {
                                    if (jsonObj.result.success) {
                                        var downloadUrl = SYSTEM_URL_ROOT + '/upload/custOrder/' + jsonObj.result.file;
                                        window.open(downloadUrl);
                                    }
                                }, mainWin);
                            } else if (companyName == '裕寶企業商行') {
                                WS.CustAction.pdfU(mainWin.param.custOrderUuid, function(obj, jsonObj) {
                                    if (jsonObj.result.success) {
                                        var downloadUrl = SYSTEM_URL_ROOT + '/upload/custOrder/' + jsonObj.result.file;
                                        window.open(downloadUrl);
                                    }
                                }, mainWin);
                            }
                        }
                    });
                });

                mainObj.storeCount++;
                mainObj.fnLoadData(mainObj);
                //2 3
                //cb(mainObj, mainObj.fnShippingStatus);
            }
        });
    },
    //2
    fnCustOrderStatus: function(mainObj, cb) {
        // mainObj.myStore.custOrderStatus.load({
        //     callback: function() {
        //         var custOrderStatus = mainObj.myStore.custOrderStatus;
        // if (mainObj.myStore.custOrderStatus.getCount() > 0) {
        //     mainObj.down("#CUST_ORDER_STATUS_UUID").setValue(custOrderStatus.getAt(0).get('CUST_ORDER_STATUS_UUID'));
        // };
        mainObj.storeCount++;
        mainObj.fnLoadData(mainObj);
        //3 4
        //cb(mainObj, mainObj.fnPayStatus);
        //     }
        // });
    },
    //3
    fnShippingStatus: function(mainObj, cb) {
        // mainObj.myStore.shippingStatus.load({
        //     callback: function() {
        //         var shippingStatus = mainObj.myStore.shippingStatus;
        //         if (mainObj.myStore.shippingStatus.getCount() > 0) {
        //             mainObj.down("#SHIPPING_STATUS_UUID").setValue(shippingStatus.getAt(0).get('SHIPPING_STATUS_UUID'));
        //         };
        mainObj.storeCount++;
        mainObj.fnLoadData(mainObj);
        //         //4 5
        //         //cb(mainObj, mainObj.fnPayMethod);
        //     }
        // });
    },
    //4
    fnPayStatus: function(mainObj, cb) {
        // mainObj.myStore.payStatus.load({
        //     callback: function() {
        //         var payStatus = mainObj.myStore.payStatus;
        //         if (mainObj.myStore.payStatus.getCount() > 0) {
        //             mainObj.down("#PAY_STATUS_UUID").setValue(payStatus.getAt(0).get('PAY_STATUS_UUID'));
        //         };
        mainObj.storeCount++;
        mainObj.fnLoadData(mainObj);
        //         //5 6 
        //         //cb(mainObj, mainObj.fnCust);
        //     }
        // });
    },
    //5
    fnPayMethod: function(mainObj, cb) {
        // mainObj.myStore.payMethod.load({
        //     callback: function() {
        //         var payMethod = mainObj.myStore.payMethod;
        //         if (mainObj.myStore.payMethod.getCount() > 0) {
        //             mainObj.down("#PAY_METHOD_UUID").setValue(payMethod.getAt(0).get('PAY_METHOD_UUID'));
        //         };
        mainObj.storeCount++;
        mainObj.fnLoadData(mainObj);
        //         //6 7
        //         //cb(mainObj, mainObj.fnCustOrg);
        //     }
        // });
    },
    //6
    fnCust: function(mainObj, cb) {
        mainObj.myStore.cust.load({
            callback: function() {
                var cust = mainObj.myStore.cust;
                if (mainObj.myStore.cust.getCount() > 0) {
                    mainObj.down("#CUST_UUID").setValue(cust.getAt(0).get('CUST_UUID'));
                };
                mainObj.storeCount++;
                mainObj.fnLoadData(mainObj);
                //7 8
                //cb(mainObj, mainObj.fnAttendant);
            }
        });
    },
    //7
    fnCustOrg: function(mainObj, cb) {
        mainObj.myStore.custOrg.load({
            callback: function() {
                var custOrg = mainObj.myStore.custOrg;
                if (mainObj.myStore.custOrg.getCount() > 0) {
                    mainObj.down("#CUST_ORG_UUID").setValue(custOrg.getAt(0).get('CUST_ORG_UUID'));
                };
                mainObj.storeCount++;
                mainObj.fnLoadData(mainObj);
                //8 9
                //cb(mainObj, mainObj.fnLoadData);
            }
        });
    },
    //8
    fnAttendant: function(mainObj, cb) {
        mainObj.myStore.attendant.load({
            callback: function() {
                // var custOrg = mainObj.myStore.custOrg;
                // if (mainObj.myStore.custOrg.getCount() > 0) {
                //     mainObj.down("#CUST_ORG_UUID").setValue(custOrg.getAt(0).get('CUST_ORG_UUID'));
                // };
                // 9
                // cb(mainObj);
                mainObj.storeCount++;
                mainObj.fnLoadData(mainObj);
            }
        });
    },
    //9
    fnLoadData: function(mainObj) {
        console.log(mainObj.storeCount);
        if (mainObj.storeCount != 9) {
            return false;
        };



        if (mainObj.param.custOrderUuid != undefined) {

            mainObj.down("#CustOrderForm").getForm().load({
                params: {
                    'pCustOrderUuid': mainObj.param.custOrderUuid
                },
                success: function(response, a, b) {
                    if (a.result.data.CUST_ORDER_REPORT_ATTENDANT_UUID == "") {
                        WS.UserAction.getUserInfo(function(obj, jsonObj) {
                            this.down("#CUST_ORDER_REPORT_ATTENDANT_UUID").setValue(jsonObj.result.UUID);
                        }, this);
                    };

                    if (a.result.data.CUST_ORDER_REPORT_DATE != '' && a.result.data.CUST_ORDER_REPORT_DATE != undefined) {
                        this.down("#CUST_ORDER_REPORT_DATE").setValue(new Date(a.result.data.CUST_ORDER_REPORT_DATE));
                    } else {
                        this.down("#CUST_ORDER_REPORT_DATE").setValue(new Date());
                    };

                    if (a.result.data.CUST_ORDER_SHIPPING_DATE != '' && a.result.data.CUST_ORDER_SHIPPING_DATE != undefined) {
                        //alert(a.result.data.CUST_ORDER_SHIPPING_DATE);
                        this.down("#CUST_ORDER_SHIPPING_DATE").setValue(new Date(a.result.data.CUST_ORDER_SHIPPING_DATE));
                    };

                    if (a.result.data.CUST_ORDER_LIMIT_DATE != '' && a.result.data.CUST_ORDER_LIMIT_DATE != undefined) {
                        //this.down("#CUST_ORDER_LIMIT_DATE").setValue(new Date(a.result.data.CUST_ORDER_LIMIT_DATE));
                    };
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
                scope: mainObj
            });

            mainObj.myStore.vCustOrderDetail.getProxy().setExtraParam('pCustOrderUuid', mainObj.param.custOrderUuid);
            mainObj.myStore.vCustOrderDetail.reload();
            mainObj.unmask();
        } else {
            WS.UserAction.getUserInfo(function(obj, jsonObj) {
                this.down("#CUST_ORDER_REPORT_ATTENDANT_UUID").setValue(jsonObj.result.UUID);
            }, mainObj);
            mainObj.down("#CUST_ORDER_REPORT_DATE").setValue(new Date());
            mainObj.unmask();
        };
    },
    listeners: {
        'show': function() {
            this.mask('資訊載入中…請稍後…');
            //1 2 
            this.fnCompany(this);
            this.fnCustOrderStatus(this);
            this.fnShippingStatus(this);
            this.fnPayStatus(this);
            this.fnPayMethod(this);
            this.fnCust(this);
            this.fnCustOrg(this);
            this.fnAttendant(this);
        },
        'close': function() {
            this.closeEvent();
        }
    }
});
