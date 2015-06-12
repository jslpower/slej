using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linq.Mvc3
{
   public interface IMvcValueProvider
   {
      bool ContainsPrefix(string prefix);
      ValueProviderResult GetValue(string key);
   }
}