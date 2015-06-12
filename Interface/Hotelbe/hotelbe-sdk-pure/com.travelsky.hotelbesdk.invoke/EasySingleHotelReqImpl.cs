namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using com.travelsky.hotelbesdk.models.basicproperty;
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.models.easyhotel.single;
    using com.travelsky.hotelbesdk.utils;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class EasySingleHotelReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
            EasySingleHotelReqCondition basereqcondition = base.Basereqcondition as EasySingleHotelReqCondition;
            DateTime time = Convert.ToDateTime(basereqcondition.getCheckindate());
            DateTime time2 = Convert.ToDateTime(basereqcondition.getCheckoutdate());
            if (string.IsNullOrEmpty(basereqcondition.Checkindate))
            {
                throw new HotelbeException("入住时间不能为空!");
            }
            if (string.IsNullOrEmpty(basereqcondition.Checkoutdate))
            {
                throw new HotelbeException("离店时间不能为空!");
            }
            if (time.AddDays(30.0).CompareTo(time2) < 0)
            {
                throw new HotelbeException("时间间隔不能大于30天");
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

        private SingleHotelVO getEasySingleHotel(OTResponse response)
        {
            EasySingleHotelReqCondition basereqcondition = base.Basereqcondition as EasySingleHotelReqCondition;
            DateTime time = DateTime.Parse(basereqcondition.Checkindate);
            DateTime time2 = DateTime.Parse(basereqcondition.Checkoutdate);
            System.TimeSpan span = (System.TimeSpan) (time2 - time);
            int days = span.Days;
            HotelAvailRS hotelAvailRS = response.HotelAvailRS;
            SingleHotelVO lvo = new SingleHotelVO {
                Singlehotelinfo = { Checkindate = basereqcondition.Checkindate, Checkoutdate = basereqcondition.Checkoutdate, Hotelcode = basereqcondition.Hotelcode }
            };
            if ((response.Errors == null) || (response.Errors.Count < 1))
            {
                lvo.Singlehotelinfo.Status = true;
            }
            else
            {
                lvo.Singlehotelinfo.Status = true;
                return lvo;
            }
            SingleHotel hotel = new SingleHotel();
            if ((hotelAvailRS.RoomStays != null) && (hotelAvailRS.RoomStays.Count<RoomStay>() > 0))
            {
                RoomStay stay = hotelAvailRS.RoomStays[0];
                BasicHotelInfo info = new BasicHotelInfo {
                    RankCode = stay.BasicProperty.Rank,
                    Tel = stay.BasicProperty.Tel,
                    FixDate = stay.BasicProperty.Fitment,
                    OpenDate = stay.BasicProperty.Opendate,
                    HotelNameCN = stay.BasicProperty.HotelName,
                    HotelNameEN = stay.BasicProperty.HotelEnglishName,
                    Minrate = stay.BasicProperty.MinRate,
                    Maxrate = stay.BasicProperty.MaxRate,
                    Address = stay.BasicProperty.Address,
                    PositionDesc = stay.BasicProperty.POR,
                    HotelCode = stay.BasicProperty.HotelCode,
                    LongDesc = stay.BasicProperty.LongDesc,
                    Floor = stay.BasicProperty.Floor,
                    HotelTrafficInfos = new List<com.travelsky.hotelbesdk.models.easyhotel.single.HotelTrafficInfo>()
                };
                if ((stay.BasicProperty.RelativePositions != null) && (stay.BasicProperty.RelativePositions.Count > 0))
                {
                    foreach (RelativePosition position in stay.BasicProperty.RelativePositions)
                    {
                        if (position.Type.Equals("TRA"))
                        {
                            com.travelsky.hotelbesdk.models.easyhotel.single.HotelTrafficInfo item = new com.travelsky.hotelbesdk.models.easyhotel.single.HotelTrafficInfo {
                                CarInterval = position.Transportation.CarInterval,
                                FootInterval = position.Transportation.FootInterval,
                                Distance = position.Distance,
                                TrafficName = position.ShortDesc
                            };
                            info.HotelTrafficInfos.Add(item);
                        }
                    }
                }
                if ((stay.BasicProperty.Images != null) && (stay.BasicProperty.Images.Count > 0))
                {
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
                }
                if (stay.BasicProperty.AcceptedPayments != null)
                {
                    foreach (AcceptedPayment payment in stay.BasicProperty.AcceptedPayments)
                    {
                        com.travelsky.hotelbesdk.models.easyhotel.single.HotelAcceptedPayment payment2 = new com.travelsky.hotelbesdk.models.easyhotel.single.HotelAcceptedPayment {
                            Cardcode = payment.PaymentCard.CardCode,
                            Cardname = payment.PaymentCard.CardName
                        };
                        info.HotelAcceptedPayments.Add(payment2);
                    }
                }
                if (stay.BasicProperty.HotelAmenities != null)
                {
                    foreach (com.travelsky.hotelbesdk.models.HotelAmenity amenity in stay.BasicProperty.HotelAmenities)
                    {
                        com.travelsky.hotelbesdk.models.easyhotel.single.HotelAmenity amenity2 = new com.travelsky.hotelbesdk.models.easyhotel.single.HotelAmenity {
                            Amenitytype = amenity.AmenityType,
                            Amenityname = amenity.AmenityName
                        };
                        info.HotelAmenities.Add(amenity2);
                    }
                }
                hotel.Basichotelinfo = info;
                List<com.travelsky.hotelbesdk.models.easyhotel.single.HotelRoomType> list = new List<com.travelsky.hotelbesdk.models.easyhotel.single.HotelRoomType>();
                if (stay.RoomTypes != null)
                {
                    foreach (RoomType type in stay.RoomTypes)
                    {
                        com.travelsky.hotelbesdk.models.easyhotel.single.HotelRoomType type2 = new com.travelsky.hotelbesdk.models.easyhotel.single.HotelRoomType {
                            Roomtypename = type.RoomTypeName,
                            Roomtypecode = type.RoomTypeCode,
                            Bedtype = type.BedType
                        };
                        if (type.RoomDescription != null)
                        {
                            type2.Desc = type.RoomDescription;
                        }
                        List<HotelRatePlan> list2 = new List<HotelRatePlan>();
                        if (stay.RoomRates != null)
                        {
                            foreach (RoomRate rate in stay.RoomRates)
                            {
                                if (rate.RoomTypeCode.Equals(type.RoomTypeCode))
                                {
                                    HotelRatePlan plan = new HotelRatePlan();
                                    if (rate.GuaranteePolicies != null)
                                    {
                                        foreach (GuaranteePolicy policy in rate.GuaranteePolicies)
                                        {
                                            HotelGuaranteePolicy policy2 = new HotelGuaranteePolicy {
                                                FeeValue = policy.FeeValue,
                                                FeeValue2 = policy.FeeValue2,
                                                FeeValue3 = policy.FeeValue3,
                                                DaysOfStay = policy.DaysOfStay,
                                                DaysOfStay2 = policy.DaysOfStay2,
                                                DaysOfStay3 = policy.DaysOfStay3,
                                                GuaranteeDate = policy.GuaranteeDate,
                                                GuaranteeDate2 = policy.GuaranteeDate2,
                                                GuaranteeDate3 = policy.GuaranteeDate3,
                                                GuaranteeMethod = policy.GuaranteeMethod,
                                                GuaranteeType = policy.GuaranteeType,
                                                HoldTime = policy.HoldTime,
                                                HoldTime2 = policy.HoldTime2,
                                                HoldTime3 = policy.HoldTime3,
                                                NumOfRoom = policy.NumOfRoom,
                                                NumOfRoom2 = policy.NumOfRoom2,
                                                NumOfRoom3 = policy.NumOfRoom3,
                                                PolicyCode = policy.PolicyCode,
                                                PolicyType = policy.PolicyType,
                                                ShortDesc = policy.ShortDesc,
                                                LongDesc = policy.LongDesc,
                                                Status = policy.Status,
                                                UnitOfFee = policy.UnitOfFee
                                            };
                                            plan.Hotelguaranteepolicy.Add(policy2);
                                        }
                                    }
                                    if (rate.CancelPolicies != null)
                                    {
                                        foreach (CancelPolicy policy3 in rate.CancelPolicies)
                                        {
                                            HotelCancelPolicie policie = new HotelCancelPolicie {
                                                EndDate = policy3.EndDate,
                                                FeeValue1 = policy3.FeeValue1,
                                                FeeValue2 = policy3.FeeValue2,
                                                FeeValue3 = policy3.FeeValue3,
                                                HotelCode = policy3.HotelCode,
                                                LongDesc = policy3.LongDesc,
                                                PeriodDate1 = policy3.PeriodDate1,
                                                PeriodDate2 = policy3.PeriodDate2,
                                                PeriodDate3 = policy3.PeriodDate3,
                                                PolicyCode = policy3.PolicyCode,
                                                PolicyType = policy3.PolicyType,
                                                RatePlanCode = policy3.RatePlanCode,
                                                RoomTypeCode = policy3.RoomTypeCode,
                                                ShortDesc = policy3.ShortDesc,
                                                StartDate = policy3.StartDate,
                                                Status = policy3.Status,
                                                UnitOfFee1 = policy3.UnitOfFee1,
                                                UnitOfFee2 = policy3.UnitOfFee2,
                                                UnitOfFee3 = policy3.UnitOfFee3,
                                                VendorCode = policy3.VendorCode
                                            };
                                            plan.CancelPolicies.Add(policie);
                                        }
                                    }
                                    if (rate.BookingPolicies != null)
                                    {
                                        foreach (BookingPolicy policy4 in rate.BookingPolicies)
                                        {
                                            HotelBookingPolicy policy5 = new HotelBookingPolicy {
                                                EndDate = policy4.EndDate,
                                                HotelCode = policy4.HotelCode,
                                                LongDesc = policy4.LongDesc,
                                                PolicyCode = policy4.PolicyCode,
                                                PolicyType = policy4.PolicyType,
                                                RatePlanCode = policy4.RatePlanCode,
                                                RoomTypeCode = policy4.RoomTypeCode,
                                                ShortDesc = policy4.ShortDesc,
                                                StartDate = policy4.StartDate,
                                                Status = policy4.Status,
                                                VendorCode = policy4.VendorCode
                                            };
                                            plan.BookingPolicys.Add(policy5);
                                        }
                                    }
                                    if (rate.FavourPolicies != null)
                                    {
                                        foreach (FavourPolicy policy6 in rate.FavourPolicies)
                                        {
                                            HotelFavourPolicy policy7 = new HotelFavourPolicy {
                                                EndDate = policy6.EndDate,
                                                HotelCode = policy6.HotelCode,
                                                LongDesc = policy6.LongDesc,
                                                PolicyCode = policy6.PolicyCode,
                                                PolicyType = policy6.PolicyType,
                                                RatePlanCode = policy6.RatePlanCode,
                                                RoomTypeCode = policy6.RoomTypeCode,
                                                ShortDesc = policy6.ShortDesc,
                                                StartDate = policy6.StartDate,
                                                Status = policy6.Status,
                                                VendorCode = policy6.VendorCode
                                            };
                                            plan.FavourPolicys.Add(policy7);
                                        }
                                    }
                                    plan.Vendor = rate.VendorCode;
                                    plan.Paymentmethod = rate.Payment;
                                    plan.Rateplancode = rate.RatePlanCode;
                                    plan.Rateplanname = rate.RatePlanName;
                                    plan.Internet = rate.Internet;
                                    plan.AvailabilityStatus = rate.AvailabilityStatus;
                                    Rate rate2 = rate.Rates[0];
                                    type2.Marketprice = rate2.AmountPrice;
                                    plan.Meal = rate2.FreeMeal;
                                    List<HotelRoomRate> list3 = new List<HotelRoomRate>();
                                    double num2 = 0.0;
                                    for (time = DateTime.Parse(basereqcondition.Checkindate); time < time2; time = time.AddDays(1.0))
                                    {
                                        foreach (Rate rate3 in rate.Rates)
                                        {
                                            DateTime time3 = DateTime.Parse(rate3.StartDate);
                                            DateTime time4 = DateTime.Parse(rate3.EndDate);
                                            if ((time >= time3) && (time <= time4))
                                            {
                                                HotelRoomRate rate4 = new HotelRoomRate {
                                                    Date = time.ToString("yyyy-MM-dd"),
                                                    Price = rate3.AmountPrice,
                                                    Fee = rate3.Fee,
                                                    FeeFix = rate3.FeeFix
                                                };
                                                if (rate.Commissions != null)
                                                {
                                                    foreach (Commission commission in rate.Commissions)
                                                    {
                                                        DateTime time5 = DateTime.Parse(commission.StartDate);
                                                        DateTime time6 = DateTime.Parse(commission.EndDate);
                                                        if ((commission.RatePlanCode.Equals(plan.Rateplancode) && (time.CompareTo(time5) >= 0)) && (time.CompareTo(time6) <= 0))
                                                        {
                                                            HotelCommission commission2 = new HotelCommission();
                                                            if ("S".Equals(rate.Payment))
                                                            {
                                                                commission2.Fix = "0.0";
                                                                commission2.Percent = "0.0";
                                                            }
                                                            else if ("T".Equals(rate.Payment))
                                                            {
                                                                commission2.Type = commission.CommissionType;
                                                                commission2.Tax = commission.Tax;
                                                                if (!(!"FIX".Equals(commission.CommissionType) && "0.0".Equals(commission.Fix)))
                                                                {
                                                                    commission2.Fix = commission.Fix;
                                                                    double num3 = Convert.ToDouble(commission.Fix) / Convert.ToDouble(rate2.AmountBeforeTax);
                                                                    commission2.Percent = string.Format("{0:0.00}", num3);
                                                                }
                                                                else if (!(!"PCT".Equals(commission.CommissionType) && "0.0".Equals(commission.Percent)))
                                                                {
                                                                    commission2.Percent = commission.Percent;
                                                                    double num4 = Convert.ToDouble(commission.Percent) * Convert.ToDouble(rate2.AmountBeforeTax);
                                                                    commission2.Fix = string.Format("{0:0.00}", num4);
                                                                }
                                                            }
                                                            rate4.Hotelcommission = commission2;
                                                        }
                                                    }
                                                }
                                                rate4.FeePercent = rate3.FeePercent;
                                                list3.Add(rate4);
                                                num2 += double.Parse(rate3.AmountPrice);
                                            }
                                            if (time == time3)
                                            {
                                                plan.Firstdayprice = rate3.AmountPrice;
                                            }
                                        }
                                    }
                                    plan.Roomrate = list3;
                                    plan.Averageprice = (num2 / ((double) days)).ToString();
                                    list2.Add(plan);
                                }
                            }
                        }
                        type2.Rateplan = list2;
                        list.Add(type2);
                    }
                }
                hotel.Roomtypeinfo = list;
                lvo.Singlehotel = hotel;
            }
            return lvo;
        }

        public override object processResp(OTResponse response)
        {
            return this.getEasySingleHotel(response);
        }

        public override void setReq()
        {
            EasySingleHotelReqCondition basereqcondition = base.Basereqcondition as EasySingleHotelReqCondition;
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
            item.RatePlanCode = basereqcondition.RatePlanCode;
            ((TH_HotelSingleAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.RatePlanCandidates.Add(item);
            EasySingleHotelReqCondition.ENUM_REQ availReqType = basereqcondition.AvailReqType;
            bool flag = 1 == 0;
            if (EasySingleHotelReqCondition.ENUM_REQ.REQ_NONE.Equals(basereqcondition.AvailReqType))
            {
                ((TH_HotelSingleAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.AvailReqType = "noneStatics";
            }
            else if (EasySingleHotelReqCondition.ENUM_REQ.REQ_INCLUDE.Equals(basereqcondition.AvailReqType))
            {
                ((TH_HotelSingleAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.AvailReqType = "includeStatic";
            }
            EasySingleHotelReqCondition.ENUM_PAYMENT payment = basereqcondition.Payment;
            flag = 1 == 0;
            if (basereqcondition.Payment.Equals(EasySingleHotelReqCondition.ENUM_PAYMENT.PAYMENT_COUNTER))
            {
                item.Payment = "T";
                ((TH_HotelSingleAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.RatePlanCandidates.Add(item);
            }
            else if (basereqcondition.Payment.Equals(EasySingleHotelReqCondition.ENUM_PAYMENT.PAYMENT_ADVANCED))
            {
                item.Payment = "S";
                ((TH_HotelSingleAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.RatePlanCandidates.Add(item);
            }
            else if (basereqcondition.Payment.Equals(EasySingleHotelReqCondition.ENUM_PAYMENT.PAYMENT_ALL))
            {
            }
            RoomStayCandidate candidate2 = new RoomStayCandidate {
                RoomTypeCode = basereqcondition.RoomTypeCode
            };
            ((TH_HotelSingleAvailRQ) base.basereq).HotelAvailRQ.HotelAvailCriteria.HotelSearchCriteria.RoomStayCandidates.Add(candidate2);
        }
    }
}

