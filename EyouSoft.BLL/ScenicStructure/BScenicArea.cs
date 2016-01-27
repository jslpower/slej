using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.ScenicStructure;
using EyouSoft.Model.ScenicStructure.WebModel;
using EyouSoft.DAL.SystemStructure;
using EyouSoft.Model.SystemStructure;
using Linq.Expressions;
using EyouSoft.DAL.ScenicStructure;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.BLL.ScenicStructure
{
   public class BScenicArea
   {
      EyouSoft.IDAL.ScenicStructure.IScenicArea dal = new EyouSoft.DAL.ScenicStructure.DScenicArea();



      #region IScenicArea 成员

      /// <summary>
      /// 添加景点
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool AddScenicArea(Model.ScenicStructure.MScenicArea model)
      {
         if (string.IsNullOrEmpty(model.OperatorId)
             || string.IsNullOrEmpty(model.ScenicName)
             || model.ProvinceId == 0
             || model.CityId == 0
             || string.IsNullOrEmpty(model.Description)) return false;

         model.ScenicId = Guid.NewGuid().ToString();

         return dal.AddScenicArea(model);
      }


      public bool AddScenicArea2(Model.ScenicStructure.MScenicArea model)
      {
         if (string.IsNullOrEmpty(model.OperatorId)
             || string.IsNullOrEmpty(model.ScenicName)
             || model.ProvinceId == 0
             || model.CityId == 0
             || string.IsNullOrEmpty(model.Description)) return false;

         return dal.AddScenicArea(model);
      }

      /// <summary>
      /// 修改景点
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool UpdateScenicArea(Model.ScenicStructure.MScenicArea model)
      {
         if (string.IsNullOrEmpty(model.OperatorId)
            || string.IsNullOrEmpty(model.ScenicName)
            || model.ProvinceId == 0
            || model.CityId == 0
            || string.IsNullOrEmpty(model.Description) || string.IsNullOrEmpty(model.ScenicId)) return false;

         return dal.UpdateScenicArea(model);
      }

      /// <summary>
      /// 删除景区
      /// </summary>
      /// <param name="Id"></param>
      /// <returns></returns>
      public bool DeleteScenicArea(string Id)
      {
         if (string.IsNullOrEmpty(Id)) return false;

         return dal.DeleteScenicArea(Id);
      }
      /// <summary>
      /// 设置点击次数
      /// </summary>
      public void SetScenicAreaClickNum(string Id)
      {
         if (!string.IsNullOrEmpty(Id))
         {
            dal.SetScenicAreaClickNum(Id);
         }
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
      /// 获取实体
      /// </summary>
      /// <param name="Id"></param>
      /// <returns></returns>
      public Model.ScenicStructure.MScenicArea GetScenicAreaById(string Id)
      {
         if (string.IsNullOrEmpty(Id)) return null;
         return dal.GetScenicAreaById(Id);
      }


      public MScenicArea GetScenicAreaByName(string ScenicName)
      {
         if (string.IsNullOrEmpty(ScenicName)) return null;
         return dal.GetScenicAreaByName(ScenicName);
      }

      /// <summary>
      /// 分页获取集合
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="RecordCount"></param>
      /// <param name="search"></param>
      /// <returns></returns>
      public IList<Model.ScenicStructure.MScenicArea> GetScenicAreaList(int pageSize, int pageIndex, ref int RecordCount, MScenicAreaSearchModel search)
      {
         var items = dal.GetScenicAreaList(pageSize, pageIndex, ref RecordCount, search);
         return items;
      }
      public IList<Model.ScenicStructure.MScenicArea> GetScenicAreaListAll(int top, MScenicAreaSearchModel search)
      {
         return dal.GetScenicAreaList(top, search, true, false, false);
      }
      /// <summary>
      /// 获取景区信息
      /// </summary>
      /// <param name="top">top条数，小于等于0取所有</param>
      /// <param name="search">查询实体</param>
      /// <returns></returns>
      public IList<Model.ScenicStructure.MScenicArea> GetScenicAreaList(int top, MScenicAreaSearchModel search)
      {
         return dal.GetScenicAreaList(top, search, true, true, true);
      }

      /// <summary>
      /// 获取非接口而来的景区list
      /// </summary>
      /// <param name="top">top条数，小于等于0取所有</param>
      /// <param name="search">查询实体</param>
      /// <returns></returns>
      public IList<Model.ScenicStructure.MScenicArea> GetScenicAreaListNoInterface(int top, MScenicAreaSearchModel search)
      {
         return dal.GetScenicAreaListNoInterface(top, search);
      }

      #endregion


      #region IScenicArea 景区图片

      /// <summary>
      /// 添加景区图片
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool AddScenicAreaImg(Model.ScenicStructure.MScenicAreaImg model)
      {
         if (string.IsNullOrEmpty(model.ScenicId)) return false;

         model.ImgId = Guid.NewGuid().ToString();

         return dal.AddScenicAreaImg(model);
      }

      /// <summary>
      /// 批量添加景区图片
      /// </summary>
      /// <param name="list"></param>
      /// <returns></returns>
      public bool AddScenicAreaImg(string ScenicId, IList<EyouSoft.Model.ScenicStructure.MScenicAreaImg> list)
      {
         if (string.IsNullOrEmpty(ScenicId)) return false;
         return dal.AddScenicAreaImg(ScenicId, list);
      }

      /// <summary>
      /// 修改景区图片
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool UpdateScenicAreaImg(Model.ScenicStructure.MScenicAreaImg model)
      {
         if (string.IsNullOrEmpty(model.ImgId) || string.IsNullOrEmpty(model.ScenicId)) return false;

         return dal.UpdateScenicAreaImg(model);

      }

      /// <summary>
      /// 根据图片编号获取实体
      /// </summary>
      /// <param name="Id"></param>
      /// <returns></returns>
      public Model.ScenicStructure.MScenicAreaImg GetScenicAreaImgById(string Id)
      {
         if (string.IsNullOrEmpty(Id)) return null;
         return dal.GetScenicAreaImgById(Id);
      }

      /// <summary>
      /// 根据图片编号删除图片
      /// </summary>
      /// <param name="Id"></param>
      /// <returns></returns>
      public bool DeleteScenicAreaImg(string Id)
      {
         if (string.IsNullOrEmpty(Id)) return false;
         return dal.DeleteScenicAreaImg(Id);
      }

      /// <summary>
      /// 根据景区集合获取集合
      /// </summary>
      /// <returns></returns>
      public IList<EyouSoft.Model.ScenicStructure.MScenicAreaImg> GetScenicAreaImgList(string ScenicId)
      {
         if (string.IsNullOrEmpty(ScenicId)) return null;

         return dal.GetScenicAreaImgList(ScenicId);
      }

      #endregion



      #region 景区订单
      /// <summary>
      /// 添加景区订单
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool AddScenicAreaOrder(EyouSoft.Model.ScenicStructure.MScenicAreaOrder model)
      {
         if (string.IsNullOrEmpty(model.ScenicId) || string.IsNullOrEmpty(model.TicketsId) || model.Price == 0
             || model.Num == 0 || string.IsNullOrEmpty(model.ContactName) || string.IsNullOrEmpty(model.ContactTel)) return false;

         model.OrderId = Guid.NewGuid().ToString();

         bool dalRetCode = dal.AddScenicAreaOrder(model);

         if (dalRetCode)
         {
            //发送短信
            //new EyouSoft.BLL.OtherStructure.BSms().FaSongDingDanDuanXin(3, model.OrderId, EyouSoft.Model.Enum.SmsFaSongLeiXing.下单);
         }

         return dalRetCode;

      }
      /// <summary>
      /// 修改景区订单
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool UpdateScenicAreaOrder(EyouSoft.Model.ScenicStructure.MScenicAreaOrder model)
      {
         if (string.IsNullOrEmpty(model.OrderId) || string.IsNullOrEmpty(model.ScenicId) || string.IsNullOrEmpty(model.TicketsId)
             || model.Price == 0 || model.Num == 0 || string.IsNullOrEmpty(model.ContactName)
             || string.IsNullOrEmpty(model.ContactTel)) return false;

         return dal.UpdateScenicAreaOrder(model);

      }

      public bool UpdateScenicAreaOrderByUser(Model.ScenicStructure.MScenicAreaOrder model)
      {
         if (string.IsNullOrEmpty(model.OrderId) || model.Price == 0 || model.Num == 0 || string.IsNullOrEmpty(model.ContactName)
             || string.IsNullOrEmpty(model.ContactTel)) return false;

         return dal.UpdateScenicAreaOrderByUser(model);
      }

      /// <summary>
      /// 修改景区订单的状态
      /// </summary>
      /// <param name="OrderId"></param>
      /// <param name="Status"></param>
      /// <returns></returns>
      public bool UpdateScenicAreaOrder(string OrderId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus? Status)
      {
         if (string.IsNullOrEmpty(OrderId) || !Status.HasValue) return false;

         return dal.UpdateScenicAreaOrder(OrderId, Status.Value);
      }

      /// <summary>
      /// 设置付款状态，返回1成功，其它失败
      /// </summary>
      /// <param name="orderId">订单编号</param>
      /// <param name="memberId">会员编号</param>
      /// <param name="status">状态</param>
      /// <returns></returns>
      public int SheZhiFuKuanStatus(string orderId, string memberId, Model.Enum.XianLuStructure.FuKuanStatus status)
      {
         if (string.IsNullOrEmpty(orderId)) return 0;

         int dalRetCode = dal.SheZhiFuKuanStatus(orderId, memberId, status);

         return dalRetCode;
      }

      /// <summary>
      /// 获取景区订单的实体
      /// </summary>
      /// <param name="orderId"></param>
      /// <returns></returns>
      public EyouSoft.Model.ScenicStructure.MScenicAreaOrder GetScenicAreaOrderModel(string orderId)
      {
         if (string.IsNullOrEmpty(orderId)) return null;
         return dal.GetScenicAreaOrderModel(orderId);
      }

      /// <summary>
      /// 获取景区订单的集合
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="RecordCount"></param>
      /// <param name="search"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.ScenicStructure.MScenicAreaOrder> GetScenicAreaOrderList(int pageSize, int pageIndex, ref int RecordCount, MScenicAreaOrderSearchModel search)
      {
         if (search != null && search.IsFeiHuiYuan)
         {
            if (string.IsNullOrEmpty(search.FeiHuiYuanDianHua)
                || string.IsNullOrEmpty(search.FeiHuiYuanDingDanHao)
                || string.IsNullOrEmpty(search.FeiHuiYuanXingMing))
               return null;
         }

         return dal.GetScenicAreaOrderList(pageSize, pageIndex, ref RecordCount, search);
      }

      #endregion


      /// <summary>
      /// 新增点评
      /// </summary>
      /// <param name="info"></param>
      /// <returns></returns>
      public int InsertDianPing(EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo info)
      {
         if (info == null
             || string.IsNullOrEmpty(info.JingDianId)
             || string.IsNullOrEmpty(info.OperatorId)) return 0;

         info.DianPingId = Guid.NewGuid().ToString();
         info.IssueTime = DateTime.Now;

         return dal.InsertDianPing(info);
      }

      /// <summary>
      /// 修改点评
      /// </summary>
      /// <param name="info"></param>
      /// <returns></returns>
      public int UpdateDianPing(EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo info)
      {
         if (info == null
             || string.IsNullOrEmpty(info.DianPingId)
             || string.IsNullOrEmpty(info.JingDianId)) return 0;

         return dal.UpdateDianPing(info);
      }

      /// <summary>
      /// 删除点评
      /// </summary>
      /// <param name="dianPingId"></param>
      /// <returns></returns>
      public int DeleteDianPing(string dianPingId)
      {
         if (string.IsNullOrEmpty(dianPingId)) return 0;

         return dal.DeleteDianPing(dianPingId);
      }

      /// <summary>
      /// 获取点评
      /// </summary>
      /// <param name="dianPingId"></param>
      /// <returns></returns>
      public EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo GetDianPingInfo(string dianPingId)
      {
         if (string.IsNullOrEmpty(dianPingId)) return null;
         return dal.GetDianPingInfo(dianPingId);
      }

      /// <summary>
      /// 获取点评集合
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="recordCount"></param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo> GetDianPings(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.ScenicStructure.MJingDianDianPingChaXunInfo chaXun)
      {
         return dal.GetDianPings(pageSize, pageIndex, ref recordCount, chaXun);
      }

      /// <summary>
      /// 审核点评
      /// </summary>
      /// <param name="dianPingId"></param>
      /// <param name="isShenHe"></param>
      /// <returns></returns>
      public int ShenHeDianPing(string dianPingId, bool isShenHe)
      {
         if (string.IsNullOrEmpty(dianPingId)) return 0;

         return dal.ShenHeDianPing(dianPingId, isShenHe);
      }

      /// <summary>
      /// 获取满意度
      /// </summary>
      /// <param name="jingDianId"></param>
      /// <returns></returns>
      public decimal GetManYiDu(string jingDianId)
      {
         if (string.IsNullOrEmpty(jingDianId)) return 0;
         return dal.GetManYiDu(jingDianId);
      }

      /// <summary>
      /// 获取门票剩余人数
      /// </summary>
      /// <param name="ticketId"></param>
      /// <returns></returns>
      public int ScenicStrucNumber(string ticketId)
      {
         if (string.IsNullOrEmpty(ticketId)) return 0;
         return dal.ScenicStrucNumber(ticketId);
      }
      /// <summary>
      /// 设置订单状态，返回1成功，其它失败
      /// </summary>
      /// <param name="orderId">订单编号</param>
      /// <param name="memberId">会员编号</param>
      /// <param name="status">状态</param>
      /// <param name="history">订单变更记录信息</param>
      /// <returns></returns>
      public int SheZhiOrderStatus(string orderId, OrderStatus status)
      {
         if (string.IsNullOrEmpty(orderId)) return 0;

         int dalRetCode = dal.SheZhiOrderStatus(orderId, status);

         if (status == OrderStatus.待付款)
         {
             new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(orderId, EyouSoft.Model.Enum.DingDanLeiBie.线路订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.确认);
         }

         return dalRetCode;
      }
      /// <summary>
      /// 支付完成执行方法
      /// </summary>
      /// <param name="info">订单</param>
      /// <returns></returns>
      public int SheZhiZhiFus(EyouSoft.Model.ScenicStructure.MScenicAreaOrder info)
      {
         if (string.IsNullOrEmpty(info.OrderId)) return 0;
         return dal.SheZhiZhiFus(info);
      }
      /// <summary>
      /// 根据订单状态获取订单数量
      /// </summary>
      /// <param name="Status">订单状态</param>
      /// <returns></returns>
      public int GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status)
      {
         return dal.GetOrderNum(Status);
      }
   }
}
