using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.Web.Html.Interface
{
   internal class DefaultValueFormatter : IValueFormatter
   {
      #region IValueFormatter 成员

      public string GetFormattedValue(object value)
      {
         return value == null ? "" : value.ToString();
      }

      #endregion
   }
}
