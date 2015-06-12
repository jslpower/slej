using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.Bussiness
{
   public class PageInfo
   {
      public int PageSize
      {
         get;
         set;
      }
      public int PageIndex
      {
         get;
         set;
      }
      /// <summary>
      /// 数据总行数
      /// </summary>
      public int TotalCount { get; set; }
      int pageCount;
      public int PageCount
      {
         get
         {
            if (TotalCount == 0) pageCount = 0;
            if (PageSize == 0) PageSize = 10;
            if (TotalCount % PageSize == 0)
               pageCount = TotalCount / PageSize;
            else
               pageCount = Convert.ToInt32(TotalCount / PageSize) + 1;
            return pageCount;
         }
         set { pageCount = value; }
      }

      public PageInfo()
      {
         this.PageSize = 10;
      }
   }
}
