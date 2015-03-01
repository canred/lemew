Ext.define('WS.SupplierGoodsWindow', {
    extend: 'Ext.window.Window',
    title: '供應商-商品維護',
    icon: SYSTEM_URL_ROOT + '/css/custimages/box16x16.png',
    closeAction: 'destroy',
    closable: false,
    param: {
        supplierGoodsUuid: undefined,
        parentObj: undefined
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
            sorters: [{
                property: 'SUPPLIER_NAME',
                direction: 'ASC'
            }]
        }),
        unit: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
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
    width: 750,
    height: 600,
    layout: 'fit',
    resizable: false,
    draggable: false,
    initComponent: function() {
        this.items = [
            Ext.create('Ext.form.Panel', {
                api: {
                    load: WS.SupplierAction.infoSupplierGoods,
                    submit: WS.SupplierAction.submitSupplierGoods
                },
                itemId: 'SupplierGoodsForm',
                paramOrder: ['pSupplierGoodsUuid'],
                autoScroll: true,
                border: true,
                bodyPadding: 5,
                buttonAlign: 'center',
                items: [{
                    xtype: 'container',
                    layout: 'vbox',
                    defaultType: 'textfield',
                    defaults: {
                        width: 700
                    },
                    items: [{
                        xtype: 'combo',
                        fieldLabel: '供應商',
                        itemId: 'cmbSupplier',
                        labelAlign: 'right',
                        displayField: 'SUPPLIER_NAME',
                        valueField: 'SUPPLIER_UUID',
                        name: 'SUPPLIER_UUID',
                        padding: 5,
                        editable: false,
                        hidden: false,
                        store: this.myStore.supplier,
                        allowBlank: false
                    }, {
                        xtype: 'textfield',
                        fieldLabel: '商品名稱',
                        itemId: 'SUPPLIER_GOODS_NAME',
                        name: 'SUPPLIER_GOODS_NAME',
                        padding: 5,
                        anchor: '0 0',
                        maxLength: 12,
                        allowBlank: false,
                        labelAlign: 'right'
                    }, {
                        xtype: 'combo',
                        fieldLabel: '單位',
                        itemId: 'cmbUnit',
                        labelAlign: 'right',
                        displayField: 'UNIT_NAME',
                        valueField: 'UNIT_UUID',
                        name: 'UNIT_UUID',
                        padding: 5,
                        editable: false,
                        hidden: false,
                        store: this.myStore.unit,
                        allowBlank: false
                    }, {
                        fieldLabel: '序號',
                        labelWidth: 100,
                        name: 'SUPPLIER_GOODS_SN',
                        padding: 5,
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
                            name: 'SUPPLIER_GOODS_IS_ACTIVE',
                            checked: true,
                            flex: 2,
                        }, {
                            xtype: 'radiofield',
                            boxLabel: '不啟用',
                            inputValue: '0',
                            name: 'SUPPLIER_GOODS_IS_ACTIVE',
                            flex: 2,
                        }]
                    }, {
                        xtype: 'fieldset',
                        border: true,
                        title: '價格',
                        margin: '0 0 10 60',
                        width: 640,
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
                                name: 'SUPPLIER_GOODS_PRICE',
                                labelAlign: 'right',
                                allowBlank: false
                            }, {
                                xtype: 'numberfield',
                                minValue: 0,
                                fieldLabel: '成本',
                                name: 'SUPPLIER_GOODS_COST',
                                labelAlign: 'right',
                                allowBlank: false
                            }]
                        }]
                    }]
                }, {
                    xtype: 'hidden',
                    fieldLabel: 'SUPPLIER_GOODS_UUID',
                    name: 'SUPPLIER_GOODS_UUID',
                    padding: 5,
                    anchor: '100%',
                    maxLength: 84,
                    itemId: 'SUPPLIER_GOODS_UUID'
                }],
                fbar: [{
                    type: 'button',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                    text: '儲存',
                    handler: function() {
                        var form = this.up('window').down("#SupplierGoodsForm").getForm();
                        if (form.isValid() == false) {
                            return;
                        };
                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                this.param.supplierGoodsUuid = action.result.SUPPLIER_GOODS_UUID;
                                this.down("#SUPPLIER_GOODS_UUID").setValue(action.result.SUPPLIER_GOODS_UUID);
                                Ext.MessageBox.show({
                                    title: '操作完成',
                                    msg: '操作完成',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK
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
                        Ext.MessageBox.confirm('刪除此供應商品操作', '確定要刪除這一個供應商品資訊?', function(result) {
                            if (result == 'yes') {
                                var supplierGoodsUuid = mainWin.param.supplierGoodsUuid;
                                WS.SupplierAction.destorySupplierGoods(supplierGoodsUuid, function(obj, jsonObj) {
                                    if (jsonObj.result.success) {
                                        this.close();
                                    } else {
                                        Ext.MessageBox.show({
                                            title: '刪除供應商品操作(1502271645)，造成原因可能是此資料已被使用!',
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

            this.myStore.unit.load({
                callback: function(obj, jsonObj) {
                    this.myStore.supplier.load({
                        callback: function(obj, jsonObj) {
                            if (this.param.supplierGoodsUuid != undefined) {
                                this.down("#SupplierGoodsForm").getForm().load({
                                    params: {
                                        'pSupplierGoodsUuid': this.param.supplierGoodsUuid
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
                                this.down("#SupplierGoodsForm").getForm().reset();

                            };
                        },
                        scope: this
                    });
                },
                scope: this
            });

            if (this.param.parentObj) {
                this.param.parentObj.mask();
            };
        },
        'close': function() {


            this.closeEvent();

            if (this.param.parentObj) {
                this.param.parentObj.unmask();
            };
        }
    }
});
