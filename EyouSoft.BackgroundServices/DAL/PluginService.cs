using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;

namespace EyouSoft.BackgroundServices.DAL
{
    public class PluginService : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.BackgroundServices.IDAL.IPluginService
    {
        #region IPluginService 成员

        public IList<EyouSoft.BackgroundServices.IPlugin> GetPlugins()
        {
            IList<EyouSoft.BackgroundServices.IPlugin> list = new List<EyouSoft.BackgroundServices.IPlugin>();
            DbCommand dc = this.SystemStore.GetSqlStringCommand("SELECT * FROM [tbl_SysPlugin]");
            using (IDataReader dr = DbHelper.ExecuteReader(dc , this.SystemStore))
            {
                EyouSoft.BackgroundServices.IPlugin plugin = null;
                while (dr.Read())
                {
                    plugin = new EyouSoft.BackgroundServices.Plugin();
                    plugin.Enabled = GetBoolean(dr["Enabled"].ToString());
                    list.Add(plugin);
                    plugin = null;
                }
            }
            return list;
        }

        public EyouSoft.BackgroundServices.IPlugin GetPlugin(Guid pluginID)
        {
            EyouSoft.BackgroundServices.IPlugin plugin = null;
            DbCommand dc = this.SystemStore.GetSqlStringCommand("SELECT * FROM [tbl_SysPlugin] WHERE [PluginId]=@PluginId");
            this.SystemStore.AddInParameter(dc, "PluginId", DbType.String, pluginID.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this.SystemStore))
            {
                while (dr.Read())
                {
                    plugin = new EyouSoft.BackgroundServices.Plugin();
                    plugin.Enabled = GetBoolean(dr["Enabled"].ToString());
                }
            }
            return plugin;
        }

        public System.Collections.Specialized.NameValueCollection LoadSettings(EyouSoft.BackgroundServices.IPlugin plugin)
        {
            System.Collections.Specialized.NameValueCollection settings = new System.Collections.Specialized.NameValueCollection();
            DbCommand dc = this.SystemStore.GetSqlStringCommand("SELECT * FROM [tbl_SysPluginSetting] WHERE [PluginId]=@PluginId");
            this.SystemStore.AddInParameter(dc, "PluginId", DbType.String, plugin.ID.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this.SystemStore))
            {
                while (dr.Read())
                {
                    settings.Add(dr["Key"].ToString(), dr["Value"].ToString());
                }
            }
            return settings;
        }

        public void Save(EyouSoft.BackgroundServices.IPlugin plugin)
        {
            throw new NotImplementedException();
        }

        public void SaveSetting(EyouSoft.BackgroundServices.IPlugin plugin, string name, string value)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
