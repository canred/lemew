﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Limew.Model.Basic;
using Limew.Model.Basic.Table.Record;
namespace Limew
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string getCompany()
        {
            if (Limew.Parameter.Config.ParemterConfigs.GetConfig().IsProductionServer == false)
            {
                return Limew.Parameter.Config.ParemterConfigs.GetConfig().DEVUserCompany;
            }
            else if (Limew.Parameter.Config.ParemterConfigs.GetConfig().AuthenticationType.ToUpper().IndexOf("AD") >= 0)
            {
                return HttpContext.Current.User.Identity.Name.Split('\\')[0];
            }
            else
            {
                return "";
            }
        }

        public string getAccount()
        {
            if (Limew.Parameter.Config.ParemterConfigs.GetConfig().IsProductionServer == false)
            {
                return Limew.Parameter.Config.ParemterConfigs.GetConfig().DEVUserAccount;
            }
            else if (Limew.Parameter.Config.ParemterConfigs.GetConfig().AuthenticationType.ToUpper().IndexOf("AD") >= 0)
            {
                try
                {
                    return HttpContext.Current.User.Identity.Name.Split('\\')[1];
                }
                catch (Exception ex)
                {
                    LK.MyException.MyException.ErrorNoThrowException(this, ex);
                    Response.Redirect(Page.ResolveUrl(Limew.Parameter.Config.ParemterConfigs.GetConfig().NoPermissionPage));
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public string getPassword()
        {
            BasicModel modBasic = new BasicModel();
            if (
                Limew.Parameter.Config.ParemterConfigs.GetConfig().AuthenticationType.ToUpper().IndexOf("AD") >= 0
                )
            {
                var dtAttendantV = modBasic.getAttendantV_By_Company_Account_Password(getCompany(), getAccount());
                AttendantV_Record drAttendantV = null;
                if (dtAttendantV.Count == 1)
                {
                    drAttendantV = dtAttendantV.First();
                    return drAttendantV.PASSWORD;

                }
                else
                {
                    return "";
                }
            }
            else if (Limew.Parameter.Config.ParemterConfigs.GetConfig().IsProductionServer == false)
            {
                return Limew.Parameter.Config.ParemterConfigs.GetConfig().DEVUserPassword;
            }
            else
            {
                return "";
            }
        }

        public string getGraphicsCertification()
        {
            if (Limew.Parameter.Config.ParemterConfigs.GetConfig().GraphicsCertification)
            {
                return "false";
            }
            else
            {
                return "true";
            }
        }
    }
}
