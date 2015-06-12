namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using com.travelsky.hotelbesdk.utils;
    using System;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Configuration;

    public class BaseRQ
    {
        private string hotelbe_address = (ConfigurationManager.AppSettings["HOTELBE_ADDRESS"] ?? "");
        private string hotelbe_if_proxy = (ConfigurationManager.AppSettings["HOTELBE_IF_PROXY"] ?? "");
        private string hotelbe_officecode = (ConfigurationManager.AppSettings["HOTELBE_OFFICECODE"] ?? "");
        private string hotelbe_officeid = (ConfigurationManager.AppSettings["HOTELBE_OFFICEID"] ?? "");
        private string hotelbe_password = (ConfigurationManager.AppSettings["HOTELBE_PASSWORD"] ?? "");
        private string hotelbe_proxyaddr = (ConfigurationManager.AppSettings["HOTELBE_PROXYADDR"] ?? "");
        private string hotelbe_proxyport = (ConfigurationManager.AppSettings["HOTELBE_PROXYPORT"] ?? "");
        private string hotelbe_useid = (ConfigurationManager.AppSettings["HOTELBE_USEID"] ?? "");
        private string hotelbe_version = (ConfigurationManager.AppSettings["HOTELBE_VERSION"] ?? "");
        private IdentityInfo identityInfo;
        private OTRequest otRequest;
        private OTResponse otResponse;
        private Source source;

        public BaseRQ()
        {
            if (string.IsNullOrEmpty(this.hotelbe_address))
            {
                throw new HotelbeException("hotelbe_sdk_net配置文件中缺少HOTELBE_ADDRESS");
            }
            if (string.IsNullOrEmpty(this.hotelbe_officecode))
            {
                throw new HotelbeException("hotelbe_sdk_net配置文件中缺少HOTELBE_OFFICECODE");
            }
            if (string.IsNullOrEmpty(this.hotelbe_officeid))
            {
                throw new HotelbeException("hotelbe_sdk_net配置文件中缺少HOTELBE_OFFICEID");
            }
            if (string.IsNullOrEmpty(this.hotelbe_useid))
            {
                throw new HotelbeException("hotelbe_sdk_net配置文件中缺少HOTELBE_USEID");
            }
            if (string.IsNullOrEmpty(this.hotelbe_password))
            {
                throw new HotelbeException("hotelbe_sdk_net配置文件中缺少HOTELBE_PASSWORD");
            }
            if (!(!string.IsNullOrEmpty(this.hotelbe_if_proxy) && this.hotelbe_if_proxy.Equals("Y")))
            {
                this.hotelbe_if_proxy = "N";
            }
            else
            {
                if (string.IsNullOrEmpty(this.hotelbe_proxyaddr))
                {
                    throw new HotelbeException("hotelbe_sdk_net配置文件中缺少HOTELBE_PROXYADDR");
                }
                if (string.IsNullOrEmpty(this.hotelbe_proxyport))
                {
                    throw new HotelbeException("hotelbe_sdk_net配置文件中缺少HOTELBE_PROXYPORT");
                }
            }
            this.otRequest = new OTRequest(base.GetType().Name);
            this.otResponse = new OTResponse();
            this.source = new Source();
            this.source.OfficeCode = this.hotelbe_officecode;
            this.identityInfo = new IdentityInfo();
            this.identityInfo.OfficeID = this.hotelbe_officeid;
            this.identityInfo.UserID = this.hotelbe_useid;
            this.identityInfo.Password = this.hotelbe_password;
            this.otRequest.Source = this.source;
            this.otRequest.IdentityInfo = this.identityInfo;
        }

        public void clear()
        {
            this.otRequest = new OTRequest(base.GetType().Name);
            this.otResponse = new OTResponse();
        }

        public void doRequest(string reqString, bool iflog)
        {
            string xml = "";
            string name = base.GetType().Name;
            try
            {
                this.request = reqString;
                xml = Utils.SendAndReceive(this.hotelbe_address, reqString);
                new XmlDocument().LoadXml(xml);
            }
            catch (Exception exception)
            {
                string str3;
                MatchCollection matchs;
                if (string.IsNullOrEmpty(xml))
                {
                    throw exception;
                }
                if ((name == "TH_HotelStaticInfoCacheRQ") && xml.ToLower().Contains("<html"))
                {
                    str3 = @"(?<=OTResponse>)([\S\s]+)(?=<\/HotelStaticInfo>)";
                    Regex regex = new Regex(str3);
                    matchs = regex.Matches(xml);
                    if ((matchs == null) || (matchs.Count < 1))
                    {
                        throw new HotelbeException("TH_HotelStaticInfoCacheRQ请求无数据！");
                    }
                    if ((matchs != null) && (matchs.Count > 0))
                    {
                        xml = "<OTResponse>" + matchs[0].Value + "</HotelStaticInfo></HotelStaticInfos></HotelStaticInfoCacheRS></OTResponse>";
                    }
                }
                if ((name == "TH_LandMarkSearchRQ") && xml.ToLower().Contains("<html"))
                {
                    str3 = @"(?<=OTResponse>)([\S\s]+)(?=<\/LandMarkInfo>)";
                    matchs = new Regex(str3).Matches(xml);
                    if ((matchs == null) || (matchs.Count < 1))
                    {
                        throw new HotelbeException("TH_LandMarkSearchRQ请求无数据！");
                    }
                    if ((matchs != null) && (matchs.Count > 0))
                    {
                        xml = "<OTResponse>" + matchs[0].Value + "</LandMarkInfo></LandMarks></LandMarkSearchRS></OTResponse>";
                    }
                }
            }
            this.response = xml;
            OTResponse response = (OTResponse) Utils.Xml2Object(xml, typeof(OTResponse));
            this.OtResponse = response;
        }

        public OTRequest OtRequest
        {
            get
            {
                return this.otRequest;
            }
            set
            {
                this.otRequest = value;
            }
        }

        public OTResponse OtResponse
        {
            get
            {
                return this.otResponse;
            }
            set
            {
                this.otResponse = value;
            }
        }

        public string request { get; set; }

        public string response { get; set; }
    }
}

