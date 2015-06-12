namespace com.travelsky.hotelbesdk.utils
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml.Serialization;

    public class Utils
    {
        public static string Object2Xml<T>(T obj)
        {
            string str;
            try
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize((Stream) stream, obj);
                    str = Encoding.UTF8.GetString(stream.ToArray());
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public static string SendAndReceive(string reqAddress, string reqString)
        {
            string str5;
            try
            {
                string str = "";
                reqString = "request=" + reqString;
                byte[] bytes = Encoding.UTF8.GetBytes(reqString);
                WebRequest request = WebRequest.Create(reqAddress);
                request.Method = "POST";
                request.Timeout = 0x1d4c0;
                request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
                request.ContentLength = bytes.Length;
                string host = ConfigurationManager.AppSettings["HOTELBE_PROXYADDR"] ?? "";
                string s = ConfigurationManager.AppSettings["HOTELBE_PROXYPORT"] ?? "";
                string str4 = ConfigurationManager.AppSettings["HOTELBE_IF_PROXY"] ?? "";
                if (str4.Trim().ToUpper().Equals("Y"))
                {
                    WebProxy proxy = new WebProxy(host, int.Parse(s));
                    request.Proxy = proxy;
                }
                WebResponse response = null;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                Encoding encoding = Encoding.UTF8;
                StreamReader reader = new StreamReader(responseStream, encoding);
                str = reader.ReadToEnd();
                responseStream.Close();
                reader.Close();
                response.Close();
                str5 = str;
            }
            catch (Exception exception)
            {
                throw new HotelbeException("指令请求异常", exception);
            }
            return str5;
        }

        public static string SendAndReceive1(string reqAddress, string reqString)
        {
            WebClient client = new WebClient();
            client.QueryString.Add("request", reqString);
            string host = ConfigurationManager.AppSettings["HOTELBE_PROXYADDR"] ?? "";
            string s = ConfigurationManager.AppSettings["HOTELBE_PROXYPORT"] ?? "";
            string str3 = ConfigurationManager.AppSettings["HOTELBE_IF_PROXY"] ?? "";
            if (str3.Trim().ToUpper().Equals("Y"))
            {
                WebProxy proxy = new WebProxy(host, int.Parse(s));
                client.Proxy = proxy;
            }
            byte[] bytes = client.DownloadData(reqAddress);
            return Encoding.UTF8.GetString(bytes);
        }

        public static object Xml2Object(string xmlString, Type t)
        {
            object obj2;
            try
            {
                XmlSerializer serializer = new XmlSerializer(t);
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
                {
                    obj2 = serializer.Deserialize(stream);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return obj2;
        }
    }
}

