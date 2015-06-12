using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.Web.Html.Interface
{
   public class IsSelectedAttributeValueTransfer : IValueFormatter
   {
      public string GetFormattedValue(object value)
      {
         return (bool)value ? "selected" : null;
      }
   }
}
