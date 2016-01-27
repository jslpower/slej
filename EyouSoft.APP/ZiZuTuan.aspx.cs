using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using Newtonsoft.Json.Converters;
using EyouSoft.Model.SystemStructure;
using EyouSoft.BLL.SystemStructure;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.WAP
{
    public partial class ZiZuTuan : Common.Page.WebPageBase
    {
        protected string defaultHBID = "-1";
        protected string defaultHB = "";
        protected int routeType = 0;
        protected string jiagelist = "";
        protected string ZaoCanList = "";
        protected string WuCanList = "";
        protected string WanCanList = "";
        protected string RSBXList = "";
        protected string JTBXList = "";
        protected decimal crjiage = 0;//线路成人门市价
        protected decimal etjiage = 0;//线路儿童门市价
        protected decimal crjiesuan = 0;//线路成人结算价
        protected decimal etjiesuan = 0;//线路儿童结算价
        protected int usertp = 1;//会员类型
        protected string RsBxJiage = string.Empty;
        protected string JtBxJiage = string.Empty;
        protected bool isShow = true;
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "组团报价";
            if (Utils.GetQueryStringValue("islogin") == "1") getLoginState();
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "save")
            {
                OrderSub();
            }
            int type = Utils.GetInt(Utils.GetQueryStringValue("type"), 1);
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("id")) && type != 0)
            {
                initPage();
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            if (new EyouSoft.IDAL.AccountStructure.BSellers().WebSiteShowOrHidden(Request.Url.Host.ToLower().Replace("m.", "")) == ShowHidden.隐藏)
            {
                isShow = false;
            }

            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void initPage()
        {
            #region 判断登陆
            Model.SSOStructure.MUserInfo userInfo = null;
            bool islogin = Security.Membership.UserProvider.IsLogin(out userInfo);
            #endregion
            string xianluid = Utils.GetQueryStringValue("id");
            string TourId = Utils.GetQueryStringValue("tid");
            string hangban = Utils.GetQueryStringValue("hangban");
            string strScript = string.Empty;
            var model = new EyouSoft.BLL.XianLuStructure.BXianLu().GetInfo(xianluid);
            if (model != null)
            {
                //if (model.Line_Source == EyouSoft.Model.XianLuStructure.LineSource.光大)
                //{
                //    lit_Line.Text = "出团编号：";
                //}
                XLXianLuId.Value = xianluid;
                var areaType = new BLL.OtherStructure.BSysAreaInfo().GetSysAreaModel(model.AreaId);
                if (areaType != null)
                {
                    routeType = (int)areaType.RouteType;
                }

                if (model.Line_Source != EyouSoft.Model.XianLuStructure.LineSource.系统) model = new EyouSoft.InterfaceLib.APITour().SyncTour(model);

                bool isxianshi = false;
                if (model.TourTraffice.Any() && model.TourTraffice.Count > 0)//光大的线路的话取航班
                {
                    isxianshi = true;
                }

                if (isxianshi)
                {
                    #region 航班信息
                    StringBuilder strHB = new StringBuilder();//显示发班信息

                    if (model.TourTraffice != null && model.TourTraffice.Count > 0)
                    {

                        foreach (var item in model.TourTraffice)
                        {
                            if (!string.IsNullOrEmpty(hangban) && item.TrafficId == hangban)
                            {
                                strHB.AppendFormat("<li class=\"on\" data-value=\"{0}\" data-hb=\"hangban\"><p><em class=\"font_yellow\">始</em>{1}</p><p><em class=\"font_yellow\">返</em>{2}</p></li>", item.TrafficId, item.Traffic_01, item.Traffic_02);
                                defaultHBID = item.TrafficId;
                                HangBanXinXI.Text = item.Traffic_01 + "-" + item.Traffic_02;
                                HangBanId.Value = item.TrafficId;
                            }
                            else
                            {
                                strHB.AppendFormat("<li data-value=\"{0}\" data-hb=\"hangban\"><p><em class=\"font_yellow\">始</em>{1}</p><p><em class=\"font_yellow\">返</em>{2}</p></li>", item.TrafficId, item.Traffic_01, item.Traffic_02);
                            }

                        }
                        if (string.IsNullOrEmpty(hangban))
                        {
                            HangBanXinXI.Text = model.TourTraffice[0].Traffic_01 + "-" + model.TourTraffice[0].Traffic_02;
                            HangBanId.Value = model.TourTraffice[0].TrafficId;
                            defaultHBID = model.TourTraffice[0].TrafficId;
                            strHB.Replace("data-value=\"" + model.TourTraffice[0].TrafficId + "\"", "class=\"on\" data-value=\"" + model.TourTraffice[0].TrafficId + "\"");
                        }
                    }
                    litHangBan.Text = strHB.ToString();
                    #endregion
                    PlaceHolder2.Visible = true;
                }

                lblXLMC.Text = Utils.ConverToStringByHtml(model.RouteName);
                XianLuName.Text = XianLuTitle.Value = Utils.ConverToStringByHtml(model.RouteName);

                EyouSoft.Model.SystemStructure.MFeeSettings bilv = new EyouSoft.Model.SystemStructure.MFeeSettings();
                EyouSoft.Model.Enum.FeeTypes FeeType = EyouSoft.Model.Enum.FeeTypes.组团;

                decimal crMsj = 0;
                decimal etMsj = 0;

                #region 价格等级显示




                string JiageDengji = "";
                JiageDengji = "<div class=\"paddT\">会员价：成人价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + UtilsCommons.GetGYStijia(FeeType, model.JSJCR, model.SCJCR, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + UtilsCommons.GetGYStijia(FeeType, model.JSJET, model.SCJET, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongHuiYuanMoney\" >0</span>  元</div>";
                //JiageDengji = "<div class=\"paddT\">门市价：成人价 <span class=\"font_yellow\" data-name=\"MenShiMoney\">" + model.SCJCR.ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"MenShiMoney\">" + model.SCJET.ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongMenShiMoney\" >0</span>  元</div>";
                if (userInfo != null)
                {
                    //if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.普通会员)
                    //{
                    //    JiageDengji = "<div class=\"paddT\">门市价：成人价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + model.SCJCR.ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + model.SCJET.ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongHuiYuanMoney\" >0</span>  元</div>";
                    //}
                    if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                    {
                        JiageDengji = "<div class=\"paddT\">贵宾价：成人价 <span class=\"font_yellow\" data-name=\"GuiBingMoney\">" + UtilsCommons.GetGYStijia(FeeType, model.JSJCR, model.SCJCR, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"GuiBingMoney\">" + UtilsCommons.GetGYStijia(FeeType, model.JSJET, model.SCJET, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongGuiBingMoney\" >0</span>  元</div>";
                    }
                    else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                    {
                        JiageDengji = "<div class=\"paddT\">代销价：成人价 <span class=\"font_yellow\" data-name=\"DaiXiaoMoney\">" + UtilsCommons.GetGYStijia(FeeType, model.JSJCR, model.SCJCR, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"DaiXiaoMoney\">" + UtilsCommons.GetGYStijia(FeeType, model.JSJET, model.SCJET, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongDaiXiaoMoney\" >0</span>  元</div>";
                    }
                    else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理)
                    {
                        JiageDengji = "<div class=\"paddT\">代理价：成人价 <span class=\"font_yellow\" data-name=\"DaiLiMoney\">" + UtilsCommons.GetGYStijia(FeeType, model.JSJCR, model.SCJCR, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"DaiLiMoney\">" + UtilsCommons.GetGYStijia(FeeType, model.JSJET, model.SCJET, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongDaiLiMoney\" >0</span>  元</div>";
                    }
                    else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                    {
                        JiageDengji = "<div class=\"paddT\">员工价：成人价 <span class=\"font_yellow\" data-name=\"YuanGongMoney\">" + UtilsCommons.GetGYStijia(FeeType, model.JSJCR, model.SCJCR, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"YuanGongMoney\">" + UtilsCommons.GetGYStijia(FeeType, model.JSJET, model.SCJET, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongYuanGongMoney\" >0</span>  元</div>";
                    }
                }
                crjiage = model.SCJCR;
                etjiage = model.SCJET;
                crjiesuan = model.JSJCR;
                etjiesuan = model.JSJET;
                #endregion

                var chufadi = new EyouSoft.BLL.OtherStructure.BSysAreaInfo().GetSysCityModel(model.DepCityId);
                if (chufadi == null)//出发地
                {
                    cfd.Text = "杭州";
                }
                else
                {
                    cfd.Text = chufadi.Name;
                }

                #region 发班信息
                int yiShouRenShu = 0;

                if (model.Tours != null && model.Tours.Count > 0)
                {
                    var s = new StringBuilder();
                    var items = model.Tours.Where(m => m.LDate >= DateTime.Now).ToList();
                    int myday = 0;
                    foreach (var item in items)
                    {
                        yiShouRenShu += item.YiShouRenShu;
                        if (item.LDate <= DateTime.Today) continue;
                        if (item.TrafficId != defaultHBID && isxianshi) continue;//只取一个航班号
                        if (item.TourId == TourId)
                        {
                            YouWanXinXi.Text = item.LDate.ToString("MM-dd") + "(" + Utils.ConvertWeekDayToChinese(item.LDate) + ")  (拼团价 成人:" + item.CRSCJ.ToString("F0") + "/人 儿童:" + item.ETSCJ.ToString("F0") + "/人)";
                            s.AppendFormat("<li class=\"on\" data-value=\"{0}\" data-riqi=\"{1}\" data-day=\"youwan\">", item.TourId, item.LDate.ToString("yyyy-MM-dd"));
                            #region  如果选择游发班日期 刷新页面价格信息
                            JiageDengji = "<div class=\"paddT\">会员价：成人价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongHuiYuanMoney\" >0</span>  元</div>";
                            //JiageDengji = "<div class=\"paddT\">门市价：成人价 <span class=\"font_yellow\" data-name=\"MenShiMoney\">" + model.SCJCR.ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"MenShiMoney\">" + model.SCJET.ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongMenShiMoney\" >0</span>  元</div>";
                            if (userInfo != null)
                            {
                                //if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.普通会员)
                                //{
                                //    JiageDengji = "<div class=\"paddT\">门市价：成人价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + model.SCJCR.ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + model.SCJET.ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongHuiYuanMoney\" >0</span>  元</div>";
                                //}
                                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                                {
                                    JiageDengji = "<div class=\"paddT\">贵宾价：成人价 <span class=\"font_yellow\" data-name=\"GuiBingMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"GuiBingMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongGuiBingMoney\" >0</span>  元</div>";
                                }
                                else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                                {
                                    JiageDengji = "<div class=\"paddT\">代销价：成人价 <span class=\"font_yellow\" data-name=\"DaiXiaoMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"DaiXiaoMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongDaiXiaoMoney\" >0</span>  元</div>";
                                }
                                else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理)
                                {
                                    JiageDengji = "<div class=\"paddT\">代理价：成人价 <span class=\"font_yellow\" data-name=\"DaiLiMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"DaiLiMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongDaiLiMoney\" >0</span>  元</div>";
                                }
                                else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                {
                                    JiageDengji = "<div class=\"paddT\">员工价：成人价 <span class=\"font_yellow\" data-name=\"YuanGongMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"YuanGongMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongYuanGongMoney\" >0</span>  元</div>";
                                }
                            }
                            crjiage = item.CRSCJ;
                            etjiage = item.ETSCJ;
                            crjiesuan = item.JSJCR;
                            etjiesuan = item.JSJET;
                            #endregion
                            YouWanId.Value = item.TourId;
                        }
                        else
                        {
                            s.AppendFormat("<li data-value=\"{0}\" data-riqi=\"{1}\" data-day=\"youwan\">", item.TourId, item.LDate.ToString("yyyy-MM-dd"));
                            if (myday == 0)
                            {
                                #region  如果选择游发班日期 刷新页面价格信息
                                JiageDengji = "<div class=\"paddT\">会员价：成人价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongHuiYuanMoney\" >0</span>  元</div>";
                                //JiageDengji = "<div class=\"paddT\">门市价：成人价 <span class=\"font_yellow\" data-name=\"MenShiMoney\">" + model.SCJCR.ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"MenShiMoney\">" + model.SCJET.ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongMenShiMoney\" >0</span>  元</div>";
                                if (userInfo != null)
                                {
                                    //if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.普通会员)
                                    //{
                                    //    JiageDengji = "<div class=\"paddT\">门市价：成人价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + model.SCJCR.ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + model.SCJET.ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongHuiYuanMoney\" >0</span>  元</div>";
                                    //}
                                    if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                                    {
                                        JiageDengji = "<div class=\"paddT\">贵宾价：成人价 <span class=\"font_yellow\" data-name=\"GuiBingMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"GuiBingMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongGuiBingMoney\" >0</span>  元</div>";
                                    }
                                    else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                                    {
                                        JiageDengji = "<div class=\"paddT\">代销价：成人价 <span class=\"font_yellow\" data-name=\"DaiXiaoMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"DaiXiaoMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongDaiXiaoMoney\" >0</span>  元</div>";
                                    }
                                    else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理)
                                    {
                                        JiageDengji = "<div class=\"paddT\">代理价：成人价 <span class=\"font_yellow\" data-name=\"DaiLiMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"DaiLiMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongDaiLiMoney\" >0</span>  元</div>";
                                    }
                                    else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                    {
                                        JiageDengji = "<div class=\"paddT\">员工价：成人价 <span class=\"font_yellow\" data-name=\"YuanGongMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"YuanGongMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongYuanGongMoney\" >0</span>  元</div>";
                                    }
                                }
                                crjiage = item.CRSCJ;
                                crjiesuan = item.JSJCR;
                                etjiage = item.ETSCJ;
                                etjiesuan = item.JSJET;
                                #endregion
                            }

                        }
                        s.AppendFormat("{0}({1})  (拼团价", item.LDate.ToString("MM-dd"), Utils.ConvertWeekDayToChinese(item.LDate));
                        s.AppendFormat(" 成人:{0}/人", item.CRSCJ.ToString("F0"));
                        s.AppendFormat(" 儿童:{0}/人)", item.ETSCJ.ToString("F0"));
                        s.Append("</li>");
                        myday++;
                    }
                    if (string.IsNullOrEmpty(TourId))
                    {
                        YouWanXinXi.Text = items[0].LDate.ToString("MM-dd") + "(" + Utils.ConvertWeekDayToChinese(items[0].LDate) + ")  (拼团价 成人:" + items[0].CRSCJ.ToString("F0") + "/人 儿童:" + items[0].ETSCJ.ToString("F0") + "/人)";
                        YouWanId.Value = items[0].TourId;
                        s = s.Replace("data-value=\"" + YouWanId.Value + "\"", "class=\"on\" data-value=\"" + YouWanId.Value + "\"");
                        foreach (var item in items)
                        {
                            if (item.LDate <= DateTime.Today)
                            {
                                continue;
                            }
                            else
                            {
                                if (item.TrafficId != defaultHBID && isxianshi)
                                {
                                    continue;//只取一个航班号
                                }
                                else
                                {
                                    #region  如果没有选择发班日期 默认第一个日期

                                    XianLuMonth.Text = XianLuChuMonth.Value = (Convert.ToDateTime(item.LDate).Month).ToString();
                                    XianLuYear.Text = XianLuChuYear.Value = (Convert.ToDateTime(item.LDate).Year).ToString();
                                    XianLuDay.Text = XianLuChuDay.Value = (Convert.ToDateTime(item.LDate).Day).ToString();
                                    XLTourId.Value = item.TourId;

                                    JiageDengji = "<div class=\"paddT\">会员价：成人价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongHuiYuanMoney\" >0</span>  元</div>";
                                    //JiageDengji = "<div class=\"paddT\">门市价：成人价 <span class=\"font_yellow\" data-name=\"MenShiMoney\">" + model.SCJCR.ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"MenShiMoney\">" + model.SCJET.ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongMenShiMoney\" >0</span>  元</div>";
                                    if (userInfo != null)
                                    {
                                        //if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.普通会员)
                                        //{
                                        //    JiageDengji = "<div class=\"paddT\">门市价：成人价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + model.SCJCR.ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"HuiYuanMoney\">" + model.SCJET.ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongHuiYuanMoney\" >0</span>  元</div>";
                                        //}
                                        if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                                        {
                                            JiageDengji = "<div class=\"paddT\">贵宾价：成人价 <span class=\"font_yellow\" data-name=\"GuiBingMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"GuiBingMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongGuiBingMoney\" >0</span>  元</div>";
                                        }
                                        else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                                        {
                                            JiageDengji = "<div class=\"paddT\">代销价：成人价 <span class=\"font_yellow\" data-name=\"DaiXiaoMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"DaiXiaoMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongDaiXiaoMoney\" >0</span>  元</div>";
                                        }
                                        else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理)
                                        {
                                            JiageDengji = "<div class=\"paddT\">代理价：成人价 <span class=\"font_yellow\" data-name=\"DaiLiMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"DaiLiMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongDaiLiMoney\" >0</span>  元</div>";
                                        }
                                        else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                        {
                                            JiageDengji = "<div class=\"paddT\">员工价：成人价 <span class=\"font_yellow\" data-name=\"YuanGongMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0") + "</span>  元/人</div><div style=\"padding-left:56px;\">儿童价 <span class=\"font_yellow\" data-name=\"YuanGongMoney\">" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0") + "</span>  元/人</div><div>总　计： <span class=\"font_yellow\" data-name=\"ZongYuanGongMoney\" >0</span>  元</div>";
                                        }
                                    }

                                    crjiage = item.CRSCJ;
                                    etjiage = item.ETSCJ;
                                    crjiesuan = item.JSJCR;
                                    etjiesuan = item.JSJET;
                                    #endregion
                                    break;
                                }
                            }
                        }
                    }
                    //string scripts = string.Format("pageData.dataBox={0};", Newtonsoft.Json.JsonConvert.SerializeObject(model.Tours));
                    IsoDateTimeConverter isDate = new IsoDateTimeConverter();
                    isDate.DateTimeFormat = "yyyy-M-d";
                    var olist = model.Tours.Where(m => m.LDate >= DateTime.Now).ToList();
                    List<seraModel> nlist = new List<seraModel>();
                    if (olist != null && olist.Count > 0)
                    {
                        for (int i = 0; i < olist.Count; i++)
                        {
                            if (olist[i].TrafficId != defaultHBID && isxianshi) continue;//只取一个航班号
                            nlist.Add(new seraModel() { tid = olist[i].TourId, hyj = UtilsCommons.GetGYStijia(FeeType, olist[i].JSJCR, olist[i].CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0"), ldate = olist[i].LDate, msj = olist[i].CRSCJ.ToString("F0"), yw = olist[i].SYRS });

                        }
                    }
                    if (s.Length > 0) ltrFaBanOptions.Text = s.ToString();
                }
                JiaGeDengJiList.Text = JiageDengji;
                #endregion
            }

            if (TourId != "")
            {
                DateTime Ldate = new EyouSoft.BLL.XianLuStructure.BXianLu().GetTourInfo(TourId).LDate;
                XianLuMonth.Text = XianLuChuMonth.Value = (Ldate.Month).ToString();
                XianLuYear.Text = XianLuChuYear.Value = (Ldate.Year).ToString();
                XianLuDay.Text = XianLuChuDay.Value = (Ldate.Day).ToString();
                XLTourId.Value = TourId;
            }
            int areatype = routeType;
            EyouSoft.Model.Enum.AreaType[] areaArr = null;
            if (areatype > 0)
            {
                areaArr = new EyouSoft.Model.Enum.AreaType[] { (EyouSoft.Model.Enum.AreaType)areatype };
            }

            EyouSoft.Model.OtherStructure.MZuTuan zutuanmodel = new EyouSoft.BLL.OtherStructure.BZuTuan().GetModel();
            if (zutuanmodel != null)
            {
                MFeeSettings feeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.组团);
                //ZaoCanMoney.Value = Convert.ToDecimal(zutuanmodel.ZaoCanMoney).ToString("f2");

                decimal discount = 0;//该用户提价比
                if (islogin)
                {
                    var userType = userInfo.UserType;
                    switch (userType)
                    {
                        case EyouSoft.Model.Enum.MemberTypes.未注册用户:
                            break;
                        case EyouSoft.Model.Enum.MemberTypes.员工:
                            discount = feeSettings.YuanGongJia;
                            usertp = 5;
                            break;
                        case EyouSoft.Model.Enum.MemberTypes.普通会员:
                            discount = feeSettings.PuTongHuiYuanJia;
                            usertp = 1;
                            break;
                        case EyouSoft.Model.Enum.MemberTypes.贵宾会员:
                            discount = feeSettings.GuiBinJia;
                            usertp = 2;
                            break;
                        case EyouSoft.Model.Enum.MemberTypes.代理:
                            discount = feeSettings.FenXiaoJia;
                            usertp = 4;
                            break;
                        case EyouSoft.Model.Enum.MemberTypes.免费代理:
                            discount = feeSettings.FreeFenXiaoJia;
                            usertp = 3;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    discount = feeSettings.PuTongHuiYuanJia;
                }
                if (routeType == 1)//长线
                {
                    BiaoZhunNum.Value = zutuanmodel.CXRS.ToString();
                    DaoYouMoney.Value = Convert.ToDecimal(zutuanmodel.MSDaoYouMoney).ToString("f2");
                    DaoYouMoneyCB.Value = Convert.ToDecimal(zutuanmodel.DaoYouMoney).ToString("f2");
                    DiPeiDaoYou.Value = Convert.ToDecimal(zutuanmodel.MSDiPeiDaoYou).ToString("f2");
                    DiPeiDaoYouCB.Value = Convert.ToDecimal(zutuanmodel.DiPeiDaoYou).ToString("f2");
                }
                else if (routeType == 2)//出境
                {
                    BiaoZhunNum.Value = zutuanmodel.CJRS.ToString();
                    DaoYouMoney.Value = Convert.ToDecimal(zutuanmodel.MSCJDaoYouMoney).ToString("f2");
                    DaoYouMoneyCB.Value = Convert.ToDecimal(zutuanmodel.CJDaoYouMoney).ToString("f2");
                    DiPeiDaoYou.Value = Convert.ToDecimal(zutuanmodel.MSCJDiPeiDaoYou).ToString("f2");
                    DiPeiDaoYouCB.Value = Convert.ToDecimal(zutuanmodel.CJDiPeiDaoYou).ToString("f2");
                }
                else//短线
                {
                    BiaoZhunNum.Value = zutuanmodel.DXRS.ToString();
                    DaoYouMoney.Value = Convert.ToDecimal(zutuanmodel.MSDXDaoYouMoney).ToString("f2");
                    DaoYouMoneyCB.Value = Convert.ToDecimal(zutuanmodel.DXDaoYouMoney).ToString("f2");
                    DiPeiDaoYou.Value = Convert.ToDecimal(zutuanmodel.MSDXDiPeiDaoYou).ToString("f2");
                    DiPeiDaoYouCB.Value = Convert.ToDecimal(zutuanmodel.DXDiPeiDaoYou).ToString("f2");
                }
                ZuiDiRenShu.Text = BiaoZhunNum.Value;
                ZuiDiRenShu1.Text = BiaoZhunNum.Value;
                ZuiDiRS.Text = BiaoZhunNum.Value;
                ZuiDiNum.Text = BiaoZhunNum.Value;

                string[] zaocanjia = zutuanmodel.ZaoCanMoney.Split(',');
                string[] zaocanmenshi = zutuanmodel.MSZaoCanMoney.Split(',');
                ZaoCanList += "<a href=\"javascript:void(0);\" class=\"on\" data-class=\"zaocanc\" data-value=\"0\" data-cb=\"0\">不增加</a>";
                for (int i = 0; i < zaocanmenshi.Length; i++)
                {
                    //decimal jiage = Convert.ToDecimal(zaocanjia[i]) + (Convert.ToDecimal(zaocanmenshi[i]) - Convert.ToDecimal(zaocanjia[i])) * discount / 100;

                    ZaoCanList += "<a href=\"javascript:void(0);\" data-class=\"zaocanc\" data-value=\"" + zaocanmenshi[i] + "\" data-cb=\"" + zaocanjia[i] + "\">" + zaocanmenshi[i] + "</a>";
                }
                string[] wucanjia = zutuanmodel.WuCanMoney.Split(',');
                string[] wucanmenshi = zutuanmodel.MSWuCanMoney.Split(',');
                WuCanList += "<a href=\"javascript:void(0);\" class=\"on\" data-class=\"wucanc\" data-value=\"0\" data-cb=\"0\">不增加</a>";
                for (int i = 0; i < wucanmenshi.Length; i++)
                {
                    //decimal jiage = Convert.ToDecimal(wucanjia[i]) + (Convert.ToDecimal(wucanmenshi[i]) - Convert.ToDecimal(wucanjia[i])) * discount / 100;
                    WuCanList += "<a href=\"javascript:void(0);\" data-class=\"wucanc\" data-value=\"" + wucanmenshi[i] + "\" data-cb=\"" + wucanjia[i] + "\" >" + wucanmenshi[i] + "</a>";
                }
                string[] wancanjia = zutuanmodel.WanCanMoney.Split(',');
                string[] wancanmenshi = zutuanmodel.MSWanCanMoney.Split(',');
                WanCanList += "<a href=\"javascript:void(0);\" class=\"on\" data-class=\"wancanc\" data-value=\"0\" data-cb=\"0\">不增加</a>";
                for (int i = 0; i < wancanmenshi.Length; i++)
                {
                    //decimal jiage = Convert.ToDecimal(wancanjia[i]) + (Convert.ToDecimal(wancanmenshi[i]) - Convert.ToDecimal(wancanjia[i])) * discount / 100;
                    WanCanList += "<a href=\"javascript:void(0);\" data-class=\"wancanc\" data-value=\"" + wancanmenshi[i] + "\" data-cb=\"" + wancanjia[i] + "\" >" + wancanmenshi[i] + "</a>";
                }
                string[] renshenjia = zutuanmodel.RSYiWai.Split(',');
                string[] renshenmenshi = zutuanmodel.MSRSYiWai.Split(',');
                RSBXList += "<a href=\"javascript:void(0);\" class=\"on\" data-class=\"rsbxc\" data-value=\"0\" data-cb=\"0\">不增加</a>";
                for (int i = 0; i < renshenmenshi.Length; i++)
                {
                    //decimal jiage = Convert.ToDecimal(renshenjia[i]) + (Convert.ToDecimal(renshenmenshi[i]) - Convert.ToDecimal(renshenjia[i])) * discount / 100;
                    RSBXList += "<a href=\"javascript:void(0);\" data-class=\"rsbxc\" data-value=\"" + renshenmenshi[i] + "\" data-cb=\"" + renshenjia[i] + "\">" + renshenmenshi[i] + "元/人天</a>";
                }
                string[] jiaotongjia = zutuanmodel.JTYiWai.Split(',');
                string[] jiaotongmenshi = zutuanmodel.MSJTYiWai.Split(',');
                JTBXList += "<a href=\"javascript:void(0);\" class=\"on\" data-class=\"jtbxc\" data-value=\"0\" data-cb=\"0\">不增加</a>";
                for (int i = 0; i < jiaotongmenshi.Length; i++)
                {
                    //decimal jiage = Convert.ToDecimal(jiaotongjia[i]) + (Convert.ToDecimal(jiaotongmenshi[i]) - Convert.ToDecimal(jiaotongjia[i])) * discount / 100;

                    JTBXList += "<a href=\"javascript:void(0);\" data-class=\"jtbxc\" data-value=\"" + jiaotongmenshi[i] + "\" data-cb=\"" + jiaotongjia[i] + "\">" + jiaotongmenshi[i] + "元/人天</a>";
                }
                CarFei.Value = Convert.ToDecimal(zutuanmodel.MSCarMoney).ToString("f2");
                CarFeiCB.Value = Convert.ToDecimal(zutuanmodel.CarMoney).ToString("f2");
                RSTianShu.Text = model.TianShu.ToString();
                lvYouTianShu.Text = LYTianShu.Value = model.TianShu.ToString();
                RsBxJiage = "0";
                JTTianShu.Text = model.TianShu.ToString();
                JtBxJiage = "0";
                ChengRenMS.Value = crjiage.ToString("f2");
                ErTongMS.Value = etjiage.ToString("f2");
                ChengRenJieSuan.Value = crjiesuan.ToString("f2");
                ErTongJieSuan.Value = etjiesuan.ToString("f2");


                #region 设置微信分享链接
                //设置图片链接
                FenXiangTuPianFilepath = string.IsNullOrEmpty(model.TeSeFilePath) ? "http://" + Request.Url.Host + " /images/line_xx001.jpg" : "http://" + Request.Url.Host + TuPian.F1(model.TeSeFilePath, 640, 400, model.XianLuId);
                FenXiangBiaoTi = model.RouteName;
                FenXiangMiaoShu = Utils.InputText(model.Description);
                #endregion

            }
            FenXiangLianJie = Utils.redirectUrl(HttpContext.Current.Request.Url.ToString());
        }
        protected string GetQuCarHtml()
        {
            StringBuilder strHtml = new StringBuilder();
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun model = new EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun()
            {
                State = EyouSoft.Model.Enum.ZuCheStates.启用,
                CarName = Utils.GetQueryStringValue("carname")
            };
            var list = bll.GetList(1000000, model);
            if (list.Count == 0)
            {
                model.State = EyouSoft.Model.Enum.ZuCheStates.启用;
                model.CarName = null;
            }
            list = bll.GetList(1000000, model);
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    strHtml.AppendFormat("<option value=\"{0}\" >{1}</option>",
                        item.ZuCheID, item.CarName);
                }
            }

            return strHtml.ToString();
        }
        protected string JSON()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("var jsonJE = { Qjc: 0, Qgl: 0, Qcc: 0, Qcs: 0, Djc: 0, Dgl: 0, Dcc: 0 };var jsonTJ = { Qhy: 0, Qgb: 0, Qmfx:0, Qfx: 0, Qyg: 0, Dhy: 0, Dgb: 0, Dmfx:0, Dfx: 0, Dyg: 0, Dcb:0 };"
                    + "var jsonCC = { QCms:0, QChy: 0, QCgb: 0, QCmfx:0, QCfx: 0, QCyg: 0, DCcb:0, DCms:0, DChy: 0, DCgb: 0, DCmfx:0, DCfx: 0, DCyg: 0 };var jsonCS = { QSms:0, QShy: 0, QSgb: 0, QSmfx:0, QSfx: 0, QSyg: 0, DSms:0, DShy: 0, DSgb: 0, DSmfx:0, DSfx: 0, DSyg: 0 }");
            return sb.ToString();
        }
        protected string FeetSetingJSON()
        {
            StringBuilder sb = new StringBuilder();
            MFeeSettings feeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.组团);
            sb.Append("var FeetSeting = { Mhy: " + feeSettings.PuTongHuiYuanJia + ", Mgb: " + feeSettings.GuiBinJia + ", Mmfx: " + feeSettings.FreeFenXiaoJia + ",Mfx: " + feeSettings.FenXiaoJia + ", Myg: " + feeSettings.YuanGongJia + " }");
            return sb.ToString();
        }
        private void OrderSub()
        {
            Model.SSOStructure.MUserInfo userInfo = null;
            if (!Security.Membership.UserProvider.IsLogin(out userInfo)) RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求错误重新操作！"));
            if (userInfo == null) RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求错误重新操作！"));
            EyouSoft.Model.XianLuStructure.MZiZuTuan ZuTuanModel = new EyouSoft.Model.XianLuStructure.MZiZuTuan();
            ZuTuanModel.ChengTuanNum = Utils.GetInt(Utils.GetFormValue(BiaoZhunNum.UniqueID));
            ZuTuanModel.ErTongNum = Utils.GetInt(Utils.GetFormValue("ETRenShu"));
            ZuTuanModel.BaoXian = Utils.GetFormValue("BaoXianFS");
            ZuTuanModel.DiPeiDaoYouNum = Utils.GetInt(Utils.GetFormValue("DiPeiDaoYouNum"));
            ZuTuanModel.DiPeiRJJia = Utils.GetDecimal(Utils.GetFormValue("DiPeiDaoYouFei"));
            ZuTuanModel.HangBanId = Utils.GetFormValue("HangBanId");
            if (string.IsNullOrEmpty(ZuTuanModel.BaoXian))
            {
                ZuTuanModel.BaoXianDay = 0;
                ZuTuanModel.BXJiaGe = 0;
            }
            else
            {
                ZuTuanModel.BaoXianDay = Utils.GetInt(Utils.GetFormValue(LYTianShu.UniqueID));
                ZuTuanModel.BXJiaGe = Utils.GetDecimal(Utils.GetFormValue("RJBXF"));
            }
            ZuTuanModel.CanWuJia = Utils.GetDecimal(Utils.GetFormValue("CanWuFei"));
            ZuTuanModel.CarMoney = Utils.GetDecimal(Utils.GetFormValue("CarMoney"));
            ZuTuanModel.ChuFaTime = Convert.ToDateTime(Utils.GetFormValue(XianLuChuYear.UniqueID) + "-" + Utils.GetFormValue(XianLuChuMonth.UniqueID) + "-" + Utils.GetFormValue(XianLuChuDay.UniqueID));
            ZuTuanModel.CRJiage = Utils.GetDecimal(Utils.GetFormValue("UChengRenJia"));
            ZuTuanModel.QuanPeiRJJia = Utils.GetDecimal(Utils.GetFormValue("QuanPeiDaoYouFei"));
            ZuTuanModel.DaoYouMoney = Utils.GetDecimal(Utils.GetFormValue("DaoYouFei"));
            ZuTuanModel.DaoYouNum = Utils.GetInt(Utils.GetFormValue("DaoYouNum"));
            ZuTuanModel.ETJiage = Utils.GetDecimal(Utils.GetFormValue("UErTongJia"));
            ZuTuanModel.IssueTime = DateTime.Now;
            ZuTuanModel.RenShu = Utils.GetInt(Utils.GetFormValue("RenShu"));
            ZuTuanModel.UserType = userInfo.UserType;
            ZuTuanModel.WanCanJia = Utils.GetDecimal(Utils.GetFormValue("WanCanMoney"));
            ZuTuanModel.WanCanNum = Utils.GetInt(Utils.GetFormValue("WanCanNum"));
            ZuTuanModel.WuCanJia = Utils.GetDecimal(Utils.GetFormValue("WuCanMoney"));
            ZuTuanModel.WuCanNum = Utils.GetInt(Utils.GetFormValue("WuCanNum"));
            ZuTuanModel.XDRId = userInfo.UserId;
            ZuTuanModel.RSBXJiaGe = Utils.GetDecimal(Utils.GetFormValue("RenShenBX"));
            ZuTuanModel.JTBXJiaGe = Utils.GetDecimal(Utils.GetFormValue("JiaoTongBX"));
            ZuTuanModel.XianLuId = Utils.GetFormValue(XLXianLuId.UniqueID);
            ZuTuanModel.XianLuName = Utils.GetFormValue(XianLuTitle.UniqueID);
            ZuTuanModel.ZaoCanJia = Utils.GetDecimal(Utils.GetFormValue("ZaoCanMoney"));
            ZuTuanModel.ZaoCanNum = Utils.GetInt(Utils.GetFormValue("ZaoCanNum"));
            ZuTuanModel.ZCMoney = Utils.GetDecimal(Utils.GetFormValue("ZuCheMoney"));
            ZuTuanModel.TourId = Utils.GetFormValue(XLTourId.UniqueID);
            ZuTuanModel.ZuTuanId = Guid.NewGuid().ToString();

            decimal crms = Utils.GetDecimal(Utils.GetFormValue("ChengRenMS"));//成人门市价
            decimal etms = Utils.GetDecimal(Utils.GetFormValue("ErTongMS"));//儿童门市价
            decimal crjs = Utils.GetDecimal(Utils.GetFormValue("ChengRenJieSuan"));//成人结算价
            decimal etjs = Utils.GetDecimal(Utils.GetFormValue("ErTongJieSuan"));//儿童结算价
            MFeeSettings feeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.组团);
            EyouSoft.Model.Enum.FeeTypes FeeType = EyouSoft.Model.Enum.FeeTypes.组团;

            string url = HttpContext.Current.Request.Url.Host.Replace("m.", "");
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
            seller = bsells.GetMSellersByWebSite(url);
            decimal zjzms = Utils.GetDecimal(Utils.GetFormValue("ZongMoney"));//增加总门市价
            decimal zjzcb = Utils.GetDecimal(Utils.GetFormValue("ZongMoneyCB"));//增加总成本价
            decimal crfx, etfx, zjzfx;
            if (seller != null)
            {
                ZuTuanModel.AgencyId = seller.ID;
                if (seller.DengJi == MemberTypes.代理)
                {
                    crfx = UtilsCommons.GetGYStijia(FeeType, crjs, crms, EyouSoft.Model.Enum.MemberTypes.代理);
                    etfx = UtilsCommons.GetGYStijia(FeeType, etjs, etms, EyouSoft.Model.Enum.MemberTypes.代理);
                    zjzfx = zjzcb + (zjzms - zjzcb) * feeSettings.FenXiaoJia / 100;
                }
                else if (seller.DengJi == MemberTypes.免费代理)
                {
                    crfx = UtilsCommons.GetGYStijia(FeeType, crjs, crms, EyouSoft.Model.Enum.MemberTypes.免费代理);
                    etfx = UtilsCommons.GetGYStijia(FeeType, etjs, etms, EyouSoft.Model.Enum.MemberTypes.免费代理);
                    zjzfx = zjzcb + (zjzms - zjzcb) * feeSettings.FreeFenXiaoJia / 100;
                }
                else if (seller.DengJi == MemberTypes.员工)
                {
                    crfx = UtilsCommons.GetGYStijia(FeeType, crjs, crms, EyouSoft.Model.Enum.MemberTypes.员工);
                    etfx = UtilsCommons.GetGYStijia(FeeType, etjs, etms, EyouSoft.Model.Enum.MemberTypes.员工);
                    zjzfx = zjzcb + (zjzms - zjzcb) * feeSettings.YuanGongJia / 100;
                }
                else
                {
                    crfx = UtilsCommons.GetGYStijia(FeeType, crjs, crms, EyouSoft.Model.Enum.MemberTypes.代理);
                    etfx = UtilsCommons.GetGYStijia(FeeType, etjs, etms, EyouSoft.Model.Enum.MemberTypes.代理);
                    zjzfx = zjzcb + (zjzms - zjzcb) * feeSettings.FenXiaoJia / 100;
                }
            }
            else
            {
                crfx = UtilsCommons.GetGYStijia(FeeType, crjs, crms, EyouSoft.Model.Enum.MemberTypes.代理);
                etfx = UtilsCommons.GetGYStijia(FeeType, etjs, etms, EyouSoft.Model.Enum.MemberTypes.代理);
                zjzfx = zjzcb + (zjzms - zjzcb) * feeSettings.FenXiaoJia / 100;
            }

            var userType = userInfo.UserType;
            decimal discount = 0;
            switch (userType)
            {
                case EyouSoft.Model.Enum.MemberTypes.未注册用户:
                    break;
                case EyouSoft.Model.Enum.MemberTypes.员工:
                    discount = feeSettings.YuanGongJia;
                    break;
                case EyouSoft.Model.Enum.MemberTypes.普通会员:
                    discount = feeSettings.PuTongHuiYuanJia;
                    break;
                case EyouSoft.Model.Enum.MemberTypes.贵宾会员:
                    discount = feeSettings.GuiBinJia;
                    break;
                case EyouSoft.Model.Enum.MemberTypes.代理:
                    discount = feeSettings.FenXiaoJia;
                    break;
                case EyouSoft.Model.Enum.MemberTypes.免费代理:
                    discount = feeSettings.FreeFenXiaoJia;
                    break;
                default:
                    break;
            }

            ZuTuanModel.ZongMOney = zjzcb + (zjzms - zjzcb) * discount / 100;
            ZuTuanModel.AgencyJinE = crfx + zjzfx;
            ZuTuanModel.ETAgencyJinE = etfx + zjzfx;
            if (ZuTuanModel.AgencyJinE > ZuTuanModel.CRJiage)
            {
                ZuTuanModel.AgencyJinE = ZuTuanModel.CRJiage;
            }
            if (ZuTuanModel.ETAgencyJinE > ZuTuanModel.ETJiage)
            {
                ZuTuanModel.ETAgencyJinE = ZuTuanModel.ETJiage;
            }


            int success = new EyouSoft.BLL.XianLuStructure.BZiZuTuan().Add(ZuTuanModel);



            string[] qucarlist = Utils.GetFormValues("ddl_QuGongLi");
            string[] qucheNum = Utils.GetFormValues("QuZuCheNum");
            string[] quchefei = Utils.GetFormValues("QuCheFei");
            string[] huicarlist = Utils.GetFormValues("ddl_HuiGongLi");
            string[] huicheNum = Utils.GetFormValues("HuiZuCheNum");
            string[] huichefei = Utils.GetFormValues("HuiCheFei");
            EyouSoft.Model.XianLuStructure.MZiZuTuanXingCheng ZiZuTuanXC = new EyouSoft.Model.XianLuStructure.MZiZuTuanXingCheng();
            if (!string.IsNullOrEmpty(quchefei[0]) && quchefei.Length > 0)
            {
                for (int i = 0; i < quchefei.Length; i++)
                {
                    if (Convert.ToDecimal(quchefei[i]) > 0)
                    {
                        ZiZuTuanXC.CheNum = Convert.ToInt32(qucheNum[i]);
                        ZiZuTuanXC.FeiYong = Convert.ToDecimal(quchefei[i]);
                        ZiZuTuanXC.GongLiShu = Utils.GetDecimal(Utils.GetFormValue("QuGongLi"));
                        ZiZuTuanXC.QiDian = Utils.GetFormValue("QuQiDian");
                        ZiZuTuanXC.ZhongDian = Utils.GetFormValue("QuZhongDian");
                        ZiZuTuanXC.ZiZuTuanId = ZuTuanModel.ZuTuanId;
                        ZiZuTuanXC.ZucheId = qucarlist[i];
                        //新增
                        new EyouSoft.BLL.XianLuStructure.BZiZuTuan().AddXC(ZiZuTuanXC);
                    }
                }
            }
            if (!string.IsNullOrEmpty(huichefei[0]) && huichefei.Length > 0)
            {
                for (int i = 0; i < huichefei.Length; i++)
                {
                    if (Convert.ToDecimal(huichefei[i]) > 0)
                    {
                        ZiZuTuanXC.CheNum = Convert.ToInt32(huicheNum[i]);
                        ZiZuTuanXC.FeiYong = Convert.ToDecimal(huichefei[i]);
                        ZiZuTuanXC.GongLiShu = Utils.GetDecimal(Utils.GetFormValue("HuiGongLi"));
                        ZiZuTuanXC.QiDian = Utils.GetFormValue("HuiQiDian");
                        ZiZuTuanXC.ZhongDian = Utils.GetFormValue("HuiZhongDian");
                        ZiZuTuanXC.ZiZuTuanId = ZuTuanModel.ZuTuanId;
                        ZiZuTuanXC.ZucheId = huicarlist[i];
                        //新增
                        new EyouSoft.BLL.XianLuStructure.BZiZuTuan().AddXC(ZiZuTuanXC);
                    }
                }
            }
            if (success > 0)
            {
                RECW(UtilsCommons.AjaxReturnJson("1", "报价成功，请前往订单中心查看"));
            }
            else
            {
                RECW(UtilsCommons.AjaxReturnJson("0", "报价失败"));
            }
        }
        private void RECW(string msg)
        {
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }
        #region 私有方法
        /// <summary>
        /// 判断登陆状态
        /// </summary>
        void getLoginState()
        {
            Response.Clear();

            Model.SSOStructure.MUserInfo userInfo = null;
            if (Security.Membership.UserProvider.IsLogin(out userInfo))
            {
                Response.Write(UtilsCommons.AjaxReturnJson("1", "login"));
            }
            else
            {
                Response.Write(UtilsCommons.AjaxReturnJson("0", "unlogin"));

            }
            Response.End();
        }
        #endregion
    }
    /// <summary>
    /// 序列化的类
    /// </summary>
    class seraModel
    {
        /// <summary>
        /// 线路编号
        /// </summary>
        public string xid { get; set; }
        /// <summary>
        /// 线路类型
        /// </summary>
        public string xtp { get; set; }
        /// <summary>
        /// 团号
        /// </summary>
        public string tid { get; set; }
        /// <summary>
        /// 出团时间
        /// </summary>
        public DateTime ldate { get; set; }
        /// <summary>
        /// 门市价
        /// </summary>
        public string msj { get; set; }
        /// <summary>
        /// 会员价
        /// </summary>
        public string hyj { get; set; }
        /// <summary>
        /// 余位
        /// </summary>
        public int yw { get; set; }
    }
}
