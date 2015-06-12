using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web.UserControl
{
    public partial class UserLeft : System.Web.UI.UserControl
    {
        public int isfenxiao = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.SSOStructure.MUserInfo userInfo = null;
            if (Security.Membership.UserProvider.IsLogin(out userInfo))
            {
                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                {
                    isfenxiao = 1;
                }
            }
        }
    }
}