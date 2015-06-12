using System.Collections.Generic;
using System;

namespace Linq.Mvc3
{
   internal class ValueProviderUtil
   {
      public static IEnumerable<string> GetPrefix(string key)
      {
         yield return key;
         for (int i = key.Length - 1; i >= 0; i--)
         {
            char c = key[i];
            if (c == '.' || c == '[')
            {
               yield return key.Substring(0, i);
            }
         }
         yield break;
      }

      public static bool CollectionContainsPrefix(IEnumerable<string> collection, string prefix)
      {
         foreach (string current in collection)
         {
            if (current != null)
            {
               if (prefix.Length == 0)
               {
                  bool result = true;
                  return result;
               }
               if (current.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
               {
                  if (current.Length == prefix.Length)
                  {
                     bool result = true;
                     return result;
                  }
                  char c = current[prefix.Length];
                  if (c == '.' || c == '[')
                  {
                     bool result = true;
                     return result;
                  }
               }
            }
         }
         return false;
      }

   }
}