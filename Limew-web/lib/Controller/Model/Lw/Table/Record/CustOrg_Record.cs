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
	[TableView("CUST_ORG", true)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class CustOrg_Record : RecordBase{
		public CustOrg_Record(){}
		/*欄位資訊 Start*/
		string _CUST_ORG_UUID=null;
		string _CUST_UUID=null;
		string _CUST_ORG_SALES_NAME=null;
		string _CUST_ORG_SALES_PHONE=null;
		string _CUST_ORG_SALES_EMAIL=null;
		string _CUST_ORG_PS=null;
		string _CUST_ORG_NAME=null;
		int? _CUST_ORG_IS_ACTIVE=null;
		string _CUST_ORG_ADDRESS=null;
		int? _CUST_ORG_IS_DEFAULT=null;
		/*欄位資訊 End*/

		[ColumnName("CUST_ORG_UUID",true,typeof(string))]
		public string CUST_ORG_UUID
		{
			set
			{
				_CUST_ORG_UUID=value;
			}
			get
			{
				return _CUST_ORG_UUID;
			}
		}

		[ColumnName("CUST_UUID",false,typeof(string))]
		public string CUST_UUID
		{
			set
			{
				_CUST_UUID=value;
			}
			get
			{
				return _CUST_UUID;
			}
		}

		[ColumnName("CUST_ORG_SALES_NAME",false,typeof(string))]
		public string CUST_ORG_SALES_NAME
		{
			set
			{
				_CUST_ORG_SALES_NAME=value;
			}
			get
			{
				return _CUST_ORG_SALES_NAME;
			}
		}

		[ColumnName("CUST_ORG_SALES_PHONE",false,typeof(string))]
		public string CUST_ORG_SALES_PHONE
		{
			set
			{
				_CUST_ORG_SALES_PHONE=value;
			}
			get
			{
				return _CUST_ORG_SALES_PHONE;
			}
		}

		[ColumnName("CUST_ORG_SALES_EMAIL",false,typeof(string))]
		public string CUST_ORG_SALES_EMAIL
		{
			set
			{
				_CUST_ORG_SALES_EMAIL=value;
			}
			get
			{
				return _CUST_ORG_SALES_EMAIL;
			}
		}

		[ColumnName("CUST_ORG_PS",false,typeof(string))]
		public string CUST_ORG_PS
		{
			set
			{
				_CUST_ORG_PS=value;
			}
			get
			{
				return _CUST_ORG_PS;
			}
		}

		[ColumnName("CUST_ORG_NAME",false,typeof(string))]
		public string CUST_ORG_NAME
		{
			set
			{
				_CUST_ORG_NAME=value;
			}
			get
			{
				return _CUST_ORG_NAME;
			}
		}

		[ColumnName("CUST_ORG_IS_ACTIVE",false,typeof(int?))]
		public int? CUST_ORG_IS_ACTIVE
		{
			set
			{
				_CUST_ORG_IS_ACTIVE=value;
			}
			get
			{
				return _CUST_ORG_IS_ACTIVE;
			}
		}

		[ColumnName("CUST_ORG_ADDRESS",false,typeof(string))]
		public string CUST_ORG_ADDRESS
		{
			set
			{
				_CUST_ORG_ADDRESS=value;
			}
			get
			{
				return _CUST_ORG_ADDRESS;
			}
		}

		[ColumnName("CUST_ORG_IS_DEFAULT",false,typeof(int?))]
		public int? CUST_ORG_IS_DEFAULT
		{
			set
			{
				_CUST_ORG_IS_DEFAULT=value;
			}
			get
			{
				return _CUST_ORG_IS_DEFAULT;
			}
		}
		public CustOrg_Record Clone(){
			try{
				return this.Clone<CustOrg_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public CustOrg gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrg ret = new CustOrg(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<CustOrder_Record> Link_CustOrder_By_CustOrgUuid()
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				ret=(List<CustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORG_UUID,this.CUST_ORG_UUID))
					.FetchAll<CustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<CustOrder_Record> Link_CustOrder_By_CustOrgUuid(OrderLimit limit)
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				ret=(List<CustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORG_UUID,this.CUST_ORG_UUID))
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
		public List<Cust_Record> Link_Cust_By_CustUuid()
		{
			try{
				List<Cust_Record> ret= new List<Cust_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Cust ___table = new Cust(dbc);
				ret=(List<Cust_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_UUID,this.CUST_UUID))
					.FetchAll<Cust_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<Cust_Record> Link_Cust_By_CustUuid(OrderLimit limit)
		{
			try{
				List<Cust_Record> ret= new List<Cust_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Cust ___table = new Cust(dbc);
				ret=(List<Cust_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_UUID,this.CUST_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<Cust_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public CustOrder LinkFill_CustOrder_By_CustOrgUuid()
		{
			try{
				var data = Link_CustOrder_By_CustOrgUuid();
				CustOrder ret=new CustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public CustOrder LinkFill_CustOrder_By_CustOrgUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrder_By_CustOrgUuid(limit);
				CustOrder ret=new CustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public Cust LinkFill_Cust_By_CustUuid()
		{
			try{
				var data = Link_Cust_By_CustUuid();
				Cust ret=new Cust(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public Cust LinkFill_Cust_By_CustUuid(OrderLimit limit)
		{
			try{
				var data = Link_Cust_By_CustUuid(limit);
				Cust ret=new Cust(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
