Ext.define('BILLING', {
    extend: 'Ext.data.Model',
    fields: [
        'BILLING_UUID',
        'BILLING_ID',
        'CUST_UUID',
        //'BILLING_START_DATE',
        {
            name: 'BILLING_START_DATE',
            convert: function(v) {
                if (v != undefined && typeof v.getFullYear == 'function') {
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

                    if (v != undefined && v.split(' ').length > 1) {
                        var y = v.split(' ')[0].split('/')[0];
                        var m = v.split(' ')[0].split('/')[1];
                        var d = v.split(' ')[0].split('/')[2];
                        if (m.length == 1) {
                            m = '0' + m;
                        }

                        if (d.length == 1) {
                            d = '0' + d;
                        }
                        return y + '/' + m + "/" + d;
                    } else {
                        return v;
                    }
                }
            }
        },

        //'BILLING_END_DATE',
        {
            name: 'BILLING_END_DATE',
            convert: function(v) {
                if (v != undefined && typeof v.getFullYear == 'function') {
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

                    if (v != undefined && v.split(' ').length > 1) {
                        var y = v.split(' ')[0].split('/')[0];
                        var m = v.split(' ')[0].split('/')[1];
                        var d = v.split(' ')[0].split('/')[2];
                        if (m.length == 1) {
                            m = '0' + m;
                        }

                        if (d.length == 1) {
                            d = '0' + d;
                        }
                        return y + '/' + m + "/" + d;
                    } else {
                        return v;
                    }
                }
            }
        },
        //'BILLING_REPORT_DATE',
        {
            name: 'BILLING_REPORT_DATE',
            convert: function(v) {
                if (v != undefined && typeof v.getFullYear == 'function') {
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

                    if (v != undefined && v.split(' ').length > 1) {
                        var y = v.split(' ')[0].split('/')[0];
                        var m = v.split(' ')[0].split('/')[1];
                        var d = v.split(' ')[0].split('/')[2];
                        if (m.length == 1) {
                            m = '0' + m;
                        }

                        if (d.length == 1) {
                            d = '0' + d;
                        }
                        return y + '/' + m + "/" + d;
                    } else {
                        return v;
                    }
                }
            }
        },
        'BILLING_CUST_NAME',
        'BILLING_CUST_UNIFORM_NUM',
        'BILLING_TEL',
        'BILLING_CUST_ADDRESS',
        'BILLING_SALES_NAME',
        'BILLING_ITEM_COUNT',
        'BILLING_DISCOUNT',
        'BILLING_SUM_PRICE',
        'BILLING_ARREARS_PRICE',
        'BILLING_TAX',
        'BILLING_TOTAL_PRICE',
        'BILLING_CHECK_YY',
        'BILLING_CHECK_MM',
        'BILLING_CHECK_TITLE',
        'BILLING_CONTACT_USER_NAME',
        'BILLING_CONTACT_ATTENDANT_UUID',
        'BILLING_BACK_ACCOUNT_NUMBER',
        'BILLING_BACK_NAME',
        'BILLING_BACK_SUB_NAME',
        'BILLING_BACK_ACCOUNT_NAME',
        'BILLING_PS',
        'BILLING_STATUS_ID',
        'BILLING_IS_ACTIVE',
        'BILLING_REPORT_ATTENDANT_UUID'
    ]
});

Ext.define('BILLING_DETAIL', {
    extend: 'Ext.data.Model',
    fields: [
        'BILLING_DETAIL_UUID',
        'CUST_ORDER_UUID',
        'BILLING_DETAIL_CR',
        'BILLING_UUID'
    ]
});

Ext.define('V_BILLING_DETAIL', {
    extend: 'Ext.data.Model',
    fields: [
        'BILLING_DETAIL_CR',
        'BILLING_DETAIL_UUID',
        'BILLING_UUID',
        'CUST_ORDER_UUID',
        //'CUST_ORDER_CR',
        {
            name: 'CUST_ORDER_CR',
            convert: function(v) {
                if (v != undefined && typeof v.getFullYear == 'function') {
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

                    if (v != undefined && v.split(' ').length > 1) {
                        var y = v.split(' ')[0].split('/')[0];
                        var m = v.split(' ')[0].split('/')[1];
                        var d = v.split(' ')[0].split('/')[2];
                        if (m.length == 1) {
                            m = '0' + m;
                        }

                        if (d.length == 1) {
                            d = '0' + d;
                        }
                        return y + '/' + m + "/" + d;
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
        'CUST_ORDER_SHIPPING_NUMBER',
        'CUST_ORDER_PS_NUMBER',
        'CUST_ORDER_PAY_PS',
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
        //'CUST_ORDER_REPORT_DATE',
        {
            name: 'CUST_ORDER_REPORT_DATE',
            convert: function(v) {
                if (v != undefined && typeof v.getFullYear == 'function') {
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

                    if (v != undefined && v.split(' ').length > 1) {
                        var y = v.split(' ')[0].split('/')[0];
                        var m = v.split(' ')[0].split('/')[1];
                        var d = v.split(' ')[0].split('/')[2];
                        if (m.length == 1) {
                            m = '0' + m;
                        }

                        if (d.length == 1) {
                            d = '0' + d;
                        }
                        return y + '/' + m + "/" + d;
                    } else {
                        return v;
                    }
                }
            }
        },
        'CUST_ORDER_REPORT_ATTENDANT_UUID',
        'CUST_ORDER_REPORT_ATTENDANT_C_NAME',
        'PAY_STATUS_NAME',
        'PAY_METHOD_NAME',
        'CUST_ORG_SALES_NAME',
        'CUST_ORG_SALES_PHONE',
        'CUST_ORG_SALES_EMAIL',
        'CUST_ORG_PS',
        'CUST_ORG_NAME',
        'CUST_ORG_IS_ACTIVE',
        'SHIPPING_ADDRESS',
        'COMPANY_UUID',
        'COMPANY_C_NAME',
        'SHIPPING_STATUS_NAME'
    ]
});

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
        'CUST_LAST_BUY',
        'CUST_UNIFORM_NUM'
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

Ext.define('CUST_ORG_V', {
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
        'CUST_LAST_BUY',
        'CUST_UNIFORM_NUM',
        'CUST_ORG_ADDRESS',
        'CUST_ORG_IS_ACTIVE',
        'CUST_ORG_IS_DEFAULT',
        'CUST_ORG_NAME',
        'CUST_ORG_PS',
        'CUST_ORG_SALES_EMAIL',
        'CUST_ORG_SALES_NAME',
        'CUST_ORG_SALES_PHONE',
        'CUST_ORG_UUID'
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
        //'CUST_ORDER_REPORT_DATE',
        {
            name: 'CUST_ORDER_REPORT_DATE',
            convert: function(v) {
                if (v != undefined && typeof v.getFullYear == 'function') {
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

                    if (v != undefined && v.split(' ').length > 1) {
                        var y = v.split(' ')[0].split('/')[0];
                        var m = v.split(' ')[0].split('/')[1];
                        var d = v.split(' ')[0].split('/')[2];
                        if (m.length == 1) {
                            m = '0' + m;
                        }

                        if (d.length == 1) {
                            d = '0' + d;
                        }
                        return y + '/' + m + "/" + d;
                    } else {
                        return v;
                    }
                }
            }
        },
        'CUST_ORDER_REPORT_ATTENDANT_UUID',
        'CUST_ORDER_SHIPPING_NUMBER',
        'SHIPPING_ADDRESS',
        'CUST_ORDER_PS_NUMBER'
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
        'CUST_ORDER_UUID', {
            name: 'CUST_ORDER_CR',
            convert: function(v) {
                if (v != undefined && typeof v.getFullYear == 'function') {
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

                    if (v != undefined && v.split(' ').length > 1) {
                        var y = v.split(' ')[0].split('/')[0];
                        var m = v.split(' ')[0].split('/')[1];
                        var d = v.split(' ')[0].split('/')[2];
                        if (m.length == 1) {
                            m = '0' + m;
                        }

                        if (d.length == 1) {
                            d = '0' + d;
                        }
                        return y + '/' + m + "/" + d;
                    } else {
                        return v;
                    }
                }
            }
        },
        'CUST_ORDER_ID', {
            name: 'CUST_ORDER_TOTAL_PRICE',
            type: 'number'
        },
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
        //'CUST_ORDER_REPORT_DATE',
        {
            name: 'CUST_ORDER_REPORT_DATE',
            convert: function(v) {
                if (v != undefined && typeof v.getFullYear == 'function') {
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

                    if (v != undefined && v.split(' ').length > 1) {
                        var y = v.split(' ')[0].split('/')[0];
                        var m = v.split(' ')[0].split('/')[1];
                        var d = v.split(' ')[0].split('/')[2];
                        if (m.length == 1) {
                            m = '0' + m;
                        }

                        if (d.length == 1) {
                            d = '0' + d;
                        }
                        return y + '/' + m + "/" + d;
                    } else {
                        return v;
                    }
                }
            }
        },
        'CUST_ORDER_REPORT_ATTENDANT_UUID',
        'CUST_ORDER_REPORT_ATTENDANT_C_NAME',
        'PAY_STATUS_NAME',
        'PAY_METHOD_NAME',
        'CUST_ORG_SALES_NAME',
        'CUST_ORG_SALES_PHONE',
        'CUST_ORG_SALES_EMAIL',
        'CUST_ORG_PS',
        'CUST_ORG_NAME',
        'CUST_ORG_IS_ACTIVE',
        'CUST_ORDER_SHIPPING_NUMBER',
        'SHIPPING_ADDRESS', 'SHIPPING_STATUS_NAME',
        'COMPANY_C_NAME',
        'CUST_ORDER_PS_NUMBER',
        'CUST_ORDER_PAY_PS',
    ]
});

Ext.define('V_CUST_ORDER_DETAIL', {
    extend: 'Ext.data.Model',
    fields: [{
            name: 'CUST_ORDER_DETAIL_COUNT',
            type: 'number'
        },
        'CUST_ORDER_DETAIL_CR', {
            name: 'CUST_ORDER_DETAIL_CUSTOMIZED',
            type: 'boolean'
        },

        'CUST_ORDER_DETAIL_GOODS_NAME',
        'CUST_ORDER_DETAIL_IS_ACTIVE',

        {
            name: 'CUST_ORDER_DETAIL_PRICE',
            type: 'number'
        },
        'CUST_ORDER_DETAIL_PS', {
            name: 'CUST_ORDER_DETAIL_TOTAL_PRICE',
            type: 'number'
        },

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
        'GOODS_NAME', {
            name: 'GOODS_PRICE',
            type: 'number'
        },

        'GOODS_PS',
        'GOODS_SN',
        'GOODS_UUID',
        'SUPPLIER_GOODS_NAME', {
            name: 'SUPPLIER_GOODS_PRICE',
            type: 'number'
        },

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
        'MY_ORDER_UUID',
        'SUPPLIER_UUID',
        'MY_ORDER_ID',
        'MY_ORDER_SUPPLIER_NAME',
        'MY_ORDER_SUPPLIER_TEL',
        'MY_ORDER_SUPPLIER_FAX',
        'MY_ORDER_SUPPLIER_ADDRESS',
        'MY_ORDER_CONTACT_NAME',
        'MY_ORDER_CONTACT_PHONE',
        'MY_ORDER_CONTACT_EMAIL',
        'MY_ORDER_PS', {
            'name': 'MY_ORDER_CR',
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
                    if (v != undefined && v.split(' ').length > 1) {
                        var y = v.split(' ')[0].split('/')[0];
                        var m = v.split(' ')[0].split('/')[1];
                        var d = v.split(' ')[0].split('/')[2];
                        if (m.length == 1) {
                            m = '0' + m;
                        }

                        if (d.length == 1) {
                            d = '0' + d;
                        }
                        return y + '/' + m + "/" + d;
                    } else {
                        return v;
                    }
                }
            }
        },
        'MY_ORDER_TOTAL_PRICE',
    ]
});


Ext.define('V_MY_ORDER_DETAIL', {
    extend: 'Ext.data.Model',
    fields: [
        'MY_ORDER_UUID',
        'SUPPLIER_UUID',
        'MY_ORDER_ID',
        'MY_ORDER_SUPPLIER_NAME',
        'MY_ORDER_SUPPLIER_TEL',
        'MY_ORDER_SUPPLIER_FAX',
        'MY_ORDER_SUPPLIER_ADDRESS',
        'MY_ORDER_CONTACT_NAME',
        'MY_ORDER_CONTACT_PHONE',
        'MY_ORDER_CONTACT_EMAIL',
        'MY_ORDER_PS', {
            'name': 'MY_ORDER_CR',
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
                    if (v != undefined && v.split(' ').length > 1) {
                        var y = v.split(' ')[0].split('/')[0];
                        var m = v.split(' ')[0].split('/')[1];
                        var d = v.split(' ')[0].split('/')[2];
                        if (m.length == 1) {
                            m = '0' + m;
                        }

                        if (d.length == 1) {
                            d = '0' + d;
                        }
                        return y + '/' + m + "/" + d;
                    } else {
                        return v;
                    }
                }
            }
        },
        'MY_ORDER_TOTAL_PRICE',
        'MY_ORDER_DETAIL_UUID',
        'MY_ORDER_DETAIL_ATTENDANT_UUID',
        'MY_ORDER_DETAIL_GOODS_COUNT',
        'MY_ORDER_DETAIL_GOODS_NAME',
        'MY_ORDER_DETAIL_PRICE',
        'MY_ORDER_DETAIL_TOTAL_PRICE',
        'SUPPLIER_GOODS_UUID',
        'MY_ORDER_DETAIL_ATTENDANT_C_NAME',
        'UNIT_UUID'
    ]
});


Ext.define('V_CUST_ORDER_SEARCH', {
    extend: 'Ext.data.Model',
    fields: [
        'COMPANY_C_NAME',
        'COMPANY_UUID',
        'CUST_ADDRESS',
        'CUST_FAX',
        'CUST_IS_ACTIVE',
        'CUST_LAST_BUY',
        'CUST_NAME',
        'CUST_ORDER_CR',
        'CUST_ORDER_CUST_NAME',
        'CUST_ORDER_DEPT',
        'CUST_ORDER_DETAIL_COUNT',
        'CUST_ORDER_DETAIL_CR', {
            name: 'CUST_ORDER_DETAIL_CUSTOMIZED',
            type: 'boolean'
        },
        'CUST_ORDER_DETAIL_GOODS_NAME',
        'CUST_ORDER_DETAIL_IS_ACTIVE', {
            name: 'CUST_ORDER_DETAIL_PRICE',
            type: 'number'
        },
        'CUST_ORDER_DETAIL_PS', {
            name: 'CUST_ORDER_DETAIL_TOTAL_PRICE',
            type: 'number'
        },

        'CUST_ORDER_DETAIL_UNIT',
        'CUST_ORDER_DETAIL_UNIT_NAME',
        'CUST_ORDER_DETAIL_UUID',
        'CUST_ORDER_HAS_TAX',
        'CUST_ORDER_ID',
        'CUST_ORDER_INVOICE_NUMBER',
        'CUST_ORDER_IS_ACTIVE',
        'CUST_ORDER_LIMIT_DATE',
        'CUST_ORDER_PO_NUMBER',
        'CUST_ORDER_PRINT_USER_NAME',
        'CUST_ORDER_PS',
        'CUST_ORDER_PURCHASE_AMOUNT',
        'CUST_ORDER_REPORT_ATTENDANT_C_NAME',
        'CUST_ORDER_REPORT_ATTENDANT_UUID',
        //'CUST_ORDER_REPORT_DATE',
        {
            name: 'CUST_ORDER_REPORT_DATE',
            convert: function(v) {
                if (v != undefined && typeof v.getFullYear == 'function') {
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

                    if (v != undefined && v.split(' ').length > 1) {
                        var y = v.split(' ')[0].split('/')[0];
                        var m = v.split(' ')[0].split('/')[1];
                        var d = v.split(' ')[0].split('/')[2];
                        if (m.length == 1) {
                            m = '0' + m;
                        }

                        if (d.length == 1) {
                            d = '0' + d;
                        }
                        return y + '/' + m + "/" + d;
                    } else {
                        return v;
                    }
                }
            }
        },
        'CUST_ORDER_SHIPPING_DATE',
        'CUST_ORDER_SHIPPING_NUMBER',
        'CUST_ORDER_STATUS_UUID',
        'CUST_ORDER_TOTAL_PRICE',
        'CUST_ORDER_TYPE',
        'CUST_ORDER_USER_NAME',
        'CUST_ORDER_USER_PHONE',
        'CUST_ORDER_UUID',
        'CUST_ORG_IS_ACTIVE',
        'CUST_ORG_NAME',
        'CUST_ORG_PS',
        'CUST_ORG_SALES_EMAIL',
        'CUST_ORG_SALES_NAME',
        'CUST_ORG_SALES_PHONE',
        'CUST_ORG_UUID',
        'CUST_PS',
        'CUST_SALES_EMAIL',
        'CUST_SALES_NAME',
        'CUST_SALES_PHONE',
        'CUST_TEL',
        'CUST_UUID',
        'FILEGROUP_DISPLAY_NAME',
        'FILEGROUP_TAG',
        'FILEGROUP_UUID',
        'FILE_COUNT',
        'GCATEGORY_FULL_NAME',
        'GCATEGORY_NAME',
        'GCATEGORY_UUID',
        'GOODS_NAME',
        'GOODS_PRICE',
        'GOODS_PS',
        'GOODS_SN',
        'GOODS_UUID',
        'PAY_METHOD_NAME',
        'PAY_METHOD_UUID',
        'PAY_STATUS_NAME',
        'PAY_STATUS_UUID',
        'SHIPPING_ADDRESS',
        'SHIPPING_STATUS_NAME',
        'SHIPPING_STATUS_UUID',
        'SUPPLIER_GOODS_NAME',
        'SUPPLIER_GOODS_PRICE',
        'SUPPLIER_GOODS_SN',
        'SUPPLIER_GOODS_UNIT_UUID',
        'SUPPLIER_GOODS_UUID',
        'UNIT_NAME'
    ]
});
