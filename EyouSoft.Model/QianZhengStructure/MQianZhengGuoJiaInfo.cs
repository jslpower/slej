//签证国家信息业务实体 汪奇志 2013-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.QianZhengStructure
{
    #region 签证国家信息业务实体
    /// <summary>
    /// 签证国家信息业务实体
    /// </summary>
    public class MQianZhengGuoJiaInfo
    {
        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId { get; set; }
        /// <summary>
        /// 洲
        /// </summary>
        public EyouSoft.Model.Enum.QianZhengStructure.Zhou Zhou { get; set; }
        /// <summary>
        /// 中文名
        /// </summary>
        public string Name1 { get; set; }
        /// <summary>
        /// 英文名
        /// </summary>
        public string Name2 { get; set; }
        /// <summary>
        /// 全拼
        /// </summary>
        public string PY1 { get; set; }
        /// <summary>
        /// 简拼
        /// </summary>
        public string PY2 { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 国旗FilePath
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 是否热门
        /// </summary>
        public bool IsReiMen { get; set; }
    }
    #endregion

    #region 签证国家查询信息业务实体
    /// <summary>
    /// 签证国家查询信息业务实体
    /// </summary>
    public class MQianZhengGuoJiaChaXunInfo
    {
        /// <summary>
        /// 洲
        /// </summary>
        public EyouSoft.Model.Enum.QianZhengStructure.Zhou? Zhou { get; set; }
        /// <summary>
        /// 是否热门
        /// </summary>
        public bool? IsReiMen { get; set; }
    }
    #endregion
}
