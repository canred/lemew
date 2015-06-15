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
	[TableView("MY_ORDER_ID", true)]
	public partial class MyOrderId : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private MyOrderId_Record _currentRecord = null;
	private IList<MyOrderId_Record> _All_Record = new List<MyOrderId_Record>();
		/*建構子*/
		public MyOrderId(){}
		public MyOrderId(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public MyOrderId(IDataBaseConfigInfo dbc): base(dbc){}
		public MyOrderId(IDataBaseConfigInfo dbc,MyOrderId_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public MyOrderId(IList<MyOrderId_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string MY_ORDER_ID_UUID {
			[ColumnName("MY_ORDER_ID_UUID",true,typeof(string))]
			get{return "MY_ORDER_ID_UUID" ; }}
		public string MAX {
			[ColumnName("MAX",false,typeof(int?))]
			get{return "MAX" ; }}
		public string MY_ORDER_ID {
			[ColumnName("MY_ORDER_ID",false,typeof(string))]
			get{return "MY_ORDER_ID" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public MyOrderId_Record CurrentRecord(){
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
		public MyOrderId_Record CreateNew(){
			try{
				MyOrderId_Record newData = new MyOrderId_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<MyOrderId_Record> AllRecord(){
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
				_All_Record = new List<MyOrderId_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public MyOrderId Fill_By_PK(string pmy_order_id_uuid){
			try{
				IList<MyOrderId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_ID_UUID,pmy_order_id_uuid)
				).FetchAll<MyOrderId_Record>()  ;  
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
		public MyOrderId Fill_By_PK(string pmy_order_id_uuid,DB db){
			try{
				IList<MyOrderId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_ID_UUID,pmy_order_id_uuid)
				).FetchAll<MyOrderId_Record>(db)  ;  
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
		public MyOrderId_Record Fetch_By_PK(string pmy_order_id_uuid){
			try{
				IList<MyOrderId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_ID_UUID,pmy_order_id_uuid)
				).FetchAll<MyOrderId_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public MyOrderId_Record Fetch_By_PK(string pmy_order_id_uuid,DB db){
			try{
				IList<MyOrderId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_ID_UUID,pmy_order_id_uuid)
				).FetchAll<MyOrderId_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public MyOrderId Fill_By_MyOrderIdUuid(string pmy_order_id_uuid){
			try{
				IList<MyOrderId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_ID_UUID,pmy_order_id_uuid)
				).FetchAll<MyOrderId_Record>()  ;  
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
		public MyOrderId Fill_By_MyOrderIdUuid(string pmy_order_id_uuid,DB db){
			try{
				IList<MyOrderId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_ID_UUID,pmy_order_id_uuid)
				).FetchAll<MyOrderId_Record>(db)  ;  
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
		public MyOrderId_Record Fetch_By_MyOrderIdUuid(string pmy_order_id_uuid){
			try{
				IList<MyOrderId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_ID_UUID,pmy_order_id_uuid)
				).FetchAll<MyOrderId_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public MyOrderId_Record Fetch_By_MyOrderIdUuid(string pmy_order_id_uuid,DB db){
			try{
				IList<MyOrderId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_ID_UUID,pmy_order_id_uuid)
				).FetchAll<MyOrderId_Record>(db)  ;  
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
				UpdateAllRecord<MyOrderId_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<MyOrderId_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<MyOrderId_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<MyOrderId_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<MyOrderId_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<MyOrderId_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
	}
}
