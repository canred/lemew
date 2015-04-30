/*全局變量*/
var WS_CUSTORDERSHIPPINGQUERYPANEL;
/*WS.SupplierQueryPanel物件類別*/
/*TODO*/
/*
1.Model 要集中                                 [YES]
2.panel 的title要換成icon , title的方式        [YES]
3.add 的icon要換成icon , title的方式           [YES]
4.自動Query 資料                               [YES]
*/
/*columns 使用default*/
Ext.define('WS.CustOrderShippingQueryPanel', {
    extend: 'Ext.panel.Panel',
    closeAction: 'destroy',
    subWinCustOrder: undefined,
    /*語言擴展*/
    lan: {},
    /*參數擴展*/
    param: {
        showADSync: true
    },
    /*值擴展*/
    val: {},
    /*物件會用到的Store物件*/
    myStore: {
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
            listeners: {
                load: function(store, records, sucessful, eOpts) {
                    store.insert(0, {
                        'CUST_UUID': '',
                        'CUST_NAME': '全部'
                    });
                }
            },
            sorters: [{
                property: 'CUST_NAME',
                direction: 'ASC'
            }]
        }),
        vcustorder: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: 'V_CUST_ORDER',
            pageSize: 10,
            remoteSort: true,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadVCustOrderShipping
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyword', 'pCustOrderType', 'pCompanyUuid', 'pCustUuid', 'pCustOrderStatusUuid', 'pShippingStatusUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pCustOrderType: '',
                    pCompanyUuid: '',
                    pCustUuid: '',
                    pCustOrderStatusUuid: '',
                    pShippingStatusUuid: 'SS_INPROCESS'
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
                property: 'CUST_ORDER_CR',
                direction: 'DESC'
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
            listeners: {
                load: function(store, records, sucessful, eOpts) {
                    store.insert(0, {
                        'UUID': '',
                        'C_NAME': '全部'
                    });
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'C_NAME',
                direction: 'ASC'
            }]
        }),
        custOrderStatus: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'CUST_ORDER_STATUS',
            pageSize: 9999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustOrderStatusAction.loadCustOrderStatus
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['keyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    keyword: ''
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        if (!response.result.success) {
                            Ext.MessageBox.show({
                                title: 'Warning',
                                icon: Ext.MessageBox.WARNING,
                                buttons: Ext.Msg.OK,
                                msg: response.result.message
                            });
                        }
                    }
                }
            },
            remoteSort: true,
            listeners: {
                load: function(store, records, sucessful, eOpts) {
                    store.insert(0, {
                        'CUST_ORDER_STATUS_UUID': '',
                        'CUST_ORDER_STATUS_NAME': '全部'
                    });
                }
            },
            sorters: [{
                property: 'CUST_ORDER_STATUS_ORD',
                direction: 'ASC'
            }]
        }),
        shippingStatus: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'SHIPPING_STATUS',
            pageSize: 9999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.ShippingStatusAction.loadShippingStatus
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['keyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    keyword: ''
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        if (!response.result.success) {
                            Ext.MessageBox.show({
                                title: 'Warning',
                                icon: Ext.MessageBox.WARNING,
                                buttons: Ext.Msg.OK,
                                msg: response.result.message
                            });
                        }
                    }
                }
            },
            listeners: {
                load: function(store, records, sucessful, eOpts) {
                    store.insert(0, {
                        'SHIPPING_STATUS_UUID': '',
                        'SHIPPING_STATUS_NAME': '全部'
                    });
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'SHIPPING_STATUS_ORD',
                direction: 'ASC'
            }]
        })
    },
    fnActiveRender: function isActiveRenderer(value, id, r) {
        var html = "<img src='" + SYSTEM_URL_ROOT;
        return value === "Y" ? html + "/css/custimages/active03.png'>" : html + "/css/custimages/unactive03.png'>";
    },
    fnCheckSubWindowns: function() {

        if (Ext.isEmpty(this.subWinCustOrder)) {
            Ext.MessageBox.show({
                title: '系統提示',
                icon: Ext.MessageBox.WARNING,
                buttons: Ext.Msg.OK,
                msg: '未實現 subWinCustOrder 物件,無法進行編輯操作!'
            });
            return false;
        };
        return true;
    },
    initComponent: function() {
        if (!this.fnCheckSubWindowns()) {
            return false;
        };
        this.items = [{
            xtype: 'panel',
            title: '出貨訂單查詢',
            icon: SYSTEM_URL_ROOT + '/css/custimages/order16x16.png',
            frame: true,
            border: false,
            height: $(document).height() - 130,
            autoWidth: true,
            padding: '5 0 5 5',
            items: [{
                xtype: 'container',
                layout: 'hbox',
                margin: '0 0 0 5',
                defaults: {
                    labelAlign: 'right'
                },
                items: [{
                    xtype: 'combo',
                    fieldLabel: '類型',
                    queryMode: 'local',
                    itemId: 'cmbCustOrderType',
                    displayField: 'text',
                    valueField: 'value',
                    labelWidth: 60,
                    width: 150,
                    editable: false,
                    hidden: false,
                    value: '',
                    store: new Ext.data.ArrayStore({
                        fields: ['text', 'value'],
                        data: [
                            ['全部', ''],
                            ['報價單', '0'],
                            ['訂單', '1']
                        ]
                    }),
                    editable: false,
                    hidden: true
                }, {
                    xtype: 'combo',
                    fieldLabel: '開單公司',
                    labelWidth: 80,
                    itemId: 'cmbCompany',
                    displayField: 'C_NAME',
                    labelAlign: 'right',
                    valueField: 'UUID',
                    editable: false,
                    hidden: true,
                    store: this.myStore.company,
                    value: '',
                }, {
                    xtype: 'combo',
                    fieldLabel: '客戶',
                    itemId: 'cmbCust',
                    margin: '0 0 0 20',
                    labelWidth: 30,
                    displayField: 'CUST_NAME',
                    valueField: 'CUST_UUID',
                    padding: 5,
                    editable: false,
                    hidden: false,
                    value: '',
                    store: this.myStore.cust,
                    editable: false
                }, {
                    xtype: 'combo',
                    fieldLabel: '訂單狀態',
                    labelWidth: 80,
                    itemId: 'cmbOrderStatus',
                    displayField: 'CUST_ORDER_STATUS_NAME',
                    valueField: 'CUST_ORDER_STATUS_UUID',
                    editable: false,
                    hidden: true,
                    store: this.myStore.custOrderStatus,
                    value: '',
                    width: 160
                }, {
                    xtype: 'combo',
                    fieldLabel: '出貨狀態',
                    queryMode: 'local',
                    itemId: 'cmbShippingStatus',
                    displayField: 'SHIPPING_STATUS_NAME',
                    valueField: 'SHIPPING_STATUS_UUID',
                    labelWidth: 80,
                    width: 200,
                    editable: false,
                    hidden: false,
                    value: 'SS_INPROCESS',
                    store: this.myStore.shippingStatus,
                    editable: false


                }, {
                    xtype: 'textfield',
                    fieldLabel: '關鍵字',
                    margin: '0 0 0 20',
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
                        var store = this.up('panel').down("#grdVCustOrder").getStore(),
                            doSomeghing = function(obj, pl) {
                                obj.getProxy().setExtraParam('pCustOrderType', pl.down("#cmbCustOrderType").getValue());
                                obj.getProxy().setExtraParam('pCustUuid', pl.down("#cmbCust").getValue());
                                obj.getProxy().setExtraParam('pKeyword', pl.down("#txt_search").getValue());
                                obj.getProxy().setExtraParam('pCompanyUuid', pl.down("#cmbCompany").getValue());
                                obj.getProxy().setExtraParam('pCustOrderStatusUuid', pl.down("#cmbOrderStatus").getValue());
                                obj.getProxy().setExtraParam('pShippingStatusUuid', pl.down("#cmbShippingStatus").getValue());
                                obj.loadPage(1);
                            }(store, this.up('panel'));
                    }
                }, {
                    xtype: 'button',
                    width: 80,
                    margin: '0 0 0 5',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/clear.png',
                    text: '清除',
                    tooltip: '*清除目前所有的條件查詢',
                    handler: function() {
                        var mainPanel = this.up('panel');
                        mainPanel.down("#txt_search").setValue('');
                        mainPanel.down("#cmbCustOrderType").setValue('');
                        mainPanel.down("#cmbCust").setValue('');
                        mainPanel.down("#cmbCompany").setValue('');
                        mainPanel.down("#cmbOrderStatus").setValue('');
                        mainPanel.down("#cmbShippingStatus").setValue('');
                    }
                }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                margin: '5 0 0 5',
                hidden: true,
                defaults: {
                    labelAlign: 'right'
                },
                items: []
            }, {
                xtype: 'gridpanel',
                store: this.myStore.vcustorder,
                itemId: 'grdVCustOrder',
                border: true,
                plugins: {
                    ptype: 'cellediting',
                    clicksToEdit: 1,
                    listeners: {
                        beforeedit: function(editor, context, eOpts) {
                            var mainPanel = context.grid.up('panel').up('panel');

                            mainPanel.param.editRecord = context.record;
                            mainPanel.param.editRowIdx = context.rowIdx;
                            mainPanel.param.editColIdx = context.colIdx;
                            //console.log(mainPanel.param);
                        },
                        edit: function(editor, context, eOpts) {
                            var mainPanel = context.grid.up('panel').up('panel');
                            //mainPanel.param.editRecord = context.record;
                            mainPanel.param.editRowIdx = context.rowIdx;
                            mainPanel.param.editColIdx = context.colIdx;

                        }
                    }
                },
                height: $(document).height() - 200,
                padding: '5 15 5 5',
                selModel: new Ext.selection.CheckboxModel({
                    mode: 'MULTI',
                    checkOnly: true,
                    renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
                        if (record.data.SHIPPING_STATUS_UUID == "SS_INPROCESS") {
                            return '<div class="x-grid-row-checker" role="presentation">&nbsp;</div>';
                        } else {
                            return "";
                        };
                    },
                    listeners: {
                        selectionchange: function(selectionModel, selected, options) {}
                    }
                }),
                listeners: {

                },
                columns: [{
                    text: "",
                    xtype: 'actioncolumn',
                    dataIndex: 'UUID',
                    align: 'center',
                    width: 30,
                    items: [{
                        tooltip: '*查看',
                        icon: SYSTEM_URL_ROOT + '/css/custimages/view16x16.png',
                        handler: function(grid, rowIndex, colIndex) {
                            var main = grid.up('panel').up('panel').up('panel');
                            if (!main.subWinCustOrder) {
                                Ext.MessageBox.show({
                                    title: '系統訊息',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK,
                                    msg: '未實現 subWinCustOrder 物件,無法進行編輯操作!'
                                });
                                return false;
                            };
                            var subWin = Ext.create(main.subWinCustOrder, {});

                            subWin.on('closeEvent', function(obj) {}, main);
                            subWin.param.custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                            subWin.param.custUuid = grid.getStore().getAt(rowIndex).data.CUST_UUID;
                            subWin.show();
                        }
                    }],
                    sortable: false,
                    hideable: false
                }, {
                    text: "",
                    xtype: 'actioncolumn',
                    dataIndex: 'UUID',
                    align: 'center',
                    width: 30,
                    items: [{
                        tooltip: '*退回到訂單狀態',
                        icon: SYSTEM_URL_ROOT + '/css/custimages/back16x16.png',
                        handler: function(grid, rowIndex, colIndex) {
                            var main = grid.up('panel').up('panel').up('panel');
                            var custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;

                            if (grid.getStore().getAt(rowIndex).data.SHIPPING_STATUS_UUID != 'SS_INPROCESS') {
                                Ext.MessageBox.show({
                                    title: '系統提示',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK,
                                    msg: '此訂單狀態為「' + grid.getStore().getAt(rowIndex).data.SHIPPING_STATUS_NAME + '」無法執行退回操作'
                                });
                                return;
                            };

                            Ext.MessageBox.confirm('請確認', '將此單退回到訂單狀態?', function(result) {
                                if (result == 'yes') {
                                    WS.CustAction.backToOrder(custOrderUuid, function(obj, jsonObj) {
                                        //alert(jsonObj.result.CUST_ORDER_UUID);
                                        var findData = this.myStore.vcustorder.findRecord("CUST_ORDER_UUID", jsonObj.result.CUST_ORDER_UUID);
                                        this.myStore.vcustorder.remove(findData);
                                    }, this);
                                }
                            }, main);
                        }
                    }],
                    sortable: false,
                    hideable: false
                }, {
                    header: '建立日期',
                    dataIndex: 'CUST_ORDER_CR',
                    align: 'left',hidden:true,
                    width: 100
                },
                {
                    header: "訂單編號",
                    dataIndex: 'CUST_ORDER_ID',
                    align: 'left',
                    width: 130
                }, {
                    header: "公司名稱",
                    dataIndex: 'CUST_NAME',
                    align: 'left',
                    width: 150
                }, {
                    header: "公司電話",
                    align: 'left',
                    dataIndex: 'CUST_TEL',
                    width: 120
                }, {
                    header: "單位",
                    dataIndex: 'CUST_ORDER_DEPT',
                    align: 'left',
                    width: 80
                }, {
                    header: '採購員',
                    dataIndex: 'CUST_ORG_SALES_NAME',
                    align: 'left',
                    width: 80
                }, {
                    header: '聯絡電話',
                    dataIndex: 'CUST_ORG_SALES_PHONE',
                    align: 'left',
                    width: 120,
                    hidden: false
                },  {
                    xtype: 'templatecolumn',
                    header: '發票號碼',
                    dataIndex: 'CUST_ORDER_INVOICE_NUMBER',
                    align: 'right',
                    width: 150,
                    layout: 'hbox',
                    tpl: new Ext.XTemplate(
                        "<tpl if='SHIPPING_STATUS_UUID == \"SS_INPROCESS\"'>",
                        '<input readonly type="text" style="width:130px;background-color:#75D966" value="{CUST_ORDER_INVOICE_NUMBER}"/>',
                        "<tpl else>",
                        '{CUST_ORDER_INVOICE_NUMBER}',
                        "</tpl>"),
                    editor: {
                        xtype: 'textfield',
                        flex: 1,
                        listeners: {
                            focus: function(obj, eOpts) {
                                var mainPanel = obj.up('panel').up('panel').up('panel');


                                if (mainPanel.param.editRecord.data.SHIPPING_STATUS_UUID != "SS_INPROCESS") {
                                    obj.setReadOnly(true);
                                } else {
                                    obj.setReadOnly(false);
                                }
                            }
                        }
                    }
                }, {
                    header: '金額',
                    dataIndex: 'CUST_ORDER_TOTAL_PRICE',
                    align: 'right',
                    width: 80
                },
                // {
                //     header: "訂單編號",
                //     dataIndex: 'CUST_ORDER_ID',
                //     align: 'left',
                //     width: 150
                // },
                 {
                    header: "出貨編號",
                    dataIndex: 'CUST_ORDER_SHIPPING_NUMBER',
                    align: 'left',
                    width: 150
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
                    width:120
                }, {
                    xtype: 'templatecolumn',
                    header: '備註',
                    dataIndex: 'CUST_ORDER_PS',
                    align: 'center',
                    width: 140,
                    layout: 'hbox',
                    tpl: new Ext.XTemplate(
                        "<tpl if='CUST_ORDER_PS != \"\"'>",
                        '<input type="button" class="red-button-s" onclick="fnOpenPs(\'{CUST_ORDER_UUID}\',\'{CUST_ORDER_STATUS}\',\'{PAY_STATUS_UUID}\')" style="width:110px" value="備註"/>',
                        "<tpl else>",
                        '<input type="button" class="edit-button" onclick="fnOpenPs(\'{CUST_ORDER_UUID}\',\'{CUST_ORDER_STATUS}\',\'{PAY_STATUS_UUID}\')" style="width:110px" value="備註"/>',
                        "</tpl>")
                }],
                tbarCfg: {
                    buttonAlign: 'right'
                },
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.vcustorder,
                    displayInfo: true,
                    displayMsg: '第{0}~{1}資料/共{2}筆',
                    emptyMsg: "無資料顯示"
                }),
                tbar: [{
                    icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                    text: '儲存全部',
                    handler: function() {
                        var mainPanel = this.up('panel').up('panel').up('panel');
                        var updateData = "";
                        Ext.each(mainPanel.myStore.vcustorder.data.items, function(item) {
                            updateData += item.data.CUST_ORDER_UUID + ",," + item.data.CUST_ORDER_INVOICE_NUMBER + "|";
                        });

                        WS.CustAction.batchUpdateCustOrderInvoice(updateData, function(obj, jsonObj) {
                            mainPanel.myStore.vcustorder.reload();
                        }, mainPanel);

                    }
                }, {
                    xtype: 'tbfill'
                }, {
                    icon: SYSTEM_URL_ROOT + '/css/images/okA16x16.png',
                    text: '確定出貨',
                    handler: function() {
                        var main = this.up('panel').up('panel').up('panel'),
                            grid = main.down('#grdVCustOrder'),
                            selectRecord = grid.getSelection();

                        //console.log( main.down('#grdVCustOrder').getSelection() );


                        if (selectRecord.length == 0) {
                            Ext.MessageBox.show({
                                title: '操作提示',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                msg: '請先選擇預出貨的訂單。'
                            });
                        } else {

                            if (main.myStore.vcustorder.getModifiedRecords().length > 0) {
                                var updateData = "";
                                Ext.each(main.myStore.vcustorder.data.items, function(item) {
                                    updateData += item.data.CUST_ORDER_UUID + ",," + item.data.CUST_ORDER_INVOICE_NUMBER + "|";
                                });

                                WS.CustAction.batchUpdateCustOrderInvoice(updateData, function(obj, jsonObj) {

                                    var postData = '';
                                    var hasAddressEmpty = false;
                                    Ext.each(selectRecord, function(item) {
                                        if (!Ext.isEmpty(item.data.SHIPPING_ADDRESS)) {
                                            postData += item.data.CUST_ORDER_UUID + "|";
                                        } else {
                                            hasAddressEmpty = true;
                                        };
                                    });

                                    if (hasAddressEmpty == true) {
                                        Ext.MessageBox.show({
                                            title: '操作提示',
                                            icon: Ext.MessageBox.INFO,
                                            buttons: Ext.Msg.OK,
                                            msg: '請檢查訂單出貨地址，發現有空的出貨地址!'
                                        });
                                        return;
                                    };

                                    if (postData.length == 0) {
                                        return;
                                    }
                                    WS.CustAction.shippingCustOrder(postData, function(obj, jsonObj) {
                                        if (jsonObj.result.success && jsonObj.result.success == true) {
                                            var shippCount = jsonObj.result.shippingCount;
                                            if (shippCount > 0) {
                                                Ext.MessageBox.show({
                                                    title: '完成出貨',
                                                    icon: Ext.MessageBox.INFO,
                                                    buttons: Ext.Msg.OK,
                                                    msg: '完成' + shippCount + '筆訂單出貨。',
                                                    fn: function() {
                                                        this.myStore.vcustorder.reload();
                                                    },
                                                    scope: this
                                                });
                                            }
                                        }
                                    }, main);


                                }, main);
                            } else {
                                var postData = '';
                                var hasAddressEmpty = false;
                                Ext.each(selectRecord, function(item) {
                                    if (!Ext.isEmpty(item.data.SHIPPING_ADDRESS)) {
                                        postData += item.data.CUST_ORDER_UUID + "|";
                                    } else {
                                        hasAddressEmpty = true;
                                    };
                                });

                                if (hasAddressEmpty == true) {
                                    Ext.MessageBox.show({
                                        title: '操作提示',
                                        icon: Ext.MessageBox.INFO,
                                        buttons: Ext.Msg.OK,
                                        msg: '請檢查訂單出貨地址，發現有空的出貨地址!'
                                    });
                                    return;
                                };

                                if (postData.length == 0) {
                                    return;
                                }
                                WS.CustAction.shippingCustOrder(postData, function(obj, jsonObj) {
                                    if (jsonObj.result.success && jsonObj.result.success == true) {
                                        var shippCount = jsonObj.result.shippingCount;
                                        if (shippCount > 0) {
                                            Ext.MessageBox.show({
                                                title: '完成出貨',
                                                icon: Ext.MessageBox.INFO,
                                                buttons: Ext.Msg.OK,
                                                msg: '完成' + shippCount + '筆訂單出貨。',
                                                fn: function() {
                                                    this.myStore.vcustorder.reload();
                                                },
                                                scope: this
                                            });
                                        }
                                    }
                                }, main);
                            }


                        };


                        /*註冊事件*/

                    }
                }]
            }]

        }];
        this.callParent(arguments);
    },
    listeners: {
        afterrender: function(obj, eOpts) {

            if (!document.fnOpenPsControlObj) {
                document.fnOpenPsControlObj = this;
            };

            if (!document.fnOpenPs) {
                document.fnOpenPs = function(custOrderUuid, custOrderStatus, payStatus) {
                    if (payStatus != 'pay_status_2') {
                        var subWin = Ext.create('WS.CustOrderPsWindow', {
                            param: {
                                custOrderUuid: custOrderUuid,
                                parentObj: document.fnOpenPsControlObj
                            }
                        });
                        subWin.on('closeEvent', function(obj) {
                            obj.param.parentObj.myStore.vcustorder.reload();
                        });
                        subWin.show();
                    } else {
                        var subWin = Ext.create('WS.CustOrderPsViewWindow', {
                            param: {
                                custOrderUuid: custOrderUuid
                            }
                        });
                        subWin.on('closeEvent', function(obj) {});
                        subWin.show();
                    }
                };
            };

            this.myStore.cust.load({
                scope: this
            });

            this.myStore.vcustorder.load({
                scope: this
            });

            this.myStore.company.load({
                scope: this
            });

            this.myStore.custOrderStatus.load({
                scope: this
            });

            this.myStore.shippingStatus.load({
                scope: this
            });

        }
    }
});
