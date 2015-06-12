using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;

namespace EyouSoft.Model.SSOStructure
{
    #region 登录用户信息业务实体
    /// <summary>
    /// 登录用户信息业务实体
    /// </summary>
    [Serializable]
    public class MUserInfo
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        public string ZhiFuPassword { get; set; }
        /// <summary>
        /// 账户剩余金额
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 账户类型
        /// </summary>
        public MemberTypes UserType { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Enum.Gender Gender { get; set; }
        /// <summary>
        /// 会员昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 证件类型(0:None;1:身份证;2:护照;3:军官证;4:台胞证;5:港澳通行证)
        /// </summary>
        public Enum.CardType CardType { get; set; }
        /// <summary>
        /// 证件号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string qq { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? RegisterTime { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// 最近登录时间
        /// </summary>
        public DateTime? LoginTime { get; set; }
        /// <summary>
        /// 最近登录IP
        /// </summary>
        public string LoginIP { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginNum { get; set; }
        /// <summary>
        /// 会员状态
        /// </summary>
        public Enum.UserStatus MemberState { get; set; }

        /// <summary>
        /// 用户在线状态
        /// </summary>
        public Enum.UserOnlineStatus OnlineStatus { get; set; }

        /// <summary>
        /// 用户会话状态标识
        /// </summary>
        public string OnlineSessionId { get; set; }

    }
    #endregion
}
