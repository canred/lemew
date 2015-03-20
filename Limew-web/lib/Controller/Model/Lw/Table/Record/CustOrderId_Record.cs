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
	[TableView("CUST_ORDER_ID", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class CustOrderId_Record : RecordBase{
		public CustOrderId_Record(){}
		/*欄位資訊 Start*/
		string _CUST_ORDER_ID_UUID=null;
		int? _MAX=null;
		/*欄位資訊 End*/

		[ColumnName("CUST_ORDER_ID_UUID",true,typeof(string))]
		public string CUST_ORDER_ID_UUID
		{
			set
			{
				_CUST_ORDER_ID_UUID=value;
			}
			get
			{
				return _CUST_ORDER_ID_UUID;
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
		public CustOrderId_Record Clone(){
			try{
				return this.Clone<CustOrderId_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public CustOrderId gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderId ret = new CustOrderId(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
