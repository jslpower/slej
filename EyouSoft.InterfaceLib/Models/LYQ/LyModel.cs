using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.LYQ
{
    [XmlRoot("GetProductResponse")]
    public class BusinessOpenAPIGetProductRepDTO
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 产品XML列表
        /// </summary>
        [XmlArray("Products")]
        [XmlArrayItem("Product")]
        public List<BusinessProductXmlEntity> ProductXmlEntityList { get; set; }

        /// <summary>
        /// 产品班期列表
        /// </summary>
        [XmlArray("ProductSchedules")]
        [XmlArrayItem("ProductSchedule")]
        public List<BusinessProductScheduleXmlEntity> ProductScheduleXmlEntityList { get; set; }
    }

    [XmlRoot("ProductRoot")]
    public class BusinessProductTotalXmlEntity
    {
        /// <summary>
        /// Xml文件总数
        /// </summary>
        public int XmlFileCount { get; set; }
        /// <summary>
        /// 产品数量总数
        /// </summary>
        public int ProductCount { get; set; }
    }

    [XmlRoot("ProductRoot")]
    public class BusinessProductListXmlEntity
    {
        public int TotalCount { get; set; }

        /// <summary>
        /// 所有产品
        /// </summary>
        [XmlArray("Products")]
        [XmlArrayItem("Product")]
        public List<BusinessProductXmlEntity> ProductList { get; set; }
    }

    [XmlRoot("ProductRoot")]
    public class BusinessProductXmlEntity
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public string ProductID { get; set; }

        /// <summary>
        /// 线路名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 线路编号
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 团号
        /// </summary>
        public string TeamCode { get; set; }

        /// <summary>
        /// 酒店标准
        /// </summary>
        public string HotelStandard { get; set; }

        /// <summary>
        /// 酒店标准其他备注
        /// </summary>
        public string HotelStandardOtherDesc { get; set; }

        /// <summary>
        /// 交通方式
        /// </summary>
        public string TrafficType { get; set; }

        /// <summary>
        /// 交通方式其他备注
        /// </summary>
        public string TrafficTypeOtherDesc { get; set; }

        /// <summary>
        /// 旅行天数
        /// </summary>
        public int JourneyDays { get; set; }

        /// <summary>
        /// 入住天数
        /// </summary>
        public int CheckInDays { get; set; }

        /// <summary>
        /// 报名截止天数
        /// </summary>
        public int SignUpEndDays { get; set; }

        /// <summary>
        /// 产品等级
        /// </summary>
        public string ProductLevel { get; set; }

        /// <summary>
        /// 产品卖点
        /// </summary>
        [XmlArray("SellPoints")]
        [XmlArrayItem("SellPoint")]
        public List<string> SellPointList { get; set; }

        /// <summary>
        /// 产品图片
        /// </summary>
        [XmlArray("Images")]
        [XmlArrayItem("Image")]
        public List<string> PicList { get; set; }

        /// <summary>
        /// 上架/下架
        /// </summary>
        public bool IsOnline { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        public string ProductType { get; set; }

        /// <summary>
        /// 旅游类型
        /// </summary>
        public string TravelType { get; set; }

        /// <summary>
        /// 产品第二级区域（线路区域）
        /// </summary>
        public string SecondLevelArea { get; set; }

        /// <summary>
        /// 产品第三级区域（国家/省份）
        /// </summary>
        [XmlArray("ThirdLevelAreas")]
        [XmlArrayItem("ThirdLevelArea")]
        public List<string> ThirdLevelAreaList { get; set; }

        /// <summary>
        /// 产品第四级区域（城市/景区）
        /// </summary>
        [XmlArray("FourthLevelAreas")]
        [XmlArrayItem("FourthLevelArea")]
        public List<string> FourthLevelAreaList { get; set; }

        /// <summary>
        /// 出发城市
        /// </summary>
        public string StartCity { get; set; }

        /// <summary>
        /// 费用包含
        /// </summary>
        public string PriceInclude { get; set; }

        /// <summary>
        /// 费用不含
        /// </summary>
        public string PriceNotInclude { get; set; }

        /// <summary>
        /// 预定须知
        /// </summary>
        public string BookMustKnow { get; set; }

        /// <summary>
        /// 签证信息
        /// </summary>
        public string VisaInfo { get; set; }

        /// <summary>
        /// 班期
        /// </summary>
        [XmlArray("ProductSchedules")]
        [XmlArrayItem("ProductSchedule")]
        public List<BusinessProductScheduleXmlEntity> ProductScheduleList { get; set; }


        /// <summary>
        /// 产品行程
        /// </summary>
        [XmlArray("ProductJourneies")]
        [XmlArrayItem("ProductJourney")]
        public List<BusinessProductJourneyXmlEntity> ProductJourneyList { get; set; }

        /// <summary>
        /// 舱型信息
        /// </summary>
        [XmlArray("ProductCabinTypes")]
        [XmlArrayItem("ProductCabinType")]
        public List<BusinessProductCabinTypeXmlEntity> ProductCabinTypeList { get; set; }
    }

    public class BusinessProductScheduleXmlEntity
    {
        public string ProductID { get; set; }
        public string ScheduleID { get; set; }
        /// <summary>
        /// 班期时间
        /// </summary>
        [XmlElement(DataType = "date")]
        public DateTime ScheduleDate { get; set; }

        /// <summary>
        /// 成人售价
        /// </summary>
        public decimal PersonPrice { get; set; }

        /// <summary>
        /// 成人同行价
        /// </summary>
        public decimal PersonPeerPrice { get; set; }

        /// <summary>
        /// 儿童售价
        /// </summary>
        public decimal ChildPrice { get; set; }

        /// <summary>
        /// 儿童同行价
        /// </summary>
        public decimal ChildPeerPrice { get; set; }

        /// <summary>
        /// 库存数
        /// </summary>
        public int StockCount { get; set; }
    }

    /// <summary>
    /// 产品行程
    /// </summary>
    public class BusinessProductJourneyXmlEntity
    {
        /// <summary>
        /// 旅程段
        /// </summary>
        public string JourneyRang { get; set; }

        /// <summary>
        /// 详细说明
        /// </summary>
        public string JourneyDetail { get; set; }

        /// <summary>
        /// 是否包含早餐
        /// </summary>
        public bool IsHaveBreakfast { get; set; }

        /// <summary>
        /// 早餐说明
        /// </summary>
        public string BreakfastDesc { get; set; }

        /// <summary>
        /// 是否包含中餐
        /// </summary>
        public bool IsHaveLunch { get; set; }

        /// <summary>
        /// 中餐说明
        /// </summary>
        public string LunchDesc { get; set; }

        /// <summary>
        /// 是否包含晚餐
        /// </summary>
        public bool IsHaveDinner { get; set; }

        /// <summary>
        /// 晚餐说明
        /// </summary>
        public string DinnerDesc { get; set; }

        /// <summary>
        /// 是否有住宿
        /// </summary>
        public bool IsHaveStay { get; set; }

        /// <summary>
        /// 住宿说明
        /// </summary>
        public string StayDesc { get; set; }

        /// <summary>
        /// 第几天
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        ///  行程图片
        /// </summary>
        [XmlArray("JourneyImages")]
        [XmlArrayItem("JourneyImage")]
        public List<BusinessProductJourneyImageXmlEntity> JourneyImageList { get; set; }
    }

    public class BusinessProductJourneyImageXmlEntity
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }

    }

    /// <summary>
    /// 舱型信息
    /// </summary>
    public class BusinessProductCabinTypeXmlEntity
    {
        public string CabinTypeID { get; set; }
        /// <summary>
        /// 舱型名称
        /// </summary>
        public string CabinName { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>
        public string Floor { get; set; }
        /// <summary>
        /// 舱内第1/2人同行价
        /// </summary>
        public decimal FirstAndSecondPeerPrice { get; set; }
        /// <summary>
        /// 舱内第1/2人市场价
        /// </summary>
        public decimal FirstAndSecondPrice { get; set; }
        /// <summary>
        /// 舱内第3/4人同行价
        /// </summary>
        public decimal ThirdAndFourthPeerPrice { get; set; }
        /// <summary>
        /// 舱内第3/4人市场价
        /// </summary>
        public decimal ThirdAndFourthPrice { get; set; }
        /// <summary>
        /// 库存数
        /// </summary>
        public int StockCount { get; set; }
    }
}
