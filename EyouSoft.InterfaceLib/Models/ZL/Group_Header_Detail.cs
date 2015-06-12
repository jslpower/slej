using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.ZL
{
   /// <summary>
   /// 团队头信息
   /// </summary>
   [XmlRoot("group_header")]
   public class Group_Header_Detail : Group_Header
   {
      public XianluTypes TypeID;
      public int LowNum;
   }
}
