using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.Expressions
{
   internal enum YieldMoel
   {
      None,
      /// <summary>
      /// rownumber
      /// </summary>
      RowNumber,
      Count,
      CountForPaging,
      Max,
      Min,
      Distinct,
      Sum,
      Exists,
      Top,
   }
}
