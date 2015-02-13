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
	[TableView("SHIPPING_STATUS", false)]
	public partial class ShippingStatus : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private ShippingStatus_Record _currentRecord = null;
	private IList<ShippingStatus_Record> _All_Record = new List<ShippingStatus_Record>();
		/*建構子*/
		public ShippingStatus(){}
		public ShippingStatus(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public ShippingStatus(IDataBaseConfigInfo dbc): base(dbc){}
		public ShippingStatus(IDataBaseConfigInfo dbc,ShippingStatus_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public ShippingStatus(IList<ShippingStatus_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string SHIPPING_STATUS_UUID {get{return "SHIPPING_STATUS_UUID" ; }}
		public string SHIPPING_STATUS_NAME {get{return "SHIPPING_STATUS_NAME" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public ShippingStatus_Record CurrentRecord(){
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
		public ShippingStatus_Record CreateNew(){
			try{
				ShippingStatus_Record newData = new ShippingStatus_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<ShippingStatus_Record> AllRecord(){
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
				_All_Record = new List<ShippingStatus_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public ShippingStatus Fill_By_PK(string pshipping_status_uuid){
			try{
				IList<ShippingStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_STATUS_UUID,pshipping_status_uuid)
				).FetchAll<ShippingStatus_Record>()  ;  
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
		public ShippingStatus Fill_By_PK(string pshipping_status_uuid,DB db){
			try{
				IList<ShippingStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_STATUS_UUID,pshipping_status_uuid)
				).FetchAll<ShippingStatus_Record>(db)  ;  
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
		public ShippingStatus_Record Fetch_By_PK(string pshipping_status_uuid){
			try{
				IList<ShippingStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_STATUS_UUID,pshipping_status_uuid)
				).FetchAll<ShippingStatus_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public ShippingStatus_Record Fetch_By_PK(string pshipping_status_uuid,DB db){
			try{
				IList<ShippingStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_STATUS_UUID,pshipping_status_uuid)
				).FetchAll<ShippingStatus_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public ShippingStatus Fill_By_ShippingStatusUuid(string pshipping_status_uuid){
			try{
				IList<ShippingStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_STATUS_UUID,pshipping_status_uuid)
				).FetchAll<ShippingStatus_Record>()  ;  
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
		public ShippingStatus Fill_By_ShippingStatusUuid(string pshipping_status_uuid,DB db){
			try{
				IList<ShippingStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_STATUS_UUID,pshipping_status_uuid)
				).FetchAll<ShippingStatus_Record>(db)  ;  
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
		public ShippingStatus_Record Fetch_By_ShippingStatusUuid(string pshipping_status_uuid){
			try{
				IList<ShippingStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_STATUS_UUID,pshipping_status_uuid)
				).FetchAll<ShippingStatus_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public ShippingStatus_Record Fetch_By_ShippingStatusUuid(string pshipping_status_uuid,DB db){
			try{
				IList<ShippingStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_STATUS_UUID,pshipping_status_uuid)
				).FetchAll<ShippingStatus_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<CustOrder_Record> Link_CustOrder_By_ShippingStatusUuid()
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SHIPPING_STATUS_UUID,item.SHIPPING_STATUS_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrder_Record>)
						___table.Where(condition)
						.FetchAll<CustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<CustOrder_Record> Link_CustOrder_By_ShippingStatusUuid(OrderLimit limit)
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SHIPPING_STATUS_UUID,item.SHIPPING_STATUS_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrder_Record>)
						___table.Where(condition)
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
		/*201303180324*/
		public CustOrder LinkFill_CustOrder_By_ShippingStatusUuid()
		{
			try{
				var data = Link_CustOrder_By_ShippingStatusUuid();
				CustOrder ret=new CustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public CustOrder LinkFill_CustOrder_By_ShippingStatusUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrder_By_ShippingStatusUuid(limit);
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
