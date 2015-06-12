using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Data;
using Linq.TypeHelpers;
using System.Collections;
using Linq.ORM.Attribute;
using Linq.Common;
namespace Linq.ORM
{
   public class Column
   {
      /// <summary>
      /// 列名
      /// </summary>
      public string n;
      internal string fn;
      public Type ct;
      public DbType dtp;
      internal MemberInfo mif;

      public Column(MemberInfo m)
      {
         mif = m;
         this.n = gn(mif);
         this.fn = Column.cfmt3(n);
         this.ct = GetMemberType();
         this.dtp = gdbt();
      }

      private Type GetMemberType()
      {
         if (mif is PropertyInfo)
            return ((PropertyInfo)mif).PropertyType;
         throw new NotSupportedException("目前只支持属性映射");
      }

      public static string GetSqlTypeName(Type te)
      {
         DbType dtp2 = DbType.AnsiString;
         if (te.IsValueType && te.IsGenericType && typeof(Nullable<>).IsAssignableFrom(te))
         {
            te = te.GetGenericArguments()[0];
         }
         if (te == typeof(int))
         {
            return "int";
         }
         if (te == typeof(short))
         {
            return "smallint";
         }
         if (te == typeof(byte))
         {
            return "tinyint";
         }
         if (te == typeof(long))
         {
            return "bigint";
         }
         if (te == typeof(string))
         {
            return "nvarchar";
         }
         if (te == typeof(DateTime))
         {
            return "datetime";
         }
         if (te == typeof(Guid))
         {
            return "uniqueidentifier";
         }
         return "varchar";
      }

      internal static string gn(MemberInfo mif)
      {
         ColumnAttribute attr = gattr(mif).OfType<ColumnAttribute>().FirstOrDefault();
         if (attr != null)
         {
            return attr.Name;
         }
         else
         {
            return mif.Name;
         }
      }
      static Dictionary<MemberInfo, object[]> mcah = new Dictionary<MemberInfo, object[]>();

      public static object[] gattr(MemberInfo br)
      {
         if (!mcah.ContainsKey(br))
         {
            lock (mcah)
            {
               if (!mcah.ContainsKey(br))
               {
                  mcah.Add(br, br.GetCustomAttributes(false));
               }
            }
         }
         return mcah[br];
      }

      public static bool hattr<T>(MemberInfo eb)
      {
         var o = gattr(eb);
         for (int i = 0, len = o.Length; i < len; i++)
         {
            if (o[i] is T)
            {
               return true;
            }
         }
         return false;
      }
      DbType gdbt()
      {
         DbTypeAttribute attr = gattr(mif).OfType<DbTypeAttribute>().FirstOrDefault();
         if (attr != null)
         {
            return attr.DbType;
         }
         else
         {
            return dm();
         }
      }
      /// <summary>
      /// 此函数待修改
      /// </summary>
      public DbType dm()
      {
         DbType dbtype = DbType.AnsiString;
         Type type = ct;
         if (TypeHelper.IsNullable(ct))
         {
            type = ct.GetGenericArguments()[0];
         }
         if (type == typeof(int))
         {
            dbtype = DbType.Int32;
         }
         if (type == typeof(uint))
         {
            dbtype = DbType.UInt32;
         }
         if (type == typeof(short))
         {
            dbtype = DbType.Int16;
         }
         if (type == typeof(ushort))
         {
            dbtype = DbType.UInt16;
         }
         if (type == typeof(byte))
         {
            dbtype = DbType.Byte;
         }
         if (type == typeof(sbyte))
         {
            dbtype = DbType.SByte;
         }
         if (type == typeof(long))
         {
            dbtype = DbType.Int64;
         }
         if (type == typeof(ulong))
         {
            dbtype = DbType.UInt64;
         }
         if (type == typeof(string))
         {
            dbtype = DbType.String;
         }
         if (type == typeof(DateTime))
         {
            dbtype = DbType.DateTime;
         }
         if (type == typeof(Guid))
         {
            dbtype = DbType.Guid;
         }
         return dbtype;
      }
      internal virtual object ga(object l)
      {
         if (l == null)
         {
            throw new NullReferenceException("Column.GetValue model参数不能为空");
         }
         object value = null;
         if (mif.MemberType == MemberTypes.Property)
         {
            PropertyInfo y = (mif as PropertyInfo);
            if (y.CanRead)
            {
               value = y.GetValue(l, null);
            }
         }
         else
         {
            throw new NotSupportedException("目前只支持属性映射");
         }
         return value;
      }
      internal string gv(object del)
      {
         return TypeHelper.sfm(ga(del), ct);
      }

      internal void svv(object ml, IDataReader rd)
      {
         if (ml == null)
         {
            throw new InvalidOperationException("设置column值时，model主体不能为空");
         }
         object finalValue = null;
         string table = tas.grna(this.mif.DeclaringType);

         bool flag1 = rd.HasColumnStartWith(n + "__" + table + "__");
         bool flag2 = rd.HasColumn(n);
         object rawValue = null;
         if (flag1)
         {
            int i = 1;
            while (i < 10)
            {
               if (rd.HasColumn(n + "__" + table + "__" + i))
               {
                  rawValue = rd[n + "__" + table + "__" + i];
                  break;
               }
               i++;
            }
         }
         else if (flag2)
         {
            rawValue = rd[n];
         }
         if (flag1 || flag2)
         {
            if (rawValue is DBNull || rawValue == null)
            {
               if (TypeHelper.IsNullable(ct) || ct == typeof(string) || ct == typeof(char))
               {
                  finalValue = null;
               }
               else
               {
                  finalValue = TypeHelper.createObject(ct);
               }
            }
            else
            {
               finalValue = rawValue;
               Type type = ct;
               if (TypeHelper.IsNullable(ct))
               {
                  type = ct.GetGenericArguments()[0];
               }
               if (type.IsEnum)
               {
                  finalValue = Enum.Parse(type, finalValue.ToString(), true);
               }
               else
               {
                  if (type == typeof(bool))
                  {
                     string f = finalValue.ToString();
                     if (f == "1" || string.Equals(f, "true", StringComparison.OrdinalIgnoreCase))
                     {
                        finalValue = true;
                     }
                     if (finalValue.ToString() == "0" || string.Equals(f, "false", StringComparison.OrdinalIgnoreCase))
                     {
                        finalValue = false;
                     }
                  }
                  finalValue = Convert.ChangeType(finalValue, type);
               }
            }
         }
         else
         {
            if (TypeHelper.IsComplex(ct))
            {
               IList<Column> complexTypeColumn = tas.SelectColumnSelector(ct);
               object complexColumn = TypeHelper.createObject(ct);
               for (int j = 0, len2 = complexTypeColumn.Count; j < len2; j++)
               {
                  complexTypeColumn[j].svv(complexColumn, rd);
               }
               finalValue = complexColumn;
            }
         }
         try
         {
            if (mif.MemberType == MemberTypes.Property)
            {
               var property = (mif as PropertyInfo);
               if (property.CanWrite)
               {
                  property.SetValue(ml, finalValue, null);
               }
            }
         }
         catch (Exception ex)
         {
            throw new Exception("在给成员[" + mif.Name + "]赋值时发生异常！\r\n" + ex.ToString());
         }
      }

      static void aedid(string n, string n2)
      {
         if (!kdci.ContainsKey(n))
         {
            lock (kdci)
            {
               if (!kdci.ContainsKey(n))
               {
                  kdci.Add(n, n2);
               }
            }
         }
      }

      static string[] sskwd = new string[] { "ADD", "EXCEPT", "PERCENT", "ALL", "EXEC", "PLAN", "ALTER", "EXECUTE", "PRECISION", "AND", "EXISTS", "PRIMARY", "ANY", "EXIT", "PRINT", "AS", "FETCH", "PROC", "ASC", "FILE", "PROCEDURE", "AUTHORIZATION", "FILLFACTOR", "PUBLIC", "BACKUP", "FOR", "RAISERROR", "BEGIN", "FOREIGN", "READ", "BETWEEN", "FREETEXT", "READTEXT", "BREAK", "FREETEXTTABLE", "RECONFIGURE", "BROWSE", "FROM", "REFERENCES", "BULK", "FULL", "REPLICATION", "BY", "FUNCTION", "RESTORE", "CASCADE", "GOTO", "RESTRICT", "CASE", "GRANT", "RETURN", "CHECK", "GROUP", "REVOKE", "CHECKPOINT", "HAVING", "RIGHT", "CLOSE", "HOLDLOCK", "ROLLBACK", "CLUSTERED", "IDENTITY", "ROWCOUNT", "COALESCE", "IDENTITY_INSERT", "ROWGUIDCOL", "COLLATE", "IDENTITYCOL", "RULE", "COLUMN", "IF", "SAVE", "COMMIT", "IN", "SCHEMA", "COMPUTE", "INDEX", "SELECT", "CONSTRAINT", "INNER", "SESSION_USER", "CONTAINS", "INSERT", "SET", "CONTAINSTABLE", "INTERSECT", "SETUSER", "CONTINUE", "INTO", "SHUTDOWN", "CONVERT", "IS", "SOME", "CREATE", "JOIN", "STATISTICS", "CROSS", "KEY", "SYSTEM_USER", "CURRENT", "KILL", "TABLE", "CURRENT_DATE", "LEFT", "TEXTSIZE", "CURRENT_TIME", "LIKE", "THEN", "CURRENT_TIMESTAMP", "LINENO", "TO", "CURRENT_USER", "LOAD", "TOP", "CURSOR", "NATIONAL ", "TRAN", "DATABASE", "NOCHECK", "TRANSACTION", "DBCC", "NONCLUSTERED", "TRIGGER", "DEALLOCATE", "NOT", "TRUNCATE", "DECLARE", "NULL", "TSEQUAL", "DEFAULT", "NULLIF", "UNION", "DELETE", "OF", "UNIQUE", "DENY", "OFF", "UPDATE", "DESC", "OFFSETS", "UPDATETEXT", "DISK", "ON", "USE", "DISTINCT", "OPEN", "USER", "DISTRIBUTED", "OPENDATASOURCE", "VALUES", "DOUBLE", "OPENQUERY", "VARYING", "DROP", "OPENROWSET", "VIEW", "DUMMY", "OPENXML", "WAITFOR", "DUMP", "OPTION", "WHEN", "ELSE", "OR", "WHERE", "END", "ORDER", "WHILE", "ERRLVL", "OUTER", "WITH", "ESCAPE", "OVER", "WRITETEXT", "ABSOLUTE", "FOUND", "PRESERVE", "ACTION", "FREE", "PRIOR", "ADMIN", "GENERAL", "PRIVILEGES", "AFTER", "GET", "READS", "AGGREGATE", "GLOBAL", "REAL", "ALIAS", "GO", "RECURSIVE", "ALLOCATE", "GROUPING", "REF", "ARE", "HOST", "REFERENCING", "ARRAY", "HOUR", "RELATIVE", "ASSERTION", "IGNORE", "RESULT", "AT", "IMMEDIATE", "RETURNS", "BEFORE", "INDICATOR", "ROLE", "BINARY", "INITIALIZE", "ROLLUP", "BIT", "INITIALLY", "ROUTINE", "BLOB", "INOUT", "ROW", "BOOLEAN", "INPUT", "ROWS", "BOTH", "INT", "SAVEPOINT", "BREADTH", "INTEGER", "SCROLL", "CALL", "INTERVAL", "SCOPE", "CASCADED", "ISOLATION", "SEARCH", "CAST", "ITERATE", "SECOND", "CATALOG", "LANGUAGE", "SECTION", "CHAR", "LARGE", "SEQUENCE", "CHARACTER", "LAST", "SESSION", "CLASS", "LATERAL", "SETS", "CLOB", "LEADING", "SIZE", "COLLATION", "LESS", "SMALLINT", "COMPLETION", "LEVEL", "SPACE", "CONNECT", "LIMIT", "SPECIFIC", "CONNECTION", "LOCAL", "SPECIFICTYPE", "CONSTRAINTS", "LOCALTIME", "SQL", "CONSTRUCTOR", "LOCALTIMESTAMP", "SQLEXCEPTION", "CORRESPONDING", "LOCATOR", "SQLSTATE", "CUBE", "MAP", "SQLWARNING", "CURRENT_PATH", "MATCH", "START", "CURRENT_ROLE", "MINUTE", "STATE", "CYCLE", "MODIFIES", "STATEMENT", "DATA", "MODIFY", "STATIC", "DATE", "MODULE", "STRUCTURE", "DAY", "MONTH", "TEMPORARY", "DEC", "NAMES", "TERMINATE", "DECIMAL", "NATURAL", "THAN", "DEFERRABLE", "NCHAR", "TIME", "DEFERRED", "NCLOB", "TIMESTAMP", "DEPTH", "NEW", "TIMEZONE_HOUR", "DEREF", "NEXT", "TIMEZONE_MINUTE", "DESCRIBE", "NO", "TRAILING", "DESCRIPTOR", "NONE", "TRANSLATION", "DESTROY", "NUMERIC", "TREAT", "DESTRUCTOR", "OBJECT", "TRUE", "DETERMINISTIC", "OLD", "UNDER", "DICTIONARY", "ONLY", "UNKNOWN", "DIAGNOSTICS", "OPERATION", "UNNEST", "DISCONNECT", "ORDINALITY", "USAGE", "DOMAIN", "OUT", "USING", "DYNAMIC", "OUTPUT", "VALUE", "EACH", "PAD", "VARCHAR", "END-EXEC", "PARAMETER", "VARIABLE", "EQUALS", "PARAMETERS", "WHENEVER", "EVERY", "PARTIAL", "WITHOUT", "EXCEPTION", "PATH", "WORK", "EXTERNAL", "POSTFIX", "WRITE", "FALSE", "PREFIX", "YEAR", "FIRST", "PREORDER", "ZONE", "FLOAT", "PREPARE", "ADA", "AVG", "BIT_LENGTH", "CHAR_LENGTH", "CHARACTER_LENGTH", "COUNT", "EXTRACT", "FORTRAN", "INCLUDE", "INSENSITIVE", "LOWER", "MAX", "MIN", "OCTET_LENGTH", "OVERLAPS", "PASCAL", "POSITION", "SQLCA", "SQLCODE", "SQLERROR", "SUBSTRING", "SUM", "TRANSLATE", "TRIM", "UPPER" };
      static Dictionary<string, string> kdci = new Dictionary<string, string>(StringComparer.Ordinal);
      internal static string cfmt3(string name)
      {
         if (!string.IsNullOrEmpty(name))
         {
            if (name.Length > 776)
            {
               throw new Exception("名称长度超过了最大长度限制！");
            }
            if (!kdci.ContainsKey(name))
            {
               lock (kdci)
               {
                  if (!kdci.ContainsKey(name))
                  {
                     int i = 0;
                     char f = name[0];
                     if (f >= '0' && f <= '9')
                     {
                        throw new NotSupportedException("不支持的名称：" + name + "，应以字母数字下化线组合，以非数字为首字符");
                     }
                     while (i < name.Length)
                     {
                        char c = name[i];
                        if (!((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '_'))
                        {
                           throw new NotSupportedException("orm暂不支持的名称：" + name + "，名称不合法。");
                        }
                        i++;
                     }
                     if (MaxUtils.Exists(sskwd, name))
                     {
                        aedid(name, "[" + name + "]");
                     }
                     else
                     {
                        aedid(name, name);
                     }
                  }
               }
            }
            return kdci[name];
         }
         throw new InvalidOperationException("名称不能为空");
      }
   }
}