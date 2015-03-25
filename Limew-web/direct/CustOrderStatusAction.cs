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

[DirectService("CustOrderStatusAction")]
public class CustOrderStatusAction : BaseAction
{


    [DirectMethod("loadCustOrderStatus", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadCustOrderStatus(string pKeyword, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = mod.getCustOrderStatus_By_Keyword_Count(pKeyword);
            var data = mod.getCustOrderStatus_By_Keyword(pKeyword, orderLimit);
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

    [DirectMethod("infoCustOrderStatus", DirectAction.Load, MethodVisibility.Visible)]
    public JObject infoCustOrderStatus(string pCustOrderStatusUuid, Request request)
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
            var data = model.getCustOrderStatus_By_CustOrderStatusUuid(pCustOrderStatusUuid);

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

    [DirectMethod("submitCustOrderStatus", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitCustOrderStatus(string cust_order_status_uuid,
string cust_order_status_name,
string cust_order_status_is_active,
string cust_order_status_ord, HttpRequest request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        CustOrderStatus_Record record = new CustOrderStatus_Record();
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
            if (cust_order_status_uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = mod.getCustOrderStatus_By_CustOrderStatusUuid(cust_order_status_uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.CUST_ORDER_STATUS_UUID = LK.Util.UID.Instance.GetUniqueID();
            }
            record.CUST_ORDER_STATUS_NAME = cust_order_status_name;
            record.CUST_ORDER_STATUS_ORD = Convert.ToInt16(cust_order_status_ord);
            record.CUST_ORDER_STATUS_IS_ACTIVE = Convert.ToInt16(cust_order_status_is_active);
            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            else if (action == SubmitAction.Create)
            {
                record.gotoTable().Insert(record);
                cust_order_status_uuid = record.CUST_ORDER_STATUS_UUID;
            }
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("CUST_ORDER_STATUS_UUID", record.CUST_ORDER_STATUS_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }
    
}

