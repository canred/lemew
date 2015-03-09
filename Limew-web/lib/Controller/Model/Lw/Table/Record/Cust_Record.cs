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
	[TableView("CUST", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class Cust_Record : RecordBase{
		public Cust_Record(){}
		/*欄位資訊 Start*/
		string _CUST_UUID=null;
		string _CUST_NAME=null;
		string _CUST_TEL=null;
		string _CUST_FAX=null;
		string _CUST_ADDRESS=null;
		string _CUST_SALES_NAME=null;
		string _CUST_SALES_PHONE=null;
		string _CUST_SALES_EMAIL=null;
		string _CUST_PS=null;
		int? _CUST_LEVEL=null;
		int? _CUST_IS_ACTIVE=null;
		DateTime? _CUST_LAST_BUY=null;
		/*欄位資訊 End*/

		[ColumnName("CUST_UUID",true,typeof(string))]
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

		[ColumnName("CUST_NAME",false,typeof(string))]
		public string CUST_NAME
		{
			set
			{
				_CUST_NAME=value;
			}
			get
			{
				return _CUST_NAME;
			}
		}

		[ColumnName("CUST_TEL",false,typeof(string))]
		public string CUST_TEL
		{
			set
			{
				_CUST_TEL=value;
			}
			get
			{
				return _CUST_TEL;
			}
		}

		[ColumnName("CUST_FAX",false,typeof(string))]
		public string CUST_FAX
		{
			set
			{
				_CUST_FAX=value;
			}
			get
			{
				return _CUST_FAX;
			}
		}

		[ColumnName("CUST_ADDRESS",false,typeof(string))]
		public string CUST_ADDRESS
		{
			set
			{
				_CUST_ADDRESS=value;
			}
			get
			{
				return _CUST_ADDRESS;
			}
		}

		[ColumnName("CUST_SALES_NAME",false,typeof(string))]
		public string CUST_SALES_NAME
		{
			set
			{
				_CUST_SALES_NAME=value;
			}
			get
			{
				return _CUST_SALES_NAME;
			}
		}

		[ColumnName("CUST_SALES_PHONE",false,typeof(string))]
		public string CUST_SALES_PHONE
		{
			set
			{
				_CUST_SALES_PHONE=value;
			}
			get
			{
				return _CUST_SALES_PHONE;
			}
		}

		[ColumnName("CUST_SALES_EMAIL",false,typeof(string))]
		public string CUST_SALES_EMAIL
		{
			set
			{
				_CUST_SALES_EMAIL=value;
			}
			get
			{
				return _CUST_SALES_EMAIL;
			}
		}

		[ColumnName("CUST_PS",false,typeof(string))]
		public string CUST_PS
		{
			set
			{
				_CUST_PS=value;
			}
			get
			{
				return _CUST_PS;
			}
		}

		[ColumnName("CUST_LEVEL",false,typeof(int?))]
		public int? CUST_LEVEL
		{
			set
			{
				_CUST_LEVEL=value;
			}
			get
			{
				return _CUST_LEVEL;
			}
		}

		[ColumnName("CUST_IS_ACTIVE",false,typeof(int?))]
		public int? CUST_IS_ACTIVE
		{
			set
			{
				_CUST_IS_ACTIVE=value;
			}
			get
			{
				return _CUST_IS_ACTIVE;
			}
		}

		[ColumnName("CUST_LAST_BUY",false,typeof(DateTime?))]
		public DateTime? CUST_LAST_BUY
		{
			set
			{
				_CUST_LAST_BUY=value;
			}
			get
			{
				return _CUST_LAST_BUY;
			}
		}
		public Cust_Record Clone(){
			try{
				return this.Clone<Cust_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public Cust gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Cust ret = new Cust(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<CustOrg_Record> Link_CustOrg_By_CustUuid()
		{
			try{
				List<CustOrg_Record> ret= new List<CustOrg_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrg ___table = new CustOrg(dbc);
				ret=(List<CustOrg_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_UUID,this.CUST_UUID))
					.FetchAll<CustOrg_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<VCustOrder_Record> Link_VCustOrder_By_CustUuid()
		{
			try{
				List<VCustOrder_Record> ret= new List<VCustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VCustOrder ___table = new VCustOrder(dbc);
				ret=(List<VCustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_UUID,this.CUST_UUID))
					.FetchAll<VCustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<CustOrg_Record> Link_CustOrg_By_CustUuid(OrderLimit limit)
		{
			try{
				List<CustOrg_Record> ret= new List<CustOrg_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrg ___table = new CustOrg(dbc);
				ret=(List<CustOrg_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_UUID,this.CUST_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<CustOrg_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<VCustOrder_Record> Link_VCustOrder_By_CustUuid(OrderLimit limit)
		{
			try{
				List<VCustOrder_Record> ret= new List<VCustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VCustOrder ___table = new VCustOrder(dbc);
				ret=(List<VCustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_UUID,this.CUST_UUID))
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
		public CustOrg LinkFill_CustOrg_By_CustUuid()
		{
			try{
				var data = Link_CustOrg_By_CustUuid();
				CustOrg ret=new CustOrg(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public VCustOrder LinkFill_VCustOrder_By_CustUuid()
		{
			try{
				var data = Link_VCustOrder_By_CustUuid();
				VCustOrder ret=new VCustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public CustOrg LinkFill_CustOrg_By_CustUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrg_By_CustUuid(limit);
				CustOrg ret=new CustOrg(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public VCustOrder LinkFill_VCustOrder_By_CustUuid(OrderLimit limit)
		{
			try{
				var data = Link_VCustOrder_By_CustUuid(limit);
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
