/*//机票订单相关 汪奇志 2013-12-04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.JiPiaoStructure
{
    /// <summary>
    /// 机票订单相关
    /// </summary>
    public class BJiPiaoDingDan
    {
        private readonly EyouSoft.IDAL.JiPiaoStructure.IJiPiaoDingDan dal = new EyouSoft.DAL.JiPiaoStructure.DJiPiaoDingDan();

        #region static constants
        //static constants
        #endregion

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BJiPiaoDingDan() { }
        #endregion

        #region private members
        
        #endregion

        #region public members
        /// <summary>
        /// 写入机票订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="hangBanInfo">航班实体</param>
        /// <param name="dingDanInfo">订单实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.JiPiaoStructure.MHangBanInfo hangBanInfo, EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo dingDanInfo)
        {
            if (hangBanInfo == null || hangBanInfo.CangWeis == null || hangBanInfo.CangWeis.Count == 0) return 0;
            if (dingDanInfo == null || dingDanInfo.ChengJiRens == null || dingDanInfo.ChengJiRens.Count == 0) return 0;
            if (string.IsNullOrEmpty(dingDanInfo.XiaDanRenId)) return 0;
            if (dingDanInfo.ChuFaRiQi.Year < 2000) return 0;

            var xiaDanInfo = new EyouSoft.BLL.JiPiaoStructure.BJiPiao().XiaDan(hangBanInfo, dingDanInfo);

            if (xiaDanInfo.RetCode != 1) return -1001;

            hangBanInfo.HangBanId = Guid.NewGuid().ToString();
            hangBanInfo.ApiHangBanId = string.Empty;            

            dingDanInfo.DingDanId = Guid.NewGuid().ToString();
            dingDanInfo.HangBanId = hangBanInfo.HangBanId;
            dingDanInfo.IssueTime = DateTime.Now;
            dingDanInfo.DingDanStatus = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理;
            dingDanInfo.FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款;
            dingDanInfo.ChuPiaoStatus = EyouSoft.Model.Enum.JiPiaoStructure.ChuPiaoStatus.未出票;
            dingDanInfo.QueRenFangShi = EyouSoft.Model.Enum.JiPiaoStructure.QueRenFangShi.不用确认;
            dingDanInfo.ChuPiaoFangShi = EyouSoft.Model.Enum.JiPiaoStructure.ChuPiaoFangShi.先不出票;
            dingDanInfo.ApiDingDanId = xiaDanInfo.ApiDingDanHao;
            dingDanInfo.ApiFaDianJinE = xiaDanInfo.ApiFaDianJinE;
            dingDanInfo.ApiJinE = xiaDanInfo.ApiJinE;

            decimal jinE = 0;
            foreach (var cjr in dingDanInfo.ChengJiRens)
            {
                jinE += hangBanInfo.CangWeis[0].JiaGe;
                jinE += hangBanInfo.RanYouFei;
                jinE += hangBanInfo.JiJianFei;
                jinE += cjr.YiWaiXianJiaGe * cjr.YiWaiXian;
            }

            dingDanInfo.JinE = jinE;

            int dalRetCodeHangBan = dal.InsertHangBan(hangBanInfo);
            if (dalRetCodeHangBan != 1) return -2;

            int dalRetCodeDingDan = dal.Insert(dingDanInfo);

            return dalRetCodeDingDan;
        }

        /// <summary>
        /// 更新机票订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo info)
        {
            if (info == null || info.ChengJiRens == null || info.ChengJiRens.Count == 0) return 0;
            if (string.IsNullOrEmpty(info.DingDanId)) return 0;

            var _info = GetInfo(info.DingDanId);
            if (_info == null) return -1;

            int dalRetCode = dal.Update(info);

            return dalRetCode;
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <param name="dingDanStatus">订单状态</param>
        /// <returns></returns>
        public int SheZhiDingDanStatus(string dingDanId, string xiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus dingDanStatus)
        {
            if (string.IsNullOrEmpty(dingDanId) || string.IsNullOrEmpty(xiaDanRenId)) return 0;

            int dalRetCode = dal.SheZhiDingDanStatus(dingDanId, xiaDanRenId, dingDanStatus);

            return dalRetCode;
        }

        /// <summary>
        /// 设置付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <param name="fuKuanStatus">付款状态</param>
        /// <returns></returns>
        public int SheZhiFuKuanStatus(string dingDanId, string xiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus fuKuanStatus)
        {
            if (string.IsNullOrEmpty(dingDanId) || string.IsNullOrEmpty(xiaDanRenId)) return 0;

            int dalRetCode = dal.SheZhiFuKuanStatus(dingDanId, xiaDanRenId, fuKuanStatus);

            return dalRetCode;
        }

        /// <summary>
        /// 设置出票状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <param name="chuPiaoStatus">出票状态</param>
        /// <returns></returns>
        public int SheZhiChuPiaoStatus(string dingDanId, string xiaDanRenId, EyouSoft.Model.Enum.JiPiaoStructure.ChuPiaoStatus chuPiaoStatus)
        {
            if (string.IsNullOrEmpty(dingDanId) || string.IsNullOrEmpty(xiaDanRenId)) return 0;

            int dalRetCode = dal.SheZhiChuPiaoStatus(dingDanId, xiaDanRenId, chuPiaoStatus);

            return dalRetCode;
        }

        /// <summary>
        /// 获取订单信息业务实体
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        public EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo GetInfo(string dingDanId)
        {
            if (string.IsNullOrEmpty(dingDanId)) return null;

            return dal.GetInfo(dingDanId);
        }

        /// <summary>
        /// 获取航班信息业务实体
        /// </summary>
        /// <param name="hangBanId">航班编号</param>
        /// <returns></returns>
        public EyouSoft.Model.JiPiaoStructure.MHangBanInfo GetHangBanInfo(string hangBanId)
        {
            if (string.IsNullOrEmpty(hangBanId)) return null;

            return dal.GetHangBanInfo(hangBanId);
        }

        /// <summary>
        /// 获取订单信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo> GetDingDans(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanChaXunInfo chaXun)
        {
            if (!EyouSoft.Toolkit.Utils.ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetDingDans(pageSize, pageIndex, ref recordCount, chaXun);
        }
        #endregion
    }
}
*/