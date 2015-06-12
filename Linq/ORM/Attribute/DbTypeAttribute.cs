using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Linq.ORM.Attribute
{
   public class DbTypeAttribute : System.Attribute
   {
      public DbType DbType { get; set; }
      public DbTypeAttribute(DbType dbtype)
      {
         this.DbType = dbtype;
      }
   }
}
