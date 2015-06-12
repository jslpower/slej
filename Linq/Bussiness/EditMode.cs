using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.Bussiness
{
   /// <summary>
   /// 页面数据编辑方式
   /// </summary>
   public enum EditMode
   {
      /// <summary>
      /// 点击保存(新增的)数据
      /// </summary>
      Add = 1,
      /// <summary>
      /// 点击保存(修改后的)数据
      /// </summary>
      Update = 2,
      /// <summary>
      /// 确认删除
      /// </summary>
      Delete = 3
   }

   /// <summary>
   /// 页面数据显示方式
   /// </summary>
   public enum ShowMode
   {
      /// <summary>
      /// 进入新增页面
      /// </summary>
      Add = 1,
      /// <summary>
      /// 进入编辑页面
      /// </summary>
      Update = 2,
      /// <summary>
      /// 仅查看页面内容
      /// </summary>
      Show = 4
   }
}
