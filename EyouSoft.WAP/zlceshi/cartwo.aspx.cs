using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.WAP.zlceshi
{
    public partial class cartwo : System.Web.UI.Page
    {
        protected string longitude1 = "";
        protected string latitude1 = "";
        protected string longitude2 = "";
        protected string latitude2 = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            longitude1 = Utils.GetQueryStringValue("fir-lng");
            latitude1 = Utils.GetQueryStringValue("fir-lat");
            longitude2 = Utils.GetQueryStringValue("last-lng");
            latitude2 = Utils.GetQueryStringValue("last-lat");

        }
    }
}
