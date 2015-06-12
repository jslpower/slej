using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;

namespace EyouSoft.Model
{
    /// <summary>
    /// 旅游攻略主题
    /// </summary>
    public class MTravelStrategyTheme
    {
        public MTravelStrategyTheme() { }
        /// <summary>
        /// 主题编号
        /// </summary>
        public int ThemeID { get; set; }
        /// <summary>
        /// 主题类别名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int SortRule { get; set; }
    }

    /// <summary>
    /// 旅游攻略
    /// </summary>
    public class MTravelStrategy
    {
        public MTravelStrategy() { }

        /// <summary>
        /// 编号
        /// </summary>
        public string TravelID { get; set; }
        /// <summary>
        /// 主题编号
        /// </summary>
        public int ThemeID { get; set; }
        /// <summary>
        /// 主题类别名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 攻略名称
        /// </summary>
        public string TravelName { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string ImgPath { get; set; }
        /// <summary>
        /// 旅行目的地
        /// </summary>
        public string TravelDestination { get; set; }
        /// <summary>
        /// 旅行时间
        /// </summary>
        public DateTime? TravelDate { get; set; }
        /// <summary>
        /// 旅行花费
        /// </summary>
        public decimal TravelMoney { get; set; }
        /// <summary>
        /// 旅途建议
        /// </summary>
        public string TravelAdvice { get; set; }
        /// <summary>
        /// 旅行内容
        /// </summary>
        public string TravelContent { get; set; }
        /// <summary>
        /// 是否首页显示
        /// </summary>
        public bool? IsFrontPage { get; set; }
        /// <summary>
        /// 是否头条
        /// </summary>
        public bool? IsHot { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 操作人类型
        /// </summary>
        public OperatorLeiXing OperatorLeiXing { get; set; }
        /// <summary>
        /// 发布人编号编号
        /// </summary>
        public string OperatorId { get; set; }
        /// <summary>
        /// 发布人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool? IsCheck { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        public int Click { get; set; }
        /// <summary>
        /// 排序规则:1低，2常规，3高
        /// </summary>
        public int SortRule { get; set; }
    }

    /// <summary>
    /// 旅游攻略查询
    /// </summary>
    public class MTravelStrategyCX
    {
        public MTravelStrategyCX() { }

        /// <summary>
        /// 主题编号
        /// </summary>
        public int ThemeID { get; set; }
        /// <summary>
        /// 主题类别名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 攻略名称
        /// </summary>
        public string TravelName { get; set; }
        /// <summary>
        /// 旅行目的地
        /// </summary>
        public string TravelDestination { get; set; }
        /// <summary>
        /// 旅行时间开始
        /// </summary>
        public DateTime? TravelDateBegin { get; set; }

        /// <summary>
        /// 旅行时间结束
        /// </summary>
        public DateTime? TravelDateEnd { get; set; }

        /// <summary>
        /// 发布时间开始
        /// </summary>
        public DateTime? IssueTimeBegin { get; set; }

        /// <summary>
        /// 发布时间结束
        /// </summary>
        public DateTime? IssueTimeEnd { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool? IsCheck { get; set; }
        /// <summary>
        /// 是否首页显示
        /// </summary>
        public bool? IsFrontPage { get; set; }
        /// <summary>
        /// 是否头条
        /// </summary>
        public bool? IsHot { get; set; }
        /// <summary>
        /// 是否有图片
        /// </summary>
        public bool? IsImg { get; set; }
        /// <summary>
        /// 操作人类型
        /// </summary>
        public OperatorLeiXing? OperatorLeiXing { get; set; }
        /// <summary>
        /// 发布人编号编号
        /// </summary>
        public string OperatorId { get; set; }
    }
}
