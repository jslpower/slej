using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Data.Common;

namespace EyouSoft.InterfaceLib
{
    public class HotelBE 
    {
         #region
        /// <summary>
        /// 城市信息查询缓存指令
        /// </summary>
        public const string TH_CityDetailsSearchRQ = "TH_CityDetailsSearchRQ";
        /// <summary>
        /// 地标行政区查询缓存指令
        /// </summary>
        public const string TH_LandMarkSearchRQ = "TH_LandMarkSearchRQ";
        #endregion

        #region 返回指令
        /// <summary>
        /// 城市信息查询缓存返回指令
        /// </summary>
        public const string TH_CityDetailsSearchRS = "TH_CityDetailsSearchRS";
        /// <summary>
        /// 地标行政区查询缓存返回指令
        /// </summary>
        public const string TH_LandMarkSearchRS = "TH_LandMarkSearchRS";
        #endregion
        #region 公共验证信息
        /// <summary>
        /// HBE 接口验证信息
        /// </summary>
        public class IdentityInfo
        {

            #region 接口认证信息 /IdentityInfo 结点
            /// <summary>
            /// HBE OFFICE ID 必填
            /// </summary>
            private string _OfficeID = "ZJF599";
            public string OfficeID { get { return _OfficeID; } set { _OfficeID = value; } }
            /// <summary>
            /// HBE UserID 必填
            /// </summary>
            private string _UserID = "zjf59900C";
            public string UserID { get { return _UserID; } set { _UserID = value; } }
            /// <summary>
            /// HBE Password 必填
            /// </summary>
            private string _Password = "888999";
            public string Password { get { return _Password; } set { _Password = value; } }
            /// <summary>
            /// 角色    接口预留
            /// </summary>
            private string _Role = "";
            public string Role { get { return _Role; } set { _Role = value; } }
            #endregion

            #region 接口 SOURCE 信息
            /// <summary>
            /// 系列编号 接口预留
            /// </summary>
            public string UniqueID { get; set; }

            private string _BookingChannel = "HOTELBE";
            /// <summary>
            /// 预定渠道代码(默认填写:HOTELBE) 必填
            /// </summary>
            public string BookingChannel { get { return _BookingChannel; } set { _BookingChannel = value; } }
            #endregion
        }

        /// <summary>
        /// 头部验证信息
        /// </summary>
        public class Header
        {
            #region 头部实体
            /// <summary>
            /// SessionID
            /// </summary>
            public string SessionID { get; set; }
            /// <summary>
            /// 调用者
            /// </summary>
            public string Invoker { get; set; }
            /// <summary>
            /// 字符编码
            /// </summary>
            public string Encoding { get; set; }
            /// <summary>
            /// 区域
            /// </summary>
            public string Locale { get; set; }
            /// <summary>
            /// SerialNo
            /// </summary>
            public string SerialNo { get; set; }
            /// <summary>
            /// 时间戳 YYYY-mm-DD HH:MM:SS
            /// </summary>
            public string TimeStamp { get; set; }

            private string _application = "availCache";
            /// <summary>
            /// 子系统名称 必填
            /// </summary>
            public string Application { get { return _application; } set { _application = value; } }

            private string _language = "CN";
            /// <summary>
            /// 语言标识 默认为”CN”
            /// </summary>
            public string Language { get { return _language; } set { _language = value; } }
            #endregion
        }
        #endregion

        #region HeaderApplication
        /// <summary>
        /// Header Application hotelbe
        /// </summary>
        public const string HeaderApplication_hotelbe = "hotelbe";
        /// <summary>
        /// Header Application availCache
        /// </summary>
        public const string HeaderApplication_availCache = "availCache";
        #endregion

        /// <summary>
        /// HBE 接口地址
        /// </summary>
        public const string HBEURL = "http://dlink.sohoto.com/directlink/send.do";
        /// <summary>
        /// WebRequest Timeout
        /// </summary>
        private const int WebRequestTimeout = 30000;

        #region private members
        /// <summary>
        /// Create TransactionName
        /// </summary>
        /// <param name="transactionName">指令名称</param>
        /// <returns></returns>
        private static string CreateTransactionName(string transactionName)
        {
            return string.Format("<TransactionName>{0}</TransactionName>", transactionName);
        }

        /// <summary>
        /// Create Header
        /// </summary>
        /// <returns></returns>
        private static string CreateHeader()
        {
            return CreateHeader(new Header());
        }

        /// <summary>
        /// Create Header
        /// </summary>
        /// <param name="header">header info</param>
        /// <returns></returns>
        private static string CreateHeader(Header header)
        {
            return "<Header>" +
                            "<SessionID>" + header.SessionID + "</SessionID>" +
                            "<Invoker>" + header.Invoker + "</Invoker>" +
                            "<Encoding>" + header.Encoding + "</Encoding>" +
                            "<Locale>" + header.Locale + "</Locale>" +
                            "<SerialNo>" + header.SerialNo + "</SerialNo>" +
                            "<TimeStamp>" + header.TimeStamp + "</TimeStamp>" +
                            "<Application>" + header.Application + "</Application>" +
                            "<Language>" + header.Language + "</Language>" +
                            "</Header>";
        }

        /// <summary>
        /// Create IdentityInfo and Source
        /// </summary>
        /// <returns></returns>
        private static string CreateIdentityInfo()
        {
            return CreateIdentityInfo(new IdentityInfo());
        }

        /// <summary>
        /// Create IdentityInfo and Source
        /// </summary>
        /// <returns></returns>
        private static string CreateIdentityInfo(IdentityInfo identityInfo)
        {
            return "<IdentityInfo>" +
                            "<OfficeID>" + identityInfo.OfficeID + "</OfficeID>" +
                            "<UserID>" + identityInfo.UserID + "</UserID>" +
                            "<Password>" + identityInfo.Password + "</Password>" +
                            "<Role>" + identityInfo.Role + "</Role>" +
                            "</IdentityInfo>" +
                            "<Source>" +
                            "<OfficeCode>" + identityInfo.OfficeID + "</OfficeCode>" +
                            "<UniqueID>" + identityInfo.UniqueID + "</UniqueID>" +
                            "<BookingChannel>" + identityInfo.BookingChannel + "</BookingChannel>" +
                            "</Source>";
        }

        #endregion
        #region public members
        /// <summary>
        /// 转换 布尔为 Y 或 N
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string BoolToYesOrNo(bool b)
        {
            return b ? "Y" : "N";
        }

        /// <summary>
        /// Create Request XML,Header.Application="hotelbe"
        /// </summary>
        /// <param name="transactionName"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static string CreateRequestXML(string transactionName, string xml)
        {
            return CreateRequestXML(transactionName, xml, HeaderApplication_availCache);
        }

        /// <summary>
        /// Create Request XML
        /// </summary>
        /// <param name="transactionName">TransactionName</param>
        /// <param name="xml"></param>
        /// <param name="headerApplication">Header.Application</param>
        /// <returns></returns>
        public static string CreateRequestXML(string transactionName, string xml, string headerApplication)
        {
            Header header = new Header();
            header.Application = headerApplication;

            StringBuilder s = new StringBuilder();
            s.Append("<OTRequest>");
            s.Append(CreateHeader(header));
            s.Append(CreateTransactionName(transactionName));
            s.Append(xml);
            s.Append(CreateIdentityInfo());
            s.Append("</OTRequest>");

            return s.ToString();
        }
        /// <summary>
        /// Create Request XML
        /// </summary>
        /// <param name="transactionName">AreaSearchRQ</param>
        /// <returns></returns>
        public static string CreateAreaSearchRQXML(string citycode)
        {
            return "<AreaSearchRQ>" +
        "<CountryCode>CN</CountryCode>" +
        "<CityCode>" + citycode + "</CityCode>" +
"</AreaSearchRQ>";
        }

        #region WebRequest
        /// <summary>
        /// 酒店系统发送请求指令,请求返回内容不进行HttpUtility.UrlDecode
        /// </summary>
        /// <param name="xml">请求指令</param>
        /// <returns></returns>
        public static string CreateRequest(string xml)
        {
            return CreateRequest(xml, false);
        }

        /// <summary>
        /// 地标发送请求指令
        /// </summary>
        /// <param name="xml">请求指令</param>
        /// <param name="isUrlDecode">返回内容是否进行HttpUtility.UrlDecode</param>
        /// <returns></returns>
        public static string CreateRequest(string xml, bool isUrlDecode)
        {
            StringBuilder responseText = new StringBuilder();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HBEURL);
            request.Timeout = WebRequestTimeout;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            Encoding encode = System.Text.Encoding.UTF8;

            byte[] bytes = encode.GetBytes("request=" + xml);
            request.ContentLength = bytes.Length;

            Stream oStreamOut = request.GetRequestStream();
            oStreamOut.Write(bytes, 0, bytes.Length);
            oStreamOut.Close();

            HttpWebResponse response = null;

            try
            {
                int i = 3;
                while (i > 0)
                {
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK) break;
                    else response = null;
                    i--;
                }
            }
            catch { response = null; }

            if (response != null)
            {
                try
                {
                    Stream resStream = null;
                    resStream = response.GetResponseStream();

                    StreamReader readStream = new StreamReader(resStream, encode);

                    Char[] read = new Char[256];
                    int count = readStream.Read(read, 0, 256);
                    while (count > 0)
                    {
                        string s = new String(read, 0, count);
                        responseText.Append(s);
                        count = readStream.Read(read, 0, 256);
                    }

                    resStream.Close();
                }
                catch { }
            }

            if (isUrlDecode)
            {
                return System.Web.HttpUtility.UrlDecode(responseText.ToString());
            }

            return responseText.ToString();
        }
        #endregion

        /// <summary>
        /// Get XAttribute Value
        /// </summary>
        /// <param name="XAttribute">xAttribute</param>
        /// <returns>Value</returns>
        public static string GetXAttributeValue(XAttribute xAttribute)
        {
            if (xAttribute == null)
                return string.Empty;

            return xAttribute.Value;
        }

        /// <summary>
        /// Get XAttribute Value
        /// </summary>
        /// <param name="xElement">XElement</param>
        /// <param name="attributeName">Attribute Name</param>
        /// <returns></returns>
        public static string GetXAttributeValue(XElement xElement, string attributeName)
        {
            return GetXAttributeValue(xElement.Attribute(attributeName));
        }

        /// <summary>
        /// Get XElement
        /// </summary>
        /// <param name="xElement">parent xElement</param>
        /// <param name="xName">xName</param>
        /// <returns>XElement</returns>
        public static XElement GetXElement(XElement xElement, string xName)
        {
            XElement x = xElement.Element(xName);

            if (x != null) return x;

            return new XElement(xName);
        }

        /// <summary>
        /// Get XElements
        /// </summary>
        /// <param name="xElement">parent xElement</param>
        /// <param name="xName">xName</param>
        /// <returns>XElements</returns>
        public static IEnumerable<XElement> GetXElements(XElement xElement, string xName)
        {
            var x = xElement.Elements(xName);
            if (x == null)
                return new List<XElement>();

            return x;
        }
        #endregion
    }
}
