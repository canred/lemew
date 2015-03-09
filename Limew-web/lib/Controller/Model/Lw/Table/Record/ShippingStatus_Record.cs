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
	[TableView("SHIPPING_STATUS", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class ShippingStatus_Record : RecordBase{
		public ShippingStatus_Record(){}
		/*欄位資訊 Start*/
		string _SHIPPING_STATUS_UUID=null;
		string _SHIPPING_STATUS_NAME=null;
		short? _SHIPPING_STATUS_ORD=null;
		/*欄位資訊 End*/

		[ColumnName("SHIPPING_STATUS_UUID",true,typeof(string))]
		public string SHIPPING_STATUS_UUID
		{
			set
			{
				_SHIPPING_STATUS_UUID=value;
			}
			get
			{
				return _SHIPPING_STATUS_UUID;
			}
		}

		[ColumnName("SHIPPING_STATUS_NAME",false,typeof(string))]
		public string SHIPPING_STATUS_NAME
		{
			set
			{
				_SHIPPING_STATUS_NAME=value;
			}
			get
			{
				return _SHIPPING_STATUS_NAME;
			}
		}

		[ColumnName("SHIPPING_STATUS_ORD",false,typeof(short?))]
		public short? SHIPPING_STATUS_ORD
		{
			set
			{
				_SHIPPING_STATUS_ORD=value;
			}
			get
			{
				return _SHIPPING_STATUS_ORD;
			}
		}
		public ShippingStatus_Record Clone(){
			try{
				return this.Clone<ShippingStatus_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public ShippingStatus gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				ShippingStatus ret = new ShippingStatus(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
