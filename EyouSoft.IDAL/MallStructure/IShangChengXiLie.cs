using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.MallStructure;

namespace EyouSoft.IDAL.MallStructure
{
    public interface IShangChengXiLie
    {
        /// <summary>
        /// 判断系列名是否存在
        /// </summary>
        /// <param name="XiLieMingCheng">系列名称</param>
        /// <returns></returns>
        bool ExistsXLName(string XiLieMingCheng);
        /// <summary>
        /// 写入商品表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MShangChengLeiBie info);
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="ChanPinBianHao"></param>
        /// <returns>-99：产品下有订单 1：成功 其他返回值：失败</returns>
        int Delete(string ChanPinBianHao);
        /// <summary>
        /// 获取商品信息实体
        /// </summary>
        /// <param name="LeiBieID">订单编号</param>
        /// <returns></returns>
        MShangChengLeiBie GetModel(int LeiBieID);
        /// <summary>
        /// 更新商品，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int Update(MShangChengLeiBie info);
        /// <summary>
        /// 获取商品集合
        /// </summary>
        /// <param name="chaXun">查询</param>
        /// <param name="ShiFouDingJi">是否只获取顶级分类</param>
        /// <returns></returns>
        IList<MShangChengLeiBie> GetList(MShangChengLeiBieSer chaXun, bool ShiFouDingJi);
        /// <summary>
        /// 获取商品集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<MShangChengLeiBie> GetList(int pageSize, int pageIndex, ref int recordCount, MShangChengLeiBieSer chaXun);
    }
}
