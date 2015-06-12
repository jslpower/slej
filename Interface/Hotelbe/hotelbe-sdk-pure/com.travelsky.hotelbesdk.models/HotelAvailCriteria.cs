namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class HotelAvailCriteria
    {
        private string availReqType;
        private string confirmRightNowIndicator;
        private string cRSPath;
        private com.travelsky.hotelbesdk.models.HotelSearchCriteria hotelSearchCriteria = new com.travelsky.hotelbesdk.models.HotelSearchCriteria();
        private string orderBy;
        private List<RatePlanCandidate> ratePlanCandidates = new List<RatePlanCandidate>();
        private com.travelsky.hotelbesdk.models.RateRange rateRange = new com.travelsky.hotelbesdk.models.RateRange();
        private com.travelsky.hotelbesdk.models.ReqPageInfo reqPageInfo = new com.travelsky.hotelbesdk.models.ReqPageInfo();
        private string roomTypeDetailShowed;
        private com.travelsky.hotelbesdk.models.StayDateRange stayDateRange = new com.travelsky.hotelbesdk.models.StayDateRange();

        public string getOrderBy()
        {
            return this.OrderBy;
        }

        public void setOrderBy(string orderBy)
        {
            this.OrderBy = orderBy;
        }

        [XmlAttribute("AvailReqType")]
        public string AvailReqType
        {
            get
            {
                return this.availReqType;
            }
            set
            {
                this.availReqType = value;
            }
        }

        public string ConfirmRightNowIndicator
        {
            get
            {
                return this.confirmRightNowIndicator;
            }
            set
            {
                this.confirmRightNowIndicator = value;
            }
        }

        public string CRSPath
        {
            get
            {
                return this.cRSPath;
            }
            set
            {
                this.cRSPath = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelSearchCriteria HotelSearchCriteria
        {
            get
            {
                return this.hotelSearchCriteria;
            }
            set
            {
                this.hotelSearchCriteria = value;
            }
        }

        public string OrderBy
        {
            get
            {
                return this.orderBy;
            }
            set
            {
                this.orderBy = value;
            }
        }

        public List<RatePlanCandidate> RatePlanCandidates
        {
            get
            {
                return this.ratePlanCandidates;
            }
            set
            {
                this.ratePlanCandidates = value;
            }
        }

        public com.travelsky.hotelbesdk.models.RateRange RateRange
        {
            get
            {
                return this.rateRange;
            }
            set
            {
                this.rateRange = value;
            }
        }

        public com.travelsky.hotelbesdk.models.ReqPageInfo ReqPageInfo
        {
            get
            {
                return this.reqPageInfo;
            }
            set
            {
                this.reqPageInfo = value;
            }
        }

        public string RoomTypeDetailShowed
        {
            get
            {
                return this.roomTypeDetailShowed;
            }
            set
            {
                this.roomTypeDetailShowed = value;
            }
        }

        public com.travelsky.hotelbesdk.models.StayDateRange StayDateRange
        {
            get
            {
                return this.stayDateRange;
            }
            set
            {
                this.stayDateRange = value;
            }
        }
    }
}

