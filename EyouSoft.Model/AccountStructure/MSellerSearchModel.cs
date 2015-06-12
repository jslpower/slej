using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Bussiness;

namespace EyouSoft.Model.AccountStructure
{
   public class MSellerSearchModel : MSellers, ISearchable
   {
      #region ISearchable 成员

      public SearchModel SearchInfo
      {
         get
         {
            throw new NotImplementedException();
         }
         set
         {
            throw new NotImplementedException();
         }
      }

      #endregion
   }
}
