namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.models.easyhotel.orderinfo;
    using com.travelsky.hotelbesdk.utils;
    using System;
    using System.Collections.Generic;

    public class HotelResProcessReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
            OrderRemarkReqCondition basereqcondition = base.Basereqcondition as OrderRemarkReqCondition;
            if (string.IsNullOrEmpty(basereqcondition.Orderid))
            {
                throw new HotelbeException("订单号不能为空!");
            }
        }

        public override object processResp(OTResponse response)
        {
            List<OrderRemarkInfo> list = new List<OrderRemarkInfo>();
            if (null != response)
            {
                if (null == response.HotelResProcessRS)
                {
                    return list;
                }
                if (null == response.HotelResProcessRS.ResProcesses)
                {
                    return list;
                }
                foreach (HotelResProcess process in response.HotelResProcessRS.ResProcesses)
                {
                    OrderRemarkInfo item = new OrderRemarkInfo {
                        OperaTor = process.OperaTor,
                        ProcessDateTime = process.ProcessDateTime,
                        ProcessType = process.ProcessType,
                        Remark = process.Remark
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        public override void setReq()
        {
            OrderRemarkReqCondition basereqcondition = base.Basereqcondition as OrderRemarkReqCondition;
            base.basereq = new TH_HotelResProcessRQ();
            ((TH_HotelResProcessRQ) base.basereq).HotelResProcessRQ.ResOrderID = basereqcondition.Orderid;
        }
    }
}

