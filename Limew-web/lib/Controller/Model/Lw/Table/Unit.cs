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
	[TableView("UNIT", false)]
	public partial class Unit : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private Unit_Record _currentRecord = null;
	private IList<Unit_Record> _All_Record = new List<Unit_Record>();
		/*建構子*/
		public Unit(){}
		public Unit(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public Unit(IDataBaseConfigInfo dbc): base(dbc){}
		public Unit(IDataBaseConfigInfo dbc,Unit_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public Unit(IList<Unit_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UNIT_UUID {get{return "UNIT_UUID" ; }}
		public string UNIT_NAME {get{return "UNIT_NAME" ; }}
		public string UNIT_IS_ACTIVE {get{return "UNIT_IS_ACTIVE" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public Unit_Record CurrentRecord(){
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
		public Unit_Record CreateNew(){
			try{
				Unit_Record newData = new Unit_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<Unit_Record> AllRecord(){
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
				_All_Record = new List<Unit_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public Unit Fill_By_PK(string pUNIT_UUID){
			try{
				IList<Unit_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UNIT_UUID,pUNIT_UUID)
				).FetchAll<Unit_Record>()  ;  
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
		public Unit Fill_By_PK(string pUNIT_UUID,DB db){
			try{
				IList<Unit_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UNIT_UUID,pUNIT_UUID)
				).FetchAll<Unit_Record>(db)  ;  
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
		public Unit_Record Fetch_By_PK(string pUNIT_UUID){
			try{
				IList<Unit_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UNIT_UUID,pUNIT_UUID)
				).FetchAll<Unit_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public Unit_Record Fetch_By_PK(string pUNIT_UUID,DB db){
			try{
				IList<Unit_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UNIT_UUID,pUNIT_UUID)
				).FetchAll<Unit_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public Unit Fill_By_UnitUuid(string pUNIT_UUID){
			try{
				IList<Unit_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UNIT_UUID,pUNIT_UUID)
				).FetchAll<Unit_Record>()  ;  
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
		public Unit Fill_By_UnitUuid(string pUNIT_UUID,DB db){
			try{
				IList<Unit_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UNIT_UUID,pUNIT_UUID)
				).FetchAll<Unit_Record>(db)  ;  
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
		public Unit_Record Fetch_By_UnitUuid(string pUNIT_UUID){
			try{
				IList<Unit_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UNIT_UUID,pUNIT_UUID)
				).FetchAll<Unit_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public Unit_Record Fetch_By_UnitUuid(string pUNIT_UUID,DB db){
			try{
				IList<Unit_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UNIT_UUID,pUNIT_UUID)
				).FetchAll<Unit_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<SupplierGoods_Record> Link_SupplierGoods_By_UnitUuid()
		{
			try{
				List<SupplierGoods_Record> ret= new List<SupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				SupplierGoods ___table = new SupplierGoods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UNIT_UUID,item.UNIT_UUID).R().Or()  ; 
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
		/*201303180321*/
		public List<SupplierGoods_Record> Link_SupplierGoods_By_UnitUuid(OrderLimit limit)
		{
			try{
				List<SupplierGoods_Record> ret= new List<SupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				SupplierGoods ___table = new SupplierGoods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UNIT_UUID,item.UNIT_UUID).R().Or()  ; 
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
		/*201303180324*/
		public SupplierGoods LinkFill_SupplierGoods_By_UnitUuid()
		{
			try{
				var data = Link_SupplierGoods_By_UnitUuid();
				SupplierGoods ret=new SupplierGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public SupplierGoods LinkFill_SupplierGoods_By_UnitUuid(OrderLimit limit)
		{
			try{
				var data = Link_SupplierGoods_By_UnitUuid(limit);
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
