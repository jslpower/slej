using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web.UserControl
{
    public partial class TopBar : System.Web.UI.UserControl
    {
        public string erweimapic = @"/Images/slej.png";
        public int uislogin = 0;//0-未登录，1-已登录
        protected void Page_Load(object sender, EventArgs e)
        {

            InitPage();
            string website = HttpContext.Current.Request.Url.Host.ToLower();
            if (website.IndexOf("slej.cn") > -1 && website.IndexOf("www") < 0)
            {
                website = website.Replace(".slej.cn", "").Replace("http://", "");
                erweimapic = @"/Images/ErWeiMa/" + website + ".png";
            }
        }


        protected void InitPage()
        {
            Model.SSOStructure.MUserInfo userInfo = null;
            bool islogin = Security.Membership.UserProvider.IsLogin(out userInfo);
            if (islogin)
            {
                lithuiyuan.Text = string.Format("<li><span><a href=\"/Member/UpdateMember.aspx\">会员管理 </a></span></li>");
            }
            else
            {
                lithuiyuan.Text = string.Format("<li><span><a id=\"alogin\" href=\"/UserCentent.aspx\">会员管理 </a></span></li>");
            }
            if (userInfo != null)
            {
                uislogin = 1;
                ltrUserName.Text = string.Format("<a href=\"/Member/UpdateMember.aspx\"> {0}</a>", string.IsNullOrEmpty(userInfo.NickName)
                                       ? (string.IsNullOrEmpty(userInfo.MemberName)
                                              ? userInfo.Username
                      : userInfo.MemberName)
                                       : userInfo.NickName);
                lblShenFen.Text = userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 ? "代理" : userInfo.UserType.ToString();
                lblShenFen.Text = lblShenFen.Text + " ";
                ltrUserName.Text = ltrUserName.Text + ",";
            }

        }
    }
}