using System;
using Linq.Web.Html.Collections;
using Linq.Web.Html.Interface;
using Linq.Web.Html.Attrib;
using Linq.Web.Html.Enums;

namespace Linq.Web.Html
{
   public class HtmlSelect : HtmlElement, INameValue
   {
      [HtmlAttribute(IsVisible = false)]
      public string Value { get; set; }
      [HtmlAttribute]
      public string Name { get; set; }
      HtmlOptionCollection options;
      [HtmlElementChildrenAttribute]
      public HtmlOptionCollection Options
      {
         get
         {
            if (options == null)
               options = new HtmlOptionCollection();
            return options;
         }
         set { options = value; }
      }

      public HtmlSelect():base(HtmlElementTag.Select)
      {
         this.ChildElementType = new HtmlElementTag[] { 
            HtmlElementTag.Option
         };
      }

      public override HtmlNodeCollection Children
      {
         get
         {
            return Options;
         }
         set
         {
            if (value != null)
            {
               Options = new HtmlOptionCollection();
               for (int i = 0, len = value.Count; i < len; i++)
               {
                  if (!(value[0] is HtmlOption))
                     throw new Exception(value[0] + "类型与 " + typeof(HtmlOption).FullName + " 不兼容,");
                  Options.Add(value[0] as HtmlOption);
               }
            }
         }
      }
   }
}
