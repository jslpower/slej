using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    /// <summary>
    /// 验证码信息实体
    /// </summary>
    public class MYanZhengMaInfo
    {
        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string ShouJi { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string YanZhengMa { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public EyouSoft.Model.Enum.YanZhengMaLeiXing LeiXing { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public EyouSoft.Model.Enum.YanZhengMaStatus Status { get; set; }
        /// <summary>
        /// 状态(OUTPUT)，已做时间判断
        /// </summary>
        public EyouSoft.Model.Enum.YanZhengMaStatus Status1
        {
            get
            {
                if (Status == EyouSoft.Model.Enum.YanZhengMaStatus.有效)
                {
                    if (this.IssueTime.AddMinutes(30) < DateTime.Now) return EyouSoft.Model.Enum.YanZhengMaStatus.已过期;

                    return Status;
                }

                return Status;
            }
        }
    }
}
