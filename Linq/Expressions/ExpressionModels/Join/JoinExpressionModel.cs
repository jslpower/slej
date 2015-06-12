using System.Linq.Expressions;
using Linq.Expressions.Enums;

namespace Linq.Expressions.ExpressionModels.Join
{
   internal class JoinExpressionModel
   {
      internal Expression essin;
      internal JTypes jt;
      internal virtual bool haso { get { return jt != JTypes.CrossJoin; } }
   }
}
