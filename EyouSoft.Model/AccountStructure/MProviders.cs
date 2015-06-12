using Linq.ORM;
using EyouSoft.Model.Enum;
using Linq.ORM.Attribute;
namespace EyouSoft.Model.AccountStructure
{
   [Table("tbl_JA_Providers")]
   public class MProviders : IConvertToMModel
   {
      public MProviders()
      { }
      #region Model
      private string _id;
      private string _lianxiren;
      private string _lianxidianhua;
      private string _address;
      private string _regaddress;
      private string _orgnizecode;
      private string _jingyingxukezheng;
      private string _suiwudengjizheng;
      private string _yingyezhizhao;
      private ProviderType _leixing;
      /// <summary>
      /// 供应商编号
      /// </summary>
      [PrimaryKey]
      public string ID
      {
         set { _id = value; }
         get { return _id; }
      }
      /// <summary>
      /// 
      /// </summary>
      public string LianXiRen
      {
         set { _lianxiren = value; }
         get { return _lianxiren; }
      }
      /// <summary>
      /// 
      /// </summary>
      public string LianXiDianHua
      {
         set { _lianxidianhua = value; }
         get { return _lianxidianhua; }
      }
      /// <summary>
      /// 
      /// </summary>
      public string Address
      {
         set { _address = value; }
         get { return _address; }
      }
      /// <summary>
      /// 
      /// </summary>
      public string RegAddress
      {
         set { _regaddress = value; }
         get { return _regaddress; }
      }
      /// <summary>
      /// 机构代码证
      /// </summary>
      public string OrgnizeCode
      {
         set { _orgnizecode = value; }
         get { return _orgnizecode; }
      }
      /// <summary>
      /// 
      /// </summary>
      public string JingYingXuKeZheng
      {
         set { _jingyingxukezheng = value; }
         get { return _jingyingxukezheng; }
      }
      /// <summary>
      /// 
      /// </summary>
      public string SuiWuDengJiZheng
      {
         set { _suiwudengjizheng = value; }
         get { return _suiwudengjizheng; }
      }
      /// <summary>
      /// 
      /// </summary>
      public string YingYeZhiZhao
      {
         set { _yingyezhizhao = value; }
         get { return _yingyezhizhao; }
      }
      /// <summary>
      /// 2  企业供应商 1个体供应商
      /// </summary>
      public ProviderType LeiXing
      {
         set { _leixing = value; }
         get { return _leixing; }
      }
      #endregion Model

   }
}
