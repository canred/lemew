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
	[TableView("SUPPLIER_GOODS", false)]
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
		public string SUPPLIER_GOODS_UUID {get{return "SUPPLIER_GOODS_UUID" ; }}
		public string SUPPLIER_GOODS_NAME {get{return "SUPPLIER_GOODS_NAME" ; }}
		public string SUPPLIER_GOODS_UNIT {get{return "SUPPLIER_GOODS_UNIT" ; }}
		public string SUPPLIER_GOODS_SN {get{return "SUPPLIER_GOODS_SN" ; }}
		public string SUPPLIER_GOODS_SPEC {get{return "SUPPLIER_GOODS_SPEC" ; }}
		public string SUPPLIER_GOODS_PRICE {get{return "SUPPLIER_GOODS_PRICE" ; }}
		public string SUPPLIER_GOODS_COST {get{return "SUPPLIER_GOODS_COST" ; }}
		public string SUPPLIER_GOODS_IS_ACTIVE {get{return "SUPPLIER_GOODS_IS_ACTIVE" ; }}
		public string SUPPLIER_UUID {get{return "SUPPLIER_UUID" ; }}
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
		/*依照資料表與資料表的關係，產生出來的方法*/
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
