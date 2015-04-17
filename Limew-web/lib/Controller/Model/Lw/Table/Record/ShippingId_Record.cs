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
	[TableView("SHIPPING_ID", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class ShippingId_Record : RecordBase{
		public ShippingId_Record(){}
		/*欄位資訊 Start*/
		string _SHIPPING_ID_UUID=null;
		int? _MAX=null;
		/*欄位資訊 End*/

		[ColumnName("SHIPPING_ID_UUID",true,typeof(string))]
		public string SHIPPING_ID_UUID
		{
			set
			{
				_SHIPPING_ID_UUID=value;
			}
			get
			{
				return _SHIPPING_ID_UUID;
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
		public ShippingId_Record Clone(){
			try{
				return this.Clone<ShippingId_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public ShippingId gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				ShippingId ret = new ShippingId(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
