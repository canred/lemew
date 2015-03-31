/*columns 使用default*/
Ext.define('WS.PayMethodWindow', {
    extend: 'Ext.window.Window',
    icon: SYSTEM_URL_ROOT + '/css/custimages/payMethod16x16.png',
    title: '付款方式維護',
    closable: false,
    closeAction: 'destroy',
    param: {
        payMethodUuid: undefined
    },
    height: 380,
    width: 550,
    layout: 'fit',
    resizable: false,
    draggable: false,
    initComponent: function() {
        this.items = [Ext.create('Ext.form.Panel', {
            api: {
                load: WS.PayMethodAction.infoPayMethod,
                submit: WS.PayMethodAction.submitPayMethod
            },
            itemId: 'frmPayMethod',
            paramOrder: ['pPayMethodUuid'],
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
                    fieldLabel: '付款方式名稱',
                    name: 'PAY_METHOD_NAME',
                    maxLength: 84,
                    allowBlank: false
                },{
                    xtype:'numberfield',
                    fieldLabel: '順序',
                    name: 'PAY_METHOD_ORD',
                    maxLength: 84,
                    allowBlank: false
                }]
            }, {
                xtype: 'hiddenfield',
                fieldLabel: 'PAY_METHOD_UUID',
                name: 'PAY_METHOD_UUID',
                maxLength: 84,
                itemId: 'PAY_METHOD_UUID'
            }],
            buttons: [{
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存',
                handler: function() {
                    var _main = this.up('window').down("#frmPayMethod"),
                        form = _main.getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            this.param.payMethodUuid = action.result.PAY_METHOD_UUID;
                            this.down("#PAY_METHOD_UUID").setValue(action.result.PAY_METHOD_UUID);
                            Ext.MessageBox.show({
                                title: '維護付款方式',
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
            Ext.getBody().mask();
            if (this.param.payMethodUuid != undefined) {
                this.down("#frmPayMethod").getForm().load({
                    params: {
                        'pPayMethodUuid': this.param.payMethodUuid
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
                this.down('#frmPayMethod').getForm().reset();
            };
        },
        'close': function() {
            Ext.getBody().unmask();
            this.closeEvent();
        }
    }
});
