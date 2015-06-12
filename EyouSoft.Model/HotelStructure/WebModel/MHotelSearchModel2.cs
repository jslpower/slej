using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Bussiness;
using EyouSoft.Model.SystemStructure;

namespace EyouSoft.Model.HotelStructure.WebModel
{
   public class MHotelSearchModel2 : MHotel2, ISearchable
   {
      public MFeeSettings FeeSetting { get; set; }
      public MHotelRoomRate2 PriceInfo { get; set; }
      #region ISearchable 成员

      public SearchModel SearchInfo
      {
         get;
         set;
      }

      #endregion
   }
}
