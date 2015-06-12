using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Models.GDWX;

namespace EyouSoft.InterfaceLib.Response.GDWX
{
    public class GetTuanGouListResponse : ResponseBase
    {
        public TuanGou[] data;
    }
}
