using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Linq.TypeHelpers;

namespace Linq.MetaDataProviders
{
   public class MvcModelMetaData
   {
      /// <summary>
      /// 模型类型
      /// </summary>
      public Type ModelType { get; set; }

      public bool IsComplexType
      {
         get
         {
            return TypeHelper.IsComplexType(this.ModelType);
         }
      }
   }
}
