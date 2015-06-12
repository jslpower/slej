using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model
{
    /// <summary>
    /// 线路主题
    /// </summary>
    public class MRouteTheme
    {
        public MRouteTheme() { }

        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 主题名称
        /// </summary>
        public string Name { get; set; }    
    }
}
