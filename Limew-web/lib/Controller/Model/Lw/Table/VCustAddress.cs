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
	[TableView("V_CUST_ADDRESS", false)]
	public partial class VCustAddress : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VCustAddress_Record _currentRecord = null;
	private IList<VCustAddress_Record> _All_Record = new List<VCustAddress_Record>();
		/*建構子*/
		public VCustAddress(){}
		public VCustAddress(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VCustAddress(IDataBaseConfigInfo dbc): base(dbc){}
		public VCustAddress(IDataBaseConfigInfo dbc,VCustAddress_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VCustAddress(IList<VCustAddress_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string CUST_ADDRESS {get{return "CUST_ADDRESS" ; }}
		public string CUST_ORG_ADDRESS {get{return "CUST_ORG_ADDRESS" ; }}
		public string CUST_UUID {get{return "CUST_UUID" ; }}
		public string CUST_ORG_UUID {get{return "CUST_ORG_UUID" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VCustAddress_Record CurrentRecord(){
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
		public VCustAddress_Record CreateNew(){
			try{
				VCustAddress_Record newData = new VCustAddress_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VCustAddress_Record> AllRecord(){
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
				_All_Record = new List<VCustAddress_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public VCustAddress Fill_By_PK(string pcust_uuid,string pcust_org_uuid){
			try{
				IList<VCustAddress_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.And()
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<VCustAddress_Record>()  ;  
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
		public VCustAddress Fill_By_PK(string pcust_uuid,string pcust_org_uuid,DB db){
			try{
				IList<VCustAddress_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.And()
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<VCustAddress_Record>(db)  ;  
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
		public VCustAddress_Record Fetch_By_PK(string pcust_uuid,string pcust_org_uuid){
			try{
				IList<VCustAddress_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<VCustAddress_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public VCustAddress_Record Fetch_By_PK(string pcust_uuid,string pcust_org_uuid,DB db){
			try{
				IList<VCustAddress_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<VCustAddress_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public VCustAddress Fill_By_CustUuid_And_CustOrgUuid(string pcust_uuid,string pcust_org_uuid){
			try{
				IList<VCustAddress_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<VCustAddress_Record>()  ;  
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
		public VCustAddress Fill_By_CustUuid_And_CustOrgUuid(string pcust_uuid,string pcust_org_uuid,DB db){
			try{
				IList<VCustAddress_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<VCustAddress_Record>(db)  ;  
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
		public VCustAddress_Record Fetch_By_CustUuid_And_CustOrgUuid(string pcust_uuid,string pcust_org_uuid){
			try{
				IList<VCustAddress_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<VCustAddress_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public VCustAddress_Record Fetch_By_CustUuid_And_CustOrgUuid(string pcust_uuid,string pcust_org_uuid,DB db){
			try{
				IList<VCustAddress_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_UUID,pcust_uuid)
									.Equal(this.CUST_ORG_UUID,pcust_org_uuid)
				).FetchAll<VCustAddress_Record>(db)  ;  
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
