using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.SSOStructure;
using Linq.Bussiness;
using Linq.Web;
using Common;
using EyouSoft.Model.Enum;
using EyouSoft.Model.ScenicStructure;
using EyouSoft.IDAL.AccountStructure;
using Linq.Web.ASPNET;

namespace EyouSoft.Common.Page
{
    public class HuiYuanPageBase : WebPageBase
    {
        /// <summary>
        /// 登录用户信息
        /// </summary>
        public MUserInfo HuiYuanInfo = null;

        public const string LoginFilePath = "/Default.aspx";
        public static string EmptyImage = "/Images/NoPic.jpg";
        protected string SupplierID = "";
        #region  获取域名信息
        /// <summary>
        /// 获取当前域名信息
        /// </summary>
        /// <returns></returns>
        public static EyouSoft.Model.OtherStructure.MYuMing GetYuMingInfo()
        {
            string s = System.Web.HttpContext.Current.Request.Url.Host.ToLower().Replace("m.", "").Replace("p.", "");
            EyouSoft.Model.OtherStructure.MYuMing info = null;
            info = new EyouSoft.BLL.OtherStructure.BYuMing().GetYuMingInfo(s);
            return info;
        }
        #endregion
        /// <summary>
        /// OnInit
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            MUserInfo m = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);
            string HostURL = Context.Request.Url.Host;
            var model = new EyouSoft.IDAL.AccountStructure.BSellers().GetMSellersByWebSite(HostURL);
            //if (!isLogin)
            //{
            //    Response.Redirect(LoginFilePath);
            //}
            if (!isLogin)
            {
                HuiYuanInfo = GuestUser;
            }
            else
            {
                HuiYuanInfo = m;
            }

            CheckLogin();
            SetExpire();
        }

        public static MUserInfo GuestUser = new MUserInfo
                  {
                      UserType = EyouSoft.Model.Enum.MemberTypes.未注册用户,
                      Username = "Guest",
                      OnlineStatus = UserOnlineStatus.Online,
                      MemberState = UserStatus.未启用,
                      OnlineSessionId = "__GuestOnlineSessionId__",
                      UserId = "Guest",
                  };

        protected MUserInfo CurrentUser
        {
            get
            {
                return HuiYuanInfo;
            }
        }

        public HuiYuanPageBase()
        {
            this.PageSize = 20;
        }

        protected virtual int PageSize { get; private set; }

        PageInfo pageInfo;
        public PageInfo PageInfo
        {
            get
            {
                if (pageInfo == null)
                {
                    pageInfo = new PageInfo();
                    pageInfo.PageSize = PageSize;
                    pageInfo.TotalCount = -1;
                }
                pageInfo.PageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
                return pageInfo;
            }
        }

        protected void SetExpire()
        {
            if (this.GetType().IsDefined(typeof(NoCacheAttribute), true))
            {
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                Response.Expires = 0;
                Response.ExpiresAbsolute = DateTime.Now;
            }
        }

        protected void CheckLogin()
        {
            if (this.GetType().IsDefined(typeof(IsLoginAttribute), true))
            {
                if (CurrentUser.UserType == MemberTypes.未注册用户)
                {
                    if (Request.IsAjaxRequest())
                    {
                        Response.Clear();
                        Response.Write(string.Format("<script type=\"text/javascript\">alert('该页需要登录才能进入，您未登录!');top.location.href='/default.aspx';</script>"));
                        Response.End();
                    }
                    else
                    {
                        Response.Redirect("/default.aspx");
                    }
                }
            }
        }

        protected void ReturnAjax(int resultCode, string msg)
        {
            ReturnAjax(resultCode, msg, null);
        }
        protected void ReturnAjax(int resultCode, string msg, object data)
        {
            RCWE(UtilsCommons.AjaxReturnJson(resultCode.ToString(), msg, data));
        }
        protected void Json(object data)
        {
            RCWE(UtilsCommons.AjaxReturnJson("", "", data));
        }

        /// <summary>
        /// 是否显示会员价
        /// </summary>
        protected bool IsShowHuiYuan()
        {
            return true;
        }
        /// <summary>
        /// 是否显示代销价
        /// </summary>
        protected bool IsShowErJiDaiLi()
        {
            return (CurrentUser.UserType == MemberTypes.免费代理 || CurrentUser.UserType == MemberTypes.代理 || CurrentUser.UserType == MemberTypes.贵宾会员 || CurrentUser.UserType == MemberTypes.员工);
        }
        /// <summary>
        /// 是否显示贵宾价
        /// </summary>
        protected bool IsShowGuiBin()
        {
            return CurrentUser.UserType == MemberTypes.贵宾会员
               || CurrentUser.UserType == MemberTypes.代理
               || CurrentUser.UserType == MemberTypes.员工;
        }
        /// <summary>
        /// 是否显示代理价
        /// </summary>
        protected bool IsShowDaiLi()
        {
            return (CurrentUser.UserType == MemberTypes.代理 || CurrentUser.UserType == MemberTypes.员工);
        }
        /// <summary>
        /// 是否显示员工价
        /// </summary>
        protected bool IsShowYuanGong()
        {
            return CurrentUser.UserType == MemberTypes.员工;
        }
        /// <summary>
        /// 是否显示 申请贵宾
        /// </summary>
        protected bool IsShowShengQingGuiBin()
        {
            return (CurrentUser.UserType == MemberTypes.未注册用户 || CurrentUser.UserType == MemberTypes.普通会员) && IsShowShenQing();
        }

        /// <summary>
        /// 是否显示 申请代理
        /// </summary>
        protected bool IsShowShengQingDaiLi()
        {
            return (CurrentUser.UserType == MemberTypes.未注册用户
               || CurrentUser.UserType == MemberTypes.普通会员
               || CurrentUser.UserType == MemberTypes.免费代理
               || CurrentUser.UserType == MemberTypes.贵宾会员) && IsShowShenQing();
        }

        bool? isShowShenQing;
        /// <summary>
        /// 是否显示申请
        /// </summary>
        /// <returns></returns>
        private bool IsShowShenQing()
        {
            if (!isShowShenQing.HasValue)
            {
                isShowShenQing = (new BSellers().WebSiteShowOrHidden(Request.Url.Host) == ShowHidden.显示);
            }
            return isShowShenQing.Value;
        }
    }
}
