using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Toolkit.BLL
{
   public class BLLBase
   {
      public void RecordError(Exception ex)
      {

         RecordError(GetExceptionString(ex));

      }

      private string GetExceptionString(Exception ex)
      {
         return ex == null ? "" : (ex.ToString() + (ex.InnerException == null ? "" : "\r\n     内部错误：" + GetExceptionString(ex.InnerException)));
      }

      public void RecordError(string s)
      {
         log4net.LogManager.GetLogger("WebErrors").Error(s);
      }
   }
}
