using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Mvc3;
using System.Collections.ObjectModel;
using Linq.ValueProvider.Factory;
using System.Web;

namespace Linq.ValueProvider
{
   public abstract class ValueProviderFactory
   {
      public abstract IMvcValueProvider GetValueProvider();
   }
   public class ValueProviderFactories
   {
      public static ValueProviderFactoryCollection Factories { get; set; }
      static ValueProviderFactories()
      {
         Factories = new ValueProviderFactoryCollection
         {
            new NameValueCollectionFactory()
         };
      }
   }

   public class ValueProviderFactoryCollection : Collection<ValueProviderFactory>
   {
      public IMvcValueProvider GetValueProvider(HttpContext context)
      {
         IEnumerable<IMvcValueProvider> list = this.Select(x => x.GetValueProvider());
         return new ValueProviderCollection(list.ToList());
      }
   }
}
