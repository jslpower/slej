using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.InterfaceLib.Request.ZL
{
   public class get_obd_group_listRequest
   {
      /// <summary>
      /// 访问用户的认证序列号,每一个与中旅系统对接的用户都必须申请唯一的序列号
      /// </summary>
      public string user_key;
      /// <summary>
      /// 用户密码
      /// </summary>
      public string password;
      /// <summary>
      /// 过滤条件表达式,不允许出现除(and  or  not  in)外的 SQL关键字、标点符号开头不用 and
      /// </summary>
      public string condition_exp;
      /// <summary>
      /// 排序表达式不允许出现除（，desc asc）外的标点符号
      /// </summary>
      public string sort_exp;
      /// <summary>
      /// 返回结果集合的页码
      /// </summary>
      public int page_index;
      /// <summary>
      /// 每页的也宽(每页的行数)
      /// </summary>
      public int page_size;
   }
}
