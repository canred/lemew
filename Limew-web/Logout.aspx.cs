using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Limew
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Limew.Util.Session.Store ss = new Limew.Util.Session.Store();
            ss.ClearCookieInSession();
        }
    }
}
