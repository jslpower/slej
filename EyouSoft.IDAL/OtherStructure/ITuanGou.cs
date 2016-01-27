using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.OtherStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface ITuanGou
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(EyouSoft.Model.OtherStructure.MTuanGouChanPin model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(EyouSoft.Model.OtherStructure.MTuanGouChanPin model);
        /// <summary>
        /// 删除数据
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        EyouSoft.Model.OtherStructure.MTuanGouChanPin GetModel(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.OtherStructure.MTuanGouChanPin> GetList(int PageSize, int PageIndex,string orderby ,ref int RecordCount, EyouSoft.Model.OtherStructure.MTuanGouChanPinSer serModel);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        IList<EyouSoft.Model.OtherStructure.MTuanGouChanPin> GetList(int Top, EyouSoft.Model.OtherStructure.MTuanGouChanPinSer serModel);
        /// <summary>
        /// 修改状态
        /// </summary>
        int UpdateState(string Id, EyouSoft.Model.Enum.XianLuStructure.XianLuZT state);
        /// <summary>
        /// 更新产品排序
        /// </summary>
        /// <param name="type">类别(租车，酒店，景区，线路，商城)</param>
        /// <param name="id">产品主id</param>
        /// <param name="xuhao">序号</param>
        /// <returns></returns>
        int UpdateProductSort(string type, string id, int xuhao);

        /// <summary>
        /// 根据表获取产品的排序
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetProductSort(string type, string id);

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
        IList<MTuanGouChanPin> GetDaiLiList(int pageSize, int pageIndex, ref int recordCount, MDaiLiTuanGouSer chaXun);
    }
}
