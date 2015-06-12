using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.MallStructure;

namespace EyouSoft.IDAL.MallStructure
{
    public interface ILianMeng
    {
        #region  联盟类别
        /// <summary>
        /// 判断类别名是否存在
        /// </summary>
        /// <param name="XiLieMingCheng">系列名称</param>
        /// <returns></returns>
        bool ExistsXLName(string MingCheng);
        /// <summary>
        /// 写入类别表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MLianMengLeiBie info);
        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="ChanPinBianHao"></param>
        /// <returns>-99：产品下有链接 1：成功 其他返回值：失败</returns>
        int DeleteLB(string ChanPinBianHao);
        /// <summary>
        /// 获取类别信息 
        /// </summary>
        /// <param name="LeiBieID">类别编号</param>
        /// <returns></returns>
        MLianMengLeiBie GetModelLB(int LeiBieID);
        /// <summary>
        /// 更新类别，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int Update(MLianMengLeiBie info);
        /// <summary>
        /// 获取类别集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<MLianMengLeiBie> GetList(int pageSize, int pageIndex, ref int recordCount, MLianMengLeiBieSer chaXun);
        #endregion

        /// <summary>
        /// 写入链接表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MLianMeng info);
        /// <summary>
        /// 删除链接
        /// </summary>
        /// <param name="ChanPinBianHao"></param>
        /// <returns> 1：成功 其他返回值：失败</returns>
        int Delete(string ChanPinBianHao);
        /// <summary>
        /// 获取商品信息实体
        /// </summary>
        /// <param name="LeiBieID">订单编号</param>
        /// <returns></returns>
        MLianMeng GetModel(int LeiBieID);
        /// <summary>
        /// 更新链接信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int Update(MLianMeng info);
        /// <summary>
        /// 获取商链接集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<MLianMeng> GetList(int pageSize, int pageIndex, ref int recordCount, MLianMengSer chaXun);


    }
}
