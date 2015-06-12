using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using Linq.Respository;
using System.Threading;
using System.IO;
namespace Linq.SQL
{
   public class SQLManager : IWithTransaction
   {
      private string nadb { get; set; }
      private static object async = new object();
      string tlskey { get { return "o__linq__yutao__connection__" + nadb + "__o_13f_dtyo23d__2"; } }
      string tlskey2 { get { return "o__linq__yutao__transaction__" + nadb + "__i_14e_zgqk7fd23__"; } }
      static string logdir;
      public SQLManager(string db)
      {
         this.nadb = db;
         this.commandTimeOut = 300;
      }

      internal DbTransaction tra
      {
         get
         {
            LocalDataStoreSlot s = Thread.GetNamedDataSlot(tlskey2);
            return Thread.GetData(s) as DbTransaction;
         }
      }
      SqlConnection ccec;
      internal DbConnection Ccec
      {
         get
         {
            if (ccec == null || string.IsNullOrEmpty(ccec.ConnectionString))
            {
               lock (async)
               {
                  if (ccec == null || string.IsNullOrEmpty(ccec.ConnectionString))
                  {
                     LocalDataStoreSlot l = Thread.GetNamedDataSlot(tlskey);
                     object c = Thread.GetData(l);
                     if (c == null)
                     {
                        ConnectionStringSettings set = ConfigurationManager.ConnectionStrings[nadb];
                        string str = null;
                        try
                        {
                           if (set == null)
                           {
                              str = nadb;
                           }
                           else
                           {
                              str = set.ConnectionString;
                           }
                           ccec = new SqlConnection(str);
                        }
                        catch
                        {
                           throw new InvalidOperationException("你传入的sql连接串有问题：[" + str + "]");
                        }
                        Thread.SetData(l, ccec);
                     }
                     return Thread.GetData(l) as DbConnection;
                  }
               }
            }
            return ccec;
         }
      }
      int commandTimeOut;
      public int CommandTimeOut
      {
         get
         {
            return commandTimeOut;
         }
         set
         {
            if (value < 15)
            {
               value = 15;
            }
            commandTimeOut = value;
         }
      }
      void ctra()
      {
         op();
         LocalDataStoreSlot slot = Thread.GetNamedDataSlot(tlskey2);
         object c = Thread.GetData(slot);
         if (c == null)
         {
            lock (async)
            {
               c = Thread.GetData(slot);
               if (c == null)
               {
                  var transaction = Ccec.BeginTransaction();
                  Thread.SetData(slot, transaction);
               }
            }
         }
      }
      void cltra()
      {
         LocalDataStoreSlot s = Thread.GetNamedDataSlot(tlskey2);
         Thread.FreeNamedDataSlot(tlskey2);
      }

      internal DbCommand gmd(string str)
      {
         DbCommand c = Ccec.CreateCommand();
         if (tra != null && tra.Connection != null)
         {
            c.Transaction = tra;
         }
         c.CommandType = CommandType.Text;
         c.CommandText = str;
         c.CommandTimeout = CommandTimeOut;
         return c;
      }
      internal void op()
      {
         if (Ccec.State == ConnectionState.Closed)
         {
            Ccec.Open();
         }
      }
      internal void cp()
      {
         if (Ccec != null)
         {
            if (tra == null)
            {
               if (Ccec.State != ConnectionState.Closed)
               {
                  Ccec.Close();
               }
            }
         }
      }
      //static void tlg(string msg)
      //{
      //   if (string.IsNullOrEmpty(msg))
      //   {
      //      return;
      //   }
      //   if (logdir == "")
      //   {
      //      return;
      //   }
      //   try
      //   {
      //      if (logdir == null)
      //      {
      //         logdir = ConfigurationManager.AppSettings["Linq.sqllogdir"] ?? "";
      //      }
      //      if (!string.IsNullOrEmpty(logdir))
      //      {
      //         if (!Path.IsPathRooted(logdir))
      //         {
      //            logdir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logdir);
      //         }
      //         if (!Directory.Exists(logdir))
      //         {
      //            try
      //            {
      //               Directory.CreateDirectory(logdir);
      //            }
      //            catch
      //            {
      //               throw new Exception("创建目录名为：" + logdir + "的目录时出错！此目录中的日志是用来记录sql文本和sql执行异常文本，请检查目录是否合法");
      //            }
      //         }
      //         string file = Path.Combine(logdir, DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt");
      //         File.AppendAllText(file, Environment.NewLine + DateTime.Now + "：" + msg);
      //      }
      //   }
      //   catch
      //   {
      //      throw;
      //   }
      //}
      #region 事务
      public IDisposable BeginTransaction()
      {
         try
         {
            ctra();
            return this;
         }
         catch (Exception ex)
         {
            //tlg(ex.ToString());
            throw ex;
         }
      }
      public void Complete()
      {
         try
         {
            tra.Commit();
            tra.Dispose();
            cltra();
            cp();
         }
         catch (Exception ex)
         {
            ////tlg(ex.ToString());
            throw ex;
         }
      }
      #endregion

      #region 原生方法
      public DbDataReader ExecuteReader(string sql)
      {
         try
         {
            op();
            DbCommand c = gmd(sql);
            //tlg(sql);
            if (tra != null)
            {
               return c.ExecuteReader();
            }
            else
            {
               return c.ExecuteReader(CommandBehavior.CloseConnection);
            }
         }
         catch (Exception ex)
         {
            //tlg(ex.ToString());
            throw ex;
         }
      }
      public int ExecuteSqlNoQuery(string sql)
      {
         try
         {
            op();
            DbCommand c = gmd(sql);
            //tlg(sql);
            int i = c.ExecuteNonQuery();
            cp();
            return i;
         }
         catch (Exception ex)
         {
            //tlg(ex.ToString());
            throw ex;
         }
      }
      public object ExecuteSqlScalar(string sql)
      {
         try
         {
            op();
            DbCommand c = gmd(sql);
            //tlg(sql);
            object o = c.ExecuteScalar();
            cp();
            return o;
         }
         catch (Exception ex)
         {
            //tlg(ex.ToString());
            throw ex;
         }
      }
      public DataSet SelectDataSet(string sql)
      {
         try
         {
            DbCommand c = gmd(sql);
            //tlg(sql);
            DbDataAdapter adapter = new SqlDataAdapter((SqlCommand)c);
            DataSet d = new DataSet();
            adapter.Fill(d);
            return d;
         }
         catch (Exception ex)
         {
            //tlg(ex.ToString());
            throw ex;
         }
      }
      public DataSet SelectProcDataSet(string procedure)
      {
         try
         {
            DbCommand c = gmd(procedure);
            //tlg(procedure);
            c.CommandType = CommandType.StoredProcedure;
            DbDataAdapter adapter = new SqlDataAdapter((SqlCommand)c);
            DataSet d = new DataSet();
            adapter.Fill(d);
            return d;
         }
         catch (Exception ex)
         {
            //tlg(ex.ToString());
            throw ex;
         }
      }
      #endregion

      #region IDisposable 成员

      public void Dispose()
      {
         try
         {
            if (tra != null)
            {
               tra.Rollback();
               tra.Dispose();
               cltra();
            }
            cp();
         }
         catch (Exception ex)
         {
            //tlg(ex.ToString());
            throw ex;
         }
      }
      #endregion
   }
}
