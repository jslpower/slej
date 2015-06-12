namespace com.travelsky.hotelbesdk.models.easyhotel.multi
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using com.travelsky.hotelbesdk.models.easyhotel.landmark;

    public class BasicHotelInfo
    {
        private string address;
        private string brandCode;
        private string floor;
        private string hotelCode;
        private string hotelNameCN;
        private string hotelNameEN;
        private List<DictionaryEntry> images = new List<DictionaryEntry>();
        private List<LandMarkVO> landmarks;
        private string latitude;
        private string longDesc;
        private string longitude;
        private string maxrate;
        private string minrate;
        private string positionDesc;
        private string rankCode;
        private string roomQuantity;

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
    }
}

