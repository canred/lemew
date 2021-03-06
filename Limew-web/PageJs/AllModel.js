/*BASIC*/
Ext.define('COMPANY', {
    extend: 'Ext.data.Model',
    fields: ['UUID', 'ID', 'C_NAME', 'E_NAME', 'WEEK_SHIFT', 'NAME_ZH_CN', 'IS_ACTIVE']
});

Ext.define('APPLICATION', {
    extend: 'Ext.data.Model',
    fields: [
        'CREATE_DATE',
        'UPDATE_DATE',
        'IS_ACTIVE',
        'NAME',
        'DESCRIPTION',
        'ID',
        'CREATE_USER',
        'UPDATE_USER',
        'WEB_SITE',
        'UUID'
    ]
});

Ext.define('APPLICATIONHEADV', {
    extend: 'Ext.data.Model',
    fields: [
        'CREATE_DATE',
        'CREATE_USER',
        'DESCRIPTION',
        'ID',
        'IS_ACTIVE',
        'NAME',
        'UPDATE_DATE',
        'UPDATE_USER',
        'UUID',
        'WEB_SITE'
    ]
});

Ext.define('APPPAGE', {
    extend: 'Ext.data.Model',
    fields: [
        'UUID',
        'IS_ACTIVE',
        'CREATE_DATE',
        'CREATE_USER',
        'UPDATE_DATE',
        'UPDATE_USER',
        'ID',
        'NAME',
        'DESCRIPTION',
        'URL',
        'PARAMETER_CLASS',
        'APPLICATION_HEAD_UUID',
        'P_MODE',
        'RUNJSFUNCTION'
    ]
});

Ext.define('ATTENDANT_V', {
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
});


Ext.define('DEPARTMENT', {
    extend: 'Ext.data.Model',
    fields: [
        'UUID', 'CREATE_DATE', 'UPDATE_DATE', 'IS_ACTIVE',
        'COMPANY_UUID', 'ID', 'C_NAME',
        'E_NAME', 'PARENT_DEPARTMENT_UUID',
        'MANAGER_UUID', 'PARENT_DEPARTMENT_ID', 'MANAGER_ID', 'PARENT_DEPARTMENT_UUID_LIST',
        'S_NAME', 'COST_CENTER', 'SRC_UUID', 'FULL_DEPARTMENT_NAME'
    ]
});

Ext.define('ERROR_LOG', {
    extend: 'Ext.data.Model',
    fields: ['UUID', 'ERROR_CODE', 'ERROR_TIME',
        'ERROR_MESSAGE', 'APPLICATION_NAME', 'ATTENDANT_UUID',
        'ERROR_TYPE', 'IS_READ', 'CREATE_DATE', 'C_NAME'
    ]
});

Ext.define('MENU', {
    extend: 'Ext.data.Model',
    fields: ['UUID', 'IS_ACTIVE', 'CREATE_DATE', 'CREATE_USER', 'UPDATE_DATE', 'UPDATE_USER', 'NAME_ZH_TW', 'NAME_ZH_CN', 'NAME_EN_US', 'ID', 'APPMENU_UUID', 'HASCHILD', 'APPLICATION_HEAD_UUID', 'ORD', 'PARAMETER_CLASS', 'IMAGE', 'SITEMAP_UUID', 'ACTION_MODE', 'IS_DEFAULT_PAGE', 'IS_ADMIN']
});

Ext.define('SITEMAP', {
    extend: 'Ext.data.Model',
    fields: ['UUID', 'IS_ACTIVE', 'CREATE_DATE', 'CREATE_USER', 'UPDATE_DATE', 'UPDATE_USER', 'SITEMAP_UUID', 'APPPAGE_UUID', 'ROOT_UUID', 'HASCHILD', 'APPLICATION_HEAD_UUID', 'NAME', 'DESCRIPTION', 'URL', 'P_MODE', 'PARAMETER_CLASS', 'APPPAGE_IS_ACTIVE']
});

Ext.define('PROXY', {
    extend: 'Ext.data.Model',
    fields: [
        'UUID',
        'PROXY_ACTION',
        'PROXY_METHOD',
        'DESCRIPTION',
        'PROXY_TYPE',
        'NEED_REDIRECT',
        'REDIRECT_PROXY_ACTION',
        'REDIRECT_PROXY_METHOD',
        'APPLICATION_HEAD_UUID',
        'REDIRECT_SRC'
    ]
});

Ext.define('GROUP_HEAD_V', {
    extend: 'Ext.data.Model',
    fields: [
        'UUID',
        'CREATE_DATE',
        'UPDATE_DATE',
        'IS_ACTIVE',
        'NAME_ZH_TW',
        'NAME_ZH_CN',
        'NAME_EN_US',
        'COMPANY_UUID',
        'ID',
        'APPLICATION_HEAD_UUID',
        'APPLICATION_HEAD_ID',
        'APPLICATION_HEAD_NAME'
    ]
});

Ext.define('V_APPMENU_PROXY_MAP', {
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
});

Ext.define('SCHEDULE', {
    extend: 'Ext.data.Model',
    fields: [
        'UUID',
        'SCHEDULE_NAME',
        'SCHEDULE_END_DATE',
        'LAST_RUN_TIME',
        'LAST_RUN_STATUS',
        'IS_CYCLE',
        'SINGLE_DATE',
        'HOUR',
        'MINUTE',
        'CYCLE_TYPE',
        'C_MINUTE',
        'C_HOUR',
        'C_DAY',
        'C_WEEK',
        'C_DAY_OF_WEEK',
        'C_MONTH',
        'C_DAY_OF_MONTH',
        'C_WEEK_OF_MONTH',
        'C_YEAR',
        'C_WEEK_OF_YEAR',
        'RUN_URL',
        'RUN_URL_PARAMETER',
        'RUN_ATTENDANT_UUID',
        'IS_ACTIVE',
        'START_DATE',
        'RUN_SECURITY'
    ]
});



/*Limew*/
Ext.define('CUST', {
    extend: 'Ext.data.Model',
    fields: [
        'CUST_UUID',
        'CUST_NAME',
        'CUST_TEL',
        'CUST_FAX',
        'CUST_ADDRESS',
        'CUST_SALES_NAME',
        'CUST_SALES_PHONE',
        'CUST_SALES_EMAIL',
        'CUST_PS',
        'CUST_LEVEL',
        'CUST_IS_ACTIVE',
        'CUST_LAST_BUY'
    ]
});

Ext.define('CUST_ORDER_DETAIL', {
    extend: 'Ext.data.Model',
    fields: [
        'CUST_ORDER_DETAIL_UUID',
        'CUST_ORDER_UUID',
        'GOODS_UUID',
        'CUST_ORDER_DETAIL_GOODS_NAME',
        'CUST_ORDER_DETAIL_COUNT',
        'CUST_ORDER_DETAIL_UNIT',
        'CUST_ORDER_DETAIL_PRICE',
        'CUST_ORDER_DETAIL_TOTAL_PRICE',
        'CUST_ORDER_DETAIL_PS',
        'CUST_ORDER_DETAIL_CR',
        'CUST_ORDER_DETAIL_CUSTOMIZED',
        'FILEGROUP_UUID',
        'SUPPLIER_GOODS_UUID',
        'CUST_ORDER_DETAIL_IS_ACTIVE'
    ]
});

Ext.define('CUST_ORDER_STATUS', {
    extend: 'Ext.data.Model',
    fields: [
        'CUST_ORDER_STATUS_UUID',
        'CUST_ORDER_STATUS_NAME',
        'CUST_ORDER_STATUS_ORD',
        'CUST_ORDER_STATUS_IS_ACTIVE'
    ]
});

Ext.define('CUST_ORG', {
    extend: 'Ext.data.Model',
    fields: [
        'CUST_ORG_UUID',
        'CUST_UUID',
        'CUST_ORG_SALES_NAME',
        'CUST_ORG_SALES_PHONE',
        'CUST_ORG_SALES_EMAIL',
        'CUST_ORG_PS',
        'CUST_ORG_NAME',
        'CUST_ORG_IS_ACTIVE',
        'CUST_ORG_IS_ADDRESS',
    ]
});

Ext.define('CUST_ORDER', {
    extend: 'Ext.data.Model',
    fields: [
        'CUST_ORDER_UUID',
        'CUST_ORDER_CR',
        'CUST_ORDER_ID',
        'CUST_ORDER_TOTAL_PRICE',
        'CUST_ORDER_STATUS_UUID',
        'CUST_ORDER_IS_ACTIVE',
        'CUST_UUID',
        'CUST_ORDER_TYPE',
        'CUST_ORDER_CUST_NAME',
        'CUST_ORDER_DEPT',
        'CUST_ORDER_USER_NAME',
        'CUST_ORDER_USER_PHONE',
        'CUST_ORDER_PURCHASE_AMOUNT',
        'CUST_ORDER_PRINT_USER_NAME',
        'CUST_ORDER_SHIPPING_DATE',
        'SHIPPING_STATUS_UUID',
        'CUST_ORDER_PO_NUMBER',
        'PAY_STATUS_UUID',
        'PAY_METHOD_UUID',
        'CUST_ORDER_INVOICE_NUMBER',
        'CUST_ORDER_LIMIT_DATE',
        'CUST_ORG_UUID',
        'CUST_ORDER_HAS_TAX',
        'CUST_ORDER_PS',
        'COMPANY_UUID',
        'CUST_ORDER_REPORT_DATE',
        'CUST_ORDER_REPORT_ATTENDANT_UUID',
        'CUST_ORDER_SHIPPING_NUMBER',
        'SHIPPING_ADDRESS'
    ]
});


Ext.define('FILEGROUP', {
    extend: 'Ext.data.Model',
    fields: [
        'FILEGROUP_UUID',
        'FILEGROUP_DISPLAY_NAME',
        'FILE_COUNT',
        'FILEGROUP_TAG'
    ]
});

Ext.define('FILE', {
    extend: 'Ext.data.Model',
    fields: [
        'FILE_UUID',
        'FILE_NAME',
        'FILE_URL',
        'FILE_PS',
        'FILE_PATH',
        'FILEGROUP_UUID',
        'FILE_CR'
    ]
});

Ext.define('GOODS', {
    extend: 'Ext.data.Model',
    fields: [
        'GOODS_UUID',
        'GOODS_SN',
        'GOODS_COST',
        'GOODS_SALE',
        'GOODS_PRICE',
        'GOODS_FOCUS',
        'GOODS_IS_ACTIVE',
        'SUPPLIER_UUID',
        'GCATEGORY_UUID',
        'GOODS_NAME',
        'GOODS_PS'
    ]
});

Ext.define('SHIPPING_STATUS', {
    extend: 'Ext.data.Model',
    fields: [
        'SHIPPING_STATUS_UUID',
        'SHIPPING_STATUS_ORD',
        'SHIPPING_STATUS_NAME'
    ]
});

Ext.define('SUPPLIER', {
    extend: 'Ext.data.Model',
    fields: [
        'SUPPLIER_UUID',
        'SUPPLIER_NAME',
        'SUPPLIER_TEL',
        'SUPPLIER_FAX',
        'SUPPLIER_ADDRESS',
        'SUPPLIER_CONTACT_NAME',
        'SUPPLIER_SALES_NAME',
        'SUPPLIER_SALES_PHONE',
        'SUPPLIER_CONTACT_PHONE',
        'SUPPLIER_CONTACT_EMAIL',
        'SUPPLIER_SALES_EMAIL',
        'SUPPLIER_PS',
        'SUPPLIER_IS_ACTIVE'
    ]
});

Ext.define('SUPPLIER_GOODS', {
    extend: 'Ext.data.Model',
    fields: [
        'SUPPLIER_UUID',
        'SUPPLIER_GOODS_UUID',
        'UNIT_UUID',
        'SUPPLIER_GOODS_SPEC',
        'SUPPLIER_GOODS_SN',
        'SUPPLIER_GOODS_PRICE',
        'SUPPLIER_GOODS_NAME',
        'SUPPLIER_GOODS_IS_ACTIVE',
        'SUPPLIER_GOODS_COST'
    ]
});

Ext.define('PAY_STATUS', {
    extend: 'Ext.data.Model',
    fields: [
        'PAY_STATUS_UUID',
        'PAY_STATUS_ORD',
        'PAY_STATUS_NAME'
    ]
});

Ext.define('PAY_METHOD', {
    extend: 'Ext.data.Model',
    fields: [
        'PAY_METHOD_UUID',
        'PAY_METHOD_ORD',
        'PAY_METHOD_NAME'
    ]
});

Ext.define('V_GOODS', {
    extend: 'Ext.data.Model',
    fields: [
        'GOODS_UUID',
        'GOODS_SN',
        'GOODS_COST',
        'GOODS_SALE',
        'GOODS_PRICE',
        'GOODS_FOCUS',
        'GOODS_NAME',
        'GOODS_IS_ACTIVE',
        'SUPPLIER_UUID',
        'SUPPLIER_NAME',
        'SUPPLIER_PS',
        'GCATEGORY_UUID',
        'GCATEGORY_NAME',
        'GCATEGORY_FULL_NAME',
        'GOODS_PS'
    ]
});


Ext.define('V_CUST_ADDRESS', {
    extend: 'Ext.data.Model',
    fields: [
        'CUST_ADDRESS',
        'CUST_ORG_ADDRESS',
        'CUST_UUID',
        'CUST_ORG_UUID'
    ]
});

Ext.define('V_CUST_ORDER', {
    extend: 'Ext.data.Model',
    fields: [
        'COMPANY_UUID',
        'CUST_ORDER_UUID',
        //'CUST_ORDER_CR',
        {
            name: 'CUST_ORDER_CR',
            convert: function(v) {
                if (typeof v.getFullYear == 'function') {
                    var month = (v.getMonth() + 1);
                    var day = v.getDate();
                    if (month < 10) {
                        month = "0" + month;
                    };
                    if (day < 10) {
                        day = "0" + day;
                    };
                    return v.getFullYear() + '/' + month + "/" + day;
                } else {
                    if (v.split(' ').length > 1) {
                        return v.split(' ')[0];
                    } else {
                        return v;
                    }
                }
            }
        },
        'CUST_ORDER_ID',
        'CUST_ORDER_TOTAL_PRICE',
        'CUST_ORDER_STATUS_UUID',
        'CUST_ORDER_IS_ACTIVE',
        'CUST_UUID',
        'CUST_ORDER_TYPE',
        'CUST_ORDER_CUST_NAME',
        'CUST_ORDER_DEPT',
        'CUST_ORDER_USER_NAME',
        'CUST_ORDER_USER_PHONE',
        'CUST_ORDER_PURCHASE_AMOUNT',
        'CUST_ORDER_PRINT_USER_NAME',
        'CUST_ORDER_SHIPPING_DATE',
        'SHIPPING_STATUS_UUID',
        'CUST_ORDER_PO_NUMBER',
        'PAY_STATUS_UUID',
        'PAY_METHOD_UUID',
        'CUST_ORDER_INVOICE_NUMBER',
        'CUST_ORDER_LIMIT_DATE',
        'CUST_ORG_UUID',
        'CUST_ORDER_HAS_TAX',
        'CUST_ORDER_PS',
        'CUST_NAME',
        'CUST_ADDRESS',
        'CUST_FAX',
        'CUST_IS_ACTIVE',
        'CUST_LAST_BUY',
        'CUST_PS',
        'CUST_SALES_EMAIL',
        'CUST_SALES_NAME',
        'CUST_SALES_PHONE',
        'CUST_TEL',
        'CUST_ORDER_REPORT_DATE',
        'CUST_ORDER_REPORT_ATTENDANT_UUID',
        'CUST_ORDER_REPORT_ATTENDANT_C_NAME',
        'PAY_STATUS_NAME',
        'PAY_METHOD_NAME',
        'CUST_ORG_SALES_NAME',
        'CUST_ORG_SALES_PHONE',
        'CUST_ORG_SALES_EMAIL',
        'CUST_ORG_PS',
        'CUST_ORG_NAME',
        'CUST_ORG_IS_ACTIVE'
    ]
});

Ext.define('V_CUST_ORDER_DETAIL', {
    extend: 'Ext.data.Model',
    fields: [
        'CUST_ORDER_DETAIL_COUNT',
        'CUST_ORDER_DETAIL_CR', {
            name: 'CUST_ORDER_DETAIL_CUSTOMIZED',
            type: 'boolean'
        },

        'CUST_ORDER_DETAIL_GOODS_NAME',
        'CUST_ORDER_DETAIL_IS_ACTIVE',
        'CUST_ORDER_DETAIL_PRICE',
        'CUST_ORDER_DETAIL_PS',
        'CUST_ORDER_DETAIL_TOTAL_PRICE',
        'CUST_ORDER_DETAIL_UNIT',
        'CUST_ORDER_DETAIL_UNIT_NAME',
        'CUST_ORDER_DETAIL_UUID',
        'CUST_ORDER_UUID',
        'FILE_COUNT',
        'FILEGROUP_DISPLAY_NAME',
        'FILEGROUP_TAG',
        'FILEGROUP_UUID',
        'GCATEGORY_FULL_NAME',
        'GCATEGORY_NAME',
        'GCATEGORY_UUID',
        'GOODS_NAME',
        'GOODS_PRICE',
        'GOODS_PS',
        'GOODS_SN',
        'GOODS_UUID',
        'SUPPLIER_GOODS_NAME',
        'SUPPLIER_GOODS_PRICE',
        'SUPPLIER_GOODS_SN',
        'SUPPLIER_GOODS_UNIT_UUID',
        'SUPPLIER_GOODS_UUID',
        'UNIT_NAME'
    ]
});
Ext.define('V_FILEGROUP', {
    extend: 'Ext.data.Model',
    fields: [
        'FILE_UUID',
        'FILE_NAME',
        'FILE_URL',
        'FILE_PS',
        'FILE_PATH',
        'FILEGROUP_UUID',
        'FILE_CR',
        'FILEGROUP_DISPLAY_NAME',
        'FILE_COUNT',
        'FILEGROUP_TAG'
    ]
});

Ext.define('V_SUPPLIER_GOODS', {
    extend: 'Ext.data.Model',
    fields: [
        'SUPPLIER_NAME',
        'SUPPLIER_GOODS_UUID',
        'SUPPLIER_GOODS_NAME',
        'UNIT_UUID',
        'SUPPLIER_GOODS_SN',
        'SUPPLIER_GOODS_PRICE',
        'SUPPLIER_GOODS_COST',
        'SUPPLIER_GOODS_IS_ACTIVE',
        'SUPPLIER_UUID',
        'SUPPLIER_GOODS',
        'UNIT_NAME'
    ]
});


Ext.define('UNIT', {
    extend: 'Ext.data.Model',
    fields: [
        'UNIT_UUID',
        'UNIT_NAME',
        'UNIT_IS_ACTIVE'
    ]
});

Ext.define('MY_ORDER', {
    extend: 'Ext.data.Model',
    fields: [
        'MY_ORDER_UUID', {
            name: 'MY_ORDER_DATE',
            convert: function(v) {
                if (typeof v.getFullYear == 'function') {
                    var month = (v.getMonth() + 1);
                    var day = v.getDate();
                    if (month < 10) {
                        month = "0" + month;
                    };
                    if (day < 10) {
                        day = "0" + day;
                    };
                    return v.getFullYear() + '/' + month + "/" + day;
                } else {
                    if (v.split(' ').length > 1) {
                        return v.split(' ')[0];
                    } else {
                        return v;
                    }
                }
            }
        },
        'MY_ORDER_SUPPLIER_NAME',
        'MY_ORDER_SUPPLIER_TEL',
        'MY_ORDER_SUPPLIER_MAN',
        'MY_ORDER_GOODS_NAME',
        'MY_ORDER_GOODS_COUNT', {
            name: 'MY_ORDER_PRICE',
            type: 'number'
        },
        'MY_ORDER_PRICE',
        'MY_ORDER_TOTAL_PRICE',
        'MY_ORDER_PS',
        'MY_ORDER_IS_FINISH',
        'MY_ORDER_PAY_METHOD',
        'MY_ORDER_IS_ACTIVE',
        'MY_ORDER_ATTENDANT_UUID'
    ]
});
