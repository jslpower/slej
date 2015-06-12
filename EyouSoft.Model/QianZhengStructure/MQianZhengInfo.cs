//签证信息业务实体 汪奇志 2013-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.QianZhengStructure
{
    #region 签证信息业务实体
    /// <summary>
    /// 签证信息业务实体
    /// </summary>
    public class MQianZhengInfo
    {
        /// <summary>
        /// 签证编号
        /// </summary>
        public string QianZhengId { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GysId { get; set; }
        /// <summary>
        /// 签证名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 国家编号
        /// </summary>
        public int GuoJiaId { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal JiaGe { get; set; }
        /// <summary>
        /// 门市价
        /// </summary>
        public decimal JiaGeMenShi { get; set; }
        /// <summary>
        /// 办理时间
        /// </summary>
        public string BanLiShiJian { get; set; }
        /// <summary>
        /// 有效期(天)
        /// </summary>
        public int YouXiaoQi { get; set; }
        /// <summary>
        /// 停留时间(天)
        /// </summary>
        public int TingLiuShiJian { get; set; }
        /// <summary>
        /// 签证面试
        /// </summary>
        public string MianShi { get; set; }
        /// <summary>
        /// 邀请函
        /// </summary>
        public string YaoQingHan { get; set; }
        /// <summary>
        /// 所属领区
        /// </summary>
        public string SuoShuLingQu { get; set; }
        /// <summary>
        /// 受理范围
        /// </summary>
        public string ShouLiFanWei { get; set; }
        /// <summary>
        /// 所需材料
        /// </summary>
        public string SuoXuCaiLiao { get; set; }
        /// <summary>
        /// 特别提示
        /// </summary>
        public string TeBieTiShi { get; set; }
        /// <summary>
        /// 注意事项
        /// </summary>
        public string ZhuYiShiXiang { get; set; }
        /// <summary>
        /// 发布人编号
        /// </summary>
        public int FaBuRenId { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LatestTime { get; set; }
        /// <summary>
        /// 签证类型
        /// </summary>
        public EyouSoft.Model.Enum.QianZhengStructure.QianZhengLeiXing QianZhengLeiXing { get; set; }
        /// <summary>
        /// 是否分销
        /// </summary>
        public bool IsFenXiao { get; set; }
        /// <summary>
        /// 签证附件材料
        /// </summary>
        public string FileUpLoad { get; set; }
        /// <summary>
        /// 首页显示（上架、下架）
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.XianLuZT IsIndex { get; set; }
    }
    #endregion

    #region 签证查询信息业务实体
    /// <summary>
    /// 签证查询信息业务实体
    /// </summary>
    public class MQianZhengChaXunInfo
    {
        /// <summary>
        /// 国家编号
        /// </summary>
        public int? GuoJiaId { get; set; }
        /// <summary>
        /// 发布人编号
        /// </summary>
        public int? FaBuRenId { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GysId { get; set; }
        /// <summary>
        /// 签证名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 所属区域
        /// </summary>
        public string SuoShuLingQu { get; set; }
        /// <summary>
        /// 所属范围
        /// </summary>
        public string ShouLiFanWei { get; set; }
        /// <summary>
        /// 签证类型
        /// </summary>
        public EyouSoft.Model.Enum.QianZhengStructure.QianZhengLeiXing? QianZhengLeiXing { get; set; }
        /// <summary>
        /// 是否分销
        /// </summary>
        public bool? IsFenXiao { get; set; }

        /// <summary>
        /// 首页显示（上架、下架）
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.XianLuZT[] IsIndex { get; set; }
    }
    #endregion
}
