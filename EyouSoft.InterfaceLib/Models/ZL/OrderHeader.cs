using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.ZL
{
    /// <summary>
    /// 团队头信息
    /// </summary>
    [XmlRoot("mt-order_header", Namespace = "")]
    public class OrderHeader
    {
        [XmlElement("mt-GroupId")]
        public int GroupId;
        [XmlElement("mt-AdultNum")]
        public int AdultNum;
        [XmlElement("mt-ChildNum")]
        public int ChildNum;
        [XmlElement("mt-Linkman")]
        public string Linkman;
        [XmlElement("mt-Telphone")]
        public string Telphone;
        [XmlElement("mt-MobilePhone")]
        public string MobilePhone;
        [XmlElement("mt-Comments")]
        public string Comments;
    }
}
