//2011-09-23 汪奇志
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EyouSoft.Model.CompanyStructure;
using EyouSoft.Model.SSOStructure;
using EyouSoft.IDAL.MemberStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.Security.Membership
{
    /// <summary>
    /// 系统用户登录处理类
    /// </summary>
    public sealed class UserProvider
    {
        #region static constants
        //static constants
        /// <summary>
        /// 登录Cookie，用户编号
        /// </summary>
        public const string LoginCookieUserId = "SYS_TieLv_UID";
        /// <summary>
        /// 登录Cookie，用户账号
        /// </summary>
        public const string LoginCookieUsername = "SYS_TieLv_UN";

        /// <summary>
        /// 登录Cookie，客服登录
        /// </summary>
        public const string LoginCookieKeFu = "SYS_TieLv_KF";

        /// <summary>
        /// 登录Cookie，会话标识
        /// </summary>
        public const string LoginCookieSessionId = "SYS_TieLv_SESSIONID";

        /// <summary>
        /// 登录Cookie
        /// 作为存储用户最后登录时间的KEY.
        /// 存储的时间格式为：year-month-day-hour-minutes-seconds.
        /// </summary>
        public const string LoginCookieLastLogTime = "lastlogintime";
        /// <summary>
        /// 城市编号Cookie，默认城市ID
        /// </summary>
        public const string MoRenCityId = "SYS_CityId";
        /// <summary>
        /// 城市编号Cookie，默认城市名称
        /// </summary>
        public const string MoRenCityName = "SYS_CityName";
        /// <summary>
        /// 返联盟推广推广编号cookie
        /// </summary>
        public const string FanLianMengTuiGuangCookieTuiGuangId = "FLMTG";
        /// <summary>
        /// 返联盟推广推广编号查询key
        /// </summary>
        public const string FanLianMengTuiGuangTuiGuangIdChaXunKey = "flmtg";
        #endregion

        #region private members

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

        /// <summary>
        /// 移除登录用户Cookie
        /// </summary>
        private static void RemoveCookies()
        {
            EyouSoft.Model.SSOStructure.MUserInfo info = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out info);
            if (isLogin)
            {
                HttpResponse response = HttpContext.Current.Response;

                var cookie = new HttpCookie(LoginCookieUserId);
                cookie.Value = info.UserId.ToString();
                cookie.HttpOnly = true;
                cookie.Expires = DateTime.Now.AddYears(-1);
                response.AppendCookie(cookie);

                cookie = new HttpCookie(LoginCookieUsername);
                cookie.Value = HttpContext.Current.Server.UrlEncode(info.Username);
                cookie.HttpOnly = true;
                cookie.Expires = DateTime.Now.AddYears(-1);
                response.AppendCookie(cookie);

                cookie = new HttpCookie(LoginCookieSessionId);
                cookie.Value = info.OnlineSessionId;
                cookie.HttpOnly = true;
                cookie.Expires = DateTime.Now.AddYears(-1);
                response.AppendCookie(cookie);

                cookie = new HttpCookie(LoginCookieLastLogTime);
                cookie.Value = DateTime.Now.ToString("yyyy-M-d-H-m-s");
                //cookie.HttpOnly = true;
                cookie.Expires = DateTime.Now.AddYears(-1);
                response.AppendCookie(cookie);  
            }
           
        }
        /// <summary>
        /// 移除登录用户Cookie
        /// </summary>
        private static void RemoveCityCookies(int CityId, string CityName)
        {
           
                HttpResponse response = HttpContext.Current.Response;

                var cookie = new HttpCookie(MoRenCityId);
                cookie.Value = CityId.ToString();
                cookie.HttpOnly = true;
                cookie.Expires = DateTime.Now.AddYears(-1);
                response.AppendCookie(cookie);

                cookie = new HttpCookie(MoRenCityName);
                cookie.Value = CityName;
                cookie.HttpOnly = true;
                cookie.Expires = DateTime.Now.AddYears(-1);
                response.AppendCookie(cookie);


          

        }
        /// <summary>
        /// 设置默认城市Cookies
        /// </summary>
        /// <param name="CityId">城市编号</param>
        /// <param name="CityName">城市名称</param>
        public static void SetCityCookies(int CityId,string CityName)
        {
            //Cookies生存周期为浏览器进程
            HttpResponse response = HttpContext.Current.Response;

            RemoveCityCookies(CityId, CityName);

            var cookie = new HttpCookie(MoRenCityId);
            cookie.Value = CityId.ToString();
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddYears(1);
            response.AppendCookie(cookie);

            cookie = new HttpCookie(MoRenCityName);
            cookie.Value = CityName;
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddYears(1);
            response.AppendCookie(cookie);
        }
        /// <summary>
        /// 获取城市信息
        /// </summary>
        /// <returns></returns>
        public static EyouSoft.Model.MSysCity GetCityInfo()
        {
            EyouSoft.Model.MSysCity info = null;
            string getcityId = GetCookie(MoRenCityId);
            string getcityName = GetCookie(MoRenCityName);

            if (string.IsNullOrEmpty(getcityId) || string.IsNullOrEmpty(getcityName))
            {
                return null;
            }
            int result = 0;
            bool b = Int32.TryParse(getcityId, out result);
            if (b)
            {
                info = new EyouSoft.Model.MSysCity();
                info.Id = result;
                info.Name = getcityName;
            }

            return info;
        }
        /// <summary>
        /// 设置登录Cookies
        /// </summary>
        /// <param name="info">登录用户信息</param>
        private static void SetCookies(MUserInfo info)
        {
            //Cookies生存周期为浏览器进程
            HttpResponse response = HttpContext.Current.Response;

            RemoveCookies();

            var cookie = new HttpCookie(LoginCookieUserId);
            cookie.Value = info.UserId.ToString();
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddYears(1);
            response.AppendCookie(cookie);

            cookie = new HttpCookie(LoginCookieUsername);
            cookie.Value = HttpContext.Current.Server.UrlEncode(info.Username);
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddYears(1);
            response.AppendCookie(cookie);

            cookie = new HttpCookie(LoginCookieSessionId);
            cookie.Value = info.OnlineSessionId;
            cookie.HttpOnly = true;
            response.AppendCookie(cookie);

            cookie = new HttpCookie(LoginCookieLastLogTime);
            cookie.Value = DateTime.Now.ToString("yyyy-M-d-H-m-s");
            //cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddYears(1);
            response.AppendCookie(cookie);
        }

        /// <summary>
        /// 设置客服登录Cookies
        /// </summary>
        private static void SetKeFuLoginCookies()
        {
            HttpResponse response = HttpContext.Current.Response;

            var cookie = new HttpCookie(LoginCookieKeFu);
            cookie.Value = "Y";
            cookie.HttpOnly = true;
            response.AppendCookie(cookie);

        }

        /// <summary>
        /// 自动登录处理
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="username">用户账号</param>  
        /// <param name="uInfo">登录用户信息</param>
        private static void AutoLogin(string userId, string username, out MUserInfo uInfo)
        {
            uInfo = null;
            IUserLogin dal = new DUserLogin();
            uInfo = dal.LoginById(userId);
            //uInfo = dal.LoginByName(username);

            if (uInfo == null) return;
            if (uInfo.Username != username) { uInfo = null; return; }

            if (uInfo.MemberState != Model.Enum.UserStatus.正常) { uInfo = null; return; }

            //if (uInfo.OnlineStatus != Model.Enum.UserOnlineStatus.Online) { uInfo = null; return; }

            uInfo.LoginTime = uInfo.LoginTime.HasValue ? uInfo.LoginTime.Value : DateTime.Now;

            //dal.LoginLogwr(uInfo, Model.Enum.UserLoginType.自动登录);
        }

        /// <summary>
        /// 是否客服登录
        /// </summary>
        /// <returns></returns>
        private static bool IsKeFuLogin()
        {
            return GetCookie(LoginCookieKeFu) == "Y";
        }

        #endregion

        #region public members

        /// <summary>
        /// 用户登录，返回1登录成功
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pwdInfo">登录密码</param>
        /// <param name="uInfo">登录用户信息</param>
        /// <returns></returns>
        public static int Login(string username, PassWord pwdInfo, out MUserInfo uInfo)
        {
            IUserLogin dal = new DUserLogin();
            uInfo = null;

            if (string.IsNullOrEmpty(username)) return -1;
            if (pwdInfo == null || string.IsNullOrEmpty(pwdInfo.MD5Password)) return -2;

            BMember2 memberBll = new BMember2();
            MMember2 memberInfo = memberBll.Get(username, pwdInfo);
            if (memberInfo == null) return -4;
            uInfo = new MUserInfo
            {
                Address = memberInfo.Address,
                BirthDate = memberInfo.BirthDate,
                CardNo = memberInfo.CardNo,
                CardType = (CardType)(memberInfo.CardType.HasValue ? memberInfo.CardType.Value : 0),
                Contact = memberInfo.Contact,
                Email = memberInfo.Email,
                Fax = memberInfo.Fax,
                Gender = (Gender)(memberInfo.Gender.HasValue ? memberInfo.Gender.Value : 0),
                LoginIP = memberInfo.LoginIP,
                LoginNum = memberInfo.LoginNum.HasValue ? memberInfo.LoginNum.Value : 0,
                LoginTime = memberInfo.LoginTime,
                MemberName = memberInfo.MemberName,
                MemberState = (UserStatus)memberInfo.MemberState,
                Mobile = memberInfo.Mobile,
                NickName = memberInfo.NickName,
                OnlineSessionId = memberInfo.OnlineSessionId,
                OnlineStatus = (UserOnlineStatus)(memberInfo.OnlineStatus.HasValue ? memberInfo.OnlineStatus.Value : 0),
                Photo = memberInfo.Photo,
                qq = memberInfo.qq,
                RegisterTime = memberInfo.RegisterTime,
                TotalMoney = memberInfo.TotalMoney.HasValue ? memberInfo.TotalMoney.Value : 0,
                UserId = memberInfo.MemberID,
                Username = memberInfo.Account,
                UserType = memberInfo.UserType,
                ZhiFuPassword = memberInfo.ZhiFuPassword,
            };
            //uInfo = dal.Login(username, pwdInfo);

            //通过用户名及密码验证失败，判断登录密码是否为客服服务密码，如果是将绕过密码验证
            //使用客服密码登录时登录日志做客服登录标识
            Model.Enum.UserLoginType loginType = Model.Enum.UserLoginType.用户登录;
            if (uInfo == null)
            {
                if (System.Configuration.ConfigurationManager.AppSettings["KeFuPwd"] == pwdInfo.MD5Password)
                {
                    uInfo = dal.LoginByName(username);
                    loginType = Model.Enum.UserLoginType.客服登录;
                }

                if (uInfo == null) return -4;
            }

            if (uInfo.MemberState != Model.Enum.UserStatus.正常)
            {
                uInfo = null;
                return -7;
            }

            uInfo.LoginTime = DateTime.Now;

            if (loginType == Model.Enum.UserLoginType.用户登录)
            {
                uInfo.OnlineStatus = Model.Enum.UserOnlineStatus.Online;
                uInfo.OnlineSessionId = Guid.NewGuid().ToString();
            }

            dal.LoginLogwr(uInfo, loginType);

            SetCookies(uInfo);

            if (loginType == Model.Enum.UserLoginType.客服登录)
            {
                SetKeFuLoginCookies();
            }

            return 1;
        }

        /// <summary>
        /// 用户退出
        /// </summary>
        public static void Logout()
        {
            string userId = GetCookie(LoginCookieUserId);

            RemoveCookies();

            if (!IsKeFuLogin())
            {
                IUserLogin dal = new DUserLogin();
                dal.SetOnlineStatus(userId, Model.Enum.UserOnlineStatus.Offline, "00000000-0000-0000-0000-000000000000");
            }
        }

        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <returns></returns>
        public static MUserInfo GetUserInfo()
        {
            MUserInfo info = null;
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
        /// 用户是否登录
        /// </summary>
        /// <param name="info">登录用户信息</param>
        /// <returns></returns>
        public static bool IsLogin(out MUserInfo info)
        {
            info = GetUserInfo();

            if (info == null) return false;

            return true;
        }

        /// <summary>
        /// 用户是否登录
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            MUserInfo info;

            return IsLogin(out info);
        }

        /// <summary>
        /// 用户退出
        /// </summary>
        public static void Logout(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                RemoveCookies();

                IUserLogin dal = new DUserLogin();
                dal.SetOnlineStatus(userId, Model.Enum.UserOnlineStatus.Offline, "00000000-0000-0000-0000-000000000000");
            }
        }

        /// <summary>
        /// 设置返联盟推广cookie
        /// </summary>
        public static void SheZhiFanLianMengTuiGuangCookie()
        {
            string s = HttpContext.Current.Request.QueryString[FanLianMengTuiGuangTuiGuangIdChaXunKey];
            if (string.IsNullOrEmpty(s)) return;

            HttpResponse response = HttpContext.Current.Response;

            DateTime cookiesExpiresDateTime = DateTime.Now.AddDays(-1);
            response.Cookies[FanLianMengTuiGuangCookieTuiGuangId].Expires = cookiesExpiresDateTime;

            var cookie = new HttpCookie(FanLianMengTuiGuangCookieTuiGuangId);
            cookie.Value = s;
            cookie.HttpOnly = true;
            response.AppendCookie(cookie);
        }

        /// <summary>
        /// 获取返联盟推广编号
        /// </summary>
        /// <returns></returns>
        public static string GetFanLianMengTuiGuangId()
        {
            string s = string.Empty;

            s = HttpContext.Current.Request.QueryString[FanLianMengTuiGuangTuiGuangIdChaXunKey];

            if (!string.IsNullOrEmpty(s)) return s;

            s = GetCookie(FanLianMengTuiGuangCookieTuiGuangId);

            return s;
        }
        #endregion

    }
}
