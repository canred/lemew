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
		public string CUST_UUID {get{return "CUST_UUID" ; }}
		public string CUST_NAME {get{return "CUST_NAME" ; }}
		public string CUST_TEL {get{return "CUST_TEL" ; }}
		public string CUST_FAX {get{return "CUST_FAX" ; }}
		public string CUST_ADDRESS {get{return "CUST_ADDRESS" ; }}
		public string CUST_SALES_NAME {get{return "CUST_SALES_NAME" ; }}
		public string CUST_SALES_PHONE {get{return "CUST_SALES_PHONE" ; }}
		public string CUST_SALES_EMAIL {get{return "CUST_SALES_EMAIL" ; }}
		public string CUST_PS {get{return "CUST_PS" ; }}
		public string CUST_LEVEL {get{return "CUST_LEVEL" ; }}
		public string CUST_IS_ACTIVE {get{return "CUST_IS_ACTIVE" ; }}
		public string CUST_LAST_BUY {get{return "CUST_LAST_BUY" ; }}
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
		public List<CustOrder_Record> Link_CustOrder_By_CustUuid()
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_UUID,item.CUST_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrder_Record>)
						___table.Where(condition)
						.FetchAll<CustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<CustOrder_Record> Link_CustOrder_By_CustUuid(OrderLimit limit)
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.CUST_UUID,item.CUST_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<CustOrder_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<CustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public CustOrder LinkFill_CustOrder_By_CustUuid()
		{
			try{
				var data = Link_CustOrder_By_CustUuid();
				CustOrder ret=new CustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public CustOrder LinkFill_CustOrder_By_CustUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrder_By_CustUuid(limit);
				CustOrder ret=new CustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}