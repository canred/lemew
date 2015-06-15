﻿#region USING
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
using System.Text;
using LK.Util;
using System.Data;
using System.Diagnostics;
#endregion
[DirectService("SiteMapAction")]
public partial class SiteMapAction : BaseAction
{
    [DirectMethod("loadSiteMapTree", DirectAction.TreeStore)]
    public JObject loadSiteMapTree(string parentUuid, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel model = new BasicModel();
        SitemapV tblSitemap = new SitemapV();
        #endregion
        try
        {    /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }         /*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得資料*/
            var genTable = new Limew.Model.Basic.Table.SitemapV();
            var dataTable = model.getSitemapV_By_RootUuid_DataTable(parentUuid);
            dataTable.Columns.Add("leaf");
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("checked", typeof(Boolean));
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i]["ROOT_UUID"].ToString() == dataTable.Rows[i]["UUID"].ToString())
                {
                    dataTable.Rows.RemoveAt(i);
                    i--;
                }
            }
            foreach (DataRow dr in dataTable.Rows)
            {
                var children = model.getSitemapV_By_RootUuid_DataTable(dr[tblSitemap.UUID].ToString());
                if (children.Rows.Count == 0)
                {
                    dr["leaf"] = "true";
                }
                else
                {
                    dr["leaf"] = "false";
                }
                dr["id"] = dr[tblSitemap.UUID].ToString();
                dr["checked"] = dr["IS_ACTIVE"].ToString().ToLower() == "y" ? true : false;
            }
            JArray jarray = new JArray();
            jarray = JsonHelper.DataTableSerializerJArray(dataTable);
            /*使用Store Std out 『Sotre物件標準輸出格式』*/
            return ExtDirect.Direct.Helper.Tree.Output(jarray, 9999);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }
   
    [DirectMethod("loadTreeRoot", DirectAction.Store)]
    public JObject loadTreeRoot(string parentUuid, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel model = new BasicModel();
        Sitemap table = new Sitemap();
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
            var data = model.getSitemapV_By_ApplicationHead(parentUuid);
            foreach (var dr in data)
            {
                if (dr.UUID == dr.ROOT_UUID)
                {
                    return JsonHelper.RecordBaseJObject(dr);
                }
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Data Not Found!"));
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }
  
    [DirectMethod("load", DirectAction.Store)]
    public JObject load(string pApplicationHeadUuid, string pIsActive, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel modBasic = new BasicModel();
        OrderLimit orderLimit = null;
        SitemapV tblSitmap = new SitemapV();
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
            /*是Store操作一下就可能含有分頁資訊。*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            /*取得總資料數*/
            var totalCount = modBasic.getSitmapV_By_ApplicationHeadUuid_Count(pApplicationHeadUuid, pIsActive);
            /*取得資料*/
            var data = modBasic.getSitmapV_By_ApplicationHeadUuid(pApplicationHeadUuid, pIsActive, orderLimit);
            if (data.Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                jobject = JsonHelper.RecordBaseListJObject(data);
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

    [DirectMethod("loadThisApplication", DirectAction.Store)]
    public JObject loadThisApplication(string pApplicationHeadUuid, string pIsActive, string pageNo, string limitNo, string sort, string dir, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel modBasic = new BasicModel();
        OrderLimit orderLimit = null;
        SitemapV tblSitmap = new SitemapV();
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
            string appName = Limew.Parameter.Config.ParemterConfigs.GetConfig().AppName;
            ApplicationHead tb = new ApplicationHead(LK.Config.DataBase.Factory.getInfo());
            var drs = tb.Where(new LK.DB.SQLCondition(tb).Equal(tb.NAME, appName))
                .FetchAll<ApplicationHead_Record>();
            
            if (drs.Count > 0)
            {
                pApplicationHeadUuid = drs.First().UUID;
            }
            /*是Store操作一下就可能含有分頁資訊。*/
            orderLimit = ExtDirect.Direct.Helper.Order.getOrderLimit(pageNo, limitNo, sort, dir);
            /*取得總資料數*/
            var totalCount = modBasic.getSitmapV_By_ApplicationHeadUuid_Count(pApplicationHeadUuid, pIsActive);
            /*取得資料*/
            var data = modBasic.getSitmapV_By_ApplicationHeadUuid(pApplicationHeadUuid, pIsActive, orderLimit);
            if (data.Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                jobject = JsonHelper.RecordBaseListJObject(data);
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

    [DirectMethod("submit", DirectAction.FormSubmission)]
    public JObject submit(string uuid,
                                        string is_active,
                                        string create_date,
                                        string create_user,
                                        string update_date,
                                        string update_user,
                                        string id,
                                        string name,
                                        string description,
                                        string url,
                                        string parameter_class,
                                        string application_head_uuid,
                                        string p_mode,
                                        Request request)
    {
        #region Declare
        var action = SubmitAction.None;
        BasicModel modBasic = new BasicModel();
        Apppage_Record drAppPage = new Apppage_Record();
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
            if (uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                drAppPage = modBasic.getApppage_By_Uuid(uuid).AllRecord().First();
            }
            else
            {
                action = SubmitAction.Create;
                drAppPage.UUID = LK.Util.UID.Instance.GetUniqueID();
                drAppPage.CREATE_DATE = DateTime.Now;
                drAppPage.CREATE_USER = getUser().UUID;
                drAppPage.UPDATE_USER = getUser().UUID;
                drAppPage.CREATE_DATE = DateTime.Now;
            }
            /*固定要更新的欄位*/
            drAppPage.UPDATE_DATE = DateTime.Now;
            /*非固定更新的欄位*/
            drAppPage.IS_ACTIVE = is_active;
            drAppPage.DESCRIPTION = description;
            drAppPage.ID = id;
            drAppPage.NAME = name;
            drAppPage.URL = url;
            drAppPage.PARAMETER_CLASS = parameter_class;
            drAppPage.APPLICATION_HEAD_UUID = application_head_uuid;
            drAppPage.P_MODE = p_mode;
            if (action == SubmitAction.Edit)
            {
                drAppPage.gotoTable().Update(drAppPage);
            }
            else if (action == SubmitAction.Create)
            {
                drAppPage.gotoTable().Insert(drAppPage);
            }
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("UUID", drAppPage.UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }
   
    [DirectMethod("info", DirectAction.Store)]
    public JObject info(string pUuid, Request request)
    {
        #region Declare
        BasicModel modBasic = new BasicModel();
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
            var dtAppPage = modBasic.getApppage_By_Uuid(pUuid);
            if (dtAppPage.AllRecord().Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                return ExtDirect.Direct.Helper.Form.OutputJObject(JsonHelper.RecordBaseJObject(dtAppPage.AllRecord().First()));
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Data Not Found!"));
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }
  
    [DirectMethod("destroyByUuid", DirectAction.Store)]
    public JObject destroyByUuid(string pUuid, Request request)
    {
        #region Declare
        BasicModel modBasic = new BasicModel();
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
            var dtAppPage = modBasic.getApppage_By_Uuid(pUuid);
            if (dtAppPage.AllRecord().Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                dtAppPage.DeleteAllRecord();
                return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Data Not Found!"));
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("setSiteMapIsActive", DirectAction.Store)]
    public JObject setSiteMapIsActive(string pUuid, string is_active, Request request)
    {
        #region Declare
        BasicModel modBasic = new BasicModel();
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
            var dtSitemap = modBasic.getSitemap_By_Uuid(pUuid);
            if (dtSitemap.AllRecord().Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                var drSitemap = dtSitemap.AllRecord().First();
                if (is_active == "1" || is_active.ToUpper() == "TRUE" || is_active.ToUpper() == "Y")
                {
                    drSitemap.IS_ACTIVE = "Y";
                }
                else
                {
                    drSitemap.IS_ACTIVE = "N";
                }
                drSitemap.UPDATE_DATE = DateTime.Now;
                drSitemap.UPDATE_USER = getUser().UUID;

                drSitemap.gotoTable().Update(drSitemap);
                return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Setting Sitemap record fail."));
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("deleteSiteMap", DirectAction.Store)]
    public JObject deleteSiteMap(string pUuid, string pApplictionUuid, Request request)
    {
        #region Declare
        BasicModel modBasic = new BasicModel();
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
            //判斷appmenu是否有此sitemap的對應
            //若有，則需回應error
            var dtAppMenu = modBasic.getAppMenu_By_ApplicationHeadAndSitemap_Count(pApplictionUuid, pUuid);
            if (dtAppMenu > 0)
            {
                return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("已存在對應選單，無法刪除"));
            }
            else
            {
                var dtSitemap = modBasic.getSitemap_By_Uuid(pUuid);
                if (dtSitemap.AllRecord().Count > 0)
                {
                    /*將List<RecordBase>變成JSON字符串*/
                    var drSitemap = dtSitemap.AllRecord().First();
                    drSitemap.gotoTable().Delete(drSitemap);
                    return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
                }
                return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("delete SiteMap record fail."));
            }
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("addSiteMap", DirectAction.Store)]
    public JObject addSiteMap(string pParentUuid, string pAppPageUuid, Request request)
    {
        #region Declare
        BasicModel modBasic = new BasicModel();
        #endregion
        try
        { /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            } /*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            var dtSitemap = modBasic.getSitemap_By_Uuid(pParentUuid);
            if (dtSitemap.AllRecord().Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                var drSitemap = dtSitemap.AllRecord().First();
                drSitemap.HASCHILD = "Y";
                drSitemap.UPDATE_DATE = DateTime.Now;
                drSitemap.UPDATE_USER = getUser().UUID;
                var drChildSitemap = drSitemap.Clone();
                drChildSitemap.UUID = LK.Util.UID.Instance.GetUniqueID();
                drChildSitemap.UPDATE_DATE = DateTime.Now;
                drChildSitemap.UPDATE_USER = getUser().UUID;
                drChildSitemap.CREATE_DATE = DateTime.Now;
                drChildSitemap.CREATE_USER = getUser().UUID;
                drChildSitemap.APPPAGE_UUID = pAppPageUuid;
                drChildSitemap.SITEMAP_UUID = drSitemap.UUID;
                drChildSitemap.ROOT_UUID = drSitemap.UUID;
                drChildSitemap.gotoTable().Insert(drChildSitemap);
                drSitemap.gotoTable().Update_Empty2Null(drSitemap);
                return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("Setting Sitemap record fail."));
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }
}