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
#endregion

[DirectService("CustAction")]
public class CustAction : BaseAction
{

    [DirectMethod("infoCust", DirectAction.Load, MethodVisibility.Visible)]
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

    [DirectMethod("loadCust", DirectAction.Store, MethodVisibility.Visible)]
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

    [DirectMethod("submitCust", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitCust(  string cust_uuid,
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
                                string cust_last_buy, HttpRequest request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        Cust_Record record = new Cust_Record();
        #endregion
        try
        {  /*Cloud身份檢查*/
            checkUser(request);
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
            record.CUST_LEVEL = Convert.ToInt16( cust_level );
            record.CUST_IS_ACTIVE = Convert.ToInt16( cust_is_active );
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
            otherParam.Add("CUST_UUID", record.CUST_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("destoryCust", DirectAction.Store, MethodVisibility.Visible)]
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

    [DirectMethod("loadCustOrder", DirectAction.Store, MethodVisibility.Visible)]
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

    [DirectMethod("infoCustOrder", DirectAction.Load, MethodVisibility.Visible)]
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

    [DirectMethod("submitCustOrder", DirectAction.FormSubmission, MethodVisibility.Visible)]
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
                                string cust_order_typeb_id,
                                string cust_order_shipping_date,
                                string shipping_status_uuid,
                                string cust_order_invoice_number,
                                string pay_status_uuid,
                                string pay_method_uuid, HttpRequest request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        CustOrder_Record record = new CustOrder_Record();
        #endregion
        try
        {  /*Cloud身份檢查*/
            checkUser(request);
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
                record = mod.getCustOrder_By_CustOrderUuid(cust_uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.CUST_ORDER_UUID = LK.Util.UID.Instance.GetUniqueID();
                record.CUST_ORDER_CR = Convert.ToDateTime( cust_order_cr);
            }
            
            
            record.CUST_ORDER_ID = cust_order_id;
            record.CUST_ORDER_TOTAL_PRICE = Convert.ToDecimal( cust_order_total_price );
            record.CUST_ORDER_STATUS_UUID = cust_order_status_uuid;
            record.CUST_ORDER_IS_ACTIVE = Convert.ToInt16( cust_order_is_active );
            record.CUST_UUID = cust_uuid;
            record.CUST_ORDER_TYPE = cust_order_type;
            record.CUST_ORDER_CUST_NAME = cust_order_cust_name;
            record.CUST_ORDER_DEPT = cust_order_dept;
            record.CUST_ORDER_USER_NAME = cust_order_user_name;
            record.CUST_ORDER_USER_PHONE = cust_order_user_phone;
            record.CUST_ORDER_PURCHASE_AMOUNT = cust_order_purchase_amount;
            record.CUST_ORDER_PRINT_USER_NAME = cust_order_print_user_name;
            record.CUST_ORDER_SHIPPING_DATE = Convert.ToDateTime( cust_order_shipping_date );
            record.SHIPPING_STATUS_UUID = shipping_status_uuid;
            record.CUST_ORDER_INVOICE_NUMBER = cust_order_invoice_number;
            record.PAY_STATUS_UUID = pay_status_uuid;
            record.PAY_METHOD_UUID = pay_method_uuid;
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
            otherParam.Add("CUST_UUID", record.CUST_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("destoryCustOrder", DirectAction.Store, MethodVisibility.Visible)]
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

    [DirectMethod("infoCustOrderDetail", DirectAction.Load, MethodVisibility.Visible)]
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
            var data = model.getCustOrderDetail_By_CusrOrderDetailUuid(pCustOrderDetailUuid);

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

    [DirectMethod("submitCustOrderDetail", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitCustOrderDetail(   string cusr_order_detail_uuid,
                                            string cust_order_uuid,
                                            string goods_uuid,
                                            string cust_order_detail_googds_name,
                                            string cust_order_detail_count,
                                            string cust_order_detail_unit,
                                            string cust_order_detail_price,
                                            string cust_order_detail_total_price,
                                            string cust_order_detail_ps,
                                            string cust_order_detail_cr, HttpRequest request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        CustOrderDetail_Record record = new CustOrderDetail_Record();
        #endregion
        try
        {  /*Cloud身份檢查*/
            checkUser(request);
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
            if (cusr_order_detail_uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = mod.getCustOrderDetail_By_CusrOrderDetailUuid(cusr_order_detail_uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.CUSR_ORDER_DETAIL_UUID = LK.Util.UID.Instance.GetUniqueID();
                record.CUST_ORDER_DETAIL_CR = Convert.ToDateTime(cust_order_detail_cr);
            }


            record.CUST_ORDER_UUID = cust_order_uuid;
            record.GOODS_UUID = goods_uuid;
            record.CUST_ORDER_DETAIL_GOOGDS_NAME = cust_order_detail_googds_name;
            record.CUST_ORDER_DETAIL_COUNT = Convert.ToInt16( cust_order_detail_count);
            record.CUST_ORDER_DETAIL_UNIT = cust_order_detail_unit;
            record.CUST_ORDER_DETAIL_PRICE = Convert.ToDecimal(cust_order_detail_price);
            record.CUST_ORDER_DETAIL_TOTAL_PRICE = Convert.ToDecimal(cust_order_detail_total_price);
            record.CUST_ORDER_DETAIL_PS = cust_order_detail_ps;
           
           
            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            else if (action == SubmitAction.Create)
            {
                record.gotoTable().Insert(record);
                cusr_order_detail_uuid = record.CUSR_ORDER_DETAIL_UUID;
            }
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("CUSR_ORDER_DETAIL_UUID", record.CUSR_ORDER_DETAIL_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("destoryCustOrderDetail", DirectAction.Store, MethodVisibility.Visible)]
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

            var data = mod.getCustOrderDetail_By_CusrOrderDetailUuid(pCustOrderDetailUuid);
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

    [DirectMethod("loadCustOrderDetail", DirectAction.Store, MethodVisibility.Visible)]
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


    [DirectMethod("infoCustOrg", DirectAction.Load, MethodVisibility.Visible)]
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

    [DirectMethod("loadCustOrg", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadCustOrg(string pCustUuid,string pKeyword, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = mod.getCustOrg_By_Keyword_Count(pCustUuid,pKeyword);
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

    [DirectMethod("submitCustOrg", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitCustOrg(string cust_org_uuid,
                                    string cust_uuid,
                                    string cust_org_sales_name,
                                    string cust_org_sales_phone,
                                    string cust_org_sales_email,
                                    string cust_org_ps,
                                    string cust_org_name,
                                    string cust_org_is_active, HttpRequest request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        CustOrg_Record record = new CustOrg_Record();
        #endregion
        try
        {  /*Cloud身份檢查*/
            checkUser(request);
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

    [DirectMethod("destoryCustOrg", DirectAction.Store, MethodVisibility.Visible)]
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

    [DirectMethod("loadVCustOrder", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadVCustOrder(string pCustOrderStatus,string pCustUuid, string pKeyword, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = mod.getVCustOrder_By_CustOrderStatus_CustUuid_Keyword_Count(pCustOrderStatus,pCustUuid,pKeyword);
            var data = mod.getVCustOrder_By_CustOrderStatus_CustUuid_Keyword(pCustOrderStatus, pCustUuid, pKeyword, orderLimit);
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

}

