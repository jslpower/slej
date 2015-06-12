using EyouSoft.Model.AccountStructure;
using EyouSoft.DAL;
using EyouSoft.IDAL.AccountStructure;
using Linq.DAL;
using System.Text.RegularExpressions;
using System;
using Common.Function;
using System.Net;
using System.Configuration;
using System.Web;

namespace EyouSoft.DAL.AccountStructure
{
   public class DSellers : DALBase<MSellers>, ISellers
   {
      #region ISellers 成员

      bool Validate(string website)
      {
         if (!Regex.IsMatch(website, "^[a-zA-Z0-9]+\\.slej\\.cn$", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
         {
            throw new InvalidOperationException(website + " 格式错误");
         }
         return true;
      }

      bool isLocal()
      {
         string host = HttpContext.Current.Request.Url.Host;
         return (string.Equals(host, "localhost", StringComparison.InvariantCultureIgnoreCase)
            || host == "127.0.0.1"
            || host == Dns.GetHostName());
      }

      public void AddWebDomain(string website, int siteId)
      {
         try
         {
             if (string.IsNullOrEmpty(website) || string.IsNullOrEmpty(website.Trim()) || isLocal())
            {
               return;
            }
            //Validate(website);
            IISHelper.AddHostHeader("localhost", siteId, "", 80, website);
         }
         catch (Exception ex)
         {
#if DEBUG
            throw ex;
#endif
         }
      }

      public void RemoveWebDomain(string website, int siteId)
      {
         try
         {
             if (string.IsNullOrEmpty(website) || string.IsNullOrEmpty(website.Trim()) || isLocal())
            {
               return;
            }
            //Validate(website);
            
            IISHelper.DeleteHostHeader("localhost", siteId, "", 80, website);
         }
         catch (Exception ex)
         {
#if DEBUG
            throw ex;
#endif
         }
      }

      public void UpdateWebDomain(string oldsite, string newsite)
      {
         if (!string.IsNullOrEmpty(newsite))
         {
            if (string.IsNullOrEmpty(oldsite))
            {
                int siteId = int.Parse(ConfigurationManager.AppSettings["siteId"]);
                int WapsiteId = int.Parse(ConfigurationManager.AppSettings["WapsiteId"]);
                AddWebDomain(newsite,siteId);
                AddWebDomain("m." + newsite, WapsiteId);
            }
            else
            {
                if (!string.Equals(newsite, oldsite, StringComparison.InvariantCultureIgnoreCase))
                {
                    int siteId = int.Parse(ConfigurationManager.AppSettings["siteId"]);
                    int WapsiteId = int.Parse(ConfigurationManager.AppSettings["WapsiteId"]);
                    RemoveWebDomain(oldsite, siteId);
                    AddWebDomain(newsite, siteId);
                    RemoveWebDomain("m." + oldsite, WapsiteId);
                    AddWebDomain("m." + newsite, WapsiteId);
                }
            }
         }
         else
         {
            if (!string.IsNullOrEmpty(oldsite))
            {
                int siteId = int.Parse(ConfigurationManager.AppSettings["siteId"]);
                int WapsiteId = int.Parse(ConfigurationManager.AppSettings["WapsiteId"]);
               RemoveWebDomain(oldsite,siteId);
               RemoveWebDomain(oldsite, WapsiteId);
            }
         }
      }

      #endregion
   }
}
