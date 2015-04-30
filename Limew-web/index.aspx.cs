using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Limew
{
    public partial class index : BasePage
    {

        protected void Page_PreRender(object sender, EventArgs e) {
        
        }

        public string getDrsAuthortyMenuV() {
            var drsAuthortyMenuV = getUserMenu();
            var ret = "";
            if (drsAuthortyMenuV != null)
            {
                foreach (var item in drsAuthortyMenuV)
                {
                    ret += item.NAME_ZH_CN + ",";                    
                }
                return ret;
            }
            else {
                return "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }
}