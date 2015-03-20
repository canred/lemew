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
	[TableView("CUST_ORDER", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class CustOrder_Record : RecordBase{
		public CustOrder_Record(){}
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
		string _COMPANY_UUID=null;
		DateTime? _CUST_ORDER_REPORT_DATE=null;
		string _CUST_ORDER_REPORT_ATTENDANT_UUID=null;
		string _CUST_ORDER_SHIPPING_NUMBER=null;
		string _SHIPPING_ADDRESS=null;
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
		public CustOrder_Record Clone(){
			try{
				return this.Clone<CustOrder_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public CustOrder gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ret = new CustOrder(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<CustOrderDetail_Record> Link_CustOrderDetail_By_CustOrderUuid()
		{
			try{
				List<CustOrderDetail_Record> ret= new List<CustOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderDetail ___table = new CustOrderDetail(dbc);
				ret=(List<CustOrderDetail_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORDER_UUID,this.CUST_ORDER_UUID))
					.FetchAll<CustOrderDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<CustOrderDetail_Record> Link_CustOrderDetail_By_CustOrderUuid(OrderLimit limit)
		{
			try{
				List<CustOrderDetail_Record> ret= new List<CustOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderDetail ___table = new CustOrderDetail(dbc);
				ret=(List<CustOrderDetail_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORDER_UUID,this.CUST_ORDER_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<CustOrderDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public CustOrderDetail LinkFill_CustOrderDetail_By_CustOrderUuid()
		{
			try{
				var data = Link_CustOrderDetail_By_CustOrderUuid();
				CustOrderDetail ret=new CustOrderDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public CustOrderDetail LinkFill_CustOrderDetail_By_CustOrderUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrderDetail_By_CustOrderUuid(limit);
				CustOrderDetail ret=new CustOrderDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
