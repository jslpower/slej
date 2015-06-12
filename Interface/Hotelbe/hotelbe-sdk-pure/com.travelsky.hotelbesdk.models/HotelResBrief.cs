namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelResBrief
    {
        private string checkInDate;
        private string checkOutDate;
        private string createDate;
        private string guestName;
        private string hotelCityCode;
        private string hotelName;
        private string hotelResStatus;
        private List<HotelRoomType> hotelRoomTypes;
        private string payment;
        private string resID;
        private string resStatus;
        private string roomNight;
        private string roomQuantity;
        private string roomTypeName;
        private string totalRateAmount;
        private string vendorCode;
        private string vendorResId;

        public string getVendorResID()
        {
            return this.VendorResId;
        }

        public void setVendorResID(string vendorResId)
        {
            this.VendorResId = vendorResId;
        }

        public string CheckInDate
        {
            get
            {
                return this.checkInDate;
            }
            set
            {
                this.checkInDate = value;
            }
        }

        public string CheckOutDate
        {
            get
            {
                return this.checkOutDate;
            }
            set
            {
                this.checkOutDate = value;
            }
        }

        public string CreateDate
        {
            get
            {
                return this.createDate;
            }
            set
            {
                this.createDate = value;
            }
        }

        public string GuestName
        {
            get
            {
                return this.guestName;
            }
            set
            {
                this.guestName = value;
            }
        }

        public string HotelCityCode
        {
            get
            {
                return this.hotelCityCode;
            }
            set
            {
                this.hotelCityCode = value;
            }
        }

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

        public string HotelResStatus
        {
            get
            {
                return this.hotelResStatus;
            }
            set
            {
                this.hotelResStatus = value;
            }
        }

        public List<HotelRoomType> HotelRoomTypes
        {
            get
            {
                return this.hotelRoomTypes;
            }
            set
            {
                this.hotelRoomTypes = value;
            }
        }

        public string Payment
        {
            get
            {
                return this.payment;
            }
            set
            {
                this.payment = value;
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

        public string ResStatus
        {
            get
            {
                return this.resStatus;
            }
            set
            {
                this.resStatus = value;
            }
        }

        public string RoomNight
        {
            get
            {
                return this.roomNight;
            }
            set
            {
                this.roomNight = value;
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

        public string TotalRateAmount
        {
            get
            {
                return this.totalRateAmount;
            }
            set
            {
                this.totalRateAmount = value;
            }
        }

        public string VendorCode
        {
            get
            {
                return this.vendorCode;
            }
            set
            {
                this.vendorCode = value;
            }
        }

        public string VendorResId
        {
            get
            {
                return this.vendorResId;
            }
            set
            {
                this.vendorResId = value;
            }
        }
    }
}

