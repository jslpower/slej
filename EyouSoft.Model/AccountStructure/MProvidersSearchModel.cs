using System;
using Linq.Bussiness;
using EyouSoft.Model.Enum;

namespace EyouSoft.Model.AccountStructure
{
   public class MProvidersSearchModel : MProviders, ISearchable
   {
      #region ISearchable 成员

      public string Account { get; set; }

      public string Password { get; set; }

      public SearchModel SearchInfo
      {
         get;
         set;
      }
  
      #endregion
   }
}
