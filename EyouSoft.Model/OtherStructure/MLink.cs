using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model
{
    /// <summary>
    /// 友情链接
    /// </summary>
    public class MLink
    {
        public MLink() { }

        /// <summary>
        /// 编号
        /// </summary>
        public string LinkID { get; set; }
        /// <summary>
        /// 文本
        /// </summary>
        public string LinkText { get; set; } 
        /// <summary>
        /// 图片
        /// </summary>
        public string ImgPath { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string LinkAddre { get; set; }
        /// <summary>
        /// 排序规则
        /// </summary>
        public int SortRule { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime IssueTime { get; set; }

    }
}
