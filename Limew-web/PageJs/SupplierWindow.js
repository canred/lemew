/*columns 使用default*/
Ext.define('WS.SupplierWindow', {
    extend: 'Ext.window.Window',
    title: '廠商維護',
    icon: SYSTEM_URL_ROOT + '/css/custimages/supplier16x16.png',
    closeAction: 'destroy',
    modal: true,
    closable: false,
    param: {
        supplierUuid: undefined
    },
    myStore: {
        vSupplierGoods: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            remoteSort: true,
            model: 'V_SUPPLIER_GOODS',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.SupplierAction.loadVSupplierGoods
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pSupplierUuid', 'pKeyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    'pSupplierUuid': '',
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
                property: 'SUPPLIER_GOODS_NAME',
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
        this.items = [Ext.create('Ext.form.Panel', {

            api: {
                load: WS.SupplierAction.infoSupplier,
                submit: WS.SupplierAction.submitSupplier
            },
            itemId: 'SupplierForm',
            paramOrder: ['pSupplierUuid'],
            autoScroll: true,
            border: true,
            //bodyPadding: 5,
            buttonAlign: 'center',
            items: [{
                xtype: 'container',
                layout: 'vbox',
                defaultType: 'textfield',
                defaults: {
                    width: 700
                },
                items: [{
                    xtype: 'textfield',
                    fieldLabel: '廠商名稱',
                    itemId: 'SUPPLIER_NAME',
                    name: 'SUPPLIER_NAME',
                    padding: '5 0 0 0',
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
                        name: 'SUPPLIER_TEL',
                        flex: 1,
                        maxLength: 84,
                        allowBlank: false,
                        labelAlign: 'right'
                    }, {
                        xtype: 'textfield',
                        fieldLabel: '傳真',
                        labelWidth: 100,
                        name: 'SUPPLIER_FAX',
                        flex: 1,
                        maxLength: 340,
                        labelAlign: 'right'
                    }]
                }, {
                    fieldLabel: '地址',
                    labelWidth: 100,
                    name: 'SUPPLIER_ADDRESS',
                    padding: '5 0 0 0',
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
                        name: 'SUPPLIER_IS_ACTIVE',
                        checked: true,
                        flex: 2,
                    }, {
                        xtype: 'radiofield',
                        boxLabel: '不啟用',
                        inputValue: '0',
                        name: 'SUPPLIER_IS_ACTIVE',
                        flex: 2,
                    }]
                }, {
                    xtype: 'textarea',
                    fieldLabel: '備註',
                    name: 'SUPPLIER_PS',
                    anchor: '0 0',
                    labelAlign: 'right',
                    selectOnFocus: true,
                    grow: true
                }, {
                    xtype: 'fieldset',
                    border: true,
                    title: '業務員',
                    margin: '0 0 0 105',
                    width: 595,
                    defaults: {
                        anchor: '-10 0',
                        labelAlign: 'right'
                    },
                    items: [{
                        xtype: 'container',
                        layout: 'hbox',
                        padding: '0 0 5 0',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '名稱',
                            name: 'SUPPLIER_SALES_NAME',
                            labelAlign: 'right'
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '電話',
                            name: 'SUPPLIER_SALES_PHONE',
                            labelAlign: 'right'
                        }]
                    }, {
                        xtype: 'textfield',
                        fieldLabel: 'Email',
                        anchor: '-23 0',
                        name: 'SUPPLIER_SALES_EMAIL'
                    }]
                }, {
                    xtype: 'fieldset',
                    border: true,
                    title: '聯絡窗口',
                    margin: '0 0 0 105',
                    width: 595,
                    defaults: {
                        anchor: '-10 0',
                        labelAlign: 'right'
                    },
                    items: [{
                        xtype: 'container',
                        layout: 'hbox',
                        padding: '0 0 5 0',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '名稱',
                            name: 'SUPPLIER_CONTACT_NAME',
                            labelAlign: 'right'
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '電話',
                            name: 'SUPPLIER_CONTACT_PHONE',
                            labelAlign: 'right'
                        }]
                    }, {
                        xtype: 'textfield',
                        fieldLabel: 'email',
                        anchor: '-23 0',
                        name: 'SUPPLIER_CONTACT_EMAIL'
                    }]
                }]
            }, {
                xtype: 'hidden',
                fieldLabel: 'SUPPLIER_UUID',
                name: 'SUPPLIER_UUID',
                padding: '5 0 0 0',
                anchor: '100%',
                maxLength: 84,
                itemId: 'SUPPLIER_UUID'
            }, {
                xtype: 'tabpanel',
                plain: false,
                border: true,
                padding: 10,
                maxWidth: 880,
                items: [{
                    title: '供應商品',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/goods16x16.png',
                    items: [{
                        xtype: 'gridpanel',
                        store: this.myStore.vSupplierGoods,
                        paramsAsHash: false,
                        autoScroll: true,
                        columns: [
                            // {
                            //     text: "編輯",
                            //     xtype: 'actioncolumn',
                            //     dataIndex: 'SUPPLIER_GOODS_UUID',
                            //     align: 'center',
                            //     width: 60,
                            //     items: [{
                            //         tooltip: '*編輯',
                            //         icon: SYSTEM_URL_ROOT + '/css/images/edit16x16.png',
                            //         handler: function(grid, rowIndex, colIndex) {
                            //             var mainWin = this.up('window');
                            //             var subWin = Ext.create('WS.SupplierGoodsWindow', {
                            //                 param: {
                            //                     supplierGoodsUuid: grid.getStore().getAt(rowIndex).data.SUPPLIER_GOODS_UUID,
                            //                     parentObj: mainWin
                            //                 }
                            //             });
                            //             subWin.on('closeEvent', function(obj) {
                            //                 obj.param.parentObj.myStore.vSupplierGoods.loadPage(1);
                            //             });

                            //             subWin.show();
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
                                    '{[this.fnInit()]}<input type="button" style="width:50px" value="編輯" onclick="SupplierWindowFnEdit(\'{SUPPLIER_GOODS_UUID}\')"/>',
                                    "</tpl>", {
                                        scope: this,
                                        fnInit: function() {
                                            document.SupplierWindow = this.scope;
                                            if (!document.SupplierWindowFnEdit) {
                                                document.SupplierWindowFnEdit = function(SUPPLIER_GOODS_UUID) {
                                                    var mainWin = document.SupplierWindow;
                                                    var subWin = Ext.create('WS.SupplierGoodsWindow', {
                                                        param: {
                                                            supplierGoodsUuid: SUPPLIER_GOODS_UUID,
                                                            parentObj: mainWin
                                                        }
                                                    });
                                                    subWin.on('closeEvent', function(obj) {
                                                        obj.param.parentObj.myStore.vSupplierGoods.loadPage(1);
                                                    });
                                                    subWin.show();
                                                }
                                            }

                                        }
                                    }),

                            }, {
                                text: "名稱",
                                dataIndex: 'SUPPLIER_GOODS_NAME',
                                align: 'left',
                                flex: 1
                            }, {
                                text: "單位",
                                dataIndex: 'UNIT_NAME',
                                align: 'center',
                                width: 120
                            }, {
                                text: "序號",
                                dataIndex: 'SUPPLIER_GOODS_SN',
                                align: 'left',
                                flex: 1
                            }, {
                                text: "售價",
                                dataIndex: 'SUPPLIER_GOODS_PRICE',
                                align: 'right',
                                width: 120
                            }, {
                                text: "成本",
                                dataIndex: 'SUPPLIER_GOODS_COST',
                                align: 'right',
                                width: 120
                            }
                        ],
                        height: 400,
                        tbar: [{
                            xtype: 'tbfill'
                        }, {
                            icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                            text: '新增供應商商品',
                            itemId: 'btnAddSupplierGood',
                            handler: function() {
                                var mainWin = this.up('window');

                                var subWin = Ext.create('WS.SupplierGoodsWindow', {
                                    param: {
                                        supplierGoodsUuid: undefined,
                                        supplierUuid: mainWin.down("#SUPPLIER_UUID").getValue(),
                                        parentObj: mainWin
                                    }
                                });
                                subWin.on('closeEvent', function(obj) {
                                    obj.param.parentObj.myStore.vSupplierGoods.loadPage(1);
                                });

                                subWin.show();
                            }
                        }],
                        bbar: Ext.create('Ext.toolbar.Paging', {
                            store: this.myStore.vSupplierGoods,
                            displayInfo: true,
                            displayMsg: '第{0}~{1}資料/共{2}筆',
                            emptyMsg: "無資料顯示"
                        })
                    }]
                }]
            }],
            fbar: [{
                type: 'button',
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存',
                handler: function() {
                    var form = this.up('window').down("#SupplierForm").getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            this.param.supplierUuid = action.result.SUPPLIER_UUID;
                            this.down("#SUPPLIER_UUID").setValue(action.result.SUPPLIER_UUID);
                            this.down('#btnAddSupplierGood').setDisabled(false);
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
                        scope: this.up('window')
                    });
                }
            }, {
                type: 'button',
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存&關閉',
                handler: function() {
                    var form = this.up('window').down("#SupplierForm").getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            this.param.supplierUuid = action.result.SUPPLIER_UUID;
                            this.down("#SUPPLIER_UUID").setValue(action.result.SUPPLIER_UUID);
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
                            var supplierUuid = mainWin.param.supplierUuid;
                            WS.SupplierAction.destorySupplier(supplierUuid, function(obj, jsonObj) {
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
            this.mask('資料準備中…');
            //if (this.param.supplierUuid != undefined) {
            this.down("#SupplierForm").getForm().load({
                params: {
                    'pSupplierUuid': this.param.supplierUuid
                },
                success: function(response, a, b) {
                    if (a.result.data.SUPPLIER_IS_ACTIVE == '-1') {
                        this.down('#btnAddSupplierGood').setDisabled(true);
                    };
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

            var proxy = this.myStore.vSupplierGoods.getProxy();
            proxy.setExtraParam('pSupplierUuid', this.param.supplierUuid);
            this.myStore.vSupplierGoods.loadPage(1);

            //} 
            // else {
            //     this.down("#SupplierForm").getForm().reset();
            // };


        },
        'close': function() {
            this.closeEvent();
            this.myStore.vSupplierGoods.removeAll();
            this.down('form').reset();
        }
    }
});
