using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using LK.Attribute;  
using LK.DB;  
using LK.Config.DataBase;  
using LK.DB.SQLCreater;  
using Limew.Model.Lw.Table.Record  ;  
namespace Limew.Model.Lw.Table
{
	[LkDataBase("LIMEW")]
	[TableView("CUST_ORDER", false)]
	public partial class CustOrder : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private CustOrder_Record _currentRecord = null;
	private IList<CustOrder_Record> _All_Record = new List<CustOrder_Record>();
		/*建構子*/
		public CustOrder(){}
		public CustOrder(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public CustOrder(IDataBaseConfigInfo dbc): base(dbc){}
		public CustOrder(IDataBaseConfigInfo dbc,CustOrder_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public CustOrder(IList<CustOrder_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string CUST_ORDER_UUID {
			[ColumnName("CUST_ORDER_UUID",true,typeof(string))]
			get{return "CUST_ORDER_UUID" ; }}
		public string CUST_ORDER_CR {
			[ColumnName("CUST_ORDER_CR",false,typeof(DateTime?))]
			get{return "CUST_ORDER_CR" ; }}
		public string CUST_ORDER_ID {
			[ColumnName("CUST_ORDER_ID",false,typeof(string))]
			get{return "CUST_ORDER_ID" ; }}
		public string CUST_ORDER_TOTAL_PRICE {
			[ColumnName("CUST_ORDER_TOTAL_PRICE",false,typeof(decimal?))]
			get{return "CUST_ORDER_TOTAL_PRICE" ; }}
		public string CUST_ORDER_STATUS_UUID {
			[ColumnName("CUST_ORDER_STATUS_UUID",false,typeof(string))]
			get{return "CUST_ORDER_STATUS_UUID" ; }}
		public string CUST_ORDER_IS_ACTIVE {
			[ColumnName("CUST_ORDER_IS_ACTIVE",false,typeof(int?))]
			get{return "CUST_ORDER_IS_ACTIVE" ; }}
		public string CUST_UUID {
			[ColumnName("CUST_UUID",false,typeof(string))]
			get{return "CUST_UUID" ; }}
		public string CUST_ORDER_TYPE {
			[ColumnName("CUST_ORDER_TYPE",false,typeof(string))]
			get{return "CUST_ORDER_TYPE" ; }}
		public string CUST_ORDER_CUST_NAME {
			[ColumnName("CUST_ORDER_CUST_NAME",false,typeof(string))]
			get{return "CUST_ORDER_CUST_NAME" ; }}
		public string CUST_ORDER_DEPT {
			[ColumnName("CUST_ORDER_DEPT",false,typeof(string))]
			get{return "CUST_ORDER_DEPT" ; }}
		public string CUST_ORDER_USER_NAME {
			[ColumnName("CUST_ORDER_USER_NAME",false,typeof(string))]
			get{return "CUST_ORDER_USER_NAME" ; }}
		public string CUST_ORDER_USER_PHONE {
			[ColumnName("CUST_ORDER_USER_PHONE",false,typeof(string))]
			get{return "CUST_ORDER_USER_PHONE" ; }}
		public string CUST_ORDER_PURCHASE_AMOUNT {
			[ColumnName("CUST_ORDER_PURCHASE_AMOUNT",false,typeof(string))]
			get{return "CUST_ORDER_PURCHASE_AMOUNT" ; }}
		public string CUST_ORDER_PRINT_USER_NAME {
			[ColumnName("CUST_ORDER_PRINT_USER_NAME",false,typeof(string))]
			get{return "CUST_ORDER_PRINT_USER_NAME" ; }}
		public string CUST_ORDER_SHIPPING_DATE {
			[ColumnName("CUST_ORDER_SHIPPING_DATE",false,typeof(DateTime?))]
			get{return "CUST_ORDER_SHIPPING_DATE" ; }}
		public string SHIPPING_STATUS_UUID {
			[ColumnName("SHIPPING_STATUS_UUID",false,typeof(string))]
			get{return "SHIPPING_STATUS_UUID" ; }}
		public string CUST_ORDER_PO_NUMBER {
			[ColumnName("CUST_ORDER_PO_NUMBER",false,typeof(string))]
			get{return "CUST_ORDER_PO_NUMBER" ; }}
		public string PAY_STATUS_UUID {
			[ColumnName("PAY_STATUS_UUID",false,typeof(string))]
			get{return "PAY_STATUS_UUID" ; }}
		public string PAY_METHOD_UUID {
			[ColumnName("PAY_METHOD_UUID",false,typeof(string))]
			get{return "PAY_METHOD_UUID" ; }}
		public string CUST_ORDER_INVOICE_NUMBER {
			[ColumnName("CUST_ORDER_INVOICE_NUMBER",false,typeof(string))]
			get{return "CUST_ORDER_INVOICE_NUMBER" ; }}
		public string CUST_ORDER_LIMIT_DATE {
			[ColumnName("CUST_ORDER_LIMIT_DATE",false,typeof(DateTime?))]
			get{return "CUST_ORDER_LIMIT_DATE" ; }}
		public string CUST_ORG_UUID {
			[ColumnName("CUST_ORG_UUID",false,typeof(string))]
			get{return "CUST_ORG_UUID" ; }}
		public string CUST_ORDER_HAS_TAX {
			[ColumnName("CUST_ORDER_HAS_TAX",false,typeof(int?))]
			get{return "CUST_ORDER_HAS_TAX" ; }}
		public string CUST_ORDER_PS {
			[ColumnName("CUST_ORDER_PS",false,typeof(string))]
			get{return "CUST_ORDER_PS" ; }}
		public string COMPANY_UUID {
			[ColumnName("COMPANY_UUID",false,typeof(string))]
			get{return "COMPANY_UUID" ; }}
		public string CUST_ORDER_REPORT_DATE {
			[ColumnName("CUST_ORDER_REPORT_DATE",false,typeof(DateTime?))]
			get{return "CUST_ORDER_REPORT_DATE" ; }}
		public string CUST_ORDER_REPORT_ATTENDANT_UUID {
			[ColumnName("CUST_ORDER_REPORT_ATTENDANT_UUID",false,typeof(string))]
			get{return "CUST_ORDER_REPORT_ATTENDANT_UUID" ; }}
		public string CUST_ORDER_SHIPPING_NUMBER {
			[ColumnName("CUST_ORDER_SHIPPING_NUMBER",false,typeof(string))]
			get{return "CUST_ORDER_SHIPPING_NUMBER" ; }}
		public string SHIPPING_ADDRESS {
			[ColumnName("SHIPPING_ADDRESS",false,typeof(string))]
			get{return "SHIPPING_ADDRESS" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public CustOrder_Record CurrentRecord(){
			try{
				if (_currentRecord == null){
					if (this._All_Record.Count > 0){
						_currentRecord = this._All_Record.First();
					}
				}
				return _currentRecord;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public CustOrder_Record CreateNew(){
			try{
				CustOrder_Record newData = new CustOrder_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<CustOrder_Record> AllRecord(){
			try{
				return _All_Record;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public void RemoveAllRecord(){
			try{
				_All_Record = new List<CustOrder_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public CustOrder Fill_By_PK(string pcust_order_uuid){
			try{
				IList<CustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<CustOrder_Record>()  ;  
				_All_Record = ret;
				if (_All_Record.Count > 0){
					_currentRecord = ret.First();}
				else{
					_currentRecord = null;}
				return this;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 201303180156
		public CustOrder Fill_By_PK(string pcust_order_uuid,DB db){
			try{
				IList<CustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<CustOrder_Record>(db)  ;  
				_All_Record = ret;
				if (_All_Record.Count > 0){
					_currentRecord = ret.First();}
				else{
					_currentRecord = null;}
				return this;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319042
		public CustOrder_Record Fetch_By_PK(string pcust_order_uuid){
			try{
				IList<CustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<CustOrder_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public CustOrder_Record Fetch_By_PK(string pcust_order_uuid,DB db){
			try{
				IList<CustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<CustOrder_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public CustOrder Fill_By_CustOrderUuid(string pcust_order_uuid){
			try{
				IList<CustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<CustOrder_Record>()  ;  
				_All_Record = ret;
				_currentRecord = ret.First();
				return this;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319046
		public CustOrder Fill_By_CustOrderUuid(string pcust_order_uuid,DB db){
			try{
				IList<CustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<CustOrder_Record>(db)  ;  
				_All_Record = ret;
				_currentRecord = ret.First();
				return this;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319047
		public CustOrder_Record Fetch_By_CustOrderUuid(string pcust_order_uuid){
			try{
				IList<CustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<CustOrder_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public CustOrder_Record Fetch_By_CustOrderUuid(string pcust_order_uuid,DB db){
			try{
				IList<CustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<CustOrder_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<CustOrderDetail_Record> Link_CustOrderDetail_By_CustOrderUuid()
		{
			try{
				List<CustOrderDetail_Record> ret= new List<CustOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderDetail ___table = new CustOrderDetail(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_ORDER_UUID,item.CUST_ORDER_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrderDetail_Record>)
						___table.Where(condition)
						.FetchAll<CustOrderDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<CustOrderDetail_Record> Link_CustOrderDetail_By_CustOrderUuid(OrderLimit limit)
		{
			try{
				List<CustOrderDetail_Record> ret= new List<CustOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderDetail ___table = new CustOrderDetail(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_ORDER_UUID,item.CUST_ORDER_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrderDetail_Record>)
						___table.Where(condition)
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
		/*201303180324*/
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
		/*201303180325*/
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
