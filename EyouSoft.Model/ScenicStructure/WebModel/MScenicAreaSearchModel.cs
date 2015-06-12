using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.ScenicStructure.WebModel
{
   #region 景区查询实体
   /// <summary>
   /// 景区查询实体
   /// </summary>
   public class MScenicAreaSearchModel : MScenicArea
   {
      /// <summary>
      /// 景区名称
      /// </summary>
      public string ScenicName { get; set; }

      /// <summary>
      /// 省份编号
      /// </summary>
      public int ProvinceId { get; set; }
      /// <summary>
      /// 城市编号
      /// </summary>
      public int CityId { get; set; }
       /// <summary>
       /// 首页显示
       /// </summary>
      public EyouSoft.Model.Enum.XianLuStructure.XianLuZT? IsIndex { get; set; }
       /// <summary>
       /// 首页排序(0-不排序，>0排序)
       /// </summary>
      public int ProductSort { get; set; }

   }
   #endregion
}
