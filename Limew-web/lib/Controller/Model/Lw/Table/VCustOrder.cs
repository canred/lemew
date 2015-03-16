using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using LK.Attribute;  
using LK.DB;  
using LK.Config.DataBase;  
using LK.DB.SQLCreater;  
using Limew.Model.Lw.Table.Record  ;  
namespace Limew.Model.Lw.Table
{
	[LkDataBase("LIMEW")]
	[TableView("V_CUST_ORDER", false)]
	public partial class VCustOrder : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VCustOrder_Record _currentRecord = null;
	private IList<VCustOrder_Record> _All_Record = new List<VCustOrder_Record>();
		/*建構子*/
		public VCustOrder(){}
		public VCustOrder(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VCustOrder(IDataBaseConfigInfo dbc): base(dbc){}
		public VCustOrder(IDataBaseConfigInfo dbc,VCustOrder_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VCustOrder(IList<VCustOrder_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string CUST_ORDER_UUID {get{return "CUST_ORDER_UUID" ; }}
		public string CUST_ORDER_CR {get{return "CUST_ORDER_CR" ; }}
		public string CUST_ORDER_ID {get{return "CUST_ORDER_ID" ; }}
		public string CUST_ORDER_TOTAL_PRICE {get{return "CUST_ORDER_TOTAL_PRICE" ; }}
		public string CUST_ORDER_STATUS_UUID {get{return "CUST_ORDER_STATUS_UUID" ; }}
		public string CUST_ORDER_IS_ACTIVE {get{return "CUST_ORDER_IS_ACTIVE" ; }}
		public string CUST_UUID {get{return "CUST_UUID" ; }}
		public string CUST_ORDER_TYPE {get{return "CUST_ORDER_TYPE" ; }}
		public string CUST_ORDER_CUST_NAME {get{return "CUST_ORDER_CUST_NAME" ; }}
		public string CUST_ORDER_DEPT {get{return "CUST_ORDER_DEPT" ; }}
		public string CUST_ORDER_USER_NAME {get{return "CUST_ORDER_USER_NAME" ; }}
		public string CUST_ORDER_USER_PHONE {get{return "CUST_ORDER_USER_PHONE" ; }}
		public string CUST_ORDER_PURCHASE_AMOUNT {get{return "CUST_ORDER_PURCHASE_AMOUNT" ; }}
		public string CUST_ORDER_PRINT_USER_NAME {get{return "CUST_ORDER_PRINT_USER_NAME" ; }}
		public string CUST_ORDER_SHIPPING_DATE {get{return "CUST_ORDER_SHIPPING_DATE" ; }}
		public string SHIPPING_STATUS_UUID {get{return "SHIPPING_STATUS_UUID" ; }}
		public string CUST_ORDER_PO_NUMBER {get{return "CUST_ORDER_PO_NUMBER" ; }}
		public string PAY_STATUS_UUID {get{return "PAY_STATUS_UUID" ; }}
		public string PAY_METHOD_UUID {get{return "PAY_METHOD_UUID" ; }}
		public string CUST_ORDER_INVOICE_NUMBER {get{return "CUST_ORDER_INVOICE_NUMBER" ; }}
		public string CUST_ORDER_LIMIT_DATE {get{return "CUST_ORDER_LIMIT_DATE" ; }}
		public string CUST_ORG_UUID {get{return "CUST_ORG_UUID" ; }}
		public string CUST_ORDER_HAS_TAX {get{return "CUST_ORDER_HAS_TAX" ; }}
		public string CUST_NAME {get{return "CUST_NAME" ; }}
		public string CUST_ADDRESS {get{return "CUST_ADDRESS" ; }}
		public string CUST_FAX {get{return "CUST_FAX" ; }}
		public string CUST_IS_ACTIVE {get{return "CUST_IS_ACTIVE" ; }}
		public string CUST_LAST_BUY {get{return "CUST_LAST_BUY" ; }}
		public string CUST_PS {get{return "CUST_PS" ; }}
		public string CUST_SALES_EMAIL {get{return "CUST_SALES_EMAIL" ; }}
		public string CUST_SALES_NAME {get{return "CUST_SALES_NAME" ; }}
		public string CUST_SALES_PHONE {get{return "CUST_SALES_PHONE" ; }}
		public string CUST_TEL {get{return "CUST_TEL" ; }}
		public string PAY_STATUS_NAME {get{return "PAY_STATUS_NAME" ; }}
		public string PAY_METHOD_NAME {get{return "PAY_METHOD_NAME" ; }}
		public string CUST_ORG_SALES_NAME {get{return "CUST_ORG_SALES_NAME" ; }}
		public string CUST_ORG_SALES_PHONE {get{return "CUST_ORG_SALES_PHONE" ; }}
		public string CUST_ORG_SALES_EMAIL {get{return "CUST_ORG_SALES_EMAIL" ; }}
		public string CUST_ORG_PS {get{return "CUST_ORG_PS" ; }}
		public string CUST_ORG_NAME {get{return "CUST_ORG_NAME" ; }}
		public string CUST_ORG_IS_ACTIVE {get{return "CUST_ORG_IS_ACTIVE" ; }}
		public string CUST_ORDER_PS {get{return "CUST_ORDER_PS" ; }}
		public string CUST_ORDER_REPORT_DATE {get{return "CUST_ORDER_REPORT_DATE" ; }}
		public string CUST_ORDER_REPORT_ATTENDANT_UUID {get{return "CUST_ORDER_REPORT_ATTENDANT_UUID" ; }}
		public string CUST_ORDER_REPORT_ATTENDANT_C_NAME {get{return "CUST_ORDER_REPORT_ATTENDANT_C_NAME" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VCustOrder_Record CurrentRecord(){
			try{
				if (_currentRecord == null){
					if (this._All_Record.Count > 0){
						_currentRecord = this._All_Record.First();
					}
				}
				return _currentRecord;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VCustOrder_Record CreateNew(){
			try{
				VCustOrder_Record newData = new VCustOrder_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VCustOrder_Record> AllRecord(){
			try{
				return _All_Record;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public void RemoveAllRecord(){
			try{
				_All_Record = new List<VCustOrder_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public VCustOrder Fill_By_PK(string pcust_order_uuid){
			try{
				IList<VCustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<VCustOrder_Record>()  ;  
				_All_Record = ret;
				if (_All_Record.Count > 0){
					_currentRecord = ret.First();}
				else{
					_currentRecord = null;}
				return this;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 201303180156
		public VCustOrder Fill_By_PK(string pcust_order_uuid,DB db){
			try{
				IList<VCustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<VCustOrder_Record>(db)  ;  
				_All_Record = ret;
				if (_All_Record.Count > 0){
					_currentRecord = ret.First();}
				else{
					_currentRecord = null;}
				return this;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319042
		public VCustOrder_Record Fetch_By_PK(string pcust_order_uuid){
			try{
				IList<VCustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<VCustOrder_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public VCustOrder_Record Fetch_By_PK(string pcust_order_uuid,DB db){
			try{
				IList<VCustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<VCustOrder_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public VCustOrder Fill_By_CustOrderUuid(string pcust_order_uuid){
			try{
				IList<VCustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<VCustOrder_Record>()  ;  
				_All_Record = ret;
				_currentRecord = ret.First();
				return this;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319046
		public VCustOrder Fill_By_CustOrderUuid(string pcust_order_uuid,DB db){
			try{
				IList<VCustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<VCustOrder_Record>(db)  ;  
				_All_Record = ret;
				_currentRecord = ret.First();
				return this;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319047
		public VCustOrder_Record Fetch_By_CustOrderUuid(string pcust_order_uuid){
			try{
				IList<VCustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<VCustOrder_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public VCustOrder_Record Fetch_By_CustOrderUuid(string pcust_order_uuid,DB db){
			try{
				IList<VCustOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
				).FetchAll<VCustOrder_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		public List<Cust_Record> Link_Cust_By_CustUuid()
		{
			try{
				List<Cust_Record> ret= new List<Cust_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Cust ___table = new Cust(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_UUID,item.CUST_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Cust_Record>)
						___table.Where(condition)
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
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_ORDER_STATUS_UUID,item.CUST_ORDER_STATUS_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrderStatus_Record>)
						___table.Where(condition)
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
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.PAY_METHOD_UUID,item.PAY_METHOD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<PayMethod_Record>)
						___table.Where(condition)
						.FetchAll<PayMethod_Record>() ; 
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
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_ORG_UUID,item.CUST_ORG_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrg_Record>)
						___table.Where(condition)
						.FetchAll<CustOrg_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<Cust_Record> Link_Cust_By_CustUuid(OrderLimit limit)
		{
			try{
				List<Cust_Record> ret= new List<Cust_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Cust ___table = new Cust(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_UUID,item.CUST_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Cust_Record>)
						___table.Where(condition)
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
		/*201303180340*/
		public List<CustOrderStatus_Record> Link_CustOrderStatus_By_CustOrderStatusUuid(OrderLimit limit)
		{
			try{
				List<CustOrderStatus_Record> ret= new List<CustOrderStatus_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderStatus ___table = new CustOrderStatus(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_ORDER_STATUS_UUID,item.CUST_ORDER_STATUS_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrderStatus_Record>)
						___table.Where(condition)
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
		/*201303180340*/
		public List<PayMethod_Record> Link_PayMethod_By_PayMethodUuid(OrderLimit limit)
		{
			try{
				List<PayMethod_Record> ret= new List<PayMethod_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				PayMethod ___table = new PayMethod(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.PAY_METHOD_UUID,item.PAY_METHOD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<PayMethod_Record>)
						___table.Where(condition)
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
		/*201303180340*/
		public List<CustOrg_Record> Link_CustOrg_By_CustOrgUuid(OrderLimit limit)
		{
			try{
				List<CustOrg_Record> ret= new List<CustOrg_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrg ___table = new CustOrg(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_ORG_UUID,item.CUST_ORG_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrg_Record>)
						___table.Where(condition)
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
		/*201303180336*/
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
		/*201303180336*/
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
		/*201303180336*/
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
		/*201303180336*/
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
		/*201303180337*/
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
		/*201303180337*/
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
		/*201303180337*/
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
		/*201303180337*/
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
