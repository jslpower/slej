using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Mvc3;

namespace Linq.ValueProvider.Factory
{
   public class NameValueCollectionFactory : ValueProviderFactory
   {
      public override IMvcValueProvider GetValueProvider()
      {
         return new NameValueCollectionValueProvider();
      }
   }
}
