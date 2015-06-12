using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Model.MemberStructure.WebModel;
using EyouSoft.IDAL.MemberStructure;

namespace EyouSoft.Web
{
    public partial class RegistSuccess : ClientModelViewPageBase<MMember2SearchModel>
    {
        public string account = "";//登录帐号
        public string password = "";//密码
        BMember2 bll = new BMember2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HuiYuanInfo.UserId != null && HuiYuanInfo.UserId !="")
            {
               MMember2 model = bll.Get(HuiYuanInfo.UserId);
               if (model.LoginNum == 1)
               {
                   account = model.Account;
                   password = model.PassWord;
                   txtaccount.Value = account;
                   txtpassword.Value = password;
               }
               else
               {
                   Response.Redirect("/Default.aspx");
               }
            }
        }
    }
}
