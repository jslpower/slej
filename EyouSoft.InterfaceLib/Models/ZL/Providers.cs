using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.ZL
{
   public enum Providers
   {
       [XmlEnum("0")]
       NONE = 0,
      [XmlEnum("1")]
      集团公司 = 1,
      [XmlEnum("2")]
      省中旅 = 2,
      [XmlEnum("3")]
      省国旅 = 3,
      [XmlEnum("4")]
      票务中心 = 4,
      [XmlEnum("6")]
      知行国际 = 6,
      [XmlEnum("7")]
      知行商务 = 7,
      [XmlEnum("8")]
      阿克苏 = 8,
      [XmlEnum("9")]
      上海分公司 = 9,
      [XmlEnum("10")]
      长兴分公司 = 10
   }
}
