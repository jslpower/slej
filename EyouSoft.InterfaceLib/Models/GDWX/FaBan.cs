using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Enums.GDWX;

namespace EyouSoft.InterfaceLib.Models.GDWX
{
    /// <summary>
    /// 发班信息
    /// </summary>
    public class FaBan
    {
        /// <summary>
        ///  发班 ID 
        /// </summary>
        public int id;

        /// <summary>
        /// 线路 ID 
        /// </summary>
        public int line_id;
        /// <summary>
        /// 发班日 
        /// </summary>
        public int dates;
        /// <summary>
        /// 发班日
        /// </summary>
        public string dates_str;
        /// <summary>
        /// 团号 
        /// </summary>
        public string number;
        /// <summary>
        /// 计划名额 
        /// </summary>
        public int plan_num;
        /// <summary>
        /// 预留名额 
        /// </summary>
        public int reserve_num;
        /// <summary>
        /// 最小成团人数
        /// </summary>
        public int mini_num;
        /// <summary>
        /// 候补人数 
        /// </summary>
        public int state1_num;
        /// <summary>
        /// 己订人数
        /// </summary>
        public int state2_num;
        /// <summary>
        /// 余位数 
        /// </summary>
        public int yu_num;
        /// <summary>
        /// 提前预定天数 
        /// </summary>
        public int advan_order_days;
        /// <summary>
        /// 是否报名
        /// </summary>
        public BaoMingJiHua is_lock;
        /// <summary>
        /// 定金（元每人）
        /// </summary>
        public int deposit_price;
        /// <summary>
        /// 门市价 
        /// </summary>
        public int market_price1;
        /// <summary>
        /// 代理价
        /// </summary>
        public int agent_price1;
        /// <summary>
        /// 儿童不占床门市价 
        /// </summary>
        public int children_bed_market_price;
        /// <summary>
        /// 儿童不占床代理价 
        /// </summary>
        public int children_bed_agent_price;
        /// <summary>
        /// 儿童不占床减 
        /// </summary>
        public int children_bed_reduce;
        /// <summary>
        /// 是否提供网上报名
        /// </summary>
        public WangShangBaoMingFangShi Is_order;

        /// <summary>
        /// 儿童门市价 
        /// </summary>
        public int market_price2;
        /// <summary>
        /// 儿童代理价
        /// </summary>
        public int agent_price2;
    }
}
