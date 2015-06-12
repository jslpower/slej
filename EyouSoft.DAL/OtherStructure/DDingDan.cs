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
using EyouSoft.Model.JPStructure;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.DAL.OtherStructure
{
    public class DDingDan : DALBase, IDingDan
    {
        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DDingDan()
        {
            _db = SystemStore;
        }
        #endregion
        /// <summary>
        /// 获取订单集合
        /// </summary>
        /// <param name="pageSize">页面显示几条记录</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="recordCount">总数</param>
        /// <param name="chaXun">查询集合</param>
        /// <returns></returns>
        public IList<MDingDan> GetOrders(int pageSize, int pageIndex, ref int recordCount, MSearchDingDan chaXun)
        {
            List<MDingDan> items = new List<MDingDan>();
            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "View_DingDan";
            string orderByString = " [IssueTime] DESC ";
            string sumString = "";

            #region fields
            fields.Append(" * ");
            #endregion

            #region sql where
            query.Append(" 1=1 ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.DingDanId))
                {
                    query.AppendFormat(" AND OrderId='{0}' ", chaXun.DingDanId);
                }
                if (!string.IsNullOrEmpty(chaXun.xiadanrenid) && !string.IsNullOrEmpty(chaXun.fenxiaoid))
                {
                    if (chaXun.fenxiaoid == "-1")
                    {
                        query.AppendFormat(" AND ( XDRId='{0}' or LEN(AgencyId)<10 ) ", chaXun.xiadanrenid);
                    }
                    else
                    {
                        query.AppendFormat(" AND ( XDRId='{0}' or AgencyId='{1}' ) ", chaXun.xiadanrenid, chaXun.fenxiaoid);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(chaXun.xiadanrenid))
                    {
                        query.AppendFormat(" AND XDRId='{0}' ", chaXun.xiadanrenid);
                    }
                    if (!string.IsNullOrEmpty(chaXun.fenxiaoid))
                    {
                        if (chaXun.fenxiaoid == "-1")
                        {
                            query.AppendFormat(" AND LEN(AgencyId)<10");
                        }
                        else
                        {
                            query.AppendFormat(" AND AgencyId='{0}' ", chaXun.fenxiaoid);
                        }
                    }
                }
                if (chaXun.dingdantype >= 0)
                {
                    query.AppendFormat(" AND OrderType = {0} ", (int)chaXun.dingdantype);
                }
                if (chaXun.startime > Convert.ToDateTime("1900-01-01") && chaXun.endtime > Convert.ToDateTime("1900-01-01") && chaXun.startime == chaXun.endtime)
                {
                    query.AppendFormat(" AND IssueTime>='{0}' ", chaXun.startime.ToShortDateString());
                }
                else
                {
                    if (chaXun.startime > Convert.ToDateTime("1900-01-01"))
                    {
                        query.AppendFormat(" AND IssueTime>='{0}' ", chaXun.startime.ToShortDateString());
                    }
                    if (chaXun.endtime > Convert.ToDateTime("1900-01-01"))
                    {
                        query.AppendFormat(" AND IssueTime<='{0}' ", chaXun.endtime.ToShortDateString());
                    }
                }
                if (!string.IsNullOrEmpty(chaXun.changpingid))
                {
                    query.AppendFormat(" AND ProductID='{0}'", chaXun.changpingid);
                }
                if (!string.IsNullOrEmpty(chaXun.lxrmoblie))
                {
                    query.AppendFormat(" AND LXRMoblie='{0}'", chaXun.lxrmoblie);
                }
                if (chaXun.OrderStatus!= null && chaXun.OrderStatus.Count > 0)
                {
                    IList<string> wl = new List<string>();
                    foreach (EyouSoft.Model.Enum.XianLuStructure.OrderStatus item in chaXun.OrderStatus)
                    {
                        wl.Add(((int)item).ToString());
                    }

                    query.AppendFormat(" AND ChuLiZT IN ({0}) ", string.Join(",", wl.ToArray()));
                }
                if (chaXun.IsWAP)
                {
                    IList<string> wl = new List<string>();
                    IList<EyouSoft.Model.OtherStructure.DingDanType> TypeList = new List<EyouSoft.Model.OtherStructure.DingDanType> { EyouSoft.Model.OtherStructure.DingDanType.长线订单, EyouSoft.Model.OtherStructure.DingDanType.出境订单, EyouSoft.Model.OtherStructure.DingDanType.单团订单, EyouSoft.Model.OtherStructure.DingDanType.短线订单, EyouSoft.Model.OtherStructure.DingDanType.机票订单, EyouSoft.Model.OtherStructure.DingDanType.酒店订单, EyouSoft.Model.OtherStructure.DingDanType.门票订单, EyouSoft.Model.OtherStructure.DingDanType.商城订单, EyouSoft.Model.OtherStructure.DingDanType.团购订单, EyouSoft.Model.OtherStructure.DingDanType.租车订单 };
                    foreach (EyouSoft.Model.OtherStructure.DingDanType item in TypeList)
                    {
                        wl.Add(((int)item).ToString());
                    }
                    query.AppendFormat(" AND OrderType IN ({0}) ", string.Join(",", wl.ToArray()));
                }
            }
            #endregion

            using (IDataReader dataReader = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (dataReader.Read())
                {
                    var model = new MDingDan();
                    object ojb;

                    model.OrderId = dataReader["OrderId"].ToString();
                    model.AgencyId = dataReader["AgencyId"].ToString();
                    ojb = dataReader["AgencyJinE"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.AgencyJinE = (decimal)ojb;
                    }
                    model.BeiZhu = dataReader["BeiZhu"].ToString();

                    ojb = dataReader["OrderType"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.OrderType = (DingDanType)dataReader.GetInt32(dataReader.GetOrdinal("OrderType"));
                    }

                    ojb = dataReader["OrderStatus"];
                    if (model.OrderType == DingDanType.机票订单)
                    {
                        if (ojb != null && ojb != DBNull.Value)
                        {
                            model.DingDanStatus = (DingDanStatus)dataReader.GetInt32(dataReader.GetOrdinal("OrderStatus"));
                        }
                    }
                    else
                    {
                        if (ojb != null && ojb != DBNull.Value)
                        {
                            model.OrderStatus = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)dataReader.GetInt32(dataReader.GetOrdinal("OrderStatus"));
                        }
                    }
                    ojb = dataReader["FuKuanStatus"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)dataReader.GetInt32(dataReader.GetOrdinal("FuKuanStatus"));
                    }
                    ojb = dataReader["IssueTime"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.IssueTime = (DateTime)ojb;
                    }
                    model.LXRName = dataReader["LXRName"].ToString();
                    model.LXRMoblie = dataReader["LXRMoblie"].ToString();
                    ojb = dataReader["XDRId"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.XDRId = ojb.ToString();
                    }
                    ojb = dataReader["IssueTime"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.IssueTime = (DateTime)ojb;
                    }
                    ojb = dataReader["OrderNum"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.OrderNum = ojb.ToString();
                    }
                    ojb = dataReader["OrderName"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.OrderName = ojb.ToString();
                    }
                    model.OrderCode = dataReader["OrderCode"].ToString();
                    ojb = dataReader["AgencyJinE"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.AgencyJinE = (decimal)ojb;
                    }
                    ojb = dataReader["JinE"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.JinE = (decimal)ojb;
                    }
                    model.AgencyId = dataReader["AgencyId"].ToString();

                    ojb = dataReader["ProductID"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.ProductID = ojb.ToString();
                    }

                    ojb = dataReader["ChuFaShiJian"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.ChuFaShiJian = (DateTime)ojb;
                    }
                    ojb = dataReader["HuiGuiShiJian"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.HuiGuiShiJian = (DateTime)ojb;
                    }
                    ojb = dataReader["ChuLiZT"];

                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.DingDanZT = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)dataReader.GetInt32(dataReader.GetOrdinal("ChuLiZT"));
                    }
                    items.Add(model);
                }
            }
            return items;
        }

        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public MDingDan GetOrderByCodeOrID(MSearchDingDan chaXun)
        {
            MDingDan model = new MDingDan();

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT OrderId ,JinE ,OrderStatus ,OrderCode ,XDRId ,FuKuanStatus ,BeiZhu ,LXRName ,LXRMoblie ,IssueTime ,OrderName ,OrderNum ,AgencyJinE ,AgencyId ,OrderType ,ProductID FROM View_DingDan ");
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.DingDanId))
                {
                    strSql.AppendFormat("  WHERE OrderId ='{0}' ", chaXun.DingDanId);
                }
                else
                {
                    strSql.AppendFormat("  WHERE OrderCode ='{0}' ", chaXun.DingDanBianHao);
                }
            }

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            if (chaXun != null)
            {
                if (string.IsNullOrEmpty(chaXun.DingDanId))
                {
                    this._db.AddInParameter(cmd, "OrderId", DbType.String, chaXun.DingDanId);
                }
                else
                {
                    this._db.AddInParameter(cmd, "OrderCode", DbType.String, chaXun.DingDanBianHao);
                }
            }


            using (IDataReader dataReader = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (dataReader.Read())
                {
                    model.OrderId = dataReader.GetString(dataReader.GetOrdinal("OrderId"));
                    model.AgencyId = dataReader.GetString(dataReader.GetOrdinal("AgencyId"));
                    model.AgencyJinE = !dataReader.IsDBNull(dataReader.GetOrdinal("AgencyJinE")) ? dataReader.GetDecimal(dataReader.GetOrdinal("AgencyJinE")) : 0;
                    model.BeiZhu = !dataReader.IsDBNull(dataReader.GetOrdinal("BeiZhu")) ? dataReader.GetString(dataReader.GetOrdinal("BeiZhu")) : "";

                    model.OrderType = !dataReader.IsDBNull(dataReader.GetOrdinal("OrderType")) ? (DingDanType)dataReader.GetInt32(dataReader.GetOrdinal("OrderType")) : DingDanType.长线订单;

                    if (model.OrderType == DingDanType.机票订单)
                    {
                        model.DingDanStatus = (DingDanStatus)dataReader.GetInt32(dataReader.GetOrdinal("OrderStatus"));
                    }
                    else
                    {
                        model.OrderStatus = (OrderStatus)dataReader.GetInt32(dataReader.GetOrdinal("OrderStatus"));
                    }

                    model.FuKuanStatus = !dataReader.IsDBNull(dataReader.GetOrdinal("FuKuanStatus")) ? (FuKuanStatus)dataReader.GetInt32(dataReader.GetOrdinal("FuKuanStatus")) : FuKuanStatus.未付款;
                    model.LXRName = dataReader.GetString(dataReader.GetOrdinal("LXRName"));
                    model.LXRMoblie = dataReader.GetString(dataReader.GetOrdinal("LXRMoblie"));
                    model.XDRId = dataReader.GetString(dataReader.GetOrdinal("XDRId"));
                    model.IssueTime = dataReader.GetDateTime(dataReader.GetOrdinal("IssueTime"));
                    model.OrderNum = dataReader.GetString(dataReader.GetOrdinal("OrderNum"));
                    model.OrderName = dataReader.GetString(dataReader.GetOrdinal("OrderName"));
                    model.OrderCode = dataReader.GetString(dataReader.GetOrdinal("OrderCode"));
                    model.JinE = dataReader.GetDecimal(dataReader.GetOrdinal("JinE"));
                    model.ProductID = dataReader.GetString(dataReader.GetOrdinal("ProductID"));

                }
            }
            return model;
        }

    }
}
