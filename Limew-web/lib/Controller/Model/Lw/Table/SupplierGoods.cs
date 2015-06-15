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
	[TableView("SUPPLIER_GOODS", true)]
	public partial class SupplierGoods : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private SupplierGoods_Record _currentRecord = null;
	private IList<SupplierGoods_Record> _All_Record = new List<SupplierGoods_Record>();
		/*建構子*/
		public SupplierGoods(){}
		public SupplierGoods(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public SupplierGoods(IDataBaseConfigInfo dbc): base(dbc){}
		public SupplierGoods(IDataBaseConfigInfo dbc,SupplierGoods_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public SupplierGoods(IList<SupplierGoods_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string SUPPLIER_GOODS_UUID {
			[ColumnName("SUPPLIER_GOODS_UUID",true,typeof(string))]
			get{return "SUPPLIER_GOODS_UUID" ; }}
		public string SUPPLIER_GOODS_NAME {
			[ColumnName("SUPPLIER_GOODS_NAME",false,typeof(string))]
			get{return "SUPPLIER_GOODS_NAME" ; }}
		public string UNIT_UUID {
			[ColumnName("UNIT_UUID",false,typeof(string))]
			get{return "UNIT_UUID" ; }}
		public string SUPPLIER_GOODS_SN {
			[ColumnName("SUPPLIER_GOODS_SN",false,typeof(string))]
			get{return "SUPPLIER_GOODS_SN" ; }}
		public string SUPPLIER_GOODS_SPEC {
			[ColumnName("SUPPLIER_GOODS_SPEC",false,typeof(string))]
			get{return "SUPPLIER_GOODS_SPEC" ; }}
		public string SUPPLIER_GOODS_PRICE {
			[ColumnName("SUPPLIER_GOODS_PRICE",false,typeof(decimal?))]
			get{return "SUPPLIER_GOODS_PRICE" ; }}
		public string SUPPLIER_GOODS_COST {
			[ColumnName("SUPPLIER_GOODS_COST",false,typeof(decimal?))]
			get{return "SUPPLIER_GOODS_COST" ; }}
		public string SUPPLIER_GOODS_IS_ACTIVE {
			[ColumnName("SUPPLIER_GOODS_IS_ACTIVE",false,typeof(int?))]
			get{return "SUPPLIER_GOODS_IS_ACTIVE" ; }}
		public string SUPPLIER_UUID {
			[ColumnName("SUPPLIER_UUID",false,typeof(string))]
			get{return "SUPPLIER_UUID" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public SupplierGoods_Record CurrentRecord(){
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
		public SupplierGoods_Record CreateNew(){
			try{
				SupplierGoods_Record newData = new SupplierGoods_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<SupplierGoods_Record> AllRecord(){
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
				_All_Record = new List<SupplierGoods_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public SupplierGoods Fill_By_PK(string psupplier_goods_uuid){
			try{
				IList<SupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
				).FetchAll<SupplierGoods_Record>()  ;  
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
		public SupplierGoods Fill_By_PK(string psupplier_goods_uuid,DB db){
			try{
				IList<SupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
				).FetchAll<SupplierGoods_Record>(db)  ;  
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
		public SupplierGoods_Record Fetch_By_PK(string psupplier_goods_uuid){
			try{
				IList<SupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
				).FetchAll<SupplierGoods_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public SupplierGoods_Record Fetch_By_PK(string psupplier_goods_uuid,DB db){
			try{
				IList<SupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
				).FetchAll<SupplierGoods_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public SupplierGoods Fill_By_SupplierGoodsUuid(string psupplier_goods_uuid){
			try{
				IList<SupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
				).FetchAll<SupplierGoods_Record>()  ;  
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
		public SupplierGoods Fill_By_SupplierGoodsUuid(string psupplier_goods_uuid,DB db){
			try{
				IList<SupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
				).FetchAll<SupplierGoods_Record>(db)  ;  
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
		public SupplierGoods_Record Fetch_By_SupplierGoodsUuid(string psupplier_goods_uuid){
			try{
				IList<SupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
				).FetchAll<SupplierGoods_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public SupplierGoods_Record Fetch_By_SupplierGoodsUuid(string psupplier_goods_uuid,DB db){
			try{
				IList<SupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
				).FetchAll<SupplierGoods_Record>(db)  ;  
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
				UpdateAllRecord<SupplierGoods_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<SupplierGoods_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<SupplierGoods_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<SupplierGoods_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<SupplierGoods_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<SupplierGoods_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<CustOrderDetail_Record> Link_CustOrderDetail_By_SupplierGoodsUuid()
		{
			try{
				List<CustOrderDetail_Record> ret= new List<CustOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderDetail ___table = new CustOrderDetail(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SUPPLIER_GOODS_UUID,item.SUPPLIER_GOODS_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrderDetail_Record>)
						___table.Where(condition)
						.FetchAll<CustOrderDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180320*/
		public List<MyOrderDetail_Record> Link_MyOrderDetail_By_SupplierGoodsUuid()
		{
			try{
				List<MyOrderDetail_Record> ret= new List<MyOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				MyOrderDetail ___table = new MyOrderDetail(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SUPPLIER_GOODS_UUID,item.SUPPLIER_GOODS_UUID).R().Or()  ; 
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
		public List<CustOrderDetail_Record> Link_CustOrderDetail_By_SupplierGoodsUuid(OrderLimit limit)
		{
			try{
				List<CustOrderDetail_Record> ret= new List<CustOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderDetail ___table = new CustOrderDetail(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SUPPLIER_GOODS_UUID,item.SUPPLIER_GOODS_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrderDetail_Record>)
						___table.Where(condition)
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
		/*201303180321*/
		public List<MyOrderDetail_Record> Link_MyOrderDetail_By_SupplierGoodsUuid(OrderLimit limit)
		{
			try{
				List<MyOrderDetail_Record> ret= new List<MyOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				MyOrderDetail ___table = new MyOrderDetail(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SUPPLIER_GOODS_UUID,item.SUPPLIER_GOODS_UUID).R().Or()  ; 
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
		public List<Unit_Record> Link_Unit_By_UnitUuid()
		{
			try{
				List<Unit_Record> ret= new List<Unit_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Unit ___table = new Unit(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UNIT_UUID,item.UNIT_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Unit_Record>)
						___table.Where(condition)
						.FetchAll<Unit_Record>() ; 
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
		public List<Unit_Record> Link_Unit_By_UnitUuid(OrderLimit limit)
		{
			try{
				List<Unit_Record> ret= new List<Unit_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Unit ___table = new Unit(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UNIT_UUID,item.UNIT_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Unit_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<Unit_Record>() ; 
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
		public CustOrderDetail LinkFill_CustOrderDetail_By_SupplierGoodsUuid()
		{
			try{
				var data = Link_CustOrderDetail_By_SupplierGoodsUuid();
				CustOrderDetail ret=new CustOrderDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public MyOrderDetail LinkFill_MyOrderDetail_By_SupplierGoodsUuid()
		{
			try{
				var data = Link_MyOrderDetail_By_SupplierGoodsUuid();
				MyOrderDetail ret=new MyOrderDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public CustOrderDetail LinkFill_CustOrderDetail_By_SupplierGoodsUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrderDetail_By_SupplierGoodsUuid(limit);
				CustOrderDetail ret=new CustOrderDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public MyOrderDetail LinkFill_MyOrderDetail_By_SupplierGoodsUuid(OrderLimit limit)
		{
			try{
				var data = Link_MyOrderDetail_By_SupplierGoodsUuid(limit);
				MyOrderDetail ret=new MyOrderDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public Unit LinkFill_Unit_By_UnitUuid()
		{
			try{
				var data = Link_Unit_By_UnitUuid();
				Unit ret=new Unit(data);
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
		public Unit LinkFill_Unit_By_UnitUuid(OrderLimit limit)
		{
			try{
				var data = Link_Unit_By_UnitUuid(limit);
				Unit ret=new Unit(data);
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
