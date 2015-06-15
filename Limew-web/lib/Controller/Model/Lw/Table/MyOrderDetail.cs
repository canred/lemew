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
	[TableView("MY_ORDER_DETAIL", true)]
	public partial class MyOrderDetail : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private MyOrderDetail_Record _currentRecord = null;
	private IList<MyOrderDetail_Record> _All_Record = new List<MyOrderDetail_Record>();
		/*建構子*/
		public MyOrderDetail(){}
		public MyOrderDetail(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public MyOrderDetail(IDataBaseConfigInfo dbc): base(dbc){}
		public MyOrderDetail(IDataBaseConfigInfo dbc,MyOrderDetail_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public MyOrderDetail(IList<MyOrderDetail_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string MY_ORDER_DETAIL_UUID {
			[ColumnName("MY_ORDER_DETAIL_UUID",true,typeof(string))]
			get{return "MY_ORDER_DETAIL_UUID" ; }}
		public string MY_ORDER_DETAIL_GOODS_NAME {
			[ColumnName("MY_ORDER_DETAIL_GOODS_NAME",false,typeof(string))]
			get{return "MY_ORDER_DETAIL_GOODS_NAME" ; }}
		public string MY_ORDER_DETAIL_GOODS_COUNT {
			[ColumnName("MY_ORDER_DETAIL_GOODS_COUNT",false,typeof(int?))]
			get{return "MY_ORDER_DETAIL_GOODS_COUNT" ; }}
		public string MY_ORDER_DETAIL_PRICE {
			[ColumnName("MY_ORDER_DETAIL_PRICE",false,typeof(decimal?))]
			get{return "MY_ORDER_DETAIL_PRICE" ; }}
		public string MY_ORDER_DETAIL_TOTAL_PRICE {
			[ColumnName("MY_ORDER_DETAIL_TOTAL_PRICE",false,typeof(decimal?))]
			get{return "MY_ORDER_DETAIL_TOTAL_PRICE" ; }}
		public string MY_ORDER_DETAIL_IS_FINISH {
			[ColumnName("MY_ORDER_DETAIL_IS_FINISH",false,typeof(int?))]
			get{return "MY_ORDER_DETAIL_IS_FINISH" ; }}
		public string MY_ORDER_DETAIL_IS_ACTIVE {
			[ColumnName("MY_ORDER_DETAIL_IS_ACTIVE",false,typeof(int?))]
			get{return "MY_ORDER_DETAIL_IS_ACTIVE" ; }}
		public string MY_ORDER_DETAIL_ATTENDANT_UUID {
			[ColumnName("MY_ORDER_DETAIL_ATTENDANT_UUID",false,typeof(string))]
			get{return "MY_ORDER_DETAIL_ATTENDANT_UUID" ; }}
		public string SUPPLIER_GOODS_UUID {
			[ColumnName("SUPPLIER_GOODS_UUID",false,typeof(string))]
			get{return "SUPPLIER_GOODS_UUID" ; }}
		public string MY_ORDER_UUID {
			[ColumnName("MY_ORDER_UUID",false,typeof(string))]
			get{return "MY_ORDER_UUID" ; }}
		public string UNIT_UUID {
			[ColumnName("UNIT_UUID",false,typeof(string))]
			get{return "UNIT_UUID" ; }}
		public string MY_ORDER_DETAIL_PS {
			[ColumnName("MY_ORDER_DETAIL_PS",false,typeof(string))]
			get{return "MY_ORDER_DETAIL_PS" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public MyOrderDetail_Record CurrentRecord(){
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
		public MyOrderDetail_Record CreateNew(){
			try{
				MyOrderDetail_Record newData = new MyOrderDetail_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<MyOrderDetail_Record> AllRecord(){
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
				_All_Record = new List<MyOrderDetail_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public MyOrderDetail Fill_By_PK(string pmy_order_detail_uuid){
			try{
				IList<MyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<MyOrderDetail_Record>()  ;  
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
		public MyOrderDetail Fill_By_PK(string pmy_order_detail_uuid,DB db){
			try{
				IList<MyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<MyOrderDetail_Record>(db)  ;  
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
		public MyOrderDetail_Record Fetch_By_PK(string pmy_order_detail_uuid){
			try{
				IList<MyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<MyOrderDetail_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public MyOrderDetail_Record Fetch_By_PK(string pmy_order_detail_uuid,DB db){
			try{
				IList<MyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<MyOrderDetail_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public MyOrderDetail Fill_By_MyOrderDetailUuid(string pmy_order_detail_uuid){
			try{
				IList<MyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<MyOrderDetail_Record>()  ;  
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
		public MyOrderDetail Fill_By_MyOrderDetailUuid(string pmy_order_detail_uuid,DB db){
			try{
				IList<MyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<MyOrderDetail_Record>(db)  ;  
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
		public MyOrderDetail_Record Fetch_By_MyOrderDetailUuid(string pmy_order_detail_uuid){
			try{
				IList<MyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<MyOrderDetail_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public MyOrderDetail_Record Fetch_By_MyOrderDetailUuid(string pmy_order_detail_uuid,DB db){
			try{
				IList<MyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<MyOrderDetail_Record>(db)  ;  
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
				UpdateAllRecord<MyOrderDetail_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<MyOrderDetail_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<MyOrderDetail_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<MyOrderDetail_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<MyOrderDetail_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<MyOrderDetail_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		public List<MyOrder_Record> Link_MyOrder_By_MyOrderUuid()
		{
			try{
				List<MyOrder_Record> ret= new List<MyOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				MyOrder ___table = new MyOrder(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.MY_ORDER_UUID,item.MY_ORDER_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<MyOrder_Record>)
						___table.Where(condition)
						.FetchAll<MyOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<SupplierGoods_Record> Link_SupplierGoods_By_SupplierGoodsUuid()
		{
			try{
				List<SupplierGoods_Record> ret= new List<SupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				SupplierGoods ___table = new SupplierGoods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SUPPLIER_GOODS_UUID,item.SUPPLIER_GOODS_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<SupplierGoods_Record>)
						___table.Where(condition)
						.FetchAll<SupplierGoods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<MyOrder_Record> Link_MyOrder_By_MyOrderUuid(OrderLimit limit)
		{
			try{
				List<MyOrder_Record> ret= new List<MyOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				MyOrder ___table = new MyOrder(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.MY_ORDER_UUID,item.MY_ORDER_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<MyOrder_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<MyOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<SupplierGoods_Record> Link_SupplierGoods_By_SupplierGoodsUuid(OrderLimit limit)
		{
			try{
				List<SupplierGoods_Record> ret= new List<SupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				SupplierGoods ___table = new SupplierGoods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SUPPLIER_GOODS_UUID,item.SUPPLIER_GOODS_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<SupplierGoods_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<SupplierGoods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public MyOrder LinkFill_MyOrder_By_MyOrderUuid()
		{
			try{
				var data = Link_MyOrder_By_MyOrderUuid();
				MyOrder ret=new MyOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public SupplierGoods LinkFill_SupplierGoods_By_SupplierGoodsUuid()
		{
			try{
				var data = Link_SupplierGoods_By_SupplierGoodsUuid();
				SupplierGoods ret=new SupplierGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public MyOrder LinkFill_MyOrder_By_MyOrderUuid(OrderLimit limit)
		{
			try{
				var data = Link_MyOrder_By_MyOrderUuid(limit);
				MyOrder ret=new MyOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public SupplierGoods LinkFill_SupplierGoods_By_SupplierGoodsUuid(OrderLimit limit)
		{
			try{
				var data = Link_SupplierGoods_By_SupplierGoodsUuid(limit);
				SupplierGoods ret=new SupplierGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
