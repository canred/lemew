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
	[TableView("SUPPLIER", false)]
	public partial class Supplier : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private Supplier_Record _currentRecord = null;
	private IList<Supplier_Record> _All_Record = new List<Supplier_Record>();
		/*建構子*/
		public Supplier(){}
		public Supplier(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public Supplier(IDataBaseConfigInfo dbc): base(dbc){}
		public Supplier(IDataBaseConfigInfo dbc,Supplier_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public Supplier(IList<Supplier_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string SUPPLIER_UUID {
			[ColumnName("SUPPLIER_UUID",true,typeof(string))]
			get{return "SUPPLIER_UUID" ; }}
		public string SUPPLIER_NAME {
			[ColumnName("SUPPLIER_NAME",false,typeof(string))]
			get{return "SUPPLIER_NAME" ; }}
		public string SUPPLIER_TEL {
			[ColumnName("SUPPLIER_TEL",false,typeof(string))]
			get{return "SUPPLIER_TEL" ; }}
		public string SUPPLIER_FAX {
			[ColumnName("SUPPLIER_FAX",false,typeof(string))]
			get{return "SUPPLIER_FAX" ; }}
		public string SUPPLIER_ADDRESS {
			[ColumnName("SUPPLIER_ADDRESS",false,typeof(string))]
			get{return "SUPPLIER_ADDRESS" ; }}
		public string SUPPLIER_CONTACT_NAME {
			[ColumnName("SUPPLIER_CONTACT_NAME",false,typeof(string))]
			get{return "SUPPLIER_CONTACT_NAME" ; }}
		public string SUPPLIER_SALES_NAME {
			[ColumnName("SUPPLIER_SALES_NAME",false,typeof(string))]
			get{return "SUPPLIER_SALES_NAME" ; }}
		public string SUPPLIER_SALES_PHONE {
			[ColumnName("SUPPLIER_SALES_PHONE",false,typeof(string))]
			get{return "SUPPLIER_SALES_PHONE" ; }}
		public string SUPPLIER_CONTACT_PHONE {
			[ColumnName("SUPPLIER_CONTACT_PHONE",false,typeof(string))]
			get{return "SUPPLIER_CONTACT_PHONE" ; }}
		public string SUPPLIER_CONTACT_EMAIL {
			[ColumnName("SUPPLIER_CONTACT_EMAIL",false,typeof(string))]
			get{return "SUPPLIER_CONTACT_EMAIL" ; }}
		public string SUPPLIER_SALES_EMAIL {
			[ColumnName("SUPPLIER_SALES_EMAIL",false,typeof(string))]
			get{return "SUPPLIER_SALES_EMAIL" ; }}
		public string SUPPLIER_PS {
			[ColumnName("SUPPLIER_PS",false,typeof(string))]
			get{return "SUPPLIER_PS" ; }}
		public string SUPPLIER_IS_ACTIVE {
			[ColumnName("SUPPLIER_IS_ACTIVE",false,typeof(int?))]
			get{return "SUPPLIER_IS_ACTIVE" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public Supplier_Record CurrentRecord(){
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
		public Supplier_Record CreateNew(){
			try{
				Supplier_Record newData = new Supplier_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<Supplier_Record> AllRecord(){
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
				_All_Record = new List<Supplier_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public Supplier Fill_By_PK(string psupplier_uuid){
			try{
				IList<Supplier_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<Supplier_Record>()  ;  
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
		public Supplier Fill_By_PK(string psupplier_uuid,DB db){
			try{
				IList<Supplier_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<Supplier_Record>(db)  ;  
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
		public Supplier_Record Fetch_By_PK(string psupplier_uuid){
			try{
				IList<Supplier_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<Supplier_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public Supplier_Record Fetch_By_PK(string psupplier_uuid,DB db){
			try{
				IList<Supplier_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<Supplier_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public Supplier Fill_By_SupplierUuid(string psupplier_uuid){
			try{
				IList<Supplier_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<Supplier_Record>()  ;  
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
		public Supplier Fill_By_SupplierUuid(string psupplier_uuid,DB db){
			try{
				IList<Supplier_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<Supplier_Record>(db)  ;  
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
		public Supplier_Record Fetch_By_SupplierUuid(string psupplier_uuid){
			try{
				IList<Supplier_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<Supplier_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public Supplier_Record Fetch_By_SupplierUuid(string psupplier_uuid,DB db){
			try{
				IList<Supplier_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SUPPLIER_UUID,psupplier_uuid)
				).FetchAll<Supplier_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<SupplierGoods_Record> Link_SupplierGoods_By_SupplierUuid()
		{
			try{
				List<SupplierGoods_Record> ret= new List<SupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				SupplierGoods ___table = new SupplierGoods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SUPPLIER_UUID,item.SUPPLIER_UUID).R().Or()  ; 
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
		/*201303180320*/
		public List<VGoods_Record> Link_VGoods_By_SupplierUuid()
		{
			try{
				List<VGoods_Record> ret= new List<VGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VGoods ___table = new VGoods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SUPPLIER_UUID,item.SUPPLIER_UUID).R().Or()  ; 
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
		/*201303180320*/
		public List<VSupplierGoods_Record> Link_VSupplierGoods_By_SupplierUuid()
		{
			try{
				List<VSupplierGoods_Record> ret= new List<VSupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VSupplierGoods ___table = new VSupplierGoods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SUPPLIER_UUID,item.SUPPLIER_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<VSupplierGoods_Record>)
						___table.Where(condition)
						.FetchAll<VSupplierGoods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<SupplierGoods_Record> Link_SupplierGoods_By_SupplierUuid(OrderLimit limit)
		{
			try{
				List<SupplierGoods_Record> ret= new List<SupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				SupplierGoods ___table = new SupplierGoods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SUPPLIER_UUID,item.SUPPLIER_UUID).R().Or()  ; 
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
		/*201303180321*/
		public List<VGoods_Record> Link_VGoods_By_SupplierUuid(OrderLimit limit)
		{
			try{
				List<VGoods_Record> ret= new List<VGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VGoods ___table = new VGoods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SUPPLIER_UUID,item.SUPPLIER_UUID).R().Or()  ; 
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
		/*201303180321*/
		public List<VSupplierGoods_Record> Link_VSupplierGoods_By_SupplierUuid(OrderLimit limit)
		{
			try{
				List<VSupplierGoods_Record> ret= new List<VSupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VSupplierGoods ___table = new VSupplierGoods(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.SUPPLIER_UUID,item.SUPPLIER_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<VSupplierGoods_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<VSupplierGoods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public SupplierGoods LinkFill_SupplierGoods_By_SupplierUuid()
		{
			try{
				var data = Link_SupplierGoods_By_SupplierUuid();
				SupplierGoods ret=new SupplierGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public VGoods LinkFill_VGoods_By_SupplierUuid()
		{
			try{
				var data = Link_VGoods_By_SupplierUuid();
				VGoods ret=new VGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public VSupplierGoods LinkFill_VSupplierGoods_By_SupplierUuid()
		{
			try{
				var data = Link_VSupplierGoods_By_SupplierUuid();
				VSupplierGoods ret=new VSupplierGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public SupplierGoods LinkFill_SupplierGoods_By_SupplierUuid(OrderLimit limit)
		{
			try{
				var data = Link_SupplierGoods_By_SupplierUuid(limit);
				SupplierGoods ret=new SupplierGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public VGoods LinkFill_VGoods_By_SupplierUuid(OrderLimit limit)
		{
			try{
				var data = Link_VGoods_By_SupplierUuid(limit);
				VGoods ret=new VGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public VSupplierGoods LinkFill_VSupplierGoods_By_SupplierUuid(OrderLimit limit)
		{
			try{
				var data = Link_VSupplierGoods_By_SupplierUuid(limit);
				VSupplierGoods ret=new VSupplierGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
