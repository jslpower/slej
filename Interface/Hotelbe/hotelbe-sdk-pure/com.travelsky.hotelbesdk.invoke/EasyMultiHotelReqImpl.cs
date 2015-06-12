namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.models.easyhotel.multi;
    using com.travelsky.hotelbesdk.utils;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class EasyMultiHotelReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
            EasyMultiHotelReqCondition basereqcondition = base.Basereqcondition as EasyMultiHotelReqCondition;
            if (string.IsNullOrEmpty(basereqcondition.getCheckindate()))
            {
                throw new HotelbeException("入住时间不能为空!");
            }
            if (string.IsNullOrEmpty(basereqcondition.getCheckoutdate()))
            {
                throw new HotelbeException("离店时间不能为空!");
            }
            string pattern = "[0-9]{4}-[0-9]{2}-[0-9]{2}";
            if (!Regex.IsMatch(basereqcondition.getCheckindate(), pattern))
            {
                throw new HotelbeException("入住时间格式错误!");
            }
            if (!Regex.IsMatch(basereqcondition.getCheckoutdate(), pattern))
            {
                throw new HotelbeException("离店时间格式错误!");
            }
            if (DateTime.Parse(basereqcondition.getCheckindate()) >= DateTime.Parse(basereqcondition.getCheckoutdate()))
            {
                throw new HotelbeException("入住日期必须小于离店日期!");
            }
            if (DateTime.Parse(basereqcondition.getCheckindate()) < DateTime.Now.Date)
            {
                throw new HotelbeException("入住日期必须大于等于当前日期!");
            }
            if (string.IsNullOrEmpty(basereqcondition.getCitycode()))
            {
                throw new HotelbeException("城市代码不能为空!");
            }
            if (basereqcondition.Pagesize == 0)
            {
                throw new HotelbeException("每页显示数量不能为空!");
            }
            if (basereqcondition.Pageno <= 0)
            {
                throw new HotelbeException("页码必须大于0!");
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

        private MultiHotelVO getEasyMultiHotels(OTResponse response)
        {
            EasyMultiHotelReqCondition basereqcondition = base.Basereqcondition as EasyMultiHotelReqCondition;
            DateTime time = DateTime.Parse(basereqcondition.getCheckindate());
            System.TimeSpan span = (System.TimeSpan) (DateTime.Parse(basereqcondition.getCheckoutdate()) - time);
            int days = span.Days;
            HotelAvailRS hotelAvailRS = response.HotelAvailRS;
            MultiHotelVO lvo = new MultiHotelVO {
                Multihotelinfo = { Checkindate = basereqcondition.getCheckindate(), Checkoutdate = basereqcondition.getCheckoutdate(), Citycode = basereqcondition.getCitycode() }
            };
            if (((response.Errors == null) || (response.Errors.Count < 1)) && ((response.HotelAvailRS.Errors == null) || (response.HotelAvailRS.Errors.Count < 1)))
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
                    HotelNameCN = stay.BasicProperty.HotelName,
                    HotelNameEN = stay.BasicProperty.HotelEnglishName,
                    Minrate = stay.BasicProperty.MinRate,
                    Maxrate = stay.BasicProperty.MaxRate,
                    Address = stay.BasicProperty.Address,
                    PositionDesc = stay.BasicProperty.POR,
                    HotelCode = stay.BasicProperty.HotelCode,
                    LongDesc = stay.BasicProperty.LongDesc,
                    Floor = stay.BasicProperty.Floor
                };
                double num2 = Convert.ToDouble(stay.BasicProperty.Position.Longitude);
                double num3 = Convert.ToDouble(stay.BasicProperty.Position.Latitude);
                info.Longitude = string.Format("{0:0.000}", num2);
                info.Latitude = string.Format("{0:0.000}", num3);
                HashtableSerailizable serailizable = new HashtableSerailizable();
                foreach (Image image in stay.BasicProperty.Images)
                {
                    DictionaryEntry entry;
                    string str = "http://media.sohoto.com/market/images/hotelimages";
                    str = image.URL.StartsWith(str) ? "" : str;
                    if (image.Category.Equals("DT"))
                    {
                        entry = new DictionaryEntry {
                            Key = "DT",
                            Value = str + image.URL
                        };
                        info.Images.Add(entry);
                    }
                    else if (image.Category.Equals("WJ"))
                    {
                        entry = new DictionaryEntry {
                            Key = "WJ",
                            Value = str + image.URL
                        };
                        info.Images.Add(entry);
                    }
                    else if (image.Category.Equals("KF"))
                    {
                        entry = new DictionaryEntry {
                            Key = "KF",
                            Value = str + image.URL
                        };
                        info.Images.Add(entry);
                    }
                }
                item.Basichotelinfo = info;
                List<com.travelsky.hotelbesdk.models.easyhotel.multi.HotelRoomType> list2 = new List<com.travelsky.hotelbesdk.models.easyhotel.multi.HotelRoomType>();
                foreach (RoomType type in stay.RoomTypes)
                {
                    com.travelsky.hotelbesdk.models.easyhotel.multi.HotelRoomType type2 = new com.travelsky.hotelbesdk.models.easyhotel.multi.HotelRoomType {
                        Roomtypename = type.RoomTypeName,
                        Roomtypecode = type.RoomTypeCode
                    };
                    if (type.RoomDescription != null)
                    {
                        type2.Desc = type.RoomDescription;
                    }
                    List<HotelRatePlan> list3 = new List<HotelRatePlan>();
                    foreach (RoomRate rate in stay.RoomRates)
                    {
                        if (rate.RoomTypeCode.Equals(type.RoomTypeCode))
                        {
                            HotelRatePlan plan = new HotelRatePlan {
                                Paymentmethod = rate.Payment,
                                Vendor = rate.VendorCode,
                                AvailabilityStatus = rate.AvailabilityStatus,
                                Rateplancode = rate.RatePlanCode,
                                Internet = rate.Internet
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
                            type2.Marketprice = rate2.AmountPrice;
                            plan.Meal = rate2.FreeMeal;
                            List<HotelRoomRate> list4 = new List<HotelRoomRate>();
                            double num4 = 0.0;
                            time = DateTime.Parse(basereqcondition.getCheckindate());
                            DateTime time2 = DateTime.Parse(basereqcondition.getCheckoutdate());
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
            return this.getEasyMultiHotels(response);
        }

        public override void setReq()
        {
            EasyMultiHotelReqCondition basereqcondition = base.Basereqcondition as EasyMultiHotelReqCondition;
            base.basereq = new TH_HotelMultiAvailRQ();
            ((TH_HotelMultiAvailRQ) base.basereq).setCheckInDate(basereqcondition.getCheckindate());
            ((TH_HotelMultiAvailRQ) base.basereq).setCheckOutDate(basereqcondition.getCheckoutdate());
            ((TH_HotelMultiAvailRQ) base.basereq).setHotelCityCode(basereqcondition.getCitycode());
            if (EasyMultiHotelReqCondition.ENUM_INCLUDETEST.INCLUDING_Y.Equals(basereqcondition.Including))
            {
                ((TH_HotelMultiAvailRQ) base.basereq).setIncludingTest("Y");
            }
            else
            {
                ((TH_HotelMultiAvailRQ) base.basereq).setIncludingTest("N");
            }
            if (basereqcondition.getOrder().Equals(EasyMultiHotelReqCondition.ENUM_ORDER.ORDER_PRICEASC))
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.setOrderBy("PRICELTH");
            }
            else if (basereqcondition.getOrder().Equals(EasyMultiHotelReqCondition.ENUM_ORDER.ORDER_PRICEDESC))
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.setOrderBy("PRICEHTL");
            }
            else if (basereqcondition.getOrder().Equals(EasyMultiHotelReqCondition.ENUM_ORDER.ORDER_RANKASC))
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.setOrderBy("STARLTH");
            }
            else if (basereqcondition.getOrder().Equals(EasyMultiHotelReqCondition.ENUM_ORDER.ORDER_RANKDESC))
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.setOrderBy("STARHTL");
            }
            if (!string.IsNullOrEmpty(basereqcondition.getRank().ToString()) && !basereqcondition.getRank().ToString().Equals("rank_null"))
            {
                string str = "";
                if (basereqcondition.getRank().Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_1))
                {
                    str = "1";
                }
                else if (basereqcondition.getRank().Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_2))
                {
                    str = "2";
                }
                else if (basereqcondition.getRank().Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_3))
                {
                    str = "3";
                }
                else if (basereqcondition.getRank().Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_4))
                {
                    str = "4";
                }
                else if (basereqcondition.getRank().Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_5))
                {
                    str = "5";
                }
                else if (basereqcondition.getRank().Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_1S))
                {
                    str = "1S";
                }
                else if (basereqcondition.getRank().Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_2S))
                {
                    str = "2S";
                }
                else if (basereqcondition.getRank().Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_3S))
                {
                    str = "3S";
                }
                else if (basereqcondition.getRank().Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_4S))
                {
                    str = "4S";
                }
                else if (basereqcondition.getRank().Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_5S))
                {
                    str = "5S";
                }
                else if (basereqcondition.getRank().Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_1A))
                {
                    str = "1A";
                }
                else if (basereqcondition.getRank().Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_2A))
                {
                    str = "2A";
                }
                else if (basereqcondition.getRank().Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_3A))
                {
                    str = "3A";
                }
                else if (basereqcondition.getRank().Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_4A))
                {
                    str = "4A";
                }
                else if (basereqcondition.getRank().Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_5A))
                {
                    str = "5A";
                }
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.HotelSearchCriteria.Rank = str;
            }
            if (!string.IsNullOrEmpty(basereqcondition.getPayment()) || !string.IsNullOrEmpty(basereqcondition.IsDefinedChannel))
            {
                RatePlanCandidate candidate = new RatePlanCandidate();
                if (!string.IsNullOrEmpty(basereqcondition.getPayment()))
                {
                    candidate.Payment = basereqcondition.getPayment();
                }
                if (!string.IsNullOrEmpty(basereqcondition.IsDefinedChannel))
                {
                    candidate.IsDefinedChannel = basereqcondition.IsDefinedChannel;
                }
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.RatePlanCandidates.Add(candidate);
            }
            if (basereqcondition.Maxrate != 0)
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.RateRange.MaxRate = basereqcondition.Maxrate.ToString();
            }
            if (basereqcondition.Minrate != 0)
            {
                ((TH_HotelMultiAvailRQ)base.basereq).HotelAvailRQ.HotelAvailCriteria.RateRange.MinRate = basereqcondition.Minrate.ToString();
            }
            if (!string.IsNullOrEmpty(basereqcondition.Chinesename))
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.HotelSearchCriteria.HotelRef.HotelChineseName = basereqcondition.Chinesename;
            }
            if (!string.IsNullOrEmpty(basereqcondition.Englishname))
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.HotelSearchCriteria.HotelRef.HotelEnglishName = basereqcondition.Englishname;
            }
            if (!string.IsNullOrEmpty(basereqcondition.getRank().ToString()))
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.HotelSearchCriteria.Rank = FunctionHelper.getRank(basereqcondition.getRank());
            }
            if (!string.IsNullOrEmpty(basereqcondition.LandMark))
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.HotelSearchCriteria.LandMark = basereqcondition.LandMark;
            }
            if (!string.IsNullOrEmpty(basereqcondition.District))
            {
                ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.HotelSearchCriteria.HotelRef.District = basereqcondition.District;
            }
            ((TH_HotelMultiAvailRQ)base.basereq).HotelAvailRQ.HotelAvailCriteria.ReqPageInfo.ReqNumOfEachPage = basereqcondition.Pagesize.ToString();
            ((TH_HotelMultiAvailRQ)base.basereq).HotelAvailRQ.HotelAvailCriteria.ReqPageInfo.ReqPageNo = basereqcondition.Pageno.ToString();
            ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.ReqPageInfo.IsPageView = "Y";
            ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.RoomTypeDetailShowed = basereqcondition.Showdetail ? "Y" : "N";
            RatePlanCandidate item = new RatePlanCandidate();
            if (basereqcondition.Vendorcodes != null)
            {
                foreach (string str2 in basereqcondition.Vendorcodes)
                {
                    Vendor vendor = new Vendor {
                        VendorCode = str2
                    };
                    item.VendorsIncluded.Add(vendor);
                }
            }
            ((TH_HotelMultiAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.RatePlanCandidates.Add(item);
        }
    }
}

