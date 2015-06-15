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
	[TableView("CUST_ORG_V", false)]
	public partial class CustOrgV : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private CustOrgV_Record _currentRecord = null;
	private IList<CustOrgV_Record> _All_Record = new List<CustOrgV_Record>();
		/*建構子*/
		public CustOrgV(){}
		public CustOrgV(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public CustOrgV(IDataBaseConfigInfo dbc): base(dbc){}
		public CustOrgV(IDataBaseConfigInfo dbc,CustOrgV_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public CustOrgV(IList<CustOrgV_Record> currenData){
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
		public string CUST_UNIFORM_NUM {
			[ColumnName("CUST_UNIFORM_NUM",false,typeof(string))]
			get{return "CUST_UNIFORM_NUM" ; }}
		public string CUST_ORG_ADDRESS {
			[ColumnName("CUST_ORG_ADDRESS",false,typeof(string))]
			get{return "CUST_ORG_ADDRESS" ; }}
		public string CUST_ORG_IS_ACTIVE {
			[ColumnName("CUST_ORG_IS_ACTIVE",false,typeof(int?))]
			get{return "CUST_ORG_IS_ACTIVE" ; }}
		public string CUST_ORG_IS_DEFAULT {
			[ColumnName("CUST_ORG_IS_DEFAULT",false,typeof(int?))]
			get{return "CUST_ORG_IS_DEFAULT" ; }}
		public string CUST_ORG_NAME {
			[ColumnName("CUST_ORG_NAME",false,typeof(string))]
			get{return "CUST_ORG_NAME" ; }}
		public string CUST_ORG_PS {
			[ColumnName("CUST_ORG_PS",false,typeof(string))]
			get{return "CUST_ORG_PS" ; }}
		public string CUST_ORG_SALES_EMAIL {
			[ColumnName("CUST_ORG_SALES_EMAIL",false,typeof(string))]
			get{return "CUST_ORG_SALES_EMAIL" ; }}
		public string CUST_ORG_SALES_NAME {
			[ColumnName("CUST_ORG_SALES_NAME",false,typeof(string))]
			get{return "CUST_ORG_SALES_NAME" ; }}
		public string CUST_ORG_SALES_PHONE {
			[ColumnName("CUST_ORG_SALES_PHONE",false,typeof(string))]
			get{return "CUST_ORG_SALES_PHONE" ; }}
		public string CUST_ORG_UUID {
			[ColumnName("CUST_ORG_UUID",true,typeof(string))]
			get{return "CUST_ORG_UUID" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public CustOrgV_Record CurrentRecord(){
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
		public CustOrgV_Record CreateNew(){
			try{
				CustOrgV_Record newData = new CustOrgV_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<CustOrgV_Record> AllRecord(){
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
				_All_Record = new List<CustOrgV_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public CustOrgV Fill_By_PK(string pcust_uuid,string pcust_org_uuid){
			try{
				IList<CustOrgV_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.And()
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<CustOrgV_Record>()  ;  
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
		public CustOrgV Fill_By_PK(string pcust_uuid,string pcust_org_uuid,DB db){
			try{
				IList<CustOrgV_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.And()
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<CustOrgV_Record>(db)  ;  
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
		public CustOrgV_Record Fetch_By_PK(string pcust_uuid,string pcust_org_uuid){
			try{
				IList<CustOrgV_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<CustOrgV_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public CustOrgV_Record Fetch_By_PK(string pcust_uuid,string pcust_org_uuid,DB db){
			try{
				IList<CustOrgV_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<CustOrgV_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public CustOrgV Fill_By_CustUuid_And_CustOrgUuid(string pcust_uuid,string pcust_org_uuid){
			try{
				IList<CustOrgV_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<CustOrgV_Record>()  ;  
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
		public CustOrgV Fill_By_CustUuid_And_CustOrgUuid(string pcust_uuid,string pcust_org_uuid,DB db){
			try{
				IList<CustOrgV_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<CustOrgV_Record>(db)  ;  
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
		public CustOrgV_Record Fetch_By_CustUuid_And_CustOrgUuid(string pcust_uuid,string pcust_org_uuid){
			try{
				IList<CustOrgV_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<CustOrgV_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public CustOrgV_Record Fetch_By_CustUuid_And_CustOrgUuid(string pcust_uuid,string pcust_org_uuid,DB db){
			try{
				IList<CustOrgV_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<CustOrgV_Record>(db)  ;  
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
