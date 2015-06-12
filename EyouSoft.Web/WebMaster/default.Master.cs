using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    /// <summary>
    /// 管理后台webmaster-master-neiye
    /// </summary>
    public partial class _default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EyouSoft.Model.SSOStructure.MWebmasterInfo info = null;
            bool isLogin = EyouSoft.Security.Membership.WebmasterProvider.IsLogin(out info);

            if (!isLogin)
            {
                Utils.RCWE(string.Format("<script type=\"text/javascript\">top.location.href='{0}';</script>", EyouSoft.Common.Page.WebmasterPageBase.LoginFilePath));
            }
        }
    }
}
