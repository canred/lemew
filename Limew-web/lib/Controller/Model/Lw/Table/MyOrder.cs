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
	[TableView("MY_ORDER", false)]
	public partial class MyOrder : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private MyOrder_Record _currentRecord = null;
	private IList<MyOrder_Record> _All_Record = new List<MyOrder_Record>();
		/*建構子*/
		public MyOrder(){}
		public MyOrder(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public MyOrder(IDataBaseConfigInfo dbc): base(dbc){}
		public MyOrder(IDataBaseConfigInfo dbc,MyOrder_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public MyOrder(IList<MyOrder_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string MY_ORDER_UUID {get{return "MY_ORDER_UUID" ; }}
		public string MY_ORDER_DATE {get{return "MY_ORDER_DATE" ; }}
		public string MY_ORDER_SUPPLIER_NAME {get{return "MY_ORDER_SUPPLIER_NAME" ; }}
		public string MY_ORDER_SUPPLIER_TEL {get{return "MY_ORDER_SUPPLIER_TEL" ; }}
		public string MY_ORDER_SUPPLIER_MAN {get{return "MY_ORDER_SUPPLIER_MAN" ; }}
		public string MY_ORDER_GOODS_NAME {get{return "MY_ORDER_GOODS_NAME" ; }}
		public string MY_ORDER_GOODS_COUNT {get{return "MY_ORDER_GOODS_COUNT" ; }}
		public string MY_ORDER_PRICE {get{return "MY_ORDER_PRICE" ; }}
		public string MY_ORDER_TOTAL_PRICE {get{return "MY_ORDER_TOTAL_PRICE" ; }}
		public string MY_ORDER_PS {get{return "MY_ORDER_PS" ; }}
		public string MY_ORDER_IS_FINISH {get{return "MY_ORDER_IS_FINISH" ; }}
		public string MY_ORDER_PAY_METHOD {get{return "MY_ORDER_PAY_METHOD" ; }}
		public string MY_ORDER_IS_ACTIVE {get{return "MY_ORDER_IS_ACTIVE" ; }}
		public string MY_ORDER_ATTENDANT_UUID {get{return "MY_ORDER_ATTENDANT_UUID" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public MyOrder_Record CurrentRecord(){
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
		public MyOrder_Record CreateNew(){
			try{
				MyOrder_Record newData = new MyOrder_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<MyOrder_Record> AllRecord(){
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
				_All_Record = new List<MyOrder_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public MyOrder Fill_By_PK(string pmy_order_uuid){
			try{
				IList<MyOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
				).FetchAll<MyOrder_Record>()  ;  
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
		public MyOrder Fill_By_PK(string pmy_order_uuid,DB db){
			try{
				IList<MyOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
				).FetchAll<MyOrder_Record>(db)  ;  
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
		public MyOrder_Record Fetch_By_PK(string pmy_order_uuid){
			try{
				IList<MyOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
				).FetchAll<MyOrder_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public MyOrder_Record Fetch_By_PK(string pmy_order_uuid,DB db){
			try{
				IList<MyOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
				).FetchAll<MyOrder_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public MyOrder Fill_By_MyOrderUuid(string pmy_order_uuid){
			try{
				IList<MyOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
				).FetchAll<MyOrder_Record>()  ;  
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
		public MyOrder Fill_By_MyOrderUuid(string pmy_order_uuid,DB db){
			try{
				IList<MyOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
				).FetchAll<MyOrder_Record>(db)  ;  
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
		public MyOrder_Record Fetch_By_MyOrderUuid(string pmy_order_uuid){
			try{
				IList<MyOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
				).FetchAll<MyOrder_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public MyOrder_Record Fetch_By_MyOrderUuid(string pmy_order_uuid,DB db){
			try{
				IList<MyOrder_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
				).FetchAll<MyOrder_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
	}
}
