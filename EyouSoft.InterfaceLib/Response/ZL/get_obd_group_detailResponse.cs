using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Models;
using EyouSoft.InterfaceLib.Response.MTS;
using EyouSoft.InterfaceLib.Models.ZL;

namespace EyouSoft.InterfaceLib.Response.ZL
{
   /// <summary>
   /// 出境团队详情
   /// </summary>
   [XmlRoot(ElementName = "request_result")]
   public class get_obd_group_detailResponse : ResponseBase
   {
      /// <summary>
      /// 返回结果 0表示成功,大于0代表错误码
      /// </summary>
      public int result_id;
      /// <summary>
      /// 错误描述
      /// </summary>
      public string error_desc;
      /// <summary>
      /// 团队头信息
      /// </summary>
      public Group_Header_Detail group_header;
      /// <summary>
      /// 团队行程清单信息
      /// </summary>
      [XmlArrayItem(ElementName = "journey_day", Type = typeof(JourneyDay))]
      public JourneyDay[] group_journeys;
      [XmlArrayItem(ElementName = "accessory", Type = typeof(GroupAccessory))]
      public GroupAccessory[] group_accessorys;
   }
}
