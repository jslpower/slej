using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.HotelStructure.WebModel;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.BLL.HotelStructure
{
    public class BHotel
    {
        EyouSoft.IDAL.HotelStructure.IHotel dal = new EyouSoft.DAL.HotelStructure.DHotel();

        #region 酒店
        /// <summary>
        /// 添加酒店
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddHotel(EyouSoft.Model.HotelStructure.MHotel model)
        {
            if (model.OperatorId == 0) return false;

            model.HotelId = Guid.NewGuid().ToString();
            return dal.AddHotel(model);

        }

        /// <summary>
        /// 修改酒店
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateHotel(EyouSoft.Model.HotelStructure.MHotel model)
        {
            if (string.IsNullOrEmpty(model.HotelId) || model.OperatorId == 0) return false;
            return dal.UpdateHotel(model);
        }

        /// <summary>
        /// 删除酒店
        /// </summary>
        /// <param name="HotelId"></param>
        /// <returns></returns>
        public bool DeleteHotel(string HotelId)
        {
            if (string.IsNullOrEmpty(HotelId)) return false;
            return dal.DeleteHotel(HotelId);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public EyouSoft.Model.HotelStructure.MHotel GetModel(string hotelId)
        {
            if (string.IsNullOrEmpty(hotelId)) return null;
            return dal.GetModel(hotelId);
        }

        /// <summary>
        /// 分页获取酒店集合
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.HotelStructure.MHotel> GetHotelList(int pageIndex, int pageSize, ref int recordCount, EyouSoft.Model.HotelStructure.MHotelSearch search)
        {
            var items= dal.GetHotelList(pageIndex, pageSize, ref recordCount, search);

            if (items != null && items.Count > 0)
            {
                var bll = new EyouSoft.BLL.OtherStructure.BWebmaster();
                foreach (var item in items)
                {
                    var info = bll.GetGysUserInfo(item.HotelId);
                    if (info != null)
                    {
                        item.UserId = info.Id;
                        item.Username = info.Username;
                    }
                }
            }

            return items;
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
        /// 获取推荐酒店信息
        /// </summary>
        /// <param name="topNum"></param>
        /// <returns></returns>
        public IList<MHotelSearchModel2> GetHotelList(int topNum)
        {
            return dal.GetHotelList(topNum);
        }
        /// <summary>
        /// 分页获取酒店集合
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<Model.HotelStructure.MHotel> GetHotelListByPublic(int pageIndex, int pageSize, ref int recordCount
            , Model.HotelStructure.MHotelSearch search)
        {
            if (pageSize < 1 && pageIndex < 1) return null;

            return dal.GetHotelListByPublic(pageIndex, pageSize, ref recordCount, search);
        }

        #endregion


        #region 酒店图片

        /// <summary>
        /// 添加酒店图片
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddHotelImg(EyouSoft.Model.HotelStructure.MHotelImg model)
        {

            if (string.IsNullOrEmpty(model.HotelId) || string.IsNullOrEmpty(model.OperatorId)) return false;

            return dal.AddHotelImg(model);

        }

        /// <summary>
        /// 批量添加酒店图片
        /// </summary>
        /// <param name="HotelId"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AddHotelImg(string HotelId, IList<EyouSoft.Model.HotelStructure.MHotelImg> list)
        {

            if (string.IsNullOrEmpty(HotelId)) return false;

            foreach (var a in list)
            {
                if (string.IsNullOrEmpty(a.OperatorId)) return false;
                break;
            }
            return dal.AddHotelImg(HotelId, list);
        }

        /// <summary>
        /// 修改酒店图片
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateHotelImg(EyouSoft.Model.HotelStructure.MHotelImg model)
        {
            if (model.ImgId == 0 || string.IsNullOrEmpty(model.HotelId) || string.IsNullOrEmpty(model.OperatorId)) return false;

            return dal.UpdateHotelImg(model);
        }

        /// <summary>
        /// 删除酒店图片
        /// </summary>
        /// <param name="ImgId"></param>
        /// <returns></returns>
        public bool DeleteHotelImg(int ImgId)
        {
            if (ImgId == 0) return false;

            return dal.DeleteHotelImg(ImgId);
        }

        /// <summary>
        /// 根据图片的编号获取酒店图片的实体
        /// </summary>
        /// <param name="ImgId"></param>
        /// <returns></returns>
        public EyouSoft.Model.HotelStructure.MHotelImg GetHotelImgModel(int ImgId)
        {

            if (ImgId == 0) return null;
            return dal.GetHotelImgModel(ImgId);
        }

        /// <summary>
        /// 根据酒店的编号获取酒店图片的集合
        /// </summary>
        /// <param name="HotelId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.HotelStructure.MHotelImg> GetHotelImgListByHotelId(string HotelId)
        {
            if (string.IsNullOrEmpty(HotelId)) return null;

            return dal.GetHotelImgListByHotelId(HotelId);
        }

        #endregion

        /// <summary>
        /// 新增点评
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertDianPing(EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo info)
        {
            if (info == null
                || string.IsNullOrEmpty(info.JiuDianId)
                ||string.IsNullOrEmpty(info.OperatorId)) return 0;

            info.DianPingId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            return dal.InsertDianPing(info);
        }

        /// <summary>
        /// 修改点评
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateDianPing(EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo info)
        {
            if (info == null
                || string.IsNullOrEmpty(info.DianPingId)
                || string.IsNullOrEmpty(info.JiuDianId)) return 0;

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
        public EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo GetDianPingInfo(string dianPingId)
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
        public IList<EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo> GetDianPings(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.HotelStructure.MJiuDianDianPingChaXunInfo chaXun)
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
        /// <param name="jiuDianId"></param>
        /// <returns></returns>
        public decimal GetManYiDu(string jiuDianId)
        {
            if (string.IsNullOrEmpty(jiuDianId)) return 0;
            return dal.GetManYiDu(jiuDianId);
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

            return dalRetCode;
        }
    }
}
