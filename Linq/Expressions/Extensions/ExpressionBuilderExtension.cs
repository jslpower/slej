using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.ORM;

namespace Linq.Expressions.Extensions
{
   public static class ExpressionBuilderExtension
   {
      public static bool In<T>(this T obj, T[] array)
      {
         return true;
      }

      public static bool In<T, T2>(this T obj, ExpressionBuilder<T2> builder) where T2 : class,new()
      {
         return true;
      }
      
      public static bool NotIn<T>(this T obj, T[] array)
      {
         return true;
      }

      public static bool NotIn<T, T2>(this T obj, ExpressionBuilder<T2> builder) where T2 : class,new()
      {
         return true;
      }

      public static bool Equal<T, T2>(this T obj, ExpressionBuilder<T2> builder) where T2 : class, new()
      {
         return true;
      }
   }
}