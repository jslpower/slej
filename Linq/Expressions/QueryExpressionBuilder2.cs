using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Linq.Bussiness;
using Linq.Expressions.Enums;
using Linq.Expressions.ExpressionModels;
using Linq.Expressions.ExpressionModels.Join;

namespace Linq.Expressions
{
   public class QueryExpressionBuilder<T, T2> : QueryExpressionBuilder<T>
      where T : new()
      where T2 : new()
   {
      public QueryExpressionBuilder<T> rP { get; set; }

      internal override int YI
      {
         get
         {
            return rP.YI;
         }
         set
         {
            rP.YI = value;
         }
      }

      public override SearchModel SearchInfo
      {
         get
         {
            return rP.SearchInfo;
         }
      }
      internal override List<SelectExpressionModel> S
      {
         get
         {
            return rP.S;
         }
      }
      internal override List<WhereExpressionModel> W
      {
         get
         {
            return rP.W;
         }

      }
      internal override List<OrderByExpressionModel> O
      {
         get
         {
            return rP.O;
         }
      }
      internal override List<JoinExpressionModel> J
      {
         get
         {
            return rP.J;
         }
         set
         {
            rP.J = value;
         }
      }
      internal override TableNameInfo TI
      {
         get
         {
            return GTIO(typeof(T2));
         }
      }

      public QueryExpressionBuilder(QueryExpressionBuilder<T> rootParent)
      {
         this.rP = rootParent;
      }
      public QueryExpressionBuilder<T, T2> Select<TResult>(Expression<Func<T, T2, TResult>> predicate)
      {
         ADS(new SelectExpressionModel(predicate));
         return this;
      }
      public QueryExpressionBuilder<T> SelectAs<TResult>(Expression<Func<T, T2, TResult>> predicate, string alias)
      {
         ADS(new SelectExpressionModel(predicate, alias));
         return this;
      }
      public new QueryExpressionBuilder<T, T2> SelectAll()
      {
         rP.SelectAll();
         List<SelectExpressionModel> list = gs(typeof(T2));
         ADS2(list);
         return this;
      }
      public QueryExpressionBuilder<T, T2> On(Expression<Func<T, T2, bool>> predicate)
      {
         ADJ(new JoinExpressionModel { essin = predicate, jt = this.JP });
         return this;
      }
      /// <summary>
      /// 内连接
      /// </summary>
      /// <typeparam name="Table2"></typeparam>
      /// <returns></returns>
      public QueryExpressionBuilder<T2, Table2> InnerJoin2<Table2>() where Table2 : new()
      {
         var qeb = new QueryExpressionBuilder<T2>();
         qeb.S = S;
         qeb.W = W;
         qeb.O = O;
         qeb.J = J;
         var builder2 = new QueryExpressionBuilder<T2, Table2>(qeb);
         builder2.JP = JTypes.InnerJoin;
         return builder2;
      }
      /// <summary>
      /// 左连接
      /// </summary>
      /// <typeparam name="Table2"></typeparam>
      /// <returns></returns>
      public QueryExpressionBuilder<T2, Table2> LeftOuterJoin2<Table2>() where Table2 : new()
      {
         var qeb = new QueryExpressionBuilder<T2>();
         qeb.S = S;
         qeb.W = W;
         qeb.O = O;
         qeb.J = J;
         var builder2 = new QueryExpressionBuilder<T2, Table2>(qeb);
         builder2.JP = JTypes.LeftOuterJoin;
         return builder2;
      }
      /// <summary>
      /// 右连接
      /// </summary>
      /// <typeparam name="Table2"></typeparam>
      /// <returns></returns>
      public QueryExpressionBuilder<T2, Table2> RightOuterJoin2<Table2>() where Table2 : new()
      {
         var qeb = new QueryExpressionBuilder<T2>();
         qeb.S = S;
         qeb.W = W;
         qeb.O = O;
         qeb.J = J;
         var builder2 = new QueryExpressionBuilder<T2, Table2>(qeb);
         builder2.JP = JTypes.RightOuterJoin;
         return builder2;
      }

      public QueryExpressionBuilder<T, T2> Where(Expression<Func<T, T2, bool>> predicate)
      {
         ADW(new WhereExpressionModel { exss = predicate, lj = ljlj.and });
         return this;
      }

      public QueryExpressionBuilder<T, T2> OrWhere(Expression<Func<T, T2, bool>> predicate)
      {
         ADW(new WhereExpressionModel { exss = predicate, lj = ljlj.or });
         return this;
      }
      public QueryExpressionBuilder<T, T2> OrderBy<TResult>(Expression<Func<T, T2, TResult>> predicate)
      {
         ADOB(new OrderByExpressionModel { pres = predicate, o = true });
         return this;
      }
      public QueryExpressionBuilder<T, T2> OrderByDescending<TResult>(Expression<Func<T, T2, TResult>> predicate)
      {
         ADOB(new OrderByExpressionModel { pres = predicate, o = false });
         return this;
      }
   }
}
