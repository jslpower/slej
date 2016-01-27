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
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Common;

namespace EyouSoft.WebApp
{
    public partial class index : System.Web.UI.Page
    {
        BSellers bsells = new BSellers();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        private readonly Toolkit.DataProtection.HashCrypto hashcrypto = new Toolkit.DataProtection.HashCrypto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var r = Utils.GetQueryStringValue("r");
                if (!string.IsNullOrEmpty(r) && r == "2")
                {
                    OutLog();
                 
                    Response.Redirect("/start.aspx");
                }
                var types = Utils.GetQueryStringValue("types");
                if (!string.IsNullOrEmpty(types) && types=="2")
                {
                    UserDl();
                }
                else
                {
                    Getusdl();
                }
                
            }
        }
        protected void OutLog()
        {
            EyouSoft.Security.Membership.UserProvider.Logout();
        }
        /// <summary>
        /// 二次登录
        /// </summary>
        protected void UserDl()
        {
            string u = Utils.InputText(Request.QueryString["u"]);
            string pmd = Utils.InputText(Request.QueryString["pmd"]);
            int isUserValid = 0;
            EyouSoft.Model.SSOStructure.MUserInfo userInfo = null;
            var pwdInfo = new EyouSoft.Model.CompanyStructure.PassWord();
            pwdInfo.SetMD5Pwd(pmd);
            isUserValid = EyouSoft.Security.Membership.UserProvider.Login(u, pwdInfo, out userInfo);
            if (isUserValid!=1)
            {
                Response.Redirect("/start.aspx");
            }
            Getusdl();
        }
        /// <summary>
        /// 是否登录
        /// </summary>
        protected void Getusdl()
        {
            EyouSoft.Model.SSOStructure.MUserInfo m = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);
            //if (!isLogin) Response.Redirect("/default.aspx");

            if (!isLogin) return;

            if ((m.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员) || (m.UserType == EyouSoft.Model.Enum.MemberTypes.普通会员))
            {
                //Response.Redirect("default.aspx");
                return;
            }
            else
            {
                mseller = bsells.Get(m.UserId);

                Response.Redirect("http://p." + mseller.Website + "/default.aspx");
            }
        }
    }
}
