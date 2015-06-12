using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Enums.GDWX;
using EyouSoft.InterfaceLib.Models.GDWX;

namespace EyouSoft.InterfaceLib.Request.GDWX
{
   public class LiangShenDingZhiRequest : RequestBase
   {
      /// <summary>
      /// 类型
      /// </summary>
      public DengluLeiXing type;
      /// <summary>
      /// 用户名
      /// </summary>
      public string username;
      /// <summary>
      /// 密码 
      /// </summary>
      public string password;
      /// <summary>
      /// 姓名 
      /// </summary>
      public string realname;
      /// <summary>
      /// 手机 
      /// </summary>
      public string phone;
      /// <summary>
      /// 成人 
      /// </summary>
      public int num1;
      /// <summary>
      /// 儿童 
      /// </summary>
      public int num2;
      /// <summary>
      /// 儿童不占床 
      /// </summary>
      public int num3;
      /// <summary>
      /// 预计的出行日期 
      /// </summary>
      public DateTime dates;
      /// <summary>
      /// 想去的目的地 
      /// </summary>
      public string addr;
      /// <summary>
      /// 其它要求
      /// </summary>
      public string content;
   }
}
