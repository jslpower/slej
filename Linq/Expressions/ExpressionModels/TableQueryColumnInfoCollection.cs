using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.Expressions
{
   public class TableQueryColumnInfoCollection : List<TableQueryColumnInfo>
   {
      public string[] cn2ss2
      {
         get
         {
            return this.Select(x => x.cn).Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
         }
      }
   }
}
