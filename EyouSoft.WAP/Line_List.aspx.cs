using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.Enum;
using EyouSoft.Model.XianLuStructure;
using System.Text;

namespace EyouSoft.WAP
{
    public partial class Line_List : Common.Page.WebPageBase
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 8;
        protected string toplist = string.Empty;//轮播广告
        protected string dianlist = string.Empty;//确认个数
        #endregion
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            initList();

            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);

        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initList()
        {

            var chufalist = new EyouSoft.BLL.XianLuStructure.BXianLu().getChuFaCitys();
            StringBuilder strChuFa = new StringBuilder();
            if (chufalist.Any())
            {
                foreach (var item in chufalist)
                {
                    strChuFa.AppendFormat(" <a class=\"city_a\" data-cityid=\"{0}\" href=\"javascript:;\">{1}</a>", item.Id, item.Name);
                }
            }
            ltrChuFas.Text = strChuFa.ToString();

            EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
            EyouSoft.Model.XianLuStructure.MXianLuChaXunInfo searchmodel = new EyouSoft.Model.XianLuStructure.MXianLuChaXunInfo();
            searchmodel.Xianluzt = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            searchmodel.isNoTour = true;
            string routeName = Utils.GetQueryStringValue("keyword");
            searchmodel.RouteName = routeName == "目的地或关键词" ? "" : routeName;
            searchmodel.SLDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("stime"));
            searchmodel.ELDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("etime"));
            searchmodel.TianShu = Utils.GetIntNull(Utils.GetQueryStringValue("days"));
            searchmodel.sPrice = Utils.GetDecimal(Utils.GetQueryStringValue("sprice"));
            searchmodel.ePrice = Utils.GetDecimal(Utils.GetQueryStringValue("eprice"));
            string source = Utils.GetQueryStringValue("source");
            if (!string.IsNullOrEmpty(source))
            {
                searchmodel.LineSource = (LineSource)Utils.GetInt(source);
            }
            int cityid = Utils.GetInt(Utils.GetQueryStringValue("cityid"));
            if (cityid > 0)
            {
                searchmodel.DepCityIds = new int[] { cityid };
            }
            else
            {
                var citymodel = EyouSoft.Security.Membership.UserProvider.GetCityInfo();
                if (citymodel != null && citymodel.Id > 0)
                {
           
                    searchmodel.DepCityIds = new int[] { citymodel.Id };
                }
            }
            int areatype = Utils.GetInt(Utils.GetQueryStringValue("type"));
            int areaid = Utils.GetInt(Utils.GetQueryStringValue("area"));
            if (areatype == 3) WapHeader1.HeadText = "周边短线";
            if (areatype == 1) WapHeader1.HeadText = "国内长线";
            if (areatype == 2) WapHeader1.HeadText = "出境线路";

            if (areaid > 0)
            {
                searchmodel.AreaIds = new int[] { areaid };
            }

            if (areatype > 0)
            {
                searchmodel.AreaTypes = new AreaType[] { (AreaType)areatype };
            }


            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);



            #region 设置分享标题
            StringBuilder strFenXiangStr = new StringBuilder();
            if (!string.IsNullOrEmpty(searchmodel.RouteName)) strFenXiangStr.AppendFormat("{0}旅游专线", searchmodel.RouteName);//设置专线名称
            if (searchmodel.TianShu > 0) strFenXiangStr.AppendFormat("_{0}天", searchmodel.TianShu);//设置天数
            if (cityid > 0)//设置出发地
            {
                var cityModel = new EyouSoft.BLL.OtherStructure.BSysAreaInfo().GetSysCityModel(cityid);
                if (cityModel != null) strFenXiangStr.AppendFormat("_{0}出发", cityModel.Name);
            }
            if (areaid > 0)//设置线路区域
            {
                var areaModel = new BLL.OtherStructure.BSysAreaInfo().GetSysAreaModel(areaid);
                if (areaModel != null) strFenXiangStr.AppendFormat("_{0}", areaModel.AreaName);
            }
            string _wxTitle = strFenXiangStr.ToString().Trim('_');
            #endregion






            var arealist = new BLL.OtherStructure.BSysAreaInfo().GetSysAreaList(10000, new EyouSoft.Model.MSysArea() { RouteType = (AreaType)areatype });
            System.Text.StringBuilder strbu = new System.Text.StringBuilder();
            if (arealist != null && arealist.Count > 0)
            {
                foreach (var item in arealist)
                {
                    strbu.AppendFormat("<li class=\"areali\" id=\"{0}\">{1}</li>", item.ID, item.AreaName);
                }
            }
            litFenlei.Text = strbu.ToString();

            IList<MXianLuInfo> list = bll.GetXianLus(pageSize, pageIndex, ref recordCount, searchmodel);






            if (list != null && list.Count > 0)
            {
                #region 设置微信分享链接
                FenXiangBiaoTi = !string.IsNullOrEmpty(_wxTitle) ? _wxTitle : WapHeader1.HeadText;
                FenXiangMiaoShu = Utils.InputText(list[0].Description);
                FenXiangTuPianFilepath = "http://" + Request.Url.Host + TuPian.F1(list[0].TeSeFilePath, 640, 400, list[0].XianLuId);
                #endregion

                rptlist.DataSource = list;
                rptlist.DataBind();

            }
            FenXiangLianJie =  Utils.redirectUrl(HttpContext.Current.Request.Url.ToString());



        }
        /// <summary>
        /// 获取城市名称
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string getCityName(object obj)
        {
            int cid = Utils.GetInt(obj.ToString());
            if (cid == 0) return "杭州";
            var model = new EyouSoft.BLL.OtherStructure.BSysAreaInfo().GetSysCityModel(cid);
            if (model == null) return "杭州";
            return model.Name;
        }
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
            BackHtml.Append("<span class=\"font_yellow\">");
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
        /// 获取会员等级价格
        /// </summary>
        /// <returns></returns>
        protected string getHYJ(string pType, string t, object tours)
        {
            List<EyouSoft.Model.XianLuStructure.MXianLuTourInfo> list = (List<EyouSoft.Model.XianLuStructure.MXianLuTourInfo>)tours;

            if (list == null || list.Count == 0)
            {
                return "待定";
            }
            var firstModel = list.OrderBy(m => m.JSJCR).First();
            EyouSoft.Model.Enum.FeeTypes type = EyouSoft.Model.Enum.FeeTypes.周边线路;
            if (t == "3") type = EyouSoft.Model.Enum.FeeTypes.周边线路;
            if (t == "1") type = EyouSoft.Model.Enum.FeeTypes.国内线路;
            if (t == "2") type = EyouSoft.Model.Enum.FeeTypes.国际线路;
            if (pType == "门市")
                return firstModel.CRSCJ.ToString("C0");
            else
                return UtilsCommons.GetGYStijia(type, firstModel.JSJCR, firstModel.CRSCJ, MemberTypes.普通会员).ToString("C0");
        }
        /// <summary>
        /// 返回景区图片
        /// </summary>
        /// <param name="objStr"></param>
        /// <returns></returns>
        protected string getImgSrc(object objStr, string xianluid)
        {
            string defaultImg = "/images/NoPic.jpg";
            if (objStr == null) return defaultImg;
            string src = objStr.ToString();
            if (string.IsNullOrEmpty(src)) return defaultImg;
            return TuPian.F1(src, 320, 240, xianluid);
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
