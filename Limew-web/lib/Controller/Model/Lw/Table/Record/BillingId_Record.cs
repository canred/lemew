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
	[TableView("BILLING_ID", true)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class BillingId_Record : RecordBase{
		public BillingId_Record(){}
		/*欄位資訊 Start*/
		string _BILLING_ID_UUID=null;
		int? _MAX=null;
		string _BILLING_ID=null;
		/*欄位資訊 End*/

		[ColumnName("BILLING_ID_UUID",true,typeof(string))]
		public string BILLING_ID_UUID
		{
			set
			{
				_BILLING_ID_UUID=value;
			}
			get
			{
				return _BILLING_ID_UUID;
			}
		}

		[ColumnName("MAX",false,typeof(int?))]
		public int? MAX
		{
			set
			{
				_MAX=value;
			}
			get
			{
				return _MAX;
			}
		}

		[ColumnName("BILLING_ID",false,typeof(string))]
		public string BILLING_ID
		{
			set
			{
				_BILLING_ID=value;
			}
			get
			{
				return _BILLING_ID;
			}
		}
		public BillingId_Record Clone(){
			try{
				return this.Clone<BillingId_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public BillingId gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				BillingId ret = new BillingId(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
