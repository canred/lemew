/*全局變量*/
var WS_BILLINGQUERYPANEL;
/*WS.SupplierQueryPanel物件類別*/
/*TODO*/
/*
1.Model 要集中                                 [YES]
2.panel 的title要換成icon , title的方式        [YES]
3.add 的icon要換成icon , title的方式           [YES]
4.自動Query 資料                               [YES]
*/
/*columns 使用default*/
Ext.define('WS.BillingQueryPanel', {
    extend: 'Ext.panel.Panel',
    closeAction: 'destroy',
    subWinBilling: undefined,
    lan: {},
    param: {
        showADSync: true
    },
    val: {},
    myStore: {
        billing: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'BILLING',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.BillingAction.loadBilling
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pCustUuid','billingIsActive', 'pKeyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pCustUuid: '',
                    billingIsActive:'1',
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
            sorters: [{
                property: 'BILLING_ID',
                direction: 'DESC'
            }]
        })
    },
    fnActiveRender: function isActiveRenderer(value, id, r) {
        var html = "<img src='" + SYSTEM_URL_ROOT;
        return value === "Y" ? html + "/css/custimages/active03.png'>" : html + "/css/custimages/unactive03.png'>";
    },
    fnCheckSubWindowns: function() {

        if (Ext.isEmpty(this.subWinBilling)) {
            Ext.MessageBox.show({
                title: '系統提示',
                icon: Ext.MessageBox.WARNING,
                buttons: Ext.Msg.OK,
                msg: '未實現 subWinBilling 物件,無法進行編輯操作!'
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
            title: '請款單查詢',
            icon: SYSTEM_URL_ROOT + '/css/custimages/moneyB16x16.png',
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
                        var store = this.up('panel').down("#grdBilling").getStore(),
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
                store: this.myStore.billing,
                itemId: 'grdBilling',
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
                            '{[this.fnInit()]}<input type="button" style="width:50px" value="編輯" onclick="BillingPanelFnEdit(\'{BILLING_UUID}\')"/>',
                            "</tpl>", {
                                scope: this,
                                fnInit: function() {
                                    if (!document.BillingPanelFnEdit) {
                                        document.BillingQueryPanel = this.scope;
                                        document.BillingPanelFnEdit = function(billingUuid) {
                                            var main = document.BillingQueryPanel;
                                            if (!main.subWinBilling) {
                                                Ext.MessageBox.show({
                                                    title: '系統訊息',
                                                    icon: Ext.MessageBox.INFO,
                                                    buttons: Ext.Msg.OK,
                                                    msg: '未實現 subWinBilling 物件,無法進行編輯操作!'
                                                });
                                                return false;
                                            };
                                            var subWin = Ext.create(main.subWinBilling, {
                                                param:{
                                                    billingUuid: billingUuid,
                                                    parentObj: main,
                                                    canSelectCust: false
                                                }
                                            });
                                            subWin.on('closeEvent', function(obj) {
                                                main.down("#grdBilling").getStore().load();
                                            }, main);                                            
                                            subWin.show();
                                        }
                                    }

                                }
                            }),

                    }, {
                        header: "建立時間",
                        dataIndex: 'BILLING_REPORT_DATE',
                        align: 'left',
                        width: 100
                    }, {
                        header: "客戶公司",
                        align: 'left',
                        dataIndex: 'BILLING_CUST_NAME',
                        width: 150
                    }, {
                        header: "請款時間(開始)",
                        dataIndex: 'BILLING_START_DATE',
                        align: 'left',
                        width: 110
                    }, {
                        header: '請款時間(結束)',
                        dataIndex: 'BILLING_END_DATE',
                        align: 'left',
                        width: 110
                    }, 
                    // {
                    //     header: '採購員',
                    //     dataIndex: 'CUST_SALES_NAME',
                    //     align: 'left',
                    //     width: 80
                    // }, {
                    //     header: '採購員電話',
                    //     dataIndex: 'CUST_SALES_PHONE',
                    //     align: 'left',
                    //      width: 80
                    // },
                     {
                        header: '請款訂單數',
                        dataIndex: 'BILLING_ITEM_COUNT',
                        align: 'right',
                        width: 80
                    }, {
                        header: '折扣',
                        dataIndex: 'BILLING_DISCOUNT',
                        align: 'right',
                        flex: 1,renderer: function (value,r) {                            
                            return Ext.String.format('${0}', value);
                        }  
                    }, {
                        header: '請款金額',
                        dataIndex: 'BILLING_TOTAL_PRICE',
                        align: 'right',
                        flex: 1,renderer: function (value,r) {                            
                            return Ext.String.format('${0}', value);
                        }  
                    }, {
                        header: '備註',
                        dataIndex: 'BILLING_PS',
                        align: 'left',
                        flex: 1
                    }
                ],
                tbarCfg: {
                    buttonAlign: 'right'
                },
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.billing,
                    displayInfo: true,
                    displayMsg: '第{0}~{1}資料/共{2}筆',
                    emptyMsg: "無資料顯示"
                }),
                tbar: [{
                    icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                    text: '新增請款單',
                    handler: function() {
                        var main = this.up('panel').up('panel').up('panel');

                        if (!main.fnCheckSubWindowns()) {
                            Ext.MessageBox.show({
                                title: '系統訊息',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                msg: '未實現 subWinBilling 物件,無法進行編輯操作!'
                            });
                            return false;
                        };

                        WS.BillingAction.createBilling(function(obj, jsonObj) {
                            if (jsonObj.result.success && jsonObj.result.BILLING_UUID) {
                                
                                var subWin = Ext.create(main.subWinBilling, {
                                    param: {
                                        billingUuid: jsonObj.result.BILLING_UUID,
                                        parentObj: this,
                                        canSelectCust:true
                                    }
                                });

                                subWin.on('closeEvent', function(obj) {
                                    main.down("#grdBilling").getStore().load();

                                }, this);
                                subWin.show();
                            }
                        }, main);


                    }
                }]
            }]
        }];
        this.callParent(arguments);
    },
    listeners: {
        afterrender: function(obj, eOpts) {
            this.myStore.billing.load({
                scope: this
            });
        }
    }
});
