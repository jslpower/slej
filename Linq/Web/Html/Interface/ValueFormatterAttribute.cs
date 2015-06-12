using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.Web.Html.Interface
{
   [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field)]
   public class ValueFormatterAttribute : Attribute
   {
      public Type ValueFormatterType
      {
         get;
         set;
      }
      public ValueFormatterAttribute(Type type)
      {
         this.ValueFormatterType = type;

      }
      public IValueFormatter ValueFormatter
      {
         get
         {
            if (ValueFormatterType != null)
            {
               if (!typeof(IValueFormatter).IsAssignableFrom(ValueFormatterType))
               {
                  throw new Exception("属性ValueFormatterType必须继承自" + typeof(IValueFormatter).FullName);
               }
               return (IValueFormatter)Activator.CreateInstance(ValueFormatterType);
            }
            return null;
         }
      }
   }
}
