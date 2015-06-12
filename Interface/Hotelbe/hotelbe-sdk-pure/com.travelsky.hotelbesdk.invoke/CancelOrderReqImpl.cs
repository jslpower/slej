namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.utils;
    using System;

    public class CancelOrderReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
            CancelOrderReqCondition basereqcondition = base.Basereqcondition as CancelOrderReqCondition;
            if (string.IsNullOrEmpty(basereqcondition.Orderid))
            {
                throw new HotelbeException("订单号不能为空!");
            }
        }

        public override void setReq()
        {
            CancelOrderReqCondition basereqcondition = base.Basereqcondition as CancelOrderReqCondition;
            base.basereq = new TH_HotelCancelRQ();
            HotelReservation item = new HotelReservation();
            ((TH_HotelCancelRQ) base.basereq).HotelCancelRQ.HotelReservations.Add(item);
            ((TH_HotelCancelRQ) base.basereq).HotelCancelRQ.HotelReservations[0].ResOrderID = basereqcondition.Orderid;
        }
    }
}

