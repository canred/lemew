Ext.define('WS.CustOrderDetailWindow', {
    extend: 'Ext.window.Window',
    title: '訂單-商品',
    icon: SYSTEM_URL_ROOT + '/css/custimages/gift16x16.png',
    closeAction: 'destroy',
    autoScroll: true, modal: true,
    width: 800,
    height: 600,
    fnLoadFile: function() {
        alert('file');
    },
    fnCal: function() {
        var mainWin = this.up('window'),
            count = mainWin.down('#CUST_ORDER_DETAIL_COUNT').getValue();
        price = mainWin.down('#CUST_ORDER_DETAIL_PRICE').getValue();
        if (Ext.isNumber(count) && Ext.isNumber(price)) {
            mainWin.down('#CUST_ORDER_DETAIL_TOTAL_PRICE').setValue(count * price);
        };
    },
    param: {
        custOrderUuid: undefined,
        custOrderDetailUuid: undefined
    },
    myStore: {
        vFilegroup: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: 'V_FILEGROUP',
            pageSize: 5,
            remoteSort: true,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.FileAction.loadVFilegroup
                },
                reader: {
                    root: 'data'
                },
                writer: {
                    type: 'json',
                    writeAllFields: true,
                    root: 'updatedata'
                },
                paramsAsHash: true,
                paramOrder: ['pFilegroupUuid', 'pKeyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    'pFilegroupUuid': '',
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
                property: 'FILE_CR',
                direction: 'ASC'
            }]
        })
    },
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
        this.myStore.vgoods = Ext.create('Ext.data.Store', {
                successProperty: 'success',
                autoLoad: false,
                model: 'V_GOODS',
                pageSize: 10,
                proxy: {
                    type: 'direct',
                    api: {
                        read: WS.GoodsAction.loadVGoods
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
                listeners: {                   
                    scope: this
                },
                sorters: [{
                    property: 'GOODS_NAME',
                    direction: 'ASC'
                }]
            }),

            this.myStore.unit = Ext.create('Ext.data.Store', {
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
                listeners: {
                    load: function(self, records, successful, eOpts) {
                        if (records.length >= 1) {
                            this.down('#CUST_ORDER_DETAIL_UNIT').setValue(records[0].data.UNIT_UUID);
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
                        var store = this.up('panel').down("#grdVGoodsQuery").getStore(),
                            doSomeghing = function(obj, pl) {
                                obj.getProxy().setExtraParam('pKeyword', pl.down("#txt_search").getValue());
                                obj.loadPage(1);
                            }(store, this.up('panel'));
                    }
                }]
            }, {
                xtype: 'gridpanel',
                store: this.myStore.vgoods,
                itemId: 'grdVGoodsQuery',
                border: true,
                height: 500,
                padding: '5 15 5 5',
                selModel: new Ext.selection.CheckboxModel({
                    mode: 'SINGLE',
                    checkOnly: true,
                    listeners: {
                        selectionchange: function(selectionModel, selected, options) {
                            if (selected[0]) {
                                var mainWin = this;
                                mainWin.down('#CUST_ORDER_DETAIL_GOODS_NAME').setValue(selected[0].data.GOODS_NAME);
                                mainWin.down('#CUST_ORDER_DETAIL_PRICE').setValue(selected[0].data.GOODS_PRICE);
                                mainWin.down('#GOODS_UUID').setValue(selected[0].data.GOODS_UUID);
                                mainWin.down('#pnlGoods').collapse();
                                mainWin.down('#frmCustOrderDetail').show();
                            }
                        },
                        scope: this
                    }
                }),
                columns: [{
                    header: "名稱",
                    dataIndex: 'GOODS_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    header: '類別',
                    dataIndex: 'GCATEGORY_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    header: '類別(全)',
                    dataIndex: 'GCATEGORY_FULL_NAME',
                    align: 'left',
                    hidden: true,
                    flex: 1
                }, {
                    header: '商品(備註)',
                    dataIndex: 'GOODS_PS',
                    align: 'left',
                    flex: 1
                }, {
                    header: "序號",
                    align: 'left',
                    dataIndex: 'GOODS_SN',
                    flex: 1
                }, {
                    header: "售價",
                    dataIndex: 'GOODS_SALE',
                    align: 'right',
                    hidden: true,
                    flex: 1
                }, {
                    header: '原價',
                    dataIndex: 'GOODS_PRICE',
                    align: 'right',
                    hidden: true,
                    flex: 1
                }, {
                    header: '成本',
                    dataIndex: 'GOODS_COST',
                    align: 'right',
                    hidden: true,
                    flex: 1
                }, {
                    header: '有效',
                    dataIndex: 'GOODS_IS_ACTIVE',
                    align: 'center',
                    flex: 1,
                    renderer: this.fnActiveRender
                }, {
                    header: '供應商',
                    dataIndex: 'SUPPLIER_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    header: '供應商備註',
                    dataIndex: 'SUPPLIER_PS',
                    align: 'left',
                    hidden: true,
                    flex: 1
                }],
                tbarCfg: {
                    buttonAlign: 'right'
                },
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.vgoods,
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
                load: WS.CustAction.infoCustOrderDetail,
                submit: WS.CustAction.submitCustOrderDetail
            },
            hidden: true,
            itemId: 'frmCustOrderDetail',
            paramOrder: ['pCustOrderDetailUuid'],
            items: [{
                xtype: 'container',
                layout: 'hbox',
                defaults: {
                    labelAlign: 'right'
                },
                items: [{
                    xtype: 'textfield',
                    fieldLabel: '商品名稱',
                    name: 'CUST_ORDER_DETAIL_GOODS_NAME',
                    itemId: 'CUST_ORDER_DETAIL_GOODS_NAME',
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
                    name: 'CUST_ORDER_DETAIL_COUNT',
                    itemId: 'CUST_ORDER_DETAIL_COUNT',
                    allowBlank: false,
                    minValue: 1,
                    listeners: {
                        change: this.fnCal
                    }
                }, {
                    xtype: 'combo',
                    fieldLabel: '單位',
                    allowBlank: false,
                    itemId: 'CUST_ORDER_DETAIL_UNIT',
                    displayField: 'UNIT_NAME',
                    valueField: 'UNIT_UUID',
                    name: 'CUST_ORDER_DETAIL_UNIT',
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
                    name: 'CUST_ORDER_DETAIL_PRICE',
                    itemId: 'CUST_ORDER_DETAIL_PRICE',
                    minValue: 1,
                    allowBlank: false,
                    listeners: {
                        change: this.fnCal
                    }
                }, {
                    xtype: 'textfield',
                    fieldLabel: '總價',
                    name: 'CUST_ORDER_DETAIL_TOTAL_PRICE',
                    itemId: 'CUST_ORDER_DETAIL_TOTAL_PRICE',
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
                    name: 'CUST_ORDER_DETAIL_PS',
                    itemId: 'CUST_ORDER_DETAIL_PS',
                    flex: 1
                }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                padding: '5 0 0 0',
                defaults: {
                    labelAlign: 'right'
                },
                flex: 1,
                items: [{
                    xtype: 'fileuploadfield',
                    name: 'file',
                    fieldLabel: '附件',
                    flex: 1,
                    listeners: {
                        change: function() {
                            var mainWin = this.up('window'),
                                frmCustOrderDetail = mainWin.down('#frmCustOrderDetail');
                            //submit: WS.CustAction.submitCustOrderDetail
                            frmCustOrderDetail.api.submit = WS.CustAction.submitCustOrderDetailForFile;
                            mainWin.down('#CUST_ORDER_DETAIL_UNIT').allowBlank = true;
                            mainWin.down('#CUST_ORDER_DETAIL_COUNT').allowBlank = true;
                            mainWin.down('#CUST_ORDER_DETAIL_TOTAL_PRICE').allowBlank = true;

                            frmCustOrderDetail.submit({
                                waitMsg: '上傳檔案中...',
                                success: function(form, action) {
                                    this.down('#frmCustOrderDetail').api.submit = WS.CustAction.submitCustOrderDetail;
                                    this.down('#CUST_ORDER_DETAIL_UNIT').allowBlank = false;
                                    this.down('#CUST_ORDER_DETAIL_COUNT').allowBlank = false;
                                    this.down('#CUST_ORDER_DETAIL_TOTAL_PRICE').allowBlank = false;
                                    if (action.result.FILEGROUP_UUID) {
                                        this.myStore.vFilegroup.getProxy().setExtraParam('pFilegroupUuid', action.result.FILEGROUP_UUID);
                                        this.myStore.vFilegroup.reload();
                                    };
                                },
                                failure: function(form, action) {
                                    Ext.MessageBox.show({
                                        title: 'System Error',
                                        msg: '上傳檔案失敗…',
                                        icon: Ext.MessageBox.ERROR,
                                        buttons: Ext.Msg.OK
                                    });
                                },
                                scope: mainWin
                            });
                        }
                    }
                }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                padding: '5 0 0 0',
                flex: 1,
                height: 330,
                defaults: {
                    labelAlign: 'right'
                },
                items: [{
                    xtype: 'gridpanel',
                    itemId: 'grdFile',
                    store: this.myStore.vFilegroup,
                    paramsAsHash: false,
                    margin: '5 0 0 105',
                    flex: 1,
                    height: 330,
                    border: true,
                    autoScroll: true,
                    columns: [{
                        text: "",
                        xtype: 'actioncolumn',
                        dataIndex: 'UUID',
                        align: 'center',
                        width: 60,
                        items: [{
                            tooltip: '*編輯備註',
                            icon: SYSTEM_URL_ROOT + '/css/custimages/edit.gif',
                            handler: function(grid, rowIndex, colIndex) {
                                var mainWin = grid.up('window');
                                var subWin = Ext.create('WS.FileWindow', {
                                    param: {
                                        fileUuid: grid.getStore().getAt(rowIndex).data.FILE_UUID,
                                        parentObj: mainWin
                                    }
                                });
                                subWin.on('closeEvent', function() {
                                    var store = mainWin.down('#grdFile').getStore();
                                    store.reload();
                                });
                                subWin.show();
                            }
                        }, {
                            tooltip: '*刪除',
                            icon: SYSTEM_URL_ROOT + '/css/custimages/delete.gif',
                            handler: function(grid, rowIndex, colIndex) {
                                var mainWin = grid.up('window');
                                Ext.MessageBox.confirm('刪除操作', '確定要刪除這一個檔案?', function(result) {
                                    if (result == 'yes') {
                                        WS.FileAction.destoryFile(grid.getStore().getAt(rowIndex).data.FILE_UUID, function(obj, jsonObj) {
                                            if (jsonObj.result.success) {
                                                var store = mainWin.down('#grdFile').getStore(),
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
                        text: "名稱",
                        dataIndex: 'FILE_NAME',
                        align: 'left',
                        renderer: function(value, r) {
                            var html = '<a target="_BLANK" href="';

                            html += SYSTEM_URL_ROOT + (r.record.data['FILE_PATH'].replace('~', ''));
                            html += '">' + value + '</a>'
                            return html;
                        },
                        flex: 1
                    }, {
                        text: "備註",
                        dataIndex: 'FILE_PS',
                        align: 'left',
                        flex: 2
                    }, {
                        text: "建立時間",
                        dataIndex: 'FILE_CR',
                        align: 'left',
                        width: 140
                    }],
                   
                    bbar: Ext.create('Ext.toolbar.Paging', {
                        store: this.myStore.vFilegroup,
                        displayInfo: true,
                        displayMsg: '第{0}~{1}資料/共{2}筆',
                        emptyMsg: "無資料顯示"
                    })
                }]
            }, {
                xtype: 'container',
                layout: 'vbox',
                items: [{
                    xtype: 'hiddenfield',
                    itemId: 'GOODS_UUID',
                    name: 'GOODS_UUID'
                }, {
                    xtype: 'hiddenfield',
                    fieldLabel: 'CUST_ORDER_UUID',
                    name: 'CUST_ORDER_UUID',
                    itemId: 'CUST_ORDER_UUID'
                }, {
                    xtype: 'hiddenfield',
                    fieldLabel: 'CUST_ORDER_DETAIL_UUID',
                    name: 'CUST_ORDER_DETAIL_UUID',
                    itemId: 'CUST_ORDER_DETAIL_UUID'
                }, {
                    xtype: 'hiddenfield',
                    fieldLabel: 'IS_ACTIVE',
                    name: 'CUST_ORDER_DETAIL_IS_ACTIVE',
                    itemId: 'CUST_ORDER_DETAIL_IS_ACTIVE',
                    value: "1"
                }, {
                    xtype: 'hiddenfield',
                    name: 'FILEGROUP_UUID',
                    itemId: 'FILEGROUP_UUID'
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
                        form = this.up('window').down("#frmCustOrderDetail").getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    mainWin.down('#CUST_ORDER_DETAIL_IS_ACTIVE').setValue('1');
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            this.param.custOrderDetailUuid = action.result.CUST_ORDER_DETAIL_UUID;
                            this.down("#CUST_ORDER_DETAIL_UUID").setValue(action.result.CUST_ORDER_DETAIL_UUID);
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
                xtype: 'button',
                icon: SYSTEM_URL_ROOT + '/css/images/delete16x16.png',
                text: '刪除',
                itemId: 'btnDelete',
                handler: function() {
                    var mainWin = this.up('window');
                    Ext.MessageBox.confirm('刪除操作', '確定要刪除這一個訂單明細?', function(result) {
                        if (result == 'yes') {
                            WS.CustAction.destoryCustOrderDetail(this.param.custOrderDetailUuid, function(obj, jsonObj) {
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
            this.down('#btnQuery').handler();
            if (this.param.custOrderUuid) {
                this.down("#CUST_ORDER_UUID").setValue(this.param.custOrderUuid);
            };


            this.myStore.unit.load({
                callback: function() {
                    var mainObj = this;

                    //if (mainObj.param.custOrderDetailUuid != undefined) {
                    mainObj.down("#frmCustOrderDetail").getForm().load({
                        params: {
                            'pCustOrderDetailUuid': mainObj.param.custOrderDetailUuid == undefined ? "" : mainObj.param.custOrderDetailUuid
                        },
                        success: function(response, a, b) {
                            this.down("#CUST_ORDER_UUID").setValue(this.param.custOrderUuid);

                            if (this.down("#CUST_ORDER_DETAIL_UNIT").getValue() == "") {
                                this.down("#CUST_ORDER_DETAIL_UNIT").setValue(this.myStore.unit.getAt(0).data.UNIT_UUID);
                            };

                            if (this.down("#FILEGROUP_UUID").getValue() != "") {
                                this.myStore.vFilegroup.getProxy().setExtraParam("pFilegroupUuid", this.down("#FILEGROUP_UUID").getValue());
                                this.myStore.vFilegroup.reload();
                            };

                            if (this.down("#CUST_ORDER_DETAIL_IS_ACTIVE").getValue() == 0) {
                                this.down('#btnDelete').setDisabled(true);

                            } else {
                                this.down('#btnDelete').setDisabled(false);
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

                    if (mainObj.param.custOrderDetailUuid) {
                        mainObj.down('#pnlGoods').collapse();
                        mainObj.down('#frmCustOrderDetail').show();
                    };

                    //}

                },
                scope: this
            });


        },
        'afterrender': function() {
            /*畫面開啟後載入資料*/
        },
        'close': function() {            
            this.myStore.vFilegroup.removeAll();
            this.closeEvent();
        }
    }
});
