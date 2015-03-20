Ext.define('WS.CustOrgWindow', {
    extend: 'Ext.window.Window',
    title: '單位採購人員維護',
    icon: SYSTEM_URL_ROOT + '/css/custimages/custOrg16x16.png',
    closeAction: 'destroy',
    closable: false,
    param: {
        custOrgUuid: undefined,
        custUuid: undefined
    },
    width: 1000,
    height: 450,
    layout: 'fit',
    resizable: false,
    draggable: false,
    initComponent: function() {
        this.items = [
            Ext.create('Ext.form.Panel', {
                api: {
                    load: WS.CustAction.infoCustOrg,
                    submit: WS.CustAction.submitCustOrg
                },
                itemId: 'CustOrgForm',
                paramOrder: ['pCustOrgUuid'],
                autoScroll: true,
                border: true,
                //bodyPadding: 5,
                buttonAlign: 'center',
                items: [{
                    xtype: 'container',
                    layout: 'vbox',
                    defaultType: 'textfield',
                    defaults: {
                        width: 950
                    },
                    items: [{
                        xtype: 'textfield',
                        fieldLabel: '單位',
                        itemId: 'CUST_ORG_NAME',
                        name: 'CUST_ORG_NAME',
                        padding: '5 0 0 0',
                        anchor: '0 0',
                        maxLength: 12,
                        allowBlank: false,
                        labelAlign: 'right'
                    }, {
                        fieldLabel: '採購人員',
                        labelWidth: 100,
                        name: 'CUST_ORG_SALES_NAME',
                        padding: '5 0 0 0',
                        anchor: '0 0',
                        labelAlign: 'right'
                    }, {
                        fieldLabel: '電話',
                        labelWidth: 100,
                        name: 'CUST_ORG_SALES_PHONE',
                        padding: '5 0 0 0',
                        anchor: '0 0',
                        labelAlign: 'right'
                    }, {
                        fieldLabel: 'Email',
                        labelWidth: 100,
                        name: 'CUST_ORG_SALES_EMAIL',
                        padding: '5 0 0 0',
                        anchor: '0 0',
                        labelAlign: 'right'
                    }, {
                        fieldLabel: '地址',
                        labelWidth: 100,
                        name: 'CUST_ORG_ADDRESS',
                        padding: '5 0 0 0',
                        anchor: '0 0',
                        labelAlign: 'right'
                    }, {
                        xtype: 'fieldcontainer',
                        labelAlign: 'right',
                        fieldLabel: '有效',
                        layout: 'hbox',
                        defaults: {
                            margins: '0 10 0 0'
                        },
                        defaultType: 'radiofield',
                        items: [{
                            xtype: 'radiofield',
                            boxLabel: '啟用',
                            inputValue: '1',
                            name: 'CUST_ORG_IS_ACTIVE',
                            checked: true,
                            flex: 2,
                        }, {
                            xtype: 'radiofield',
                            boxLabel: '不啟用',
                            inputValue: '0',
                            name: 'CUST_ORG_IS_ACTIVE',
                            flex: 2,
                        }]
                    }, {
                        xtype: 'textarea',
                        fieldLabel: '備註',
                        name: 'CUST_ORG_PS',
                        autoWidth: true,
                        anchor: '97% -250',
                        labelAlign: 'right',
                        selectOnFocus: true
                    }]
                }, {
                    xtype: 'hidden',
                    fieldLabel: 'CUST_UUID',
                    name: 'CUST_UUID',
                    padding: '5 0 0 0',
                    anchor: '100%',
                    maxLength: 84,
                    itemId: 'CUST_UUID'
                }, {
                    xtype: 'hidden',
                    fieldLabel: 'CUST_ORG_UUID',
                    name: 'CUST_ORG_UUID',
                    padding: '5 0 0 0',
                    anchor: '100%',
                    maxLength: 84,
                    itemId: 'CUST_ORG_UUID'
                }],
                fbar: [{
                    type: 'button',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                    text: '儲存',
                    handler: function() {
                        var form = this.up('window').down("#CustOrgForm").getForm();
                        if (form.isValid() == false) {
                            return;
                        };
                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                this.param.custOrgUuid = action.result.CUST_ORG_UUID;
                                this.down("#CUST_ORG_UUID").setValue(action.result.CUST_ORG_UUID);
                                Ext.MessageBox.show({
                                    title: '操作完成',
                                    msg: '操作完成',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK
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
                        Ext.MessageBox.confirm('刪除單位採購人員操作', '確定要刪除這一個單位採購人員資訊?', function(result) {
                            if (result == 'yes') {
                                var custOrgUuid = mainWin.param.custOrgUuid;
                                WS.CustAction.destoryCustOrg(custOrgUuid, function(obj, jsonObj) {
                                    if (jsonObj.result.success) {
                                        this.close();
                                    } else {
                                        Ext.MessageBox.show({
                                            title: '刪除單位採購人員操作(15003011811)，造成原因可能是此資料已被使用!',
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
            })
        ]
        this.callParent(arguments);
    },
    closeEvent: function() {
        this.fireEvent('closeEvent', this);
    },
    listeners: {
        'show': function() {

            if (this.param.parentObj) {
                this.param.parentObj.mask();
            };



            if (this.param.custOrgUuid != undefined) {

                this.down("#CustOrgForm").getForm().load({
                    params: {
                        'pCustOrgUuid': this.param.custOrgUuid
                    },
                    success: function(response, a, b) {},
                    failure: function(response, jsonObj, b) {
                        if (!jsonObj.result.success) {
                            Ext.MessageBox.show({
                                title: 'Warning',
                                icon: Ext.MessageBox.WARNING,
                                buttons: Ext.Msg.OK,
                                msg: jsonObj.result.message
                            });
                        };
                    }
                });




            } else {
                this.down("#CustOrgForm").getForm().reset();

            };

            this.down('#CUST_UUID').setValue(this.param.custUuid);
        },
        'close': function() {
            if (this.param.parentObj) {
                this.param.parentObj.unmask();
            };
            this.closeEvent();
        }
    }
});
