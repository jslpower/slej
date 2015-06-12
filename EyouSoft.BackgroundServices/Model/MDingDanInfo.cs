using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BackgroundServices.Model
{
    /// <summary>
    /// 自动处理的订单信息业务实体
    /// </summary>
    public class MDingDanInfo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 订单类型 1:线路 2:酒店 3:门票
        /// </summary>
        public int DingDanLeiXing { get; set; }
    }
}
