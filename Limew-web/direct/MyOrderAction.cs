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

[DirectService("MyOrderAction")]
public class MyOrderAction : BaseAction
{


        [DirectMethod("createMyOrderDetailCustomize", DirectAction.Load)]
    public JObject createMyOrderDetailCustomize(string pMyOrderUuid, string createNumber, Request request)
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
                _submitMyOrderDetail("","", "1", "0", "0", "0", "1", getUser().UUID, "", pMyOrderUuid, "A0001");     
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

    [DirectMethod("infoMyOrder", DirectAction.Load)]
    public JObject infoMyOrder(string pMyOrderUuid, Request request)
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
            var data = model.getMyOrder_By_MyOrderUuid(pMyOrderUuid);
            var dr = new MyOrder_Record();
            if (data.AllRecord().Count == 0) {
                
                dr.MY_ORDER_UUID = LK.Util.UID.Instance.GetUniqueID();
                dr.MY_ORDER_IS_ACTIVE = 0;
                dr.MY_ORDER_CR = DateTime.Now;
                dr.gotoTable().Insert_Empty2Null(dr);
            }

            if (data.AllRecord().Count == 1)
            {
                return ExtDirect.Direct.Helper.Form.OutputJObject(JsonHelper.RecordBaseJObject(data.AllRecord().First()));
            }
            else {
                return ExtDirect.Direct.Helper.Form.OutputJObject(JsonHelper.RecordBaseJObject(dr));
            
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Data Not Found!"));
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("infoMyOrderDetail", DirectAction.Load)]
    public JObject infoMyOrderDetail(string pMyOrderDetailUuid,string pMyOrderUuid, Request request)
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
            var data = model.getMyOrderDetail_By_MyOrderDetailUuid(pMyOrderDetailUuid);
            //myOrderDetailUuid
            MyOrderDetail_Record newDr = new MyOrderDetail_Record();
            if (data.AllRecord().Count == 1)
            {
                return ExtDirect.Direct.Helper.Form.OutputJObject(JsonHelper.RecordBaseJObject(data.AllRecord().First()));
            }
            else {
                newDr.MY_ORDER_DETAIL_UUID = LK.Util.UID.Instance.GetUniqueID();
                newDr.MY_ORDER_DETAIL_IS_ACTIVE = 0;
                newDr.MY_ORDER_UUID = pMyOrderUuid;
                newDr.MY_ORDER_DETAIL_GOODS_COUNT = 1;
                newDr.gotoTable().Insert_Empty2Null(newDr);
                return ExtDirect.Direct.Helper.Form.OutputJObject(JsonHelper.RecordBaseJObject(newDr));
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Data Not Found!"));
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadMyOrder", DirectAction.Store)]
    public JObject loadMyOrder(string pKeyword, string pSupplierUuid, string pIsActive, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = mod.getMyOrder_By_Keyword_SupplierUuid_IsActive_Count(pKeyword,pSupplierUuid,pIsActive);
            var data = mod.getMyOrder_By_Keyword_SupplierUuid_IsActive(pKeyword, pSupplierUuid, pIsActive, orderLimit);
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


    [DirectMethod("loadMyOrderDetail", DirectAction.Store)]
    public JObject loadMyOrderDetail(string pMyOrderUuid,string pKeyword, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = mod.getMyOrderDetail_By_MyOrderUuid_Keyword_Count(pMyOrderUuid, pKeyword);
            var data = mod.getMyOrderDetail_By_MyOrderUuid_Keyword(pMyOrderUuid, pKeyword, orderLimit);
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

    [DirectMethod("loadVMyOrderDetail", DirectAction.Store)]
    public JObject loadVMyOrderDetail(string pMyOrderUuid, string pSupplierUuid, string pKeyword,string pIsFinish, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = mod.getVMyOrderDetail_By_MyOrderUuid_SupplierUuid_Keyword_Count(pMyOrderUuid,pSupplierUuid,pKeyword);
            var data = mod.getVMyOrderDetail_By_MyOrderUuid_SupplierUuid_Keyword(pMyOrderUuid, pSupplierUuid, pKeyword,orderLimit);
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


    [DirectMethod("submitMyOrder", DirectAction.FormSubmission)]
    public JObject submitMyOrder(string my_order_uuid,
string supplier_uuid,
string my_order_supplier_name,
string my_order_supplier_tel,
string my_order_supplier_fax,
string my_order_supplier_address,
string my_order_contact_name,
string my_order_contact_phone,
string my_order_contact_email,
string my_order_ps,
string my_order_cr,
string my_order_total_price,
        string my_order_is_active,Request request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        MyOrder_Record record = new MyOrder_Record();
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
            if (my_order_uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = mod.getMyOrder_By_MyOrderUuid(my_order_uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.MY_ORDER_UUID = LK.Util.UID.Instance.GetUniqueID();
            }
            record.SUPPLIER_UUID = supplier_uuid;
            record.MY_ORDER_SUPPLIER_NAME = my_order_supplier_name;
            record.MY_ORDER_SUPPLIER_TEL = my_order_supplier_tel;
            record.MY_ORDER_SUPPLIER_FAX = my_order_supplier_fax;
            record.MY_ORDER_SUPPLIER_ADDRESS = my_order_supplier_address;
            record.MY_ORDER_CONTACT_NAME = my_order_contact_name;
            record.MY_ORDER_CONTACT_PHONE = my_order_contact_phone;
            record.MY_ORDER_CONTACT_EMAIL = my_order_contact_email;
            record.MY_ORDER_PS = my_order_ps;
            record.MY_ORDER_IS_ACTIVE = Convert.ToInt32(my_order_is_active);
            if (record.MY_ORDER_ID == null || record.MY_ORDER_ID == "") {
                record.MY_ORDER_ID = getMyOrderId();
            }
            if (my_order_cr!=null && my_order_cr.Trim().Length > 0)
            {
                record.MY_ORDER_CR = Convert.ToDateTime(my_order_cr);
            }
            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            else if (action == SubmitAction.Create)
            {
                record.gotoTable().Insert(record);
                my_order_uuid = record.MY_ORDER_UUID;
            }
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("MY_ORDER_UUID", record.MY_ORDER_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }
    public string getMyOrderId()
    {
        LwModel mod = new LwModel();
        var drs = mod.getMyOrderId_By_MyOrderIdUuid(DateTime.Now.ToString("yyyyMMdd")).AllRecord();
        if (drs.Count == 0)
        {
            MyOrderId_Record newRow = new MyOrderId_Record();
            newRow.MY_ORDER_ID_UUID = DateTime.Now.ToString("yyyyMMdd");
            newRow.MAX = 1;
            newRow.gotoTable().Insert_Empty2Null(newRow);
            return newRow.MY_ORDER_ID_UUID + String.Format("{0:0000}", newRow.MAX);
        }
        else
        {
            var dr = drs.First();
            
            dr.MAX = dr.MAX + 1;
            dr.gotoTable().Update_Empty2Null(dr);
            return dr.MY_ORDER_ID_UUID + String.Format("{0:0000}", dr.MAX);
        }

    }
    [DirectMethod("submitMyOrderDetail", DirectAction.FormSubmission)]
    public JObject submitMyOrderDetail(string my_order_detail_uuid,
string my_order_detail_goods_name,
string my_order_detail_goods_count,
string my_order_detail_price,
string my_order_detail_total_price,
string my_order_detail_is_finish,
string my_order_detail_is_active,
string my_order_detail_attendant_uuid,
string supplier_goods_uuid,
string my_order_uuid, 
        string unit_uuid,Request request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        MyOrderDetail_Record record = new MyOrderDetail_Record();
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

            record = _submitMyOrderDetail( my_order_detail_uuid,
 my_order_detail_goods_name,
 my_order_detail_goods_count,
 my_order_detail_price,
 my_order_detail_total_price,
 my_order_detail_is_finish,
 my_order_detail_is_active,
 my_order_detail_attendant_uuid,
 supplier_goods_uuid,
 my_order_uuid, 
         unit_uuid);
            
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("MY_ORDER_DETAIL_UUID", record.MY_ORDER_DETAIL_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    public MyOrderDetail_Record _submitMyOrderDetail(string my_order_detail_uuid,
string my_order_detail_goods_name,
string my_order_detail_goods_count,
string my_order_detail_price,
string my_order_detail_total_price,
string my_order_detail_is_finish,
string my_order_detail_is_active,
string my_order_detail_attendant_uuid,
string supplier_goods_uuid,
string my_order_uuid,
        string unit_uuid)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        MyOrderDetail_Record record = new MyOrderDetail_Record();
        #endregion
        try
        {  /*Cloud身份檢查*/            
            /*
             * 所有Form的動作最終是使用Submit的方式將資料傳出；
             * 必須有一個特徵來判斷使用者，執行的動作；
             */
            if (my_order_detail_uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = mod.getMyOrderDetail_By_MyOrderDetailUuid(my_order_detail_uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.MY_ORDER_DETAIL_UUID = LK.Util.UID.Instance.GetUniqueID();
            }
            record.MY_ORDER_DETAIL_GOODS_NAME = my_order_detail_goods_name;
            record.MY_ORDER_DETAIL_GOODS_COUNT = Convert.ToInt32(my_order_detail_goods_count);
            record.MY_ORDER_DETAIL_PRICE = Convert.ToDecimal(my_order_detail_price);
            record.MY_ORDER_DETAIL_TOTAL_PRICE = Convert.ToDecimal(record.MY_ORDER_DETAIL_PRICE) * Convert.ToDecimal(record.MY_ORDER_DETAIL_GOODS_COUNT);
            record.MY_ORDER_DETAIL_IS_FINISH = Convert.ToInt32(my_order_detail_is_finish);
            record.MY_ORDER_DETAIL_IS_ACTIVE = Convert.ToInt32(my_order_detail_is_active);
            record.MY_ORDER_DETAIL_ATTENDANT_UUID = my_order_detail_attendant_uuid;
            record.SUPPLIER_GOODS_UUID = supplier_goods_uuid;
            record.MY_ORDER_UUID = my_order_uuid;
            record.UNIT_UUID = unit_uuid;

            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
                return record;
            }
            else if (action == SubmitAction.Create)
            {
                record.gotoTable().Insert_Empty2Null(record);
                return record;

            }
            return record;
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            throw ex;
        }
    }

    [DirectMethod("batchUpdateMyOrderDetail", DirectAction.Load)]
    public JObject batchUpdateMyOrderDetail(string allItem, Request request)
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
            var myOrderlUuid = "";
            foreach (var item in drsUpdate)
            {
                if (item.Trim().Length > 0)
                {
                    var data = item.Split(',');
                    var myOrderDetailUuid = data[0];
                    var myOrderDetailGoodsName = data[1];
                    var myOrderDetailPrice = data[2];
                    var myOrderDetailCount = data[3];
                    var myOrderDetailUnit = data[4];
                    decimal? total = 0;
                    var drMyOrderDetail = mod.getMyOrderDetail_By_MyOrderDetailUuid(myOrderDetailUuid).AllRecord().First();
                    if (drMyOrderDetail.SUPPLIER_GOODS_UUID == "")
                    {
                        drMyOrderDetail.MY_ORDER_DETAIL_GOODS_NAME = myOrderDetailGoodsName;
                    }
                    drMyOrderDetail.MY_ORDER_DETAIL_GOODS_COUNT = Convert.ToInt32(myOrderDetailCount);
                    drMyOrderDetail.MY_ORDER_DETAIL_PRICE = Convert.ToDecimal(myOrderDetailPrice);
                    drMyOrderDetail.MY_ORDER_DETAIL_TOTAL_PRICE = drMyOrderDetail.MY_ORDER_DETAIL_PRICE * drMyOrderDetail.MY_ORDER_DETAIL_GOODS_COUNT;
                    drMyOrderDetail.UNIT_UUID = myOrderDetailUnit;
                    drMyOrderDetail.gotoTable().Update_Empty2Null(drMyOrderDetail);
                    if (myOrderDetailUuid.Trim().Length == 0)
                    {
                        myOrderlUuid = drMyOrderDetail.MY_ORDER_UUID;
                    }                    
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

    [DirectMethod("destoryMyOrder", DirectAction.Store)]
    public JObject destoryMyOrder(string pMyOrderUuid, Request request)
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

            var data = mod.getMyOrder_By_MyOrderUuid(pMyOrderUuid);
            if (data.AllRecord().Count > 0)
            {
                
                var delDr = data.AllRecord().First();
                var delDetail = mod.getMyOrderDetail_By_MyOrderUuid(delDr.MY_ORDER_UUID);
                foreach (var item in delDetail) {
                    item.gotoTable().Delete(item);
                }
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

    [DirectMethod("destoryMyOrderDetail", DirectAction.Store)]
    public JObject destoryMyOrderDetail(string pMyOrderDetailUuid, Request request)
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

            var data = mod.getMyOrderDetail_By_MyOrderDetailUuid(pMyOrderDetailUuid);
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

}

