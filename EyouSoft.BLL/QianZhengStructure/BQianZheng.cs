//签证信息 汪奇志 2013-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.BLL.QianZhengStructure
{
    /// <summary>
    /// 签证信息
    /// </summary>
    public class BQianZheng
    {
        private readonly EyouSoft.IDAL.QianZhengStructure.IQianZheng dal = new EyouSoft.DAL.QianZhengStructure.DQianZheng();

        #region static constants
        //static constants
        #endregion

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BQianZheng() { }
        #endregion

        #region private members
        /// <summary>
        /// 获取签证下订单数
        /// </summary>
        /// <param name="qianZhengId">签证编号</param>
        /// <returns></returns>
        int GetDingDanShu(string qianZhengId)
        {
            if (string.IsNullOrEmpty(qianZhengId)) return 1;

            return dal.GetDingDanShu(qianZhengId);
        }
        #endregion

        #region public members
        /// <summary>
        /// 写入签证信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.QianZhengStructure.MQianZhengInfo info)
        {
            if (info == null
                || info.GuoJiaId < 1
                || info.FaBuRenId < 1
                || string.IsNullOrEmpty(info.Name)) return 0;

            info.QianZhengId = Guid.NewGuid().ToString();
            info.LatestTime = info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Insert(info);

            return dalRetCode;
        }

        /// <summary>
        /// 更新签证信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.QianZhengStructure.MQianZhengInfo info)
        {
            if (info == null
                || info.GuoJiaId < 1
                || info.FaBuRenId < 1
                || string.IsNullOrEmpty(info.Name)
                || string.IsNullOrEmpty(info.QianZhengId)) return 0;

            if (GetDingDanShu(info.QianZhengId) > 0) return -1;
            
            info.LatestTime = info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Update(info);

            return dalRetCode;
        }

        /// <summary>
        /// 删除签证信息，返回1成功，其它失败
        /// </summary>
        /// <param name="qianZhengId">签证编号</param>
        /// <param name="faBuRenId">发布人编号</param>
        /// <returns></returns>
        public int Delete(string qianZhengId, int faBuRenId)
        {
            if (string.IsNullOrEmpty(qianZhengId) 
                || faBuRenId < 1) return 0;

            if (GetDingDanShu(qianZhengId) > 0) return -1;

            int dalRetCode = dal.Delete(qianZhengId, faBuRenId);

            return dalRetCode;
        }


        /// <summary>
        /// 获取签证信息业务实体
        /// </summary>
        /// <param name="qianZhengId">签证编号</param>
        /// <returns></returns>
        public EyouSoft.Model.QianZhengStructure.MQianZhengInfo GetInfo(string qianZhengId)
        {
            if (string.IsNullOrEmpty(qianZhengId)) return null;

            return dal.GetInfo(qianZhengId);
        }

        /// <summary>
        /// 获取签证信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.QianZhengStructure.MQianZhengInfo> GetQianZhengs(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.QianZhengStructure.MQianZhengChaXunInfo chaXun)
        {
            if (!EyouSoft.Toolkit.Utils.ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetQianZhengs(pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 根据条件获取前几条数据
        /// </summary>
        /// <param name="top">数据量</param>
        /// <param name="chaXun">条件</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.QianZhengStructure.MQianZhengInfo> GetTopQianZheng(int top ,EyouSoft.Model.QianZhengStructure.MQianZhengChaXunInfo chaXun)
        {
            if (string.IsNullOrEmpty(top.ToString())) return null;
            return dal.GetTopQianZheng(top, chaXun);
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <param name="history">订单变更记录信息</param>
        /// <returns></returns>
        public int SheZhiOrderStatus(string orderId, OrderStatus status)
        {
            if (string.IsNullOrEmpty(orderId)) return 0;

            int dalRetCode = dal.SheZhiOrderStatus(orderId, status);

            return dalRetCode;
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        public bool UpdateState(string Id, EyouSoft.Model.Enum.XianLuStructure.XianLuZT state)
        {
            if (string.IsNullOrEmpty(Id) && state == null) return false;
            return dal.UpdateState(Id, state) > 0 ? true : false;
        }
        #endregion
    }
}
