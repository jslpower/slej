using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.InterfaceLib
{
    public class APIOrder
    {
        public int InsertOrder(EyouSoft.Model.XianLuStructure.MXianLuInfo tinfo, EyouSoft.Model.XianLuStructure.MOrderInfo OrderInfo)
        {
            int resultVal = 0;

            //return resultVal;
            switch (tinfo.Line_Source)
            {
                case EyouSoft.Model.XianLuStructure.LineSource.博客:
                    if (tinfo.LineType == EyouSoft.Model.XianLuStructure.LineType.长线)
                        resultVal = new EyouSoft.InterfaceLib.BokServiceSeeker().SetLineOrder(tinfo, OrderInfo);
                    else
                        resultVal = new EyouSoft.InterfaceLib.BokServiceSeeker().SetShortOrder(tinfo, OrderInfo);
                    break;
                case EyouSoft.Model.XianLuStructure.LineSource.光大:
                    resultVal = new EyouSoft.InterfaceLib.GDWX.Lib.GDWXSeeker().LuXianYuDing(tinfo, OrderInfo);
                    break;
                case EyouSoft.Model.XianLuStructure.LineSource.省中旅:
                    //resultVal = new EyouSoft.InterfaceLib.ZLCommonServiceSeeker().insert_obd_order(tinfo, OrderInfo);
                    resultVal = 1;
                    break;
                case EyouSoft.Model.XianLuStructure.LineSource.旅游圈:
                    resultVal = new EyouSoft.InterfaceLib.GDWX.Lib.GDWXSeeker().LuXianYuDing(tinfo, OrderInfo);
                    break;

            }
            return resultVal;
        }
    }
}
