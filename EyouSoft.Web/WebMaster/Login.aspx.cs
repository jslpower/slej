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
using EyouSoft.Common;
using System.Collections.Generic;

namespace EyouSoft.Web.WebMaster
{
    /// <summary>
    /// 运营后台登录页面
    /// </summary>
    public partial class Login:System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("type") != "")
            {
                EyouSoft.Model.SSOStructure.MUserInfo m = null;
                bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);

                if (isLogin)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["url"]))

                        Response.Redirect(Request.QueryString["url"]);
                    else
                        Response.Redirect("default.aspx");
                }
                else
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["url"]))

                        Response.Redirect(Request.QueryString["url"]);
                    else
                        Response.Redirect("default.aspx");
                }
            }
            
        }

        /*void JiPiaoCeShi()
        {
            string depAirportCode = "PEK";
            string arrAirportCode = "SHA";
            DateTime depRiQi = DateTime.Today.AddDays(1);

            var items = new EyouSoft.BLL.JiPiaoStructure.BJiPiao().GetHangBans(depAirportCode, arrAirportCode, depRiQi);
        }*/

        /// <summary>
        /// btnLogin click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            EyouSoft.Model.CompanyStructure.PassWord pwd = new EyouSoft.Model.CompanyStructure.PassWord();
            string username = EyouSoft.Common.Utils.GetFormValue("t_u");
            pwd.NoEncryptPassword = EyouSoft.Common.Utils.GetFormValue("t_p");

            if (string.IsNullOrEmpty(username))
            {
                this.RegisterAlertScript("用户名不可为空！");
            }

            if (string.IsNullOrEmpty(pwd.NoEncryptPassword))
            {
                this.RegisterAlertScript("密码不可为空！");
            }

            EyouSoft.Model.SSOStructure.MWebmasterInfo webmasterInfo = null;
            EyouSoft.Security.Membership.WebmasterProvider.Login(username, pwd, out webmasterInfo);

            if (webmasterInfo != null)
            {
                Response.Redirect("default.aspx");
            }

            this.RegisterAlertScript("账号或密码错误！");
        }

        #region private members
        /// <summary>
        /// register alert script
        /// </summary>
        /// <param name="s">msg</param>
        private void RegisterAlertScript(string s)
        {
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), string.Format("alert('{0}');", s), true);
        }
        #endregion
    }
}
