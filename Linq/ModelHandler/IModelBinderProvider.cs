using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Mvc3;

namespace Linq.ModelHandler
{
   public interface IModelBinderProvider
   {
      IModelBinder GetModelBinder(Type t);
   }
}
