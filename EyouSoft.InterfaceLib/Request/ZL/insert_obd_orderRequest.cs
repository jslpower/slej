using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.InterfaceLib.Request.ZL
{
    public class insert_obd_orderRequest : RequestBase
    {
        public insert_obd_orderRequest()
        {
            arglist = new SendOrderRequestArgumentList();
        }
        public SendOrderRequestArgumentList arglist;
    }
}
