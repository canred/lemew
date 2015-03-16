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
	[TableView("V_FILEGROUP", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class VFilegroup_Record : RecordBase{
		public VFilegroup_Record(){}
		/*欄位資訊 Start*/
		string _FILE_UUID=null;
		string _FILE_NAME=null;
		string _FILE_URL=null;
		string _FILE_PS=null;
		string _FILE_PATH=null;
		string _FILEGROUP_UUID=null;
		DateTime? _FILE_CR=null;
		string _FILEGROUP_DISPLAY_NAME=null;
		int? _FILE_COUNT=null;
		string _FILEGROUP_TAG=null;
		/*欄位資訊 End*/

		[ColumnName("FILE_UUID",true,typeof(string))]
		public string FILE_UUID
		{
			set
			{
				_FILE_UUID=value;
			}
			get
			{
				return _FILE_UUID;
			}
		}

		[ColumnName("FILE_NAME",false,typeof(string))]
		public string FILE_NAME
		{
			set
			{
				_FILE_NAME=value;
			}
			get
			{
				return _FILE_NAME;
			}
		}

		[ColumnName("FILE_URL",false,typeof(string))]
		public string FILE_URL
		{
			set
			{
				_FILE_URL=value;
			}
			get
			{
				return _FILE_URL;
			}
		}

		[ColumnName("FILE_PS",false,typeof(string))]
		public string FILE_PS
		{
			set
			{
				_FILE_PS=value;
			}
			get
			{
				return _FILE_PS;
			}
		}

		[ColumnName("FILE_PATH",false,typeof(string))]
		public string FILE_PATH
		{
			set
			{
				_FILE_PATH=value;
			}
			get
			{
				return _FILE_PATH;
			}
		}

		[ColumnName("FILEGROUP_UUID",false,typeof(string))]
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

		[ColumnName("FILE_CR",false,typeof(DateTime?))]
		public DateTime? FILE_CR
		{
			set
			{
				_FILE_CR=value;
			}
			get
			{
				return _FILE_CR;
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
		public VFilegroup_Record Clone(){
			try{
				return this.Clone<VFilegroup_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VFilegroup gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VFilegroup ret = new VFilegroup(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
