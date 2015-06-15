Ext.define('WS.CustOrderStep1ViewWindow', {
    extend: 'Ext.window.Window',
    title: '訂單資訊(唯讀模式)',
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
    },
    width: 1000,
    height: 660,
    layout: {
        type: 'border'
    },
    resizable: false,
    draggable: false,
    fnCompany: function(mainObj, cb) {
        this.myStore.company.load({
            callback: function() {
                var btnMenuOrderPerview = mainObj.down("#btnMenuOrderPerview");
                if (mainObj.myStore.company.getCount() > 0) {
                    var storeCompany = mainObj.myStore.company;
                    if (storeCompany.getCount() > 0) {
                        //mainObj.down("#COMPANY_UUID").setValue(storeCompany.getAt(0).get('UUID'));
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

                //2 3
                //cb(mainObj, mainObj.fnShippingStatus);
            }
        });
    },
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
                    this.down('#btnMoneyTitle').show();

                    this.down('#btnMoneyTitle').setText('<span style="font-size:18px;">數量：' + itemCount + '筆</span>');
                    var taxMoney = sum * 0.05;
                    taxMoney = Math.round(taxMoney * 100) / 100;
                    this.down('#btnMoney').setText('<span style="font-size:18px;">未稅 金額合計：' + sum + '元+稅金' + taxMoney + '元</span>');

                } else {
                    this.down('#btnMoney').show();
                    this.down('#btnMoneyTitle').show();
                    this.down('#btnMoneyTitle').setText('<span style="font-size:18px;">數量：' + itemCount + '筆</span>');
                    this.down('#btnMoney').setText('<span style="font-size:18px;">含稅 金額合計：' + sum + '元</span>');
                }

            }, this);
        };
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
                                this.down('#btnMoneyTitle').show();

                                this.down('#btnMoneyTitle').setText('<span style="font-size:18px;">數量：' + itemCount + '筆</span>');
                                var taxMoney = sum * 0.05;
                                taxMoney = Math.round(taxMoney * 100) / 100;
                                this.down('#btnMoney').setText('<span style="font-size:18px;">未稅 金額合計：' + sum + '元+稅金' + taxMoney + '元</span>');

                            } else {
                                this.down('#btnMoney').show();
                                this.down('#btnMoneyTitle').show();
                                this.down('#btnMoneyTitle').setText('<span style="font-size:18px;">數量：' + itemCount + '筆</span>');
                                this.down('#btnMoney').setText('<span style="font-size:18px;">含稅 金額合計：' + sum + '元</span>');
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
        this.items = [
            Ext.create('Ext.form.Panel', {
                api: {
                    load: WS.CustAction.infoVCustOrder
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
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '製單人員',
                            labelAlign: 'right',
                            name: 'CUST_ORDER_REPORT_ATTENDANT_C_NAME',
                            itemId: 'CUST_ORDER_REPORT_ATTENDANT_C_NAME',
                            labelWidth: 100,
                            readOnly: true
                        }, {
                            xtype: 'datefield',
                            fieldLabel: '製單日期',
                            //value: new Date(),
                            format: 'Y/m/d',
                            submitFormat: 'Y/m/d',
                            //2015/06/01 00:00:00
                            readOnly: true,
                            name: 'CUST_ORDER_REPORT_DATE',
                            itemId: 'CUST_ORDER_REPORT_DATE',
                            labelAlign: 'right'
                        }, {
                            xtype: 'textfield',
                            hidden: true,
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
                            maxLength: 20,
                            allowBlank: true,
                            labelAlign: 'right',
                            readOnly: true,
                            fieldStyle: 'background-color:#F2D49B'
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '開單公司',
                            labelAlign: 'right',
                            itemId: 'COMPANY_C_NAME',
                            name: 'COMPANY_C_NAME',
                            readOnly: true
                        }, {
                            xtype: 'checkbox',
                            fieldLabel: '訂單含稅',
                            name: 'CUST_ORDER_HAS_TAX',
                            checked: true,
                            labelWidth: 80,
                            inputValue: '1',
                            readOnly: true,
                            labelAlign: 'right'
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '請示單號',
                            labelAlign: 'right',
                            labelWidth: 180,
                            readOnly:true,
                            name: 'CUST_ORDER_PS_NUMBER',
                            flex: 1
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        margin: '5 0 5 0',
                        items: [{
                            xtype: 'textfield',
                            allowBlank: true,
                            readOnly: true,
                            width: 275,
                            fieldLabel: '客戶',
                            labelAlign: 'right',
                            name: 'CUST_NAME',
                            itemId: 'CUST_NAME',
                            readOnly: true
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '出貨日期',
                            name: 'CUST_ORDER_SHIPPING_DATE',
                            labelAlign: 'right',
                            allowBlank: true,
                            readOnly: true,
                            readOnly: true,
                            labelWidth: 100,
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '出貨單號',
                            name: 'CUST_ORDER_SHIPPING_NUMBER',
                            labelAlign: 'right',
                            allowBlank: true,
                            readOnly: true,
                            readOnly: true,
                            labelWidth: 80,
                            width: 200
                        }, {
                            xtype: 'textfield',
                            allowBlank: true,
                            readOnly: true,
                            width: 200,
                            labelWidth: 80,
                            fieldLabel: '出貨狀態',
                            labelAlign: 'right',
                            name: 'SHIPPING_STATUS_NAME',
                            itemId: 'SHIPPING_STATUS_NAME',
                            readOnly: true
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        margin: '0 0 5 0',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '付款方式',
                            name: 'PAY_METHOD_NAME',
                            labelAlign: 'right',
                            allowBlank: true,
                            readOnly: true,
                            readOnly: true,
                            labelWidth: 100,
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '付款狀態',
                            name: 'PAY_STATUS_NAME',
                            labelAlign: 'right',
                            allowBlank: true,
                            readOnly: true,
                            readOnly: true,
                            labelWidth: 100
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '發票號碼',
                            name: 'CUST_ORDER_INVOICE_NUMBER',
                            labelAlign: 'right',
                            allowBlank: true,
                            readOnly: true,
                            readOnly: true,
                            labelWidth: 80,
                            width: 200
                        }, {
                            xtype: 'tbfill'
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        padding: '0 0 0 0',
                        items: [{

                        }]
                    }, {
                        xtype: 'fieldset',
                        title: '採購人員資訊',
                        border: true,
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
                                        readOnly: true,
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
                        readOnly: true,
                        name: 'CUST_ORDER_PS'
                    }]
                }, {
                    xtype: 'hidden',
                    fieldLabel: 'CUST_ORDER_UUID',
                    name: 'CUST_ORDER_UUID',
                    maxLength: 84,
                    itemId: 'CUST_ORDER_UUID'
                }, {
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
                    title: '訂單項目明細',
                    store: this.myStore.vCustOrderDetail,
                    itemId: 'grdVCustOrderDetail',
                    columns: [

                        // {
                        //     xtype: 'actioncolumn',
                        //     dataIndex: 'UUID',
                        //     align: 'center',
                        //     width: 60,
                        //     items: [{
                        //         tooltip: '*查看',
                        //         icon: SYSTEM_URL_ROOT + '/css/custImages/view16x16.png',
                        //         handler: function(grid, rowIndex, colIndex) {
                        //             var mainWin = grid.up('window'),
                        //                 custOrderUuid = mainWin.down('#CUST_ORDER_UUID').getValue();
                        //             if (grid.getStore().getAt(rowIndex).data.GOODS_UUID != "") {
                        //                 var subWin = Ext.create('WS.CustOrderDetailViewWindow', {
                        //                     param: {
                        //                         parentObj: mainWin,
                        //                         custOrderUuid: custOrderUuid,
                        //                         custOrderDetailUuid: grid.getStore().getAt(rowIndex).data.CUST_ORDER_DETAIL_UUID
                        //                     }
                        //                 });
                        //                 subWin.on('closeEvent', function() {
                        //                     //mainWin.myStore.vCustOrderDetail.reload();
                        //                 });
                        //                 subWin.show();
                        //             } else if (grid.getStore().getAt(rowIndex).data.SUPPLIER_GOODS_UUID != "") {
                        //                 var subWin = Ext.create('WS.CustOrderDetailSupplierWindow', {
                        //                     param: {
                        //                         parentObj: mainWin,
                        //                         custOrderUuid: custOrderUuid,
                        //                         custOrderDetailUuid: grid.getStore().getAt(rowIndex).data.CUST_ORDER_DETAIL_UUID
                        //                     }
                        //                 });
                        //                 subWin.on('closeEvent', function() {
                        //                     //mainWin.myStore.vCustOrderDetail.reload();
                        //                 });
                        //                 subWin.show();
                        //             } else {
                        //                 var subWin = Ext.create('WS.CustOrderDetailCustomizedViewWindow', {
                        //                     param: {
                        //                         parentObj: mainWin,
                        //                         custOrderUuid: custOrderUuid,
                        //                         custOrderDetailUuid: grid.getStore().getAt(rowIndex).data.CUST_ORDER_DETAIL_UUID
                        //                     }
                        //                 });
                        //                 subWin.on('closeEvent', function() {
                        //                     //mainWin.myStore.vCustOrderDetail.reload();
                        //                 });
                        //                 subWin.show();
                        //             }
                        //         }
                        //     }],
                        //     sortable: false,
                        //     hideable: false
                        // }, 
                        {
                            xtype: 'templatecolumn',
                            text: '查看',
                            width: 70,
                            sortable: false,
                            hideable: false,
                            tpl: new Ext.XTemplate(
                                "<tpl >",
                                '{[this.fnInit()]}<input type="button" style="width:60px" value="查看" onclick="CustOrderStep1ViewWindowFnView(\'{CUST_ORDER_UUID}\',\'{CUST_UUID}\',\'{CUST_ORDER_DETAIL_UUID}\',\'{SUPPLIER_GOODS_UUID}\',\'{GOODS_UUID}\')"/>',
                                "</tpl>", {
                                    scope: this,
                                    fnInit: function() {
                                        document.CustOrderStep1ViewWindow = this.scope;
                                        if (!document.CustOrderStep1ViewWindowFnView) {
                                            document.CustOrderStep1ViewWindowFnView = function(CUST_ORDER_UUID, CUST_UUID, CUST_ORDER_DETAIL_UUID, SUPPLIER_GOODS_UUID, GOODS_UUID) {
                                                var mainWin = document.CustOrderStep1ViewWindow,
                                                    custOrderUuid = mainWin.down('#CUST_ORDER_UUID').getValue();
                                                if (GOODS_UUID != "") {
                                                    var subWin = Ext.create('WS.CustOrderDetailViewWindow', {
                                                        param: {
                                                            parentObj: mainWin,
                                                            custOrderUuid: custOrderUuid,
                                                            custOrderDetailUuid: CUST_ORDER_DETAIL_UUID
                                                        }
                                                    });
                                                    subWin.on('closeEvent', function() {
                                                        //mainWin.myStore.vCustOrderDetail.reload();
                                                    });
                                                    subWin.show();
                                                } else if (SUPPLIER_GOODS_UUID != "") {
                                                    var subWin = Ext.create('WS.CustOrderDetailSupplierWindow', {
                                                        param: {
                                                            parentObj: mainWin,
                                                            custOrderUuid: custOrderUuid,
                                                            custOrderDetailUuid: CUST_ORDER_DETAIL_UUID
                                                        }
                                                    });
                                                    subWin.on('closeEvent', function() {
                                                        //mainWin.myStore.vCustOrderDetail.reload();
                                                    });
                                                    subWin.show();
                                                } else {
                                                    var subWin = Ext.create('WS.CustOrderDetailCustomizedViewWindow', {
                                                        param: {
                                                            parentObj: mainWin,
                                                            custOrderUuid: custOrderUuid,
                                                            custOrderDetailUuid: CUST_ORDER_DETAIL_UUID
                                                        }
                                                    });
                                                    subWin.on('closeEvent', function() {
                                                        //mainWin.myStore.vCustOrderDetail.reload();
                                                    });
                                                    subWin.show();
                                                }
                                            }
                                        }

                                    }
                                }),

                        }
                        // , {
                        //     xtype: 'booleancolumn',
                        //     text: "客製",
                        //     enableColumnHide: false,
                        //     trueText: '是',
                        //     falseText: '否',
                        //     dataIndex: 'CUST_ORDER_DETAIL_CUSTOMIZED',
                        //     align: 'center',
                        //     width: 50
                        // }
                        , {
                            text: "商品",
                            dataIndex: 'CUST_ORDER_DETAIL_GOODS_NAME',
                            align: 'left',
                            flex: 2
                        }, {
                            text: "數量",
                            dataIndex: 'CUST_ORDER_DETAIL_COUNT',
                            align: 'right',
                            flex: 1
                        }, {
                            text: "單位",
                            dataIndex: 'CUST_ORDER_DETAIL_UNIT',
                            align: 'center',
                            width: 60,
                            renderer: function(value, r) {
                                return r.record.data.CUST_ORDER_DETAIL_UNIT_NAME;
                            }
                        }, {
                            text: "單價",
                            dataIndex: 'CUST_ORDER_DETAIL_PRICE',
                            align: 'right',
                            flex: 1,renderer: function (value,r) {                            
                            return Ext.String.format('${0}', value);
                        }  
                        }, {
                            text: "小計",
                            dataIndex: 'CUST_ORDER_DETAIL_TOTAL_PRICE',
                            align: 'right',
                            flex: 1,renderer: function (value,r) {                            
                            return Ext.String.format('${0}', value);
                        }  
                        }, {
                            text: "備註",
                            dataIndex: 'CUST_ORDER_DETAIL_PS',
                            align: 'left',
                            flex: 1
                        }, {
                            xtype: 'templatecolumn',
                            text: '附件(個)',
                            flex: 1,
                            tpl: new Ext.XTemplate(
                                "<tpl >",
                                '{[this.fnInit()]}<input type="button" style="width:100%" value="{[this.fnFileCount(values.FILE_COUNT)]}" onclick="CustOrderStep1ViewWindowFnUploadFile(\'{CUST_ORDER_DETAIL_UUID}\',\'{GOODS_UUID}\',\'{SUPPLIER_GOODS_UUID}\')"/>',
                                "</tpl>", {
                                    scope: this,
                                    fnFileCount: function(filecount) {
                                        if (filecount == "") {
                                            return "無";
                                        } else {
                                            return filecount;
                                        }
                                    },
                                    fnInit: function() {
                                        document.CustOrderStep1ViewWindow = this.scope;
                                        if (!document.CustOrderStep1ViewWindowFnUploadFile) {
                                            document.CustOrderStep1ViewWindowFnUploadFile = function(CUST_ORDER_DETAIL_UUID, GOODS_UUID, SUPPLIER_GOODS_UUID) {
                                                var mainWin = document.CustOrderStep1ViewWindow,
                                                    custOrderUuid = mainWin.down('#CUST_ORDER_UUID').getValue();
                                                if (GOODS_UUID != "") {
                                                    var subWin = Ext.create('WS.CustOrderDetailViewJustFileWindow', {
                                                        param: {
                                                            parentObj: mainWin,
                                                            custOrderUuid: custOrderUuid,
                                                            custOrderDetailUuid: CUST_ORDER_DETAIL_UUID
                                                        }
                                                    });
                                                    subWin.on('closeEvent', function() {
                                                        document.CustOrderStep1ViewWindow.myStore.vCustOrderDetail.reload();
                                                    });
                                                    subWin.show();
                                                } else if (SUPPLIER_GOODS_UUID != "") {
                                                    // var subWin = Ext.create('WS.CustOrderDetailJustFileSupplierWindow', {
                                                    //     param: {
                                                    //         parentObj: mainWin,
                                                    //         custOrderUuid: custOrderUuid,
                                                    //         custOrderDetailUuid: CUST_ORDER_DETAIL_UUID
                                                    //     }
                                                    // });
                                                    // subWin.on('closeEvent', function() {
                                                    //     document.CustOrderStep1ViewWindow.myStore.vCustOrderDetail.reload();
                                                    // });
                                                    // subWin.show();
                                                } else {
                                                    var subWin = Ext.create('WS.CustOrderDetailCustomizedViewJustFileWindow', {
                                                        param: {
                                                            parentObj: mainWin,
                                                            custOrderUuid: custOrderUuid,
                                                            custOrderDetailUuid: CUST_ORDER_DETAIL_UUID
                                                        }
                                                    });
                                                    subWin.on('closeEvent', function() {
                                                        document.CustOrderStep1ViewWindow.myStore.vCustOrderDetail.reload();
                                                    });
                                                    subWin.show();
                                                }
                                            }
                                        }
                                    }
                                })
                        }
                    ],
                    minHeight: 300,
                    autoHeight: true
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
                buttonAlign: 'center',
                buttons: [{
                    xtype: 'button',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/exit16x16.png',
                    text: '關閉',
                    handler: function() {
                        this.up('window').close();
                    }
                }]
            })
        ]
        this.callParent(arguments);
    },
    closeEvent: function() {
        this.fireEvent('closeEvent', this);
    },
    fnLoadData: function(mainObj) {
        this.mask('資訊載入中…請稍後…');
        if (mainObj.param.custOrderUuid != undefined) {
            mainObj.fnCompany(this);
            mainObj.down("#CustOrderForm").getForm().load({
                params: {
                    'pCustOrderUuid': mainObj.param.custOrderUuid
                },
                success: function(response, a, b) {
                    if (a.result.data.CUST_ORDER_REPORT_DATE != '' && a.result.data.CUST_ORDER_REPORT_DATE != undefined) {
                        this.down("#CUST_ORDER_REPORT_DATE").setValue(new Date(a.result.data.CUST_ORDER_REPORT_DATE));
                    } else {
                        this.down("#CUST_ORDER_REPORT_DATE").setValue(new Date());
                    };

                    this.myStore.vCustOrderDetail.getProxy().setExtraParam('pCustOrderUuid', this.param.custOrderUuid);
                    this.myStore.vCustOrderDetail.reload();
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
                scope: mainObj
            });
        };
    },
    listeners: {
        'show': function() {
            this.fnLoadData(this);
        },
        'close': function() {
            this.myStore.company.removeAll();
            this.myStore.vCustOrderDetail.removeAll();
            this.closeEvent();
            this.down('form').reset();
        }
    }
});
