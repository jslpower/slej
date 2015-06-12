using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.BLL;
using EyouSoft.Model.MallStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.BLL.MallStructure
{
    public class BShangChengShangPin : BLLBase
    {
        private readonly EyouSoft.IDAL.MallStructure.IShangCheng dal = new EyouSoft.DAL.MallStructure.DShangChengShangPin();
        /// <summary>
        /// 写入商品表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MShangChengShangPin info)
        {
            info.ProductID = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;
            if (info.ProductImgs != null && info.ProductImgs.Count > 0)
            {
                for (int i = 0; i < info.ProductImgs.Count; i++)
                {
                    info.ProductImgs[i].ProductID = info.ProductID;
                }
            }

            return dal.Insert(info);
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="ChanPinBianHao"></param>
        /// <returns>-99：产品下有订单 1：成功 其他返回值：失败</returns>
        public int Delete(string ChanPinBianHao)
        {
            if (string.IsNullOrEmpty(ChanPinBianHao)) return 0;
            return dal.Delete(ChanPinBianHao);
        }
        /// <summary>
        /// 获取商品信息实体
        /// </summary>
        /// <param name="ShangPinID">订单编号</param>
        /// <returns></returns>
        public MShangChengShangPin GetModel(string ShangPinID)
        {
            if (string.IsNullOrEmpty(ShangPinID)) return null;
            return dal.GetModel(ShangPinID);

        }
        /// <summary>
        /// 更新商品上下架
        /// </summary>
        /// <param name="ShangPinID">订单编号</param>
        /// <param name="isup">上架or下架（0-上架，1-下架）</param>
        /// <returns></returns>
        public int UpDateUp(string ShangPinID, EyouSoft.Model.Enum.XianLuStructure.XianLuZT isup)
        {
            if (string.IsNullOrEmpty(ShangPinID)) return 0;
            return dal.UpDateUp(ShangPinID,isup);

        }
        /// <summary>
        /// 更新商品，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(MShangChengShangPin info)
        {
            if (string.IsNullOrEmpty(info.ProductID) || info.TypeID == 0) return 0;
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
        public IList<MShangChengShangPin> GetList(int pageSize, int pageIndex, ref int recordCount, MShangChengShangPinSer chaXun)
        {
            return dal.GetList(pageSize, pageIndex, ref recordCount, chaXun);
        }
        /// <summary>
        /// 根据代理商id和商品id获取该商品在代理商网站的状态
        /// </summary>
        /// <param name="ShangPinID">商品id</param>
        /// <param name="MemberId">代理商id</param>
        /// <returns></returns>
        public int GetDaiLiPro(string ShangPinID, string MemberId)
        {
            if (string.IsNullOrEmpty(ShangPinID) || string.IsNullOrEmpty(MemberId)) return -2;
            return dal.GetDaiLiPro(ShangPinID, MemberId);
        }
        /// <summary>
        /// 更新商品上下架
        /// </summary>
        /// <param name="ShangPinID">商品id</param>
        /// <param name="isup">上架or下架（0-上架，1-下架）</param>
        /// <param name="MemberId">代理商id</param>
        /// <returns></returns>
        public int UpDateDaiLiUp(string ShangPinID, ProductZT isup, string MemberId)
        {
            if (string.IsNullOrEmpty(ShangPinID) || string.IsNullOrEmpty(MemberId)) return 0;
            return dal.UpDateDaiLiUp(ShangPinID, isup,MemberId);
        }
        /// <summary>
        /// 增加代理商产品
        /// </summary>
        /// <param name="ProductId">商品id</param>
        /// <param name="MemberId">代理商id</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public int AddDaiLiPro(string MemberId, string ProductId, int state)
        {
            if (string.IsNullOrEmpty(ProductId) || string.IsNullOrEmpty(MemberId)) return 0;
           return dal.AddDaiLiPro(MemberId, ProductId, state);
        }
        /// <summary>
        /// 删除代理商产品
        /// </summary>
        /// <param name="ProductId">商品id</param>
        /// <returns></returns>
        public int DelDaiLiPro(string ProductId)
        {
            if (string.IsNullOrEmpty(ProductId)) return 0;
            return dal.DelDaiLiPro(ProductId);
        }
         /// <summary>
        /// 获取代理商商品集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MShangChengShangPin> GetDaiLiList(int pageSize, int pageIndex, ref int recordCount, MDaiLiShangChanPinSer chaXun)
        {
            return dal.GetDaiLiList(pageSize, pageIndex, ref recordCount, chaXun);
        }
    }
}
