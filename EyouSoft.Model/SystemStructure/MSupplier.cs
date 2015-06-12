using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;

namespace EyouSoft.Model.SystemStructure
{
    public class MSupplier
    {
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string ID { get; set; }
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
        /// 添加时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string OperatorID { get; set; }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 资质
        /// </summary>
        public string Qualifications { get; set; }
        /// <summary>
        /// 网址
        /// </summary>
        public string SuppULR { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string SuppAddress { get; set; }
        /// <summary>
        /// 地图位置X
        /// </summary>
        public string MapX { get; set; }
        /// <summary>
        /// 地图位置Y
        /// </summary>
        public string MapY { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string ContactPhone { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string ContactMobile { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string ContactQQ { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string ContactMail { get; set; }
        /// <summary>
        /// 登陆账号
        /// </summary>
        public string SuppName { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string SuppPwd { get; set; }

    }
    public class MSupplierSer
    {
        /// <summary>
        /// 单位名称
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 联系手机
        /// </summary>
        public string SupplierMoblie { get; set; }
    }
}
