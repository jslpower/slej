namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class GuestCount
    {
        private string age;
        private string ageQualifyingCode;
        private string count;

        public string Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        [XmlAttribute("AgeQualifyingCode")]
        public string AgeQualifyingCode
        {
            get
            {
                return this.ageQualifyingCode;
            }
            set
            {
                this.ageQualifyingCode = value;
            }
        }

        [XmlAttribute("Count")]
        public string Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }
    }
}

