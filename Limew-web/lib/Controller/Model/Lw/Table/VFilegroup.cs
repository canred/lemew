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
	[TableView("V_FILEGROUP", false)]
	public partial class VFilegroup : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VFilegroup_Record _currentRecord = null;
	private IList<VFilegroup_Record> _All_Record = new List<VFilegroup_Record>();
		/*建構子*/
		public VFilegroup(){}
		public VFilegroup(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VFilegroup(IDataBaseConfigInfo dbc): base(dbc){}
		public VFilegroup(IDataBaseConfigInfo dbc,VFilegroup_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VFilegroup(IList<VFilegroup_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string FILE_UUID {
			[ColumnName("FILE_UUID",true,typeof(string))]
			get{return "FILE_UUID" ; }}
		public string FILE_NAME {
			[ColumnName("FILE_NAME",false,typeof(string))]
			get{return "FILE_NAME" ; }}
		public string FILE_URL {
			[ColumnName("FILE_URL",false,typeof(string))]
			get{return "FILE_URL" ; }}
		public string FILE_PS {
			[ColumnName("FILE_PS",false,typeof(string))]
			get{return "FILE_PS" ; }}
		public string FILE_PATH {
			[ColumnName("FILE_PATH",false,typeof(string))]
			get{return "FILE_PATH" ; }}
		public string FILEGROUP_UUID {
			[ColumnName("FILEGROUP_UUID",false,typeof(string))]
			get{return "FILEGROUP_UUID" ; }}
		public string FILE_CR {
			[ColumnName("FILE_CR",false,typeof(DateTime?))]
			get{return "FILE_CR" ; }}
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
		public VFilegroup_Record CurrentRecord(){
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
		public VFilegroup_Record CreateNew(){
			try{
				VFilegroup_Record newData = new VFilegroup_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VFilegroup_Record> AllRecord(){
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
				_All_Record = new List<VFilegroup_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public VFilegroup Fill_By_PK(string pfile_uuid){
			try{
				IList<VFilegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<VFilegroup_Record>()  ;  
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
		public VFilegroup Fill_By_PK(string pfile_uuid,DB db){
			try{
				IList<VFilegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<VFilegroup_Record>(db)  ;  
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
		public VFilegroup_Record Fetch_By_PK(string pfile_uuid){
			try{
				IList<VFilegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<VFilegroup_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public VFilegroup_Record Fetch_By_PK(string pfile_uuid,DB db){
			try{
				IList<VFilegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<VFilegroup_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public VFilegroup Fill_By_FileUuid(string pfile_uuid){
			try{
				IList<VFilegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<VFilegroup_Record>()  ;  
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
		public VFilegroup Fill_By_FileUuid(string pfile_uuid,DB db){
			try{
				IList<VFilegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<VFilegroup_Record>(db)  ;  
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
		public VFilegroup_Record Fetch_By_FileUuid(string pfile_uuid){
			try{
				IList<VFilegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<VFilegroup_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public VFilegroup_Record Fetch_By_FileUuid(string pfile_uuid,DB db){
			try{
				IList<VFilegroup_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<VFilegroup_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
	}
}
