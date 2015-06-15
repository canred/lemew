/*columns 使用default*/
Ext.define('WS.MyOrderWindow', {
    extend: 'Ext.window.Window',
    title: '訂貨維護',
    icon: SYSTEM_URL_ROOT + '/css/custimages/Record16x16.png',
    closeAction: 'destroy',
    closable: false,
    modal: true,
    param: {
        myOrderUuid: undefined
    },
    fnActiveRender: function(value, id, r) {
        var html = "<img src='" + SYSTEM_URL_ROOT;
        return value === "1" ? html + "/css/custimages/active03.png'>" : html + "/css/custimages/unactive03.png'>";
    },
    fnCreateMyOrderDetailCustomize: function(createNumber) {
        WS.MyOrderAction.createMyOrderDetailCustomize(this.param.myOrderUuid, createNumber, function(obj, jsonObj) {
            if (jsonObj.result.success) {
                this.myStore.vMyOrderDetail.reload();
            };
        }, this);
    },
    myStore: {
        supplier: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: 'SUPPLIER',
            remoteSort: true,
            pageSize: 99999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.SupplierAction.loadSupplier
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'pSupplierIsActive', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    'pKeyword': '',
                    pSupplierIsActive: '1|0'
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
        vMyOrderDetail: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: 'V_MY_ORDER_DETAIL',
            remoteSort: true,
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.MyOrderAction.loadVMyOrderDetail
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pMyOrderUuid', 'pSupplierUuid', 'pKeyword', 'pIsFinish', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    'pMyOrderUuid': '',
                    'pSupplierUuid': '',
                    'pKeyword': '',
                    'pIsFinish': ''
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
                property: 'MY_ORDER_DETAIL_UUID',
                direction: 'ASC'
            }]
        }),
        unit: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: true,
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
            sorters: [{
                property: 'UNIT_NAME',
                direction: 'ASC'
            }]
        })
    },
    width: 800,
    height: 600,
    layout: 'fit',
    resizable: false,
    draggable: false,
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
                        xtype: 'container',
                        layout: 'hbox',
                        margin: '0 0 5 0',
                        items: [{
                            xtype: 'combo',
                            fieldLabel: '供應商名稱',
                            itemId: 'cmbSupplierUuid',
                            displayField: 'SUPPLIER_NAME',
                            valueField: 'SUPPLIER_UUID',
                            name: 'SUPPLIER_UUID',
                            editable: false,
                            hidden: false,
                            flex: 1,
                            store: this.myStore.supplier,
                            listeners: {
                                'select': function(combo, records, eOpts) {
                                    this.down('#MY_ORDER_SUPPLIER_NAME').setValue(records.data.SUPPLIER_NAME);
                                    this.down('#MY_ORDER_SUPPLIER_ADDRESS').setValue(records.data.SUPPLIER_ADDRESS);
                                    this.down('#MY_ORDER_SUPPLIER_TEL').setValue(records.data.SUPPLIER_TEL);
                                    this.down('#MY_ORDER_SUPPLIER_FAX').setValue(records.data.SUPPLIER_FAX);
                                    this.down('#MY_ORDER_CONTACT_NAME').setValue(records.data.SUPPLIER_CONTACT_NAME);
                                    this.down('#MY_ORDER_CONTACT_PHONE').setValue(records.data.SUPPLIER_CONTACT_PHONE);
                                },
                                scope: this
                            }
                        }, {
                            xtype: 'datefield',
                            fieldLabel: '製單日期',
                            value: new Date(),
                            format: 'Y/m/d',
                            submitFormat: 'Y/m/d',
                            name: 'MY_ORDER_CR',
                            itemId: 'MY_ORDER_CR',
                            labelAlign: 'right',
                            value: new Date(),
                            flex: 1
                        },{
                            xtype:'button',
                            text:'列印',
                            margin:'0 0 0 10',
                            handler:function(handler,scope){
                                var mainWin = this.up('window');
                                WS.MyOrderAction.pdfMyOrder(mainWin.param.myOrderUuid, function(obj, jsonObj) {
                                    if (jsonObj.result.success) {


                                        var downloadUrl = SYSTEM_URL_ROOT + '/upload/myOrder/' + jsonObj.result.file;
                                        window.open(downloadUrl);
                                    }
                                }, mainWin);
                            }
                        }]
                    }, {
                        xtype: 'fieldset',
                        border: true,
                        padding: '5 5 0 0',
                        defaults: {
                            labelAlign: 'right',
                            margin: '5 5 0 0'
                        },
                        items: [{
                            xtype: 'container',
                            layout: 'hbox',
                            defaults: {
                                labelAlign: 'right'
                            },
                            items: [{
                                xtype: 'textfield',
                                fieldLabel: '供應商名稱',
                                name: 'MY_ORDER_SUPPLIER_NAME',
                                itemId: 'MY_ORDER_SUPPLIER_NAME',
                                flex: 1
                            }, {
                                xtype: 'textfield',
                                fieldLabel: '地址',
                                name: 'MY_ORDER_SUPPLIER_ADDRESS',
                                itemId: 'MY_ORDER_SUPPLIER_ADDRESS',
                                flex: 1
                            }]
                        }, {
                            xtype: 'container',
                            layout: 'hbox',
                            defaults: {
                                labelAlign: 'right'
                            },
                            items: [{
                                xtype: 'textfield',
                                fieldLabel: '電話',
                                name: 'MY_ORDER_SUPPLIER_TEL',
                                itemId: 'MY_ORDER_SUPPLIER_TEL',
                                flex: 1
                            }, {
                                xtype: 'textfield',
                                fieldLabel: '傳真',
                                name: 'MY_ORDER_SUPPLIER_FAX',
                                itemId: 'MY_ORDER_SUPPLIER_FAX',
                                flex: 1
                            }]
                        }, {
                            xtype: 'container',
                            layout: 'hbox',
                            padding: '5 0 5 0',
                            defaults: {
                                labelAlign: 'right'
                            },
                            items: [{
                                xtype: 'textfield',
                                fieldLabel: '聯絡人',
                                name: 'MY_ORDER_CONTACT_NAME',
                                itemId: 'MY_ORDER_CONTACT_NAME',
                                flex: 1
                            }, {
                                xtype: 'textfield',
                                fieldLabel: '電話',
                                name: 'MY_ORDER_CONTACT_PHONE',
                                itemId: 'MY_ORDER_CONTACT_PHONE',
                                flex: 1
                            }]
                        }]
                    }]
                }, {
                    xtype: 'fieldset',
                    title: '訂貨備註',
                    border: true,
                    items: [{
                        xtype: 'textarea',
                        name: 'MY_ORDER_PS',
                        margin: '0 0 5 0',
                        anchor: '0 0',
                        selectOnFocus: true,
                        grow: true
                    }]
                }, {
                    xtype: 'fieldset',
                    title: '明細',
                    border: true,
                    flex: 1,
                    items: [{
                        xtype: 'gridpanel',
                        itemId: 'grdVMyOrderDetail',
                        store: this.myStore.vMyOrderDetail,
                        plugins: {
                            ptype: 'cellediting',
                            clicksToEdit: 1,
                            listeners: {
                                beforeedit: function(editor, context, eOpts) {
                                    var mainWin = context.grid.up('window');
                                    mainWin.param.editRecord = context.record;
                                    mainWin.param.editRowIdx = context.rowIdx;
                                    mainWin.param.editColIdx = context.colIdx;
                                },
                                edit: function(editor, context, eOpts) {
                                    var mainWin = context.grid.up('window');
                                    mainWin.param.editRowIdx = context.rowIdx;
                                    mainWin.param.editColIdx = context.colIdx;
                                }
                            }
                        },
                        remoteSort: true,
                        padding: 5,
                        autoScroll: true,
                        columns: [
                            // {
                            //     xtype: 'actioncolumn',
                            //     dataIndex: 'MY_ORDER_DETAIL_UUID',
                            //     align: 'center',
                            //     width: 60,
                            //     items: [{
                            //         tooltip: '*編輯',
                            //         icon: SYSTEM_URL_ROOT + '/css/custImages/edit.gif',
                            //         handler: function(grid, rowIndex, colIndex) {
                            //             var mainWin = grid.up('window'),
                            //                 myOrderUuid = grid.getStore().getAt(rowIndex).data.MY_ORDER_UUID,
                            //                 myOrderDetailUuid = grid.getStore().getAt(rowIndex).data.MY_ORDER_DETAIL_UUID;
                            //             if (grid.getStore().getAt(rowIndex).data.SUPPLIER_GOODS_UUID != "") {
                            //                 var subWin = Ext.create('WS.MyOrderDetailWindow', {
                            //                     param: {
                            //                         parentObj: mainWin,
                            //                         supplierUuid: grid.getStore().getAt(rowIndex).data.SUPPLIER_UUID,
                            //                         myOrderUuid: myOrderUuid,
                            //                         myOrderDetailUuid: grid.getStore().getAt(rowIndex).data.MY_ORDER_DETAIL_UUID
                            //                     }
                            //                 });
                            //                 subWin.on('closeEvent', function() {
                            //                     mainWin.myStore.vMyOrderDetail.reload();
                            //                 });
                            //                 subWin.show();
                            //             } else {
                            //                 var subWin = Ext.create('WS.MyOrderDetailCustomizedWindow', {
                            //                     param: {
                            //                         parentObj: mainWin,
                            //                         myOrderUuid: myOrderUuid,
                            //                         myOrderDetailUuid: grid.getStore().getAt(rowIndex).data.MY_ORDER_DETAIL_UUID
                            //                     }
                            //                 });
                            //                 subWin.on('closeEvent', function() {
                            //                     mainWin.myStore.vMyOrderDetail.reload();
                            //                 });
                            //                 subWin.show();
                            //             }
                            //         }
                            //     }, {
                            //         tooltip: '*刪除',
                            //         icon: SYSTEM_URL_ROOT + '/css/images/delete16x16.png',
                            //         handler: function(grid, rowIndex, colIndex) {
                            //             var mainWin = grid.up('window');
                            //             var store = mainWin.down('#grdVMyOrderDetail').getStore();
                            //             var find = store.findRecord("MY_ORDER_DETAIL_UUID", grid.getStore().getAt(rowIndex).data.MY_ORDER_DETAIL_UUID);
                            //             WS.MyOrderAction.destoryMyOrderDetail(grid.getStore().getAt(rowIndex).data.MY_ORDER_DETAIL_UUID, function(obj, jsonObj) {
                            //                 if (jsonObj.result.success) {
                            //                     var store = mainWin.down('#grdVMyOrderDetail').getStore(),
                            //                         count = store.getCount();
                            //                     store.remove(find);
                            //                 };
                            //             }, mainWin);
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
                                    '{[this.fnInit()]}<input type="button" style="width:50px" value="編輯" onclick="MyOrderWindowFnEdit(\'{MY_ORDER_UUID}\',\'{MY_ORDER_DETAIL_UUID}\',\'{SUPPLIER_GOODS_UUID}\',\'{SUPPLIER_UUID}\')"/>',
                                    "</tpl>", {
                                        scope: this,
                                        fnInit: function() {
                                            document.MyOrderWindow = this.scope;
                                            if (!document.MyOrderWindowFnEdit) {
                                                document.MyOrderWindowFnEdit = function(MY_ORDER_UUID, MY_ORDER_DETAIL_UUID, SUPPLIER_GOODS_UUID, SUPPLIER_UUID) {
                                                    var mainWin = document.MyOrderWindow,
                                                        myOrderUuid = MY_ORDER_UUID,
                                                        myOrderDetailUuid = MY_ORDER_DETAIL_UUID;
                                                    if (SUPPLIER_GOODS_UUID != "") {
                                                        var subWin = Ext.create('WS.MyOrderDetailWindow', {
                                                            param: {
                                                                parentObj: mainWin,
                                                                supplierUuid: SUPPLIER_UUID,
                                                                myOrderUuid: myOrderUuid,
                                                                myOrderDetailUuid: MY_ORDER_DETAIL_UUID
                                                            }
                                                        });
                                                        subWin.on('closeEvent', function() {
                                                            document.MyOrderWindow.myStore.vMyOrderDetail.reload();
                                                        });
                                                        subWin.show();
                                                    } else {
                                                        var subWin = Ext.create('WS.MyOrderDetailCustomizedWindow', {
                                                            param: {
                                                                parentObj: mainWin,
                                                                myOrderUuid: myOrderUuid,
                                                                myOrderDetailUuid: MY_ORDER_DETAIL_UUID
                                                            }
                                                        });
                                                        subWin.on('closeEvent', function() {
                                                            document.MyOrderWindow.myStore.vMyOrderDetail.reload();
                                                        });
                                                        subWin.show();
                                                    }
                                                }
                                            }
                                        }
                                    })
                            }, {
                                xtype: 'templatecolumn',
                                text: '刪除',
                                width: 60,
                                sortable: false,
                                hideable: false,
                                tpl: new Ext.XTemplate(
                                    "<tpl >",
                                    '{[this.fnInit()]}<input type="button" style="width:50px" value="刪除" onclick="MyOrderWindowFnDelete(\'{MY_ORDER_DETAIL_UUID}\')"/>',
                                    "</tpl>", {
                                        scope: this,
                                        fnInit: function() {
                                            document.MyOrderWindow = this.scope;
                                            if (!document.MyOrderWindowFnDelete) {
                                                document.MyOrderWindowFnDelete = function(MY_ORDER_DETAIL_UUID) {
                                                    var mainWin = document.MyOrderWindow;
                                                    var store = mainWin.down('#grdVMyOrderDetail').getStore();
                                                    var find = store.findRecord("MY_ORDER_DETAIL_UUID", MY_ORDER_DETAIL_UUID);
                                                    WS.MyOrderAction.destoryMyOrderDetail(MY_ORDER_DETAIL_UUID, function(obj, jsonObj) {
                                                        if (jsonObj.result.success) {
                                                            var store = mainWin.down('#grdVMyOrderDetail').getStore(),
                                                                count = store.getCount();
                                                            store.remove(find);
                                                        };
                                                    }, mainWin);
                                                }
                                            }
                                        }
                                    })
                            }, {
                                xtype: 'templatecolumn',
                                text: "商品名稱",
                                dataIndex: 'MY_ORDER_DETAIL_GOODS_NAME',
                                align: 'center',
                                width: 250,
                                tpl: new Ext.XTemplate(
                                    "<tpl if='SUPPLIER_GOODS_UUID == \"\" '>",
                                    '<input type="text" readonly  style="width:220px" value="{MY_ORDER_DETAIL_GOODS_NAME}"/>',
                                    "<tpl else>",
                                    '{MY_ORDER_DETAIL_GOODS_NAME}',
                                    "</tpl>"),
                                editor: {
                                    xtype: 'textfield',
                                    enableKeyEvents: true,
                                    listeners: {
                                        change: function(obj, newValue, oldValue, eOpts) {
                                            var mainWin = obj.up('window');
                                            if (mainWin.param.editRecord.data.SUPPLIER_GOODS_UUID != '') {
                                                MY_ORDER_DETAIL_GOODS_NAME = oldValue;
                                                return;
                                            } else {
                                                mainWin.param.editRecord.data.MY_ORDER_DETAIL_GOODS_NAME = newValue;
                                                mainWin.param.modified = true;
                                            }
                                            mainWin.param.editRecord.commit();
                                        },
                                        focus: function(obj, eOpts) {
                                            var mainWin = obj.up('window');
                                            if (mainWin.param.editRecord.data.SUPPLIER_GOODS_UUID != '') {
                                                obj.setReadOnly(true);
                                            } else {
                                                obj.setReadOnly(false);
                                            }
                                        }
                                    }
                                }
                            }, {
                                text: "單價",
                                dataIndex: 'MY_ORDER_DETAIL_PRICE',
                                align: 'center',
                                width: 100,
                                xtype: 'templatecolumn',
                                align: 'right',
                                tpl: new Ext.XTemplate(
                                    '<input type="text" readonly  style="width:80px" value="{MY_ORDER_DETAIL_PRICE}"/>'
                                ),
                                editor: {
                                    xtype: 'numberfield',
                                    listeners: {
                                        change: function(obj, newValue, oldValue, eOpts) {
                                            var mainWin = obj.up('window');
                                            mainWin.param.editRecord.data.MY_ORDER_DETAIL_TOTAL_PRICE = newValue * mainWin.param.editRecord.data.MY_ORDER_DETAIL_GOODS_COUNT;
                                            mainWin.param.modified = true;
                                            mainWin.param.editRecord.commit();
                                        }
                                    }
                                }
                            }, {
                                text: "數量",
                                dataIndex: 'MY_ORDER_DETAIL_GOODS_COUNT',
                                align: 'center',
                                width: 100,
                                xtype: 'templatecolumn',
                                align: 'right',
                                tpl: new Ext.XTemplate(
                                    '<input type="text" readonly style="width:80px" value="{MY_ORDER_DETAIL_GOODS_COUNT}"/>'
                                ),
                                editor: {
                                    xtype: 'numberfield',
                                    listeners: {
                                        change: function(obj, newValue, oldValue, eOpts) {
                                            var mainWin = obj.up('window');
                                            mainWin.param.editRecord.data.MY_ORDER_DETAIL_TOTAL_PRICE = newValue * mainWin.param.editRecord.data.MY_ORDER_DETAIL_PRICE;
                                            mainWin.param.modified = true;
                                            mainWin.param.editRecord.commit();
                                        }
                                    }
                                }
                            }, {
                                text: "單位",
                                dataIndex: 'UNIT_UUID',
                                align: 'center',
                                width: 100,
                                xtype: 'templatecolumn',
                                align: 'center',
                                tpl: new Ext.XTemplate(
                                    '<input type="text" readonly style="width:80px" value="{MY_ORDER_DETAIL_UNIT_NAME}"/>'
                                ),
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
                                            if (!Ext.isEmpty(newValue)) {
                                                var dr = obj.getStore().findRecord("UNIT_UUID", newValue).data;
                                                mainWin.param.modified = true;
                                                mainWin.param.editRecord.data.MY_ORDER_DETAIL_UNIT_NAME = dr.UNIT_NAME;
                                            };
                                        }
                                    }
                                }
                            }, {
                                text: "小計",
                                dataIndex: 'MY_ORDER_DETAIL_TOTAL_PRICE',
                                align: 'center',
                                fles: 1
                            }
                        ],
                        tbar: [{
                                type: 'button',
                                text: '新增商品',
                                icon: SYSTEM_URL_ROOT + '/css/images/addC16x16.png',
                                handler: function() {
                                    var mainWin = this.up('window'),
                                        myOrderUuid = mainWin.down('#MY_ORDER_UUID').getValue(),
                                        supplierUuid = mainWin.down('#cmbSupplierUuid').getValue();

                                    var updateData = "";
                                    if (mainWin.param.modified && mainWin.param.modified == true) {
                                        Ext.each(mainWin.myStore.vMyOrderDetail.data.items, function(item) {
                                            updateData += item.data.MY_ORDER_DETAIL_UUID + "`" + item.data.MY_ORDER_DETAIL_GOODS_NAME + "`" + item.data.MY_ORDER_DETAIL_PRICE + "`" + item.data.MY_ORDER_DETAIL_GOODS_COUNT + "`" + item.data.UNIT_UUID + "|";
                                        });
                                        WS.MyOrderAction.batchUpdateMyOrderDetail(updateData, function(obj, jsonObj) {});
                                    }

                                    if (myOrderUuid && myOrderUuid != "") {
                                        var mainWin = this.up('window');
                                        var subWin = Ext.create('WS.MyOrderDetailWindow', {
                                            param: {
                                                supplierUuid: supplierUuid,
                                                parentObj: mainWin,
                                                myOrderUuid: myOrderUuid,
                                                myOrderDetailUuid: ""
                                            }
                                        });
                                        subWin.on('closeEvent', function() {
                                            mainWin.myStore.vMyOrderDetail.reload();
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
                            }
                            // , {
                            //     type: 'button',
                            //     text: '新增自訂商品',
                            //     icon: SYSTEM_URL_ROOT + '/css/images/addD16x16.png',
                            //     handler: function() {
                            //         var mainWin = this.up('window'),
                            //             myOrderUuid = mainWin.down('#MY_ORDER_UUID').getValue(),
                            //             supplierUuid = "";
                            //         if (myOrderUuid && myOrderUuid != "") {
                            //             var mainWin = this.up('window');
                            //             var subWin = Ext.create('WS.MyOrderDetailCustomizedWindow', {
                            //                 param: {
                            //                     supplierUuid: supplierUuid,
                            //                     parentObj: mainWin,
                            //                     myOrderUuid: myOrderUuid,
                            //                     myOrderDetailUuid: ""
                            //                 }
                            //             });
                            //             subWin.on('closeEvent', function() {
                            //                 mainWin.myStore.vMyOrderDetail.reload();
                            //             });
                            //             subWin.show();
                            //         } else {
                            //             Ext.MessageBox.show({
                            //                 title: '操作通知',
                            //                 icon: Ext.MessageBox.INFO,
                            //                 buttons: Ext.Msg.OK,
                            //                 msg: '請先執行儲存操作，才可新增子項商品內容。'
                            //             });
                            //         }
                            //     }
                            // }
                            , {
                                xtype: 'button',
                                text: '新增自訂商品',
                                icon: SYSTEM_URL_ROOT + '/css/images/addD16x16.png',
                                handler: function() {
                                        var mainWin = this.up('window');
                                        var updateData = "";
                                        if (mainWin.param.modified && mainWin.param.modified == true) {
                                            Ext.each(mainWin.myStore.vMyOrderDetail.data.items, function(item) {
                                                updateData += item.data.MY_ORDER_DETAIL_UUID + "`" + item.data.MY_ORDER_DETAIL_GOODS_NAME + "`" + item.data.MY_ORDER_DETAIL_PRICE + "`" + item.data.MY_ORDER_DETAIL_GOODS_COUNT + "`" + item.data.UNIT_UUID + "|";
                                            });
                                            WS.MyOrderAction.batchUpdateMyOrderDetail(updateData, function(obj, jsonObj) {});
                                        }
                                        mainWin.fnCreateMyOrderDetailCustomize(1);
                                    }
                                    // menu: [{
                                    //     text: '1項',
                                    //     handler: function() {
                                    //         var mainWin = this.up('window');
                                    //         mainWin.fnCreateMyOrderDetailCustomize(1);
                                    //     }
                                    // }, {
                                    //     text: '2項',
                                    //     handler: function() {
                                    //         var mainWin = this.up('window');
                                    //         mainWin.fnCreateMyOrderDetailCustomize(2);
                                    //     }
                                    // }, {
                                    //     text: '3項',
                                    //     handler: function() {
                                    //         var mainWin = this.up('window');
                                    //         mainWin.fnCreateMyOrderDetailCustomize(3);
                                    //     }
                                    // }, {
                                    //     text: '4項',
                                    //     handler: function() {
                                    //         var mainWin = this.up('window');
                                    //         mainWin.fnCreateMyOrderDetailCustomize(4);
                                    //     }
                                    // }, {
                                    //     text: '5項',
                                    //     handler: function() {
                                    //         var mainWin = this.up('window');
                                    //         mainWin.fnCreateMyOrderDetailCustomize(5);
                                    //     }
                                    // }, {
                                    //     text: '6項',
                                    //     handler: function() {
                                    //         var mainWin = this.up('window');
                                    //         mainWin.fnCreateMyOrderDetailCustomize(6);
                                    //     }
                                    // }, {
                                    //     text: '7項',
                                    //     handler: function() {
                                    //         var mainWin = this.up('window');
                                    //         mainWin.fnCreateMyOrderDetailCustomize(7);
                                    //     }
                                    // }, {
                                    //     text: '8項',
                                    //     handler: function() {
                                    //         var mainWin = this.up('window');
                                    //         mainWin.fnCreateMyOrderDetailCustomize(8);
                                    //     }
                                    // }, {
                                    //     text: '9項',
                                    //     handler: function() {
                                    //         var mainWin = this.up('window');
                                    //         mainWin.fnCreateMyOrderDetailCustomize(9);
                                    //     }
                                    // }, {
                                    //     text: '10項',
                                    //     handler: function() {
                                    //         var mainWin = this.up('window');
                                    //         mainWin.fnCreateMyOrderDetailCustomize(10);
                                    //     }
                                    // }, {
                                    //     text: '20項',
                                    //     handler: function() {
                                    //         var mainWin = this.up('window');
                                    //         mainWin.fnCreateMyOrderDetailCustomize(20);
                                    //     }
                                    // }, {
                                    //     text: '30項',
                                    //     handler: function() {
                                    //         var mainWin = this.up('window');
                                    //         mainWin.fnCreateMyOrderDetailCustomize(30);
                                    //     }
                                    // }]
                            }
                        ],
                        minHeight: 330,
                        autoHeight: true,
                        overflowY: 'auto'
                    }]
                }]
            }, {
                xtype: 'hiddenfield',
                fieldLabel: 'MY_ORDER_UUID',
                name: 'MY_ORDER_UUID',
                anchor: '100%',
                maxLength: 84,
                itemId: 'MY_ORDER_UUID'
            }, {
                xtype: 'hiddenfield',
                name: 'MY_ORDER_IS_ACTIVE',
                itemId: 'MY_ORDER_IS_ACTIVE'
            }],
            fbar: [{
                type: 'button',
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存',
                handler: function() {
                    var mw = this.up('window');
                    var form = this.up('window').down("#MyOrderForm").getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    var updateData = "";
                    Ext.each(mw.myStore.vMyOrderDetail.data.items, function(item) {
                        updateData += item.data.MY_ORDER_DETAIL_UUID + "`" + item.data.MY_ORDER_DETAIL_GOODS_NAME + "`" + item.data.MY_ORDER_DETAIL_PRICE + "`" + item.data.MY_ORDER_DETAIL_GOODS_COUNT + "`" + item.data.UNIT_UUID + "|";
                    });
                    WS.MyOrderAction.batchUpdateMyOrderDetail(updateData, function(obj, jsonObj) {});
                    mw.down('#MY_ORDER_IS_ACTIVE').setValue(1);
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
                text: '儲存離開',
                handler: function() {
                    var mw = this.up('window');
                    var form = this.up('window').down("#MyOrderForm").getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    var updateData = "";
                    Ext.each(mw.myStore.vMyOrderDetail.data.items, function(item) {
                        updateData += item.data.MY_ORDER_DETAIL_UUID + "`" + item.data.MY_ORDER_DETAIL_GOODS_NAME + "`" + item.data.MY_ORDER_DETAIL_PRICE + "`" + item.data.MY_ORDER_DETAIL_GOODS_COUNT + "`" + item.data.UNIT_UUID + "|";
                    });
                    WS.MyOrderAction.batchUpdateMyOrderDetail(updateData, function(obj, jsonObj) {});
                    mw.down('#MY_ORDER_IS_ACTIVE').setValue(1);
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
                    Ext.MessageBox.confirm('刪除訂貨操作', '確定要刪除這一個訂貨資訊?', function(result) {
                        if (result == 'yes') {
                            var myOrderUuid = mainWin.param.myOrderUuid;
                            WS.MyOrderAction.destoryMyOrder(myOrderUuid, function(obj, jsonObj) {
                                if (jsonObj.result.success) {
                                    this.close();
                                } else {
                                    Ext.MessageBox.show({
                                        title: '刪除訂貨操作(1504171344)',
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
            this.mask('資訊載入中…請稍後…');
            this.myStore.supplier.load();

            //     if(this.param.myOrderUuid){
            //     this.myStore.vMyOrderDetail.getProxy().setExtraParam('pMyOrderUuid', this.param.myOrderUuid);
            // };
            if (this.param.myOrderUuid != undefined) {
                this.down("#MyOrderForm").getForm().load({
                    params: {
                        'pMyOrderUuid': this.param.myOrderUuid
                    },
                    success: function(response, a, b) {
                        if (a.result.data.MY_ORDER_CR != '' && a.result.data.MY_ORDER_CR != undefined) {
                            this.down("#MY_ORDER_CR").setValue(new Date(a.result.data.MY_ORDER_CR));
                        } else {
                            this.down("#MY_ORDER_CR").setValue(new Date());
                        };
                        this.myStore.vMyOrderDetail.getProxy().setExtraParam('pMyOrderUuid', a.result.data.MY_ORDER_UUID);

                        this.myStore.vMyOrderDetail.load();
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
            } else {
                this.down("#MyOrderForm").getForm().load({
                    params: {
                        'pMyOrderUuid': ""
                    },
                    success: function(response, a, b) {
                        this.param.myOrderUuid = a.result.data.MY_ORDER_UUID;
                        this.myStore.vMyOrderDetail.getProxy().setExtraParam('pMyOrderUuid', a.result.data.MY_ORDER_UUID);
                        this.myStore.vMyOrderDetail.load();

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
            };
        },
        'close': function() {
            this.closeEvent();
            this.myStore.vMyOrderDetail.removeAll();
            this.myStore.supplier.removeAll();
            this.myStore.unit.removeAll();
            this.down('form').reset();

        }
    }
});
