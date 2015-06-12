using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Web.Html.Attrib;
using Linq.Web.Html.Enums;

namespace Linq.Web.Html
{
   public class HtmlTextNode : HtmlNode
   {
      public override HtmlNodeType NodeType
      {
         get { return HtmlNodeType.Text; }
      }

      public override string ToString()
      {
         return this.Text;
      }

      public string Text { get; set; }
   }
}
