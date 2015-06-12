using System;
using System.Linq.Expressions;
using Linq.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
namespace Linq.Respository
{
   public interface IRepository<TModel> : IWithTransaction
   where TModel : new()
   {
      IDisposable BeginTransaction();
      int CommandTimeOut { get; set; }
      void Complete();
      void Dispose();
      DbDataReader ExecuteReader(string sql);
      int ExecuteSqlNoQuery(string sql);
      object ExecuteSqlScalar(string sql);
      DataSet SelectDataSet(string sql);
      DataSet SelectProcDataSet(string procedure);
      long Count();
      long Count(Expression<Func<TModel, bool>> wherePredicate);
      int Delete(Expression<Func<TModel, bool>> wherePredicate);
      int Delete(object id);
      IList<TModel> Distinct<TResult>(Expression<Func<TModel, TResult>> selectPredicate, Expression<Func<TModel, bool>> wherePredicate);
      bool Exists(Expression<Func<TModel, bool>> wherePredicate);
      TModel Get(QueryExpressionBuilder<TModel> expressionBuilder);
      TModel Get(Expression<Func<TModel, bool>> wherePredicate);
      TModel Get(Expression<Func<TModel, object>> selectPredicate, Expression<Func<TModel, bool>> wherePredicate);
      TModel Get(object id);
      TSearchModel Get<TSearchModel>(QueryExpressionBuilder<TModel> expressionBuilder) where TSearchModel : new();
      TSearchModel Get<TSearchModel>(Expression<Func<TModel, bool>> wherePredicate) where TSearchModel : new();
      TSearchModel Get<TSearchModel>(Expression<Func<TModel, object>> selectPredicate, Expression<Func<TModel, bool>> wherePredicate) where TSearchModel : new();
      TSearchModel Get<TSearchModel>(object id) where TSearchModel : new();
      int Insert(TModel model);
      int InsertWithIdentity(TModel model);
      TResult Max<TResult>(Expression<Func<TModel, TResult>> predicate, Expression<Func<TModel, bool>> wherePredicate) where TResult : new();
      TResult Min<TResult>(Expression<Func<TModel, TResult>> predicate, Expression<Func<TModel, bool>> wherePredicate) where TResult : new();
      IList<TModel> Select(QueryExpressionBuilder<TModel> expressionBuilder);
      IList<TSearchModel> Select<TSearchModel>(QueryExpressionBuilder<TModel> expressionBuilder) where TSearchModel : new();
      IList<TSearchModel> Select<TSearchModel>(string sql) where TSearchModel : new();
      System.Data.DataSet SelectDataSet(QueryExpressionBuilder<TModel> expressionBuilder);
      IList<TSearchModel> SelectPagedList<TSearchModel>(QueryExpressionBuilder<TModel> expressionBuilder) where TSearchModel : new();
      IList<TSearchModel> SelectPagedList<TSearchModel>(string sql, global::Linq.Bussiness.PageInfo pageInfo) where TSearchModel : new();
      TResult Sum<TResult>(Expression<Func<TModel, TResult>> predicate, Expression<Func<TModel, bool>> wherePredicate) where TResult : new();
      int Update(TModel model);
      int Update(TModel model, Expression<Func<TModel, object>> updatePredicate);
      int Update(TModel model, Expression<Func<TModel, object>> updatePredicate, Expression<Func<TModel, bool>> wherePredicate);
      int Update(TModel model, Expression<Func<TModel, object>> updatePredicate, Expression<Func<TModel, object>> exceptUpdatePredicate, Expression<Func<TModel, bool>> wherePredicate);
      int Update_ButExcept(TModel model, Expression<Func<TModel, object>> exceptUpdatePredicate);
      int Update_ButExcept(TModel model, Expression<Func<TModel, object>> exceptUpdatePredicate, Expression<Func<TModel, bool>> wherePredicate);
      int Update_ButExcept(TModel model, Expression<Func<TModel, object>> updateExceptPredicate, Expression<Func<TModel, object>> updatePredicate, Expression<Func<TModel, bool>> wherePredicate);
   }
}
