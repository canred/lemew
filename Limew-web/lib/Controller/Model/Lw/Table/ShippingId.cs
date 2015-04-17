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
	[TableView("SHIPPING_ID", false)]
	public partial class ShippingId : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private ShippingId_Record _currentRecord = null;
	private IList<ShippingId_Record> _All_Record = new List<ShippingId_Record>();
		/*建構子*/
		public ShippingId(){}
		public ShippingId(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public ShippingId(IDataBaseConfigInfo dbc): base(dbc){}
		public ShippingId(IDataBaseConfigInfo dbc,ShippingId_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public ShippingId(IList<ShippingId_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string SHIPPING_ID_UUID {get{return "SHIPPING_ID_UUID" ; }}
		public string MAX {get{return "MAX" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public ShippingId_Record CurrentRecord(){
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
		public ShippingId_Record CreateNew(){
			try{
				ShippingId_Record newData = new ShippingId_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<ShippingId_Record> AllRecord(){
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
				_All_Record = new List<ShippingId_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public ShippingId Fill_By_PK(string pshipping_id_uuid){
			try{
				IList<ShippingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_ID_UUID,pshipping_id_uuid)
				).FetchAll<ShippingId_Record>()  ;  
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
		public ShippingId Fill_By_PK(string pshipping_id_uuid,DB db){
			try{
				IList<ShippingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_ID_UUID,pshipping_id_uuid)
				).FetchAll<ShippingId_Record>(db)  ;  
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
		public ShippingId_Record Fetch_By_PK(string pshipping_id_uuid){
			try{
				IList<ShippingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_ID_UUID,pshipping_id_uuid)
				).FetchAll<ShippingId_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public ShippingId_Record Fetch_By_PK(string pshipping_id_uuid,DB db){
			try{
				IList<ShippingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_ID_UUID,pshipping_id_uuid)
				).FetchAll<ShippingId_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public ShippingId Fill_By_ShippingIdUuid(string pshipping_id_uuid){
			try{
				IList<ShippingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_ID_UUID,pshipping_id_uuid)
				).FetchAll<ShippingId_Record>()  ;  
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
		public ShippingId Fill_By_ShippingIdUuid(string pshipping_id_uuid,DB db){
			try{
				IList<ShippingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_ID_UUID,pshipping_id_uuid)
				).FetchAll<ShippingId_Record>(db)  ;  
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
		public ShippingId_Record Fetch_By_ShippingIdUuid(string pshipping_id_uuid){
			try{
				IList<ShippingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_ID_UUID,pshipping_id_uuid)
				).FetchAll<ShippingId_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public ShippingId_Record Fetch_By_ShippingIdUuid(string pshipping_id_uuid,DB db){
			try{
				IList<ShippingId_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.SHIPPING_ID_UUID,pshipping_id_uuid)
				).FetchAll<ShippingId_Record>(db)  ;  
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
