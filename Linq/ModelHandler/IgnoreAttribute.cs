using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.ModelHandler
{
   /// <summary>
   /// 指示该字段在绑定时应忽略
   /// </summary>
   [AttributeUsage(AttributeTargets.Property)]
   public class IgnoreAttribute : Attribute
   {
   }
}
