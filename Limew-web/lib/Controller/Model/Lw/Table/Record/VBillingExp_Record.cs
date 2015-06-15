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
	[TableView("V_BILLING_EXP", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class VBillingExp_Record : RecordBase{
		public VBillingExp_Record(){}
		/*欄位資訊 Start*/
		string _BILLING_ID=null;
		DateTime? _BILLING_START_DATE=null;
		DateTime? _BILLING_END_DATE=null;
		DateTime? _BILLING_REPORT_DATE=null;
		string _BILLING_CUST_NAME=null;
		string _BILLING_CUST_UNIFORM_NUM=null;
		string _BILLING_TEL=null;
		string _BILLING_CUST_ADDRESS=null;
		string _BILLING_SALES_NAME=null;
		int? _BILLING_ITEM_COUNT=null;
		decimal? _BILLING_DISCOUNT=null;
		decimal? _BILLING_SUM_PRICE=null;
		decimal? _BILLING_ARREARS_PRICE=null;
		decimal? _BILLING_TAX=null;
		decimal? _BILLING_TOTAL_PRICE=null;
		string _BILLING_CHECK_YY=null;
		string _BILLING_CHECK_MM=null;
		string _BILLING_CHECK_TITLE=null;
		string _BILLING_CONTACT_USER_NAME=null;
		string _BILLING_CONTACT_ATTENDANT_UUID=null;
		string _BILLING_BACK_ACCOUNT_NUMBER=null;
		string _BILLING_BACK_NAME=null;
		string _BILLING_BACK_SUB_NAME=null;
		string _BILLING_BACK_ACCOUNT_NAME=null;
		string _BILLING_PS=null;
		int? _BILLING_IS_ACTIVE=null;
		string _BILLING_REPORT_ATTENDANT_UUID=null;
		DateTime? _BILLING_DETAIL_CR=null;
		string _BILLING_DETAIL_UUID=null;
		string _BILLING_UUID=null;
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
		string _CUST_ORDER_PS_NUMBER=null;
		string _CUST_ORDER_PAY_PS=null;
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
		string _GOODS_NAME=null;
		decimal? _GOODS_PRICE=null;
		string _GOODS_PS=null;
		string _GOODS_SN=null;
		string _GOODS_UUID=null;
		/*欄位資訊 End*/

		[ColumnName("BILLING_ID",false,typeof(string))]
		public string BILLING_ID
		{
			set
			{
				_BILLING_ID=value;
			}
			get
			{
				return _BILLING_ID;
			}
		}

		[ColumnName("BILLING_START_DATE",false,typeof(DateTime?))]
		public DateTime? BILLING_START_DATE
		{
			set
			{
				_BILLING_START_DATE=value;
			}
			get
			{
				return _BILLING_START_DATE;
			}
		}

		[ColumnName("BILLING_END_DATE",false,typeof(DateTime?))]
		public DateTime? BILLING_END_DATE
		{
			set
			{
				_BILLING_END_DATE=value;
			}
			get
			{
				return _BILLING_END_DATE;
			}
		}

		[ColumnName("BILLING_REPORT_DATE",false,typeof(DateTime?))]
		public DateTime? BILLING_REPORT_DATE
		{
			set
			{
				_BILLING_REPORT_DATE=value;
			}
			get
			{
				return _BILLING_REPORT_DATE;
			}
		}

		[ColumnName("BILLING_CUST_NAME",false,typeof(string))]
		public string BILLING_CUST_NAME
		{
			set
			{
				_BILLING_CUST_NAME=value;
			}
			get
			{
				return _BILLING_CUST_NAME;
			}
		}

		[ColumnName("BILLING_CUST_UNIFORM_NUM",false,typeof(string))]
		public string BILLING_CUST_UNIFORM_NUM
		{
			set
			{
				_BILLING_CUST_UNIFORM_NUM=value;
			}
			get
			{
				return _BILLING_CUST_UNIFORM_NUM;
			}
		}

		[ColumnName("BILLING_TEL",false,typeof(string))]
		public string BILLING_TEL
		{
			set
			{
				_BILLING_TEL=value;
			}
			get
			{
				return _BILLING_TEL;
			}
		}

		[ColumnName("BILLING_CUST_ADDRESS",false,typeof(string))]
		public string BILLING_CUST_ADDRESS
		{
			set
			{
				_BILLING_CUST_ADDRESS=value;
			}
			get
			{
				return _BILLING_CUST_ADDRESS;
			}
		}

		[ColumnName("BILLING_SALES_NAME",false,typeof(string))]
		public string BILLING_SALES_NAME
		{
			set
			{
				_BILLING_SALES_NAME=value;
			}
			get
			{
				return _BILLING_SALES_NAME;
			}
		}

		[ColumnName("BILLING_ITEM_COUNT",false,typeof(int?))]
		public int? BILLING_ITEM_COUNT
		{
			set
			{
				_BILLING_ITEM_COUNT=value;
			}
			get
			{
				return _BILLING_ITEM_COUNT;
			}
		}

		[ColumnName("BILLING_DISCOUNT",false,typeof(decimal?))]
		public decimal? BILLING_DISCOUNT
		{
			set
			{
				_BILLING_DISCOUNT=value;
			}
			get
			{
				return _BILLING_DISCOUNT;
			}
		}

		[ColumnName("BILLING_SUM_PRICE",false,typeof(decimal?))]
		public decimal? BILLING_SUM_PRICE
		{
			set
			{
				_BILLING_SUM_PRICE=value;
			}
			get
			{
				return _BILLING_SUM_PRICE;
			}
		}

		[ColumnName("BILLING_ARREARS_PRICE",false,typeof(decimal?))]
		public decimal? BILLING_ARREARS_PRICE
		{
			set
			{
				_BILLING_ARREARS_PRICE=value;
			}
			get
			{
				return _BILLING_ARREARS_PRICE;
			}
		}

		[ColumnName("BILLING_TAX",false,typeof(decimal?))]
		public decimal? BILLING_TAX
		{
			set
			{
				_BILLING_TAX=value;
			}
			get
			{
				return _BILLING_TAX;
			}
		}

		[ColumnName("BILLING_TOTAL_PRICE",false,typeof(decimal?))]
		public decimal? BILLING_TOTAL_PRICE
		{
			set
			{
				_BILLING_TOTAL_PRICE=value;
			}
			get
			{
				return _BILLING_TOTAL_PRICE;
			}
		}

		[ColumnName("BILLING_CHECK_YY",false,typeof(string))]
		public string BILLING_CHECK_YY
		{
			set
			{
				_BILLING_CHECK_YY=value;
			}
			get
			{
				return _BILLING_CHECK_YY;
			}
		}

		[ColumnName("BILLING_CHECK_MM",false,typeof(string))]
		public string BILLING_CHECK_MM
		{
			set
			{
				_BILLING_CHECK_MM=value;
			}
			get
			{
				return _BILLING_CHECK_MM;
			}
		}

		[ColumnName("BILLING_CHECK_TITLE",false,typeof(string))]
		public string BILLING_CHECK_TITLE
		{
			set
			{
				_BILLING_CHECK_TITLE=value;
			}
			get
			{
				return _BILLING_CHECK_TITLE;
			}
		}

		[ColumnName("BILLING_CONTACT_USER_NAME",false,typeof(string))]
		public string BILLING_CONTACT_USER_NAME
		{
			set
			{
				_BILLING_CONTACT_USER_NAME=value;
			}
			get
			{
				return _BILLING_CONTACT_USER_NAME;
			}
		}

		[ColumnName("BILLING_CONTACT_ATTENDANT_UUID",false,typeof(string))]
		public string BILLING_CONTACT_ATTENDANT_UUID
		{
			set
			{
				_BILLING_CONTACT_ATTENDANT_UUID=value;
			}
			get
			{
				return _BILLING_CONTACT_ATTENDANT_UUID;
			}
		}

		[ColumnName("BILLING_BACK_ACCOUNT_NUMBER",false,typeof(string))]
		public string BILLING_BACK_ACCOUNT_NUMBER
		{
			set
			{
				_BILLING_BACK_ACCOUNT_NUMBER=value;
			}
			get
			{
				return _BILLING_BACK_ACCOUNT_NUMBER;
			}
		}

		[ColumnName("BILLING_BACK_NAME",false,typeof(string))]
		public string BILLING_BACK_NAME
		{
			set
			{
				_BILLING_BACK_NAME=value;
			}
			get
			{
				return _BILLING_BACK_NAME;
			}
		}

		[ColumnName("BILLING_BACK_SUB_NAME",false,typeof(string))]
		public string BILLING_BACK_SUB_NAME
		{
			set
			{
				_BILLING_BACK_SUB_NAME=value;
			}
			get
			{
				return _BILLING_BACK_SUB_NAME;
			}
		}

		[ColumnName("BILLING_BACK_ACCOUNT_NAME",false,typeof(string))]
		public string BILLING_BACK_ACCOUNT_NAME
		{
			set
			{
				_BILLING_BACK_ACCOUNT_NAME=value;
			}
			get
			{
				return _BILLING_BACK_ACCOUNT_NAME;
			}
		}

		[ColumnName("BILLING_PS",false,typeof(string))]
		public string BILLING_PS
		{
			set
			{
				_BILLING_PS=value;
			}
			get
			{
				return _BILLING_PS;
			}
		}

		[ColumnName("BILLING_IS_ACTIVE",false,typeof(int?))]
		public int? BILLING_IS_ACTIVE
		{
			set
			{
				_BILLING_IS_ACTIVE=value;
			}
			get
			{
				return _BILLING_IS_ACTIVE;
			}
		}

		[ColumnName("BILLING_REPORT_ATTENDANT_UUID",false,typeof(string))]
		public string BILLING_REPORT_ATTENDANT_UUID
		{
			set
			{
				_BILLING_REPORT_ATTENDANT_UUID=value;
			}
			get
			{
				return _BILLING_REPORT_ATTENDANT_UUID;
			}
		}

		[ColumnName("BILLING_DETAIL_CR",false,typeof(DateTime?))]
		public DateTime? BILLING_DETAIL_CR
		{
			set
			{
				_BILLING_DETAIL_CR=value;
			}
			get
			{
				return _BILLING_DETAIL_CR;
			}
		}

		[ColumnName("BILLING_DETAIL_UUID",true,typeof(string))]
		public string BILLING_DETAIL_UUID
		{
			set
			{
				_BILLING_DETAIL_UUID=value;
			}
			get
			{
				return _BILLING_DETAIL_UUID;
			}
		}

		[ColumnName("BILLING_UUID",false,typeof(string))]
		public string BILLING_UUID
		{
			set
			{
				_BILLING_UUID=value;
			}
			get
			{
				return _BILLING_UUID;
			}
		}

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

		[ColumnName("CUST_ORDER_PS_NUMBER",false,typeof(string))]
		public string CUST_ORDER_PS_NUMBER
		{
			set
			{
				_CUST_ORDER_PS_NUMBER=value;
			}
			get
			{
				return _CUST_ORDER_PS_NUMBER;
			}
		}

		[ColumnName("CUST_ORDER_PAY_PS",false,typeof(string))]
		public string CUST_ORDER_PAY_PS
		{
			set
			{
				_CUST_ORDER_PAY_PS=value;
			}
			get
			{
				return _CUST_ORDER_PAY_PS;
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
		public VBillingExp_Record Clone(){
			try{
				return this.Clone<VBillingExp_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VBillingExp gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VBillingExp ret = new VBillingExp(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
