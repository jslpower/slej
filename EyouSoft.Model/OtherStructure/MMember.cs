using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;
using Linq.ORM;
using Linq.ORM.Attribute;

namespace EyouSoft.Model
{
   /// <summary>
   /// 个人会员
   /// </summary>
   [Table("tbl_Member")]
   public class MMember
   {
      public MMember() { }

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
      /// 用户密码(在应用层设置时,只需设置其NoEncryptPassword属性)
      /// </summary>
      public CompanyStructure.PassWord PassWord { get; set; }

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
      public Gender Gender { get; set; }
      /// <summary>
      /// 会员昵称
      /// </summary>
      public string NickName { get; set; }
      /// <summary>
      /// 证件类型(0:None;1:身份证;2:护照;3:军官证;4:台胞证;5:港澳通行证)
      /// </summary>
      public CardType CardType { get; set; }
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
      public UserStatus MemberState { get; set; }
      /// <summary>
      /// 是否有车
      /// </summary>
      public bool IsCar { get; set; }
      /// <summary>
      /// 车辆信息
      /// </summary>
      public string CarInfo { get; set; }
   }


   /// <summary>
   /// 查询实体
   /// </summary>
   public class MSearchMember
   {
      /// <summary>
      /// 会员账号
      /// </summary>
      public string Account { get; set; }

      /// <summary>
      /// 会员姓名
      /// </summary>
      public string MemberName { get; set; }

      /// <summary>
      /// 会员昵称
      /// </summary>
      public string NickName { get; set; }

      /// <summary>
      /// 联系电话
      /// </summary>
      public string Contact { get; set; }

      /// <summary>
      /// 手机
      /// </summary>
      public string Mobile { get; set; }


      /// <summary>
      /// Email
      /// </summary>
      public string Email { get; set; }


   }


   #region 上级代理商信息业务实体
   /// <summary>
    /// 上级代理商信息业务实体
    /// </summary>
   public class MShangJiDaiLiShangInfo
   {
       /// <summary>
       /// 代理商编号
       /// </summary>
       public string DaiLiShangId { get; set; }
       /// <summary>
       /// 代理商会员编号
       /// </summary>
       public string HuiYuanId { get; set; }
       /// <summary>
       /// 代理商会员姓名
       /// </summary>
       public string HuiYuanXingMing { get; set; }
       /// <summary>
       /// 代理商域名
       /// </summary>
       public string YuMing { get; set; }
   }
   #endregion

   #region 粉丝信息业务实体
   /// <summary>
    /// 粉丝信息业务实体
    /// </summary>
   public class MFenSiInfo
   {
       /// <summary>
       /// 会员编号
       /// </summary>
       public string HuiYuanId { get; set; }
       /// <summary>
       /// 会员用户名
       /// </summary>
       public string HuiYuanYongHuMing { get; set; }
       /// <summary>
       /// 会员姓名
       /// </summary>
       public string HuiYuanXingMing { get; set; }
       /// <summary>
       /// 会员网站名称
       /// </summary>
       public string HuiYuanWangZhanName { get; set; }
       /// <summary>
       /// 会员网站域名
       /// </summary>
       public string HuiYuanYuMing { get; set; }
       /// <summary>
       /// 会员手机
       /// </summary>
       public string HuiYuanShouJi { get; set; }
       /// <summary>
       /// 会员注册时间
       /// </summary>
       public DateTime ZhuCeShiJian { get; set; }
       /// <summary>
       /// 会员到期时间
       /// </summary>
       public DateTime? DaoQiShiJian { get; set; }

       /// <summary>
       /// 会员代理商编号
       /// </summary>
       public string HuiYuanDaiLiShangId { get; set; }
   }
   #endregion

   #region 粉丝信息查询业务实体
   /// <summary>
    /// 粉丝信息查询业务实体
    /// </summary>
   public class MFenSiChaXunInfo
   {
       /// <summary>
       /// 粉丝编号（粉丝会员编号）
       /// </summary>
       public string FenSiId { get; set; }
   }
   #endregion

   #region 粉丝交易信息业务实体
   /// <summary>
    /// 粉丝交易信息业务实体
    /// </summary>
   public class MFenSiJiaoYiInfo
   {
       /// <summary>
       /// 订单编号
       /// </summary>
       public string DingDanId { get; set; }
       /// <summary>
       /// 下单时间
       /// </summary>
       public DateTime XiaDanShiJian { get; set; }
       /// <summary>
       /// 下单人编号
       /// </summary>
       public string XianDanRenId { get; set; }
       /// <summary>
       /// 订单金额
       /// </summary>
       public decimal DingDanJinE { get; set; }
       /// <summary>
       /// 订单状态
       /// </summary>
       public EyouSoft.Model.Enum.XianLuStructure.OrderStatus DingDanStatus { get; set; }
       /// <summary>
       /// 付款状态
       /// </summary>
       public EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus FuKuanStatus { get; set; }
       /// <summary>
       /// 代理商编号
       /// </summary>
       public string DaiLiShangId { get; set; }
       /// <summary>
       /// 代理商编号
       /// </summary>
       public string DaiLiShangHuiYuanId { get; set; }
       /// <summary>
       /// 代理商金额
       /// </summary>
       public decimal DaiLiShangJinE { get; set; }
       /// <summary>
       /// 下单人上级代理商编号
       /// </summary>
       public string ShangJiDaiLiShangId { get; set; }
       /// <summary>
       /// 下单人上级代理商会员编号
       /// </summary>
       public string ShangJiDaiLiShangHuiYuanId { get; set; }
       /// <summary>
       /// 客人姓名
       /// </summary>
       public string KeRenName { get; set; }
       /// <summary>
       /// 产品名称
       /// </summary>
       public string CPName { get; set; }
       /// <summary>
       /// 订单类型
       /// </summary>
       public EyouSoft.Model.OtherStructure.DingDanType DingDanLeiXing { get; set; }
       /// <summary>
       /// 下单人姓名
       /// </summary>
       public string XiaDanRenName { get; set; }
       /// <summary>
       /// 佣金金额
       /// </summary>
       public decimal YongJinJinE { get { return DingDanJinE - DaiLiShangJinE; } }
       /// <summary>
       /// 奖励比值
       /// </summary>
       public decimal JiangLiBi { get; set; }
   }
   #endregion

   #region 粉丝交易信息查询业务实体
   /// <summary>
    /// 粉丝交易信息查询业务实体
    /// </summary>
   public class MFenSiJiaoYiChaXunInfo
   {
       /// <summary>
       /// 粉丝编号（粉丝会员编号）
       /// </summary>
       public string FenSiId { get; set; }
   }
   #endregion

   #region 会员代理商信息业务实体
   /// <summary>
    /// 会员代理商信息业务实体
    /// </summary>
   public class MHuiYuanDaiLiShangInfo
   {
       /// <summary>
       /// 会员编号
       /// </summary>
       public string HuiYuanId { get; set; }
       /// <summary>
       /// 代理商编号
       /// </summary>
       public string DaiLiShangId { get; set; }
   }
   #endregion
}
