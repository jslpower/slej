/*
using System;
using Linq.ORM;
using Linq.ORM.Attribute;

namespace EyouSoft.Model.MoneyStructure
{
   [Table("tbl_JA_FanLi")]
   public partial class MFanLi
   {
      public MFanLi()
      { }
      #region Model
      private int _id;
      private string _userid;
      private decimal _fanlijine;
      private DateTime _shijian;
      private string _desc;
      private string _orderid;
      private OrderType _ordertype;
      [PrimaryKey]
      [Identity(IdentityType.Increment)]
      public int ID
      {
         set { _id = value; }
         get { return _id; }
      }
      /// <summary>
      /// 会员
      /// </summary>
      public string UserID
      {
         set { _userid = value; }
         get { return _userid; }
      }
      /// <summary>
      /// 返利金额
      /// </summary>
      public decimal FanLiJinE
      {
         set { _fanlijine = value; }
         get { return _fanlijine; }
      }
      /// <summary>
      /// 时间
      /// </summary>
      public DateTime ShiJian
      {
         set { _shijian = value; }
         get { return _shijian; }
      }
      /// <summary>
      /// 描述
      /// </summary>
      public string Desc
      {
         set { _desc = value; }
         get { return _desc; }
      }
      /// <summary>
      /// 订单ID
      /// </summary>
      public string OrderID
      {
         set { _orderid = value; }
         get { return _orderid; }
      }
      /// <summary>
      /// 
      /// </summary>
      public OrderType OrderType
      {
         set { _ordertype = value; }
         get { return _ordertype; }
      }
      #endregion Model
   }
}
*/