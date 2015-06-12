namespace com.travelsky.hotelbesdk.utils
{
    using System;

    public class HotelbeException : Exception
    {
        public HotelbeException()
        {
        }

        public HotelbeException(string message)
        {
            throw new Exception(message);
        }

        public HotelbeException(string message, Exception innerException)
        {
            throw new Exception(message, innerException);
        }
    }
}

