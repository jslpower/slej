namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.models.easyhotel.order;
    using com.travelsky.hotelbesdk.utils;
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class OrderHotelReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
            OrderHotelReqCondition basereqcondition = base.Basereqcondition as OrderHotelReqCondition;
            string pattern = "[0-9]{4}-[0-9]{2}-[0-9]{2}";
            if (!string.IsNullOrEmpty(basereqcondition.Payment) && ((basereqcondition.Payment.Trim().ToUpper() != "T") && (basereqcondition.Payment.Trim().ToUpper() != "S")))
            {
                throw new HotelbeException("支付方式填写错误!");
            }
            if (string.IsNullOrEmpty(basereqcondition.Checkindate))
            {
                throw new HotelbeException("入住时间不能为空!");
            }
            if (string.IsNullOrEmpty(basereqcondition.Checkoutdate))
            {
                throw new HotelbeException("离店时间不能为空!");
            }
            if (!Regex.IsMatch(basereqcondition.Checkindate, pattern))
            {
                throw new HotelbeException("入住时间格式错误!");
            }
            if (!Regex.IsMatch(basereqcondition.Checkoutdate, pattern))
            {
                throw new HotelbeException("入住时间格式错误!");
            }
            if (string.IsNullOrEmpty(basereqcondition.Earlyarrivetime))
            {
                throw new HotelbeException("最早到达时间不能为空!");
            }
            if (basereqcondition.Earlyarrivetime.Length != 4)
            {
                throw new HotelbeException("最早到达时间格式错误!");
            }
            if (string.IsNullOrEmpty(basereqcondition.Latearrivetime))
            {
                throw new HotelbeException("最晚到达时间不能为空!");
            }
            if (basereqcondition.Latearrivetime.Length != 4)
            {
                throw new HotelbeException("最晚到达时间格式错误!");
            }
            DateTime time = DateTime.Parse(basereqcondition.Checkindate);
            DateTime time2 = DateTime.Parse(basereqcondition.Checkoutdate);
            if (time >= time2)
            {
                throw new HotelbeException("入住日期必须小于离店日期!");
            }
            if (DateTime.Parse(basereqcondition.Checkindate) >= DateTime.Parse(basereqcondition.Checkoutdate))
            {
                throw new HotelbeException("入住日期必须小于离店日期!");
            }
            if (DateTime.Parse(basereqcondition.Checkindate) < DateTime.Now.Date)
            {
                throw new HotelbeException("入住日期必须大于等于当前日期!");
            }
            if (string.IsNullOrEmpty(basereqcondition.Hotelcode))
            {
                throw new HotelbeException("酒店代码不能为空!");
            }
            if (!string.IsNullOrEmpty(basereqcondition.Contact.Contactemail))
            {
                string str2 = @"\w{1,}[@][\w\-]{1,}([.]([\w\-]{1,})){1,3}$";
                if (!Regex.IsMatch(basereqcondition.Contact.Contactemail, str2))
                {
                    throw new HotelbeException("联系人电子邮件格式错误!");
                }
            }
            if (string.IsNullOrEmpty(basereqcondition.Contact.Contactmobile))
            {
                throw new HotelbeException("联系人电话不能为空!");
            }
            if (string.IsNullOrEmpty(basereqcondition.Contact.Contactname))
            {
                throw new HotelbeException("联系人姓名不能为空!");
            }
            if (basereqcondition.Guests.Count == 0)
            {
                throw new HotelbeException("客人列表不能为空!");
            }
            foreach (string str3 in basereqcondition.Guests)
            {
                if (string.IsNullOrEmpty(str3))
                {
                    throw new HotelbeException("客人姓名不能为空!");
                }
            }
            if (basereqcondition.Roomprices.Count == 0)
            {
                throw new HotelbeException("房价列表不能为空!");
            }
            foreach (RoomPrice price in basereqcondition.Roomprices)
            {
                if (string.IsNullOrEmpty(price.Startdate))
                {
                    throw new HotelbeException("房价开始日期不能为空!");
                }
                if (string.IsNullOrEmpty(price.Enddate))
                {
                    throw new HotelbeException("房价结束日期不能为空!");
                }
                if (!Regex.IsMatch(price.Startdate, pattern))
                {
                    throw new HotelbeException("房价开始日期格式错误!");
                }
                if (!Regex.IsMatch(price.Enddate, pattern))
                {
                    throw new HotelbeException("房价结束日期格式错误!");
                }
                DateTime time3 = DateTime.Parse(price.Startdate);
                DateTime time4 = DateTime.Parse(price.Enddate);
                if (time3 >= time4)
                {
                    throw new HotelbeException("房价开始日期必须小于房价结束日期!");
                }
                if (string.IsNullOrEmpty(price.Rateplancode))
                {
                    throw new HotelbeException("价格计划不能为空!");
                }
                if (price.Roomnum == 0)
                {
                    throw new HotelbeException("房间数量不能为空!");
                }
                if (string.IsNullOrEmpty(price.Roomtypecode))
                {
                    throw new HotelbeException("房型代码不能为空!");
                }
            }
            if (basereqcondition.Guarantee)
            {
                HotelCreditCardInfo hotelcreditcardinfo = basereqcondition.Hotelcreditcardinfo;
                if (string.IsNullOrEmpty(hotelcreditcardinfo.CardNum))
                {
                    throw new HotelbeException("CardNum不能为空!");
                }
                if (string.IsNullOrEmpty(hotelcreditcardinfo.CVV2))
                {
                    throw new HotelbeException("CVV2不能为空!");
                }
                if (string.IsNullOrEmpty(hotelcreditcardinfo.ExpireDate))
                {
                    throw new HotelbeException("ExpireDate不能为空!");
                }
                if (string.IsNullOrEmpty(hotelcreditcardinfo.OwnerName))
                {
                    throw new HotelbeException("OwnerName不能为空!");
                }
            }
        }

        public override void setReq()
        {
            OrderHotelReqCondition basereqcondition = base.Basereqcondition as OrderHotelReqCondition;
            base.basereq = new TH_HotelResRQ();
            TH_HotelResRQ basereq = (TH_HotelResRQ) base.basereq;
            HotelReservation reservation = basereq.HotelResRQ.HotelReservations[0];
            ResGuest item = new ResGuest {
                Type = "gue"
            };
            StringBuilder builder = new StringBuilder();
            foreach (string str in basereqcondition.Guests)
            {
                builder.Append(str);
                builder.Append(",");
            }
            item.GuestProfile.PersonName = builder.ToString().Substring(0, builder.Length - 1);
            item.GuestProfile.Mobile = basereqcondition.Contact.Contactmobile;
            reservation.ResGuests.Add(item);
            ResGlobalInfo info = new ResGlobalInfo {
                ArriveEarlyTime = basereqcondition.Earlyarrivetime,
                ArriveLateTime = basereqcondition.Latearrivetime,
                GuestCount = builder.Length.ToString()
            };
            if (basereqcondition.getPayment() != null)
            {
                info.Payment = basereqcondition.Payment;
            }
            info.TimeSpan.StartDate = basereqcondition.Checkindate;
            info.TimeSpan.EndDate = basereqcondition.Checkoutdate;
            reservation.ResGlobalInfo = info;
            RoomStay stay = new RoomStay();
            reservation.RoomStays.Add(stay);
            stay.BasicProperty.HotelCode = basereqcondition.Hotelcode;
            stay.ArriveEarlyTime = basereqcondition.Earlyarrivetime;
            stay.SpecialRequest = basereqcondition.SpecialRequest;
            stay.ArriveLateTime = basereqcondition.Latearrivetime;
            stay.TimeSpan.StartDate = basereqcondition.Checkindate;
            stay.TimeSpan.EndDate = basereqcondition.Checkoutdate;
            ContactorInfo info2 = new ContactorInfo {
                Profile = { Email = basereqcondition.Contact.Contactemail, PersonName = basereqcondition.Contact.Contactname, Mobile = basereqcondition.Contact.Contactmobile }
            };
            if (!string.IsNullOrEmpty(basereqcondition.IsMobileContact) && "N".Equals(basereqcondition.IsMobileContact))
            {
                info2.IsMobileContact = "N";
            }
            if (!string.IsNullOrEmpty(basereqcondition.IsEmailContact) && "N".Equals(basereqcondition.IsEmailContact))
            {
                info2.IsEmailContact = "N";
            }
            info2.IsFaxContact = "N";
            info2.IsTelephoneContact = "N";
            reservation.ContactorInfo = info2;
            foreach (RoomPrice price in basereqcondition.Roomprices)
            {
                RoomRate rate = new RoomRate {
                    RatePlanCode = price.Rateplancode,
                    RoomTypeCode = price.Roomtypecode,
                    StartDate = price.Startdate,
                    EndDate = price.Enddate,
                    HotelCode = basereqcondition.Hotelcode,
                    VendorCode = price.VendorCode,
                    Quantity = price.Roomnum.ToString(),
                    CrsIndicator = "Y"
                };
                stay.RoomRates.Add(rate);
            }
            if (basereqcondition.Guarantee)
            {
                CreditCardInfo info3 = new CreditCardInfo {
                    CardNum = basereqcondition.Hotelcreditcardinfo.CardNum
                };
                string str2 = "";
                switch (basereqcondition.Hotelcreditcardinfo.getCardCode())
                {
                    case HotelCreditCardInfo.ENUM_CARDCODE.CORD_SHENFAZHAN:
                        str2 = "06";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_ZHONGGUO:
                        str2 = "07";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_GONGSHANG:
                        str2 = "08";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_JIANSHE:
                        str2 = "09";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_NONGYE:
                        str2 = "10";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_PUDONGFAZHAN:
                        str2 = "11";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_GUANGDONGFAZHAN:
                        str2 = "12";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_ZHAOSHANG:
                        str2 = "13";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_JIAOTONG:
                        str2 = "14";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_GUANGDA:
                        str2 = "15";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_HUAXIA:
                        str2 = "16";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_XINGYE:
                        str2 = "17";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_ZHONGXIN:
                        str2 = "18";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_MINSHENG:
                        str2 = "19";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_SHANGHAI:
                        str2 = "20";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_PINGAN:
                        str2 = "21";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_JCB:
                        str2 = "01";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_AE:
                        str2 = "02";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_MASTER:
                        str2 = "03";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_DC:
                        str2 = "04";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDCODE.CODE_VISA:
                        str2 = "05";
                        break;
                }
                info3.CardCode = str2;
                string str3 = "";
                switch (basereqcondition.Hotelcreditcardinfo.getCardType())
                {
                    case HotelCreditCardInfo.ENUM_CARDTYPE.TYPE_AX:
                        str3 = "AX";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDTYPE.TYPE_DN:
                        str3 = "DN";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDTYPE.TYPE_JC:
                        str3 = "JC";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDTYPE.TYPE_MC:
                        str3 = "MC";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDTYPE.TYPE_VI:
                        str3 = "VI";
                        break;

                    case HotelCreditCardInfo.ENUM_CARDTYPE.TYPE_UP:
                        str3 = "UP";
                        break;
                }
                info3.CardType = str3;
                info3.CVV2 = basereqcondition.Hotelcreditcardinfo.CVV2;
                info3.ExpireDate = basereqcondition.Hotelcreditcardinfo.ExpireDate;
                info3.OwnerName = basereqcondition.Hotelcreditcardinfo.OwnerName;
                info3.IDNum = basereqcondition.Hotelcreditcardinfo.IDNum;
                info3.Tel = basereqcondition.Hotelcreditcardinfo.Tel;
                if (HotelCreditCardInfo.ENUM_IDTYPE.IDTYPE_ID.Equals(basereqcondition.Hotelcreditcardinfo.IDType))
                {
                    info3.IDType = "01";
                }
                else if (HotelCreditCardInfo.ENUM_IDTYPE.IDTYPE_PASSPORT.Equals(basereqcondition.Hotelcreditcardinfo.IDType))
                {
                    info3.IDType = "02";
                }
                else if (HotelCreditCardInfo.ENUM_IDTYPE.IDTYPE_SOLDIER.Equals(basereqcondition.Hotelcreditcardinfo.IDType))
                {
                    info3.IDType = "03";
                }
                GuaranteeInfo info4 = new GuaranteeInfo();
                reservation.GuaranteeInfo = info4;
                info4.CreditCardInfo = info3;
                info4.GuaranteeType = "CRED";
                reservation.ResGlobalInfo.Guarantee = "CRED";
            }
        }
    }
}

