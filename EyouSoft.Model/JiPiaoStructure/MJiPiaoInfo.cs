/*//机票-机票信息业务实体 汪奇志 2013-11-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.JiPiaoStructure
{
    #region 机票-航班信息业务实体
    /// <summary>
    /// 机票-航班信息业务实体
    /// </summary>
    public class MHangBanInfo
    {
        /// <summary>
        /// 到达机场三字码
        /// </summary>
        public string ArrAirportCode { get; set; }
        /// <summary>
        /// 到达时间
        /// </summary>
        public string ArrTime { get; set; }
        /// <summary>
        /// 航空公司代码
        /// </summary>
        public string HangKongGongSiCode { get; set; }
        /// <summary>
        /// 航班班次
        /// </summary>
        public string BanCi { get; set; }
        /// <summary>
        /// 出发机场三字码
        /// </summary>
        public string DepAirportCode { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        public string DepTime { get; set; }
        /// <summary>
        /// 燃油价
        /// </summary>
        public decimal RanYouFei { get; set; }
        /// <summary>
        /// 机票价
        /// </summary>
        public decimal JiaGe { get; set; }
        /// <summary>
        /// 是否含餐
        /// </summary>
        public bool IsHanCan { get; set; }
        /// <summary>
        /// 机建费
        /// </summary>
        public decimal JiJianFei { get; set; }
        /// <summary>
        /// 舱位信息集合
        /// </summary>
        public IList<MCangWeiInfo> CangWeis { get; set; }
        /// <summary>
        /// 机型
        /// </summary>
        public string JiXing { get; set; }
        /// <summary>
        /// 到达航站楼
        /// </summary>
        public string ArrHangZhanLou { get; set; }
        /// <summary>
        /// 出发航站楼
        /// </summary>
        public string DepHangZhanLou { get; set; }
        /// <summary>
        /// 最低价舱位index
        /// </summary>
        public int ZuiDiJiaCangWeiIndex
        {
            get
            {
                if (CangWeis == null || CangWeis.Count == 0) return -1;
                int _index = 0;
                decimal _jiage = CangWeis[0].JiaGe;

                for (int i = 1; i < CangWeis.Count; i++)
                {
                    if (CangWeis[i].JiaGe < _jiage)
                    {
                        _index = i;
                        _jiage = CangWeis[i].JiaGe;
                    }
                }

                return _index;
            }
        }

        /// <summary>
        /// 航班编号
        /// </summary>
        public string HangBanId { get; set; }
        /// <summary>
        /// 航班编号-外部API
        /// </summary>
        public string ApiHangBanId { get; set; }
    }
    #endregion

    #region 机票-航班舱位信息业务实体
    /// <summary>
    /// 机票-航班舱位信息业务实体
    /// </summary>
    public class MCangWeiInfo
    {
        /// <summary>
        /// 舱位类型
        /// </summary>
        public string CangWeiCode { get; set; }
        /// <summary>
        /// 机票价格
        /// </summary>
        public decimal JiaGe { get; set; }
        /// <summary>
        /// 剩余数量
        /// </summary>
        public int ShengYuShuLiang { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal ZheKou { get; set; }
        /// <summary>
        /// 特殊政策
        /// </summary>
        public decimal TeXuZhengCe { get; set; }
    }
    #endregion
}
*/