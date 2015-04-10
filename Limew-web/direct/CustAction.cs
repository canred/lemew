#region USING
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ExtDirect;
using ExtDirect.Direct;
using LK.DB.SQLCreater;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

using Limew.Model.Basic;
using Limew.Model.Basic.Table;
using Limew.Model.Basic.Table.Record;
using Limew;
using Limew.Model.Lw;
using Limew.Model.Lw.Table;
using Limew.Model.Lw.Table.Record;
using System.Text;
using LK.Util;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Collections;

using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using iTextSharp.tool.xml;
using System.Net;
#endregion

[DirectService("CustAction")]
public class CustAction : BaseAction
{

    [DirectMethod("infoCust", DirectAction.Load)]
    public JObject infoCust(string pCustUuid, Request request)
    {
        #region Declare
        LwModel model = new LwModel();
        #endregion

        try
        {  /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            var data = model.getCust_By_CustUuid(pCustUuid);

            if (data.AllRecord().Count == 1)
            {
                return ExtDirect.Direct.Helper.Form.OutputJObject(JsonHelper.RecordBaseJObject(data.AllRecord().First()));
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Data Not Found!"));
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("loadVCustAddress", DirectAction.Store)]
    public JObject loadVCustAddress(string pCustUuid,string pCustOrgUuid, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        Limew.Model.Basic.BasicModel model = new Limew.Model.Basic.BasicModel();
        LwModel mod = new LwModel();
        OrderLimit orderLimit = new OrderLimit();

        #endregion
        try
        {     /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得總資料數*/
            //orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            var data = mod.getVCustAddress_By_CustUuid_Or_CustOrgUuid(pCustUuid, pCustOrgUuid);
            //var totalCount =

            IList<VCustAddress_Record> ret = new List<VCustAddress_Record>();
            System.Collections.Hashtable ht = new Hashtable();
            foreach (var item in data) {
                if (ht.ContainsKey(item.CUST_ADDRESS) == false) {
                    if (item.CUST_ADDRESS.Trim().Length > 0) {
                        ht.Add(item.CUST_ADDRESS, "");
                    }
                    
                };

                if (ht.ContainsKey(item.CUST_ORG_ADDRESS) == false) {
                    if (item.CUST_ORG_ADDRESS.Trim().Length>0)
                    {
                        ht.Add(item.CUST_ORG_ADDRESS, "");
                    }
                    
                }
            }

            foreach (DictionaryEntry item in ht)
            {
                VCustAddress_Record r = new VCustAddress_Record();
                r.CUST_ADDRESS = item.Key.ToString();
                ret.Add(r);  
            }
                        
            if (ret.Count > 0)
            {
                jobject = JsonHelper.RecordBaseListJObject(ret);
            }
            
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, ret.Count);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }
    [DirectMethod("loadCust", DirectAction.Store)]
    public JObject loadCust(string pKeyword, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        Limew.Model.Basic.BasicModel model = new Limew.Model.Basic.BasicModel();
        LwModel mod = new LwModel();
        OrderLimit orderLimit = new OrderLimit();

        #endregion
        try
        {     /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得總資料數*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            var totalCount = mod.getCust_By_Keyword_Count(pKeyword);
            var data = mod.getCust_By_Keyword(pKeyword, orderLimit);
            if (data.Count > 0)
            {
                jobject = JsonHelper.RecordBaseListJObject(data.ToList());
            }
            else
            {
                totalCount = 0;
            }
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, totalCount);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("submitCust", DirectAction.FormSubmission)]
    public JObject submitCust(string cust_uuid,
                                string cust_name,
                                string cust_tel,
                                string cust_fax,
                                string cust_address,
                                string cust_sales_name,
                                string cust_sales_phone,
                                string cust_sales_email,
                                string cust_ps,
                                string cust_level,
                                string cust_is_active,
                                string cust_last_buy, Request request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        Cust_Record record = new Cust_Record();
        #endregion
        try
        {  /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*
             * 所有Form的動作最終是使用Submit的方式將資料傳出；
             * 必須有一個特徵來判斷使用者，執行的動作；
             */
            if (cust_uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = mod.getCust_By_CustUuid(cust_uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.CUST_UUID = LK.Util.UID.Instance.GetUniqueID();
            }
            record.CUST_NAME = cust_name;
            record.CUST_TEL = cust_tel;
            record.CUST_FAX = cust_fax;
            record.CUST_ADDRESS = cust_address;
            record.CUST_SALES_NAME = cust_sales_name;
            record.CUST_SALES_PHONE = cust_sales_phone;
            record.CUST_SALES_EMAIL = cust_sales_email;
            record.CUST_PS = cust_ps;
            record.CUST_LEVEL = Convert.ToInt16(cust_level);
            record.CUST_IS_ACTIVE = Convert.ToInt16(cust_is_active);
            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            else if (action == SubmitAction.Create)
            {
                record.gotoTable().Insert(record);
                cust_uuid = record.CUST_UUID;
            };

            var drsCustOrg = mod.getCustOrg_By_CustUuid_CustOrgIsDefault(record.CUST_UUID, "1");
            if (drsCustOrg.Count == 0)
            {
                CustOrg_Record custOrg = new CustOrg_Record();
                custOrg.CUST_ORG_UUID = LK.Util.UID.Instance.GetUniqueID();
                custOrg.CUST_UUID = record.CUST_UUID;
                custOrg.CUST_ORG_ADDRESS = record.CUST_ADDRESS;
                custOrg.CUST_ORG_IS_ACTIVE = 1;
                custOrg.CUST_ORG_IS_DEFAULT = 1;
                custOrg.CUST_ORG_NAME = record.CUST_NAME;
                custOrg.CUST_ORG_PS = "";
                custOrg.CUST_ORG_SALES_EMAIL = record.CUST_SALES_EMAIL;
                custOrg.CUST_ORG_SALES_NAME = record.CUST_SALES_NAME;
                custOrg.CUST_ORG_SALES_PHONE = record.CUST_SALES_PHONE;
                custOrg.gotoTable().Insert_Empty2Null(custOrg);
            }
            else if(drsCustOrg.Count==1) {
                var drCustOrg = drsCustOrg.First();
                drCustOrg.CUST_ORG_ADDRESS = record.CUST_ADDRESS;
                drCustOrg.CUST_ORG_IS_ACTIVE = 1;
                drCustOrg.CUST_ORG_IS_DEFAULT = 1;
                drCustOrg.CUST_ORG_NAME = record.CUST_NAME;
                drCustOrg.CUST_ORG_PS = "";
                drCustOrg.CUST_ORG_SALES_EMAIL = record.CUST_SALES_EMAIL;
                drCustOrg.CUST_ORG_SALES_NAME = record.CUST_SALES_NAME;
                drCustOrg.CUST_ORG_SALES_PHONE = record.CUST_SALES_PHONE;
                drCustOrg.gotoTable().Update_Empty2Null(drCustOrg);
            };
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("CUST_UUID", record.CUST_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("destoryCust", DirectAction.Store)]
    public JObject destoryCust(string pCustUuid, Request request)
    {
        #region Declare
        LwModel mod = new LwModel();
        #endregion
        try
        {     /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得總資料數*/

            var data = mod.getCust_By_CustUuid(pCustUuid);
            if (data.AllRecord().Count > 0)
            {
                var delDr = data.AllRecord().First();
                delDr.gotoTable().Delete(delDr);
            }
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadCustOrder", DirectAction.Store)]
    public JObject loadCustOrder(string pCustUuid, string pKeyword, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        LwModel mod = new LwModel();
        OrderLimit orderLimit = new OrderLimit();

        #endregion
        try
        {     /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得總資料數*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            var totalCount = mod.getCustOrder_By_CustUuid_Count(pCustUuid);
            var data = mod.getCustOrder_By_CustUuid(pCustUuid, orderLimit);
            if (data.Count > 0)
            {
                jobject = JsonHelper.RecordBaseListJObject(data.ToList());
            }
            else
            {
                totalCount = 0;
            }
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, totalCount);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("infoCustOrder", DirectAction.Load)]
    public JObject infoCustOrder(string pCustOrderUuid, Request request)
    {
        #region Declare
        LwModel model = new LwModel();
        #endregion

        try
        {  /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            var data = model.getCustOrder_By_CustOrderUuid(pCustOrderUuid);

            if (data.AllRecord().Count == 1)
            {
               // data.AllRecord().First().CUST_ORDER_REPORT_DATE = "";
                return ExtDirect.Direct.Helper.Form.OutputJObject(JsonHelper.RecordBaseJObject(data.AllRecord().First()));
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Data Not Found!"));
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("createCustOrder", DirectAction.Load)]
    public JObject createCustOrder(Request request)
    {
        #region Declare
        LwModel mod = new LwModel();
        CustOrder_Record record = new CustOrder_Record();
        #endregion
        try
        {  /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*
             * 所有Form的動作最終是使用Submit的方式將資料傳出；
             * 必須有一個特徵來判斷使用者，執行的動作；
             */
            record.CUST_ORDER_UUID = LK.Util.UID.Instance.GetUniqueID();
            record.CUST_ORDER_CR = DateTime.Now;
            record.CUST_ORDER_ID = getCustOrderId();
            record.CUST_ORDER_IS_ACTIVE = 0;
            record.CUST_ORDER_STATUS_UUID = "COS_INIT";
            record.PAY_STATUS_UUID = "pay_status_1";
            record.PAY_METHOD_UUID = "PM_INIT";
            record.SHIPPING_STATUS_UUID = "SS_INIT";
            record.CUST_ORDER_HAS_TAX = 1;
            record.gotoTable().Insert_Empty2Null(record);
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("CUST_ORDER_UUID", record.CUST_ORDER_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }


    }

    public string getCustOrderId() {
        LwModel mod = new LwModel();
        var drs = mod.getCustOrderId_By_CustOrderIdUuid(DateTime.Now.ToString("yyyyMMdd")).AllRecord();
        if (drs.Count == 0)
        {
            CustOrderId_Record newRow = new CustOrderId_Record();
            newRow.CUST_ORDER_ID_UUID = DateTime.Now.ToString("yyyyMMdd");
            newRow.MAX = 1;
            newRow.gotoTable().Insert_Empty2Null(newRow);
            return newRow.CUST_ORDER_ID_UUID + String.Format("{0:0000}", newRow.MAX);
        }
        else {
            var dr = drs.First();
            //drs.First()drs.Max(c => c.MAX).Value()+1
            dr.MAX = dr.MAX + 1;
            dr.gotoTable().Update_Empty2Null(dr);
            return dr.CUST_ORDER_ID_UUID + String.Format("{0:0000}", dr.MAX); 
        }

    }

    [DirectMethod("submitCustOrder", DirectAction.FormSubmission)]
    public JObject submitCustOrder(string cust_order_uuid,
                                    string cust_order_cr,
                                    string cust_order_id,
                                    string cust_order_total_price,
                                    string cust_order_status_uuid,
                                    string cust_order_is_active,
                                    string cust_uuid,
                                    string cust_order_type,
                                    string cust_order_cust_name,
                                    string cust_order_dept,
                                    string cust_order_user_name,
                                    string cust_order_user_phone,
                                    string cust_order_purchase_amount,
                                    string cust_order_print_user_name,
                                    string cust_order_shipping_date,
                                    string shipping_status_uuid,
                                    string cust_order_po_number,
                                    string pay_status_uuid,
                                    string pay_method_uuid,
                                    string cust_order_invoice_number,
                                    string cust_order_limit_date,
                                    string cust_org_uuid,
                                    string cust_order_has_tax,
                                    string cust_order_ps,
                                    string company_uuid,
        string cust_order_report_attendant_uuid,
        string cust_order_report_date ,
        string cust_order_shipping_number ,
        string shipping_address,Request request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        CustOrder_Record record = new CustOrder_Record();
        #endregion
        try
        {  /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*
             * 所有Form的動作最終是使用Submit的方式將資料傳出；
             * 必須有一個特徵來判斷使用者，執行的動作；
             */
            if (cust_order_uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = mod.getCustOrder_By_CustOrderUuid(cust_order_uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.CUST_ORDER_UUID = LK.Util.UID.Instance.GetUniqueID();
                record.CUST_ORDER_CR = DateTime.Now;
            }

            var checkCustOrderId = mod.getCustOrder_By_CustOrderId(cust_order_id, new OrderLimit());
            var orgDr = mod.getCustOrder_By_CustOrderUuid(cust_order_uuid).AllRecord().First();
            if (checkCustOrderId.Count > 1) {
                throw new Exception("訂單編號發生重複!");
            }
            else if (checkCustOrderId.Count == 1) {
                if (orgDr.CUST_ORDER_UUID == checkCustOrderId.First().CUST_ORDER_UUID)
                {
                }
                else {
                    throw new Exception("訂單編號發生重複!");
                }
            }
            
            record.CUST_ORDER_ID = cust_order_id;
            //要自動計算的1
            //if (cust_order_total_price.Trim().Length > 0)
            //{
            //    record.CUST_ORDER_TOTAL_PRICE = Convert.ToDecimal(cust_order_total_price);
            //}
            //else {
            //    record.CUST_ORDER_TOTAL_PRICE =null;
            //}

            //要自動計算的2
            //record.CUST_ORDER_PURCHASE_AMOUNT = cust_order_purchase_amount;
            record.CUST_ORDER_STATUS_UUID = cust_order_status_uuid;
            record.CUST_ORDER_IS_ACTIVE = Convert.ToInt16(cust_order_is_active);
            record.CUST_UUID = cust_uuid;
            record.CUST_ORDER_TYPE = cust_order_type;
            record.CUST_ORDER_CUST_NAME = cust_order_cust_name;
            record.CUST_ORDER_DEPT = cust_order_dept;
            record.CUST_ORDER_USER_NAME = cust_order_user_name;
            record.CUST_ORDER_USER_PHONE = cust_order_user_phone;
            record.SHIPPING_ADDRESS = shipping_address;

            record.CUST_ORDER_PRINT_USER_NAME = cust_order_print_user_name;
            if (cust_order_shipping_date !=null && cust_order_shipping_date.Trim().Length > 0)
            {
                record.CUST_ORDER_SHIPPING_DATE = Convert.ToDateTime(cust_order_shipping_date);
            }
            else
            {
                record.CUST_ORDER_SHIPPING_DATE = null;
            }
            record.SHIPPING_STATUS_UUID = shipping_status_uuid;
            record.CUST_ORDER_PO_NUMBER = cust_order_po_number;
            record.PAY_STATUS_UUID = pay_status_uuid;
            record.PAY_METHOD_UUID = pay_method_uuid;
            record.CUST_ORDER_INVOICE_NUMBER = cust_order_invoice_number;
            record.CUST_ORDER_REPORT_ATTENDANT_UUID = cust_order_report_attendant_uuid;
            if (cust_order_limit_date!=null && cust_order_limit_date.Trim().Length > 0)
            {
                record.CUST_ORDER_LIMIT_DATE = Convert.ToDateTime((cust_order_limit_date));
            }
            else
            {
                record.CUST_ORDER_LIMIT_DATE = null;
            }

            if (cust_order_report_date.Trim().Length > 0)
            {
                record.CUST_ORDER_REPORT_DATE = Convert.ToDateTime((cust_order_report_date));
            }
            else
            {
                record.CUST_ORDER_REPORT_DATE = null;
            }

            record.CUST_ORG_UUID = cust_org_uuid;
            record.CUST_ORDER_HAS_TAX = Convert.ToInt16(cust_order_has_tax);
            record.CUST_ORDER_PS = cust_order_ps;
            record.COMPANY_UUID = company_uuid;
            if (record.CUST_ORDER_SHIPPING_NUMBER.Trim().Length == 0)
            {
                record.CUST_ORDER_SHIPPING_NUMBER = cust_order_shipping_number;
            }
                
            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            else if (action == SubmitAction.Create)
            {
                record.gotoTable().Insert(record);
                cust_uuid = record.CUST_UUID;
            }
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("CUST_ORDER_UUID", record.CUST_ORDER_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("destoryCustOrder", DirectAction.Store)]
    public JObject destoryCustOrder(string pCustOrderUuid, Request request)
    {
        #region Declare
        LwModel mod = new LwModel();
        #endregion
        try
        {     /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得總資料數*/

            var data = mod.getCustOrder_By_CustOrderUuid(pCustOrderUuid);
            if (data.AllRecord().Count > 0)
            {
                var delDr = data.AllRecord().First();
                delDr.gotoTable().Delete(delDr);
            }
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("infoCustOrderDetail", DirectAction.Load)]
    public JObject infoCustOrderDetail(string pCustOrderDetailUuid, Request request)
    {
        #region Declare
        LwModel model = new LwModel();
        #endregion

        try
        {  /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };

            if (pCustOrderDetailUuid.Trim().Length == 0)
            {
                pCustOrderDetailUuid = LK.Util.UID.Instance.GetUniqueID();
                CustOrderDetail_Record newRecord = new CustOrderDetail_Record();
                newRecord.CUST_ORDER_DETAIL_CR = DateTime.Now;
                newRecord.CUST_ORDER_DETAIL_IS_ACTIVE = 0;
                newRecord.CUST_ORDER_DETAIL_UUID = pCustOrderDetailUuid;
                newRecord.CUST_ORDER_DETAIL_COUNT = 1;
                newRecord.CUST_ORDER_DETAIL_PRICE = 0;
                newRecord.CUST_ORDER_DETAIL_TOTAL_PRICE = 0;
                newRecord.gotoTable().Insert_Empty2Null(newRecord);
            }
            var data = model.getCustOrderDetail_By_CustOrderDetailUuid(pCustOrderDetailUuid);

            if (data.AllRecord().Count == 1)
            {
                return ExtDirect.Direct.Helper.Form.OutputJObject(JsonHelper.RecordBaseJObject(data.AllRecord().First()));
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Data Not Found!"));
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("submitCustOrderDetail", DirectAction.FormSubmission)]
    public JObject submitCustOrderDetail(string cust_order_detail_uuid,
string cust_order_uuid,
string goods_uuid,
string cust_order_detail_goods_name,
string cust_order_detail_count,
string cust_order_detail_unit,
string cust_order_detail_price,
string cust_order_detail_total_price,
string cust_order_detail_ps,
string cust_order_detail_cr,
string cust_order_detail_customized,
string filegroup_uuid,
        string cust_order_detail_is_active,
string supplier_goods_uuid, Request request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        CustOrderDetail_Record record = new CustOrderDetail_Record();
        #endregion
        try
        {  /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*
             * 所有Form的動作最終是使用Submit的方式將資料傳出；
             * 必須有一個特徵來判斷使用者，執行的動作；
             */
            record = _submitCustOrderDetail(cust_order_detail_uuid,
 cust_order_uuid,
 goods_uuid,
 cust_order_detail_goods_name,
 cust_order_detail_count,
 cust_order_detail_unit,
 cust_order_detail_price,
 cust_order_detail_total_price,
 cust_order_detail_ps,
 cust_order_detail_cr,
 cust_order_detail_customized,
 filegroup_uuid,
        cust_order_detail_is_active,
 supplier_goods_uuid);
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("CUST_ORDER_DETAIL_UUID", record.CUST_ORDER_DETAIL_UUID);

            _calCustOrderTotalPrice(record.CUST_ORDER_UUID);
            //if (record.CUST_ORDER_UUID.Trim().Length > 0)
            //{
            //    var allrecord = mod.getCustOrderDetail_By_CustOrderUuid(record.CUST_ORDER_UUID, new OrderLimit());
            //    decimal sum = 0;
            //    foreach (var item in allrecord)
            //    {
            //        sum += item.CUST_ORDER_DETAIL_TOTAL_PRICE.Value;
            //    }
            //    var custOrder = mod.getCustOrder_By_CustOrderUuid(record.CUST_ORDER_UUID).AllRecord().First();
            //    custOrder.CUST_ORDER_TOTAL_PRICE = sum;
            //    custOrder.gotoTable().Update_Empty2Null(custOrder);
            //}
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    public CustOrderDetail_Record _submitCustOrderDetail(string cust_order_detail_uuid,
string cust_order_uuid,
string goods_uuid,
string cust_order_detail_goods_name,
string cust_order_detail_count,
string cust_order_detail_unit,
string cust_order_detail_price,
string cust_order_detail_total_price,
string cust_order_detail_ps,
string cust_order_detail_cr,
string cust_order_detail_customized,
string filegroup_uuid,
       string cust_order_detail_is_active,
string supplier_goods_uuid)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        CustOrderDetail_Record record = new CustOrderDetail_Record();
        #endregion
        try
        {             
            /*
             * 所有Form的動作最終是使用Submit的方式將資料傳出；
             * 必須有一個特徵來判斷使用者，執行的動作；
             */
            if (cust_order_detail_uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = mod.getCustOrderDetail_By_CustOrderDetailUuid(cust_order_detail_uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.CUST_ORDER_DETAIL_UUID = LK.Util.UID.Instance.GetUniqueID();
                record.CUST_ORDER_DETAIL_CR = DateTime.Now;
            }

            record.CUST_ORDER_UUID = cust_order_uuid;
            record.GOODS_UUID = goods_uuid;
            record.CUST_ORDER_DETAIL_GOODS_NAME = cust_order_detail_goods_name;
            record.CUST_ORDER_DETAIL_COUNT = Convert.ToInt32(cust_order_detail_count);
            record.CUST_ORDER_DETAIL_UNIT = cust_order_detail_unit;
            record.CUST_ORDER_DETAIL_PRICE = Convert.ToDecimal(cust_order_detail_price);
            record.CUST_ORDER_DETAIL_TOTAL_PRICE = Convert.ToDecimal(cust_order_detail_total_price);
            record.CUST_ORDER_DETAIL_PS = cust_order_detail_ps;

            record.CUST_ORDER_DETAIL_CUSTOMIZED = Convert.ToInt16(cust_order_detail_customized);
            //record.FILEGROUP_UUID = filegroup_uuid;
            record.SUPPLIER_GOODS_UUID = supplier_goods_uuid;
            record.CUST_ORDER_DETAIL_IS_ACTIVE = Convert.ToInt16(cust_order_detail_is_active);



            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            else if (action == SubmitAction.Create)
            {
                record.gotoTable().Insert_Empty2Null(record);
                cust_order_detail_uuid = record.CUST_ORDER_DETAIL_UUID;
            }
            return record;
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            throw ex;
        }
    }

    public void _calCustOrderTotalPrice(string cust_order_uuid)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        //CustOrderDetail_Record record = new CustOrderDetail_Record();
        #endregion
        try
        {
            if (cust_order_uuid.Trim().Length > 0)
            {
                var allrecord = mod.getCustOrderDetail_By_CustOrderUuid(cust_order_uuid, new OrderLimit());
                decimal sum = 0;
                foreach (var item in allrecord)
                {
                    sum += item.CUST_ORDER_DETAIL_TOTAL_PRICE.Value;
                }
                var custOrder = mod.getCustOrder_By_CustOrderUuid(cust_order_uuid).AllRecord().First();
                custOrder.CUST_ORDER_TOTAL_PRICE = sum;
                custOrder.gotoTable().Update_Empty2Null(custOrder);
            }
            
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            throw ex;
        }
    }

    [DirectMethod("submitCustOrderDetailForFile", DirectAction.FormSubmission)]
    public JObject submitCustOrderDetailForFile(string cust_order_detail_uuid,
string cust_order_uuid,
string goods_uuid,
string cust_order_detail_goods_name,
string cust_order_detail_count,
string cust_order_detail_unit,
string cust_order_detail_price,
string cust_order_detail_total_price,
string cust_order_detail_ps,
string cust_order_detail_cr,
string cust_order_detail_customized,
string filegroup_uuid,
        string cust_order_detail_is_active,
string supplier_goods_uuid, Request request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        CustOrderDetail_Record record = new CustOrderDetail_Record();
        #endregion
        try
        {  /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*
             * 所有Form的動作最終是使用Submit的方式將資料傳出；
             * 必須有一個特徵來判斷使用者，執行的動作；
             */
            if (cust_order_detail_uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = mod.getCustOrderDetail_By_CustOrderDetailUuid(cust_order_detail_uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.CUST_ORDER_DETAIL_UUID = LK.Util.UID.Instance.GetUniqueID();
                record.CUST_ORDER_DETAIL_CR = DateTime.Now;
            }

            //record.CUST_ORDER_UUID = cust_order_uuid;
            //record.GOODS_UUID = goods_uuid;
            //record.CUST_ORDER_DETAIL_GOODS_NAME = cust_order_detail_goods_name;
            //record.CUST_ORDER_DETAIL_COUNT = Convert.ToInt16(cust_order_detail_count);
            //record.CUST_ORDER_DETAIL_UNIT = cust_order_detail_unit;
            //record.CUST_ORDER_DETAIL_PRICE = Convert.ToInt16(cust_order_detail_price);
            //record.CUST_ORDER_DETAIL_TOTAL_PRICE = Convert.ToInt16(cust_order_detail_total_price);
            //record.CUST_ORDER_DETAIL_PS = cust_order_detail_ps;
            //record.CUST_ORDER_DETAIL_CUSTOMIZED = Convert.ToInt16(cust_order_detail_customized);
            //record.SUPPLIER_GOODS_UUID = supplier_goods_uuid;


            //record.CUST_ORDER_DETAIL_IS_ACTIVE = Convert.ToInt16(cust_order_detail_is_active);

            #region 附件處理
            if (request.HttpRequest.Files.Count > 0)
            {
                if (request.HttpRequest.Files[0].FileName != "")
                {
                    //System.Web.HttpServerUtility a = new HttpServerUtility();
                    HttpServerUtility server = System.Web.HttpContext.Current.Server;

                    var uploadFolder = server.MapPath(Limew.Parameter.Config.ParemterConfigs.GetConfig().UploadFolder);
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(uploadFolder);
                    if (di.Exists == false)
                    {
                        di.Create();
                    }

                    //公司用的目錄
                    //uploadFolder = uploadFolder + getUser().COMPANY_ID + "//";

                    //di = new System.IO.DirectoryInfo(uploadFolder);
                    //if (di.Exists == false)
                    //{
                    //    di.Create();
                    //}

                    //頭像的folder
                    uploadFolder = uploadFolder + "custOrderDetail//";

                    di = new System.IO.DirectoryInfo(uploadFolder);
                    if (di.Exists == false)
                    {
                        di.Create();
                    }

                    string extName = "";
                    if (request.HttpRequest.Files[0].FileName.Split('.').Length > 1)
                    {
                        extName = request.HttpRequest.Files[0].FileName.Split('.').Last();
                    }

                    var fileUuid = LK.Util.UID.Instance.GetUniqueID();
                    string saveFilePath = "";
                    if (extName.Trim().Length > 0)
                    {
                        saveFilePath = uploadFolder + fileUuid + "." + extName;
                    }
                    else
                    {
                        saveFilePath = uploadFolder + fileUuid;
                    }

                    request.HttpRequest.Files[0].SaveAs(saveFilePath);
                    Filegroup_Record filegroup = new Filegroup_Record();
                    if (record.FILEGROUP_UUID.Trim().Length == 0)
                    {
                        record.FILEGROUP_UUID = LK.Util.UID.Instance.GetUniqueID();
                        filegroup.FILEGROUP_UUID = record.FILEGROUP_UUID;
                        filegroup.FILEGROUP_TAG = "custOrderDetail";
                        filegroup.gotoTable().Insert_Empty2Null(filegroup);
                    }
                    else
                    {
                        filegroup = mod.getFilegroup_By_FilegroupUuid(record.FILEGROUP_UUID).AllRecord().First();
                    }




                    File_Record f = new File_Record();
                    f.FILE_UUID = LK.Util.UID.Instance.GetUniqueID();
                    f.FILE_NAME = request.HttpRequest.Files[0].FileName;

                    f.FILE_PATH = Limew.Parameter.Config.ParemterConfigs.GetConfig().UploadFolder + "//custOrderDetail//" + fileUuid + "." + extName;
                    f.FILE_PS = "";
                    f.FILE_URL = Limew.Parameter.Config.ParemterConfigs.GetConfig().UploadFolder + "//custOrderDetail//" + fileUuid + "." + extName;
                    f.FILEGROUP_UUID = record.FILEGROUP_UUID;
                    f.FILE_CR = DateTime.Now;
                    f.gotoTable().Insert_Empty2Null(f);

                    var allFile = mod.getFile_By_FilegroupUuid(record.FILEGROUP_UUID);
                    var displayName = "";
                    short fileCount = 0;
                    foreach (var item in allFile)
                    {
                        displayName += item.FILE_NAME + ",";
                        fileCount++;
                    }
                    filegroup.FILEGROUP_DISPLAY_NAME = displayName;
                    filegroup.FILE_COUNT = fileCount;
                    filegroup.gotoTable().Update_Empty2Null(filegroup);
                    //record.FILEGROUP_UUID = Limew.Parameter.Config.ParemterConfigs.GetConfig().UploadFolder + this.getUser().COMPANY_ID + "//custOrderDetail//" + fileUuid + "." + extName;


                }
            }
            #endregion


            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            else if (action == SubmitAction.Create)
            {
                record.gotoTable().Insert(record);
                cust_order_detail_uuid = record.CUST_ORDER_DETAIL_UUID;
            }
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("CUST_ORDER_DETAIL_UUID", record.CUST_ORDER_DETAIL_UUID);
            otherParam.Add("FILEGROUP_UUID", record.FILEGROUP_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("destoryCustOrderDetail", DirectAction.Store)]
    public JObject destoryCustOrderDetail(string pCustOrderDetailUuid, Request request)
    {
        #region Declare
        LwModel mod = new LwModel();
        #endregion
        try
        {     /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得總資料數*/

            var data = mod.getCustOrderDetail_By_CustOrderDetailUuid(pCustOrderDetailUuid);
            if (data.AllRecord().Count > 0)
            {
                var delDr = data.AllRecord().First();
                var drCustOrder = mod.getCustOrder_By_CustOrderUuid(delDr.CUST_ORDER_UUID).AllRecord().First();
                if (drCustOrder.CUST_ORDER_STATUS_UUID == "COS_FINISH")
                {
                    throw new Exception("此訂單的狀態為完成，不可以刪除!");
                }
                else
                {
                    delDr.gotoTable().Delete(delDr);
                }

            }
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadCustOrderDetail", DirectAction.Store)]
    public JObject loadCustOrderDetail(string pCustOrderUuid, string pKeyword, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        LwModel mod = new LwModel();
        OrderLimit orderLimit = new OrderLimit();

        #endregion
        try
        {     /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得總資料數*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            var totalCount = mod.getCustOrderDetail_By_CustOrderUuid_Count(pCustOrderUuid);
            var data = mod.getCustOrderDetail_By_CustOrderUuid(pCustOrderUuid, orderLimit);
            if (data.Count > 0)
            {
                jobject = JsonHelper.RecordBaseListJObject(data.ToList());
            }
            else
            {
                totalCount = 0;
            }
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, totalCount);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("loadVCustOrderDetail", DirectAction.Store)]
    public JObject loadVCustOrderDetail(string pCustOrderUuid, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        LwModel mod = new LwModel();
        OrderLimit orderLimit = new OrderLimit();

        #endregion
        try
        {     /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得總資料數*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            var totalCount = mod.getVCustOrderDetail_By_CustOrderUuid_Count(pCustOrderUuid);
            var data = mod.getVCustOrderDetail_By_CustOrderUuid(pCustOrderUuid, orderLimit);
            if (data.Count > 0)
            {
                jobject = JsonHelper.RecordBaseListJObject(data.ToList());
            }
            else
            {
                totalCount = 0;
            }
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, totalCount);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("infoCustOrg", DirectAction.Load)]
    public JObject infoCustOrg(string pCustOrgUuid, Request request)
    {
        #region Declare
        LwModel model = new LwModel();
        #endregion

        try
        {  /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            var data = model.getCustOrg_By_CustOrgUuid(pCustOrgUuid);

            if (data.AllRecord().Count == 1)
            {
                return ExtDirect.Direct.Helper.Form.OutputJObject(JsonHelper.RecordBaseJObject(data.AllRecord().First()));
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Data Not Found!"));
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadCustOrg", DirectAction.Store)]
    public JObject loadCustOrg(string pCustUuid, string pKeyword, string pShowIsDefault,string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        Limew.Model.Basic.BasicModel model = new Limew.Model.Basic.BasicModel();
        LwModel mod = new LwModel();
        OrderLimit orderLimit = new OrderLimit();

        #endregion
        try
        {     /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得總資料數*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            var totalCount = mod.getCustOrg_By_Keyword_Count(pCustUuid, pKeyword,pShowIsDefault);
            var data = mod.getCustOrg_By_Keyword(pCustUuid, pKeyword,pShowIsDefault, orderLimit);
            if (data.Count > 0)
            {
                jobject = JsonHelper.RecordBaseListJObject(data.ToList());
            }
            else
            {
                totalCount = 0;
            }
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, totalCount);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadCustOrgAll", DirectAction.Store)]
    public JObject loadCustOrgAll(string pCustUuid, string pKeyword, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        Limew.Model.Basic.BasicModel model = new Limew.Model.Basic.BasicModel();
        LwModel mod = new LwModel();
        OrderLimit orderLimit = new OrderLimit();

        #endregion
        try
        {     /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得總資料數*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            var totalCount = mod.getCustOrg_By_Keyword_Count(pCustUuid, pKeyword);
            var data = mod.getCustOrg_By_Keyword(pCustUuid, pKeyword, orderLimit);
            if (data.Count > 0)
            {
                jobject = JsonHelper.RecordBaseListJObject(data.ToList());
            }
            else
            {
                totalCount = 0;
            }
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, totalCount);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("submitCustOrg", DirectAction.FormSubmission)]
    public JObject submitCustOrg(string cust_org_uuid,
                                    string cust_uuid,
                                    string cust_org_sales_name,
                                    string cust_org_sales_phone,
                                    string cust_org_sales_email,
                                    string cust_org_ps,
                                    string cust_org_name,
                                    string cust_org_is_active,
        string cust_org_address,Request request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        CustOrg_Record record = new CustOrg_Record();
        #endregion
        try
        {  /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*
             * 所有Form的動作最終是使用Submit的方式將資料傳出；
             * 必須有一個特徵來判斷使用者，執行的動作；
             */
            if (cust_org_uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = mod.getCustOrg_By_CustOrgUuid(cust_org_uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.CUST_ORG_UUID = LK.Util.UID.Instance.GetUniqueID();
            }
            record.CUST_UUID = cust_uuid;
            record.CUST_ORG_SALES_NAME = cust_org_sales_name;
            record.CUST_ORG_SALES_PHONE = cust_org_sales_phone;
            record.CUST_ORG_SALES_EMAIL = cust_org_sales_email;
            record.CUST_ORG_PS = cust_org_ps;
            record.CUST_ORG_NAME = cust_org_name;
            record.CUST_ORG_IS_ACTIVE = Convert.ToInt16(cust_org_is_active);
            record.CUST_ORG_ADDRESS = cust_org_address;
            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            else if (action == SubmitAction.Create)
            {
                record.gotoTable().Insert(record);
                cust_org_uuid = record.CUST_UUID;
            }
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("CUST_ORG_UUID", record.CUST_ORG_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("destoryCustOrg", DirectAction.Store)]
    public JObject destoryCustOrg(string pCustOrgUuid, Request request)
    {
        #region Declare
        LwModel mod = new LwModel();
        #endregion
        try
        {     /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得總資料數*/

            var data = mod.getCustOrg_By_CustOrgUuid(pCustOrgUuid);
            if (data.AllRecord().Count > 0)
            {
                var delDr = data.AllRecord().First();
                delDr.gotoTable().Delete(delDr);
            }
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadVCustOrder", DirectAction.Store)]
    public JObject loadVCustOrder(string pKeyword,string pCustOrderType,string pCompanyUuid,string pCustUuid,string pCustOrderStatusUuid,string pShippingStatusUuid, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        LwModel mod = new LwModel();
        OrderLimit orderLimit = new OrderLimit();

        #endregion
        try
        {     /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得總資料數*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            var totalCount = mod.getVCustOrder_By_Keyword_CustOrderTypeUuid_CompanyUuid_CustUuid_CustOrderStatus_ShippingStatusUuid_Count(pKeyword,pCustOrderType,pCompanyUuid,pCustUuid,pCustOrderStatusUuid,pShippingStatusUuid);
            var data = mod.getVCustOrder_By_Keyword_CustOrderTypeUuid_CompanyUuid_CustUuid_CustOrderStatus_ShippingStatusUuid(pKeyword, pCustOrderType, pCompanyUuid, pCustUuid, pCustOrderStatusUuid, pShippingStatusUuid, orderLimit);
            if (data.Count > 0)
            {
                jobject = JsonHelper.RecordBaseListJObject(data.ToList());
            }
            else
            {
                totalCount = 0;
            }
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Store.OutputJObject(jobject, totalCount);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("batchUpdateCustOrderDetail", DirectAction.Load)]
    public JObject batchUpdateCustOrderDetail(string allItem, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        LwModel mod = new LwModel();
        OrderLimit orderLimit = new OrderLimit();

        #endregion
        try
        {     /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得總資料數*/
            var drsUpdate = allItem.Split('|');
            foreach (var item in drsUpdate) {
                if (item.Trim().Length > 0) {
                    var data = item.Split(',');
                    var custOrderDetailUuid = data[0];
                    var custOrderDetailGoodsName = data[1];
                    var custOrderDetailPrice = data[2];
                    var custOrderDetailCount = data[3];
                    decimal? total = 0;

                    var drCustOrderDetail = mod.getCustOrderDetail_By_CustOrderDetailUuid(custOrderDetailUuid).AllRecord().First();
                    if (drCustOrderDetail.CUST_ORDER_DETAIL_CUSTOMIZED == 1) {
                        drCustOrderDetail.CUST_ORDER_DETAIL_GOODS_NAME = custOrderDetailGoodsName;
                    }

                    drCustOrderDetail.CUST_ORDER_DETAIL_COUNT = Convert.ToInt32(custOrderDetailCount);
                    drCustOrderDetail.CUST_ORDER_DETAIL_PRICE = Convert.ToDecimal(custOrderDetailPrice);
                    drCustOrderDetail.CUST_ORDER_DETAIL_TOTAL_PRICE = drCustOrderDetail.CUST_ORDER_DETAIL_COUNT * drCustOrderDetail.CUST_ORDER_DETAIL_PRICE;
                    drCustOrderDetail.gotoTable().Update_Empty2Null(drCustOrderDetail);
                }
            }
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


[DirectMethod("createCustOrderDetailCustomize", DirectAction.Load)]
    public JObject createCustOrderDetailCustomize(string custOrderUuid,string createNumber, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        LwModel mod = new LwModel();
        OrderLimit orderLimit = new OrderLimit();

        #endregion
        try
        {     /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得總資料數*/
            var i = System.Convert.ToInt32(createNumber);
            for (var j = 1; j <= i; j++) {
                //submitCustOrderDetail("", custOrderUuid, "", "", "1", "A0001", "0", "0","", "", "1", "", "1", "", request);
                _submitCustOrderDetail("", custOrderUuid, "", "", "1", "A0001", "0", "0", "", "", "1", "", "1", "");     
            };
            //_calCustOrderTotalPrice(record.CUST_ORDER_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    public string getCustOrderPath(string pCustOrderUuid,out string extName) {
        HttpServerUtility server = System.Web.HttpContext.Current.Server;
        var uploadFolder = server.MapPath(Limew.Parameter.Config.ParemterConfigs.GetConfig().UploadFolder);
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(uploadFolder);
        if (di.Exists == false)
        {
            di.Create();
        }

        uploadFolder = uploadFolder + "custOrder//";

        di = new System.IO.DirectoryInfo(uploadFolder);
        if (di.Exists == false)
        {
            di.Create();
        }
        extName = pCustOrderUuid+"-"+LK.Util.UID.Instance.GetUniqueID()+".pdf";

        return uploadFolder = uploadFolder + extName;
    }

    public string getShippingPath(string pCustOrderUuid, out string extName)
    {
        HttpServerUtility server = System.Web.HttpContext.Current.Server;
        var uploadFolder = server.MapPath(Limew.Parameter.Config.ParemterConfigs.GetConfig().UploadFolder);
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(uploadFolder);
        if (di.Exists == false)
        {
            di.Create();
        }

        uploadFolder = uploadFolder + "shipping//";

        di = new System.IO.DirectoryInfo(uploadFolder);
        if (di.Exists == false)
        {
            di.Create();
        }
        extName = pCustOrderUuid + "-" + LK.Util.UID.Instance.GetUniqueID() + ".pdf";

        return uploadFolder = uploadFolder + extName;
    }



    [DirectMethod("pdfLimew", DirectAction.Load)]
    public JObject pdfLimew(string pCustOrderUuid, Request request)
    {
        #region Declare
        LwModel model = new LwModel();
        #endregion
        pCustOrderUuid = "15031223373300495";
        try
        {  
            WebRequest req = WebRequest.Create("http://localhost/limew/pdftest.aspx");
            req.Timeout = 30 * 60 * 1000;
            WebResponse response = (WebResponse)req.GetResponse();
            var downloadfilename = "";     
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s, System.Text.Encoding.UTF8))
                {
                    var text = sr.ReadToEnd();
                    //Document doc = new Document(new Rectangle(9.5f * 72f, 5.5f * 72f), 40, 40, 10, 40);
                    Document doc = new Document(new Rectangle(9.5f * 72f, 5.5f * 72f), 40, 40, 10, 20);
                    HTMLWorker hw = new HTMLWorker(doc);
                    FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
                    @"\Fonts\simhei.ttf");//SimHei字體(中易黑體)
                    FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
                    @"\Fonts\MINGLIU.TTC");//細明體 & 新細明體
                    FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
                    @"\Fonts\KAIU.TTF");//標楷體
                    String fontPath = System.Environment.GetEnvironmentVariable("windir") +
                    @"\Fonts\MINGLIU.TTC";
                    XMLWorkerFontProvider fontImp = new XMLWorkerFontProvider(fontPath);
                    FontFactory.FontImp = fontImp;
                    FontFactory.Register(fontPath, "mingliu");
                    fontPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\..\Fonts\kaiu.ttf";
                    BaseFont bfChinese = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    BaseFont bfChineseUnderLine = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                                      
                    
                    Font fontChinese16 = new Font(bfChinese, 16f, Font.NORMAL);
                    Font fontChinese14 = new Font(bfChinese, 14f, Font.NORMAL);
                    Font fontChinese12 = new Font(bfChinese, 12f, Font.NORMAL); 
                    Font fontChinese10 = new Font(bfChinese, 10f, Font.NORMAL); 
                    Font fontChinese8 = new Font(bfChinese, 8f, Font.NORMAL);
                                 
                    var fileSavePath = getCustOrderPath(pCustOrderUuid,out downloadfilename);
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(fileSavePath, System.IO.FileMode.Create));
                    doc.Open();                    
                    doc.Add(new Paragraph(" ", fontChinese10));
                    writer.DirectContent.BeginText();
                    
                    writer.DirectContent.SetTextMatrix(250, 370);
                    writer.DirectContent.SetFontAndSize(bfChinese, 16);
                    writer.DirectContent.ShowText("利旻禮品文具有限公司" );

                    writer.DirectContent.SetTextMatrix(300, 350);
                    writer.DirectContent.SetFontAndSize(bfChinese, 14);                                        
                    writer.DirectContent.ShowText("估價單");
                    HttpServerUtility server = System.Web.HttpContext.Current.Server;
                    var url = server.MapPath("~/css/custImages/利旻禮品文具有限公司.jpg");                    
                    var img = Image.GetInstance(new Uri(url));
                    img.SetAbsolutePosition(525,328);
                    //原大小 240 * 180 ;
                    img.ScaleAbsolute( 80, 70);                    
                    doc.Add(img);
                    doc.Add(new Paragraph(" ", fontChinese10));
                    
                    PdfPTable tableH = new PdfPTable(new float[] { 120f, 40f });
                    tableH.WidthPercentage = 100;
                    PdfPCell cellH1 = new PdfPCell(new Phrase(""));
                    cellH1.BorderWidth = 0f;
                    cellH1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    cellH1.FixedHeight = 10;
                    tableH.AddCell(cellH1);
                    PdfPCell cellH2 = new PdfPCell(new Phrase("電話:", fontChinese10));
                    cellH2.HorizontalAlignment = 0;
                    cellH2.BorderWidthRight = 0f;
                    cellH2.BorderWidthTop = 0f;
                    cellH2.BorderWidthBottom = 0f;
                    cellH2.FixedHeight = 10;
                    tableH.AddCell(cellH2);

                    PdfPCell cellH3 = new PdfPCell(new Phrase(""));
                    cellH3.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    cellH3.BorderWidth = 0f;
                    cellH3.FixedHeight = 10;
                    tableH.AddCell(cellH3);
                    PdfPCell cellH4 = new PdfPCell(new Phrase("傳真:", fontChinese10));
                    cellH4.HorizontalAlignment = 0;
                    cellH4.FixedHeight = 10;
                    cellH4.BorderWidthRight = 0f;
                    cellH4.BorderWidthTop = 0f;
                    cellH4.BorderWidthBottom = 0f;
                    tableH.AddCell(cellH4);

                    PdfPCell cellH5 = new PdfPCell(new Phrase(""));
                    cellH5.BorderWidth = 0f;
                    cellH5.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    cellH5.FixedHeight = 10;
                    tableH.AddCell(cellH5);
                    PdfPCell cellH6 = new PdfPCell(new Phrase("地止:", fontChinese10));
                    cellH6.HorizontalAlignment = 0;
                    cellH6.FixedHeight = 10;
                    cellH6.BorderWidthRight = 0f;
                    cellH6.BorderWidthTop = 0f;
                    cellH6.BorderWidthBottom = 0f;
                    tableH.AddCell(cellH6);

                    PdfPCell cellH7 = new PdfPCell(new Phrase(""));
                    cellH7.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    cellH7.FixedHeight = 10;
                    cellH7.BorderWidth = 0f;
                    tableH.AddCell(cellH7);
                    PdfPCell cellH8 = new PdfPCell(new Phrase("信箱:", fontChinese10));
                    cellH8.HorizontalAlignment = 0;
                    cellH8.FixedHeight = 10;
                    cellH8.BorderWidthRight = 0f;
                    cellH8.BorderWidthTop = 0f;
                    cellH8.BorderWidthBottom = 0f;
                    tableH.AddCell(cellH8);

                    PdfPCell cellH9 = new PdfPCell(new Phrase(""));
                    cellH9.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    cellH9.BorderWidth = 0f;
                    cellH9.FixedHeight = 10;
                    tableH.AddCell(cellH9);
                    PdfPCell cellH10 = new PdfPCell(new Phrase("網址:", fontChinese10));
                    cellH10.HorizontalAlignment = 0;
                    cellH10.FixedHeight = 10;
                    cellH10.BorderWidthRight = 0f;
                    cellH10.BorderWidthTop = 0f;
                    cellH10.BorderWidthBottom = 0f;
                    tableH.AddCell(cellH10);

                    PdfPCell cellH11 = new PdfPCell(new Phrase(""));
                    cellH11.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    cellH11.BorderWidth = 0f;
                    cellH11.FixedHeight = 3;
                    tableH.AddCell(cellH11);
                    PdfPCell cellH12 = new PdfPCell(new Phrase(" ", fontChinese10));
                    cellH12.HorizontalAlignment = 0;
                    cellH12.FixedHeight = 3;
                    cellH12.BorderWidthRight = 0f;
                    cellH12.BorderWidthTop = 0f;
                    cellH12.BorderWidthBottom = 0f;
                    cellH12.BorderWidthLeft=0f;
                    tableH.AddCell(cellH12);
                    doc.Add(tableH);

                    writer.DirectContent.SetTextMatrix(500, 353);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);                    
                    writer.DirectContent.ShowText("電話：");

                    writer.DirectContent.SetTextMatrix(500, 343);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("傳真：");

                    writer.DirectContent.SetTextMatrix(500, 333);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("地址：");

                    writer.DirectContent.SetTextMatrix(500, 323);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("信箱：ac@limew.com.tw");

                    writer.DirectContent.SetTextMatrix(500, 313);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("網址：www.limew.com.tw");

                    PdfPTable table = new PdfPTable(new float[] { 5f, 10f, 20f, 20f, 5f, 15f, 0f, 10f, 15f, 15f, 30f });
                    table.WidthPercentage = 100;
                    table.SpacingAfter = 10f;                   
                    //第1行
                    #region 第一行
                    writer.DirectContent.SetTextMatrix(45, 343);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    var drCustOrder = model.getVCustOrder_By_CustOrderUuid(pCustOrderUuid).AllRecord().First();
                    writer.DirectContent.ShowText("客戶名稱：" + drCustOrder.CUST_NAME);
                    #endregion
                    //第2行
                    #region 
                    writer.DirectContent.SetTextMatrix(45, 333);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    if (drCustOrder.CUST_ORDER_PRINT_USER_NAME.Trim().Length > 0)
                    {
                        writer.DirectContent.ShowText("採購人員：" + drCustOrder.CUST_ORDER_PRINT_USER_NAME);
                    }
                    else
                    {
                        writer.DirectContent.ShowText("採購人員：" + drCustOrder.CUST_ORG_SALES_NAME);
                    }

                    #endregion
                    //第3行
                    #region
                    writer.DirectContent.SetTextMatrix(45, 323);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("客戶電話：" + drCustOrder.CUST_ORG_SALES_PHONE);

                    writer.DirectContent.SetTextMatrix(380, 323);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("單號：" + drCustOrder.CUST_ORDER_ID);
                    #endregion
                    //第4行
                    #region
                    writer.DirectContent.SetTextMatrix(45, 313);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("客戶地址：" + drCustOrder.CUST_ADDRESS);

                    writer.DirectContent.SetTextMatrix(380, 313);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("日期：" + drCustOrder.CUST_ORDER_REPORT_DATE.Value.ToString("yyyy/MM/dd"));
                    #endregion
                    //第一聯
                    #region
                    writer.DirectContent.SetTextMatrix(650, 298);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("第");

                    writer.DirectContent.SetTextMatrix(650, 288);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("一");

                    writer.DirectContent.SetTextMatrix(650, 278);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("聯");

                    writer.DirectContent.SetTextMatrix(652, 268);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText(":");

                    writer.DirectContent.SetTextMatrix(650, 258);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("會");

                    writer.DirectContent.SetTextMatrix(650, 248);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("計");

                    writer.DirectContent.SetTextMatrix(650, 238);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("聯");

                    #endregion
                    //第二聯
                    #region
                    writer.DirectContent.SetTextMatrix(650, 218);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("第");

                    writer.DirectContent.SetTextMatrix(650, 208);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("二");

                    writer.DirectContent.SetTextMatrix(650, 198);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("聯");

                    writer.DirectContent.SetTextMatrix(652, 188);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText(":");

                    writer.DirectContent.SetTextMatrix(650, 178);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("客");

                    writer.DirectContent.SetTextMatrix(650, 168);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("戶");

                    writer.DirectContent.SetTextMatrix(650, 158);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("聯");
                    #endregion

                    //第三聯
                    #region
                    writer.DirectContent.SetTextMatrix(650, 138);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("第");

                    writer.DirectContent.SetTextMatrix(650, 128);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("三");

                    writer.DirectContent.SetTextMatrix(650, 118);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("聯");

                    writer.DirectContent.SetTextMatrix(652, 108);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText(":");

                    writer.DirectContent.SetTextMatrix(650, 98);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("存");

                    writer.DirectContent.SetTextMatrix(650, 88);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("根");

                    writer.DirectContent.SetTextMatrix(650, 78);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("聯");
                    writer.DirectContent.EndText();

                    #endregion
                    //第4行
                    var cell1_1 = new PdfPCell(new Phrase("序",fontChinese10));
                    cell1_1.Colspan = 1;
                    cell1_1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    cell1_1.FixedHeight = 16;
                    table.AddCell(cell1_1);

                    var cell1_5 = new PdfPCell(new Phrase("商品名稱/規格", fontChinese10));
                    cell1_5.Colspan = 4;
                    cell1_5.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_5);

                    var cell1_6 = new PdfPCell(new Phrase("數量", fontChinese10));
                    cell1_6.Colspan = 1;
                    cell1_6.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_6);



                    var cell1_8 = new PdfPCell(new Phrase("單位", fontChinese10));
                    cell1_8.Colspan = 2;
                    cell1_8.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_8);

                    var cell1_9 = new PdfPCell(new Phrase("單價", fontChinese10));
                    cell1_9.Colspan = 1;
                    cell1_9.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_9);

                    var cell1_10 = new PdfPCell(new Phrase("金額", fontChinese10));
                    cell1_10.Colspan = 1;
                    cell1_10.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_10);

                    var cell1_11 = new PdfPCell(new Phrase("備註", fontChinese10));
                    cell1_11.Colspan = 1;
                    cell1_11.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_11);
                    var drVCustOrderDetail = model.getVCustOrderDetail_By_CustOrderUuid(pCustOrderUuid,new OrderLimit());
                    var rowCount = 0;
                    decimal sumMoney = 0;
                    foreach (var item in drVCustOrderDetail) {
                        rowCount++;
                        //序
                        var cellD_1 = new PdfPCell(new Phrase(rowCount.ToString(), fontChinese10));
                        cellD_1.Colspan = 1;
                        cellD_1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        cellD_1.FixedHeight = 16;
                        table.AddCell(cellD_1);
                        //品名規格
                        var cellD_5 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_GOODS_NAME, fontChinese10));
                        cellD_5.Colspan = 4;
                        cellD_5.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_5);
                        //數量
                        var cellD_6 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_COUNT.ToString(), fontChinese10));
                        cellD_6.Colspan = 1;
                        cellD_6.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_6);
                        //單位
                        var cellD_8 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_UNIT_NAME, fontChinese10));
                        cellD_8.Colspan = 2;
                        cellD_8.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_8);
                        //單價
                        var cellD_9 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_PRICE.ToString(), fontChinese10));
                        cellD_9.Colspan = 1;
                        cellD_9.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_9);
                        //金額
                        var cellD_10 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_TOTAL_PRICE.ToString(), fontChinese10));
                        cellD_10.Colspan = 1;
                        cellD_10.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_10);
                        //備註
                        var cellD_11 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_PS, fontChinese10));
                        cellD_11.Colspan = 1;
                        cellD_11.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_11);
                        sumMoney += item.CUST_ORDER_DETAIL_TOTAL_PRICE.Value;                        
                    }
                    //資料
                    for (int i = rowCount+1; i < 16; i++)
                    {
                        //序
                        var cellD_1 = new PdfPCell(new Phrase(i.ToString(), fontChinese10));
                        cellD_1.Colspan = 1;
                        cellD_1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        cellD_1.FixedHeight = 16;
                        table.AddCell(cellD_1);
                        //品名規格
                        var cellD_5 = new PdfPCell(new Phrase("" , fontChinese10));
                        cellD_5.Colspan = 4;
                        cellD_5.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_5);
                        //數量
                        var cellD_6 = new PdfPCell(new Phrase("", fontChinese10));
                        cellD_6.Colspan = 1;
                        cellD_6.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_6);
                        //單位
                        var cellD_8 = new PdfPCell(new Phrase("", fontChinese10));
                        cellD_8.Colspan = 2;
                        cellD_8.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_8);
                        //單價
                        var cellD_9 = new PdfPCell(new Phrase("", fontChinese10));
                        cellD_9.Colspan = 1;
                        cellD_9.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_9);
                        //金額
                        var cellD_10 = new PdfPCell(new Phrase("", fontChinese10));
                        cellD_10.Colspan = 1;
                        cellD_10.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_10);
                        //備註
                        var cellD_11 = new PdfPCell(new Phrase("", fontChinese10));
                        cellD_11.Colspan = 1;
                        cellD_11.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_11);      
                    }
                    //var cell2_2 = new PdfPCell(new Phrase("小計", fontChinese10));
                    //cell2_2.Colspan = 2;
                    //cell2_2.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //cell2_2.FixedHeight = 16;
                    //table.AddCell(cell2_2);

                    //var cell2_3 = new PdfPCell(new Phrase("NT$ "+sumMoney.ToString(), fontChinese10));
                    //cell2_3.Colspan = 1;
                    //cell2_3.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //table.AddCell(cell2_3);

                    //var cell2_4 = new PdfPCell(new Phrase("營業稅", fontChinese10));
                    //cell2_4.Colspan = 1;
                    
                    //cell2_4.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //table.AddCell(cell2_4);

                    //string hasTax = "含稅";
                    //if (drCustOrder.CUST_ORDER_HAS_TAX != 1) {
                    //    hasTax = "未稅";
                    //}
                    //var cell2_7 = new PdfPCell(new Phrase(hasTax, fontChinese10));
                    //cell2_7.Colspan = 3;
                    //cell2_7.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //table.AddCell(cell2_7);

                    //var cell2_9 = new PdfPCell(new Phrase("合計", fontChinese10));
                    //cell2_9.Colspan =2;
                    //cell2_9.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //table.AddCell(cell2_9);

                    //string showMoney = "";
                    //if (drCustOrder.CUST_ORDER_HAS_TAX != 1)
                    //{
                    //    showMoney = (sumMoney * Convert.ToDecimal(1.05)).ToString();
                    //}
                    //else {
                    //    showMoney = sumMoney.ToString();
                    //}
                    //var cell2_11 = new PdfPCell(new Phrase("NT$ " + showMoney, fontChinese12));
                    //cell2_11.Colspan = 2;
                    //cell2_11.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                    //table.AddCell(cell2_11);
                    //var cell3_2 = new PdfPCell(new Phrase("備註", fontChinese10));
                    //cell3_2.Colspan = 2;
                    //cell3_2.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //cell3_2.FixedHeight = 32;
                    //table.AddCell(cell3_2);
                    var cell3_11 = new PdfPCell(new Phrase("總額新臺幣 " + ConvertSum( sumMoney.ToString() ) +"  NT$ "+sumMoney.ToString(), fontChinese10));
                    cell3_11.FixedHeight = 16;
                    cell3_11.Colspan = 11;
                    cell3_11.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell3_11);   
                    doc.Add(table);
                    doc.Close();                    
                    sr.Close();
               }
            }
            System.Collections.Hashtable ht = new Hashtable();
            ht.Add("file", downloadfilename);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(ht);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("pdfShipping", DirectAction.Load)]
    public JObject pdfShipping(string pCustOrderUuid, Request request)
    {
        #region Declare
        LwModel model = new LwModel();
        //pCustOrderUuid = "15031223373300495";
        #endregion        
        try
        {  /*Cloud身份檢查*/           
            WebRequest req = WebRequest.Create("http://localhost/limew/pdftest.aspx");
            req.Timeout = 30 * 60 * 1000;           
            WebResponse response = (WebResponse)req.GetResponse();
            var downloadfilename = "";
            var drCustOrder = model.getVCustOrder_By_CustOrderUuid(pCustOrderUuid).AllRecord().First();
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s, System.Text.Encoding.UTF8))
                {
                    var text = sr.ReadToEnd();                    
                    Document doc = new Document(new Rectangle(9.5f * 72f, 5.5f * 72f), 40, 40, 10, 40);
                    HTMLWorker hw = new HTMLWorker(doc);                  
                    FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
                    @"\Fonts\simhei.ttf");//SimHei字體(中易黑體)
                    FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
                    @"\Fonts\MINGLIU.TTC");//細明體 & 新細明體
                    FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
                    @"\Fonts\KAIU.TTF");//標楷體
                    String fontPath = System.Environment.GetEnvironmentVariable("windir") +
                    @"\Fonts\MINGLIU.TTC";
                    XMLWorkerFontProvider fontImp = new XMLWorkerFontProvider(fontPath);
                    FontFactory.FontImp = fontImp;
                    FontFactory.Register(fontPath, "mingliu");
                    fontPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\..\Fonts\kaiu.ttf";
                    BaseFont bfChinese = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    Font fontChinese16 = new Font(bfChinese, 16f, Font.NORMAL);
                    Font fontChinese14 = new Font(bfChinese, 14f, Font.NORMAL);
                    Font fontChinese12 = new Font(bfChinese, 12f, Font.NORMAL); //title
                    Font fontChinese10 = new Font(bfChinese, 10f, Font.NORMAL); //table title , 第一聯
                    Font fontChinese8 = new Font(bfChinese, 8f, Font.NORMAL);

                    var fileSavePath = getShippingPath(pCustOrderUuid, out downloadfilename);
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(fileSavePath, System.IO.FileMode.Create));
                    doc.Open();
                    doc.Add(new Paragraph(" ", fontChinese10));
                    writer.DirectContent.BeginText();

                    writer.DirectContent.SetTextMatrix(310, 370);
                    writer.DirectContent.SetFontAndSize(bfChinese, 15);
                    writer.DirectContent.ShowText("出 貨 單");

                    writer.DirectContent.SetTextMatrix(40, 360);
                    writer.DirectContent.SetFontAndSize(bfChinese, 12);
                    if (drCustOrder.CUST_ORDER_SHIPPING_DATE != null)
                    {
                        writer.DirectContent.ShowText("出貨日期：" + drCustOrder.CUST_ORDER_SHIPPING_DATE.Value.ToString("yyyy/MM/dd"));
                    }
                    else {
                        writer.DirectContent.ShowText("出貨日期：" );
                    }
                   

                    writer.DirectContent.SetTextMatrix(500, 360);
                    writer.DirectContent.SetFontAndSize(bfChinese, 12);
                    writer.DirectContent.ShowText("出貨單號：" );
                    
                   
                    doc.Add(new Chunk("\n"));
                    //PdfPTable table = new PdfPTable(11);
                    //                                             1    2    3    4   5      6  
                    PdfPTable table = new PdfPTable(new float[] { 5f, 30f, 15f, 10f, 15f, 20f});
                    table.WidthPercentage = 100;
                    table.SpacingAfter = 10f;
                    PdfPCell cell = new PdfPCell(new Phrase(""));
                    cell.Colspan = 6;
                    cell.FixedHeight = 30f;
                    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell);
                    //第1行
                    writer.DirectContent.SetTextMatrix(45, 338);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    

                    writer.DirectContent.ShowText("客戶名稱：" + drCustOrder.CUST_NAME);

                    writer.DirectContent.SetTextMatrix(280, 338);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    if (drCustOrder.CUST_ORDER_PRINT_USER_NAME.Trim().Length > 0) {
                        writer.DirectContent.ShowText("採購人員：" + drCustOrder.CUST_ORDER_PRINT_USER_NAME);
                    }
                    else
                    {
                        writer.DirectContent.ShowText("採購人員：" + drCustOrder.CUST_ORG_SALES_NAME);
                    }
                    


                    writer.DirectContent.SetTextMatrix(450, 338);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("客戶地址：" + drCustOrder.CUST_ADDRESS);

                    //writer.DirectContent.SetTextMatrix(550, 328);
                    //writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    //writer.DirectContent.ShowText("報價日期：" + drCustOrder.CUST_ORDER_REPORT_DATE.Value.ToString("yyyy/MM/dd"));
                    //第2行
                    writer.DirectContent.SetTextMatrix(45, 328);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("單位部門：" + drCustOrder.CUST_ORG_NAME);

                    writer.DirectContent.SetTextMatrix(280, 328);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("聯絡電話：" + drCustOrder.CUST_ORG_SALES_PHONE);

                    writer.DirectContent.SetTextMatrix(450, 328);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("交貨地址："+drCustOrder.SHIPPING_ADDRESS );

                    //writer.DirectContent.SetTextMatrix(550, 318);
                    //writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    //writer.DirectContent.ShowText("報價單號：XXXXXXXXXXX");
                   
                    //第一聯
                    writer.DirectContent.SetTextMatrix(650, 328);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("第");

                    writer.DirectContent.SetTextMatrix(650, 318);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("一");

                    writer.DirectContent.SetTextMatrix(650, 308);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("聯");

                    writer.DirectContent.SetTextMatrix(652, 298);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText(":");

                    writer.DirectContent.SetTextMatrix(650, 288);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("客");

                    writer.DirectContent.SetTextMatrix(650, 278);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("戶");



                    //第二聯
                    writer.DirectContent.SetTextMatrix(650, 248);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("第");

                    writer.DirectContent.SetTextMatrix(650, 238);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("二");

                    writer.DirectContent.SetTextMatrix(650, 228);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("聯");

                    writer.DirectContent.SetTextMatrix(652, 218);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText(":");

                    writer.DirectContent.SetTextMatrix(650, 208);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("會");

                    writer.DirectContent.SetTextMatrix(650, 198);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("計");


                    //第三聯
                    writer.DirectContent.SetTextMatrix(650, 168);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("第");

                    writer.DirectContent.SetTextMatrix(650, 158);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("三");

                    writer.DirectContent.SetTextMatrix(650, 148);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("聯");

                    writer.DirectContent.SetTextMatrix(652, 138);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText(":");

                    writer.DirectContent.SetTextMatrix(650, 128);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("存");

                    writer.DirectContent.SetTextMatrix(650, 118);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("根");

                    writer.DirectContent.EndText();


                    //第4行
                    var cell1_1 = new PdfPCell(new Phrase("序", fontChinese10));
                    cell1_1.Colspan = 1;
                    cell1_1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    cell1_1.FixedHeight = 16;
                    table.AddCell(cell1_1);

                    var cell1_2 = new PdfPCell(new Phrase("品名規格", fontChinese10));
                    //cell1_5.Colspan = 4;
                    cell1_2.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_2);

                    var cell1_3 = new PdfPCell(new Phrase("訂購數量", fontChinese10));
                    //cell1_3.Colspan = 1;
                    cell1_3.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_3);



                    var cell1_4 = new PdfPCell(new Phrase("單位", fontChinese10));
                    //cell1_4.Colspan = 2;
                    cell1_4.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_4);

                    var cell1_5 = new PdfPCell(new Phrase("出貨數量", fontChinese10));
                    //cell1_5.Colspan = 1;
                    cell1_5.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_5);

                   

                    var cell1_6 = new PdfPCell(new Phrase("備註", fontChinese10));
                    //cell1_6.Colspan = 1;
                    cell1_6.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_6);

                    var drVCustOrderDetail = model.getVCustOrderDetail_By_CustOrderUuid(pCustOrderUuid, new OrderLimit());
                    var rowCount = 0;
                    //decimal sumMoney = 0;
                    foreach (var item in drVCustOrderDetail)
                    {
                        rowCount++;
                        //序
                        var cellD_1 = new PdfPCell(new Phrase(rowCount.ToString(), fontChinese10));
                        //cellD_1.Colspan = 1;
                        cellD_1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        cellD_1.FixedHeight = 16;
                        table.AddCell(cellD_1);
                        //品名規格
                        var cellD_2 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_GOODS_NAME, fontChinese10));
                        //cellD_5.Colspan = 4;
                        cellD_2.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_2);
                        //訂購數量
                        var cellD_3 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_COUNT.ToString(), fontChinese10));
                        //cellD_3.Colspan = 1;
                        cellD_3.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_3);
                        //單位
                        var cellD_4 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_UNIT_NAME, fontChinese10));
                        //cellD_4.Colspan = 2;
                        cellD_4.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_4);

                        //出貨數量
                        var cellD_5 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_UNIT_NAME, fontChinese10));
                        //cellD_4.Colspan = 2;
                        cellD_5.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_5);

                        
                        //備註
                        var cellD_6 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_PS, fontChinese10));
                        cellD_6.Colspan = 1;
                        cellD_6.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_6);
                        //sumMoney += item.CUST_ORDER_DETAIL_TOTAL_PRICE.Value;
                    }
                    //資料
                    for (int i = rowCount + 1; i < 15; i++)
                    {
                        //序
                        var cellD_1 = new PdfPCell(new Phrase(i.ToString(), fontChinese10));
                        //cellD_1.Colspan = 1;
                        cellD_1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        cellD_1.FixedHeight = 16;
                        table.AddCell(cellD_1);
                        //品名規格
                        var cellD_2 = new PdfPCell(new Phrase("", fontChinese10));
                        //cellD_5.Colspan = 4;
                        cellD_2.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_2);
                        //訂購數量
                        var cellD_3 = new PdfPCell(new Phrase("", fontChinese10));
                        //cellD_6.Colspan = 1;
                        cellD_3.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_3);
                        //單位
                        var cellD_4 = new PdfPCell(new Phrase("", fontChinese10));
                        //cellD_8.Colspan = 2;
                        cellD_4.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_4);
                        //出貨數量
                        var cellD_5 = new PdfPCell(new Phrase("", fontChinese10));
                        //cellD_9.Colspan = 1;
                        cellD_5.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_5);
                        
                        //備註
                        var cellD_6 = new PdfPCell(new Phrase("", fontChinese10));
                        //cellD_11.Colspan = 1;
                        cellD_6.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_6);
                    }

                    var cellF1 = new PdfPCell(new Phrase("製單：                      倉庫：                      會計：                      配送：", fontChinese10));
                    cellF1.Colspan = 5;
                    cellF1.FixedHeight = 40f;
                    cellF1.BorderWidthBottom = 0f;
                    cellF1.BorderWidthLeft = 0f;
                    table.AddCell(cellF1);

                    var cellF2 = new PdfPCell(new Phrase("客戶簽收：", fontChinese10));
                    cellF2.Colspan = 5;
                    table.AddCell(cellF2);



                    //var cell2_2 = new PdfPCell(new Phrase("小計", fontChinese10));
                    //cell2_2.Colspan = 2;
                    //cell2_2.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //cell2_2.FixedHeight = 16;
                    //table.AddCell(cell2_2);

                    //var cell2_3 = new PdfPCell(new Phrase("NT$ " + sumMoney.ToString(), fontChinese10));
                    //cell2_3.Colspan = 1;
                    //cell2_3.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //table.AddCell(cell2_3);

                    //var cell2_4 = new PdfPCell(new Phrase("營業稅", fontChinese10));
                    //cell2_4.Colspan = 1;

                    //cell2_4.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //table.AddCell(cell2_4);

                    //string hasTax = "含稅";
                    //if (drCustOrder.CUST_ORDER_HAS_TAX != 1)
                    //{
                    //    hasTax = "未稅";
                    //}
                    //var cell2_7 = new PdfPCell(new Phrase(hasTax, fontChinese10));
                    //cell2_7.Colspan = 3;
                    //cell2_7.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //table.AddCell(cell2_7);

                    //var cell2_9 = new PdfPCell(new Phrase("合計", fontChinese10));
                    //cell2_9.Colspan = 2;
                    //cell2_9.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //table.AddCell(cell2_9);

                    //string showMoney = "";
                    //if (drCustOrder.CUST_ORDER_HAS_TAX != 1)
                    //{
                    //    showMoney = (sumMoney * Convert.ToDecimal(1.05)).ToString();
                    //}
                    //else
                    //{
                    //    showMoney = sumMoney.ToString();
                    //}
                    //var cell2_11 = new PdfPCell(new Phrase("NT$ " + showMoney, fontChinese12));
                    //cell2_11.Colspan = 2;
                    //cell2_11.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                    //table.AddCell(cell2_11);
                    //var cell3_2 = new PdfPCell(new Phrase("備註", fontChinese10));
                    //cell3_2.Colspan = 2;
                    //cell3_2.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //cell3_2.FixedHeight = 32;
                    //table.AddCell(cell3_2);
                    //var cell3_11 = new PdfPCell(new Phrase(drCustOrder.CUST_ORDER_PS, fontChinese10));
                    //cell3_11.Colspan = 9;
                    //cell3_11.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                    //table.AddCell(cell3_11);
                    doc.Add(table);
                    doc.Close();
                    sr.Close();
                }
            }
            System.Collections.Hashtable ht = new Hashtable();
            ht.Add("file", downloadfilename);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(ht);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("pdfW", DirectAction.Load)]
    public JObject pdfW(string pCustOrderUuid, Request request)
    {
        #region Declare
        LwModel model = new LwModel();
        #endregion
        //pCustOrderUuid = "15031223373300495";
        try
        {   WebRequest req = WebRequest.Create("http://localhost/limew/pdftest.aspx");
            req.Timeout = 30 * 60 * 1000;
            var downloadfilename = "";
            WebResponse response = (WebResponse)req.GetResponse();

            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s, System.Text.Encoding.UTF8))
                {
                    var text = sr.ReadToEnd();
                    Document doc = new Document(new Rectangle(9.5f * 72f, 5.5f * 72f), 40, 40, 10, 20);
                    HTMLWorker hw = new HTMLWorker(doc);
                    FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
                    @"\Fonts\simhei.ttf");//SimHei字體(中易黑體)
                    FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
                    @"\Fonts\MINGLIU.TTC");//細明體 & 新細明體                    
                    String fontPath = System.Environment.GetEnvironmentVariable("windir") +
                    @"\Fonts\MINGLIU.TTC";
                    XMLWorkerFontProvider fontImp = new XMLWorkerFontProvider(fontPath);
                    FontFactory.FontImp = fontImp;
                    FontFactory.Register(fontPath);

                     var drCustOrder = model.getVCustOrder_By_CustOrderUuid(pCustOrderUuid).AllRecord().First();
                    fontPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\..\Fonts\kaiu.ttf";
                    BaseFont bfChinese = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    Font fontChinese16 = new Font(bfChinese, 16f, Font.NORMAL);
                    Font fontChinese14 = new Font(bfChinese, 14f, Font.NORMAL);
                    Font fontChinese12 = new Font(bfChinese, 12f, Font.NORMAL); 
                    Font fontChinese10 = new Font(bfChinese, 10f, Font.NORMAL); 
                    Font fontChinese8 = new Font(bfChinese, 8f, Font.NORMAL);
                    
                    var fileSavePath = getCustOrderPath(pCustOrderUuid, out downloadfilename);
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(fileSavePath, System.IO.FileMode.Create));
                    doc.Open();
                    doc.Add(new Chunk("\n"));
                    writer.DirectContent.BeginText();

                    doc.Add(new Paragraph(" ", fontChinese10));
                    doc.Add(new Paragraph(" ", fontChinese10));

                    writer.DirectContent.SetTextMatrix(250, 380);
                    writer.DirectContent.SetFontAndSize(bfChinese, 14);
                    writer.DirectContent.ShowText("韋成企業商行    估價單");



                    writer.DirectContent.SetTextMatrix(40, 345);
                    writer.DirectContent.SetFontAndSize(bfChinese, 12);
                    writer.DirectContent.ShowText("日期：" + drCustOrder.CUST_ORDER_REPORT_DATE.Value.ToString("yyyy/MM/dd") );

                    writer.DirectContent.SetTextMatrix(240, 345);
                    writer.DirectContent.SetFontAndSize(bfChinese, 12);
                    writer.DirectContent.ShowText("單號:" + drCustOrder.CUST_ORDER_ID);


                    writer.DirectContent.SetTextMatrix(40, 330);
                    writer.DirectContent.SetFontAndSize(bfChinese, 12);
                    writer.DirectContent.ShowText("客戶：" + drCustOrder.CUST_NAME );
                   

                    if (drCustOrder.CUST_ORDER_PRINT_USER_NAME.Trim().Length > 0)
                    {
                        writer.DirectContent.SetTextMatrix(240, 330);
                        writer.DirectContent.SetFontAndSize(bfChinese, 12);
                        writer.DirectContent.ShowText("單位:" + drCustOrder.CUST_ORG_NAME + "          採購：" + drCustOrder.CUST_ORDER_PRINT_USER_NAME + "          電話：" + drCustOrder.CUST_ORG_SALES_PHONE);
                    }
                    else
                    {
                        writer.DirectContent.SetTextMatrix(240, 330);
                        writer.DirectContent.SetFontAndSize(bfChinese, 12);
                        writer.DirectContent.ShowText("單位:" + drCustOrder.CUST_ORG_NAME + "          採購：" + drCustOrder.CUST_ORG_SALES_NAME + "          電話：" + drCustOrder.CUST_ORG_SALES_PHONE);
                    }
                    
                    //293 204
                    HttpServerUtility server = System.Web.HttpContext.Current.Server;
                    var url = server.MapPath("~/css/custImages/韋成企業商行.jpg");
                    var img = Image.GetInstance(new Uri(url));
                    img.SetAbsolutePosition(572,325);
                    //原大小 240 * 180 ;
                    img.ScaleAbsolute( 100, 75);                    
                    doc.Add(img);                    
                    doc.Add(new Chunk("\n"));
                    //                                             1    2    3    4   5      6  7    8     9   10   11
                    PdfPTable table = new PdfPTable(new float[] { 5f, 10f, 20f, 20f, 5f, 15f, 0f, 10f, 15f, 15f, 30 });
                    table.WidthPercentage = 100;
                    table.SpacingAfter = 10f;
                    PdfPCell cell = new PdfPCell(new Phrase(""));
                    cell.Colspan =11;                    
                    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell);                                      
                    writer.DirectContent.EndText();                     
                    //第4行
                    var cell1_1 = new PdfPCell(new Phrase("序",fontChinese10));
                    cell1_1.Colspan = 1;
                    cell1_1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    cell1_1.FixedHeight = 16;
                    table.AddCell(cell1_1);

                    var cell1_5 = new PdfPCell(new Phrase("品名規格", fontChinese10));
                    cell1_5.Colspan = 4;
                    cell1_5.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_5);

                    var cell1_6 = new PdfPCell(new Phrase("數量", fontChinese10));
                    cell1_6.Colspan = 1;
                    cell1_6.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_6);



                    var cell1_8 = new PdfPCell(new Phrase("單位", fontChinese10));
                    cell1_8.Colspan = 2;
                    cell1_8.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_8);

                    var cell1_9 = new PdfPCell(new Phrase("單價", fontChinese10));
                    cell1_9.Colspan = 1;
                    cell1_9.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_9);

                    var cell1_10 = new PdfPCell(new Phrase("金額", fontChinese10));
                    cell1_10.Colspan = 1;
                    cell1_10.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_10);

                    var cell1_11 = new PdfPCell(new Phrase("備註", fontChinese10));
                    cell1_11.Colspan = 1;
                    cell1_11.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_11);
                    var drVCustOrderDetail = model.getVCustOrderDetail_By_CustOrderUuid(pCustOrderUuid,new OrderLimit());
                    var rowCount = 0;
                    decimal sumMoney = 0;
                    foreach (var item in drVCustOrderDetail) {
                        rowCount++;
                        //序
                        var cellD_1 = new PdfPCell(new Phrase(rowCount.ToString(), fontChinese10));
                        cellD_1.Colspan = 1;
                        cellD_1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        cellD_1.FixedHeight = 16;
                        table.AddCell(cellD_1);
                        //品名規格
                        var cellD_5 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_GOODS_NAME, fontChinese10));
                        cellD_5.Colspan = 4;
                        cellD_5.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_5);
                        //數量
                        var cellD_6 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_COUNT.ToString(), fontChinese10));
                        cellD_6.Colspan = 1;
                        cellD_6.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_6);
                        //單位
                        var cellD_8 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_UNIT_NAME, fontChinese10));
                        cellD_8.Colspan = 2;
                        cellD_8.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_8);
                        //單價
                        var cellD_9 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_PRICE.ToString(), fontChinese10));
                        cellD_9.Colspan = 1;
                        cellD_9.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_9);
                        //金額
                        var cellD_10 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_TOTAL_PRICE.ToString(), fontChinese10));
                        cellD_10.Colspan = 1;
                        cellD_10.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_10);
                        //備註
                        var cellD_11 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_PS, fontChinese10));
                        cellD_11.Colspan = 1;
                        cellD_11.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_11);
                        sumMoney += item.CUST_ORDER_DETAIL_TOTAL_PRICE.Value;                        
                    }
                    //資料
                    for (int i = rowCount+1; i < 17; i++)
                    {
                        //序
                        var cellD_1 = new PdfPCell(new Phrase(i.ToString(), fontChinese10));
                        cellD_1.Colspan = 1;
                        cellD_1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        cellD_1.FixedHeight = 16;
                        table.AddCell(cellD_1);
                        //品名規格
                        var cellD_5 = new PdfPCell(new Phrase("" , fontChinese10));
                        cellD_5.Colspan = 4;
                        cellD_5.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_5);
                        //數量
                        var cellD_6 = new PdfPCell(new Phrase("", fontChinese10));
                        cellD_6.Colspan = 1;
                        cellD_6.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_6);
                        //單位
                        var cellD_8 = new PdfPCell(new Phrase("", fontChinese10));
                        cellD_8.Colspan = 2;
                        cellD_8.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_8);
                        //單價
                        var cellD_9 = new PdfPCell(new Phrase("", fontChinese10));
                        cellD_9.Colspan = 1;
                        cellD_9.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_9);
                        //金額
                        var cellD_10 = new PdfPCell(new Phrase("", fontChinese10));
                        cellD_10.Colspan = 1;
                        cellD_10.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_10);
                        //備註
                        var cellD_11 = new PdfPCell(new Phrase("", fontChinese10));
                        cellD_11.Colspan = 1;
                        cellD_11.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_11);
                        
                        
                    }
                    string chinessMoney = "總額新臺幣 ";
                    chinessMoney += ConvertSum(sumMoney.ToString());

                    //var cell2_2 = new PdfPCell(new Phrase("總額新臺幣    零 拾    零 萬    伍 仟    伍 佰    零 拾    零 元整", fontChinese12));
                    var cell2_2 = new PdfPCell(new Phrase(chinessMoney, fontChinese12));
                    cell2_2.Colspan = 9;
                    cell2_2.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                    cell2_2.FixedHeight = 20;
                    table.AddCell(cell2_2);
                    var cell2_3 = new PdfPCell(new Phrase("NT$ " + sumMoney.ToString(), fontChinese12));
                    cell2_3.Colspan = 9;
                    cell2_3.FixedHeight = 20;
                    cell2_3.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell2_3);
                    doc.Add(table);
                    writer.DirectContent.BeginText();
                    writer.DirectContent.SetTextMatrix(40, 20);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("製單："+drCustOrder.CUST_ORDER_REPORT_ATTENDANT_C_NAME+"          備註："+drCustOrder.CUST_ORDER_PS);
                    writer.DirectContent.EndText(); 
                    doc.Close();                    
                    sr.Close();
                }

            }



            System.Collections.Hashtable ht = new Hashtable();
            ht.Add("file", downloadfilename);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(ht);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    public string ConvertSum(string str)
    {
        if (!IsPositveDecimal(str))
            return "輸入的不是正數字！";
        if (Double.Parse(str) > 999999999999.99)
            return "數字太大，無法換算，請輸入一萬億元以下的金額";
        char[] ch = new char[1];
        ch[0] = '.'; //小數點
        string[] splitstr = null; //定義按小數點分割後的字符串數組
        splitstr = str.Split(ch[0]);//按小數點分割字符串
        if (splitstr.Length == 1) //只有整數部分
            return ConvertData(str) + "圓整";
        else //有小數部分
        {
            string rstr;
            rstr = ConvertData(splitstr[0]) + "圓";//轉換整數部分
            rstr += ConvertXiaoShu(splitstr[1]);//轉換小數部分
            return rstr;
        }

    }
    /// 
    /// 判斷是否是正數字字符串
    /// 
    /// 判斷字符串
    /// 如果是數字，返回true，否則返回false
    public bool IsPositveDecimal(string str)
    {
        Decimal d;
        try
        {
            d = Decimal.Parse(str);

        }
        catch (Exception)
        {
            return false;
        }
        if (d > 0)
            return true;
        else
            return false;
    }
    /// 
    /// 轉換數字（整數）
    /// 
    /// 需要轉換的整數數字字符串
    /// 轉換成中文大寫後的字符串
    public string ConvertData(string str)
    {
        string tmpstr = "";
        string rstr = "";
        int strlen = str.Length;
        if (strlen <= 4)//數字長度小于四位
        {
            rstr = ConvertDigit(str);

        }
        else
        {

            if (strlen <= 8)//數字長度大于四位，小于八位
            {
                tmpstr = str.Substring(strlen - 4, 4);//先截取最後四位數字
                rstr = ConvertDigit(tmpstr);//轉換最後四位數字
                tmpstr = str.Substring(0, strlen - 4);//截取其余數字
                //將兩次轉換的數字加上萬後相連接
                rstr = String.Concat(ConvertDigit(tmpstr) + "萬", rstr);
                rstr = rstr.Replace("零萬", "萬");
                rstr = rstr.Replace("零零", "零");

            }
            else
                if (strlen <= 12)//數字長度大于八位，小于十二位
                {
                    tmpstr = str.Substring(strlen - 4, 4);//先截取最後四位數字
                    rstr = ConvertDigit(tmpstr);//轉換最後四位數字
                    tmpstr = str.Substring(strlen - 8, 4);//再截取四位數字
                    rstr = String.Concat(ConvertDigit(tmpstr) + "萬", rstr);
                    tmpstr = str.Substring(0, strlen - 8);
                    rstr = String.Concat(ConvertDigit(tmpstr) + "億", rstr);
                    rstr = rstr.Replace("零億", "億");
                    rstr = rstr.Replace("零萬", "零");
                    rstr = rstr.Replace("零零", "零");
                    rstr = rstr.Replace("零零", "零");
                }
        }
        strlen = rstr.Length;
        if (strlen >= 2)
        {
            switch (rstr.Substring(strlen - 2, 2))
            {
                case "佰零": rstr = rstr.Substring(0, strlen - 2) + "佰"; break;
                case "仟零": rstr = rstr.Substring(0, strlen - 2) + "仟"; break;
                case "萬零": rstr = rstr.Substring(0, strlen - 2) + "萬"; break;
                case "億零": rstr = rstr.Substring(0, strlen - 2) + "億"; break;

            }
        }
        return rstr;
    }
    /// 
    /// 轉換數字（小數部分）
    /// 
    /// 需要轉換的小數部分數字字符串
    /// 轉換成中文大寫後的字符串
    public string ConvertXiaoShu(string str)
    {
        int strlen = str.Length;
        string rstr;
        if (strlen == 1)
        {
            rstr = ConvertChinese(str) + "角";
            return rstr;
        }
        else
        {
            string tmpstr = str.Substring(0, 1);
            rstr = ConvertChinese(tmpstr) + "角";
            tmpstr = str.Substring(1, 1);
            rstr += ConvertChinese(tmpstr) + "分";
            rstr = rstr.Replace("零分", "");
            rstr = rstr.Replace("零角", "");
            return rstr;
        }


    }
    /// 
    /// 轉換數字
    /// 
    /// 轉換的字符串（四位以內）
    /// 
    public string ConvertDigit(string str)
    {
        int strlen = str.Length;
        string rstr = "";
        switch (strlen)
        {
            case 1: rstr = ConvertChinese(str); break;
            case 2: rstr = Convert2Digit(str); break;
            case 3: rstr = Convert3Digit(str); break;
            case 4: rstr = Convert4Digit(str); break;
        }
        rstr = rstr.Replace("拾零", "拾");
        strlen = rstr.Length;
        return rstr;
    }
    /// 
    /// 轉換四位數字
    /// 
    public string Convert4Digit(string str)
    {
        string str1 = str.Substring(0, 1);
        string str2 = str.Substring(1, 1);
        string str3 = str.Substring(2, 1);
        string str4 = str.Substring(3, 1);
        string rstring = "";
        rstring += ConvertChinese(str1) + "仟";
        rstring += ConvertChinese(str2) + "佰";
        rstring += ConvertChinese(str3) + "拾";
        rstring += ConvertChinese(str4);
        rstring = rstring.Replace("零仟", "零");
        rstring = rstring.Replace("零佰", "零");
        rstring = rstring.Replace("零拾", "零");
        rstring = rstring.Replace("零零", "零");
        rstring = rstring.Replace("零零", "零");
        rstring = rstring.Replace("零零", "零");
        return rstring;
    }
    /// 
    /// 轉換三位數字
    /// 
    public string Convert3Digit(string str)
    {
        string str1 = str.Substring(0, 1);
        string str2 = str.Substring(1, 1);
        string str3 = str.Substring(2, 1);
        string rstring = "";
        rstring += ConvertChinese(str1) + "佰";
        rstring += ConvertChinese(str2) + "拾";
        rstring += ConvertChinese(str3);
        rstring = rstring.Replace("零佰", "零");
        rstring = rstring.Replace("零拾", "零");
        rstring = rstring.Replace("零零", "零");
        rstring = rstring.Replace("零零", "零");
        return rstring;
    }
    /// 
    /// 轉換二位數字
    /// 
    public string Convert2Digit(string str)
    {
        string str1 = str.Substring(0, 1);
        string str2 = str.Substring(1, 1);
        string rstring = "";
        rstring += ConvertChinese(str1) + "拾";
        rstring += ConvertChinese(str2);
        rstring = rstring.Replace("零拾", "零");
        rstring = rstring.Replace("零零", "零");
        return rstring;
    }
    /// 
    /// 將一位數字轉換成中文大寫數字
    /// 
    public string ConvertChinese(string str)
    {
        //"零壹貳叁肆伍陸柒捌玖拾佰仟萬億圓整角分"
        string cstr = "";
        switch (str)
        {
            case "0": cstr = "零"; break;
            case "1": cstr = "壹"; break;
            case "2": cstr = "貳"; break;
            case "3": cstr = "叁"; break;
            case "4": cstr = "肆"; break;
            case "5": cstr = "伍"; break;
            case "6": cstr = "陸"; break;
            case "7": cstr = "柒"; break;
            case "8": cstr = "捌"; break;
            case "9": cstr = "玖"; break;
        }
        return (cstr);
    }

    [DirectMethod("pdfU", DirectAction.Load)]
    public JObject pdfU(string pCustOrderUuid, Request request)
    {
        #region Declare
        LwModel model = new LwModel();
        #endregion
        //pCustOrderUuid = "15031223373300495";
        try
        {   WebRequest req = WebRequest.Create("http://localhost/limew/pdftest.aspx");
            req.Timeout = 30 * 60 * 1000;            
            WebResponse response = (WebResponse)req.GetResponse();
            var downloadfilename = "";
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s, System.Text.Encoding.UTF8))
                {
                    var text = sr.ReadToEnd();                   
                    Document doc = new Document(new Rectangle(9.5f * 72f, 5.5f * 72f), 40, 40, 10, 20);
                    HTMLWorker hw = new HTMLWorker(doc);
                    FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
                    @"\Fonts\simhei.ttf");//SimHei字體(中易黑體)
                    FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
                    @"\Fonts\MINGLIU.TTC");//細明體 & 新細明體
                    FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
                    @"\Fonts\KAIU.TTF");//標楷體
                    String fontPath = System.Environment.GetEnvironmentVariable("windir") +
                    @"\Fonts\MINGLIU.TTC";
                    XMLWorkerFontProvider fontImp = new XMLWorkerFontProvider(fontPath);
                    FontFactory.FontImp = fontImp;
                    FontFactory.Register(fontPath, "mingliu");


                    fontPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\..\Fonts\kaiu.ttf";
                    BaseFont bfChinese = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    Font fontChinese16 = new Font(bfChinese, 16f, Font.NORMAL);
                    Font fontChinese14 = new Font(bfChinese, 14f, Font.NORMAL);
                    Font fontChinese12 = new Font(bfChinese, 12f, Font.NORMAL); //title
                    Font fontChinese10 = new Font(bfChinese, 10f, Font.NORMAL); //table title , 第一聯
                    Font fontChinese8 = new Font(bfChinese, 8f, Font.NORMAL);
                     var drCustOrder = model.getVCustOrder_By_CustOrderUuid(pCustOrderUuid).AllRecord().First();
                    
                     var fileSavePath = getCustOrderPath(pCustOrderUuid, out downloadfilename);
                     PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(fileSavePath, System.IO.FileMode.Create));
                    doc.Open();                    
                    
                    writer.DirectContent.BeginText();
                    
                    writer.DirectContent.SetTextMatrix(300, 370);
                    writer.DirectContent.SetFontAndSize(bfChinese, 12);
                    writer.DirectContent.ShowText("裕寶企業商行 報價單");

                    writer.DirectContent.SetTextMatrix(300, 355);
                    writer.DirectContent.SetFontAndSize(bfChinese, 10);
                    writer.DirectContent.ShowText("新竹縣新豐鄉道化街10號1樓");
                    HttpServerUtility server = System.Web.HttpContext.Current.Server;
                    var url = server.MapPath("~/css/custImages/裕寶企業商行.jpg");
                    var img = Image.GetInstance(new Uri(url));
                    img.SetAbsolutePosition(225,320);                   
                    img.ScaleAbsolute( 75, 75);                    
                    doc.Add(img);
                    writer.DirectContent.SetTextMatrix(40, 345);
                    writer.DirectContent.SetFontAndSize(bfChinese, 12);
                    writer.DirectContent.ShowText("報價日期："+drCustOrder.CUST_ORDER_REPORT_DATE.Value.ToString("yyyy/MM/dd") );

                    writer.DirectContent.SetTextMatrix(550, 345);
                    writer.DirectContent.SetFontAndSize(bfChinese, 12);
                    writer.DirectContent.ShowText("製單人員：" + drCustOrder.CUST_ORDER_REPORT_ATTENDANT_C_NAME);

                    doc.Add(new Paragraph(""));
                    doc.Add(new Chunk("\n"));
                    doc.Add(new Chunk("\n"));
                    //PdfPTable table = new PdfPTable(11);
                    //                                             1    2    3    4   5      6  7    8     9   10   11
                    PdfPTable table = new PdfPTable(new float[] { 10f, 10f, 20f, 20f, 5f, 15f, 0f, 20f, 20f, 20f, 20f });
                    table.WidthPercentage = 100;
                    table.SpacingAfter = 10f;
                    PdfPCell cell = new PdfPCell(new Phrase(""));
                    cell.Colspan =11;
                    cell.FixedHeight = 30f;
                    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell);
                    //第1行
                    writer.DirectContent.SetTextMatrix(45, 318);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("客戶名稱：" + drCustOrder.CUST_NAME);

                    writer.DirectContent.SetTextMatrix(280, 318);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("單位部門：" + drCustOrder.CUST_ORG_NAME);

                    writer.DirectContent.SetTextMatrix(400, 318);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("聯絡電話：" + drCustOrder.CUST_ORG_SALES_PHONE);

                    //第2行                  

                    writer.DirectContent.SetTextMatrix(45, 308);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);

                    if (drCustOrder.CUST_ORDER_PRINT_USER_NAME.Trim().Length > 0)
                    {
                        writer.DirectContent.ShowText("採購人員：" + drCustOrder.CUST_ORDER_PRINT_USER_NAME);
                    }
                    else
                    {
                        writer.DirectContent.ShowText("採購人員：" + drCustOrder.CUST_ORG_SALES_NAME);
                    }
                    //writer.DirectContent.ShowText("採購人員：" + drCustOrder.CUST_ORG_SALES_NAME);

                    writer.DirectContent.SetTextMatrix(280, 308);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("地址：" + drCustOrder.CUST_ADDRESS);
                   
                    //第一聯
                    writer.DirectContent.SetTextMatrix(650, 328);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("第");

                    writer.DirectContent.SetTextMatrix(650, 318);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("一");

                    writer.DirectContent.SetTextMatrix(650, 308);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("聯");

                    writer.DirectContent.SetTextMatrix(652, 298);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText(":");

                    writer.DirectContent.SetTextMatrix(650, 288);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("存");

                    writer.DirectContent.SetTextMatrix(650, 278);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("根");

                    


                    //第二聯
                    writer.DirectContent.SetTextMatrix(650, 248);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("第");

                    writer.DirectContent.SetTextMatrix(650, 238);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("二");

                    writer.DirectContent.SetTextMatrix(650, 228);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("聯");

                    writer.DirectContent.SetTextMatrix(652, 218);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText(":");

                    writer.DirectContent.SetTextMatrix(650, 208);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("會");

                    writer.DirectContent.SetTextMatrix(650, 198);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("計");


                    //第三聯
                    writer.DirectContent.SetTextMatrix(650, 168);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("第");

                    writer.DirectContent.SetTextMatrix(650, 158);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("三");

                    writer.DirectContent.SetTextMatrix(650, 148);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("聯");

                    writer.DirectContent.SetTextMatrix(652, 138);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText(":");

                    writer.DirectContent.SetTextMatrix(650, 128);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("客");

                    writer.DirectContent.SetTextMatrix(650, 118);
                    writer.DirectContent.SetFontAndSize(bfChinese, 8);
                    writer.DirectContent.ShowText("戶");

                    writer.DirectContent.EndText(); 

                    
                    //第4行
                    var cell1_1 = new PdfPCell(new Phrase("序",fontChinese10));
                    cell1_1.Colspan = 1;
                    cell1_1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    cell1_1.FixedHeight = 16;
                    table.AddCell(cell1_1);

                    var cell1_5 = new PdfPCell(new Phrase("品名規格", fontChinese10));
                    cell1_5.Colspan = 4;
                    cell1_5.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_5);

                    var cell1_6 = new PdfPCell(new Phrase("數量", fontChinese10));
                    cell1_6.Colspan = 1;
                    cell1_6.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_6);



                    var cell1_8 = new PdfPCell(new Phrase("單位", fontChinese10));
                    cell1_8.Colspan = 2;
                    cell1_8.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_8);

                    var cell1_9 = new PdfPCell(new Phrase("單價", fontChinese10));
                    cell1_9.Colspan = 1;
                    cell1_9.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_9);

                    var cell1_10 = new PdfPCell(new Phrase("金額", fontChinese10));
                    cell1_10.Colspan = 1;
                    cell1_10.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_10);

                    var cell1_11 = new PdfPCell(new Phrase("備註", fontChinese10));
                    cell1_11.Colspan = 1;
                    cell1_11.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell1_11);
                    var drVCustOrderDetail = model.getVCustOrderDetail_By_CustOrderUuid(pCustOrderUuid,new OrderLimit());
                    var rowCount = 0;
                    decimal sumMoney = 0;
                    foreach (var item in drVCustOrderDetail) {
                        rowCount++;
                        //序
                        var cellD_1 = new PdfPCell(new Phrase(rowCount.ToString(), fontChinese10));
                        cellD_1.Colspan = 1;
                        cellD_1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        cellD_1.FixedHeight = 16;
                        table.AddCell(cellD_1);
                        //品名規格
                        var cellD_5 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_GOODS_NAME, fontChinese10));
                        cellD_5.Colspan = 4;
                        cellD_5.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_5);
                        //數量
                        var cellD_6 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_COUNT.ToString(), fontChinese10));
                        cellD_6.Colspan = 1;
                        cellD_6.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_6);
                        //單位
                        var cellD_8 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_UNIT_NAME, fontChinese10));
                        cellD_8.Colspan = 2;
                        cellD_8.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_8);
                        //單價
                        var cellD_9 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_PRICE.ToString(), fontChinese10));
                        cellD_9.Colspan = 1;
                        cellD_9.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_9);
                        //金額
                        var cellD_10 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_TOTAL_PRICE.ToString(), fontChinese10));
                        cellD_10.Colspan = 1;
                        cellD_10.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_10);
                        //備註
                        var cellD_11 = new PdfPCell(new Phrase(item.CUST_ORDER_DETAIL_PS, fontChinese10));
                        cellD_11.Colspan = 1;
                        cellD_11.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_11);

                        sumMoney += item.CUST_ORDER_DETAIL_TOTAL_PRICE.Value;

                        
                    }
                    //資料
                    for (int i = rowCount+1; i < 13; i++)
                    {
                        //序
                        var cellD_1 = new PdfPCell(new Phrase(i.ToString(), fontChinese10));
                        cellD_1.Colspan = 1;
                        cellD_1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        cellD_1.FixedHeight = 16;
                        table.AddCell(cellD_1);
                        //品名規格
                        var cellD_5 = new PdfPCell(new Phrase("" , fontChinese10));
                        cellD_5.Colspan = 4;
                        cellD_5.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_5);
                        //數量
                        var cellD_6 = new PdfPCell(new Phrase("", fontChinese10));
                        cellD_6.Colspan = 1;
                        cellD_6.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_6);
                        //單位
                        var cellD_8 = new PdfPCell(new Phrase("", fontChinese10));
                        cellD_8.Colspan = 2;
                        cellD_8.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_8);
                        //單價
                        var cellD_9 = new PdfPCell(new Phrase("", fontChinese10));
                        cellD_9.Colspan = 1;
                        cellD_9.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_9);
                        //金額
                        var cellD_10 = new PdfPCell(new Phrase("", fontChinese10));
                        cellD_10.Colspan = 1;
                        cellD_10.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_10);
                        //備註
                        var cellD_11 = new PdfPCell(new Phrase("", fontChinese10));
                        cellD_11.Colspan = 1;
                        cellD_11.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cellD_11);
                        
                        
                    }
                    //var cell2_2 = new PdfPCell(new Phrase("小計", fontChinese10));
                    //cell2_2.Colspan = 2;
                    //cell2_2.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //cell2_2.FixedHeight = 16;
                    //table.AddCell(cell2_2);

                    //var cell2_3 = new PdfPCell(new Phrase("NT$ "+sumMoney.ToString(), fontChinese10));
                    //cell2_3.Colspan = 1;
                    //cell2_3.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //table.AddCell(cell2_3);

                    //var cell2_4 = new PdfPCell(new Phrase("營業稅", fontChinese10));
                    //cell2_4.Colspan = 1;
                    
                    //cell2_4.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //table.AddCell(cell2_4);

                    //string hasTax = "含稅";
                    //if (drCustOrder.CUST_ORDER_HAS_TAX != 1) {
                    //    hasTax = "未稅";
                    //}
                    //var cell2_7 = new PdfPCell(new Phrase(hasTax, fontChinese10));
                    //cell2_7.Colspan = 3;
                    //cell2_7.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //table.AddCell(cell2_7);
                    var cell2_1 = new PdfPCell(new Phrase("", fontChinese10));
                    cell2_1.Colspan = 7;
                    cell2_1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell2_1);

                    var cell2_9 = new PdfPCell(new Phrase("合計", fontChinese10));
                    cell2_9.Colspan =2;
                    cell2_9.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell2_9);

                    string showMoney = "";
                    if (drCustOrder.CUST_ORDER_HAS_TAX != 1)
                    {
                        showMoney = (sumMoney * Convert.ToDecimal(1.05)).ToString();
                    }
                    else {
                        showMoney = sumMoney.ToString();
                    }
                    var cell2_11 = new PdfPCell(new Phrase("NT$ " + showMoney, fontChinese12));
                    cell2_11.Colspan = 2;
                    cell2_11.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell2_11);



                    var cell3_2 = new PdfPCell(new Phrase("備註", fontChinese10));
                    cell3_2.Colspan = 2;
                    cell3_2.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    cell3_2.FixedHeight = 32;
                    table.AddCell(cell3_2);

                    var cell3_11 = new PdfPCell(new Phrase(drCustOrder.CUST_ORDER_PS, fontChinese10));
                    cell3_11.Colspan = 9;
                    cell3_11.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell3_11);   
                    doc.Add(table);

                    
                   

                    doc.Close();                    
                    sr.Close();
                }

            }
            System.Collections.Hashtable ht = new Hashtable();
            ht.Add("file", downloadfilename);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(ht);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

}

