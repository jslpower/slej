namespace com.travelsky.hotelbesdk.models.easyhotel.landmark
{
    using System;

    public class LandMarkVO
    {
        private string cityCode;
        private string landmarkName;

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

        public string LandmarkName
        {
            get
            {
                return this.landmarkName;
            }
            set
            {
                this.landmarkName = value;
            }
        }
    }
}

