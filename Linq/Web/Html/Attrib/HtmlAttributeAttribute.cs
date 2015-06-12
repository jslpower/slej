using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Web.Html.Interface;

namespace Linq.Web.Html.Attrib
{
   [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
   public class HtmlAttributeAttribute : ValueFormatterAttribute
   {
      /// <summary>
      /// 是否会呈现在标记中
      /// </summary>
      public bool IsVisible { get; set; }
      /// <summary>
      /// 即便为空值，也呈现出来,这个是为解决 jquery1.4.4的一个bug，如果option没有value，且该option为选中状态，那么select的值就是该option的文本了。
      /// </summary>
      public bool AllowEmptyString { get; set; }
      public string Name { get; set; }

      public object RawValue { get; set; }
      public HtmlAttributeAttribute()
         : this(true)
      {
      }
      internal HtmlAttributeAttribute(object rawValue)
         : this()
      {
         this.RawValue = rawValue;
         this.ValueFormatterType = typeof(DefaultValueFormatter);
      }

      public HtmlAttributeAttribute(string name, Type valueFormatterType, bool isVisible)
         : base(valueFormatterType)
      {
         this.Name = name;
         this.IsVisible = isVisible;
         this.ValueFormatterType = valueFormatterType;
      }
      public HtmlAttributeAttribute(bool isVisible)
         : this(null, null, isVisible)
      {
      }
   }
}
