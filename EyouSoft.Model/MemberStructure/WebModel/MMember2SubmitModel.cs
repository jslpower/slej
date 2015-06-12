using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Bussiness;

namespace EyouSoft.Model.MemberStructure.WebModel
{
   public class MMember2SubmitModel : MMember2, ISearchable, IConvertToMModel
   {
      #region ISearchable 成员

      public SearchModel SearchInfo
      {
         get;
         set;
      }

      #endregion
   }
}
