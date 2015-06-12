namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelResModifyRS
    {
        private List<Error> errors;
        private Warnings qarnings;
        private List<ResModifyAppInfo> resModifyAppInfos;
        private com.travelsky.hotelbesdk.models.Success success;

        public List<Error> Errors
        {
            get
            {
                return this.errors;
            }
            set
            {
                this.errors = value;
            }
        }

        public Warnings Qarnings
        {
            get
            {
                return this.qarnings;
            }
            set
            {
                this.qarnings = value;
            }
        }

        private List<ResModifyAppInfo> ResModifyAppInfos
        {
            get
            {
                return this.resModifyAppInfos;
            }
            set
            {
                this.resModifyAppInfos = value;
            }
        }

        public com.travelsky.hotelbesdk.models.Success Success
        {
            get
            {
                return this.success;
            }
            set
            {
                this.success = value;
            }
        }
    }
}

