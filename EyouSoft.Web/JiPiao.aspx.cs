using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web
{
    public partial class JiPiao : System.Web.UI.Page
    {
        public int ShowOrHidden = 0;//0-显示，1-隐藏
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 5;
            }
            string url = HttpContext.Current.Request.Url.Host.ToLower();

            ShowOrHidden = (int)new EyouSoft.IDAL.AccountStructure.BSellers().WebSiteShowOrHidden(url);
        }
    }
}
