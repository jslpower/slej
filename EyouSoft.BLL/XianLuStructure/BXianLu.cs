//线路产品相关信息业务逻辑类 汪奇志 2013-03-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.XianLuStructure;
using EyouSoft.Toolkit;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.BLL.XianLuStructure
{
    /// <summary>
    /// 线路产品相关信息业务逻辑类
    /// </summary>
    public class BXianLu
    {
        private readonly EyouSoft.IDAL.XianLuStructure.IXianLu dal = new EyouSoft.DAL.XianLuStructure.DXianLu();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BXianLu() { }
        #endregion

        #region public members
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="InterfaceID"></param>
        /// <returns></returns>
        public string ExistsInterfaceID(string InterfaceID, EyouSoft.Model.XianLuStructure.LineSource LineSource)
        {
            if (string.IsNullOrEmpty(InterfaceID)) return "";
            string num = dal.ExistsInterfaceID(InterfaceID, LineSource);
            return num;
        }

        /// <summary>
        /// 写入线路产品信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MXianLuInfo info)
        {
            if (info == null || info.OperatorId == 0) return 0;
            info.XianLuId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;
            info.LatestId = info.OperatorId;
            info.LatestTime = info.IssueTime;

            if (info.Tours != null && info.Tours.Count > 0)
            {
                foreach (var item in info.Tours)
                {
                    if (item.LDate == DateTime.MinValue
                        || item.LDate < new DateTime(2000, 1, 1)) { throw new System.Exception("ERROR-XIANLU-TOUR-0001:出团时间含有无效值。"); }
                    item.TourId = Guid.NewGuid().ToString();
                    item.RDate = item.LDate.AddDays(info.TianShu - 1);

                    if (info.Line_Source == LineSource.系统)
                    {
                        item.JSJCR = info.JSJCR;
                        item.JSJET = info.JSJET;
                        item.SYRS = info.JiHuaRenShu;
                        item.CRSCJ = info.SCJCR;
                        item.ETSCJ = info.SCJET;
                        item.CRSCJ = info.SCJCR;
                        item.ETSCJ = info.SCJET;
                    }

                }
            }

            info.TeSeFilePath = string.Empty;
            if (info.TeSeFiles != null && info.TeSeFiles.Count > 0)
            {
                info.TeSeFilePath = info.TeSeFiles[0].FilePath;
            }

            int dalRetCode = dal.Insert(info);

            return dalRetCode;
        }

        /// <summary>
        /// 获取线路产品信息业务实体
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        public MXianLuInfo GetInfo(string xianLuId)
        {
            if (string.IsNullOrEmpty(xianLuId)) return null;

            return dal.GetInfo(xianLuId);
        }

        /// <summary>
        /// 更新接口线路产品信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int OutUpdate(MXianLuInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.XianLuId)
                   || info.LatestId == 0) return 0;

            info.LatestTime = DateTime.Now;

            if (info.Tours != null && info.Tours.Count > 0)
            {
                foreach (var item in info.Tours)
                {
                    if (item.LDate == DateTime.MinValue
                        || item.LDate < new DateTime(2000, 1, 1)) { throw new System.Exception("ERROR-XIANLU-TOUR-0001:出团时间含有无效值。"); }
                    if (string.IsNullOrEmpty(item.TourId)) item.TourId = Guid.NewGuid().ToString();
                    item.RDate = item.LDate.AddDays(info.TianShu - 1);
                }
            }

            info.TeSeFilePath = string.Empty;
            if (info.TeSeFiles != null && info.TeSeFiles.Count > 0)
            {
                info.TeSeFilePath = info.TeSeFiles[0].FilePath;
            }

            int dalRetCode = dal.OutUpdate(info);

            return dalRetCode;
        }

        /// <summary>
        /// 更新线路产品信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MXianLuInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.XianLuId)
                || info.LatestId == 0) return 0;

            info.LatestTime = DateTime.Now;

            if (info.Tours != null && info.Tours.Count > 0)
            {
                foreach (var item in info.Tours)
                {
                    if (item.LDate == DateTime.MinValue
                        || item.LDate < new DateTime(2000, 1, 1)) { throw new System.Exception("ERROR-XIANLU-TOUR-0001:出团时间含有无效值。"); }
                    if (string.IsNullOrEmpty(item.TourId)) item.TourId = Guid.NewGuid().ToString();
                    item.RDate = item.LDate.AddDays(info.TianShu - 1);
                    item.SYRS = info.JiHuaRenShu;
                }
            }

            info.TeSeFilePath = string.Empty;
            if (info.TeSeFiles != null && info.TeSeFiles.Count > 0)
            {
                info.TeSeFilePath = info.TeSeFiles[0].FilePath;
            }

            int dalRetCode = dal.Update(info);

            return dalRetCode;
        }

        /// <summary>
        /// 删除线路产品信息，返回1成功，其它失败
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        public int Delete(string xianLuId)
        {
            if (string.IsNullOrEmpty(xianLuId)) return 0;

            int dalRetCode = dal.Delete(xianLuId);

            return dalRetCode;
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
            if (!Utils.ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetXianLus(pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 获取线路产品信息集合，SELECT TOP(expression) 
        /// </summary>
        /// <param name="topExpression">指定返回行数的数值表达式</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns></returns>
        public IList<MXianLuInfo> GetXianLus(int topExpression, MXianLuChaXunInfo chaXun)
        {
            if (topExpression < 1) topExpression = 1;

            return dal.GetXianLus(topExpression, chaXun);
        }

        /// <summary>
        /// 增加关注数
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <param name="expression">增加数量的数值表达式</param>
        /// <returns></returns>
        public bool JiaGuanZhuShu(string xianLuId, int expression)
        {
            if (string.IsNullOrEmpty(xianLuId)) return false;

            return dal.JiaGuanZhuShu(xianLuId, expression);
        }

        /// <summary>
        /// 设置线路状态
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <param name="zhuangTais">状态数组</param>
        /// <returns></returns>
        public bool SheZhiZhuangTai(string xianLuId, XianLuZhuangTai[] zhuangTais)
        {
            if (string.IsNullOrEmpty(xianLuId) || zhuangTais == null
                || zhuangTais.Length == 0) return false;

            if (zhuangTais.Contains(XianLuZhuangTai.None))
            {
                return dal.DeleteZhuangTai(xianLuId);
            }

            if (dal.DeleteZhuangTai(xianLuId))
            {
                return dal.SheZhiZhuangTai(xianLuId, zhuangTais);
            }

            return false;
        }

        /// <summary>
        /// 写入团购信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertTuanGou(MXianLuTuanGouInfo info)
        {
            if (info == null || info.OperatorId == 0
                || string.IsNullOrEmpty(info.XianLuId)
                || info.STime == DateTime.MinValue
                || info.ETime == DateTime.MinValue
                || info.STime < new DateTime(2000, 1, 1)
                || info.ETime < new DateTime(2000, 1, 1)) return 0;

            info.TuanGouId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;
            info.LatestId = info.OperatorId;
            info.LatestTime = info.IssueTime;

            info.FilePath = string.Empty;
            if (info.Files != null && info.Files.Count > 0)
            {
                info.FilePath = info.Files[0].FilePath;
            }

            int dalRetCode = dal.InsertTuanGou(info);

            return dalRetCode;
        }

        /// <summary>
        /// 更新团购信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int UpdateTuanGou(MXianLuTuanGouInfo info)
        {
            if (info == null || info.LatestId == 0
                || string.IsNullOrEmpty(info.XianLuId)
                || info.STime == DateTime.MinValue
                || info.ETime == DateTime.MinValue
                || info.STime < new DateTime(2000, 1, 1)
                || info.ETime < new DateTime(2000, 1, 1)
                || string.IsNullOrEmpty(info.TuanGouId)) return 0;

            info.LatestTime = DateTime.Now;

            info.FilePath = string.Empty;
            if (info.Files != null && info.Files.Count > 0)
            {
                info.FilePath = info.Files[0].FilePath;
            }

            int dalRetCode = dal.UpdateTuanGou(info);

            return dalRetCode;
        }

        /// <summary>
        /// 删除团购信息，返回1成功，其它失败
        /// </summary>
        /// <param name="tuanGouId">团购编号</param>
        /// <returns></returns>
        public int DeleteTuanGou(string tuanGouId)
        {
            if (string.IsNullOrEmpty(tuanGouId)) return 0;

            int dalRetCode = dal.DeleteTuanGou(tuanGouId);

            return dalRetCode;
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
            if (!Utils.ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetTuanGous(pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 获取线路团购信息业务实体
        /// </summary>
        /// <param name="tuanGouId">团购编号</param>
        /// <returns></returns>
        public MXianLuTuanGouInfo GetTuanGouInfo(string tuanGouId)
        {
            if (string.IsNullOrEmpty(tuanGouId)) return null;

            return dal.GetTuanGouInfo(tuanGouId);
        }


        /// <summary>
        /// 增加一条线路回访数据
        /// </summary>
        public bool AddDianPing(MXianLuDianPing model)
        {
            if (string.IsNullOrEmpty(model.OperatorId)) return false;
            model.DianPingId = Guid.NewGuid().ToString();
            return dal.AddDianPing(model);
        }
        /// <summary>
        /// 更新一条线路回访数据
        /// </summary>
        public bool UpdateDianPing(MXianLuDianPing model)
        {
            if (string.IsNullOrEmpty(model.DianPingId) || model.ChuYouRenShu == 0 || model.ManYiDu == 0 || model.GuiLaiShiJian == null || string.IsNullOrEmpty(model.OperatorId)) return false;
            return dal.UpdateDianPing(model);
        }
        /// <summary>
        /// 更新一条回访记录的审核状态
        /// </summary>
        /// <param name="DianPingIds"></param>
        /// <returns></returns>
        public bool UpdateDianPing(bool IsCheck, params string[] DianPingIds)
        {
            if (DianPingIds == null && DianPingIds.Length == 0) return false;
            return dal.UpdateDianPing(IsCheck, DianPingIds);
        }
        /// <summary>
        /// 删除线路回访数据
        /// </summary>
        public bool DeleteDianPing(params string[] DianPingIds)
        {
            if (DianPingIds == null && DianPingIds.Length == 0) return false;
            return dal.DeleteDianPing(DianPingIds);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MXianLuDianPing GetDianPingModel(string DianPingId)
        {
            return dal.GetDianPingModel(DianPingId);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<MXianLuDianPing> GetDianPingList(int PageSize, int PageIndex, ref int RecordCount, MDianPingSeach Search)
        {
            return dal.GetDianPingList(PageSize, PageIndex, ref RecordCount, Search);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IList<MXianLuDianPing> GetDianPingList(int Top, string XianLuId)
        {
            return dal.GetDianPingList(Top, XianLuId);
        }

        /// <summary>
        /// 根据线路编号获取满意度
        /// </summary>
        /// <param name="xianLuId"></param>
        /// <returns></returns>
        public decimal GetManYiDuByXianLuId(string xianLuId)
        {
            if (string.IsNullOrEmpty(xianLuId)) return 0;
            return dal.GetManYiDuByXianLuId(xianLuId);
        }

        /// <summary>
        /// 设置线路具体发班日期差异信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">发班信息</param>
        /// <returns></returns>
        public int SheZhiXianLuTourChaYi(MXianLuTourInfo info)
        {
            if (info == null
                || string.IsNullOrEmpty(info.TourId)) return 0;

            int dalRetCode = dal.SheZhiXianLuTourChaYi(info);

            return dalRetCode;
        }
        /// <summary>
        /// 更新发班信息
        /// </summary>
        /// <param name="xianlu">发班日期</param>
        /// <returns></returns>
        public int UpdateToursDataLS(MXianLuInfo xianlu)
        {
            if (xianlu == null
                || string.IsNullOrEmpty(xianlu.XianLuId)
                || xianlu.Tours == null
                || xianlu.Tours.Count == 0) return 0;
            return dal.UpdateToursDataLS(xianlu);
        }
        /// <summary>
        /// 获取发班信息
        /// </summary>
        /// <param name="tourid">发班编号</param>
        /// <returns></returns>
        public MXianLuTourInfo GetTourInfo(string tourid)
        {
            if (string.IsNullOrEmpty(tourid)) return null;
            return dal.GetTourInfo(tourid);
        }
        /// <summary>
        /// 设置线路状态
        /// </summary>
        /// <param name="ids">线路编号</param>
        /// <param name="zt">线路状态</param>
        /// <returns></returns>
        public int setXianLuZT(string[] ids, XianLuZT zt)
        {
            if (ids == null || ids.Length == 0) return 0;
            return dal.setXianLuZT(ids, zt);
        }
                /// <summary>
        /// 获取出发地列表
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.MSysCity> getChuFaCitys()
        {
            return dal.getChuFaCitys();
        }
        #endregion
    }
}
