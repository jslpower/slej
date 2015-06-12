using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Linq.Mvc3;

namespace Linq.ValueProvider
{
   public class ValueProviderCollection : Collection<IMvcValueProvider>, IMvcValueProvider
   {
      public ValueProviderCollection(List<IMvcValueProvider> collection)
         : base(collection)
      {
      }
      public bool ContainsPrefix(string prefix)
      {
         return this.Any(x => x.ContainsPrefix(prefix));
      }
      static ValueProviderResult GetValueFromProvider(IMvcValueProvider ValueProvider, string key)
      {
         return ValueProvider.GetValue(key);
      }

      public ValueProviderResult GetValue(string key)
      {
         return this.Select(x => GetValueFromProvider(x, key)).Where(y => y != null).FirstOrDefault();
      }
   }
}
