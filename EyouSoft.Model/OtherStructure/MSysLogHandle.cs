using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model
{
    /// <summary>
    /// 操作日志信息表
    /// </summary>
    public class MSysLogHandle
    {
        public MSysLogHandle() { }

        /// <summary>
        /// 日志编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 日志类型号
        /// </summary>
        public int EventCode { get; set; }
        /// <summary>
        /// 日志内容
        /// </summary>
        public string EventMessage { get; set; }
        /// <summary>
        /// 日志标题
        /// </summary>
        public string EventTitle { get; set; }
        /// <summary>
        /// 记录日志时间
        /// </summary>
        public DateTime EventTime { get; set; }
        /// <summary>
        /// 日志发生IP
        /// </summary>
        public string EventIp { get; set; }
    }

    /// <summary>
    /// 查询实体
    /// </summary>
    public class MSearchSysLogHandle
    {
        /// <summary>
        /// 操作员
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 操作开始时间
        /// </summary>
        public DateTime? BeginEventTime { get; set; }

        /// <summary>
        /// 操作结束时间
        /// </summary>
        public DateTime? EndEventTime { get; set; }
    }
}
