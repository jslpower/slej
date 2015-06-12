using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.ZL
{
   /// <summary>
   /// 团队头信息
   /// </summary>
   [XmlRoot("group_header")]
   public class Group_Header
   {
      /// <summary>
      /// 团队内部编码
      /// </summary>
      public int SID{ get; set; }
      /// <summary>
      /// 归属线路编码
      /// </summary>
      public int RouteID{ get; set; }
      /// <summary>
      ///  团号
      /// </summary>
      public string Billno{ get; set; }
      /// <summary>
      ///   线路名称
      /// </summary>
      public string Name{ get; set; }
      /// <summary>
      /// 线路类别
      /// </summary>
      public XianluTypes TypeId{ get; set; }
      /// <summary>
      /// 线路主图的 URL
      /// </summary>
      public string MainPic{ get; set; }
      /// <summary>
      /// 目的地
      /// </summary>
      public string Destinations{ get; set; }
      /// <summary>
      ///  出发日期
      /// </summary>
      public string LeftDate{ get; set; }
      /// <summary>
      /// 报名截止日期
      /// </summary>
      public string ShutDate{ get; set; }
      /// <summary>
      /// 回程日期
      /// </summary>
      public string BackDate{ get; set; }
      /// <summary>
      /// 出发城市
      /// </summary>
      public string CityOfDepart{ get; set; }
      /// <summary>
      /// 出发口岸
      /// </summary>
      public string PortOfDepart{ get; set; }
      /// <summary>
      /// 回程口岸
      /// </summary>
      public string PortOfReturn{ get; set; }
      /// <summary>
      /// 天数
      /// </summary>
      public int Days{ get; set; }
      /// <summary>
      /// 线路特色
      /// </summary>
      public string Feature{ get; set; }
      /// <summary>
      /// 费用包含
      /// </summary>
      public string Contain{ get; set; }
      /// <summary>
      /// 费用不含
      /// </summary>
      public string UnContain{ get; set; }
      /// <summary>
      /// 检索关键字
      /// </summary>
      public string Keyword{ get; set; }
      /// <summary>
      /// 门市成人价
      /// </summary>
      public double? AdultPrice{ get; set; }
      /// <summary>
      /// 门市儿童价
      /// </summary>
      public double? ChildPrice{ get; set; }
      /// <summary>
      /// 代理成人价
      /// </summary>
      public double? AdultPriceI{ get; set; }
      /// <summary>
      /// 代理儿童价
      /// </summary>
      public double? ChildPriceI{ get; set; }
      /// <summary>
      /// 是否是最低报价
      /// </summary>
      public Is MinPrice{ get; set; }
      /// <summary>
      /// 团队操作员
      /// </summary>
      public string OperatorName{ get; set; }
      /// <summary>
      /// 当前领队
      /// </summary>
      public string CaptainName{ get; set; }
      /// <summary>
      /// 团队备注
      /// </summary>
      public string Comments{ get; set; }
      /// <summary>
      /// 注意事项
      /// </summary>
      public string Attention{ get; set; }
      /// <summary>
      /// 联系方式
      /// </summary>
      public string LinkInfo{ get; set; }
      /// <summary>
      /// 可收客人数（即时变换）
      /// </summary>
      public int LeftNum{ get; set; }
      /// <summary>
      /// 团队步骤
      /// </summary>
      public Steps StepID{ get; set; }
      /// <summary>
      /// 团队状态
      /// </summary>
      public TuanDuiStates Status{ get; set; }
      /// <summary>
      /// 产品提供商
      /// </summary>
      public Providers ProviderID{ get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string ProviderName{ get; set; }


      /// <summary>
      /// 
      /// </summary>
      public int HKHour { get; set; }

      public int LeftCityID { get; set; }

      public int AvailNum { get; set; }

      public string CustomJur { get; set; }

      public string Recommend { get; set; }

      public string ModifyDate { get; set; }
   }
}
