using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Linq.Expressions.Interface
{
   public interface IExpressionBuilder<T>: ISelectExpressionBuilder where T : new()
   {
   }
}
