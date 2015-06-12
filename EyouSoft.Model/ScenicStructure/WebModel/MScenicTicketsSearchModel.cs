using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.ScenicStructure.WebModel
{
   /// <summary>
   /// 景区门票
   /// </summary>
   public class MScenicTicketsSearchModel
   {
      /// <summary>
      /// 景区编号
      /// </summary>
      public string ScenicId { get; set; }
      /// <summary>
      /// 门票类型名称
      /// </summary>
      public string TypeName { get; set; }
      /// <summary>
      /// 英文名称
      /// </summary>
      public string EnName { get; set; }
      /// <summary>
      /// 票价有效时间_始
      /// </summary>
      public DateTime? StartTimeS { get; set; }
      /// <summary>
      /// 票价有效时间_始
      /// </summary>
      public DateTime? StartTimeE { get; set; }
      /// <summary>
      /// 票价有效时间_止
      /// </summary>
      public DateTime? EndTimeS { get; set; }
      /// <summary>
      /// 票价有效时间_止
      /// </summary>
      public DateTime? EndTimeE { get; set; }
      /// <summary>
      /// 状态（上架，下架）
      /// </summary>
      public EyouSoft.Model.Enum.ScenicStructure.ScenicTicketsStatus? Status { get; set; }
      /// <summary>
      /// 最后修改时间
      /// </summary>
      public DateTime? LastUpdateTimeS { get; set; }
      /// <summary>
      /// 最后修改时间
      /// </summary>
      public DateTime? LastUpdateTimeE { get; set; }
      /// <summary>
      /// 景区名称
      /// </summary>
      public string ScenicName { get; set; }
      /// <summary>
      /// 是否同行分销
      /// </summary>
      public bool? IsFenXiao { get; set; }
   }
}
