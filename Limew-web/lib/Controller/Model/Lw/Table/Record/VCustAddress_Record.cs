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
	[TableView("V_CUST_ADDRESS", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class VCustAddress_Record : RecordBase{
		public VCustAddress_Record(){}
		/*欄位資訊 Start*/
		string _CUST_ADDRESS=null;
		string _CUST_ORG_ADDRESS=null;
		string _CUST_UUID=null;
		string _CUST_ORG_UUID=null;
		/*欄位資訊 End*/

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
		public VCustAddress_Record Clone(){
			try{
				return this.Clone<VCustAddress_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VCustAddress gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VCustAddress ret = new VCustAddress(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
