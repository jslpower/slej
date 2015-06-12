using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web.UserControl
{
    public partial class DingDanNav : System.Web.UI.UserControl
    {
        public int isAgency = 0;//判断是否为分销商、免费分销商、员工，1为true
        BSellers bsells = new BSellers();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.SSOStructure.MUserInfo HuiYuanInfo = null;
            Security.Membership.UserProvider.IsLogin(out HuiYuanInfo);
            mseller = bsells.Get(HuiYuanInfo.UserId);
            if (mseller != null)
            {
                isAgency = 1;
            }
        }
    }
}