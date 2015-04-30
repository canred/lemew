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
	[TableView("GCATEGORY", false)]
	public partial class Gcategory : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private Gcategory_Record _currentRecord = null;
	private IList<Gcategory_Record> _All_Record = new List<Gcategory_Record>();
		/*建構子*/
		public Gcategory(){}
		public Gcategory(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public Gcategory(IDataBaseConfigInfo dbc): base(dbc){}
		public Gcategory(IDataBaseConfigInfo dbc,Gcategory_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public Gcategory(IList<Gcategory_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string GCATEGORY_UUID {
			[ColumnName("GCATEGORY_UUID",true,typeof(string))]
			get{return "GCATEGORY_UUID" ; }}
		public string GCATEGORY_NAME {
			[ColumnName("GCATEGORY_NAME",false,typeof(string))]
			get{return "GCATEGORY_NAME" ; }}
		public string GCATEGORY_FULL_NAME {
			[ColumnName("GCATEGORY_FULL_NAME",false,typeof(string))]
			get{return "GCATEGORY_FULL_NAME" ; }}
		public string GCATEGORY_FULL_UUID {
			[ColumnName("GCATEGORY_FULL_UUID",false,typeof(string))]
			get{return "GCATEGORY_FULL_UUID" ; }}
		public string GCATEGORY_IS_ACTIVE {
			[ColumnName("GCATEGORY_IS_ACTIVE",false,typeof(string))]
			get{return "GCATEGORY_IS_ACTIVE" ; }}
		public string GCATEGORY_PARENT_UUID {
			[ColumnName("GCATEGORY_PARENT_UUID",false,typeof(string))]
			get{return "GCATEGORY_PARENT_UUID" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public Gcategory_Record CurrentRecord(){
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
		public Gcategory_Record CreateNew(){
			try{
				Gcategory_Record newData = new Gcategory_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<Gcategory_Record> AllRecord(){
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
				_All_Record = new List<Gcategory_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public Gcategory Fill_By_PK(string pgcategory_uuid){
			try{
				IList<Gcategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GCATEGORY_UUID,pgcategory_uuid)
				).FetchAll<Gcategory_Record>()  ;  
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
		public Gcategory Fill_By_PK(string pgcategory_uuid,DB db){
			try{
				IList<Gcategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GCATEGORY_UUID,pgcategory_uuid)
				).FetchAll<Gcategory_Record>(db)  ;  
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
		public Gcategory_Record Fetch_By_PK(string pgcategory_uuid){
			try{
				IList<Gcategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GCATEGORY_UUID,pgcategory_uuid)
				).FetchAll<Gcategory_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public Gcategory_Record Fetch_By_PK(string pgcategory_uuid,DB db){
			try{
				IList<Gcategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GCATEGORY_UUID,pgcategory_uuid)
				).FetchAll<Gcategory_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public Gcategory Fill_By_GcategoryUuid(string pgcategory_uuid){
			try{
				IList<Gcategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GCATEGORY_UUID,pgcategory_uuid)
				).FetchAll<Gcategory_Record>()  ;  
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
		public Gcategory Fill_By_GcategoryUuid(string pgcategory_uuid,DB db){
			try{
				IList<Gcategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GCATEGORY_UUID,pgcategory_uuid)
				).FetchAll<Gcategory_Record>(db)  ;  
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
		public Gcategory_Record Fetch_By_GcategoryUuid(string pgcategory_uuid){
			try{
				IList<Gcategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GCATEGORY_UUID,pgcategory_uuid)
				).FetchAll<Gcategory_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public Gcategory_Record Fetch_By_GcategoryUuid(string pgcategory_uuid,DB db){
			try{
				IList<Gcategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GCATEGORY_UUID,pgcategory_uuid)
				).FetchAll<Gcategory_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<Goods_Record> Link_Goods_By_GcategoryUuid()
		{
			try{
				List<Goods_Record> ret= new List<Goods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Goods ___table = new Goods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.GCATEGORY_UUID,item.GCATEGORY_UUID).R().Or()  ; 
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
		/*201303180320*/
		public List<VGoods_Record> Link_VGoods_By_GcategoryUuid()
		{
			try{
				List<VGoods_Record> ret= new List<VGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VGoods ___table = new VGoods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.GCATEGORY_UUID,item.GCATEGORY_UUID).R().Or()  ; 
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
		public List<Goods_Record> Link_Goods_By_GcategoryUuid(OrderLimit limit)
		{
			try{
				List<Goods_Record> ret= new List<Goods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Goods ___table = new Goods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.GCATEGORY_UUID,item.GCATEGORY_UUID).R().Or()  ; 
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
		/*201303180321*/
		public List<VGoods_Record> Link_VGoods_By_GcategoryUuid(OrderLimit limit)
		{
			try{
				List<VGoods_Record> ret= new List<VGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VGoods ___table = new VGoods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.GCATEGORY_UUID,item.GCATEGORY_UUID).R().Or()  ; 
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
		/*201303180324*/
		public Goods LinkFill_Goods_By_GcategoryUuid()
		{
			try{
				var data = Link_Goods_By_GcategoryUuid();
				Goods ret=new Goods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public VGoods LinkFill_VGoods_By_GcategoryUuid()
		{
			try{
				var data = Link_VGoods_By_GcategoryUuid();
				VGoods ret=new VGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public Goods LinkFill_Goods_By_GcategoryUuid(OrderLimit limit)
		{
			try{
				var data = Link_Goods_By_GcategoryUuid(limit);
				Goods ret=new Goods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public VGoods LinkFill_VGoods_By_GcategoryUuid(OrderLimit limit)
		{
			try{
				var data = Link_VGoods_By_GcategoryUuid(limit);
				VGoods ret=new VGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
