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
	[TableView("PAY_STATUS", false)]
	public partial class PayStatus : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private PayStatus_Record _currentRecord = null;
	private IList<PayStatus_Record> _All_Record = new List<PayStatus_Record>();
		/*建構子*/
		public PayStatus(){}
		public PayStatus(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public PayStatus(IDataBaseConfigInfo dbc): base(dbc){}
		public PayStatus(IDataBaseConfigInfo dbc,PayStatus_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public PayStatus(IList<PayStatus_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string PAY_STATUS_UUID {
			[ColumnName("PAY_STATUS_UUID",true,typeof(string))]
			get{return "PAY_STATUS_UUID" ; }}
		public string PAY_STATUS_NAME {
			[ColumnName("PAY_STATUS_NAME",false,typeof(string))]
			get{return "PAY_STATUS_NAME" ; }}
		public string PAY_STATUS_ORD {
			[ColumnName("PAY_STATUS_ORD",false,typeof(short?))]
			get{return "PAY_STATUS_ORD" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public PayStatus_Record CurrentRecord(){
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
		public PayStatus_Record CreateNew(){
			try{
				PayStatus_Record newData = new PayStatus_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<PayStatus_Record> AllRecord(){
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
				_All_Record = new List<PayStatus_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public PayStatus Fill_By_PK(string ppay_status_uuid){
			try{
				IList<PayStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_STATUS_UUID,ppay_status_uuid)
				).FetchAll<PayStatus_Record>()  ;  
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
		public PayStatus Fill_By_PK(string ppay_status_uuid,DB db){
			try{
				IList<PayStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_STATUS_UUID,ppay_status_uuid)
				).FetchAll<PayStatus_Record>(db)  ;  
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
		public PayStatus_Record Fetch_By_PK(string ppay_status_uuid){
			try{
				IList<PayStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_STATUS_UUID,ppay_status_uuid)
				).FetchAll<PayStatus_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public PayStatus_Record Fetch_By_PK(string ppay_status_uuid,DB db){
			try{
				IList<PayStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_STATUS_UUID,ppay_status_uuid)
				).FetchAll<PayStatus_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public PayStatus Fill_By_PayStatusUuid(string ppay_status_uuid){
			try{
				IList<PayStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_STATUS_UUID,ppay_status_uuid)
				).FetchAll<PayStatus_Record>()  ;  
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
		public PayStatus Fill_By_PayStatusUuid(string ppay_status_uuid,DB db){
			try{
				IList<PayStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_STATUS_UUID,ppay_status_uuid)
				).FetchAll<PayStatus_Record>(db)  ;  
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
		public PayStatus_Record Fetch_By_PayStatusUuid(string ppay_status_uuid){
			try{
				IList<PayStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_STATUS_UUID,ppay_status_uuid)
				).FetchAll<PayStatus_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public PayStatus_Record Fetch_By_PayStatusUuid(string ppay_status_uuid,DB db){
			try{
				IList<PayStatus_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PAY_STATUS_UUID,ppay_status_uuid)
				).FetchAll<PayStatus_Record>(db)  ;  
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
