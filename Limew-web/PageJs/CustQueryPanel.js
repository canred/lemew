/*全局變量*/
var WS_CUSTQUERYPANEL;
/*WS.SupplierQueryPanel物件類別*/
/*TODO*/
/*
1.Model 要集中                                 [YES]
2.panel 的title要換成icon , title的方式        [YES]
3.add 的icon要換成icon , title的方式           [YES]
4.自動Query 資料                               [YES]
*/
/*columns 使用default*/
Ext.define('WS.CustQueryPanel', {
    extend: 'Ext.panel.Panel',
    closeAction: 'destroy',
    subWinCust: undefined,
    lan: {},
    param: {
        showADSync: true
    },
    val: {},
    myStore: {
        cust: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'CUST',
            pageSize: 10,
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
            sorters: [{
                property: 'CUST_NAME',
                direction: 'ASC'
            }]
        })
    },
    fnActiveRender: function isActiveRenderer(value, id, r) {
        var html = "<img src='" + SYSTEM_URL_ROOT;
        return value === "Y" ? html + "/css/custimages/active03.png'>" : html + "/css/custimages/unactive03.png'>";
    },
    fnCheckSubWindowns: function() {

        if (Ext.isEmpty(this.subWinCust)) {
            Ext.MessageBox.show({
                title: '系統提示',
                icon: Ext.MessageBox.WARNING,
                buttons: Ext.Msg.OK,
                msg: '未實現 subWinCust 物件,無法進行編輯操作!'
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
            title: '客戶查詢',
            icon: SYSTEM_URL_ROOT + '/css/custimages/cust16x16.png',
            frame: true,

            border: false,
            height: $(document).height() - 130,
            autoWidth: true,
            padding: '5 0 5 5',
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
                        var store = this.up('panel').down("#grdSupplierQuery").getStore(),
                            doSomeghing = function(obj, pl) {
                                obj.getProxy().setExtraParam('pKeyword', pl.down("#txt_search").getValue());
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
                    }
                }]
            }, {
                xtype: 'gridpanel',
                store: this.myStore.cust,
                itemId: 'grdSupplierQuery',
                border: true,
                height: $(document).height() - 200,
                padding: '5 15 5 5',
                columns: [
                    // {
                    //     text: "編輯",
                    //     xtype: 'actioncolumn',
                    //     dataIndex: 'UUID',
                    //     align: 'center',
                    //     width: 60,
                    //     items: [{
                    //         tooltip: '*編輯',
                    //         icon: SYSTEM_URL_ROOT + '/css/images/edit16x16.png',
                    //         handler: function(grid, rowIndex, colIndex) {

                    //         }
                    //     }],

                    // }, 
                    {
                        xtype: 'templatecolumn',
                        text: '編輯',
                        width: 60,
                        sortable: false,
                        hideable: false,
                        tpl: new Ext.XTemplate(
                            "<tpl >",
                            '{[this.fnInit()]}<input type="button" style="width:50px" value="編輯" onclick="CustQueryPanelFnEdit(\'{CUST_UUID}\')"/>',
                            "</tpl>", {
                                fnInit: function() {
                                    if (!document.CustQueryPanelFnEdit) {
                                        document.CustQueryPanelFnEdit = function(CUST_UUID) {
                                            var main = WS_CUSTQUERYPANEL;
                                            if (!main.subWinCust) {
                                                Ext.MessageBox.show({
                                                    title: '系統訊息',
                                                    icon: Ext.MessageBox.INFO,
                                                    buttons: Ext.Msg.OK,
                                                    msg: '未實現 subWinCust 物件,無法進行編輯操作!'
                                                });
                                                return false;
                                            };
                                            var subWin = Ext.create(main.subWinCust, {
                                                subWinCustOrder: 'WS.CustOrderStep1Window'
                                            });
                                            subWin.on('closeEvent', function(obj) {
                                                main.down("#grdSupplierQuery").getStore().load();
                                            }, main);
                                            subWin.param.custUuid = CUST_UUID;
                                            subWin.show();
                                        }
                                    }

                                }
                            }),

                    }, {
                        header: "客戶名稱",
                        dataIndex: 'CUST_NAME',
                        align: 'left',
                        width: 200
                    }, {
                        header: "電話",
                        align: 'left',
                        dataIndex: 'CUST_TEL',
                        flex: 1
                    }, {
                        header: "傳真",
                        dataIndex: 'CUST_FAX',
                        align: 'left',
                        hidden: true,
                        flex: 1
                    }, {
                        header: '地址',
                        dataIndex: 'CUST_ADDRESS',
                        align: 'left',
                        flex: 1
                    }, {
                        header: '採購員',
                        dataIndex: 'CUST_SALES_NAME',
                        align: 'left',
                        flex: 1
                    }, {
                        header: '採購員電話',
                        dataIndex: 'CUST_SALES_PHONE',
                        align: 'left',
                        flex: 1
                    }, {
                        header: '採購員email',
                        dataIndex: 'CUST_SALES_EMAIL',
                        align: 'left',
                        hidden: true,
                        flex: 1
                    }, {
                        header: '備註',
                        dataIndex: 'CUST_PS',
                        align: 'left',
                        flex: 1
                    }
                ],
                tbarCfg: {
                    buttonAlign: 'right'
                },
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.cust,
                    displayInfo: true,
                    displayMsg: '第{0}~{1}資料/共{2}筆',
                    emptyMsg: "無資料顯示"
                }),
                tbar: [{
                    icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                    text: '新增',
                    handler: function() {
                        var main = this.up('panel').up('panel').up('panel');

                        if (!main.fnCheckSubWindowns()) {
                            Ext.MessageBox.show({
                                title: '系統訊息',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                msg: '未實現 subWinCust 物件,無法進行編輯操作!'
                            });
                            return false;
                        };

                        WS.CustAction.infoCust("", function(obj, jsonObj) {
                            var subWin = Ext.create(main.subWinCust, {
                                param: {
                                    custUuid: jsonObj.result.data.CUST_UUID
                                },
                                subWinCustOrder: 'WS.CustOrderStep1Window'
                            });
                            subWin.on('closeEvent', function(obj) {
                                this.down("#grdSupplierQuery").getStore().load();
                            }, this);
                            subWin.show();
                        }, main);


                    }
                }]
            }]
        }];
        this.callParent(arguments);
    },
    listeners: {
        afterrender: function(obj, eOpts) {
            this.myStore.cust.load({
                scope: this
            });
        }
    }
});
