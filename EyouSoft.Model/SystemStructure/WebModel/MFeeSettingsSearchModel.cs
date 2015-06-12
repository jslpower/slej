using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Bussiness;

namespace EyouSoft.Model.SystemStructure.WebModel
{
   public class MFeeSettingsSearchModel : MFeeSettings, ISearchable
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
