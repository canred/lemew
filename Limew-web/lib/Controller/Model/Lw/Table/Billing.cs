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
	[TableView("BILLING", true)]
	public partial class Billing : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private Billing_Record _currentRecord = null;
	private IList<Billing_Record> _All_Record = new List<Billing_Record>();
		/*建構子*/
		public Billing(){}
		public Billing(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public Billing(IDataBaseConfigInfo dbc): base(dbc){}
		public Billing(IDataBaseConfigInfo dbc,Billing_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public Billing(IList<Billing_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string BILLING_UUID {
			[ColumnName("BILLING_UUID",true,typeof(string))]
			get{return "BILLING_UUID" ; }}
		public string BILLING_ID {
			[ColumnName("BILLING_ID",false,typeof(string))]
			get{return "BILLING_ID" ; }}
		public string CUST_UUID {
			[ColumnName("CUST_UUID",false,typeof(string))]
			get{return "CUST_UUID" ; }}
		public string BILLING_START_DATE {
			[ColumnName("BILLING_START_DATE",false,typeof(DateTime?))]
			get{return "BILLING_START_DATE" ; }}
		public string BILLING_END_DATE {
			[ColumnName("BILLING_END_DATE",false,typeof(DateTime?))]
			get{return "BILLING_END_DATE" ; }}
		public string BILLING_REPORT_DATE {
			[ColumnName("BILLING_REPORT_DATE",false,typeof(DateTime?))]
			get{return "BILLING_REPORT_DATE" ; }}
		public string BILLING_CUST_NAME {
			[ColumnName("BILLING_CUST_NAME",false,typeof(string))]
			get{return "BILLING_CUST_NAME" ; }}
		public string BILLING_CUST_UNIFORM_NUM {
			[ColumnName("BILLING_CUST_UNIFORM_NUM",false,typeof(string))]
			get{return "BILLING_CUST_UNIFORM_NUM" ; }}
		public string BILLING_TEL {
			[ColumnName("BILLING_TEL",false,typeof(string))]
			get{return "BILLING_TEL" ; }}
		public string BILLING_CUST_ADDRESS {
			[ColumnName("BILLING_CUST_ADDRESS",false,typeof(string))]
			get{return "BILLING_CUST_ADDRESS" ; }}
		public string BILLING_SALES_NAME {
			[ColumnName("BILLING_SALES_NAME",false,typeof(string))]
			get{return "BILLING_SALES_NAME" ; }}
		public string BILLING_ITEM_COUNT {
			[ColumnName("BILLING_ITEM_COUNT",false,typeof(int?))]
			get{return "BILLING_ITEM_COUNT" ; }}
		public string BILLING_DISCOUNT {
			[ColumnName("BILLING_DISCOUNT",false,typeof(decimal?))]
			get{return "BILLING_DISCOUNT" ; }}
		public string BILLING_SUM_PRICE {
			[ColumnName("BILLING_SUM_PRICE",false,typeof(decimal?))]
			get{return "BILLING_SUM_PRICE" ; }}
		public string BILLING_ARREARS_PRICE {
			[ColumnName("BILLING_ARREARS_PRICE",false,typeof(decimal?))]
			get{return "BILLING_ARREARS_PRICE" ; }}
		public string BILLING_TAX {
			[ColumnName("BILLING_TAX",false,typeof(decimal?))]
			get{return "BILLING_TAX" ; }}
		public string BILLING_TOTAL_PRICE {
			[ColumnName("BILLING_TOTAL_PRICE",false,typeof(decimal?))]
			get{return "BILLING_TOTAL_PRICE" ; }}
		public string BILLING_CHECK_YY {
			[ColumnName("BILLING_CHECK_YY",false,typeof(string))]
			get{return "BILLING_CHECK_YY" ; }}
		public string BILLING_CHECK_MM {
			[ColumnName("BILLING_CHECK_MM",false,typeof(string))]
			get{return "BILLING_CHECK_MM" ; }}
		public string BILLING_CHECK_TITLE {
			[ColumnName("BILLING_CHECK_TITLE",false,typeof(string))]
			get{return "BILLING_CHECK_TITLE" ; }}
		public string BILLING_CONTACT_USER_NAME {
			[ColumnName("BILLING_CONTACT_USER_NAME",false,typeof(string))]
			get{return "BILLING_CONTACT_USER_NAME" ; }}
		public string BILLING_CONTACT_ATTENDANT_UUID {
			[ColumnName("BILLING_CONTACT_ATTENDANT_UUID",false,typeof(string))]
			get{return "BILLING_CONTACT_ATTENDANT_UUID" ; }}
		public string BILLING_BACK_ACCOUNT_NUMBER {
			[ColumnName("BILLING_BACK_ACCOUNT_NUMBER",false,typeof(string))]
			get{return "BILLING_BACK_ACCOUNT_NUMBER" ; }}
		public string BILLING_BACK_NAME {
			[ColumnName("BILLING_BACK_NAME",false,typeof(string))]
			get{return "BILLING_BACK_NAME" ; }}
		public string BILLING_BACK_SUB_NAME {
			[ColumnName("BILLING_BACK_SUB_NAME",false,typeof(string))]
			get{return "BILLING_BACK_SUB_NAME" ; }}
		public string BILLING_BACK_ACCOUNT_NAME {
			[ColumnName("BILLING_BACK_ACCOUNT_NAME",false,typeof(string))]
			get{return "BILLING_BACK_ACCOUNT_NAME" ; }}
		public string BILLING_PS {
			[ColumnName("BILLING_PS",false,typeof(string))]
			get{return "BILLING_PS" ; }}
		public string BILLING_STATUS_ID {
			[ColumnName("BILLING_STATUS_ID",false,typeof(string))]
			get{return "BILLING_STATUS_ID" ; }}
		public string BILLING_IS_ACTIVE {
			[ColumnName("BILLING_IS_ACTIVE",false,typeof(int?))]
			get{return "BILLING_IS_ACTIVE" ; }}
		public string BILLING_REPORT_ATTENDANT_UUID {
			[ColumnName("BILLING_REPORT_ATTENDANT_UUID",false,typeof(string))]
			get{return "BILLING_REPORT_ATTENDANT_UUID" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public Billing_Record CurrentRecord(){
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
		public Billing_Record CreateNew(){
			try{
				Billing_Record newData = new Billing_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<Billing_Record> AllRecord(){
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
				_All_Record = new List<Billing_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public Billing Fill_By_PK(string pbilling_uuid){
			try{
				IList<Billing_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_UUID,pbilling_uuid)
				).FetchAll<Billing_Record>()  ;  
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
		public Billing Fill_By_PK(string pbilling_uuid,DB db){
			try{
				IList<Billing_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_UUID,pbilling_uuid)
				).FetchAll<Billing_Record>(db)  ;  
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
		public Billing_Record Fetch_By_PK(string pbilling_uuid){
			try{
				IList<Billing_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_UUID,pbilling_uuid)
				).FetchAll<Billing_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public Billing_Record Fetch_By_PK(string pbilling_uuid,DB db){
			try{
				IList<Billing_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_UUID,pbilling_uuid)
				).FetchAll<Billing_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public Billing Fill_By_BillingUuid(string pbilling_uuid){
			try{
				IList<Billing_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_UUID,pbilling_uuid)
				).FetchAll<Billing_Record>()  ;  
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
		public Billing Fill_By_BillingUuid(string pbilling_uuid,DB db){
			try{
				IList<Billing_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_UUID,pbilling_uuid)
				).FetchAll<Billing_Record>(db)  ;  
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
		public Billing_Record Fetch_By_BillingUuid(string pbilling_uuid){
			try{
				IList<Billing_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_UUID,pbilling_uuid)
				).FetchAll<Billing_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public Billing_Record Fetch_By_BillingUuid(string pbilling_uuid,DB db){
			try{
				IList<Billing_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_UUID,pbilling_uuid)
				).FetchAll<Billing_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord() {
			try{
				UpdateAllRecord<Billing_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<Billing_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<Billing_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<Billing_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<Billing_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<Billing_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<BillingDetail_Record> Link_BillingDetail_By_BillingUuid()
		{
			try{
				List<BillingDetail_Record> ret= new List<BillingDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				BillingDetail ___table = new BillingDetail(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.BILLING_UUID,item.BILLING_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<BillingDetail_Record>)
						___table.Where(condition)
						.FetchAll<BillingDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<BillingDetail_Record> Link_BillingDetail_By_BillingUuid(OrderLimit limit)
		{
			try{
				List<BillingDetail_Record> ret= new List<BillingDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				BillingDetail ___table = new BillingDetail(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.BILLING_UUID,item.BILLING_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<BillingDetail_Record>)
						___table.Where(condition)
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
		/*201303180324*/
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
		/*201303180325*/
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
