namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.models.easyhotel.orderinfo;
    using com.travelsky.hotelbesdk.utils;
    using System;
    using System.Linq;

    public class HotelResDetailSearchImpl : HotelbeReq
    {
        public override void checkReq()
        {
            HotelResDetailReqCondition basereqcondition = base.Basereqcondition as HotelResDetailReqCondition;
            if (string.IsNullOrEmpty(basereqcondition.getOrderid()))
            {
                throw new HotelbeException("订单号不能为空!");
            }
        }

        public override object processResp(OTResponse response)
        {
            OrderInfo info = new OrderInfo();
            if (response != null)
            {
                if (response.HotelResDetailSearchRS == null)
                {
                    return info;
                }
                if ((response.HotelResDetailSearchRS.HotelReservations != null) && (response.HotelResDetailSearchRS.HotelReservations.Count<HotelReservation>() > 0))
                {
                    info.Resstatus = response.HotelResDetailSearchRS.HotelReservations[0].ResStatus;
                }
            }
            return info;
        }

        public override void setReq()
        {
            HotelResDetailReqCondition basereqcondition = base.Basereqcondition as HotelResDetailReqCondition;
            base.basereq = new TH_HotelResDetailSearchRQ();
            ((TH_HotelResDetailSearchRQ) base.basereq).HotelResDetailSearchRQ.getHotelResSearchCriteria().setResID(basereqcondition.getOrderid());
        }
    }
}

