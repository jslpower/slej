using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.Enum
{
    /// <summary>
    /// 未提现,已提现
    /// </summary>
    public enum TiXianState
    {
        未提现 = 0,
        已提现 = 1,
        提现失败 = 2
    }

    /// <summary>
    /// 未审核,未通过,已审核,
    /// </summary>
    public enum TiXianShenHe
    {
        未审核 = 0,
        未通过 = 1,
        已审核 = 2
    }
}
