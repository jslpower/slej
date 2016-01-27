using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web
{
    public partial class LogOut : Common.Page.HuiYuanPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string s = Newtonsoft.Json.JsonConvert.SerializeObject(new EyouSoft.BLL.JiPiaoStructure.BJiPiaoSanZiMa().GetSanZiMas());
            LoginOutWeb();

            Response.Clear();
            Response.Write(EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "退出成功！"));
            Response.End();
        }

        private void LoginOutWeb()
        {
            if (HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
            {
                EyouSoft.Security.Membership.UserProvider.Logout();
                EyouSoft.Security.Membership.WebmasterProvider.Logout();
            }
            else
            {
                EyouSoft.Security.Membership.UserProvider.Logout();
            }
        }
    }
}
