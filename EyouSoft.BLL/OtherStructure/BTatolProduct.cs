using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.OtherStructure;
using EyouSoft.Toolkit;

namespace EyouSoft.BLL.OtherStructure
{
    public class BTatolProduct
    {
        private readonly EyouSoft.IDAL.OtherStructure.ITatolProduct dal = new EyouSoft.DAL.OtherStructure.DTatolProduct();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BTatolProduct() { }
        #endregion

        #region 积分产品
        /// <summary>
        /// 增加一个积分产品
        /// </summary>
        public bool AddProduct(MTatolProduct model)
        {
            if (model != null && !string.IsNullOrEmpty(model.ProductName) && !string.IsNullOrEmpty(model.OperatorId))
            {
                return dal.AddProduct(model);
            }
            else
                return false;
        }
        /// <summary>
        /// 更新一个积分产品
        /// </summary>
        public bool UpdateProduct(MTatolProduct model)
        {
            if (model != null && model.ProductID > 0 && !string.IsNullOrEmpty(model.ProductName) && !string.IsNullOrEmpty(model.OperatorId))
                return dal.UpdateProduct(model);
            else
                return false;
        }
        /// <summary>
        /// 批量删除积分产品
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteProduct(params string[] ids)
        {
            if (ids != null && ids.Length > 0)
                return dal.DeleteProduct(ids);
            else
                return false;
        }
        /// <summary>
        /// 得到一个积分产品
        /// </summary>
        /// <param name="id">产品编号</param>
        /// <param name="MemberID">会员编号,可为空</param>
        /// <returns></returns>
        public MTatolProduct GetProductModel(int id, string MemberID)
        {
            if (id > 0)
                return dal.GetProductModel(id, MemberID);
            else
                return null;
        }
        /// <summary>
        /// 获得积分产品列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<MTatolProduct> GetProductList(int pageSize, int pageIndex, ref int recordCount, MTatolProductCX chaXun)
        {
            if (!Utils.ValidPaging(pageSize, pageIndex))
                return null;
            return dal.GetProductList(pageSize, pageIndex, ref recordCount, chaXun);
        }
        /// <summary>
        /// 获得积分产品前几行数据集合
        /// </summary>
        /// <param name="Top">0:所有</param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<MTatolProduct> GetProductTopList(int Top, MTatolProductCX chaXun)
        {
            return dal.GetProductTopList((Top < 0 ? 0 : Top), chaXun);
        }
        #endregion

        #region 积分兑换信息
        /// <summary>
        /// 得到会员累计积分
        /// </summary>
        /// <param name="MemberID">会员ID</param>
        /// <returns></returns>
        public MTatolProduct GetMemberTatal(string MemberID)
        {
            if (!string.IsNullOrEmpty(MemberID))
            {
                return dal.GetMemberTatal(MemberID);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 增加一条积分兑换信息
        /// </summary>
        public bool AddTotalToProduct(MTotalToProduct model)
        {
            if (model != null && !string.IsNullOrEmpty(model.MemberID) && model.ProductID > 0)
            {
                return dal.AddTotalToProduct(model);
            }
            else
                return false;
        }
        /// <summary>
        /// 更新一条积分兑换信息
        /// </summary>
        public bool UpdateTotalToProduct(MTotalToProduct model)
        {
            if (model != null && model.ID > 0 && !string.IsNullOrEmpty(model.MemberID) && model.ProductID > 0)
                return dal.UpdateTotalToProduct(model);
            else
                return false;
        }
        /// <summary>
        /// 批量删除积分兑换信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteTotalToProduct(params string[] ids)
        {
            if (ids != null && ids.Length > 0)
                return dal.DeleteTotalToProduct(ids);
            else
                return false;
        }
        /// <summary>
        /// 得到一条积分兑换信息
        /// </summary>
        public MTotalToProduct GetTotalToProductModel(int id)
        {
            if (id > 0)
                return dal.GetTotalToProductModel(id);
            else
                return null;
        }
        /// <summary>
        /// 获得积分兑换信息列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<MTotalToProduct> GetTotalToProductList(int pageSize, int pageIndex, ref int recordCount, MTotalToProductCX chaXun)
        {
            if (!Utils.ValidPaging(pageSize, pageIndex))
                return null;
            return dal.GetTotalToProductList(pageSize, pageIndex, ref recordCount, chaXun);
        }
        /// <summary>
        /// 获得积分兑换信息前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<MTotalToProduct> GetTotalToProductTopList(int Top, MTotalToProductCX chaXun)
        {
            return dal.GetTotalToProductTopList((Top < 0 ? 0 : Top), chaXun);
        }
        /// <summary>
        /// 改变兑换状态
        /// </summary>
        /// <param name="status">改变的状态</param>
        /// <param name="OperatorId">审核人</param>
        /// <param name="ids">改变的ids</param>
        /// <returns></returns>
        public bool SetExchange(EyouSoft.Model.Enum.ExchangeStatus status, int OperatorId, params string[] ids)
        {
            if (ids != null && ids.Length > 0)
                return dal.SetExchange(status, OperatorId, ids);
            else
                return false;
        }
        #endregion

        #region 积分获取信息
        /// <summary>
        /// 验证会员积分是否添加
        /// </summary>
        /// <param name="OrderId">订单编号</param>
        /// <param name="MemberID">会员编号</param>
        /// <returns></returns>
        public bool ExistsMemberTotal(string OrderId, string MemberID)
        {
            if (!string.IsNullOrEmpty(MemberID) && !string.IsNullOrEmpty(OrderId))
            {
                return dal.ExistsMemberTotal(OrderId, MemberID);
            }
            else
                return false;
        }
        /// <summary>
        /// 增加一条积分获取信息
        /// </summary>
        public bool AddMemberTotal(MMemberTotal model)
        {
            if (model != null && !string.IsNullOrEmpty(model.MemberID) && !string.IsNullOrEmpty(model.OrderId) && (int)model.OrderType > 0)
            {
                return dal.AddMemberTotal(model);
            }
            else
                return false;
        }
        /// <summary>
        /// 更新一条积分获取信息
        /// </summary>
        public bool UpdateMemberTotal(MMemberTotal model)
        {
            if (model != null && model.ID > 0 && !string.IsNullOrEmpty(model.MemberID) && !string.IsNullOrEmpty(model.OrderId) && (int)model.OrderType > 0)
                return dal.UpdateMemberTotal(model);
            else
                return false;
        }
        /// <summary>
        /// 根据会员编号和订单编号删除积分获取信息
        /// </summary>
        /// <param name="MemberID">会员编号</param>
        /// <param name="OrderId">订单编号</param>
        /// <returns></returns>
        public bool DeleteMemberTotal(string MemberID, string OrderId)
        {
            if (!string.IsNullOrEmpty(OrderId) || !string.IsNullOrEmpty(MemberID))
                return dal.DeleteMemberTotal(MemberID, OrderId);
            else
                return false;
        }
        /// <summary>
        /// 批量删除积分获取信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteMemberTotal(params string[] ids)
        {
            if (ids != null && ids.Length > 0)
                return dal.DeleteMemberTotal(ids);
            else
                return false;
        }
        /// <summary>
        /// 得到一条积分获取信息
        /// </summary>
        public MMemberTotal GetMemberTotalModel(int id)
        {
            if (id > 0)
                return dal.GetMemberTotalModel(id);
            else
                return null;
        }
        /// <summary>
        /// 获得积分获取信息列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<MMemberTotal> GetMemberTotalList(int pageSize, int pageIndex, ref int recordCount, MMemberTotalCX chaXun)
        {
            if (!Utils.ValidPaging(pageSize, pageIndex))
                return null;
            return dal.GetMemberTotalList(pageSize, pageIndex, ref recordCount, chaXun);
        }
        ///// <summary>
        ///// 获得积分获取信息前几行数据集合
        ///// </summary>
        ///// <param name="Top"></param>
        ///// <param name="chaXun"></param>
        ///// <returns></returns>
        //public IList<MMemberTotal> GetMemberTotalTopList(int Top, MMemberTotalCX chaXun)
        //{
        //    return dal.GetMemberTotalTopList((Top < 0 ? 0 : Top), chaXun);
        //}
        #endregion

        #region 会员联系信息
        /// <summary>
        /// 增加一条会员联系信息
        /// </summary>
        public bool AddMemberContact(MMemberContact model)
        {
            if (model != null && !string.IsNullOrEmpty(model.MemberID) && !string.IsNullOrEmpty(model.MemberName) && !string.IsNullOrEmpty(model.Mobile) && !string.IsNullOrEmpty(model.Address))
            {
                return dal.AddMemberContact(model);
            }
            else
                return false;
        }
        /// <summary>
        /// 更新一条会员联系信息
        /// </summary>
        public bool UpdateMemberContact(MMemberContact model)
        {
            if (model != null && model.ID > 0 && !string.IsNullOrEmpty(model.MemberID) && !string.IsNullOrEmpty(model.MemberName) && !string.IsNullOrEmpty(model.Mobile) && !string.IsNullOrEmpty(model.Address))
                return dal.UpdateMemberContact(model);
            else
                return false;
        }
        /// <summary>
        /// 根据联系信息编号或会员编号删除会员联系信息
        /// 如果联系编号为0，则根据会员编号删除该会员的所有联系信息
        /// </summary>
        /// <returns></returns>
        public bool DeleteMemberContact(int Id, string MemberID)
        {
            if (Id > 0 || !string.IsNullOrEmpty(MemberID))
                return dal.DeleteMemberContact(Id, MemberID);
            else
                return false;
        }
        /// <summary>
        /// 批量删除会员联系信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteMemberContact(params string[] ids)
        {
            if (ids != null && ids.Length > 0)
                return dal.DeleteMemberContact(ids);
            else
                return false;
        }
        /// <summary>
        /// 得到一条会员联系信息
        /// </summary>
        public MMemberContact GetMemberContact(int id)
        {
            if (id > 0)
                return dal.GetMemberContact(id);
            else
                return null;
        }
        /// <summary>
        /// 根据会员编号获得会员联系信息前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<MMemberContact> GetMemberContactTopList(int Top, string MemberID)
        {
            return dal.GetMemberContactTopList((Top < 0 ? 0 : Top), MemberID);
        }
        #endregion
    }
}
