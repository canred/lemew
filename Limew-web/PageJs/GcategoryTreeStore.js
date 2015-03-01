Ext.define('Model.Gcategory', {
        extend: 'Ext.data.Model',
        fields: [{
            name: 'GCATEGORY_UUID'
        }, {
            name: 'GCATEGORY_UUID'
        }, {
            name: 'GCATEGORY_FULL_NAME'
        }, {
            name: 'GCATEGORY_FULL_UUID'
        }, {
            name: 'GCATEGORY_PARENT_UUID'
        }, {
            name: 'GCATEGORY_IS_ACTIVE'
        }]
    });
Ext.define('WS.GcategoryTreeStore', {
    extend: 'Ext.data.TreeStore',
    root: {
        expanded: true
    },
    autoLoad: false,
    successProperty: 'success',
    model: 'Model.Gcategory',
    nodeParam: 'id',
    proxy: {
            paramOrder: ['pGcategoryParentUuid'],
            type: 'direct',
            directFn: WS.GcategoryAction.loadGcategoryTree,
            extraParams: {
                "pGcategoryParentUuid": ''
            }
        }
});
