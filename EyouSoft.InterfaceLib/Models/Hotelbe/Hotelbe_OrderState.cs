using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.InterfaceLib.Models.Hotelbe
{
   /// <summary>
   /// Hotelbe 返回订单状态
   /// </summary>
   public enum Hotelbe_OrderState
   {
      /// <summary>
      /// (确认单)
      /// </summary>
      CON,
      /// <summary>
      /// (申请单)
      /// </summary>
      RES,
      /// <summary>
      /// (修改单)
      /// </summary>
      MOD,
      /// <summary>
      /// (拒绝单)
      /// </summary>
      HAC,
      /// <summary>
      /// (测试)
      /// </summary>
      TST,
      /// <summary>
      /// (客户取消)
      /// </summary>
      XXX,
      /// <summary>
      /// (取消确认单)
      /// </summary>
      CAN,
      /// <summary>
      /// (房间确认)
      /// </summary>
      RCM
   }
}
