using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.MTS
{
   /// <summary>
   /// 景区(资源)级别
   /// </summary>
   public enum Grades
   {
      [XmlEnum("1")]
      A = 1,
      [XmlEnum("2")]
      AA = 2,
      [XmlEnum("3")]
      AAA = 3,
      [XmlEnum("4")]
      AAAA = 4,
      [XmlEnum("5")]
      AAAAA = 5,
      [XmlEnum("9")]
      未评级 = 9,
   }
}
