using Linq.Web.Html.Interface;
using Linq.Web.Html.Enums;
using Linq.Web.Html.Attrib;

namespace Linq.Web.Html
{
   public class HtmlTextArea : HtmlElement, INameValue, IDisabled, IReadonly
   {
      [HtmlAttribute]
      public int? Rows { get; set; }
      [HtmlAttribute]
      public int? Cols { get; set; }
      [HtmlAttribute]
      public string Name { get; set; }
      [HtmlAttribute]
      public string Disabled { get; set; }
      [HtmlAttribute]
      public string Readonly { get; set; }
      [HtmlAttribute(IsVisible = false)]
      public string Value
      {
         get
         {
            return base.InnerHtml;
         }
         set
         {
            base.InnerHtml = value;
         }
      }

      public sealed override Collections.HtmlNodeCollection Children
      {
         get;
         set;
      }

      public HtmlTextArea()
         : base(HtmlElementTag.TextArea)
      {
         this.ContentResolveWay = Enums.ContentResolveWay.OnlyText;
      }

   }
}
