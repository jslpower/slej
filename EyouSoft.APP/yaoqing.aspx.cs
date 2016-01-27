using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;

namespace EyouSoft.WebApp
{
    public partial class yaoqing : System.Web.UI.Page
    {
        protected string uid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "APP分享";
            if (!IsPostBack)
            {
                uid = Utils.GetQueryStringValue("uid");
                if (!string.IsNullOrEmpty(uid))
                {
                    liteyqm.Text = uid;
                }
            }
        }
    }
}
