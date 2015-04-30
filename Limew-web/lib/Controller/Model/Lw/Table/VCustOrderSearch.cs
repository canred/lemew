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
	[TableView("V_CUST_ORDER_SEARCH", false)]
	public partial class VCustOrderSearch : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VCustOrderSearch_Record _currentRecord = null;
	private IList<VCustOrderSearch_Record> _All_Record = new List<VCustOrderSearch_Record>();
		/*建構子*/
		public VCustOrderSearch(){}
		public VCustOrderSearch(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VCustOrderSearch(IDataBaseConfigInfo dbc): base(dbc){}
		public VCustOrderSearch(IDataBaseConfigInfo dbc,VCustOrderSearch_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VCustOrderSearch(IList<VCustOrderSearch_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string CUST_ORDER_UUID {
			[ColumnName("CUST_ORDER_UUID",true,typeof(string))]
			get{return "CUST_ORDER_UUID" ; }}
		public string CUST_ORDER_CR {
			[ColumnName("CUST_ORDER_CR",false,typeof(DateTime?))]
			get{return "CUST_ORDER_CR" ; }}
		public string CUST_ORDER_ID {
			[ColumnName("CUST_ORDER_ID",false,typeof(string))]
			get{return "CUST_ORDER_ID" ; }}
		public string CUST_ORDER_TOTAL_PRICE {
			[ColumnName("CUST_ORDER_TOTAL_PRICE",false,typeof(decimal?))]
			get{return "CUST_ORDER_TOTAL_PRICE" ; }}
		public string CUST_ORDER_STATUS_UUID {
			[ColumnName("CUST_ORDER_STATUS_UUID",false,typeof(string))]
			get{return "CUST_ORDER_STATUS_UUID" ; }}
		public string CUST_ORDER_IS_ACTIVE {
			[ColumnName("CUST_ORDER_IS_ACTIVE",false,typeof(int?))]
			get{return "CUST_ORDER_IS_ACTIVE" ; }}
		public string CUST_UUID {
			[ColumnName("CUST_UUID",false,typeof(string))]
			get{return "CUST_UUID" ; }}
		public string CUST_ORDER_TYPE {
			[ColumnName("CUST_ORDER_TYPE",false,typeof(string))]
			get{return "CUST_ORDER_TYPE" ; }}
		public string CUST_ORDER_CUST_NAME {
			[ColumnName("CUST_ORDER_CUST_NAME",false,typeof(string))]
			get{return "CUST_ORDER_CUST_NAME" ; }}
		public string CUST_ORDER_DEPT {
			[ColumnName("CUST_ORDER_DEPT",false,typeof(string))]
			get{return "CUST_ORDER_DEPT" ; }}
		public string CUST_ORDER_USER_NAME {
			[ColumnName("CUST_ORDER_USER_NAME",false,typeof(string))]
			get{return "CUST_ORDER_USER_NAME" ; }}
		public string CUST_ORDER_USER_PHONE {
			[ColumnName("CUST_ORDER_USER_PHONE",false,typeof(string))]
			get{return "CUST_ORDER_USER_PHONE" ; }}
		public string CUST_ORDER_PURCHASE_AMOUNT {
			[ColumnName("CUST_ORDER_PURCHASE_AMOUNT",false,typeof(string))]
			get{return "CUST_ORDER_PURCHASE_AMOUNT" ; }}
		public string CUST_ORDER_PRINT_USER_NAME {
			[ColumnName("CUST_ORDER_PRINT_USER_NAME",false,typeof(string))]
			get{return "CUST_ORDER_PRINT_USER_NAME" ; }}
		public string CUST_ORDER_SHIPPING_DATE {
			[ColumnName("CUST_ORDER_SHIPPING_DATE",false,typeof(DateTime?))]
			get{return "CUST_ORDER_SHIPPING_DATE" ; }}
		public string SHIPPING_STATUS_UUID {
			[ColumnName("SHIPPING_STATUS_UUID",false,typeof(string))]
			get{return "SHIPPING_STATUS_UUID" ; }}
		public string CUST_ORDER_PO_NUMBER {
			[ColumnName("CUST_ORDER_PO_NUMBER",false,typeof(string))]
			get{return "CUST_ORDER_PO_NUMBER" ; }}
		public string PAY_STATUS_UUID {
			[ColumnName("PAY_STATUS_UUID",false,typeof(string))]
			get{return "PAY_STATUS_UUID" ; }}
		public string PAY_METHOD_UUID {
			[ColumnName("PAY_METHOD_UUID",false,typeof(string))]
			get{return "PAY_METHOD_UUID" ; }}
		public string CUST_ORDER_INVOICE_NUMBER {
			[ColumnName("CUST_ORDER_INVOICE_NUMBER",false,typeof(string))]
			get{return "CUST_ORDER_INVOICE_NUMBER" ; }}
		public string CUST_ORDER_LIMIT_DATE {
			[ColumnName("CUST_ORDER_LIMIT_DATE",false,typeof(DateTime?))]
			get{return "CUST_ORDER_LIMIT_DATE" ; }}
		public string CUST_ORG_UUID {
			[ColumnName("CUST_ORG_UUID",false,typeof(string))]
			get{return "CUST_ORG_UUID" ; }}
		public string CUST_ORDER_HAS_TAX {
			[ColumnName("CUST_ORDER_HAS_TAX",false,typeof(int?))]
			get{return "CUST_ORDER_HAS_TAX" ; }}
		public string CUST_ORDER_PS {
			[ColumnName("CUST_ORDER_PS",false,typeof(string))]
			get{return "CUST_ORDER_PS" ; }}
		public string CUST_ORDER_SHIPPING_NUMBER {
			[ColumnName("CUST_ORDER_SHIPPING_NUMBER",false,typeof(string))]
			get{return "CUST_ORDER_SHIPPING_NUMBER" ; }}
		public string CUST_NAME {
			[ColumnName("CUST_NAME",false,typeof(string))]
			get{return "CUST_NAME" ; }}
		public string CUST_ADDRESS {
			[ColumnName("CUST_ADDRESS",false,typeof(string))]
			get{return "CUST_ADDRESS" ; }}
		public string CUST_FAX {
			[ColumnName("CUST_FAX",false,typeof(string))]
			get{return "CUST_FAX" ; }}
		public string CUST_IS_ACTIVE {
			[ColumnName("CUST_IS_ACTIVE",false,typeof(int?))]
			get{return "CUST_IS_ACTIVE" ; }}
		public string CUST_LAST_BUY {
			[ColumnName("CUST_LAST_BUY",false,typeof(DateTime?))]
			get{return "CUST_LAST_BUY" ; }}
		public string CUST_PS {
			[ColumnName("CUST_PS",false,typeof(string))]
			get{return "CUST_PS" ; }}
		public string CUST_SALES_EMAIL {
			[ColumnName("CUST_SALES_EMAIL",false,typeof(string))]
			get{return "CUST_SALES_EMAIL" ; }}
		public string CUST_SALES_NAME {
			[ColumnName("CUST_SALES_NAME",false,typeof(string))]
			get{return "CUST_SALES_NAME" ; }}
		public string CUST_SALES_PHONE {
			[ColumnName("CUST_SALES_PHONE",false,typeof(string))]
			get{return "CUST_SALES_PHONE" ; }}
		public string CUST_TEL {
			[ColumnName("CUST_TEL",false,typeof(string))]
			get{return "CUST_TEL" ; }}
		public string CUST_ORDER_REPORT_DATE {
			[ColumnName("CUST_ORDER_REPORT_DATE",false,typeof(DateTime?))]
			get{return "CUST_ORDER_REPORT_DATE" ; }}
		public string CUST_ORDER_REPORT_ATTENDANT_UUID {
			[ColumnName("CUST_ORDER_REPORT_ATTENDANT_UUID",false,typeof(string))]
			get{return "CUST_ORDER_REPORT_ATTENDANT_UUID" ; }}
		public string CUST_ORDER_REPORT_ATTENDANT_C_NAME {
			[ColumnName("CUST_ORDER_REPORT_ATTENDANT_C_NAME",false,typeof(string))]
			get{return "CUST_ORDER_REPORT_ATTENDANT_C_NAME" ; }}
		public string PAY_STATUS_NAME {
			[ColumnName("PAY_STATUS_NAME",false,typeof(string))]
			get{return "PAY_STATUS_NAME" ; }}
		public string PAY_METHOD_NAME {
			[ColumnName("PAY_METHOD_NAME",false,typeof(string))]
			get{return "PAY_METHOD_NAME" ; }}
		public string CUST_ORG_SALES_NAME {
			[ColumnName("CUST_ORG_SALES_NAME",false,typeof(string))]
			get{return "CUST_ORG_SALES_NAME" ; }}
		public string CUST_ORG_SALES_PHONE {
			[ColumnName("CUST_ORG_SALES_PHONE",false,typeof(string))]
			get{return "CUST_ORG_SALES_PHONE" ; }}
		public string CUST_ORG_SALES_EMAIL {
			[ColumnName("CUST_ORG_SALES_EMAIL",false,typeof(string))]
			get{return "CUST_ORG_SALES_EMAIL" ; }}
		public string CUST_ORG_PS {
			[ColumnName("CUST_ORG_PS",false,typeof(string))]
			get{return "CUST_ORG_PS" ; }}
		public string CUST_ORG_NAME {
			[ColumnName("CUST_ORG_NAME",false,typeof(string))]
			get{return "CUST_ORG_NAME" ; }}
		public string CUST_ORG_IS_ACTIVE {
			[ColumnName("CUST_ORG_IS_ACTIVE",false,typeof(int?))]
			get{return "CUST_ORG_IS_ACTIVE" ; }}
		public string SHIPPING_ADDRESS {
			[ColumnName("SHIPPING_ADDRESS",false,typeof(string))]
			get{return "SHIPPING_ADDRESS" ; }}
		public string COMPANY_UUID {
			[ColumnName("COMPANY_UUID",false,typeof(string))]
			get{return "COMPANY_UUID" ; }}
		public string COMPANY_C_NAME {
			[ColumnName("COMPANY_C_NAME",false,typeof(string))]
			get{return "COMPANY_C_NAME" ; }}
		public string SHIPPING_STATUS_NAME {
			[ColumnName("SHIPPING_STATUS_NAME",false,typeof(string))]
			get{return "SHIPPING_STATUS_NAME" ; }}
		public string CUST_ORDER_DETAIL_COUNT {
			[ColumnName("CUST_ORDER_DETAIL_COUNT",false,typeof(int?))]
			get{return "CUST_ORDER_DETAIL_COUNT" ; }}
		public string CUST_ORDER_DETAIL_CR {
			[ColumnName("CUST_ORDER_DETAIL_CR",false,typeof(DateTime?))]
			get{return "CUST_ORDER_DETAIL_CR" ; }}
		public string CUST_ORDER_DETAIL_CUSTOMIZED {
			[ColumnName("CUST_ORDER_DETAIL_CUSTOMIZED",false,typeof(int?))]
			get{return "CUST_ORDER_DETAIL_CUSTOMIZED" ; }}
		public string CUST_ORDER_DETAIL_GOODS_NAME {
			[ColumnName("CUST_ORDER_DETAIL_GOODS_NAME",false,typeof(string))]
			get{return "CUST_ORDER_DETAIL_GOODS_NAME" ; }}
		public string CUST_ORDER_DETAIL_IS_ACTIVE {
			[ColumnName("CUST_ORDER_DETAIL_IS_ACTIVE",false,typeof(int?))]
			get{return "CUST_ORDER_DETAIL_IS_ACTIVE" ; }}
		public string CUST_ORDER_DETAIL_PRICE {
			[ColumnName("CUST_ORDER_DETAIL_PRICE",false,typeof(decimal?))]
			get{return "CUST_ORDER_DETAIL_PRICE" ; }}
		public string CUST_ORDER_DETAIL_PS {
			[ColumnName("CUST_ORDER_DETAIL_PS",false,typeof(string))]
			get{return "CUST_ORDER_DETAIL_PS" ; }}
		public string CUST_ORDER_DETAIL_TOTAL_PRICE {
			[ColumnName("CUST_ORDER_DETAIL_TOTAL_PRICE",false,typeof(decimal?))]
			get{return "CUST_ORDER_DETAIL_TOTAL_PRICE" ; }}
		public string CUST_ORDER_DETAIL_UNIT {
			[ColumnName("CUST_ORDER_DETAIL_UNIT",false,typeof(string))]
			get{return "CUST_ORDER_DETAIL_UNIT" ; }}
		public string CUST_ORDER_DETAIL_UNIT_NAME {
			[ColumnName("CUST_ORDER_DETAIL_UNIT_NAME",false,typeof(string))]
			get{return "CUST_ORDER_DETAIL_UNIT_NAME" ; }}
		public string CUST_ORDER_DETAIL_UUID {
			[ColumnName("CUST_ORDER_DETAIL_UUID",true,typeof(string))]
			get{return "CUST_ORDER_DETAIL_UUID" ; }}
		public string FILEGROUP_DISPLAY_NAME {
			[ColumnName("FILEGROUP_DISPLAY_NAME",false,typeof(string))]
			get{return "FILEGROUP_DISPLAY_NAME" ; }}
		public string FILEGROUP_TAG {
			[ColumnName("FILEGROUP_TAG",false,typeof(string))]
			get{return "FILEGROUP_TAG" ; }}
		public string FILEGROUP_UUID {
			[ColumnName("FILEGROUP_UUID",false,typeof(string))]
			get{return "FILEGROUP_UUID" ; }}
		public string FILE_COUNT {
			[ColumnName("FILE_COUNT",false,typeof(int?))]
			get{return "FILE_COUNT" ; }}
		public string GCATEGORY_FULL_NAME {
			[ColumnName("GCATEGORY_FULL_NAME",false,typeof(string))]
			get{return "GCATEGORY_FULL_NAME" ; }}
		public string GCATEGORY_NAME {
			[ColumnName("GCATEGORY_NAME",false,typeof(string))]
			get{return "GCATEGORY_NAME" ; }}
		public string GCATEGORY_UUID {
			[ColumnName("GCATEGORY_UUID",false,typeof(string))]
			get{return "GCATEGORY_UUID" ; }}
		public string GOODS_NAME {
			[ColumnName("GOODS_NAME",false,typeof(string))]
			get{return "GOODS_NAME" ; }}
		public string GOODS_PRICE {
			[ColumnName("GOODS_PRICE",false,typeof(decimal?))]
			get{return "GOODS_PRICE" ; }}
		public string GOODS_PS {
			[ColumnName("GOODS_PS",false,typeof(string))]
			get{return "GOODS_PS" ; }}
		public string GOODS_SN {
			[ColumnName("GOODS_SN",false,typeof(string))]
			get{return "GOODS_SN" ; }}
		public string GOODS_UUID {
			[ColumnName("GOODS_UUID",false,typeof(string))]
			get{return "GOODS_UUID" ; }}
		public string SUPPLIER_GOODS_NAME {
			[ColumnName("SUPPLIER_GOODS_NAME",false,typeof(string))]
			get{return "SUPPLIER_GOODS_NAME" ; }}
		public string SUPPLIER_GOODS_PRICE {
			[ColumnName("SUPPLIER_GOODS_PRICE",false,typeof(decimal?))]
			get{return "SUPPLIER_GOODS_PRICE" ; }}
		public string SUPPLIER_GOODS_SN {
			[ColumnName("SUPPLIER_GOODS_SN",false,typeof(string))]
			get{return "SUPPLIER_GOODS_SN" ; }}
		public string SUPPLIER_GOODS_UNIT_UUID {
			[ColumnName("SUPPLIER_GOODS_UNIT_UUID",false,typeof(string))]
			get{return "SUPPLIER_GOODS_UNIT_UUID" ; }}
		public string SUPPLIER_GOODS_UUID {
			[ColumnName("SUPPLIER_GOODS_UUID",false,typeof(string))]
			get{return "SUPPLIER_GOODS_UUID" ; }}
		public string UNIT_NAME {
			[ColumnName("UNIT_NAME",false,typeof(string))]
			get{return "UNIT_NAME" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VCustOrderSearch_Record CurrentRecord(){
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
		public VCustOrderSearch_Record CreateNew(){
			try{
				VCustOrderSearch_Record newData = new VCustOrderSearch_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VCustOrderSearch_Record> AllRecord(){
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
				_All_Record = new List<VCustOrderSearch_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public VCustOrderSearch Fill_By_PK(string pcust_order_uuid,string pcust_order_detail_uuid){
			try{
				IList<VCustOrderSearch_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.And()
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderSearch_Record>()  ;  
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
		public VCustOrderSearch Fill_By_PK(string pcust_order_uuid,string pcust_order_detail_uuid,DB db){
			try{
				IList<VCustOrderSearch_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.And()
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderSearch_Record>(db)  ;  
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
		public VCustOrderSearch_Record Fetch_By_PK(string pcust_order_uuid,string pcust_order_detail_uuid){
			try{
				IList<VCustOrderSearch_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderSearch_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public VCustOrderSearch_Record Fetch_By_PK(string pcust_order_uuid,string pcust_order_detail_uuid,DB db){
			try{
				IList<VCustOrderSearch_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderSearch_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public VCustOrderSearch Fill_By_CustOrderUuid_And_CustOrderDetailUuid(string pcust_order_uuid,string pcust_order_detail_uuid){
			try{
				IList<VCustOrderSearch_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderSearch_Record>()  ;  
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
		public VCustOrderSearch Fill_By_CustOrderUuid_And_CustOrderDetailUuid(string pcust_order_uuid,string pcust_order_detail_uuid,DB db){
			try{
				IList<VCustOrderSearch_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderSearch_Record>(db)  ;  
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
		public VCustOrderSearch_Record Fetch_By_CustOrderUuid_And_CustOrderDetailUuid(string pcust_order_uuid,string pcust_order_detail_uuid){
			try{
				IList<VCustOrderSearch_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderSearch_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public VCustOrderSearch_Record Fetch_By_CustOrderUuid_And_CustOrderDetailUuid(string pcust_order_uuid,string pcust_order_detail_uuid,DB db){
			try{
				IList<VCustOrderSearch_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VCustOrderSearch_Record>(db)  ;  
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
