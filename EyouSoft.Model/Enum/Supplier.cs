using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.Enum
{
    public enum SupplierType
    {
        /// <summary>
        /// 
        /// </summary>
        个人供应商 = 0,
        单位供应商
    }

    #region 代理商商品状态 20141203
    public enum ProductZT
    {
        /// <summary>
        /// 默认状态
        /// </summary>
        上架 = 0,
        /// <summary>
        /// 线路下架
        /// </summary>
        下架,
        /// <summary>
        /// 首页推荐
        /// </summary>
        首页推荐,
        /// <summary>
        /// 暂无该商品
        /// </summary>
        暂无该商品,
    }
    #endregion
}
