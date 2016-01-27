using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;

namespace EyouSoft.Model.MallStructure
{
    public class MShangChengShangPin
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 类型编号
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int ProductNum { get; set; }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal MarketPrice { get; set; }
        /// <summary>
        /// 优惠价/结算价
        /// </summary>
        public decimal SalePrice { get; set; }
        /// <summary>
        /// 包含服务
        /// </summary>
        public string ContentService { get; set; }
        /// <summary>
        /// 不含服务
        /// </summary>
        public string UnContentService { get; set; }
        /// <summary>
        /// 使用方法
        /// </summary>
        public string UseRule { get; set; }
        /// <summary>
        /// 注意事项
        /// </summary>
        public string NoticeKnow { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? ProductionDate { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime? EffectDate { get; set; }
        /// <summary>
        /// 保质期
        /// </summary>
        public int ShelfDate { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 产品描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        public string ModelDesc { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string ColorDesc { get; set; }
        /// <summary>
        /// 款式
        /// </summary>
        public string StylesDesc { get; set; }
        /// <summary>
        /// 邮寄办法/几天后到货
        /// </summary>
        public string MailWay { get; set; }
        /// <summary>
        /// 供应商id
        /// </summary>
        public string GYSid { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }

        #region 扩展属性
        /// <summary>
        /// 库存
        /// </summary>
        public int StockNum { get; set; }
        /// <summary>
        /// 产品图片
        /// </summary>
        public List<MChanPinTuPian> ProductImgs { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 销售数量
        /// </summary>
        public int SaleNum { get { return this.ProductNum - this.StockNum; } }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.XianLuZT IsTrue { get; set; }
        #endregion
    }

    public class MShangChengShangPinSer
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 类型编号
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// 供应商id
        /// </summary>
        public string GYSid { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GYSName { get; set; }
        //是否不显示过期产品
        public bool isGetTrue { get; set; }
        /// <summary>
        /// 是否上架
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.XianLuZT[] isTrue { get; set; }
        /// <summary>
        /// 代理商Id
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// sql语句部分where条件
        /// </summary>
        public string sqlWhere { get; set; }
        /// <summary>
        /// 是否有排序（0.没有，其他都有）
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 供应商商铺名称
        /// </summary>
        public string CompanyName { get; set; }
    }


    #region 代理商产品表
    public class MDaiLiShangChanPin
    {
        /// <summary>
        /// 代理商id
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// 产品id
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 产品状态
        /// </summary>
        public EyouSoft.Model.Enum.ProductZT ProductStatus { get; set; }
    }
    #endregion
    #region 代理商产品表查询
    public class MDaiLiShangChanPinSer
    {
        /// <summary>
        /// 代理商id
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// 产品状态
        /// </summary>
        public EyouSoft.Model.Enum.ProductZT[] ProductStatus { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 类型编号
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// 是否不显示过期产品
        /// </summary>
        public bool isGetTrue { get; set; }
    }
    #endregion
}
