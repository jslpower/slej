using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    /// <summary>
    /// 短信信息业务实体
    /// </summary>
    public class MDuanXinInfo
    {
        /// <summary>
        /// 接收短信的手机号码
        /// </summary>
        public string JieShouShouJi { get; set; }
        /// <summary>
        /// 短信内容
        /// </summary>
        public string NeiRong { get; set; }
    }
}
