using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Enums.GDWX;

namespace EyouSoft.InterfaceLib.Models.GDWX
{
    [XmlRoot("visaarealist")]
    public class QianZhengGuoJia
    {
        /// <summary>
        /// 目的地一级分类ID
        /// </summary>
        public int area_parent_id;
        /// <summary>
        /// 目的地一级分类
        /// </summary>
        public string area_parent_title;
        /// <summary>
        /// 目的地二级分类ID
        /// </summary>
        public int area_id;
        /// <summary>
        /// 目的地二级分类
        /// </summary>
        public string area_title;
        /// <summary>
        /// 序号 
        /// </summary>
        public int id;
        /// <summary>
        /// 父级 ID 0 为 1 级目录
        /// </summary>
        public int parent_id;
        LuXianShuXing type_id;
        /// <summary>
        /// 名称 
        /// </summary>
        public string title;
        /// <summary>
        /// 排序  越大越靠前
        /// </summary>
        public int sort_id;
        /// <summary>
        /// 是否显示1 显示 0 来显示
        /// </summary>
        public int show;
        /// <summary>
        /// 是否推荐 
        /// </summary>
        public int recommend;
    }
}
