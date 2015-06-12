using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model
{
    /// <summary>
    /// 登录日志信息
    /// </summary>
    public class MSysLogLogin
    {
        public MSysLogLogin() { }

        /// <summary>
        /// 日志编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string OperatorId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 登录IP
        /// </summary>
        public string LoginIp { get; set; }
        /// <summary>
        /// 请求头
        /// </summary>
        public string AllHttp { get; set; }
    }

    /// <summary>
    /// 查询实体
    /// </summary>
    public class MSearchSysLogLogin
    {

        /// <summary>
        /// 操作人
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 操作开始时间
        /// </summary>
        public DateTime? BeginIssueTime { get; set; }

        /// <summary>
        /// 操作结束时间
        /// </summary>
        public DateTime? EndIssueTime { get; set; }
    }
}
