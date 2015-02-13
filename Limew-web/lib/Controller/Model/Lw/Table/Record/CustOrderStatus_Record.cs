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
	[TableView("CUST_ORDER_STATUS", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class CustOrderStatus_Record : RecordBase{
		public CustOrderStatus_Record(){}
		/*欄位資訊 Start*/
		string _CUST_ORDER_STATUS_UUID=null;
		string _CUST_ORDER_STATUS_NAME=null;
		int? _CUST_ORDER_STATUS_IS_ACTIVE=null;
		/*欄位資訊 End*/

		[ColumnName("CUST_ORDER_STATUS_UUID",true,typeof(string))]
		public string CUST_ORDER_STATUS_UUID
		{
			set
			{
				_CUST_ORDER_STATUS_UUID=value;
			}
			get
			{
				return _CUST_ORDER_STATUS_UUID;
			}
		}

		[ColumnName("CUST_ORDER_STATUS_NAME",false,typeof(string))]
		public string CUST_ORDER_STATUS_NAME
		{
			set
			{
				_CUST_ORDER_STATUS_NAME=value;
			}
			get
			{
				return _CUST_ORDER_STATUS_NAME;
			}
		}

		[ColumnName("CUST_ORDER_STATUS_IS_ACTIVE",false,typeof(int?))]
		public int? CUST_ORDER_STATUS_IS_ACTIVE
		{
			set
			{
				_CUST_ORDER_STATUS_IS_ACTIVE=value;
			}
			get
			{
				return _CUST_ORDER_STATUS_IS_ACTIVE;
			}
		}
		public CustOrderStatus_Record Clone(){
			try{
				return this.Clone<CustOrderStatus_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public CustOrderStatus gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderStatus ret = new CustOrderStatus(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<CustOrder_Record> Link_CustOrder_By_CustOrderStatusUuid()
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				ret=(List<CustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORDER_STATUS_UUID,this.CUST_ORDER_STATUS_UUID))
					.FetchAll<CustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<CustOrder_Record> Link_CustOrder_By_CustOrderStatusUuid(OrderLimit limit)
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				ret=(List<CustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORDER_STATUS_UUID,this.CUST_ORDER_STATUS_UUID))
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
		public CustOrder LinkFill_CustOrder_By_CustOrderStatusUuid()
		{
			try{
				var data = Link_CustOrder_By_CustOrderStatusUuid();
				CustOrder ret=new CustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public CustOrder LinkFill_CustOrder_By_CustOrderStatusUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrder_By_CustOrderStatusUuid(limit);
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
