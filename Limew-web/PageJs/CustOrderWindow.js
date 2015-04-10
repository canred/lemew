Ext.define('WS.CustOrderWindow', {
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
        custOrg: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'CUST',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadCustOrg
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
        })

    },
    width: 1000,
    height: 650,
    layout: 'fit',
    resizable: false,
    draggable: false,
    initComponent: function() {
        this.myStore.vCustOrderDetail = Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'V_CUST_ORDER_DETAIL',
            pageSize: 10,
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
                scope: this,
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
                                this.down('#grdVCustOrderDetail').setTitle('訂單項目明細    數量：' + itemCount + '筆,金額合計：' + sum + '元(未稅)');
                            } else {
                                this.down('#grdVCustOrderDetail').setTitle('訂單項目明細    數量：' + itemCount + '筆,金額合計：' + sum + '元(含稅)');
                            }
                        }, this);
                    };

                    var mainWin = this;
                    for (var i = 0; i < records.length; i++) {
                        if (records[i].data["SUPPLIER_GOODS_UUID"] != "") {
                            var color = '#D96ED1';
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 0
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 1
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 2
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 3
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 4
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 5
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 6
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 7
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 8
                            })).dom.style.background = color;
                        } else if (records[i].data["GOODS_UUID"] != "") {
                            var color = '#A9D941';
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 0
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 1
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 2
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 3
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 4
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 5
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 6
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 7
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 8
                            })).dom.style.background = color;
                        } else {
                            var color = '#D96A5B';
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 0
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 1
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 2
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 3
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 4
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 5
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 6
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 7
                            })).dom.style.background = color;
                            Ext.get(mainWin.down("#grdVCustOrderDetail").getView().getCellByPosition({
                                row: i,
                                column: 8
                            })).dom.style.background = color;
                        }
                    }

                },
                scope: this
            },
            remoteSort: true,
            sorters: [{
                property: 'CUST_ORDER_DETAIL_CR',
                direction: 'ASC'
            }]
        });
        this.items = [
            Ext.create('Ext.form.Panel', {
                api: {
                    load: WS.CustAction.infoCustOrder,
                    submit: WS.CustAction.submitCustOrder
                },
                itemId: 'CustOrderForm',
                paramOrder: ['pCustOrderUuid'],
                autoScroll: true,
                border: true,

                buttonAlign: 'center',
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

                        mainWin.down('#CUST_ORDER_IS_ACTIVE').setValue('1');
                        /*資料檢查*/
                        if (mainWin.down('#CUST_ORDER_STATUS_UUID').getValue() == 'COS_IN_PROCESS') {
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
                        };


                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                this.param.custOrderUuid = action.result.CUST_ORDER_UUID;
                                this.down("#CUST_ORDER_UUID").setValue(action.result.CUST_ORDER_UUID);
                                this.myStore.vCustOrderDetail.getProxy().setExtraParam('pCustOrderUuid', action.result.CUST_ORDER_UUID);

                                this.myStore.vCustOrderDetail.reload();
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
                }],
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
                                xtype: 'radiogroup',
                                width: 250,
                                labelAlign: 'right',
                                fieldLabel: '訂單類型',
                                itemId: 'CUST_ORDER_TYPE',
                                layout: 'hbox',
                                defaults: {
                                    margin: '0 10 0 0'
                                },
                                defaultType: 'radiofield',
                                items: [{
                                    xtype: 'radiofield',
                                    boxLabel: '報價',
                                    inputValue: '0',
                                    name: 'CUST_ORDER_TYPE',
                                    checked: true
                                }, {
                                    xtype: 'radiofield',
                                    boxLabel: '訂單',
                                    inputValue: '1',
                                    name: 'CUST_ORDER_TYPE'
                                }]
                            }, {
                                xtype: 'combo',
                                fieldLabel: '製單人員',
                                labelAlign: 'right',
                                name: 'CUST_ORDER_REPORT_ATTENDANT_UUID',
                                itemId: 'CUST_ORDER_REPORT_ATTENDANT_UUID',
                                displayField: 'C_NAME',
                                valueField: 'UUID',
                                width: 300,
                                labelWidth: 125,
                                editable: false,
                                hidden: false,
                                store: this.myStore.attendant
                            }, {
                                xtype: 'datefield',
                                fieldLabel: '製單日期',
                                value: new Date(),
                                format: 'Y/m/d',
                                submitFormat: 'Y/m/d',
                                width: 210,
                                labelWidth: 90,
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
                            }]
                        }, {
                            xtype: 'container',
                            layout: 'hbox',
                            items: [{
                                xtype: 'textfield',
                                fieldLabel: '訂單編號',
                                itemId: 'CUST_ORDER_ID',
                                name: 'CUST_ORDER_ID',
                                //                             anchor: '0 0',
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
                                store: this.myStore.company,
                                listeners: {
                                    'select': function(combo, records, eOpts) {

                                    }
                                }
                            }, {
                                xtype: 'combo',
                                fieldLabel: '訂單狀態',
                                labelAlign: 'right',
                                labelWidth: 90,
                                width: 210,
                                itemId: 'CUST_ORDER_STATUS_UUID',
                                displayField: 'CUST_ORDER_STATUS_NAME',
                                valueField: 'CUST_ORDER_STATUS_UUID',
                                name: 'CUST_ORDER_STATUS_UUID',
                                editable: false,
                                hidden: false,
                                store: this.myStore.custOrderStatus,
                                allowBlank: false,
                                listeners: {
                                    'change': function(combo, records, eOpts) {
                                        var mainWin = combo.up('window'),
                                            payStatus = mainWin.down('#PAY_STATUS_UUID'),
                                            payMethod = mainWin.down('#PAY_METHOD_UUID'),
                                            shippingStatus = mainWin.down('#SHIPPING_STATUS_UUID'),
                                            custOrderType = mainWin.down('#CUST_ORDER_TYPE');

                                        if (combo.getValue() == 'COS_INIT') {
                                            payStatus.setValue('pay_status_1');
                                            payMethod.setValue('PM_INIT');
                                            shippingStatus.setValue('SS_INIT');
                                            payStatus.setReadOnly(true);
                                            payMethod.setReadOnly(true);
                                            shippingStatus.setReadOnly(true);

                                        } else {
                                            payStatus.setReadOnly(false);
                                            payMethod.setReadOnly(false);
                                            shippingStatus.setReadOnly(false);

                                            custOrderType.setValue({
                                                CUST_ORDER_TYPE: '1'
                                            });
                                        }
                                    }
                                }
                            }, {
                                xtype: 'combo',
                                fieldLabel: '付款狀態',
                                width: 190,
                                labelAlign: 'right',
                                itemId: 'PAY_STATUS_UUID',
                                displayField: 'PAY_STATUS_NAME',
                                valueField: 'PAY_STATUS_UUID',
                                name: 'PAY_STATUS_UUID',
                                editable: false,
                                hidden: false,
                                store: this.myStore.payStatus,
                                readOnly: true,
                                allowBlank: false,
                                listeners: {
                                    'select': function(combo, records, eOpts) {

                                    }
                                }
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
                                    handler: function(handler, scope) {
                                        //your code
                                    }
                                }]
                            }, {
                                xtype: 'container',
                                layout: 'hbox',
                                items: [{
                                    xtype: 'combo',
                                    width: 255,
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
                                            if (custOrderDept.getValue() == "" && record) {
                                                custOrderDept.setValue(record.data.CUST_ORG_NAME)
                                            };
                                            if (custOrderUserName.getValue() == "" && record) {
                                                custOrderUserName.setValue(record.data.CUST_ORG_SALES_NAME)
                                            };
                                            if (custOrderUserPhone.getValue() == "" && record) {
                                                custOrderUserPhone.setValue(record.data.CUST_ORG_SALES_PHONE)
                                            };
                                        }
                                    }
                                }, {
                                    xtype: 'button',
                                    text: '',
                                    width: 20,
                                    handler: function(handler, scope) {
                                        //your code
                                    }
                                }]
                            }, {
                                xtype: 'tbfill'
                            }, {
                                xtype: 'combo',
                                fieldLabel: '付款方式',
                                labelAlign: 'right',
                                width: 190,
                                itemId: 'PAY_METHOD_UUID',
                                displayField: 'PAY_METHOD_NAME',
                                valueField: 'PAY_METHOD_UUID',
                                name: 'PAY_METHOD_UUID',
                                editable: false,
                                hidden: false,
                                readOnly: true,
                                store: this.myStore.payMethod,
                                allowBlank: false,
                                listeners: {
                                    'select': function(combo, records, eOpts) {

                                    }
                                }
                            }]
                        }, {
                            xtype: 'container',
                            layout: 'hbox',
                            items: [{
                                xtype: 'combo',
                                fieldLabel: '出貨狀態',
                                labelAlign: 'right',
                                width: 275,
                                labelWidth: 100,
                                itemId: 'SHIPPING_STATUS_UUID',
                                displayField: 'SHIPPING_STATUS_NAME',
                                valueField: 'SHIPPING_STATUS_UUID',
                                name: 'SHIPPING_STATUS_UUID',
                                //                             //labelWidth: 90,
                                editable: false,
                                hidden: false,
                                allowBlank: false,
                                store: this.myStore.shippingStatus,
                                readOnly: true,
                                listeners: {
                                    'select': function(combo, records, eOpts) {

                                    }
                                }
                            }, {
                                xtype: 'datefield',
                                fieldLabel: '出貨日期',
                                //value: new Date(),
                                format: 'Y/m/d',
                                submitFormat: 'Y/m/d',
                                labelAlign: 'right',
                                width: 275,
                                name: 'CUST_ORDER_SHIPPING_DATE',
                                itemId: 'CUST_ORDER_SHIPPING_DATE'

                            }, {
                                xtype: 'textfield',
                                fieldLabel: '出貨單號',
                                name: 'CUST_ORDER_SHIPPING_NUMBER',
                                itemId: 'CUST_ORDER_SHIPPING_NUMBER',
                                labelAlign: 'right',
                                labelWidth: 90,

                                emptyText: '自動產生',
                                readOnly: true,
                                flex: 1
                            }]
                        }, {
                            xtype: 'container',
                            layout: 'hbox',
                            padding: '5 0 0 0',
                            items: [{
                                xtype: 'textfield',
                                fieldLabel: '出貨地址',
                                labelAlign: 'right',
                                flex: 1,
                                labelWidth: 100,
                                itemId: 'SHIPPING_ADDRESS',
                                name: 'SHIPPING_ADDRESS',
                                //                             hidden: false
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
                                        //obj.close();
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
                        }, {
                            xtype: 'container',
                            layout: 'hbox',
                            items: [{
                                xtype: 'checkbox',
                                fieldLabel: '訂單含稅',
                                name: 'CUST_ORDER_HAS_TAX',
                                checked: true,
                                inputValue: '1',
                                flex: 1,
                                labelAlign: 'right'
                            }]
                        }
                        // , {
                        //     xtype: 'container',
                        //     layout: 'hbox',
                        //     margin: '5 0 5 0',
                        //     items: [{
                        //         xtype: 'textfield',
                        //         name: 'CUST_ORDER_INVOICE_NUMBER',
                        //         fieldLabel: '發票號碼',
                        //         flex: 1,
                        //         labelAlign: 'right',
                        //         fieldStyle: 'background-color:#F2D49B'
                        //     }]
                        // }

                    ]
                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    flex: 1,
                    items: [{
                        flex: 1,
                        margin: '0 10 5 0',
                        labelAlign: 'right',
                        xtype: 'textarea',
                        fieldLabel: '備註',
                        name: 'CUST_ORDER_PS'
                    }]
                }, {
                    xtype: 'hidden',
                    fieldLabel: 'CUST_ORDER_UUID',
                    name: 'CUST_ORDER_UUID',
                    //                     anchor: '100%',
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
                    itemId: 'grdVCustOrderDetail',
                    //plugins: [this.rowEditing],
                    plugins: [
                        Ext.create('Ext.grid.plugin.RowEditing', {
                            clicksToMoveEditor: 1,
                            autoCancel: true,
                            listeners: {
                                edit: function(editor, e) {
                                    // var mainPanel = editor.grid.up('panel');
                                    // var store = mainPanel.down('#grdMyOrderQuery').getStore();
                                    // Ext.each(store.getModifiedRecords(), function(item) {
                                    //     var my_order_uuid = item.data.MY_ORDER_UUID;
                                    //     var my_order_date = item.data.MY_ORDER_DATE;
                                    //     var my_order_supplier_name = item.data.MY_ORDER_SUPPLIER_NAME;
                                    //     var my_order_supplier_tel = item.data.MY_ORDER_SUPPLIER_TEL;
                                    //     var my_order_supplier_man = item.data.MY_ORDER_SUPPLIER_MAN;
                                    //     var my_order_goods_name = item.data.MY_ORDER_GOODS_NAME;
                                    //     var my_order_goods_count = item.data.MY_ORDER_GOODS_COUNT;
                                    //     var my_order_price = item.data.MY_ORDER_PRICE;
                                    //     var my_order_total_price = item.data.MY_ORDER_TOTAL_PRICE;
                                    //     var my_order_ps = item.data.MY_ORDER_PS;
                                    //     var my_order_is_finish = item.data.MY_ORDER_IS_FINISH;
                                    //     var my_order_pay_method = item.data.MY_ORDER_PAY_METHOD;
                                    //     var my_order_is_active = item.data.MY_ORDER_IS_ACTIVE;
                                    //     var my_order_attendant_uuid = item.data.MY_ORDER_ATTENDANT_UUID;

                                    //     WS.MyOrderAction.quickEdit(
                                    //         my_order_uuid,
                                    //         my_order_date,
                                    //         my_order_supplier_name,
                                    //         my_order_supplier_tel,
                                    //         my_order_supplier_man,
                                    //         my_order_goods_name,
                                    //         my_order_goods_count,
                                    //         my_order_price,
                                    //         my_order_total_price,
                                    //         my_order_ps,
                                    //         my_order_is_finish,
                                    //         my_order_pay_method,
                                    //         my_order_is_active,
                                    //         my_order_attendant_uuid,
                                    //         function(obj, jsonObj) {

                                    //         }
                                    //     );
                                    // });
                                    // mainPanel.up('panel').myStore.myOrder.reload();
                                }
                            }
                        })
                    ],
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
                            //margin: '0 5 0 5',
                            handler: function(grid, rowIndex, colIndex) {
                                var mainWin = grid.up('window');
                                Ext.MessageBox.confirm('刪除操作', '確定要刪除這一個訂單明細?', function(result) {
                                    if (result == 'yes') {
                                        WS.CustAction.destoryCustOrderDetail(grid.getStore().getAt(rowIndex).data.CUST_ORDER_DETAIL_UUID, function(obj, jsonObj) {
                                            if (jsonObj.result.success) {
                                                var store = mainWin.down('#grdVCustOrderDetail').getStore(),
                                                    count = store.getCount();
                                                if (count == 1) {
                                                    if (store.currentPage > 1) {
                                                        store.previousPage();
                                                    } else {
                                                        store.reload();
                                                    };
                                                } else {
                                                    store.reload();
                                                };

                                            };
                                        }, mainWin);
                                    };
                                }, mainWin);
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
                        xtype: 'textbox',
                        text: "商品",
                        dataIndex: 'CUST_ORDER_DETAIL_GOODS_NAME',
                        align: 'left',
                        flex: 2,
                        ,
                        editor: {
                            xtype: 'textfield',                           
                            listeners: {
                                render: function(obj, eOpts) {
                                    //return new Date();
                                }
                            }
                        }
                    }, {
                        text: "單價",
                        dataIndex: 'CUST_ORDER_DETAIL_PRICE',
                        align: 'right',
                        flex: 1
                    }, {
                        text: "數量",
                        dataIndex: 'CUST_ORDER_DETAIL_COUNT',
                        align: 'right',
                        flex: 1
                    }, {
                        text: "單位",
                        dataIndex: 'CUST_ORDER_DETAIL_UNIT_NAME',
                        align: 'center',
                        width: 60
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
                    height: 350,
                    bbar: Ext.create('Ext.toolbar.Paging', {
                        store: this.myStore.vCustOrderDetail,
                        displayInfo: true,
                        displayMsg: '第{0}~{1}資料/共{2}筆',
                        emptyMsg: "無資料顯示"
                    }),
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
                    }],
                    listeners: {
                        cellclick: function(iView, iCellEl, iColIdx, iRecord, iRowEl, iRowIdx, iEvent) {

                        }
                    }
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
                // ,
                //     btnMenuOrder = mainObj.down("#btnMenuOrder");
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
                    // btnMenuOrder.menu.add({
                    //     text: item.data.C_NAME,
                    //     handler:function(){
                    //         alert('未完成');
                    //     }
                    // });
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
        mainObj.myStore.custOrderStatus.load({
            callback: function() {
                var custOrderStatus = mainObj.myStore.custOrderStatus;
                if (mainObj.myStore.custOrderStatus.getCount() > 0) {
                    mainObj.down("#CUST_ORDER_STATUS_UUID").setValue(custOrderStatus.getAt(0).get('CUST_ORDER_STATUS_UUID'));
                };
                mainObj.storeCount++;
                mainObj.fnLoadData(mainObj);
                //3 4
                //cb(mainObj, mainObj.fnPayStatus);
            }
        });
    },
    //3
    fnShippingStatus: function(mainObj, cb) {
        mainObj.myStore.shippingStatus.load({
            callback: function() {
                var shippingStatus = mainObj.myStore.shippingStatus;
                if (mainObj.myStore.shippingStatus.getCount() > 0) {
                    mainObj.down("#SHIPPING_STATUS_UUID").setValue(shippingStatus.getAt(0).get('SHIPPING_STATUS_UUID'));
                };
                mainObj.storeCount++;
                mainObj.fnLoadData(mainObj);
                //4 5
                //cb(mainObj, mainObj.fnPayMethod);
            }
        });
    },
    //4
    fnPayStatus: function(mainObj, cb) {
        mainObj.myStore.payStatus.load({
            callback: function() {
                var payStatus = mainObj.myStore.payStatus;
                if (mainObj.myStore.payStatus.getCount() > 0) {
                    mainObj.down("#PAY_STATUS_UUID").setValue(payStatus.getAt(0).get('PAY_STATUS_UUID'));
                };
                mainObj.storeCount++;
                mainObj.fnLoadData(mainObj);
                //5 6 
                //cb(mainObj, mainObj.fnCust);
            }
        });
    },
    //5
    fnPayMethod: function(mainObj, cb) {
        mainObj.myStore.payMethod.load({
            callback: function() {
                var payMethod = mainObj.myStore.payMethod;
                if (mainObj.myStore.payMethod.getCount() > 0) {
                    mainObj.down("#PAY_METHOD_UUID").setValue(payMethod.getAt(0).get('PAY_METHOD_UUID'));
                };
                mainObj.storeCount++;
                mainObj.fnLoadData(mainObj);
                //6 7
                //cb(mainObj, mainObj.fnCustOrg);
            }
        });
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
        //console.log(mainObj.storeCount);
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
        } else {
            WS.UserAction.getUserInfo(function(obj, jsonObj) {
                this.down("#CUST_ORDER_REPORT_ATTENDANT_UUID").setValue(jsonObj.result.UUID);
            }, mainObj);
            mainObj.down("#CUST_ORDER_REPORT_DATE").setValue(new Date());
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
