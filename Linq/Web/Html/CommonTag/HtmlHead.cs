using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Web.Html.Enums;

namespace Linq.Web.Html.CommonTag
{
   public class HtmlHead : HtmlElement
   {
      public HtmlHead() :base(HtmlElementTag.Head)
      {
         this.ChildElementType = new HtmlElementTag[] { 
             HtmlElementTag.Title,
             HtmlElementTag.Meta,
             HtmlElementTag.Script,
             HtmlElementTag.Style,
             HtmlElementTag.Link
         };
      }
   }
}
