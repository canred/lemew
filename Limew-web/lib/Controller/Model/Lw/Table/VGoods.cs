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
		public string GOODS_NAME {
			[ColumnName("GOODS_NAME",false,typeof(string))]
			get{return "GOODS_NAME" ; }}
		public string GOODS_UUID {
			[ColumnName("GOODS_UUID",true,typeof(string))]
			get{return "GOODS_UUID" ; }}
		public string GOODS_SN {
			[ColumnName("GOODS_SN",false,typeof(string))]
			get{return "GOODS_SN" ; }}
		public string GOODS_COST {
			[ColumnName("GOODS_COST",false,typeof(decimal?))]
			get{return "GOODS_COST" ; }}
		public string GOODS_SALE {
			[ColumnName("GOODS_SALE",false,typeof(decimal?))]
			get{return "GOODS_SALE" ; }}
		public string GOODS_PRICE {
			[ColumnName("GOODS_PRICE",false,typeof(decimal?))]
			get{return "GOODS_PRICE" ; }}
		public string GOODS_FOCUS {
			[ColumnName("GOODS_FOCUS",false,typeof(int?))]
			get{return "GOODS_FOCUS" ; }}
		public string GOODS_IS_ACTIVE {
			[ColumnName("GOODS_IS_ACTIVE",false,typeof(int?))]
			get{return "GOODS_IS_ACTIVE" ; }}
		public string SUPPLIER_UUID {
			[ColumnName("SUPPLIER_UUID",false,typeof(string))]
			get{return "SUPPLIER_UUID" ; }}
		public string SUPPLIER_NAME {
			[ColumnName("SUPPLIER_NAME",false,typeof(string))]
			get{return "SUPPLIER_NAME" ; }}
		public string SUPPLIER_PS {
			[ColumnName("SUPPLIER_PS",false,typeof(string))]
			get{return "SUPPLIER_PS" ; }}
		public string GCATEGORY_UUID {
			[ColumnName("GCATEGORY_UUID",false,typeof(string))]
			get{return "GCATEGORY_UUID" ; }}
		public string GCATEGORY_NAME {
			[ColumnName("GCATEGORY_NAME",false,typeof(string))]
			get{return "GCATEGORY_NAME" ; }}
		public string GCATEGORY_FULL_NAME {
			[ColumnName("GCATEGORY_FULL_NAME",false,typeof(string))]
			get{return "GCATEGORY_FULL_NAME" ; }}
		public string GOODS_PS {
			[ColumnName("GOODS_PS",false,typeof(string))]
			get{return "GOODS_PS" ; }}
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
	}
}
