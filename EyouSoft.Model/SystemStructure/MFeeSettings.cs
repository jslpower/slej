using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.ORM;
using EyouSoft.Model.Enum;
using Linq.ORM.Attribute;

namespace EyouSoft.Model.SystemStructure
{
   [Table("tbl_JA_FeeSettings")]
   public partial class MFeeSettings : IConvertToMModel
   {
      public MFeeSettings()
      { }
      #region Model
      private int _id;
      private FeeTypes _leibie;
      private decimal _putonghuiyuanjia;
      private decimal _guibinjia;
      private decimal _fenxiaojia;
      private decimal _yuangongjia;
      private DateTime _updatetime;
      private decimal _freefenxiaojia;
      /// <summary>
      /// 编号
      /// </summary>
      [PrimaryKey]
      [Identity(IdentityType.Increment)]
      public int ID
      {
         set { _id = value; }
         get { return _id; }
      }
      /// <summary>
      /// 所属分类
      /// </summary>
      public FeeTypes LeiBie
      {
         set { _leibie = value; }
         get { return _leibie; }
      }
      /// <summary>
      /// 普通会员价提升比
      /// </summary>
      public decimal PuTongHuiYuanJia
      {
         set { _putonghuiyuanjia = value; }
         get { return _putonghuiyuanjia; }
      }
      /// <summary>
      /// 贵宾价提升比
      /// </summary>
      public decimal GuiBinJia
      {
         set { _guibinjia = value; }
         get { return _guibinjia; }
      }
      /// <summary>
      /// 免费分销价提升比
      /// </summary>
      public decimal FreeFenXiaoJia
      {
         set { _freefenxiaojia = value; }
         get { return _freefenxiaojia; }
      }
      /// <summary>
      /// 分销价提升比
      /// </summary>
      public decimal FenXiaoJia
      {
         set { _fenxiaojia = value; }
         get { return _fenxiaojia; }
      }
      /// <summary>
      /// 员工价提升比
      /// </summary>
      public decimal YuanGongJia
      {
         set { _yuangongjia = value; }
         get { return _yuangongjia; }
      }
      /// <summary>
      /// 最后更新时间
      /// </summary>
      public DateTime UpdateTime
      {
         set { _updatetime = value; }
         get { return _updatetime; }
      }
      #endregion Model
   }
}
