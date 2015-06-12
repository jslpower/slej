using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.IDAL.MemberStructure;
using Common.page;
using EyouSoft.Model.CompanyStructure;
using System.Text.RegularExpressions;

namespace EyouSoft.Web.UserControl
{
    public partial class UserLoginOrReg : System.Web.UI.UserControl
    {
        BMember2 bll = new BMember2();
        MMember2 Model = new MMember2();
        public int isfenxiao = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitPage();
            }
        }

        private void InitPage()
        {
            Model.SSOStructure.MUserInfo userInfo = null;
            if (Security.Membership.UserProvider.IsLogin(out userInfo))
            {
                if (userInfo != null)
                {
                    plnUserLog.Visible = false;
                    plnUserReg.Visible = false;
                    plnUserInfo.Visible = true;
                    ltrUserName.Text = string.IsNullOrEmpty(userInfo.NickName)
                                           ? (string.IsNullOrEmpty(userInfo.MemberName)
                                                  ? userInfo.Username
                                                  : userInfo.MemberName)
                                           : userInfo.NickName;
                    lblShenFen.Text = userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 ? "代理" : userInfo.UserType.ToString();
                    if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                    {
                        isfenxiao = 1;
                    }
                }
            }
        }

        /*protected void Button1_Click(object sender, EventArgs e)
        {
            if (membername.Value.Trim() != "" && mobile.Value.Trim() != "")
            {
                Model.MemberID = Guid.NewGuid().ToString();
                Model.RegisterTime = DateTime.Now;
                Model.Account = mobile.Value.Trim();
                Model.MemberName = membername.Value.Trim();
                Model.MemberState = (EyouSoft.Model.Enum.UserStatus)1;
                Model.Mobile = mobile.Value.Trim();
                Model.PassWord = GetPassWord();
                Model.ZhiFuPassword = Model.PassWord;
                Model.UserType = (EyouSoft.Model.Enum.MemberTypes)1;
                bool success = bll.Add(Model);
                if (success)
                {
                    EyouSoft.Model.SSOStructure.MUserInfo userInfo = null;

                    var pwdInfo = new EyouSoft.Model.CompanyStructure.PassWord();
                    Model.MD5Password = new PassWord(Model.PassWord).MD5Password;
                    pwdInfo.SetMD5Pwd(Model.MD5Password);
                    int isUserValid = EyouSoft.Security.Membership.UserProvider.Login(Model.Account, pwdInfo, out userInfo);
                    Response.Redirect("/RegistSuccess.aspx");
                }
            }
        }

        public string GetPassWord()
        {
            string pass = "";
            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                pass += rand.Next(1, 9);
            }
            return pass;
        }*/


    }
}