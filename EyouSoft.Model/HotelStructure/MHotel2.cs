using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.HotelStructure
{
   using System;
   using Linq.ORM;
   using System.ComponentModel;
   using EyouSoft.Model.Enum;
   using Linq.ORM.Attribute;
   /// <summary>
   /// 
   /// </summary>
   [Table("tbl_Hotel")]
   public class MHotel2
   {
      /// <summary>
      /// 酒店编号
      /// </summary>
      [PrimaryKey]
      [DisplayName("酒店编号")]
      public string HotelId { get; set; }
      /// <summary>
      /// 酒店代码
      /// </summary>
      [DisplayName("酒店代码")]
      public string HotelCode { get; set; }
      /// <summary>
      /// 酒店名称（中）
      /// </summary>
      [DisplayName("酒店名称（中文）")]
      public string HotelName { get; set; }
      /// <summary>
      /// 酒店名称（英）
      /// </summary>
      [DisplayName("酒店名称（英）")]
      public string HotelNameEn { get; set; }
      /// <summary>
      /// 纬度
      /// </summary>
      [DisplayName("纬度")]
      public string Latitude { get; set; }
      /// <summary>
      /// 经度
      /// </summary>
      [DisplayName("经度")]
      public string Longitude { get; set; }
      /// <summary>
      /// 客服电话
      /// </summary>
      [DisplayName("客服电话")]
      public string ServiceTel { get; set; }
      /// <summary>
      /// 省份
      /// </summary>
      [DisplayName("省份")]
      public int ProvinceId { get; set; }
      /// <summary>
      /// 城市
      /// </summary>
      [DisplayName("城市")]
      public int CityId { get; set; }
      /// <summary>
      /// 县区
      /// </summary>
      [DisplayName("县区")]
      public int CountyId { get; set; }
      /// <summary>
      /// 地址
      /// </summary>
      [DisplayName("地址")]
      public string Address { get; set; }
      /// <summary>
      /// 英文地址
      /// </summary>
      [DisplayName("英文地址")]
      public string EnAddress { get; set; }
      /// <summary>
      /// 星级代码
      /// </summary>
      [DisplayName("星级代码")]
      public HotelStar? Star { get; set; }
      /// <summary>
      /// 邮编
      /// </summary>
      [DisplayName("邮编")]
      public string PostalCode { get; set; }
      /// <summary>
      /// 开业时间 
      /// </summary>
      [DisplayName("开业时间 ")]
      public string OpenDate { get; set; }
      /// <summary>
      /// 装修时间
      /// </summary>
      [DisplayName("装修时间")]
      public string Fitment { get; set; }
      /// <summary>
      /// 房间数量
      /// </summary>
      [DisplayName("房间数量")]
      public int RoomQuantity { get; set; }
      /// <summary>
      /// 楼层
      /// </summary>
      [DisplayName("楼层")]
      public string Floor { get; set; }
      /// <summary>
      /// 详细描述
      /// </summary>
      [DisplayName("详细描述")]
      public string LongDesc { get; set; }
      /// <summary>
      /// 交通情况
      /// </summary>
      [DisplayName("交通情况")]
      public string Transport { get; set; }
      /// <summary>
      /// 额外收费
      /// </summary>
      [DisplayName("额外收费")]
      public string AdditionalCost { get; set; }
      /// <summary>
      /// 状态
      /// </summary>
      [DisplayName("状态")]
      public HotelStatus Status { get; set; }
      /// <summary>
      /// 操作员
      /// </summary>
      [DisplayName("操作员")]
      public int OperatorId { get; set; }
      /// <summary>
      /// 创建时间
      /// </summary>
      [DisplayName("创建时间")]
      public DateTime IssueTime { get; set; }
      /// <summary>
      /// 是否删除
      /// </summary>
      [DisplayName("是否删除")]
      public string IsDelete { get; set; }
      /// <summary>
      /// 是否热门
      /// </summary>
      [DisplayName("是否热门")]
      public string IsHot { get; set; }
      /// <summary>
      /// 是否推荐
      /// </summary>
      [DisplayName("是否推荐")]
      public string IsRecommend { get; set; }
      /// <summary>
      /// 城市三字码
      /// </summary>
      [DisplayName("城市三字码")]
      public string CityCode { get; set; }
      /// <summary>
      /// 联系手机
      /// </summary>
      [DisplayName("联系手机")]
      public string Mobile { get; set; }
      /// <summary>
      /// 结算方式 0 现结 1 月结
      /// </summary>
      [DisplayName("结算方式 0 现结 1 月结")]
      public string JieSuanType { get; set; }
      /// <summary>
      /// 接口编号(接口HotelCode)
      /// </summary>
      [DisplayName("接口编号(接口HotelCode)")]
      public string InterfaceId { get; set; }
       /// <summary>
       /// 排序
       /// </summary>
      public int ProductSort { get; set; }
   }
}
