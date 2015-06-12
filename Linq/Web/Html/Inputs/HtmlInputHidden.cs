using Linq.Web.Html.Enums;

namespace Linq.Web.Html
{
   public class HtmlInputHidden : HtmlInput
   {
      public HtmlInputHidden()
      {
         base.Type = HtmlInputType.Hidden;
      }
   }
}
