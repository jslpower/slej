using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Bussiness;

namespace EyouSoft.Model.MemberStructure.WebModel
{
   public class MMember2SearchModel : MMember2, ISearchable
   {
       public bool GetSellerInfo { get; set; }
       public string WebsiteName { get; set; }
       public bool IsPage { get; set; }
      #region ISearchable 成员
    
      public SearchModel SearchInfo
      {
         get;
         set;
      }

      #endregion
   }
}
