using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.Model.ZuCheStructure
{
    public class MZuCheInfo
    {
        public MZuCheInfo() { }

        #region 租车产品信息业务实体
        private string _zucheid;
        private string _carname;
        private int _xianzuorenshu = 0;
        private decimal _menshijia = 0M;
        private decimal _menshijiagezuche = 0M;
        private decimal _menshichaoshi = 0M;
        private decimal _menshijiagechaoshi = 0M;
        private decimal _menshichaocheng = 0M;
        private decimal _menshijiagechaocheng = 0M;
        private decimal _youhuijia = 0M;
        private decimal _youhuijiagezuche = 0M;
        private decimal _youhuichaoshi = 0M;
        private decimal _youhuijiagechaoshi = 0M;
        private decimal _youhuichaocheng = 0M;
        private decimal _youhuijiagechaocheng = 0M;
        private int _operatorid = 0;
        private DateTime _issuetime = DateTime.Now;
        private int? _latestid;
        private DateTime? _latesttime = DateTime.Now;
        private int _identityid;
        private string _isrecommend;
        private string _remark;
        private ZuCheStates _state;
        private string _filepath;
        private decimal _menshijiagedancheng = 0M;
        private decimal _youhuijiagedancheng = 0M;
        private IList<ZuCheImg> _zucheimg;
        private XianLuZT _isindex;
        private int _productsort;

        /// <summary>
        /// 租车ID
        /// </summary>
        public string ZuCheID
        {
            set { _zucheid = value; }
            get { return _zucheid; }
        }
        /// <summary>
        /// 车辆名称
        /// </summary>
        public string CarName
        {
            set { _carname = value; }
            get { return _carname; }
        }
        /// <summary>
        /// 限坐人数
        /// </summary>
        public int XianZuoRenShu
        {
            set { _xianzuorenshu = value; }
            get { return _xianzuorenshu; }
        }
        /// <summary>
        /// 含司机包车费用-门市价
        /// </summary>
        public decimal MenShiJia
        {
            set { _menshijia = value; }
            get { return _menshijia; }
        }
        /// <summary>
        /// 含司机包车费用-单程公里数
        /// </summary>
        public decimal MenShiJiaGeZuChe
        {
            set { _menshijiagezuche = value; }
            get { return _menshijiagezuche; }
        }
        /// <summary>
        /// 含司机包车费用-超出天数门市费用
        /// </summary>
        public decimal MenShiChaoShi
        {
            set { _menshichaoshi = value; }
            get { return _menshichaoshi; }
        }
        /// <summary>
        /// 含司机包车费用-超出天数费用
        /// </summary>
        public decimal MenShiJiaGeChaoShi
        {
            set { _menshijiagechaoshi = value; }
            get { return _menshijiagechaoshi; }
        }
        /// <summary>
        /// 含司机包车费用-超程门市费用
        /// </summary>
        public decimal MenShiChaoCheng
        {
            set { _menshichaocheng = value; }
            get { return _menshichaocheng; }
        }
        /// <summary>
        /// 含司机包车费用-超程费用
        /// </summary>
        public decimal MenShiJiaGeChaoCheng
        {
            set { _menshijiagechaocheng = value; }
            get { return _menshijiagechaocheng; }
        }
        /// <summary>
        /// 单接或单送费用-门市价
        /// </summary>
        public decimal YouHuiJia
        {
            set { _youhuijia = value; }
            get { return _youhuijia; }
        }
        /// <summary>
        /// 单接或单送费用-单程公里数
        /// </summary>
        public decimal YouHuiJiaGeZuChe
        {
            set { _youhuijiagezuche = value; }
            get { return _youhuijiagezuche; }
        }
        /// <summary>
        /// 单接或单送费用-超时门市费用
        /// </summary>
        public decimal YouHuiChaoShi
        {
            set { _youhuichaoshi = value; }
            get { return _youhuichaoshi; }
        }
        /// <summary>
        /// 单接或单送费用-超时费用
        /// </summary>
        public decimal YouHuiJiaGeChaoShi
        {
            set { _youhuijiagechaoshi = value; }
            get { return _youhuijiagechaoshi; }
        }
        /// <summary>
        /// 单接或单送费用-超程门市费用
        /// </summary>
        public decimal YouHuiChaoCheng
        {
            set { _youhuichaocheng = value; }
            get { return _youhuichaocheng; }
        }
        /// <summary>
        /// 单接或单送费用-超程费用
        /// </summary>
        public decimal YouHuiJiaGeChaoCheng
        {
            set { _youhuijiagechaocheng = value; }
            get { return _youhuijiagechaocheng; }
        }
        /// <summary>
        /// 发布人编号
        /// </summary>
        public int OperatorId
        {
            set { _operatorid = value; }
            get { return _operatorid; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime IssueTime
        {
            set { _issuetime = value; }
            get { return _issuetime; }
        }
        /// <summary>
        /// 修改人编号
        /// </summary>
        public int? LatestId
        {
            set { _latestid = value; }
            get { return _latestid; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? LatestTime
        {
            set { _latesttime = value; }
            get { return _latesttime; }
        }
        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId
        {
            set { _identityid = value; }
            get { return _identityid; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public string IsRecommend
        {
            set { _isrecommend = value; }
            get { return _isrecommend; }
        }
        /// <summary>
        /// 相关说明
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public ZuCheStates State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        /// <summary>
        /// 含司机包车费用-基础费用
        /// </summary>
        public decimal MenShiJiaGeDanCheng
        {
            set { _menshijiagedancheng = value; }
            get { return _menshijiagedancheng; }
        }
        /// <summary>
        /// 单接或单送费用-基础费用
        /// </summary>
        public decimal YouHuiJiaGeDanCheng
        {
            set { _youhuijiagedancheng = value; }
            get { return _youhuijiagedancheng; }
        }
        /// <summary>
        /// 租车图片
        /// </summary>
        public IList<ZuCheImg> ZucheInfoImg
        {
            set { _zucheimg = value; }
            get { return _zucheimg; }
        }
        /// <summary>
        /// 是否首页显示
        /// </summary>
        public XianLuZT IsIndex
        {
            set { _isindex = value; }
            get { return _isindex; }
        }
        /// <summary>
        /// 序号
        /// </summary>
        public int ProductSort
        {
            set { _productsort = value; }
            get { return _productsort; }
        }
        #endregion Model
    }

    public class MZuCheInfoChaXun
    {
        public MZuCheInfoChaXun() { }
        /// <summary>
        /// 车辆名称
        /// </summary>
        public string CarName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public ZuCheStates? State { get; set; }
        /// <summary>
        /// 首页推荐
        /// </summary>
        public XianLuZT? IsIndex { get; set; }
        /// <summary>
        /// 产品排序
        /// </summary>
        public int PSort { get; set; }
    }
    public partial class ZuCheImg
    {
        public ZuCheImg()
        { }
        #region Model
        private int _imgid;
        private string _zucheid;
        private int? _imgcategory;
        private string _filepath;
        private string _desc;
        private DateTime _issuetime = DateTime.Now;
        private string _operatorid;
        /// <summary>
        /// 图片ID
        /// </summary>
        public int ImgID
        {
            set { _imgid = value; }
            get { return _imgid; }
        }
        /// <summary>
        /// 租车编号
        /// </summary>
        public string ZuCheID
        {
            set { _zucheid = value; }
            get { return _zucheid; }
        }
        /// <summary>
        /// 图片类型
        /// </summary>
        public int? ImgCategory
        {
            set { _imgcategory = value; }
            get { return _imgcategory; }
        }
        /// <summary>
        /// 路径
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc
        {
            set { _desc = value; }
            get { return _desc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime IssueTime
        {
            set { _issuetime = value; }
            get { return _issuetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OperatorId
        {
            set { _operatorid = value; }
            get { return _operatorid; }
        }
        #endregion Model

    }
}
