namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("OTResponse")]
    public class OTResponse
    {
        private com.travelsky.hotelbesdk.models.CityDetailsSearchRS cityDetailsSearchRS;
        private string code;
        private string description;
        private com.travelsky.hotelbesdk.models.DestinationSystemCodes destinationSystemCodes;
        private List<Error> errors;
        private com.travelsky.hotelbesdk.models.Header header;
        private com.travelsky.hotelbesdk.models.HotelAvailabilityCacheRS hotelAvailabilityCacheRS;
        private com.travelsky.hotelbesdk.models.HotelAvailRS hotelAvailRS;
        private com.travelsky.hotelbesdk.models.HotelCancelRS hotelCancelRS;
        private com.travelsky.hotelbesdk.models.HotelCheckSearchRS hotelCheckSearchRS;
        private com.travelsky.hotelbesdk.models.HotelResDetailSearchRS hotelResDetailSearchRS;
        private com.travelsky.hotelbesdk.models.HotelResModifyRS hotelResModifyRS;
        private com.travelsky.hotelbesdk.models.HotelResProcessRS hotelResProcessRS;
        private com.travelsky.hotelbesdk.models.HotelResRS hotelResRS;
        private com.travelsky.hotelbesdk.models.HotelResSearchRS hotelResSearchRS;
        private com.travelsky.hotelbesdk.models.HotelRoomTypeStaticInfoCacheRS hotelRoomTypeStaticInfoCacheRS;
        private com.travelsky.hotelbesdk.models.HotelStaticInfoCacheRS hotelStaticInfoCacheRS;
        private com.travelsky.hotelbesdk.models.IdentityInfo identityInfo;
        private com.travelsky.hotelbesdk.models.LandMarkSearchRS landMarkSearchRS;
        private com.travelsky.hotelbesdk.models.OfferHotelsRS offerHotelsRS;
        private com.travelsky.hotelbesdk.models.OfferRoomTypesRS offerRoomTypesRS;
        private com.travelsky.hotelbesdk.models.RatePlanControlRS ratePlanControlRS;
        private com.travelsky.hotelbesdk.models.Source source;
        private com.travelsky.hotelbesdk.models.Success success;
        private string transactionName;
        private com.travelsky.hotelbesdk.models.UpdateHotelsRS updateHotelsRS;

        public com.travelsky.hotelbesdk.models.CityDetailsSearchRS CityDetailsSearchRS
        {
            get
            {
                return this.cityDetailsSearchRS;
            }
            set
            {
                this.cityDetailsSearchRS = value;
            }
        }

        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public com.travelsky.hotelbesdk.models.DestinationSystemCodes DestinationSystemCodes
        {
            get
            {
                return this.destinationSystemCodes;
            }
            set
            {
                this.destinationSystemCodes = value;
            }
        }

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

        public com.travelsky.hotelbesdk.models.Header Header
        {
            get
            {
                return this.header;
            }
            set
            {
                this.header = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelAvailabilityCacheRS HotelAvailabilityCacheRS
        {
            get
            {
                return this.hotelAvailabilityCacheRS;
            }
            set
            {
                this.hotelAvailabilityCacheRS = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelAvailRS HotelAvailRS
        {
            get
            {
                return this.hotelAvailRS;
            }
            set
            {
                this.hotelAvailRS = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelCancelRS HotelCancelRS
        {
            get
            {
                return this.hotelCancelRS;
            }
            set
            {
                this.hotelCancelRS = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelCheckSearchRS HotelCheckSearchRS
        {
            get
            {
                return this.hotelCheckSearchRS;
            }
            set
            {
                this.hotelCheckSearchRS = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelResDetailSearchRS HotelResDetailSearchRS
        {
            get
            {
                return this.hotelResDetailSearchRS;
            }
            set
            {
                this.hotelResDetailSearchRS = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelResModifyRS HotelResModifyRS
        {
            get
            {
                return this.hotelResModifyRS;
            }
            set
            {
                this.hotelResModifyRS = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelResProcessRS HotelResProcessRS
        {
            get
            {
                return this.hotelResProcessRS;
            }
            set
            {
                this.hotelResProcessRS = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelResRS HotelResRS
        {
            get
            {
                return this.hotelResRS;
            }
            set
            {
                this.hotelResRS = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelResSearchRS HotelResSearchRS
        {
            get
            {
                return this.hotelResSearchRS;
            }
            set
            {
                this.hotelResSearchRS = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelRoomTypeStaticInfoCacheRS HotelRoomTypeStaticInfoCacheRS
        {
            get
            {
                return this.hotelRoomTypeStaticInfoCacheRS;
            }
            set
            {
                this.hotelRoomTypeStaticInfoCacheRS = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelStaticInfoCacheRS HotelStaticInfoCacheRS
        {
            get
            {
                return this.hotelStaticInfoCacheRS;
            }
            set
            {
                this.hotelStaticInfoCacheRS = value;
            }
        }

        public com.travelsky.hotelbesdk.models.IdentityInfo IdentityInfo
        {
            get
            {
                return this.identityInfo;
            }
            set
            {
                this.identityInfo = value;
            }
        }

        public com.travelsky.hotelbesdk.models.LandMarkSearchRS LandMarkSearchRS
        {
            get
            {
                return this.landMarkSearchRS;
            }
            set
            {
                this.landMarkSearchRS = value;
            }
        }

        public com.travelsky.hotelbesdk.models.OfferHotelsRS OfferHotelsRS
        {
            get
            {
                return this.offerHotelsRS;
            }
            set
            {
                this.offerHotelsRS = value;
            }
        }

        public com.travelsky.hotelbesdk.models.OfferRoomTypesRS OfferRoomTypesRS
        {
            get
            {
                return this.offerRoomTypesRS;
            }
            set
            {
                this.offerRoomTypesRS = value;
            }
        }

        public com.travelsky.hotelbesdk.models.RatePlanControlRS RatePlanControlRS
        {
            get
            {
                return this.ratePlanControlRS;
            }
            set
            {
                this.ratePlanControlRS = value;
            }
        }

        public com.travelsky.hotelbesdk.models.Source Source
        {
            get
            {
                return this.source;
            }
            set
            {
                this.source = value;
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

        public string TransactionName
        {
            get
            {
                return this.transactionName;
            }
            set
            {
                this.transactionName = value;
            }
        }

        public com.travelsky.hotelbesdk.models.UpdateHotelsRS UpdateHotelsRS
        {
            get
            {
                return this.updateHotelsRS;
            }
            set
            {
                this.updateHotelsRS = value;
            }
        }
    }
}

