using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    public class MTuanGouChanPin
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 促销类型
        /// </summary>
        public EyouSoft.Model.Enum.CuXiaoLeiXing SaleType { get; set; }
        /// <summary>
        /// 产品类型
        /// </summary>
        public EyouSoft.Model.Enum.ChanPinLeiXing ProductType { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string SimpleInfo { get; set; }
        /// <summary>
        /// 详细介绍
        /// </summary>
        public string DetailInfo { get; set; }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal MarketPrice { get; set; }
        /// <summary>
        /// 促销价
        /// </summary>
        public decimal GroupPrice { get; set; }
        /// <summary>
        /// 产品数量
        /// </summary>
        public int ProductNum { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime ValiDate { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 添加人编号
        /// </summary>
        public string OperatorID { get; set; }
        /// <summary>
        /// 添加人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 产品图片
        /// </summary>
        public string ProductImg { get; set; }
        /// <summary>
        /// 销量
        /// </summary>
        public int Salevolume { get; set; }
        /// <summary>
        /// 显示位置
        /// </summary>
        public EyouSoft.Model.Enum.XianShiWeiZhi WeiZhi { get; set; }
        /// <summary>
        /// 首页显示（上架、下架）
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.XianLuZT IsIndex { get; set; }
        /// <summary>
        /// 购买人数
        /// </summary>
        public int GouMaiRenShu { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int ProductSort { get; set; }
    }
    public class MTuanGouChanPinSer
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 促销类型
        /// </summary>
        public EyouSoft.Model.Enum.CuXiaoLeiXing? SaleType { get; set; }
        /// <summary>
        /// 产品类型
        /// </summary>
        public EyouSoft.Model.Enum.ChanPinLeiXing? ProductType { get; set; }
        /// <summary>
        ///  显示位置
        /// </summary>
        public IList<EyouSoft.Model.Enum.XianShiWeiZhi> WeiZhi { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime? ValiDate { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 首页显示（上架、下架）
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.XianLuZT[] IsIndex { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? ProductSort { get; set; }
    }
}
