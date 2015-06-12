namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.models.easyhotel.orderinfo;
    using com.travelsky.hotelbesdk.utils;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class HotelResOutLineSearchImpl : HotelbeReq
    {
        private bool checkCompareDate(string startDate, string endDate)
        {
            DateTime time = Convert.ToDateTime(startDate);
            DateTime time2 = Convert.ToDateTime(endDate);
            return (time.CompareTo(time2) > 0);
        }

        private bool checkDate(string startDate, string endDate)
        {
            DateTime time = Convert.ToDateTime(startDate);
            DateTime time2 = Convert.ToDateTime(endDate);
            return (time.AddDays(30.0).CompareTo(time2) <= 0);
        }

        public override void checkReq()
        {
            HotelResOutLineReqCondition basereqcondition = base.Basereqcondition as HotelResOutLineReqCondition;
            if (!string.IsNullOrEmpty(basereqcondition.getOrderid()))
            {
                if (!string.IsNullOrEmpty(basereqcondition.getBookingDateStart()) || !string.IsNullOrEmpty(basereqcondition.getBookingDateEnd()))
                {
                    if (!(string.IsNullOrEmpty(basereqcondition.getBookingDateStart()) && string.IsNullOrEmpty(basereqcondition.getBookingDateEnd())))
                    {
                        throw new HotelbeException("预订日期范围开始时间或结束时间不能为空");
                    }
                    if (this.checkDate(basereqcondition.getBookingDateStart(), basereqcondition.getBookingDateEnd()))
                    {
                        throw new HotelbeException("开始时间不能大于结束时间");
                    }
                    if (this.checkDate(basereqcondition.getBookingDateStart(), basereqcondition.getBookingDateEnd()))
                    {
                        throw new HotelbeException("只能查询30天内的订单");
                    }
                }
                if (string.IsNullOrEmpty(basereqcondition.getCheckInDateStart()) || string.IsNullOrEmpty(basereqcondition.getCheckInDateEnd()))
                {
                    if (string.IsNullOrEmpty(basereqcondition.getCheckInDateStart()) || string.IsNullOrEmpty(basereqcondition.getCheckInDateEnd()))
                    {
                        throw new HotelbeException("入住日期范围开始时间或结束时间不能为空");
                    }
                    if (this.checkCompareDate(basereqcondition.getCheckInDateStart(), basereqcondition.getCheckInDateEnd()))
                    {
                        throw new HotelbeException("开始时间不能大于结束时间");
                    }
                    if (this.checkDate(basereqcondition.getCheckInDateStart(), basereqcondition.getCheckInDateEnd()))
                    {
                        throw new HotelbeException("只能查询30天内的订单");
                    }
                }
                if (!string.IsNullOrEmpty(basereqcondition.getCheckOutDateStart()) || !string.IsNullOrEmpty(basereqcondition.getCheckOutDateEnd()))
                {
                    if (string.IsNullOrEmpty(basereqcondition.getCheckOutDateStart()) || string.IsNullOrEmpty(basereqcondition.getCheckOutDateEnd()))
                    {
                        throw new HotelbeException("离店日期范围开始时间或结束时间不能为空");
                    }
                    if (this.checkCompareDate(basereqcondition.getCheckOutDateStart(), basereqcondition.getCheckOutDateEnd()))
                    {
                        throw new HotelbeException("开始时间不能大于结束时间");
                    }
                    if (this.checkDate(basereqcondition.getCheckOutDateStart(), basereqcondition.getCheckOutDateEnd()))
                    {
                        throw new HotelbeException("只能查询30天内的订单");
                    }
                }
                if (!string.IsNullOrEmpty(basereqcondition.getGuestMobile()))
                {
                    string pattern = @"^[0-9]{3,4}\-[0-9]{7,8}$|(^[0-9]{7,8}$)|(^\([0-9]{3,4}\)[0-9]{3,8}$)|^0{0,1}13[0-9]{9}$";
                    if (!Regex.IsMatch(basereqcondition.getGuestMobile(), pattern))
                    {
                        throw new HotelbeException("联系人电话格式错误!");
                    }
                }
            }
        }

        public override object processResp(OTResponse response)
        {
            List<OrderOutLineInfo> list = new List<OrderOutLineInfo>();
            if (response != null)
            {
                if (response.HotelResSearchRS == null)
                {
                    return list;
                }
                if (response.HotelResSearchRS.HotelResBriefs == null)
                {
                    return list;
                }
                if (response.HotelResSearchRS.HotelResBriefs == null)
                {
                    return list;
                }
                foreach (HotelResBrief brief in response.HotelResSearchRS.HotelResBriefs)
                {
                    OrderOutLineInfo item = new OrderOutLineInfo {
                        OrderID = brief.ResID
                    };
                    item.setVendorResID(brief.VendorResId);
                    item.setCreateDate(brief.CreateDate);
                    item.setCheckInDate(brief.CheckInDate);
                    item.setCheckOutDate(brief.CheckOutDate);
                    item.setHotelName(brief.HotelName);
                    item.setResStatus(brief.ResStatus);
                    item.setHotelCityCode(brief.HotelCityCode);
                    item.setVendorCode(brief.VendorCode);
                    item.setRoomTypeName(brief.RoomTypeName);
                    item.setGuestName(brief.GuestName);
                    item.setRoomQuantity(brief.RoomQuantity);
                    item.setRoomNight(brief.RoomNight);
                    item.setPayment(brief.Payment);
                    item.setTotalRateAmount(brief.TotalRateAmount);
                    list.Add(item);
                }
            }
            return list;
        }

        public override void setReq()
        {
            HotelResOutLineReqCondition basereqcondition = base.Basereqcondition as HotelResOutLineReqCondition;
            base.basereq = new TH_HotelResSearchRQ();
            if (!string.IsNullOrEmpty(basereqcondition.getOrderid()))
            {
                ((TH_HotelResSearchRQ) base.basereq).getHotelResSearchRQ().getHotelResSearchCriteria().setResID(basereqcondition.getOrderid());
            }
            else
            {
                ReqPageInfo info;
                if (!string.IsNullOrEmpty(basereqcondition.getGuestMobile()))
                {
                    ((TH_HotelResSearchRQ) base.basereq).getHotelResSearchRQ().getHotelResSearchCriteria().setGuestMobile(basereqcondition.getGuestMobile());
                }
                if (!string.IsNullOrEmpty(basereqcondition.getGuestName()))
                {
                    ((TH_HotelResSearchRQ) base.basereq).getHotelResSearchRQ().getHotelResSearchCriteria().setGuestName(basereqcondition.getGuestName());
                }
                if (!string.IsNullOrEmpty(basereqcondition.getHotelName()))
                {
                    ((TH_HotelResSearchRQ) base.basereq).getHotelResSearchRQ().getHotelResSearchCriteria().setHotelName(basereqcondition.getHotelName());
                }
                if (!string.IsNullOrEmpty(basereqcondition.getResStatus()))
                {
                    ((TH_HotelResSearchRQ) base.basereq).getHotelResSearchRQ().getHotelResSearchCriteria().setResStatus(basereqcondition.getResStatus());
                }
                if (!string.IsNullOrEmpty(basereqcondition.getBookingDateStart()))
                {
                    BookingDateRange bookingDateRange = new BookingDateRange();
                    bookingDateRange.setStartDate(basereqcondition.getBookingDateStart());
                    bookingDateRange.setEndDate(basereqcondition.getBookingDateEnd());
                    ((TH_HotelResSearchRQ) base.basereq).getHotelResSearchRQ().getHotelResSearchCriteria().setBookingDateRange(bookingDateRange);
                }
                if (!string.IsNullOrEmpty(basereqcondition.getCheckInDateStart()))
                {
                    ResCheckInDateRange range2 = new ResCheckInDateRange();
                    range2.setStartDate(basereqcondition.getCheckInDateStart());
                    range2.setEndDate(basereqcondition.getCheckInDateEnd());
                    ((TH_HotelResSearchRQ) base.basereq).getHotelResSearchRQ().getHotelResSearchCriteria().ResCheckInDateRange = range2;
                }
                if (!string.IsNullOrEmpty(basereqcondition.getCheckOutDateStart()))
                {
                    ResCheckOutDateRange range3 = new ResCheckOutDateRange {
                        StartDate = basereqcondition.getCheckOutDateStart(),
                        EndDate = basereqcondition.getCheckOutDateEnd()
                    };
                    ((TH_HotelResSearchRQ) base.basereq).getHotelResSearchRQ().getHotelResSearchCriteria().ResCheckOutDateRange = range3;
                }
                if (!string.IsNullOrEmpty(basereqcondition.getReqNumOfEachPage()))
                {
                    info = new ReqPageInfo {
                        ReqNumOfEachPage = basereqcondition.getReqNumOfEachPage()
                    };
                    if (!string.IsNullOrEmpty(basereqcondition.getReqPageNo()))
                    {
                        info.ReqPageNo = basereqcondition.getReqPageNo();
                    }
                    ((TH_HotelResSearchRQ) base.basereq).getHotelResSearchRQ().getHotelResSearchCriteria().setReqPageInfo(info);
                }
                if (!string.IsNullOrEmpty(basereqcondition.getReqPageNo()))
                {
                    info = new ReqPageInfo {
                        ReqPageNo = basereqcondition.getReqPageNo()
                    };
                    if (!string.IsNullOrEmpty(basereqcondition.getReqNumOfEachPage()))
                    {
                        info.ReqNumOfEachPage = basereqcondition.getReqNumOfEachPage();
                    }
                    ((TH_HotelResSearchRQ) base.basereq).getHotelResSearchRQ().getHotelResSearchCriteria().setReqPageInfo(info);
                }
            }
        }
    }
}

