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
	[TableView("BILLING_DETAIL", true)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class BillingDetail_Record : RecordBase{
		public BillingDetail_Record(){}
		/*欄位資訊 Start*/
		string _BILLING_DETAIL_UUID=null;
		string _CUST_ORDER_UUID=null;
		DateTime? _BILLING_DETAIL_CR=null;
		string _BILLING_UUID=null;
		/*欄位資訊 End*/

		[ColumnName("BILLING_DETAIL_UUID",true,typeof(string))]
		public string BILLING_DETAIL_UUID
		{
			set
			{
				_BILLING_DETAIL_UUID=value;
			}
			get
			{
				return _BILLING_DETAIL_UUID;
			}
		}

		[ColumnName("CUST_ORDER_UUID",false,typeof(string))]
		public string CUST_ORDER_UUID
		{
			set
			{
				_CUST_ORDER_UUID=value;
			}
			get
			{
				return _CUST_ORDER_UUID;
			}
		}

		[ColumnName("BILLING_DETAIL_CR",false,typeof(DateTime?))]
		public DateTime? BILLING_DETAIL_CR
		{
			set
			{
				_BILLING_DETAIL_CR=value;
			}
			get
			{
				return _BILLING_DETAIL_CR;
			}
		}

		[ColumnName("BILLING_UUID",false,typeof(string))]
		public string BILLING_UUID
		{
			set
			{
				_BILLING_UUID=value;
			}
			get
			{
				return _BILLING_UUID;
			}
		}
		public BillingDetail_Record Clone(){
			try{
				return this.Clone<BillingDetail_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public BillingDetail gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				BillingDetail ret = new BillingDetail(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<Billing_Record> Link_Billing_By_BillingUuid()
		{
			try{
				List<Billing_Record> ret= new List<Billing_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Billing ___table = new Billing(dbc);
				ret=(List<Billing_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.BILLING_UUID,this.BILLING_UUID))
					.FetchAll<Billing_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<Billing_Record> Link_Billing_By_BillingUuid(OrderLimit limit)
		{
			try{
				List<Billing_Record> ret= new List<Billing_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Billing ___table = new Billing(dbc);
				ret=(List<Billing_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.BILLING_UUID,this.BILLING_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<Billing_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public Billing LinkFill_Billing_By_BillingUuid()
		{
			try{
				var data = Link_Billing_By_BillingUuid();
				Billing ret=new Billing(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public Billing LinkFill_Billing_By_BillingUuid(OrderLimit limit)
		{
			try{
				var data = Link_Billing_By_BillingUuid(limit);
				Billing ret=new Billing(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
