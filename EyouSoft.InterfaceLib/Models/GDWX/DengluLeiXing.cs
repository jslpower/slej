using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.InterfaceLib.Enums.GDWX
{
    /// <summary>
    /// 1 同行登陆 2 会员登陆(同行帐号可以直接登陆会员平台)   1和2必须要有用户名和密码,3不需要
    /// </summary>
    public enum DengluLeiXing
    {
        同行=1,
        会员=2,
        直客=3,
    }
}
