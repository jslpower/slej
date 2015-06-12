using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.GDWX
{
   [XmlRoot("customize")]
    public class LiangShenDingZhi
    {
        /// <summary>
        /// 序号 
        /// </summary>
        public int id;
        /// <summary>
        /// 类型 
        /// </summary>
        public int type;
        public string realname;
        public string phone;
        public int num1;
        public int num2;
        public int num3;
        public string dates;
        public string addr;
        public string content;
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime add_time;
        /// <summary>
        /// 添加人 ID
        /// </summary>
        public int user_id;
        /// <summary>
        /// 状态
        /// </summary>
        public int state;
        /// <summary>
        /// 管理员备注
        /// </summary>
        public string admin_content;
        /// <summary>
        /// 审核时间
        /// </summary>
        public string state_time;

    }
}
