Ext.define('WS.MyOrderDetailWindow', {
    extend: 'Ext.window.Window',
    title: '訂貨-供應商商品',
    icon: SYSTEM_URL_ROOT + '/css/custimages/gift16x16.png',
    closeAction: 'destroy',
    autoScroll: true,
    modal: true,
    width: 800,
    height: 600,
    fnLoadFile: function() {
        alert('file');
    },
    fnCal: function() {
        var mainWin = this.up('window'),
            count = mainWin.down('#MY_ORDER_DETAIL_GOODS_COUNT').getValue();
        price = mainWin.down('#MY_ORDER_DETAIL_PRICE').getValue();
        if (Ext.isNumber(count) && Ext.isNumber(price)) {
            mainWin.down('#MY_ORDER_DETAIL_TOTAL_PRICE').setValue(count * price);
        };
    },
    param: {
        supplierUuid: undefined,
        myOrderUuid: undefined,
        myOrderDetailUuid: undefined
    },
    myStore: {},
    resizable: false,
    draggable: false,
    fnActiveRender: function(value, id, r) {
        var html = "<img src='" + SYSTEM_URL_ROOT;
        return value === "1" ? html + "/css/custimages/active03.png'>" : html + "/css/custimages/unactive03.png'>";
    },
    fnCheckSubWindowns: function() {

        if (Ext.isEmpty(this.subWinGoods)) {
            Ext.MessageBox.show({
                title: '系統提示',
                icon: Ext.MessageBox.WARNING,
                buttons: Ext.Msg.OK,
                msg: '未實現 subWinGoods 物件,無法進行編輯操作!'
            });
            return false;
        };
        return true;
    },
    initComponent: function() {
        this.myStore.vSupplierGoods = Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
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
                    pSupplierUuid: this.param.supplierUuid,
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
            listeners: {
                scope: this
            },
            sorters: [{
                property: 'SUPPLIER_GOODS_NAME',
                direction: 'ASC'
            }]
        });
        this.myStore.unit = Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            remoteSort: true,
            model: 'UNIT',
            pageSize: 9999,
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
            listeners: {
                load: function(self, records, successful, eOpts) {
                    if (records.length >= 1) {
                        if (this.down('#UNIT_UUID').getValue() == '') {
                            this.down('#UNIT_UUID').setValue(records[0].data.UNIT_UUID);
                        };
                    }
                },
                scope: this
            },
            sorters: [{
                property: 'UNIT_NAME',
                direction: 'ASC'
            }]
        });
        this.items = [{
            xtype: 'panel',
            collapsible: true,
            itemId: 'pnlGoods',
            title: '選擇商品',
            frame: false,
            border: false,
            autoHeight: true,
            autoWidth: true,
            padding: 0,
            listeners: {
                collapse: function(p, eOpts) {
                    p.hide();
                }
            },
            items: [{
                xtype: 'container',
                layout: 'hbox',
                margin: '5 0 0 5',
                items: [{
                    xtype: 'textfield',
                    fieldLabel: '關鍵字',
                    itemId: 'txt_search',
                    labelWidth: 50,
                    enableKeyEvents: true,
                    listeners: {
                        keyup: function(e, t, eOpts) {
                            var keyCode = t.keyCode;
                            if (keyCode == Ext.event.Event.ENTER) {
                                this.up('panel').down("#btnQuery").handler();
                            };
                        }
                    }
                }, {
                    xtype: 'button',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/find.png',
                    text: '查詢',
                    margin: '0 0 0 20',
                    itemId: 'btnQuery',
                    width: 80,
                    handler: function() {
                        var store = this.up('panel').down("#grdSupplierGoodsQuery").getStore(),
                            doSomeghing = function(obj, pl) {
                                obj.getProxy().setExtraParam('pKeyword', pl.down("#txt_search").getValue());
                                obj.loadPage(1);
                            }(store, this.up('panel'));
                    }
                }]
            }, {
                xtype: 'gridpanel',
                store: this.myStore.vSupplierGoods,
                itemId: 'grdSupplierGoodsQuery',
                border: true,
                height: 500,
                padding: '5 15 5 5',
                selModel: new Ext.selection.CheckboxModel({
                    mode: 'SINGLE',
                    checkOnly: true,
                    listeners: {
                        selectionchange: function(selectionModel, selected, options) {
                            if (selected[0]) {
                                console.log('canred');
                                var mainWin = this;
                                mainWin.down('#MY_ORDER_DETAIL_GOODS_NAME').setValue(selected[0].data.SUPPLIER_GOODS_NAME);
                                mainWin.down('#MY_ORDER_DETAIL_PRICE').setValue(selected[0].data.SUPPLIER_GOODS_PRICE);
                                mainWin.down('#SUPPLIER_GOODS_UUID').setValue(selected[0].data.SUPPLIER_GOODS_UUID);
                                mainWin.down('#pnlGoods').collapse();
                                mainWin.down('#frmMyOrderDetail').show();
                            }
                        },
                        scope: this
                    }
                }),
                columns: [{
                    header: "名稱",
                    dataIndex: 'SUPPLIER_GOODS_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    header: '單位',
                    dataIndex: 'UNIT_UUID',
                    align: 'left',
                    flex: 1
                }, {
                    header: "序號",
                    align: 'left',
                    dataIndex: 'SUPPLIER_GOODS_SN',
                    flex: 1
                }, {
                    header: "售價",
                    dataIndex: 'SUPPLIER_GOODS_PRICE',
                    align: 'right',
                    hidden: true,
                    flex: 1
                }, {
                    header: '成本',
                    dataIndex: 'SUPPLIER_GOODS_COST',
                    align: 'right',
                    hidden: true,
                    flex: 1
                }, {
                    header: '有效',
                    dataIndex: 'SUPPLIER_GOODS_IS_ACTIVE',
                    align: 'center',
                    flex: 1,
                    renderer: this.fnActiveRender
                }],
                tbarCfg: {
                    buttonAlign: 'right'
                },
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.vSupplierGoods,
                    displayInfo: true,
                    displayMsg: '第{0}~{1}資料/共{2}筆',
                    emptyMsg: "無資料顯示"
                })
            }]
        }, {
            xtype: 'form',
            padding: '5 15 5 5',
            width: 780,
            layout: 'form',
            api: {
                load: WS.MyOrderAction.infoMyOrderDetail,
                submit: WS.MyOrderAction.submitMyOrderDetail
            },
            hidden: true,
            itemId: 'frmMyOrderDetail',
            paramOrder: ['pMyOrderDetailUuid', 'pMyOrderUuid'],
            items: [{
                xtype: 'container',
                layout: 'hbox',
                defaults: {
                    labelAlign: 'right'
                },
                items: [{
                    xtype: 'textfield',
                    fieldLabel: '商品名稱',
                    name: 'MY_ORDER_DETAIL_GOODS_NAME',
                    itemId: 'MY_ORDER_DETAIL_GOODS_NAME',
                    allowBlank: false,
                    flex: 1
                }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                margin: '5 0 0 0',
                defaults: {
                    labelAlign: 'right'
                },
                items: [{
                    xtype: 'numberfield',
                    fieldLabel: '數量',
                    name: 'MY_ORDER_DETAIL_GOODS_COUNT',
                    itemId: 'MY_ORDER_DETAIL_GOODS_COUNT',
                    allowBlank: false,
                    minValue: 1,
                    value: 1,
                    listeners: {
                        change: this.fnCal
                    }
                }, {
                    xtype: 'combo',
                    fieldLabel: '單位',
                    allowBlank: false,
                    itemId: 'UNIT_UUID',
                    displayField: 'UNIT_NAME',
                    valueField: 'UNIT_UUID',
                    name: 'UNIT_UUID',
                    store: this.myStore.unit,
                    editable: false,
                    hidden: false
                }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                padding: '5 0 0 0',
                defaults: {
                    labelAlign: 'right'
                },
                items: [{
                    xtype: 'numberfield',
                    fieldLabel: '單價',
                    name: 'MY_ORDER_DETAIL_PRICE',
                    itemId: 'MY_ORDER_DETAIL_PRICE',
                    minValue: 1,
                    allowBlank: false,
                    listeners: {
                        change: this.fnCal
                    }
                }, {
                    xtype: 'textfield',
                    fieldLabel: '總價',
                    name: 'MY_ORDER_DETAIL_TOTAL_PRICE',
                    itemId: 'MY_ORDER_DETAIL_TOTAL_PRICE',
                    readOnly: true,
                    allowBlank: false
                }, {

                }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                padding: '5 0 0 0',
                defaults: {
                    labelAlign: 'right'
                },
                items: [{
                    xtype: 'textarea',
                    fieldLabel: '備註',
                    name: 'MY_ORDER_DETAIL_PS',
                    itemId: 'MY_ORDER_DETAIL_PS',
                    flex: 1
                }]
            }, {
                xtype: 'container',
                layout: 'vbox',
                items: [{
                    xtype: 'hiddenfield',
                    itemId: 'MY_ORDER_DETAIL_UUID',
                    name: 'MY_ORDER_DETAIL_UUID',
                    itemId: 'MY_ORDER_DETAIL_UUID'
                }, {
                    xtype: 'hiddenfield',
                    fieldLabel: 'MY_ORDER_UUID',
                    name: 'MY_ORDER_UUID',
                    itemId: 'MY_ORDER_UUID'
                }, {
                    xtype: 'hiddenfield',
                    fieldLabel: 'IS_ACTIVE',
                    name: 'MY_ORDER_DETAIL_IS_ACTIVE',
                    itemId: 'MY_ORDER_DETAIL_IS_ACTIVE',
                    value: "1"
                }, {
                    xtype: 'hiddenfield',
                    fieldLabel: 'MY_ORDER_DETAIL_IS_ACTIVE',
                    name: 'MY_ORDER_DETAIL_IS_ACTIVE',
                    itemId: 'MY_ORDER_DETAIL_IS_ACTIVE'
                }, {

                    xtype: 'hiddenfield',
                    fieldLabel: 'SUPPLIER_GOODS_UUID',
                    name: 'SUPPLIER_GOODS_UUID',
                    itemId: 'SUPPLIER_GOODS_UUID'
                }]
            }],
            fbar: [{
                xtype: 'tbfill'
            }, {
                xtype: 'button',
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存',
                handler: function() {
                    var mainWin = this.up('window'),
                        form = this.up('window').down("#frmMyOrderDetail").getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    mainWin.down('#MY_ORDER_DETAIL_IS_ACTIVE').setValue('1');
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            this.param.myOrderDetailUuid = action.result.MY_ORDER_DETAIL_UUID;
                            this.down("#MY_ORDER_DETAIL_UUID").setValue(action.result.MY_ORDER_DETAIL_UUID);
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
                itemId: 'btnDelete',
                handler: function() {
                    var mainWin = this.up('window');
                    Ext.MessageBox.confirm('刪除操作', '確定要刪除這一個訂貨明細?', function(result) {
                        if (result == 'yes') {
                            WS.MyOrderAction.destoryMyOrderDetail(this.param.myOrderDetailUuid, function(obj, jsonObj) {
                                if (jsonObj.result.success) {
                                    this.close();
                                };
                            }, mainWin);
                        };
                    }, mainWin);
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
        }];
        this.callParent(arguments);
    },
    closeEvent: function() {
        this.fireEvent('closeEvent', this);
    },
    listeners: {
        'show': function() {
            this.mask('資訊載入中…請稍後…');
            this.down('#btnQuery').handler();
            if (this.param.myOrderUuid) {
                this.down("#MY_ORDER_UUID").setValue(this.param.myOrderUuid);
            };
            this.myStore.unit.load({
                callback: function() {
                    var mainObj = this;
                    mainObj.down("#frmMyOrderDetail").getForm().load({
                        params: {
                            'pMyOrderDetailUuid': mainObj.param.myOrderDetailUuid == undefined ? "" : mainObj.param.myOrderDetailUuid,
                            'pMyOrderUuid': mainObj.param.myOrderUuid == undefined ? "" : mainObj.param.myOrderUuid
                        },
                        success: function(response, a, b) {
                            this.down("#MY_ORDER_UUID").setValue(this.param.myOrderUuid);
                            if (this.down("#UNIT_UUID").getValue() == "") {
                                this.down("#UNIT_UUID").setValue(this.myStore.unit.getAt(0).data.UNIT_UUID);
                            };
                            if (this.down("#MY_ORDER_DETAIL_IS_ACTIVE").getValue() == 0) {
                                this.down('#btnDelete').setDisabled(true);
                            } else {
                                this.down('#btnDelete').setDisabled(false);
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
                        scope: mainObj
                    });
                    if (mainObj.param.myOrderDetailUuid) {
                        mainObj.down('#pnlGoods').collapse();
                        mainObj.down('#frmMyOrderDetail').show();
                    };
                },
                scope: this
            });
        },
        'close': function() {
            this.closeEvent();
            this.myStore.vSupplierGoods.removeAll();
            this.myStore.unit.removeAll();
            this.down('form').reset();
        }
    }
});
