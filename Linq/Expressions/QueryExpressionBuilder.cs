using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Linq.Expressions.Enums;
using Linq.ORM;
using Linq.Expressions.ExpressionModels;
using Linq.Expressions.Interface;
using Linq.Expressions.ExpressionModels.Join;

namespace Linq.Expressions
{
   public class QueryExpressionBuilder<T> : ExpressionBuilder<T> where T : new()
   {
      internal JTypes JP { get; set; }
      public T EntityModel { get; set; }

      public QueryExpressionBuilder()
      {
         EntityModel = (T)Activator.CreateInstance(typeof(T));
      }

      /// <summary>
      /// 相当于sql的 and where
      /// </summary>
      /// <param name="sql"></param>
      /// <returns></returns>
      public QueryExpressionBuilder<T> Where(string sql)
      {
         ADW(new WhereExpressionModel { ws = sql, lj = ljlj.and });
         return this;
      }
      /// <summary>
      /// 相当于sql的 or where
      /// </summary>
      /// <param name="sql"></param>
      /// <returns></returns>
      public QueryExpressionBuilder<T> OrWhere(string sql)
      {
         ADW(new WhereExpressionModel { ws = sql, lj = ljlj.or });
         return this;
      }
      /// <summary>
      /// 相当于sql的 and where
      /// </summary>
      /// <param name="sql"></param>
      /// <returns></returns>
      public QueryExpressionBuilder<T> Where(Expression<Func<T, bool>> predicate)
      {
         ADW(new WhereExpressionModel { exss = predicate, lj = ljlj.and });
         return this;
      }
      /// <summary>
      /// 相当于sql的 or where
      /// </summary>
      /// <param name="sql"></param>
      /// <returns></returns>
      public QueryExpressionBuilder<T> OrWhere(Expression<Func<T, bool>> predicate)
      {
         ADW(new WhereExpressionModel { exss = predicate, lj = ljlj.or });
         return this;
      }
      /// <summary>
      /// 相当于sql的 select xxxxxx
      /// </summary>
      /// <param name="sql"></param>
      /// <returns></returns>
      public QueryExpressionBuilder<T> Select<TResult>(Expression<Func<T, TResult>> predicate)
      {
         ADS(new SelectExpressionModel(predicate));
         return this;
      }
      /// <summary>
      /// 相当于sql的 select 所有列，不是select *
      /// </summary>
      /// <returns></returns>
      public QueryExpressionBuilder<T> SelectAll()
      {
         return sintern();
      }
      internal static Dictionary<Type, List<SelectExpressionModel>> sc = new Dictionary<Type, List<SelectExpressionModel>>();

      internal List<SelectExpressionModel> gs(Type ty)
      {
         List<SelectExpressionModel> l2 = new List<SelectExpressionModel>();
         if (!sc.ContainsKey(ty))
         {
            lock (sc)
            {
               if (!sc.ContainsKey(ty))
               {
                  Type rt = tas.gtty(ty);
                  IList<Column> ccs = tas.cssr(rt, false, null);
                  List<SelectExpressionModel> listtemp = new List<SelectExpressionModel>();
                  for (int i = 0, len = ccs.Count; i < len; i++)
                  {
                     ParameterExpression examer = Expression.Parameter(ty, "xi");
                     LambdaExpression le = Expression.Lambda(Expression.MakeMemberAccess(examer, ccs[i].mif), examer);
                     SelectExpressionModel model = new SelectExpressionModel(le);
                     listtemp.Add(model);
                  }
                  sc.Add(ty, listtemp);
               }
            }
         }
         return sc[ty];
      }

      private QueryExpressionBuilder<T> sintern()
      {
         List<SelectExpressionModel> list = gs(typeof(T));
         ADS2(list);
         return this;
      }

      /// <summary>
      /// 给列取别名
      /// </summary>
      /// <typeparam name="TResult"></typeparam>
      /// <param name="predicate"></param>
      /// <param name="alias"></param>
      /// <returns></returns>
      public QueryExpressionBuilder<T> SelectAs<TResult>(Expression<Func<T, TResult>> predicate, string alias)
      {
         ADS(new SelectExpressionModel(predicate, alias));
         return this;
      }
      /// <summary>
      /// 内连接
      /// </summary>
      /// <typeparam name="Table2"></typeparam>
      /// <returns></returns>
      public QueryExpressionBuilder<T, Table2> InnerJoin<Table2>() where Table2 : new()
      {
         var builder = new QueryExpressionBuilder<T, Table2>(this);
         builder.JP = JTypes.InnerJoin;
         return builder;
      }
      /// <summary>
      /// 左外连接
      /// </summary>
      /// <typeparam name="Table2"></typeparam>
      /// <returns></returns>
      public QueryExpressionBuilder<T, Table2> LeftOuterJoin<Table2>() where Table2 : new()
      {
         var builder = new QueryExpressionBuilder<T, Table2>(this);
         builder.JP = JTypes.LeftOuterJoin;
         return builder;
      }
      /// <summary>
      /// 右外连接
      /// </summary>
      /// <typeparam name="Table2"></typeparam>
      /// <returns></returns>
      public QueryExpressionBuilder<T, Table2> RightOuterJoin<Table2>() where Table2 : new()
      {
         var b = new QueryExpressionBuilder<T, Table2>(this);
         b.JP = JTypes.RightOuterJoin;
         return b;
      }
      /// <summary>
      /// 相当于sql的 cross join
      /// </summary>
      /// <typeparam name="Table2"></typeparam>
      /// <returns></returns>
      public QueryExpressionBuilder<T> CrossJoin<Table2>() where Table2 : new()
      {
         var b = new QueryExpressionBuilder<T, Table2>(this);
         b.JP = JTypes.CrossJoin;
         ParameterExpression p1 = Expression.Parameter(typeof(Table2), "x");
         ADJ(new JoinExpressionModel { essin = Expression.Lambda(p1, p1), jt = JTypes.CrossJoin });
         return b;
      }
      /// <summary>
      /// 相当于sql的 top关键字
      /// </summary>
      /// <param name="i"></param>
      /// <returns></returns>
      public QueryExpressionBuilder<T> Top(int i)
      {
         ADS(new TopExpressionModel { rct = i });
         return this;
      }
      /// <summary>
      /// 嵌套子查询
      /// </summary>
      /// <param name="query"></param>
      /// <param name="alias"></param>
      /// <returns></returns>
      public QueryExpressionBuilder<T> Select(ISelectExpressionBuilder query, string alias)
      {
         query.Relates.Add(this);
         ADS(new SelectChildQueryModel { als = alias, cq = query });
         return this;
      }
      /// <summary>
      /// 排序（正序）
      /// </summary>
      /// <typeparam name="TResult"></typeparam>
      /// <param name="predicate"></param>
      /// <returns></returns>
      public QueryExpressionBuilder<T> OrderBy<TResult>(Expression<Func<T, TResult>> predicate)
      {
         O.Add(new OrderByExpressionModel { pres = predicate, o = true });
         return this;
      }
      /// <summary>
      /// 排序（倒序）
      /// </summary>
      /// <typeparam name="TResult"></typeparam>
      /// <param name="predicate"></param>
      /// <returns></returns>
      public QueryExpressionBuilder<T> OrderByDescending<TResult>(Expression<Func<T, TResult>> predicate)
      {
         O.Add(new OrderByExpressionModel { pres = predicate, o = false });
         return this;
      }
      /// <summary>
      /// 相当于sql的 distinct 关键字
      /// </summary>
      /// <typeparam name="TResult"></typeparam>
      /// <param name="predicate"></param>
      /// <returns></returns>
      public QueryExpressionBuilder<T> Distinct<TResult>(Expression<Func<T, TResult>> predicate)
      {
         ADS(new DistinctExpressionModel { sion = predicate });
         return this;
      }
      /// <summary>
      /// 相当于sql的 count函数
      /// </summary>
      /// <returns></returns>
      public QueryExpressionBuilder<T> Count()
      {
         ADS(new CountExpressionModel());
         return this;
      }
      /// <summary>
      /// 相当于sql的 count函数
      /// </summary>
      /// <returns></returns>
      public QueryExpressionBuilder<T> Count<TResult>(Expression<Func<T, TResult>> predicate, CTType countType)
      {
         ADS(new CountExpressionModel { sion = predicate, CountType = countType });
         return this;
      }
      /// <summary>
      /// 相当于sql的 max函数
      /// </summary>
      /// <returns></returns>
      public QueryExpressionBuilder<T> Max<TResult>(Expression<Func<T, TResult>> predicate)
      {
         ADS(new MaxExpressionModel { sion = predicate });
         return this;
      }
      /// <summary>
      /// 相当于sql的 min函数
      /// </summary>
      /// <returns></returns>
      public QueryExpressionBuilder<T> Min<TResult>(Expression<Func<T, TResult>> predicate)
      {
         ADS(new MinExpressionModel { sion = predicate });
         return this;
      }
      /// <summary>
      /// 相当于sql的 sum函数
      /// </summary>
      /// <returns></returns>
      public QueryExpressionBuilder<T> Sum<TResult>(Expression<Func<T, TResult>> predicate)
      {
         ADS(new SumExpressionModel { sion = predicate });
         return this;
      }
      public override string ToString()
      {
         if (Paging)
         {
            return this.bpsql();
         }
         else
         {
            return this.bs();
         }
      }
   }
}