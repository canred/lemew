/*columns 使用default*/
Ext.define('WS.GcategoryWindow', {
    extend: 'Ext.window.Window',
    icon: SYSTEM_URL_ROOT + '/css/images/manb16x16.png',
    title: '商品類別維護',
    closable: false,
    closeAction: 'destroy',
    modal: true,
    param: {
        gcategoryUuid: undefined,
        gcategoryParentUuid: undefined
    },
    height: 200,
    width: 550,
    layout: 'fit',
    resizable: false,
    draggable: false,
    initComponent: function() {
        /*gcategoryUuid的參數設check*/
        this.items = [Ext.create('Ext.form.Panel', {
            layout: {
                type: 'form',
                align: 'stretch'
            },
            api: {
                load: WS.GcategoryAction.infoGcategory,
                submit: WS.GcategoryAction.submitGcategory
            },
            itemId: 'GcategoryForm',
            paramOrder: ['pGcategoryUuid'],
            border: true,
            autoScroll: true,
            defaultType: 'textfield',
            buttonAlign: 'center',
            items: [{
                xtype: 'container',
                layout: 'anchor',
                defaultType: 'textfield',
                items: [{
                    fieldLabel: '類別名稱',
                    labelAlign: 'right',
                    labelWidth: 100,
                    name: 'GCATEGORY_NAME',
                    anchor: '-50 0',
                    maxLength: 84,
                    allowBlank: false
                }, {
                    xtype: 'hiddenfield',
                    fieldLabel: 'GCATEGORY_PARENT_UUID',
                    name: 'GCATEGORY_PARENT_UUID',
                    itemId: 'GCATEGORY_PARENT_UUID'
                }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                defaultType: 'radiofield',
                items: [{
                    fieldLabel: '啟用',
                    labelAlign: 'right',
                    boxLabel: '是',
                    name: 'GCATEGORY_IS_ACTIVE',
                    checked: true,
                    inputValue: '1',
                }, {
                    boxLabel: '否',
                    name: 'GCATEGORY_IS_ACTIVE',
                    inputValue: '0',
                    padding: '0 0 0 60'
                }]
            }, {
                xtype: 'hidden',
                fieldLabel: 'GCATEGORY_UUID',
                name: 'GCATEGORY_UUID',
                padding: 5,
                anchor: '100%',
                maxLength: 84,
                itemId: 'GCATEGORY_UUID'
            }],
            fbar: [{
                type: 'button',
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存',
                handler: function() {
                    var _main = this.up('window').down("#GcategoryForm"),
                        form = _main.getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            this.param.gcategoryUuid = action.result.GCATEGORY_UUID;
                            this.down("#GCATEGORY_UUID").setValue(action.result.GCATEGORY_UUID);
                            Ext.MessageBox.show({
                                title: '商品類別',
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
                type: 'button',
                icon: SYSTEM_URL_ROOT + '/css/custimages/exit16x16.png',
                text: '關閉',
                handler: function() {
                    this.up('window').close();
                }
            }]
        })]
        this.callParent(arguments);
    },
    closeEvent: function() {
        this.fireEvent('closeEvent', this);
    },
    listeners: {
        'show': function() {
            if (this.param.gcategoryUuid != undefined) {
                this.down("#GcategoryForm").getForm().load({
                    params: {
                        'pGcategoryUuid': this.param.gcategoryUuid
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
                this.down('#GcategoryForm').getForm().reset();
                this.down("#GCATEGORY_PARENT_UUID").setValue(this.param.gcategoryParentUuid);
            }
        },
        'close': function() {
            this.closeEvent();
            this.down('form').reset();
        }
    }
});
