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
	[TableView("CUST_ORDER", true)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class CustOrder_Record : RecordBase{
		public CustOrder_Record(){}
		/*欄位資訊 Start*/
		string _CUST_ORDER_UUID=null;
		DateTime? _CUST_ORDER_CR=null;
		string _CUST_ORDER_ID=null;
		decimal? _CUST_ORDER_TOTAL_PRICE=null;
		string _CUST_ORDER_STATUS_UUID=null;
		int? _CUST_ORDER_IS_ACTIVE=null;
		string _CUST_UUID=null;
		string _CUST_ORDER_TYPE=null;
		string _CUST_ORDER_CUST_NAME=null;
		string _CUST_ORDER_DEPT=null;
		string _CUST_ORDER_USER_NAME=null;
		string _CUST_ORDER_USER_PHONE=null;
		string _CUST_ORDER_PURCHASE_AMOUNT=null;
		string _CUST_ORDER_PRINT_USER_NAME=null;
		DateTime? _CUST_ORDER_SHIPPING_DATE=null;
		string _SHIPPING_STATUS_UUID=null;
		string _CUST_ORDER_INVOICE_NUMBER=null;
		string _PAY_STATUS_UUID=null;
		string _PAY_METHOD_UUID=null;
		string _CUST_ORDER_PO_NUMBER=null;
		DateTime? _CUST_ORDER_LIMIT_DATE=null;
		string _CUST_ORG_UUID=null;
		short? _CUST_ORDER_HAS_TAX=null;
		/*欄位資訊 End*/

		[ColumnName("CUST_ORDER_UUID",true,typeof(string))]
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

		[ColumnName("CUST_ORDER_CR",false,typeof(DateTime?))]
		public DateTime? CUST_ORDER_CR
		{
			set
			{
				_CUST_ORDER_CR=value;
			}
			get
			{
				return _CUST_ORDER_CR;
			}
		}

		[ColumnName("CUST_ORDER_ID",false,typeof(string))]
		public string CUST_ORDER_ID
		{
			set
			{
				_CUST_ORDER_ID=value;
			}
			get
			{
				return _CUST_ORDER_ID;
			}
		}

		[ColumnName("CUST_ORDER_TOTAL_PRICE",false,typeof(decimal?))]
		public decimal? CUST_ORDER_TOTAL_PRICE
		{
			set
			{
				_CUST_ORDER_TOTAL_PRICE=value;
			}
			get
			{
				return _CUST_ORDER_TOTAL_PRICE;
			}
		}

		[ColumnName("CUST_ORDER_STATUS_UUID",false,typeof(string))]
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

		[ColumnName("CUST_ORDER_IS_ACTIVE",false,typeof(int?))]
		public int? CUST_ORDER_IS_ACTIVE
		{
			set
			{
				_CUST_ORDER_IS_ACTIVE=value;
			}
			get
			{
				return _CUST_ORDER_IS_ACTIVE;
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

		[ColumnName("CUST_ORDER_TYPE",false,typeof(string))]
		public string CUST_ORDER_TYPE
		{
			set
			{
				_CUST_ORDER_TYPE=value;
			}
			get
			{
				return _CUST_ORDER_TYPE;
			}
		}

		[ColumnName("CUST_ORDER_CUST_NAME",false,typeof(string))]
		public string CUST_ORDER_CUST_NAME
		{
			set
			{
				_CUST_ORDER_CUST_NAME=value;
			}
			get
			{
				return _CUST_ORDER_CUST_NAME;
			}
		}

		[ColumnName("CUST_ORDER_DEPT",false,typeof(string))]
		public string CUST_ORDER_DEPT
		{
			set
			{
				_CUST_ORDER_DEPT=value;
			}
			get
			{
				return _CUST_ORDER_DEPT;
			}
		}

		[ColumnName("CUST_ORDER_USER_NAME",false,typeof(string))]
		public string CUST_ORDER_USER_NAME
		{
			set
			{
				_CUST_ORDER_USER_NAME=value;
			}
			get
			{
				return _CUST_ORDER_USER_NAME;
			}
		}

		[ColumnName("CUST_ORDER_USER_PHONE",false,typeof(string))]
		public string CUST_ORDER_USER_PHONE
		{
			set
			{
				_CUST_ORDER_USER_PHONE=value;
			}
			get
			{
				return _CUST_ORDER_USER_PHONE;
			}
		}

		[ColumnName("CUST_ORDER_PURCHASE_AMOUNT",false,typeof(string))]
		public string CUST_ORDER_PURCHASE_AMOUNT
		{
			set
			{
				_CUST_ORDER_PURCHASE_AMOUNT=value;
			}
			get
			{
				return _CUST_ORDER_PURCHASE_AMOUNT;
			}
		}

		[ColumnName("CUST_ORDER_PRINT_USER_NAME",false,typeof(string))]
		public string CUST_ORDER_PRINT_USER_NAME
		{
			set
			{
				_CUST_ORDER_PRINT_USER_NAME=value;
			}
			get
			{
				return _CUST_ORDER_PRINT_USER_NAME;
			}
		}

		[ColumnName("CUST_ORDER_SHIPPING_DATE",false,typeof(DateTime?))]
		public DateTime? CUST_ORDER_SHIPPING_DATE
		{
			set
			{
				_CUST_ORDER_SHIPPING_DATE=value;
			}
			get
			{
				return _CUST_ORDER_SHIPPING_DATE;
			}
		}

		[ColumnName("SHIPPING_STATUS_UUID",false,typeof(string))]
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

		[ColumnName("CUST_ORDER_INVOICE_NUMBER",false,typeof(string))]
		public string CUST_ORDER_INVOICE_NUMBER
		{
			set
			{
				_CUST_ORDER_INVOICE_NUMBER=value;
			}
			get
			{
				return _CUST_ORDER_INVOICE_NUMBER;
			}
		}

		[ColumnName("PAY_STATUS_UUID",false,typeof(string))]
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

		[ColumnName("PAY_METHOD_UUID",false,typeof(string))]
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

		[ColumnName("CUST_ORDER_PO_NUMBER",false,typeof(string))]
		public string CUST_ORDER_PO_NUMBER
		{
			set
			{
				_CUST_ORDER_PO_NUMBER=value;
			}
			get
			{
				return _CUST_ORDER_PO_NUMBER;
			}
		}

		[ColumnName("CUST_ORDER_LIMIT_DATE",false,typeof(DateTime?))]
		public DateTime? CUST_ORDER_LIMIT_DATE
		{
			set
			{
				_CUST_ORDER_LIMIT_DATE=value;
			}
			get
			{
				return _CUST_ORDER_LIMIT_DATE;
			}
		}

		[ColumnName("CUST_ORG_UUID",false,typeof(string))]
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

		[ColumnName("CUST_ORDER_HAS_TAX",false,typeof(short?))]
		public short? CUST_ORDER_HAS_TAX
		{
			set
			{
				_CUST_ORDER_HAS_TAX=value;
			}
			get
			{
				return _CUST_ORDER_HAS_TAX;
			}
		}
		public CustOrder_Record Clone(){
			try{
				return this.Clone<CustOrder_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public CustOrder gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ret = new CustOrder(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<CustOrderDetail_Record> Link_CustOrderDetail_By_CustOrderUuid()
		{
			try{
				List<CustOrderDetail_Record> ret= new List<CustOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderDetail ___table = new CustOrderDetail(dbc);
				ret=(List<CustOrderDetail_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORDER_UUID,this.CUST_ORDER_UUID))
					.FetchAll<CustOrderDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<VCustOrder_Record> Link_VCustOrder_By_CustOrderUuid()
		{
			try{
				List<VCustOrder_Record> ret= new List<VCustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VCustOrder ___table = new VCustOrder(dbc);
				ret=(List<VCustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORDER_UUID,this.CUST_ORDER_UUID))
					.FetchAll<VCustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<CustOrderDetail_Record> Link_CustOrderDetail_By_CustOrderUuid(OrderLimit limit)
		{
			try{
				List<CustOrderDetail_Record> ret= new List<CustOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderDetail ___table = new CustOrderDetail(dbc);
				ret=(List<CustOrderDetail_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORDER_UUID,this.CUST_ORDER_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<CustOrderDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<VCustOrder_Record> Link_VCustOrder_By_CustOrderUuid(OrderLimit limit)
		{
			try{
				List<VCustOrder_Record> ret= new List<VCustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VCustOrder ___table = new VCustOrder(dbc);
				ret=(List<VCustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORDER_UUID,this.CUST_ORDER_UUID))
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
		public List<CustOrderStatus_Record> Link_CustOrderStatus_By_CustOrderStatusUuid()
		{
			try{
				List<CustOrderStatus_Record> ret= new List<CustOrderStatus_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderStatus ___table = new CustOrderStatus(dbc);
				ret=(List<CustOrderStatus_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORDER_STATUS_UUID,this.CUST_ORDER_STATUS_UUID))
					.FetchAll<CustOrderStatus_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<PayMethod_Record> Link_PayMethod_By_PayMethodUuid()
		{
			try{
				List<PayMethod_Record> ret= new List<PayMethod_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				PayMethod ___table = new PayMethod(dbc);
				ret=(List<PayMethod_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.PAY_METHOD_UUID,this.PAY_METHOD_UUID))
					.FetchAll<PayMethod_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<ShippingStatus_Record> Link_ShippingStatus_By_ShippingStatusUuid()
		{
			try{
				List<ShippingStatus_Record> ret= new List<ShippingStatus_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				ShippingStatus ___table = new ShippingStatus(dbc);
				ret=(List<ShippingStatus_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.SHIPPING_STATUS_UUID,this.SHIPPING_STATUS_UUID))
					.FetchAll<ShippingStatus_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<CustOrg_Record> Link_CustOrg_By_CustOrgUuid()
		{
			try{
				List<CustOrg_Record> ret= new List<CustOrg_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrg ___table = new CustOrg(dbc);
				ret=(List<CustOrg_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORG_UUID,this.CUST_ORG_UUID))
					.FetchAll<CustOrg_Record>() ; 
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
		/*201303180404*/
		public List<CustOrderStatus_Record> Link_CustOrderStatus_By_CustOrderStatusUuid(OrderLimit limit)
		{
			try{
				List<CustOrderStatus_Record> ret= new List<CustOrderStatus_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderStatus ___table = new CustOrderStatus(dbc);
				ret=(List<CustOrderStatus_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORDER_STATUS_UUID,this.CUST_ORDER_STATUS_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<CustOrderStatus_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<PayMethod_Record> Link_PayMethod_By_PayMethodUuid(OrderLimit limit)
		{
			try{
				List<PayMethod_Record> ret= new List<PayMethod_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				PayMethod ___table = new PayMethod(dbc);
				ret=(List<PayMethod_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.PAY_METHOD_UUID,this.PAY_METHOD_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<PayMethod_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<ShippingStatus_Record> Link_ShippingStatus_By_ShippingStatusUuid(OrderLimit limit)
		{
			try{
				List<ShippingStatus_Record> ret= new List<ShippingStatus_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				ShippingStatus ___table = new ShippingStatus(dbc);
				ret=(List<ShippingStatus_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.SHIPPING_STATUS_UUID,this.SHIPPING_STATUS_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<ShippingStatus_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<CustOrg_Record> Link_CustOrg_By_CustOrgUuid(OrderLimit limit)
		{
			try{
				List<CustOrg_Record> ret= new List<CustOrg_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrg ___table = new CustOrg(dbc);
				ret=(List<CustOrg_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORG_UUID,this.CUST_ORG_UUID))
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
		/*201303180357*/
		public CustOrderDetail LinkFill_CustOrderDetail_By_CustOrderUuid()
		{
			try{
				var data = Link_CustOrderDetail_By_CustOrderUuid();
				CustOrderDetail ret=new CustOrderDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public VCustOrder LinkFill_VCustOrder_By_CustOrderUuid()
		{
			try{
				var data = Link_VCustOrder_By_CustOrderUuid();
				VCustOrder ret=new VCustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public CustOrderDetail LinkFill_CustOrderDetail_By_CustOrderUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrderDetail_By_CustOrderUuid(limit);
				CustOrderDetail ret=new CustOrderDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public VCustOrder LinkFill_VCustOrder_By_CustOrderUuid(OrderLimit limit)
		{
			try{
				var data = Link_VCustOrder_By_CustOrderUuid(limit);
				VCustOrder ret=new VCustOrder(data);
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
		/*2013031800428*/
		public CustOrderStatus LinkFill_CustOrderStatus_By_CustOrderStatusUuid()
		{
			try{
				var data = Link_CustOrderStatus_By_CustOrderStatusUuid();
				CustOrderStatus ret=new CustOrderStatus(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public PayMethod LinkFill_PayMethod_By_PayMethodUuid()
		{
			try{
				var data = Link_PayMethod_By_PayMethodUuid();
				PayMethod ret=new PayMethod(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public ShippingStatus LinkFill_ShippingStatus_By_ShippingStatusUuid()
		{
			try{
				var data = Link_ShippingStatus_By_ShippingStatusUuid();
				ShippingStatus ret=new ShippingStatus(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public CustOrg LinkFill_CustOrg_By_CustOrgUuid()
		{
			try{
				var data = Link_CustOrg_By_CustOrgUuid();
				CustOrg ret=new CustOrg(data);
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
		/*201303180429*/
		public CustOrderStatus LinkFill_CustOrderStatus_By_CustOrderStatusUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrderStatus_By_CustOrderStatusUuid(limit);
				CustOrderStatus ret=new CustOrderStatus(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public PayMethod LinkFill_PayMethod_By_PayMethodUuid(OrderLimit limit)
		{
			try{
				var data = Link_PayMethod_By_PayMethodUuid(limit);
				PayMethod ret=new PayMethod(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public ShippingStatus LinkFill_ShippingStatus_By_ShippingStatusUuid(OrderLimit limit)
		{
			try{
				var data = Link_ShippingStatus_By_ShippingStatusUuid(limit);
				ShippingStatus ret=new ShippingStatus(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public CustOrg LinkFill_CustOrg_By_CustOrgUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrg_By_CustOrgUuid(limit);
				CustOrg ret=new CustOrg(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
