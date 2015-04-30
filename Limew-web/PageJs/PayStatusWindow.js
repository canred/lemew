/*columns 使用default*/
Ext.define('WS.PayStatusWindow', {
    extend: 'Ext.window.Window',
    icon: SYSTEM_URL_ROOT + '/css/custimages/money16x16.png',
    title: '付款狀態維護',
    closable: false,
    closeAction: 'destroy',
    modal: true,
    param: {
        payStatusUuid: undefined
    },
    height: 380,
    width: 550,
    layout: 'fit',
    resizable: false,
    draggable: false,
    initComponent: function() {
        this.items = [Ext.create('Ext.form.Panel', {
            api: {
                load: WS.PayStatusAction.infoPayStatus,
                submit: WS.PayStatusAction.submitPayStatus
            },
            itemId: 'frmPayStatus',
            paramOrder: ['pPayStatusUuid'],
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
                    fieldLabel: '付款狀態名稱',
                    name: 'PAY_STATUS_NAME',
                    maxLength: 84,
                    allowBlank: false
                }, {
                    xtype: 'numberfield',
                    fieldLabel: '順序',
                    name: 'PAY_STATUS_ORD',
                    maxLength: 84,
                    allowBlank: false
                }]
            }, {
                xtype: 'hiddenfield',
                fieldLabel: 'PAY_STATUS_UUID',
                name: 'PAY_STATUS_UUID',
                maxLength: 84,
                itemId: 'PAY_STATUS_UUID'
            }],
            buttons: [{
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存',
                handler: function() {
                    var _main = this.up('window').down("#frmPayStatus"),
                        form = _main.getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            this.param.payStatusUuid = action.result.PAY_STATUS_UUID;
                            this.down("#PAY_STATUS_UUID").setValue(action.result.PAY_STATUS_UUID);
                            Ext.MessageBox.show({
                                title: '維護付款狀態',
                                msg: '操作完成',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                fn: function() {
                                    this.close();
                                },
                                scope: this
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
            if (this.param.payStatusUuid != undefined) {
                this.down("#frmPayStatus").getForm().load({
                    params: {
                        'pPayStatusUuid': this.param.payStatusUuid
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
                this.down('#frmPayStatus').getForm().reset();
            };
        },
        'close': function() {
            this.closeEvent();
            this.down('form').reset();
        }
    }
});
