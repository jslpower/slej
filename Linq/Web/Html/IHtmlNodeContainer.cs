using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Web.Html.Collections;
namespace Linq.Web.Html
{
   public interface IHtmlNodeContainer : IUnique
   {
      HtmlNodeCollection Children { get; set; }
      HtmlElement Parent { get; set; }
   }
}
