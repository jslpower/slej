using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.MallStructure
{
    /// <summary>
    /// 商城类别
    /// </summary>
    public class MShangChengLeiBie
    {
        /// <summary>
        /// 类别编号
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 类别描述
        /// </summary>
        public string TypeDesc { get; set; }
        /// <summary>
        /// 父类别
        /// </summary>
        public int ParentID { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 添加人编号
        /// </summary>
        public int OperatorID { get; set; }
        /// <summary>
        /// 添加人姓名
        /// </summary>
        public string OperatorName { get; set; }

    }
    public class MShangChengLeiBieSer
    {
        /// <summary>
        /// 类别名称
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 添加人编号
        /// </summary>
        public string OperatorID { get; set; }
        /// <summary>
        /// 添加人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 父类别
        /// </summary>
        public int ParentID { get; set; }
    }
}
