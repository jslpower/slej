using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.Expressions.ExpressionModels
{
   internal class TopExpressionModel : SelectExpressionModel, IJH
   {
      internal int rct { get; set; }
   }
}
