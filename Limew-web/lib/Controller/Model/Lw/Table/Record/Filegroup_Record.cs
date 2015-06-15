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
	[TableView("FILEGROUP", true)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class Filegroup_Record : RecordBase{
		public Filegroup_Record(){}
		/*欄位資訊 Start*/
		string _FILEGROUP_UUID=null;
		string _FILEGROUP_DISPLAY_NAME=null;
		int? _FILE_COUNT=null;
		string _FILEGROUP_TAG=null;
		/*欄位資訊 End*/

		[ColumnName("FILEGROUP_UUID",true,typeof(string))]
		public string FILEGROUP_UUID
		{
			set
			{
				_FILEGROUP_UUID=value;
			}
			get
			{
				return _FILEGROUP_UUID;
			}
		}

		[ColumnName("FILEGROUP_DISPLAY_NAME",false,typeof(string))]
		public string FILEGROUP_DISPLAY_NAME
		{
			set
			{
				_FILEGROUP_DISPLAY_NAME=value;
			}
			get
			{
				return _FILEGROUP_DISPLAY_NAME;
			}
		}

		[ColumnName("FILE_COUNT",false,typeof(int?))]
		public int? FILE_COUNT
		{
			set
			{
				_FILE_COUNT=value;
			}
			get
			{
				return _FILE_COUNT;
			}
		}

		[ColumnName("FILEGROUP_TAG",false,typeof(string))]
		public string FILEGROUP_TAG
		{
			set
			{
				_FILEGROUP_TAG=value;
			}
			get
			{
				return _FILEGROUP_TAG;
			}
		}
		public Filegroup_Record Clone(){
			try{
				return this.Clone<Filegroup_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public Filegroup gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Filegroup ret = new Filegroup(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
