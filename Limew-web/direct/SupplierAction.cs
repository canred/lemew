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

[DirectService("SupplierAction")]
public class SupplierAction : BaseAction
{

    [DirectMethod("infoSupplier", DirectAction.Load, MethodVisibility.Visible)]
    public JObject infoSupplier(string pSupplierUuid, Request request)
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
            var data = model.getSupplier_By_SupplierUuid(pSupplierUuid);

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

    [DirectMethod("loadSupplier", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadSupplier(string pKeyword, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = mod.getSupplier_By_Keyword_Count(pKeyword);
            var data = mod.getSupplier_By_Keyword(pKeyword, orderLimit);
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

    [DirectMethod("submitSupplier", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitSupplier(  string supplier_uuid,
                                    string supplier_name,
                                    string supplier_tel,
                                    string supplier_fax,
                                    string supplier_address,
                                    string supplier_contact_name,
                                    string supplier_sales_name,
                                    string supplier_sales_phone,
                                    string supplier_contact_phone,
                                    string supplier_contact_email,
                                    string supplier_sales_email,
                                    string supplier_ps,
                                    string supplier_is_active, HttpRequest request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        Supplier_Record record = new Supplier_Record();
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
            if (supplier_uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = mod.getSupplier_By_SupplierUuid(supplier_uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.SUPPLIER_UUID = LK.Util.UID.Instance.GetUniqueID();
            }
            record.SUPPLIER_ADDRESS = supplier_address;
            record.SUPPLIER_CONTACT_EMAIL = supplier_contact_email;
            record.SUPPLIER_CONTACT_NAME = supplier_contact_name;
            record.SUPPLIER_CONTACT_PHONE = supplier_contact_phone;
            record.SUPPLIER_FAX = supplier_fax;
            record.SUPPLIER_IS_ACTIVE = Convert.ToInt16(supplier_is_active);
            record.SUPPLIER_NAME = supplier_name;
            record.SUPPLIER_PS = supplier_ps;
            record.SUPPLIER_SALES_EMAIL = supplier_sales_email;
            record.SUPPLIER_SALES_NAME = supplier_sales_name;
            record.SUPPLIER_SALES_PHONE = supplier_sales_phone;
            record.SUPPLIER_TEL = supplier_tel;
            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            else if (action == SubmitAction.Create)
            {
                record.gotoTable().Insert(record);
                supplier_uuid = record.SUPPLIER_UUID;
            }
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("SUPPLIER_UUID", record.SUPPLIER_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("destorySupplier", DirectAction.Store, MethodVisibility.Visible)]
    public JObject destorySupplier(string pUuid, Request request)
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

            var data = mod.getSupplier_By_SupplierUuid(pUuid);
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


    [DirectMethod("infoSupplierGoods", DirectAction.Load, MethodVisibility.Visible)]
    public JObject infoSupplierGoods(string pSupplierGoodsUuid, Request request)
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
            var data = model.getSupplierGoods_By_SupplierGoodsUuid(pSupplierGoodsUuid);

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

    [DirectMethod("loadSupplierGoods", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadSupplierGoods(string pSupplierUuid, string pKeyword, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = mod.getSupplierGoods_By_SupplierUuid_Keyword_Count(pSupplierUuid, pKeyword);
            var data = mod.getSupplierGoods_By_SupplierUuid_Keyword(pSupplierUuid, pKeyword, orderLimit);
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

    [DirectMethod("destorySupplierGoods", DirectAction.Store, MethodVisibility.Visible)]
    public JObject destorySupplierGoods(string pSupplierGoodsUuid, Request request)
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

            var data = mod.getSupplierGoods_By_SupplierGoodsUuid(pSupplierGoodsUuid);
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

    [DirectMethod("submitSupplierGoods", DirectAction.FormSubmission, MethodVisibility.Visible)]
    public JObject submitSupplierGoods(string supplier_goods_uuid,
                                        string supplier_goods_name,
                                        string unit_uuid,
                                        string supplier_goods_sn,
                                        string supplier_goods_spec,
                                        string supplier_goods_price,
                                        string supplier_goods_cost,
                                        string supplier_goods_is_active,
                                        string supplier_uuid, HttpRequest request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        SupplierGoods_Record record = new SupplierGoods_Record();
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
            if (supplier_goods_uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = mod.getSupplierGoods_By_SupplierGoodsUuid(supplier_goods_uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                record.SUPPLIER_GOODS_UUID = LK.Util.UID.Instance.GetUniqueID();
            }
            record.SUPPLIER_GOODS_NAME = supplier_goods_name;
            record.UNIT_UUID = unit_uuid;
            record.SUPPLIER_GOODS_SN = supplier_goods_sn;
            record.SUPPLIER_GOODS_SPEC = supplier_goods_spec;
            record.SUPPLIER_GOODS_PRICE = Convert.ToDecimal( supplier_goods_price );
            record.SUPPLIER_GOODS_COST = Convert.ToDecimal(supplier_goods_cost);
            record.SUPPLIER_GOODS_IS_ACTIVE = Convert.ToInt16(supplier_goods_is_active);
            record.SUPPLIER_UUID = supplier_uuid;
           
            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            else if (action == SubmitAction.Create)
            {
                record.gotoTable().Insert(record);
                supplier_goods_uuid = record.SUPPLIER_UUID;
            }
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("SUPPLIER_GOODS_UUID", record.SUPPLIER_GOODS_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadVSupplierGoods", DirectAction.Store, MethodVisibility.Visible)]
    public JObject loadVSupplierGoods(string pSupplierUuid, string pKeyword, string pageNo, string limitNo, string sort, string dir, Request request)
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
            var totalCount = mod.getVSupplierGoods_By_SupplierUuid_Keyword_Count(pSupplierUuid, pKeyword);
            var data = mod.getVSupplierGoods_By_SupplierUuid_Keyword(pSupplierUuid, pKeyword, orderLimit);
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

