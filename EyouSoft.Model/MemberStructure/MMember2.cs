using System;
using Linq.ORM;
using EyouSoft.Model.Enum;
using Linq.ORM.Attribute;

/// <summary>
/// 
/// </summary>
[Table("tbl_Member")]
public class MMember2
{
   /// <summary>
   /// 会员编号
   /// </summary>
   [PrimaryKey]
   public string MemberID { get; set; }
   /// <summary>
   /// 会员账号
   /// </summary>
   public string Account { get; set; }
   /// <summary>
   /// 会员姓名
   /// </summary>
   public string MemberName { get; set; }
   /// <summary>
   /// 会员密码
   /// </summary>
   public string PassWord { get; set; }
   /// <summary>
   /// MD5密码
   /// </summary>
   public string MD5Password { get; set; }
   /// <summary>
   /// 支付密码
   /// </summary>
   public string ZhiFuPassword { get; set; }
   /// <summary>
   /// 账户金额
   /// </summary>
   public decimal? TotalMoney { get; set; }
   /// <summary>
   /// 普通用户、普通会员，贵宾会员、分销商
   /// </summary>
   public MemberTypes UserType { get; set; }
   /// <summary>
   /// 手机号
   /// </summary>
   public string Mobile { get; set; }
   /// <summary>
   /// Email
   /// </summary>
   public string Email { get; set; }
   /// <summary>
   /// 地址
   /// </summary>
   public string Address { get; set; }
   /// <summary>
   /// 注册时间
   /// </summary>
   public DateTime RegisterTime { get; set; }
   /// <summary>
   /// 照片
   /// </summary>
   public string Photo { get; set; }
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
   public int? LoginNum { get; set; }
   /// <summary>
   /// 会员状态
   /// </summary>
   public UserStatus MemberState { get; set; }
   /// <summary>
   /// 用户在线状态    离线   在线
   /// </summary>
   public byte? OnlineStatus { get; set; }
   /// <summary>
   /// 用户会话状态标识
   /// </summary>
   public string OnlineSessionId { get; set; }
   /// <summary>
   /// 是否有车
   /// </summary>
   public string IsCar { get; set; }
   /// <summary>
   /// 车辆信息
   /// </summary>
   public string CarInfo { get; set; }
   /// <summary>
   /// 电话
   /// </summary>
   public string Contact { get; set; }
   /// <summary>
   /// QQ
   /// </summary>
   public string qq { get; set; }
   /// <summary>
   /// 传真
   /// </summary>
   public string Fax { get; set; }
   /// <summary>
   /// 生日
   /// </summary>
   public DateTime? BirthDate { get; set; }
   /// <summary>
   /// 性别
   /// </summary>
   public Gender? Gender { get; set; }
   /// <summary>
   /// 昵称
   /// </summary>
   public string NickName { get; set; }
   /// <summary>
   /// 卡类型
   /// </summary>
   public int? CardType { get; set; }
   /// <summary>
   /// 卡号
   /// </summary>
   public string CardNo { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
   public string Remark { get; set; }
    /// <summary>
    /// 微信号
    /// </summary>
   public string WeiXin { get; set; }
    /// <summary>
    /// 有效日期
    /// </summary>
   public DateTime? ValidDate { get; set; }

}
/// <summary>
/// 特约代理
/// </summary>
public class MTeYue
{
    /// <summary>
    /// 供应商id
    /// </summary>
    public string ID { get; set; }
    /// <summary>
    /// 会员id
    /// </summary>
    public string MemberID { get; set; }
    /// <summary>
    /// 网店名称
    /// </summary>
    public string WebsiteName { get; set; }
    /// <summary>
    /// 公司名称
    /// </summary>
    public string CompanyName { get; set; }
    /// <summary>
    /// 联系人
    /// </summary>
    public string MemberName { get; set; }
    /// <summary>
    /// 联系人手机
    /// </summary>
    public string Mobile { get; set; }
    /// <summary>
    /// 网站域名
    /// </summary>
    public string WebSite { get; set; }
}
/// <summary>
/// 我的下级分销搜索
/// </summary>
public class MTeYueSer
{
    /// <summary>
    /// 网店名称
    /// </summary>
    public string WebsiteName { get; set; }
    /// <summary>
    /// 公司名称
    /// </summary>
    public string CompanyName { get; set; }
    /// <summary>
    /// 联系人
    /// </summary>
    public string MemberName { get; set; }
    /// <summary>
    /// 联系人手机
    /// </summary>
    public string Mobile { get; set; }
    /// <summary>
    /// 是否是我的代理(1-是，2-不是，0-未选择）
    /// </summary>
    public int IsMyDaiLi { get; set; }
}