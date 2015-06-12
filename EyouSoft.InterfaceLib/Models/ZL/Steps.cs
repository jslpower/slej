using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.ZL
{
   /// <summary>
   /// 团队步骤
   /// </summary>
   public enum Steps
   {
       [XmlEnum("0")]
       NONE = 0,
      [XmlEnum("1")]
      筹划中 = 1,
      [XmlEnum("2")]
      收客中 = 2,
      [XmlEnum("3")]
      停止收客 = 3,
      [XmlEnum("4")]
      出发完成 = 4,
   }
}
