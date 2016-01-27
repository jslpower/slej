using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model;
using EyouSoft.Model.AccountStructure;
using EyouSoft.Model.Enum;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.WAP
{
    public partial class Logindomain : System.Web.UI.Page
    {
        EyouSoft.IDAL.AccountStructure.BSellers bllSellers = new EyouSoft.IDAL.AccountStructure.BSellers();
        MSellers Seller = new MSellers();
        MMember2 model = new MMember2();
        private readonly Toolkit.DataProtection.HashCrypto hashcrypto = new Toolkit.DataProtection.HashCrypto();

        protected void Page_Load(object sender, EventArgs e)
        {
            string u = Utils.InputText(Request.QueryString["u"]);
            string p = Utils.InputText(Request.QueryString["p"]);
            string pmd = Utils.InputText(Request.QueryString["pmd"]);
            string vc = Utils.InputText(Request.QueryString["vc"]);
            string callback = Utils.InputText(Request.QueryString["callback"]);

            int isUserValid = 0;
            var ecdlmm = "";
            EyouSoft.Model.SSOStructure.MUserInfo userInfo = null;
            var pwdInfo = new EyouSoft.Model.CompanyStructure.PassWord();
            if (vc == "1")
            {
                pwdInfo.SetMD5Pwd(pmd);
                isUserValid = EyouSoft.Security.Membership.UserProvider.Login(u, pwdInfo, out userInfo);
                ecdlmm = pmd;
            }
            else
            {

                var yanZhengMaInfo = new EyouSoft.BLL.OtherStructure.BYanZhengMa().GetInfo(u, p, EyouSoft.Model.Enum.YanZhengMaLeiXing.用户登录);
                if (yanZhengMaInfo == null
                    || yanZhengMaInfo.YanZhengMa != p)
                   
                 REWC(Utils.AjaxReturnJson("0", "验证码错误，请输入正确的验证码！"));

                if (yanZhengMaInfo.Status1 == EyouSoft.Model.Enum.YanZhengMaStatus.已过期)
                {
                    
                     REWC(Utils.AjaxReturnJson("0", "验证码已过期，请重新获取验证码！"));
                }

                if (yanZhengMaInfo.Status1 == EyouSoft.Model.Enum.YanZhengMaStatus.已使用)
                {
                    
                     REWC(Utils.AjaxReturnJson("0", "验证码已使用，请重新获取验证码！"));
                }

                if (new EyouSoft.BLL.MemberStructure.BMember().IsExistsUsername(u) == 0)
                {
                   
                     REWC(Utils.AjaxReturnJson("0", "暂不存在该用户，请注册后登录！"));
                }
                var list = new EyouSoft.IDAL.MemberStructure.BMember2().GetByAccount(u);
                ecdlmm = hashcrypto.MD5Encrypt(list.PassWord);
                pwdInfo.SetMD5Pwd(hashcrypto.MD5Encrypt(list.PassWord));
                isUserValid = EyouSoft.Security.Membership.UserProvider.Login(u, pwdInfo, out userInfo);
            }
            

            //获取当前页面主机名
            string url = HttpContext.Current.Request.Url.Host.ToLower();
            if (isUserValid == 1)
            {
                string tzurl = "1";
                if ((userInfo.UserType==MemberTypes.普通会员)||(userInfo.UserType==MemberTypes.贵宾会员))
                {
                    tzurl="default.aspx";
                    REWC(Utils.AjaxReturnJson("1", tzurl));
                 
                }
                else
                {
                    BSellers bsells = new BSellers();
                    EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
                    mseller = bsells.Get(userInfo.UserId);
                    tzurl = "http://p." + mseller.Website + "/index.aspx?types=2&u=" + u + "&pmd=" + ecdlmm;
                    REWC(Utils.AjaxReturnJson("1", tzurl));
               
                }
                //登录成功后，判断员工或者代理商是否有权限访问页面
                /*
                 * 1.员工账号不能访问代理商和免费代理商网站。
                 * 2.代理商不能访问免费代理商网站
                 */
                //url = url.Replace("m.", "");
                //if (url.IndexOf("slej.cn") > -1 && url.IndexOf("www") < 0)
                //{                  
                //    //根据主机名获取当前网站账号信息
                //    Seller = bllSellers.GetMSellersByWebSite(url);
                //    if (Seller != null)
                //    {
                //        //根据网站账号信息获取会员实体
                //        model = new EyouSoft.IDAL.MemberStructure.BMember2().Get(Seller.MemberID);
                //    }
                //    //根据当前登录用户信息，获取当前用户类型和当前访问网站所属类型
                //    if (userInfo.UserType == MemberTypes.员工 && (model.UserType == MemberTypes.代理 || model.UserType == MemberTypes.免费代理))
                //    {

                //        EyouSoft.Security.Membership.UserProvider.Logout();

                //        REWC(";" + callback + "({m:'员工账号不能登录代理商和免费代理商网站！'});");

                //    }
                //    else if (userInfo.UserType == MemberTypes.代理 && model.UserType == MemberTypes.免费代理)
                //    {

                //        EyouSoft.Security.Membership.UserProvider.Logout();

                //        REWC(";" + callback + "({m:'代理商账号不能登录免费代理商网站！'});");

                //    }
                //    else if (userInfo.UserType == MemberTypes.贵宾会员 && model.UserType == MemberTypes.免费代理)
                //    {

                //        EyouSoft.Security.Membership.UserProvider.Logout();

                //        REWC(";" + callback + "({m:'贵宾账号不能登录免费代理商网站！'});");

                //    }
                //}

                //if (userInfo.UserType == MemberTypes.代理 || userInfo.UserType == MemberTypes.免费代理)
                //{
                //    #region  如果是代理商同时登录总后台                    
                //    string username = u;
                //    EyouSoft.Model.SSOStructure.MWebmasterInfo webmasterInfo = null;
                //    EyouSoft.Security.Membership.WebmasterProvider.Login(username, pwdInfo, out webmasterInfo);
                //    #endregion
                //}


            }
            else if (isUserValid == -4)
            {
                
                REWC(Utils.AjaxReturnJson("0", "用户名或密码不正确！"));
            }
            else if (isUserValid == -7)
            {
               
                REWC(Utils.AjaxReturnJson("0", "您的账户已停用或已过期，请联系管理员！"));
            }
            else if (isUserValid == -8)
            {
                
                REWC(Utils.AjaxReturnJson("0", "您的账户已登录，不能重复登录！"));
            }
            else
            {

                REWC(Utils.AjaxReturnJson("0", "登录错误，请联系管理员！"));
            }
        }

        private void REWC(string str)
        {
            Response.Clear();
            Response.Write(str);
            Response.End();
        }
    }
}
