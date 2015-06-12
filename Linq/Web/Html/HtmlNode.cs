using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Web.Html.Attrib;
using Linq.Web.Html.Enums;

namespace Linq.Web.Html
{
   public abstract class HtmlNode
   {
      public HtmlElement Parent { get; set; }
      public abstract HtmlNodeType NodeType { get; }
      public virtual void Dispose() { }
      public override string ToString()
      {
         return string.Empty;
      }
   }
}
