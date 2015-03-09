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
		short? _CUST_ORDER_STATUS_ORD=null;
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

		[ColumnName("CUST_ORDER_STATUS_ORD",false,typeof(short?))]
		public short? CUST_ORDER_STATUS_ORD
		{
			set
			{
				_CUST_ORDER_STATUS_ORD=value;
			}
			get
			{
				return _CUST_ORDER_STATUS_ORD;
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
		public List<VCustOrder_Record> Link_VCustOrder_By_CustOrderStatusUuid()
		{
			try{
				List<VCustOrder_Record> ret= new List<VCustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VCustOrder ___table = new VCustOrder(dbc);
				ret=(List<VCustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORDER_STATUS_UUID,this.CUST_ORDER_STATUS_UUID))
					.FetchAll<VCustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<VCustOrder_Record> Link_VCustOrder_By_CustOrderStatusUuid(OrderLimit limit)
		{
			try{
				List<VCustOrder_Record> ret= new List<VCustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VCustOrder ___table = new VCustOrder(dbc);
				ret=(List<VCustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORDER_STATUS_UUID,this.CUST_ORDER_STATUS_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<VCustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public VCustOrder LinkFill_VCustOrder_By_CustOrderStatusUuid()
		{
			try{
				var data = Link_VCustOrder_By_CustOrderStatusUuid();
				VCustOrder ret=new VCustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public VCustOrder LinkFill_VCustOrder_By_CustOrderStatusUuid(OrderLimit limit)
		{
			try{
				var data = Link_VCustOrder_By_CustOrderStatusUuid(limit);
				VCustOrder ret=new VCustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
