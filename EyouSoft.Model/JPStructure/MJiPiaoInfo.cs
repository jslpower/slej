//机票公用信息相关业务实体 汪奇志 2014-11-24
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.JPStructure
{
    #region 通知信息业务实体
    /// <summary>
    /// 通知信息业务实体
    /// </summary>
    public class MNotifyInfo
    {
        /// <summary>
        /// 通知编号
        /// </summary>
        public string NotifyId { get; set; }
        /// <summary>
        /// 接收通知的URL
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// 通知类型
        /// </summary>
        public string LeiXing { get; set; }
        /// <summary>
        /// JSON
        /// </summary>
        public string JSON { get; set; }
        /// <summary>
        /// 通知时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 关联类型
        /// </summary>
        public string GuanLianLeiXing { get; set; }
        /// <summary>
        /// 关联编号
        /// </summary>
        public string GuanLianId { get; set; }
        /// <summary>
        /// 处理通知的结果 1成功，其它失败
        /// </summary>
        public string HandlerRetCode { get; set; }
    }
    #endregion

    #region 出票通知信息业务实体
    /// <summary>
    /// 出票通知信息业务实体
    /// </summary>
    public class MChuPiaoNotifyInfo
    {
        /// <summary>
        /// 订单编号（系统）
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 订单编号（API）
        /// </summary>
        public string ApiDingDanId { get; set; }
        /// <summary>
        /// 出票状态，T-出票完成 F-暂不能出票
        /// </summary>
        public string ChuPiaoStatus { get; set; }
        /// <summary>
        /// 备注，若status=F，此处为暂不能出票的原因
        /// </summary>
        public string BeiZhu { get; set; }
        /// <summary>
        /// 乘机人姓名，多人用^分隔，如：张三^李四
        /// </summary>
        public string ChengJiRenName { get; set; }
        /// <summary>
        /// 证件号，多证件号用^分隔
        /// </summary>
        public string ChengJiRenZhengJianHao { get; set; }
        /// <summary>
        /// 票号，多票号用^分隔，对应乘机人的顺序
        /// </summary>
        public string PiaoHao { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string QianMing { get; set; }
        /// <summary>
        /// 接收通知的URL
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// 处理通知的结果 1成功，其它失败
        /// </summary>
        public string HandlerRetCode { get; set; }
        /// <summary>
        /// 通知时间
        /// </summary>
        public DateTime NotifyTime { get; set; }
    }
    #endregion
}
