namespace com.travelsky.hotelbesdk.models.easyhotel.single
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using com.travelsky.hotelbesdk.models.easyhotel.landmark;

    public class BasicHotelInfo
    {
        private string address;
        private string brandCode;
        private string cityCode;
        private string fixDate;
        private string floor;
        private List<HotelAcceptedPayment> hotelAcceptedPayments = new List<HotelAcceptedPayment>();
        private List<HotelAmenity> hotelAmenities = new List<HotelAmenity>();
        private string hotelCode;
        private string hotelNameCN;
        private string hotelNameEN;
        private List<HotelTrafficInfo> hotelTrafficInfos;
        private List<DictionaryEntry> images = new List<DictionaryEntry>();
        private List<LandMarkVO> landmarks;
        private string latitude;
        private string longDesc;
        private string longitude;
        private string maxrate;
        private string minrate;
        private string openDate;
        private string positionDesc;
        private string rankCode;
        private string roomQuantity;
        private string tel;

        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        public string BrandCode
        {
            get
            {
                return this.brandCode;
            }
            set
            {
                this.brandCode = value;
            }
        }

        public string CityCode
        {
            get
            {
                return this.cityCode;
            }
            set
            {
                this.cityCode = value;
            }
        }

        public string FixDate
        {
            get
            {
                return this.fixDate;
            }
            set
            {
                this.fixDate = value;
            }
        }

        public string Floor
        {
            get
            {
                return this.floor;
            }
            set
            {
                this.floor = value;
            }
        }

        public List<HotelAcceptedPayment> HotelAcceptedPayments
        {
            get
            {
                return this.hotelAcceptedPayments;
            }
            set
            {
                this.hotelAcceptedPayments = value;
            }
        }

        public List<HotelAmenity> HotelAmenities
        {
            get
            {
                return this.hotelAmenities;
            }
            set
            {
                this.hotelAmenities = value;
            }
        }

        public string HotelCode
        {
            get
            {
                return this.hotelCode;
            }
            set
            {
                this.hotelCode = value;
            }
        }

        public string HotelNameCN
        {
            get
            {
                return this.hotelNameCN;
            }
            set
            {
                this.hotelNameCN = value;
            }
        }

        public string HotelNameEN
        {
            get
            {
                return this.hotelNameEN;
            }
            set
            {
                this.hotelNameEN = value;
            }
        }

        public List<HotelTrafficInfo> HotelTrafficInfos
        {
            get
            {
                return this.hotelTrafficInfos;
            }
            set
            {
                this.hotelTrafficInfos = value;
            }
        }

        public List<DictionaryEntry> Images
        {
            get
            {
                return this.images;
            }
            set
            {
                this.images = value;
            }
        }

        public List<LandMarkVO> Landmarks
        {
            get
            {
                return this.landmarks;
            }
            set
            {
                this.landmarks = value;
            }
        }

        public string Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                this.latitude = value;
            }
        }

        public string LongDesc
        {
            get
            {
                return this.longDesc;
            }
            set
            {
                this.longDesc = value;
            }
        }

        public string Longitude
        {
            get
            {
                return this.longitude;
            }
            set
            {
                this.longitude = value;
            }
        }

        public string Maxrate
        {
            get
            {
                return this.maxrate;
            }
            set
            {
                this.maxrate = value;
            }
        }

        public string Minrate
        {
            get
            {
                return this.minrate;
            }
            set
            {
                this.minrate = value;
            }
        }

        public string OpenDate
        {
            get
            {
                return this.openDate;
            }
            set
            {
                this.openDate = value;
            }
        }

        public string PositionDesc
        {
            get
            {
                return this.positionDesc;
            }
            set
            {
                this.positionDesc = value;
            }
        }

        public string RankCode
        {
            get
            {
                return this.rankCode;
            }
            set
            {
                this.rankCode = value;
            }
        }

        public string RoomQuantity
        {
            get
            {
                return this.roomQuantity;
            }
            set
            {
                this.roomQuantity = value;
            }
        }

        public string Tel
        {
            get
            {
                return this.tel;
            }
            set
            {
                this.tel = value;
            }
        }
    }
}

