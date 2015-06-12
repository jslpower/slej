using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.HotelStructure.WebModel;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.IDAL.HotelStructure
{
    public interface IHotel
    {
        bool AddHotel(EyouSoft.Model.HotelStructure.MHotel model);

        bool UpdateHotel(EyouSoft.Model.HotelStructure.MHotel model);

        bool DeleteHotel(string HotelId);

        EyouSoft.Model.HotelStructure.MHotel GetModel(string hotelId);

        IList<EyouSoft.Model.HotelStructure.MHotel> GetHotelList(int pageIndex, int pageSize, ref int recordCount, EyouSoft.Model.HotelStructure.MHotelSearch search);

        /// <summary>
        /// 获取推荐的酒店信息
        /// </summary>
        /// <param name="topNum"></param>
        /// <returns></returns>
        IList<MHotelSearchModel2> GetHotelList(int topNum);
        bool AddHotelImg(EyouSoft.Model.HotelStructure.MHotelImg model);

        bool AddHotelImg(string HotelId, IList<EyouSoft.Model.HotelStructure.MHotelImg> list);

        bool UpdateHotelImg(EyouSoft.Model.HotelStructure.MHotelImg model);
        /// <summary>
        /// 修改状态
        /// </summary>
        int UpdateState(string Id, EyouSoft.Model.Enum.XianLuStructure.XianLuZT state);

        bool DeleteHotelImg(int ImgId);

        EyouSoft.Model.HotelStructure.MHotelImg GetHotelImgModel(int ImgId);

        IList<EyouSoft.Model.HotelStructure.MHotelImg> GetHotelImgListByHotelId(string HotelId);

        /// <summary>
        /// 分页获取酒店集合
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        IList<Model.HotelStructure.MHotel> GetHotelListByPublic(
            int pageIndex, int pageSize, ref int recordCount, Model.HotelStructure.MHotelSearch search);

        /// <summary>
        /// 新增点评
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int InsertDianPing(EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo info);
        /// <summary>
        /// 修改点评
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int UpdateDianPing(EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo info);
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
        EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo GetDianPingInfo(string dianPingId);
        /// <summary>
        /// 获取点评集合
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo> GetDianPings(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.HotelStructure.MJiuDianDianPingChaXunInfo chaXun);
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
        /// <param name="jiuDianId"></param>
        /// <returns></returns>
        decimal GetManYiDu(string jiuDianId);
        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderId">订单id</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiOrderStatus(string orderId, OrderStatus status);
    }
}
