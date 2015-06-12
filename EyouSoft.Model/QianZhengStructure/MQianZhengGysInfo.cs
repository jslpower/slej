//签证供应商信息业务实体 汪奇志 2013-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.QianZhengStructure
{
    #region 签证供应商信息业务实体
    /// <summary>
    /// 签证供应商信息业务实体
    /// </summary>
    public class MQianZhengGysInfo
    {
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GysId { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 省份编号
        /// </summary>
        public int ShengFenId { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int ChengShiId { get; set; }
        /// <summary>
        /// 县区编号
        /// </summary>
        public int XianQuId { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string DiZhi { get; set; }
        /// <summary>
        /// 供应商介绍
        /// </summary>
        public string JieShao { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 创建人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 用户编号(OUTPUT)
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户名(OUTPUT)
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LxrName { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string LxrDianHua { get; set; }
        /// <summary>
        /// 联系传真
        /// </summary>
        public string Fax { get;set; }
    }
    #endregion

    #region 签证供应商查询信息业务实体
    /// <summary>
    /// 签证供应商查询信息业务实体
    /// </summary>
    public class MQianZhengGysChaXunInfo
    {
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GysName { get; set; }
    }
    #endregion
}
