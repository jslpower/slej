using Linq.Web.Html.Interface;
using Linq.Web.Html.Enums;
using Linq.Web.Html.Attrib;

namespace Linq.Web.Html
{
   public abstract class HtmlInput : HtmlElement, INameValue, IReadonly, IDisabled
   {
      [HtmlAttribute]
      public string Name { get; set; }
      [HtmlAttribute]
      public string Value { get; set; }
      [HtmlAttribute(ValueFormatterType = typeof(EnumRawStringValueFormatter))]
      public HtmlInputType Type { get; internal set; }
      [HtmlAttribute]
      public virtual string Disabled { get; set; }
      [HtmlAttribute]
      public virtual string Readonly { get; set; }
      public sealed override Collections.HtmlNodeCollection Children { get; set; }
      public HtmlInput()
         : base(HtmlElementTag.Input, TagCloseType.SingleTag)
      {
         this.Type = HtmlInputType.Text;
      }

      internal static HtmlInput Create(HtmlInputType inputType)
      {
         switch (inputType)
         {
            case HtmlInputType.Hidden:
               return new HtmlInputHidden();
            case HtmlInputType.Text:
               return new HtmlInputText();
            default:
               return new HtmlInputText();
         }
      }
   }
}
