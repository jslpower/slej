using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.ORM.Attribute
{
   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
   public class UniqueAttribute : System.Attribute
   {
   }
}
