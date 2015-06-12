using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.MTS
{
   /// <summary>
   /// 支付状态
   /// </summary>
   public enum PayStates
   {
      [XmlEnum("1")]
      未付款 = 1,
      [XmlEnum("2")]
      已付款 = 2,
      [XmlEnum("3")]
      支付失败 = 3
   }
}
