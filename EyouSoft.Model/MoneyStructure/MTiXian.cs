/*
using System;
using EyouSoft.Model.Enum;
using Linq.ORM;
using Linq.ORM.Attribute;

namespace EyouSoft.Model.MoneyStructure
{
   [Table("tbl_JA_TiXian")]
   public partial class MTiXian
   {
      public MTiXian()
      { }
      #region Model
      private int _id;
      private string _userid;
      private string _jiaoyinum;
      private decimal _tixianjine;
      private DateTime _tixianshijian;
      private TiXianWays _tixianfangshi;
      private string _account;
      private TiXianState _state;
      private string _desc;
      [PrimaryKey]
      [Identity(IdentityType.Increment)]
      public int ID
      {
         set { _id = value; }
         get { return _id; }
      }
      /// <summary>
      /// 提现用户
      /// </summary>
      public string UserID
      {
         set { _userid = value; }
         get { return _userid; }
      }
       /// <summary>
       /// 交易号
       /// </summary>
      public string JiaoYiNum
      {
          set { _jiaoyinum = value; }
          get { return _jiaoyinum; }
      }
      /// <summary>
      /// 金额
      /// </summary>
      public decimal TiXianJinE
      {
         set { _tixianjine = value; }
         get { return _tixianjine; }
      }
      /// <summary>
      /// 提现时间
      /// </summary>
      public DateTime TiXianShiJian
      {
         set { _tixianshijian = value; }
         get { return _tixianshijian; }
      }
      /// <summary>
      /// 提现方式
      /// </summary>
      public TiXianWays TiXianFangShi
      {
         set { _tixianfangshi = value; }
         get { return _tixianfangshi; }
      }
      /// <summary>
      /// 提现账户
      /// </summary>
      public string Account
      {
         set { _account = value; }
         get { return _account; }
      }
      /// <summary>
      /// 0 未确认 1 已确认
      /// </summary>
      public TiXianState State
      {
         set { _state = value; }
         get { return _state; }
      }
      /// <summary>
      /// 描述
      /// </summary>
      public string Desc
      {
         set { _desc = value; }
         get { return _desc; }
      }
      #endregion Model
   }
}
*/