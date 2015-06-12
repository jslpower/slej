using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Reflection;
using System.Data;
using System.ComponentModel;
using Linq.ORM;
using Linq.Bussiness;
using Linq.Expressions;
using System.Linq.Expressions;
using Linq.Respository;
using System.Data.SqlClient;
using System.Configuration;
using Linq.SQL;
namespace Linq.DAL
{
   /// <summary>
   /// 数据库访问基类。基于lambda语法。如果不会写lambda, 建议只使用原生方法。
   /// </summary>
   /// <typeparam name="TModel"></typeparam>
   public class RepositoryBase<TModel> : SQLManager, IRepository<TModel> where TModel : new()
   {
      public RepositoryBase(string name)
         : base(name)
      {
      }

      public RepositoryBase(string name, int comandTimeout)
         : base(name)
      {
         this.CommandTimeOut = comandTimeout;
      }

      #region 增删改查
      public int Insert(TModel model)
      {
         QueryExpressionBuilder<TModel> b = new QueryExpressionBuilder<TModel>();
         string str = b.bisql(model);
         return Convert.ToInt32(ExecuteSqlNoQuery(str));
      }
      public int InsertWithIdentity(TModel model)
      {
         QueryExpressionBuilder<TModel> b = new QueryExpressionBuilder<TModel>();
         string str = b.bisql(model);
         str += ";select SCOPE_IDENTITY();";
         return Convert.ToInt32(ExecuteSqlScalar(str));
      }

      public int Update(TModel model, Expression<Func<TModel, object>> updatePredicate)
      {
         return Update(model, updatePredicate, null, null);
      }
      public int Update(TModel model, Expression<Func<TModel, object>> updatePredicate, Expression<Func<TModel, bool>> wherePredicate)
      {
         return Update(model, updatePredicate, null, wherePredicate);
      }
      public int Update(TModel model, Expression<Func<TModel, object>> updatePredicate, Expression<Func<TModel, object>> exceptUpdatePredicate, Expression<Func<TModel, bool>> wherePredicate)
      {
         QueryExpressionBuilder<TModel> b = new QueryExpressionBuilder<TModel>();
         string str = b.busql(model, updatePredicate, exceptUpdatePredicate, wherePredicate);
         return ExecuteSqlNoQuery(str);
      }
      public int Update(TModel model)
      {
         return Update(model, null, null, null);
      }

      /// <summary>
      /// 更新
      /// </summary>
      /// <param name="model">模型</param>
      /// <param name="exceptUpdatePredicate">排除更新的列</param>
      /// <returns></returns>
      public int Update_ButExcept(TModel model, Expression<Func<TModel, object>> exceptUpdatePredicate)
      {
         return Update(model, null, exceptUpdatePredicate, null);
      }
      /// <summary>
      /// 更新
      /// </summary>
      /// <param name="model">模型</param>
      /// <param name="exceptUpdatePredicate">排除更新的列</param>
      /// <param name="wherePredicate">where条件</param>
      /// <returns></returns>
      public int Update_ButExcept(TModel model, Expression<Func<TModel, object>> exceptUpdatePredicate, Expression<Func<TModel, bool>> wherePredicate)
      {
         return Update(model, null, exceptUpdatePredicate, wherePredicate);
      }
      /// <summary>
      /// 更新
      /// </summary>
      /// <param name="model">模型</param>
      /// <param name="updateExceptPredicate">排除更新的列</param>
      /// <param name="updatePredicate">更新的列</param>
      /// <param name="wherePredicate">where条件</param>
      /// <returns></returns>
      public int Update_ButExcept(TModel model, Expression<Func<TModel, object>> updateExceptPredicate, Expression<Func<TModel, object>> updatePredicate, Expression<Func<TModel, bool>> wherePredicate)
      {
         return Update(model, updatePredicate, updateExceptPredicate, wherePredicate);
      }
      pkv vpv(object k)
      {
         if (k == null)
         {
            throw new NullReferenceException("参数id不能为空");
         }
         pkv kv = null;

         if (k is TModel)
         {
            kv = tas.gpmv(k);
         }
         else
         {
            kv = tas.spk(typeof(TModel));
            if (kv != null)
            {
               kv.aue = k;
            }
         }
         if (kv == null)
         {
            throw new NullReferenceException("类型" + typeof(TModel).FullName + "没有找到主键，请改用该方法的其他重载试试");
         }
         return kv;
      }
      public int Delete(object id)
      {
         pkv k = vpv(id);
         ParameterExpression m = Expression.Parameter(typeof(TModel), "t");
         Expression<Func<TModel, bool>> da = Expression.Lambda<Func<TModel, bool>>(BinaryExpression.Equal(Expression.MakeMemberAccess(m, k.mifp), Expression.Constant(k.aue, k.aue.GetType())), m);
         return Delete(da);
      }
      public int Delete(Expression<Func<TModel, bool>> wherePredicate)
      {
         if (wherePredicate == null)
         {
            throw new NullReferenceException();
         }
         QueryExpressionBuilder<TModel> b = new QueryExpressionBuilder<TModel>();
         string str = b.bdsql(wherePredicate);
         return Convert.ToInt32(ExecuteSqlNoQuery(str));
      }

      public IList<TModel> Distinct<TResult>(Expression<Func<TModel, TResult>> selectPredicate, Expression<Func<TModel, bool>> wherePredicate)
      {
         QueryExpressionBuilder<TModel> builder = new QueryExpressionBuilder<TModel>();
         builder.Distinct(selectPredicate);
         builder.Where(wherePredicate);
         return Select(builder);
      }
      public long Count()
      {
         var builder = new QueryExpressionBuilder<TModel>();
         return Convert.ToInt64(ExecuteSqlScalar(builder.bcsql()));
      }
      public long Count(Expression<Func<TModel, bool>> wherePredicate)
      {
         QueryExpressionBuilder<TModel> queryRoot = new QueryExpressionBuilder<TModel>();
         if (wherePredicate != null)
         {
            queryRoot.Where(wherePredicate);
         }
         return Convert.ToInt64(ExecuteSqlScalar(queryRoot.bcsql()));
      }
      public TResult Min<TResult>(Expression<Func<TModel, TResult>> predicate, Expression<Func<TModel, bool>> wherePredicate) where TResult : new()
      {
         QueryExpressionBuilder<TModel> builder = new QueryExpressionBuilder<TModel>();
         builder.Min(predicate);
         builder.Where(wherePredicate);
         return (TResult)ExecuteSqlScalar(builder.bs());
      }
      public TResult Max<TResult>(Expression<Func<TModel, TResult>> predicate, Expression<Func<TModel, bool>> wherePredicate) where TResult : new()
      {
         QueryExpressionBuilder<TModel> builder = new QueryExpressionBuilder<TModel>();
         builder.Where(wherePredicate);
         builder.Max(predicate);
         return (TResult)ExecuteSqlScalar(builder.bs());
      }
      public TResult Sum<TResult>(Expression<Func<TModel, TResult>> predicate, Expression<Func<TModel, bool>> wherePredicate) where TResult : new()
      {
         QueryExpressionBuilder<TModel> builder = new QueryExpressionBuilder<TModel>();
         builder.Where(wherePredicate);
         builder.Sum(predicate);
         return (TResult)ExecuteSqlScalar(builder.bs());
      }
      public bool Exists(Expression<Func<TModel, bool>> wherePredicate)
      {
         QueryExpressionBuilder<TModel> builder = new QueryExpressionBuilder<TModel>();
         builder.Where(wherePredicate);
         return (int)ExecuteSqlScalar(builder.bcsql()) > 0;
      }
      #endregion

      Expression<Func<TModel, bool>> gpv(pkv pkInfo)
      {
         ParameterExpression m = Expression.Parameter(typeof(TModel), "t");
         Expression<Func<TModel, bool>> am = Expression.Lambda<Func<TModel, bool>>(BinaryExpression.Equal(Expression.MakeMemberAccess(m, pkInfo.mifp), Expression.Constant(pkInfo.aue, pkInfo.aue.GetType())), m);
         return am;
      }

      #region 原始模型
      public TModel Get(object id)
      {
         pkv kv = vpv(id);
         var pkPredicate = gpv(kv);
         return this.Get(pkPredicate);
      }
      public TModel Get(Expression<Func<TModel, bool>> wherePredicate)
      {
         return this.Get(null, wherePredicate);
      }
      public TModel Get(Expression<Func<TModel, object>> selectPredicate, Expression<Func<TModel, bool>> wherePredicate)
      {
         QueryExpressionBuilder<TModel> builder = new QueryExpressionBuilder<TModel>();
         if (selectPredicate == null)
         {
            builder.SelectAll();
         }
         else
         {
            builder.Select(selectPredicate);
         }
         builder.Where(wherePredicate);
         IList<TModel> list = Select<TModel>(builder);
         if (list == null || list.Count == 0)
         {
            return default(TModel);
         }
         return list[0];
      }
      public TModel Get(QueryExpressionBuilder<TModel> expressionBuilder)
      {
         return Get<TModel>(expressionBuilder);
      }
      public TSearchModel Get<TSearchModel>(object id) where TSearchModel : new()
      {
         pkv kv = vpv(id);
         var pkPredicate = gpv(kv);
         return Get<TSearchModel>(pkPredicate);
      }
      public TSearchModel Get<TSearchModel>(Expression<Func<TModel, bool>> wherePredicate) where TSearchModel : new()
      {
         QueryExpressionBuilder<TModel> builder = new QueryExpressionBuilder<TModel>();
         builder.Where(wherePredicate);
         return Get<TSearchModel>(builder);
      }
      public TSearchModel Get<TSearchModel>(Expression<Func<TModel, object>> selectPredicate, Expression<Func<TModel, bool>> wherePredicate) where TSearchModel : new()
      {
         QueryExpressionBuilder<TModel> builder = new QueryExpressionBuilder<TModel>();
         if (selectPredicate == null)
         {
            builder.SelectAll();
         }
         else
         {
            builder.Select(selectPredicate);
         }
         builder.Where(wherePredicate);
         IList<TSearchModel> list = Select<TSearchModel>(builder);
         if (list == null || list.Count == 0)
         {
            return default(TSearchModel);
         }
         return list[0];
      }
      public TSearchModel Get<TSearchModel>(QueryExpressionBuilder<TModel> expressionBuilder) where TSearchModel : new()
      {
         IList<TSearchModel> list = Select<TSearchModel>(expressionBuilder);
         if (list == null || list.Count == 0)
         {
            return default(TSearchModel);
         }
         return list[0];
      }
      #endregion

      #region 复杂模型
      public IList<TSearchModel> Select<TSearchModel>(string sql) where TSearchModel : new()
      {
         List<TSearchModel> list = new List<TSearchModel>();
         IList<Column> columns = tas.SelectColumnSelector(typeof(TSearchModel));
         using (var reader = ExecuteReader(sql))
         {
            while (reader.Read())
            {
               TSearchModel model2 = new TSearchModel();
               for (int i = 0, len = columns.Count; i < len; i++)
               {
                  Column column = columns[i];
                  column.svv(model2, reader);
               }
               list.Add(model2);
            }
         }
         return list;
      }
      public IList<TModel> Select(QueryExpressionBuilder<TModel> expressionBuilder)
      {
         return Select<TModel>(expressionBuilder.ToString());
      }
      public IList<TSearchModel> Select<TSearchModel>(QueryExpressionBuilder<TModel> expressionBuilder) where TSearchModel : new()
      {
         string sql = expressionBuilder.bs();
         return Select<TSearchModel>(sql);
      }

      public IList<TSearchModel> SelectPagedList<TSearchModel>(QueryExpressionBuilder<TModel> expressionBuilder) where TSearchModel : new()
      {
         if (expressionBuilder == null || expressionBuilder.SearchInfo == null || expressionBuilder.SearchInfo.PageInfo == null)
         {
            throw new Exception("expressionBuilder.SearchInfo.PageInfo不能为空");
         }
         string sql = expressionBuilder.bpsql();
         return SelectPagedList<TSearchModel>(sql, expressionBuilder.SearchInfo.PageInfo);
      }
      public IList<TSearchModel> SelectPagedList<TSearchModel>(string sql, PageInfo pageInfo) where TSearchModel : new()
      {
         List<TSearchModel> list = new List<TSearchModel>(10);
         if (pageInfo == null)
         {
            throw new Exception("参数2：pageInfo不能为空");
         }
         else if (pageInfo.PageIndex <= 0)
         {
            throw new Exception("参数2：pageInfo.PageIndex 值不正确");
         }
         try
         {
            using (IDataReader reader = ExecuteReader(sql))
            {
               if (!reader.Read())
               {
                  throw new InvalidOperationException();
               }
               pageInfo.TotalCount = Convert.ToInt32(reader[0]);
               if (!reader.NextResult())
               {
                  throw new InvalidOperationException();
               }
               IList<Column> columns = tas.SelectColumnSelector(typeof(TSearchModel));
               while (reader.Read())
               {
                  TSearchModel model2 = new TSearchModel();
                  for (int i = 0, len = columns.Count; i < len; i++)
                  {
                     columns[i].svv(model2, reader);
                  }
                  list.Add(model2);
               }
            }
            return list;
         }
         catch (System.Exception e)
         {
            throw e;
         }
      }
      public DataSet SelectDataSet(QueryExpressionBuilder<TModel> expressionBuilder)
      {
         string sql = expressionBuilder.bs();
         return SelectDataSet(sql);
      }
      #endregion


   }
}