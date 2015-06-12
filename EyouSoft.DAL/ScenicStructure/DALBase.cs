using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.DAL;

namespace EyouSoft.DAL
{
   /// <summary>
   /// 数据访问基类，此类的大部分方法的参数基于lambda表达式
   /// </summary>
   /// <typeparam name="T"></typeparam>
   public class DALBase<T> : RepositoryBase<T> where T : new()
   {
      /// <summary>
      /// SystemStore 可以是连接串或ConnectionString 节点的 key名称
      /// </summary>
      public DALBase() : base("SystemStore") { }
   }

   /// <summary>
   /// 数据访问基类，此类的大部分方法的参数基于lambda表达式
   /// </summary>
   /// <typeparam name="T"></typeparam>
   public class DALHotelBI<T> : RepositoryBase<T> where T : new()
   {
       /// <summary>
       /// SystemStore 可以是连接串或ConnectionString 节点的 key名称
       /// </summary>
       public DALHotelBI() : base("HotelStore") { }
   }
}
