namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelResProcessRS
    {
        private List<HotelResProcess> resProcesses = new List<HotelResProcess>();
        private string success;

        public List<HotelResProcess> ResProcesses
        {
            get
            {
                return this.resProcesses;
            }
            set
            {
                this.resProcesses = value;
            }
        }

        public string Success
        {
            get
            {
                return this.success;
            }
            set
            {
                this.success = value;
            }
        }
    }
}

