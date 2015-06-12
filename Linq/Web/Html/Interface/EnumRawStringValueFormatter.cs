using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.Web.Html.Interface
{
   public class EnumRawStringValueFormatter : IValueFormatter
   {
      public string GetFormattedValue(object value)
      {
         if (value == null)
         {
            return "";
         }
         return value.ToString().ToLower();
      }
   }
}
