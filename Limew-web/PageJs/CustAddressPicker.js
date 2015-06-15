Ext.define('WS.CustAddressPicker', {
    extend: 'Ext.window.Window',
    title: '出貨地址挑選',
    closeAction: 'destroy',
    width: 600,
    height: 400,
    modal: true,
    resizable: false,
    draggable: false,
    param: {
        custUuid: undefined,
        custOrgUuid: undefined,
        parentObj: undefined
    },
    myStore: {
        vCustAddress: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: 'V_CUST_ADDRESS',
            remoteSort: true,
            pageSize: 999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CustAction.loadVCustAddress
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pCustUuid', 'pCustOrgUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    'pCustUuid': '',
                    'pCustOrgUuid': ''
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
                property: 'CUST_ADDRESS',
                direction: 'ASC'
            }]
        })
    },
    /*定義事件的方法*/
    initComponent: function() {
        var me = this;
        me.items = [{
            xtype: 'panel',
            items: [{
                xtype: 'gridpanel',
                autoScroll: true,
                columns: [
                    // {
                    //     text: "選擇",
                    //     xtype: 'actioncolumn',
                    //     dataIndex: 'CUST_ADDRESS',
                    //     align: 'center',
                    //     width: 80,
                    //     items: [{
                    //         tooltip: '*選擇',
                    //         icon: SYSTEM_URL_ROOT + '/css/images/mouseSelect16x16.png',
                    //         handler: function(grid, rowIndex, colIndex) {
                    //             var mainWin = grid.up('window');
                    //             //取得當前行的欄位資訊     
                    //             mainWin.fireEvent('closeEvent', mainWin, grid.getStore().getAt(rowIndex).data.CUST_ADDRESS);
                    //             mainWin.close();
                    //         }
                    //     }],
                    //     sortable: false,
                    //     hideable: false
                    // }, 
                    {
                        xtype: 'templatecolumn',
                        text: '選擇',
                        width: 100,
                        sortable: false,
                        hideable: false,
                        tpl: new Ext.XTemplate(
                            "<tpl >",
                            '{[this.fnInit()]}<input type="button" style="width:80px" value="選擇" onclick="CustAddressPickerFnPickerHandler(\'{CUST_ADDRESS}\')"/>',
                            "</tpl>", {
                                scope: this,
                                fnInit: function() {
                                    document.CustAddressPicker = this.scope;
                                    if (!document.CustAddressPickerFnPickerHandler) {
                                        document.CustAddressPickerFnPickerHandler = function(CUST_ADDRESS) {
                                            // var mainWin = document.CustAddressPicker;
                                            // mainWin.selectedEvent(mainWin, CUST_UUID, CUST_ORG_UUID);

                                            var mainWin = document.CustAddressPicker;
                                            //取得當前行的欄位資訊     
                                            mainWin.fireEvent('closeEvent', mainWin, CUST_ADDRESS);
                                            mainWin.close();
                                        }
                                    }
                                }
                            })
                    }, {
                        text: "地址",
                        dataIndex: 'CUST_ADDRESS',
                        align: 'left',
                        flex: 4
                    }
                ],
                flex: 1,
                store: this.myStore.vCustAddress,
                minHeight: 360,
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: this.myStore.vCustAddress,
                    displayInfo: true,
                    displayMsg: '第{0}~{1}資料/共{2}筆',
                    emptyMsg: "無資料顯示"
                }),
                listeners: {
                    cellclick: function(iView, iCellEl, iColIdx, iRecord, iRowEl, iRowIdx, iEvent) {

                    }
                }
            }]
        }];
        me.callParent(arguments);
    },
    closeEvent: function() {
        //this.fireEvent('closeEvent', this);
    },
    listeners: {
        'show': function() {
            var proxy = this.myStore.vCustAddress.getProxy();
            proxy.setExtraParam("pCustUuid", this.param.custUuid);
            proxy.setExtraParam("pCustOrgUuid", this.param.custOrgUuid);
            this.myStore.vCustAddress.reload();
        },
        close: function() {
            this.myStore.vCustAddress.removeAll();
        }

    }
});
