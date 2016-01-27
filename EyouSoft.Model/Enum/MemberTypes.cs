using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.Enum
{
   /// <summary>
   /// 
   /// </summary>
   public enum MemberTypes
   {
      未注册用户 = 0,
      普通会员,
      贵宾会员,
      /// <summary>
      /// 代销
      /// </summary>
      免费代理,
      /// <summary>
      /// 一级代理
      /// </summary>
      代理,
      员工,
   }
   public enum ShowHidden
   {
       显示 = 0,
       隐藏,
   }
   public enum NavNum
   {
       主站导航 =0,
       代理商导航 =1,
   }
   /// <summary>
   /// 是否开启总代理配置
   /// </summary>
   public enum IsZDaiLi
   {
       不开启总代理配置=0,
       开启总代理配置=1,
   }
}
