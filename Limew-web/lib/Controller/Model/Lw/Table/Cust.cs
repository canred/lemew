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
	[TableView("CUST", false)]
	public partial class Cust : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private Cust_Record _currentRecord = null;
	private IList<Cust_Record> _All_Record = new List<Cust_Record>();
		/*建構子*/
		public Cust(){}
		public Cust(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public Cust(IDataBaseConfigInfo dbc): base(dbc){}
		public Cust(IDataBaseConfigInfo dbc,Cust_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public Cust(IList<Cust_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string CUST_UUID {
			[ColumnName("CUST_UUID",true,typeof(string))]
			get{return "CUST_UUID" ; }}
		public string CUST_NAME {
			[ColumnName("CUST_NAME",false,typeof(string))]
			get{return "CUST_NAME" ; }}
		public string CUST_TEL {
			[ColumnName("CUST_TEL",false,typeof(string))]
			get{return "CUST_TEL" ; }}
		public string CUST_FAX {
			[ColumnName("CUST_FAX",false,typeof(string))]
			get{return "CUST_FAX" ; }}
		public string CUST_ADDRESS {
			[ColumnName("CUST_ADDRESS",false,typeof(string))]
			get{return "CUST_ADDRESS" ; }}
		public string CUST_SALES_NAME {
			[ColumnName("CUST_SALES_NAME",false,typeof(string))]
			get{return "CUST_SALES_NAME" ; }}
		public string CUST_SALES_PHONE {
			[ColumnName("CUST_SALES_PHONE",false,typeof(string))]
			get{return "CUST_SALES_PHONE" ; }}
		public string CUST_SALES_EMAIL {
			[ColumnName("CUST_SALES_EMAIL",false,typeof(string))]
			get{return "CUST_SALES_EMAIL" ; }}
		public string CUST_PS {
			[ColumnName("CUST_PS",false,typeof(string))]
			get{return "CUST_PS" ; }}
		public string CUST_LEVEL {
			[ColumnName("CUST_LEVEL",false,typeof(int?))]
			get{return "CUST_LEVEL" ; }}
		public string CUST_IS_ACTIVE {
			[ColumnName("CUST_IS_ACTIVE",false,typeof(int?))]
			get{return "CUST_IS_ACTIVE" ; }}
		public string CUST_LAST_BUY {
			[ColumnName("CUST_LAST_BUY",false,typeof(DateTime?))]
			get{return "CUST_LAST_BUY" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public Cust_Record CurrentRecord(){
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
		public Cust_Record CreateNew(){
			try{
				Cust_Record newData = new Cust_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<Cust_Record> AllRecord(){
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
				_All_Record = new List<Cust_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public Cust Fill_By_PK(string pcust_uuid){
			try{
				IList<Cust_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
				).FetchAll<Cust_Record>()  ;  
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
		public Cust Fill_By_PK(string pcust_uuid,DB db){
			try{
				IList<Cust_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
				).FetchAll<Cust_Record>(db)  ;  
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
		public Cust_Record Fetch_By_PK(string pcust_uuid){
			try{
				IList<Cust_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
				).FetchAll<Cust_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public Cust_Record Fetch_By_PK(string pcust_uuid,DB db){
			try{
				IList<Cust_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
				).FetchAll<Cust_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public Cust Fill_By_CustUuid(string pcust_uuid){
			try{
				IList<Cust_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
				).FetchAll<Cust_Record>()  ;  
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
		public Cust Fill_By_CustUuid(string pcust_uuid,DB db){
			try{
				IList<Cust_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
				).FetchAll<Cust_Record>(db)  ;  
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
		public Cust_Record Fetch_By_CustUuid(string pcust_uuid){
			try{
				IList<Cust_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
				).FetchAll<Cust_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public Cust_Record Fetch_By_CustUuid(string pcust_uuid,DB db){
			try{
				IList<Cust_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
				).FetchAll<Cust_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<CustOrg_Record> Link_CustOrg_By_CustUuid()
		{
			try{
				List<CustOrg_Record> ret= new List<CustOrg_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrg ___table = new CustOrg(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_UUID,item.CUST_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrg_Record>)
						___table.Where(condition)
						.FetchAll<CustOrg_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180320*/
		public List<VCustOrder_Record> Link_VCustOrder_By_CustUuid()
		{
			try{
				List<VCustOrder_Record> ret= new List<VCustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VCustOrder ___table = new VCustOrder(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_UUID,item.CUST_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<VCustOrder_Record>)
						___table.Where(condition)
						.FetchAll<VCustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<CustOrg_Record> Link_CustOrg_By_CustUuid(OrderLimit limit)
		{
			try{
				List<CustOrg_Record> ret= new List<CustOrg_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrg ___table = new CustOrg(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_UUID,item.CUST_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrg_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<CustOrg_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<VCustOrder_Record> Link_VCustOrder_By_CustUuid(OrderLimit limit)
		{
			try{
				List<VCustOrder_Record> ret= new List<VCustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VCustOrder ___table = new VCustOrder(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_UUID,item.CUST_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<VCustOrder_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<VCustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public CustOrg LinkFill_CustOrg_By_CustUuid()
		{
			try{
				var data = Link_CustOrg_By_CustUuid();
				CustOrg ret=new CustOrg(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public VCustOrder LinkFill_VCustOrder_By_CustUuid()
		{
			try{
				var data = Link_VCustOrder_By_CustUuid();
				VCustOrder ret=new VCustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public CustOrg LinkFill_CustOrg_By_CustUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrg_By_CustUuid(limit);
				CustOrg ret=new CustOrg(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public VCustOrder LinkFill_VCustOrder_By_CustUuid(OrderLimit limit)
		{
			try{
				var data = Link_VCustOrder_By_CustUuid(limit);
				VCustOrder ret=new VCustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
