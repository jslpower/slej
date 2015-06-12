using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Globalization;
using Linq;
using Linq.MetaDataProviders;
using Linq.ModelHandler;

namespace Linq.Mvc3
{
   public class DefaultModelBinder : IModelBinder
   {
      public object BindModel(ModelBindingContext H)
      {
         if (H == null || H.ModelType == null)
         {
            throw new Exception();
         }

         bool flag = false;
         if (!string.IsNullOrEmpty(H.ModelName) && !H.ValueProvider.ContainsPrefix(H.ModelName))
         {
            if (!H.FallbackToEmptyPrefix)
            {
               return null;
            }

            H = new ModelBindingContext
            {
               MetaData = H.MetaData,
               ModelType = H.ModelType,
               PropertyFilter = H.PropertyFilter,
               ValueProvider = H.ValueProvider,
            };
            flag = true;
         }
         if (flag)
         {
            if (!H.MetaData.IsComplexType)
            {
               return null;
            }
         }

         if (!H.MetaData.IsComplexType)
         {
            ValueProviderResult r = H.ValueProvider.GetValue(H.ModelName);
            return r.ConvertTo(H.ModelType);
            //根据deep判断前缀(祖父累加)，key是否有该【祖父累加前缀 + '.'+propertyName】, //propertyName只在有父元素时才有
            //有则判断key后面是否有字符，有则抛异常(primitive没有成员)，否则取value，return 值；
         }
         else if (typeof(IDictionary<,>).IsAssignableFrom(H.ModelType) || typeof(Hashtable).IsAssignableFrom(H.ModelType))
         {
            if (H.ValueProvider.ContainsPrefix(H.ModelName))
            {
               IEnumerable<string> ISS;
               bool HG = false;
               DefaultModelBinder.a(H, out HG, out ISS);
               object obj = Activator.CreateInstance(H.ModelType);
               IDictionary dic = (IDictionary)obj;

               foreach (string ide in ISS)
               {
                  string si = c(H.ModelName, ide);
                  if (!H.ValueProvider.ContainsPrefix(si))
                  {
                     if (HG)
                     {
                        break;
                     }
                  }
                  else
                  {
                     Type[] ETS = H.ModelType.GetGenericArguments();
                     Type KY = ETS[0], ValueType = ETS[1];
                     if (!KY.IsPrimitive)
                     {
                        throw new NotSupportedException("key不能为复杂类型，目前不支持 !");
                     }
                     IModelBinder KeyElementBinder1 = Binder.GetModelBinder(KY);
                     IModelBinder ValueElementBinder2 = Binder.GetModelBinder(ValueType);

                     ModelBindingContext bindingContext2 = new ModelBindingContext
                     {
                        ModelName = si + ".Key",
                        MetaData = ModelMetaDataProviders.Current.GetModelMetaDataForType(dic, KY),
                        ValueProvider = H.ValueProvider
                     };
                     ModelBindingContext bindingContext3 = new ModelBindingContext
                     {
                        ModelName = si + ".Value",
                        MetaData = ModelMetaDataProviders.Current.GetModelMetaDataForType(dic, ValueType),
                        ValueProvider = H.ValueProvider
                     };

                     object o1 = KeyElementBinder1.BindModel(bindingContext2);
                     object o2 = ValueElementBinder2.BindModel(bindingContext3);

                     dic.Add(o1, o2);
                  }
               }
               return obj;
            }
            //根据deep判断前缀(祖父累加)，key是否有该 【祖父累加前缀 + '.[索引值].Key'】,
            //key是否有该 【祖父累加前缀 + '.[索引值].Value'】,
            //有则实例化Dictionary对象，
            //Dictionary.Add(key, GetModel(new bindingContext { ModelType=Value的类型, ModelName= 【祖父累加前缀 + '.[索引值].Value' });
         }
         else if (H.ModelType.IsArray)
         {
            if (H.ValueProvider.ContainsPrefix(H.ModelName))
            {
               Type et = H.ModelType.GetElementType();
               IList bast = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(et));

               IEnumerable<string> indexes;
               bool hasNameCalledIndex = false;
               DefaultModelBinder.a(H, out hasNameCalledIndex, out indexes);
               foreach (string i in indexes)
               {
                  string sin = c(H.ModelName, i);
                  if (!H.ValueProvider.ContainsPrefix(sin))
                  {
                     if (hasNameCalledIndex)
                     {
                        break;
                     }
                  }
                  else
                  {
                     IModelBinder ElementBinder = Binder.GetModelBinder(et);
                     ModelBindingContext bindingContext2 = new ModelBindingContext
                     {
                        ModelName = sin,
                        MetaData = ModelMetaDataProviders.Current.GetModelMetaDataForType(null, et),
                        ValueProvider = H.ValueProvider,
                        ModelState = H.ModelState,
                        ModelType = et,
                     };
                     object o = ElementBinder.BindModel(bindingContext2);
                     bast.Add(o);
                  }
               }
               if (bast.Count == 0)
                  return null;
               Array hg_0 = Array.CreateInstance(et, bast.Count);
               bast.CopyTo(hg_0, 0);
               return hg_0;
            }
            return null;
         }
         else if (typeof(IList).IsAssignableFrom(H.ModelType)
           || typeof(IEnumerable).IsAssignableFrom(H.ModelType)
           || typeof(ICollection).IsAssignableFrom(H.ModelType))
         {
            //<input name="students.index" value="1,2,3,4" /> 且有 <input name="student"
            //<input name="students[0]" value="aaa" /><input name="students[1]" value="aaa" />
            if (H.ValueProvider.ContainsPrefix(H.ModelName))
            {
               Type et22 = H.ModelType.GetGenericArguments()[0];
               IList LT = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(et22));

               IEnumerable<string> indexes;
               bool hC = false;
               DefaultModelBinder.a(H, out hC, out indexes);
               foreach (string i in indexes)
               {
                  string SI = c(H.ModelName, i);
                  if (!H.ValueProvider.ContainsPrefix(SI))
                  {
                     if (hC)
                     {
                        break;
                     }
                  }
                  else
                  {
                     IModelBinder B = Binder.GetModelBinder(et22);

                     ModelBindingContext bindingContext2 = new ModelBindingContext
                     {
                        ModelName = SI,
                        MetaData = ModelMetaDataProviders.Current.GetModelMetaDataForType(null, et22),
                        ValueProvider = H.ValueProvider
                     };

                     object o = B.BindModel(bindingContext2);
                     LT.Add(o);
                  }
               }
               if (LT.Count == 0)
               {
                  return null;
               }
               return LT;
            }
            return null;
            //根据deep判断前缀(祖父累加)，key是否有该 【祖父累加前缀 + '.'?+propertyName[】，
            //有则实例化Array对象， 
            //Array.SetValue(index, GetModel(new bindingContext { ModelType=ELementType, ModelName= 【祖父累加前缀 + '.'?+propertyName+'[索引值]' });
            //无则抛异常。return 值；
         }
         else
         {

            if (H.ModelType.GetConstructor(Type.EmptyTypes) != null) //必须有无参构造函数
            {
               H.Model = Activator.CreateInstance(H.ModelType);
               PropertyInfo[] ps = H.ModelType.GetProperties();
               foreach (PropertyInfo p in ps)
               {
                  if (!p.IsDefined(typeof(IgnoreAttribute), false))
                  {
                     ModelBindingContext dfeqqq_kdl_li = new ModelBindingContext
                     {
                        ModelName = b(H.ModelName, p.Name),
                        MetaData = ModelMetaDataProviders.Current.GetModelMetaDataForProperty(null, p.PropertyType),
                        ValueProvider = H.ValueProvider,
                        ModelState = H.ModelState,
                        ModelType = p.PropertyType,
                        FallbackToEmptyPrefix = true,
                        // PropertyFilter = 
                     };
                     IModelBinder binder = this.Binder.GetModelBinder(p.PropertyType);
                     object pv = binder.BindModel(dfeqqq_kdl_li);
                     dfeqqq_kdl_li.Model = pv;
                     if (p.CanWrite)
                     {
                        p.SetValue(H.Model, pv, null);
                     }
                  }
               }
            }
            return H.Model;

         }
         throw new Exception("不支持的类型");
      }


      //internal ModelBindingContext CreateComplexElementalModelBindingContext(ModelBindingContext bindingContext, object model)
      //{
      //BindAttribute bindAttr = (BindAttribute)this.GetTypeDescriptor(controllerContext, bindingContext).GetAttributes()[typeof(BindAttribute)];
      //Predicate<string> propertyFilter = (bindAttr != null) ? ((string propertyName) => bindAttr.IsPropertyAllowed(propertyName) && bindingContext.PropertyFilter(propertyName)) : bindingContext.PropertyFilter;
      //return new ModelBindingContext
      //{
      //   MetaData = ModelMetaDataProviders.Current.GetModelMetaDataForType(model, bindingContext.ModelType),
      //   ModelName = bindingContext.ModelName,
      //   ModelState = bindingContext.ModelState,
      //   PropertyFilter = propertyFilter,
      //   ValueProvider = bindingContext.ValueProvider
      //};
      //}

      private static void a(ModelBindingContext bindingContext, out bool hci, out IEnumerable<string> ides)
      {
         ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + ".index");
         object v = result.RawValue;

         string[] arrr2 = result.ConvertTo(typeof(string[])) as string[];
         if (arrr2 != null)
         {
            ides = arrr2;
            hci = true;
            return;
         }
         hci = false;
         ides = d();
      }

      private static IEnumerable<string> d()
      {
         byte num = 0;
         while (num < byte.MaxValue)
         {
            yield return num.ToString(CultureInfo.InvariantCulture);
            num++;
         }
         yield break;
      }

      private string c(string qw, string ide)
      {
         return string.Format("{0}[{1}]", qw, ide);
      }

      private ModelBinderDictionary Binder
      {
         get
         {
            return ModelBinders.Binders;
         }
      }

      private string b(string pr, string pn)
      {
         if (string.IsNullOrEmpty(pn))
         {
            throw new Exception();
         }
         else if (string.IsNullOrEmpty(pr))
         {
            return pn;
         }
         else
         {
            return pr + '.' + pn;
         }
      }
   }
}
