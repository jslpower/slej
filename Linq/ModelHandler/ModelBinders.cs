using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Mvc3;

namespace Linq.ModelHandler
{
   public class ModelBinders
   {
      public static ModelBinderDictionary Binders { get; set; }
      static ModelBinders()
      {
         Binders = new ModelBinderDictionary();
      }
   }
   public class ModelBinderDictionary : Dictionary<Type, IModelBinder>
   {
      public IModelBinder GetModelBinder(Type type)
      {
         IModelBinderProvider provider;
         if (ModelBinderProviders.Providers.TryGetValue(type, out provider))
         {
            return provider.GetModelBinder(type);
         }
         IModelBinder binder;
         if (this.TryGetValue(type, out binder))
         {
            return binder;
         }
         var attrs = type.GetCustomAttributes(false).OfType<ModelBinderAttribute>();
         if (attrs.Count() > 0)
         {
            Type binderType = attrs.First().ModelBinderType;
            return (IModelBinder)Activator.CreateInstance(binderType);
         }
         return new DefaultModelBinder();
      }
   }
}
