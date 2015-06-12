using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.ORM;
using System.ComponentModel;
using Linq.ORM.Attribute;

namespace EyouSoft.Model.HotelStructure
{
   #region 酒店房型基础信息
   /// <summary>
   /// 酒店房型基础信息
   /// </summary>
   [Table("tbl_HotelRoomType")]
   public class MBaseHotelRoomType
   {
      /// <summary>
      /// 房型编号
      /// </summary>
      [PrimaryKey]
      public string RoomTypeId { get; set; }
      /// <summary>
      /// 酒店编号
      /// </summary>
      public string HotelId { get; set; }
      /// <summary>
      /// 房型名称
      /// </summary>
      public string RoomName { get; set; }
      /// <summary>
      /// 总房间数
      /// </summary>
      public int TotalNumber { get; set; }
      /// <summary>
      /// 房间类型
      /// </summary>
      public EyouSoft.Model.Enum.RoomType RoomType { get; set; }
      /// <summary>
      /// 房型面积
      /// </summary>
      public string RoomArea { get; set; }
      /// <summary>
      /// 楼层
      /// </summary>
      public string Floor { get; set; }
      /// <summary>
      /// 床型
      /// </summary>
      public EyouSoft.Model.Enum.BedType BedType { get; set; }
      /// <summary>
      /// 床长
      /// </summary>
      public decimal BedHeight { get; set; }
      /// <summary>
      /// 床宽
      /// </summary>
      public decimal BedWidth { get; set; }
      /// <summary>
      /// 房型最大入住人数
      /// </summary>
      public int MaxGuestNum { get; set; }
      /// <summary>
      /// 是否无烟
      /// </summary>
      public bool IsSmoking { get; set; }
      /// <summary>
      /// 是否上网
      /// </summary>
      public EyouSoft.Model.Enum.IsInternet IsInternet { get; set; }
      /// <summary>
      /// 宽带费用
      /// </summary>
      public decimal IsInternetPrice { get; set; }
      /// <summary>
      /// 朝向
      /// </summary>
      public EyouSoft.Model.Enum.Orientation Orientation { get; set; }
      /// <summary>
      /// 早餐
      /// </summary>
      public EyouSoft.Model.Enum.IsBreakfast IsBreakfast { get; set; }
      /// <summary>
      /// 早餐费用
      /// </summary>
      public decimal IsBreakfastPrice { get; set; }
      /// <summary>
      /// 开窗
      /// </summary>
      public EyouSoft.Model.Enum.IsWindow IsWindow { get; set; }
      /// <summary>
      /// 是否加床
      /// </summary>
      public EyouSoft.Model.Enum.IsAddBed IsAddBed { get; set; }
      /// <summary>
      /// 加床价格
      /// </summary>
      public decimal IsAddBedPrice { get; set; }
      /// <summary>
      /// 支付方式
      /// </summary>
      public EyouSoft.Model.Enum.Payment Payment { get; set; }
      /// <summary>
      /// 房型描述
      /// </summary>
      public string Desc { get; set; }
      /// <summary>
      /// 创建时间
      /// </summary>
      public DateTime IssueTime { get; set; }
      /// <summary>
      /// 操作员编号
      /// </summary>
      public int OperatorId { get; set; }
      /// <summary>
      /// 排序编号
      /// </summary>
      public int SortId { get; set; }
      /// <summary>
      /// 房型状态
      /// </summary>
      public EyouSoft.Model.Enum.RoomStatus RoomStatus { get; set; }

      /// <summary>
      /// 酒店名称
      /// </summary>
      [ColumnIgnore]
      public string HotelName { get; set; }
      /// <summary>
      /// 是否同行分销
      /// </summary>
      public bool IsFenXiao { get; set; }
      /// <summary>
      /// 床型描述（接口用的）
      /// </summary>
      public string BedTypeDescription { get; set; }
      /// <summary>
      /// 房型编号（接口）
      /// </summary>
      public string InterfaceID { get; set; }

      public string HotelCode { get; set; }
   }
   #endregion

   #region 酒店房型图片
   /// <summary>
   /// 
   /// </summary>
   [Table("tbl_HotelRoomImg")]
   public class MHotelRoomImg
   {
      /// <summary>
      /// 图片编号
      /// </summary>
      [PrimaryKey]
      [Identity(IdentityType.Increment)]
      [DisplayName("图片编号")]
      public int RoomImgId { get; set; }
      /// <summary>
      /// 房型编号
      /// </summary>
      [DisplayName("房型编号")]
      public string RoomTypeId { get; set; }
      /// <summary>
      /// 图片路径
      /// </summary>
      [DisplayName("图片路径")]
      public string FilePath { get; set; }
      /// <summary>
      /// 图片描述
      /// </summary>
      [DisplayName("图片描述")]
      public string Desc { get; set; }
   }
   #endregion

   #region 酒店房型信息
   /// <summary>
   /// 酒店房型信息
   /// </summary>
   [Serializable]
   public class MHotelRoomType : MBaseHotelRoomType
   {
      /// <summary>
      /// 酒店图片的结合
      /// </summary>
      public List<MHotelRoomImg> HoteRoomImgList { get; set; }

      /// <summary>
      /// 销售价，税前价格+其他费用（如服务费、税）[挂牌价]
      /// </summary>
      public decimal AmountPrice { get; set; }
      /// <summary>
      /// 同行价
      /// </summary>
      public decimal PreferentialPrice { get; set; }
      /// <summary>
      /// 结算价[网络价]
      /// </summary>
      public decimal SettlementPrice { get; set; }
      /// <summary>
      /// 价格编号
      /// </summary>
      public int JiaGeId { get; set; }
      /// <summary>
      /// 房间数量
      /// </summary>
      public int ShuLiang { get; set; }
      /// <summary>
      /// 已预订数量
      /// </summary>
      public int YiYuDingShuLiang { get; set; }
      /// <summary>
      /// 剩余数量
      /// </summary>
      public int ShengYuShuLiang { get { return ShuLiang - YiYuDingShuLiang; } }

   }
   #endregion

   #region 酒店房型的查询实体
   /// <summary>
   /// 酒店房型的查询实体
   /// </summary>
   [Serializable]
   public class MHotelRoomTypeSearch
   {
      /// <summary>
      /// 酒店名称
      /// </summary>
      public string HotelName { get; set; }

      /// <summary>
      /// 房型名称
      /// </summary>
      public string RoomName { get; set; }

      /// <summary>
      /// 酒店编号
      /// </summary>
      public string HotelId { get; set; }

      /// <summary>
      /// 入住时间
      /// </summary>
      public DateTime? InDate { get; set; }

      /// <summary>
      /// 离店时间
      /// </summary>
      public DateTime? OutDate { get; set; }

      /// <summary>
      /// 上下架
      /// </summary>
      public Enum.HotelStatus? RoomStatus { get; set; }
      /// <summary>
      /// 是否同行分销
      /// </summary>
      public bool? IsFenXiao { get; set; }

   }

   #endregion

   #region 酒店价格
   /// <summary>
   /// 酒店价格
   /// </summary>
   [Table("tbl_HotelRoomRate")]
   public class MHotelRoomRate
   {
      /// <summary>
      /// 酒店价格的编号
      /// </summary>
      [PrimaryKey]
      [Identity(IdentityType.Increment)]
      public int RoomRateId { get; set; }
      /// <summary>
      /// 酒店编号
      /// </summary>
      public string HotelId { get; set; }
      /// <summary>
      /// 酒店名称(用于显示)
      /// </summary>
      [ColumnIgnore]
      public string HotelName { get; set; }
      /// <summary>
      /// 房型编号
      /// </summary>
      public string RoomTypeId { get; set; }
      /// <summary>
      /// 房型名称(用于显示)
      /// </summary>
      [ColumnIgnore]
      public string RoomName { get; set; }
      /// <summary>
      /// 房间类型
      /// </summary>
      [ColumnIgnore]
      public EyouSoft.Model.Enum.RoomType RoomType { get; set; }
      /// <summary>
      /// 门市价，税前价格+其他费用（如服务费、税）[挂牌价]
      /// </summary>
      public decimal AmountPrice { get; set; }
      /// <summary>
      /// 网络优惠价
      /// </summary>
      public decimal PreferentialPrice { get; set; }
      /// <summary>
      /// 结算价
      /// </summary>
      public decimal SettlementPrice { get; set; }
      /// <summary>
      /// 开始日期
      /// </summary>
      public DateTime StartDate { get; set; }
      /// <summary>
      /// 结束日期
      /// </summary>
      public DateTime EndDate { get; set; }
      /// <summary>
      /// 原因
      /// </summary>
      public string Reason { get; set; }
      /// <summary>
      /// 操作员编号
      /// </summary>
      public int OperatorId { get; set; }
      /// <summary>
      /// 操作人
      /// </summary>
      [ColumnIgnore]
      public string OperatorName { get; set; }
      /// <summary>
      /// 添加时间
      /// </summary>
      public DateTime IssueTime { get; set; }
      /// <summary>
      /// 房间数量
      /// </summary>
      public int ShuLiang { get; set; }
      /// <summary>
      /// 剩余数量
      /// </summary>
      public int ShengYuShuLiang { get; set; }
      /// <summary>
      /// 所属价格计划（接口）
      /// </summary>
      public string InterfaceID { get; set; }
      /// <summary>
      /// 价格计划名称（接口） 又叫套餐名， 只有接口来的数据才有值，非接口数据界面永远显示“默认”
      /// </summary>
      public string RoomRateName { get; set; }

      public string VenderCode { get; set; }

      public string Breakfast { get; set; }

      public string HotelCode { get; set; }
      public string RoomTypeCode { get; set; }
      public string Status { get; set; }

   }
   #endregion

   #region 酒店价格的查询实体
   /// <summary>
   /// 酒店价格的查询实体
   /// </summary>
   [Serializable]
   public class MHotelRoomRateSearch
   {
      /// <summary>
      /// 酒店名称
      /// </summary>
      public string HotelId { get; set; }
      /// <summary>
      /// 房型
      /// </summary>
      public EyouSoft.Model.Enum.RoomType? RoomType { get; set; }
      /// <summary>
      /// 房型的名称
      /// </summary>
      public string RoomName { get; set; }
      /// <summary>
      /// 开始时间
      /// </summary>
      public DateTime? StartDate { get; set; }
      /// <summary>
      /// 结束时间
      /// </summary>
      public DateTime? EndDate { get; set; }


   }
   #endregion
}
