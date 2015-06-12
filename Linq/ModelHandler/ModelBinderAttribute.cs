using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.ModelHandler
{
   [AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter, AllowMultiple = false)]
   public class ModelBinderAttribute : Attribute
   {
      public ModelBinderAttribute(Type modelBinderType)
      {
         this.ModelBinderType = modelBinderType;
      }

      public Type ModelBinderType { get; set; }
   }
}
