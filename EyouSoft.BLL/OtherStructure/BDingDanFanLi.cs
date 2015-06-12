//订单返利信息BLL 汪奇志 2014-11-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{
    /// <summary>
    /// 订单返利信息BLL
    /// </summary>
    public class BDingDanFanLi
    {
        readonly EyouSoft.IDAL.OtherStructure.IDingDanFanLi dal = new EyouSoft.DAL.OtherStructure.DDingDanFanLi();

        /// <summary>
        /// default constructor
        /// </summary>
        public BDingDanFanLi() { }

        #region private members

        #endregion

        #region public members
        /// <summary>
        /// 订单返利信息新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int DingDanFanLi_C(EyouSoft.Model.OtherStructure.MDingDanFanLiInfo info)
        {
            if (info == null
                || string.IsNullOrEmpty(info.HuiYuanId)
                || string.IsNullOrEmpty(info.DingDanId)
                || info.FanLiJinE < 0) return 0;

            info.FanLiId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.DingDanFanLi_C(info);

            if (dalRetCode == 1)
            {
                var zhiFuMingXiInfo = new EyouSoft.Model.OtherStructure.MJiaoYiMingXiInfo();
                zhiFuMingXiInfo.ApiJiaoYiHao = string.Empty; ;
                zhiFuMingXiInfo.DingDanId = info.FanLiId;
                zhiFuMingXiInfo.DingDanLeiXing = EyouSoft.Model.Enum.DingDanLeiBie.订单返利;
                zhiFuMingXiInfo.HuiYuanId = info.HuiYuanId;
                zhiFuMingXiInfo.JiaoYiHao = info.FanLiJiaoYiHao;
                zhiFuMingXiInfo.JiaoYiJinE = info.FanLiJinE;
                zhiFuMingXiInfo.JiaoYiLeiBie = EyouSoft.Model.Enum.JiaoYiLeiBie.返利;
                zhiFuMingXiInfo.JiaoYiMiaoShu = string.Empty;
                zhiFuMingXiInfo.JiaoYiShiJian = DateTime.Now;
                zhiFuMingXiInfo.JiaoYiStatus = EyouSoft.Model.Enum.JiaoYiStatus.交易成功;
                zhiFuMingXiInfo.MingXiId = string.Empty;
                zhiFuMingXiInfo.ZhiFuFangShi = EyouSoft.Model.Enum.ZhiFuFangShi.E额宝;

                new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().JiaoYiMingXi_C(zhiFuMingXiInfo);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取订单返利信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MDingDanFanLiInfo> GetDingDanFanLis(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.OtherStructure.MDingDanFanLiChaXunInfo chaXun)
        {
            return dal.GetDingDanFanLis(pageSize, pageIndex, ref recordCount, chaXun);
        }
        #endregion
    }
}
