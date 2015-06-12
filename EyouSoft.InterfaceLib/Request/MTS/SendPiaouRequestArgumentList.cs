using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Models;
using EyouSoft.InterfaceLib.Models.MTS;

namespace EyouSoft.InterfaceLib.Request.MTS
{
   [XmlRoot("Response")]
   public class SendPiaouRequestArgumentList : ArgumentBase
   {
      /// <summary>
      /// 订单id
      /// </summary>
      public int orderid;
      /// <summary>
      /// 支付宝订单号
      /// </summary>
      public string trade_no;
      /// <summary>
      /// 支付宝帐号
      /// </summary>
      [XmlElement("buyer_email")]
      public string aplipay_account;
      /// <summary>
      /// 支付状态
      /// </summary>
      public PayStates trade_status;
   }
}
