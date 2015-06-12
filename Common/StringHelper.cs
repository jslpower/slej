using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Common
{
   public static class StringHelper
   {
      public static string Replicate(this string s, int times)
      {
         string str = "";
         if (s != null)
         {
            for (int i = 0; i < times; i++)
            {
               str += s;
            }
         }
         return str;
      }
   }
}
