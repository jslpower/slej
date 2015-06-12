using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Response.MTS
{
   [XmlRoot("Response")]
   public class SelectResourceListResponse : ResponseArray<SelectResourceListResponse.item>
   {
      public class item
      {
         public int Id;
         public string sightname;
      }
   }
}
