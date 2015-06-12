using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Enums.GDWX
{
    [XmlRoot("linearealist")]
    public class XianLuFenLei
    {
        /// <summary>
        /// 序号 
        /// </summary>
        public int id;
        /// <summary>
        /// 父级 ID  0 为 1 级目录
        /// </summary>
        public int parent_id;
        /// <summary>
        /// 属性
        /// </summary>
        public LuXianShuXing type_id;
        /// <summary>
        /// 名称 
        /// </summary>
        public string title;
        /// <summary>
        /// 排序 越大越靠前
        /// </summary>
        public int sort_id;
        /// <summary>
        /// 是否显示 1 显示 0 来显示
        /// </summary>
        public Is show;
        /// <summary>
        /// 是否推荐
        /// </summary>
        public int recommend;
    }
}
