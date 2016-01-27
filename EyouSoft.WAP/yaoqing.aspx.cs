using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;

namespace EyouSoft.WAP
{
    public partial class yaoqing : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var uid = Utils.GetQueryStringValue("uid");
                if (!string.IsNullOrEmpty(uid))
                {
                    liteyqm.Value = uid;
                }
            }
        }
    }
}
