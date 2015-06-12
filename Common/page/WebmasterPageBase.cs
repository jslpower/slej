using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.page;
using EyouSoft.Model.Enum.Privs;
using Linq.Web;
using EyouSoft.Model.Enum;
using Linq.Bussiness;

namespace EyouSoft.Common.Page
{
   #region webmaster page base

   public class WebmasterPageBase : System.Web.UI.Page, IValidator
   {
      #region attibutes
      /// <summary>
      /// login page file path
      /// </summary>
      public const string LoginFilePath = "/webmaster/login.aspx";


      private EyouSoft.Model.SSOStructure.MWebmasterInfo _userInfo;

      /// <summary>
      /// 管理后台用户信息
      /// </summary>
      public EyouSoft.Model.SSOStructure.MWebmasterInfo UserInfo
      {
         get
         {
            return _userInfo;
         }
      }


      PageInfo pageInfo;
      public PageInfo PageInfo
      {
         get
         {
            if (pageInfo == null)
            {
               pageInfo = new PageInfo();
               pageInfo.PageSize = 20;
               pageInfo.TotalCount = -1;
            }
            pageInfo.PageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
            return pageInfo;
         }
      }

      #endregion

      protected override void OnInit(EventArgs e)
      {
         base.OnInit(e);

         bool isLogin = EyouSoft.Security.Membership.WebmasterProvider.IsLogin(out _userInfo);

         if (!isLogin)
         {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(
                string.Format("<script type=\"text/javascript\">top.location.href='{0}';</script>", LoginFilePath));
            HttpContext.Current.Response.End();
         }
         ValidatePower();
         SetExpire();
      }

      #region protected members

      protected void RegisterAlertScript(string s)
      {
         this.RegisterScript(string.Format("alert('{0}');", s));
      }

      protected void RegisterAlertAndRedirectScript(string s, string url)
      {
         if (!string.IsNullOrEmpty(url))
         {
            this.RegisterScript(string.Format("alert('{0}');window.location.href='{1}';", s, url));
         }
         else
         {
            this.RegisterScript(string.Format("alert('{0}');window.location.href=window.location.href;", s));
         }
      }


      protected void RegisterAlertAndReloadScript(string s)
      {
         RegisterAlertAndRedirectScript(s, null);
      }

      protected void RegisterScript(string script)
      {
         this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
      }

      protected string ToMoneyString(object obj)
      {
         return UtilsCommons.GetMoneyString(obj, "zh-cn");
      }

      protected string ToDateTimeString(object obj)
      {
         return UtilsCommons.GetDateString(obj, "yyyy-MM-dd");
      }



      protected override void OnPreInit(EventArgs e)
      {
         base.OnPreInit(e);
      }


      protected void ReturnAjax(int resultCode, string msg)
      {
         RCWE(UtilsCommons.AjaxReturnJson(resultCode.ToString(), msg));
      }

      /// <summary>
      /// 判断当前用户是否有权限
      /// </summary>
      /// <param name="permissionId">权限ID</param>
      /// <returns></returns>
      public bool CheckGrantMenu1(EyouSoft.Model.Enum.Privs.Menu1 menu)
      {
         if (_userInfo == null) return false;
         return _userInfo.Permissions.Contains(((int)menu).ToString());
      }

      /// <summary>
      /// 判断当前用户是否有权限
      /// </summary>
      /// <param name="permissionId">权限ID</param>
      /// <returns></returns>
      public bool CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2 menu)
      {
         if (_userInfo == null) return false;
         return _userInfo.Permissions.Contains(((int)menu).ToString());
      }

      /// <summary>
      /// 判断当前用户是否有权限
      /// </summary>
      /// <param name="permissionId">权限ID</param>
      /// <returns></returns>
      public bool CheckGrantPrivs(EyouSoft.Model.Enum.Privs.Privs privs)
      {
         if (_userInfo == null) return false;
         return _userInfo.Permissions.Contains(((int)privs).ToString());
      }

      /// <summary>
      /// 页面跳转
      /// </summary>
      /// <returns></returns>
      public void ToUrl(string url)
      {
         HttpContext.Current.Response.Clear();
         HttpContext.Current.Response.Write(
             string.Format("<script type=\"text/javascript\">top.location.href='{0}';</script>", url));
         HttpContext.Current.Response.End();
      }

      protected void RCWE(string s)
      {
         Response.Clear();
         Response.Write(s);
         Response.End();
      }

      #endregion

      private object[] GetCustomAttribute()
      {
         return this.GetType().GetCustomAttributes(true);
      }

      #region IValidatetor 成员

      public virtual bool IsValidatePower
      {
         get { return false; }
      }

      public virtual bool ValidatePower()
      {
         if (this.IsValidatePower)
         {
            bool flag1 = false;

            foreach (PowerAttribute power in GetCustomAttribute().OfType<PowerAttribute>())
            {
               if (UserInfo.LeiXing ==  WebmasterUserType.后台用户)
               {
                  if ((power.ParentMenu != Menu1.None && !CheckGrantMenu1(power.ParentMenu)) || (power.CurrentMenu != Menu2.None && !CheckGrantMenu2(power.CurrentMenu)))
                  {
                     flag1 = true;
                     break;
                  }
               }
            }
            if (flag1)
            {
               ToUrl("/webmaster/default.aspx");
            }
         }
         return true;
      }

      #endregion


      protected void SetExpire()
      {
         if (GetCustomAttribute().OfType<NoCacheAttribute>().Any())
         {
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
         }
      }

      protected void Json(object data)
      {
         RCWE(UtilsCommons.AjaxReturnJson("", "", data));
      }

   }
   #endregion
}
