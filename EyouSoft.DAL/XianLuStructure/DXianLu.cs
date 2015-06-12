//线路产品相关信息数据访问类 汪奇志 2013-03-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.IDAL.XianLuStructure;
using EyouSoft.Model.XianLuStructure;
using EyouSoft.Toolkit;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.DAL.XianLuStructure
{
    /// <summary>
    /// 线路产品相关信息数据访问类
    /// </summary>
    public class DXianLu : DALBase, IXianLu
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetInfo = "SELECT * FROM [view_XianLu] WHERE [XianLuId]=@XianLuId";
        const string SQL_SELECT_GetTourInfo = "SELECT * FROM [view_XianLuTour] WHERE [TourId]=@TourId ORDER BY [LDate] ASC";
        const string SQL_SELECT_GetXianLuFuWuInfo = "SELECT * FROM [tbl_XianLuFuWu] WHERE [XianLuId]=@XianLuId";
        const string SQL_SELECT_GetXianLuTours = "SELECT * FROM [view_XianLuTour] WHERE [XianLuId]=@XianLuId ORDER BY [LDate] ASC";
        const string SQL_SELECT_GetXianLuXingChengs = "SELECT * FROM [tbl_XianLuXingCheng] WHERE [XianLuId]=@XianLuId ORDER BY [IdentityId] ASC";
        const string SQL_SELECT_GetXianLuZhuangTais = "SELECT * FROM [tbl_XianLuZhuangTai] WHERE [XianLuId]=@XianLuId";
        const string SQL_SELECT_GetXianLuZhuTis = "SELECT A.ZhuTiId,B.Name FROM [tbl_XianLuZhuTi] AS A INNER JOIN [tbl_RouteTheme] AS B ON A.ZhuTiId=B.[Id] WHERE A.[XianLuId]=@XianLuId";
        const string SQL_UPDATE_JiaGuanZhuShu = "UPDATE [tbl_XianLu] SET [GuanZhuShu]=[GuanZhuShu]+@Expression WHERE [XianLuId]=@XianLuId";
        const string SQL_DELETE_DeleteZhuangTai = "DELETE FROM [tbl_XianLuZhuangTai] WHERE [XianLuId]=@XianLuId";
        const string SQL_SELECT_GetTeSeFiles = "SELECT * FROM [tbl_XianLuTeSeFile] WHERE [XianLuId]=@XianLuId ORDER BY [IdentityId] ASC";
        const string SQL_SELECT_GetTourTraffice = "SELECT * FROM [tbl_XianLuTourTraffice] WHERE [XianLuId]=@XianLuId AND TrafficId IN (SELECT  TrafficId FROM dbo.tbl_XianLuTour WHERE LDate>GETDATE()) ORDER BY [IdentityId] ASC";
        const string SQL_SELECT_GetXianLuTuanGous = "SELECT A.* FROM [view_XianLuTuanGou] AS A WHERE A.[XianLuId]=@XianLuId ORDER BY A.[IdentityId] ASC";
        const string SQL_SELECT_GetTuanGouInfo = "SELECT A.* FROM [view_XianLuTuanGou] AS A WHERE A.[TuanGouId]=@TuanGouId";
        const string SQL_UPDATE_SheZhiXianLuTourChaYi = "UPDATE [tbl_XianLuTour] SET [JSJCR]=@JSJCR,[JSJET]=@JSJET,[CRSCJ]=@CRSCJ,[ETSCJ]=@ETSCJ WHERE [TourId]=@TourId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DXianLu()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// 创建线路行程XML
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateXingChengXml(IList<MXianLuXingChengInfo> items)
        {
            //行程XML:<root><info QuJian="" JiaoTong="" ZhuSu="" YongCan="" XingCheng="" FilePath="" /></root>
            if (items == null || items.Count == 0) return string.Empty;

            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.AppendFormat("<info QuJian=\"{0}\" JiaoTong=\"{1}\" ZhuSu=\"{2}\" YongCan=\"{3}\" XingCheng=\"{4}\" FilePath=\"{5}\" />", Utils.ReplaceXmlSpecialCharacter(item.QuJian)
                    , Utils.ReplaceXmlSpecialCharacter(item.JiaoTong)
                    , Utils.ReplaceXmlSpecialCharacter(item.ZhuSu)
                    , Utils.ReplaceXmlSpecialCharacter(item.YongCan)
                    , Utils.ReplaceXmlSpecialCharacter(item.XingCheng)
                    , Utils.ReplaceXmlSpecialCharacter(item.FilePath));
            }
            s.Append("</root>");

            return s.ToString();
        }

        /// <summary>
        /// 创建线路服务标准XML
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        string CreateFuWuXml(MXianLuFuWuInfo info)
        {
            //服务标准XML:<root><info FuWuBiaoZhun="" BuHanXiangMu="" GouWuAnPai="" ErTongAnPai="" ZiFeiXiangMu="" ZhuYiShiXiang="" WenXinTiXing="" BaoMingXuZhi=""/></root>
            if (info == null) return string.Empty;

            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            s.Append("<info");
            s.AppendFormat(" FuWuBiaoZhun=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(info.FuWuBiaoZhun));
            s.AppendFormat(" BuHanXiangMu=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(info.BuHanXiangMu));
            s.AppendFormat(" GouWuAnPai=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(info.GouWuAnPai));
            s.AppendFormat(" ErTongAnPai=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(info.ErTongAnPai));
            s.AppendFormat(" ZiFeiXiangMu=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(info.ZiFeiXiangMu));
            s.AppendFormat(" ZhuYiShiXiang=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(info.ZhuYiShiXiang));
            s.AppendFormat(" WenXinTiXing=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(info.WenXinTiXing));
            s.AppendFormat(" BaoMingXuZhi=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(info.BaoMingXuZhi));
            s.AppendFormat(" ZengSongXiangMu=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(info.ZengSongXiangMu));
            s.AppendFormat(" QiTaShiXiang=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(info.QiTaShiXiang));

            s.Append("/>");
            s.Append("</root>");

            return s.ToString();
        }

        /// <summary>
        /// 创建线路主题Xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateZhuTiXml(IList<MXianLuZhuTiInfo> items)
        {
            //主题XML:<root><info ZhuTiId="" /></root>
            if (items == null || items.Count == 0) return string.Empty;

            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.AppendFormat("<info ZhuTiId=\"{0}\"/>", item.Id);
            }
            s.Append("</root>");

            return s.ToString();
        }

        /// <summary>
        /// 创建线路状态Xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateZhuangTaiXml(IList<XianLuZhuangTai> items)
        {
            //状态XML:<root><info Status="" /></root>
            if (items == null || items.Count == 0) return string.Empty;

            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.AppendFormat("<info Status=\"{0}\"/>", (int)item);
            }
            s.Append("</root>");

            return s.ToString();
        }

        /// <summary>
        /// 创建线路发班周期Xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateTourXml(IList<MXianLuTourInfo> items)
        {
            //发班周期XML:<root><info TourId="" LDate="" RDate="" Status="" SYRS="" TrafficId="" JSJCR="" JSJET="" /></root>
            if (items == null || items.Count == 0) return string.Empty;

            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.AppendFormat("<info TourId=\"{0}\" LDate=\"{1}\" RDate=\"{2}\" Status=\"{3}\" SYRS=\"{4}\" TrafficId=\"{5}\" JSJCR=\"{6}\" JSJET=\"{7}\" CRSCJ=\"{8}\" ETSCJ=\"{9}\"  />", item.TourId
                    , item.LDate
                    , item.RDate
                    , (int)item.Status
                    , item.SYRS
                    , item.TrafficId
                    , item.JSJCR
                    , item.JSJET
                    , item.CRSCJ
                    , item.ETSCJ);
            }
            s.Append("</root>");

            return s.ToString();
        }

        /// <summary>
        /// 创建图片Xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateFileXml(IList<MFileInfo> items)
        {
            //特色图片XML:<root><info FilePath="" MiaoShu="" /></root>
            if (items == null || items.Count == 0) return string.Empty;

            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.AppendFormat("<info FilePath=\"{0}\" MiaoShu=\"{1}\" />", item.FilePath
                    , Utils.ReplaceXmlSpecialCharacter(item.MiaoShu));
            }
            s.Append("</root>");

            return s.ToString();

        }
        /// <summary>
        /// 创建航班XML
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        string CreateTrafficXml(List<MXianLuTourTraffice> info)
        {
            //航班XML:<root><info XianLuId=\"{0}\" TrafficId=\"{1}\"  Traffic_01=\"{2}\"  Traffic_02=\"{3}\" /></root>
            if (info == null || info.Count == 0) return string.Empty;

            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var i in info)
            {
                s.AppendFormat("<info XianLuId=\"{0}\" TrafficId=\"{1}\"  Traffic_01=\"{2}\"  Traffic_02=\"{3}\" />"
                    , i.TourId
                    , i.TrafficId
                    , i.Traffic_01
                    , i.Traffic_02);
            }
            s.Append("</root>");

            return s.ToString();

        }
        /// <summary>
        /// 获取线路服务标准信息实体
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        MXianLuFuWuInfo GetXianLuFuWuInfo(string xianLuId)
        {
            MXianLuFuWuInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetXianLuFuWuInfo);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianLuId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MXianLuFuWuInfo();

                    info.BaoMingXuZhi = rdr["BaoMingXuZhi"].ToString();
                    info.BuHanXiangMu = rdr["BuHanXiangMu"].ToString();
                    info.ErTongAnPai = rdr["ErTongAnPai"].ToString();
                    info.FuWuBiaoZhun = rdr["FuWuBiaoZhun"].ToString();
                    info.GouWuAnPai = rdr["GouWuAnPai"].ToString();
                    info.WenXinTiXing = rdr["WenXinTiXing"].ToString();
                    info.ZhuYiShiXiang = rdr["ZhuYiShiXiang"].ToString();
                    info.ZiFeiXiangMu = rdr["ZiFeiXiangMu"].ToString();
                    info.ZengSongXiangMu = rdr["ZengSongXiangMu"].ToString();
                    info.QiTaShiXiang = rdr["QiTaShiXiang"].ToString();

                }
            }

            return info;
        }

        /// <summary>
        /// 获取线路发班周期信息集合
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        List<MXianLuTourInfo> GetXianLuTours(string xianLuId)
        {
            List<MXianLuTourInfo> items = new List<MXianLuTourInfo>();
            string query = "SELECT * FROM [view_XianLuTour] WHERE [XianLuId]=@XianLuId AND Status=0  AND LDate>GETDATE()   ORDER BY [LDate] ASC";
            DbCommand cmd = _db.GetSqlStringCommand(query);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianLuId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MXianLuTourInfo();
                    item.XianLuID = xianLuId;
                    item.LDate = Utils.GetDateTime(rdr.GetDateTime(rdr.GetOrdinal("LDate")).ToString("yyyy-MM-dd"));
                    item.RDate = rdr.GetDateTime(rdr.GetOrdinal("RDate"));
                    item.Status = (ShouKeZhuangTai)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.TourId = rdr.GetString(rdr.GetOrdinal("TourId"));
                    item.DingDanShu = rdr.IsDBNull(rdr.GetOrdinal("DingDanShu")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("DingDanShu"));
                    item.ShiShouRenShu = rdr.IsDBNull(rdr.GetOrdinal("ShiShouRenShu")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("ShiShouRenShu"));
                    item.YiShouRenShu = rdr.IsDBNull(rdr.GetOrdinal("YiShouRenShu")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("YiShouRenShu"));
                    item.JSJCR = rdr.IsDBNull(rdr.GetOrdinal("JSJCR")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("JSJCR"));
                    item.JSJET = rdr.IsDBNull(rdr.GetOrdinal("JSJET")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("JSJET"));
                    item.SYRS = rdr.IsDBNull(rdr.GetOrdinal("SYRS")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("SYRS"));
                    item.TrafficId = rdr.IsDBNull(rdr.GetOrdinal("TrafficId")) ? "" : rdr.GetString(rdr.GetOrdinal("TrafficId"));
                    item.CRSCJ = rdr.IsDBNull(rdr.GetOrdinal("CRSCJ")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("CRSCJ"));
                    item.ETSCJ = rdr.IsDBNull(rdr.GetOrdinal("ETSCJ")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("ETSCJ"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取线路行程信息集合
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        List<MXianLuXingChengInfo> GetXianLuXingChengs(string xianLuId)
        {
            List<MXianLuXingChengInfo> items = new List<MXianLuXingChengInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetXianLuXingChengs);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianLuId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MXianLuXingChengInfo();
                    item.FilePath = rdr["FilePath"].ToString();
                    item.JiaoTong = rdr["JiaoTong"].ToString();
                    item.QuJian = rdr["QuJian"].ToString();
                    item.XingCheng = rdr["XingCheng"].ToString();
                    item.YongCan = rdr["YongCan"].ToString();
                    item.ZhuSu = rdr["ZhuSu"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取线路状态信息集合
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        List<XianLuZhuangTai> GetXianLuZhuangTais(string xianLuId)
        {
            List<XianLuZhuangTai> items = new List<XianLuZhuangTai>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetXianLuZhuangTais);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianLuId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    items.Add((XianLuZhuangTai)rdr.GetInt32(rdr.GetOrdinal("Status")));
                }
            }

            return items;
        }

        /// <summary>
        /// 获取线路主题信息集合
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        List<MXianLuZhuTiInfo> GetXianLuZhuTis(string xianLuId)
        {
            List<MXianLuZhuTiInfo> items = new List<MXianLuZhuTiInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetXianLuZhuTis);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianLuId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    var item = new MXianLuZhuTiInfo();
                    item.Id = rdr.GetInt32(rdr.GetOrdinal("ZhuTiId"));
                    item.Name = rdr["Name"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取线路特色图片信息集合
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        List<MFileInfo> GetTeSeFiles(string xianLuId)
        {
            List<MFileInfo> items = new List<MFileInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetTeSeFiles);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianLuId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MFileInfo();
                    item.FilePath = rdr["FilePath"].ToString();
                    item.MiaoShu = rdr["MiaoShu"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }
        /// <summary>
        /// 获取线路特色图片信息集合
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        List<MXianLuTourTraffice> GetTourTraffice(string xianLuId)
        {
            List<MXianLuTourTraffice> items = new List<MXianLuTourTraffice>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetTourTraffice);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianLuId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MXianLuTourTraffice();
                    item.TourId = rdr["XianLuId"].ToString();
                    item.TrafficId = rdr["TrafficId"].ToString();
                    item.Traffic_01 = rdr["Traffic_01"].ToString();
                    item.Traffic_02 = rdr["Traffic_02"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 拼接查询SQL
        /// </summary>
        /// <param name="chaXun">查询实体</param>
        /// <param name="tName">主表名</param>
        /// <returns></returns>
        string PinJieChaXunSql(MXianLuChaXunInfo chaXun, string tName)
        {
            StringBuilder s = new StringBuilder();
            if (chaXun != null)
            {
                if (string.IsNullOrEmpty(tName)) tName = "view_XianLu";

                if (chaXun.IsYouXiaoTour)
                {
                    s.Append(" AND TourId IS NOT NULL ");
                }
                if (chaXun.AreaIds != null && chaXun.AreaIds.Length > 0)
                {
                    s.AppendFormat(" AND AreaId IN({0}) ", Utils.GetSqlIn(chaXun.AreaIds));
                }
                if (chaXun.Xianluzt != null && chaXun.Xianluzt.Length > 0)
                {
                    s.AppendFormat(" AND XianLuzt IN({0}) ", Utils.GetSqlIn(chaXun.Xianluzt));
                }
                if (chaXun.AreaTypes != null && chaXun.AreaTypes.Length > 0)
                {
                    s.AppendFormat(" AND AreaId IN(SELECT A1.ID FROM tbl_SysArea AS A1  WHERE A1.RouteType IN({0})) ", Utils.GetSqlIn(chaXun.AreaTypes));
                }
                if (chaXun.ArrCityIds != null && chaXun.ArrCityIds.Length > 0)
                {
                    s.AppendFormat(" AND ArrCityId IN({0}) ", Utils.GetSqlIn(chaXun.ArrCityIds));
                }
                if (chaXun.ArrProvinceIds != null && chaXun.ArrProvinceIds.Length > 0)
                {
                    s.AppendFormat(" AND ArrProvinceId IN({0}) ", Utils.GetSqlIn(chaXun.ArrProvinceIds));
                }
                if (chaXun.DepCityIds != null && chaXun.DepCityIds.Length > 0)
                {
                    s.AppendFormat(" AND DepCityId IN({0}) ", Utils.GetSqlIn(chaXun.DepCityIds));
                }
                if (chaXun.DepProvinceIds != null && chaXun.DepProvinceIds.Length > 0)
                {
                    s.AppendFormat(" AND DepProvinceId IN({0}) ", Utils.GetSqlIn(chaXun.DepProvinceIds));
                }
                if (chaXun.ELDate.HasValue || chaXun.SLDate.HasValue)
                {
                    s.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_XianLuTour AS A1 WHERE A1.XianLuId={0}.XianLuId ", tName);
                    if (chaXun.ELDate.HasValue)
                    {
                        s.AppendFormat(" AND A1.LDate< '{0}'", chaXun.ELDate.Value.AddDays(1));
                    }
                    if (chaXun.SLDate.HasValue)
                    {
                        s.AppendFormat(" AND A1.LDate>'{0}' ", chaXun.SLDate.Value.AddDays(-1));
                    }
                    s.Append(" ) ");
                }
                if (!string.IsNullOrEmpty(chaXun.RouteName))
                {
                    s.AppendFormat(" AND RouteName LIKE '%{0}%' ", chaXun.RouteName);
                }
                if (!string.IsNullOrEmpty(chaXun.ChuFaDi))
                {
                    s.AppendFormat(" AND (DepProvinceId IN (SELECT ID FROM tbl_SysProvince WHERE [Name] LIKE '%{0}%') ", chaXun.ChuFaDi);
                    s.AppendFormat("        OR DepCityId IN (SELECT ID FROM tbl_SysCity WHERE [Name] LIKE '%{0}%'))", chaXun.ChuFaDi);
                }
                if (chaXun.TianShu.HasValue)
                {
                    //如果当天数等于8，查询天数大于8的数据
                    if (chaXun.TianShu.Value >= 8)
                    {
                        s.AppendFormat(" AND TianShu>={0} ", chaXun.TianShu.Value);
                    }
                    else
                    {
                        s.AppendFormat(" AND TianShu={0} ", chaXun.TianShu.Value);
                    }
                }
                if (chaXun.ZhuangTais != null && chaXun.ZhuangTais.Length > 0)
                {
                    s.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_XianLuZhuangTai AS A1 WHERE A1.XianLuId={1}.XianLuId AND A1.Status IN({0})) ", Utils.GetSqlIn(chaXun.ZhuangTais), tName);
                }
                if (!string.IsNullOrEmpty(chaXun.ZhuTiName) || (chaXun.ZhuTis != null && chaXun.ZhuTis.Length > 0))
                {
                    s.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_XianLuZhuTi AS A1 WHERE A1.XianLuId={0}.XianLuId ", tName);
                    if (!string.IsNullOrEmpty(chaXun.ZhuTiName))
                    {
                        s.AppendFormat(" AND A1.ZhuTiId IN(SELECT Id FROM tbl_RouteTheme AS A2 WHERE A2.Name LIKE '%{0}%') ", chaXun.ZhuTiName);
                    }
                    if (chaXun.ZhuTis != null && chaXun.ZhuTis.Length > 0)
                    {
                        s.AppendFormat(" AND A1.ZhuTiId IN({0}) ", Utils.GetSqlIn(chaXun.ZhuTis));
                    }
                    s.Append(" ) ");
                }

                if (chaXun.IsTuanGou.HasValue)
                {
                    if (chaXun.IsTuanGou.Value)
                    {
                        s.AppendFormat(" AND EXISTS (SELECT 1 FROM tbl_XianLuTuanGou AS A1 WHERE A1.XianLuId={0}.XianLuId) ", tName);
                    }
                    else
                    {
                        s.AppendFormat(" AND NOT EXISTS (SELECT 1 FROM tbl_XianLuTuanGou AS A1 WHERE A1.XianLuId={0}.XianLuId) ", tName);
                    }
                }

                if (chaXun.TuanGouETime.HasValue || chaXun.TuanGouSTime.HasValue || chaXun.IsYouXiaoTuanGou.HasValue)
                {
                    s.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_XianLuTuanGou AS A1 WHERE A1.XianLuId={0}.XianLuId ", tName);

                    if (chaXun.IsYouXiaoTuanGou.HasValue)
                    {
                        //s.AppendFormat(" AND '{0}'  BETWEEN A1.STime AND A1.ETime ", DateTime.Now);
                        s.AppendFormat(" AND '{0}'<A1.ETime ", DateTime.Now);
                    }

                    if (chaXun.TuanGouETime.HasValue || chaXun.TuanGouSTime.HasValue)
                    {
                        s.Append(" AND (1=0 ");
                        if (chaXun.TuanGouETime.HasValue)
                        {
                            s.AppendFormat(" OR '{0}' BETWEEN A1.STime AND A1.ETime", chaXun.TuanGouETime.Value);
                        }
                        if (chaXun.TuanGouSTime.HasValue)
                        {
                            s.AppendFormat(" OR '{0}' BETWEEN A1.STime AND A1.ETime", chaXun.TuanGouSTime.Value);
                        }
                        s.Append(" ) ");
                    }

                    s.Append(" ) ");
                }
                if (chaXun.sPrice > 0)
                {
                    s.AppendFormat(" AND SCJCR >= '{0}' ", chaXun.sPrice);
                }
                if (chaXun.ePrice > 0)
                {
                    s.AppendFormat(" AND SCJCR <= '{0}' ", chaXun.ePrice);
                }
                if (chaXun.LineSource.HasValue) s.AppendFormat(" and Line_Source={0}", (int)chaXun.LineSource);
                if (chaXun.isNoTour) s.AppendFormat(" and  LDate > GETDATE()");
            }

            return s.ToString();
        }

        /// <summary>
        /// 获取线路团购信息集合
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        List<MXianLuTuanGouInfo> GetXianLuTuanGous(string xianLuId)
        {
            List<MXianLuTuanGouInfo> items = new List<MXianLuTuanGouInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetXianLuTuanGous);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianLuId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MXianLuTuanGouInfo();

                    item.ETime = rdr.GetDateTime(rdr.GetOrdinal("ETime"));
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JSJCR = rdr.GetDecimal(rdr.GetOrdinal("JSJCR"));
                    item.JSJET = rdr.GetDecimal(rdr.GetOrdinal("JSJET"));
                    item.LatestId = rdr.GetInt32(rdr.GetOrdinal("LatestId"));
                    item.LatestTime = rdr.GetDateTime(rdr.GetOrdinal("LatestTime"));
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.RenShu = rdr.GetInt32(rdr.GetOrdinal("RenShu"));
                    item.SCJCR = rdr.GetDecimal(rdr.GetOrdinal("SCJCR"));
                    item.SCJET = rdr.GetDecimal(rdr.GetOrdinal("SCJET"));
                    item.STime = rdr.GetDateTime(rdr.GetOrdinal("STime"));
                    item.TuanGouId = rdr.GetString(rdr.GetOrdinal("TuanGouId"));
                    item.XiangQing = rdr["XiangQing"].ToString();
                    item.XianLuId = xianLuId;
                    item.ZheKou = rdr.GetDecimal(rdr.GetOrdinal("ZheKou"));
                    item.ShiShouRenShu = rdr.GetInt32(rdr.GetOrdinal("ShiShouRenShu"));
                    item.YiShouRenShu = rdr.GetInt32(rdr.GetOrdinal("YiShouRenShu"));
                    item.DingDanShu = rdr.GetInt32(rdr.GetOrdinal("DingDanShu"));
                    item.TuanName = rdr["TuanName"].ToString();
                    item.JianYaoMiaoShu = rdr["JianYaoMiaoShu"].ToString();
                    item.FilePath = rdr["FilePath"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region EyouSoft.IDAL.XianLuStructure.IXianLu 成员

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="InterfaceID"></param>
        /// <returns></returns>
        public string ExistsInterfaceID(string InterfaceID, EyouSoft.Model.XianLuStructure.LineSource LineSource)
        {
            string returnVal = "";
            #region sql
            StringBuilder sql = new StringBuilder();
            sql.Append("select [XianLuId] from [tbl_XianLu]");
            sql.Append("where [InterfaceID]=@InterfaceID and Line_Source=@Line_Source");
            #endregion
            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());
            _db.AddInParameter(cmd, "InterfaceID", DbType.String, InterfaceID);
            _db.AddInParameter(cmd, "Line_Source", DbType.Byte, (int)LineSource);
            object obj = DbHelper.GetSingle(cmd, _db);
            if (obj != null && obj != DBNull.Value)
            { returnVal = obj.ToString(); }
            return returnVal;
        }

        /// <summary>
        /// 写入线路产品信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MXianLuInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_XianLu_Insert");

            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, info.XianLuId);
            _db.AddInParameter(cmd, "InterfaceID", DbType.String, info.LineID);
            _db.AddInParameter(cmd, "AreaName", DbType.String, info.AreaName);
            _db.AddInParameter(cmd, "AreaId", DbType.Int32, info.AreaId);
            _db.AddInParameter(cmd, "RouteName", DbType.String, info.RouteName);
            _db.AddInParameter(cmd, "TianShu", DbType.Int32, info.TianShu);
            _db.AddInParameter(cmd, "DepProvinceId", DbType.Int32, info.DepProvinceId);
            _db.AddInParameter(cmd, "DepCityId", DbType.Int32, info.DepCityId);
            _db.AddInParameter(cmd, "ArrProvinceId", DbType.Int32, info.ArrProvinceId);
            _db.AddInParameter(cmd, "ArrCityId", DbType.Int32, info.ArrCityId);
            _db.AddInParameter(cmd, "JiHuaRenShu", DbType.Int32, info.JiHuaRenShu);
            _db.AddInParameter(cmd, "SCJCR", DbType.Decimal, info.SCJCR);
            _db.AddInParameter(cmd, "SCJET", DbType.Decimal, info.SCJET);
            _db.AddInParameter(cmd, "JSJCR", DbType.Decimal, info.JSJCR);
            _db.AddInParameter(cmd, "JSJET", DbType.Decimal, info.JSJET);
            _db.AddInParameter(cmd, "TingTianShu", DbType.Int32, info.TingTianShu);
            _db.AddInParameter(cmd, "ChuFaJiaoTong", DbType.String, info.ChuFaJiaoTong);
            _db.AddInParameter(cmd, "FanChengJiaoTong", DbType.String, info.FanChengJiaoTong);
            _db.AddInParameter(cmd, "JiHeFangShi", DbType.String, info.JiHeFangShi);
            _db.AddInParameter(cmd, "TeSe", DbType.String, info.TeSe);
            _db.AddInParameter(cmd, "TeSeFilePath", DbType.String, info.TeSeFilePath);
            _db.AddInParameter(cmd, "TuJing", DbType.String, info.TuJing);
            _db.AddInParameter(cmd, "QianZheng", DbType.String, info.QianZheng);
            _db.AddInParameter(cmd, "QianZhengFilePath", DbType.String, info.QianZhengFilePath);
            _db.AddInParameter(cmd, "GuanZhuShu", DbType.Int32, info.GuanZhuShu);
            _db.AddInParameter(cmd, "LxrName", DbType.String, info.LxrName);
            _db.AddInParameter(cmd, "LxrTelephone", DbType.String, info.LxrTelephone);
            _db.AddInParameter(cmd, "LxrQQ", DbType.String, info.LxrQQ);
            _db.AddInParameter(cmd, "LxrMobile", DbType.String, info.LxrMobile);
            _db.AddInParameter(cmd, "Description", DbType.String, info.Description);
            _db.AddInParameter(cmd, "Keywords", DbType.String, info.Keywords);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "LatestId", DbType.Int32, info.LatestId);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, info.LatestTime);
            _db.AddInParameter(cmd, "XingChengXML", DbType.String, CreateXingChengXml(info.XingChengs));
            _db.AddInParameter(cmd, "FuWuXml", DbType.String, CreateFuWuXml(info.FuWu));
            _db.AddInParameter(cmd, "ZhuTiXml", DbType.String, CreateZhuTiXml(info.ZhuTis));
            _db.AddInParameter(cmd, "ZhuangTaiXml", DbType.String, CreateZhuangTaiXml(info.ZhuangTais));
            _db.AddInParameter(cmd, "TourXml", DbType.String, CreateTourXml(info.Tours));
            _db.AddInParameter(cmd, "TeSeFileXml", DbType.String, CreateFileXml(info.TeSeFiles));
            _db.AddInParameter(cmd, "Line_Source", DbType.Byte, info.Line_Source);
            _db.AddInParameter(cmd, "LineType", DbType.Byte, info.LineType);
            _db.AddInParameter(cmd, "TourTraffice", DbType.String, CreateTrafficXml(info.TourTraffice));
            _db.AddInParameter(cmd, "CFCS", DbType.String, info.CFCS);


            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);

            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 获取线路产品信息业务实体
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        public MXianLuInfo GetInfo(string xianLuId)
        {
            MXianLuInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianLuId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MXianLuInfo();

                    info.AreaId = rdr.GetInt32(rdr.GetOrdinal("AreaId"));
                    info.ArrCityId = rdr.GetInt32(rdr.GetOrdinal("ArrCityId"));
                    info.ArrProvinceId = rdr.GetInt32(rdr.GetOrdinal("ArrProvinceId"));
                    info.ChuFaJiaoTong = rdr["ChuFaJiaoTong"].ToString();
                    info.DepCityId = rdr.GetInt32(rdr.GetOrdinal("DepCityId"));
                    info.DepProvinceId = rdr.GetInt32(rdr.GetOrdinal("DepProvinceId"));
                    info.Description = rdr["Description"].ToString();
                    info.FanChengJiaoTong = rdr["FanChengJiaoTong"].ToString();
                    info.FuWu = null;
                    info.GuanZhuShu = rdr.GetInt32(rdr.GetOrdinal("GuanZhuShu"));
                    info.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JiHeFangShi = rdr["JiHeFangShi"].ToString();
                    info.JiHuaRenShu = rdr.GetInt32(rdr.GetOrdinal("JiHuaRenShu"));
                    info.JSJCR = rdr.IsDBNull(rdr.GetOrdinal("JSJCR")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("JSJCR"));
                    info.JSJET = rdr.IsDBNull(rdr.GetOrdinal("JSJET")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("JSJET"));
                    info.Keywords = rdr["Keywords"].ToString();
                    info.LatestId = rdr.GetInt32(rdr.GetOrdinal("LatestId"));
                    info.LatestTime = rdr.GetDateTime(rdr.GetOrdinal("LatestTime"));
                    info.LxrMobile = rdr["LxrMobile"].ToString();
                    info.LxrName = rdr["LxrName"].ToString();
                    info.LxrQQ = rdr["LxrQQ"].ToString();
                    info.LxrTelephone = rdr["LxrTelephone"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.QianZheng = rdr["QianZheng"].ToString();
                    info.QianZhengFilePath = rdr["QianZhengFilePath"].ToString();
                    info.RouteName = rdr["RouteName"].ToString();
                    info.SCJCR = rdr.IsDBNull(rdr.GetOrdinal("SCJCR")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("SCJCR"));
                    info.SCJET = rdr.IsDBNull(rdr.GetOrdinal("SCJET")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("SCJET"));
                    info.TeSe = rdr["TeSe"].ToString();
                    info.TeSeFilePath = rdr["TeSeFilePath"].ToString();
                    info.TeSeFiles = null;
                    info.TianShu = rdr.GetInt32(rdr.GetOrdinal("TianShu"));
                    info.TingTianShu = rdr.GetInt32(rdr.GetOrdinal("TingTianShu"));
                    info.Tours = null;
                    info.TuJing = rdr["TuJing"].ToString();
                    info.XianLuId = xianLuId;
                    info.XingChengs = null;
                    info.ZhuangTais = null;
                    info.ZhuTis = null;
                    info.Line_Source = (LineSource)rdr.GetByte(rdr.GetOrdinal("Line_Source"));
                    info.LineType = (LineType)rdr.GetByte(rdr.GetOrdinal("LineType"));
                    info.CFCS = rdr["CFCS"].ToString();
                    info.LineID = rdr["InterfaceID"].ToString();
                    info.xianluZT = (XianLuZT)rdr.GetInt32(rdr.GetOrdinal("XianLuZT"));


                }
            }

            if (info != null)
            {
                info.FuWu = GetXianLuFuWuInfo(xianLuId);
                info.TeSeFiles = GetTeSeFiles(xianLuId);
                info.Tours = GetXianLuTours(xianLuId);
                info.XingChengs = GetXianLuXingChengs(xianLuId);
                info.ZhuangTais = GetXianLuZhuangTais(xianLuId);
                info.ZhuTis = GetXianLuZhuTis(xianLuId);

                info.TuanGous = GetXianLuTuanGous(xianLuId);
                info.TourTraffice = GetTourTraffice(xianLuId);

                if (info.Line_Source != LineSource.系统 && string.IsNullOrEmpty(info.TeSeFilePath))
                {
                    info.XingChengs = GetXianLuXingChengs(info.XianLuId);
                    if (info.XingChengs.Count > 0)
                        info.TeSeFilePath = info.XingChengs[0].FilePath;
                }
            }

            return info;
        }

        /// <summary>
        /// 更新接口线路产品信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int OutUpdate(MXianLuInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_XianLu_OutUpdate");

            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, info.XianLuId);
            _db.AddInParameter(cmd, "InterfaceID", DbType.String, info.LineID);
            _db.AddInParameter(cmd, "AreaName", DbType.String, info.AreaName);
            _db.AddInParameter(cmd, "AreaId", DbType.Int32, info.AreaId);
            _db.AddInParameter(cmd, "RouteName", DbType.String, info.RouteName);
            _db.AddInParameter(cmd, "TianShu", DbType.Int32, info.TianShu);
            _db.AddInParameter(cmd, "DepProvinceId", DbType.Int32, info.DepProvinceId);
            _db.AddInParameter(cmd, "DepCityId", DbType.Int32, info.DepCityId);
            _db.AddInParameter(cmd, "ArrProvinceId", DbType.Int32, info.ArrProvinceId);
            _db.AddInParameter(cmd, "ArrCityId", DbType.Int32, info.ArrCityId);
            _db.AddInParameter(cmd, "JiHuaRenShu", DbType.Int32, info.JiHuaRenShu);
            _db.AddInParameter(cmd, "SCJCR", DbType.Decimal, info.SCJCR);
            _db.AddInParameter(cmd, "SCJET", DbType.Decimal, info.SCJET);
            _db.AddInParameter(cmd, "JSJCR", DbType.Decimal, info.JSJCR);
            _db.AddInParameter(cmd, "JSJET", DbType.Decimal, info.JSJET);
            _db.AddInParameter(cmd, "TingTianShu", DbType.Int32, info.TingTianShu);
            _db.AddInParameter(cmd, "ChuFaJiaoTong", DbType.String, info.ChuFaJiaoTong);
            _db.AddInParameter(cmd, "FanChengJiaoTong", DbType.String, info.FanChengJiaoTong);
            _db.AddInParameter(cmd, "JiHeFangShi", DbType.String, info.JiHeFangShi);
            _db.AddInParameter(cmd, "TeSe", DbType.String, info.TeSe);
            _db.AddInParameter(cmd, "TeSeFilePath", DbType.String, info.TeSeFilePath);
            _db.AddInParameter(cmd, "TuJing", DbType.String, info.TuJing);
            _db.AddInParameter(cmd, "QianZheng", DbType.String, info.QianZheng);
            _db.AddInParameter(cmd, "QianZhengFilePath", DbType.String, info.QianZhengFilePath);
            _db.AddInParameter(cmd, "GuanZhuShu", DbType.Int32, info.GuanZhuShu);
            _db.AddInParameter(cmd, "LxrName", DbType.String, info.LxrName);
            _db.AddInParameter(cmd, "LxrTelephone", DbType.String, info.LxrTelephone);
            _db.AddInParameter(cmd, "LxrQQ", DbType.String, info.LxrQQ);
            _db.AddInParameter(cmd, "LxrMobile", DbType.String, info.LxrMobile);
            _db.AddInParameter(cmd, "Description", DbType.String, info.Description);
            _db.AddInParameter(cmd, "Keywords", DbType.String, info.Keywords);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "LatestId", DbType.Int32, info.LatestId);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, info.LatestTime);
            _db.AddInParameter(cmd, "XingChengXML", DbType.String, CreateXingChengXml(info.XingChengs));
            _db.AddInParameter(cmd, "FuWuXml", DbType.String, CreateFuWuXml(info.FuWu));
            _db.AddInParameter(cmd, "ZhuTiXml", DbType.String, CreateZhuTiXml(info.ZhuTis));
            _db.AddInParameter(cmd, "ZhuangTaiXml", DbType.String, CreateZhuangTaiXml(info.ZhuangTais));
            _db.AddInParameter(cmd, "TourXml", DbType.String, CreateTourXml(info.Tours));
            _db.AddInParameter(cmd, "TeSeFileXml", DbType.String, CreateFileXml(info.TeSeFiles));
            _db.AddInParameter(cmd, "TourTraffice", DbType.String, CreateTrafficXml(info.TourTraffice));
            _db.AddInParameter(cmd, "CFCS", DbType.String, info.CFCS);
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);

            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 更新线路产品信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MXianLuInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_XianLu_Update");

            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, info.XianLuId);
            _db.AddInParameter(cmd, "InterfaceID", DbType.String, info.LineID);
            _db.AddInParameter(cmd, "AreaName", DbType.String, info.AreaName);
            _db.AddInParameter(cmd, "AreaId", DbType.Int32, info.AreaId);
            _db.AddInParameter(cmd, "RouteName", DbType.String, info.RouteName);
            _db.AddInParameter(cmd, "TianShu", DbType.Int32, info.TianShu);
            _db.AddInParameter(cmd, "DepProvinceId", DbType.Int32, info.DepProvinceId);
            _db.AddInParameter(cmd, "DepCityId", DbType.Int32, info.DepCityId);
            _db.AddInParameter(cmd, "ArrProvinceId", DbType.Int32, info.ArrProvinceId);
            _db.AddInParameter(cmd, "ArrCityId", DbType.Int32, info.ArrCityId);
            _db.AddInParameter(cmd, "JiHuaRenShu", DbType.Int32, info.JiHuaRenShu);
            _db.AddInParameter(cmd, "SCJCR", DbType.Decimal, info.SCJCR);
            _db.AddInParameter(cmd, "SCJET", DbType.Decimal, info.SCJET);
            _db.AddInParameter(cmd, "JSJCR", DbType.Decimal, info.JSJCR);
            _db.AddInParameter(cmd, "JSJET", DbType.Decimal, info.JSJET);
            _db.AddInParameter(cmd, "TingTianShu", DbType.Int32, info.TingTianShu);
            _db.AddInParameter(cmd, "ChuFaJiaoTong", DbType.String, info.ChuFaJiaoTong);
            _db.AddInParameter(cmd, "FanChengJiaoTong", DbType.String, info.FanChengJiaoTong);
            _db.AddInParameter(cmd, "JiHeFangShi", DbType.String, info.JiHeFangShi);
            _db.AddInParameter(cmd, "TeSe", DbType.String, info.TeSe);
            _db.AddInParameter(cmd, "TeSeFilePath", DbType.String, info.TeSeFilePath);
            _db.AddInParameter(cmd, "TuJing", DbType.String, info.TuJing);
            _db.AddInParameter(cmd, "QianZheng", DbType.String, info.QianZheng);
            _db.AddInParameter(cmd, "QianZhengFilePath", DbType.String, info.QianZhengFilePath);
            _db.AddInParameter(cmd, "GuanZhuShu", DbType.Int32, info.GuanZhuShu);
            _db.AddInParameter(cmd, "LxrName", DbType.String, info.LxrName);
            _db.AddInParameter(cmd, "LxrTelephone", DbType.String, info.LxrTelephone);
            _db.AddInParameter(cmd, "LxrQQ", DbType.String, info.LxrQQ);
            _db.AddInParameter(cmd, "LxrMobile", DbType.String, info.LxrMobile);
            _db.AddInParameter(cmd, "Description", DbType.String, info.Description);
            _db.AddInParameter(cmd, "Keywords", DbType.String, info.Keywords);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "LatestId", DbType.Int32, info.LatestId);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, info.LatestTime);
            _db.AddInParameter(cmd, "XingChengXML", DbType.String, CreateXingChengXml(info.XingChengs));
            _db.AddInParameter(cmd, "FuWuXml", DbType.String, CreateFuWuXml(info.FuWu));
            _db.AddInParameter(cmd, "ZhuTiXml", DbType.String, CreateZhuTiXml(info.ZhuTis));
            _db.AddInParameter(cmd, "ZhuangTaiXml", DbType.String, CreateZhuangTaiXml(info.ZhuangTais));
            _db.AddInParameter(cmd, "TourXml", DbType.String, CreateTourXml(info.Tours));
            _db.AddInParameter(cmd, "TeSeFileXml", DbType.String, CreateFileXml(info.TeSeFiles));
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);

            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 删除线路产品信息，返回1成功，其它失败
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        public int Delete(string xianLuId)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_XianLu_Delete");

            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianLuId);
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);

            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 获取线路产品信息集合，分页
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns></returns>
        public IList<MXianLuInfo> GetXianLus(int pageSize, int pageIndex, ref int recordCount, MXianLuChaXunInfo chaXun)
        {
            IList<MXianLuInfo> items = new List<MXianLuInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "view_XianLu";
            string orderByString = "  LDate ASC";
            string sumString = "";

            #region fields
            fields.Append(" DepCityId,AreaId,XianLuId,RouteName,GuanZhuShu,SCJCR,SCJET,JSJCR,JSJET,TingTianShu,TeSe,TeSeFilePath,TianShu,JiHuaRenShu,IssueTime,ManYiDu,DianPingShu,JSJCR1,JSJET1,Line_Source, LineType,CFCS,XianLuZT");
            #endregion

            #region sql where
            query.Append(" 1=1 ");
            query.Append(PinJieChaXunSql(chaXun, tableName));
            #endregion

            #region paixu
            if (chaXun != null && chaXun.PaiXuLeiXing > 0)
            {
                switch (chaXun.PaiXuLeiXing)
                {
                    case 1: orderByString = "LDate DESC"; break;
                    case 2: orderByString = "SCJCR ASC"; break;
                    case 3: orderByString = "SCJCR DESC"; break;
                    case 4: orderByString = "IssueTime asc"; break;
                    case 5: orderByString = "IssueTime desc"; break;
                    default: break;
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MXianLuInfo();

                    item.XianLuId = rdr.GetString(rdr.GetOrdinal("XianLuId"));
                    item.RouteName = rdr["RouteName"].ToString();
                    item.GuanZhuShu = rdr.GetInt32(rdr.GetOrdinal("GuanZhuShu"));
                    item.SCJCR = rdr.IsDBNull(rdr.GetOrdinal("SCJCR")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("SCJCR"));
                    item.SCJET = rdr.IsDBNull(rdr.GetOrdinal("SCJET")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("SCJET"));

                    if (rdr.IsDBNull(rdr.GetOrdinal("JSJCR1")))
                        item.JSJCR = rdr.IsDBNull(rdr.GetOrdinal("JSJCR")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("JSJCR"));
                    else
                        item.JSJCR = rdr.GetDecimal(rdr.GetOrdinal("JSJCR1"));

                    if (rdr.IsDBNull(rdr.GetOrdinal("JSJET1")))
                        item.JSJET = rdr.IsDBNull(rdr.GetOrdinal("JSJET")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("JSJET"));
                    else
                        item.JSJET = rdr.GetDecimal(rdr.GetOrdinal("JSJET1"));

                    item.TingTianShu = rdr.GetInt32(rdr.GetOrdinal("TingTianShu"));
                    item.TeSe = rdr["TeSe"].ToString();
                    item.TeSeFilePath = rdr["TeSeFilePath"].ToString();
                    item.TianShu = rdr.GetInt32(rdr.GetOrdinal("TianShu"));
                    item.JiHuaRenShu = rdr.GetInt32(rdr.GetOrdinal("JiHuaRenShu"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.AreaId = rdr.GetInt32(rdr.GetOrdinal("AreaId"));
                    item.ManYiDu = !rdr.IsDBNull(rdr.GetOrdinal("ManYiDu")) ? rdr.GetDecimal(rdr.GetOrdinal("ManYiDu")) : 0;
                    item.DianPingShu = rdr.GetInt32(rdr.GetOrdinal("DianPingShu"));
                    item.DepCityId = rdr.GetInt32(rdr.GetOrdinal("DepCityId"));
                    item.Line_Source = (LineSource)rdr.GetByte(rdr.GetOrdinal("Line_Source"));
                    item.LineType = (LineType)rdr.GetByte(rdr.GetOrdinal("LineType"));
                    item.CFCS = !rdr.IsDBNull(rdr.GetOrdinal("CFCS")) ? rdr.GetString(rdr.GetOrdinal("CFCS")) : "";
                    item.xianluZT = (XianLuZT)rdr.GetInt32(rdr.GetOrdinal("XianLuZT"));



                    if (item.Line_Source != LineSource.系统 && string.IsNullOrEmpty(item.TeSeFilePath))
                    {
                        item.TeSeFiles = GetTeSeFiles(item.XianLuId);
                        item.XingChengs = GetXianLuXingChengs(item.XianLuId);
                        if (item.XingChengs.Count > 0)
                            item.TeSeFilePath = item.XingChengs[0].FilePath;
                    }



                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {

                }
            }

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.Tours = GetXianLuTours(item.XianLuId);
                    item.ZhuangTais = GetXianLuZhuangTais(item.XianLuId);
                    item.TuanGous = GetXianLuTuanGous(item.XianLuId);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取线路产品信息集合，SELECT TOP(expression) 
        /// </summary>
        /// <param name="topExpression">指定返回行数的数值表达式</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns></returns>
        public IList<MXianLuInfo> GetXianLus(int topExpression, MXianLuChaXunInfo chaXun)
        {
            IList<MXianLuInfo> items = new List<MXianLuInfo>();
            #region sql
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT TOP(@TopExpression) ");
            sql.Append(" XianLuId,RouteName,GuanZhuShu,SCJCR,SCJET,JSJCR,JSJET,TingTianShu,TeSe,TeSeFilePath,TianShu,JiHuaRenShu,IssueTime,ManYiDu,DianPingShu,JSJCR1,JSJET1,Line_Source ");
            sql.Append(" FROM view_XianLu ");
            sql.Append(" WHERE 1=1 and ProductSort>0 AND AreaId>0 ");
            sql.Append(PinJieChaXunSql(chaXun, "view_XianLu"));
            sql.Append(" ORDER BY  ProductSort Asc,  LDate ASC");
            #endregion

            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());
            _db.AddInParameter(cmd, "TopExpression", DbType.Int32, topExpression);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MXianLuInfo();

                    item.XianLuId = rdr.GetString(rdr.GetOrdinal("XianLuId"));
                    item.RouteName = rdr["RouteName"].ToString();
                    item.GuanZhuShu = rdr.GetInt32(rdr.GetOrdinal("GuanZhuShu"));
                    item.SCJCR = rdr.GetDecimal(rdr.GetOrdinal("SCJCR"));
                    item.SCJET = rdr.GetDecimal(rdr.GetOrdinal("SCJET"));
                    if (rdr.IsDBNull(rdr.GetOrdinal("JSJCR1")))
                        item.JSJCR = rdr.GetDecimal(rdr.GetOrdinal("JSJCR"));
                    else
                        item.JSJCR = rdr.GetDecimal(rdr.GetOrdinal("JSJCR1"));

                    if (rdr.IsDBNull(rdr.GetOrdinal("JSJET1")))
                        item.JSJET = rdr.GetDecimal(rdr.GetOrdinal("JSJET"));
                    else
                        item.JSJET = rdr.GetDecimal(rdr.GetOrdinal("JSJET1"));

                    item.TingTianShu = rdr.GetInt32(rdr.GetOrdinal("TingTianShu"));
                    item.TeSe = rdr["TeSe"].ToString();
                    item.TeSeFilePath = rdr["TeSeFilePath"].ToString();
                    item.TianShu = rdr.GetInt32(rdr.GetOrdinal("TianShu"));
                    item.JiHuaRenShu = rdr.GetInt32(rdr.GetOrdinal("JiHuaRenShu"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.ManYiDu = !rdr.IsDBNull(rdr.GetOrdinal("ManYiDu")) ? rdr.GetDecimal(rdr.GetOrdinal("ManYiDu")) : 0;
                    item.DianPingShu = rdr.GetInt32(rdr.GetOrdinal("DianPingShu"));
                    item.Line_Source = (LineSource)rdr.GetByte(rdr.GetOrdinal("Line_Source"));
                    items.Add(item);
                }
            }

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.Tours = GetXianLuTours(item.XianLuId);
                    item.ZhuangTais = GetXianLuZhuangTais(item.XianLuId);
                    item.TuanGous = GetXianLuTuanGous(item.XianLuId);
                    if (item.Line_Source != LineSource.系统 && string.IsNullOrEmpty(item.TeSeFilePath))
                    {
                        item.XingChengs = GetXianLuXingChengs(item.XianLuId);
                        if (item.XingChengs.Count > 0)
                            item.TeSeFilePath = item.XingChengs[0].FilePath;
                    }
                }
            }

            return items;
        }

        /// <summary>
        /// 增加关注数
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <param name="expression">增加数量的数值表达式</param>
        /// <returns></returns>
        public bool JiaGuanZhuShu(string xianLuId, int expression)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_JiaGuanZhuShu);
            _db.AddInParameter(cmd, "Expression", DbType.Int32, expression);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianLuId);

            return DbHelper.ExecuteSql(cmd, _db) > 0;
        }

        /// <summary>
        /// 设置线路状态
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <param name="zhuangTais">状态数组</param>
        /// <returns></returns>
        public bool SheZhiZhuangTai(string xianLuId, XianLuZhuangTai[] zhuangTais)
        {
            DbCommand cmd = _db.GetSqlStringCommand("SELECT 1");
            StringBuilder sql = new StringBuilder();
            for (int i = 0; i < zhuangTais.Length; i++)
            {
                sql.AppendFormat(" IF NOT EXISTS(SELECT 1 FROM tbl_XianLuZhuangTai WHERE XianLuId=@XianLuId AND [Status]=@Status{0}) ", i);
                sql.Append(" BEGIN ");
                sql.AppendFormat(" INSERT INTO [tbl_XianLuZhuangTai]([XianLuId],[Status])VALUES(@XianLuId,@Status{0}) ", i);
                sql.AppendFormat(" END; ");

                _db.AddInParameter(cmd, "Status" + i, DbType.Byte, zhuangTais[i]);
            }
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianLuId);
            cmd.CommandText = sql.ToString();

            return DbHelper.ExecuteSql(cmd, _db) > 0;
        }

        /// <summary>
        /// 删除线路状态
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        public bool DeleteZhuangTai(string xianLuId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_DeleteZhuangTai);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianLuId);

            DbHelper.ExecuteSql(cmd, _db);

            return true;
        }

        /// <summary>
        /// 写入团购信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertTuanGou(MXianLuTuanGouInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_XianLuTuanGou_Insert");
            _db.AddInParameter(cmd, "TuanGouId", DbType.AnsiStringFixedLength, info.TuanGouId);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, info.XianLuId);
            _db.AddInParameter(cmd, "STime", DbType.DateTime, info.STime);
            _db.AddInParameter(cmd, "ETime", DbType.DateTime, info.ETime);
            _db.AddInParameter(cmd, "RenShu", DbType.Int32, info.RenShu);
            _db.AddInParameter(cmd, "SCJCR", DbType.Decimal, info.SCJCR);
            _db.AddInParameter(cmd, "SCJET", DbType.Decimal, info.SCJET);
            _db.AddInParameter(cmd, "ZheKou", DbType.Decimal, info.ZheKou);
            _db.AddInParameter(cmd, "JSJCR", DbType.Decimal, info.JSJCR);
            _db.AddInParameter(cmd, "JSJET", DbType.Decimal, info.JSJET);
            _db.AddInParameter(cmd, "XiangQing", DbType.String, info.XiangQing);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "LatestId", DbType.Int32, info.LatestId);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, info.LatestTime);
            _db.AddInParameter(cmd, "TuanName", DbType.String, info.TuanName);
            _db.AddInParameter(cmd, "JianYaoMiaoShu", DbType.String, info.JianYaoMiaoShu);
            _db.AddInParameter(cmd, "FilePath", DbType.String, info.FilePath);
            _db.AddInParameter(cmd, "FileXml", DbType.String, CreateFileXml(info.Files));

            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);

            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 更新团购信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int UpdateTuanGou(MXianLuTuanGouInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_XianLuTuanGou_Update");
            _db.AddInParameter(cmd, "TuanGouId", DbType.AnsiStringFixedLength, info.TuanGouId);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, info.XianLuId);
            _db.AddInParameter(cmd, "STime", DbType.DateTime, info.STime);
            _db.AddInParameter(cmd, "ETime", DbType.DateTime, info.ETime);
            _db.AddInParameter(cmd, "RenShu", DbType.Int32, info.RenShu);
            _db.AddInParameter(cmd, "SCJCR", DbType.Decimal, info.SCJCR);
            _db.AddInParameter(cmd, "SCJET", DbType.Decimal, info.SCJET);
            _db.AddInParameter(cmd, "ZheKou", DbType.Decimal, info.ZheKou);
            _db.AddInParameter(cmd, "JSJCR", DbType.Decimal, info.JSJCR);
            _db.AddInParameter(cmd, "JSJET", DbType.Decimal, info.JSJET);
            _db.AddInParameter(cmd, "XiangQing", DbType.String, info.XiangQing);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "LatestId", DbType.Int32, info.LatestId);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, info.LatestTime);
            _db.AddInParameter(cmd, "TuanName", DbType.String, info.TuanName);
            _db.AddInParameter(cmd, "JianYaoMiaoShu", DbType.String, info.JianYaoMiaoShu);
            _db.AddInParameter(cmd, "FilePath", DbType.String, info.FilePath);
            _db.AddInParameter(cmd, "FileXml", DbType.String, CreateFileXml(info.Files));
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);

            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 删除团购信息，返回1成功，其它失败
        /// </summary>
        /// <param name="tuanGouId">团购编号</param>
        /// <returns></returns>
        public int DeleteTuanGou(string tuanGouId)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_XianLuTuanGou_Delete");
            _db.AddInParameter(cmd, "TuanGouId", DbType.AnsiStringFixedLength, tuanGouId);
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);

            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 获取线路团购信息集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <returns></returns>
        public IList<MXianLuTuanGouInfo> GetTuanGous(int pageSize, int pageIndex, ref int recordCount, MXianLuTuanGouChaXunInfo chaXun)
        {
            IList<MXianLuTuanGouInfo> items = new List<MXianLuTuanGouInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "view_XianLuTuanGou";
            string orderByString = "IdentityId ASC";
            string sumString = "";

            #region fields
            fields.Append(" * ");
            #endregion

            #region sql where
            query.Append(" 1=1 ");
            if (chaXun != null)
            {
                if (chaXun.ETime.HasValue)
                {
                    query.AppendFormat(" AND '{0}' BETWEEN STime AND ETime ", chaXun.ETime.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.RouteName))
                {
                    query.AppendFormat(" AND RouteName LIKE '%{0}%' ", chaXun.RouteName);
                }
                if (chaXun.STime.HasValue)
                {
                    query.AppendFormat(" AND '{0}' BETWEEN STime AND ETime ", chaXun.STime.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.XianLuId))
                {
                    query.AppendFormat(" AND XianLuId='{0}' ", chaXun.XianLuId);
                }
                if (!string.IsNullOrEmpty(chaXun.TuanName))
                {
                    query.AppendFormat(" AND TuanName LIKE '%{0}%'", chaXun.TuanName);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MXianLuTuanGouInfo();

                    item.ETime = rdr.GetDateTime(rdr.GetOrdinal("ETime"));
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JSJCR = rdr.GetDecimal(rdr.GetOrdinal("JSJCR"));
                    item.JSJET = rdr.GetDecimal(rdr.GetOrdinal("JSJET"));
                    item.LatestId = rdr.GetInt32(rdr.GetOrdinal("LatestId"));
                    item.LatestTime = rdr.GetDateTime(rdr.GetOrdinal("LatestTime"));
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.RenShu = rdr.GetInt32(rdr.GetOrdinal("RenShu"));
                    item.SCJCR = rdr.GetDecimal(rdr.GetOrdinal("SCJCR"));
                    item.SCJET = rdr.GetDecimal(rdr.GetOrdinal("SCJET"));
                    item.STime = rdr.GetDateTime(rdr.GetOrdinal("STime"));
                    item.TuanGouId = rdr.GetString(rdr.GetOrdinal("TuanGouId"));
                    item.XiangQing = rdr["XiangQing"].ToString();
                    item.XianLuId = rdr.GetString(rdr.GetOrdinal("XianLuId"));
                    item.ZheKou = rdr.GetDecimal(rdr.GetOrdinal("ZheKou"));
                    item.ShiShouRenShu = rdr.GetInt32(rdr.GetOrdinal("ShiShouRenShu"));
                    item.YiShouRenShu = rdr.GetInt32(rdr.GetOrdinal("YiShouRenShu"));
                    item.DingDanShu = rdr.GetInt32(rdr.GetOrdinal("DingDanShu"));
                    item.RouteName = rdr["RouteName"].ToString();
                    item.TuanName = rdr["TuanName"].ToString();
                    item.JianYaoMiaoShu = rdr["JianYaoMiaoShu"].ToString();
                    item.FilePath = rdr["FilePath"].ToString();

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {

                }
            }

            return items;
        }

        /// <summary>
        /// 获取线路团购信息业务实体
        /// </summary>
        /// <param name="tuanGouId">团购编号</param>
        /// <returns></returns>
        public MXianLuTuanGouInfo GetTuanGouInfo(string tuanGouId)
        {
            MXianLuTuanGouInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetTuanGouInfo);
            _db.AddInParameter(cmd, "TuanGouId", DbType.AnsiStringFixedLength, tuanGouId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MXianLuTuanGouInfo();

                    info.ETime = rdr.GetDateTime(rdr.GetOrdinal("ETime"));
                    info.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JSJCR = rdr.GetDecimal(rdr.GetOrdinal("JSJCR"));
                    info.JSJET = rdr.GetDecimal(rdr.GetOrdinal("JSJET"));
                    info.LatestId = rdr.GetInt32(rdr.GetOrdinal("LatestId"));
                    info.LatestTime = rdr.GetDateTime(rdr.GetOrdinal("LatestTime"));
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.RenShu = rdr.GetInt32(rdr.GetOrdinal("RenShu"));
                    info.SCJCR = rdr.GetDecimal(rdr.GetOrdinal("SCJCR"));
                    info.SCJET = rdr.GetDecimal(rdr.GetOrdinal("SCJET"));
                    info.STime = rdr.GetDateTime(rdr.GetOrdinal("STime"));
                    info.TuanGouId = rdr.GetString(rdr.GetOrdinal("TuanGouId"));
                    info.XiangQing = rdr["XiangQing"].ToString();
                    info.XianLuId = rdr.GetString(rdr.GetOrdinal("XianLuId"));
                    info.ZheKou = rdr.GetDecimal(rdr.GetOrdinal("ZheKou"));
                    info.ShiShouRenShu = rdr.GetInt32(rdr.GetOrdinal("ShiShouRenShu"));
                    info.YiShouRenShu = rdr.GetInt32(rdr.GetOrdinal("YiShouRenShu"));
                    info.DingDanShu = rdr.GetInt32(rdr.GetOrdinal("DingDanShu"));
                    info.RouteName = rdr["RouteName"].ToString();
                    info.TuanName = rdr["TuanName"].ToString();
                    info.JianYaoMiaoShu = rdr["JianYaoMiaoShu"].ToString();
                    info.FilePath = rdr["FilePath"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 增加一条线路点评数据
        /// </summary>
        public bool AddDianPing(MXianLuDianPing model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_XianLuDianPing(");
            strSql.Append("DianPingId,ManYiDu,DianPingFangShi,DianPingContet,SortId,IsCheck,OperatorId,XianLuId,GuiLaiShiJian,ChuYouRenShu,ZhuShu,JiaoTong,DaoYou,XingCheng,YuDingGuoCheng");
            strSql.Append(") values (");
            strSql.Append("@DianPingId,@ManYiDu,@DianPingFangShi,@DianPingContet,@SortId,@IsCheck,@OperatorId,@XianLuId,@GuiLaiShiJian,@ChuYouRenShu,@ZhuShu,@JiaoTong,@DaoYou,@XingCheng,@YuDingGuoCheng");
            strSql.Append(") ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "DianPingId", DbType.AnsiStringFixedLength, model.DianPingId);
            this._db.AddInParameter(cmd, "ManYiDu", DbType.Decimal, model.ManYiDu);
            this._db.AddInParameter(cmd, "DianPingFangShi", DbType.Byte, (int)model.DianPingFangShi);

            this._db.AddInParameter(cmd, "SortId", DbType.Int32, model.SortId);
            this._db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, model.XianLuId);
            this._db.AddInParameter(cmd, "GuiLaiShiJian", DbType.DateTime, model.GuiLaiShiJian.HasValue ? (DateTime?)model.GuiLaiShiJian.Value : null);
            this._db.AddInParameter(cmd, "ChuYouRenShu", DbType.Int32, model.ChuYouRenShu);
            this._db.AddInParameter(cmd, "ZhuShu", DbType.Byte, (int)model.ZhuShu);
            this._db.AddInParameter(cmd, "JiaoTong", DbType.Byte, (int)model.JiaoTong);
            this._db.AddInParameter(cmd, "DaoYou", DbType.Byte, (int)model.DaoYou);
            this._db.AddInParameter(cmd, "XingCheng", DbType.Byte, (int)model.XingCheng);
            this._db.AddInParameter(cmd, "YuDingGuoCheng", DbType.Byte, (int)model.YuDingGuoCheng);
            this._db.AddInParameter(cmd, "OperatorId", DbType.AnsiStringFixedLength, model.OperatorId);
            this._db.AddInParameter(cmd, "IsCheck", DbType.AnsiStringFixedLength, model.IsCheck ? 1 : 0);
            this._db.AddInParameter(cmd, "DianPingContet", DbType.String, model.DianPingContet);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;


        }
        /// <summary>
        /// 更新一条线路回访数据
        /// </summary>
        public bool UpdateDianPing(MXianLuDianPing model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_XianLuDianPing set ");

            strSql.Append(" ManYiDu = @ManYiDu , ");
            strSql.Append(" DianPingFangShi = @DianPingFangShi , ");
            strSql.Append(" DianPingContet = @DianPingContet , ");
            strSql.Append(" SortId = @SortId , ");
            strSql.Append(" IsCheck = @IsCheck , ");
            strSql.Append(" OperatorId = @OperatorId , ");
            strSql.Append(" XianLuId = @XianLuId , ");
            strSql.Append(" GuiLaiShiJian = @GuiLaiShiJian , ");
            strSql.Append(" ChuYouRenShu = @ChuYouRenShu , ");
            strSql.Append(" ZhuShu = @ZhuShu , ");
            strSql.Append(" JiaoTong = @JiaoTong , ");
            strSql.Append(" DaoYou = @DaoYou , ");
            strSql.Append(" XingCheng = @XingCheng , ");
            strSql.Append(" YuDingGuoCheng = @YuDingGuoCheng  ");
            strSql.Append(" where DianPingId=@DianPingId  ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "DianPingId", DbType.AnsiStringFixedLength, model.DianPingId);
            this._db.AddInParameter(cmd, "ManYiDu", DbType.Decimal, model.ManYiDu);
            this._db.AddInParameter(cmd, "DianPingFangShi", DbType.Byte, (int)model.DianPingFangShi);

            this._db.AddInParameter(cmd, "SortId", DbType.Int32, model.SortId);
            this._db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, model.XianLuId);
            this._db.AddInParameter(cmd, "GuiLaiShiJian", DbType.DateTime, model.GuiLaiShiJian.HasValue ? (DateTime?)model.GuiLaiShiJian.Value : null);
            this._db.AddInParameter(cmd, "ChuYouRenShu", DbType.Int32, model.ChuYouRenShu);
            this._db.AddInParameter(cmd, "ZhuShu", DbType.Byte, (int)model.ZhuShu);
            this._db.AddInParameter(cmd, "JiaoTong", DbType.Byte, (int)model.JiaoTong);
            this._db.AddInParameter(cmd, "DaoYou", DbType.Byte, (int)model.DaoYou);
            this._db.AddInParameter(cmd, "XingCheng", DbType.Byte, (int)model.XingCheng);
            this._db.AddInParameter(cmd, "YuDingGuoCheng", DbType.Byte, (int)model.YuDingGuoCheng);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "IsCheck", DbType.AnsiStringFixedLength, model.IsCheck ? 1 : 0);
            this._db.AddInParameter(cmd, "DianPingContet", DbType.String, model.DianPingContet);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条回访记录的审核状态
        /// </summary>
        /// <param name="DianPingIds"></param>
        /// <returns></returns>
        public bool UpdateDianPing(bool IsCheck, params string[] DianPingIds)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (var id in DianPingIds)
            {
                strSql.AppendFormat("update tbl_XianLuDianPing set IsCheck='{0}' where DianPingId='{1}' ", IsCheck ? 1 : 0, id);
            }
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSqlTrans(cmd, this._db) > 0 ? true : false;

        }
        /// <summary>
        /// 删除线路回访数据
        /// </summary>
        public bool DeleteDianPing(params string[] DianPingIds)
        {
            string strSql = null;
            foreach (var id in DianPingIds)
            {
                strSql = string.Format("delete from tbl_XianLuDianPing where DianPingId='{0}' ", id);
            }
            DbCommand cmd = this._db.GetSqlStringCommand(strSql);

            return DbHelper.ExecuteSqlTrans(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MXianLuDianPing GetDianPingModel(string DianPingId)
        {
            MXianLuDianPing model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select DianPingId, ManYiDu, DianPingFangShi, DianPingContet, SortId, IsCheck, OperatorId, IssueTime, XianLuId, GuiLaiShiJian, ChuYouRenShu, ZhuShu, JiaoTong, DaoYou, XingCheng, YuDingGuoCheng,  ");
            strSql.Append(" (select RouteName from tbl_XianLu where XianLuId=tbl_XianLuDianPing.XianLuId ) as RouteName, ");
            strSql.Append(" (case len(OperatorId)  ");
            strSql.Append(" when 36 then (select Account   from tbl_Member where MemberID=tbl_XianLuDianPing.OperatorId )  ");
            strSql.Append(" else ");
            strSql.Append(" (select Username   from tbl_Webmaster where Id=tbl_XianLuDianPing.OperatorId )  ");
            strSql.Append(" end )as OperatorName ");
            strSql.Append(" from tbl_XianLuDianPing ");
            strSql.Append(" where DianPingId=@DianPingId ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "DianPingId", DbType.AnsiStringFixedLength, DianPingId);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new MXianLuDianPing();

                    model.DianPingId = dr.GetString(dr.GetOrdinal("DianPingId"));
                    model.ManYiDu = dr.GetDecimal(dr.GetOrdinal("ManYiDu"));
                    model.DianPingFangShi = (DianPingType)dr.GetByte(dr.GetOrdinal("DianPingFangShi"));

                    model.SortId = dr.GetInt32(dr.GetOrdinal("SortId"));
                    model.XianLuId = dr.GetString(dr.GetOrdinal("XianLuId"));
                    model.RouteName = !dr.IsDBNull(dr.GetOrdinal("RouteName")) ? dr.GetString(dr.GetOrdinal("RouteName")) : null;
                    model.GuiLaiShiJian = dr.GetDateTime(dr.GetOrdinal("GuiLaiShiJian"));
                    model.ChuYouRenShu = dr.GetInt32(dr.GetOrdinal("ChuYouRenShu"));
                    model.ZhuShu = (DianPingStatus)dr.GetByte(dr.GetOrdinal("ZhuShu"));
                    model.JiaoTong = (DianPingStatus)dr.GetByte(dr.GetOrdinal("JiaoTong"));
                    model.DaoYou = (DianPingStatus)dr.GetByte(dr.GetOrdinal("DaoYou"));
                    model.XingCheng = (DianPingStatus)dr.GetByte(dr.GetOrdinal("XingCheng"));
                    model.YuDingGuoCheng = (DianPingStatus)dr.GetByte(dr.GetOrdinal("YuDingGuoCheng"));
                    model.IsCheck = dr.GetString(dr.GetOrdinal("IsCheck")) == "1";
                    model.DianPingContet = !dr.IsDBNull(dr.GetOrdinal("DianPingContet")) ? dr.GetString(dr.GetOrdinal("DianPingContet")) : null;
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : null;
                    model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));

                }
            }
            return model;

        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<MXianLuDianPing> GetDianPingList(int PageSize, int PageIndex, ref int RecordCount, MDianPingSeach Search)
        {
            IList<MXianLuDianPing> list = new List<MXianLuDianPing>();

            string tableName = "tbl_XianLuDianPing";

            StringBuilder fields = new StringBuilder();
            fields.Append("  DianPingId, ManYiDu, DianPingFangShi, DianPingContet, SortId, IsCheck, OperatorId, IssueTime, XianLuId, GuiLaiShiJian, ChuYouRenShu, ZhuShu, JiaoTong, DaoYou, XingCheng, YuDingGuoCheng,  ");
            fields.Append(" (select RouteName from tbl_XianLu where XianLuId=tbl_XianLuDianPing.XianLuId ) as RouteName, ");
            fields.Append(" (case len(OperatorId)  ");
            fields.Append(" when 36 then (select Account as OperatorName  from tbl_Member where MemberID=tbl_XianLuDianPing.OperatorId )  ");
            fields.Append(" else ");
            fields.Append(" (select Username as OperatorName  from tbl_Webmaster where Id=tbl_XianLuDianPing.OperatorId )  ");
            fields.Append(" end ) as OperatorName");

            string orderByString = "DianPingShiJian desc,SortId desc";

            StringBuilder query = new StringBuilder();

            query.Append(" 1=1 ");

            if (Search != null)
            {
                if (!string.IsNullOrEmpty(Search.RouteName))
                {
                    query.AppendFormat(" and exists(select 1 from tbl_XianLu where XianLuId=tbl_XianLuDianPing.XianLuId and RouteName like '%{0}%' ) ", Search.RouteName);
                }

                if (!string.IsNullOrEmpty(Search.OperatorName))
                {
                    query.AppendFormat(" and (exists(select 1 from tbl_Member where MemberID=tbl_XianLuDianPing.OperatorId and Account like '%{0}%') or exists(select 1 from tbl_Webmaster where Id=tbl_XianLuDianPing.OperatorId and Username like '%{0}%') )", Search.OperatorName);
                }

                if (Search.BeginDianPingTime.HasValue)
                {
                    query.AppendFormat(" and  datediff(day,DianPingShiJian,'{0}')<=0 ", Search.BeginDianPingTime.Value);
                }

                if (Search.EndDianPingTime.HasValue)
                {
                    query.AppendFormat(" and  datediff(day,DianPingShiJian,'{0}')>=0 ", Search.EndDianPingTime.Value);
                }

                if (Search.IsCheck.HasValue)
                {
                    query.AppendFormat(" and  IsCheck='{0}' ", Search.IsCheck.Value ? 1 : 0);
                }

                if (!string.IsNullOrEmpty(Search.OperatorId))
                {
                    query.AppendFormat(" and  OperatorId='{0}' ", Search.OperatorId);
                }
            }

            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fields.ToString(), query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    MXianLuDianPing model = new MXianLuDianPing();

                    model.DianPingId = dr.GetString(dr.GetOrdinal("DianPingId"));
                    model.ManYiDu = dr.GetDecimal(dr.GetOrdinal("ManYiDu"));
                    model.DianPingFangShi = (DianPingType)dr.GetByte(dr.GetOrdinal("DianPingFangShi"));

                    model.SortId = dr.GetInt32(dr.GetOrdinal("SortId"));
                    model.XianLuId = dr.GetString(dr.GetOrdinal("XianLuId"));
                    model.RouteName = !dr.IsDBNull(dr.GetOrdinal("RouteName")) ? dr.GetString(dr.GetOrdinal("RouteName")) : null;
                    model.GuiLaiShiJian = dr.GetDateTime(dr.GetOrdinal("GuiLaiShiJian"));
                    model.ChuYouRenShu = dr.GetInt32(dr.GetOrdinal("ChuYouRenShu"));
                    model.ZhuShu = (DianPingStatus)dr.GetByte(dr.GetOrdinal("ZhuShu"));
                    model.JiaoTong = (DianPingStatus)dr.GetByte(dr.GetOrdinal("JiaoTong"));
                    model.DaoYou = (DianPingStatus)dr.GetByte(dr.GetOrdinal("DaoYou"));
                    model.XingCheng = (DianPingStatus)dr.GetByte(dr.GetOrdinal("XingCheng"));
                    model.YuDingGuoCheng = (DianPingStatus)dr.GetByte(dr.GetOrdinal("YuDingGuoCheng"));
                    model.IsCheck = dr.GetString(dr.GetOrdinal("IsCheck")) == "1";
                    model.DianPingContet = !dr.IsDBNull(dr.GetOrdinal("DianPingContet")) ? dr.GetString(dr.GetOrdinal("DianPingContet")) : null;
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : null;
                    model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    list.Add(model);
                }
            }

            return list;
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IList<MXianLuDianPing> GetDianPingList(int Top, string XianLuId)
        {
            IList<MXianLuDianPing> list = new List<MXianLuDianPing>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }

            strSql.Append(" DianPingId, ManYiDu, DianPingFangShi, DianPingContet, SortId, IsCheck, OperatorId, IssueTime, XianLuId, GuiLaiShiJian, ChuYouRenShu, ZhuShu, JiaoTong, DaoYou, XingCheng, YuDingGuoCheng, IssueTime, ");
            strSql.Append(" (select RouteName from tbl_XianLu where XianLuId=tbl_XianLuDianPing.XianLuId ) as RouteName, ");
            strSql.Append(" (case len(OperatorId)  ");
            strSql.Append(" when 36 then (select Account from tbl_Member where MemberID=tbl_XianLuDianPing.OperatorId )  ");
            strSql.Append(" else ");
            strSql.Append(" (select Username  from tbl_Webmaster where Id=tbl_XianLuDianPing.OperatorId )  ");
            strSql.Append(" end ) as OperatorName ");

            strSql.Append("  from tbl_XianLuDianPing ");
            strSql.Append(" Where IsCheck='1' ");

            if (!string.IsNullOrEmpty(XianLuId))
            {

                strSql.AppendFormat("and XianLuId='{0}' ", XianLuId);
            }


            strSql.Append(" Order by DianPingShiJian desc,SortId desc ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    MXianLuDianPing model = new MXianLuDianPing();

                    model.DianPingId = dr.GetString(dr.GetOrdinal("DianPingId"));
                    model.ManYiDu = dr.GetDecimal(dr.GetOrdinal("ManYiDu"));
                    model.DianPingFangShi = (DianPingType)dr.GetByte(dr.GetOrdinal("DianPingFangShi"));

                    model.SortId = dr.GetInt32(dr.GetOrdinal("SortId"));
                    model.XianLuId = dr.GetString(dr.GetOrdinal("XianLuId"));
                    model.RouteName = !dr.IsDBNull(dr.GetOrdinal("RouteName")) ? dr.GetString(dr.GetOrdinal("RouteName")) : null;
                    model.GuiLaiShiJian = dr.GetDateTime(dr.GetOrdinal("GuiLaiShiJian"));
                    model.ChuYouRenShu = dr.GetInt32(dr.GetOrdinal("ChuYouRenShu"));
                    model.ZhuShu = (DianPingStatus)dr.GetByte(dr.GetOrdinal("ZhuShu"));
                    model.JiaoTong = (DianPingStatus)dr.GetByte(dr.GetOrdinal("JiaoTong"));
                    model.DaoYou = (DianPingStatus)dr.GetByte(dr.GetOrdinal("DaoYou"));
                    model.XingCheng = (DianPingStatus)dr.GetByte(dr.GetOrdinal("XingCheng"));
                    model.YuDingGuoCheng = (DianPingStatus)dr.GetByte(dr.GetOrdinal("YuDingGuoCheng"));
                    model.IsCheck = dr.GetString(dr.GetOrdinal("IsCheck")) == "1";
                    model.DianPingContet = !dr.IsDBNull(dr.GetOrdinal("DianPingContet")) ? dr.GetString(dr.GetOrdinal("DianPingContet")) : null;
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : null;
                    model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));

                    list.Add(model);
                }
            }

            return list;
        }


        /// <summary>
        /// 根据线路编号获取满意度
        /// </summary>
        /// <param name="xianLuId"></param>
        /// <returns></returns>
        public decimal GetManYiDuByXianLuId(string xianLuId)
        {
            string sql = "select avg(ManYiDu) as ManYiDu from tbl_XianLuDianPing  where XianLuId=@XianLuId";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);
            this._db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianLuId);

            return Convert.ToDecimal(DbHelper.GetSingle(cmd, this._db));
        }

        /// <summary>
        /// 设置线路具体发班日期差异信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">发班信息</param>
        /// <returns></returns>
        public int SheZhiXianLuTourChaYi(MXianLuTourInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_SheZhiXianLuTourChaYi);
            _db.AddInParameter(cmd, "JSJCR", DbType.Decimal, info.JSJCR);
            _db.AddInParameter(cmd, "JSJET", DbType.Decimal, info.JSJET);
            _db.AddInParameter(cmd, "CRSCJ", DbType.Decimal, info.CRSCJ);
            _db.AddInParameter(cmd, "ETSCJ", DbType.Decimal, info.ETSCJ);
            _db.AddInParameter(cmd, "TourId", DbType.AnsiStringFixedLength, info.TourId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }
        /// <summary>
        /// 更新发班信息
        /// </summary>
        /// <param name="xianlu">线路</param>
        /// <returns></returns>
        public int UpdateToursDataLS(MXianLuInfo xianlu)
        {
            if (xianlu == null
                    || string.IsNullOrEmpty(xianlu.XianLuId)
                    || xianlu.Tours == null
                    || xianlu.Tours.Count == 0) return 0;

            int count = 0;
            if (xianlu.Tours != null && xianlu.Tours.Count > 0)
            {
                for (int i = 0; i < xianlu.Tours.Count; i++)
                {
                    DbCommand cmd = _db.GetStoredProcCommand("proc_UpdateTours");
                    _db.AddInParameter(cmd, "TourId", DbType.AnsiStringFixedLength, Guid.NewGuid().ToString());
                    _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianlu.XianLuId);
                    _db.AddInParameter(cmd, "LDate", DbType.DateTime, xianlu.Tours[i].LDate);
                    _db.AddInParameter(cmd, "RDate", DbType.DateTime, xianlu.Tours[i].RDate);
                    _db.AddInParameter(cmd, "Status", DbType.Byte, xianlu.Tours[i].Status);
                    _db.AddInParameter(cmd, "JSJCR", DbType.Decimal, xianlu.Tours[i].JSJCR);
                    _db.AddInParameter(cmd, "JSJET", DbType.Decimal, xianlu.Tours[i].JSJET);
                    _db.AddInParameter(cmd, "CRSCJ", DbType.Decimal, xianlu.Tours[i].CRSCJ);
                    _db.AddInParameter(cmd, "ETSCJ", DbType.Decimal, xianlu.Tours[i].ETSCJ);
                    _db.AddInParameter(cmd, "SYRS", DbType.Int32, xianlu.Tours[i].SYRS);
                    _db.AddInParameter(cmd, "TrafficId", DbType.String, string.IsNullOrEmpty(xianlu.Tours[i].TrafficId) ? "" : xianlu.Tours[i].TrafficId);
                    _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);
                    DbHelper.RunProcedure(cmd, _db);
                    count += Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
                }
                xianlu.Tours = GetXianLuTours(xianlu.XianLuId);
            }

            if (count == xianlu.Tours.Count) return 1;
            return 0;

        }
        /// <summary>
        /// 更新发班信息
        /// </summary>
        /// <param name="xianlu">线路</param>
        /// <returns></returns>
        public int UpdateToursTra(MXianLuInfo xianlu)
        {
            if (xianlu == null
                    || string.IsNullOrEmpty(xianlu.XianLuId)
                    || xianlu.TourTraffice == null
                    || xianlu.TourTraffice.Count == 0) return 0;

            int count = 0;
            if (xianlu.TourTraffice != null && xianlu.TourTraffice.Count > 0)
            {

                _db.ExecuteNonQuery(CommandType.Text, string.Format("DELETE FROM tbl_XianLuTourTraffice WHERE [XianLuId]='{0}'", xianlu.XianLuId));

                for (int i = 0; i < xianlu.TourTraffice.Count; i++)
                {
                    DbCommand cmd = _db.GetStoredProcCommand("proc_UpdateToursTraffice");
                    _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianlu.XianLuId);
                    _db.AddInParameter(cmd, "TrafficId", DbType.String, xianlu.TourTraffice[i].TrafficId);
                    _db.AddInParameter(cmd, "Traffic_01", DbType.String, xianlu.TourTraffice[i].Traffic_01);
                    _db.AddInParameter(cmd, "Traffic_02", DbType.String, xianlu.TourTraffice[i].Traffic_02);

                    _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);
                    DbHelper.RunProcedure(cmd, _db);
                    count += Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
                }
                if (xianlu.LineType != LineType.短线)
                    _db.ExecuteNonQuery(CommandType.Text, string.Format("DELETE FROM tbl_XianLuTour WHERE [XianLuId]='{0}' AND trafficid not in (select trafficid from tbl_XianLuTourTraffice WHERE [XianLuId]='{0}')", xianlu.XianLuId));

                xianlu.TourTraffice = GetTourTraffice(xianlu.XianLuId);
            }

            if (count == xianlu.TourTraffice.Count) return 1;
            return 0;

        }

        /// <summary>
        /// 获取发班信息
        /// </summary>
        /// <param name="tourid">发班编号</param>
        /// <returns></returns>
        public MXianLuTourInfo GetTourInfo(string tourid)
        {
            MXianLuTourInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetTourInfo);
            _db.AddInParameter(cmd, "TourId", DbType.AnsiStringFixedLength, tourid);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MXianLuTourInfo();
                    item.LDate = rdr.GetDateTime(rdr.GetOrdinal("LDate"));
                    item.RDate = rdr.GetDateTime(rdr.GetOrdinal("RDate"));
                    item.Status = (ShouKeZhuangTai)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.TourId = rdr.GetString(rdr.GetOrdinal("TourId"));
                    item.DingDanShu = rdr.IsDBNull(rdr.GetOrdinal("DingDanShu")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("DingDanShu"));
                    item.ShiShouRenShu = rdr.IsDBNull(rdr.GetOrdinal("ShiShouRenShu")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("ShiShouRenShu"));
                    item.YiShouRenShu = rdr.IsDBNull(rdr.GetOrdinal("YiShouRenShu")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("YiShouRenShu"));
                    item.JSJCR = rdr.IsDBNull(rdr.GetOrdinal("JSJCR")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("JSJCR"));
                    item.JSJET = rdr.IsDBNull(rdr.GetOrdinal("JSJET")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("JSJET"));
                    item.SYRS = rdr.IsDBNull(rdr.GetOrdinal("SYRS")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("SYRS"));
                    item.TrafficId = rdr.IsDBNull(rdr.GetOrdinal("TrafficId")) ? "" : rdr.GetString(rdr.GetOrdinal("TrafficId"));
                    item.CRSCJ = rdr.IsDBNull(rdr.GetOrdinal("CRSCJ")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("CRSCJ"));
                    item.ETSCJ = rdr.IsDBNull(rdr.GetOrdinal("ETSCJ")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("ETSCJ"));

                    info = item;
                }
            }

            return info;
        }
        #endregion
        /// <summary>
        /// 设置线路状态
        /// </summary>
        /// <param name="ids">线路编号</param>
        /// <param name="zt">线路状态</param>
        /// <returns></returns>
        public int setXianLuZT(string[] ids, XianLuZT zt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update tbl_XianLu set  XianLuZT = @XianLuZT  where XianLuId in ({0})", Toolkit.Utils.GetSqlInExpression(ids));


            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "XianLuZT", DbType.Byte, zt);


            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 获取出发地列表
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.MSysCity> getChuFaCitys()
        {
            IList<EyouSoft.Model.MSysCity> ResultList = null;
            StringBuilder StrSql = new StringBuilder();
            StrSql.Append("select * from  tbl_SysCity ");
            StrSql.Append("where id in(select depcityid from tbl_xianlu where depcityid<>0)");
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                ResultList = new List<EyouSoft.Model.MSysCity>();
                while (dr.Read())
                {
                    EyouSoft.Model.MSysCity model = new EyouSoft.Model.MSysCity()
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId")),
                        Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                        CenterCityId = dr.GetInt32(dr.GetOrdinal("CenterCityId")),
                        HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter")),
                        IsSite = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsSite")) ? "" : dr.GetString(dr.GetOrdinal("IsSite"))),
                        DomainName = dr.IsDBNull(dr.GetOrdinal("DomainName")) ? "" : dr.GetString(dr.GetOrdinal("DomainName")),
                        IsEnabled = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsEnabled")) ? "" : dr.GetString(dr.GetOrdinal("IsEnabled")))
                    };
                    ResultList.Add(model);
                    model = null;
                }

            }
            return ResultList;
        }

    }
}
