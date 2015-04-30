using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LK.Attribute;
using LK.DB;  
using LK.DB.SQLCreater;  
using Limew.Model.Lw.Table;
namespace Limew.Model.Lw.Table.Record
{
	[LkRecord]
	[TableView("V_CUST_ORDER_SEARCH", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class VCustOrderSearch_Record : RecordBase{
		public VCustOrderSearch_Record(){}
		/*欄位資訊 Start*/
		string _CUST_ORDER_UUID=null;
		DateTime? _CUST_ORDER_CR=null;
		string _CUST_ORDER_ID=null;
		decimal? _CUST_ORDER_TOTAL_PRICE=null;
		string _CUST_ORDER_STATUS_UUID=null;
		int? _CUST_ORDER_IS_ACTIVE=null;
		string _CUST_UUID=null;
		string _CUST_ORDER_TYPE=null;
		string _CUST_ORDER_CUST_NAME=null;
		string _CUST_ORDER_DEPT=null;
		string _CUST_ORDER_USER_NAME=null;
		string _CUST_ORDER_USER_PHONE=null;
		string _CUST_ORDER_PURCHASE_AMOUNT=null;
		string _CUST_ORDER_PRINT_USER_NAME=null;
		DateTime? _CUST_ORDER_SHIPPING_DATE=null;
		string _SHIPPING_STATUS_UUID=null;
		string _CUST_ORDER_PO_NUMBER=null;
		string _PAY_STATUS_UUID=null;
		string _PAY_METHOD_UUID=null;
		string _CUST_ORDER_INVOICE_NUMBER=null;
		DateTime? _CUST_ORDER_LIMIT_DATE=null;
		string _CUST_ORG_UUID=null;
		int? _CUST_ORDER_HAS_TAX=null;
		string _CUST_ORDER_PS=null;
		string _CUST_ORDER_SHIPPING_NUMBER=null;
		string _CUST_NAME=null;
		string _CUST_ADDRESS=null;
		string _CUST_FAX=null;
		int? _CUST_IS_ACTIVE=null;
		DateTime? _CUST_LAST_BUY=null;
		string _CUST_PS=null;
		string _CUST_SALES_EMAIL=null;
		string _CUST_SALES_NAME=null;
		string _CUST_SALES_PHONE=null;
		string _CUST_TEL=null;
		DateTime? _CUST_ORDER_REPORT_DATE=null;
		string _CUST_ORDER_REPORT_ATTENDANT_UUID=null;
		string _CUST_ORDER_REPORT_ATTENDANT_C_NAME=null;
		string _PAY_STATUS_NAME=null;
		string _PAY_METHOD_NAME=null;
		string _CUST_ORG_SALES_NAME=null;
		string _CUST_ORG_SALES_PHONE=null;
		string _CUST_ORG_SALES_EMAIL=null;
		string _CUST_ORG_PS=null;
		string _CUST_ORG_NAME=null;
		int? _CUST_ORG_IS_ACTIVE=null;
		string _SHIPPING_ADDRESS=null;
		string _COMPANY_UUID=null;
		string _COMPANY_C_NAME=null;
		string _SHIPPING_STATUS_NAME=null;
		int? _CUST_ORDER_DETAIL_COUNT=null;
		DateTime? _CUST_ORDER_DETAIL_CR=null;
		int? _CUST_ORDER_DETAIL_CUSTOMIZED=null;
		string _CUST_ORDER_DETAIL_GOODS_NAME=null;
		int? _CUST_ORDER_DETAIL_IS_ACTIVE=null;
		decimal? _CUST_ORDER_DETAIL_PRICE=null;
		string _CUST_ORDER_DETAIL_PS=null;
		decimal? _CUST_ORDER_DETAIL_TOTAL_PRICE=null;
		string _CUST_ORDER_DETAIL_UNIT=null;
		string _CUST_ORDER_DETAIL_UNIT_NAME=null;
		string _CUST_ORDER_DETAIL_UUID=null;
		string _FILEGROUP_DISPLAY_NAME=null;
		string _FILEGROUP_TAG=null;
		string _FILEGROUP_UUID=null;
		int? _FILE_COUNT=null;
		string _GCATEGORY_FULL_NAME=null;
		string _GCATEGORY_NAME=null;
		string _GCATEGORY_UUID=null;
		string _GOODS_NAME=null;
		decimal? _GOODS_PRICE=null;
		string _GOODS_PS=null;
		string _GOODS_SN=null;
		string _GOODS_UUID=null;
		string _SUPPLIER_GOODS_NAME=null;
		decimal? _SUPPLIER_GOODS_PRICE=null;
		string _SUPPLIER_GOODS_SN=null;
		string _SUPPLIER_GOODS_UNIT_UUID=null;
		string _SUPPLIER_GOODS_UUID=null;
		string _UNIT_NAME=null;
		/*欄位資訊 End*/

		[ColumnName("CUST_ORDER_UUID",true,typeof(string))]
		public string CUST_ORDER_UUID
		{
			set
			{
				_CUST_ORDER_UUID=value;
			}
			get
			{
				return _CUST_ORDER_UUID;
			}
		}

		[ColumnName("CUST_ORDER_CR",false,typeof(DateTime?))]
		public DateTime? CUST_ORDER_CR
		{
			set
			{
				_CUST_ORDER_CR=value;
			}
			get
			{
				return _CUST_ORDER_CR;
			}
		}

		[ColumnName("CUST_ORDER_ID",false,typeof(string))]
		public string CUST_ORDER_ID
		{
			set
			{
				_CUST_ORDER_ID=value;
			}
			get
			{
				return _CUST_ORDER_ID;
			}
		}

		[ColumnName("CUST_ORDER_TOTAL_PRICE",false,typeof(decimal?))]
		public decimal? CUST_ORDER_TOTAL_PRICE
		{
			set
			{
				_CUST_ORDER_TOTAL_PRICE=value;
			}
			get
			{
				return _CUST_ORDER_TOTAL_PRICE;
			}
		}

		[ColumnName("CUST_ORDER_STATUS_UUID",false,typeof(string))]
		public string CUST_ORDER_STATUS_UUID
		{
			set
			{
				_CUST_ORDER_STATUS_UUID=value;
			}
			get
			{
				return _CUST_ORDER_STATUS_UUID;
			}
		}

		[ColumnName("CUST_ORDER_IS_ACTIVE",false,typeof(int?))]
		public int? CUST_ORDER_IS_ACTIVE
		{
			set
			{
				_CUST_ORDER_IS_ACTIVE=value;
			}
			get
			{
				return _CUST_ORDER_IS_ACTIVE;
			}
		}

		[ColumnName("CUST_UUID",false,typeof(string))]
		public string CUST_UUID
		{
			set
			{
				_CUST_UUID=value;
			}
			get
			{
				return _CUST_UUID;
			}
		}

		[ColumnName("CUST_ORDER_TYPE",false,typeof(string))]
		public string CUST_ORDER_TYPE
		{
			set
			{
				_CUST_ORDER_TYPE=value;
			}
			get
			{
				return _CUST_ORDER_TYPE;
			}
		}

		[ColumnName("CUST_ORDER_CUST_NAME",false,typeof(string))]
		public string CUST_ORDER_CUST_NAME
		{
			set
			{
				_CUST_ORDER_CUST_NAME=value;
			}
			get
			{
				return _CUST_ORDER_CUST_NAME;
			}
		}

		[ColumnName("CUST_ORDER_DEPT",false,typeof(string))]
		public string CUST_ORDER_DEPT
		{
			set
			{
				_CUST_ORDER_DEPT=value;
			}
			get
			{
				return _CUST_ORDER_DEPT;
			}
		}

		[ColumnName("CUST_ORDER_USER_NAME",false,typeof(string))]
		public string CUST_ORDER_USER_NAME
		{
			set
			{
				_CUST_ORDER_USER_NAME=value;
			}
			get
			{
				return _CUST_ORDER_USER_NAME;
			}
		}

		[ColumnName("CUST_ORDER_USER_PHONE",false,typeof(string))]
		public string CUST_ORDER_USER_PHONE
		{
			set
			{
				_CUST_ORDER_USER_PHONE=value;
			}
			get
			{
				return _CUST_ORDER_USER_PHONE;
			}
		}

		[ColumnName("CUST_ORDER_PURCHASE_AMOUNT",false,typeof(string))]
		public string CUST_ORDER_PURCHASE_AMOUNT
		{
			set
			{
				_CUST_ORDER_PURCHASE_AMOUNT=value;
			}
			get
			{
				return _CUST_ORDER_PURCHASE_AMOUNT;
			}
		}

		[ColumnName("CUST_ORDER_PRINT_USER_NAME",false,typeof(string))]
		public string CUST_ORDER_PRINT_USER_NAME
		{
			set
			{
				_CUST_ORDER_PRINT_USER_NAME=value;
			}
			get
			{
				return _CUST_ORDER_PRINT_USER_NAME;
			}
		}

		[ColumnName("CUST_ORDER_SHIPPING_DATE",false,typeof(DateTime?))]
		public DateTime? CUST_ORDER_SHIPPING_DATE
		{
			set
			{
				_CUST_ORDER_SHIPPING_DATE=value;
			}
			get
			{
				return _CUST_ORDER_SHIPPING_DATE;
			}
		}

		[ColumnName("SHIPPING_STATUS_UUID",false,typeof(string))]
		public string SHIPPING_STATUS_UUID
		{
			set
			{
				_SHIPPING_STATUS_UUID=value;
			}
			get
			{
				return _SHIPPING_STATUS_UUID;
			}
		}

		[ColumnName("CUST_ORDER_PO_NUMBER",false,typeof(string))]
		public string CUST_ORDER_PO_NUMBER
		{
			set
			{
				_CUST_ORDER_PO_NUMBER=value;
			}
			get
			{
				return _CUST_ORDER_PO_NUMBER;
			}
		}

		[ColumnName("PAY_STATUS_UUID",false,typeof(string))]
		public string PAY_STATUS_UUID
		{
			set
			{
				_PAY_STATUS_UUID=value;
			}
			get
			{
				return _PAY_STATUS_UUID;
			}
		}

		[ColumnName("PAY_METHOD_UUID",false,typeof(string))]
		public string PAY_METHOD_UUID
		{
			set
			{
				_PAY_METHOD_UUID=value;
			}
			get
			{
				return _PAY_METHOD_UUID;
			}
		}

		[ColumnName("CUST_ORDER_INVOICE_NUMBER",false,typeof(string))]
		public string CUST_ORDER_INVOICE_NUMBER
		{
			set
			{
				_CUST_ORDER_INVOICE_NUMBER=value;
			}
			get
			{
				return _CUST_ORDER_INVOICE_NUMBER;
			}
		}

		[ColumnName("CUST_ORDER_LIMIT_DATE",false,typeof(DateTime?))]
		public DateTime? CUST_ORDER_LIMIT_DATE
		{
			set
			{
				_CUST_ORDER_LIMIT_DATE=value;
			}
			get
			{
				return _CUST_ORDER_LIMIT_DATE;
			}
		}

		[ColumnName("CUST_ORG_UUID",false,typeof(string))]
		public string CUST_ORG_UUID
		{
			set
			{
				_CUST_ORG_UUID=value;
			}
			get
			{
				return _CUST_ORG_UUID;
			}
		}

		[ColumnName("CUST_ORDER_HAS_TAX",false,typeof(int?))]
		public int? CUST_ORDER_HAS_TAX
		{
			set
			{
				_CUST_ORDER_HAS_TAX=value;
			}
			get
			{
				return _CUST_ORDER_HAS_TAX;
			}
		}

		[ColumnName("CUST_ORDER_PS",false,typeof(string))]
		public string CUST_ORDER_PS
		{
			set
			{
				_CUST_ORDER_PS=value;
			}
			get
			{
				return _CUST_ORDER_PS;
			}
		}

		[ColumnName("CUST_ORDER_SHIPPING_NUMBER",false,typeof(string))]
		public string CUST_ORDER_SHIPPING_NUMBER
		{
			set
			{
				_CUST_ORDER_SHIPPING_NUMBER=value;
			}
			get
			{
				return _CUST_ORDER_SHIPPING_NUMBER;
			}
		}

		[ColumnName("CUST_NAME",false,typeof(string))]
		public string CUST_NAME
		{
			set
			{
				_CUST_NAME=value;
			}
			get
			{
				return _CUST_NAME;
			}
		}

		[ColumnName("CUST_ADDRESS",false,typeof(string))]
		public string CUST_ADDRESS
		{
			set
			{
				_CUST_ADDRESS=value;
			}
			get
			{
				return _CUST_ADDRESS;
			}
		}

		[ColumnName("CUST_FAX",false,typeof(string))]
		public string CUST_FAX
		{
			set
			{
				_CUST_FAX=value;
			}
			get
			{
				return _CUST_FAX;
			}
		}

		[ColumnName("CUST_IS_ACTIVE",false,typeof(int?))]
		public int? CUST_IS_ACTIVE
		{
			set
			{
				_CUST_IS_ACTIVE=value;
			}
			get
			{
				return _CUST_IS_ACTIVE;
			}
		}

		[ColumnName("CUST_LAST_BUY",false,typeof(DateTime?))]
		public DateTime? CUST_LAST_BUY
		{
			set
			{
				_CUST_LAST_BUY=value;
			}
			get
			{
				return _CUST_LAST_BUY;
			}
		}

		[ColumnName("CUST_PS",false,typeof(string))]
		public string CUST_PS
		{
			set
			{
				_CUST_PS=value;
			}
			get
			{
				return _CUST_PS;
			}
		}

		[ColumnName("CUST_SALES_EMAIL",false,typeof(string))]
		public string CUST_SALES_EMAIL
		{
			set
			{
				_CUST_SALES_EMAIL=value;
			}
			get
			{
				return _CUST_SALES_EMAIL;
			}
		}

		[ColumnName("CUST_SALES_NAME",false,typeof(string))]
		public string CUST_SALES_NAME
		{
			set
			{
				_CUST_SALES_NAME=value;
			}
			get
			{
				return _CUST_SALES_NAME;
			}
		}

		[ColumnName("CUST_SALES_PHONE",false,typeof(string))]
		public string CUST_SALES_PHONE
		{
			set
			{
				_CUST_SALES_PHONE=value;
			}
			get
			{
				return _CUST_SALES_PHONE;
			}
		}

		[ColumnName("CUST_TEL",false,typeof(string))]
		public string CUST_TEL
		{
			set
			{
				_CUST_TEL=value;
			}
			get
			{
				return _CUST_TEL;
			}
		}

		[ColumnName("CUST_ORDER_REPORT_DATE",false,typeof(DateTime?))]
		public DateTime? CUST_ORDER_REPORT_DATE
		{
			set
			{
				_CUST_ORDER_REPORT_DATE=value;
			}
			get
			{
				return _CUST_ORDER_REPORT_DATE;
			}
		}

		[ColumnName("CUST_ORDER_REPORT_ATTENDANT_UUID",false,typeof(string))]
		public string CUST_ORDER_REPORT_ATTENDANT_UUID
		{
			set
			{
				_CUST_ORDER_REPORT_ATTENDANT_UUID=value;
			}
			get
			{
				return _CUST_ORDER_REPORT_ATTENDANT_UUID;
			}
		}

		[ColumnName("CUST_ORDER_REPORT_ATTENDANT_C_NAME",false,typeof(string))]
		public string CUST_ORDER_REPORT_ATTENDANT_C_NAME
		{
			set
			{
				_CUST_ORDER_REPORT_ATTENDANT_C_NAME=value;
			}
			get
			{
				return _CUST_ORDER_REPORT_ATTENDANT_C_NAME;
			}
		}

		[ColumnName("PAY_STATUS_NAME",false,typeof(string))]
		public string PAY_STATUS_NAME
		{
			set
			{
				_PAY_STATUS_NAME=value;
			}
			get
			{
				return _PAY_STATUS_NAME;
			}
		}

		[ColumnName("PAY_METHOD_NAME",false,typeof(string))]
		public string PAY_METHOD_NAME
		{
			set
			{
				_PAY_METHOD_NAME=value;
			}
			get
			{
				return _PAY_METHOD_NAME;
			}
		}

		[ColumnName("CUST_ORG_SALES_NAME",false,typeof(string))]
		public string CUST_ORG_SALES_NAME
		{
			set
			{
				_CUST_ORG_SALES_NAME=value;
			}
			get
			{
				return _CUST_ORG_SALES_NAME;
			}
		}

		[ColumnName("CUST_ORG_SALES_PHONE",false,typeof(string))]
		public string CUST_ORG_SALES_PHONE
		{
			set
			{
				_CUST_ORG_SALES_PHONE=value;
			}
			get
			{
				return _CUST_ORG_SALES_PHONE;
			}
		}

		[ColumnName("CUST_ORG_SALES_EMAIL",false,typeof(string))]
		public string CUST_ORG_SALES_EMAIL
		{
			set
			{
				_CUST_ORG_SALES_EMAIL=value;
			}
			get
			{
				return _CUST_ORG_SALES_EMAIL;
			}
		}

		[ColumnName("CUST_ORG_PS",false,typeof(string))]
		public string CUST_ORG_PS
		{
			set
			{
				_CUST_ORG_PS=value;
			}
			get
			{
				return _CUST_ORG_PS;
			}
		}

		[ColumnName("CUST_ORG_NAME",false,typeof(string))]
		public string CUST_ORG_NAME
		{
			set
			{
				_CUST_ORG_NAME=value;
			}
			get
			{
				return _CUST_ORG_NAME;
			}
		}

		[ColumnName("CUST_ORG_IS_ACTIVE",false,typeof(int?))]
		public int? CUST_ORG_IS_ACTIVE
		{
			set
			{
				_CUST_ORG_IS_ACTIVE=value;
			}
			get
			{
				return _CUST_ORG_IS_ACTIVE;
			}
		}

		[ColumnName("SHIPPING_ADDRESS",false,typeof(string))]
		public string SHIPPING_ADDRESS
		{
			set
			{
				_SHIPPING_ADDRESS=value;
			}
			get
			{
				return _SHIPPING_ADDRESS;
			}
		}

		[ColumnName("COMPANY_UUID",false,typeof(string))]
		public string COMPANY_UUID
		{
			set
			{
				_COMPANY_UUID=value;
			}
			get
			{
				return _COMPANY_UUID;
			}
		}

		[ColumnName("COMPANY_C_NAME",false,typeof(string))]
		public string COMPANY_C_NAME
		{
			set
			{
				_COMPANY_C_NAME=value;
			}
			get
			{
				return _COMPANY_C_NAME;
			}
		}

		[ColumnName("SHIPPING_STATUS_NAME",false,typeof(string))]
		public string SHIPPING_STATUS_NAME
		{
			set
			{
				_SHIPPING_STATUS_NAME=value;
			}
			get
			{
				return _SHIPPING_STATUS_NAME;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_COUNT",false,typeof(int?))]
		public int? CUST_ORDER_DETAIL_COUNT
		{
			set
			{
				_CUST_ORDER_DETAIL_COUNT=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_COUNT;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_CR",false,typeof(DateTime?))]
		public DateTime? CUST_ORDER_DETAIL_CR
		{
			set
			{
				_CUST_ORDER_DETAIL_CR=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_CR;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_CUSTOMIZED",false,typeof(int?))]
		public int? CUST_ORDER_DETAIL_CUSTOMIZED
		{
			set
			{
				_CUST_ORDER_DETAIL_CUSTOMIZED=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_CUSTOMIZED;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_GOODS_NAME",false,typeof(string))]
		public string CUST_ORDER_DETAIL_GOODS_NAME
		{
			set
			{
				_CUST_ORDER_DETAIL_GOODS_NAME=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_GOODS_NAME;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_IS_ACTIVE",false,typeof(int?))]
		public int? CUST_ORDER_DETAIL_IS_ACTIVE
		{
			set
			{
				_CUST_ORDER_DETAIL_IS_ACTIVE=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_IS_ACTIVE;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_PRICE",false,typeof(decimal?))]
		public decimal? CUST_ORDER_DETAIL_PRICE
		{
			set
			{
				_CUST_ORDER_DETAIL_PRICE=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_PRICE;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_PS",false,typeof(string))]
		public string CUST_ORDER_DETAIL_PS
		{
			set
			{
				_CUST_ORDER_DETAIL_PS=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_PS;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_TOTAL_PRICE",false,typeof(decimal?))]
		public decimal? CUST_ORDER_DETAIL_TOTAL_PRICE
		{
			set
			{
				_CUST_ORDER_DETAIL_TOTAL_PRICE=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_TOTAL_PRICE;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_UNIT",false,typeof(string))]
		public string CUST_ORDER_DETAIL_UNIT
		{
			set
			{
				_CUST_ORDER_DETAIL_UNIT=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_UNIT;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_UNIT_NAME",false,typeof(string))]
		public string CUST_ORDER_DETAIL_UNIT_NAME
		{
			set
			{
				_CUST_ORDER_DETAIL_UNIT_NAME=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_UNIT_NAME;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_UUID",true,typeof(string))]
		public string CUST_ORDER_DETAIL_UUID
		{
			set
			{
				_CUST_ORDER_DETAIL_UUID=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_UUID;
			}
		}

		[ColumnName("FILEGROUP_DISPLAY_NAME",false,typeof(string))]
		public string FILEGROUP_DISPLAY_NAME
		{
			set
			{
				_FILEGROUP_DISPLAY_NAME=value;
			}
			get
			{
				return _FILEGROUP_DISPLAY_NAME;
			}
		}

		[ColumnName("FILEGROUP_TAG",false,typeof(string))]
		public string FILEGROUP_TAG
		{
			set
			{
				_FILEGROUP_TAG=value;
			}
			get
			{
				return _FILEGROUP_TAG;
			}
		}

		[ColumnName("FILEGROUP_UUID",false,typeof(string))]
		public string FILEGROUP_UUID
		{
			set
			{
				_FILEGROUP_UUID=value;
			}
			get
			{
				return _FILEGROUP_UUID;
			}
		}

		[ColumnName("FILE_COUNT",false,typeof(int?))]
		public int? FILE_COUNT
		{
			set
			{
				_FILE_COUNT=value;
			}
			get
			{
				return _FILE_COUNT;
			}
		}

		[ColumnName("GCATEGORY_FULL_NAME",false,typeof(string))]
		public string GCATEGORY_FULL_NAME
		{
			set
			{
				_GCATEGORY_FULL_NAME=value;
			}
			get
			{
				return _GCATEGORY_FULL_NAME;
			}
		}

		[ColumnName("GCATEGORY_NAME",false,typeof(string))]
		public string GCATEGORY_NAME
		{
			set
			{
				_GCATEGORY_NAME=value;
			}
			get
			{
				return _GCATEGORY_NAME;
			}
		}

		[ColumnName("GCATEGORY_UUID",false,typeof(string))]
		public string GCATEGORY_UUID
		{
			set
			{
				_GCATEGORY_UUID=value;
			}
			get
			{
				return _GCATEGORY_UUID;
			}
		}

		[ColumnName("GOODS_NAME",false,typeof(string))]
		public string GOODS_NAME
		{
			set
			{
				_GOODS_NAME=value;
			}
			get
			{
				return _GOODS_NAME;
			}
		}

		[ColumnName("GOODS_PRICE",false,typeof(decimal?))]
		public decimal? GOODS_PRICE
		{
			set
			{
				_GOODS_PRICE=value;
			}
			get
			{
				return _GOODS_PRICE;
			}
		}

		[ColumnName("GOODS_PS",false,typeof(string))]
		public string GOODS_PS
		{
			set
			{
				_GOODS_PS=value;
			}
			get
			{
				return _GOODS_PS;
			}
		}

		[ColumnName("GOODS_SN",false,typeof(string))]
		public string GOODS_SN
		{
			set
			{
				_GOODS_SN=value;
			}
			get
			{
				return _GOODS_SN;
			}
		}

		[ColumnName("GOODS_UUID",false,typeof(string))]
		public string GOODS_UUID
		{
			set
			{
				_GOODS_UUID=value;
			}
			get
			{
				return _GOODS_UUID;
			}
		}

		[ColumnName("SUPPLIER_GOODS_NAME",false,typeof(string))]
		public string SUPPLIER_GOODS_NAME
		{
			set
			{
				_SUPPLIER_GOODS_NAME=value;
			}
			get
			{
				return _SUPPLIER_GOODS_NAME;
			}
		}

		[ColumnName("SUPPLIER_GOODS_PRICE",false,typeof(decimal?))]
		public decimal? SUPPLIER_GOODS_PRICE
		{
			set
			{
				_SUPPLIER_GOODS_PRICE=value;
			}
			get
			{
				return _SUPPLIER_GOODS_PRICE;
			}
		}

		[ColumnName("SUPPLIER_GOODS_SN",false,typeof(string))]
		public string SUPPLIER_GOODS_SN
		{
			set
			{
				_SUPPLIER_GOODS_SN=value;
			}
			get
			{
				return _SUPPLIER_GOODS_SN;
			}
		}

		[ColumnName("SUPPLIER_GOODS_UNIT_UUID",false,typeof(string))]
		public string SUPPLIER_GOODS_UNIT_UUID
		{
			set
			{
				_SUPPLIER_GOODS_UNIT_UUID=value;
			}
			get
			{
				return _SUPPLIER_GOODS_UNIT_UUID;
			}
		}

		[ColumnName("SUPPLIER_GOODS_UUID",false,typeof(string))]
		public string SUPPLIER_GOODS_UUID
		{
			set
			{
				_SUPPLIER_GOODS_UUID=value;
			}
			get
			{
				return _SUPPLIER_GOODS_UUID;
			}
		}

		[ColumnName("UNIT_NAME",false,typeof(string))]
		public string UNIT_NAME
		{
			set
			{
				_UNIT_NAME=value;
			}
			get
			{
				return _UNIT_NAME;
			}
		}
		public VCustOrderSearch_Record Clone(){
			try{
				return this.Clone<VCustOrderSearch_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VCustOrderSearch gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VCustOrderSearch ret = new VCustOrderSearch(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
