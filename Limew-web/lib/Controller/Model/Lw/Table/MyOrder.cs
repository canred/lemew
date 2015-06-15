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
	[TableView("MY_ORDER", true)]
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
		public string MY_ORDER_UUID {
			[ColumnName("MY_ORDER_UUID",true,typeof(string))]
			get{return "MY_ORDER_UUID" ; }}
		public string SUPPLIER_UUID {
			[ColumnName("SUPPLIER_UUID",false,typeof(string))]
			get{return "SUPPLIER_UUID" ; }}
		public string MY_ORDER_SUPPLIER_NAME {
			[ColumnName("MY_ORDER_SUPPLIER_NAME",false,typeof(string))]
			get{return "MY_ORDER_SUPPLIER_NAME" ; }}
		public string MY_ORDER_SUPPLIER_TEL {
			[ColumnName("MY_ORDER_SUPPLIER_TEL",false,typeof(string))]
			get{return "MY_ORDER_SUPPLIER_TEL" ; }}
		public string MY_ORDER_SUPPLIER_FAX {
			[ColumnName("MY_ORDER_SUPPLIER_FAX",false,typeof(string))]
			get{return "MY_ORDER_SUPPLIER_FAX" ; }}
		public string MY_ORDER_SUPPLIER_ADDRESS {
			[ColumnName("MY_ORDER_SUPPLIER_ADDRESS",false,typeof(string))]
			get{return "MY_ORDER_SUPPLIER_ADDRESS" ; }}
		public string MY_ORDER_CONTACT_NAME {
			[ColumnName("MY_ORDER_CONTACT_NAME",false,typeof(string))]
			get{return "MY_ORDER_CONTACT_NAME" ; }}
		public string MY_ORDER_CONTACT_PHONE {
			[ColumnName("MY_ORDER_CONTACT_PHONE",false,typeof(string))]
			get{return "MY_ORDER_CONTACT_PHONE" ; }}
		public string MY_ORDER_CONTACT_EMAIL {
			[ColumnName("MY_ORDER_CONTACT_EMAIL",false,typeof(string))]
			get{return "MY_ORDER_CONTACT_EMAIL" ; }}
		public string MY_ORDER_PS {
			[ColumnName("MY_ORDER_PS",false,typeof(string))]
			get{return "MY_ORDER_PS" ; }}
		public string MY_ORDER_CR {
			[ColumnName("MY_ORDER_CR",false,typeof(DateTime?))]
			get{return "MY_ORDER_CR" ; }}
		public string MY_ORDER_TOTAL_PRICE {
			[ColumnName("MY_ORDER_TOTAL_PRICE",false,typeof(decimal?))]
			get{return "MY_ORDER_TOTAL_PRICE" ; }}
		public string MY_ORDER_IS_ACTIVE {
			[ColumnName("MY_ORDER_IS_ACTIVE",false,typeof(int?))]
			get{return "MY_ORDER_IS_ACTIVE" ; }}
		public string MY_ORDER_ID {
			[ColumnName("MY_ORDER_ID",false,typeof(string))]
			get{return "MY_ORDER_ID" ; }}
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
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord() {
			try{
				UpdateAllRecord<MyOrder_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<MyOrder_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<MyOrder_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<MyOrder_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<MyOrder_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<MyOrder_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<MyOrderDetail_Record> Link_MyOrderDetail_By_MyOrderUuid()
		{
			try{
				List<MyOrderDetail_Record> ret= new List<MyOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				MyOrderDetail ___table = new MyOrderDetail(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.MY_ORDER_UUID,item.MY_ORDER_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<MyOrderDetail_Record>)
						___table.Where(condition)
						.FetchAll<MyOrderDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<MyOrderDetail_Record> Link_MyOrderDetail_By_MyOrderUuid(OrderLimit limit)
		{
			try{
				List<MyOrderDetail_Record> ret= new List<MyOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				MyOrderDetail ___table = new MyOrderDetail(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.MY_ORDER_UUID,item.MY_ORDER_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<MyOrderDetail_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<MyOrderDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<Supplier_Record> Link_Supplier_By_SupplierUuid()
		{
			try{
				List<Supplier_Record> ret= new List<Supplier_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Supplier ___table = new Supplier(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SUPPLIER_UUID,item.SUPPLIER_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Supplier_Record>)
						___table.Where(condition)
						.FetchAll<Supplier_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<Supplier_Record> Link_Supplier_By_SupplierUuid(OrderLimit limit)
		{
			try{
				List<Supplier_Record> ret= new List<Supplier_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Supplier ___table = new Supplier(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SUPPLIER_UUID,item.SUPPLIER_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Supplier_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<Supplier_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public MyOrderDetail LinkFill_MyOrderDetail_By_MyOrderUuid()
		{
			try{
				var data = Link_MyOrderDetail_By_MyOrderUuid();
				MyOrderDetail ret=new MyOrderDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public MyOrderDetail LinkFill_MyOrderDetail_By_MyOrderUuid(OrderLimit limit)
		{
			try{
				var data = Link_MyOrderDetail_By_MyOrderUuid(limit);
				MyOrderDetail ret=new MyOrderDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public Supplier LinkFill_Supplier_By_SupplierUuid()
		{
			try{
				var data = Link_Supplier_By_SupplierUuid();
				Supplier ret=new Supplier(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public Supplier LinkFill_Supplier_By_SupplierUuid(OrderLimit limit)
		{
			try{
				var data = Link_Supplier_By_SupplierUuid(limit);
				Supplier ret=new Supplier(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
