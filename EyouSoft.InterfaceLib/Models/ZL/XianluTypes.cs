using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.ZL
{
   public enum XianluTypes
   {

        [XmlEnum("0")]
        NONE = 0,
      [XmlEnum("1")]
      散拼团 = 1,
      [XmlEnum("2")]
      整包团 = 2,
      [XmlEnum("3")]
      自由行 = 3,
      [XmlEnum("4")]
      单做签证 = 4
   }
}
