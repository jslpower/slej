using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.WeiXin
{
    public class MWinXin
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 服务ID
        /// </summary>
        public string OpenID { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string MemberID { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 绑定账号
        /// </summary>
        public string AccountNum { get; set; }
        /// <summary>
        /// 微店地址
        /// </summary>
        public string ShopUrl { get; set; }
        /// <summary>
        /// 绑定事件
        /// </summary>
        public DateTime BindTime { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
    }
}
