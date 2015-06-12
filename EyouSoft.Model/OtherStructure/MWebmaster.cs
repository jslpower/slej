using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.ORM;
using Linq.ORM.Attribute;

namespace EyouSoft.Model
{
    ///// <summary>
    ///// 管理员信息表
    ///// </summary>
    //public class MWebmaster
    //{
    //    public MWebmaster() { }

    //    /// <summary>
    //    /// 自动编号
    //    /// </summary>
    //    public int Id { get; set; }
    //    /// <summary>
    //    /// 用户名
    //    /// </summary>
    //    public string Username { get; set; }

    //    /// <summary>
    //    /// 用户密码(在应用层设置时,只需设置其NoEncryptPassword属性)
    //    /// </summary>
    //    public CompanyStructure.PassWord PassWord { get; set; }

    //    /// <summary>
    //    /// 姓名
    //    /// </summary>
    //    public string Realname { get; set; }
    //    /// <summary>
    //    /// 联系电话
    //    /// </summary>
    //    public string Telephone { get; set; }
    //    /// <summary>
    //    /// 传真
    //    /// </summary>
    //    public string Fax { get; set; }
    //    /// <summary>
    //    /// 手机
    //    /// </summary>
    //    public string Mobile { get; set; }
    //    /// <summary>
    //    /// 角色权限，多个权限间用半角逗号间隔
    //    /// </summary>
    //    public string Permissions { get; set; }
    //    /// <summary>
    //    /// 是否启用
    //    /// </summary>
    //    public bool IsEnable { get; set; }
    //    /// <summary>
    //    /// 是否管理员
    //    /// </summary>
    //    public bool IsAdmin { get; set; }
    //    /// <summary>
    //    /// 创建时间
    //    /// </summary>
    //    public DateTime CreateTime { get; set; }
    //    /// <summary>
    //    /// 用户类型 0:webmaster 1:酒店 2:景点 3:签证
    //    /// </summary>
    //    public int LeiXing { get; set; }
    //    /// <summary>
    //    /// 供应商编号
    //    /// </summary>
    //    public string GysId { get; set; }
    //}

    /// <summary>
    /// 管理员信息表
    /// </summary>
    [Table("tbl_Webmaster")]
    public partial class MWebmaster
    {
       public MWebmaster()
       { }
       #region Model
       private int _id;
       private string _username;
       private string _password;
       private string _md5password;
       private string _realname;
       private string _telephone;
       private string _fax;
       private string _mobile;
       private int _isenable = 0;
       private int _isadmin = 0;
       private DateTime _createtime;
       private int _leixing = 0;
       private string _gysid;
       private string _permissions;
       /// <summary>
       /// 自动编号
       /// </summary>
       [PrimaryKey]
       [Identity(IdentityType.Increment)]
       public int Id
       {
          set { _id = value; }
          get { return _id; }
       }
       /// <summary>
       /// 用户名
       /// </summary>
       public string Username
       {
          set { _username = value; }
          get { return _username; }
       }
       /// <summary>
       /// 明文密码
       /// </summary>
       public string Password
       {
          set { _password = value; }
          get { return _password; }
       }
       /// <summary>
       /// MD5密码
       /// </summary>
       public string MD5Password
       {
          set { _md5password = value; }
          get { return _md5password; }
       }
       /// <summary>
       /// 姓名
       /// </summary>
       public string Realname
       {
          set { _realname = value; }
          get { return _realname; }
       }
       /// <summary>
       /// 联系电话
       /// </summary>
       public string Telephone
       {
          set { _telephone = value; }
          get { return _telephone; }
       }
       /// <summary>
       /// 传真
       /// </summary>
       public string Fax
       {
          set { _fax = value; }
          get { return _fax; }
       }
       /// <summary>
       /// 手机
       /// </summary>
       public string Mobile
       {
          set { _mobile = value; }
          get { return _mobile; }
       }
       /// <summary>
       /// 是否启用
       /// </summary>
       public int IsEnable
       {
          set { _isenable = value; }
          get { return _isenable; }
       }
       /// <summary>
       /// 1是、 0否
       /// </summary>
       public int IsAdmin
       {
          set { _isadmin = value; }
          get { return _isadmin; }
       }
       /// <summary>
       /// 创建时间
       /// </summary>
       public DateTime CreateTime
       {
          set { _createtime = value; }
          get { return _createtime; }
       }
       /// <summary>
       /// 后台用户、供应商
       /// </summary>
       public int LeiXing
       {
          set { _leixing = value; }
          get { return _leixing; }
       }
       /// <summary>
       /// 供应商编号
       /// </summary>
       public string GysId
       {
          set { _gysid = value; }
          get { return _gysid; }
       }
       /// <summary>
       /// 权限信息
       /// </summary>
       public string Permissions
       {
          set { _permissions = value; }
          get { return _permissions; }
       }
       #endregion Model
    }

    public class MWebmasterSearchModel : MWebmaster
    {
       public new int? IsAdmin { get; set; }
       public new int? IsEnable { get; set; }
       public new int? LeiXing {get;set;}
    }
}
