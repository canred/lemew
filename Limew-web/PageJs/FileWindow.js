Ext.define('WS.FileWindow', {
    extend: 'Ext.window.Window',
    title: '檔案備註',
    icon: SYSTEM_URL_ROOT + '/css/custimages/box16x16.png',
    closeAction: 'destroy',
    closable: false,
    modal: true,
    param: {
        fileUuid: undefined,
        parentObj: undefined
    },
    width: 500,
    height: 300,
    layout: 'fit',
    resizable: false,
    draggable: false,
    initComponent: function() {
        this.items = [
            Ext.create('Ext.form.Panel', {
                api: {
                    load: WS.FileAction.infoFile,
                    submit: WS.FileAction.submitFile
                },
                itemId: 'FileForm',
                paramOrder: ['pFileUuid'],
                autoScroll: false,
                border: true,
                bodyPadding: 5,
                buttonAlign: 'center',
                items: [{
                    xtype: 'container',
                    layout: 'vbox',
                    defaultType: 'textfield',
                    defaults: {
                        width: 450
                    },
                    items: [{
                        xtype: 'textfield',
                        fieldLabel: '檔案名稱',
                        itemId: 'FILE_NAME',
                        name: 'FILE_NAME',
                        padding: 5,
                        anchor: '0 0',
                        maxLength: 50,
                        allowBlank: false,
                        labelAlign: 'right',
                        readOnly: true
                    }, {
                        xtype: 'textarea',
                        selectOnFocus: true,
                        fieldLabel: '檔案備註',
                        labelWidth: 100,
                        height: 170,
                        name: 'FILE_PS',
                        padding: 5,
                        anchor: '0 0',
                        labelAlign: 'right'
                    }]
                }, {
                    xtype: 'hiddenfield',
                    fieldLabel: 'FILE_UUID',
                    name: 'FILE_UUID',
                    padding: 5,
                    anchor: '100%',
                    maxLength: 84,
                    itemId: 'FILE_UUID'
                }, {
                    xtype: 'hiddenfield',
                    fieldLabel: 'FILEGROUP_UUID',
                    name: 'FILEGROUP_UUID',
                    padding: 5,
                    anchor: '100%',
                    maxLength: 84,
                    itemId: 'FILEGROUP_UUID'
                }],
                fbar: [{
                    type: 'button',
                    icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                    text: '儲存',
                    handler: function() {
                        var form = this.up('window').down("#FileForm").getForm();
                        if (form.isValid() == false) {
                            return;
                        };
                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                this.param.fileUuid = action.result.FILE_UUID;
                                this.down("#FILE_UUID").setValue(action.result.FILE_UUID);
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
                }, 
                // {
                //     type: 'button',
                //     icon: SYSTEM_URL_ROOT + '/css/images/delete16x16.png',
                //     text: '刪除',
                //     handler: function() {
                //         var mainWin = this.up('window');
                //         Ext.MessageBox.confirm('刪除此檔案', '確定要刪除這一個檔案?', function(result) {
                //             if (result == 'yes') {
                //                 var fileUuid = mainWin.param.fileUuid;
                //                 WS.FileAction.destoryFile(fileUuid, function(obj, jsonObj) {
                //                     if (jsonObj.result.success) {
                //                         this.close();
                //                     } else {
                //                         Ext.MessageBox.show({
                //                             title: '刪除檔案操作(1503100944)，造成原因可能是此資料已被使用!',
                //                             icon: Ext.MessageBox.INFO,
                //                             buttons: Ext.Msg.OK,
                //                             msg: jsonObj.result.message
                //                         });
                //                     }
                //                 }, mainWin);
                //             }
                //         });
                //     }
                // },
                 {
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
            if (this.param.fileUuid != undefined) {
                this.down("#FileForm").getForm().load({
                    params: {
                        'pFileUuid': this.param.fileUuid
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
                this.down("#FileForm").getForm().reset();

            };
        },
        'close': function() {
            this.closeEvent();
        }
    }
});
