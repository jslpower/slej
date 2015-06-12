using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.GDWX
{
    [XmlRoot("visaorder")]
    public class QianZhengYuDing
    {
        /// <summary>
        /// 序号 
        /// </summary>
        public int id;
        /// <summary>
        /// 签证 ID 
        /// </summary>
        public int visa_id;
        /// <summary>
        /// 类型
        /// </summary>
        public int type;
        /// <summary>
        /// 订单号 
        /// </summary>
        public string number;
        /// <summary>
        /// 预订人 ID 
        /// </summary>
        public int user_id;
        /// <summary>
        /// 预订公司 ID
        /// </summary>
        public int company_id;
        /// <summary>
        /// 预订公司 
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
        /// 备注 
        /// </summary>
        public string order_content;
        /// <summary>
        ///  出发日期 
        /// </summary>
        public DateTime days;
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
        /// 成人数 
        /// </summary>
        public int num1;
        /// <summary>
        /// 儿童数
        /// </summary>
        public int num2;
        /// <summary>
        /// 总人数 
        /// </summary>
        public int total_num;
        /// <summary>
        /// 费用调整
        /// </summary>
        public int adjust_price;
        /// <summary>
        /// 调整说明
        /// </summary>
        public string adjust_content;
        /// <summary>
        /// 结算价
        /// </summary>
        public int total_adjust_price;
        /// <summary>
        /// 己付款 
        /// </summary>
        public float yifu_price;
        /// <summary>
        /// 状态 
        /// </summary>
        public int state;
        /// <summary>
        /// 是否锁定名单 
        /// </summary>
        public int is_price_lock;
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime state_time;
    }
}
