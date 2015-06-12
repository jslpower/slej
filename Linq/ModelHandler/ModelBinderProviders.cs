using System;
using System.Collections.Generic;
using System.Linq;
using Linq.ModelHandler;
namespace Linq.Mvc3
{
   public class ModelBinderProviders
   {
      public static ModelBinderProviderDictionary Providers { get; set; }

      static ModelBinderProviders()
      {
         Providers = new ModelBinderProviderDictionary();
      }
   }
   public class ModelBinderProviderDictionary : Dictionary<Type, IModelBinderProvider>
   {

   }
}