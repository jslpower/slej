using System;
using System.Collections.Generic;
using Linq.ORM;
using Linq.ORM.Attribute;

namespace EyouSoft.Model.HotelStructure
{
   #region 酒店基础表
   /// <summary>
   /// 酒店基础表
   /// </summary>
   [Serializable]
   public class MBaseHotel
   {
      /// <summary>
      /// 酒店编号
      /// </summary>
      public string HotelId { get; set; }
      /// <summary>
      /// 酒店代码
      /// </summary>
      public string HotelCode { get; set; }
      /// <summary>
      /// 酒店名称（中）
      /// </summary>
      public string HotelName { get; set; }
      /// <summary>
      /// 酒店名称（英）
      /// </summary>
      public string HotelNameEn { get; set; }
      /// <summary>
      /// 纬度
      /// </summary>
      public string Latitude { get; set; }
      /// <summary>
      /// 经度
      /// </summary>
      public string Longitude { get; set; }
      /// <summary>
      /// 客服电话
      /// </summary>
      public string ServiceTel { get; set; }
      /// <summary>
      /// 省份
      /// </summary>
      public int ProvinceId { get; set; }
      /// <summary>
      /// 城市
      /// </summary>
      public int CityId { get; set; }
      /// <summary>
      /// 县区
      /// </summary>
      public int CountyId { get; set; }
      /// <summary>
      /// 地址
      /// </summary>
      public string Address { get; set; }
      /// <summary>
      /// 英文地址
      /// </summary>
      public string EnAddress { get; set; }
      /// <summary>
      /// 星级代码
      /// </summary>
      public EyouSoft.Model.Enum.HotelStar? Star { get; set; }
      /// <summary>
      /// 邮编
      /// </summary>
      public string PostalCode { get; set; }
      /// <summary>
      /// 开业时间 
      /// </summary>
      public string OpenDate { get; set; }
      /// <summary>
      /// 装修时间
      /// </summary>
      public string Fitment { get; set; }
      /// <summary>
      /// 房间数量
      /// </summary>
      public int RoomQuantity { get; set; }
      /// <summary>
      /// 楼层
      /// </summary>
      public string Floor { get; set; }
      /// <summary>
      /// 详细描述
      /// </summary>
      public string LongDesc { get; set; }
      /// <summary>
      /// 交通情况
      /// </summary>
      public string Transport { get; set; }
      /// <summary>
      /// 额外收费
      /// </summary>
      public string AdditionalCost { get; set; }
      /// <summary>
      /// 状态
      /// </summary>
      public EyouSoft.Model.Enum.HotelStatus Status { get; set; }
      /// <summary>
      /// 操作员编号
      /// </summary>
      public int OperatorId { get; set; }
      /// <summary>
      /// 创建时间
      /// </summary>
      public DateTime IssueTime { get; set; }
      /// <summary>
      /// 是否热门
      /// </summary>
      public bool IsHot { get; set; }
      /// <summary>
      /// 是否推荐
      /// </summary>
      public bool IsRecommend { get; set; }
      /// <summary>
      /// 城市三字码
      /// </summary>
      public string CityCode { get; set; }
      /// <summary>
      /// 联系手机
      /// </summary>
      public string Mobile { get; set; }

      /// <summary>
      /// 结算方式
      /// </summary>
      public bool JieSuanType { get; set; }


      public string  InterfaceId { get; set; }
      /// <summary>
      /// 首页显示，上下架
      /// </summary>
      public EyouSoft.Model.Enum.XianLuStructure.XianLuZT IsIndex { get; set; }
   }
   #endregion

   #region 酒店图片
   /// <summary>
   /// 酒店图片
   /// </summary>
   [Table("tbl_HotelImg")]
   public class MHotelImg
   {
      /// <summary>
      /// 图片编号
      /// </summary>
      [PrimaryKey]
      [Identity(IdentityType.Increment)]
      public int ImgId { get; set; }
      /// <summary>
      /// 酒店编号
      /// </summary>
      public string HotelId { get; set; }
      /// <summary>
      /// 图片类型
      /// </summary>
      public EyouSoft.Model.Enum.HotelImgType ImgCategory { get; set; }
      /// <summary>
      /// 图片路径
      /// </summary>
      public string FilePath { get; set; }
      /// <summary>
      /// 图片描述
      /// </summary>
      public string Desc { get; set; }
      /// <summary>
      /// 发布时间
      /// </summary>
      public DateTime IssueTime { get; set; }
      /// <summary>
      /// 发布用户
      /// </summary>
      public string OperatorId { get; set; }
   }
   #endregion

   #region 酒店地标
   /// <summary>
   /// 酒店地标
   /// </summary>
   [Serializable]
   public class MHotelLandMark
   {
      /// <summary>
      /// 酒店编号
      /// </summary>
      public string HotelId { get; set; }
      /// <summary>
      /// 地标编号
      /// </summary>
      public int LandMarkId { get; set; }
      /// <summary>
      /// 地标名字
      /// </summary>
      public string Por { get; set; }
   }
   #endregion

   #region 酒店信息
   /// <summary>
   /// 酒店信息
   /// </summary>
   [Serializable]
   public class MHotel : MBaseHotel
   {
      /// <summary>
      /// 地标集合
      /// </summary>
      public List<MHotelLandMark> MarkList { get; set; }
      /// <summary>
      /// 酒店的图片 
      /// </summary>
      public List<MHotelImg> ImgList { get; set; }
      /// <summary>
      /// 酒店房型(用于列表的获取)
      /// </summary>
      public List<EyouSoft.Model.HotelStructure.MHotelRoomType> RoomTypeList { get; set; }
      /// <summary>
      /// 用户编号
      /// </summary>
      public int UserId { get; set; }
      /// <summary>
      /// 用户名
      /// </summary>
      public string Username { get; set; }

   }
   #endregion

   #region 酒店查询信息
   /// <summary>
   /// 酒店查询信息
   /// </summary>
   [Serializable]
   public class MHotelSearch
   {
      /// <summary>
      /// 酒店代码
      /// </summary>
      public string HotelCode { get; set; }
      /// <summary>
      /// 酒店名称（中）
      /// </summary>
      public string HotelName { get; set; }
      /// <summary>
      /// 酒店城市代码
      /// </summary>
      public string HotelCityCode { get; set; }
      /// <summary>
      /// 入住时间
      /// </summary>
      public DateTime? InDate { get; set; }
      /// <summary>
      /// 离店时间
      /// </summary>
      public DateTime? OutDate { get; set; }
      /// <summary>
      /// 最大价格
      /// </summary>
      public decimal MaxPrice { get; set; }
      /// <summary>
      /// 最小价格
      /// </summary>
      public decimal MinPrice { get; set; }
      /// <summary>
      /// 酒店星级
      /// </summary>
      public Enum.HotelStar? HotelStar { get; set; }

      /// <summary>
      /// 酒店地标编号
      /// </summary>
      public int HotelMarkId { get; set; }

      /// <summary>
      /// 是否热门
      /// </summary>
      public bool? IsHot { get; set; }

      /// <summary>
      /// 是否推荐
      /// </summary>
      public bool? IsRecommend { get; set; }
      /// <summary>
      /// 城市三字码
      /// </summary>
      public string CityCode { get; set; }

      /// <summary>
      /// 排序索引  默认 0 酒店添加时间降序排列；1/2价格升/降序排列；3/4酒店星级升/降序排列
      /// </summary>
      public int OrderIndex { get; set; }

      /// <summary>
      /// 酒店状态
      /// </summary>
      public EyouSoft.Model.Enum.HotelStatus? HotelStatus { get; set; }

      /// <summary>
      /// 省份
      /// </summary>
      public int ProvinceId { get; set; }
      /// <summary>
      /// 城市
      /// </summary>
      public int CityId { get; set; }
      /// <summary>
      /// 县区
      /// </summary>
      public int CountyId { get; set; }

   }
   #endregion


}
