using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using Linq.Expressions.ExpressionModels;
namespace Linq.Expressions
{
   public interface ISelectExpressionBuilder
   {
      string bs();
      void InitTableInfo();
      Dictionary<Type, TableNameInfo> TableInfoDictioanry { get; set; }
      List<ISelectExpressionBuilder> Relates { get; set; }
   }

}
