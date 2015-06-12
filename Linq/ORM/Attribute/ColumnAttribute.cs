using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.ORM.Attribute
{
   [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
   public class ColumnAttribute : System.Attribute
   {
      public string Name { get; set; }
      public ColumnAttribute(string name)
      {
         this.Name = name;
      }
   }
}
