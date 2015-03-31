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

    [DirectMethod("loadMyOrder", DirectAction.Store)]
    public JObject loadMyOrder(string pKeyword, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = mod.getMyOrder_By_Keyword_Count(pKeyword);
            var data = mod.getMyOrder_By_Keyword(pKeyword, orderLimit);
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
string my_order_date,
string my_order_supplier_name,
string my_order_supplier_tel,
string my_order_supplier_man,
string my_order_goods_name,
string my_order_goods_count,
string my_order_price,
string my_order_total_price,
string my_order_ps,
string my_order_is_finish,
string my_order_pay_method,
string my_order_is_active,
string my_order_attendant_uuid, Request request)
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

            if (my_order_date.Trim().Length > 0)
            {
                record.MY_ORDER_DATE = Convert.ToDateTime( my_order_date );
            }
            record.MY_ORDER_SUPPLIER_NAME = my_order_supplier_name;
            record.MY_ORDER_SUPPLIER_TEL = my_order_supplier_tel;
            record.MY_ORDER_SUPPLIER_MAN = my_order_supplier_man;
            record.MY_ORDER_GOODS_NAME = my_order_goods_name;
            if (my_order_goods_count.Trim().Length > 0)
            {
                record.MY_ORDER_GOODS_COUNT = Convert.ToInt32( my_order_goods_count);
            }
            if (my_order_price.Trim().Length > 0)
            {

                record.MY_ORDER_PRICE = Convert.ToDecimal( my_order_price);
            }

            if (my_order_price.Trim().Length > 0)
            {
                record.MY_ORDER_TOTAL_PRICE =Convert.ToDecimal( my_order_total_price );
            }
            record.MY_ORDER_PS = my_order_ps;
            if (my_order_price.Trim().Length > 0)
            {
                record.MY_ORDER_IS_FINISH = Convert.ToInt32( my_order_is_finish);
            }
            record.MY_ORDER_PAY_METHOD = my_order_pay_method;
            if (my_order_price.Trim().Length > 0)
            {
                record.MY_ORDER_IS_ACTIVE = Convert.ToInt32( my_order_is_active);
            }
            record.MY_ORDER_ATTENDANT_UUID = this.getUser().UUID;
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


    [DirectMethod("quickEdit", DirectAction.Load)]
    public JObject quickEdit(string my_order_uuid,
string my_order_date,
string my_order_supplier_name,
string my_order_supplier_tel,
string my_order_supplier_man,
string my_order_goods_name,
string my_order_goods_count,
string my_order_price,
string my_order_total_price,
string my_order_ps,
string my_order_is_finish,
string my_order_pay_method,
string my_order_is_active,
string my_order_attendant_uuid, Request request)
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

            if (my_order_date.Trim().Length > 0)
            {
                record.MY_ORDER_DATE = Convert.ToDateTime(my_order_date);
            }
            record.MY_ORDER_SUPPLIER_NAME = my_order_supplier_name;
            record.MY_ORDER_SUPPLIER_TEL = my_order_supplier_tel;
            record.MY_ORDER_SUPPLIER_MAN = my_order_supplier_man;
            record.MY_ORDER_GOODS_NAME = my_order_goods_name;
            if (my_order_goods_count.Trim().Length > 0)
            {
                record.MY_ORDER_GOODS_COUNT = Convert.ToInt32(my_order_goods_count);
            }
            if (my_order_price.Trim().Length > 0)
            {

                record.MY_ORDER_PRICE = Convert.ToDecimal(my_order_price);
            }

            if (my_order_price.Trim().Length > 0 && my_order_goods_count.Trim().Length>0)
            {
                record.MY_ORDER_TOTAL_PRICE = Convert.ToDecimal(my_order_price.Trim()) * Convert.ToDecimal(my_order_goods_count.Trim());
            }
            record.MY_ORDER_PS = my_order_ps;
            if (my_order_price.Trim().Length > 0)
            {
                record.MY_ORDER_IS_FINISH = Convert.ToInt32(my_order_is_finish);
            }
            record.MY_ORDER_PAY_METHOD = my_order_pay_method;
            if (my_order_price.Trim().Length > 0)
            {
                record.MY_ORDER_IS_ACTIVE = Convert.ToInt32(my_order_is_active);
            }
            record.MY_ORDER_ATTENDANT_UUID = this.getUser().UUID;


            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }



    [DirectMethod("cloneMyOrder", DirectAction.Load)]
    public JObject cloneMyOrder(string my_order_uuid, Request request)
    {
        #region Declare
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
                record = mod.getMyOrder_By_MyOrderUuid(my_order_uuid).AllRecord().First();
            }
            else {
                throw new Exception("資料不存在!");
            }

            record.MY_ORDER_UUID = LK.Util.UID.Instance.GetUniqueID();
            record.MY_ORDER_ATTENDANT_UUID = this.getUser().UUID;
            record.gotoTable().Insert_Empty2Null(record);

            return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
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

