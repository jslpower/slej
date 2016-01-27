using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.WAP
{
    public partial class BaiDuMap : System.Web.UI.Page
    {
        public string jingdu = "120.091887";
        public string weidu = "30.286442";
        public string title = "杭州金奥";
        public string content = "12344566";

        protected void Page_Load(object sender, EventArgs e)
        {
            jingdu = Utils.GetQueryStringValue("jingdu");
            weidu = Utils.GetQueryStringValue("weidu");
            title = Server.UrlDecode(Utils.GetQueryStringValue("title"));
            content = "联系电话：" + Server.UrlDecode(Utils.GetQueryStringValue("Mobile")) + "<br />地址：" + Server.UrlDecode(Utils.GetQueryStringValue("Address"));
        }
    }
}
