using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Bussiness;

namespace EyouSoft.Model.ScenicStructure.WebModel
{
   public class RegModel : MMember2, ISearchable, IConvertToMModel
   {
      public string Code { get; set; }

      #region ISearchable 成员

      public SearchModel SearchInfo
      {
         get;
         set;
      }

      #endregion
   }
}
