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
                _submitMyOrderDetail("","", "1", "0", "0", "0", "1", getUser().UUID, "", pMyOrderUuid, "A0001","");     
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
        string unit_uuid,
        string my_order_detail_ps,
        Request request)
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
         unit_uuid,
         my_order_detail_ps);
            
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
        string unit_uuid, string my_order_detail_ps)
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
            record.MY_ORDER_DETAIL_PS = my_order_detail_ps;
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
                    var data = item.Split('`');
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

    [DirectMethod("pdfMyOrder", DirectAction.Load)]
    public JObject pdfMyOrder(string pMyOrderUuid, Request request)
    {
        #region Declare
        LwModel model = new LwModel();
        HttpServerUtility server = System.Web.HttpContext.Current.Server;            
        #endregion
        try
        {

            var downloadfilename = "";
            Document doc = new Document(PageSize.A4, 40f, 40f, 10f, 10f);
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

            var fileSavePath = getMyOrderPath(pMyOrderUuid, out downloadfilename);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(fileSavePath, System.IO.FileMode.Create));
            doc.Open();
            doc.Add(new Paragraph(" ", fontChinese10));
            //begin
            writer.DirectContent.BeginText();
            writer.DirectContent.SetTextMatrix(260, 800);
            writer.DirectContent.SetFontAndSize(bfChinese, 16);
            //表頭
            writer.DirectContent.ShowText("訂購單");
            doc.Add(new Paragraph(" ", fontChinese10));
            //end
            writer.DirectContent.EndText();

            PdfPTable table = new PdfPTable(new float[] { 10f, 30f, 20f, 20f, 20f, 20f, 0f, 20f, 20f, 20f, 50f });
            table.WidthPercentage = 100;
            table.SpacingAfter = 10f;
            //第1行 直的由上而下            
            writer.DirectContent.SetTextMatrix(45, 780);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);            
            var drMyOrder = model.getMyOrder_By_MyOrderUuid(pMyOrderUuid).AllRecord().First();
            writer.DirectContent.ShowText("訂購單編號：" + drMyOrder.MY_ORDER_ID);

            writer.DirectContent.SetTextMatrix(45, 770);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);
            writer.DirectContent.ShowText("供應商名稱：" + drMyOrder.MY_ORDER_SUPPLIER_NAME);

            writer.DirectContent.SetTextMatrix(45, 760);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);
            writer.DirectContent.ShowText("連 聯 人  ：" + drMyOrder.MY_ORDER_CONTACT_NAME);
                       
            writer.DirectContent.SetTextMatrix(45, 750);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);
            writer.DirectContent.ShowText("供應商地址：" + drMyOrder.MY_ORDER_SUPPLIER_ADDRESS);

            //writer.DirectContent.SetTextMatrix(45, 740);
            //writer.DirectContent.SetFontAndSize(bfChinese, 10);
            //writer.DirectContent.ShowText("備      註：" + "未完成");

            //第2行 直的由上而下
            writer.DirectContent.SetTextMatrix(380, 780);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);
            writer.DirectContent.ShowText("製單日期  ：" + drMyOrder.MY_ORDER_CR.Value.ToString("yyyy/MM/dd"));

            writer.DirectContent.SetTextMatrix(380, 770);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);
            writer.DirectContent.ShowText("列印時間  ：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm"));

            writer.DirectContent.SetTextMatrix(380, 760);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);
            writer.DirectContent.ShowText("供應商電話：" + drMyOrder.MY_ORDER_SUPPLIER_TEL);
           
            writer.DirectContent.SetTextMatrix(380, 750);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);
            writer.DirectContent.ShowText("供應商傳真：" + drMyOrder.MY_ORDER_SUPPLIER_FAX);
            
            //表格
            var cell1_1 = new PdfPCell(new Phrase("序", fontChinese10));
            cell1_1.Colspan = 1;
            cell1_1.HorizontalAlignment = 1; 
            cell1_1.FixedHeight = 16;
            table.AddCell(cell1_1);

            var cell1_5 = new PdfPCell(new Phrase("商品名稱/規格", fontChinese10));
            cell1_5.Colspan = 4;
            cell1_5.HorizontalAlignment = 1; 
            table.AddCell(cell1_5);

            var cell1_6 = new PdfPCell(new Phrase("數量", fontChinese10));
            cell1_6.Colspan = 1;
            cell1_6.HorizontalAlignment = 1; 
            table.AddCell(cell1_6);

            var cell1_8 = new PdfPCell(new Phrase("單位", fontChinese10));
            cell1_8.Colspan = 2;
            cell1_8.HorizontalAlignment = 1; 
            table.AddCell(cell1_8);

            var cell1_9 = new PdfPCell(new Phrase("單價", fontChinese10));
            cell1_9.Colspan = 1;
            cell1_9.HorizontalAlignment = 1; 
            table.AddCell(cell1_9);

            var cell1_10 = new PdfPCell(new Phrase("金額", fontChinese10));
            cell1_10.Colspan = 1;
            cell1_10.HorizontalAlignment = 1; 
            table.AddCell(cell1_10);

            var cell1_11 = new PdfPCell(new Phrase("備註", fontChinese10));
            cell1_11.Colspan = 1;
            cell1_11.HorizontalAlignment = 1; 
            table.AddCell(cell1_11);
            var drVMyOrderDetail = model.getVMyOrderDetail_By_MyOrderUuid_SupplierUuid_Keyword(pMyOrderUuid, "", "", new OrderLimit("MY_ORDER_DETAIL_UUID", OrderLimit.OrderMethod.ASC));
            var rowCount = 0;
            decimal sumMoney = 0;
            foreach (var item in drVMyOrderDetail)
            {
                rowCount++;
                //序
                var cellD_1 = new PdfPCell(new Phrase(rowCount.ToString(), fontChinese10));
                cellD_1.Colspan = 1;
                cellD_1.HorizontalAlignment = 1; 
                cellD_1.FixedHeight = 16;
                table.AddCell(cellD_1);
                //品名規格
                var cellD_5 = new PdfPCell(new Phrase(item.MY_ORDER_DETAIL_GOODS_NAME, fontChinese10));
                cellD_5.Colspan = 4;
                cellD_5.HorizontalAlignment = 0; 
                table.AddCell(cellD_5);
                //數量
                var cellD_6 = new PdfPCell(new Phrase(item.MY_ORDER_DETAIL_GOODS_COUNT.ToString(), fontChinese10));
                cellD_6.Colspan = 1;
                cellD_6.HorizontalAlignment = 1; 
                table.AddCell(cellD_6);
                //單位
                var cellD_8 = new PdfPCell(new Phrase(item.MY_ORDER_DETAIL_UNIT_NAME, fontChinese10));
                cellD_8.Colspan = 2;
                cellD_8.HorizontalAlignment = 1; 
                table.AddCell(cellD_8);
                //單價
                var cellD_9 = new PdfPCell(new Phrase(item.MY_ORDER_DETAIL_PRICE.ToString(), fontChinese10));
                cellD_9.Colspan = 1;
                cellD_9.HorizontalAlignment = 2; 
                table.AddCell(cellD_9);
                //金額
                var cellD_10 = new PdfPCell(new Phrase(item.MY_ORDER_DETAIL_TOTAL_PRICE.ToString(), fontChinese10));
                cellD_10.Colspan = 1;
                cellD_10.HorizontalAlignment = 2; 
                table.AddCell(cellD_10);
                //備註
                //var cellD_11 = new PdfPCell(new Phrase(item., fontChinese10));
                var cellD_11 = new PdfPCell(new Phrase(item.MY_ORDER_DETAIL_PS, fontChinese10));
                cellD_11.Colspan = 1;
                cellD_11.HorizontalAlignment = 0; 
                table.AddCell(cellD_11);
                sumMoney += item.MY_ORDER_DETAIL_TOTAL_PRICE.Value;
            }
            var isFirst = true;
            //資料
            for (int i = rowCount + 1; i < 41; i++)
            {
                //序
                var cellD_1 = new PdfPCell(new Phrase(i.ToString(), fontChinese10));
                cellD_1.Colspan = 1;
                cellD_1.HorizontalAlignment = 1; 
                cellD_1.FixedHeight = 16;
                table.AddCell(cellD_1);
                //品名規格
                string showText = "";
                if (isFirst == true)
                {
                    showText = "以下空白";
                    isFirst = false;
                }
                else {
                    showText = "";                    
                }
                var cellD_5 = new PdfPCell(new Phrase(showText, fontChinese10));
                cellD_5.Colspan = 4;
                cellD_5.HorizontalAlignment = 0; 
                table.AddCell(cellD_5);
                //數量
                var cellD_6 = new PdfPCell(new Phrase("", fontChinese10));
                cellD_6.Colspan = 1;
                cellD_6.HorizontalAlignment = 1; 
                table.AddCell(cellD_6);
                //單位
                var cellD_8 = new PdfPCell(new Phrase("", fontChinese10));
                cellD_8.Colspan = 2;
                cellD_8.HorizontalAlignment = 1; 
                table.AddCell(cellD_8);
                //單價
                var cellD_9 = new PdfPCell(new Phrase("", fontChinese10));
                cellD_9.Colspan = 1;
                cellD_9.HorizontalAlignment = 2; 
                table.AddCell(cellD_9);
                //金額
                var cellD_10 = new PdfPCell(new Phrase("", fontChinese10));
                cellD_10.Colspan = 1;
                cellD_10.HorizontalAlignment = 2; 
                table.AddCell(cellD_10);
                //備註
                var cellD_11 = new PdfPCell(new Phrase("", fontChinese10));
                cellD_11.Colspan = 1;
                cellD_11.HorizontalAlignment = 0; 
                table.AddCell(cellD_11);
            }
            
            var cell3_11 = new PdfPCell(new Phrase("總額新臺幣 " + ConvertSum(sumMoney.ToString()) + "  NT$ " + sumMoney.ToString(), fontChinese10));
            cell3_11.FixedHeight = 16;
            cell3_11.Colspan = 11;
            cell3_11.HorizontalAlignment = 0; 
            table.AddCell(cell3_11);
            doc.Add(new Chunk("\n"));
            doc.Add(new Chunk("\n"));            
            doc.Add(new Chunk("\n"));
            doc.Add(table);

            doc.Add(new Paragraph("備註："+drMyOrder.MY_ORDER_PS, fontChinese12));

            doc.Close();
            
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
    public string getMyOrderPath(string pMyOrderUuid, out string extName)
    {
        HttpServerUtility server = System.Web.HttpContext.Current.Server;
        var uploadFolder = server.MapPath(Limew.Parameter.Config.ParemterConfigs.GetConfig().UploadFolder);
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(uploadFolder);
        if (di.Exists == false)
        {
            di.Create();
        }

        uploadFolder = uploadFolder + "myOrder//";

        di = new System.IO.DirectoryInfo(uploadFolder);
        if (di.Exists == false)
        {
            di.Create();
        }
        extName = pMyOrderUuid + "-" + LK.Util.UID.Instance.GetUniqueID() + ".pdf";

        return uploadFolder = uploadFolder + extName;
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

}

