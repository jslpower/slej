using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.ORM.Attribute
{
   [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
   public class IdentityAttribute : System.Attribute
   {
      public IdentityAttribute()
      {
      }
      public IdentityAttribute(IdentityType identityType)
      {
         this.IdentityType = identityType;
      }
      public IdentityType IdentityType { get; set; }
   }
}
