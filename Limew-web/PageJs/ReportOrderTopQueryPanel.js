/*全局變量*/
var WS_REPORTORDERTOPQUERYPANEL;
/*WS.SupplierQueryPanel物件類別*/
/*TODO*/
/*
1.Model 要集中                                 [YES]
2.panel 的title要換成icon , title的方式        [YES]
3.add 的icon要換成icon , title的方式           [YES]
4.自動Query 資料                               [YES]
*/
/*columns 使用default*/
Ext.define('WS.ReportOrderTopQueryPanel', {
    extend: 'Ext.panel.Panel',
    closeAction: 'destroy',
    //subWinCustOrder: undefined,
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
                    for(var i = 0 ; i < store.getCount() ; i++){
                        if(store.getAt(i).get('C_NAME').length>2){
                        store.getAt(i).set('C_NAME',store.getAt(i).get('C_NAME').substr(0,2));
                        store.getAt(i).commit();    
                        }
                        
                    }
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'C_NAME',
                direction: 'ASC'
            }]
        }),
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
            listeners: {
                load: function(store, records, sucessful, eOpts) {
                    store.insert(0, {
                        'CUST_UUID': '',
                        'CUST_NAME': '全部'
                    });
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'CUST_NAME',
                direction: 'ASC'
            }]
        }),
        vCustOrder: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'V_CUST_ORDER',
            pageSize: 999999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadVCustOrderForReport
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pStartDate', 'pEndDate', 'pIsGroup', 'pGroupType', 'pCompanyUuid', 'pCustUuid', 'pCustOrgUuid', 'pKeyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    'pStartDate': '',
                    'pEndDate': '',
                    'pIsGroup': '',
                    'pGroupType': '',
                    'pCompanyUuid': '',
                    'pCustUuid': '',
                    'pCustOrgUuid': '',
                    'pKeyword': ''
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
                property: 'CUST_ORDER_ID',
                direction: 'DESC'
            }]
        }),
        custOrg: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'V_CUST_ORDER',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadCustOrg
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pCustUuid', 'pKeyword', 'pShowIsDefault', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pCustUuid: '',
                    pKeyword: '',
                    pShowIsDefault: '0'
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
                        'CUST_ORG_UUID': '',
                        'CUST_ORG_NAME': '全部'
                    });
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'CUST_ORG_NAME',
                direction: 'ASC'
            }]
        })

    },
    //width:$(document).width()*.94,
    fnActiveRender: function isActiveRenderer(value, id, r) {
        var html = "<img src='" + SYSTEM_URL_ROOT;
        return value === "Y" ? html + "/css/custimages/active03.png'>" : html + "/css/custimages/unactive03.png'>";
    },
    fnCheckSubWindowns: function() {

        // if (Ext.isEmpty(this.subWinCustOrder)) {
        //     Ext.MessageBox.show({
        //         title: '系統提示',
        //         icon: Ext.MessageBox.WARNING,
        //         buttons: Ext.Msg.OK,
        //         msg: '未實現 subWinCustOrder 物件,無法進行編輯操作!'
        //     });
        //     return false;
        // };
        return true;
    },
    initComponent: function() {
        if (!this.fnCheckSubWindowns()) {
            return false;
        };
        this.items = [{
            xtype: 'panel',
            title: '銷售業績圖表',
            icon: SYSTEM_URL_ROOT + '/css/custimages/reportB16x16.png',
            frame: true,
            border: false,
            autoWidth: true,
            height: 80,
            padding: '5 0 5 5',
            items: [{
                xtype: 'container',
                layout: 'hbox',
                items: [{
                    xtype: 'combo',
                    fieldLabel: '年份',
                    queryMode: 'local',
                    itemId: 'cmbYear',
                    displayField: 'text',
                    valueField: 'value',
                    editable: false,
                    hidden: false,
                    labelWidth: 40,
                    width: 110,
                    labelAlign: 'right',
                    store: new Ext.data.ArrayStore({
                        fields: ['text', 'value']
                    }),
                    listeners: {
                        'select': function(combo, records, eOpts) {
                            var mainPanel = this.up('panel').up('panel');
                            var start = mainPanel.down('#dfStart');
                            var end = mainPanel.down("#dfEnd");
                            start.setValue(this.getValue() + "/01/01");
                            end.setValue(this.getValue() + "/12/31");
                        }
                    }
                }, {
                    xtype: 'datefield',
                    labelWidth: 60,
                    fieldLabel: '日期區間',
                    hidden: true,
                    //value: new Date(),
                    format: 'Y/m/d',
                    submitFormat: 'Y/m/d',
                    labelAlign: 'right',
                    itemId: 'dfStart',
                    width: 170
                }, {
                    xtype: 'datefield',
                    hidden: true,
                    //value: new Date(),
                    format: 'Y/m/d',
                    submitFormat: 'Y/m/d',
                    labelAlign: 'right',
                    itemId: 'dfEnd',
                    width: 110
                }, {
                    xtype: 'combo',
                    fieldLabel: '出貨公司',
                    labelAlign: 'right',
                    width: 130,
                    labelWidth: 60,
                    itemId: 'cmbCompany',
                    displayField: 'C_NAME',
                    valueField: 'UUID',
                    editable: false,
                    store: this.myStore.company,
                    value: '',
                    listeners: {
                        'select': function(combo, records, eOpts) {}
                    }
                }, {
                    xtype: 'combo',
                    fieldLabel: '客戶名稱',
                    displayField: 'CUST_NAME',
                    valueField: 'CUST_UUID',
                    itemId: 'cmbCust',
                    hidden: false,
                    editable: false,
                    readOnly:true,
                    store: this.myStore.cust,
                    value: '',
                    listeners: {
                        'select': function(combo, records, eOpts) {
                            var mainPanel = combo.up('panel').up('panel');
                            mainPanel.down('#cmbCustOrg').setValue('');
                            mainPanel.myStore.custOrg.getProxy().setExtraParam('pCustUuid', combo.getValue());
                            mainPanel.myStore.custOrg.load();
                        }
                    },
                    labelAlign: 'right',
                    width: 130,
                    labelWidth: 60
                },{
                    xtype:'button',
                    text:'選',
                    handler:function(handler,scope){
                        var mainPanel = this.up('panel').up('panel');
                        var subWin = Ext.create('WS.CustPickerWindow',{
                            param:{
                                parentObj:mainPanel,
                                showAllBtn:true
                            }
                        });
                        subWin.on('selectedEvent',function(obj,selectRecord){
                            obj.param.parentObj.down('#cmbCust').setValue(selectRecord.CUST_UUID);
                            
                            obj.param.parentObj.down('#cmbCustOrg').setValue('');
                            obj.param.parentObj.myStore.custOrg.getProxy().setExtraParam('pCustUuid', selectRecord.CUST_UUID);
                            obj.param.parentObj.myStore.custOrg.load();

                            obj.close();

                        });
                        subWin.show();
                    }
                },{

                    xtype: 'combo',
                    fieldLabel: '單位',
                    itemId: 'cmbCustOrg',
                    value: '',
                    displayField: 'CUST_ORG_NAME',
                    valueField: 'CUST_ORG_UUID',
                    editable: false,
                    hidden: false,
                    store: this.myStore.custOrg,
                    labelAlign: 'right',
                    width: 110,
                    labelWidth: 40

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

                                var start = pl.down('#dfStart').getValue();
                                var end = pl.down('#dfEnd').getValue();

                                if (start != undefined && typeof start.getFullYear == 'function') {
                                    var month = (start.getMonth() + 1);
                                    var day = start.getDate();
                                    if (month < 10) {
                                        month = "0" + month;
                                    };
                                    if (day < 10) {
                                        day = "0" + day;
                                    };
                                    start = start.getFullYear() + '/' + month + "/" + day;
                                };

                                if (end != undefined && typeof end.getFullYear == 'function') {
                                    var month = (end.getMonth() + 1);
                                    var day = end.getDate();
                                    if (month < 10) {
                                        month = "0" + month;
                                    };
                                    if (day < 10) {
                                        day = "0" + day;
                                    };
                                    end = end.getFullYear() + '/' + month + "/" + day;
                                };


                                if (Ext.isEmpty(start)) {
                                    start = '';
                                };
                                if (Ext.isEmpty(end)) {
                                    end = '';
                                };
                                if (start != '' || end != '') {
                                    if (start == '' || end == '') {
                                        Ext.MessageBox.show({
                                            title: '操作提示',
                                            icon: Ext.MessageBox.INFO,
                                            buttons: Ext.Msg.OK,
                                            msg: '日期區間查詢，須要填寫開始日期、結束日期!'
                                        });
                                        return;
                                    }
                                };
                                var company = pl.down('#cmbCompany').getValue();
                                var cust = pl.down('#cmbCust').getValue();
                                var custOrg = pl.down('#cmbCustOrg').getValue();
                                var keyword = '';

                                obj.getProxy().setExtraParam('pStartDate', start);
                                obj.getProxy().setExtraParam('pEndDate', end);
                                obj.getProxy().setExtraParam('pIsGroup', '');
                                obj.getProxy().setExtraParam('pGroupType', '');
                                obj.getProxy().setExtraParam('pCompanyUuid', company);
                                obj.getProxy().setExtraParam('pCustUuid', cust);
                                obj.getProxy().setExtraParam('pCustOrgUuid', custOrg);
                                obj.getProxy().setExtraParam('pKeyword', keyword);


                                //alert();
                                //obj.loadPage(1);
                                obj.reload({
                                    callback: pl.up('panel').fnChartB,
                                    scope: pl.up('panel')
                                });

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
                        mainPanel.down("#dfStart").setValue('');
                        mainPanel.down("#dfEnd").setValue('');
                        mainPanel.down("#cmbCompany").setValue('');
                        mainPanel.down("#cmbCust").setValue('');
                        mainPanel.down("#cmbCustOrg").setValue('');
                        //mainPanel.down("#txt_search").setValue('');

                    }
                }]
            }, {
                xtype: 'gridpanel',
                store: this.myStore.vCustOrder,
                itemId: 'grdSupplierQuery',
                border: true,
                hidden: true,
                height: $(document).height() - 210,
                width: $(document).width * .9,
                padding: '5 15 5 5',
                columns: [{
                    text: "查看",
                    xtype: 'actioncolumn',
                    dataIndex: 'UUID',
                    align: 'center',
                    width: 60,
                    items: [{
                        tooltip: '*編輯',
                        icon: SYSTEM_URL_ROOT + '/css/images/edit16x16.png',
                        handler: function(grid, rowIndex, colIndex) {
                            var main = grid.up('panel').up('panel').up('panel');
                            subWin.on('closeEvent', function(obj) {}, main);
                            subWin.param.custOrderUuid = grid.getStore().getAt(rowIndex).data.CUST_ORDER_UUID;
                            subWin.param.custUuid = grid.getStore().getAt(rowIndex).data.CUST_UUID;
                            subWin.show();
                        }
                    }],
                    sortable: false,
                    hideable: false
                }, {
                    header: '訂單編號',
                    dataIndex: 'CUST_ORDER_ID',
                    width: 140,
                }, {
                    header: "出貨日期",
                    dataIndex: 'CUST_ORDER_SHIPPING_DATE',
                    align: 'left',
                    flex: 1
                }, {
                    header: "出貨公司",
                    align: 'left',
                    dataIndex: 'COMPANY_C_NAME',
                    flex: 1
                }, {
                    header: "客戶名稱",
                    dataIndex: 'CUST_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    header: '單位',
                    dataIndex: 'CUST_ORG_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    header: '總銷售金額',
                    dataIndex: 'CUST_ORDER_TOTAL_PRICE',
                    align: 'right',
                    flex: 1
                }],
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.vCustOrder,
                    displayInfo: true,
                    displayMsg: '第{0}~{1}資料/共{2}筆',
                    emptyMsg: "無資料顯示"
                })
            }]
        }, {
            xtype: 'panel',
            itemId: 'pnlPie',
            height: 400,
            width: $(document).width() * .9
        }, {
            xtype: 'panel',
            itemId: 'pnlBar',
            height: 400,
            width: $(document).width() * .9
        }];
        this.callParent(arguments);
    },
    fnChartA: function() {
        var me = this;
        require(
            [
                'echarts',
                'echarts/chart/line',
                'echarts/chart/bar'
            ],
            function(ec) {
                var arrXAxis = [];
                var arrXAxisUuid = [];
                var arrYAxis = [];
                var keyXAxiz = '';
                // var arrXAxisCpuValue = [];
                // var arrXAxisMenValue = [];
                Ext.each(me.myStore.vCustOrder.data.items, function(item) {
                    if (keyXAxiz.indexOf(item.data.CUST_UUID) == -1) {
                        arrXAxisUuid.push(item.data.CUST_UUID);
                        arrXAxis.push(item.data.CUST_NAME);
                        keyXAxiz += item.data.CUST_UUID + '|';
                    }
                    //arrXAxisCpuValue.push(item.data.cpu);
                    //arrXAxisMenValue.push(item.data.men);
                });

                for (var i = 0; i < arrXAxisUuid.length; i++) {
                    var m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12 = 0;
                    //01
                    me.myStore.vCustOrder.filterBy(function(record, id) {
                        if (record.data.CUST_UUID == arrXAxisUuid[i]) {
                            try {
                                var recordDate = new Date(record.data.CUST_ORDER_SHIPPING_DATE.split(' ')[0]);
                                if (recordDate.getFullYear() == me.down('#cmbYear').getValue() && (recordDate.getMonth() + 1) == "1") {
                                    return true;
                                } else {
                                    return false;
                                }
                            } catch (e) {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    });
                    m1 = parseFloat(me.myStore.vCustOrder.sum('CUST_ORDER_TOTAL_PRICE'));
                    me.myStore.vCustOrder.clearFilter();
                    //02
                    me.myStore.vCustOrder.filterBy(function(record, id) {
                        if (record.data.CUST_UUID == arrXAxisUuid[i]) {
                            try {
                                var recordDate = new Date(record.data.CUST_ORDER_SHIPPING_DATE.split(' ')[0]);
                                if (recordDate.getFullYear() == me.down('#cmbYear').getValue() && (recordDate.getMonth() + 1) == "2") {
                                    return true;
                                } else {
                                    return false;
                                }
                            } catch (e) {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    });
                    m2 = parseFloat(me.myStore.vCustOrder.sum('CUST_ORDER_TOTAL_PRICE'));
                    me.myStore.vCustOrder.clearFilter();
                    //03
                    me.myStore.vCustOrder.filterBy(function(record, id) {
                        if (record.data.CUST_UUID == arrXAxisUuid[i]) {
                            try {
                                var recordDate = new Date(record.data.CUST_ORDER_SHIPPING_DATE.split(' ')[0]);
                                if (recordDate.getFullYear() == me.down('#cmbYear').getValue() && (recordDate.getMonth() + 1) == "3") {
                                    return true;
                                } else {
                                    return false;
                                }
                            } catch (e) {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    });
                    m3 = parseFloat(me.myStore.vCustOrder.sum('CUST_ORDER_TOTAL_PRICE'));
                    me.myStore.vCustOrder.clearFilter();
                    //04
                    me.myStore.vCustOrder.filterBy(function(record, id) {
                        if (record.data.CUST_UUID == arrXAxisUuid[i]) {
                            try {
                                var recordDate = new Date(record.data.CUST_ORDER_SHIPPING_DATE.split(' ')[0]);
                                if (recordDate.getFullYear() == me.down('#cmbYear').getValue() && (recordDate.getMonth() + 1) == "4") {
                                    return true;
                                } else {
                                    return false;
                                }
                            } catch (e) {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    });
                    m4 = parseFloat(me.myStore.vCustOrder.sum('CUST_ORDER_TOTAL_PRICE'));
                    me.myStore.vCustOrder.clearFilter();

                    //05
                    me.myStore.vCustOrder.filterBy(function(record, id) {
                        if (record.data.CUST_UUID == arrXAxisUuid[i]) {
                            try {
                                var recordDate = new Date(record.data.CUST_ORDER_SHIPPING_DATE.split(' ')[0]);
                                if (recordDate.getFullYear() == me.down('#cmbYear').getValue() && (recordDate.getMonth() + 1) == "5") {
                                    return true;
                                } else {
                                    return false;
                                }
                            } catch (e) {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    });
                    m5 = parseFloat(me.myStore.vCustOrder.sum('CUST_ORDER_TOTAL_PRICE'));
                    me.myStore.vCustOrder.clearFilter();

                    //06
                    me.myStore.vCustOrder.filterBy(function(record, id) {
                        if (record.data.CUST_UUID == arrXAxisUuid[i]) {
                            try {
                                var recordDate = new Date(record.data.CUST_ORDER_SHIPPING_DATE.split(' ')[0]);
                                if (recordDate.getFullYear() == me.down('#cmbYear').getValue() && (recordDate.getMonth() + 1) == "6") {
                                    return true;
                                } else {
                                    return false;
                                }
                            } catch (e) {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    });
                    m6 = parseFloat(me.myStore.vCustOrder.sum('CUST_ORDER_TOTAL_PRICE'));
                    me.myStore.vCustOrder.clearFilter();

                    //07
                    me.myStore.vCustOrder.filterBy(function(record, id) {
                        if (record.data.CUST_UUID == arrXAxisUuid[i]) {
                            try {
                                var recordDate = new Date(record.data.CUST_ORDER_SHIPPING_DATE.split(' ')[0]);
                                if (recordDate.getFullYear() == me.down('#cmbYear').getValue() && (recordDate.getMonth() + 1) == "7") {
                                    return true;
                                } else {
                                    return false;
                                }
                            } catch (e) {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    });
                    m7 = parseFloat(me.myStore.vCustOrder.sum('CUST_ORDER_TOTAL_PRICE'));
                    me.myStore.vCustOrder.clearFilter();

                    //08
                    me.myStore.vCustOrder.filterBy(function(record, id) {
                        if (record.data.CUST_UUID == arrXAxisUuid[i]) {
                            try {
                                var recordDate = new Date(record.data.CUST_ORDER_SHIPPING_DATE.split(' ')[0]);
                                if (recordDate.getFullYear() == me.down('#cmbYear').getValue() && (recordDate.getMonth() + 1) == "8") {
                                    return true;
                                } else {
                                    return false;
                                }
                            } catch (e) {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    });
                    m8 = parseFloat(me.myStore.vCustOrder.sum('CUST_ORDER_TOTAL_PRICE'));
                    me.myStore.vCustOrder.clearFilter();

                    //09
                    me.myStore.vCustOrder.filterBy(function(record, id) {
                        if (record.data.CUST_UUID == arrXAxisUuid[i]) {
                            try {
                                var recordDate = new Date(record.data.CUST_ORDER_SHIPPING_DATE.split(' ')[0]);
                                if (recordDate.getFullYear() == me.down('#cmbYear').getValue() && (recordDate.getMonth() + 1) == "9") {
                                    return true;
                                } else {
                                    return false;
                                }
                            } catch (e) {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    });
                    m9 = parseFloat(me.myStore.vCustOrder.sum('CUST_ORDER_TOTAL_PRICE'));
                    me.myStore.vCustOrder.clearFilter();

                    //10
                    me.myStore.vCustOrder.filterBy(function(record, id) {
                        if (record.data.CUST_UUID == arrXAxisUuid[i]) {
                            try {
                                var recordDate = new Date(record.data.CUST_ORDER_SHIPPING_DATE.split(' ')[0]);
                                if (recordDate.getFullYear() == me.down('#cmbYear').getValue() && (recordDate.getMonth() + 1) == "10") {
                                    return true;
                                } else {
                                    return false;
                                }
                            } catch (e) {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    });
                    m10 = parseFloat(me.myStore.vCustOrder.sum('CUST_ORDER_TOTAL_PRICE'));
                    me.myStore.vCustOrder.clearFilter();

                    //11
                    me.myStore.vCustOrder.filterBy(function(record, id) {
                        if (record.data.CUST_UUID == arrXAxisUuid[i]) {
                            try {
                                var recordDate = new Date(record.data.CUST_ORDER_SHIPPING_DATE.split(' ')[0]);
                                if (recordDate.getFullYear() == me.down('#cmbYear').getValue() && (recordDate.getMonth() + 1) == "11") {
                                    return true;
                                } else {
                                    return false;
                                }
                            } catch (e) {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    });
                    m11 = parseFloat(me.myStore.vCustOrder.sum('CUST_ORDER_TOTAL_PRICE'));
                    me.myStore.vCustOrder.clearFilter();

                    //12
                    me.myStore.vCustOrder.filterBy(function(record, id) {
                        if (record.data.CUST_UUID == arrXAxisUuid[i]) {
                            try {
                                var recordDate = new Date(record.data.CUST_ORDER_SHIPPING_DATE.split(' ')[0]);
                                if (recordDate.getFullYear() == me.down('#cmbYear').getValue() && (recordDate.getMonth() + 1) == "12") {
                                    return true;
                                } else {
                                    return false;
                                }
                            } catch (e) {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    });

                    m12 = parseFloat(me.myStore.vCustOrder.sum('CUST_ORDER_TOTAL_PRICE'));
                    me.myStore.vCustOrder.clearFilter();

                    arrYAxis.push({
                        name: arrXAxis[i],
                        type: 'bar',
                        data: [m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12],
                        markPoint: {
                            data: [{
                                type: 'max',
                                name: '最大值'
                            }, {
                                type: 'min',
                                name: '最小值'
                            }]
                        },
                        markLine: {
                            data: [{
                                type: 'average',
                                name: '平均值'
                            }]
                        }
                    });
                };




                var subText = '';
                if (me.down('#dfStart').getValue() != undefined && me.down('#dfStart').getValue() != '') {
                    subText += me.down('#dfStart').getValue().getFullYear();
                };
                if ($("#" + me.down('#pnlBar').id) != undefined) {
                    $("#" + me.down('#pnlBar').id).html('');
                }
                var myCpuChart = ec.init(document.getElementById(me.down('#pnlBar').id));
                var option = {
                    title: {
                        text: me.down('#cmbYear').getValue() + '年 各月銷售長條圖'
                    },
                    tooltip: {
                        trigger: 'axis'
                    },
                    legend: {
                        data: arrXAxis //['蒸发量', '降水量']
                    },
                    toolbox: {
                        show: true,
                        feature: {
                            magicType: {
                                show: true,
                                type: ['line', 'bar']
                            },
                            restore: {
                                show: false
                            },
                            saveAsImage: {
                                show: true
                            }
                        }
                    },
                    calculable: false,
                    xAxis: [{
                        type: 'category',
                        data: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月']
                    }],
                    yAxis: [{
                        type: 'value'
                    }],
                    series: arrYAxis
                };
                myCpuChart.setOption(option);

            }
        );
        //echart end
        //this.fnChartB();
    },
    fnChartB: function() {
        var me = this;
        require(
            [
                'echarts',
                'echarts/chart/pie',
                'echarts/chart/funnel'
            ],
            function(ec) {
                var arrXAxis = [];
                var arrXAxisUuid = [];
                var arrYAxis = [];
                var keyXAxiz = '';

                Ext.each(me.myStore.vCustOrder.data.items, function(item) {
                    if (keyXAxiz.indexOf(item.data.CUST_UUID) == -1) {
                        arrXAxisUuid.push(item.data.CUST_UUID);
                        arrXAxis.push(item.data.CUST_NAME);
                        keyXAxiz += item.data.CUST_UUID + '|';
                    }
                });

                for (var i = 0; i < arrXAxisUuid.length; i++) {
                    me.myStore.vCustOrder.filterBy(function(record, id) {
                        if (record.data.CUST_UUID == arrXAxisUuid[i]) {
                            return true;
                        } else {
                            return false;
                        }
                    });

                    var sumValue = parseFloat(me.myStore.vCustOrder.sum('CUST_ORDER_TOTAL_PRICE'));

                    arrYAxis.push({
                        value: sumValue,
                        name: arrXAxis[i]
                    });

                    me.myStore.vCustOrder.clearFilter();
                };
                var subText = '';
                console.log(arrYAxis);
                // if ($("#" + me.down('#pnlPie').id) != undefined) {
                //     $("#" + me.down('#pnlPie').id).html('');
                // }
                var myPieChart = ec.init(document.getElementById(me.down('#pnlPie').id));
                var option = {
                    title: {
                        text: me.down('#cmbYear').getValue() + '年 總銷售圓餅圖',
                        x: 'center'
                    },
                    tooltip: {
                        trigger: 'item',
                        formatter: "{a} <br/>{b} : {c} ({d}%)"
                    },
                    legend: {
                        orient: 'vertical',
                        x: 'left',
                        data: arrXAxis
                    },
                    toolbox: {
                        show: true,
                        feature: {
                            mark: {
                                show: false
                            },
                            dataView: {
                                show: false,
                                readOnly: false
                            },
                            magicType: {
                                show: false,
                                type: ['pie', 'funnel'],
                                option: {
                                    funnel: {
                                        x: '25%',
                                        width: '50%',
                                        funnelAlign: 'left',
                                        max: 1548
                                    }
                                }
                            },
                            restore: {
                                show: false
                            },
                            saveAsImage: {
                                show: true
                            }
                        }
                    },
                    calculable: true,
                    series: [{
                        name: '访问来源',
                        type: 'pie',
                        radius: '55%',
                        center: ['50%', '60%'],
                        data: arrYAxis
                    }]
                };
                myPieChart.setOption(option);

                me.fnChartA();

            }
        );
        //echart end

    },
    listeners: {
        afterrender: function(obj, eOpts) {
            var cmbYearStore = this.down('#cmbYear').getStore();
            var today = new Date();
            for (var i = 2000; i <= today.getFullYear(); i++) {
                cmbYearStore.insert(0, {
                    text: i,
                    value: i
                });
            };

            this.down('#cmbYear').setValue(today.getFullYear());
            this.down('#dfStart').setValue(today.getFullYear() + "/01/01");
            this.down("#dfEnd").setValue(today.getFullYear() + "/12/31");

            this.myStore.vCustOrder.getProxy().setExtraParam('pStartDate', this.down('#dfStart').getValue());
            this.myStore.vCustOrder.getProxy().setExtraParam('pEndDate', this.down("#dfEnd").getValue());
            this.myStore.company.load();
            this.myStore.vCustOrder.load({
                callback: this.fnChartB,
                scope: this
            });
            this.myStore.cust.load();
            this.myStore.custOrg.load();


        }
    }
});
