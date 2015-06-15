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
	[TableView("FILEGROUP", true)]
	public partial class Filegroup : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private Filegroup_Record _currentRecord = null;
	private IList<Filegroup_Record> _All_Record = new List<Filegroup_Record>();
		/*建構子*/
		public Filegroup(){}
		public Filegroup(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public Filegroup(IDataBaseConfigInfo dbc): base(dbc){}
		public Filegroup(IDataBaseConfigInfo dbc,Filegroup_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public Filegroup(IList<Filegroup_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string FILEGROUP_UUID {
			[ColumnName("FILEGROUP_UUID",true,typeof(string))]
			get{return "FILEGROUP_UUID" ; }}
		public string FILEGROUP_DISPLAY_NAME {
			[ColumnName("FILEGROUP_DISPLAY_NAME",false,typeof(string))]
			get{return "FILEGROUP_DISPLAY_NAME" ; }}
		public string FILE_COUNT {
			[ColumnName("FILE_COUNT",false,typeof(int?))]
			get{return "FILE_COUNT" ; }}
		public string FILEGROUP_TAG {
			[ColumnName("FILEGROUP_TAG",false,typeof(string))]
			get{return "FILEGROUP_TAG" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public Filegroup_Record CurrentRecord(){
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
		public Filegroup_Record CreateNew(){
			try{
				Filegroup_Record newData = new Filegroup_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<Filegroup_Record> AllRecord(){
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
				_All_Record = new List<Filegroup_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public Filegroup Fill_By_PK(string pfilegroup_uuid){
			try{
				IList<Filegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILEGROUP_UUID,pfilegroup_uuid)
				).FetchAll<Filegroup_Record>()  ;  
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
		public Filegroup Fill_By_PK(string pfilegroup_uuid,DB db){
			try{
				IList<Filegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILEGROUP_UUID,pfilegroup_uuid)
				).FetchAll<Filegroup_Record>(db)  ;  
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
		public Filegroup_Record Fetch_By_PK(string pfilegroup_uuid){
			try{
				IList<Filegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILEGROUP_UUID,pfilegroup_uuid)
				).FetchAll<Filegroup_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public Filegroup_Record Fetch_By_PK(string pfilegroup_uuid,DB db){
			try{
				IList<Filegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILEGROUP_UUID,pfilegroup_uuid)
				).FetchAll<Filegroup_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public Filegroup Fill_By_FilegroupUuid(string pfilegroup_uuid){
			try{
				IList<Filegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILEGROUP_UUID,pfilegroup_uuid)
				).FetchAll<Filegroup_Record>()  ;  
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
		public Filegroup Fill_By_FilegroupUuid(string pfilegroup_uuid,DB db){
			try{
				IList<Filegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILEGROUP_UUID,pfilegroup_uuid)
				).FetchAll<Filegroup_Record>(db)  ;  
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
		public Filegroup_Record Fetch_By_FilegroupUuid(string pfilegroup_uuid){
			try{
				IList<Filegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILEGROUP_UUID,pfilegroup_uuid)
				).FetchAll<Filegroup_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public Filegroup_Record Fetch_By_FilegroupUuid(string pfilegroup_uuid,DB db){
			try{
				IList<Filegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILEGROUP_UUID,pfilegroup_uuid)
				).FetchAll<Filegroup_Record>(db)  ;  
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
				UpdateAllRecord<Filegroup_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<Filegroup_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<Filegroup_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<Filegroup_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<Filegroup_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<Filegroup_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
	}
}
