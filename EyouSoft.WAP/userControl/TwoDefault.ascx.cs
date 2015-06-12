using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.SystemStructure;
using EyouSoft.BLL.SystemStructure;
using EyouSoft.Model.Enum;
using EyouSoft.Model.XianLuStructure;

namespace EyouSoft.WAP.userControl
{
    public partial class TwoDefault : System.Web.UI.UserControl
    {
        private const string NoImgSrc = "<img alt=\"暂无图片\" src=\"/images/NoPic.jpg\" />";
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        private void InitPage()
        {
            InitMenPiao();
            InitGuoNeiRoute();
        }
        /// <summary>
        /// 景区门票初始化
        /// </summary>
        private void InitMenPiao()
        {
            EyouSoft.Model.ScenicStructure.WebModel.MScenicAreaSearchModel model = new EyouSoft.Model.ScenicStructure.WebModel.MScenicAreaSearchModel();
            model.IsIndex = EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐;
            model.ProductSort = 1;
            var list = new BLL.ScenicStructure.BScenicArea().GetScenicAreaList(4, model);

            if (list != null && list.Count > 0)
            {
                MFeeSettings feesetting = new BFeeSettings().GetByType(FeeTypes.门票);
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
            search.IsYouXiaoTour = true;
            list = bll.GetXianLus(4, search);
            if (list != null && list.Count > 0)
            {
                if (list != null && list.Count > 0)
                {
                    rpt_GuoNeiRoute.DataSource = list.OrderByDescending(t => t.LatestTime);
                    rpt_GuoNeiRoute.DataBind();
                }
            }
            #endregion

            #region 国际
            search.AreaTypes = new[] { Model.Enum.AreaType.出境线路 };
            search.IsYouXiaoTour = true;
            list = bll.GetXianLus(4, search);
            if (list != null && list.Count > 0)
            {
                rpt_ChuJingRoute.DataSource = list.OrderByDescending(t => t.LatestTime);
                rpt_ChuJingRoute.DataBind();
            }
            #endregion

            #region 周边线路
            search.AreaTypes = new[] { Model.Enum.AreaType.周边短线 };
            search.IsYouXiaoTour = true;
            list = bll.GetXianLus(4, search);
            if (list != null && list.Count > 0)
            {
                rpt_ZhouBian.DataSource = list.OrderByDescending(t => t.LatestTime);
                rpt_ZhouBian.DataBind();
            }
            #endregion
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

            return string.Format("<img alt=\"{0}\" src=\"{1}\" />", tmp.Description, TuPian.F1(tmp.Address,320,240));
        }

        /// <summary>
        /// 处理线路图片（没有图片显示默认图片）
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        protected string GetRouteImgPath(object img, object xianluid)
        {
            if (string.IsNullOrEmpty(img.ToString()))
            {
                return NoImgSrc;
            }
            else
            {
                return "<img src='" + TuPian.F1(img, 320, 240, xianluid.ToString()) + "' />";
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
        /// 获取最近发班日期
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string getLastDate(object obj)
        {
            List<MXianLuTourInfo> items = (List<MXianLuTourInfo>)obj;

            if (items == null) return "暂无发班信息";
            var lastList = items.OrderBy(j => j.LDate).Where(i => Utils.GetDateTime(i.LDate.ToString("yyyy-MM-dd")) > DateTime.Now).ToList();

            if (lastList == null || lastList.Count == 0) return "暂无发班信息";
            int top = 0;
            System.Text.StringBuilder BackHtml = new System.Text.StringBuilder();
            for (int i = 0; i < lastList.Count; i++)
            {
                if (i != 0 && (lastList[i].LDate == lastList[0].LDate || lastList[i].LDate == lastList[i - 1].LDate)) continue;
                top++;
                BackHtml.AppendFormat("{0},", lastList[i].LDate.ToString("MM-dd"));
                if (top == 3) break;

            }
            string bkString = BackHtml.ToString().TrimEnd(',').Replace("-", "/").Replace(",", "、");
            //bkString += string.Format("</span><br/><a href=\"/Line_Info.aspx?id={0}&type={1}\">更多团期</a> ", lastList[0].XianLuID, Utils.GetQueryStringValue("type"));
            return bkString;
        }

        /// <summary>
        /// 获取城市名称
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string getCityName(object obj)
        {
            int cid = Utils.GetInt(obj.ToString());
            if (cid == 0) return "待定";
            var model = new EyouSoft.BLL.OtherStructure.BSysAreaInfo().GetSysCityModel(cid);
            if (model == null) return "待定";
            return model.Name;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="lineType"></param>
        /// <returns></returns>
        protected string getSourceJP(object lineType)
        {
            LineSource source = (LineSource)lineType;
            if (source == LineSource.系统) return "JA";
            if (source == LineSource.博客) return "BK";
            if (source == LineSource.光大) return "GD";
            if (source == LineSource.欢途) return "HT";
            if (source == LineSource.省中旅) return "SZL";
            if (source == LineSource.旅游圈) return "LYQ";
            return "JA";
        }
    }
}