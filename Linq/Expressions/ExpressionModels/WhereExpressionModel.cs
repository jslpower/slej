using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Linq.Expressions.ExpressionModels
{
   internal enum ljlj
   {
      and,
      or
   }
   internal class WhereExpressionModel
   {
      internal Expression exss;

      internal ISelectExpressionBuilder eb;

      internal ljlj lj { get; set; }
      internal string ws { get; set; }
   }
}
