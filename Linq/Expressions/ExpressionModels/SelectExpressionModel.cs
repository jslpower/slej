using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Linq.Expressions
{
   internal class SelectExpressionModel
   {
      internal Expression sion;
      internal string als;
      internal SelectExpressionModel()
      {
      }
      internal SelectExpressionModel(Expression ep)
      {
         sion = ep;
      }
      internal SelectExpressionModel(Expression ep, string ass)
      {
         sion = ep;
         als = ass;
      }
   }
}
