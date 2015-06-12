namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.models.easyhotel.i18nmulti;
    using com.travelsky.hotelbesdk.utils;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class EasyI18NMultiHotelReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
            EasyI18NMultiHotelReqCondition basereqcondition = base.Basereqcondition as EasyI18NMultiHotelReqCondition;
            if (string.IsNullOrEmpty(basereqcondition.Checkindate))
            {
                throw new HotelbeException("入住时间不能为空!");
            }
            if (string.IsNullOrEmpty(basereqcondition.Checkoutdate))
            {
                throw new HotelbeException("离店时间不能为空!");
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
            if (string.IsNullOrEmpty(basereqcondition.Citycode))
            {
                throw new HotelbeException("城市代码不能为空!");
            }
            if (string.IsNullOrEmpty(basereqcondition.Countrycode))
            {
                throw new HotelbeException("国家代码不能为空!");
            }
            if (string.IsNullOrEmpty(basereqcondition.Bedtype))
            {
                throw new HotelbeException("床型不能为空!");
            }
            if (!("SB".Equals(basereqcondition.Bedtype) || "TB".Equals(basereqcondition.Bedtype)))
            {
                throw new HotelbeException("床型格式不正确!");
            }
            if (basereqcondition.Adultnum == 0)
            {
                throw new HotelbeException("成人数量必须大于0!");
            }
            if (basereqcondition.Roomnum == 0)
            {
                throw new HotelbeException("房间数量必须大于0!");
            }
            if (basereqcondition.Pagesize == 0)
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
        }

        private MultiHotelVO getEasyI18NMultiHotels(OTResponse response)
        {
            EasyI18NMultiHotelReqCondition basereqcondition = base.Basereqcondition as EasyI18NMultiHotelReqCondition;
            DateTime time = DateTime.Parse(basereqcondition.Checkindate);
            System.TimeSpan span = (System.TimeSpan) (DateTime.Parse(basereqcondition.Checkoutdate) - time);
            int days = span.Days;
            HotelAvailRS hotelAvailRS = response.HotelAvailRS;
            MultiHotelVO lvo = new MultiHotelVO {
                Multihotelinfo = { Checkindate = basereqcondition.Checkindate, Checkoutdate = basereqcondition.Checkoutdate, Citycode = basereqcondition.Citycode, Adultnum = basereqcondition.Adultnum, Childnum = basereqcondition.Childnum, Countrycode = basereqcondition.Countrycode, Roomnum = basereqcondition.Roomnum }
            };
            if ((response.Errors == null) || (response.Errors.Count < 1))
            {
                lvo.Multihotelinfo.Status = true;
            }
            else
            {
                lvo.Multihotelinfo.Status = false;
                return lvo;
            }
            lvo.Multihotelinfo.Pageindex = basereqcondition.Pageno;
            lvo.Multihotelinfo.Pagesize = basereqcondition.Pagesize;
            lvo.Multihotelinfo.Totalhotels = Convert.ToInt32(response.HotelAvailRS.RespPageInfo.TotalNum);
            lvo.Multihotelinfo.Totalpage = Convert.ToInt32(response.HotelAvailRS.RespPageInfo.TotalPageNum);
            List<SingleHotel> list = new List<SingleHotel>();
            foreach (RoomStay stay in hotelAvailRS.RoomStays)
            {
                SingleHotel item = new SingleHotel();
                BasicHotelInfo info = new BasicHotelInfo {
                    RankCode = stay.BasicProperty.Rank,
                    HotelNameEN = stay.BasicProperty.HotelEnName,
                    EnAddress = stay.BasicProperty.Enaddress,
                    HotelCode = stay.BasicProperty.HotelCode,
                    LongDesc = stay.BasicProperty.LongDesc,
                    CityCode = stay.BasicProperty.CityCode,
                    CountryCode = stay.BasicProperty.CountryCode,
                    District = stay.BasicProperty.District,
                    Image = stay.BasicProperty.Images[0].URL
                };
                double num2 = Convert.ToDouble(stay.BasicProperty.Position.Longitude);
                double num3 = Convert.ToDouble(stay.BasicProperty.Position.Latitude);
                info.Longitude = string.Format("{0:0.000}", num2);
                info.Latitude = string.Format("{0:0.000}", num3);
                item.Basichotelinfo = info;
                List<com.travelsky.hotelbesdk.models.easyhotel.i18nmulti.HotelRoomType> list2 = new List<com.travelsky.hotelbesdk.models.easyhotel.i18nmulti.HotelRoomType>();
                foreach (RoomType type in stay.RoomTypes)
                {
                    com.travelsky.hotelbesdk.models.easyhotel.i18nmulti.HotelRoomType type2 = new com.travelsky.hotelbesdk.models.easyhotel.i18nmulti.HotelRoomType {
                        Roomtypename = type.RoomTypeName,
                        Roomtypecode = type.RoomTypeCode
                    };
                    List<HotelRatePlan> list3 = new List<HotelRatePlan>();
                    foreach (RoomRate rate in stay.RoomRates)
                    {
                        if (rate.RoomTypeCode.Equals(type.RoomTypeCode))
                        {
                            HotelRatePlan plan = new HotelRatePlan {
                                Rateplancode = rate.RatePlanCode
                            };
                            foreach (RatePlan plan2 in stay.RatePlans)
                            {
                                if (rate.RatePlanCode.Equals(plan2.RatePlanCode))
                                {
                                    plan.Rateplanname = plan2.RatePlanName;
                                    break;
                                }
                            }
                            Rate rate2 = rate.Rates[0];
                            plan.Meal = rate2.FreeMeal;
                            plan.Currency = rate2.Currency;
                            List<HotelRoomRate> list4 = new List<HotelRoomRate>();
                            double num4 = 0.0;
                            time = DateTime.Parse(basereqcondition.Checkindate);
                            DateTime time2 = DateTime.Parse(basereqcondition.Checkoutdate);
                            while (time < time2)
                            {
                                foreach (Rate rate3 in rate.Rates)
                                {
                                    DateTime time3 = DateTime.Parse(rate3.StartDate);
                                    DateTime time4 = DateTime.Parse(rate3.EndDate);
                                    if ((time >= time3) && (time <= time4))
                                    {
                                        HotelRoomRate rate4 = new HotelRoomRate {
                                            Date = time.ToString("yyyy-MM-dd"),
                                            Price = rate3.AmountPrice
                                        };
                                        list4.Add(rate4);
                                        num4 += double.Parse(rate3.AmountPrice);
                                    }
                                    if (time == time3)
                                    {
                                        plan.Firstdayprice = rate3.AmountPrice;
                                    }
                                }
                                time = time.AddDays(1.0);
                            }
                            plan.Roomrate = list4;
                            plan.Averageprice = (num4 / ((double) days)).ToString("f1");
                            list3.Add(plan);
                        }
                    }
                    type2.Rateplan = list3;
                    list2.Add(type2);
                }
                item.Roomtypeinfo = list2;
                list.Add(item);
            }
            lvo.Singlehotel = list;
            return lvo;
        }

        public override object processResp(OTResponse response)
        {
            return this.getEasyI18NMultiHotels(response);
        }

        public override void setReq()
        {
            RoomStayCandidate candidate;
            GuestCount count;
            EasyI18NMultiHotelReqCondition basereqcondition = base.Basereqcondition as EasyI18NMultiHotelReqCondition;
            base.basereq = new TH_HotelMultiAvailRQ();
            ((TH_HotelMultiAvailRQ) base.basereq).setCheckInDate(basereqcondition.Checkindate);
            ((TH_HotelMultiAvailRQ) base.basereq).setCheckOutDate(basereqcondition.Checkoutdate);
            ((TH_HotelMultiAvailRQ) base.basereq).setHotelCityCode(basereqcondition.Citycode);
            ((TH_HotelMultiAvailRQ) base.basereq).setCountryCode(basereqcondition.Countrycode);
            HotelAvailCriteria hotelAvailCriteria = ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria;
            if (basereqcondition.Maxrate != 0)
            {
                hotelAvailCriteria.RateRange.MaxRate = basereqcondition.Maxrate.ToString();
            }
            if (basereqcondition.Minrate != 0)
            {
                hotelAvailCriteria.RateRange.MinRate = basereqcondition.Minrate.ToString();
            }
            if (!string.IsNullOrEmpty(basereqcondition.Englishname))
            {
                hotelAvailCriteria.HotelSearchCriteria.HotelRef.HotelEnglishName = basereqcondition.Englishname;
            }
            if (basereqcondition.Bedtype.Equals("SB"))
            {
                candidate = new RoomStayCandidate {
                    BedType = basereqcondition.Bedtype,
                    Quantity = basereqcondition.Roomnum.ToString()
                };
                count = new GuestCount {
                    AgeQualifyingCode = "1",
                    Count = basereqcondition.Adultnum.ToString()
                };
                candidate.GuestCounts.Add(count);
                count = new GuestCount {
                    AgeQualifyingCode = "0",
                    Count = basereqcondition.Childnum.ToString()
                };
                candidate.GuestCounts.Add(count);
                hotelAvailCriteria.HotelSearchCriteria.RoomStayCandidates.Add(candidate);
            }
            else
            {
                candidate = new RoomStayCandidate {
                    BedType = basereqcondition.Bedtype,
                    Quantity = basereqcondition.Roomnum.ToString()
                };
                count = new GuestCount {
                    AgeQualifyingCode = "1",
                    Count = basereqcondition.Adultnum.ToString()
                };
                candidate.GuestCounts.Add(count);
                count = new GuestCount {
                    AgeQualifyingCode = "0",
                    Count = basereqcondition.Childnum.ToString()
                };
                candidate.GuestCounts.Add(count);
                hotelAvailCriteria.HotelSearchCriteria.RoomStayCandidates.Add(candidate);
            }
            hotelAvailCriteria.ReqPageInfo.ReqNumOfEachPage = basereqcondition.Pagesize.ToString();
            hotelAvailCriteria.ReqPageInfo.ReqPageNo = basereqcondition.Pageno.ToString();
            hotelAvailCriteria.ReqPageInfo.IsPageView = "Y";
            hotelAvailCriteria.AvailReqType = "noneStatics";
            hotelAvailCriteria.CRSPath = "TIH";
            ((TH_HotelMultiAvailRQ) base.basereq).OtRequest.Header.Application = "hotelbeIh";
            RatePlanCandidate item = new RatePlanCandidate();
            Vendor vendor = new Vendor {
                VendorCode = "HRS"
            };
            item.VendorsIncluded.Add(vendor);
            ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.RatePlanCandidates.Add(item);
        }
    }
}

