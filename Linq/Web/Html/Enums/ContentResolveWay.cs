using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.Web.Html.Enums
{
   public enum ContentResolveWay
   {
      /// <summary>
      /// 所有都看作html
      /// </summary>
      Html,
      /// <summary>
      /// 只解析文本，忽略html
      /// </summary>
      Text,
      /// <summary>
      /// 所有都看作文本
      /// </summary>
      HtmlText,
      /// <summary>
      /// 只能允许文本
      /// </summary>
      OnlyText,
   }
}
