using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model;

namespace EyouSoft.InterfaceLib.Models.Bok
{
   /// <summary>
   /// 线路行程信息业务实体
   /// </summary>
   public class MXianLuXingChengInfo_BokServcice : IConvertToMModel
   {
      public MXianLuXingChengInfo_BokServcice() { }

      /// <summary>
      /// 区间
      /// </summary>
      public string QuJian { get; set; }
      /// <summary>
      /// 交通
      /// </summary>
      public string JiaoTong { get; set; }
      /// <summary>
      /// 住宿
      /// </summary>
      public string ZhuSu { get; set; }
      /// <summary>
      /// 用餐
      /// </summary>
      public string YongCan { get; set; }
      /// <summary>
      /// 行程内容
      /// </summary>
      public string XingCheng { get; set; }
      /// <summary>
      /// 行程图片
      /// </summary>
      public string FilePath { get; set; }
   }
}
