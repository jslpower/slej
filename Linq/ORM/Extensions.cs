using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Linq.ORM
{
    public static class Extension
    {
        /// <summary>
        /// GetSchemaTable此方法内部微软已做性能优化
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static bool HasColumn(this IDataReader reader, string columnName)
        {
            return reader.GetSchemaTable().Select("ColumnName='" + columnName + "'").Length > 0;
        }

        public static bool HasColumnStartWith(this IDataReader reader, string columnName)
        {
            return reader.GetSchemaTable().Select("ColumnName like '" + columnName + "%'").Length > 0;
        }
    }
}
