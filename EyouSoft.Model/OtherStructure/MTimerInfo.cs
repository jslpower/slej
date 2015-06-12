using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    /// <summary>
    /// 定时服务-需要变更状态的订单信息业务实体
    /// </summary>
    [Serializable]
    public class MTimerDingDanInfo
    {
        /// <summary>
        /// 订单类型 1:线路 2:酒店 3:门票
        /// </summary>
        public int DingDanLeiXing { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanId { get; set; }
    }
}
