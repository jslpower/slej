using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.ORM;

namespace EyouSoft.Model.ScenicStructure
{
   using System;
   using Linq.ORM;
   using EyouSoft.Model.Enum.ScenicStructure;
   using Linq.ORM.Attribute;

   /// <summary>
   /// 
   /// </summary>
   [Table("tbl_ScenicAreaImg")]
   public class MScenicAreaImg
   {
      /// <summary>
      /// 图片编号
      /// </summary>
      [PrimaryKey]
      public string ImgId { get; set; }
      /// <summary>
      /// 景区编号
      /// </summary>
      public string ScenicId { get; set; }
      /// <summary>
      /// 图片类型
      /// </summary>
      public ScenicImgType ImgType { get; set; }
      /// <summary>
      /// 图片地址
      /// </summary>
      public string Address { get; set; }
      /// <summary>
      /// 图片缩略图
      /// </summary>
      public string ThumbAddress { get; set; }
      /// <summary>
      /// 图片说明
      /// </summary>
      public string Description { get; set; }
      /// <summary>
      /// 发布时间
      /// </summary>
      public DateTime IssueTime { get; set; }
      /// <summary>
      /// 发布用户
      /// </summary>
      public string OperatorId { get; set; }
   }
}
