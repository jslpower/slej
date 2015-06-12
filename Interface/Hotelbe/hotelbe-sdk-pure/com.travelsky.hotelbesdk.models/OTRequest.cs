namespace com.travelsky.hotelbesdk.models
{
    using com.travelsky.hotelbesdk.utils;
    using System;
    using System.Configuration;
    using System.Xml.Serialization;

    [XmlRoot("OTRequest")]
    public class OTRequest : BaseHotelBEXml
    {
        private com.travelsky.hotelbesdk.models.CityDetailsSearchRQ cityDetailsSearchRQ;
        private com.travelsky.hotelbesdk.models.DestinationSystemCodes destinationSystemCodes;
        private com.travelsky.hotelbesdk.models.HotelAvailabilityCacheRQ hotelAvailabilityCacheRQ;
        private com.travelsky.hotelbesdk.models.HotelAvailRQ hotelAvailRQ;
        private com.travelsky.hotelbesdk.models.HotelCancelRQ hotelCancelRQ;
        private com.travelsky.hotelbesdk.models.HotelCheckSearchRQ hotelCheckSearchRQ;
        private com.travelsky.hotelbesdk.models.HotelResDetailSearchRQ hotelResDetailSearchRQ;
        private com.travelsky.hotelbesdk.models.HotelResModifyRQ hotelResModifyRQ;
        private com.travelsky.hotelbesdk.models.HotelResProcessRQ hotelResProcessRQ;
        private com.travelsky.hotelbesdk.models.HotelResRQ hotelResRQ;
        private com.travelsky.hotelbesdk.models.HotelResSearchRQ hotelResSearchRQ;
        private com.travelsky.hotelbesdk.models.HotelRoomTypeStaticInfoCacheRQ hotelRoomTypeStaticInfoCacheRQ;
        private com.travelsky.hotelbesdk.models.HotelStaticInfoCacheRQ hotelStaticInfoCacheRQ;
        private com.travelsky.hotelbesdk.models.LandMarkSearchRQ landMarkSearchRQ;
        private com.travelsky.hotelbesdk.models.OfferHotelsRQ offerHotelsRQ;
        private com.travelsky.hotelbesdk.models.OfferRoomTypesRQ offerRoomTypesRQ;
        private com.travelsky.hotelbesdk.models.OrderStatusMessage orderStatusMessage;
        private com.travelsky.hotelbesdk.models.RateplanControlCacheRQ rateplanControlCacheRQ;
        private com.travelsky.hotelbesdk.models.Source source;
        private com.travelsky.hotelbesdk.models.UpdateHotelsRQ updateHotelsRQ;

        public OTRequest()
        {
        }

        public OTRequest(string transactionName)
        {
            this.initHeader();
            this.initSource();
            this.initIdentityInfo();
            base.TransactionName = transactionName;
        }

        private void initHeader()
        {
            base.Header = new Header();
            base.Header.Application = "hotelbe";
            base.Header.Encoding = "UTF-8";
            base.Header.Invoker = "travelsky";
            base.Header.Locale = "cn";
            base.Header.SerialNo = "";
            base.Header.SessionID = "";
            base.Header.TimeStamp = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
            string str = ConfigurationManager.AppSettings["HOTELBE_VERSION"] ?? "";
            if (string.IsNullOrEmpty(str))
            {
                throw new HotelbeException("hotelbe_sdk_net配置文件中缺少HOTELBE_VERSION");
            }
        }

        private void initIdentityInfo()
        {
            base.IdentityInfo = new IdentityInfo();
        }

        private void initSource()
        {
            this.Source = new com.travelsky.hotelbesdk.models.Source();
        }

        public com.travelsky.hotelbesdk.models.CityDetailsSearchRQ CityDetailsSearchRQ
        {
            get
            {
                return this.cityDetailsSearchRQ;
            }
            set
            {
                this.cityDetailsSearchRQ = value;
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

        public com.travelsky.hotelbesdk.models.HotelAvailabilityCacheRQ HotelAvailabilityCacheRQ
        {
            get
            {
                return this.hotelAvailabilityCacheRQ;
            }
            set
            {
                this.hotelAvailabilityCacheRQ = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelAvailRQ HotelAvailRQ
        {
            get
            {
                return this.hotelAvailRQ;
            }
            set
            {
                this.hotelAvailRQ = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelCancelRQ HotelCancelRQ
        {
            get
            {
                return this.hotelCancelRQ;
            }
            set
            {
                this.hotelCancelRQ = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelCheckSearchRQ HotelCheckSearchRQ
        {
            get
            {
                return this.hotelCheckSearchRQ;
            }
            set
            {
                this.hotelCheckSearchRQ = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelResDetailSearchRQ HotelResDetailSearchRQ
        {
            get
            {
                return this.hotelResDetailSearchRQ;
            }
            set
            {
                this.hotelResDetailSearchRQ = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelResModifyRQ HotelResModifyRQ
        {
            get
            {
                return this.hotelResModifyRQ;
            }
            set
            {
                this.hotelResModifyRQ = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelResProcessRQ HotelResProcessRQ
        {
            get
            {
                return this.hotelResProcessRQ;
            }
            set
            {
                this.hotelResProcessRQ = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelResRQ HotelResRQ
        {
            get
            {
                return this.hotelResRQ;
            }
            set
            {
                this.hotelResRQ = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelResSearchRQ HotelResSearchRQ
        {
            get
            {
                return this.hotelResSearchRQ;
            }
            set
            {
                this.hotelResSearchRQ = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelRoomTypeStaticInfoCacheRQ HotelRoomTypeStaticInfoCacheRQ
        {
            get
            {
                return this.hotelRoomTypeStaticInfoCacheRQ;
            }
            set
            {
                this.hotelRoomTypeStaticInfoCacheRQ = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelStaticInfoCacheRQ HotelStaticInfoCacheRQ
        {
            get
            {
                return this.hotelStaticInfoCacheRQ;
            }
            set
            {
                this.hotelStaticInfoCacheRQ = value;
            }
        }

        public com.travelsky.hotelbesdk.models.LandMarkSearchRQ LandMarkSearchRQ
        {
            get
            {
                return this.landMarkSearchRQ;
            }
            set
            {
                this.landMarkSearchRQ = value;
            }
        }

        public com.travelsky.hotelbesdk.models.OfferHotelsRQ OfferHotelsRQ
        {
            get
            {
                return this.offerHotelsRQ;
            }
            set
            {
                this.offerHotelsRQ = value;
            }
        }

        public com.travelsky.hotelbesdk.models.OfferRoomTypesRQ OfferRoomTypesRQ
        {
            get
            {
                return this.offerRoomTypesRQ;
            }
            set
            {
                this.offerRoomTypesRQ = value;
            }
        }

        public com.travelsky.hotelbesdk.models.OrderStatusMessage OrderStatusMessage
        {
            get
            {
                return this.orderStatusMessage;
            }
            set
            {
                this.orderStatusMessage = value;
            }
        }

        public com.travelsky.hotelbesdk.models.RateplanControlCacheRQ RateplanControlCacheRQ
        {
            get
            {
                return this.rateplanControlCacheRQ;
            }
            set
            {
                this.rateplanControlCacheRQ = value;
            }
        }

        [XmlElement(ElementName="Source")]
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

        public com.travelsky.hotelbesdk.models.UpdateHotelsRQ UpdateHotelsRQ
        {
            get
            {
                return this.updateHotelsRQ;
            }
            set
            {
                this.updateHotelsRQ = value;
            }
        }
    }
}

