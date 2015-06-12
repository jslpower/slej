using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Linq.Web
{
   public class SelectListItem
   {
      public string Text { get; set; }
      public string Value { get; set; }
      public bool IsSelected { get; set; }
      public SelectListItem()
      {
      }
      public SelectListItem(string value, string text, bool isSelected)
      {
         this.Value = value;
         this.Text = text;
         this.IsSelected = IsSelected;
      }
      public override string ToString()
      {
         return "<option value='" + Value + "'" + (IsSelected ? " selected=\"selected\"" : "") + ">" + Text + "</option>";
      }
   }
}
