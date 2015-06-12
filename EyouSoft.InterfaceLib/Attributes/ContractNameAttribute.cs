using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.InterfaceLib.Attributes
{
   /// <summary>
   /// 接口名称
   /// </summary>
   public class ContractNameAttribute : Attribute
   {
      public string Name { get; set; }

      public ContractNameAttribute(string Name)
      {
         this.Name = Name;
      }
   }
}
