using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.OtherStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.BLL.OtherStructure
{
    public class BTuanGou
    {
        private readonly EyouSoft.IDAL.OtherStructure.ITuanGou dal = new EyouSoft.DAL.OtherStructure.DTuanGou();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EyouSoft.Model.OtherStructure.MTuanGouChanPin model)
        {
            model.IssueTime = DateTime.Now;
            if (string.IsNullOrEmpty(model.OperatorID) ||
                string.IsNullOrEmpty(model.SupplierID)) return 0;
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(EyouSoft.Model.OtherStructure.MTuanGouChanPin model)
        {
            if (model.ID == 0) return 0;
            return dal.Update(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            if (ID == 0) return 0;
            return dal.Delete(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EyouSoft.Model.OtherStructure.MTuanGouChanPin GetModel(int ID)
        {
            if (ID == 0) return null;
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MTuanGouChanPin> GetList(int PageSize, int PageIndex, string orderby, ref int RecordCount, EyouSoft.Model.OtherStructure.MTuanGouChanPinSer serModel)
        {
            return dal.GetList(PageSize, PageIndex, orderby, ref RecordCount, serModel);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MTuanGouChanPin> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.OtherStructure.MTuanGouChanPinSer serModel)
        {
            return dal.GetList(PageSize, PageIndex, null, ref RecordCount, serModel);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IList<EyouSoft.Model.OtherStructure.MTuanGouChanPin> GetList(int Top, EyouSoft.Model.OtherStructure.MTuanGouChanPinSer serModel)
        {
            return dal.GetList(Top, serModel);
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        public bool UpdateState(string Id, EyouSoft.Model.Enum.XianLuStructure.XianLuZT state)
        {
            if (string.IsNullOrEmpty(Id) && state == null) return false;
            return dal.UpdateState(Id, state) > 0 ? true : false;
        }
        /// <summary>
        /// 更新产品排序
        /// </summary>
        /// <param name="type">类别(租车，酒店，景区，线路，商城)</param>
        /// <param name="id">产品主id</param>
        /// <param name="xuhao">序号</param>
        /// <returns></returns>
        public int UpdateProductSort(string type, string id, int xuhao)
        {
            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(id)) return 0;
            return dal.UpdateProductSort(type, id, xuhao);
        }
        /// <summary>
        /// 根据表获取产品的排序
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetProductSort(string type, string id)
        {
            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(id)) return 0;
            return dal.GetProductSort(type, id);
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
            return dal.UpDateDaiLiUp(ShangPinID, isup, MemberId);
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
        public IList<MTuanGouChanPin> GetDaiLiList(int pageSize, int pageIndex, ref int recordCount, MDaiLiTuanGouSer chaXun)
        {
            return dal.GetDaiLiList(pageSize, pageIndex, ref recordCount, chaXun);
        }
    }
}
