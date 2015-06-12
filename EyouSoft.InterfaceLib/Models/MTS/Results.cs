using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.InterfaceLib.Models.MTS
{
   public enum Results
   {
      成功 = 0,
      系统内部错误 = 101000,
      访问IP被绝 = 101001,
      用户校验失败 = 101002,
      占位失败 = 201000,
      尝试修改他人数据 = 201001,
      订单已经被确认_不允许删除 = 201002,
      条件表达式不正确 = 201003,
      排序表达式不正确 = 201004,
      指定的团队不存在 = 201005,
      指定的团队不允许订购 = 201006,
      指定的订单不存在 = 201007,
      指定的游客不存在 = 201008,
   }
}
