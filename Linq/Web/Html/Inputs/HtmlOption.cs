using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Linq.Web.Html.Interface;
using Linq.Web.Html.Enums;
using Linq.Web.Html.Attrib;

namespace Linq.Web.Html
{
   public class HtmlOption : HtmlElement, IValue
   {
      [HtmlAttribute(AllowEmptyString = true)]
      public string Value { get; set; }
      [HtmlAttribute("selected", typeof(IsSelectedAttributeValueTransfer), true)]
      public bool IsSelected { get; set; }
      public HtmlOption()
         : base(HtmlElementTag.Option)
      {
      }

      public HtmlOption(string value, string text, bool isSelected)
         : this()
      {
         this.Value = value;
         this.InnerHtml = text;
         this.IsSelected = isSelected;
      }
   }
}
