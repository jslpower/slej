using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    public class MYuMing
    {
        /// <summary>
        /// 域名
        /// </summary>
        public string HOSTURL { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GYSID { get; set; }
        /// <summary>
        /// 分销商类型
        /// </summary>
        public EyouSoft.Model.Enum.MemberTypes UserType { get; set; }
    }
}
