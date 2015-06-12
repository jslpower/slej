namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.utils;
    using System;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    public abstract class HotelbeReq
    {
        protected BaseRQ basereq;
        private BaseReqCondition basereqcondition;

        protected HotelbeReq()
        {
        }

        public abstract void checkReq();
        public BaseReqCondition getBaseReqCondition()
        {
            return this.basereqcondition;
        }

        public virtual object processResp(OTResponse response)
        {
            return response;
        }

        public object send()
        {
            this.checkReq();
            if (this.basereqcondition.GetType() == typeof(PromotionHotelReqCondition))
            {
                return this.sendPromotionHotel();
            }
            this.setReq();
            string reqString = XDocument.Parse(Utils.Object2Xml<OTRequest>(this.basereq.OtRequest)).ToString();
            this.basereq.doRequest(reqString, this.basereqcondition.Log);
            this.request = this.basereq.request;
            this.response = this.basereq.response;
            return this.processResp(this.basereq.OtResponse);
        }

        private object sendPromotionHotel()
        {
            HashtableSerailizable serailizable = new HashtableSerailizable();
            PromotionHotelReqCondition basereqcondition = this.Basereqcondition as PromotionHotelReqCondition;
            foreach (string str in basereqcondition.City)
            {
                try
                {
                    TimeZone currentTimeZone = TimeZone.CurrentTimeZone;
                    DateTime now = DateTime.Now;
                    DateTime time2 = new DateTime(now.Year, now.Month, now.Day);
                    DateTime time3 = time2.AddDays(1.0);
                    string checkindate = time2.ToString("yyyy-MM-dd");
                    string checkoutdate = time3.ToString("yyyy-MM-dd");
                    HotelbeReq req = new EasyMultiHotelReqImpl();
                    EasyMultiHotelReqCondition condition2 = new EasyMultiHotelReqCondition();
                    condition2.setCheckindate(checkindate);
                    condition2.setCheckoutdate(checkoutdate);
                    condition2.setCitycode(str);
                    condition2.Pageno = 1;
                    condition2.Pagesize = basereqcondition.Size;
                    condition2.Showdetail = true;
                    condition2.Log = true;
                    req.Basereqcondition = condition2;
                    object obj2 = req.send();
                    serailizable.Add(str, obj2);
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (serailizable.Count < 1)
                    {
                        throw new HotelbeException("指令请求异常。。。");
                    }
                }
            }
            return serailizable;
        }

        public void setBasereqcondition(BaseReqCondition basereqcondition)
        {
            this.basereqcondition = basereqcondition;
        }

        public abstract void setReq();

        public BaseReqCondition Basereqcondition
        {
            get
            {
                return this.basereqcondition;
            }
            set
            {
                this.basereqcondition = value;
            }
        }

        public string request { get; set; }

        public string response { get; set; }
    }
}

