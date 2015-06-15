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
	[TableView("CUST_ORG_V", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class CustOrgV_Record : RecordBase{
		public CustOrgV_Record(){}
		/*欄位資訊 Start*/
		string _CUST_UUID=null;
		string _CUST_NAME=null;
		string _CUST_TEL=null;
		string _CUST_FAX=null;
		string _CUST_ADDRESS=null;
		string _CUST_SALES_NAME=null;
		string _CUST_SALES_PHONE=null;
		string _CUST_SALES_EMAIL=null;
		string _CUST_PS=null;
		int? _CUST_LEVEL=null;
		int? _CUST_IS_ACTIVE=null;
		DateTime? _CUST_LAST_BUY=null;
		string _CUST_UNIFORM_NUM=null;
		string _CUST_ORG_ADDRESS=null;
		int? _CUST_ORG_IS_ACTIVE=null;
		int? _CUST_ORG_IS_DEFAULT=null;
		string _CUST_ORG_NAME=null;
		string _CUST_ORG_PS=null;
		string _CUST_ORG_SALES_EMAIL=null;
		string _CUST_ORG_SALES_NAME=null;
		string _CUST_ORG_SALES_PHONE=null;
		string _CUST_ORG_UUID=null;
		/*欄位資訊 End*/

		[ColumnName("CUST_UUID",true,typeof(string))]
		public string CUST_UUID
		{
			set
			{
				_CUST_UUID=value;
			}
			get
			{
				return _CUST_UUID;
			}
		}

		[ColumnName("CUST_NAME",false,typeof(string))]
		public string CUST_NAME
		{
			set
			{
				_CUST_NAME=value;
			}
			get
			{
				return _CUST_NAME;
			}
		}

		[ColumnName("CUST_TEL",false,typeof(string))]
		public string CUST_TEL
		{
			set
			{
				_CUST_TEL=value;
			}
			get
			{
				return _CUST_TEL;
			}
		}

		[ColumnName("CUST_FAX",false,typeof(string))]
		public string CUST_FAX
		{
			set
			{
				_CUST_FAX=value;
			}
			get
			{
				return _CUST_FAX;
			}
		}

		[ColumnName("CUST_ADDRESS",false,typeof(string))]
		public string CUST_ADDRESS
		{
			set
			{
				_CUST_ADDRESS=value;
			}
			get
			{
				return _CUST_ADDRESS;
			}
		}

		[ColumnName("CUST_SALES_NAME",false,typeof(string))]
		public string CUST_SALES_NAME
		{
			set
			{
				_CUST_SALES_NAME=value;
			}
			get
			{
				return _CUST_SALES_NAME;
			}
		}

		[ColumnName("CUST_SALES_PHONE",false,typeof(string))]
		public string CUST_SALES_PHONE
		{
			set
			{
				_CUST_SALES_PHONE=value;
			}
			get
			{
				return _CUST_SALES_PHONE;
			}
		}

		[ColumnName("CUST_SALES_EMAIL",false,typeof(string))]
		public string CUST_SALES_EMAIL
		{
			set
			{
				_CUST_SALES_EMAIL=value;
			}
			get
			{
				return _CUST_SALES_EMAIL;
			}
		}

		[ColumnName("CUST_PS",false,typeof(string))]
		public string CUST_PS
		{
			set
			{
				_CUST_PS=value;
			}
			get
			{
				return _CUST_PS;
			}
		}

		[ColumnName("CUST_LEVEL",false,typeof(int?))]
		public int? CUST_LEVEL
		{
			set
			{
				_CUST_LEVEL=value;
			}
			get
			{
				return _CUST_LEVEL;
			}
		}

		[ColumnName("CUST_IS_ACTIVE",false,typeof(int?))]
		public int? CUST_IS_ACTIVE
		{
			set
			{
				_CUST_IS_ACTIVE=value;
			}
			get
			{
				return _CUST_IS_ACTIVE;
			}
		}

		[ColumnName("CUST_LAST_BUY",false,typeof(DateTime?))]
		public DateTime? CUST_LAST_BUY
		{
			set
			{
				_CUST_LAST_BUY=value;
			}
			get
			{
				return _CUST_LAST_BUY;
			}
		}

		[ColumnName("CUST_UNIFORM_NUM",false,typeof(string))]
		public string CUST_UNIFORM_NUM
		{
			set
			{
				_CUST_UNIFORM_NUM=value;
			}
			get
			{
				return _CUST_UNIFORM_NUM;
			}
		}

		[ColumnName("CUST_ORG_ADDRESS",false,typeof(string))]
		public string CUST_ORG_ADDRESS
		{
			set
			{
				_CUST_ORG_ADDRESS=value;
			}
			get
			{
				return _CUST_ORG_ADDRESS;
			}
		}

		[ColumnName("CUST_ORG_IS_ACTIVE",false,typeof(int?))]
		public int? CUST_ORG_IS_ACTIVE
		{
			set
			{
				_CUST_ORG_IS_ACTIVE=value;
			}
			get
			{
				return _CUST_ORG_IS_ACTIVE;
			}
		}

		[ColumnName("CUST_ORG_IS_DEFAULT",false,typeof(int?))]
		public int? CUST_ORG_IS_DEFAULT
		{
			set
			{
				_CUST_ORG_IS_DEFAULT=value;
			}
			get
			{
				return _CUST_ORG_IS_DEFAULT;
			}
		}

		[ColumnName("CUST_ORG_NAME",false,typeof(string))]
		public string CUST_ORG_NAME
		{
			set
			{
				_CUST_ORG_NAME=value;
			}
			get
			{
				return _CUST_ORG_NAME;
			}
		}

		[ColumnName("CUST_ORG_PS",false,typeof(string))]
		public string CUST_ORG_PS
		{
			set
			{
				_CUST_ORG_PS=value;
			}
			get
			{
				return _CUST_ORG_PS;
			}
		}

		[ColumnName("CUST_ORG_SALES_EMAIL",false,typeof(string))]
		public string CUST_ORG_SALES_EMAIL
		{
			set
			{
				_CUST_ORG_SALES_EMAIL=value;
			}
			get
			{
				return _CUST_ORG_SALES_EMAIL;
			}
		}

		[ColumnName("CUST_ORG_SALES_NAME",false,typeof(string))]
		public string CUST_ORG_SALES_NAME
		{
			set
			{
				_CUST_ORG_SALES_NAME=value;
			}
			get
			{
				return _CUST_ORG_SALES_NAME;
			}
		}

		[ColumnName("CUST_ORG_SALES_PHONE",false,typeof(string))]
		public string CUST_ORG_SALES_PHONE
		{
			set
			{
				_CUST_ORG_SALES_PHONE=value;
			}
			get
			{
				return _CUST_ORG_SALES_PHONE;
			}
		}

		[ColumnName("CUST_ORG_UUID",true,typeof(string))]
		public string CUST_ORG_UUID
		{
			set
			{
				_CUST_ORG_UUID=value;
			}
			get
			{
				return _CUST_ORG_UUID;
			}
		}
		public CustOrgV_Record Clone(){
			try{
				return this.Clone<CustOrgV_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public CustOrgV gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrgV ret = new CustOrgV(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
