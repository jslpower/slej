using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace EyouSoft.Model.Enum
{
   /// <summary>
   /// 酒店状态
   /// </summary>
   public enum HotelStatus
   {
      /// <summary>
      /// 正常
      /// </summary>
      正常 = 0,
      /// <summary>
      /// 下架
      /// </summary>
      下架 = 1
   }

   /// <summary>
   /// 酒店照片类型
   /// </summary>
   public enum HotelImgType
   {
      /// <summary>
      /// 酒店形象照片
      /// </summary>
      酒店形象照片 = 1,
      其他 = 2
   }

   /// <summary>
   /// 酒店星级
   /// </summary>
   public enum HotelStar
   {
      /// <summary>
      /// 一星级
      /// </summary>
      一星级 = 1,
      /// <summary>
      /// 二星级
      /// </summary>
      二星级 = 2,
      /// <summary>
      /// 三星级
      /// </summary>
      三星级 = 3,
      /// <summary>
      /// 四星级
      /// </summary>
      四星级 = 4,
      /// <summary>
      /// 五星级
      /// </summary>
      五星级 = 5,
      /// <summary>
      /// 准一星级
      /// </summary>
      准一星级 = 6,
      /// <summary>
      /// 准二星级
      /// </summary>
      准二星级 = 7,
      /// <summary>
      /// 准三星级
      /// </summary>
      准三星级 = 8,
      /// <summary>
      /// 准四星级
      /// </summary>
      准四星级 = 9,
      /// <summary>
      /// 准五星级
      /// </summary>
      准五星级 = 10,
      /// <summary>
      /// 二星级以下
      /// </summary>
      二星级以下 = 11

   }

   /// <summary>
   /// 房型状态
   /// </summary>
   public enum RoomStatus
   {
      /// <summary>
      /// 正常
      /// </summary>
      正常 = 0,
      /// <summary>
      /// 下架
      /// </summary>
      下架 = 1
   }

   /// <summary>
   /// 房间类型
   /// </summary>
   public enum RoomType
   {
      /// <summary>
      /// 标房
      /// </summary>
      标房 = 1,
      /// <summary>
      /// 统间
      /// </summary>
      统间 = 2,
      /// <summary>
      /// 独栋别墅
      /// </summary>
      独栋别墅 = 3,
      /// <summary>
      /// 酒店式公寓
      /// </summary>
      酒店式公寓 = 4,
      /// <summary>
      /// 别墅套间
      /// </summary>
      别墅套间 = 5,
      /// <summary>
      /// 其它
      /// </summary>
      其它 = 6
   }

   /// <summary>
   /// 床型
   /// </summary>
   public enum BedType
   {
      /// <summary>
      /// 单人床
      /// </summary>
      单人床 = 1,
      /// <summary>
      /// 大双房
      /// </summary>
      大双房 = 2,
      /// <summary>
      /// 大床房
      /// </summary>
      大床房 = 3,
      /// <summary>
      /// 高低铺
      /// </summary>
      高低铺 = 4,
      /// <summary>
      /// 其它
      /// </summary>
      其它 = 6
   }
   /// <summary>
   /// 宽带
   /// </summary>
   public enum IsInternet
   {
      /// <summary>
      /// 免费宽带
      /// </summary>
      免费宽带 = 1,
      /// <summary>
      /// 收费宽带
      /// </summary>
      收费宽带 = 2,
      /// <summary>
      /// 无宽带
      /// </summary>
      无宽带 = 3
   }
   /// <summary>
   /// 朝向
   /// </summary>
   public enum Orientation
   {
      请选择 = 0,
      /// <summary>
      /// 东
      /// </summary>
      东 = 1,
      /// <summary>
      /// 南
      /// </summary>
      南 = 2,
      /// <summary>
      /// 西
      /// </summary>
      西 = 3,
      /// <summary>
      /// 北
      /// </summary>
      北 = 4,
      /// <summary>
      /// 东南
      /// </summary>
      东南 = 5,
      /// <summary>
      /// 西南
      /// </summary>
      西南 = 6,
      /// <summary>
      /// 东北
      /// </summary>
      东北 = 7,
      /// <summary>
      /// 西北
      /// </summary>
      西北 = 8
   }

   /// <summary>
   /// 早餐
   /// </summary>
   public enum IsBreakfast
   {
      /// <summary>
      /// 不含
      /// </summary>
      不含早 = 1,
      /// <summary>
      /// 含单早
      /// </summary>
      含单早 = 2,
      /// <summary>
      /// 含双早
      /// </summary>
      含双早 = 3,
      /// <summary>
      /// 含早
      /// </summary>
      含早 = 4,
   }

   /// <summary>
   /// 开窗
   /// </summary>
   public enum IsWindow
   {
      /// <summary>
      /// 无窗
      /// </summary>
      无窗 = 1,
      /// <summary>
      /// 有开窗
      /// </summary>
      有开窗 = 2,
      /// <summary>
      /// 有阳台
      /// </summary>
      有阳台 = 3
   }

   /// <summary>
   /// 是否加床
   /// </summary>
   public enum IsAddBed
   {
      /// <summary>
      /// 能
      /// </summary>
      能 = 1,
      /// <summary>
      /// 不能
      /// </summary>
      不能 = 2,
   }


   /// <summary>
   /// 付款方式
   /// </summary>
   public enum Payment
   {
      /// <summary>
      /// 前台支付
      /// </summary>
      前台支付 = 1,
      /// <summary>
      /// 预付全款
      /// </summary>
      预付全款 = 2
   }

   /// <summary>
   /// 宾客类型
   /// </summary>
   public enum GuestType
   {
      /// <summary>
      /// 内宾
      /// </summary>
      内宾 = 1,
      /// <summary>
      /// 外宾
      /// </summary>
      外宾 = 2
   }

   /// <summary>
   /// 旅客类型
   /// </summary>
   public enum TravellerType
   {
      /// <summary>
      /// 内宾
      /// </summary>
      内宾 = 1,
      /// <summary>
      /// 外宾
      /// </summary>
      外宾 = 2
   }

   /// <summary>
   /// 团队类型
   /// </summary>
   public enum TourType
   {
      /// <summary>
      /// 旅游团
      /// </summary>
      旅游团 = 1,
      /// <summary>
      /// 会议团
      /// </summary>
      会议团 = 2
   }

   /// <summary>
   /// 处理状态
   /// </summary>
   public enum TreatState
   {
      /// <summary>
      /// 未处理
      /// </summary>
      未处理 = 1,
      /// <summary>
      /// 处理中
      /// </summary>
      处理中 = 2,
      /// <summary>
      /// 已确认
      /// </summary>
      已确认 = 3
   }

   /// <summary>
   /// 订单状态
   /// </summary>
   public enum OrderState
   {
      /// <summary>
      /// 未处理
      /// </summary>
      未处理 = 0,
      /// <summary>
      /// 待付款
      /// </summary>
      待付款 = 1,
      /// <summary>
      /// 订单出货
      /// </summary>
      订单出货 = 2,
      /// <summary>
      /// 确认收货
      /// </summary>
      确认收货 = 3,
      /// <summary>
      /// 待返利
      /// </summary>
      待返利 = 4,
      /// <summary>
      /// 交易完成
      /// </summary>
      交易完成 = 5
      ///// <summary>
      ///// 未处理
      ///// </summary>
      //未处理 = 0,
      ///// <summary>
      ///// 不受理
      ///// </summary>
      //不受理 = 1,
      ///// <summary>
      ///// 已取消
      ///// </summary>
      //已取消 = 2,
      ///// <summary>
      ///// 处理中
      ///// </summary>
      //处理中 = 3,
      ///// 待付款
      ///// </summary>
      //待付款 = 4,
      ///// <summary>
      ///// 已成交
      ///// </summary>
      //已成交 = 5
   }

   /// <summary>
   /// 佣金类型
   /// </summary>
   public enum CommissionType
   {
      /// <summary>
      /// 无返佣
      /// </summary>
      无返佣 = 1,
      /// <summary>
      /// 百分比
      /// </summary>
      百分比 = 2,
      /// <summary>
      /// 固定返佣
      /// </summary>
      固定返佣 = 3
   }

   /// <summary>
   /// 酒店系统订单类别
   /// </summary>
   public enum OrderType
   {
      /// <summary>
      /// 国内现付
      /// </summary>
      国内现付
   }

   /// <summary>
   /// 审核状态
   /// </summary>
   public enum CheckState
   {
      /// <summary>
      /// 待审结
      /// </summary>
      待审结 = 1,
      /// <summary>
      /// 在入住
      /// </summary>
      已入住 = 2,
      /// <summary>
      /// nowshow
      /// </summary>
      nowshow = 3
   }

   /// <summary>
   /// 支付状态
   /// </summary>
   public enum PaymentState
   {
      /// <summary>
      /// 未支付
      /// </summary>
      未支付 = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款),
      /// <summary>
      /// 已支付
      /// </summary>
      已支付 = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款)
   }
}
