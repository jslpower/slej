using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model;

namespace EyouSoft.InterfaceLib.Models.Bok
{
   public class MXianLuFuWuInfo_BokServcice : IConvertToMModel
   {
      /// <summary>
      /// default constructor
      /// </summary>
      public MXianLuFuWuInfo_BokServcice() { }

      /// <summary>
      /// 服务标准
      /// </summary>
      public string FuWuBiaoZhun { get; set; }
      /// <summary>
      /// 不含项目
      /// </summary>
      public string BuHanXiangMu { get; set; }
      /// <summary>
      /// 购物安排
      /// </summary>
      public string GouWuAnPai { get; set; }
      /// <summary>
      /// 儿童安排
      /// </summary>
      public string ErTongAnPai { get; set; }
      /// <summary>
      /// 自费项目
      /// </summary>
      public string ZiFeiXiangMu { get; set; }
      /// <summary>
      /// 注意事项
      /// </summary>
      public string ZhuYiShiXiang { get; set; }
      /// <summary>
      /// 温馨提醒
      /// </summary>
      public string WenXinTiXing { get; set; }
      /// <summary>
      /// 报名须知
      /// </summary>
      public string BaoMingXuZhi { get; set; }

      /// <summary>
      /// 赠送项目
      /// </summary>
      public string ZengSongXiangMu { get; set; }
      /// <summary>
      /// 其他事项
      /// </summary>
      public string QiTaShiXiang { get; set; }
   }
}
