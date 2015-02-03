/*WS.ChangeAttendantWindow*/
/*TODO*/
/*
1.Model 要集中                                 [NO]
2.panel 的title要換成icon , title的方式        [YES]
3.add 的icon要換成icon , title的方式           [YES]
4. getCmp
*/

/*columns 使用default*/
Ext.define('WS.GroupWindow', {
    extend: 'Ext.window.Window',
    title: '群組權限',
    icon: SYSTEM_URL_ROOT + '/css/images/permission.png',
    closeAction: 'destroy',
    padding: 10,
    border: false,
    param: {
        uuid: undefined,
        companyUuid: undefined,
    },
    fnQuery: function() {
        var mainWin = this.up('window');
        loadAttendantStoreNotInGroup(
            COMPANYUUID,
            mainWin.param.uuid,
            mainWin.down('#txtSearch').getValue()
        );
    },
    myStore: {
        applicationheadheadv: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: true,
            model: Ext.define('APPLICATIONHEADV', {
                extend: 'Ext.data.Model',
                fields: [
                    'UUID',
                    'CREATE_DATE',
                    'UPDATE_DATE',
                    'IS_ACTIVE',
                    'NAME',
                    'DESCRIPTION',
                    'WEB_SITE',
                    'ID'
                ]
            }),
            pageSize: 9999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.ApplicationAction.loadApplication
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pKeyWord', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyWord: ''
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        Ext.MessageBox.show({
                            title: 'Warning',
                            msg: response.result.message,
                            icon: Ext.MessageBox.WARNING,
                            buttons: Ext.Msg.OK
                        });
                    }
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'NAME',
                direction: 'ASC'
            }]
        }),
        attendantnotingroupattendant: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: Ext.define('ATTEDNANTVV', {
                extend: 'Ext.data.Model',
                fields: [
                    'COMPANY_ID',
                    'COMPANY_C_NAME',
                    'COMPANY_E_NAME',
                    'DEPARTMENT_ID',
                    'DEPARTMENT_C_NAME',
                    'DEPARTMENT_E_NAME',
                    'SITE_ID',
                    'SITE_C_NAME',
                    'SITE_E_NAME',
                    'UUID',
                    'CREATE_DATE',
                    'UPDATE_DATE',
                    'IS_ACTIVE',
                    'COMPANY_UUID',
                    'ACCOUNT',
                    'C_NAME',
                    'E_NAME',
                    'EMAIL',
                    'PASSWORD',
                    'IS_SUPPER',
                    'IS_ADMIN',
                    'CODE_PAGE',
                    'DEPARTMENT_UUID',
                    'PHONE',
                    'SITE_UUID',
                    'GENDER',
                    'BIRTHDAY',
                    'HIRE_DATE',
                    'QUIT_DATE',
                    'IS_MANAGER',
                    'IS_DIRECT',
                    'GRADE',
                    'ID',
                    'IS_DEFAULT_PASS'
                ]
            }),
            pageSize: 9999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.GroupAttendantAction.loadAttendantStoreNotInGroup
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['company_uuid', 'group_head_uuid', 'keyword', 'is_active', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    company_uuid: '', //要回頭設定這一個值
                    group_head_uuid: '',
                    keyword: '',
                    is_active: 'Y'
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        Ext.MessageBox.show({
                            title: 'Warning',
                            msg: response.result.message,
                            icon: Ext.MessageBox.WARNING,
                            buttons: Ext.Msg.OK
                        });
                    }
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'C_NAME',
                direction: 'ASC'
            }]
        }),
        attendantingroupattendant: Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: Ext.define('ATTEDNANTVV', {
                extend: 'Ext.data.Model',
                fields: [
                    'COMPANY_ID',
                    'COMPANY_C_NAME',
                    'COMPANY_E_NAME',
                    'DEPARTMENT_ID',
                    'DEPARTMENT_C_NAME',
                    'DEPARTMENT_E_NAME',
                    'SITE_ID',
                    'SITE_C_NAME',
                    'SITE_E_NAME',
                    'UUID',
                    'CREATE_DATE',
                    'UPDATE_DATE',
                    'IS_ACTIVE',
                    'COMPANY_UUID',
                    'ACCOUNT',
                    'C_NAME',
                    'E_NAME',
                    'EMAIL',
                    'PASSWORD',
                    'IS_SUPPER',
                    'IS_ADMIN',
                    'CODE_PAGE',
                    'DEPARTMENT_UUID',
                    'PHONE',
                    'SITE_UUID',
                    'GENDER',
                    'BIRTHDAY',
                    'HIRE_DATE',
                    'QUIT_DATE',
                    'IS_MANAGER',
                    'IS_DIRECT',
                    'GRADE',
                    'ID',
                    'IS_DEFAULT_PASS'
                ]
            }),
            pageSize: 9999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.GroupAttendantAction.loadAttendantStoreInGroup
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['company_uuid', 'group_head_uuid', 'keyword', 'is_active', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    company_uuid: '',
                    group_head_uuid: '',
                    keyword: '',
                    is_active: 'Y'
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        Ext.MessageBox.show({
                            title: 'Warning',
                            msg: response.result.message,
                            icon: Ext.MessageBox.WARNING,
                            buttons: Ext.Msg.OK
                        });
                    }
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'C_NAME',
                direction: 'ASC'
            }]
        }),
        appmenutree: Ext.create('WS.AppMenuVTree', {})
    },
    width: 1000,
    height: 700,
    maxWidth: 930,
    maxHeight: 550,
    resizable: false,
    draggable: true,
    autoScroll: true,
    initComponent: function() {
        this.items = [Ext.create('Ext.form.Panel', {
            layout: {
                type: 'form',
                align: 'stretch'
            },
            api: {
                load: WS.GroupHeadAction.info,
                submit: WS.GroupHeadAction.submit
            },
            itemId: 'groupHeadForm',
            paramOrder: ['pUuid'],
            border: false,
            defaultType: 'textfield',
            buttonAlign: 'center',
            items: [{
                xtype: 'container',
                layout: 'hbox',
                margin: 5,
                items: [{
                    fieldLabel: '系統',
                    labelAlign: 'right',
                    xtype: 'combobox',
                    itemId: 'groupheafFormApplicationHead',
                    queryMode: 'local',
                    displayField: 'NAME',
                    valueField: 'UUID',
                    name: 'APPLICATION_HEAD_UUID',
                    anchor: '100%',
                    padding: 5,
                    editable: false,
                    hidden: false,
                    store: this.myStore.applicationheadheadv
                }, {
                    xtype: 'textfield',
                    fieldLabel: '代碼',
                    labelAlign: 'right',
                    labelWidth: 100,
                    itemId: 'groupHeadId',
                    name: 'ID',
                    padding: 5,
                    maxLength: 50
                }]
            }, {
                xtype: 'container',
                layout: 'hbox',
                margin: 5,
                items: [{
                    xtype: 'textfield',
                    fieldLabel: '群組繁中',
                    labelAlign: 'right',
                    id: 'NAME_ZH_TW',
                    labelWidth: 100,
                    name: 'NAME_ZH_TW',
                    padding: 5,
                    anchor: '100%',
                    maxLength: 100,
                    allowBlank: false
                }, {
                    xtype: 'textfield',
                    fieldLabel: '群組簡中',
                    labelAlign: 'right',
                    labelWidth: 100,
                    name: 'NAME_ZH_CN',
                    padding: 5,
                    anchor: '100%',
                    maxLength: 100,
                    allowBlank: false
                }, {
                    xtype: 'textfield',
                    fieldLabel: '群組英文',
                    labelWidth: 100,
                    labelAlign: 'right',
                    name: 'NAME_EN_US',
                    padding: 5,
                    maxLength: 100
                }]
            }, {
                xtype: 'hidden',
                fieldLabel: 'UUID',
                name: 'UUID',
                padding: 5,
                anchor: '100%',
                maxLength: 84,
                itemId: 'groupHeadFormUuid'
            }, {
                xtype: 'hidden',
                fieldLabel: 'IS_ACTIVE',
                name: 'IS_ACTIVE',
                padding: 5,
                anchor: '100%',
                maxLength: 1,
                value: 'Y'
            }],
            fbar: [{
                type: 'button',
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/save.gif" style="width:16px;height:16px;vertical-align:middle;margin-right:5px;"/>' + '儲存',
                handler: function() {
                    var mainWin = this.up('window');
                    var form = mainWin.down('#groupHeadForm').getForm();
                    if (form.isValid() == false) {
                        return;
                    };
                    form.submit({
                        waitMsg: '更新中...',
                        success: function(form, action) {
                            this.down('#groupHeadId').setDisabled(false);
                            this.down('#groupheafFormApplicationHead').setDisabled(false);
                            this.down('#bnt_Query').setDisabled(false);
                            this.down('#bnt_Delete').setDisabled(false);
                            var mainWin = this;
                            Ext.MessageBox.show({
                                title: '維護群組定義',
                                msg: '操作完成',
                                icon: Ext.MessageBox.INFO,
                                buttons: Ext.Msg.OK,
                                fn: function() {
                                    mainWin.down('#groupHeadFormUuid').setValue(action.result.UUID);
                                }
                            });
                        },
                        failure: function(form, action) {
                            Ext.MessageBox.show({
                                title: '維護群組定義',
                                msg: action.result.message,
                                icon: Ext.MessageBox.ERROR,
                                buttons: Ext.Msg.OK
                            });
                        },
                        scope: mainWin
                    });
                }
            }, {
                type: 'button',
                itemId: 'bnt_Delete',
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/delete.png" style="width:16px;height:16px;vertical-align:middle;margin-right:5px;"/>' + '刪除',
                handler: function() {
                    var mainWin = this.up('window');
                    Ext.Msg.show({
                        title: '刪除節點操作',
                        msg: '確定執行刪除動作?',
                        buttons: Ext.Msg.YESNO,
                        fn: function(btn) {
                            if (btn == "yes") {
                                WS.GroupHeadAction.deleteGroupHead(mainWin.param.uuid, function(data) {
                                    this.close();
                                }, mainWin);
                            }
                        }
                    });
                }
            }, {
                type: 'button',
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/leave.png" style="width:16px;height:16px;vertical-align:middle;margin-right:5px;"/>' + '關閉',
                handler: function() {
                    this.up('window').close();
                }
            }]
        }), {
            xtype: 'tabpanel',
            plain: true,
            padding: 10,
            border: true,
            maxWidth: 880,
            items: [{
                title: '權限維護',
                icon: SYSTEM_URL_ROOT + '/css/images/menu.png',
                items: [{
                    itemId: 'AppMenuPanel',
                    xtype: 'panel',
                    frame: false,
                    padding: 5,
                    autoHeight: true,
                    autoWidth: true,
                    companyUuid: undefined,
                    border: false,
                    items: [{
                        xtype: 'treepanel',
                        fieldLabel: '權限維護',
                        itemId: 'appMenuTree',
                        padding: 5,
                        border: true,
                        autoWidth: true,
                        autoHeight: true,
                        minHeight: 400,
                        store: this.myStore.appmemutree,
                        multiSelect: true,
                        rootVisible: false,
                        useArrows: true,
                        loadMask: true,
                        columns: [{
                            text: '<center>UUID</center>',
                            flex: 2,
                            sortable: false,
                            dataIndex: 'UUID',
                            hidden: true
                        }, {
                            xtype: 'treecolumn',
                            text: '<center>名稱</center>',
                            flex: 2,
                            sortable: false,
                            dataIndex: 'NAME_ZH_TW'
                        }, {
                            text: '<center>行為模式</center>',
                            flex: 1,
                            dataIndex: 'ACTION_MODE',
                            align: 'left',
                            sortable: false
                        }, {
                            text: "<center>預設頁面</center>",
                            dataIndex: 'DEFAULT_PAGE_CHECKED',
                            align: 'center',
                            flex: 0.5,
                            xtype: 'checkcolumn',
                            listeners: {
                                'checkchange': function(obj, rowIndex, checked) {
                                    var grid = obj.up().view,
                                        store = grid.store,
                                        record = store.getAt(rowIndex),
                                        uuid = record.data.UUID,
                                        mainWin = grid.up('window'),
                                        is_default_page = record.data.IS_DEFAULT_PAGE;
                                    if (!is_default_page) {
                                        var _item = Ext.get(grid.all.elements[rowIndex].childNodes[0].childNodes[0].childNodes[2].childNodes[0]);
                                        if (_item != null) {
                                            _item.remove();
                                        };
                                    } else {
                                        WS.AuthorityAction.setGroupAppmenuIsDefaultPage(uuid,
                                            mainWin.param.uuid, checked,
                                            function(data) {
                                                /*若是勾選*/
                                                if (checked) {
                                                    record.set('checked', checked);
                                                }
                                            });
                                    };
                                }
                            },
                            sortable: false,
                            hideable: false
                        }, {
                            text: '<center>功能描述</center>',
                            flex: 1,
                            dataIndex: 'DESCRIPTION',
                            align: 'left',
                            sortable: false
                        }, {
                            text: '<center>虛擬路徑</center>',
                            flex: 1,
                            dataIndex: 'URL',
                            align: 'left',
                            sortable: false
                        }, {
                            text: '<center>參數</center>',
                            flex: 1,
                            dataIndex: 'PARAMETER_CLASS',
                            align: 'left',
                            sortable: false
                        }],
                        listeners: {
                            beforeload: function(tree, node) {
                                // canred update ing
                                // if (node.isComplete() == false) {
                                //     if (node.getParams()["UUID"] != undefined) {
                                //         thisTreeStore.getProxy().setExtraParam('UUID', node.getParams()["UUID"]);
                                //     } else {
                                //         thisTreeStore.getProxy().setExtraParam('UUID', node.config.node.data["UUID"]);

                                //     }
                                //     thisTreeStore.getProxy().setExtraParam('GROUPHEADUUID', Ext.getCmp('ExtGroupHeadForm').uuid);
                                // }
                            },
                            checkchange: function(a, b, c, d) {
                                var mainWin = this.up('window'),
                                    oUuid = a.data.UUID,
                                    _group_head_uuid = mainWin.param.uuid;
                                if (a.data.checked == true) {
                                    /*表加入*/
                                    WS.AuthorityAction.setGroupAppmenu(oUuid, _group_head_uuid, "Y", function(ret) {
                                        setParentsChecked(a, a.data.checked);
                                    });
                                } else {
                                    WS.AuthorityAction.setGroupAppmenu(oUuid, _group_head_uuid, "N", function(ret) {
                                        setChildrenUnchecked(a, a.data.checked);
                                        /*可以勾選是否為is_default_page*/
                                        var _is_default_page = a.data.IS_DEFAULT_PAGE;
                                        /*是否勾選為default_page，因為是取消check，所以若有check，則需移除
                                        var _default_page_checked = a.data.DEFAULT_PAGE_CHECKED;*/
                                        if (_is_default_page && _default_page_checked) {
                                            var _tree = this.down('#appMenuTree');
                                            var _rowNumber = _tree.view.store.indexOf(a);
                                            Ext.get(Ext.get(_tree.view.all.elements[_rowNumber].childNodes[2].id)).checked = false;
                                        }
                                    }, mainWin);
                                }
                            },
                            itemclick: function(view, record, item, index, e) {
                                /*
                                 if (record.isLeaf()) {
                                 var nodeId = record.raw.id;//获取点击的节点id
                                 var nodeText = record.raw.text;//获取点击的节点text
                                 alert(nodeId);
                                 }
                                 */
                            },
                            afteritemexpand: function(node, index, item, eOpts) {
                                var mainWin = this.up('window'),
                                    queryUuid = mainWin.param.uuid;
                                if (queryUuid != undefined) {
                                    var _default_page_checked = node.data.DEFAULT_PAGE_CHECKED,
                                        _is_default_page = node.data.IS_DEFAULT_PAGE,
                                        _tree = mainWin.down('#appMenuTree'),
                                        _childNode = node.childNodes,
                                        _childNodeCount = _childNode.length;
                                    if (_childNodeCount > 0) {
                                        for (var i = 0; i < _childNodeCount; i++) {
                                            var item_is_default_page = _childNode[i].data.IS_DEFAULT_PAGE,
                                                _rowNumber = _tree.view.store.indexOf(_childNode[i]);
                                            Ext.get(Ext.get(_tree.view.all.elements[_rowNumber].childNodes[2].childNodes[0].children[0]).id).remove();
                                        }
                                    }
                                    if (!_is_default_page) {
                                        var rowNumber = _tree.view.store.indexOf(node);
                                        Ext.get(Ext.get(_tree.view.all.elements[rowNumber].childNodes[2].childNodes[0].children[0]).id).remove();
                                    }
                                }
                            },
                            afterlayout: function(obj, eOpts) {
                                /*處理root的下一層*/
                                var mainWin = this.up('window'),
                                    _tree = mainWin.down('#appMenuTree'),
                                    node = _tree.view.node,
                                    is_root = _tree.view.node.data.root;
                                if (is_root && node.childNodes.length > 0) {
                                    node.eachChild(function(n) {
                                        var _is_default_page = n.data.IS_DEFAULT_PAGE,
                                            _rowNumber = _tree.view.store.indexOf(n);
                                        if (_rowNumber != -1 && !_is_default_page) {
                                            //var _item = Ext.get(_tree.view.all.elements[_rowNumber].childNodes[2].childNodes[0].children[0]);
                                            var _item = Ext.get(_tree.view.all.elements[_rowNumber].childNodes[0].childNodes[0].childNodes[2].childNodes[0].childNodes[0]);
                                            if (_item != null) {
                                                Ext.get(_item.id).remove();
                                            };
                                        };
                                    });
                                }
                            }
                        }
                    }]

                }]
            }, {
                title: '使用者維護',
                icon: SYSTEM_URL_ROOT + '/css/images/man.png',
                items: [{
                    xtype: 'panel',
                    id: 'myUserPanel',
                    frame: false,
                    padding: 5,
                    bodyStyle: "padding:2px 0px 0",
                    border: false,
                    items: [{
                        xtype: 'fieldset',
                        title: '搜尋條件',
                        collapsible: true,
                        height: 60,
                        width: '100%',
                        border: true,
                        labelWidth: 60,
                        items: [{
                            xtype: 'container',
                            layout: 'hbox',
                            items: [{
                                xtype: "textfield",
                                name: "_txtSearch",
                                itemIdL: 'txtSearch',
                                fieldLabel: '關鍵字',
                                width: 200,
                                enableKeyEvents: true,
                                listeners: {
                                    keyup: function(e, t, eOpts) {
                                        if (t.button == 12) {
                                            btn_Query_Click();
                                        };
                                    }
                                }
                            }, {
                                xtype: 'button',
                                itemId: 'bnt_Query',
                                margin: '0 0 0 10',
                                text: '<img src="../../../css/custImages/search.gif" height="15"  style="vertical-align:middle"> 查詢',
                                listeners: {
                                    "click": this.fnQuery
                                }
                            }]
                        }]
                    }, {
                        xtype: 'panel',
                        border: false,
                        defaults: {
                            flex: 1
                        },
                        layout: {
                            type: 'hbox',
                            align: 'stretch'
                        },
                        width: '100%',
                        height: 400,
                        items: [{
                            xtype: 'gridpanel',
                            multiSelect: true,
                            margin: '0 10 0 0',
                            border: true,
                            viewConfig: {
                                plugins: {
                                    ptype: 'gridviewdragdrop',
                                    dragGroup: 'firstGridDDGroup',
                                    dropGroup: 'secondGridDDGroup'
                                },
                                listeners: {
                                    drop: function(node, data, dropRec, dropPosition) {
                                        var mainWin = this.up('window'),
                                            dropOn = dropRec ? ' ' + dropPosition + ' ' + dropRec.get('account') : ' on empty view',
                                            attendant_uuid = data.records[0].get('UUID'),
                                            group_head_uuid = mainWin.param.uuid;
                                        WS.GroupAttendantAction.destroyBy(group_head_uuid, attendant_uuid, function(data) {

                                        });
                                    }
                                },
                            },
                            width: '50%',
                            store: this.myStore.attendantnotingroupattendant,
                            columns: [{
                                header: "繁體名稱",
                                sortable: true,
                                width: '20%',
                                dataIndex: 'C_NAME'
                            }, {
                                header: "英文名稱",
                                sortable: true,
                                width: '20%',
                                dataIndex: 'E_NAME'
                            }, {
                                id: 'unselected_account',
                                header: "帳號",
                                sortable: true,
                                width: '20%',
                                dataIndex: 'ACCOUNT'
                            }, {
                                header: "信箱",
                                sortable: true,
                                width: '28%',
                                dataIndex: 'EMAIL'
                            }],
                            enableDragDrop: true,
                            stripeRows: true,
                            title: '未選取人員'
                        }, {
                            xtype: 'gridpanel',
                            multiSelect: true,
                            border: true,
                            margin: '0 0 0 10',
                            viewConfig: {
                                plugins: {
                                    ptype: 'gridviewdragdrop',
                                    dragGroup: 'secondGridDDGroup',
                                    dropGroup: 'firstGridDDGroup'
                                },
                                listeners: {
                                    drop: function(node, data, dropRec, dropPosition) {
                                        var mainWin = this.up('window'),
                                            dropOn = dropRec ? ' ' + dropPosition + ' ' + dropRec.get('uuid') : ' on empty view',
                                            attendant_uuid = data.records[0].get('UUID'),
                                            group_head_uuid = mainWin.param.uuid;
                                        WS.GroupAttendantAction.addAttendnatGroupHead(group_head_uuid, attendant_uuid, function(data) {

                                        });
                                    }
                                }
                            },
                            width: '50%',
                            store: this.myStore.attendantingroupattendant,
                            columns: [{
                                header: "繁體名稱",
                                sortable: true,
                                width: '20%',
                                dataIndex: 'C_NAME'
                            }, {
                                header: "英文名稱",
                                sortable: true,
                                width: '20%',
                                dataIndex: 'E_NAME'
                            }, {
                                id: 'selected_account',
                                header: "帳號",
                                width: '20%',
                                sortable: true,
                                dataIndex: 'ACCOUNT'
                            }, {
                                header: "信箱",
                                sortable: true,
                                width: '28%',
                                dataIndex: 'EMAIL'
                            }],
                            enableDragDrop: true,
                            stripeRows: true,
                            title: '已選取人員'
                        }]

                    }]
                }]
            }]
        }]
        this.callParent(arguments);
    },
    closeEvent: function() {
        this.fireEvent('closeEvent', this);
    },
    listeners: {
        'show': function() {
            Ext.getBody().mask();
            var mainWin = this;
            if (this.param.companyUuid == undefined) {
                WS.UserAction.getUserInfo(function(jsonObj) {
                    mainWin.param.companyUuid = jsonObj.COMPANY_UUID;
                });
            };
            myMask = new Ext.LoadMask(mainWin.down('#AppMenuPanel'), {
                msg: "資料載入中，請稍等...",
                store: this.myStore.appmenutree
            });
            myMask.show();
            if (this.uuid != undefined) {
                /*When 編輯/刪除資料*/
                var queryUuid = this.param.uuid;
                mainWin.down('#groupHeadId').setDisabled(true);
                mainWin.down('#groupHeadForm').getForm().load({
                    params: {
                        'pUuid': this.uuid
                    },
                    success: function(response, a, b) {
                        WS.AuthorityAction.loadTreeRoot(
                            this.down('#groupheafFormApplicationHead').getValue(),
                            function(data) {
                                thisTreeStore.load({
                                    params: {
                                        UUID: data.UUID,
                                        GROUPHEADUUID: queryUuid
                                    }
                                });
                                AppMenuVTaskFlag = true;
                            });

                        if (LoadDataTask) {
                            storeAttendantInGroupAttendant.getProxy().setExtraParam('group_head_uuid', queryUuid);
                            storeAttendantInGroupAttendant.getProxy().setExtraParam('company_uuid', COMPANYUUID);
                            storeAttendantInGroupAttendant.load({
                                callback: function() {
                                    LoadDataTask = false;
                                }
                            });
                        }
                    },
                    failure: function(response, a, b) {
                        r = Ext.decode(response.responseText);
                        alert('err:' + r);
                    },
                    scope: mainWin
                });
            } else {
                /*When 新增資料*/
                mainWin.down('#groupHeadId').setDisabled(false);
                mainWin.down('#groupheafFormApplicationHead').setDisabled(false);
                mainWin.down('#groupHeadForm').getForm().reset();
                mainWin.down('#appMenuTree').getRootNode().removeAll();
                this.myStore.attendantnotingroupattendant.removeAll();
                this.myStore.attendantingroupattendant.removeAll();
                mainWin.down('#bnt_Query').setDisabled(true);
                mainWin.down('#bnt_Delete').setDisabled(true);
            }
        },
        'close': function() {
            Ext.getBody().unmask();
            this.closeEvent();
        }
    }
});
