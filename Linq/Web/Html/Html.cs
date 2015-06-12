using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Linq.Web.Html.CommonTag;
using Linq.Web.Html.Enums;
namespace Linq.Web.Html
{
   public class HtmlHtml : HtmlElement
   {
      public HtmlBody b { get; set; }
      public HtmlHead h { get; set; }
      public HtmlScript s { get; set; }

      protected HtmlHtml():base(HtmlElementTag.Html)
      {
         this.ChildElementType = new HtmlElementTag[] { HtmlElementTag.Head, HtmlElementTag.Body, HtmlElementTag.Script };
      }
   }
}
