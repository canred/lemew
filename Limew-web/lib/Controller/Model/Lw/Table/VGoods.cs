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
	[TableView("V_GOODS", false)]
	public partial class VGoods : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VGoods_Record _currentRecord = null;
	private IList<VGoods_Record> _All_Record = new List<VGoods_Record>();
		/*建構子*/
		public VGoods(){}
		public VGoods(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VGoods(IDataBaseConfigInfo dbc): base(dbc){}
		public VGoods(IDataBaseConfigInfo dbc,VGoods_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VGoods(IList<VGoods_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string GOODS_UUID {get{return "GOODS_UUID" ; }}
		public string GOODS_SN {get{return "GOODS_SN" ; }}
		public string GOODS_COST {get{return "GOODS_COST" ; }}
		public string GOODS_SALE {get{return "GOODS_SALE" ; }}
		public string GOODS_PRICE {get{return "GOODS_PRICE" ; }}
		public string GOODS_FOCUS {get{return "GOODS_FOCUS" ; }}
		public string GOODS_IS_ACTIVE {get{return "GOODS_IS_ACTIVE" ; }}
		public string SUPPLIER_UUID {get{return "SUPPLIER_UUID" ; }}
		public string SUPPLIER_NAME {get{return "SUPPLIER_NAME" ; }}
		public string SUPPLIER_PS {get{return "SUPPLIER_PS" ; }}
		public string GCATEGORY_UUID {get{return "GCATEGORY_UUID" ; }}
		public string GCATEGORY_NAME {get{return "GCATEGORY_NAME" ; }}
		public string GCATEGORY_FULL_NAME {get{return "GCATEGORY_FULL_NAME" ; }}
		public string GOODS_NAME {get{return "GOODS_NAME" ; }}
		public string GOODS_PS {get{return "GOODS_PS" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VGoods_Record CurrentRecord(){
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
		public VGoods_Record CreateNew(){
			try{
				VGoods_Record newData = new VGoods_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VGoods_Record> AllRecord(){
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
				_All_Record = new List<VGoods_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public VGoods Fill_By_PK(string pgoods_uuid){
			try{
				IList<VGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<VGoods_Record>()  ;  
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
		public VGoods Fill_By_PK(string pgoods_uuid,DB db){
			try{
				IList<VGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<VGoods_Record>(db)  ;  
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
		public VGoods_Record Fetch_By_PK(string pgoods_uuid){
			try{
				IList<VGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<VGoods_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public VGoods_Record Fetch_By_PK(string pgoods_uuid,DB db){
			try{
				IList<VGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<VGoods_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public VGoods Fill_By_GoodsUuid(string pgoods_uuid){
			try{
				IList<VGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<VGoods_Record>()  ;  
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
		public VGoods Fill_By_GoodsUuid(string pgoods_uuid,DB db){
			try{
				IList<VGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<VGoods_Record>(db)  ;  
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
		public VGoods_Record Fetch_By_GoodsUuid(string pgoods_uuid){
			try{
				IList<VGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<VGoods_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public VGoods_Record Fetch_By_GoodsUuid(string pgoods_uuid,DB db){
			try{
				IList<VGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<VGoods_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		public List<Gcategory_Record> Link_Gcategory_By_GcategoryUuid()
		{
			try{
				List<Gcategory_Record> ret= new List<Gcategory_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Gcategory ___table = new Gcategory(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.GCATEGORY_UUID,item.GCATEGORY_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Gcategory_Record>)
						___table.Where(condition)
						.FetchAll<Gcategory_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
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
		public List<Gcategory_Record> Link_Gcategory_By_GcategoryUuid(OrderLimit limit)
		{
			try{
				List<Gcategory_Record> ret= new List<Gcategory_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Gcategory ___table = new Gcategory(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.GCATEGORY_UUID,item.GCATEGORY_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Gcategory_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<Gcategory_Record>() ; 
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
		/*201303180336*/
		public Gcategory LinkFill_Gcategory_By_GcategoryUuid()
		{
			try{
				var data = Link_Gcategory_By_GcategoryUuid();
				Gcategory ret=new Gcategory(data);
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
		public Gcategory LinkFill_Gcategory_By_GcategoryUuid(OrderLimit limit)
		{
			try{
				var data = Link_Gcategory_By_GcategoryUuid(limit);
				Gcategory ret=new Gcategory(data);
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
