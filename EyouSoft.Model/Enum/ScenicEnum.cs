using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.Enum.ScenicStructure
{
    /// <summary>
    /// 景区等级
    /// </summary>
    public enum ScenicLevel
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// A = 1
        /// </summary>
        A = 1,
        /// <summary>
        /// AA
        /// </summary>
        AA,
        /// <summary>
        /// AAA
        /// </summary>
        AAA,
        /// <summary>
        /// AAAA
        /// </summary>
        AAAA,
        /// <summary>
        /// AAAAA
        /// </summary>
        AAAAA,
        /// <summary>
        /// None
        /// </summary>
        未评级 = 9,
    }





    /// <summary>
    /// 景区门票状态
    /// </summary>
    public enum ScenicTicketsStatus
    {
        /// <summary>
        /// 上架,
        /// </summary>
        上架 = 1,
        /// <summary>
        /// 下架,
        /// </summary>
        下架,

    }

    /// <summary>
    /// 景区图片类型
    /// </summary>
    public enum ScenicImgType
    {
        /// <summary>
        /// 景区形象 = 1,
        /// </summary>
        景区形象 = 1,
        /// <summary>
        /// 景区导游地图,
        /// </summary>
        景区导游地图,
        /// <summary>
        /// 其他
        /// </summary>
        其他
    }

    /// <summary>
    /// 景区门票订单订单来源
    /// </summary>
    public enum ScenicAreaOrderSource
    {
        /// <summary>
        /// 网站
        /// </summary>
        网站 = 0,
        /// <summary>
        /// 来自接口
        /// </summary>
        来自接口 = 1
    }
}
