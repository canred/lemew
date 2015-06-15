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
	[TableView("BILLING_DETAIL", true)]
	public partial class BillingDetail : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private BillingDetail_Record _currentRecord = null;
	private IList<BillingDetail_Record> _All_Record = new List<BillingDetail_Record>();
		/*建構子*/
		public BillingDetail(){}
		public BillingDetail(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public BillingDetail(IDataBaseConfigInfo dbc): base(dbc){}
		public BillingDetail(IDataBaseConfigInfo dbc,BillingDetail_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public BillingDetail(IList<BillingDetail_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string BILLING_DETAIL_UUID {
			[ColumnName("BILLING_DETAIL_UUID",true,typeof(string))]
			get{return "BILLING_DETAIL_UUID" ; }}
		public string CUST_ORDER_UUID {
			[ColumnName("CUST_ORDER_UUID",false,typeof(string))]
			get{return "CUST_ORDER_UUID" ; }}
		public string BILLING_DETAIL_CR {
			[ColumnName("BILLING_DETAIL_CR",false,typeof(DateTime?))]
			get{return "BILLING_DETAIL_CR" ; }}
		public string BILLING_UUID {
			[ColumnName("BILLING_UUID",false,typeof(string))]
			get{return "BILLING_UUID" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public BillingDetail_Record CurrentRecord(){
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
		public BillingDetail_Record CreateNew(){
			try{
				BillingDetail_Record newData = new BillingDetail_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<BillingDetail_Record> AllRecord(){
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
				_All_Record = new List<BillingDetail_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public BillingDetail Fill_By_PK(string pbilling_detail_uuid){
			try{
				IList<BillingDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
				).FetchAll<BillingDetail_Record>()  ;  
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
		public BillingDetail Fill_By_PK(string pbilling_detail_uuid,DB db){
			try{
				IList<BillingDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
				).FetchAll<BillingDetail_Record>(db)  ;  
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
		public BillingDetail_Record Fetch_By_PK(string pbilling_detail_uuid){
			try{
				IList<BillingDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
				).FetchAll<BillingDetail_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public BillingDetail_Record Fetch_By_PK(string pbilling_detail_uuid,DB db){
			try{
				IList<BillingDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
				).FetchAll<BillingDetail_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public BillingDetail Fill_By_BillingDetailUuid(string pbilling_detail_uuid){
			try{
				IList<BillingDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
				).FetchAll<BillingDetail_Record>()  ;  
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
		public BillingDetail Fill_By_BillingDetailUuid(string pbilling_detail_uuid,DB db){
			try{
				IList<BillingDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
				).FetchAll<BillingDetail_Record>(db)  ;  
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
		public BillingDetail_Record Fetch_By_BillingDetailUuid(string pbilling_detail_uuid){
			try{
				IList<BillingDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
				).FetchAll<BillingDetail_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public BillingDetail_Record Fetch_By_BillingDetailUuid(string pbilling_detail_uuid,DB db){
			try{
				IList<BillingDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
				).FetchAll<BillingDetail_Record>(db)  ;  
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
				UpdateAllRecord<BillingDetail_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<BillingDetail_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<BillingDetail_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<BillingDetail_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<BillingDetail_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<BillingDetail_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		public List<Billing_Record> Link_Billing_By_BillingUuid()
		{
			try{
				List<Billing_Record> ret= new List<Billing_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Billing ___table = new Billing(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.BILLING_UUID,item.BILLING_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Billing_Record>)
						___table.Where(condition)
						.FetchAll<Billing_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<Billing_Record> Link_Billing_By_BillingUuid(OrderLimit limit)
		{
			try{
				List<Billing_Record> ret= new List<Billing_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Billing ___table = new Billing(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.BILLING_UUID,item.BILLING_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Billing_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<Billing_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public Billing LinkFill_Billing_By_BillingUuid()
		{
			try{
				var data = Link_Billing_By_BillingUuid();
				Billing ret=new Billing(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public Billing LinkFill_Billing_By_BillingUuid(OrderLimit limit)
		{
			try{
				var data = Link_Billing_By_BillingUuid(limit);
				Billing ret=new Billing(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
