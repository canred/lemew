/*columns 使用default*/
Ext.define('WS.ShippingStatusWindow', {
    extend: 'Ext.window.Window',
    icon: SYSTEM_URL_ROOT + '/css/custimages/shippingStatus16x16.png',
    title: '出貨狀態維護',
    closable: false,
    closeAction: 'destroy',
    param: {
        shippingStatusUuid: undefined
    },
    height: 380,
    width: 550,
    layout: 'fit',
    resizable: false,
    draggable: false,
    initComponent: function() {
        this.items = [Ext.create('Ext.form.Panel', {
            api: {
                load: WS.ShippingStatusAction.infoShippingStatus,
                submit: WS.ShippingStatusAction.submitShippingStatus
            },
            itemId: 'frmShippingStatus',
            paramOrder: ['pShippingStatusUuid'],
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
                    fieldLabel: '出貨狀態名稱',
                    name: 'SHIPPING_STATUS_NAME',
                    maxLength: 84,
                    allowBlank: false
                },{
                    xtype:'numberfield',
                    fieldLabel: '順序',
                    name: 'SHIPPING_STATUS_ORD',
                    maxLength: 84,
                    allowBlank: false
                }]
            }, {
                xtype: 'hiddenfield',
                fieldLabel: 'SHIPPING_STATUS_UUID',
                name: 'SHIPPING_STATUS_UUID',
                maxLength: 84,
                itemId: 'SHIPPING_STATUS_UUID'
            }],
            buttons: [{
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存',
                handler: function() {
                    var _main = this.up('window').down("#frmShippingStatus"),
                        form = _main.getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            this.param.shippingStatusUuid = action.result.SHIPPING_STATUS_UUID;
                            this.down("#SHIPPING_STATUS_UUID").setValue(action.result.SHIPPING_STATUS_UUID);
                            Ext.MessageBox.show({
                                title: '維護出貨狀態',
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
            if (this.param.shippingStatusUuid != undefined) {
                this.down("#frmShippingStatus").getForm().load({
                    params: {
                        'pShippingStatusUuid': this.param.shippingStatusUuid
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
                this.down('#frmShippingStatus').getForm().reset();
            };
        },
        'close': function() {
            Ext.getBody().unmask();
            this.closeEvent();
        }
    }
});
