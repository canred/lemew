/*columns 使用default*/
Ext.define('WS.AttendantWindow', {
    extend: 'Ext.window.Window',
    icon: SYSTEM_URL_ROOT + '/css/images/manb16x16.png',
    title: '人員維護',
    closable: false,
    closeAction: 'destroy',
    param: {
        uuid: undefined
    },
    height: 380,
    width: 550,
    layout: 'fit',
    resizable: false,
    draggable: false,
    initComponent: function() {
        this.items = [Ext.create('Ext.form.Panel', {
            api: {
                load: WS.AttendantAction.info,
                submit: WS.AttendantAction.submit
            },
            itemId: 'AttendantForm',
            paramOrder: ['pUuid'],
            border: true,
            defaultType: 'textfield',
            buttonAlign: 'center',
            items: [{
                xtype: 'container',
                layout: 'hbox',
                items: [{
                    xtype: 'container',
                    layout: 'vbox',
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
                            fieldLabel: '帳號',
                            name: 'ACCOUNT',
                            maxLength: 84,
                            allowBlank: false
                        }, {
                            fieldLabel: '密碼',
                            name: 'PASSWORD',
                            maxLength: 84,
                            allowBlank: false
                        }, {
                            fieldLabel: '名稱-繁中',
                            name: 'C_NAME',
                            maxLength: 84,
                            allowBlank: false
                        }, {
                            fieldLabel: '名稱-英文',
                            name: 'E_NAME',
                            maxLength: 340
                        }, {
                            fieldLabel: 'E-Mail',
                            name: 'EMAIL',
                            maxLength: 84,
                            allowBlank: false
                        }, {
                            fieldLabel: '電話',
                            name: 'PHONE',
                            maxLength: 84,
                            allowBlank: true
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        defaultType: 'radiofield',
                        defaults: {
                            labelAlign: 'right'
                        },
                        items: [{
                            fieldLabel: '性別',
                            boxLabel: '男',
                            name: 'GENDER',
                            inputValue: 'M',
                            checked: true
                        }, {
                            boxLabel: '女',
                            name: 'GENDER',
                            inputValue: 'F',
                            padding: '0 0 0 60'
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        defaultType: 'radiofield',
                        defaults: {
                            labelAlign: 'right'
                        },
                        items: [{
                            fieldLabel: '主管',
                            boxLabel: '是',
                            name: 'IS_MANAGER',
                            inputValue: 'Y',
                        }, {
                            boxLabel: '否',
                            name: 'IS_MANAGER',
                            inputValue: 'N',
                            checked: true,
                            padding: '0 0 0 60'
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        defaultType: 'radiofield',
                        defaults: {
                            labelAlign: 'right'
                        },
                        items: [{
                            fieldLabel: '直接人員',
                            boxLabel: '是',
                            name: 'IS_DIRECT',
                            inputValue: 'Y',
                        }, {
                            boxLabel: '否',
                            name: 'IS_DIRECT',
                            inputValue: 'N',
                            checked: true,
                            padding: '0 0 0 60'
                        }]
                    }, {
                        xtype: 'hidden',
                        name: 'IS_SUPPER',
                        value: 'N'
                    }, {
                        xtype: 'hidden',
                        name: 'IS_ADMIN',
                        value: 'N'
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        defaultType: 'radiofield',
                        items: [{
                            fieldLabel: '是否啟用',
                            labelAlign: 'right',
                            boxLabel: '是',
                            name: 'IS_ACTIVE',
                            inputValue: 'Y',
                            checked: true
                        }, {
                            boxLabel: '否',
                            name: 'IS_ACTIVE',
                            inputValue: 'N',
                            padding: '0 0 0 60'
                        }]
                    }, {
                        xtype: 'hiddenfield',
                        fieldLabel: 'UUID',
                        name: 'UUID',
                        maxLength: 84,
                        itemId: 'UUID'
                    }, {
                        xtype: 'hiddenfield',
                        fieldLabel: 'COMPANY_UUID',
                        name: 'COMPANY_UUID',
                        maxLength: 84
                    }, {
                        xtype: 'hiddenfield',
                        fieldLabel: 'ID',
                        name: 'ID',
                        maxLength: 84
                    }]
                }, {
                            xtype: 'container',
                            layout: {
                                type: 'vbox'
                            },
                            width: 200,
                            items: [{
                                xtype: 'image',
                                src: 'https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcS-OXSMwx1armeFFM9jDMTymj3vy418oT96OtmMmnUSmx1swDWzeA',
                                itemId: 'imgUser',
                                tag: "img",
                                height: 140,
                                width: 180,
                                //maxHeight:140,
                                border: true
                            }, {
                                xtype: 'filefield',
                                text: '上傳',
                                emptyText: 'Select an image',
                                width: 180,
                                margin: '3 0 0 0',
                                handler: function(handler, scope) {
                                    //your code
                                }
                            }, {
                                xtype: 'button',
                                width: 180,
                                text: '攝影',
                                margin: '3 0 0 0',
                                handler: function(handler, scope) {
                                    //your code
                                }
                            }]
                        }]
            }, ],
            buttons: [{
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存',
                handler: function() {
                    var _main = this.up('window').down("#AttendantForm"),
                        form = _main.getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            this.param.uuid = action.result.UUID;
                            this.down("#UUID").setValue(action.result.UUID);
                            Ext.MessageBox.show({
                                title: '維護人員',
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
            if (this.param.uuid != undefined) {
                this.down("#AttendantForm").getForm().load({
                    params: {
                        'pUuid': this.param.uuid
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
                this.down('#AttendantForm').getForm().reset();
            };
        },
        'hide': function() {
            Ext.getBody().unmask();
            this.closeEvent();
        }
    }
});
