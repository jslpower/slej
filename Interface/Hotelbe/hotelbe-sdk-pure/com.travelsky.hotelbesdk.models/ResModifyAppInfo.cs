namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class ResModifyAppInfo
    {
        private string appDateTime;
        private string appID;
        private string applicant;
        private string appStatus;
        private com.travelsky.hotelbesdk.models.BasicProperty basicProperty;
        private com.travelsky.hotelbesdk.models.ContactorInfo contactorInfo;
        private com.travelsky.hotelbesdk.models.ResGlobalInfo resGlobalInfo;
        private List<ResGuest> resGuests;
        private string resID;
        private List<RoomRate> roomRates;
        private string specialRequest;
        private string subchannelTransCode;

        public string AppDateTime
        {
            get
            {
                return this.appDateTime;
            }
            set
            {
                this.appDateTime = value;
            }
        }

        public string AppID
        {
            get
            {
                return this.appID;
            }
            set
            {
                this.appID = value;
            }
        }

        public string Applicant
        {
            get
            {
                return this.applicant;
            }
            set
            {
                this.applicant = value;
            }
        }

        public string AppStatus
        {
            get
            {
                return this.appStatus;
            }
            set
            {
                this.appStatus = value;
            }
        }

        public com.travelsky.hotelbesdk.models.BasicProperty BasicProperty
        {
            get
            {
                return this.basicProperty;
            }
            set
            {
                this.basicProperty = value;
            }
        }

        public com.travelsky.hotelbesdk.models.ContactorInfo ContactorInfo
        {
            get
            {
                return this.contactorInfo;
            }
            set
            {
                this.contactorInfo = value;
            }
        }

        public com.travelsky.hotelbesdk.models.ResGlobalInfo ResGlobalInfo
        {
            get
            {
                return this.resGlobalInfo;
            }
            set
            {
                this.resGlobalInfo = value;
            }
        }

        public List<ResGuest> ResGuests
        {
            get
            {
                return this.resGuests;
            }
            set
            {
                this.resGuests = value;
            }
        }

        public string ResID
        {
            get
            {
                return this.resID;
            }
            set
            {
                this.resID = value;
            }
        }

        public List<RoomRate> RoomRates
        {
            get
            {
                return this.roomRates;
            }
            set
            {
                this.roomRates = value;
            }
        }

        public string SpecialRequest
        {
            get
            {
                return this.specialRequest;
            }
            set
            {
                this.specialRequest = value;
            }
        }

        public string SubchannelTransCode
        {
            get
            {
                return this.subchannelTransCode;
            }
            set
            {
                this.subchannelTransCode = value;
            }
        }
    }
}

