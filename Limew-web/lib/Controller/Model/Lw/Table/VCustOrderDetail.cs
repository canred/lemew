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
	[TableView("V_CUST_ORDER_DETAIL", false)]
	public partial class VCustOrderDetail : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VCustOrderDetail_Record _currentRecord = null;
	private IList<VCustOrderDetail_Record> _All_Record = new List<VCustOrderDetail_Record>();
		/*建構子*/
		public VCustOrderDetail(){}
		public VCustOrderDetail(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VCustOrderDetail(IDataBaseConfigInfo dbc): base(dbc){}
		public VCustOrderDetail(IDataBaseConfigInfo dbc,VCustOrderDetail_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VCustOrderDetail(IList<VCustOrderDetail_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string CUST_ORDER_DETAIL_UUID {get{return "CUST_ORDER_DETAIL_UUID" ; }}
		public string CUST_ORDER_UUID {get{return "CUST_ORDER_UUID" ; }}
		public string GOODS_UUID {get{return "GOODS_UUID" ; }}
		public string CUST_ORDER_DETAIL_GOODS_NAME {get{return "CUST_ORDER_DETAIL_GOODS_NAME" ; }}
		public string CUST_ORDER_DETAIL_COUNT {get{return "CUST_ORDER_DETAIL_COUNT" ; }}
		public string CUST_ORDER_DETAIL_UNIT {get{return "CUST_ORDER_DETAIL_UNIT" ; }}
		public string CUST_ORDER_DETAIL_PRICE {get{return "CUST_ORDER_DETAIL_PRICE" ; }}
		public string CUST_ORDER_DETAIL_TOTAL_PRICE {get{return "CUST_ORDER_DETAIL_TOTAL_PRICE" ; }}
		public string CUST_ORDER_DETAIL_PS {get{return "CUST_ORDER_DETAIL_PS" ; }}
		public string CUST_ORDER_DETAIL_CR {get{return "CUST_ORDER_DETAIL_CR" ; }}
		public string CUST_ORDER_DETAIL_CUSTOMIZED {get{return "CUST_ORDER_DETAIL_CUSTOMIZED" ; }}
		public string FILEGROUP_UUID {get{return "FILEGROUP_UUID" ; }}
		public string SUPPLIER_GOODS_UUID {get{return "SUPPLIER_GOODS_UUID" ; }}
		public string CUST_ORDER_DETAIL_IS_ACTIVE {get{return "CUST_ORDER_DETAIL_IS_ACTIVE" ; }}
		public string GCATEGORY_FULL_NAME {get{return "GCATEGORY_FULL_NAME" ; }}
		public string GCATEGORY_NAME {get{return "GCATEGORY_NAME" ; }}
		public string GCATEGORY_UUID {get{return "GCATEGORY_UUID" ; }}
		public string GOODS_NAME {get{return "GOODS_NAME" ; }}
		public string GOODS_PRICE {get{return "GOODS_PRICE" ; }}
		public string GOODS_PS {get{return "GOODS_PS" ; }}
		public string GOODS_SN {get{return "GOODS_SN" ; }}
		public string SUPPLIER_GOODS_NAME {get{return "SUPPLIER_GOODS_NAME" ; }}
		public string SUPPLIER_GOODS_PRICE {get{return "SUPPLIER_GOODS_PRICE" ; }}
		public string SUPPLIER_GOODS_SN {get{return "SUPPLIER_GOODS_SN" ; }}
		public string SUPPLIER_GOODS_UNIT_UUID {get{return "SUPPLIER_GOODS_UNIT_UUID" ; }}
		public string UNIT_NAME {get{return "UNIT_NAME" ; }}
		public string CUST_ORDER_DETAIL_UNIT_NAME {get{return "CUST_ORDER_DETAIL_UNIT_NAME" ; }}
		public string FILEGROUP_DISPLAY_NAME {get{return "FILEGROUP_DISPLAY_NAME" ; }}
		public string FILEGROUP_TAG {get{return "FILEGROUP_TAG" ; }}
		public string FILE_COUNT {get{return "FILE_COUNT" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VCustOrderDetail_Record CurrentRecord(){
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
		public VCustOrderDetail_Record CreateNew(){
			try{
				VCustOrderDetail_Record newData = new VCustOrderDetail_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VCustOrderDetail_Record> AllRecord(){
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
				_All_Record = new List<VCustOrderDetail_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public VCustOrderDetail Fill_By_PK(string pcust_order_detail_uuid){
			try{
				IList<VCustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderDetail_Record>()  ;  
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
		public VCustOrderDetail Fill_By_PK(string pcust_order_detail_uuid,DB db){
			try{
				IList<VCustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderDetail_Record>(db)  ;  
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
		public VCustOrderDetail_Record Fetch_By_PK(string pcust_order_detail_uuid){
			try{
				IList<VCustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderDetail_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public VCustOrderDetail_Record Fetch_By_PK(string pcust_order_detail_uuid,DB db){
			try{
				IList<VCustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderDetail_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public VCustOrderDetail Fill_By_CustOrderDetailUuid(string pcust_order_detail_uuid){
			try{
				IList<VCustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderDetail_Record>()  ;  
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
		public VCustOrderDetail Fill_By_CustOrderDetailUuid(string pcust_order_detail_uuid,DB db){
			try{
				IList<VCustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderDetail_Record>(db)  ;  
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
		public VCustOrderDetail_Record Fetch_By_CustOrderDetailUuid(string pcust_order_detail_uuid){
			try{
				IList<VCustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderDetail_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public VCustOrderDetail_Record Fetch_By_CustOrderDetailUuid(string pcust_order_detail_uuid,DB db){
			try{
				IList<VCustOrderDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderDetail_Record>(db)  ;  
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
