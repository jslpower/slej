using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.ZL
{
   /// <summary>
   /// 团队状态
   /// </summary>
   public enum TuanDuiStates
   {
      [XmlEnum("0")]
      无效 = 0,
      [XmlEnum("1")]
      有效 = 1
   }
}
