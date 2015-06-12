namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.utils;
    using System;
    using System.Text.RegularExpressions;

    public class MultiHotelReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
            MultiHotelReqCondition basereqcondition = base.Basereqcondition as MultiHotelReqCondition;
            string pattern = "[0-9]{4}-[0-9]{2}-[0-9]{2}";
            if (string.IsNullOrEmpty(basereqcondition.Checkindate))
            {
                throw new HotelbeException("入住时间不能为空!");
            }
            if (string.IsNullOrEmpty(basereqcondition.Checkoutdate))
            {
                throw new HotelbeException("离店时间不能为空!");
            }
            if (!string.IsNullOrEmpty(basereqcondition.getPayment()) && !(basereqcondition.getPayment().Equals("T") || basereqcondition.getPayment().Equals("S")))
            {
                throw new HotelbeException("酒店支付类型必须为代收代付:S,前台现付:T");
            }
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
            if (string.IsNullOrEmpty(basereqcondition.Citycode))
            {
                throw new HotelbeException("城市代码不能为空!");
            }
            if (basereqcondition.Pagesize <= 0)
            {
                throw new HotelbeException("每页显示数量不能为空!");
            }
            if (basereqcondition.Pageno <= 0)
            {
                throw new HotelbeException("页码必须大于0!");
            }
            if ((basereqcondition.Minrate != 0) && (basereqcondition.Minrate < 0))
            {
                throw new HotelbeException("酒店最低价不能为负数!");
            }
            if ((basereqcondition.Maxrate != 0) && (basereqcondition.Maxrate < 0))
            {
                throw new HotelbeException("酒店最高价不能为负数!");
            }
            if (((basereqcondition.Minrate != 0) && (basereqcondition.Maxrate != 0)) && (basereqcondition.Minrate > basereqcondition.Maxrate))
            {
                throw new HotelbeException("酒店最低价不能大于最高价!");
            }
            if (!string.IsNullOrEmpty(basereqcondition.Rank))
            {
                if (basereqcondition.Rank.Length > 2)
                {
                    throw new HotelbeException("酒店星级为1,2,3,4,5,1S,2S,3S,4S,5S,1A,2A,3A,4A,5A(S代表准星级，A代表星级)");
                }
                string str2 = basereqcondition.Rank.Substring(0, 1);
                if ((((str2 != "1") && (str2 != "2")) && ((str2 != "3") && (str2 != "4"))) && (str2 != "5"))
                {
                    throw new HotelbeException("酒店星级为1,2,3,4,5,1S,2S,3S,4S,5S,1A,2A,3A,4A,5A(S代表准星级，A代表星级)");
                }
                if ((basereqcondition.Rank.Length == 2) && (basereqcondition.Rank.Substring(1, 2).Equals("A") || basereqcondition.Rank.Substring(1, 2).Equals("S")))
                {
                    throw new HotelbeException("酒店星级为1,2,3,4,5,1S,2S,3S,4S,5S,1A,2A,3A,4A,5A(S代表准星级，A代表星级)");
                }
            }
        }

        public override void setReq()
        {
            MultiHotelReqCondition basereqcondition = base.Basereqcondition as MultiHotelReqCondition;
            base.basereq = new TH_HotelMultiAvailRQ();
            ((TH_HotelMultiAvailRQ) base.basereq).setCheckInDate(basereqcondition.Checkindate);
            ((TH_HotelMultiAvailRQ) base.basereq).setCheckOutDate(basereqcondition.Checkoutdate);
            ((TH_HotelMultiAvailRQ) base.basereq).setHotelCityCode(basereqcondition.Citycode);
            ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.ConfirmRightNowIndicator = basereqcondition.Confirmrightnow ? "Y" : null;
            if (!string.IsNullOrEmpty(basereqcondition.getPayment()))
            {
                RatePlanCandidate item = new RatePlanCandidate {
                    Payment = basereqcondition.getPayment()
                };
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.RatePlanCandidates.Add(item);
            }
            if (basereqcondition.Maxrate != 0)
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.RateRange.MaxRate = basereqcondition.Maxrate.ToString();
            }
            if (basereqcondition.Minrate != 0)
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.RateRange.MinRate = basereqcondition.Minrate.ToString();
            }
            if (string.IsNullOrEmpty(basereqcondition.Chinesename))
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.HotelSearchCriteria.HotelRef.HotelChineseName = basereqcondition.Chinesename;
            }
            if (string.IsNullOrEmpty(basereqcondition.Englishname))
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.HotelSearchCriteria.HotelRef.HotelEnglishName = basereqcondition.Englishname;
            }
            if (string.IsNullOrEmpty(basereqcondition.Rank))
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.HotelSearchCriteria.Rank = basereqcondition.Rank;
            }
            if (string.IsNullOrEmpty(basereqcondition.District))
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.HotelSearchCriteria.HotelRef.District = basereqcondition.District;
            }
            ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.ReqPageInfo.ReqNumOfEachPage = basereqcondition.Pagesize.ToString();
            ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.ReqPageInfo.ReqPageNo = basereqcondition.Pageno.ToString();
            ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.ReqPageInfo.IsPageView = "Y";
            ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.RoomTypeDetailShowed = basereqcondition.Showdetail ? "Y" : "N";
        }
    }
}

