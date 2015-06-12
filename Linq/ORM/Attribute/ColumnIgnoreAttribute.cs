using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.ORM.Attribute
{
   /// <summary>
   /// 不属于此表的列
   /// </summary>
   [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
   public class ColumnIgnoreAttribute : System.Attribute
   {
   }
}
