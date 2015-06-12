using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Enums.GDWX;
using EyouSoft.InterfaceLib.Models.GDWX;

namespace EyouSoft.InterfaceLib.Response.GDWX
{
    public class GetQianZhengListResponse : ResponseBase
    {
        public QianZheng[] data;
    }

}
