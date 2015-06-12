using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models
{
   public enum Is
   {
      /// <summary>
      /// 是
      /// </summary>
      [XmlEnum("1")]
      是 = 1,
      /// <summary>
      /// 否
      /// </summary>
      [XmlEnum("0")]
      否 = 0
   }
}
