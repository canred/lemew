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
	[TableView("PAY_METHOD", true)]
	public partial class PayMethod : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private PayMethod_Record _currentRecord = null;
	private IList<PayMethod_Record> _All_Record = new List<PayMethod_Record>();
		/*建構子*/
		public PayMethod(){}
		public PayMethod(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public PayMethod(IDataBaseConfigInfo dbc): base(dbc){}
		public PayMethod(IDataBaseConfigInfo dbc,PayMethod_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public PayMethod(IList<PayMethod_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string PAY_METHOD_UUID {
			[ColumnName("PAY_METHOD_UUID",true,typeof(string))]
			get{return "PAY_METHOD_UUID" ; }}
		public string PAY_METHOD_NAME {
			[ColumnName("PAY_METHOD_NAME",false,typeof(string))]
			get{return "PAY_METHOD_NAME" ; }}
		public string PAY_METHOD_ORD {
			[ColumnName("PAY_METHOD_ORD",false,typeof(int?))]
			get{return "PAY_METHOD_ORD" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public PayMethod_Record CurrentRecord(){
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
		public PayMethod_Record CreateNew(){
			try{
				PayMethod_Record newData = new PayMethod_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<PayMethod_Record> AllRecord(){
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
				_All_Record = new List<PayMethod_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public PayMethod Fill_By_PK(string ppay_method_uuid){
			try{
				IList<PayMethod_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_METHOD_UUID,ppay_method_uuid)
				).FetchAll<PayMethod_Record>()  ;  
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
		public PayMethod Fill_By_PK(string ppay_method_uuid,DB db){
			try{
				IList<PayMethod_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_METHOD_UUID,ppay_method_uuid)
				).FetchAll<PayMethod_Record>(db)  ;  
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
		public PayMethod_Record Fetch_By_PK(string ppay_method_uuid){
			try{
				IList<PayMethod_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_METHOD_UUID,ppay_method_uuid)
				).FetchAll<PayMethod_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public PayMethod_Record Fetch_By_PK(string ppay_method_uuid,DB db){
			try{
				IList<PayMethod_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_METHOD_UUID,ppay_method_uuid)
				).FetchAll<PayMethod_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public PayMethod Fill_By_PayMethodUuid(string ppay_method_uuid){
			try{
				IList<PayMethod_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_METHOD_UUID,ppay_method_uuid)
				).FetchAll<PayMethod_Record>()  ;  
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
		public PayMethod Fill_By_PayMethodUuid(string ppay_method_uuid,DB db){
			try{
				IList<PayMethod_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_METHOD_UUID,ppay_method_uuid)
				).FetchAll<PayMethod_Record>(db)  ;  
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
		public PayMethod_Record Fetch_By_PayMethodUuid(string ppay_method_uuid){
			try{
				IList<PayMethod_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_METHOD_UUID,ppay_method_uuid)
				).FetchAll<PayMethod_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public PayMethod_Record Fetch_By_PayMethodUuid(string ppay_method_uuid,DB db){
			try{
				IList<PayMethod_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_METHOD_UUID,ppay_method_uuid)
				).FetchAll<PayMethod_Record>(db)  ;  
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
				UpdateAllRecord<PayMethod_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<PayMethod_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<PayMethod_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<PayMethod_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<PayMethod_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<PayMethod_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<CustOrder_Record> Link_CustOrder_By_PayMethodUuid()
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.PAY_METHOD_UUID,item.PAY_METHOD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrder_Record>)
						___table.Where(condition)
						.FetchAll<CustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<CustOrder_Record> Link_CustOrder_By_PayMethodUuid(OrderLimit limit)
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.PAY_METHOD_UUID,item.PAY_METHOD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrder_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<CustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public CustOrder LinkFill_CustOrder_By_PayMethodUuid()
		{
			try{
				var data = Link_CustOrder_By_PayMethodUuid();
				CustOrder ret=new CustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public CustOrder LinkFill_CustOrder_By_PayMethodUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrder_By_PayMethodUuid(limit);
				CustOrder ret=new CustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
