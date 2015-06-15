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
	[TableView("BILLING", true)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class Billing_Record : RecordBase{
		public Billing_Record(){}
		/*欄位資訊 Start*/
		string _BILLING_UUID=null;
		string _BILLING_ID=null;
		string _CUST_UUID=null;
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
		string _BILLING_STATUS_ID=null;
		int? _BILLING_IS_ACTIVE=null;
		string _BILLING_REPORT_ATTENDANT_UUID=null;
		/*欄位資訊 End*/

		[ColumnName("BILLING_UUID",true,typeof(string))]
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

		[ColumnName("BILLING_STATUS_ID",false,typeof(string))]
		public string BILLING_STATUS_ID
		{
			set
			{
				_BILLING_STATUS_ID=value;
			}
			get
			{
				return _BILLING_STATUS_ID;
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
		public Billing_Record Clone(){
			try{
				return this.Clone<Billing_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public Billing gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Billing ret = new Billing(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<BillingDetail_Record> Link_BillingDetail_By_BillingUuid()
		{
			try{
				List<BillingDetail_Record> ret= new List<BillingDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				BillingDetail ___table = new BillingDetail(dbc);
				ret=(List<BillingDetail_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.BILLING_UUID,this.BILLING_UUID))
					.FetchAll<BillingDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<BillingDetail_Record> Link_BillingDetail_By_BillingUuid(OrderLimit limit)
		{
			try{
				List<BillingDetail_Record> ret= new List<BillingDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				BillingDetail ___table = new BillingDetail(dbc);
				ret=(List<BillingDetail_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.BILLING_UUID,this.BILLING_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<BillingDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public BillingDetail LinkFill_BillingDetail_By_BillingUuid()
		{
			try{
				var data = Link_BillingDetail_By_BillingUuid();
				BillingDetail ret=new BillingDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public BillingDetail LinkFill_BillingDetail_By_BillingUuid(OrderLimit limit)
		{
			try{
				var data = Link_BillingDetail_By_BillingUuid(limit);
				BillingDetail ret=new BillingDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
