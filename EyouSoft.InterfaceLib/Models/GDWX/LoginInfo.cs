using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Enums.GDWX;
using System.ComponentModel;

namespace EyouSoft.InterfaceLib.Models.GDWX
{
    [XmlRoot("login")]
    public class LoginInfo
    {
        /// <summary>
        /// 用户 ID 
        /// </summary>
        public int id;
        /// <summary>
        /// 用户名 
        /// </summary>
        public string username;
        /// <summary>
        /// 姓名 
        /// </summary>
        public string realname;
        /// <summary>
        ///  性别 
        /// </summary>
        [DefaultValue(Sex.男)]
        public Sex sex;
        /// <summary>
        /// 省 
        /// </summary>
        public int province_id;
        /// <summary>
        /// 市 
        /// </summary>
        public int city_id;
        /// <summary>
        /// 区 
        /// </summary>
        public int area_id;
        /// <summary>
        /// 地址 
        /// </summary>
        public string addr;
        public string email;
        public string phone;
        public string tel;
        /// <summary>
        /// 昵称 
        /// </summary>
        public string nickname;
        /// <summary>
        /// 职务 
        /// </summary>
        public string job;
        /// <summary>
        /// 传真 
        /// </summary>
        public string fax;
        public string qq;
        /// <summary>
        /// 公司信息
        /// </summary>
        public Company company;
    }
}
