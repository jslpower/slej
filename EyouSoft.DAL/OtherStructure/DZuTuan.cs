using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.OtherStructure;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.IDAL.OtherStructure;

namespace EyouSoft.DAL.OtherStructure
{
    public class DZuTuan : DALBase, IZuTuan
    {
        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DZuTuan()
        {
            _db = SystemStore;
        }
        #endregion
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public int Add(MZuTuan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_JA_DanDuZuTuan (");
            strSql.Append("CarMoney,ZaoCanMoney,WuCanMoney,WanCanMoney,RSYiWai,JTYiWai,DaoYouMoney,MSCarMoney,MSZaoCanMoney,MSWuCanMoney,MSWanCanMoney,MSRSYiWai,MSJTYiWai,MSDaoYouMoney,DXRS,CXRS,CJRS,DiPeiDaoYou,MSDiPeiDaoYou,DXDiPeiDaoYou,MSDXDiPeiDaoYou,DXDaoYouMoney,MSDXDaoYouMoney,CJDiPeiDaoYou,MSCJDiPeiDaoYou,CJDaoYouMoney,MSCJDaoYouMoney ");
            strSql.Append(") values (");
            strSql.Append("@CarMoney,@ZaoCanMoney,@WuCanMoney,@WanCanMoney,@RSYiWai,@JTYiWai,@DaoYouMoney,@MSCarMoney,@MSZaoCanMoney,@MSWuCanMoney,@MSWanCanMoney,@MSRSYiWai,@MSJTYiWai,@MSDaoYouMoney,@DXRS,@CXRS,@CJRS,@DiPeiDaoYou,@MSDiPeiDaoYou,@DXDiPeiDaoYou,@MSDXDiPeiDaoYou,@DXDaoYouMoney,@MSDXDaoYouMoney,@CJDiPeiDaoYou,@MSCJDiPeiDaoYou,@CJDaoYouMoney,@MSCJDaoYouMoney ");
            strSql.Append(") ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "CarMoney", System.Data.DbType.Decimal,model.CarMoney);
            this._db.AddInParameter(cmd, "ZaoCanMoney", System.Data.DbType.Decimal,model.ZaoCanMoney);
            this._db.AddInParameter(cmd, "WuCanMoney", System.Data.DbType.Decimal,model.WuCanMoney);
            this._db.AddInParameter(cmd, "WanCanMoney", System.Data.DbType.Decimal,model.WanCanMoney);
            this._db.AddInParameter(cmd, "RSYiWai", System.Data.DbType.Decimal,model.RSYiWai);
            this._db.AddInParameter(cmd, "JTYiWai", System.Data.DbType.Decimal,model.JTYiWai);
            this._db.AddInParameter(cmd, "DaoYouMoney", System.Data.DbType.Decimal,model.DaoYouMoney);
            this._db.AddInParameter(cmd, "MSCarMoney", System.Data.DbType.Decimal, model.MSCarMoney);
            this._db.AddInParameter(cmd, "MSZaoCanMoney", System.Data.DbType.Decimal, model.MSZaoCanMoney);
            this._db.AddInParameter(cmd, "MSWuCanMoney", System.Data.DbType.Decimal, model.MSWuCanMoney);
            this._db.AddInParameter(cmd, "MSWanCanMoney", System.Data.DbType.Decimal, model.MSWanCanMoney);
            this._db.AddInParameter(cmd, "MSRSYiWai", System.Data.DbType.Decimal, model.MSRSYiWai);
            this._db.AddInParameter(cmd, "MSJTYiWai", System.Data.DbType.Decimal, model.MSJTYiWai);
            this._db.AddInParameter(cmd, "MSDaoYouMoney", System.Data.DbType.Decimal, model.MSDaoYouMoney);
            this._db.AddInParameter(cmd, "DXRS", System.Data.DbType.Int32, model.DXRS);
            this._db.AddInParameter(cmd, "CXRS", System.Data.DbType.Int32, model.CXRS);
            this._db.AddInParameter(cmd, "CJRS", System.Data.DbType.Int32, model.CJRS);
            this._db.AddInParameter(cmd, "DiPeiDaoYou", System.Data.DbType.Decimal, model.DiPeiDaoYou);
            this._db.AddInParameter(cmd, "MSDiPeiDaoYou", System.Data.DbType.Decimal, model.MSDiPeiDaoYou);
            this._db.AddInParameter(cmd, "DXDiPeiDaoYou", System.Data.DbType.Decimal, model.DXDiPeiDaoYou);
            this._db.AddInParameter(cmd, "MSDXDiPeiDaoYou", System.Data.DbType.Decimal, model.MSDXDiPeiDaoYou);
            this._db.AddInParameter(cmd, "DXDaoYouMoney", System.Data.DbType.Decimal, model.DXDaoYouMoney);
            this._db.AddInParameter(cmd, "MSDXDaoYouMoney", System.Data.DbType.Decimal, model.MSDXDaoYouMoney);
            this._db.AddInParameter(cmd, "CJDiPeiDaoYou", System.Data.DbType.Decimal, model.CJDiPeiDaoYou);
            this._db.AddInParameter(cmd, "MSCJDiPeiDaoYou", System.Data.DbType.Decimal, model.MSCJDiPeiDaoYou);
            this._db.AddInParameter(cmd, "CJDaoYouMoney", System.Data.DbType.Decimal, model.CJDaoYouMoney);
            this._db.AddInParameter(cmd, "MSCJDaoYouMoney", System.Data.DbType.Decimal, model.MSCJDaoYouMoney);
            return DbHelper.ExecuteSql(cmd, this._db);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(MZuTuan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tbl_JA_DanDuZuTuan SET CarMoney=@CarMoney, ");
            strSql.Append(" ZaoCanMoney=@ZaoCanMoney, WuCanMoney=@WuCanMoney, ");
            strSql.Append(" WanCanMoney=@WanCanMoney, RSYiWai= @RSYiWai, JTYiWai= @JTYiWai, DaoYouMoney= @DaoYouMoney, ");
            strSql.Append(" MSCarMoney=@MSCarMoney,MSZaoCanMoney=@MSZaoCanMoney, MSWuCanMoney=@MSWuCanMoney, ");
            strSql.Append(" MSWanCanMoney=@MSWanCanMoney, MSRSYiWai= @MSRSYiWai, MSJTYiWai= @MSJTYiWai, MSDaoYouMoney= @MSDaoYouMoney,DXRS=@DXRS,CXRS=@CXRS,CJRS=@CJRS,DiPeiDaoYou=@DiPeiDaoYou,MSDiPeiDaoYou=@MSDiPeiDaoYou,DXDiPeiDaoYou=@DXDiPeiDaoYou,MSDXDiPeiDaoYou=@MSDXDiPeiDaoYou,DXDaoYouMoney=@DXDaoYouMoney,MSDXDaoYouMoney=@MSDXDaoYouMoney,CJDiPeiDaoYou=@CJDiPeiDaoYou,MSCJDiPeiDaoYou=@MSCJDiPeiDaoYou,CJDaoYouMoney=@CJDaoYouMoney,MSCJDaoYouMoney=@MSCJDaoYouMoney ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "CarMoney", System.Data.DbType.Decimal, model.CarMoney);
            this._db.AddInParameter(cmd, "ZaoCanMoney", System.Data.DbType.String, model.ZaoCanMoney);
            this._db.AddInParameter(cmd, "WuCanMoney", System.Data.DbType.String, model.WuCanMoney);
            this._db.AddInParameter(cmd, "WanCanMoney", System.Data.DbType.String, model.WanCanMoney);
            this._db.AddInParameter(cmd, "RSYiWai", System.Data.DbType.String, model.RSYiWai);
            this._db.AddInParameter(cmd, "JTYiWai", System.Data.DbType.String, model.JTYiWai);
            this._db.AddInParameter(cmd, "DaoYouMoney", System.Data.DbType.Decimal, model.DaoYouMoney);
            this._db.AddInParameter(cmd, "MSCarMoney", System.Data.DbType.Decimal, model.MSCarMoney);
            this._db.AddInParameter(cmd, "MSZaoCanMoney", System.Data.DbType.String, model.MSZaoCanMoney);
            this._db.AddInParameter(cmd, "MSWuCanMoney", System.Data.DbType.String, model.MSWuCanMoney);
            this._db.AddInParameter(cmd, "MSWanCanMoney", System.Data.DbType.String, model.MSWanCanMoney);
            this._db.AddInParameter(cmd, "MSRSYiWai", System.Data.DbType.String, model.MSRSYiWai);
            this._db.AddInParameter(cmd, "MSJTYiWai", System.Data.DbType.String, model.MSJTYiWai);
            this._db.AddInParameter(cmd, "MSDaoYouMoney", System.Data.DbType.Decimal, model.MSDaoYouMoney);
            this._db.AddInParameter(cmd, "DXRS", System.Data.DbType.Int32, model.DXRS);
            this._db.AddInParameter(cmd, "CXRS", System.Data.DbType.Int32, model.CXRS);
            this._db.AddInParameter(cmd, "CJRS", System.Data.DbType.Int32, model.CJRS);
            this._db.AddInParameter(cmd, "DiPeiDaoYou", System.Data.DbType.Decimal, model.DiPeiDaoYou);
            this._db.AddInParameter(cmd, "MSDiPeiDaoYou", System.Data.DbType.Decimal, model.MSDiPeiDaoYou);
            this._db.AddInParameter(cmd, "DXDiPeiDaoYou", System.Data.DbType.Decimal, model.DXDiPeiDaoYou);
            this._db.AddInParameter(cmd, "MSDXDiPeiDaoYou", System.Data.DbType.Decimal, model.MSDXDiPeiDaoYou);
            this._db.AddInParameter(cmd, "DXDaoYouMoney", System.Data.DbType.Decimal, model.DXDaoYouMoney);
            this._db.AddInParameter(cmd, "MSDXDaoYouMoney", System.Data.DbType.Decimal, model.MSDXDaoYouMoney);
            this._db.AddInParameter(cmd, "CJDiPeiDaoYou", System.Data.DbType.Decimal, model.CJDiPeiDaoYou);
            this._db.AddInParameter(cmd, "MSCJDiPeiDaoYou", System.Data.DbType.Decimal, model.MSCJDiPeiDaoYou);
            this._db.AddInParameter(cmd, "CJDaoYouMoney", System.Data.DbType.Decimal, model.CJDaoYouMoney);
            this._db.AddInParameter(cmd, "MSCJDaoYouMoney", System.Data.DbType.Decimal, model.MSCJDaoYouMoney);

            return DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public MZuTuan GetModel()
        {
            MZuTuan model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from tbl_JA_DanDuZuTuan ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    object obj = null;
                    model = new MZuTuan();
                    model.CarMoney = !dr.IsDBNull(dr.GetOrdinal("CarMoney")) ? dr.GetDecimal(dr.GetOrdinal("CarMoney")) : 0;
                    model.DaoYouMoney = !dr.IsDBNull(dr.GetOrdinal("DaoYouMoney")) ? dr.GetDecimal(dr.GetOrdinal("DaoYouMoney")) : 0;
                    obj = dr["JTYiWai"];
                    if (!string.IsNullOrEmpty(obj.ToString()))
                    {
                        model.JTYiWai = dr.GetString(dr.GetOrdinal("JTYiWai"));
                    }
                    else
                    {
                        model.JTYiWai = "0";
                    }
                    obj = dr["RSYiWai"];
                    if (!string.IsNullOrEmpty(obj.ToString()))
                    {
                        model.RSYiWai = dr.GetString(dr.GetOrdinal("RSYiWai"));
                    }
                    else
                    {
                        model.RSYiWai = "0";
                    }
                    obj = dr["WanCanMoney"];
                    if (!string.IsNullOrEmpty(obj.ToString()))
                    {
                        model.WanCanMoney = dr.GetString(dr.GetOrdinal("WanCanMoney"));
                    }
                    else
                    {
                        model.WanCanMoney = "0";
                    }
                    obj = dr["WuCanMoney"];
                    if (!string.IsNullOrEmpty(obj.ToString()))
                    {
                        model.WuCanMoney = dr.GetString(dr.GetOrdinal("WuCanMoney"));
                    }
                    else
                    {
                        model.WuCanMoney = "0";
                    }
                    obj = dr["ZaoCanMoney"];
                    if (!string.IsNullOrEmpty(obj.ToString()))
                    {
                        model.ZaoCanMoney = dr.GetString(dr.GetOrdinal("ZaoCanMoney"));
                    }
                    else
                    {
                        model.ZaoCanMoney = "0";
                    }
                    model.MSCarMoney = !dr.IsDBNull(dr.GetOrdinal("MSCarMoney")) ? dr.GetDecimal(dr.GetOrdinal("MSCarMoney")) : 0;
                    model.MSDaoYouMoney = !dr.IsDBNull(dr.GetOrdinal("MSDaoYouMoney")) ? dr.GetDecimal(dr.GetOrdinal("MSDaoYouMoney")) : 0;
                    obj = dr["MSJTYiWai"];
                    if (!string.IsNullOrEmpty(obj.ToString()))
                    {
                        model.MSJTYiWai = dr.GetString(dr.GetOrdinal("MSJTYiWai"));
                    }
                    else
                    {
                        model.MSJTYiWai = "0";
                    }
                    obj = dr["MSRSYiWai"];
                    if (!string.IsNullOrEmpty(obj.ToString()))
                    {
                        model.MSRSYiWai = dr.GetString(dr.GetOrdinal("MSRSYiWai"));
                    }
                    else
                    {
                        model.MSRSYiWai = "0";
                    }
                    obj = dr["MSWanCanMoney"];
                    if (!string.IsNullOrEmpty(obj.ToString()))
                    {
                        model.MSWanCanMoney = dr.GetString(dr.GetOrdinal("MSWanCanMoney"));
                    }
                    else
                    {
                        model.MSWanCanMoney = "0";
                    }
                    obj = dr["MSWuCanMoney"];
                    if (!string.IsNullOrEmpty(obj.ToString()))
                    {
                        model.MSWuCanMoney = dr.GetString(dr.GetOrdinal("MSWuCanMoney"));
                    }
                    else
                    {
                        model.MSWuCanMoney = "0";
                    }
                    obj = dr["MSZaoCanMoney"];
                    if (!string.IsNullOrEmpty(obj.ToString()))
                    {
                        model.MSZaoCanMoney = dr.GetString(dr.GetOrdinal("MSZaoCanMoney"));
                    }
                    else
                    {
                        model.MSZaoCanMoney = "0";
                    }
                    model.CJRS = !dr.IsDBNull(dr.GetOrdinal("CJRS")) ? dr.GetInt32(dr.GetOrdinal("CJRS")) : 0;
                    model.CXRS = !dr.IsDBNull(dr.GetOrdinal("CXRS")) ? dr.GetInt32(dr.GetOrdinal("CXRS")) : 0;
                    model.DXRS = !dr.IsDBNull(dr.GetOrdinal("DXRS")) ? dr.GetInt32(dr.GetOrdinal("DXRS")) : 0;

                    model.DiPeiDaoYou = !dr.IsDBNull(dr.GetOrdinal("DiPeiDaoYou")) ? dr.GetDecimal(dr.GetOrdinal("DiPeiDaoYou")) : 0;
                    model.MSDiPeiDaoYou = !dr.IsDBNull(dr.GetOrdinal("MSDiPeiDaoYou")) ? dr.GetDecimal(dr.GetOrdinal("MSDiPeiDaoYou")) : 0;
                    model.DXDiPeiDaoYou = !dr.IsDBNull(dr.GetOrdinal("DXDiPeiDaoYou")) ? dr.GetDecimal(dr.GetOrdinal("DXDiPeiDaoYou")) : 0;
                    model.MSDXDiPeiDaoYou = !dr.IsDBNull(dr.GetOrdinal("MSDXDiPeiDaoYou")) ? dr.GetDecimal(dr.GetOrdinal("MSDXDiPeiDaoYou")) : 0;
                    model.DXDaoYouMoney = !dr.IsDBNull(dr.GetOrdinal("DXDaoYouMoney")) ? dr.GetDecimal(dr.GetOrdinal("DXDaoYouMoney")) : 0;
                    model.MSDXDaoYouMoney = !dr.IsDBNull(dr.GetOrdinal("MSDXDaoYouMoney")) ? dr.GetDecimal(dr.GetOrdinal("MSDXDaoYouMoney")) : 0;
                    model.CJDiPeiDaoYou = !dr.IsDBNull(dr.GetOrdinal("CJDiPeiDaoYou")) ? dr.GetDecimal(dr.GetOrdinal("CJDiPeiDaoYou")) : 0;
                    model.MSCJDiPeiDaoYou = !dr.IsDBNull(dr.GetOrdinal("MSCJDiPeiDaoYou")) ? dr.GetDecimal(dr.GetOrdinal("MSCJDiPeiDaoYou")) : 0;
                    model.CJDaoYouMoney = !dr.IsDBNull(dr.GetOrdinal("CJDaoYouMoney")) ? dr.GetDecimal(dr.GetOrdinal("CJDaoYouMoney")) : 0;
                    model.MSCJDaoYouMoney = !dr.IsDBNull(dr.GetOrdinal("MSCJDaoYouMoney")) ? dr.GetDecimal(dr.GetOrdinal("MSCJDaoYouMoney")) : 0;
                }
            }

            return model;
        }
    }
}
