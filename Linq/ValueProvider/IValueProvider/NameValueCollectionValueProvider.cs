using System.Collections.Generic;
using System.Web;
using System.Collections.Specialized;
using System.Globalization;
using System;

namespace Linq.Mvc3
{
   internal class NameValueCollectionValueProvider : IMvcValueProvider
   {
      public HashSet<string> Prefixes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

      public NameValueCollection forms { get; set; }
      public NameValueCollection queryString { get; set; }
      public NameValueCollection collection { get; set; }

      public NameValueCollectionValueProvider()
      {
         forms = HttpContext.Current.Request.Form;
         queryString = HttpContext.Current.Request.QueryString;
         collection = new NameValueCollection();
         foreach (string key in forms)
         {
            Prefixes.UnionWith(ValueProviderUtil.GetPrefix(key));
            collection.Add(key, forms[key]);
         }
         foreach (string key2 in queryString)
         {
            Prefixes.UnionWith(ValueProviderUtil.GetPrefix(key2));
            collection.Add(key2, queryString[key2]);
         }
      }

      #region IValueProvider 成员

      public ValueProviderResult GetValue(string key)
      {
         string[] values = collection.GetValues(key);
         return new ValueProviderResult(values, collection[key], CultureInfo.CurrentCulture); //rawValue, attemptValue, culture
      }

      public bool ContainsPrefix(string prefix)
      {
         return Prefixes.Contains(prefix);
      }

      #endregion
   }
}