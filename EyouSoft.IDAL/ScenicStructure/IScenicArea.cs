using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.ScenicStructure.WebModel;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.IDAL.ScenicStructure
{

    public interface IScenicArea
    {
        #region 景区

        bool AddScenicArea(Model.ScenicStructure.MScenicArea model);

        bool UpdateScenicArea(Model.ScenicStructure.MScenicArea model);

        bool DeleteScenicArea(string Id);

        void SetScenicAreaClickNum(string Id);
        /// <summary>
        /// 修改状态
        /// </summary>
        int UpdateState(string Id, EyouSoft.Model.Enum.XianLuStructure.XianLuZT state);

        Model.ScenicStructure.MScenicArea GetScenicAreaById(string Id);
        Model.ScenicStructure.MScenicArea GetScenicAreaByName(string ScenicName);
       
        IList<Model.ScenicStructure.MScenicArea> GetScenicAreaList(int pageSize,int pageIndex,ref int RecordCount,MScenicAreaSearchModel search);

        IList<Model.ScenicStructure.MScenicArea> GetScenicAreaList(int top, MScenicAreaSearchModel search, bool isGetInterfaceData,bool hasImg,bool mustHasTicket);

        #endregion

        #region 景区图片

        bool AddScenicAreaImg(Model.ScenicStructure.MScenicAreaImg model);

        bool AddScenicAreaImg(string ScenicId, IList<EyouSoft.Model.ScenicStructure.MScenicAreaImg> list);

        bool UpdateScenicAreaImg(Model.ScenicStructure.MScenicAreaImg model);

        Model.ScenicStructure.MScenicAreaImg GetScenicAreaImgById(string Id);

        bool DeleteScenicAreaImg(string Id);

        IList<Model.ScenicStructure.MScenicAreaImg> GetScenicAreaImgList(string ScenicId);

        #endregion

        #region 景区订单
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        int SheZhiZhiFus(EyouSoft.Model.ScenicStructure.MScenicAreaOrder info);

        bool AddScenicAreaOrder(EyouSoft.Model.ScenicStructure.MScenicAreaOrder model);

        bool UpdateScenicAreaOrder(EyouSoft.Model.ScenicStructure.MScenicAreaOrder model);

        bool UpdateScenicAreaOrder(string OrderId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status);

        EyouSoft.Model.ScenicStructure.MScenicAreaOrder GetScenicAreaOrderModel(string orderId);

        IList<EyouSoft.Model.ScenicStructure.MScenicAreaOrder> GetScenicAreaOrderList(int pageSize, int pageIndex, ref int RecordCount, MScenicAreaOrderSearchModel search);

        bool UpdateScenicAreaOrderByUser(Model.ScenicStructure.MScenicAreaOrder model);

        /// <summary>
        /// 设置付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiFuKuanStatus(string orderId, string memberId, Model.Enum.XianLuStructure.FuKuanStatus status);

        #endregion

        /// <summary>
        /// 新增点评
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int InsertDianPing(EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo info);
        /// <summary>
        /// 修改点评
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int UpdateDianPing(EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo info);
        /// <summary>
        /// 删除点评
        /// </summary>
        /// <param name="dianPingId"></param>
        /// <returns></returns>
        int DeleteDianPing(string dianPingId);
        /// <summary>
        /// 获取点评
        /// </summary>
        /// <param name="dianPingId"></param>
        /// <returns></returns>
        EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo GetDianPingInfo(string dianPingId);
        /// <summary>
        /// 获取点评集合
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo> GetDianPings(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.ScenicStructure.MJingDianDianPingChaXunInfo chaXun);
        /// <summary>
        /// 审核点评
        /// </summary>
        /// <param name="dianPingId"></param>
        /// <param name="isShenHe"></param>
        /// <returns></returns>
        int ShenHeDianPing(string dianPingId, bool isShenHe);
        /// <summary>
        /// 获取满意度
        /// </summary>
        /// <param name="jingDianId"></param>
        /// <returns></returns>
        decimal GetManYiDu(string jingDianId);

        /// <summary>
        /// 获取门票剩余人数
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        int ScenicStrucNumber(string ticketId);
        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderId">订单id</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiOrderStatus(string orderId, OrderStatus status);
       /// <summary>
       /// 获取非接口景区列表
       /// </summary>
       /// <param name="top"></param>
       /// <param name="search"></param>
       /// <returns></returns>
        IList<EyouSoft.Model.ScenicStructure.MScenicArea> GetScenicAreaListNoInterface(int top, MScenicAreaSearchModel search);
        /// <summary>
        /// 根据订单状态获取订单数量
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns></returns>
        int GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status);
    }
}
