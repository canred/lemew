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
	[TableView("PAY_METHOD", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class PayMethod_Record : RecordBase{
		public PayMethod_Record(){}
		/*欄位資訊 Start*/
		string _PAY_METHOD_UUID=null;
		string _PAY_METHOD_NAME=null;
		short? _PAY_METHOD_ORD=null;
		/*欄位資訊 End*/

		[ColumnName("PAY_METHOD_UUID",true,typeof(string))]
		public string PAY_METHOD_UUID
		{
			set
			{
				_PAY_METHOD_UUID=value;
			}
			get
			{
				return _PAY_METHOD_UUID;
			}
		}

		[ColumnName("PAY_METHOD_NAME",false,typeof(string))]
		public string PAY_METHOD_NAME
		{
			set
			{
				_PAY_METHOD_NAME=value;
			}
			get
			{
				return _PAY_METHOD_NAME;
			}
		}

		[ColumnName("PAY_METHOD_ORD",false,typeof(short?))]
		public short? PAY_METHOD_ORD
		{
			set
			{
				_PAY_METHOD_ORD=value;
			}
			get
			{
				return _PAY_METHOD_ORD;
			}
		}
		public PayMethod_Record Clone(){
			try{
				return this.Clone<PayMethod_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public PayMethod gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				PayMethod ret = new PayMethod(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<VCustOrder_Record> Link_VCustOrder_By_PayMethodUuid()
		{
			try{
				List<VCustOrder_Record> ret= new List<VCustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VCustOrder ___table = new VCustOrder(dbc);
				ret=(List<VCustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.PAY_METHOD_UUID,this.PAY_METHOD_UUID))
					.FetchAll<VCustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<VCustOrder_Record> Link_VCustOrder_By_PayMethodUuid(OrderLimit limit)
		{
			try{
				List<VCustOrder_Record> ret= new List<VCustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VCustOrder ___table = new VCustOrder(dbc);
				ret=(List<VCustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.PAY_METHOD_UUID,this.PAY_METHOD_UUID))
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
		public VCustOrder LinkFill_VCustOrder_By_PayMethodUuid()
		{
			try{
				var data = Link_VCustOrder_By_PayMethodUuid();
				VCustOrder ret=new VCustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public VCustOrder LinkFill_VCustOrder_By_PayMethodUuid(OrderLimit limit)
		{
			try{
				var data = Link_VCustOrder_By_PayMethodUuid(limit);
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
