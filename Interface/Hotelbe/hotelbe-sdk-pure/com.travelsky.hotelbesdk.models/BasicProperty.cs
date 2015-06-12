namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class BasicProperty
    {
        private List<AcceptedPayment> acceptedPayments;
        private string address;
        private string brandCode;
        private string brandName;
        private string chainCode;
        private string chainName;
        private string cityCode;
        private string countryCode;
        private string district;
        private string enaddress;
        private string fax;
        private string fitment;
        private string floor;
        private List<HotelAmenity> hotelAmenities;
        private string hotelCode;
        private string hotelEnglishName;
        private string hotelEnName;
        private string hotelName;
        private List<Image> images;
        private string longDesc;
        private string maxRate;
        private string minRate;
        private string opendate;
        private string pOR;
        private com.travelsky.hotelbesdk.models.Position position;
        private string postCode;
        private string rank;
        private List<RelativePosition> relativePositions;
        private string roomQuantity;
        private string shortDesc;
        private string tel;
        private List<VendorMessage> vendorMessages;

        public List<AcceptedPayment> AcceptedPayments
        {
            get
            {
                return this.acceptedPayments;
            }
            set
            {
                this.acceptedPayments = value;
            }
        }

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

        public string BrandName
        {
            get
            {
                return this.brandName;
            }
            set
            {
                this.brandName = value;
            }
        }

        public string ChainCode
        {
            get
            {
                return this.chainCode;
            }
            set
            {
                this.chainCode = value;
            }
        }

        public string ChainName
        {
            get
            {
                return this.chainName;
            }
            set
            {
                this.chainName = value;
            }
        }

        [XmlAttribute("CityCode")]
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

        [XmlAttribute("CountryCode")]
        public string CountryCode
        {
            get
            {
                return this.countryCode;
            }
            set
            {
                this.countryCode = value;
            }
        }

        public string District
        {
            get
            {
                return this.district;
            }
            set
            {
                this.district = value;
            }
        }

        [XmlElement("EnAddress")]
        public string Enaddress
        {
            get
            {
                return this.enaddress;
            }
            set
            {
                this.enaddress = value;
            }
        }

        public string Fax
        {
            get
            {
                return this.fax;
            }
            set
            {
                this.fax = value;
            }
        }

        public string Fitment
        {
            get
            {
                return this.fitment;
            }
            set
            {
                this.fitment = value;
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

        [XmlAttribute("HotelCode")]
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

        [XmlAttribute("HotelEnglishName")]
        public string HotelEnglishName
        {
            get
            {
                return this.hotelEnglishName;
            }
            set
            {
                this.hotelEnglishName = value;
            }
        }

        [XmlAttribute("HotelEnName")]
        public string HotelEnName
        {
            get
            {
                return this.hotelEnName;
            }
            set
            {
                this.hotelEnName = value;
            }
        }

        [XmlAttribute("HotelName")]
        public string HotelName
        {
            get
            {
                return this.hotelName;
            }
            set
            {
                this.hotelName = value;
            }
        }

        public List<Image> Images
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

        public string MaxRate
        {
            get
            {
                return this.maxRate;
            }
            set
            {
                this.maxRate = value;
            }
        }

        public string MinRate
        {
            get
            {
                return this.minRate;
            }
            set
            {
                this.minRate = value;
            }
        }

        public string Opendate
        {
            get
            {
                return this.opendate;
            }
            set
            {
                this.opendate = value;
            }
        }

        public string POR
        {
            get
            {
                return this.pOR;
            }
            set
            {
                this.pOR = value;
            }
        }

        public com.travelsky.hotelbesdk.models.Position Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public string PostCode
        {
            get
            {
                return this.postCode;
            }
            set
            {
                this.postCode = value;
            }
        }

        public string Rank
        {
            get
            {
                return this.rank;
            }
            set
            {
                this.rank = value;
            }
        }

        public List<RelativePosition> RelativePositions
        {
            get
            {
                return this.relativePositions;
            }
            set
            {
                this.relativePositions = value;
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

        public string ShortDesc
        {
            get
            {
                return this.shortDesc;
            }
            set
            {
                this.shortDesc = value;
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

        public List<VendorMessage> VendorMessages
        {
            get
            {
                return this.vendorMessages;
            }
            set
            {
                this.vendorMessages = value;
            }
        }
    }
}

