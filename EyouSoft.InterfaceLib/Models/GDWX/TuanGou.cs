using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Enums.GDWX;

namespace EyouSoft.InterfaceLib.Models.GDWX
{

   [XmlRoot("tuanlist")]
   public class TuanGou
   {
      /// <summary>
      /// 序号 
      /// </summary>
      public string id;
      /// <summary>
      /// 线路 ID 
      /// </summary>
      public string line_id;
      /// <summary>
      /// 发班 ID 
      /// </summary>
      public int tour_id;
      /// <summary>
      /// 团购开始时间
      /// </summary>
      public DateTime start_days;
      /// <summary>
      /// 团购结束时间
      /// </summary>
      public DateTime end_days;
      /// <summary>
      /// 每个 ID 限购几人 0 代表不限购
      /// </summary>
      public int limit_buy;
      /// <summary>
      /// 团购门市价 
      /// </summary>
      public int market_price;
      /// <summary>
      /// 团购会员价 
      /// </summary>
      public int user_price;
      /// <summary>
      /// 团购代理价 
      /// </summary>
      public int agent_price;
      public int children_market_price;
      public int children_user_price;
      public int children_agent_price;
      public int children_bed_market_price;

      public int children_bed_user_price;

      public int children_bed_agent_price;

      public int children_bed_reduce;
      /// <summary>
      /// 是否显示 
      /// </summary>
      public Is show;
      /// <summary>
      /// 添加时间 
      /// </summary>
      public DateTime add_time;
   }
}
