using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.Common
{
   public class MaxUtils
   {
      internal static bool Exists(string[] arr, string s)
      {
         if (arr == null || arr.Length == 0)
         {
            return false;
         }
         for (int i = 0, len = arr.Length; i < len; i++)
         {
            if (string.Equals(arr[i], s, StringComparison.OrdinalIgnoreCase))
            {
               return true;
            }
         }
         return false;
      }
   }
}
