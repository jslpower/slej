namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelCheckSearchRQ
    {
        private string checkStatus;
        private com.travelsky.hotelbesdk.models.DateSearchCriteria dateSearchCriteria;
        private com.travelsky.hotelbesdk.models.HotelSearchCriteria hotelSearchCriteria;
        private string includingDetail;
        private com.travelsky.hotelbesdk.models.ReqPageInfo reqPageInfo;
        private List<ResID> resIDs = new List<ResID>();

        public string CheckStatus
        {
            get
            {
                return this.checkStatus;
            }
            set
            {
                this.checkStatus = value;
            }
        }

        public com.travelsky.hotelbesdk.models.DateSearchCriteria DateSearchCriteria
        {
            get
            {
                return this.dateSearchCriteria;
            }
            set
            {
                this.dateSearchCriteria = value;
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

        public string IncludingDetail
        {
            get
            {
                return this.includingDetail;
            }
            set
            {
                this.includingDetail = value;
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

        public List<ResID> ResIDs
        {
            get
            {
                return this.resIDs;
            }
            set
            {
                this.resIDs = value;
            }
        }
    }
}

