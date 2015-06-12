using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Bussiness;
using EyouSoft.Model.SystemStructure;

namespace EyouSoft.Model.ScenicStructure.WebModel
{
   public class MScenicAreaTicketsOrderWebBindModel : MScenicAreaOrder, ISearchable
   {
      public MScenicArea AreaInfo { get; set; }

      public MFeeSettings FeeSetting { get; set; }

      public MScenicTickets TicketInfo { get; set; }
      /// <summary>
      /// 当前登录用户的价格
      /// </summary>
      public decimal CurrentPrice { get; set; }
      /// <summary>
      /// 是否显示申请分销
      /// </summary>
      public bool IsShowFenXiaoShenQing { get; set; }

      #region ISearchable 成员

      public SearchModel SearchInfo
      {
         get;
         set;
      }

      #endregion
   }
}
