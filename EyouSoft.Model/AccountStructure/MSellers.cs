
using Linq.ORM;
using Linq.ORM.Attribute;
using EyouSoft.Model.Enum;
namespace EyouSoft.Model.AccountStructure
{
   [Table("tbl_JA_Sellers")]
   public class MSellers
   {
      public MSellers()
      { }
      #region Model
      private string _id;
      private MemberTypes _dengji;
      private string _mapx;
      private string _mapy;
      private string _backgroundstyle;
      private string _memberid;
      private string _websitename;
      private string _website;
      private string _quanxian;
      private string _jinaolxr;
      private string _jinaotel;
      private string _jinaomobile;
      private string _jinaoweixin;
      private string _jinaoqq;
      private string _jinaophoto;
      private ShowHidden _showorhidden;
      private string _erweimaurl;
      private string _xukezhenghao;
      private string _companycontent;
      private string _companyname;
      private string _companyjc;
      private NavNum _navnum;
      private string _wapLogo;
      private string _webLogo;
      /// <summary>
      /// 分销商编号
      /// </summary>
      [PrimaryKey]
      public string ID
      {
         set { _id = value; }
         get { return _id; }
      }
      /// <summary>
      /// 1，2，3
      /// </summary>
      public MemberTypes DengJi
      {
         set { _dengji = value; }
         get { return _dengji; }
      }
      /// <summary>
      /// MapX
      /// </summary>
      public string MapX
      {
         set { _mapx = value; }
         get { return _mapx; }
      }
      /// <summary>
      /// MapY
      /// </summary>
      public string MapY
      {
         set { _mapy = value; }
         get { return _mapy; }
      }
      /// <summary>
      /// 背景样式
      /// </summary>
      public string BackGroundStyle
      {
         set { _backgroundstyle = value; }
         get { return _backgroundstyle; }
      }
      /// <summary>
      /// 会员ID
      /// </summary>
      public string MemberID
      {
         set { _memberid = value; }
         get { return _memberid; }
      }
      /// <summary>
      /// WebsiteName
      /// </summary>
      public string WebsiteName
      {
          set { _websitename = value; }
          get { return _websitename; }
      }
      /// <summary>
      /// Website域名
      /// </summary>
      public string Website
      {
          set { _website = value; }
          get { return _website; }
      }
       /// <summary>
      /// 权限
      /// </summary>
      public string QuanXian
      {
          set { _quanxian = value; }
          get { return _quanxian; }
      }
       /// <summary>
       /// 金奥联系人
       /// </summary>
      public string JinAoLXR
      {
          set { _jinaolxr = value; }
          get { return _jinaolxr; }
      }
       /// <summary>
       /// 金奥电话
       /// </summary>
      public string JinAoTel
      {
          set { _jinaotel = value; }
          get { return _jinaotel; }
      }
       /// <summary>
       /// 金奥手机
       /// </summary>
      public string JinAoMobile
      {
          set { _jinaomobile = value; }
          get { return _jinaomobile; }
      }
       /// <summary>
       /// 金奥微信
       /// </summary>
      public string JinAoWeiXin
      {
          set { _jinaoweixin = value; }
          get { return _jinaoweixin; }
      }
       /// <summary>
       /// 金奥QQ
       /// </summary>
      public string JinAoQQ
      {
          set { _jinaoqq = value; }
          get { return _jinaoqq; }
      }
       /// <summary>
       /// 金奥头像
       /// </summary>
      public string JinAoPhoto
      {
          set { _jinaophoto = value; }
          get { return _jinaophoto; }
      }
      /// <summary>
      /// 是否显示申请分销商
      /// </summary>
      public ShowHidden ShowOrHidden
      {
          set { _showorhidden = value; }
          get { return _showorhidden; }
      }
       /// <summary>
       /// 二维码路径
       /// </summary>
      public string ErWeiMaUrl
      {
          set { _erweimaurl = value; }
          get { return _erweimaurl; }
      }
       /// <summary>
       /// 许可证号
       /// </summary>
      public string XuKeZhengHao
      {
          set { _xukezhenghao = value; }
          get { return _xukezhenghao; }
      }
       /// <summary>
       /// 公司介绍
       /// </summary>
      public string CompanyContent
      {
          set { _companycontent = value; }
          get { return _companycontent; }
      }
       /// <summary>
       /// 公司名称
       /// </summary>
      public string CompanyName
      {
          set { _companyname = value; }
          get { return _companyname; }
      }
       /// <summary>
       /// 公司简称
       /// </summary>
      public string CompanyJC
      {
          set { _companyjc = value; }
          get { return _companyjc; }
      }
      /// <summary>
      /// 导航类别
      /// </summary>
      public NavNum NavNum
      {
          set { _navnum = value; }
          get { return _navnum; }
      }
      /// <summary>
      /// 供应商类型
      /// </summary>
      public SupplierType SupplierType { get; set; }
      /// <summary>
      /// 个人身份证/单位营业执照
      /// </summary>
      public string CardPath { get; set; }
      /// <summary>
      /// 户口本/经营许可证
      /// </summary>
      public string AccountPaht { get; set; }
      /// <summary>
      /// 工作名片/税务登记证
      /// </summary>
      public string VisitPath { get; set; }
      /// <summary>
      /// 其他个人证件/代码证
      /// </summary>
      public string OtherPath { get; set; }
      /// <summary>
      /// 表格资料
      /// </summary>
      public string FormPath { get; set; }
      /// <summary>
      /// 资质
      /// </summary>
      public string Qualifications { get; set; }
      /// <summary>
      /// 是否开启总代理配置
      /// </summary>
      public IsZDaiLi IsZDaiLi { get; set; }
      /// <summary>
      /// 移动端LOGO
      /// </summary>
      public string WapLogo { get; set; }
      /// <summary>
      /// 电脑端LOGO
      /// </summary>
      public string WebLogo { get; set; }
      #endregion Model

   }
}
