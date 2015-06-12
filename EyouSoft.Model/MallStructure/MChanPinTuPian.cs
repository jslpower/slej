using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.MallStructure
{
    /// <summary>
    /// 产品图片
    /// </summary>
    public class MChanPinTuPian
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 图片描述
        /// </summary>
        public string FileDesc { get; set; }
    }
}
