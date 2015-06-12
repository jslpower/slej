using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.InterfaceLib.Models.MTS
{
   /// <summary>
   /// 分页数据
   /// </summary>
   public class Page
   {
      public int pageIndex;

      public override string ToString()
      {
         return pageIndex.ToString();
      }
   }
}
