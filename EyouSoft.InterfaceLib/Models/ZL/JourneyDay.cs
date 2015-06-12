using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.InterfaceLib.Models.ZL
{
   /// <summary>
   /// 一天的具体行程
   /// </summary>
   public class JourneyDay
   {
      /// <summary>
      /// 该天行程的主键
      /// </summary>
      public int SID;
      /// <summary>
      /// 该天行程所属团队编码
      /// </summary>
      public int GroupID;
      /// <summary>
      /// 所属天次（从 1 开始）
      /// </summary>
      public int Days;
      /// <summary>
      /// 地点或城市
      /// </summary>
      public string Place;
      /// <summary>
      /// 住宿
      /// </summary>
      public string Lodging;
      /// <summary>
      /// 用餐
      /// </summary>
      public string Dining;
      /// <summary>
      /// 大交通
      /// </summary>
      public string Traffic;
      /// <summary>
      /// 活动内容
      /// </summary>
      public string Content;

   }
}
