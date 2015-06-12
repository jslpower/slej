using System.Linq.Expressions;

namespace Linq.Bussiness
{
   public class SearchModel
   {
      public PageInfo PageInfo { get; set; }
      /// <summary>
      /// 编辑模式
      /// </summary>
      public EditMode? EditMode { get; set; }
      /// <summary>
      /// 显示模式
      /// </summary>
      public ShowMode? ShowMode { get; set; }
   }
}
