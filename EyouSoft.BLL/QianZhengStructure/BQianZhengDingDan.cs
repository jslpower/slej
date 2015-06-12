//签证订单信息 汪奇志 2013-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.QianZhengStructure
{
    /// <summary>
    /// 签证订单信息
    /// </summary>
    public class BQianZhengDingDan
    {
        private readonly EyouSoft.IDAL.QianZhengStructure.IQianZhengDingDan dal = new EyouSoft.DAL.QianZhengStructure.DQianZhengDingDan();

        #region static constants
        //static constants
        #endregion

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BQianZhengDingDan() { }
        #endregion

        #region private members
        #endregion

        #region public members
        /// <summary>
        /// 写入订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo info)
        {
            if (info == null
                || string.IsNullOrEmpty(info.QianZhengId)
                || string.IsNullOrEmpty(info.XiaDanRenId)
                || info.YuDingShuLiang < 1)
                return 0;

            if (new BQianZheng().GetInfo(info.QianZhengId) == null) return -1; ;
            info.LatestTime = info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                //分销比例
                var jianglibi = new EyouSoft.Model.OtherStructure.MJiangJiBi();
                jianglibi.DingDanId = info.DingDanId;
                jianglibi.OrderType = EyouSoft.Model.OtherStructure.DingDanType.签证订单;
                jianglibi.JiangLiBiLi = new EyouSoft.BLL.OtherStructure.BKV().GetXiaJiFenXiaoJiangLiPeiZhi().JieSuanBiLi;
                new EyouSoft.BLL.OtherStructure.BTuiGuang().FenXiaoJiangli_C(jianglibi);
            }



            return dalRetCode;
        }

        /// <summary>
        /// 更新订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo info)
        {
            if (info == null
               || string.IsNullOrEmpty(info.QianZhengId)
               || string.IsNullOrEmpty(info.XiaDanRenId)
               || info.YuDingShuLiang < 1
               || string.IsNullOrEmpty(info.DingDanId))
                return 0;

            if (new BQianZheng().GetInfo(info.QianZhengId) == null) return -1;
            var yuaninfo = GetInfo(info.DingDanId);

            if (yuaninfo == null) return -2;

            if (yuaninfo.XiaDanRenId != info.XiaDanRenId) return -5;

            info.JinE = info.YuDingShuLiang * info.DanJia;

            int dalRetCode = dal.Update(info);

            return dalRetCode;
        }

        /// <summary>
        /// 删除订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <returns></returns>
        public int Delete(string dingDanId, string xiaDanRenId)
        {
            if (string.IsNullOrEmpty(dingDanId)
                || string.IsNullOrEmpty(xiaDanRenId)) return 0;

            var yuaninfo = GetInfo(dingDanId);

            if (yuaninfo == null) return -2;
            if (yuaninfo.DingDanStatus != EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理) return -3;
            if (yuaninfo.FuKuanStatus != EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款) return -4;
            if (yuaninfo.XiaDanRenId != xiaDanRenId) return -5;

            int dalRetCode = dal.Delete(dingDanId, xiaDanRenId);

            return dalRetCode;
        }

        /// <summary>
        /// 获取订单信息实体
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        public EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo GetInfo(string dingDanId)
        {
            if (string.IsNullOrEmpty(dingDanId)) return null;

            return dal.GetInfo(dingDanId);
        }

        /// <summary>
        /// 获取订单信息集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo> GetDingDans(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.QianZhengStructure.MQianZhengDingDanChaXunInfo chaXun)
        {
            if (!EyouSoft.Toolkit.Utils.ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetDingDans(pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <param name="dingDanStatus">状态</param>
        /// <returns></returns>
        public int SheZhiDingDanStatus(string dingDanId, string xiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus dingDanStatus)
        {
            if (string.IsNullOrEmpty(dingDanId) || string.IsNullOrEmpty(xiaDanRenId)) return 0;

            var info = GetInfo(dingDanId);

            //已付款只能更改成已成交
            if (info.FuKuanStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款
                && dingDanStatus != EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
                return -1;

            int dalRetCode = dal.SheZhiDingDanStatus(dingDanId, xiaDanRenId, dingDanStatus);

            return dalRetCode;
        }

        /// <summary>
        /// 设置付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <param name="fuKuanStatus">状态</param>
        /// <returns></returns>
        public int SheZhiFuKuanStatus(string dingDanId, string xiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus fuKuanStatus)
        {
            if (string.IsNullOrEmpty(dingDanId) || string.IsNullOrEmpty(xiaDanRenId)) return 0;

            int dalRetCode = dal.SheZhiFuKuanStatus(dingDanId, xiaDanRenId, fuKuanStatus, DateTime.Now);

            return dalRetCode;
        }
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        public int SheZhiZhiFus(EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo info)
        {
            if (string.IsNullOrEmpty(info.DingDanId)) return 0;
            return dal.SheZhiZhiFus(info);
        }
        /// <summary>
        /// 根据订单状态获取订单数量
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns></returns>
        public int GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status)
         {
            return dal.GetOrderNum(Status);
        }
        #endregion
    }
}
