using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.MallStructure
{
    public class MLianMengLeiBie
    {
        /// <summary>
        /// 类别编号
        /// </summary>
        public int LeiBieID { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string LeiBieMingCheng { get; set; }
        /// <summary>
        /// 类别分类
        /// </summary>
        public EyouSoft.Model.Enum.ModelTypes modelTp { get; set; }
    }
    public class MLianMengLeiBieSer
    {
        /// <summary>
        /// 类别分类
        /// </summary>
        public EyouSoft.Model.Enum.ModelTypes? modelTp { get; set; }
    }
    /// <summary>
    /// 商城联盟
    /// </summary>
    public class MLianMeng
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 类别编号
        /// </summary>
        public int LieBieID { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string LeiBieMingCheng { get; set; }
        /// <summary>
        /// 广告名称
        /// </summary>
        public string SiteName { get; set; }
        /// <summary>
        /// 广告链接
        /// </summary>
        public string SiteUrl { get; set; }
        /// <summary>
        /// 附加图片
        /// </summary>
        public string ImgFile { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>
        public string OperatorID { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWord { get; set; }
        /// <summary>
        /// 类别分类
        /// </summary>
        public EyouSoft.Model.Enum.ModelTypes modelTp { get; set; }
    }
    /// <summary>
    /// 商城联盟
    /// </summary>
    public class MLianMengSer
    {

        /// <summary>
        /// 类别编号
        /// </summary>
        public int? LieBieID { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string LeiBieMingCheng { get; set; }
        /// <summary>
        /// 广告名称
        /// </summary>
        public string SiteName { get; set; }
        /// <summary>
        /// 类别分类
        /// </summary>
        public EyouSoft.Model.Enum.ModelTypes? modelTp { get; set; }

    }
}
