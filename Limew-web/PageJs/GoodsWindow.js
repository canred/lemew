Ext.define('WS.GoodsWindow', {
    extend: 'Ext.window.Window',
    title: '商品維護',
    icon: SYSTEM_URL_ROOT + '/css/custimages/gift16x16.png',
    closeAction: 'destroy',
    closable: false,
    param: {
        goodsUuid: undefined
    },
    myStore: {
        supplier: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            remoteSort: true,
            model: 'SUPPLIER',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.SupplierAction.loadSupplier
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
            listeners: {
                load: function(store, records, sucessful, eOpts) {
                    store.insert(0, {
                        'SUPPLIER_UUID': '',
                        'SUPPLIER_NAME': '---'
                    });
                }
            },
            sorters: [{
                property: 'SUPPLIER_NAME',
                direction: 'ASC'
            }]
        })
    },
    width: 1000,
    height: 450,
    layout: 'fit',
    resizable: false,
    draggable: false,
    initComponent: function() {
        this.items = [
            Ext.create('Ext.form.Panel', {
                api: {
                    load: WS.GoodsAction.infoGoods,
                    submit: WS.GoodsAction.submitGoods
                },
                itemId: 'GoodsForm',
                paramOrder: ['pGoodsUuid'],
                autoScroll: true,
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
                        fieldLabel: '商品名稱',
                        itemId: 'GOODS_NAME',
                        name: 'GOODS_NAME',

                        anchor: '0 0',
                        maxLength: 12,
                        allowBlank: false,
                        labelAlign: 'right'
                    }, {
                        fieldLabel: '序號',
                        labelWidth: 100,
                        name: 'GOODS_SN',

                        anchor: '0 0',
                        labelAlign: 'right'
                    }, {
                        xtype: 'combo',
                        fieldLabel: '供應商',
                        itemId: 'cmbSupplier',
                        labelAlign: 'right',
                        displayField: 'SUPPLIER_NAME',
                        valueField: 'SUPPLIER_UUID',
                        name: 'SUPPLIER_UUID',

                        editable: false,
                        hidden: false,
                        store: this.myStore.supplier,
                        allowBlank: false
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        items: [{
                            fieldLabel: '類別',
                            labelAlign: 'right',
                            xtype: 'textfield',
                            flex: 1,
                            itemId: 'txtGcategoryName',
                            readOnly: true,
                            allowBlank: false
                        }, {
                            xtype: 'button',
                            text: '選',
                            margin: '0 0 0 10',
                            handler: function(handler, scope) {
                                var pickerWin = Ext.create('WS.GcategoryPicker', {
                                    param: {
                                        parentObj: this.up('window')
                                    }
                                });
                                pickerWin.on('selected', function(win, returnRecord) {
                                    if (returnRecord && returnRecord.GCATEGORY_UUID && returnRecord.GCATEGORY_UUID.length > 0) {
                                        win.param.parentObj.down('#GCATEGORY_UUID').setValue(returnRecord.GCATEGORY_UUID);
                                        win.close();
                                    }
                                });
                                pickerWin.show();
                            }
                        }]
                    }, {
                        xtype: 'fieldcontainer',
                        labelAlign: 'right',
                        fieldLabel: '啟用',
                        layout: 'hbox',
                        margin: '5 0 0 0',
                        defaults: {
                            margins: '0 10 0 0'
                        },
                        defaultType: 'radiofield',
                        items: [{
                            xtype: 'radiofield',
                            boxLabel: '啟用',
                            inputValue: '1',
                            name: 'GOODS_IS_ACTIVE',
                            checked: true,
                            flex: 2,
                        }, {
                            xtype: 'radiofield',
                            boxLabel: '不啟用',
                            inputValue: '0',
                            name: 'GOODS_IS_ACTIVE',
                            flex: 2,
                        }]
                    }, {
                        xtype: 'fieldset',
                        border: true,
                        title: '價格',
                        margin: '0 0 10 60',
                        width: 890,
                        height: 55,
                        defaults: {
                            anchor: '-10 0',
                            labelAlign: 'right'
                        },
                        items: [{
                            xtype: 'container',
                            layout: 'hbox',
                            padding: '0 0 5 0',
                            items: [{
                                xtype: 'numberfield',
                                minValue: 0,
                                fieldLabel: '原價',
                                name: 'GOODS_PRICE',
                                labelAlign: 'right',
                                allowBlank: false
                            }, {
                                xtype: 'numberfield',
                                minValue: 0,
                                fieldLabel: '售價',
                                name: 'GOODS_SALE',
                                labelAlign: 'right',
                                allowBlank: false
                            }, {
                                xtype: 'numberfield',
                                minValue: 0,
                                fieldLabel: '成本',
                                name: 'GOODS_COST',
                                labelAlign: 'right',
                                allowBlank: false
                            }]
                        }]
                    }]
                }, {
                    xtype: 'textarea',
                    fieldLabel: '備註',
                    name: 'GOODS_PS',
                    autoWidth: true,
                    anchor: '-35 -250',
                    labelAlign: 'right',
                    selectOnFocus: true
                }, {
                    xtype: 'hiddenfield',
                    fieldLabel: 'GCATEGORY_UUID',
                    name: 'GCATEGORY_UUID',

                    anchor: '100%',
                    maxLength: 84,
                    itemId: 'GCATEGORY_UUID',
                    listeners: {
                        'change': function(obj, newValue, oldValue, eOpts) {
                            if (newValue.length > 0) {
                                WS.GcategoryAction.infoGcategory(newValue, function(obj, jsonObj) {
                                    this.down('#txtGcategoryName').setValue(jsonObj.result.data.GCATEGORY_NAME);
                                }, this.up('window'));
                            };
                        }
                    }
                }, {
                    xtype: 'hidden',
                    fieldLabel: 'GOODS_UUID',
                    name: 'GOODS_UUID',

                    anchor: '100%',
                    maxLength: 84,
                    itemId: 'GOODS_UUID'
                }],
                fbar: [{
                    type: 'button',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                    text: '儲存',
                    handler: function() {
                        var form = this.up('window').down("#GoodsForm").getForm();
                        if (form.isValid() == false) {
                            return;
                        };
                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                this.param.goodsUuid = action.result.GOODS_UUID;
                                this.down("#GOODS_UUID").setValue(action.result.GOODS_UUID);
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
                        Ext.MessageBox.confirm('刪除商品操作', '確定要刪除這一個商品資訊?', function(result) {
                            if (result == 'yes') {
                                var goodsUuid = mainWin.param.goodsUuid;
                                WS.GoodsAction.destoryGoods(goodsUuid, function(obj, jsonObj) {
                                    if (jsonObj.result.success) {
                                        this.close();
                                    } else {
                                        Ext.MessageBox.show({
                                            title: '刪除商品操作(1502272312)，造成原因可能是此資料已被使用!',
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
            })
        ]
        this.callParent(arguments);
    },
    closeEvent: function() {
        this.fireEvent('closeEvent', this);
    },
    listeners: {
        'show': function() {
            Ext.getBody().mask();
            this.myStore.supplier.load({
                callback: function(obj, jsonObj) {
                    if (this.param.goodsUuid != undefined) {
                        this.down("#GoodsForm").getForm().load({
                            params: {
                                'pGoodsUuid': this.param.goodsUuid
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
                    } else {
                        this.down("#GoodsForm").getForm().reset();

                    };
                },
                scope: this
            })
        },
        'close': function() {
            Ext.getBody().unmask();
            this.closeEvent();
        }
    }
});
