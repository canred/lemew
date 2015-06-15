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
	[TableView("BILLING_ID", true)]
	public partial class BillingId : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private BillingId_Record _currentRecord = null;
	private IList<BillingId_Record> _All_Record = new List<BillingId_Record>();
		/*建構子*/
		public BillingId(){}
		public BillingId(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public BillingId(IDataBaseConfigInfo dbc): base(dbc){}
		public BillingId(IDataBaseConfigInfo dbc,BillingId_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public BillingId(IList<BillingId_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string BILLING_ID_UUID {
			[ColumnName("BILLING_ID_UUID",true,typeof(string))]
			get{return "BILLING_ID_UUID" ; }}
		public string MAX {
			[ColumnName("MAX",false,typeof(int?))]
			get{return "MAX" ; }}
		public string BILLING_ID {
			[ColumnName("BILLING_ID",false,typeof(string))]
			get{return "BILLING_ID" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public BillingId_Record CurrentRecord(){
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
		public BillingId_Record CreateNew(){
			try{
				BillingId_Record newData = new BillingId_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<BillingId_Record> AllRecord(){
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
				_All_Record = new List<BillingId_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public BillingId Fill_By_PK(string pbilling_id_uuid){
			try{
				IList<BillingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_ID_UUID,pbilling_id_uuid)
				).FetchAll<BillingId_Record>()  ;  
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
		public BillingId Fill_By_PK(string pbilling_id_uuid,DB db){
			try{
				IList<BillingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_ID_UUID,pbilling_id_uuid)
				).FetchAll<BillingId_Record>(db)  ;  
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
		public BillingId_Record Fetch_By_PK(string pbilling_id_uuid){
			try{
				IList<BillingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_ID_UUID,pbilling_id_uuid)
				).FetchAll<BillingId_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public BillingId_Record Fetch_By_PK(string pbilling_id_uuid,DB db){
			try{
				IList<BillingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_ID_UUID,pbilling_id_uuid)
				).FetchAll<BillingId_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public BillingId Fill_By_BillingIdUuid(string pbilling_id_uuid){
			try{
				IList<BillingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_ID_UUID,pbilling_id_uuid)
				).FetchAll<BillingId_Record>()  ;  
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
		public BillingId Fill_By_BillingIdUuid(string pbilling_id_uuid,DB db){
			try{
				IList<BillingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_ID_UUID,pbilling_id_uuid)
				).FetchAll<BillingId_Record>(db)  ;  
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
		public BillingId_Record Fetch_By_BillingIdUuid(string pbilling_id_uuid){
			try{
				IList<BillingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_ID_UUID,pbilling_id_uuid)
				).FetchAll<BillingId_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public BillingId_Record Fetch_By_BillingIdUuid(string pbilling_id_uuid,DB db){
			try{
				IList<BillingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_ID_UUID,pbilling_id_uuid)
				).FetchAll<BillingId_Record>(db)  ;  
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
				UpdateAllRecord<BillingId_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<BillingId_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<BillingId_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<BillingId_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<BillingId_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<BillingId_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
	}
}
