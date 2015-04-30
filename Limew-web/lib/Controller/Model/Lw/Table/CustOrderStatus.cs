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
	[TableView("CUST_ORDER_STATUS", false)]
	public partial class CustOrderStatus : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private CustOrderStatus_Record _currentRecord = null;
	private IList<CustOrderStatus_Record> _All_Record = new List<CustOrderStatus_Record>();
		/*建構子*/
		public CustOrderStatus(){}
		public CustOrderStatus(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public CustOrderStatus(IDataBaseConfigInfo dbc): base(dbc){}
		public CustOrderStatus(IDataBaseConfigInfo dbc,CustOrderStatus_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public CustOrderStatus(IList<CustOrderStatus_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string CUST_ORDER_STATUS_UUID {
			[ColumnName("CUST_ORDER_STATUS_UUID",true,typeof(string))]
			get{return "CUST_ORDER_STATUS_UUID" ; }}
		public string CUST_ORDER_STATUS_NAME {
			[ColumnName("CUST_ORDER_STATUS_NAME",false,typeof(string))]
			get{return "CUST_ORDER_STATUS_NAME" ; }}
		public string CUST_ORDER_STATUS_IS_ACTIVE {
			[ColumnName("CUST_ORDER_STATUS_IS_ACTIVE",false,typeof(int?))]
			get{return "CUST_ORDER_STATUS_IS_ACTIVE" ; }}
		public string CUST_ORDER_STATUS_ORD {
			[ColumnName("CUST_ORDER_STATUS_ORD",false,typeof(short?))]
			get{return "CUST_ORDER_STATUS_ORD" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public CustOrderStatus_Record CurrentRecord(){
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
		public CustOrderStatus_Record CreateNew(){
			try{
				CustOrderStatus_Record newData = new CustOrderStatus_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<CustOrderStatus_Record> AllRecord(){
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
				_All_Record = new List<CustOrderStatus_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public CustOrderStatus Fill_By_PK(string pcust_order_status_uuid){
			try{
				IList<CustOrderStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_STATUS_UUID,pcust_order_status_uuid)
				).FetchAll<CustOrderStatus_Record>()  ;  
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
		public CustOrderStatus Fill_By_PK(string pcust_order_status_uuid,DB db){
			try{
				IList<CustOrderStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_STATUS_UUID,pcust_order_status_uuid)
				).FetchAll<CustOrderStatus_Record>(db)  ;  
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
		public CustOrderStatus_Record Fetch_By_PK(string pcust_order_status_uuid){
			try{
				IList<CustOrderStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_STATUS_UUID,pcust_order_status_uuid)
				).FetchAll<CustOrderStatus_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public CustOrderStatus_Record Fetch_By_PK(string pcust_order_status_uuid,DB db){
			try{
				IList<CustOrderStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_STATUS_UUID,pcust_order_status_uuid)
				).FetchAll<CustOrderStatus_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public CustOrderStatus Fill_By_CustOrderStatusUuid(string pcust_order_status_uuid){
			try{
				IList<CustOrderStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_STATUS_UUID,pcust_order_status_uuid)
				).FetchAll<CustOrderStatus_Record>()  ;  
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
		public CustOrderStatus Fill_By_CustOrderStatusUuid(string pcust_order_status_uuid,DB db){
			try{
				IList<CustOrderStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_STATUS_UUID,pcust_order_status_uuid)
				).FetchAll<CustOrderStatus_Record>(db)  ;  
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
		public CustOrderStatus_Record Fetch_By_CustOrderStatusUuid(string pcust_order_status_uuid){
			try{
				IList<CustOrderStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_STATUS_UUID,pcust_order_status_uuid)
				).FetchAll<CustOrderStatus_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public CustOrderStatus_Record Fetch_By_CustOrderStatusUuid(string pcust_order_status_uuid,DB db){
			try{
				IList<CustOrderStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_STATUS_UUID,pcust_order_status_uuid)
				).FetchAll<CustOrderStatus_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<VCustOrder_Record> Link_VCustOrder_By_CustOrderStatusUuid()
		{
			try{
				List<VCustOrder_Record> ret= new List<VCustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VCustOrder ___table = new VCustOrder(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_ORDER_STATUS_UUID,item.CUST_ORDER_STATUS_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<VCustOrder_Record>)
						___table.Where(condition)
						.FetchAll<VCustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<VCustOrder_Record> Link_VCustOrder_By_CustOrderStatusUuid(OrderLimit limit)
		{
			try{
				List<VCustOrder_Record> ret= new List<VCustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VCustOrder ___table = new VCustOrder(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_ORDER_STATUS_UUID,item.CUST_ORDER_STATUS_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<VCustOrder_Record>)
						___table.Where(condition)
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
		/*201303180324*/
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
		/*201303180325*/
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
