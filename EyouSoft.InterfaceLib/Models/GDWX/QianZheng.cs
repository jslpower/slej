using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Enums.GDWX;

namespace EyouSoft.InterfaceLib.Models.GDWX
{
    [XmlRoot("visalist")]
    public class QianZheng
    {
        /// <summary>
        /// 序号 
        /// </summary>
        public int id;
        /// <summary>
        /// 国家 ID 
        /// </summary>
        public int area_id;
        /// <summary>
        /// 
        /// </summary>
        public QianZhengLeiXing type;
        /// <summary>
        /// 标题 
        /// </summary>
        public string title;
        /// <summary>
        /// 门市价 
        /// </summary>
        public int market_price;
        /// <summary>
        /// 会员价 
        /// </summary>
        public int user_price;
        /// <summary>
        /// 代理价 
        /// </summary>
        public int agent_price;
        /// <summary>
        /// 签证有效期 
        /// </summary>
        public string effective_time;
        /// <summary>
        /// 办理时间 
        /// </summary>
        public string dates;
        /// <summary>
        /// 入境次数 
        /// </summary>
        public string entry_times;
        /// <summary>
        /// 最长停留时间 
        /// </summary>
        public string stay_time;
        /// <summary>
        /// 特别提醒 
        /// </summary>
        public string tips;
        /// <summary>
        /// 是否面试 
        /// </summary>
        public string interview;
        /// <summary>
        /// 预订须知 
        /// </summary>
        public string content;
        /// <summary>
        /// 受理范围
        /// </summary>
        public string accept_scope;
        /// <summary>
        /// 提前预订天数 
        /// </summary>
        public int advan_order_days;
        /// <summary>
        /// 推荐 
        /// </summary>
        public int recommend;
        /// <summary>
        /// 所需财料
        /// </summary>
        public Material[] material;
    }
    
}
