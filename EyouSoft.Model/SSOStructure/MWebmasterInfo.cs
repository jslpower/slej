using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;

namespace EyouSoft.Model.SSOStructure
{
   /// <summary>
   /// webmaster登录信息业务实体
   /// </summary>
   public class MWebmasterInfo
   {
      /// <summary>
      /// 用户编号
      /// </summary>
      public int UserId { get; set; }

      /// <summary>
      /// 用户名
      /// </summary>
      public string Username { get; set; }

      /// <summary>
      /// 姓名
      /// </summary>
      public string ContactName { get; set; }
      /// <summary>
      /// 电话
      /// </summary>
      public string Telephone { get; set; }
      /// <summary>
      /// 传真
      /// </summary>
      public string Fax { get; set; }
      /// <summary>
      /// 手机
      /// </summary>
      public string Mobile { get; set; }
      /// <summary>
      /// 是否启用
      /// </summary>
      public Is IsEnable { get; set; }
      /// <summary>
      /// 是否管理员
      /// </summary>
      public Is IsAdmin { get; set; }
      /// <summary>
      /// 创建时间
      /// </summary>
      public DateTime CreateTime { get; set; }

      /// <summary>
      /// 角色权限，多个权限间用半角逗号间隔
      /// </summary>
      public string Permissions { get; set; }
      /// <summary>
      /// 用户类型 0:webmaster  1 供应商  2代理商  
      /// </summary>
      public WebmasterUserType LeiXing { get; set; }
      /// <summary>
      /// 供应商编号/代理商编号
      /// </summary>
      public string GysId { get; set; }
   }
}
