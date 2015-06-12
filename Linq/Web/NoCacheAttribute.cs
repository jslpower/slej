using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Linq.Web
{
   /// <summary>
   /// 
   /// </summary>
   [AttributeUsage(AttributeTargets.Class)]
   public class NoCacheAttribute : Attribute
   {
      public NoCacheAttribute()
      {
         if (HttpContext.Current!=null)
         {
            HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
         }
      }
   }
}
