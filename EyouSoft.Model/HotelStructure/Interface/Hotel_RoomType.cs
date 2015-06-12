using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.HotelStructure.Interface
{
   using System;
   using Linq.ORM;
   using System.ComponentModel;
   using Linq.ORM.Attribute;
   /// <summary>
   /// 
   /// </summary>
   [Table("Hotel_RoomType")]
   public class Hotel_RoomType
   {
      /// <summary>
      /// 酒店代码
      /// </summary>
      [PrimaryKey]
      [DisplayName("酒店代码")]
      public string HOTEL_CODE { get; set; }
      /// <summary>
      /// 房型代码
      /// </summary>
      [PrimaryKey]
      [DisplayName("房型代码")]
      public string ROOM_TYPE_CODE { get; set; }
      /// <summary>
      /// 房型状态
      /// </summary>
      [DisplayName("房型状态")]
      public string STATUS { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string INV_STATUS { get; set; }
      /// <summary>
      /// 是否无烟
      /// </summary>
      [DisplayName("是否无烟")]
      public string NO_SMOKING { get; set; }
      /// <summary>
      /// 床型
      /// </summary>
      [DisplayName("床型")]
      public string BED_TYPE { get; set; }
      /// <summary>
      /// 房间总数量
      /// </summary>
      [DisplayName("房间总数量")]
      public string TOTAL_NUMBER { get; set; }
      /// <summary>
      /// 楼层
      /// </summary>
      [DisplayName("楼层")]
      public string FLOOR { get; set; }
      /// <summary>
      /// 房间面积
      /// </summary>
      [DisplayName("房间面积")]
      public string ROOM_AREA { get; set; }
      /// <summary>
      /// 最大加床数
      /// </summary>
      [DisplayName("最大加床数")]
      public string MAX_ADD_BED { get; set; }
      /// <summary>
      /// 描述
      /// </summary>
      [DisplayName("描述")]
      public string DESCP { get; set; }
      /// <summary>
      /// 房型名称
      /// </summary>
      [DisplayName("房型名称")]
      public string INV_TYPE { get; set; }
      /// <summary>
      /// 房型种类
      /// </summary>
      [DisplayName("房型种类")]
      public string CATEGORY { get; set; }
      /// <summary>
      /// 房型景观
      /// </summary>
      [DisplayName("房型景观")]
      public string ROOM_VIEW { get; set; }
      /// <summary>
      /// 最大入住客人数目
      /// </summary>
      [DisplayName("最大入住客人数目")]
      public string MAX_GUEST_NUM { get; set; }
      /// <summary>
      /// 宽带
      /// </summary>
      [DisplayName("宽带")]
      public string INTERNET { get; set; }
      /// <summary>
      /// 房型英文名称
      /// </summary>
      [DisplayName("房型英文名称")]
      public string EN_INV_TYPE { get; set; }
      /// <summary>
      /// 床面积
      /// </summary>
      [DisplayName("床面积")]
      public string BED_AREA { get; set; }

      public enum InternetType
      {
         [Description("免费上网")]
         Y = 1,
         [Description("上网收费")]
         C = 2,
         [Description("不能上网")]
         N = 3
      }

      public enum SmokingType
      {
         [Description("有烟")]
         Y,
         [Description("无烟")]
         N,
      }

      public enum Category
      {
         [Description("经济")]
         BUD,
         [Description("标准")]
         STA,
         [Description("豪华")]
         DEL,
         [Description("舒适")]
         SUI,
         [Description("行政")]
         ADM,
         [Description("商务")]
         BIS,
      }
   }
}
