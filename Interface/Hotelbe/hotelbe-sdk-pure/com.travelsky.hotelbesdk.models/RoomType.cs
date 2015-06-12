namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class RoomType
    {
        private List<AdditionalDetail> additionalDetails;
        private List<Amenity> amenities;
        private string bedType;
        private string category;
        private string description;
        private string hotelCode;
        private string maxAddBed;
        private string noSmoking;
        private string orientation;
        private string roomArea;
        private string roomDescription;
        private string roomTypeCode;
        private string roomTypeName;
        private string roomView;
        private string totalNumber;

        public List<AdditionalDetail> AdditionalDetails
        {
            get
            {
                return this.additionalDetails;
            }
            set
            {
                this.additionalDetails = value;
            }
        }

        public List<Amenity> Amenities
        {
            get
            {
                return this.amenities;
            }
            set
            {
                this.amenities = value;
            }
        }

        [XmlAttribute("BedType")]
        public string BedType
        {
            get
            {
                return this.bedType;
            }
            set
            {
                this.bedType = value;
            }
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
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

        public string MaxAddBed
        {
            get
            {
                return this.maxAddBed;
            }
            set
            {
                this.maxAddBed = value;
            }
        }

        [XmlAttribute("NoSmoking")]
        public string NoSmoking
        {
            get
            {
                return this.noSmoking;
            }
            set
            {
                this.noSmoking = value;
            }
        }

        public string Orientation
        {
            get
            {
                return this.orientation;
            }
            set
            {
                this.orientation = value;
            }
        }

        public string RoomArea
        {
            get
            {
                return this.roomArea;
            }
            set
            {
                this.roomArea = value;
            }
        }

        public string RoomDescription
        {
            get
            {
                return this.roomDescription;
            }
            set
            {
                this.roomDescription = value;
            }
        }

        [XmlAttribute("RoomTypeCode")]
        public string RoomTypeCode
        {
            get
            {
                return this.roomTypeCode;
            }
            set
            {
                this.roomTypeCode = value;
            }
        }

        [XmlAttribute("RoomTypeName")]
        public string RoomTypeName
        {
            get
            {
                return this.roomTypeName;
            }
            set
            {
                this.roomTypeName = value;
            }
        }

        public string RoomView
        {
            get
            {
                return this.roomView;
            }
            set
            {
                this.roomView = value;
            }
        }

        public string TotalNumber
        {
            get
            {
                return this.totalNumber;
            }
            set
            {
                this.totalNumber = value;
            }
        }
    }
}

