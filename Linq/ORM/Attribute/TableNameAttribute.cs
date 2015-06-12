using System;
using Linq.ORM;
using System.Security.Permissions;

//[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
namespace Linq.ORM.Attribute
{
   [AttributeUsage(AttributeTargets.Class)]
   public class TableAttribute : System.Attribute
   {
      public string Name { get; set; }
      public TableAttribute(string name)
      {
         Name = name;
      }
   }
}
