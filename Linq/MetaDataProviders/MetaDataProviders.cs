using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Linq.ModelHandler;

namespace Linq.MetaDataProviders
{
   public class ModelMetaDataProviders
   {
      public static MetaDataProvider Current { get; set; }
      static ModelMetaDataProviders()
      {
         Current = new DefaultMetaDataProvider();
      }
   }
}
