using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web.UserControl
{
    public partial class ZhuCe : System.Web.UI.UserControl
    {
        public int isfenxiao = 0;
        protected void Page_Load(object sender, EventArgs e)
        { }
        //{
        //    string website = HttpContext.Current.Request.Url.Host.ToLower();
        //    if (website.IndexOf("slej.cn") > -1 && website.IndexOf("www") < 0)
        //    {
        //        isfenxiao = 1;
        //    }
        //    EyouSoft.Model.SSOStructure.MUserInfo info;
        //    bool islogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out info);
        //    if (islogin)
        //    {
        //        if (info.UserType == EyouSoft.Model.Enum.MemberTypes.普通会员) plahuiyuan.Visible = false;
        //        if (info.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员) plahuiyuan.Visible = plaguibin.Visible = false;
        //    }
        //}
    }
}