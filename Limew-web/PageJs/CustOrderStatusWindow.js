/*columns 使用default*/
Ext.define('WS.CustOrderStatusWindow', {
    extend: 'Ext.window.Window',
    icon: SYSTEM_URL_ROOT + '/css/custimages/list16x16.png',
    title: '訂單狀態維護',
    closable: false,
    closeAction: 'destroy',
    param: {
        custOrderStatusUuid: undefined
    },
    height: 380,
    modal: true,
    width: 550,
    layout: 'fit',
    resizable: false,
    draggable: false,
    initComponent: function() {
        this.items = [Ext.create('Ext.form.Panel', {
            api: {
                load: WS.CustOrderStatusAction.infoCustOrderStatus,
                submit: WS.CustOrderStatusAction.submitCustOrderStatus
            },
            itemId: 'frmCustOrderStatus',
            paramOrder: ['pCustOrderStatusUuid'],
            border: true,
            defaultType: 'textfield',
            buttonAlign: 'center',
            items: [{
                xtype: 'container',
                layout: 'anchor',
                margin: '5 0 0 0',
                defaultType: 'textfield',
                defaults: {
                    anchor: '-20 0',
                    labelAlign: 'right',
                    labelWidth: 100
                },
                items: [{
                    fieldLabel: '狀態名稱',
                    name: 'CUST_ORDER_STATUS_NAME',
                    maxLength: 84,
                    allowBlank: false
                },{
                    xtype:'numberfield',
                    fieldLabel: '順序',
                    name: 'CUST_ORDER_STATUS_ORD',
                    maxLength: 84,
                    allowBlank: false
                }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                defaultType: 'radiofield',
                defaults: {
                    labelAlign: 'right'
                },
                items: [{
                    fieldLabel: '有效',
                    boxLabel: '是',
                    name: 'CUST_ORDER_STATUS_IS_ACTIVE',
                    inputValue: '1',
                    checked: true
                }, {
                    boxLabel: '否',
                    name: 'CUST_ORDER_STATUS_IS_ACTIVE',
                    inputValue: '0',
                    padding: '0 0 0 60'
                }]
            }, {
                xtype: 'hiddenfield',
                fieldLabel: 'CUST_ORDER_STATUS_UUID',
                name: 'CUST_ORDER_STATUS_UUID',
                maxLength: 84,
                itemId: 'CUST_ORDER_STATUS_UUID'
            }],
            buttons: [{
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存',
                handler: function() {
                    var _main = this.up('window').down("#frmCustOrderStatus"),
                        form = _main.getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            this.param.custOrderStatusUuid = action.result.CUST_ORDER_STATUS_UUID;
                            this.down("#CUST_ORDER_STATUS_UUID").setValue(action.result.CUST_ORDER_STATUS_UUID);
                            Ext.MessageBox.show({
                                title: '維護訂單狀態',
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
                icon: SYSTEM_URL_ROOT + '/css/custimages/exit16x16.png',
                text: '關閉',
                handler: function() {
                    this.up('window').close();
                }
            }]
        })];
        this.callParent(arguments);
    },
    closeEvent: function() {
        this.fireEvent('closeEvent', this);
    },
    listeners: {
        'show': function() {
            if (this.param.custOrderStatusUuid != undefined) {
                this.down("#frmCustOrderStatus").getForm().load({
                    params: {
                        'pCustOrderStatusUuid': this.param.custOrderStatusUuid
                    },
                    success: function(response, jsonObj) {},
                    failure: function(response, jsonObj) {
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
                this.down('#frmCustOrderStatus').getForm().reset();
            };
        },
        'close': function() {
            this.closeEvent();
        }
    }
});
