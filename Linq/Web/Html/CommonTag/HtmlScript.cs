using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Web.Html.Attrib;
using Linq.Web.Html.Enums;

namespace Linq.Web.Html.CommonTag
{
   public class HtmlScript : HtmlElement
   {
      public string Language { get; set; }
      public ScriptType Type { get; set; }
      public string Src { get; set; }
      public HtmlScript():base(HtmlElementTag.Script)
      {
      }
   }
}
