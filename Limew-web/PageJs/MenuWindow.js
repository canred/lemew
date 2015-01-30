Ext.define('WS.MenuWindow', {
    extend: 'Ext.window.Window',
    title: '選單維護',
    closable: false,
    icon: SYSTEM_URL_ROOT + '/css/images/menu16x16.png',
    closeAction: 'destroy',
    border: true,
    param: {
        uuid: undefined,
        applicationHeadUuid: undefined,
        parentUuid: undefined
    },
    myStore: {
        sitemap: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: Ext.define('SiteMap', {
                extend: 'Ext.data.Model',
                /*:::欄位設定:::*/
                fields: ['UUID', 'IS_ACTIVE', 'CREATE_DATE', 'CREATE_USER', 'UPDATE_DATE', 'UPDATE_USER', 'SITEMAP_UUID', 'APPPAGE_UUID', 'ROOT_UUID', 'HASCHILD', 'APPLICATION_HEAD_UUID', 'NAME', 'DESCRIPTION', 'URL', 'P_MODE', 'PARAMETER_CLASS', 'APPPAGE_IS_ACTIVE']
            }),
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.SiteMapAction.loadThisApplication
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: false,
                paramOrder: ['pApplicationHeadUuid', 'pIsActive', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pApplicationHeadUuid: '',
                    pIsActive: 'Y'
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        Ext.MessageBox.show({
                            title: 'REMOTE EXCEPTION',
                            msg: operation.getError(),
                            icon: Ext.MessageBox.ERROR,
                            buttons: Ext.Msg.OK
                        });
                    }
                }
            },
            listeners: {
                load: function() {
                    this.insert(0, new this.model({
                        'NAME': 'Empty',
                        'UUID': ''
                    }));
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'UUID',
                direction: 'ASC'
            }]
        }),
        menu: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            autoLoad: false,
            model: Ext.define('Menu', {
                extend: 'Ext.data.Model',
                fields: ['UUID', 'IS_ACTIVE', 'CREATE_DATE', 'CREATE_USER', 'UPDATE_DATE', 'UPDATE_USER', 'NAME_ZH_TW', 'NAME_ZH_CN', 'NAME_EN_US', 'ID', 'APPMENU_UUID', 'HASCHILD', 'APPLICATION_HEAD_UUID', 'ORD', 'PARAMETER_CLASS', 'IMAGE', 'SITEMAP_UUID', 'ACTION_MODE', 'IS_DEFAULT_PAGE', 'IS_ADMIN']
            }),
            pageSize: 99999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.MenuAction.loadThisApplicationMenu
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: false,
                paramOrder: ['pApplicationHeadUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pApplicationHeadUuid: ''
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        Ext.MessageBox.show({
                            title: 'REMOTE EXCEPTION',
                            msg: operation.getError(),
                            icon: Ext.MessageBox.ERROR,
                            buttons: Ext.Msg.OK
                        });
                    }
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'NAME_ZH_TW',
                direction: 'ASC'
            }]
        }),
        vappmenuproxymap: Ext.create('Ext.data.Store', {
            extend: 'Ext.data.Store',
            storeId: 'storevappmenuproxymap',
            autoLoad: false,
            model: Ext.define('Vappmenuproxymap', {
                extend: 'Ext.data.Model',
                fields: [
                    'PROXY_UUID',
                    'PROXY_ACTION',
                    'PROXY_METHOD',
                    'PROXY_DESCRIPTION',
                    'PROXY_TYPE',
                    'NEED_REDIRECT',
                    'REDIRECT_PROXY_ACTION',
                    'REDIRECT_PROXY_METHOD',
                    'REDIRECT_SRC',
                    'APPLICATION_HEAD_UUID',
                    'NAME_ZH_TW',
                    'NAME_ZH_CN',
                    'NAME_EN_US',
                    'UUID',
                    'APPMENU_PROXY_UUID',
                    'APPMENU_UUID',
                ]
            }),
            pageSize: 5,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.ProxyAction.loadVAppmenuProxyMap
                },
                reader: {
                    root: 'data'
                },
                writer: {
                    type: 'json',
                    writeAllFields: true,
                    root: 'updatedata'
                },
                paramsAsHash: true,
                paramOrder: ['pApplicationHeadUuid', 'pAppmenuUuid', 'pKeyWord', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    'pApplicationHeadUuid': '',
                    'pAppmenuUuid': '',
                    'pKeyWord': ''
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        Ext.MessageBox.show({
                            title: 'REMOTE EXCEPTON A',
                            msg: operation.getError(),
                            icon: Ext.MessageBox.ERROR,
                            buttons: Ext.Msg.OK
                        });
                    }
                }
            },
            sorters: [{
                property: 'PROXY_ACTION',
                direction: 'ASC'
            }]
        })
    },
    is_operational_boundary: undefined,
    width: $(window).width() * 0.9,
    height: $(window).height() * 0.9,
    maxHeight: 600,
    maxWidth: 700,
    overflowY: 'auto',
    border: false,
    resizable: false,
    draggable: false,
    autoFitErrors: true,
    initComponent: function() {
        this.items = [Ext.create('Ext.form.Panel', {
            padding: '5 25 5 5',
            layout: {
                type: 'form',
                align: 'stretch'
            },
            api: {
                load: WS.MenuAction.info,
                submit: WS.MenuAction.submit,
                destroy: WS.MenuAction.destroyByUuid
            },
            itemId: 'AppMenuForm',
            paramOrder: ['pUuid'],
            border: false,
            defaultType: 'textfield',
            buttonAlign: 'center',
            autoScroll: true,
            monitorvalid: true,
            items: [{
                fieldLabel: '代碼',
                padding: 5,
                allowBlank: false,
                maxLength: 33,
                name: 'ID',
                labelAlign: 'right',
                id: 'Ext.AppMenuForm.Form.ID'
            }, {
                fieldLabel: '排序',
                labelAlign: 'right',
                padding: 5,
                allowBlank: false,
                maxLength: 33,
                name: 'ORD',
                xtype: 'numberfield',
                minValue: 0,
                id: 'Ext_AppMenuForm_Form_ORD'
            }, {
                fieldLabel: '繁中名稱',
                labelAlign: 'right',
                name: 'NAME_ZH_TW',
                padding: 5,
                anchor: '50%',
                allowBlank: false,
                maxLength: 128
            }, {
                fieldLabel: '簡中名稱',
                labelAlign: 'right',
                name: 'NAME_ZH_CN',
                padding: 5,
                anchor: '50%',
                allowBlank: false,
                maxLength: 128
            }, {
                fieldLabel: '英文名稱',
                labelAlign: 'right',
                name: 'NAME_EN_US',
                padding: 5,
                anchor: '50%',
                allowBlank: false,
                maxLength: 128
            }, {
                fieldLabel: '參數',
                labelAlign: 'right',
                name: 'PARAMETER_CLASS',
                padding: 5,
                anchor: '50%',
                allowBlank: true,
                maxLength: 128
            }, {
                fieldLabel: 'Icon路徑',
                labelAlign: 'right',
                name: 'IMAGE',
                padding: 5,
                anchor: '50%',
                allowBlank: true,
                maxLength: 128
            }, {
                xtype: 'fieldcontainer',
                fieldLabel: '行為模式',
                labelAlign: 'right',
                layout: 'hbox',
                defaults: {
                    margins: '0 10 0 0'
                },
                defaultType: 'radiofield',
                items: [{
                    boxLabel: 'Empty',
                    inputValue: '',
                    name: 'ACTION_MODE',
                    checked: true
                }, {
                    boxLabel: 'Edit',
                    inputValue: 'Edit',
                    name: 'ACTION_MODE',
                    margin: '0 0 0 60'
                }, {
                    boxLabel: 'View',
                    inputValue: 'View',
                    name: 'ACTION_MODE',
                    margin: '0 0 0 60'
                }, ]
            }, {
                fieldLabel: '入口網頁',
                xtype: 'combobox',
                labelAlign: 'right',
                id: 'Ext_AppMenuForm_Form_SITEMAP_UUID',
                displayField: 'NAME',
                valueField: 'UUID',
                name: 'SITEMAP_UUID',
                padding: 5,
                editable: false,
                hidden: false,
                store: this.storeSiteMap
            }, {
                fieldLabel: '父選單',
                labelAlign: 'right',
                xtype: 'combobox',

                itemId: 'APPMENU_UUID',
                displayField: 'NAME_ZH_TW',
                valueField: 'UUID',
                name: 'APPMENU_UUID',
                padding: 5,
                editable: false,
                hidden: false,
                store: this.storeMenu,
                value: ' '
            }, {
                xtype: 'fieldcontainer',
                fieldLabel: '預設頁面',
                layout: 'hbox',
                labelAlign: 'right',
                defaults: {
                    margins: '0 10 0 0'
                },
                defaultType: 'radiofield',
                items: [{
                    boxLabel: '是',
                    inputValue: 'Y',
                    name: 'IS_DEFAULT_PAGE'
                }, {
                    boxLabel: '否',
                    inputValue: 'N',
                    name: 'IS_DEFAULT_PAGE',
                    checked: true,
                    margin: '0 0 0 60'
                }]
            }, {
                xtype: 'fieldcontainer',
                fieldLabel: '系統管理員',
                layout: 'hbox',
                labelAlign: 'right',
                defaults: {
                    margins: '0 10 0 0'
                },
                defaultType: 'radiofield',
                items: [{
                    boxLabel: '是',
                    inputValue: 'Y',
                    name: 'IS_ADMIN'
                }, {
                    boxLabel: '否',
                    inputValue: 'N',
                    name: 'IS_ADMIN',
                    checked: true,
                    margin: '0 0 0 60'
                }]
            }, {
                xtype: 'fieldcontainer',
                fieldLabel: '是否啟用',
                labelAlign: 'right',
                layout: 'hbox',
                defaults: {
                    margins: '0 10 0 0'
                },
                defaultType: 'radiofield',
                items: [{
                    boxLabel: '啟用',
                    inputValue: 'Y',
                    name: 'IS_ACTIVE',
                    checked: true
                }, {
                    boxLabel: '不啟用',
                    inputValue: 'N',
                    name: 'IS_ACTIVE',
                    margin: '0 0 0 47'
                }]
            }, {
                /*PK值，必須存在*/
                xtype: 'hidden',
                fieldLabel: 'UUID',
                name: 'UUID',
                itemId: 'UUID'
            }, {
                /*appliction_head_uuid值，必須存在*/
                xtype: 'hidden',
                fieldLabel: 'APPLICATION_HEAD_UUID',
                name: 'APPLICATION_HEAD_UUID',
                itemId: 'APPLICATION_HEAD_UUID'
            }],
            fbar: [{
                type: 'button',
                icon: SYSTEM_URL_ROOT + '/css/custimages/save16x16.png',
                text: '儲存',
                formBind: true,
                handler: function() {
                    var form = this.up('window').down('#AppMenuForm').getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            Ext.MessageBox.show({
                                title: '選擇維護',
                                msg: '操作完成',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                fn: function() {
                                    this.close();
                                }
                            });
                        },
                        failure: function(form, action) {
                            Ext.MessageBox.show({
                                title: 'System Error',
                                msg: action.result.message,
                                icon: Ext.MessageBox.ERROR,
                                buttons: Ext.Msg.OK
                            });
                        },
                        scope: this.up('window')
                    });
                }
            }, {
                itemId: 'btnDelete',
                type: 'button',
                icon: SYSTEM_URL_ROOT + '/css/images/delete16x16.png',
                text: '刪除',
                handler: function() {
                    var form = this.up('window').down('#AppMenuForm').getForm();
                    /*:::變更Submit的方向:::*/
                    form.api.submit = WS.MenuAction.destroy;
                    form.submit({
                        params: {
                            requestAction: 'delete'
                        },
                        waitMsg: '刪除中...',
                        success: function(form, action) {
                            Ext.MessageBox.show({
                                title: '維護部門/營運邊界',
                                msg: '刪除完成',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                fn: function() {
                                    /*:::變更Submit的方向:::*/
                                    form.api.submit = WS.MenuAction.submit;

                                    this.close();
                                }
                            });
                        },
                        failure: function(form, action) {
                            Ext.MessageBox.show({
                                title: 'System Error',
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
        }), {
            xtype: 'tabpanel',
            padding: '5 25 5 5',
            maxWidth: 880,
            plain: true,
            items: [{
                icon: SYSTEM_URL_ROOT + '/css/images/connector16x16.png',
                title: '資源',
                items: [{
                    xtype: 'gridpanel',
                    border: true,
                    tbar: [{
                        type: 'button',
                        icon: SYSTEM_URL_ROOT + '/css/images/add16x16.png',
                        text: '挑選資源',
                        handler: function() {
                            var mainWin = this.up('window');
                            if (WinProxyPicker == undefined) {
                                WinProxyPicker = Ext.create('ProxyPicker', {});
                                WinProxyPicker.on('closeEvent', function(obj) {
                                    if (appMenuForm) {
                                        appMenuForm.unmask();
                                    }
                                });
                                WinProxyPicker.on('selectedEvent', function(obj, jsonObj) {
                                    var appUuid = obj.down('#APPLICATION_HEAD_UUID').getValue();
                                    var menUuid = obj.down('#UUID').getValue();
                                    // var appUuid = Ext.getCmp('Ext.AppMenuForm.Form.APPLICATION_HEAD_UUID').getValue();
                                    // var menUuid = Ext.getCmp('Ext.AppMenuForm.Form.UUID').getValue();
                                    WS.ProxyAction.addAppmenuProxyMap(appUuid, menUuid, jsonObj.UUID, function(obj, jsonObj2) {
                                        if (jsonObj2.result.success) {
                                            WinProxyPicker.hide();
                                            Ext.data.StoreManager.lookup('storevappmenuproxymap').reload();
                                        } else {
                                            Ext.MessageBox.show({
                                                title: 'Warning',
                                                icon: Ext.MessageBox.INFO,
                                                buttons: Ext.Msg.OK,
                                                msg: jsonObj2.result.message
                                            });
                                        }
                                        if (appMenuForm) {
                                            appMenuForm.unmask();
                                        }
                                    });
                                }, mainWin);
                            };
                            WinProxyPicker.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/source.png" style="height:20px;vertical-align:middle;margin-right:5px;">挑選資源');
                            WinProxyPicker.applicationHeadUuid = mainWin.down('#APPLICATION_HEAD_UUID').getValue();
                            WinProxyPicker.menuUuid = mainWin.down('#UUID').getValue();
                            WinProxyPicker.show();
                            if (appMenuForm) {
                                appMenuForm.mask();
                            };
                        }
                    }],
                    itemId: 'gridProxy',
                    store: this.myStore.vappmenuproxymap,                    
                    padding: 5,
                    autoScroll: true,
                    columns: [{
                        text: '',
                        dataIndex: 'PROXY_UUID',
                        align: 'center',
                        maxWidth: 50,
                        renderer: function(value, m, r) {
                            var id = Ext.id();
                            Ext.defer(function() {
                                Ext.widget('button', {
                                    renderTo: id,
                                    text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/delete2.png" style="height:12px;vertical-align:middle;margin-right:5px;margin-top:-2px;">',
                                    width: 30,
                                    handler: function() {
                                        Ext.MessageBox.confirm('刪除資源通知', '要刪除此項資源?', function(result) {
                                            //alert(result);
                                            //alert(value);
                                            var menUuid = Ext.getCmp('Ext.AppMenuForm.Form.UUID').getValue();
                                            if (result == 'yes') {
                                                WS.ProxyAction.removeAppmenuProxyMap(menUuid, value, function(obj, jsonObj) {
                                                    if (jsonObj.result.success) {
                                                        Ext.data.StoreManager.lookup('storevappmenuproxymap').loadPage(1);
                                                    } else {
                                                        Ext.MessageBox.show({
                                                            title: 'Warning',
                                                            msg: jsonObj.result.message,
                                                            icon: Ext.MessageBox.ERROR,
                                                            buttons: Ext.Msg.OK
                                                        });
                                                    }
                                                });
                                            }
                                        });
                                    }
                                });
                            }, 50);
                            return Ext.String.format('<div id="{0}"></div>', id);
                        }
                    }, {
                        text: "Action",
                        dataIndex: 'PROXY_ACTION',
                        align: 'left',
                        flex: 1
                    }, {
                        text: "Method",
                        dataIndex: 'PROXY_METHOD',
                        align: 'left',
                        flex: 1
                    }, {
                        text: "說明",
                        dataIndex: 'DESCRIPTION',
                        align: 'left',
                        flex: 1
                    }, {
                        text: "ReDirect",
                        dataIndex: 'NEED_REDIRECT',
                        align: 'left',
                        flex: 1
                    }, {
                        text: "Proxy[R]",
                        dataIndex: 'REDIRECT_PROXY_ACTION',
                        align: 'left',
                        flex: 1
                    }, {
                        text: "Method[R]",
                        dataIndex: 'REDIRECT_PROXY_METHOD',
                        align: 'left',
                        flex: 1
                    }],
                    height: 300,
                    bbar: Ext.create('Ext.toolbar.Paging', {
                        store: Ext.data.StoreManager.lookup('storevappmenuproxymap'),
                        itemId: 'gridPading',
                        displayInfo: true,
                        displayMsg: '第{0}~{1}資料/共{2}筆',
                        emptyMsg: "無資料顯示"
                    })
                }]
            }]
        }];
        this.callParent(arguments);
    },
    closeEvent: function() {
        this.fireEvent('closeEvent', this);
    },
    listeners: {
        'show': function() {
            Ext.getBody().mask();
            this.myMask = new Ext.LoadMask(this.down('#AppMenuForm'), {
                msg: "資料載入中，請稍等...",
                store: this.storeMenu,
                removeMask: true
            });
            this.myMask.show();
            this.myStore.sitemap.getProxy().setExtraParam('pApplicationHeadUuid', 'AUTO');
            this.myStore.sitemap.load({
                callback: function() {
                    this.myStore.menu.getProxy().setExtraParam('pApplicationHeadUuid', "ATUO");
                    this.myStore.menu.load();
                },
                scope: this
            });
            if (this.param.uuid != undefined) {
                this.down('#btnDelete').setDisabled(true);
                this.down('#AppMenuForm').getForm().load({
                    params: {
                        'pUuid': this.param.uuid
                    },
                    success: function(response, a, b) {
                        var _gridProxy = this.down("#gridProxy");
                        _gridProxy.getStore().getProxy().setExtraParam('pApplicationHeadUuid', this.down('#APPLICATION_HEAD_UUID').getValue());
                        _gridProxy.getStore().getProxy().setExtraParam('pAppmenuUuid', this.down('#UUID').getValue());
                        _gridProxy.getStore().load({
                            callback: function() {
                                this.myMask.hide();
                            },
                            scope: this
                        });
                    },
                    failure: function(response, a, b) {
                        r = Ext.decode(response.responseText);
                        alert('err:' + r);
                    },
                    scope: this
                });
            } else {
                this.down('#btnDelete').setDisabled(true);
                this.down('#AppMenuForm').getForm().reset();
                this.down('#APPMENU_UUID').setValue(this.parentUuid);
                this.down('#APPLICATION_HEAD_UUID').setValue(this.param.applicationHeadUuid);
                this.down('#UUID').setValue('');
            };
        },
        'close': function() {
            Ext.getBody().unmask();
            this.closeEvent();
        }
    }
});
