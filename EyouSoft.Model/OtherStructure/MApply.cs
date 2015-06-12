using System;
using EyouSoft.Model.Enum;
using Linq.ORM;
using Linq.ORM.Attribute;
using Linq.Bussiness;

namespace EyouSoft.Model.OtherStructure
{
    [Table("tbl_Apply")]
    public partial class MApply
    {
        public MApply()
        { }
        #region Model
        private int _id;
        private string _membername;
        private string _membermoblie;
        private MemberTypes _usercate;
        private string _companyname;
        private DateTime _applytime;
        private int _applystatus;
        [PrimaryKey]
        [Identity(IdentityType.Increment)]
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string MemberName
        {
            set { _membername = value; }
            get { return _membername; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string MemberMoblie
        {
            set { _membermoblie = value; }
            get { return _membermoblie; }
        }
        /// <summary>
        /// 公司名
        /// </summary>
        public string CompanyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        /// <summary>
        /// 申请类别
        /// </summary>
        public MemberTypes UserCate
        {
            set { _usercate = value; }
            get { return _usercate; }
        }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyTime
        {
            set { _applytime = value; }
            get { return _applytime; }
        }
        /// <summary>
        /// 申请状态
        /// </summary>
        public int ApplyStatus
        {
            set { _applystatus = value; }
            get { return _applystatus; }
        }
        #endregion Model
    }
    /// <summary>
    /// 会员申请查询实体
    /// </summary>
    public class MSearchApplyUser
    {
        public SearchModel SearchInfo { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime startime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime endtime { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string uname { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string umoblie { get; set; }
        /// <summary>
        /// 公司名
        /// </summary>
        public string ucompany { get; set; }
    }
}
