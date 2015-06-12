using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum.Privs;

namespace Common.page
{
   public class PowerAttribute : Attribute
   {
      public Menu2 CurrentMenu { get; set; }
      public Menu1 ParentMenu { get; set; }
      public PowerAttribute(Menu1 parent)
      {
         this.ParentMenu = parent;
         this.CurrentMenu = Menu2.None;
      }
      public PowerAttribute(Menu1 parent, Menu2 current)
      {
         this.CurrentMenu = current;
         this.ParentMenu = parent;
      }
   }
}
