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

    
}

