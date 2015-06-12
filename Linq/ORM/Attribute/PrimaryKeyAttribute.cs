using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq;

namespace Linq.ORM.Attribute
{
   [AttributeUsageAttribute(AttributeTargets.Property | AttributeTargets.Field)]
   public class PrimaryKeyAttribute : System.Attribute
   {
   }
}
