Ext.define('WS.CustOrderPsWindow', {
    extend: 'Ext.window.Window',
    title: '訂單備註',
    closeAction: 'destory',
    width: 400,
    height: 300,
    resizable: false,
    draggable: false,
    modal: true,
    param: {
        custOrderUuid: undefined
    },
    /*定義事件的方法*/
    initComponent: function() {
        this.items = [{
            xtype: 'form',
            api: {
                load: WS.CustAction.infoCustActioForPs,
                submit: WS.CustAction.submitCustOrderForPs
            },
            itemId: 'frmCustOrder',
            paramOrder: ['pCustOrderUuid'],
            autoScroll: true,
            border: true,

            buttonAlign: 'center',
            items: [{
                xtype: 'fieldset',
                title: '備註',
                border: true,
                items: [{
                    xtype: 'textarea',
                    name: 'CUST_ORDER_PS',
                    selectOnFocus: true,
                    height: 180,
                    width: 370
                }]
            }, {
                xtype: 'hiddenfield',
                name: 'CUST_ORDER_UUID'
            }],
            buttonAlign: 'center',
            buttons: [{
                xtype: 'button',
                text: '儲存',
                handler: function(handler, scope) {
                    var mainWin = this.up('window'),
                        form = mainWin.down('form').getForm();
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            this.param.changed = true;
                            if (this.param.changed) {
                                this.fireEvent('closeEvent', this);
                                this.close();
                            } else {
                                this.close();
                            };
                        },
                        failure: function(form, action) {
                            Ext.MessageBox.show({
                                title: 'System Error',
                                msg: action.result.message,
                                icon: Ext.MessageBox.ERROR,
                                buttons: Ext.Msg.OK
                            });
                        },
                        scope: mainWin
                    });
                }
            }, {
                xtype: 'button',
                text: '關閉',
                handler: function(handler, scope) {

                    var mainWin = this.up('window');
                    if (mainWin.param.changed) {
                        mainWin.fireEvent('closeEvent', mainWin);
                        mainWin.close();
                    } else {
                        mainWin.close();
                    };
                }
            }]
        }];
        this.callParent(arguments);
    },
    listeners: {
        'show': function() {
            var form = this.down('form').getForm();
            this.param.changed = false;
            this.mask('資訊載入中…請稍後…');
            //alert(this.param.custOrderUuid);
            if (!this.param.custOrderUuid) {
                return;
            }

            form.load({
                params: {
                    'pCustOrderUuid': this.param.custOrderUuid
                },
                success: function(response, a, b) {
                	this.unmask();
                },
                failure: function(response, jsonObj, b) {
                    if (!jsonObj.result.success) {
                        Ext.MessageBox.show({
                            title: 'Warning',
                            icon: Ext.MessageBox.WARNING,
                            buttons: Ext.Msg.OK,
                            msg: jsonObj.result.message
                        });
                    };
                },
                scope: this
            });
        }
    }
});
