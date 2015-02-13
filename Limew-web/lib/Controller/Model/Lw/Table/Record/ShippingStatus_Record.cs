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
		/*201303180347*/
		public List<CustOrder_Record> Link_CustOrder_By_ShippingStatusUuid()
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				ret=(List<CustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.SHIPPING_STATUS_UUID,this.SHIPPING_STATUS_UUID))
					.FetchAll<CustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<CustOrder_Record> Link_CustOrder_By_ShippingStatusUuid(OrderLimit limit)
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				ret=(List<CustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.SHIPPING_STATUS_UUID,this.SHIPPING_STATUS_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<CustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public CustOrder LinkFill_CustOrder_By_ShippingStatusUuid()
		{
			try{
				var data = Link_CustOrder_By_ShippingStatusUuid();
				CustOrder ret=new CustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public CustOrder LinkFill_CustOrder_By_ShippingStatusUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrder_By_ShippingStatusUuid(limit);
				CustOrder ret=new CustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
