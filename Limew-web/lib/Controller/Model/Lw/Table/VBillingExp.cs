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
	[TableView("V_BILLING_EXP", false)]
	public partial class VBillingExp : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VBillingExp_Record _currentRecord = null;
	private IList<VBillingExp_Record> _All_Record = new List<VBillingExp_Record>();
		/*建構子*/
		public VBillingExp(){}
		public VBillingExp(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VBillingExp(IDataBaseConfigInfo dbc): base(dbc){}
		public VBillingExp(IDataBaseConfigInfo dbc,VBillingExp_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VBillingExp(IList<VBillingExp_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string BILLING_ID {
			[ColumnName("BILLING_ID",false,typeof(string))]
			get{return "BILLING_ID" ; }}
		public string BILLING_START_DATE {
			[ColumnName("BILLING_START_DATE",false,typeof(DateTime?))]
			get{return "BILLING_START_DATE" ; }}
		public string BILLING_END_DATE {
			[ColumnName("BILLING_END_DATE",false,typeof(DateTime?))]
			get{return "BILLING_END_DATE" ; }}
		public string BILLING_REPORT_DATE {
			[ColumnName("BILLING_REPORT_DATE",false,typeof(DateTime?))]
			get{return "BILLING_REPORT_DATE" ; }}
		public string BILLING_CUST_NAME {
			[ColumnName("BILLING_CUST_NAME",false,typeof(string))]
			get{return "BILLING_CUST_NAME" ; }}
		public string BILLING_CUST_UNIFORM_NUM {
			[ColumnName("BILLING_CUST_UNIFORM_NUM",false,typeof(string))]
			get{return "BILLING_CUST_UNIFORM_NUM" ; }}
		public string BILLING_TEL {
			[ColumnName("BILLING_TEL",false,typeof(string))]
			get{return "BILLING_TEL" ; }}
		public string BILLING_CUST_ADDRESS {
			[ColumnName("BILLING_CUST_ADDRESS",false,typeof(string))]
			get{return "BILLING_CUST_ADDRESS" ; }}
		public string BILLING_SALES_NAME {
			[ColumnName("BILLING_SALES_NAME",false,typeof(string))]
			get{return "BILLING_SALES_NAME" ; }}
		public string BILLING_ITEM_COUNT {
			[ColumnName("BILLING_ITEM_COUNT",false,typeof(int?))]
			get{return "BILLING_ITEM_COUNT" ; }}
		public string BILLING_DISCOUNT {
			[ColumnName("BILLING_DISCOUNT",false,typeof(decimal?))]
			get{return "BILLING_DISCOUNT" ; }}
		public string BILLING_SUM_PRICE {
			[ColumnName("BILLING_SUM_PRICE",false,typeof(decimal?))]
			get{return "BILLING_SUM_PRICE" ; }}
		public string BILLING_ARREARS_PRICE {
			[ColumnName("BILLING_ARREARS_PRICE",false,typeof(decimal?))]
			get{return "BILLING_ARREARS_PRICE" ; }}
		public string BILLING_TAX {
			[ColumnName("BILLING_TAX",false,typeof(decimal?))]
			get{return "BILLING_TAX" ; }}
		public string BILLING_TOTAL_PRICE {
			[ColumnName("BILLING_TOTAL_PRICE",false,typeof(decimal?))]
			get{return "BILLING_TOTAL_PRICE" ; }}
		public string BILLING_CHECK_YY {
			[ColumnName("BILLING_CHECK_YY",false,typeof(string))]
			get{return "BILLING_CHECK_YY" ; }}
		public string BILLING_CHECK_MM {
			[ColumnName("BILLING_CHECK_MM",false,typeof(string))]
			get{return "BILLING_CHECK_MM" ; }}
		public string BILLING_CHECK_TITLE {
			[ColumnName("BILLING_CHECK_TITLE",false,typeof(string))]
			get{return "BILLING_CHECK_TITLE" ; }}
		public string BILLING_CONTACT_USER_NAME {
			[ColumnName("BILLING_CONTACT_USER_NAME",false,typeof(string))]
			get{return "BILLING_CONTACT_USER_NAME" ; }}
		public string BILLING_CONTACT_ATTENDANT_UUID {
			[ColumnName("BILLING_CONTACT_ATTENDANT_UUID",false,typeof(string))]
			get{return "BILLING_CONTACT_ATTENDANT_UUID" ; }}
		public string BILLING_BACK_ACCOUNT_NUMBER {
			[ColumnName("BILLING_BACK_ACCOUNT_NUMBER",false,typeof(string))]
			get{return "BILLING_BACK_ACCOUNT_NUMBER" ; }}
		public string BILLING_BACK_NAME {
			[ColumnName("BILLING_BACK_NAME",false,typeof(string))]
			get{return "BILLING_BACK_NAME" ; }}
		public string BILLING_BACK_SUB_NAME {
			[ColumnName("BILLING_BACK_SUB_NAME",false,typeof(string))]
			get{return "BILLING_BACK_SUB_NAME" ; }}
		public string BILLING_BACK_ACCOUNT_NAME {
			[ColumnName("BILLING_BACK_ACCOUNT_NAME",false,typeof(string))]
			get{return "BILLING_BACK_ACCOUNT_NAME" ; }}
		public string BILLING_PS {
			[ColumnName("BILLING_PS",false,typeof(string))]
			get{return "BILLING_PS" ; }}
		public string BILLING_IS_ACTIVE {
			[ColumnName("BILLING_IS_ACTIVE",false,typeof(int?))]
			get{return "BILLING_IS_ACTIVE" ; }}
		public string BILLING_REPORT_ATTENDANT_UUID {
			[ColumnName("BILLING_REPORT_ATTENDANT_UUID",false,typeof(string))]
			get{return "BILLING_REPORT_ATTENDANT_UUID" ; }}
		public string BILLING_DETAIL_CR {
			[ColumnName("BILLING_DETAIL_CR",false,typeof(DateTime?))]
			get{return "BILLING_DETAIL_CR" ; }}
		public string BILLING_DETAIL_UUID {
			[ColumnName("BILLING_DETAIL_UUID",true,typeof(string))]
			get{return "BILLING_DETAIL_UUID" ; }}
		public string BILLING_UUID {
			[ColumnName("BILLING_UUID",false,typeof(string))]
			get{return "BILLING_UUID" ; }}
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
		public string CUST_ORDER_PS_NUMBER {
			[ColumnName("CUST_ORDER_PS_NUMBER",false,typeof(string))]
			get{return "CUST_ORDER_PS_NUMBER" ; }}
		public string CUST_ORDER_PAY_PS {
			[ColumnName("CUST_ORDER_PAY_PS",false,typeof(string))]
			get{return "CUST_ORDER_PAY_PS" ; }}
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
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VBillingExp_Record CurrentRecord(){
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
		public VBillingExp_Record CreateNew(){
			try{
				VBillingExp_Record newData = new VBillingExp_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VBillingExp_Record> AllRecord(){
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
				_All_Record = new List<VBillingExp_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public VBillingExp Fill_By_PK(string pbilling_detail_uuid,string pcust_order_uuid,string pcust_order_detail_uuid){
			try{
				IList<VBillingExp_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
									.And()
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.And()
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VBillingExp_Record>()  ;  
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
		public VBillingExp Fill_By_PK(string pbilling_detail_uuid,string pcust_order_uuid,string pcust_order_detail_uuid,DB db){
			try{
				IList<VBillingExp_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
									.And()
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.And()
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VBillingExp_Record>(db)  ;  
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
		public VBillingExp_Record Fetch_By_PK(string pbilling_detail_uuid,string pcust_order_uuid,string pcust_order_detail_uuid){
			try{
				IList<VBillingExp_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VBillingExp_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public VBillingExp_Record Fetch_By_PK(string pbilling_detail_uuid,string pcust_order_uuid,string pcust_order_detail_uuid,DB db){
			try{
				IList<VBillingExp_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VBillingExp_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public VBillingExp Fill_By_BillingDetailUuid_And_CustOrderUuid_And_CustOrderDetailUuid(string pbilling_detail_uuid,string pcust_order_uuid,string pcust_order_detail_uuid){
			try{
				IList<VBillingExp_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VBillingExp_Record>()  ;  
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
		public VBillingExp Fill_By_BillingDetailUuid_And_CustOrderUuid_And_CustOrderDetailUuid(string pbilling_detail_uuid,string pcust_order_uuid,string pcust_order_detail_uuid,DB db){
			try{
				IList<VBillingExp_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VBillingExp_Record>(db)  ;  
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
		public VBillingExp_Record Fetch_By_BillingDetailUuid_And_CustOrderUuid_And_CustOrderDetailUuid(string pbilling_detail_uuid,string pcust_order_uuid,string pcust_order_detail_uuid){
			try{
				IList<VBillingExp_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VBillingExp_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public VBillingExp_Record Fetch_By_BillingDetailUuid_And_CustOrderUuid_And_CustOrderDetailUuid(string pbilling_detail_uuid,string pcust_order_uuid,string pcust_order_detail_uuid,DB db){
			try{
				IList<VBillingExp_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.BILLING_DETAIL_UUID,pbilling_detail_uuid)
									.Equal(this.CUST_ORDER_UUID,pcust_order_uuid)
									.Equal(this.CUST_ORDER_DETAIL_UUID,pcust_order_detail_uuid)
				).FetchAll<VBillingExp_Record>(db)  ;  
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
