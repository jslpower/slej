using System;
using System.Linq;
using Linq.ModelHandler;
using System.Collections.Generic;
using System.Reflection;
using Linq.ModelState;
using Linq.MetaDataProviders;

namespace Linq.Mvc3
{
   /// <summary>
   /// 模型绑定上下文
   /// </summary>
   public class ModelBindingContext
   {
      public bool FallbackToEmptyPrefix { get; set; }

      public Type ModelType { get; set; }
      public MvcModelMetaData MetaData { get; set; }
      /// <summary>
      /// 模型名称
      /// </summary>
      public string ModelName { get; set; }
      /// <summary>
      /// 值提供器
      /// </summary>
      public IMvcValueProvider ValueProvider { get; set; }
      /// <summary>
      /// 模型值
      /// </summary>
      public object Model { get; set; }
      public MvcModelStateDicitonary ModelState { get; set; }
      public ModelBindingContext()
      {
         ValueProvider = new NameValueCollectionValueProvider();
      }

      public Predicate<string> PropertyFilter { get; set; }
   }
}