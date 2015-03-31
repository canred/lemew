/*columns 使用default*/
Ext.define('WS.MyOrderWindow', {
    extend: 'Ext.window.Window',
    title: '訂貨維護',
    icon: SYSTEM_URL_ROOT + '/css/custimages/Record16x16.png',
    closeAction: 'destroy',
    closable: false,
    param: {
        myOrderUuid: undefined
    },
    fnActiveRender: function(value, id, r) {
        var html = "<img src='" + SYSTEM_URL_ROOT;
        return value === "1" ? html + "/css/custimages/active03.png'>" : html + "/css/custimages/unactive03.png'>";
    },
    myStore: {

    },
    width: 800,
    height: 450,
    layout: 'fit',
    resizable: false,
    draggable: false,
    fnCal: function(mainWin) {
        var p = mainWin.down('#MY_ORDER_PRICE').getValue();
        var c = mainWin.down('#MY_ORDER_GOODS_COUNT').getValue();
        var tObj = mainWin.down('#MY_ORDER_TOTAL_PRICE');

        if (Ext.isNumber(p) && Ext.isNumber(c)) {
            tObj.setValue(p * c);
        };

    },
    initComponent: function() {
        this.items = [Ext.create('Ext.form.Panel', {
            api: {
                load: WS.MyOrderAction.infoMyOrder,
                submit: WS.MyOrderAction.submitMyOrder
            },
            itemId: 'MyOrderForm',
            paramOrder: ['pMyOrderUuid'],
            overflowY: 'scroll',
            border: true,
            bodyPadding: 5,
            buttonAlign: 'center',
            items: [{
                xtype: 'container',
                layout: 'vbox',
                defaultType: 'textfield',
                defaults: {
                    width: 770
                },
                items: [{
                    xtype: 'fieldset',
                    title: '供應商',
                    border: true,
                    items: [{
                        xtype: 'textfield',
                        fieldLabel: '供應商名稱',
                        itemId: 'MY_ORDER_SUPPLIER_NAME',
                        name: 'MY_ORDER_SUPPLIER_NAME',
                        anchor: '0 0',
                        maxLength: 12,
                        allowBlank: false,
                        labelAlign: 'right'
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        margin: '0 0 5 0',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '人員',
                            labelWidth: 100,
                            name: 'MY_ORDER_SUPPLIER_MAN',
                            flex: 1,
                            maxLength: 84,
                            allowBlank: true,
                            labelAlign: 'right'
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '電話',
                            labelWidth: 100,
                            name: 'MY_ORDER_SUPPLIER_TEL',
                            flex: 1,
                            maxLength: 340,
                            labelAlign: 'right'
                        }]
                    }]
                }, {
                    xtype: 'fieldset',
                    title: '商品資訊',
                    border: true,
                    flex: 1,
                    items: [{
                        xtype: 'textfield',
                        fieldLabel: '貨品名稱',
                        labelWidth: 100,
                        margin: '5 0 5 0',
                        name: 'MY_ORDER_GOODS_NAME',
                        anchor: '0 0',
                        labelAlign: 'right',
                        allowBlank: false
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        margin: '0 0 5 0',

                        items: [{
                            xtype: 'numberfield',
                            fieldLabel: '價格',
                            labelWidth: 100,
                            name: 'MY_ORDER_PRICE',
                            itemId: 'MY_ORDER_PRICE',
                            flex: 1,
                            allowBlank: false,
                            labelAlign: 'right',
                            listeners: {
                                change: function(e, t, eOpts) {
                                    var mainWin = this.up('window');
                                    mainWin.fnCal(mainWin);
                                }
                            }
                        }, {
                            xtype: 'numberfield',
                            fieldLabel: '數量',
                            labelWidth: 100,
                            name: 'MY_ORDER_GOODS_COUNT',
                            itemId: 'MY_ORDER_GOODS_COUNT',
                            flex: 1,
                            allowBlank: false,
                            labelAlign: 'right',
                            listeners: {
                                change: function(e, t, eOpts) {
                                    var mainWin = this.up('window');
                                    mainWin.fnCal(mainWin);
                                }
                            }
                        }, {
                            xtype: 'numberfield',
                            fieldLabel: '總價',
                            labelWidth: 100,
                            name: 'MY_ORDER_TOTAL_PRICE',
                            itemId: 'MY_ORDER_TOTAL_PRICE',
                            flex: 1,
                            labelAlign: 'right',
                            allowBlank: false,
                            readOnly: true
                        }]
                    }, {
                        xtype: 'datefield',
                        fieldLabel: '建立日期',
                        value: new Date(),
                        width: 250,
                        format: 'Y/m/d',
                        submitFormat: 'Y/m/d',
                        name: 'MY_ORDER_DATE',
                        itemId: 'MY_ORDER_DATE',
                        labelAlign: 'right',
                        allowBlank: false
                    }]
                }, {
                    xtype: 'fieldset',
                    title: '狀態',
                    border: true,
                    items: [{
                        xtype: 'container',
                        layout: 'hbox',
                        margin: '0 0 5 0',
                        items: [{
                            xtype: 'fieldcontainer',
                            labelAlign: 'right',
                            fieldLabel: '完成',
                            layout: 'hbox',
                            defaults: {
                                margins: '0 10 0 0'
                            },
                            defaultType: 'radiofield',
                            flex: 1,
                            items: [{
                                xtype: 'radiofield',
                                boxLabel: '完成',
                                inputValue: '1',
                                name: 'MY_ORDER_IS_FINISH',
                                flex: 1,
                            }, {
                                xtype: 'radiofield',
                                boxLabel: '處理中',
                                inputValue: '0',
                                name: 'MY_ORDER_IS_FINISH',
                                flex: 1,
                                checked: true
                            }]
                        }, {
                            flex: 2,
                            xtype: 'combo',
                            fieldLabel: '支援方式',
                            labelAlign: 'right',
                            queryMode: 'local',
                            itemId: 'MY_ORDER_PAY_METHOD',
                            displayField: 'text',
                            valueField: 'value',
                            name: 'MY_ORDER_PAY_METHOD',
                            editable: false,
                            hidden: false,
                            value: '未設定',
                            store: new Ext.data.ArrayStore({
                                fields: ['text', 'value'],
                                data: [
                                    ['未設定', '未設定'],
                                    ['現金', '現金'],
                                    ['支票', '支票'],
                                    ['信用卡', '信用卡'],
                                    ['其他', '其他']
                                ]
                            })
                        }]
                    }]
                }, {
                    xtype: 'fieldset',
                    title: '備註',
                    border: true,
                    items: [{
                        xtype: 'textarea',
                        name: 'MY_ORDER_PS',
                        margin: '0 0 5 0',
                        anchor: '0 0',
                        selectOnFocus: true,
                        grow: true
                    }]
                }]
            }, {
                xtype: 'hidden',
                fieldLabel: 'MY_ORDER_UUID',
                name: 'MY_ORDER_UUID',
                anchor: '100%',
                maxLength: 84,
                itemId: 'MY_ORDER_UUID'
            }],
            fbar: [{
                type: 'button',
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存',
                handler: function() {
                    var form = this.up('window').down("#MyOrderForm").getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            this.param.myOrderUuid = action.result.MY_ORDER_UUID;
                            this.down("#MY_ORDER_UUID").setValue(action.result.MY_ORDER_UUID);
                            Ext.MessageBox.show({
                                title: '操作完成',
                                msg: '操作完成',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                fn:function(){
                                    this.close();
                                },
                                scope:this
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
                    Ext.MessageBox.confirm('刪除訂貨操作', '確定要刪除這一個訂貨資訊?', function(result) {
                        if (result == 'yes') {
                            var myOrderUuid = mainWin.param.myOrderUuid;
                            WS.MyOrderAction.destoryMyOrder(myOrderUuid, function(obj, jsonObj) {
                                if (jsonObj.result.success) {
                                    this.close();
                                } else {
                                    Ext.MessageBox.show({
                                        title: '刪除訂貨操作(1502221728)',
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
            Ext.getBody().mask();
            if (this.param.myOrderUuid != undefined) {
                //alert(this.param.myOrderUuid);
                this.down("#MyOrderForm").getForm().load({
                    params: {
                        'pMyOrderUuid': this.param.myOrderUuid
                    },
                    success: function(response, a, b) {
                        if (a.result.data.MY_ORDER_DATE != '' && a.result.data.MY_ORDER_DATE != undefined) {
                            this.down("#MY_ORDER_DATE").setValue(new Date(a.result.data.MY_ORDER_DATE));
                        } else {
                            this.down("#MY_ORDER_DATE").setValue(new Date());
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
                    scope:this
                });
            } else {
                this.down("#MyOrderForm").getForm().reset();
            };
        },
        'close': function() {
            Ext.getBody().unmask();
            this.closeEvent();
        }
    }
});
