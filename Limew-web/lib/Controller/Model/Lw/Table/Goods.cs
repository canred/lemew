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
	[TableView("GOODS", false)]
	public partial class Goods : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private Goods_Record _currentRecord = null;
	private IList<Goods_Record> _All_Record = new List<Goods_Record>();
		/*建構子*/
		public Goods(){}
		public Goods(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public Goods(IDataBaseConfigInfo dbc): base(dbc){}
		public Goods(IDataBaseConfigInfo dbc,Goods_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public Goods(IList<Goods_Record> currenData){
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
		public string GCATEGORY_UUID {get{return "GCATEGORY_UUID" ; }}
		public string GOODS_NAME {get{return "GOODS_NAME" ; }}
		public string GOODS_PS {get{return "GOODS_PS" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public Goods_Record CurrentRecord(){
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
		public Goods_Record CreateNew(){
			try{
				Goods_Record newData = new Goods_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<Goods_Record> AllRecord(){
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
				_All_Record = new List<Goods_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public Goods Fill_By_PK(string pgoods_uuid){
			try{
				IList<Goods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<Goods_Record>()  ;  
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
		public Goods Fill_By_PK(string pgoods_uuid,DB db){
			try{
				IList<Goods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<Goods_Record>(db)  ;  
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
		public Goods_Record Fetch_By_PK(string pgoods_uuid){
			try{
				IList<Goods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<Goods_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public Goods_Record Fetch_By_PK(string pgoods_uuid,DB db){
			try{
				IList<Goods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<Goods_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public Goods Fill_By_GoodsUuid(string pgoods_uuid){
			try{
				IList<Goods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<Goods_Record>()  ;  
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
		public Goods Fill_By_GoodsUuid(string pgoods_uuid,DB db){
			try{
				IList<Goods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<Goods_Record>(db)  ;  
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
		public Goods_Record Fetch_By_GoodsUuid(string pgoods_uuid){
			try{
				IList<Goods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<Goods_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public Goods_Record Fetch_By_GoodsUuid(string pgoods_uuid,DB db){
			try{
				IList<Goods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GOODS_UUID,pgoods_uuid)
				).FetchAll<Goods_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<VGoods_Record> Link_VGoods_By_GoodsUuid()
		{
			try{
				List<VGoods_Record> ret= new List<VGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VGoods ___table = new VGoods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.GOODS_UUID,item.GOODS_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<VGoods_Record>)
						___table.Where(condition)
						.FetchAll<VGoods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<VGoods_Record> Link_VGoods_By_GoodsUuid(OrderLimit limit)
		{
			try{
				List<VGoods_Record> ret= new List<VGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VGoods ___table = new VGoods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.GOODS_UUID,item.GOODS_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<VGoods_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<VGoods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
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
		/*201303180324*/
		public VGoods LinkFill_VGoods_By_GoodsUuid()
		{
			try{
				var data = Link_VGoods_By_GoodsUuid();
				VGoods ret=new VGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public VGoods LinkFill_VGoods_By_GoodsUuid(OrderLimit limit)
		{
			try{
				var data = Link_VGoods_By_GoodsUuid(limit);
				VGoods ret=new VGoods(data);
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
	}
}
