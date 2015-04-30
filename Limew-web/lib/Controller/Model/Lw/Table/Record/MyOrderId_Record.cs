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
	[TableView("MY_ORDER_ID", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class MyOrderId_Record : RecordBase{
		public MyOrderId_Record(){}
		/*欄位資訊 Start*/
		string _MY_ORDER_ID=null;
		string _MY_ORDER_ID_UUID=null;
		int? _MAX=null;
		/*欄位資訊 End*/

		[ColumnName("MY_ORDER_ID",false,typeof(string))]
		public string MY_ORDER_ID
		{
			set
			{
				_MY_ORDER_ID=value;
			}
			get
			{
				return _MY_ORDER_ID;
			}
		}

		[ColumnName("MY_ORDER_ID_UUID",true,typeof(string))]
		public string MY_ORDER_ID_UUID
		{
			set
			{
				_MY_ORDER_ID_UUID=value;
			}
			get
			{
				return _MY_ORDER_ID_UUID;
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
		public MyOrderId_Record Clone(){
			try{
				return this.Clone<MyOrderId_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public MyOrderId gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				MyOrderId ret = new MyOrderId(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
