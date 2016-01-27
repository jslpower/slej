using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;

namespace EyouSoft.Model.WeiXin
{
    /// <summary>
    /// 游记
    /// </summary>
    public class MYouJi
    {
        /// <summary>
        /// 游记主ID
        /// </summary>
        public string YouJiId { get; set; }
        /// <summary>
        /// 会员Id
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 游记标题
        /// </summary>
        public string YouJiTitle { get; set; }
        /// <summary>
        /// 游记内容
        /// </summary>
        public IList<XingCheng> YouJiContent { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime IssueTime { get; set; }

        /// <summary>
        /// 游记类型
        /// </summary>
        public YouJiLeiXing YouJiType { get; set; }
        /// <summary>
        /// 视频地址
        /// </summary>
        public string ShiPinLink { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string HuiYuanName { get; set; }

    }
    /// <summary>
    /// 游记行程
    /// </summary>
    public class XingCheng
    {
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImgFile { get; set; }
        /// <summary>
        /// 行程内容
        /// </summary>
        public string XingChengContent { get; set; }
    }

    /// <summary>
    /// 游记查询类
    /// </summary>
    public class MYouJiSer
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 游记类型
        /// </summary>
        public YouJiLeiXing? YouJiType { get; set; }
        /// <summary>
        /// 游记标题
        /// </summary>
        public string YouJiTitle { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string HuiYuanName { get; set; }

        /// <summary>
        /// 是否显示管理后台数据
        /// </summary>
        public bool XianShiGuanLi { get; set; }
    }
}
