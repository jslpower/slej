using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace EyouSoft.BLL
{
   public class SellerDomainGetter
   {
      public static string GetSellerDomain()
      {
         string url = HttpContext.Current.Request.RawUrl;
         if (string.IsNullOrEmpty(url))
         {
            return "";
         }
         string[] dotSig = null;
         if (url.IndexOf("//") > -1)
         {
            string[] sig = url.Split(new string[] { "//" }, StringSplitOptions.RemoveEmptyEntries);
            if (sig.Length == 2)
            {
               dotSig = sig[1].Split('.');
            }
         }
         else
         {
            dotSig = url.Split('.');
         }
         if (dotSig != null && dotSig.Length > 0)
         {
            string cellphoneNo = dotSig[0];
            if (!Regex.IsMatch(cellphoneNo, "\\d{4}"))
            {
               return "";
            }
            return cellphoneNo;
         }
         return "";
      }
   }
}
