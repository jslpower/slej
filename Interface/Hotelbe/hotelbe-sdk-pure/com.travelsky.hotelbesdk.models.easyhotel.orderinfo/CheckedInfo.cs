namespace com.travelsky.hotelbesdk.models.easyhotel.orderinfo
{
    using System;

    public class CheckedInfo
    {
        private string checkedstatus;
        private string commisionFix;
        private string commisionPercent;
        private string commisionType;
        private string createDate;
        private string duration;
        private string payment;
        private string realCheckInDate;
        private string realCheckOutDate;
        private string resID;
        private string roomName;
        private string roomNight;
        private string roomQuantity;
        private string totalCommision;
        private string totalFee;
        private string totalRateAmount;

        public string getCheckedstatus()
        {
            return this.Checkedstatus;
        }

        public string getCommisionFix()
        {
            return this.commisionFix;
        }

        public string getCommisionPercent()
        {
            return this.commisionPercent;
        }

        public string getCommisionType()
        {
            return this.commisionType;
        }

        public string getCreateDate()
        {
            return this.createDate;
        }

        public string getDuration()
        {
            return this.duration;
        }

        public string getPayment()
        {
            return this.payment;
        }

        public string getRealCheckInDate()
        {
            return this.realCheckInDate;
        }

        public string getRealCheckOutDate()
        {
            return this.realCheckOutDate;
        }

        public string getResID()
        {
            return this.resID;
        }

        public string getRoomName()
        {
            return this.roomName;
        }

        public string getRoomNight()
        {
            return this.roomNight;
        }

        public string getRoomQuantity()
        {
            return this.roomQuantity;
        }

        public string getTotalCommision()
        {
            return this.totalCommision;
        }

        public string getTotalFee()
        {
            return this.totalFee;
        }

        public string getTotalRateAmount()
        {
            return this.totalRateAmount;
        }

        public void setCheckedstatus(string checkedstatus)
        {
            this.Checkedstatus = checkedstatus;
        }

        public void setCommisionFix(string commisionFix)
        {
            this.commisionFix = commisionFix;
        }

        public void setCommisionPercent(string commisionPercent)
        {
            this.commisionPercent = commisionPercent;
        }

        public void setCommisionType(string commisionType)
        {
            this.commisionType = commisionType;
        }

        public void setCreateDate(string createDate)
        {
            this.createDate = createDate;
        }

        public void setDuration(string duration)
        {
            this.duration = duration;
        }

        public void setPayment(string payment)
        {
            this.payment = payment;
        }

        public void setRealCheckInDate(string realCheckInDate)
        {
            this.realCheckInDate = realCheckInDate;
        }

        public void setRealCheckOutDate(string realCheckOutDate)
        {
            this.realCheckOutDate = realCheckOutDate;
        }

        public void setResID(string resID)
        {
            this.resID = resID;
        }

        public void setRoomName(string roomName)
        {
            this.roomName = roomName;
        }

        public void setRoomNight(string roomNight)
        {
            this.roomNight = roomNight;
        }

        public void setRoomQuantity(string roomQuantity)
        {
            this.roomQuantity = roomQuantity;
        }

        public void setTotalCommision(string totalCommision)
        {
            this.totalCommision = totalCommision;
        }

        public void setTotalFee(string totalFee)
        {
            this.totalFee = totalFee;
        }

        public void setTotalRateAmount(string totalRateAmount)
        {
            this.totalRateAmount = totalRateAmount;
        }

        public string Checkedstatus
        {
            get
            {
                return this.checkedstatus;
            }
            set
            {
                this.checkedstatus = value;
            }
        }
    }
}

