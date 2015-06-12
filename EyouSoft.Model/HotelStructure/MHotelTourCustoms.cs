using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;
namespace EyouSoft.Model.HotelStructure
{
    /// <summary>
    /// 酒店团队定制
    /// </summary>
    [Serializable]
    public class MHotelTourCustoms
    {
        public MHotelTourCustoms() { }
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string ContacterName { get; set; }
        /// <summary>
        /// 联系人手机
        /// </summary>
        public string ContacterMobile { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string ContacterTelephone { get; set; }
        /// <summary>
        /// 酒店编号
        /// </summary>
        public string HotelId { get; set; }
        /// <summary>
        /// 酒店代码
        /// </summary>
        public string HotelCode { get; set; }
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName { get; set; }
        /// <summary>
        /// 星级要求
        /// </summary>
        public HotelStar HotelStar { get; set; }
        /// <summary>
        /// 目的地城市三字码
        /// </summary>
        public string CityCode { get; set; }
        /// <summary>
        /// 地理位置要求
        /// </summary>
        public string LocationAsk { get; set; }
        /// <summary>
        /// 房间要求
        /// </summary>
        public string RoomAsk { get; set; }
        /// <summary>
        /// 入住开始时间
        /// </summary>
        public DateTime? LiveStartDate { get; set; }
        /// <summary>
        /// 入住结束时间
        /// </summary>
        public DateTime? LiveEndDate { get; set; }
        /// <summary>
        /// 房间数
        /// </summary>
        public int RoomCount { get; set; }
        /// <summary>
        /// 入住人数
        /// </summary>
        public int PeopleCount { get; set; }
        /// <summary>
        /// 团预算最小值
        /// </summary>
        public decimal BudgetMin { get; set; }
        /// <summary>
        /// 团预算最大值
        /// </summary>
        public decimal BudgetMax { get; set; }
        /// <summary>
        /// 付款方式
        /// </summary>
        public Payment Payment { get; set; }
        /// <summary>
        /// 宾客类型[内宾,外宾]
        /// </summary>
        public GuestType GuestType { get; set; }
        /// <summary>
        /// 团队类型
        /// </summary>
        public TourType TourType { get; set; }
        /// <summary>
        /// 其他要求
        /// </summary>
        public string OtherRemark { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 处理状态
        /// </summary>
        public TreatState TreatState { get; set; }
        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime? TreateTime { get; set; }
        /// <summary>
        /// 处理人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource Source { get; set; }
        /// <summary>
        /// 酒店团队订单回复
        /// </summary>
        public IList<MHotelTourCustomsAsk> AskList { get; set; }
    }

    /// <summary>
    /// 酒店团队订单回复
    /// </summary>
    [Serializable]
    public class MHotelTourCustomsAsk
    {
        public MHotelTourCustomsAsk() { }
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 团队定制编号
        /// </summary>
        public int TourOrderID { get; set; }
        /// <summary>
        /// 回复人
        /// </summary>
        public string AskName { get; set; }
        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime AskTime { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string AskContent { get; set; }

    }

    /// <summary>
    /// 酒店团队定制查询实体
    /// </summary>
    public class MHotelTourCustomsSeach
    {
        public MHotelTourCustomsSeach() { }
        /// <summary>
        /// 入住开始时间开始
        /// </summary>
        public DateTime? LiveStartDateS { get; set; }
        /// <summary>
        /// 入住开始时间结束
        /// </summary>
        public DateTime? LiveStartDateE { get; set; }
        /// <summary>
        /// 入住结束时间开始
        /// </summary>
        public DateTime? LiveEndDateS { get; set; }
        /// <summary>
        /// 入住结束时间结束
        /// </summary>
        public DateTime? LiveEndDateE { get; set; }
        /// <summary>
        /// 处理时间开始
        /// </summary>
        public DateTime? TreateTimeS { get; set; }
        /// <summary>
        /// 处理时间结束
        /// </summary>
        public DateTime? TreateTimeE { get; set; }
        /// <summary>
        /// 处理状态
        /// </summary>
        public TreatState? TreatState { get; set; }
    }
}
