using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.OtherStructure;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface ITatolProduct
    {
        #region 积分产品
        /// <summary>
        /// 增加一个积分产品
        /// </summary>
        bool AddProduct(MTatolProduct model);
        /// <summary>
        /// 更新一个积分产品
        /// </summary>
        bool UpdateProduct(MTatolProduct model);
        /// <summary>
        /// 批量删除积分产品
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteProduct(params string[] ids);
        /// <summary>
        /// 得到一个积分产品
        /// </summary>
        MTatolProduct GetProductModel(int id, string MemberID);
        /// <summary>
        /// 获得积分产品列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        IList<MTatolProduct> GetProductList(int pageSize, int pageIndex, ref int recordCount, MTatolProductCX chaXun);
        /// <summary>
        /// 获得积分产品前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        IList<MTatolProduct> GetProductTopList(int Top, MTatolProductCX chaXun);
        #endregion

        #region 积分兑换信息
        /// <summary>
        /// 增加一条积分兑换信息
        /// </summary>
        bool AddTotalToProduct(MTotalToProduct model);
        /// <summary>
        /// 更新一条积分兑换信息
        /// </summary>
        bool UpdateTotalToProduct(MTotalToProduct model);
        /// <summary>
        /// 批量删除积分兑换信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteTotalToProduct(params string[] ids);
        /// <summary>
        /// 得到一条积分兑换信息
        /// </summary>
        MTotalToProduct GetTotalToProductModel(int id);
        /// <summary>
        /// 获得积分兑换信息列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        IList<MTotalToProduct> GetTotalToProductList(int pageSize, int pageIndex, ref int recordCount, MTotalToProductCX chaXun);
        /// <summary>
        /// 获得积分兑换信息前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        IList<MTotalToProduct> GetTotalToProductTopList(int Top, MTotalToProductCX chaXun);
        /// <summary>
        /// 改变兑换状态
        /// </summary>
        /// <param name="status">改变的状态</param>
        /// <param name="OperatorId">审核人</param>
        /// <param name="ids">改变的ids</param>
        /// <returns></returns>
        bool SetExchange(EyouSoft.Model.Enum.ExchangeStatus status, int OperatorId, params string[] ids);
        #endregion

        #region 积分获取信息
        /// <summary>
        /// 得到会员累计积分
        /// </summary>
        /// <param name="MemberID">会员ID</param>
        /// <returns></returns>
        MTatolProduct GetMemberTatal(string MemberID);


        /// <summary>
        /// 验证会员积分是否添加
        /// </summary>
        /// <param name="OrderId">订单编号</param>
        /// <param name="MemberID">会员编号</param>
        /// <returns></returns>
        bool ExistsMemberTotal(string OrderId, string MemberID);
        /// <summary>
        /// 增加一条积分获取信息
        /// </summary>
        bool AddMemberTotal(MMemberTotal model);
        /// <summary>
        /// 更新一条积分获取信息
        /// </summary>
        bool UpdateMemberTotal(MMemberTotal model);
        /// <summary>
        /// 根据会员编号和订单编号删除积分获取信息
        /// </summary>
        /// <returns></returns>
        bool DeleteMemberTotal(string MemberID, string OrderId);
        /// <summary>
        /// 批量删除积分获取信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteMemberTotal(params string[] ids);
        /// <summary>
        /// 得到一条积分获取信息
        /// </summary>
        MMemberTotal GetMemberTotalModel(int id);
        /// <summary>
        /// 获得积分获取信息列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        IList<MMemberTotal> GetMemberTotalList(int pageSize, int pageIndex, ref int recordCount, MMemberTotalCX chaXun);
        ///// <summary>
        ///// 获得积分获取信息前几行数据集合
        ///// </summary>
        ///// <param name="Top"></param>
        ///// <param name="chaXun"></param>
        ///// <returns></returns>
        //IList<MMemberTotal> GetMemberTotalTopList(int Top, MMemberTotalCX chaXun);
        #endregion

        #region 会员联系信息
        /// <summary>
        /// 增加一条会员联系信息
        /// </summary>
        bool AddMemberContact(MMemberContact model);
        /// <summary>
        /// 更新一条会员联系信息
        /// </summary>
        bool UpdateMemberContact(MMemberContact model);
        /// <summary>
        /// 根据联系信息编号或会员编号删除会员联系信息
        /// </summary>
        /// <returns></returns>
        bool DeleteMemberContact(int Id, string MemberID);
        /// <summary>
        /// 批量删除会员联系信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteMemberContact(params string[] ids);
        /// <summary>
        /// 得到一条会员联系信息
        /// </summary>
        MMemberContact GetMemberContact(int id);
        /// <summary>
        /// 根据会员编号获得会员联系信息前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        IList<MMemberContact> GetMemberContactTopList(int Top, string MemberID);
        #endregion
    }
}
