using System;
namespace Linq.Respository
{
   public interface IWithTransaction : IDisposable
   {
      /// <summary>
      /// 开始一个 readComitted 事务
      /// </summary>
      /// <returns></returns>
      IDisposable BeginTransaction();
      /// <summary>
      /// 提交事务
      /// </summary>
      void Complete();
   }
}
