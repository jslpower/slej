using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Enums.GDWX;

namespace EyouSoft.InterfaceLib.Models.GDWX
{
    /// <summary>
    /// 签证所需材料
    /// </summary>
    public class Material
    {
        /// <summary>
        /// 序号 
        /// </summary>
        public int id;
        /// <summary>
        /// 类型
        /// </summary>
        public QianZhengRenLeiXing type;
        /// <summary>
        /// 签证 ID 
        /// </summary>
        public int visa_id;
        /// <summary>
        /// 标题 
        /// </summary>
        public string title;
        /// <summary>
        /// 内容 
        /// </summary>
        public string content;
    }
}
