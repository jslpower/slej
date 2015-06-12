using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Linq.Web
{
   public interface IValidator
   {
      bool IsValidatePower { get; }
      bool ValidatePower();
   }
}
