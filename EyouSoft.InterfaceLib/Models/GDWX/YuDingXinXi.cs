using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Enums.GDWX;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.GDWX
{
    //[XmlRoot("lineorder")]
    /// <summary>
    /// 路线预订信息
    /// </summary>
    public class YuDingXinXi
    {
        /// <summary>
        /// 订单 ID 
        /// </summary>
        public int id;
        /// <summary>
        /// 发团 ID
        /// </summary>
        public int tour_id;
        /// <summary>
        ///  类型  1 代理，2 会员，3 门市
        /// </summary>
        public int type;
        /// <summary>
        /// 订单类型  0 正常 1 团购 2 抢购
        /// </summary>
        public int type2;
        /// <summary>
        ///  团购 ID  是团购或是抢购的团购 ID
        /// </summary>
        public int tuan_id;
        /// <summary>
        /// 订单号 
        /// </summary>
        public string number;
        /// <summary>
        /// 预订人会员 ID
        /// </summary>
        public int user_id;
        /// <summary>
        /// 预订人公司 ID 
        /// </summary>
        public int company_id;
        /// <summary>
        /// 预订公司名称  由于修改公司名称这个字段名不会自动修改， 请根据会员 ID来查询公司名称
        /// </summary>
        public string company_title;
        /// <summary>
        /// 预订时间
        /// </summary>
        public DateTime add_time;
        /// <summary>
        /// 预订人姓名 
        /// </summary>
        public string order_name;
        /// <summary>
        /// 预订人电话
        /// </summary>
        public string order_tel;
        /// <summary>
        /// 预订备注 
        /// </summary>
        public string order_content;

        /// <summary>
        /// 门市价 以下内容同发团价格说明
        /// </summary>
        public int market_price;

        public int user_price;
        public int agent_price;
        public int children_market_price;
        public int children_user_price;

        public int children_agent_price;

        public int children_bed_market_price;

        public int children_bed_user_price;

        public int children_bed_agent_price;

        public int children_bed_reduce;
        /// <summary>
        /// 导服费  以下同线路导服务说明
        /// </summary>
        public int tips_price;
        public Is has_tips_price;

        public int zifei_price;
        public Is has_zifei_price;

        public int taxes_price;
        public Is has_taxes_price;
        public string other_title;
        public int other_price;
        public Is has_other_price;
        /// <summary>
        ///  成人人数 
        /// </summary>
        public int num1;
        public int num2;
        public int num3;
        /// <summary>
        /// 总人数 
        /// </summary>
        public int total_num;
        /// <summary>
        /// 费用调整 
        /// </summary>
        public decimal adjust_price;
        /// <summary>
        /// 调整说明
        /// </summary>
        public string adjust_content;
        /// <summary>
        /// 总价格
        /// </summary>
        public decimal total_adjust_price;
        /// <summary>
        /// 己付金额 
        /// </summary>
        public decimal yifu_price;

        /// <summary>
        ///  状态  1 未处理，2 未确认，3 预留，4 审核通过，5 取消
        /// </summary>
        public YuDingZhuangTai state;
        /// <summary>
        /// 是否己经回传团费确认单
        /// </summary>
        public Is is_price_lock;
        /// <summary>
        /// 预留时间  只有订单状态是 3 才有效
        /// </summary>
        public DateTime reserve_time;
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime state_time;
    }
}
