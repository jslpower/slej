namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelCheckSearchRS
    {
        private List<Error> errors;
        private List<HotelCheckInfo> hotelCheckInfos;
        private com.travelsky.hotelbesdk.models.RespPageInfo respPageInfo;

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

        public List<HotelCheckInfo> HotelCheckInfos
        {
            get
            {
                return this.hotelCheckInfos;
            }
            set
            {
                this.hotelCheckInfos = value;
            }
        }

        public com.travelsky.hotelbesdk.models.RespPageInfo RespPageInfo
        {
            get
            {
                return this.respPageInfo;
            }
            set
            {
                this.respPageInfo = value;
            }
        }
    }
}

