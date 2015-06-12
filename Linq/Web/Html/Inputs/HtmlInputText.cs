using Linq.Web.Html.Enums;
using Linq.Web.Html.Attrib;

namespace Linq.Web.Html
{
   public class HtmlInputText : HtmlInput
   {
      [HtmlAttribute]
      public int? MaxLength { get; set; }
      [HtmlAttribute]
      public int? Size { get; set; }
      public HtmlInputText()
         : this(HtmlInputType.Text)
      {
      }

      public HtmlInputText(HtmlInputType type)
      {
         base.Type = type;
      }
   }
}
