using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;
using Linq.ORM;
using Linq.ORM.Attribute;
namespace EyouSoft.Model
{
   #region 区域
   /// <summary>
   /// 区域
   /// </summary>
   public class MSysArea
   {
      public MSysArea() { }

      /// <summary>
      /// 编号
      /// </summary>
      public int ID { get; set; }
      /// <summary>
      /// 线路区域名称
      /// </summary>
      public string AreaName { get; set; }
      /// <summary>
      /// 线路区域类别
      /// </summary>
      public AreaType RouteType { get; set; }
   }
   #endregion 区域

   #region 国家
   /// <summary>
   /// 国家
   /// </summary>
   public class MSysCountry
   {
      public MSysCountry() { }

      /// <summary>
      /// 国家编号
      /// </summary>
      public int Id { get; set; }
      /// <summary>
      /// 英文名称
      /// </summary>
      public string EnName { get; set; }
      /// <summary>
      /// Zones
      /// </summary>
      public int Zones { get; set; }
      /// <summary>
      /// 中文名称
      /// </summary>
      public string CnName { get; set; }

   }
   #endregion 国家

   #region 省份
   /// <summary>
   /// 省份
   /// </summary>
   [Table("tbl_SysProvince")]
   public class MSysProvince
   {
      public MSysProvince() { }

      /// <summary>
      /// 编号
      /// </summary>
      [PrimaryKey]
      [Identity(IdentityType.Increment)]
      public int ID { get; set; }
      /// <summary>
      /// 国家编号
      /// </summary>
      public int CountryId { get; set; }
      /// <summary>
      /// 省份简拼
      /// </summary>
      public string HeaderLetter { get; set; }
      /// <summary>
      /// 省份名称
      /// </summary>
      public string Name { get; set; }
      /// <summary>
      /// 地区类型
      /// </summary>
      public int AreaId { get; set; }
      /// <summary>
      /// 排序
      /// </summary>
      public int SortId { get; set; }

      /// <summary>
      /// 下属城市集合
      /// </summary>
      public List<MSysCity> CityList
      {
         get;
         set;
      }

   }
   #endregion 省份

   #region 城市
   /// <summary>
   /// 城市
   /// </summary>
   [Table("tbl_SysCity")]
   public class MSysCity
   {
      public MSysCity() { }
      /// <summary>
      /// 编号
      /// </summary>
      [PrimaryKey]
      [Identity(IdentityType.Increment)]
      public int Id { get; set; }
      /// <summary>
      /// 省份编号
      /// </summary>
      public int ProvinceId { get; set; }
      /// <summary>
      /// 城市名称
      /// </summary>
      public string Name { get; set; }
      /// <summary>
      /// 省会城市ID
      /// </summary>
      public int CenterCityId { get; set; }
      /// <summary>
      /// 城市简拼
      /// </summary>
      public string HeaderLetter { get; set; }
      /// <summary>
      /// 是否出港城市
      /// </summary>
      public bool IsSite { get; set; }
      /// <summary>
      /// 城市二级域名
      /// </summary>
      public string DomainName { get; set; }
      /// <summary>
      /// 是否启用
      /// </summary>
      public bool IsEnabled { get; set; }

   }
   #endregion 城市

   #region 县区
   /// <summary>
   /// 县区
   /// </summary>
   [Table("tbl_SysDistrict")]
   public class MSysDistrict
   {
      public MSysDistrict() { }
      /// <summary>
      /// 编号
      /// </summary>
      [PrimaryKey]
      [Identity(IdentityType.Increment)]
      public int Id { get; set; }
      /// <summary>
      /// 县区名称
      /// </summary>
      public string Name { get; set; }
      /// <summary>
      /// 省份编号
      /// </summary>
      public int ProvinceId { get; set; }
      /// <summary>
      /// 城市编号
      /// </summary>
      public int CityId { get; set; }
      /// <summary>
      /// 县区简拼
      /// </summary>
      public string HeaderLetter { get; set; }

   }
   #endregion 县区

}
