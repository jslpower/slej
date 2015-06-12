using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Models;
using EyouSoft.InterfaceLib.Models.MTS;

namespace EyouSoft.InterfaceLib.Response.MTS
{
   [XmlRoot("Response")]
   public class ResourceDetailResponse : ResponseArray<ResourceDetailResponse.item>
   {
      public class item
      {
         public int Id;
         public string sightname;
         public string Category;
         /// <summary>
         /// 景区级别
         /// </summary>
         public Grades Grade;
         public string Tel;

         public string Address;
         public string Description;
         /// <summary>
         /// 公交线路
         /// </summary>
         public string BusLine;
         public string DriveLine;
         public string Country;
         public string Province;
         public string City;
         /// <summary>
         /// yyyy/MM/dd HH:mm:ss
         /// </summary>
         public string UpdateTime;
         /// <summary>
         /// 开放时间
         /// </summary>
         public string OpenTime;
         /// <summary>
         /// 友情提示
         /// </summary>
         public string Notice;
         /// <summary>
         /// 地图x坐标
         /// </summary>
         public string MapX;
         public string Mapy;
         public Images[] Imageslist;

         public class Images
         {
            /// <summary>
            /// 图片id
            /// </summary>
            public int sightid;
            public string Title;
            public string ImageUrl;
         }
      }
   }
}
