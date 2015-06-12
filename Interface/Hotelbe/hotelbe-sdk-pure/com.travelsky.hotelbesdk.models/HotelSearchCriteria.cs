namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelSearchCriteria
    {
        private com.travelsky.hotelbesdk.models.HotelRef hotelRef;
        private string includingTest;
        private string landMark;
        private string rank;
        private List<RoomStayCandidate> roomStayCandidates = new List<RoomStayCandidate>();

        public com.travelsky.hotelbesdk.models.HotelRef HotelRef
        {
            get
            {
                return this.hotelRef;
            }
            set
            {
                this.hotelRef = value;
            }
        }

        public string IncludingTest
        {
            get
            {
                return this.includingTest;
            }
            set
            {
                this.includingTest = value;
            }
        }

        public string LandMark
        {
            get
            {
                return this.landMark;
            }
            set
            {
                this.landMark = value;
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

        public List<RoomStayCandidate> RoomStayCandidates
        {
            get
            {
                return this.roomStayCandidates;
            }
            set
            {
                this.roomStayCandidates = value;
            }
        }
    }
}

