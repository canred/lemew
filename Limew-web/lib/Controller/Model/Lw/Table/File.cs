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
	[TableView("FILE", false)]
	public partial class File : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private File_Record _currentRecord = null;
	private IList<File_Record> _All_Record = new List<File_Record>();
		/*建構子*/
		public File(){}
		public File(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public File(IDataBaseConfigInfo dbc): base(dbc){}
		public File(IDataBaseConfigInfo dbc,File_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public File(IList<File_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string FILE_UUID {get{return "FILE_UUID" ; }}
		public string FILE_NAME {get{return "FILE_NAME" ; }}
		public string FILE_URL {get{return "FILE_URL" ; }}
		public string FILE_PS {get{return "FILE_PS" ; }}
		public string FILE_PATH {get{return "FILE_PATH" ; }}
		public string FILEGROUP_UUID {get{return "FILEGROUP_UUID" ; }}
		public string FILE_CR {get{return "FILE_CR" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public File_Record CurrentRecord(){
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
		public File_Record CreateNew(){
			try{
				File_Record newData = new File_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<File_Record> AllRecord(){
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
				_All_Record = new List<File_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public File Fill_By_PK(string pfile_uuid){
			try{
				IList<File_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<File_Record>()  ;  
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
		public File Fill_By_PK(string pfile_uuid,DB db){
			try{
				IList<File_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<File_Record>(db)  ;  
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
		public File_Record Fetch_By_PK(string pfile_uuid){
			try{
				IList<File_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<File_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public File_Record Fetch_By_PK(string pfile_uuid,DB db){
			try{
				IList<File_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<File_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public File Fill_By_FileUuid(string pfile_uuid){
			try{
				IList<File_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<File_Record>()  ;  
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
		public File Fill_By_FileUuid(string pfile_uuid,DB db){
			try{
				IList<File_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<File_Record>(db)  ;  
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
		public File_Record Fetch_By_FileUuid(string pfile_uuid){
			try{
				IList<File_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<File_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public File_Record Fetch_By_FileUuid(string pfile_uuid,DB db){
			try{
				IList<File_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.FILE_UUID,pfile_uuid)
				).FetchAll<File_Record>(db)  ;  
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
