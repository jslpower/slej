/*
using System;
using EyouSoft.Model.Enum;
using Linq.ORM;
using Linq.ORM.Attribute;

namespace EyouSoft.Model.MoneyStructure
{
   [Table("tbl_JA_ChongZhi")]
   public partial class MChongZhi
   {
      public MChongZhi()
      { }
      #region Model
      private int _id;
      private string _userid;
      private string _jiaoyinum;
      private decimal _chongzhijine;
      private decimal _leftmoney;
      private DateTime _shijian;
      private ChongZhiWay _chongzhiway;
      private ChongZhiState _state;
      private string _desc;
      [PrimaryKey]
      [Identity(IdentityType.Increment)]
      public int ID
      {
         set { _id = value; }
         get { return _id; }
      }
      /// <summary>
      /// 充值用户
      /// </summary>
      public string UserID
      {
         set { _userid = value; }
         get { return _userid; }
      }
       /// <summary>
       /// 充值交易号
       /// </summary>
      public string JiaoYINum
      {
          set { _jiaoyinum = value; }
          get { return _jiaoyinum; }
      }
      /// <summary>
      /// 充值金额
      /// </summary>
      public decimal ChongZhiJinE
      {
         set { _chongzhijine = value; }
         get { return _chongzhijine; }
      }
      /// <summary>
      /// 剩余余额
      /// </summary>
      public decimal LeftMoney
      {
         set { _leftmoney = value; }
         get { return _leftmoney; }
      }
      /// <summary>
      /// 充值时间
      /// </summary>
      public DateTime ShiJian
      {
         set { _shijian = value; }
         get { return _shijian; }
      }
      /// <summary>
      /// 充值方式
      /// </summary>
      public ChongZhiWay ChongZhiWay
      {
         set { _chongzhiway = value; }
         get { return _chongzhiway; }
      }
      /// <summary>
      /// 未确认，已确认
      /// </summary>
      public ChongZhiState State
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