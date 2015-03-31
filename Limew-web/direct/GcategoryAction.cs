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

[DirectService("GcategoryAction")]
public class GcategoryAction : BaseAction
{
    [DirectMethod("infoGcategory", DirectAction.Load)]
    public JObject infoGcategory(string pGcategoryUuid, Request request)
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
            var data = model.getGcategory_By_GcategoryUuid(pGcategoryUuid);

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
    [DirectMethod("submitGcategory", DirectAction.FormSubmission)]
    public JObject submitGcategory(string gcategory_uuid,
string gcategory_name,
string gcategory_is_active,
string gcategory_parent_uuid, Request request)
    {


        #region Declare
        var action = SubmitAction.None;
        LwModel mod = new LwModel();
        Gcategory_Record record = new Gcategory_Record();
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
            if (gcategory_uuid.Trim().Length > 0)
            {
                action = SubmitAction.Edit;
                record = mod.getGcategory_By_GcategoryUuid(gcategory_uuid).AllRecord().First();
                record.GCATEGORY_IS_ACTIVE = gcategory_is_active;
                record.GCATEGORY_NAME = gcategory_name;
                record.GCATEGORY_PARENT_UUID = gcategory_parent_uuid;
            }
            else
            {
                action = SubmitAction.Create;
                record.GCATEGORY_UUID = LK.Util.UID.Instance.GetUniqueID();
                record.GCATEGORY_IS_ACTIVE = gcategory_is_active;
                record.GCATEGORY_NAME = gcategory_name;
                record.GCATEGORY_PARENT_UUID = gcategory_parent_uuid;
                record.gotoTable().Insert_Empty2Null(record);
            }
            
           
            //string fullUuid = "";

            if (gcategory_parent_uuid.Trim().Length > 0) {
                record.GCATEGORY_FULL_NAME = getGcategoryFullName("", record.GCATEGORY_UUID);
                record.GCATEGORY_FULL_UUID = getGcategoryFullUuid("", record.GCATEGORY_UUID);
                record.gotoTable().Update_Empty2Null(record);
            }
           
            if (action == SubmitAction.Edit)
            {
                record.gotoTable().Update_Empty2Null(record);
            }
            else if (action == SubmitAction.Create)
            {
                gcategory_uuid = record.GCATEGORY_UUID;
            }
            System.Collections.Hashtable otherParam = new System.Collections.Hashtable();
            otherParam.Add("GCATEGORY_UUID", record.GCATEGORY_UUID);
            return ExtDirect.Direct.Helper.Message.Success.OutputJObject(otherParam);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }


    [DirectMethod("deleteGcategory", DirectAction.Store)]
    public JObject deleteGcategory(string pGcategoryUuid, Request request)
    {
        #region Declare
        LwModel mod = new LwModel();
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            var dtGcategory = mod.getGcategory_By_GcategoryUuid(pGcategoryUuid);
            if (dtGcategory.AllRecord().Count > 0)
            {
                /*將List<RecordBase>變成JSON字符串*/
                var drGcategory = dtGcategory.AllRecord().First();
                drGcategory.gotoTable().Delete(drGcategory);
                return ExtDirect.Direct.Helper.Message.Success.OutputJObject();
            }
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(new Exception("delete SiteMap record fail."));
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    private string getGcategoryFullName(string fullName,string pGcategoryUuid) {
        
        LwModel mod = new LwModel();
        if (pGcategoryUuid.Trim().Length > 0)
        {
            var self = mod.getGcategory_By_GcategoryUuid(pGcategoryUuid).AllRecord().First();
            fullName = self.GCATEGORY_NAME +"|"+ fullName;
            if (self.GCATEGORY_PARENT_UUID.Trim().Length > 0) {
                return getGcategoryFullName(fullName, self.GCATEGORY_PARENT_UUID);
            }
            else
            {
                return fullName;
            }
        }
        else {
            return fullName;
        }
    }

    private string getGcategoryFullUuid(string fullUuid, string pGcategoryUuid)
    {

        LwModel mod = new LwModel();
        if (pGcategoryUuid.Trim().Length > 0)
        {
            var self = mod.getGcategory_By_GcategoryUuid(pGcategoryUuid).AllRecord().First();
            fullUuid = self.GCATEGORY_UUID + "|" + fullUuid;
            if (self.GCATEGORY_PARENT_UUID.Trim().Length > 0)
            {
                return getGcategoryFullUuid(fullUuid, self.GCATEGORY_PARENT_UUID);
            }
            else
            {
                return fullUuid;
            }
        }
        else
        {
            return fullUuid;
        }
    }
    [DirectMethod("loadTreeRoot", DirectAction.Store)]
    public JObject loadTreeRoot( Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        LwModel model = new LwModel();
        Gcategory table = new Gcategory();
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
            var data = model.getGcategoryRoot();
            foreach (var dr in data)
            {
                if (dr.GCATEGORY_PARENT_UUID.Trim() == "")
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

    [DirectMethod("loadGcagegoryTree", DirectAction.TreeStore)]
    public JObject loadGcagegoryTree(Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();        
        LwModel mod = new LwModel();
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得資料*/
            var genTable = new Gcategory();
            var dataTable = mod.getGcategory_By_Root_DataTable();
            dataTable.Columns.Add("leaf");
            dataTable.Columns.Add("name");
            dataTable.Columns.Add("checked", typeof(Boolean));
            if (dataTable.Rows.Count == 0) {
                Gcategory_Record newDr = new Gcategory_Record();
                newDr.GCATEGORY_FULL_NAME = "ROOT|";
                newDr.GCATEGORY_UUID = LK.Util.UID.Instance.GetUniqueID();
                newDr.GCATEGORY_FULL_UUID = newDr.GCATEGORY_UUID + "|";
                newDr.GCATEGORY_IS_ACTIVE = "Y";
                newDr.GCATEGORY_NAME = "ROOT";
                newDr.GCATEGORY_PARENT_UUID = null;
                newDr.gotoTable().Insert_Empty2Null(newDr);
                dataTable = mod.getGcategory_By_Root_DataTable();
                dataTable.Columns.Add("leaf");
                dataTable.Columns.Add("name");
                dataTable.Columns.Add("checked", typeof(Boolean));
            }
            foreach (DataRow dr in dataTable.Rows)
            {

                var children = mod.getGcategory_By_RootUuid_DataTable(dr[genTable.GCATEGORY_UUID].ToString());
                if (children.Rows.Count == 0)
                {
                    dr["leaf"] = "true";
                }
                else
                {
                    dr["leaf"] = "false";
                }
                dr["name"] = dr[genTable.GCATEGORY_NAME].ToString();
                dr["checked"] = dr[genTable.GCATEGORY_IS_ACTIVE].ToString().ToLower() == "Y" ? true : false;

            }
            var jarray = JsonHelper.DataTableSerializerJArray(dataTable);
            return ExtDirect.Direct.Helper.Tree.Output(jarray, 9999);
        }
        catch (Exception ex)
        {
            log.Error(ex); LK.MyException.MyException.Error(this, ex);
            /*將Exception轉成EXT Exception JSON格式*/
            return ExtDirect.Direct.Helper.Message.Fail.OutputJObject(ex);
        }
    }

    [DirectMethod("loadGcategoryTree", DirectAction.TreeStore)]
    public JObject loadGcategoryTree(string pGcategoryParentUuid, Request request)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel model = new BasicModel();
        LwModel mod = new LwModel();
        #endregion
        try
        {
            /*Cloud身份檢查*/
            checkUser(request.HttpRequest);
            if (this.getUser() == null)
            {
                throw new Exception("Identity authentication failed.");
            }/*權限檢查*/
            if (!checkProxy(new StackTrace().GetFrame(0)))
            {
                throw new Exception("Permission Denied!");
            };
            /*取得資料*/

            var genTable = new Gcategory();
            //var drsAppmenu = model.getAppmenu_By_Uuid(parentUuid).AllRecord();
            var drsGcagegory = mod.getGcategory_By_GcategoryUuid(pGcategoryParentUuid).AllRecord();
            var drGcagegory = drsGcagegory.First();            
            drsGcagegory = mod.getGcategory_By_StartLikeGcategoryFullUuid(drGcagegory.GCATEGORY_FULL_UUID);
            //var dataTable = model.getAppmenu_By_RootUuid_DataTable(parentUuid);
            var dataTable = mod.getGcategory_By_RootUuid_DataTable(pGcategoryParentUuid);
            dataTable.Columns.Add("leaf", System.Type.GetType("System.Boolean"));
            dataTable.Columns.Add("name");
            dataTable.Columns.Add("expanded", System.Type.GetType("System.Boolean"));
            foreach (DataRow dr in dataTable.Rows)
            {

                //var children = model.getAppmenu_By_RootUuid_DataTable(dr[genTable.UUID].ToString());
                var children = mod.getGcategory_By_RootUuid_DataTable(dr[genTable.GCATEGORY_PARENT_UUID].ToString());
                if (children.Rows.Count == 0)
                {
                    dr["leaf"] = true;
                }
                else
                {
                    dr["leaf"] = false;
                }
                dr["name"] = dr[genTable.GCATEGORY_NAME].ToString();
                dr["expanded"] = true;
            }
            var jarray = JsonHelper.DataTableSerializerJArray(dataTable);

            foreach (var item in jarray)
            {
                var thisUuid = item[genTable.GCATEGORY_UUID].ToString();
                var thisLeaf = item["leaf"].ToString();
                if (thisLeaf.ToLower() == "false")
                {
                    item["children"] = _loadGcategoryTree(thisUuid, ref drsGcagegory);
                }
            }
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

    [DirectMethod("_loadGcategoryTree", DirectAction.TreeStore)]
    public JArray _loadGcategoryTree(string parentUuid, ref IList<Gcategory_Record> drsGcategory)
    {
        #region Declare
        List<JObject> jobject = new List<JObject>();
        BasicModel model = new BasicModel();
        LwModel mod = new LwModel();
        #endregion
        try
        {
            /*取得資料*/

            var dataTable = new System.Data.DataTable();
            Gcategory tbl = new Gcategory();
            dataTable.Columns.Add(tbl.GCATEGORY_FULL_NAME);
            dataTable.Columns.Add(tbl.GCATEGORY_FULL_UUID);
            dataTable.Columns.Add(tbl.GCATEGORY_IS_ACTIVE);
            dataTable.Columns.Add(tbl.GCATEGORY_NAME);
            dataTable.Columns.Add(tbl.GCATEGORY_PARENT_UUID);
            dataTable.Columns.Add(tbl.GCATEGORY_UUID);           
            dataTable.Columns.Add("leaf", System.Type.GetType("System.Boolean"));
            dataTable.Columns.Add("name");
            dataTable.Columns.Add("expanded", System.Type.GetType("System.Boolean"));
            var _drsGcategory = drsGcategory.Where(c => c.GCATEGORY_PARENT_UUID.Equals(parentUuid));
            foreach (var item in _drsGcategory)
            {
                var dr = dataTable.NewRow();
                dr[tbl.GCATEGORY_FULL_NAME] = item.GCATEGORY_FULL_NAME;
                dr[tbl.GCATEGORY_FULL_UUID] = item.GCATEGORY_FULL_UUID;
                dr[tbl.GCATEGORY_IS_ACTIVE] = item.GCATEGORY_IS_ACTIVE;
                dr[tbl.GCATEGORY_NAME] = item.GCATEGORY_NAME;
                dr[tbl.GCATEGORY_PARENT_UUID] = item.GCATEGORY_PARENT_UUID;
                dr[tbl.GCATEGORY_UUID] = item.GCATEGORY_UUID;              
                dr["expanded"] = true;
                var childrenCount = drsGcategory.Where(c => c.GCATEGORY_UUID.Equals(dr[tbl.GCATEGORY_UUID].ToString())).Count();
                if (childrenCount == 0)
                {
                    dr["leaf"] = true;
                }
                else
                {
                    dr["leaf"] = false;
                }
                dr["name"] = dr[tbl.GCATEGORY_NAME].ToString();
                dataTable.Rows.Add(dr);
                dataTable.AcceptChanges();
            }
            var jarray = JsonHelper.DataTableSerializerJArray(dataTable);
            foreach (var item in jarray)
            {
                var thisUuid = item["GCATEGORY_UUID"].ToString();
                var thisLeaf = item["leaf"].ToString();
                if (thisLeaf.ToLower() == "false")
                {
                    item["children"] = _loadGcategoryTree(thisUuid, ref drsGcategory);
                }
            }
            return jarray;
        }
        catch (Exception ex)
        {
            log.Error(ex);
            LK.MyException.MyException.Error(this, ex);
            throw ex;
        }
    }

}

