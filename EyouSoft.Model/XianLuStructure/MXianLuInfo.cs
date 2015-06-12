//线路产品相关信息业务实体 汪奇志 2013-03-13
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.Model.Enum;
using System.Xml.Serialization;

namespace EyouSoft.Model.XianLuStructure
{
    #region 线路产品信息业务实体
    /// <summary>
    /// 线路产品信息业务实体
    /// </summary>
    public class MXianLuInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MXianLuInfo() { }

        /// <summary>
        /// 线路编号
        /// </summary>
        public string XianLuId { get; set; }
        /// <summary>
        /// 线路区域
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 行程天数
        /// </summary>
        public int TianShu { get; set; }
        /// <summary>
        /// 出发地省份编号
        /// </summary>
        public int DepProvinceId { get; set; }
        /// <summary>
        /// 出发地城市编号
        /// </summary>
        public int DepCityId { get; set; }
        /// <summary>
        /// 目的地省份编号
        /// </summary>
        public int ArrProvinceId { get; set; }
        /// <summary>
        /// 目的地城市编号
        /// </summary>
        public int ArrCityId { get; set; }
        /// <summary>
        /// 计划人数
        /// </summary>
        public int JiHuaRenShu { get; set; }
        /// <summary>
        /// 市场价-成人
        /// </summary>
        public decimal SCJCR { get; set; }
        /// <summary>
        /// 市场价-儿童
        /// </summary>
        public decimal SCJET { get; set; }
        /// <summary>
        /// 结算价-成人
        /// </summary>
        public decimal JSJCR { get; set; }
        /// <summary>
        /// 结算价-儿童
        /// </summary>
        public decimal JSJET { get; set; }
        /// <summary>
        /// 提前X天报名
        /// </summary>
        public int TingTianShu { get; set; }
        /// <summary>
        /// 出发交通
        /// </summary>
        public string ChuFaJiaoTong { get; set; }
        /// <summary>
        /// 返程交通
        /// </summary>
        public string FanChengJiaoTong { get; set; }
        /// <summary>
        /// 集合方式
        /// </summary>
        public string JiHeFangShi { get; set; }
        /// <summary>
        /// 特色描述文字
        /// </summary>
        public string TeSe { get; set; }
        /// <summary>
        /// 特色描述图片
        /// </summary>
        public string TeSeFilePath { get; set; }
        /// <summary>
        /// 途径
        /// </summary>
        public string TuJing { get; set; }
        /// <summary>
        /// 签证资料
        /// </summary>
        public string QianZheng { get; set; }
        /// <summary>
        /// 签证说明
        /// </summary>
        public string QianZhengFilePath { get; set; }
        /// <summary>
        /// 关注数
        /// </summary>
        public int GuanZhuShu { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LxrName { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string LxrTelephone { get; set; }
        /// <summary>
        /// 联系人QQ
        /// </summary>
        public string LxrQQ { get; set; }
        /// <summary>
        /// 联系人手机
        /// </summary>
        public string LxrMobile { get; set; }
        /// <summary>
        /// description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// keywords
        /// </summary>
        public string Keywords { get; set; }
        /// <summary>
        /// 发布人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 修改人编号
        /// </summary>
        public int LatestId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime LatestTime { get; set; }
        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId { get; set; }
        /// <summary>
        /// 线路行程信息集合
        /// </summary>
        public List<MXianLuXingChengInfo> XingChengs { get; set; }
        /// <summary>
        /// 服务标准信息业务实体
        /// </summary>
        public MXianLuFuWuInfo FuWu { get; set; }
        /// <summary>
        /// 线路主题集合
        /// </summary>
        public List<MXianLuZhuTiInfo> ZhuTis { get; set; }
        /// <summary>
        /// 线路状态集合
        /// </summary>
        public List<XianLuZhuangTai> ZhuangTais { get; set; }
        /// <summary>
        /// 发班信息集合
        /// </summary>
        public List<MXianLuTourInfo> Tours { get; set; }
        /// <summary>
        /// 线路产品特色图片信息集合
        /// </summary>
        public List<MFileInfo> TeSeFiles { get; set; }
        /// <summary>
        /// 团购信息集合
        /// </summary>
        public List<MXianLuTuanGouInfo> TuanGous { get; set; }


        /// <summary>
        /// 线路航班信息集合[博客]
        /// </summary>
        public List<MXianLuTourTraffice> TourTraffice { get; set; }

        /// <summary>
        /// 出发城市
        /// </summary>
        public string CFCS { get; set; }

        /// <summary>
        /// 最近出团的团队信息
        /// </summary>
        public MXianLuTourInfo LatestTour
        {
            get
            {
                if (this.Tours == null || this.Tours.Count == 0) return null;
                DateTime _today = DateTime.Today;
                MXianLuTourInfo _latestTour = null;

                foreach (var item in this.Tours)
                {
                    if (item.LDate < _today) continue;
                    if (_latestTour == null) { _latestTour = item; continue; }
                    if (item.LDate < _latestTour.LDate) _latestTour = item;
                }

                return _latestTour;
            }
        }

        /// <summary>
        /// 最近的团购信息
        /// </summary>
        public MXianLuTuanGouInfo LatestTuanGou
        {
            get
            {
                if (this.TuanGous == null || this.TuanGous.Count == 0) return null;
                DateTime _now = DateTime.Now;
                MXianLuTuanGouInfo _latestTuanGou = null;

                foreach (var item in this.TuanGous)
                {
                    if (item.ETime < _now) continue;
                    if (_latestTuanGou == null) { _latestTuanGou = item; continue; }
                    if (item.STime < _latestTuanGou.STime) _latestTuanGou = item;
                }

                return _latestTuanGou;
            }
        }

        /// <summary>
        /// 满意度
        /// </summary>
        public decimal ManYiDu { get; set; }

        /// <summary>
        /// 点评数
        /// </summary>
        public decimal DianPingShu { get; set; }

        /// <summary>
        /// 线路区域名称
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 接口编号
        /// </summary>
        public string LineID { get; set; }

        /// <summary>
        /// 线路来源
        /// </summary>
        public LineSource Line_Source
        {
            set;
            get;
        }
        /// <summary>
        /// 国内产品类型
        /// </summary>
        public LineType LineType
        {
            set;
            get;
        }
        /// <summary>
        /// 设置线路状态
        /// </summary>
        public XianLuZT xianluZT { get; set; }
    }
    #endregion

    #region 线路行程信息业务实体
    /// <summary>
    /// 线路行程信息业务实体
    /// </summary>
    public class MXianLuXingChengInfo
    {
        public MXianLuXingChengInfo() { }

        /// <summary>
        /// 区间
        /// </summary>
        public string QuJian { get; set; }
        /// <summary>
        /// 交通
        /// </summary>
        public string JiaoTong { get; set; }
        /// <summary>
        /// 住宿
        /// </summary>
        public string ZhuSu { get; set; }
        /// <summary>
        /// 用餐
        /// </summary>
        public string YongCan { get; set; }
        /// <summary>
        /// 行程内容
        /// </summary>
        public string XingCheng { get; set; }
        /// <summary>
        /// 行程图片
        /// </summary>
        public string FilePath { get; set; }
    }
    #endregion

    #region 线路服务标准信息业务实体
    /// <summary>
    /// 线路服务标准信息业务实体
    /// </summary>
    public class MXianLuFuWuInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MXianLuFuWuInfo() { }

        /// <summary>
        /// 服务标准
        /// </summary>
        public string FuWuBiaoZhun { get; set; }
        /// <summary>
        /// 不含项目
        /// </summary>
        public string BuHanXiangMu { get; set; }
        /// <summary>
        /// 购物安排
        /// </summary>
        public string GouWuAnPai { get; set; }
        /// <summary>
        /// 儿童安排
        /// </summary>
        public string ErTongAnPai { get; set; }
        /// <summary>
        /// 自费项目
        /// </summary>
        public string ZiFeiXiangMu { get; set; }
        /// <summary>
        /// 注意事项
        /// </summary>
        public string ZhuYiShiXiang { get; set; }
        /// <summary>
        /// 温馨提醒
        /// </summary>
        public string WenXinTiXing { get; set; }
        /// <summary>
        /// 报名须知
        /// </summary>
        public string BaoMingXuZhi { get; set; }
        /// <summary>
        /// 赠送项目
        /// </summary>
        public string ZengSongXiangMu { get; set; }
        /// <summary>
        /// 其他事项
        /// </summary>
        public string QiTaShiXiang { get; set; }
    }
    #endregion

    #region 线路发班信息业务实体
    /// <summary>
    /// 线路发班信息业务实体
    /// </summary>
    public partial class MXianLuTourInfo
    {
        public MXianLuTourInfo() { }
        /// <summary>
        /// 线路编号
        /// </summary>
        public string XianLuID { get; set; }
        /// <summary>
        /// 团队编号
        /// </summary>
        public string TourId { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public DateTime LDate { get; set; }
        /// <summary>
        /// 回程日期
        /// </summary>
        public DateTime RDate { get; set; }
        /// <summary>
        /// 收客状态
        /// </summary>
        public ShouKeZhuangTai Status { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public int DingDanShu { get; set; }
        /// <summary>
        /// 已收人数
        /// </summary>
        public int YiShouRenShu { get; set; }
        /// <summary>
        /// 实收人数
        /// </summary>
        public int ShiShouRenShu { get; set; }

        /// <summary>
        /// 结算价-成人
        /// </summary>
        public decimal JSJCR { get; set; }
        /// <summary>
        /// 结算价-儿童
        /// </summary>
        public decimal JSJET { get; set; }
        /// <summary>
        /// 剩余人数
        /// </summary>
        public int SYRS { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        public string TrafficId { get; set; }
        /// <summary>
        /// 市场价-成人-针对接口数据
        /// </summary>
        public decimal CRSCJ { get; set; }
        /// <summary>
        /// 市场价-儿童-针对接口数据
        /// </summary>
        public decimal ETSCJ { get; set; }


    }
    #endregion

    #region 线路主题信息业务实体
    /// <summary>
    /// 线路主题信息业务实体
    /// </summary>
    public class MXianLuZhuTiInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MXianLuZhuTiInfo() { }

        /// <summary>
        /// 主题编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 主题名称
        /// </summary>
        public string Name { get; set; }
    }
    #endregion

    #region 线路查询信息业务实体
    /// <summary>
    /// 线路产品查询信息业务实体
    /// </summary>
    public class MXianLuChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MXianLuChaXunInfo() { }

        /// <summary>
        /// 出团起始时间
        /// </summary>
        public DateTime? SLDate { get; set; }
        /// <summary>
        /// 出团截止时间
        /// </summary>
        public DateTime? ELDate { get; set; }
        /// <summary>
        /// 天数
        /// </summary>
        public int? TianShu { get; set; }
        /// <summary>
        /// 线路状态
        /// </summary>
        public XianLuZhuangTai[] ZhuangTais { get; set; }
        /// <summary>
        /// 线路主题
        /// </summary>
        public int[] ZhuTis { get; set; }
        /// <summary>
        /// 线路区域
        /// </summary>
        public int[] AreaIds { get; set; }
        /// <summary>
        /// 线路区域类型
        /// </summary>
        public AreaType[] AreaTypes { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 线路主题名称
        /// </summary>
        public string ZhuTiName { get; set; }
        /// <summary>
        /// 出发地省份编号
        /// </summary>
        public int[] DepProvinceIds { get; set; }
        /// <summary>
        /// 出发地城市编号
        /// </summary>
        public int[] DepCityIds { get; set; }
        /// <summary>
        /// 目的地省份编号
        /// </summary>
        public int[] ArrProvinceIds { get; set; }
        /// <summary>
        /// 目的地城市编号
        /// </summary>
        public int[] ArrCityIds { get; set; }
        /// <summary>
        /// 是否有效团队
        /// </summary>
        public bool IsYouXiaoTour { get; set; }
        /// <summary>
        /// 是否团购产品
        /// </summary>
        public bool? IsTuanGou { get; set; }
        /// <summary>
        /// 是否有效团购
        /// </summary>
        public bool? IsYouXiaoTuanGou { get; set; }
        /// <summary>
        /// 团购起始时间
        /// </summary>
        public DateTime? TuanGouSTime { get; set; }
        /// <summary>
        /// 团购截止时间
        /// </summary>
        public DateTime? TuanGouETime { get; set; }
        /// <summary>
        /// 出发地
        /// </summary>
        public string ChuFaDi { get; set; }
        /// <summary>
        /// 排序类型 0:出团时间升序 1：出团时间降序 2：市场价成人升序 3：市场价儿童降序 4：发布日期升序 5：发布日期降序
        /// </summary>
        public int PaiXuLeiXing { get; set; }
        /// <summary>
        /// 价格开始区间
        /// </summary>
        public decimal sPrice { get; set; }
        /// <summary>
        /// 价格结束区间
        /// </summary>
        public decimal ePrice { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public LineSource? LineSource { get; set; }
        /// <summary>
        /// 是否只显示有发班信息的团队
        /// </summary>
        public bool isNoTour { get; set; }
        /// <summary>
        /// 线路状态筛选
        /// </summary>
        public XianLuZT[] Xianluzt { get; set; }
    }
    #endregion

    #region 图片信息业务实体
    /// <summary>
    /// 图片信息业务实体
    /// </summary>
    public class MFileInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MFileInfo() { }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string MiaoShu { get; set; }
    }
    #endregion

    #region  线路团购信息业务实体
    /// <summary>
    /// 线路团购信息业务实体
    /// </summary>
    public partial class MXianLuTuanGouInfo
    {
        public MXianLuTuanGouInfo() { }
        /// <summary>
        /// 团购编号
        /// </summary>
        public string TuanGouId { get; set; }
        /// <summary>
        /// 线路编号
        /// </summary>
        public string XianLuId { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime STime { get; set; }
        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime ETime { get; set; }
        /// <summary>
        /// 成团人数
        /// </summary>
        public int RenShu { get; set; }
        /// <summary>
        /// 市场价-成人
        /// </summary>
        public decimal SCJCR { get; set; }
        /// <summary>
        /// 市场价-儿童
        /// </summary>
        public decimal SCJET { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal ZheKou { get; set; }
        /// <summary>
        /// 结算价-成人
        /// </summary>
        public decimal JSJCR { get; set; }
        /// <summary>
        /// 结算价-儿童
        /// </summary>
        public decimal JSJET { get; set; }
        /// <summary>
        /// 团购详情
        /// </summary>
        public string XiangQing { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 修改人编号
        /// </summary>
        public int LatestId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime LatestTime { get; set; }
        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId { get; set; }

        /// <summary>
        /// 团购名称
        /// </summary>
        public string TuanName { get; set; }
        /// <summary>
        /// 简要描述
        /// </summary>
        public string JianYaoMiaoShu { get; set; }
        /// <summary>
        /// 团购图片路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 团购图片信息集合
        /// </summary>
        public List<MFileInfo> Files { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public int DingDanShu { get; set; }
        /// <summary>
        /// 已收人数
        /// </summary>
        public int YiShouRenShu { get; set; }
        /// <summary>
        /// 实收人数
        /// </summary>
        public int ShiShouRenShu { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
    }
    #endregion

    #region 线路点评信息业务实体
    /// <summary>
    /// 线路点评信息业务实体
    /// </summary>
    public class MXianLuDianPing
    {
        /// <summary>
        /// 点评编号
        /// </summary>
        public string DianPingId { get; set; }
        /// <summary>
        /// 线路编号
        /// </summary>
        public string XianLuId { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 归来时间
        /// </summary>
        public DateTime? GuiLaiShiJian { get; set; }
        /// <summary>
        /// 出游人数
        /// </summary>
        public int ChuYouRenShu { get; set; }
        /// <summary>
        /// 住宿
        /// </summary>
        public DianPingStatus? ZhuShu { get; set; }
        /// <summary>
        /// 交通
        /// </summary>
        public DianPingStatus? JiaoTong { get; set; }
        /// <summary>
        /// 导游
        /// </summary>
        public DianPingStatus? DaoYou { get; set; }
        /// <summary>
        /// 行程
        /// </summary>
        public DianPingStatus? XingCheng { get; set; }
        /// <summary>
        /// 预定过程
        /// </summary>
        public DianPingStatus? YuDingGuoCheng { get; set; }
        /// <summary>
        /// 满意度
        /// </summary>
        public decimal ManYiDu { get; set; }
        /// <summary>
        /// 点评方式
        /// </summary>
        public DianPingType DianPingFangShi { get; set; }

        /// <summary>
        /// 点评内容
        /// </summary>
        public string DianPingContet { get; set; }
        /// <summary>
        /// 排序方式
        /// </summary>
        public int SortId { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsCheck { get; set; }

        /// <summary>
        /// 操作员编号
        /// </summary>
        public string OperatorId { get; set; }

        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 点评时间
        /// </summary>
        public DateTime IssueTime { get; set; }

    }

    /// <summary>
    /// 线路点评搜索实体
    /// </summary>
    public class MDianPingSeach
    {
        /// <summary>
        /// 线路编号
        /// </summary>
        public string RouteName { get; set; }

        /// <summary>
        /// 点评人
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 线路点评开始时间
        /// </summary>
        public DateTime? BeginDianPingTime { get; set; }

        /// <summary>
        /// 线路点评借宿时间
        /// </summary>
        public DateTime? EndDianPingTime { get; set; }

        /// <summary>
        /// 是否审核
        /// </summary>
        public bool? IsCheck { get; set; }


        /// <summary>
        /// 操作员编号(用于会员搜索)
        /// </summary>
        public string OperatorId { get; set; }
    }


    #endregion

    #region 线路团购查询信息业务实体
    /// <summary>
    /// 线路团购查询信息业务实体
    /// </summary>
    public class MXianLuTuanGouChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MXianLuTuanGouChaXunInfo() { }

        /// <summary>
        /// 团购名称
        /// </summary>
        public string TuanName { get; set; }

        /// <summary>
        /// 线路编号
        /// </summary>
        public string XianLuId { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 团购开始时间
        /// </summary>
        public DateTime? STime { get; set; }
        /// <summary>
        /// 团购结束时间
        /// </summary>
        public DateTime? ETime { get; set; }
    }
    #endregion

    /// <summary>
    /// 线路来源
    /// </summary>
    public enum LineSource
    {
        系统 = 0,
        博客,
        欢途,
        省中旅,
        光大,
        旅游圈
    }
    /// <summary>
    /// 国内产品类型
    /// </summary>
    public enum LineType
    {
        长线 = 0,
        短线,
        出境
    }


    /// <summary>
    /// 线路发班信息业务实体
    /// </summary>
    public partial class MXianLuTourTraffice
    {

        /// <summary>
        /// 线路编号
        /// </summary>
        public string TourId { get; set; }

        /// <summary>
        /// 航班号
        /// </summary>
        public string TrafficId { get; set; }


        /// <summary>
        /// 去程信息
        /// </summary>
        public string Traffic_01 { get; set; }


        /// <summary>
        /// 回程信息
        /// </summary>
        public string Traffic_02 { get; set; }
    }


}
