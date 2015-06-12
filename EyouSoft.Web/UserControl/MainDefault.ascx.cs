using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EyouSoft.Web.MasterPage;
using EyouSoft.Common;
using EyouSoft.BLL.SystemStructure;
using EyouSoft.Model.SystemStructure;
using System.Web.Script.Serialization;
using EyouSoft.Common.Page;
using Linq.Bussiness;
using EyouSoft.Model.HotelStructure.WebModel;
using EyouSoft.Model.Enum;
using EyouSoft.Common;
using EyouSoft.BLL.HotelStructure;


namespace EyouSoft.Web.UserControl
{
    public partial class MainDefault : System.Web.UI.UserControl
    {
        protected string MenPiaoShow = string.Empty;
        protected string GuoNeiShow = string.Empty;
        protected string ChuJingShow = string.Empty;
        protected string ZhouBianShow = string.Empty;
        protected string toplist = string.Empty;
        protected string dianlist = string.Empty;//确认个数
        private const string NoImgSrc = "<img alt=\"暂无图片\" src=\"/images/NoPic.jpg\" />";
        /// <summary>
        /// 酒店星级html
        /// </summary>
        private const string HotelStarHtml = "<img alt=\"{0}\" title=\"{0}\" src=\"/images/star.gif\" />";
        public Model.SSOStructure.MUserInfo CurrentUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.Host;
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.IDAL.AccountStructure.BSellers().GetMSellersByWebSite(url);
            if (url.IndexOf("www.slej.cn") < 0)
            {
                if (seller != null && seller.QuanXian.IndexOf("9") < 0)
                {
                    Visa.Visible = false;
                }
            }
            InitPage();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        private void InitPage()
        {
            InitMenPiao();
            InitGuoNeiRoute();

            InitHotel();
            InitZuChe();
            InitQianZheng();
            InitAd();
            InitHuiYuanShopping();

            InitCuXiao();
            InitMiaoSha();

        }
        /// <summary>
        /// 绑定页面广告
        /// </summary>
        private void InitAd()
        {
            EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv();
            //首页轮播图
            var top = bll.GetList(5, EyouSoft.Model.Enum.AdvArea.首页轮换广告);
            if (top != null && top.Count > 0)
            {
                for (int i = 0; i < top.Count; i++)
                {
                    if (i != top.Count - 1)
                    {
                        toplist += "<li style='position: absolute; left: " + (830 * i) + "px; display: block;'>"
                            + "<a target='_blank' href='" + top[i].AdvLink + "'><img src='" + top[i].ImgPath + "'></a></li>";
                    }
                    else
                    {
                        toplist += "<li style='position: absolute; left: -830px; display: block;'>"
                            + "<a target='_blank' href='" + top[i].AdvLink + "'><img src='" + top[i].ImgPath + "'></a></li>";
                    }
                    dianlist += "<li><a href='#'>" + (i + 1) + "</a></li>";
                }
            }

        }
        /// <summary>
        /// 促销初始化
        /// </summary>
        private void InitCuXiao()
        {
            var serchModel = new EyouSoft.Model.OtherStructure.MTuanGouChanPinSer();
            serchModel.SaleType = EyouSoft.Model.Enum.CuXiaoLeiXing.促销;
            serchModel.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态};
            serchModel.WeiZhi = new List<EyouSoft.Model.Enum.XianShiWeiZhi> { EyouSoft.Model.Enum.XianShiWeiZhi.网站首页, EyouSoft.Model.Enum.XianShiWeiZhi.以上全部};
            serchModel.ProductSort = 0;
            var list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetList(10, serchModel);
            CuXiao.DataSource = list;
            CuXiao.DataBind();
        }
        /// <summary>
        /// 秒杀初始化
        /// </summary>
        private void InitMiaoSha()
        {
            var serchModel = new EyouSoft.Model.OtherStructure.MTuanGouChanPinSer();
            serchModel.SaleType = EyouSoft.Model.Enum.CuXiaoLeiXing.秒杀;
            serchModel.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            serchModel.WeiZhi = new List<EyouSoft.Model.Enum.XianShiWeiZhi> { EyouSoft.Model.Enum.XianShiWeiZhi.网站首页,EyouSoft.Model.Enum.XianShiWeiZhi.以上全部}; ;
            serchModel.ProductSort = 0;
            var list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetList(10, serchModel);
            if (list.Count > 2 && list.Count % 2 != 0)
            {
                list.Remove(list[list.Count - 1]);
            }
            MiaoSha.DataSource = list;
            MiaoSha.DataBind();
        }
        /// <summary>
        /// 景区门票初始化
        /// </summary>
        private void InitMenPiao()
        {
            EyouSoft.Model.ScenicStructure.WebModel.MScenicAreaSearchModel model = new EyouSoft.Model.ScenicStructure.WebModel.MScenicAreaSearchModel();
            model.IsIndex = EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐;
            model.ProductSort = 1;
            var list = new BLL.ScenicStructure.BScenicArea().GetScenicAreaList(7, model);

            if (list != null && list.Count > 0)
            {
                MFeeSettings feesetting = new BFeeSettings().GetByType(FeeTypes.门票);
                MenPiaoShow = string.Format("<a href=\"{0}\"> {1} </a><p style=\"text-align:center;\"> <a href=\"{0}\" style=\"font-size:15px;\">{2}</a></p><p class=\"price\" style=\"font-size:15px;text-align:center;\">¥" + BHotel2.CalculateFee(list[0].SettlementPrice, list[0].WebPrice, CurrentUser.UserType, feesetting, FeeTypes.门票).ToString("0") + "起/人</p>",
                   "/YouHuiMenPiaoXiangQing.aspx?ScenicId=" + list[0].ScenicId,
                   GetScenicImg(list[0].ImgList),
                   list[0].ScenicName);
                list.RemoveAt(0);

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].FeeSetting = feesetting;
                }
                rpt_MenPiao.DataSource = list;
                rpt_MenPiao.DataBind();
            }

        }
        /// <summary>
        /// 线路
        /// </summary>
        private void InitGuoNeiRoute()
        {
            var bll = new BLL.XianLuStructure.BXianLu();
            var search = new Model.XianLuStructure.MXianLuChaXunInfo();
            search.Xianluzt = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐 };
            IList<Model.XianLuStructure.MXianLuInfo> list = null;


            #region 国内
            search.AreaTypes = new[] { Model.Enum.AreaType.国内长线 };
            // search.ZhuangTais = new[] { Model.Enum.XianLuStructure.XianLuZhuangTai.最新 };
            search.IsYouXiaoTour = true;
            list = bll.GetXianLus(7, search);
            if (list != null && list.Count > 0)
            {
                GuoNeiShow = string.Format("<a href=\"/XianLuYuDing.aspx?id={0}&type={4}\"> {1} </a><p> <a href=\"/XianLuYuDing.aspx?id={0}&type={4}\">{2}</a></p><p class=\"price\"><em>{3}</em>起</p>",
                   list[0].XianLuId,
                   GetRouteImgPath(list[0].TeSeFilePath, list[0].RouteName),
                   list[0].RouteName,
                   getHYJ(FeeTypes.国内线路, list[0].Tours),
                   (int)Model.Enum.AreaType.国内长线);
                list.RemoveAt(0);
                if (list != null && list.Count > 0)
                {
                    rpt_GuoNeiRoute.DataSource = list.OrderByDescending(t => t.LatestTime);
                    rpt_GuoNeiRoute.DataBind();
                }
            }
            #endregion

            #region 国际
            search.AreaTypes = new[] { Model.Enum.AreaType.出境线路 };
            // search.ZhuangTais = new[] { Model.Enum.XianLuStructure.XianLuZhuangTai.最新 };
            search.IsYouXiaoTour = true;
            list = bll.GetXianLus(7, search);
            if (list != null && list.Count > 0)
            {
                ChuJingShow = string.Format("<a href=\"XianLuYuDing.aspx?id={0}&type={4}\"> {1} </a><p> <a href=\"/XianLuYuDing.aspx?id={0}&type={4}\">{2}</a></p><p class=\"price\"><em>{3}</em>起</p>",
                   list[0].XianLuId,
                   GetRouteImgPath(list[0].TeSeFilePath, list[0].RouteName),
                   list[0].RouteName,
                    getHYJ(FeeTypes.国际线路, list[0].Tours),
                   (int)Model.Enum.AreaType.出境线路);
                list.RemoveAt(0);
                rpt_ChuJingRoute.DataSource = list.OrderByDescending(t => t.LatestTime);
                rpt_ChuJingRoute.DataBind();
            }
            #endregion

            #region 周边线路
            search.AreaTypes = new[] { Model.Enum.AreaType.周边短线 };
            //search.ZhuangTais = new[] { Model.Enum.XianLuStructure.XianLuZhuangTai.最新 };
            search.IsYouXiaoTour = true;
            list = bll.GetXianLus(7, search);
            if (list != null && list.Count > 0)
            {
                ZhouBianShow = string.Format("<a href=\"XianLuYuDing.aspx?id={0}&type={4}\"> {1} </a><p> <a href=\"/XianLuYuDing.aspx?id={0}&type={4}\">{2}</a></p><p class=\"price\"><em>{3}</em>起</p>",
                   list[0].XianLuId,
                   GetRouteImgPath(list[0].TeSeFilePath, list[0].RouteName),
                   list[0].RouteName,
                   getHYJ(FeeTypes.周边线路, list[0].Tours),
                   (int)Model.Enum.AreaType.周边短线);
                list.RemoveAt(0);
                rpt_ZhouBian.DataSource = list.OrderByDescending(t => t.LatestTime);
                rpt_ZhouBian.DataBind();
            }
            #endregion
        }

        /// <summary>
        /// 酒店
        /// </summary>
        private void InitHotel()
        {
            var list = new BLL.HotelStructure.BHotel2().GetHotelList(new MHotelSearchModel1 { IsHot = "1", MustHasImg = true, IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐 }, CityCode = "HGH", RuZhuRiQi = DateTime.Now.AddDays(7).Date, LiDianRiQi = DateTime.Now.Date.AddDays(8).Date, SearchInfo = new SearchModel { PageInfo = new PageInfo { PageSize = 10, PageIndex = 1 } } }, true, CurrentUser.UserType, true);
            IList<MHotelSearchModel1> _list = new List<MHotelSearchModel1>();
            for (int i = 0; i < 4 && list.Count > 4; i++)
            {
                _list.Add(list[i]);
            }
            if (list != null && list.Count > 0)
            {
                if (list.Count > 4)
                {
                    rpt_Hotel.DataSource = _list.OrderBy(x => x.ProductSort);
                }
                else
                {
                    rpt_Hotel.DataSource = list.OrderBy(x => x.ProductSort);
                }
                rpt_Hotel.DataBind();
            }

        }

        #region 酒店详情
        /// <summary>
        /// 酒店价格
        /// </summary>
        protected string InitHotelPrice(object HotelID)
        {
            if (HotelID == null || string.IsNullOrEmpty(HotelID.ToString())) return "￥0";
            var search = new Model.HotelStructure.MHotelRoomTypeSearch
            {
                HotelId = HotelID.ToString(),
                RoomName = string.Empty,
                RoomStatus = Model.Enum.HotelStatus.正常
            };
            var list = new BLL.HotelStructure.BHotelRoomType().GetHotelRoomTypeListByHotelId(1, search);
            if (list != null && list.Count > 0)
            {
                return list[0].AmountPrice.ToString("F0");
            }
            else
            {
                return "￥0";
            }

        }
        /// <summary>
        /// 酒店点评数量
        /// </summary>
        /// <param name="HotelID"></param>
        /// <returns></returns>
        protected string InitHotelDianPingSum(object HotelID)
        {
            if (HotelID == null || string.IsNullOrEmpty(HotelID.ToString())) return "￥0";
            EyouSoft.BLL.HotelStructure.BHotel bll = new EyouSoft.BLL.HotelStructure.BHotel();
            var chaXun = new EyouSoft.Model.HotelStructure.MJiuDianDianPingChaXunInfo();
            chaXun.JiuDianId = HotelID.ToString();
            chaXun.IsShenHe = true;
            int recordCount = 0;
            var list = bll.GetDianPings(20, 1, ref recordCount, chaXun);

            return recordCount.ToString();

        }
        #endregion

        /// <summary>
        /// 租车初始化
        /// </summary>
        private void InitZuChe()
        {
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun model = new EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun()
            {
                State = EyouSoft.Model.Enum.ZuCheStates.启用
            };
            model.IsIndex = EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐;
            model.PSort = 1;
            var list = bll.GetList(4, model);
            if (list != null && list.Count > 0)
            {
                rpt_ZuChe.DataSource = list;
                rpt_ZuChe.DataBind();
            }
        }

        /// <summary>
        /// 签证初始化
        /// </summary>
        private void InitQianZheng()
        {
            EyouSoft.BLL.QianZhengStructure.BQianZheng bll = new EyouSoft.BLL.QianZhengStructure.BQianZheng();
            EyouSoft.Model.QianZhengStructure.MQianZhengChaXunInfo model = new EyouSoft.Model.QianZhengStructure.MQianZhengChaXunInfo();
            model.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            var list = bll.GetTopQianZheng(8, model);
            if (list != null && list.Count > 0)
            {
                rpt_QianZheng.DataSource = list;
                rpt_QianZheng.DataBind();
            }
        }
        /// <summary>
        /// 会员商城初始化
        /// </summary>
        protected void InitHuiYuanShopping()
        {
            int recordCount = 0;
            EyouSoft.Model.MallStructure.MShangChengShangPinSer model = new EyouSoft.Model.MallStructure.MShangChengShangPinSer();
            model.isTrue = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐 };

            model.Sort = 1;
            var list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetList(8, 1, ref recordCount, model);
            if (list != null && list.Count > 0)
            {
                rpt_HuiYuanShopping.DataSource = list;
                rpt_HuiYuanShopping.DataBind();
            }
            
        }
        #region  图片处理||酒店星级||酒店分数
        /// <summary>
        /// 生成景区形象图片Html
        /// </summary>
        /// <param name="imgList"></param>
        /// <returns></returns>
        protected string GetScenicImg(object imgList)
        {
            if (imgList == null) return "<img alt=\"暂无图片\" src=\"/images/NoPic.jpg\" />";

            var list = (IList<Model.ScenicStructure.MScenicAreaImg>)imgList;

            if (!list.Any()) return "<img alt=\"暂无图片\" src=\"/images/NoPic.jpg\" />";

            var tmp = list[0];
            if (tmp == null || string.IsNullOrEmpty(tmp.Address)) return "<img alt=\"暂无图片\" src=\"/images/NoPic.jpg\" />";

            return string.Format("<img alt=\"{0}\" src=\"{1}\" />", tmp.Description, tmp.Address);
        }

        /// <summary>
        /// 处理线路图片（没有图片显示默认图片）
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        protected string GetRouteImgPath(object img, object name)
        {
            string imgPath = img.ToString();
            if (string.IsNullOrEmpty(imgPath))
            {
                return NoImgSrc;
            }
            else
            {
                return "<img src='" + imgPath + "' alt='" + Utils.ConverToStringByHtml(name.ToString()) + "' />";
            }
        }

        /// <summary>
        /// 酒店分数
        /// </summary>
        /// <param name="HotelID"></param>
        /// <returns></returns>
        protected string GetHotelFenShu(object HotelID)
        {
            if (HotelID != null && string.IsNullOrEmpty(HotelID.ToString())) return "0";
            EyouSoft.BLL.HotelStructure.BHotel bll = new EyouSoft.BLL.HotelStructure.BHotel();
            decimal manYiDu = bll.GetManYiDu(HotelID.ToString());
            if (manYiDu != 0)
            {
                return manYiDu.ToString("F2");
            }
            else
            {
                return "0";
            }
        }
        #endregion


        /// <summary>
        /// 获取商城默认图片
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string getImgs(object obj)
        {
            List<EyouSoft.Model.MallStructure.MChanPinTuPian> list = (List<EyouSoft.Model.MallStructure.MChanPinTuPian>)obj;
            if (list != null && list.Count > 0) return list[0].FilePath;
            return "";
        }

        /// <summary>
        /// 计算折扣
        /// </summary>
        /// <param name="cuxiaojia">促销价</param>
        /// <param name="yuanjia">原价</param>
        /// <returns></returns>
        protected string GetZheKou(object cuxiaojia, object yuanjia)
        {
            string zhekou = "0";
            zhekou = Convert.ToDouble(Convert.ToDouble(cuxiaojia) / Convert.ToDouble(yuanjia) * 10).ToString("f1");
            return zhekou;
        }
        /// <summary>
        /// 计算秒数
        /// </summary>
        /// <param name="datetime">时间</param>
        /// <returns></returns>
        protected string GetMiaoshu(object datetime)
        {
            string miaoshu = "0";
            if (!string.IsNullOrEmpty(datetime.ToString()) && Convert.ToDateTime(datetime).AddDays(1) > DateTime.Now)
            {
                miaoshu = Convert.ToInt32((Convert.ToDateTime(datetime).AddDays(1) - DateTime.Now).TotalSeconds).ToString();
            }
            return miaoshu;
        }
        /// <summary>
        /// 获取签证图片
        /// </summary>
        /// <param name="datetime">时间</param>
        /// <returns></returns>
        protected string GetVisaImg(object guojiaid)
        {
            string imgsrc = "";
            EyouSoft.BLL.QianZhengStructure.BQianZhengGuoJia guojiabll = new EyouSoft.BLL.QianZhengStructure.BQianZhengGuoJia();
            if (!string.IsNullOrEmpty(guojiaid.ToString()))
            {
                var list = guojiabll.GetInfo(Convert.ToInt32(guojiaid));
                imgsrc = list.FilePath;
            }
            return imgsrc;
        }

        /// <summary>
        /// 获取会员等级价格
        /// </summary>
        /// <returns></returns>
        protected string getHYJ(EyouSoft.Model.Enum.FeeTypes t, object tours)
        {
            List<EyouSoft.Model.XianLuStructure.MXianLuTourInfo> list = (List<EyouSoft.Model.XianLuStructure.MXianLuTourInfo>)tours;

            if (list == null || list.Count == 0)
            {
                return "待定";
            }
            var firstModel = list.OrderBy(m => m.JSJCR).First();
            return UtilsCommons.GetGYStijia(t, firstModel.JSJCR, firstModel.CRSCJ, MemberTypes.普通会员).ToString("F0");
        }
    }
}