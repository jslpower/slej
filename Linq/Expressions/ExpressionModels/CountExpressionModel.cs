using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Expressions.Enums;

namespace Linq.Expressions.ExpressionModels
{
   internal class CountExpressionModel : SelectExpressionModel, IJH
   {
      internal CTType CountType { get; set; }
   }
}
