using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class NavNum : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected int show = 0;//0-主站，1-代理商
        //EyouSoft.Model.SSOStructure.MUserInfo model = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //EyouSoft.Security.Membership.UserProvider.IsLogin(out model);
            string type = Utils.GetQueryStringValue("type").Trim();

            if (type == "update")
            {
                Response.Clear();
                Response.Write(UpdateUserInfo());
                Response.End();
            }
            
            if (UserInfo.LeiXing == EyouSoft.Model.Enum.WebmasterUserType.代理商用户)
            {
                EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(UserInfo.GysId);
                if (mseller.NavNum == EyouSoft.Model.Enum.NavNum.代理商导航)
                {
                    show = 1;
                }
            }
        }
        private string UpdateUserInfo()
        {
            string msg = "";
            EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(UserInfo.GysId);
            EyouSoft.BLL.MemberStructure.BMember membll = new EyouSoft.BLL.MemberStructure.BMember();
            int count = membll.UpdateShowOrHidden(mseller.ShowOrHidden, (EyouSoft.Model.Enum.NavNum)Utils.GetInt(Utils.GetFormValue("radio")), mseller.MemberID);
            if (count > 0)
            {
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "修改成功！");
            }
            else
            {
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "修改失败！");
            }
            return msg;
        }
    }
}
