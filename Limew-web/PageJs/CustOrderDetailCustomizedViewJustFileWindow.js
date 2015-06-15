Ext.define('WS.CustOrderDetailCustomizedViewJustFileWindow', {
    extend: 'Ext.window.Window',
    title: '訂單-客製化商品檔案附件',
    icon: SYSTEM_URL_ROOT + '/css/custimages/gift16x16.png',
    closeAction: 'destroy',
    modal: true,
    autoScroll: true,
    width: 800,
    height: 450,    
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
            pageSize: 99999,
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
    draggable: true,
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
            xtype: 'form',
            padding: '5 15 5 5',
            width: 780,
            layout: 'form',
            api: {
                load: WS.CustAction.infoCustOrderDetail,
                submit: WS.CustAction.submitCustOrderDetail
            },

            itemId: 'frmCustOrderDetail',
            paramOrder: ['pCustOrderDetailUuid'],
            items: [{
                xtype: 'container',
                layout: 'hbox',hidden:true,
                defaults: {
                    labelAlign: 'right'
                },
                items: [{
                    xtype: 'textfield',
                    fieldLabel: '商品名稱',
                    name: 'CUST_ORDER_DETAIL_GOODS_NAME',
                    itemId: 'CUST_ORDER_DETAIL_GOODS_NAME',
                    allowBlank: true,
                    flex: 1
                }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                margin: '5 0 0 0',hidden:true,
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
                    fieldLabel: '單位',hidden:true,
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
                padding: '5 0 0 0',hidden:true,
                defaults: {
                    labelAlign: 'right'
                },
                items: [{
                    xtype: 'numberfield',
                    fieldLabel: '單價',
                    name: 'CUST_ORDER_DETAIL_PRICE',
                    itemId: 'CUST_ORDER_DETAIL_PRICE',
                    minValue: 0,
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
                layout: 'hbox',hidden:true,
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
                flex: 1,
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
                    border: true,
                    autoScroll: true,
                    columns: [{
                        xtype: 'templatecolumn',
                        text: '編輯備註',
                        width: 100,
                        sortable: false,
                        hideable: false,
                        tpl: new Ext.XTemplate(
                            "<tpl >",
                            '{[this.fnInit()]}<input type="button" style="width:80px" value="編輯備註" onclick="CustOrderDetailCustomizedWindowFnEditPs(\'{FILE_UUID}\')"/>',
                            "</tpl>", {
                                scope: this,
                                fnInit: function() {
                                    document.CustOrderDetailCustomizedWindow = this.scope;
                                    if (!document.CustOrderDetailCustomizedWindowFnEditPs) {
                                        document.CustOrderDetailCustomizedWindowFnEditPs = function(FILE_UUID) {
                                            var mainWin = this.scope;
                                            var subWin = Ext.create('WS.FileWindow', {
                                                param: {
                                                    fileUuid: FILE_UUID,
                                                    parentObj: mainWin
                                                }
                                            });
                                            subWin.on('closeEvent', function() {
                                                var store = document.CustOrderDetailCustomizedWindow.down('#grdFile').getStore();
                                                store.reload();
                                            });
                                            subWin.show();
                                        }
                                    }
                                }
                            })
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
                        width: 200
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
                    height: 310
                        // ,
                        // bbar: Ext.create('Ext.toolbar.Paging', {
                        //     store: this.myStore.vFilegroup,
                        //     displayInfo: true,
                        //     displayMsg: '第{0}~{1}資料/共{2}筆',
                        //     emptyMsg: "無資料顯示"
                        // })
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
                    itemId: 'SUPPLIER_GOODS_PRICE',
                    name: 'SUPPLIER_GOODS_PRICE'
                }, {
                    xtype: 'hiddenfield',
                    itemId: 'SUPPLIER_GOODS_UUID',
                    name: 'SUPPLIER_GOODS_UUID'
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
                }, {
                    xtype: 'hiddenfield',
                    value: '1',
                    name: 'cust_order_detail_customized'
                }]
            }],
            fbar: [{
                xtype: 'tbfill'
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
            this.mask("資訊載入中…請稍後…");
            if (this.param.custOrderUuid) {
                this.down("#CUST_ORDER_UUID").setValue(this.param.custOrderUuid);
            };

            this.myStore.unit.load({
                callback: function() {
                    var mainObj = this;
                    mainObj.down("#frmCustOrderDetail").getForm().load({
                        params: {
                            'pCustOrderDetailUuid': mainObj.param.custOrderDetailUuid == undefined ? "" : mainObj.param.custOrderDetailUuid
                        },
                        success: function(response, a, b) {
                            this.down("#CUST_ORDER_UUID").setValue(this.param.custOrderUuid);


                            if (this.down("#CUST_ORDER_DETAIL_UNIT").getValue() == "") {
                                this.down("#CUST_ORDER_DETAIL_UNIT").setValue(this.myStore.unit.getAt(0).data.UNIT_UUID);
                            };
                            //alert(this.down("#FILEGROUP_UUID").getValue());
                            if (this.down("#FILEGROUP_UUID").getValue() != "") {
                                this.myStore.vFilegroup.getProxy().setExtraParam("pFilegroupUuid", this.down("#FILEGROUP_UUID").getValue());
                                this.myStore.vFilegroup.reload();
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
                    if (mainObj.param.custOrderDetailUuid) {

                        mainObj.down('#frmCustOrderDetail').show();
                    };
                },
                scope: this
            });





        },
        'afterrender': function() {
            /*畫面開啟後載入資料*/
        },
        'close': function() {
            this.myStore.vFilegroup.removeAll();
            this.myStore.unit.removeAll();
            this.closeEvent();
            this.down('form').reset();
        }
    }
});