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
	[TableView("V_SUPPLIER_GOODS", false)]
	public partial class VSupplierGoods : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VSupplierGoods_Record _currentRecord = null;
	private IList<VSupplierGoods_Record> _All_Record = new List<VSupplierGoods_Record>();
		/*建構子*/
		public VSupplierGoods(){}
		public VSupplierGoods(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VSupplierGoods(IDataBaseConfigInfo dbc): base(dbc){}
		public VSupplierGoods(IDataBaseConfigInfo dbc,VSupplierGoods_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VSupplierGoods(IList<VSupplierGoods_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string SUPPLIER_NAME {
			[ColumnName("SUPPLIER_NAME",false,typeof(string))]
			get{return "SUPPLIER_NAME" ; }}
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
		public string SUPPLIER_GOODS_PRICE {
			[ColumnName("SUPPLIER_GOODS_PRICE",false,typeof(decimal?))]
			get{return "SUPPLIER_GOODS_PRICE" ; }}
		public string SUPPLIER_GOODS_COST {
			[ColumnName("SUPPLIER_GOODS_COST",false,typeof(string))]
			get{return "SUPPLIER_GOODS_COST" ; }}
		public string SUPPLIER_GOODS_IS_ACTIVE {
			[ColumnName("SUPPLIER_GOODS_IS_ACTIVE",false,typeof(int?))]
			get{return "SUPPLIER_GOODS_IS_ACTIVE" ; }}
		public string SUPPLIER_UUID {
			[ColumnName("SUPPLIER_UUID",true,typeof(string))]
			get{return "SUPPLIER_UUID" ; }}
		public string UNIT_NAME {
			[ColumnName("UNIT_NAME",false,typeof(string))]
			get{return "UNIT_NAME" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VSupplierGoods_Record CurrentRecord(){
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
		public VSupplierGoods_Record CreateNew(){
			try{
				VSupplierGoods_Record newData = new VSupplierGoods_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VSupplierGoods_Record> AllRecord(){
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
				_All_Record = new List<VSupplierGoods_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public VSupplierGoods Fill_By_PK(string psupplier_goods_uuid,string psupplier_uuid){
			try{
				IList<VSupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
									.And()
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<VSupplierGoods_Record>()  ;  
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
		public VSupplierGoods Fill_By_PK(string psupplier_goods_uuid,string psupplier_uuid,DB db){
			try{
				IList<VSupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
									.And()
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<VSupplierGoods_Record>(db)  ;  
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
		public VSupplierGoods_Record Fetch_By_PK(string psupplier_goods_uuid,string psupplier_uuid){
			try{
				IList<VSupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<VSupplierGoods_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public VSupplierGoods_Record Fetch_By_PK(string psupplier_goods_uuid,string psupplier_uuid,DB db){
			try{
				IList<VSupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<VSupplierGoods_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public VSupplierGoods Fill_By_SupplierGoodsUuid_And_SupplierUuid(string psupplier_goods_uuid,string psupplier_uuid){
			try{
				IList<VSupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<VSupplierGoods_Record>()  ;  
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
		public VSupplierGoods Fill_By_SupplierGoodsUuid_And_SupplierUuid(string psupplier_goods_uuid,string psupplier_uuid,DB db){
			try{
				IList<VSupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<VSupplierGoods_Record>(db)  ;  
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
		public VSupplierGoods_Record Fetch_By_SupplierGoodsUuid_And_SupplierUuid(string psupplier_goods_uuid,string psupplier_uuid){
			try{
				IList<VSupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<VSupplierGoods_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public VSupplierGoods_Record Fetch_By_SupplierGoodsUuid_And_SupplierUuid(string psupplier_goods_uuid,string psupplier_uuid,DB db){
			try{
				IList<VSupplierGoods_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_GOODS_UUID,psupplier_goods_uuid)
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<VSupplierGoods_Record>(db)  ;  
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
