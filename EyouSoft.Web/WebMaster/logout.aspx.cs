using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace EyouSoft.Web.WebMaster
{
    public partial class logout : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserInfo.LeiXing == EyouSoft.Model.Enum.WebmasterUserType.代理商用户 || UserInfo.LeiXing == EyouSoft.Model.Enum.WebmasterUserType.供应商用户)
            {
                EyouSoft.Security.Membership.WebmasterProvider.Logout();
                EyouSoft.Security.Membership.UserProvider.Logout();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                EyouSoft.Security.Membership.WebmasterProvider.Logout();
                Response.Redirect(LoginFilePath);
            }
            
        }
    }
}
