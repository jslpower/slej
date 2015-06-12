using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Enums.GDWX;

namespace EyouSoft.InterfaceLib.Models.GDWX
{
    [XmlRoot("bulletinlist")]
    public class GongGaoZhongXin
    {
        /// <summary>
        /// 序号 
        /// </summary>
        public int id;
        /// <summary>
        /// 类型 
        /// </summary>
        public int type;
        /// <summary>
        /// 标题 
        /// </summary>
        public string title;
        /// <summary>
        /// 内容
        /// </summary>
        public string content;
        /// <summary>
        /// 来源
        /// </summary>
        public string author;
        /// <summary>
        /// 查看数
        /// </summary>
        public int click;
        /// <summary>
        /// 发布时间
        /// </summary>
        public long timeline;
        /// <summary>
        /// 排序
        /// </summary>
        public int sort_id;
        /// <summary>
        /// 显隐
        /// </summary>
        public Is show;
        /// <summary>
        /// 推荐
        /// </summary>
        public IsRecommend recommend;
    }
}
