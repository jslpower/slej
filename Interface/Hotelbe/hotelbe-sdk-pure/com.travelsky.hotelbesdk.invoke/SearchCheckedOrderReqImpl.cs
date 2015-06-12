namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.models.easyhotel.orderinfo;
    using com.travelsky.hotelbesdk.utils;
    using System;

    public class SearchCheckedOrderReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
            SearchCheckedOrderReqCondition basereqcondition = base.Basereqcondition as SearchCheckedOrderReqCondition;
            if (string.IsNullOrEmpty(basereqcondition.Orderid))
            {
                throw new HotelbeException("订单号不能为空!");
            }
        }

        public override object processResp(OTResponse response)
        {
            CheckedInfo info = new CheckedInfo();
            if (response != null)
            {
                if (response.HotelCheckSearchRS == null)
                {
                    return info;
                }
                if ((response.HotelCheckSearchRS.HotelCheckInfos == null) || (response.HotelCheckSearchRS.HotelCheckInfos.Count <= 0))
                {
                    return info;
                }
                if (response.HotelCheckSearchRS.HotelCheckInfos[0].HotelCheckBrief != null)
                {
                    HotelCheckBrief hotelCheckBrief = response.HotelCheckSearchRS.HotelCheckInfos[0].HotelCheckBrief;
                    info.setResID(hotelCheckBrief.ResID);
                    info.setCheckedstatus(hotelCheckBrief.CheckStatus);
                    info.setCreateDate(hotelCheckBrief.CreateDate);
                    info.setRoomNight(hotelCheckBrief.RoomNight);
                    info.setRoomQuantity(hotelCheckBrief.RoomQuantity);
                    info.setPayment(hotelCheckBrief.Payment);
                    info.setTotalFee(hotelCheckBrief.TotalFee);
                    info.setTotalRateAmount(hotelCheckBrief.TotalRateAmount);
                    info.setDuration(hotelCheckBrief.TimeSpan.Duration);
                    info.setRealCheckInDate(hotelCheckBrief.TimeSpan.StartDate);
                    info.setRealCheckOutDate(hotelCheckBrief.TimeSpan.EndDate);
                    info.setTotalCommision(hotelCheckBrief.Commision.TotalCommision);
                    info.setRoomName(hotelCheckBrief.RoomType.RoomTypeName);
                    info.setCommisionType(hotelCheckBrief.Commision.CommisionType);
                    info.setCommisionPercent(hotelCheckBrief.Commision.TaxPercent);
                    info.setCommisionFix(hotelCheckBrief.Commision.Fix);
                }
            }
            return info;
        }

        public override void setReq()
        {
            SearchCheckedOrderReqCondition basereqcondition = base.Basereqcondition as SearchCheckedOrderReqCondition;
            base.basereq = new TH_HotelCheckSearchRQ();
            ResID item = new ResID {
                Value = basereqcondition.Orderid
            };
            ((TH_HotelCheckSearchRQ) base.basereq).HotelCheckSearchRQ.ResIDs.Add(item);
            if (!basereqcondition.getStatus().Equals(null))
            {
                if (SearchCheckedOrderReqCondition.ENUM_STATUS.STATUS_NNN.Equals(basereqcondition.getStatus()))
                {
                    ((TH_HotelCheckSearchRQ) base.basereq).HotelCheckSearchRQ.CheckStatus = "NNN";
                }
                else if (SearchCheckedOrderReqCondition.ENUM_STATUS.STATUS_CAN.Equals(basereqcondition.getStatus()))
                {
                    ((TH_HotelCheckSearchRQ) base.basereq).HotelCheckSearchRQ.CheckStatus = "CAN";
                }
                else if (SearchCheckedOrderReqCondition.ENUM_STATUS.STATUS_INN.Equals(basereqcondition.getStatus()))
                {
                    ((TH_HotelCheckSearchRQ) base.basereq).HotelCheckSearchRQ.CheckStatus = "INN";
                }
                else if (SearchCheckedOrderReqCondition.ENUM_STATUS.STATUS_LES.Equals(basereqcondition.getStatus()))
                {
                    ((TH_HotelCheckSearchRQ) base.basereq).HotelCheckSearchRQ.CheckStatus = "LES";
                }
                else if (SearchCheckedOrderReqCondition.ENUM_STATUS.STATUS_MOR.Equals(basereqcondition.getStatus()))
                {
                    ((TH_HotelCheckSearchRQ) base.basereq).HotelCheckSearchRQ.CheckStatus = "MOR";
                }
                else if (SearchCheckedOrderReqCondition.ENUM_STATUS.STATUS_NML.Equals(basereqcondition.getStatus()))
                {
                    ((TH_HotelCheckSearchRQ) base.basereq).HotelCheckSearchRQ.CheckStatus = "NML";
                }
            }
        }
    }
}

