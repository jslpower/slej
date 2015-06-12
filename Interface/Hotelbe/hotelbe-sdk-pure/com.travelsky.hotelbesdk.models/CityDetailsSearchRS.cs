namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class CityDetailsSearchRS
    {
        private List<CityInfo> cityInfos;
        private com.travelsky.hotelbesdk.models.Success success;
        private com.travelsky.hotelbesdk.models.Warnings warnings;

        public List<CityInfo> CityInfos
        {
            get
            {
                return this.cityInfos;
            }
            set
            {
                this.cityInfos = value;
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

        public com.travelsky.hotelbesdk.models.Warnings Warnings
        {
            get
            {
                return this.warnings;
            }
            set
            {
                this.warnings = value;
            }
        }
    }
}

