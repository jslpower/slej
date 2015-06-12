namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.utils;
    using System;
    using System.Text.RegularExpressions;

    public class SingleHotelReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
            SingleHotelReqCondition basereqcondition = base.Basereqcondition as SingleHotelReqCondition;
            if (string.IsNullOrEmpty(basereqcondition.Checkindate))
            {
                throw new HotelbeException("入住时间不能为空!");
            }
            if (string.IsNullOrEmpty(basereqcondition.Checkoutdate))
            {
                throw new HotelbeException("离店时间不能为空!");
            }
            if (string.IsNullOrEmpty(basereqcondition.Hotelcode))
            {
                throw new HotelbeException("酒店代码不能为空!");
            }
            string pattern = "[0-9]{4}-[0-9]{2}-[0-9]{2}";
            if (!Regex.IsMatch(basereqcondition.Checkindate, pattern))
            {
                throw new HotelbeException("入住时间格式错误!");
            }
            if (!Regex.IsMatch(basereqcondition.Checkoutdate, pattern))
            {
                throw new HotelbeException("离店时间格式错误!");
            }
            if (DateTime.Parse(basereqcondition.Checkindate) >= DateTime.Parse(basereqcondition.Checkoutdate))
            {
                throw new HotelbeException("入住日期必须小于离店日期!");
            }
            if (DateTime.Parse(basereqcondition.Checkindate) < DateTime.Now.Date)
            {
                throw new HotelbeException("入住日期必须大于等于当前日期!");
            }
        }

        public override void setReq()
        {
            SingleHotelReqCondition basereqcondition = base.Basereqcondition as SingleHotelReqCondition;
            base.basereq = new TH_HotelSingleAvailRQ();
            ((TH_HotelSingleAvailRQ) base.basereq).setCheckInDate(basereqcondition.Checkindate);
            ((TH_HotelSingleAvailRQ) base.basereq).setCheckOutDate(basereqcondition.Checkoutdate);
            ((TH_HotelSingleAvailRQ) base.basereq).setHotelCode(basereqcondition.Hotelcode);
            RatePlanCandidate item = new RatePlanCandidate();
            if (basereqcondition.Vendorcodes != null)
            {
                foreach (string str in basereqcondition.Vendorcodes)
                {
                    Vendor vendor = new Vendor {
                        VendorCode = str
                    };
                    item.VendorsIncluded.Add(vendor);
                }
            }
            ((TH_HotelSingleAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.RatePlanCandidates.Add(item);
        }
    }
}

