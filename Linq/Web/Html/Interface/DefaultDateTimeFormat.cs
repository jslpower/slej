using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.Web.Html.Interface
{
   public class DefaultDateTimeFormat : IValueFormatter
   {
      #region IValueFormatter 成员

      public string GetFormattedValue(object value)
      {
         if (value == null)
         {
            return "";
         }
         return ((DateTime)value).ToString("yyyy-MM-dd");
      }

      #endregion
   }
}
