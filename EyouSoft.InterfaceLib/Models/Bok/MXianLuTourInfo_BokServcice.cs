using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Models;
using EyouSoft.Model;

namespace EyouSoft.InterfaceLib.Models.Bok
{
   /// <summary>
   /// 线路发班信息业务实体
   /// </summary>
   public partial class MXianLuTourInfo_BokServcice : IConvertToMModel
   {
      public MXianLuTourInfo_BokServcice() { }
      /// <summary>
      /// 团队编号
      /// </summary>
      public string TourId { get; set; }
      /// <summary>
      /// 出发日期
      /// </summary>
      public DateTime LDate { get; set; }
      /// <summary>
      /// 回程日期
      /// </summary>
      public DateTime RDate { get; set; }
      /// <summary>
      /// 收客状态
      /// </summary>
      public ShouKeZhuangTai Status { get; set; }

      /// <summary>
      /// 订单数量
      /// </summary>
      public int DingDanShu { get; set; }
      /// <summary>
      /// 已收人数
      /// </summary>
      public int YiShouRenShu { get; set; }
      /// <summary>
      /// 实收人数
      /// </summary>
      public int ShiShouRenShu { get; set; }

      /// <summary>
      /// 结算价-成人
      /// </summary>
      public decimal JSJCR { get; set; }
      /// <summary>
      /// 结算价-儿童
      /// </summary>
      public decimal JSJET { get; set; }

      /// <summary>
      /// 剩余人数
      /// </summary>
      public int SYRS { get; set; }

      /// <summary>
      /// 航班号
      /// </summary>
      public string TrafficId { get; set; }
      /// <summary>
      /// 市场价-成人-针对接口数据
      /// </summary>
      public decimal CRSCJ { get; set; }
      /// <summary>
      /// 市场价-儿童-针对接口数据
      /// </summary>
      public decimal ETSCJ { get; set; }
   }

    /// <summary>
   /// 线路发班信息业务实体
   /// </summary>
   public partial class MXianLuTourTraffice_BokServcice : IConvertToMModel
   {

       /// <summary>
       /// 线路编号
       /// </summary>
       public string TourId { get; set; }

       /// <summary>
       /// 航班号
       /// </summary>
       public string TrafficId { get; set; }


       /// <summary>
       /// 去程信息
       /// </summary>
       public string Traffic_01 { get; set; }


       /// <summary>
       /// 回程信息
       /// </summary>
       public string Traffic_02 { get; set; }
   }
}
