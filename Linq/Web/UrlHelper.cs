using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.ComponentModel;

namespace Linq.Web
{
   public class UrlHelper
   {
      public UrlHelper(HttpContext httpContext)
      {
         this.HttpContext = httpContext;
      }
      //不熟悉Execute,勿盲目使用RenderPartial方法
      public string RenderPartial(string partialView)
      {
         StringWriter sw = new StringWriter();
         if (!string.IsNullOrEmpty(partialView))
         {
            //不熟悉Execute,勿盲目使用RenderPartial方法
            HttpContext.Server.Execute(partialView, sw, true);
         }
         return sw.ToString();
      }
      //不熟悉Execute,勿盲目使用RenderPartial方法
      public string RenderPartial(string partialView, object model)
      {
         StringWriter sw = new StringWriter();
         string s = "";
         if (model != null)
         {
            int i = 0;
            foreach (PropertyDescriptor p in TypeDescriptor.GetProperties(model))
            {
               object value = p.GetValue(model);
               s += (i > 0 ? "&" : "") + (p.Name + "=" + HttpContext.Server.UrlEncode(value == null ? "" : value.ToString()));
               i++;
            }
         }
         if (!string.IsNullOrEmpty(partialView))
         {
            if (partialView.IndexOf("?") > -1)
            {
               partialView += "&" + s;
            }
            else
            {
               partialView += "?" + s;
            }
            HttpContext.Server.Execute(partialView, sw, false);
         }
         return sw.ToString();
      }

      public HttpContext HttpContext { get; set; }
   }
}
