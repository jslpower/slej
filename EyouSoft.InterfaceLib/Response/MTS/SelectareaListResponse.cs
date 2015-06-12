using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Models;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Common.Serializer;

namespace EyouSoft.InterfaceLib.Response.MTS
{
   [XmlRoot("Response")]
   public class SelectareaListResponse : ResponseArray<SelectareaListResponse.item>//, IXmlSerializable
   {
      public class item
      {
         public int AreaId;
         public string areaname;
         /// <summary>
         /// 分类序号
         /// </summary>
         public string xh;
         public subarea[] subsightarea;

         public class subarea
         {
            public string subsightareaId;
            public string pAreaId;
            public string areaname;
         }
      }
   }
}
