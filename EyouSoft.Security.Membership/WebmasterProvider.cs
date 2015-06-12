//2011-09-23 汪奇志
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EyouSoft.Model.SSOStructure;

namespace EyouSoft.Security.Membership
{
    /// <summary>
    /// webmaster登录处理类
    /// </summary>
    public sealed class WebmasterProvider
    {
        #region static constants
        //static constants
        /// <summary>
        /// webmaster login session name
        /// </summary>
        public const string LoginSessionName = "SYS_WEBMASTER";


        //static constants
        /// <summary>
        /// 登录Cookie，用户编号
        /// </summary>
        public const string LoginCookieUserId = "SYS_WEB_UID";
        /// <summary>
        /// 登录Cookie，用户账号
        /// </summary>
        public const string LoginCookieUsername = "SYS_WEB_UN";

        /// <summary>
        /// 登录Cookie
        /// 作为存储用户最后登录时间的KEY.
        /// 存储的时间格式为：year-month-day-hour-minutes-seconds.
        /// </summary>
        public const string LoginCookieLastLogTime = "lastlogintimeweb";

        #endregion

        #region private members
        /// <summary>
        /// set login session
        /// </summary>
        /// <param name="info">webmaster info</param>
        private static void SetSession(EyouSoft.Model.SSOStructure.MWebmasterInfo info)
        {
            HttpContext.Current.Session[LoginSessionName] = info;
        }

        ///// <summary>
        ///// get login session
        ///// </summary>
        ///// <returns></returns>
        //private static EyouSoft.Model.SSOStructure.MWebmasterInfo GetSession()
        //{
        //    return (EyouSoft.Model.SSOStructure.MWebmasterInfo)HttpContext.Current.Session[LoginSessionName];
        //}
        /// <summary>
        /// get login session
        /// </summary>
        /// <returns></returns>
        private static EyouSoft.Model.SSOStructure.MWebmasterInfo GetSession()
        {
            MWebmasterInfo info = null;
            string userId = GetCookie(LoginCookieUserId);
            string username = GetCookie(LoginCookieUsername);

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(username))
            {
                return null;
            }

            AutoLogin(userId, username, out info);

            return info;
        }
        /// <summary>
        /// remove login session
        /// </summary>
        private static void RemoveSession()
        {
            SetSession(null);
        }
        /// <summary>
        /// 设置登录Cookies
        /// </summary>
        /// <param name="info">登录用户信息</param>
        private static void SetCookies(MWebmasterInfo info)
        {
            //Cookies生存周期为浏览器进程
            HttpResponse response = HttpContext.Current.Response;

            RemoveCookies();

            var cookie = new HttpCookie(LoginCookieUserId);
            cookie.Value = info.UserId.ToString();
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddDays(1);
            response.AppendCookie(cookie);

            cookie = new HttpCookie(LoginCookieUsername);
            cookie.Value = HttpContext.Current.Server.UrlEncode(info.Username);
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddDays(1);
            response.AppendCookie(cookie);

            cookie = new HttpCookie(LoginCookieUsername);
            cookie.Value = HttpContext.Current.Server.UrlEncode(info.Username);
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddDays(1);
            response.AppendCookie(cookie);


            cookie = new HttpCookie(LoginCookieLastLogTime);
            cookie.Value = DateTime.Now.ToString("yyyy-M-d-H-m-s");
            //cookie.HttpOnly = true;
            response.AppendCookie(cookie);
        }
        /// <summary>
        /// 移除登录用户Cookie
        /// </summary>
        private static void RemoveCookies()
        {
            HttpResponse response = HttpContext.Current.Response;

            response.Cookies.Remove(LoginCookieUserId);
            response.Cookies.Remove(LoginCookieUsername);

            DateTime cookiesExpiresDateTime = DateTime.Now.AddDays(-1);

            response.Cookies[LoginCookieUserId].Expires = cookiesExpiresDateTime;
            response.Cookies[LoginCookieUsername].Expires = cookiesExpiresDateTime;
        }
        /// <summary>
        /// 获取登录用户Cookie信息
        /// </summary>
        /// <param name="name">登录Cookie名称</param>
        /// <returns></returns>
        private static string GetCookie(string name)
        {
            HttpRequest request = HttpContext.Current.Request;

            if (request.Cookies[name] == null)
            {
                return string.Empty;
            }

            return HttpContext.Current.Server.UrlDecode(request.Cookies[name].Value);
        }
        #endregion

        #region public members
        /// <summary>
        /// webmaster login
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="pwdInfo">pwd</param>
        /// <param name="uInfo">webmaster info</param>
        /// <returns></returns>
        public static int Login(string username, Model.CompanyStructure.PassWord pwdInfo, out Model.SSOStructure.MWebmasterInfo uInfo)
        {
            IWebmasterLogin dal = new DWebmasterLogin();
            uInfo = null;

            if (string.IsNullOrEmpty(username)) return 0;
            if (pwdInfo == null || string.IsNullOrEmpty(pwdInfo.MD5Password)) return -1;

            uInfo = dal.Login(username, pwdInfo);

            if (uInfo == null) return -3;

            //SetSession(uInfo);
            SetCookies(uInfo);

            return 1;
        }
        /// <summary>
        /// webmaster login
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="pwdInfo">pwd</param>
        /// <param name="uInfo">webmaster info</param>
        /// <returns></returns>
        public static void AutoLogin(string userId, string username, out Model.SSOStructure.MWebmasterInfo uInfo)
        {

            uInfo = null;
            IWebmasterLogin dal = new DWebmasterLogin();
            uInfo = dal.LoginById(userId);

            if (uInfo == null) return;
            if (uInfo.Username != username) { uInfo = null; return; }

            if (uInfo.IsEnable != EyouSoft.Model.Enum.Is.是) { uInfo = null; return; }
        }

        /// <summary>
        /// get logion webmaster info
        /// </summary>
        /// <returns></returns>
        public static EyouSoft.Model.SSOStructure.MWebmasterInfo GetWebmasterInfo()
        {
            return GetSession();
        }

        /// <summary>
        /// webmaster is login
        /// </summary>
        /// <param name="info">out webmaster info</param>
        /// <returns></returns>
        public static bool IsLogin(out EyouSoft.Model.SSOStructure.MWebmasterInfo info)
        {
            info = GetWebmasterInfo();

            if (info == null) return false;

            return true;
        }

        /// <summary>
        /// webmaster is login
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            EyouSoft.Model.SSOStructure.MWebmasterInfo info = null;

            return IsLogin(out info);
        }

        /// <summary>
        /// webmaster logout
        /// </summary>
        public static void Logout()
        {
            //RemoveSession();
            RemoveCookies();
        }
        #endregion
    }
}
