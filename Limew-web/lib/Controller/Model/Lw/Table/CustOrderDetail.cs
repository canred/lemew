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
	[TableView("CUST_ORDER_DETAIL", true)]
	public partial class CustOrderDetail : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private CustOrderDetail_Record _currentRecord = null;
	private IList<CustOrderDetail_Record> _All_Record = new List<CustOrderDetail_Record>();
		/*建構子*/
		public CustOrderDetail(){}
		public CustOrderDetail(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public CustOrderDetail(IDataBaseConfigInfo dbc): base(dbc){}
		public CustOrderDetail(IDataBaseConfigInfo dbc,CustOrderDetail_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public CustOrderDetail(IList<CustOrderDetail_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string CUST_ORDER_DETAIL_UUID {
			[ColumnName("CUST_ORDER_DETAIL_UUID",true,typeof(string))]
			get{return "CUST_ORDER_DETAIL_UUID" ; }}
		public string CUST_ORDER_UUID {
			[ColumnName("CUST_ORDER_UUID",false,typeof(string))]
			get{return "CUST_ORDER_UUID" ; }}
		public string GOODS_UUID {
			[ColumnName("GOODS_UUID",false,typeof(string))]
			get{return "GOODS_UUID" ; }}
		public string CUST_ORDER_DETAIL_GOODS_NAME {
			[ColumnName("CUST_ORDER_DETAIL_GOODS_NAME",false,typeof(string))]
			get{return "CUST_ORDER_DETAIL_GOODS_NAME" ; }}
		public string CUST_ORDER_DETAIL_COUNT {
			[ColumnName("CUST_ORDER_DETAIL_COUNT",false,typeof(int?))]
			get{return "CUST_ORDER_DETAIL_COUNT" ; }}
		public string CUST_ORDER_DETAIL_UNIT {
			[ColumnName("CUST_ORDER_DETAIL_UNIT",false,typeof(string))]
			get{return "CUST_ORDER_DETAIL_UNIT" ; }}
		public string CUST_ORDER_DETAIL_PRICE {
			[ColumnName("CUST_ORDER_DETAIL_PRICE",false,typeof(decimal?))]
			get{return "CUST_ORDER_DETAIL_PRICE" ; }}
		public string CUST_ORDER_DETAIL_TOTAL_PRICE {
			[ColumnName("CUST_ORDER_DETAIL_TOTAL_PRICE",false,typeof(decimal?))]
			get{return "CUST_ORDER_DETAIL_TOTAL_PRICE" ; }}
		public string CUST_ORDER_DETAIL_PS {
			[ColumnName("CUST_ORDER_DETAIL_PS",false,typeof(string))]
			get{return "CUST_ORDER_DETAIL_PS" ; }}
		public string CUST_ORDER_DETAIL_CR {
			[ColumnName("CUST_ORDER_DETAIL_CR",false,typeof(DateTime?))]
			get{return "CUST_ORDER_DETAIL_CR" ; }}
		public string CUST_ORDER_DETAIL_CUSTOMIZED {
			[ColumnName("CUST_ORDER_DETAIL_CUSTOMIZED",false,typeof(int?))]
			get{return "CUST_ORDER_DETAIL_CUSTOMIZED" ; }}
		public string FILEGROUP_UUID {
			[ColumnName("FILEGROUP_UUID",false,typeof(string))]
			get{return "FILEGROUP_UUID" ; }}
		public string SUPPLIER_GOODS_UUID {
			[ColumnName("SUPPLIER_GOODS_UUID",false,typeof(string))]
			get{return "SUPPLIER_GOODS_UUID" ; }}
		public string CUST_ORDER_DETAIL_IS_ACTIVE {
			[ColumnName("CUST_ORDER_DETAIL_IS_ACTIVE",false,typeof(int?))]
			get{return "CUST_ORDER_DETAIL_IS_ACTIVE" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public CustOrderDetail_Record CurrentRecord(){
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
		public CustOrderDetail_Record CreateNew(){
			try{
				CustOrderDetail_Record newData = new CustOrderDetail_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<CustOrderDetail_Record> AllRecord(){
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
				_All_Record = new List<CustOrderDetail_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public CustOrderDetail Fill_By_PK(string pcust_order_detail_uuid){
			try{
				IList<CustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<CustOrderDetail_Record>()  ;  
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
		public CustOrderDetail Fill_By_PK(string pcust_order_detail_uuid,DB db){
			try{
				IList<CustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<CustOrderDetail_Record>(db)  ;  
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
		public CustOrderDetail_Record Fetch_By_PK(string pcust_order_detail_uuid){
			try{
				IList<CustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<CustOrderDetail_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public CustOrderDetail_Record Fetch_By_PK(string pcust_order_detail_uuid,DB db){
			try{
				IList<CustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<CustOrderDetail_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public CustOrderDetail Fill_By_CustOrderDetailUuid(string pcust_order_detail_uuid){
			try{
				IList<CustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<CustOrderDetail_Record>()  ;  
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
		public CustOrderDetail Fill_By_CustOrderDetailUuid(string pcust_order_detail_uuid,DB db){
			try{
				IList<CustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<CustOrderDetail_Record>(db)  ;  
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
		public CustOrderDetail_Record Fetch_By_CustOrderDetailUuid(string pcust_order_detail_uuid){
			try{
				IList<CustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<CustOrderDetail_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public CustOrderDetail_Record Fetch_By_CustOrderDetailUuid(string pcust_order_detail_uuid,DB db){
			try{
				IList<CustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<CustOrderDetail_Record>(db)  ;  
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
				UpdateAllRecord<CustOrderDetail_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<CustOrderDetail_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<CustOrderDetail_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<CustOrderDetail_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<CustOrderDetail_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<CustOrderDetail_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		public List<Goods_Record> Link_Goods_By_GoodsUuid()
		{
			try{
				List<Goods_Record> ret= new List<Goods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Goods ___table = new Goods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.GOODS_UUID,item.GOODS_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Goods_Record>)
						___table.Where(condition)
						.FetchAll<Goods_Record>() ; 
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
		public List<CustOrder_Record> Link_CustOrder_By_CustOrderUuid()
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_ORDER_UUID,item.CUST_ORDER_UUID).R().Or()  ; 
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
		/*201303180340*/
		public List<Goods_Record> Link_Goods_By_GoodsUuid(OrderLimit limit)
		{
			try{
				List<Goods_Record> ret= new List<Goods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Goods ___table = new Goods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.GOODS_UUID,item.GOODS_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Goods_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<Goods_Record>() ; 
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
		/*201303180340*/
		public List<CustOrder_Record> Link_CustOrder_By_CustOrderUuid(OrderLimit limit)
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_ORDER_UUID,item.CUST_ORDER_UUID).R().Or()  ; 
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
		/*201303180336*/
		public Goods LinkFill_Goods_By_GoodsUuid()
		{
			try{
				var data = Link_Goods_By_GoodsUuid();
				Goods ret=new Goods(data);
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
		/*201303180336*/
		public CustOrder LinkFill_CustOrder_By_CustOrderUuid()
		{
			try{
				var data = Link_CustOrder_By_CustOrderUuid();
				CustOrder ret=new CustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public Goods LinkFill_Goods_By_GoodsUuid(OrderLimit limit)
		{
			try{
				var data = Link_Goods_By_GoodsUuid(limit);
				Goods ret=new Goods(data);
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
		/*201303180337*/
		public CustOrder LinkFill_CustOrder_By_CustOrderUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrder_By_CustOrderUuid(limit);
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
