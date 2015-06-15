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
	[TableView("PAY_STATUS", true)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class PayStatus_Record : RecordBase{
		public PayStatus_Record(){}
		/*欄位資訊 Start*/
		string _PAY_STATUS_UUID=null;
		string _PAY_STATUS_NAME=null;
		int? _PAY_STATUS_ORD=null;
		/*欄位資訊 End*/

		[ColumnName("PAY_STATUS_UUID",true,typeof(string))]
		public string PAY_STATUS_UUID
		{
			set
			{
				_PAY_STATUS_UUID=value;
			}
			get
			{
				return _PAY_STATUS_UUID;
			}
		}

		[ColumnName("PAY_STATUS_NAME",false,typeof(string))]
		public string PAY_STATUS_NAME
		{
			set
			{
				_PAY_STATUS_NAME=value;
			}
			get
			{
				return _PAY_STATUS_NAME;
			}
		}

		[ColumnName("PAY_STATUS_ORD",false,typeof(int?))]
		public int? PAY_STATUS_ORD
		{
			set
			{
				_PAY_STATUS_ORD=value;
			}
			get
			{
				return _PAY_STATUS_ORD;
			}
		}
		public PayStatus_Record Clone(){
			try{
				return this.Clone<PayStatus_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public PayStatus gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				PayStatus ret = new PayStatus(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<CustOrder_Record> Link_CustOrder_By_PayStatusUuid()
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				ret=(List<CustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.PAY_STATUS_UUID,this.PAY_STATUS_UUID))
					.FetchAll<CustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<CustOrder_Record> Link_CustOrder_By_PayStatusUuid(OrderLimit limit)
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				ret=(List<CustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.PAY_STATUS_UUID,this.PAY_STATUS_UUID))
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
		public CustOrder LinkFill_CustOrder_By_PayStatusUuid()
		{
			try{
				var data = Link_CustOrder_By_PayStatusUuid();
				CustOrder ret=new CustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public CustOrder LinkFill_CustOrder_By_PayStatusUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrder_By_PayStatusUuid(limit);
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
