using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.Web.Html.Interface
{
   public class CustomValueFormatter : IValueFormatter
   {
      #region IValueFormatter 成员

      public string GetFormattedValue(object value)
      {
         object v = value;
         if (this.predicate != null)
         {
            v = predicate.DynamicInvoke(value);
         }
         return v == null ? "" : v.ToString();
      }
      Delegate predicate;
      public CustomValueFormatter(Delegate predicate)
      {
         this.predicate = predicate;
      }
      #endregion
   }
}
