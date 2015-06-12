using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Linq.Common
{
   /// <summary>
   /// 支持同类模型间的填充（不建议再使用它）。
   /// </summary>
   public interface IConvertToMModel
   {

   }

   /// <summary>
   /// （不建议再使用它）
   /// </summary>
   public static class Converter
   {
      public static T ConvertTo<T>(this IConvertToMModel model)
         where T : new()
      {
         return ConvertTo<T>(model, default(T));
      }

      /// <summary>
      /// 更新到模型（不建议再使用它）
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="model"></param>
      /// <param name="detinationModel"></param>
      /// <returns></returns>
      public static T UpdateTo<T>(this IConvertToMModel model, T detinationModel) where T : new()
      {
         return ConvertTo<T>(model, detinationModel);
      }

      static Dictionary<Type, PropertyInfo[]> PropertyInfoCache = new Dictionary<Type, PropertyInfo[]>();

      public static T ConvertTo<T>(this IConvertToMModel sourceModel, T destinationModel) where T : new()
      {
         if (sourceModel == null)
         {
            return default(T);
         }
         if (destinationModel == null)
         {
            destinationModel = new T();
         }
         Type T1 = sourceModel.GetType();
         Type T2 = typeof(T);
         PropertyInfo[] modelP, detinationModelP;
         if (!PropertyInfoCache.ContainsKey(T2))
         {
            PropertyInfoCache.Add(T2, T2.GetProperties());
         }
         if (!PropertyInfoCache.ContainsKey(T1))
         {
            PropertyInfoCache.Add(T1, T1.GetProperties());
         }
         modelP = PropertyInfoCache[T1];
         detinationModelP = PropertyInfoCache[T2];
         for (int i = 0; i < detinationModelP.Length; i++)
         {
            PropertyInfo p = detinationModelP[i];
            var mP = modelP.Where(x => x.Name == p.Name);
            foreach (PropertyInfo _mp in mP)
            {
               if (p.CanWrite)
               {
                  p.SetValue(destinationModel, _mp.GetValue(sourceModel, null), null);
               }
            }
         }
         return destinationModel;
      }
   }
}
