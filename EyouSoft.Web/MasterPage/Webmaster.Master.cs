using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web.MasterPage
{
    public partial class Webmaster : System.Web.UI.MasterPage
    {
        /// <summary>
        /// page title
        /// </summary>
        protected string ITitle = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            ITitle = Page.Title;
            var setting = new BLL.OtherStructure.BKV().GetCompanySetting();
            if (setting != null) ITitle = ITitle + "- webmaster -" + setting.Title;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            EyouSoft.Model.SSOStructure.MWebmasterInfo userinfo;
            bool isLogin = EyouSoft.Security.Membership.WebmasterProvider.IsLogin(out userinfo);

            if (!isLogin)
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Write(
                    string.Format("<script type=\"text/javascript\">top.location.href='{0}';</script>", EyouSoft.Common.Page.WebmasterPageBase.LoginFilePath));
                HttpContext.Current.Response.End();
            }
        }
    }
}
