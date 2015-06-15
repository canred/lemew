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

[DirectService("BillingAction")]
public class BillingAction : BaseAction
{
    [DirectMethod("createBilling", DirectAction.Load)]
    public JObject createBilling(Request request)
    {
        #region Declare
        LwModel mod = new LwModel();
        Billing_Record record = new Billing_Record();
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
            record.BILLING_UUID = LK.Util.UID.Instance.GetUniqueID();
            record.CUST_UUID = null;
            record.BILLING_IS_ACTIVE = 0;
            record.BILLING_ID = getBillingId();
            record.BILLING_REPORT_ATTENDANT_UUID = getUser().UUID;
            record.BILLING_DISCOUNT = 0;
      
            record.BILLING_STATUS_ID = "A";
            record.gotoTable().Insert_Empty2Null(record);
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("BILLING_UUID", record.BILLING_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }


    }


    [DirectMethod("infoBilling", DirectAction.Load)]
    public JObject infoBilling(string pBillingUuid, Request request)
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
            var data = model.getBilling_By_BillingUuid(pBillingUuid);

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
    [DirectMethod("submitBilling", DirectAction.FormSubmission)]
    public JObject submitBilling(string billing_uuid,
string billing_id,
string cust_uuid,
string billing_start_date,
string billing_end_date,
string billing_report_date,
string billing_cust_name,
string billing_cust_uniform_num,
string billing_tel,
string billing_cust_address,
string billing_sales_name,
string billing_item_count,
string billing_discount,
string billing_sum_price,
string billing_arrears_price,
string billing_tax,
string billing_total_price,
string billing_check_yy,
string billing_check_mm,
string billing_check_title,
string billing_contact_user_name,
string billing_contact_attendant_uuid,
string billing_back_account_number,
string billing_back_name,
string billing_back_sub_name,
string billing_back_account_name,
string billing_ps,
string billing_status_id,
string billing_is_active,
        string billing_report_attendant_uuid,
        Request request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        Billing_Record record = new Billing_Record();
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
            if (billing_uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = mod.getBilling_By_BillingUuid(billing_uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.BILLING_UUID = LK.Util.UID.Instance.GetUniqueID();
                //record.billing_cr = DateTime.Now;
            }

            var checkCustOrderId = mod.getBilling_By_BillingId(billing_id, new OrderLimit());
            var orgDr = mod.getBilling_By_BillingUuid(billing_uuid).AllRecord().First();
            
            if (checkCustOrderId.Count > 1)
            {
                throw new Exception("請款單編號發生重複!");
            }
            else if (checkCustOrderId.Count == 1)
            {
                if (orgDr.BILLING_UUID == checkCustOrderId.First().BILLING_UUID)
                {
                }
                else
                {
                    throw new Exception("訂單編號發生重複!");
                }
            }

            record.BILLING_ID = billing_id;
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
           
            record.CUST_UUID = cust_uuid;

            if (billing_start_date != null && billing_start_date.Trim().Length > 0)
            {
                record.BILLING_START_DATE = Convert.ToDateTime(billing_start_date);
            }
            else
            {
                record.BILLING_START_DATE = null;
            }

            if (billing_end_date != null && billing_end_date.Trim().Length > 0)
            {
                record.BILLING_END_DATE = Convert.ToDateTime(billing_end_date);
            }
            else
            {
                record.BILLING_END_DATE = null;
            }

            if (billing_report_date != null && billing_report_date.Trim().Length > 0)
            {
                record.BILLING_REPORT_DATE = Convert.ToDateTime(billing_report_date);
            }
            else
            {
                record.BILLING_REPORT_DATE = null;
            }


            if (billing_discount != null && billing_discount.Trim().Length > 0)
            {
                record.BILLING_DISCOUNT = Convert.ToDecimal(billing_discount);
            }else{
                record.BILLING_DISCOUNT = null;
            }
            
           

            record.BILLING_IS_ACTIVE = Convert.ToInt16(billing_is_active);

            record.BILLING_CUST_NAME = billing_cust_name;
            record.BILLING_CUST_UNIFORM_NUM = billing_cust_uniform_num;
            record.BILLING_TEL = billing_tel;
            record.BILLING_CUST_ADDRESS = billing_cust_address;
            record.BILLING_SALES_NAME = billing_sales_name;
            record.BILLING_REPORT_ATTENDANT_UUID = billing_report_attendant_uuid;
            
           
            //自動計算的項目

            var drsBillingDetail = mod.getBillingDetail_By_BillingUuid(record.BILLING_UUID);

            record.BILLING_ITEM_COUNT = drsBillingDetail.Count;
            decimal sum = 0;
            foreach (var item in drsBillingDetail) {
                var drCustOrder = mod.getCustOrder_By_CustOrderUuid(item.CUST_ORDER_UUID).AllRecord().First();
                sum += drCustOrder.CUST_ORDER_TOTAL_PRICE.Value;
            }
            record.BILLING_SUM_PRICE = sum;
            record.BILLING_TOTAL_PRICE = sum - record.BILLING_DISCOUNT;
            
            record.BILLING_PS = billing_ps;
            record.BILLING_STATUS_ID = "A";           

            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            else if (action == SubmitAction.Create)
            {
                record.gotoTable().Insert(record);
                cust_uuid = record.CUST_UUID;
            }
            _calBillingTotalPrice(record.BILLING_UUID);
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("BILLING_UUID", record.BILLING_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    public void _calBillingTotalPrice(string billingUuid)
    {


        #region Declare
        LwModel mod = new LwModel();
        //CustOrderDetail_Record record = new CustOrderDetail_Record();
        #endregion
        try
        {
            if (billingUuid.Trim().Length > 0)
            {
                //mod.getBillingDetail_By_BillingDetailUuid
                var allrecord = mod.getBillingDetail_By_BillingUuid(billingUuid);
                decimal sum = 0;
                List<object> allCustOrderUuid = new List<object>();
                foreach (var item in allrecord)
                {
                    allCustOrderUuid.Add(item.CUST_ORDER_UUID);
                    //sum += item.CUST_ORDER_DETAIL_TOTAL_PRICE.Value;
                }
                if (allCustOrderUuid.Count > 0)
                {
                    var drsCustOrder = mod.getCustOrder_By_CustOrderUuid(allCustOrderUuid);
                    foreach (var item in drsCustOrder)
                    {
                        sum += item.CUST_ORDER_TOTAL_PRICE.Value;
                    }
                    var billing = mod.getBilling_By_BillingUuid(billingUuid).AllRecord().First();
                    billing.BILLING_SUM_PRICE = sum;
                    billing.gotoTable().Update_Empty2Null(billing);
                }
                else {
                    var billing = mod.getBilling_By_BillingUuid(billingUuid).AllRecord().First();
                    billing.BILLING_SUM_PRICE = 0;
                    billing.gotoTable().Update_Empty2Null(billing);
                }                
            }

        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            throw ex;
        }
    }


    [DirectMethod("destoryBilling", DirectAction.Store)]
    public JObject destoryBilling(string pBillingUuid, Request request)
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

            var drsBillingDetail = mod.getBillingDetail_By_BillingUuid(pBillingUuid);
            var drBilling = mod.getBilling_By_BillingUuid(pBillingUuid).AllRecord().First() ;

            foreach (var item in drsBillingDetail) {
                item.gotoTable().Delete(item);
            }
            drBilling.gotoTable().Delete(drBilling); 
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("fullDestoryBilling", DirectAction.Store)]
    public JObject fullDestoryBilling(string pBillingUuid, Request request)
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

            var drsBillingDetail = mod.getBillingDetail_By_BillingUuid(pBillingUuid);
            var drBilling = mod.getBilling_By_BillingUuid(pBillingUuid).AllRecord().First();

            foreach (var item in drsBillingDetail)
            {
                item.gotoTable().Delete(item);
            }
            drBilling.gotoTable().Delete(drBilling);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("destoryBillingDetail", DirectAction.Store)]
    public JObject destoryBillingDetail(string pBillingDetailUuid, Request request)
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
            var drBillingDetail = mod.getBillingDetail_By_BillingDetailUuid(pBillingDetailUuid).AllRecord().First();
            drBillingDetail.gotoTable().Delete(drBillingDetail);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadVBillingDetail", DirectAction.Store)]
    public JObject loadVBillingDetail(string pBillingUuid, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = mod.getVBillingDetail_By_BillingUuid_Count(pBillingUuid);
            var data = mod.getVBillingDetail_By_BillingUuid(pBillingUuid, orderLimit);
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

    [DirectMethod("loadBilling", DirectAction.Store)]
    public JObject loadBilling(string pCustUuid,string pBillingIsActive, string pKeyword, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = mod.getBilling_By_CustUuid_Keyword_Count(pCustUuid, pBillingIsActive,pKeyword);
            var data = mod.getBilling_By_CustUuid_Keyword(pCustUuid, pBillingIsActive,pKeyword, orderLimit);
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


    [DirectMethod("addBillingDetail", DirectAction.Load)]
    public JObject addBillingDetail(string pBillingUuid , string arsCustOrderUuid, Request request)
    {
        #region Declare
        LwModel mod = new LwModel();
        Billing_Record record = new Billing_Record();
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
            var drsBillingDetail = mod.getBillingDetail_By_BillingUuid(pBillingUuid);
            var arrCustOrderUuid = new List<string>();

            foreach (var item in arsCustOrderUuid.Split('|')) {
                if (item.Trim().Length > 0) {
                    arrCustOrderUuid.Add(item);
                }
            }
            var itemCount = 0;
            decimal sumPrice = 0; 
            foreach (var item in arrCustOrderUuid) {
                var count = drsBillingDetail.Count(c => c.CUST_ORDER_UUID.Equals(item));
                if (count == 0) {
                    var newDr = new BillingDetail_Record();
                    newDr.CUST_ORDER_UUID = item;
                    newDr.BILLING_UUID = pBillingUuid;
                    newDr.BILLING_DETAIL_UUID = LK.Util.UID.Instance.GetUniqueID();
                    newDr.BILLING_DETAIL_CR = DateTime.Now;
                    newDr.gotoTable().Insert_Empty2Null(newDr);

                    var drCustOrder = mod.getCustOrder_By_CustOrderUuid(item).AllRecord().First();
                    sumPrice += drCustOrder.CUST_ORDER_TOTAL_PRICE.Value;

                }
                itemCount++;
            }

            var drBilling = mod.getBilling_By_BillingUuid(pBillingUuid).AllRecord().First();
            drBilling.BILLING_ITEM_COUNT = itemCount;
            drBilling.BILLING_SUM_PRICE = sumPrice;
            drBilling.gotoTable().Update_Empty2Null(drBilling);

            
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }


    }

    public string getBillingId()
    {
        LwModel mod = new LwModel();
        var drs = mod.getBillingId_By_BillingIdUuid(DateTime.Now.ToString("yyyyMMdd")).AllRecord();
        
        if (drs.Count == 0)
        {
            BillingId_Record newRow = new BillingId_Record();
            newRow.BILLING_ID_UUID = DateTime.Now.ToString("yyyyMMdd");
            newRow.MAX = 1;
            newRow.gotoTable().Insert_Empty2Null(newRow);
            return newRow.BILLING_ID_UUID + String.Format("{0:0000}", newRow.MAX);
        }
        else
        {
            var dr = drs.First();
            //drs.First()drs.Max(c => c.MAX).Value()+1
            dr.MAX = dr.MAX + 1;
            dr.gotoTable().Update_Empty2Null(dr);
            return dr.BILLING_ID_UUID + String.Format("{0:0000}", dr.MAX);
        }

    }

    [DirectMethod("pdfBilling", DirectAction.Load)]
    public JObject pdfBilling(string pBillingUuid, Request request)
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

            var fileSavePath = getBillingPath(pBillingUuid, out downloadfilename);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(fileSavePath, System.IO.FileMode.Create));
            doc.Open();
            doc.Add(new Paragraph(" ", fontChinese10));
            //begin
            writer.DirectContent.BeginText();
            writer.DirectContent.SetTextMatrix(260, 800);
            writer.DirectContent.SetFontAndSize(bfChinese, 16);
            //表頭
            writer.DirectContent.ShowText("請款單");
            doc.Add(new Paragraph(" ", fontChinese10));
            //end
            writer.DirectContent.EndText();

            PdfPTable table = new PdfPTable(new float[] { 8f, 8f, 15f, 5f, 5f, 5f, 7f, 10f });
            table.WidthPercentage = 100;
            table.SpacingAfter = 0f;
            //第1行 直的由上而下            
            writer.DirectContent.SetTextMatrix(45, 780);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);
            
            var drBilling = model.getBilling_By_BillingUuid(pBillingUuid).AllRecord().First();
            writer.DirectContent.ShowText("請款單編號：" + drBilling.BILLING_ID);

            writer.DirectContent.SetTextMatrix(45, 770);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);
            writer.DirectContent.ShowText("客戶公司：" + drBilling.BILLING_CUST_NAME);

            writer.DirectContent.SetTextMatrix(45, 760);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);
            writer.DirectContent.ShowText("統一編號：" + drBilling.BILLING_CUST_UNIFORM_NUM);

            writer.DirectContent.SetTextMatrix(45, 750);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);
            var drCust = model.getCust_By_CustUuid(drBilling.CUST_UUID).AllRecord().First();
            writer.DirectContent.ShowText("公司電話：" + drCust.CUST_TEL);


            writer.DirectContent.SetTextMatrix(45, 740);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);            
            writer.DirectContent.ShowText("帳號地址：" + drBilling.BILLING_CUST_ADDRESS);


            //writer.DirectContent.SetTextMatrix(45, 740);
            //writer.DirectContent.SetFontAndSize(bfChinese, 10);
            //writer.DirectContent.ShowText("備      註：" + "未完成");

            //第2行 直的由上而下
            writer.DirectContent.SetTextMatrix(380, 780);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);
            writer.DirectContent.ShowText("製單日期  ：" + drBilling.BILLING_REPORT_DATE.Value.ToString("yyyy/MM/dd"));

            writer.DirectContent.SetTextMatrix(380, 770);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);
            writer.DirectContent.ShowText("列印時間  ：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm"));

            //writer.DirectContent.SetTextMatrix(380, 760);
            //writer.DirectContent.SetFontAndSize(bfChinese, 10);
            //writer.DirectContent.ShowText("供應商電話：" + drBilling.billing_cust.billing_cust.MY_ORDER_SUPPLIER_TEL);

            writer.DirectContent.SetTextMatrix(380, 740);
            writer.DirectContent.SetFontAndSize(bfChinese, 10);
            writer.DirectContent.ShowText("請款期間：" + drBilling.BILLING_START_DATE.Value.ToString("yyyy/MM/dd") + "~" + drBilling.BILLING_END_DATE.Value.ToString("yyyy/MM/dd"));
            var orderLimit = new OrderLimit("CUST_ORDER_ID", OrderLimit.OrderMethod.ASC);
            orderLimit.Start = 1;
            orderLimit.Limit = 99999;
            var drsVBillingExp = model.getVBillingExp_By_BillingUuid(drBilling.BILLING_UUID, orderLimit);

            //表格
            var cell1_1 = new PdfPCell(new Phrase("銷售日期", fontChinese10));
            cell1_1.Colspan = 1;
            cell1_1.HorizontalAlignment = 1;
            cell1_1.FixedHeight = 16;
            table.AddCell(cell1_1);

            var cell1_5 = new PdfPCell(new Phrase("訂單編號", fontChinese10));
            cell1_5.Colspan = 1;
            cell1_5.HorizontalAlignment = 1;
            table.AddCell(cell1_5);

            var cell1_6 = new PdfPCell(new Phrase("商品名稱", fontChinese10));
            cell1_6.Colspan = 1;
            cell1_6.HorizontalAlignment = 1;
            table.AddCell(cell1_6);

            var cell1_8 = new PdfPCell(new Phrase("數量", fontChinese10));
            cell1_8.Colspan = 1;
            cell1_8.HorizontalAlignment = 1;
            table.AddCell(cell1_8);

            var cell1_9 = new PdfPCell(new Phrase("單位", fontChinese10));
            cell1_9.Colspan = 1;
            cell1_9.HorizontalAlignment = 1;
            table.AddCell(cell1_9);

            var cell1_10 = new PdfPCell(new Phrase("單價", fontChinese10));
            cell1_10.Colspan = 1;
            cell1_10.HorizontalAlignment = 1;
            table.AddCell(cell1_10);

            var cell1_11 = new PdfPCell(new Phrase("小計", fontChinese10));
            cell1_11.Colspan = 1;
            cell1_11.HorizontalAlignment = 1;
            table.AddCell(cell1_11);

            var cell1_12 = new PdfPCell(new Phrase("備註", fontChinese10));
            cell1_12.Colspan = 1;
            cell1_12.HorizontalAlignment = 1;
            table.AddCell(cell1_12);
            //var drVMyOrderDetail = model.getVMyOrderDetail_By_MyOrderUuid_SupplierUuid_Keyword(pMyOrderUuid, "", "", new OrderLimit("MY_ORDER_DETAIL_UUID", OrderLimit.OrderMethod.ASC));
            
            //decimal sumMoney = 0;
            var _custOrderUuid = "";
            var isNew = true;
            for (var i = 0; i < drsVBillingExp.Count; i++) {
                var item = drsVBillingExp[i];
                string columnDate = item.CUST_ORDER_CR.Value.ToString("yyyy/MM/dd");
                string columnCustOrderId = item.CUST_ORDER_ID;
                string columnCustOrderDetailGoodsName = item.CUST_ORDER_DETAIL_GOODS_NAME;
                string columnCustOrderDetailGoodsCount = item.CUST_ORDER_DETAIL_COUNT.Value.ToString();
                string columnCustOrderDetailGoodsUnitName = item.CUST_ORDER_DETAIL_UNIT_NAME;
                string columnCustOrderDetailGoodsPrice = item.CUST_ORDER_DETAIL_PRICE.Value.ToString();
                string columnCustOrderDetailGoodsTotlaPrice = item.CUST_ORDER_DETAIL_TOTAL_PRICE.Value.ToString();
                string columnCustOrderDetailGoodsPs = item.CUST_ORDER_DETAIL_PS;


                if (_custOrderUuid == "")
                {
                    _custOrderUuid = item.CUST_ORDER_UUID;
                    isNew = true;
                }
                else if (item.CUST_ORDER_UUID != _custOrderUuid)
                {
                    _custOrderUuid = item.CUST_ORDER_UUID;
                    isNew = true;
                }
                else {
                    _custOrderUuid = item.CUST_ORDER_UUID;
                    isNew = false;
                }


                //銷售日期
                var cellD_1 = new PdfPCell(new Phrase(columnDate, fontChinese10));

                if (isNew == false) {
                    cellD_1 = new PdfPCell(new Phrase("", fontChinese10));
                    cellD_1.BorderWidthRight = 0f;
                    cellD_1.BorderWidthTop = 0f;
                    cellD_1.BorderWidthBottom = 0f;
                }

                cellD_1.Colspan = 1;
                cellD_1.HorizontalAlignment = 1;
                cellD_1.FixedHeight = 16;
                table.AddCell(cellD_1);



                //訂單編號
                var cellD_5 = new PdfPCell(new Phrase(columnCustOrderId, fontChinese10));
                if (isNew == false)
                {
                    cellD_5 = new PdfPCell(new Phrase("", fontChinese10));
                    cellD_5.BorderWidthRight = 0f;
                    cellD_5.BorderWidthTop = 0f;
                    cellD_5.BorderWidthBottom = 0f;
                }
                cellD_5.Colspan = 1;
                cellD_5.HorizontalAlignment = 0;
                table.AddCell(cellD_5);
                //商品名稱
                var cellD_6 = new PdfPCell(new Phrase(columnCustOrderDetailGoodsName, fontChinese10));
                cellD_6.Colspan = 1;
                cellD_6.HorizontalAlignment = 0;
                table.AddCell(cellD_6);
                //數量
                var cellD_8 = new PdfPCell(new Phrase(columnCustOrderDetailGoodsCount, fontChinese10));
                cellD_8.Colspan = 1;
                cellD_8.HorizontalAlignment = 1;
                table.AddCell(cellD_8);
                //單位
                var cellD_9 = new PdfPCell(new Phrase(columnCustOrderDetailGoodsUnitName, fontChinese10));
                cellD_9.Colspan = 1;
                cellD_9.HorizontalAlignment = 1;
                table.AddCell(cellD_9);
                //單價
                var cellD_10 = new PdfPCell(new Phrase(columnCustOrderDetailGoodsPrice, fontChinese10));
                cellD_10.Colspan = 1;
                cellD_10.HorizontalAlignment = 2;
                table.AddCell(cellD_10);
                //小計
                //var cellD_11 = new PdfPCell(new Phrase(item., fontChinese10));
                var cellD_11 = new PdfPCell(new Phrase(columnCustOrderDetailGoodsTotlaPrice, fontChinese10));
                cellD_11.Colspan = 1;
                cellD_11.HorizontalAlignment = 2;
                table.AddCell(cellD_11);
                //備註
                var cellD_12 = new PdfPCell(new Phrase(columnCustOrderDetailGoodsPs, fontChinese10));
                cellD_12.Colspan = 1;
                cellD_12.HorizontalAlignment = 0;
                table.AddCell(cellD_12);
                //sumMoney += item.cust.MY_ORDER_DETAIL_TOTAL_PRICE.Value; 
            }
                //foreach (var item in drsVBillingExp)
                //{
                    
                    
                //}
            //var isFirst = true;
            //資料
            
            //var cell3_11 = new PdfPCell(new Phrase(" " + ConvertSum(sumMoney.ToString()) + "  NT$ " + sumMoney.ToString(), fontChinese10));
            //cell3_11.FixedHeight = 16;
            //cell3_11.Colspan = 11;
            //cell3_11.HorizontalAlignment = 0;
            //table.AddCell(cell3_11);
            doc.Add(new Chunk("\n"));
            doc.Add(new Chunk("\n"));
            doc.Add(new Chunk("\n"));
            doc.Add(new Chunk("\n"));
            doc.Add(table);

            PdfPTable table2 = new PdfPTable(new float[] { 10f, 10f, 10f, 10f});
            table2.WidthPercentage = 100;
            table2.SpacingAfter = 10f;
            //表格2
            var cell2_1_1 = new PdfPCell(new Phrase("項目:"+drBilling.BILLING_ITEM_COUNT.ToString(), fontChinese10));
            cell2_1_1.Colspan = 1;
            cell2_1_1.HorizontalAlignment = 0;
            cell2_1_1.FixedHeight = 16;

            cell2_1_1.BorderWidthRight = 0f;
            cell2_1_1.BorderWidthLeft = 0f;
            cell2_1_1.BorderWidthBottom = 0f;

            table2.AddCell(cell2_1_1);

            var cell2_1_2 = new PdfPCell(new Phrase("應收金額:" + drBilling.BILLING_SUM_PRICE.Value.ToString(), fontChinese10));
            cell2_1_2.Colspan = 1;
            cell2_1_2.HorizontalAlignment =0;
            cell2_1_2.FixedHeight = 16;
            cell2_1_2.BorderWidthRight = 0f;
            cell2_1_2.BorderWidthLeft = 0f;
            cell2_1_2.BorderWidthBottom = 0f;
            table2.AddCell(cell2_1_2);

            var cell2_1_3 = new PdfPCell(new Phrase("折扣:" + drBilling.BILLING_DISCOUNT.Value.ToString(), fontChinese10));
            cell2_1_3.Colspan = 1;
            cell2_1_3.HorizontalAlignment = 0;
            cell2_1_3.FixedHeight = 16;
            cell2_1_3.BorderWidthRight = 0f;
            cell2_1_3.BorderWidthLeft = 0f;
            cell2_1_3.BorderWidthBottom = 0f;
            table2.AddCell(cell2_1_3);

            var cell2_1_4 = new PdfPCell(new Phrase("請款金額:" + drBilling.BILLING_TOTAL_PRICE.ToString(), fontChinese10));
            cell2_1_4.Colspan = 1;
            cell2_1_4.HorizontalAlignment =0;
            cell2_1_4.FixedHeight = 16;
            
            cell2_1_4.BorderWidthRight = 0f;
            cell2_1_4.BorderWidthLeft = 0f;
            cell2_1_4.BorderWidthBottom = 0f;
            table2.AddCell(cell2_1_4);
            doc.Add(table2);

            if (drBilling.BILLING_PS.Trim().Length == 0) {
                doc.Add(new Paragraph("請款單備註：無", fontChinese12));
            }
            else
            {
                doc.Add(new Paragraph("請款單備註：" + drBilling.BILLING_PS, fontChinese12));
            }

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

    public string getBillingPath(string pMyOrderUuid, out string extName)
    {
        HttpServerUtility server = System.Web.HttpContext.Current.Server;
        var uploadFolder = server.MapPath(Limew.Parameter.Config.ParemterConfigs.GetConfig().UploadFolder);
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(uploadFolder);
        if (di.Exists == false)
        {
            di.Create();
        }

        uploadFolder = uploadFolder + "billing//";

        di = new System.IO.DirectoryInfo(uploadFolder);
        if (di.Exists == false)
        {
            di.Create();
        }
        extName = pMyOrderUuid + "-" + LK.Util.UID.Instance.GetUniqueID() + ".pdf";

        return uploadFolder = uploadFolder + extName;
    }
}

