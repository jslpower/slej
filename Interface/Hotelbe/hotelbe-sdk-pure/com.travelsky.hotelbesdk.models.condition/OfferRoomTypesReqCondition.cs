namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class OfferRoomTypesReqCondition : BaseReqCondition
    {
        private string endtime;
        private string starttime;

        public string getEndtime()
        {
            return this.endtime;
        }

        public string getStarttime()
        {
            return this.starttime;
        }

        public void setEndtime(string endtime)
        {
            this.endtime = endtime;
        }

        public void setStarttime(string starttime)
        {
            this.starttime = starttime;
        }

        public string Endtime
        {
            get
            {
                return this.endtime;
            }
            set
            {
                this.endtime = value;
            }
        }

        public string Starttime
        {
            get
            {
                return this.starttime;
            }
            set
            {
                this.starttime = value;
            }
        }
    }
}

