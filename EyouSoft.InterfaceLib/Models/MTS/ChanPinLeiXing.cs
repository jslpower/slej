using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.MTS
{
   /// <summary>
   /// 产品类型
   /// </summary>
   public enum ChanPinLeiXing
   {
      [XmlEnum("1")]
      团体票 = 1,
      [XmlEnum("2")]
      散客票 = 2,
   }
}
