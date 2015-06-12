namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class LandMarkSearchRS
    {
        private List<LandMarkInfo> landMarks = new List<LandMarkInfo>();

        public List<LandMarkInfo> LandMarks
        {
            get
            {
                return this.landMarks;
            }
            set
            {
                this.landMarks = value;
            }
        }
    }
}

