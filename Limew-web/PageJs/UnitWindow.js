/*columns 使用default*/
Ext.define('WS.UnitWindow', {
    extend: 'Ext.window.Window',
    icon: SYSTEM_URL_ROOT + '/css/custimages/unit16x16.png',
    title: '單位維護',
    closable: false,
    closeAction: 'destroy',
    param: {
        unitUuid: undefined
    },
    height: 380,
    width: 550,
    layout: 'fit',
    resizable: false,
    draggable: false,
    initComponent: function() {
        this.items = [Ext.create('Ext.form.Panel', {
            api: {
                load: WS.UnitAction.infoUnit,
                submit: WS.UnitAction.submitUnit
            },
            itemId: 'UnitForm',
            paramOrder: ['pUnitUuid'],
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
                    fieldLabel: '單位',
                    name: 'UNIT_NAME',
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
                    name: 'UNIT_IS_ACTIVE',
                    inputValue: '1',
                    checked: true
                }, {
                    boxLabel: '否',
                    name: 'UNIT_IS_ACTIVE',
                    inputValue: '0',
                    padding: '0 0 0 60'
                }]
            }, {
                xtype: 'hiddenfield',
                fieldLabel: 'UNIT_UUID',
                name: 'UNIT_UUID',
                maxLength: 84,
                itemId: 'UNIT_UUID'
            }],
            buttons: [{
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存',
                handler: function() {
                    var _main = this.up('window').down("#UnitForm"),
                        form = _main.getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            this.param.unitUuid = action.result.UNIT_UUID;
                            this.down("#UNIT_UUID").setValue(action.result.UNIT_UUID);
                            Ext.MessageBox.show({
                                title: '維護單位',
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
                icon: SYSTEM_URL_ROOT + '/css/custimages/exit16x16.png',
                text: '關閉',
                handler: function() {
                    this.up('window').hide();
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
            if (this.param.unitUuid != undefined) {
                this.down("#UnitForm").getForm().load({
                    params: {
                        'pUnitUuid': this.param.unitUuid
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
                this.down('#UnitForm').getForm().reset();
            };
        },
        'hide': function() {
            Ext.getBody().unmask();
            this.closeEvent();
        }
    }
});
