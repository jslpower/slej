using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.InterfaceLib.Request.ZL
{
   public class get_obd_group_detailRequest
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
      /// 团队id
      /// </summary>
      public int sid;
   }
}
