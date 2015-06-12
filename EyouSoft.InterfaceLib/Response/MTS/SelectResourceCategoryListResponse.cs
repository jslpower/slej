using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Response.MTS
{
   /// <summary>
   /// 景区(资源)类型
   /// </summary>
   [XmlRoot("Response")]
   public class SelectResourceCategoryListResponse : ResponseArray<SelectResourceCategoryListResponse.item>
   {
      public class item
      {
         /// <summary>
         /// 分类id
         /// </summary>
         public int flag;
         /// <summary>
         /// 分类名称
         /// </summary>
         public string name;
      }
   }
}
