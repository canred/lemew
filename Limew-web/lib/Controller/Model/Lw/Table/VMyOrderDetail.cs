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
	[TableView("V_MY_ORDER_DETAIL", false)]
	public partial class VMyOrderDetail : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VMyOrderDetail_Record _currentRecord = null;
	private IList<VMyOrderDetail_Record> _All_Record = new List<VMyOrderDetail_Record>();
		/*建構子*/
		public VMyOrderDetail(){}
		public VMyOrderDetail(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VMyOrderDetail(IDataBaseConfigInfo dbc): base(dbc){}
		public VMyOrderDetail(IDataBaseConfigInfo dbc,VMyOrderDetail_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VMyOrderDetail(IList<VMyOrderDetail_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string MY_ORDER_UUID {get{return "MY_ORDER_UUID" ; }}
		public string SUPPLIER_UUID {get{return "SUPPLIER_UUID" ; }}
		public string MY_ORDER_SUPPLIER_NAME {get{return "MY_ORDER_SUPPLIER_NAME" ; }}
		public string MY_ORDER_SUPPLIER_TEL {get{return "MY_ORDER_SUPPLIER_TEL" ; }}
		public string MY_ORDER_SUPPLIER_FAX {get{return "MY_ORDER_SUPPLIER_FAX" ; }}
		public string MY_ORDER_SUPPLIER_ADDRESS {get{return "MY_ORDER_SUPPLIER_ADDRESS" ; }}
		public string MY_ORDER_CONTACT_NAME {get{return "MY_ORDER_CONTACT_NAME" ; }}
		public string MY_ORDER_CONTACT_PHONE {get{return "MY_ORDER_CONTACT_PHONE" ; }}
		public string MY_ORDER_CONTACT_EMAIL {get{return "MY_ORDER_CONTACT_EMAIL" ; }}
		public string MY_ORDER_PS {get{return "MY_ORDER_PS" ; }}
		public string MY_ORDER_CR {get{return "MY_ORDER_CR" ; }}
		public string MY_ORDER_TOTAL_PRICE {get{return "MY_ORDER_TOTAL_PRICE" ; }}
		public string MY_ORDER_DETAIL_UUID {get{return "MY_ORDER_DETAIL_UUID" ; }}
		public string MY_ORDER_DETAIL_ATTENDANT_UUID {get{return "MY_ORDER_DETAIL_ATTENDANT_UUID" ; }}
		public string MY_ORDER_DETAIL_GOODS_COUNT {get{return "MY_ORDER_DETAIL_GOODS_COUNT" ; }}
		public string MY_ORDER_DETAIL_GOODS_NAME {get{return "MY_ORDER_DETAIL_GOODS_NAME" ; }}
		public string MY_ORDER_DETAIL_PRICE {get{return "MY_ORDER_DETAIL_PRICE" ; }}
		public string MY_ORDER_DETAIL_TOTAL_PRICE {get{return "MY_ORDER_DETAIL_TOTAL_PRICE" ; }}
		public string SUPPLIER_GOODS_UUID {get{return "SUPPLIER_GOODS_UUID" ; }}
		public string MY_ORDER_DETAIL_ATTENDANT_C_NAME {get{return "MY_ORDER_DETAIL_ATTENDANT_C_NAME" ; }}
		public string UNIT_UUID {get{return "UNIT_UUID" ; }}
		public string MY_ORDER_DETAIL_UNIT_NAME {get{return "MY_ORDER_DETAIL_UNIT_NAME" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VMyOrderDetail_Record CurrentRecord(){
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
		public VMyOrderDetail_Record CreateNew(){
			try{
				VMyOrderDetail_Record newData = new VMyOrderDetail_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VMyOrderDetail_Record> AllRecord(){
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
				_All_Record = new List<VMyOrderDetail_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public VMyOrderDetail Fill_By_PK(string pmy_order_uuid,string pmy_order_detail_uuid){
			try{
				IList<VMyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
									.And()
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<VMyOrderDetail_Record>()  ;  
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
		public VMyOrderDetail Fill_By_PK(string pmy_order_uuid,string pmy_order_detail_uuid,DB db){
			try{
				IList<VMyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
									.And()
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<VMyOrderDetail_Record>(db)  ;  
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
		public VMyOrderDetail_Record Fetch_By_PK(string pmy_order_uuid,string pmy_order_detail_uuid){
			try{
				IList<VMyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<VMyOrderDetail_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public VMyOrderDetail_Record Fetch_By_PK(string pmy_order_uuid,string pmy_order_detail_uuid,DB db){
			try{
				IList<VMyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<VMyOrderDetail_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public VMyOrderDetail Fill_By_MyOrderUuid_And_MyOrderDetailUuid(string pmy_order_uuid,string pmy_order_detail_uuid){
			try{
				IList<VMyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<VMyOrderDetail_Record>()  ;  
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
		public VMyOrderDetail Fill_By_MyOrderUuid_And_MyOrderDetailUuid(string pmy_order_uuid,string pmy_order_detail_uuid,DB db){
			try{
				IList<VMyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<VMyOrderDetail_Record>(db)  ;  
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
		public VMyOrderDetail_Record Fetch_By_MyOrderUuid_And_MyOrderDetailUuid(string pmy_order_uuid,string pmy_order_detail_uuid){
			try{
				IList<VMyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<VMyOrderDetail_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public VMyOrderDetail_Record Fetch_By_MyOrderUuid_And_MyOrderDetailUuid(string pmy_order_uuid,string pmy_order_detail_uuid,DB db){
			try{
				IList<VMyOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.MY_ORDER_UUID,pmy_order_uuid)
									.Equal(this.MY_ORDER_DETAIL_UUID,pmy_order_detail_uuid)
				).FetchAll<VMyOrderDetail_Record>(db)  ;  
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
