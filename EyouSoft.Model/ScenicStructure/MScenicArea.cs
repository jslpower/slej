using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.Model.Enum.ScenicStructure;
using EyouSoft.Model.ScenicStructure.WebModel;
using Linq.ORM;
using Linq.ORM.Attribute;
using EyouSoft.Model.SystemStructure;

namespace EyouSoft.Model.ScenicStructure
{
    /// <summary>
    /// 景区
    /// </summary>
    [Table("tbl_ScenicArea")]
    public class MScenicArea
    {
        /// <summary>
        /// 景区编号
        /// </summary>
        [PrimaryKey]
        public string ScenicId { get; set; }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRecommend { get; set; }
        /// <summary>
        /// 景区名称
        /// </summary>
        public string ScenicName { get; set; }
        /// <summary>
        /// 英文名
        /// </summary>
        public string EnName { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string X { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public string Y { get; set; }
        /// <summary>
        /// 客服电话
        /// </summary>
        public string ServiceTel { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactTel { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string ContactMobile { get; set; }
        /// <summary>
        /// 联系传真
        /// </summary>
        public string ContactFax { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public int ProvinceId { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        /// 
        public string ProvinceName { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 县区
        /// </summary>
        public int CountyId { get; set; }
        /// <summary>
        /// 中文地址
        /// </summary>
        public string CnAddress { get; set; }
        /// <summary>
        /// 英文地址
        /// </summary>
        public string EnAddress { get; set; }
        /// <summary>
        /// 景区A级
        /// </summary>
        public ScenicLevel? ScenicLevel { get; set; }
        /// <summary>
        /// 成立年份
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 日程开放时间
        /// </summary>
        public string OpenTime { get; set; }
        /// <summary>
        /// 景区详细介绍
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 交通说明
        /// </summary>
        public string Traffic { get; set; }
        /// <summary>
        /// 周边设施
        /// </summary>
        public string Facilities { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 发布用户
        /// </summary>
        public string OperatorId { get; set; }
        /// <summary>
        /// 发布用户
        /// </summary>
        [ColumnIgnore]
        public string OperatorName { get; set; }
        /// <summary>
        /// 点击量
        /// </summary>
        public int ClickNum { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        ///结算方式 
        /// </summary>
        public bool JieSuanType { get; set; }
        /// <summary>
        ///景区接口 ID
        /// </summary>
        public string InterfaceID { get; set; }
        /// <summary>
        /// 产品来源
        /// </summary>
        public int ChanPinSource { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 网址
        /// </summary>
        public string NetAddress { get; set; }
        /// <summary>
        /// 首页显示、上下架
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.XianLuZT IsIndex { get; set; }
        /// <summary>
        /// 景区地标关联
        /// </summary>
        public List<MScenicRelationLandMark> MarkList { get; set; }
        /// <summary>
        /// 景区图片
        /// </summary>
        public List<MScenicAreaImg> ImgList { get; set; }
        /// <summary>
        /// 县区名
        /// </summary>
        [ColumnIgnore]
        public string CountyName { get; set; }
        [ColumnIgnore]
        public decimal SettlementPrice { get; set; }
        [ColumnIgnore]
        public decimal WebPrice { get; set; }
        [ColumnIgnore]
        public decimal RetailPrice { get; set; }
        [ColumnIgnore]
        public MFeeSettings FeeSetting { get; set; }
    }
}
