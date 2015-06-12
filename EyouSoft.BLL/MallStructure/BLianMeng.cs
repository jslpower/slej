using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.BLL;
using EyouSoft.Model.MallStructure;

namespace EyouSoft.BLL.MallStructure
{
    public class BLianMeng : BLLBase
    {
        private readonly EyouSoft.IDAL.MallStructure.ILianMeng dal = new EyouSoft.DAL.MallStructure.DLianMeng();
        #region 联盟类别
        /// <summary>
        /// 判断类别名是否存在
        /// </summary>
        /// <param name="XiLieMingCheng">系列名称</param>
        /// <returns></returns>
        public bool ExistsXLName(string MingCheng)
        {
            if (string.IsNullOrEmpty(MingCheng)) return false;
            return dal.ExistsXLName(MingCheng);
        }
        /// <summary>
        /// 写入类别表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MLianMengLeiBie info)
        {
            return dal.Insert(info);
        }
        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="ChanPinBianHao">类别编号</param>
        /// <returns>-99：产品下有订单 1：成功 其他返回值：失败</returns>
        public int DeleteLB(string ChanPinBianHao)
        {
            if (string.IsNullOrEmpty(ChanPinBianHao)
                || ChanPinBianHao == "0") return 0;
            return dal.DeleteLB(ChanPinBianHao);
        }
        /// <summary>
        /// 获取类别信息实体
        /// </summary>
        /// <param name="LeiBieID">类别编号</param>
        /// <returns></returns>
        public MLianMengLeiBie GetModelLB(int LeiBieID)
        {
            if (LeiBieID == 0) return null;
            return dal.GetModelLB(LeiBieID);
        }
        /// <summary>
        /// 更新商品，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(MLianMengLeiBie info)
        {
            if (info.LeiBieID == 0) return 0;
            return dal.Update(info);
        }
        /// <summary>
        /// 获取商品集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MLianMengLeiBie> GetList(int pageSize, int pageIndex, ref int recordCount, MLianMengLeiBieSer chaXun)
        {
            return dal.GetList(pageSize, pageIndex, ref recordCount, chaXun);
        }
        #endregion

        #region 链接
        /// <summary>
        /// 写入链接表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MLianMeng info)
        {
            if (string.IsNullOrEmpty(info.SiteName)
                                      || string.IsNullOrEmpty(info.SiteUrl)
                                      || string.IsNullOrEmpty(info.OperatorID)) return 0;
            info.IssueTime = DateTime.Now;
            return dal.Insert(info);
        }
        /// <summary>
        /// 删除链接
        /// </summary>
        /// <param name="ChanPinBianHao"></param>
        /// <returns> 1：成功 其他返回值：失败</returns>
        public int Delete(string ChanPinBianHao)
        {
            if (string.IsNullOrEmpty(ChanPinBianHao) || ChanPinBianHao == "0") return 0;
            return dal.Delete(ChanPinBianHao);
        }
        /// <summary>
        /// 获取商品信息实体
        /// </summary>
        /// <param name="LeiBieID">订单编号</param>
        /// <returns></returns>
        public MLianMeng GetModel(int LeiBieID)
        {
            if (LeiBieID == 0) return null;
            return dal.GetModel(LeiBieID);
        }
        /// <summary>
        /// 更新链接信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(MLianMeng info)
        {
            if (info.ID == 0) return 0;
            return dal.Update(info);
        }
        /// <summary>
        /// 获取商链接集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MLianMeng> GetList(int pageSize, int pageIndex, ref int recordCount, MLianMengSer chaXun)
        {
            return dal.GetList(pageSize, pageIndex, ref recordCount, chaXun);
        }
        #endregion
    }
}
