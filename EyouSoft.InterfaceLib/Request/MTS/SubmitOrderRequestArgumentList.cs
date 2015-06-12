using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Common.Serializer;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Models;
using EyouSoft.InterfaceLib.Models.MTS;

namespace EyouSoft.InterfaceLib.Request.MTS
{
   [XmlRoot("Response")]
   public class SubmitOrderRequestArgumentList : ArgumentBase
   {
      /// <summary>
      /// 订单id，自己网站的订单id
      /// </summary>
      public string orderid;
      /// <summary>
      /// 门票记录id
      /// </summary>
      public int productid;
      /// <summary>
      /// 预订张数
      /// </summary>
      public int amount;
      /// <summary>
      /// 使用日期
      /// </summary>
      public DateTime date;
      /// <summary>
      /// 取票人姓名
      /// </summary>
      public string username;
      /// <summary>
      /// 接收短信手机号
      /// </summary>
      public string mobile;
      /// <summary>
      /// 备注
      /// </summary>
      public string bz;
      /// <summary>
      /// 预订人姓名
      /// </summary>
      public string name_linkman;
      /// <summary>
      /// 预订人电话
      /// </summary>
      public string phone_linkman;
   }
}
