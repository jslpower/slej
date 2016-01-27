using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.MallStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.IDAL.MallStructure
{
    /// <summary>
    /// 线路产品订单相关信息数据访问类接口
    /// </summary>
    public interface IShangCheng
    {
        /// <summary>
        /// 写入商品表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MShangChengShangPin info);
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="ChanPinBianHao"></param>
        /// <returns>-99：产品下有订单 1：成功 其他返回值：失败</returns>
        int Delete(string ChanPinBianHao);
        /// <summary>
        /// 获取商品信息实体
        /// </summary>
        /// <param name="ShangPinID">订单编号</param>
        /// <returns></returns>
        MShangChengShangPin GetModel(string ShangPinID);
        /// <summary>
        /// 更新商品，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int Update(MShangChengShangPin info);
        /// <summary>
        /// 获取商品集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<MShangChengShangPin> GetList(int pageSize, int pageIndex, ref int recordCount, MShangChengShangPinSer chaXun);
        /// <summary>
        /// 更新商品上下架
        /// </summary>
        /// <param name="ShangPinID">订单编号</param>
        /// <param name="isup">上架or下架（0-上架，1-下架）</param>
        /// <returns></returns>
        int UpDateUp(string ShangPinID, EyouSoft.Model.Enum.XianLuStructure.XianLuZT isup);
        /// <summary>
        /// 根据代理商id和商品id获取该商品在代理商网站的状态
        /// </summary>
        /// <param name="ShangPinID">商品id</param>
        /// <param name="MemberId">代理商id</param>
        /// <returns></returns>
        int GetDaiLiPro(string ShangPinID, string MemberId);
        /// <summary>
        /// 更新商品上下架
        /// </summary>
        /// <param name="ShangPinID">商品id</param>
        /// <param name="isup">上架or下架（0-上架，1-下架）</param>
        /// <param name="MemberId">代理商id</param>
        /// <returns></returns>
        int UpDateDaiLiUp(string ShangPinID, ProductZT isup, string MemberId);

        /// <summary>
        /// 更新商品上下架
        /// </summary>
        /// <param name="ShangPinID">商品[]id</param>
        /// <param name="isup">上架or下架（0-上架，1-下架）</param>
        /// <param name="MemberId">代理商id</param>
        /// <returns></returns>
        int UpDateDaiLiUp(string[] ShangPinID, ProductZT isup, string MemberId);
        /// <summary>
        /// 增加代理商产品
        /// </summary>
        /// <param name="ProductId">商品id</param>
        /// <param name="MemberId">代理商id</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        int AddDaiLiPro(string MemberId, string ProductId, int state);
        /// <summary>
        /// 删除代理商产品
        /// </summary>
        /// <param name="ProductId">商品id</param>
        /// <returns></returns>
        int DelDaiLiPro(string ProductId);
         /// <summary>
        /// 获取代理商商品集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<MShangChengShangPin> GetDaiLiList(int pageSize, int pageIndex, ref int recordCount, MDaiLiShangChanPinSer chaXun);
        /// <summary>
        /// 更新产品排序
        /// </summary>
        /// <param name="DaiLiId">代理id</param>
        /// <param name="id">产品主id</param>
        /// <param name="xuhao">序号</param>
        /// <returns></returns>
        int UpdateProductSort(string DaiLiId, string id, int xuhao);
        /// <summary>
        /// 根据表获取产品的排序
        /// </summary>
        /// <param name="dailiid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetProductSort(string dailiid, string id);
    }
}
