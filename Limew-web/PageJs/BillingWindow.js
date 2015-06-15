Ext.define('WS.BillingWindow', {
    extend: 'Ext.window.Window',
    title: '請款單維護',
    icon: SYSTEM_URL_ROOT + '/css/custimages/moneyB16x16.png',
    closeAction: 'destroy',
    closable: false,
    storeCount: 1,
    modal: true,
    param: {
        billingUuid: undefined,
        parentObj: undefined,
        canSelectCust: false
    },
    myStore: {
        attendant: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'ATTENDANT_V',
            pageSize: 9999,
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
            pageSize: 9999,
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
            sorters: [{
                property: 'CUST_NAME',
                direction: 'ASC'
            }]
        })
    },
    width: 900,
    height: 620,
    //layout: 'vbox',
    layout: {
        type: 'border'
    },
    resizable: false,
    draggable: false,
    fnCal: function(mainWin) {
        var sum = 0,
            itemCount = 0,
            records = mainWin.myStore.vBillingDetail.data.items;

        Ext.each(records, function(item) {
            sum += parseFloat(item.data.CUST_ORDER_TOTAL_PRICE);
            itemCount++;
        });
        if (itemCount > 0) {
            this.down('#btnMoney').show();
            this.down('#btnMoneyTitle').show();
            this.down('#btnMoneyTitle').setText('<span style="font-size:18px;">數量：' + itemCount + '筆</span>');
            this.down('#BILLING_SUM_PRICE').setValue(sum);
            var v = mainWin.down("#BILLING_DISCOUNT");
            if (v.isValid()) {
                if (!Ext.isEmpty(this.down('#BILLING_DISCOUNT').getValue())) {
                    sum = sum - this.down('#BILLING_DISCOUNT').getValue();
                }
                this.down('#btnMoney').setText('<span style="font-size:18px;">請款金額：' + sum + '元</span>');
                this.down('#BILLING_TOTAL_PRICE').setValue(sum);
            }
        }else{
            this.down('#btnMoney').hide();
            this.down('#btnMoneyTitle').hide();
            this.down('#btnMoneyTitle').setText('<span style="font-size:18px;">數量：0筆</span>');
            this.down('#BILLING_SUM_PRICE').setValue(0);
           
            this.down('#btnMoney').setText('<span style="font-size:18px;">請款金額：0元</span>');
            this.down('#BILLING_TOTAL_PRICE').setValue(0);
            

        };
    },
    fnCreateCustOrderDetailCustomize: function(createNumber, targetFromObject) {
        if (this.param.modified && this.param.modified) {
            var updateData = "";
            Ext.each(this.myStore.vBillingDetail.data.items, function(item) {
                updateData += item.data.CUST_ORDER_DETAIL_UUID + "`" + item.data.CUST_ORDER_DETAIL_GOODS_NAME + "`" + item.data.CUST_ORDER_DETAIL_PRICE + "`" + item.data.CUST_ORDER_DETAIL_COUNT + "`" + item.data.CUST_ORDER_DETAIL_PS + "|";
            });

            if (targetFromObject) {
                UTIL.Alert('自動儲存', 1000, 50, targetFromObject.getX(), targetFromObject.getY() + targetFromObject.getHeight(), 2000);
            } else {
                UTIL.Alert('自動儲存', 1000, 50, 0, 0, 2000);
            };

            WS.CustAction.batchUpdateCustOrderDetail(updateData, function(obj, jsonObj) {
                WS.CustAction.createCustOrderDetailCustomize(this.param.custOrderUuid, createNumber, function(obj, jsonObj) {
                    if (jsonObj.result.success) {
                        this.myStore.vBillingDetail.reload();
                    };
                }, this);

            }, this);


        } else {
            WS.CustAction.createCustOrderDetailCustomize(this.param.custOrderUuid, createNumber, function(obj, jsonObj) {
                if (jsonObj.result.success) {
                    this.myStore.vBillingDetail.reload();
                };
            }, this);
        }

    },
    initComponent: function() {
        this.myStore.vBillingDetail = Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'V_BILLING_DETAIL',
            pageSize: 9999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.BillingAction.loadVBillingDetail
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pBillingUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pBillingUuid: ''
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
                        sum += parseFloat(item.data.CUST_ORDER_TOTAL_PRICE);
                        itemCount++;
                    });
                    if (itemCount > 0) {


                        this.down('#btnMoney').show();
                        this.down('#btnMoneyTitle').show();

                        this.down('#btnMoneyTitle').setText('<span style="font-size:18px;">數量：' + itemCount + '筆</span>');

                        this.down('#BILLING_SUM_PRICE').setValue(sum);

                        var v = this.down("#BILLING_DISCOUNT");
                        if (v.isValid()) {
                            if (!Ext.isEmpty(this.down('#BILLING_DISCOUNT').getValue())) {

                                sum = sum - this.down('#BILLING_DISCOUNT').getValue();
                            }


                            this.down('#btnMoney').setText('<span style="font-size:18px;">請款金額：' + sum + '元</span>');

                            this.down('#BILLING_TOTAL_PRICE').setValue(sum);
                        }

                    };


                },
                scope: this
            },
            remoteSort: true,
            sorters: [{
                property: 'BILLING_DETAIL_CR',
                direction: 'ASC'
            }]
        });

        this.items = [
            Ext.create('Ext.form.Panel', {
                api: {
                    load: WS.BillingAction.infoBilling,
                    submit: WS.BillingAction.submitBilling
                },
                region: 'center',
                itemId: 'BillingForm',
                paramOrder: ['pBillingUuid'],
                autoScroll: true,
                border: true,
                buttonAlign: 'center',
                items: [{
                        xtype: 'container',
                        layout: 'vbox',
                        defaultType: 'textfield',
                        defaults: {
                            width: 900
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
                            }, {
                                xtype: 'combo',
                                fieldLabel: '製單人員',
                                labelAlign: 'right',
                                name: 'BILLING_REPORT_ATTENDANT_UUID',
                                itemId: 'BILLING_REPORT_ATTENDANT_UUID',
                                displayField: 'C_NAME',
                                valueField: 'UUID',
                                labelWidth: 100,
                                editable: false,
                                hidden: false,
                                store: this.myStore.attendant
                            }, {
                                xtype: 'textfield',
                                fieldLabel: '請款單編號',
                                itemId: 'BILLING_ID',
                                name: 'BILLING_ID',
                                maxLength: 20,
                                allowBlank: false,
                                labelAlign: 'right',
                                fieldStyle: 'background-color:#F2D49B'
                            }, {
                                xtype: 'datefield',
                                fieldLabel: '製單日期',
                                value: new Date(),
                                format: 'Y/m/d',
                                submitFormat: 'Y/m/d',
                                name: 'BILLING_REPORT_DATE',
                                itemId: 'BILLING_REPORT_DATE',
                                labelAlign: 'right',
                                allowBlank: false,
                                width: 220
                            }, {
                                xtype: 'textfield',
                                hidden: true,
                                name: 'BILLING_IS_ACTIVE',
                                itemId: 'BILLING_IS_ACTIVE',
                                value: '0',
                                flex: 1

                            }, {
                                xtype: 'container',

                                items: [{
                                    xtype: 'button',
                                    text: '列印',
                                    icon: SYSTEM_URL_ROOT + '/css/custimages/print16x16.png',
                                    width: 110,
                                    margin: '0 0 0 10',
                                    itemId: 'btnPrint',
                                    arrowAlign: 'right',
                                    handler: function() {

                                        var mainWin = this.up('window'),
                                            form = this.up('window').down("#BillingForm").getForm();
                                        if (form.isValid() == false) {
                                            return;
                                        };
                                        mainWin.down('#BILLING_IS_ACTIVE').setValue('1');
                                        /*資料檢查*/
                                        form.submit({
                                            waitMsg: '更新中...',
                                            success: function(form, action) {
                                                this.param.billingUuid = action.result.BILLING_UUID;
                                                this.down("#BILLING_UUID").setValue(action.result.BILLING_UUID);

                                                WS.BillingAction.pdfBilling(this.param.billingUuid, function(obj, jsonObj) {
                                                    if (jsonObj.result.success) {

                                                        var downloadUrl = SYSTEM_URL_ROOT + '/upload/billing/' + jsonObj.result.file;
                                                        window.open(downloadUrl);
                                                    }
                                                }, mainWin);

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
                                }],
                                flex: 2
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
                                        width: 275,
                                        editable: false,
                                        hidden: false,
                                        store: this.myStore.cust,
                                        allowBlank: false,
                                        listeners: {
                                            change: function(self, newValue, oldValue) {
                                                if (newValue != "") {

                                                    //alert(newValue);    
                                                    var mainWin = this.up('window');

                                                    if (mainWin.param.canSelectCust == true) {
                                                        var r = mainWin.myStore.cust.findRecord("CUST_UUID", newValue);
                                                        if (r) {
                                                            mainWin.down('#BILLING_CUST_NAME').setValue(r.data.CUST_NAME);
                                                            mainWin.down('#BILLING_CUST_UNIFORM_NUM').setValue(r.data.CUST_UNIFORM_NUM);
                                                            mainWin.down('#BILLING_TEL').setValue(r.data.CUST_TEL);
                                                            mainWin.down('#BILLING_CUST_ADDRESS').setValue(r.data.CUST_ADDRESS);
                                                        }
                                                    }

                                                }
                                            }
                                        }
                                    }, {
                                        xtype: 'datefield',
                                        fieldLabel: '訂單開始日期',
                                        value: new Date(),
                                        format: 'Y/m/d',
                                        submitFormat: 'Y/m/d',
                                        name: 'BILLING_START_DATE',
                                        itemId: 'BILLING_START_DATE',
                                        allowBlank: false,
                                        labelAlign: 'right',
                                        renderer: function(value, r) {
                                            return '1999/01/01';
                                        },
                                        render: function() {
                                            return '1998/01/01'
                                        }
                                    }, {
                                        xtype: 'datefield',
                                        fieldLabel: '訂單結束日期',
                                        value: new Date(),
                                        allowBlank: false,
                                        format: 'Y/m/d',
                                        submitFormat: 'Y/m/d',
                                        labelAlign: 'right',
                                        name: 'BILLING_END_DATE',
                                        itemId: 'BILLING_END_DATE',
                                        renderer: function(value, r) {
                                            return '1999/01/01';
                                        },
                                        render: function() {
                                            return '1998/01/01'
                                        },
                                        width: 220
                                    }, {
                                        xtype: 'button',
                                        text: '挑選可請款訂單',
                                        width: 110,
                                        margin: '0 0 0 10',
                                        itemId: 'btnPrint',
                                        arrowAlign: 'right',
                                        handler: function() {
                                            var mainWin = this.up('window'),
                                                custUuid = mainWin.down('#CUST_UUID').getValue(),
                                                startDate = mainWin.down("#BILLING_START_DATE").getValue(),
                                                endDate = mainWin.down("#BILLING_END_DATE").getValue();
                                            if (Ext.isEmpty(custUuid)) {
                                                Ext.MessageBox.show({
                                                    title: '系統提示',
                                                    icon: Ext.MessageBox.INFO,
                                                    buttons: Ext.Msg.OK,
                                                    msg: '請先選擇客戶'
                                                });
                                                return;
                                            }

                                            if (Ext.isEmpty(startDate) || Ext.isEmpty(endDate)) {
                                                Ext.MessageBox.show({
                                                    title: '系統提示',
                                                    icon: Ext.MessageBox.INFO,
                                                    buttons: Ext.Msg.OK,
                                                    msg: '訂單開始日期、結案日期不可以為空值，請先選擇!'
                                                });
                                                return;
                                            }
                                            // WS.CustAction.pdfShipping(mainWin.param.custOrderUuid, function(obj, jsonObj) {
                                            //     if (jsonObj.result.success) {
                                            //         var downloadUrl = SYSTEM_URL_ROOT + '/upload/shipping/' + jsonObj.result.file;
                                            //         window.open(downloadUrl);
                                            //     }
                                            // }, mainWin);
                                            if (custUuid) {
                                                var subWin = Ext.create('WS.CustOrderInInvoicePickerWindow', {
                                                    param: {
                                                        parentObj: mainWin,
                                                        custUuid: custUuid,
                                                        startDate: startDate,
                                                        endDate: endDate
                                                    }
                                                });
                                                subWin.on('selectCustOrder', function(obj, arrCustOrder) {

                                                    var aCo = '';
                                                    Ext.each(arrCustOrder, function(item) {
                                                        aCo += item.data.CUST_ORDER_UUID + '|';
                                                    });
                                                    obj.close();

                                                    WS.BillingAction.addBillingDetail(obj.param.parentObj.param.billingUuid, aCo, function() {
                                                        this.down('#grdVBillingDetail').getStore().reload();
                                                    }, obj.param.parentObj);

                                                });
                                                subWin.show();
                                            }

                                        }
                                    }

                                ]
                            }]
                        }, {
                            xtype: 'container',
                            layout: 'hbox',
                            margin: '5 0 5 0',
                            items: [{
                                xtype: 'container',
                                layout: 'hbox',
                                items: [{
                                        xtype: 'numberfield',
                                        fieldLabel: '應收金額',
                                        labelAlign: 'right',
                                        readOnly: true,
                                        name: 'BILLING_SUM_PRICE',
                                        itemId: 'BILLING_SUM_PRICE'
                                    }

                                ]
                            }, {
                                xtype: 'container',
                                layout: 'hbox',
                                items: [{
                                        xtype: 'numberfield',
                                        fieldLabel: '折扣',
                                        labelAlign: 'right',
                                        name: 'BILLING_DISCOUNT',
                                        itemId: 'BILLING_DISCOUNT',
                                        value: 0,
                                        minValue: 0,
                                        listeners: {
                                            change: function() {
                                                var mainWin = this.up('window');
                                                mainWin.fnCal(mainWin);
                                            }
                                        }
                                    }

                                ]
                            }, {
                                xtype: 'container',
                                layout: 'hbox',

                                items: [{
                                        xtype: 'numberfield',
                                        fieldLabel: '請款金額',
                                        labelAlign: 'right',
                                        name: 'BILLING_TOTAL_PRICE',
                                        itemId: 'BILLING_TOTAL_PRICE',
                                        readOnly: true,
                                        width: 220
                                    }

                                ]
                            }]
                        }]
                    }, {
                        xtype: 'fieldset',
                        border: true,
                        title: '客戶資訊',
                        margin: '0 27 5 45',
                        collapsed: true,
                        collapsible: true,
                        //height: 80,
                        items: [{
                                xtype: 'container',
                                layout: 'hbox',
                                defaults: {
                                    labelAlign: 'right'
                                },
                                items: [{
                                    xtype: 'textfield',
                                    fieldLabel: '客戶名稱',
                                    name: 'BILLING_CUST_NAME',
                                    itemId: 'BILLING_CUST_NAME',
                                    flex: 1
                                }, {
                                    xtype: 'textfield',
                                    fieldLabel: '統一編號',
                                    name: 'BILLING_CUST_UNIFORM_NUM',
                                    itemId: 'BILLING_CUST_UNIFORM_NUM',
                                    flex: 1
                                }, {
                                    xtype: 'textfield',
                                    fieldLabel: '公司電話',
                                    name: 'BILLING_TEL',
                                    itemId: 'BILLING_TEL',
                                    flex: 1
                                }]
                            }, {
                                xtype: 'container',
                                layout: 'hbox',
                                margin: '5 0 5 0',
                                defaults: {
                                    labelAlign: 'right'
                                },
                                items: [{
                                    xtype: 'textfield',
                                    fieldLabel: '公司地址',
                                    name: 'BILLING_CUST_ADDRESS',
                                    itemId: 'BILLING_CUST_ADDRESS',
                                    flex: 1
                                }]
                            }

                        ]
                    }, {
                        xtype: 'fieldset',
                        border: true,
                        title: '備註',
                        margin: '0 27 5 45',
                        height: 100,
                        items: [{
                            xtype: 'textareafield',
                            width: 885,
                            growMin: 35,
                            growMax: 90,
                            grow: true,
                            name: 'BILLING_PS',
                            height: 70
                        }]
                    }, {
                        xtype: 'hidden',
                        fieldLabel: 'BILLING_UUID',
                        name: 'BILLING_UUID',
                        maxLength: 84,
                        itemId: 'BILLING_UUID'
                    },

                    {
                        xtype: 'hidden',
                        fieldLabel: '',
                        name: 'SHIPPING_STATUS_UUID',
                        maxLength: 84,
                        itemId: 'SHIPPING_STATUS_UUID'
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
                        title: '請款訂單明細',
                        store: this.myStore.vBillingDetail,
                        itemId: 'grdVBillingDetail',
                        columns: [{
                                xtype: 'templatecolumn',
                                text: '操作',
                                width: 60,
                                sortable: false,
                                hideable: false,
                                tpl: new Ext.XTemplate(
                                    "<tpl >",
                                    '{[this.fnInit()]}<input type="button" style="width:50px" value="移除" onclick="BillingWindowFnDelete(\'{BILLING_DETAIL_UUID}\')"/>',
                                    "</tpl>", {
                                        scope: this,
                                        fnInit: function() {
                                            document.BillingWindow = this.scope;
                                            if (!document.BillingWindowFnDelete) {
                                                document.BillingWindowFnDelete = function(BILLING_DETAIL_UUID) {
                                                    var mainWin = document.BillingWindow;
                                                    var store = mainWin.down('#grdVBillingDetail').getStore();
                                                    var find = store.findRecord("BILLING_DETAIL_UUID", BILLING_DETAIL_UUID);



                                                    WS.BillingAction.destoryBillingDetail(BILLING_DETAIL_UUID, function(obj, jsonObj) {
                                                        if (jsonObj.result.success) {
                                                            var store = document.BillingWindow.down('#grdVBillingDetail').getStore(),
                                                                count = store.getCount();
                                                            store.remove(find);
                                                            document.BillingWindow.fnCal(document.BillingWindow);

                                                        };
                                                    }, mainWin);
                                                }
                                            }
                                        }
                                    })
                            }, {
                                xtype: 'templatecolumn',
                                text: '查看',
                                width: 60,
                                sortable: false,
                                hideable: false,
                                tpl: new Ext.XTemplate(
                                    "<tpl >",
                                    '{[this.fnInit()]}<input type="button" style="width:50px" value="查看" onclick="BillingWindowFnView(\'{CUST_ORDER_UUID}\',\'{CUST_UUID}\')"/>',
                                    "</tpl>", {
                                        scope: this,
                                        fnInit: function() {
                                            document
                                                .CustWindow = this.scope;
                                            if (!document.BillingWindowFnView) {
                                                document.BillingWindowFnView = function(CUST_ORDER_UUID, CUST_UUID) {
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
                                header: "訂單編號",
                                dataIndex: 'CUST_ORDER_ID',
                                align: 'left',
                                width: 110
                            }, {
                                header: '建立日期',
                                dataIndex: 'CUST_ORDER_CR',
                                align: 'left',
                                width: 80
                            },
                            // {
                            //     header: "客戶名稱",
                            //     dataIndex: 'CUST_NAME',
                            //     align: 'left',
                            //     width: 150
                            // },
                            {
                                header: "單位",
                                dataIndex: 'CUST_ORDER_DEPT',
                                align: 'left',
                                width: 100,
                                hidden: false
                            },
                            // {
                            //     header: "客戶電話",
                            //     align: 'left',
                            //     hidden: true,
                            //     dataIndex: 'CUST_TEL',
                            //     width: 120
                            // },
                            {
                                header: '採購員',
                                dataIndex: 'CUST_ORG_SALES_NAME',
                                align: 'left',
                                width: 70
                            }, {
                                header: '聯絡電話',
                                dataIndex: 'CUST_ORG_SALES_PHONE',
                                align: 'left',
                                width: 100,
                                hidden: true
                            }, {
                                header: '金額',
                                dataIndex: 'CUST_ORDER_TOTAL_PRICE',
                                align: 'right',
                                width: 80,renderer: function (value,r) {                            
                            return Ext.String.format('${0}', value);
                        }  
                            }, {
                                header: '付款狀態',
                                dataIndex: 'PAY_STATUS_NAME',
                                width: 80
                            }, {
                                header: '款項方式',
                                width: 100,
                                dataIndex: 'PAY_METHOD_NAME',
                            }, {
                                header: '款項備註',
                                dataIndex: 'CUST_ORDER_PAY_PS',
                                align: 'right',
                                width: 140,
                                layout: 'hbox',
                            }, {
                                header: '發票號碼',
                                dataIndex: 'CUST_ORDER_INVOICE_NUMBER',
                                align: 'right',
                                width: 140,
                                layout: 'hbox',
                            }, {
                                header: "出貨編號",
                                dataIndex: 'CUST_ORDER_SHIPPING_NUMBER',
                                align: 'left',
                                width: 120
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
                                header: '地址',
                                dataIndex: 'CUST_ADDRESS',
                                align: 'left',
                                width: 150,
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
                                flex: 1,
                                minWidth: 70
                            }, {

                                header: '備註',
                                dataIndex: 'CUST_ORDER_PS',
                                align: 'left',
                                width: 140,
                                layout: 'hbox'
                            }
                        ],
                        height: 275,
                        //autoHeight: true
                    }
                ]
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
                    itemId: 'btnMoneyTitle'
                }, {
                    xtype: 'tbfill'
                }, {
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
                            form = this.up('window').down("#BillingForm").getForm();
                        if (form.isValid() == false) {
                            return;
                        };

                        mainWin.down('#BILLING_IS_ACTIVE').setValue('1');
                        /*資料檢查*/



                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                this.param.billingUuid = action.result.BILLING_UUID;
                                this.down("#BILLING_UUID").setValue(action.result.BILLING_UUID);

                                Ext.MessageBox.show({
                                    title: '操作完成',
                                    msg: '操作完成',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK,
                                    fn: function() {

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
                    icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                    text: '儲存關閉',
                    handler: function() {
                        var mainWin = this.up('window'),
                            form = this.up('window').down("#BillingForm").getForm();
                        if (form.isValid() == false) {
                            return;
                        };
                        mainWin.down('#BILLING_IS_ACTIVE').setValue('1');
                        /*資料檢查*/
                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                this.param.billingUuid = action.result.BILLING_UUID;
                                this.down("#BILLING_UUID").setValue(action.result.BILLING_UUID);

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
                    icon: SYSTEM_URL_ROOT + '/css/images/delete16x16.png',
                    text: '刪除',
                    itemId: 'btnDel',
                    handler: function() {
                        var mainWin = this.up('window');
                        Ext.MessageBox.confirm('刪除請款單操作', '確定要刪除這一個請款單資訊?', function(result) {
                            if (result == 'yes') {
                                var billingUuid = mainWin.param.billingUuid;
                                WS.BillingAction.fullDestoryBilling(billingUuid, function(obj, jsonObj) {
                                    if (jsonObj.result.success) {
                                        this.close();
                                    } else {
                                        Ext.MessageBox.show({
                                            title: '刪除訂單操作(1506031502)',
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

    fnCust: function(mainObj, cb) {
        mainObj.myStore.cust.load({
            callback: function() {
                var cust = mainObj.myStore.cust;
                if (mainObj.myStore.cust.getCount() > 0) {
                    mainObj.down("#CUST_UUID").setValue(cust.getAt(0).get('CUST_UUID'));
                };
                mainObj.storeCount++;
                mainObj.fnLoadData(mainObj);

            }
        });
    },

    //8
    fnAttendant: function(mainObj, cb) {
        mainObj.myStore.attendant.load({
            callback: function() {

                mainObj.storeCount++;
                mainObj.fnLoadData(mainObj);
            }
        });
    },
    //9
    fnLoadData: function(mainObj) {

        if (mainObj.storeCount != 3) {
            return false;
        };


        //alert(mainObj.param.billingUuid)
        if (mainObj.param.billingUuid != undefined) {

            mainObj.down("#BillingForm").getForm().load({
                params: {
                    'pBillingUuid': mainObj.param.billingUuid
                },
                success: function(response, a, b) {
                    if (a.result.data.BILLING_START_DATE == "") {
                        var d = new Date();
                        var month = (d.getMonth() + 1);
                        var day = d.getDate();
                        if (month < 10) {
                            month = "0" + month;
                        };
                        if (day < 10) {
                            day = "0" + day;
                        };
                        //d = d.getFullYear() + '/' + month + "/" + day;
                        d = d.getFullYear() + '/01/01';
                        this.down('#BILLING_START_DATE').setValue(d);
                    } else {
                        var d = new Date(a.result.data.BILLING_START_DATE);
                        var month = (d.getMonth() + 1);
                        var day = d.getDate();
                        if (month < 10) {
                            month = "0" + month;
                        };
                        if (day < 10) {
                            day = "0" + day;
                        };
                        //d = d.getFullYear() + '/' + month + "/" + day;
                        d = d.getFullYear() + '/01/01';
                        this.down('#BILLING_START_DATE').setValue(d);
                    }


                    if (a.result.data.BILLING_END_DATE == "") {
                        var d = new Date();
                        var month = (d.getMonth() + 1);
                        var day = d.getDate();
                        if (month < 10) {
                            month = "0" + month;
                        };
                        if (day < 10) {
                            day = "0" + day;
                        };
                        d = d.getFullYear() + '/' + month + "/" + day;
                        this.down('#BILLING_END_DATE').setValue(d);
                    } else {
                        var d = new Date(a.result.data.BILLING_END_DATE);
                        var month = (d.getMonth() + 1);
                        var day = d.getDate();
                        if (month < 10) {
                            month = "0" + month;
                        };
                        if (day < 10) {
                            day = "0" + day;
                        };
                        d = d.getFullYear() + '/' + month + "/" + day;
                        this.down('#BILLING_END_DATE').setValue(d);
                    }
                    if (a.result.data.BILLING_REPORT_DATE == "") {
                        var d = new Date();
                        var month = (d.getMonth() + 1);
                        var day = d.getDate();
                        if (month < 10) {
                            month = "0" + month;
                        };
                        if (day < 10) {
                            day = "0" + day;
                        };
                        d = d.getFullYear() + '/' + month + "/" + day;
                        this.down('#BILLING_REPORT_DATE').setValue(d);
                    } else {
                        var d = new Date(a.result.data.BILLING_REPORT_DATE);
                        var month = (d.getMonth() + 1);
                        var day = d.getDate();
                        if (month < 10) {
                            month = "0" + month;
                        };
                        if (day < 10) {
                            day = "0" + day;
                        };
                        d = d.getFullYear() + '/' + month + "/" + day;
                        this.down('#BILLING_REPORT_DATE').setValue(d);
                    }

                    //alert(a.result.data.BILLING_REPORT_DATE);
                    // if (a.result.data.BILLING_REPORT_DATE == "") {
                    //     var d = new Date();
                    //     var month = (d.getMonth() + 1);
                    //     var day = d.getDate();
                    //     if (month < 10) {
                    //         month = "0" + month;
                    //     };
                    //     if (day < 10) {
                    //         day = "0" + day;
                    //     };
                    //     d = d.getFullYear() + '/' + month + "/" + day;
                    //     this.down('#BILLING_REPORT_DATE').setValue(d);
                    // }
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

            mainObj.myStore.vBillingDetail.getProxy().setExtraParam('pBillingUuid', mainObj.param.billingUuid);
            mainObj.myStore.vBillingDetail.reload();

        } else {
            WS.UserAction.getUserInfo(function(obj, jsonObj) {
                this.down("#BILLING_REPORT_ATTENDANT_UUID").setValue(jsonObj.result.UUID);
            }, mainObj);
            mainObj.down("#CUST_ORDER_REPORT_DATE").setValue(new Date());

        };
    },
    listeners: {
        'show': function() {
            //this.mask('資訊載入中…請稍後…');

            this.fnCust(this);
            //this.fnCustOrg(this);
            this.fnAttendant(this);
        },
        'close': function() {
            this.myStore.attendant.removeAll();

            this.myStore.cust.removeAll();

            this.myStore.vBillingDetail.removeAll();

            this.closeEvent();
            this.down('form').reset();
        }
    }
});
