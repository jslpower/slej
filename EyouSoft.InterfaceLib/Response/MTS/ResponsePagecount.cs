using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.InterfaceLib.Response.MTS
{
   public class ResponsePagecount : ResponseArray<ResponsePagecount.item>
   {
      public class item
      {
         public int PageCount;
      }
   }
}
