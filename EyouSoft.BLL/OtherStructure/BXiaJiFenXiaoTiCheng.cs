//下级分销提成信息相关BLL 汪奇志 2014-10-30
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{
    /// <summary>
    /// 下级分销提成信息相关BLL
    /// </summary>
    public class BXiaJiFenXiaoTiCheng
    {
        readonly EyouSoft.IDAL.OtherStructure.IXiaJiFenXiaoTiCheng dal = new EyouSoft.DAL.OtherStructure.DXiaJiFenXiaoTiCheng();

        /// <summary>
        /// default constructor
        /// </summary>
        public BXiaJiFenXiaoTiCheng() { }

        #region public members
        /// <summary>
        /// 下级分销提成申请，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int XiaJiFenXiaoTiCheng_C(EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.HuiYuanId)) return 0;
            if (info.JinE < 00 || info.BiLi <= 0 || info.YongJinJinE <= 0) return 0;

            info.TiChengId = Guid.NewGuid().ToString();
            info.ShiJian = DateTime.Now;
            info.Status = EyouSoft.Model.Enum.XiaJiFenXiaoTiChengStatus.未处理;

            int dalRetCode = dal.XiaJiFenXiaoTiCheng_C(info);

            return dalRetCode;
        }

        /// <summary>
        /// 获取下级分销提成实体
        /// </summary>
        /// <param name="tiChengId">提成编号</param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengInfo GetInfo(string tiChengId)
        {
            if (string.IsNullOrEmpty(tiChengId)) return null;

            return dal.GetInfo(tiChengId);
        }

        /// <summary>
        /// 获取下级分销提成集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengInfo> GetTiChengs(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengChaXunInfo chaXun)
        {
            return dal.GetTiChengs(pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 设置下级分销提成状态，返回1成功，其它失败
        /// </summary>
        /// <param name="tiChengId">提成编号</param>
        /// <param name="status">状态</param>
        /// <param name="caoZuoRenId">操作人编号</param>
        /// <returns></returns>
        public int SheZhiTiChengStatus(string tiChengId, EyouSoft.Model.Enum.XiaJiFenXiaoTiChengStatus status, string caoZuoRenId)
        {
            if (string.IsNullOrEmpty(tiChengId) || string.IsNullOrEmpty(caoZuoRenId)) return 0;
            int dalRetCode = dal.SheZhiTiChengStatus(tiChengId, status, caoZuoRenId);

            if (dalRetCode == 1&&status== EyouSoft.Model.Enum.XiaJiFenXiaoTiChengStatus.已成交)
            {
                var tiChengInfo = GetInfo(tiChengId);

                var zhiFuMingXiInfo = new EyouSoft.Model.OtherStructure.MJiaoYiMingXiInfo();
                zhiFuMingXiInfo.ApiJiaoYiHao = string.Empty; ;
                zhiFuMingXiInfo.DingDanId = tiChengInfo.TiChengId;
                zhiFuMingXiInfo.DingDanLeiXing = EyouSoft.Model.Enum.DingDanLeiBie.下级分销结算;
                zhiFuMingXiInfo.HuiYuanId = tiChengInfo.HuiYuanId;
                zhiFuMingXiInfo.JiaoYiHao = tiChengInfo.JiaoYiHao;
                zhiFuMingXiInfo.JiaoYiJinE = tiChengInfo.JinE;
                zhiFuMingXiInfo.JiaoYiLeiBie = EyouSoft.Model.Enum.JiaoYiLeiBie.分销奖金;
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
        /// 获取会员下级分销提成金额信息
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengJinEInfo GetHuiYuanXiaJiFenXiaoTiChengJinEInfo(string huiYuanId)
        {
            if (string.IsNullOrEmpty(huiYuanId)) return new EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengJinEInfo();

            return dal.GetHuiYuanXiaJiFenXiaoTiChengJinEInfo(huiYuanId);
        }
        #endregion
    }
}
