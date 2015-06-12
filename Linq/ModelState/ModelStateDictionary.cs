using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.MetaDataProviders;

namespace Linq.ModelState
{
   public class MvcModelStateDicitonary : Dictionary<string, string>
   {
      MvcModelMetaData MetaData { get; set; }
   }
}
