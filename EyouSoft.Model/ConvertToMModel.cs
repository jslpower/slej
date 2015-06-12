using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using Linq.TypeHelpers;

namespace EyouSoft.Model
{
   /// <summary>
   /// 支持同类模型间的填充
   /// </summary>
   public interface IConvertToMModel
   {

   }

   public static class Converter
   {
      /// <summary>
      /// 从模型更新
      /// </summary>
      public static object UpdateFrom<T>(this IConvertToMModel model1, T model2)
        where T : new()
      {
         if (model1 == null || model2 == null)
         {
            return model2;
         }
         return Convert(model1, model2, true);
      }

      public static T ConvertTo<T>(this IConvertToMModel model)
         where T : new()
      {
         return (T)Convert(model, default(T), false);
      }

      /// <summary>
      /// 更新到模型
      /// </summary>
      public static T UpdateTo<T>(this IConvertToMModel model, T detinationModel) where T : new()
      {
         if (detinationModel == null)
         {
            return default(T);
         }
         return (T)Convert(model, detinationModel, false);
      }

      static Dictionary<Type, PropertyInfo[]> PropertyInfoCache = new Dictionary<Type, PropertyInfo[]>();

      public static object Convert<T>(this IConvertToMModel model1, T model2, bool from) where T : new()
      {
         if (model1 == null)
         {
            return default(T);
         }
         if (model2 == null)
         {
            model2 = new T();
         }
         Type T1 = model1.GetType();
         Type T2 = typeof(T);
         PropertyInfo[] model1Ps, model2Ps;
         if (!PropertyInfoCache.ContainsKey(T2))
         {
            PropertyInfoCache.Add(T2, T2.GetProperties());
         }
         if (!PropertyInfoCache.ContainsKey(T1))
         {
            PropertyInfoCache.Add(T1, T1.GetProperties());
         }
         model1Ps = PropertyInfoCache[T1];
         model2Ps = PropertyInfoCache[T2];

         if (from)
         {
            for (int i = 0, len = model1Ps.Length; i < len; i++)
            {
               PropertyInfo p1 = model1Ps[i];
               for (int j = 0, len2 = model2Ps.Length; j < len2; j++)
               {
                  PropertyInfo p2 = model2Ps[j];
                  Type t1 = p1.PropertyType, t2 = p2.PropertyType;
                  bool t1IsNullable = TypeHelper.IsNullable(t1),
                     t2IsNullable = TypeHelper.IsNullable(t2);
                  if (t1IsNullable) { t1 = t1.GetGenericArguments()[0]; }
                  if (t2IsNullable) { t2 = t2.GetGenericArguments()[0]; }

                  if (string.Equals(p2.Name, p1.Name) && t1 == t2)
                  {
                     if (p1.CanWrite)
                     {
                        object value = p2.GetValue(model2, null);
                        if (value == null && t1.IsValueType && !t1IsNullable)
                        {
                           throw new InvalidCastException();
                        }
                        p1.SetValue(model1, value, null);
                     }
                  }
               }
            }

            return model1;
         }
         else
         {
            for (int i = 0, len = model2Ps.Length; i < len; i++)
            {
               PropertyInfo p2 = model2Ps[i];
               Type t2 = p2.PropertyType;
               bool t2IsNullable = TypeHelper.IsNullable(t2);
               if (t2IsNullable) { t2 = t2.GetGenericArguments()[0]; }
               for (int j = 0, len2 = model1Ps.Length; j < len2; j++)
               {
                  PropertyInfo p1 = model1Ps[j];
                  Type t1 = p1.PropertyType;
                  bool t1IsNullable = TypeHelper.IsNullable(t1);
                  if (t1IsNullable) { t1 = t1.GetGenericArguments()[0]; }

                  if (string.Equals(p2.Name, p1.Name) && t1 == t2)
                  {
                     if (p2.CanWrite)
                     {
                        object value = p1.GetValue(model1, null);
                        if (value == null && t2.IsValueType && !t2IsNullable)
                        {
                           throw new InvalidCastException();
                        }
                        p2.SetValue(model2, value, null);
                     }
                  }
               }
            }
            return model2;
         }
      }
   }
}
