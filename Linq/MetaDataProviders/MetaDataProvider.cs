using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.ModelHandler;

namespace Linq.MetaDataProviders
{
   public abstract class MetaDataProvider
   {
      public abstract MvcModelMetaData CreateMetaData(Type type);
      public MvcModelMetaData GetModelMetaDataForProperty(object model, Type type)
      {
         return new MvcModelMetaData
         {
            ModelType = type,
         };
      }
      public MvcModelMetaData GetModelMetaDataForType(object model, Type type)
      {
         //return this[0].CreateMetaData(type);
         return new MvcModelMetaData
         {
            ModelType = type,
         };
      }
   }

   public class DefaultMetaDataProvider : MetaDataProvider
   {
      public override MvcModelMetaData CreateMetaData(Type type)
      {
         return null;
      }
   }
}
