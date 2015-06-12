using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.ORM;
using System.Reflection;

namespace Linq.Expressions
{
   public class TableNameInfo
   {
      /// <summary>
      ///表的别名
      /// </summary>
      public string tan;
      public string tan2 { get { return Column.cfmt3(tan); } }
      /// <summary>
      /// 表实际名称
      /// </summary>
      public string tn;
      public string tn2 { get { return Column.cfmt3(tn); } }

      public Type ttt { get; set; }
   }
   /// <summary>
   /// 表示单个列的查询信息
   /// </summary>
   public class TableQueryColumnInfo : TableNameInfo
   {
      /// <summary>
      /// 列名
      /// </summary>
      public string cn;
      public string cn2 { get { return Column.cfmt3(cn); } }
      /// <summary>
      /// 列的别名
      /// </summary>
      public string can;
      public string can2 { get { return Column.cfmt3(can); } }
      /// <summary>
      /// 是否是子查询
      /// </summary>
      public bool iscq;

      public MemberInfo mifin2;
   }
}
