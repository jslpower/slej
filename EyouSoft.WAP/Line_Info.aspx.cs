using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using Newtonsoft.Json.Converters;
using EyouSoft.Model.Enum;
using EyouSoft.Model.XianLuStructure;

namespace EyouSoft.WAP
{
    public partial class Line_Info : Common.Page.WebPageBase
    {
        protected string defaultHBID = "-1", tid = string.Empty;
        protected int routeType = 0;
        //List<MXianLuTourTraffice> hangbanList = new List<MXianLuTourTraffice>();
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("getSum") == "1") getSumMoney();
            initData();
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
        void initData()
        {
            string xianluid = Utils.GetQueryStringValue("id");
            defaultHBID = Utils.GetQueryStringValue("hangban");

            var model = new EyouSoft.BLL.XianLuStructure.BXianLu().GetInfo(xianluid);
            if (model != null)
            {
                string sourceFrom = model.Line_Source.ToString();
                if (model.Line_Source != EyouSoft.Model.XianLuStructure.LineSource.系统)
                {
                    //获取接口最新数据
                    model = new EyouSoft.InterfaceLib.APITour().SyncTour(model);
                }
                //提示获取错误数据来源
                if (model == null) RCWE("接口数据获取失败，ERROR:" + sourceFrom + "");

                var areaType = new BLL.OtherStructure.BSysAreaInfo().GetSysAreaModel(model.AreaId);
                if (areaType != null)
                {
                    routeType = (int)areaType.RouteType;
                    WapHeader1.HeadText = areaType.RouteType == EyouSoft.Model.Enum.AreaType.出境线路 ? "国际线路" : areaType.RouteType.ToString();
                }



                if (model.TourTraffice != null && model.TourTraffice.Count > 0)
                {
                    if (string.IsNullOrEmpty(defaultHBID))
                    {
                        if (model.Tours != null && model.Tours.Any())
                        {
                            defaultHBID = model.Tours.First().TrafficId;
                        }
                    }
                }
                lblImg.Text = string.IsNullOrEmpty(model.TeSeFilePath) ? "<img src=\"/images/line_xx001.jpg\" />" : "<img src=\"" + TuPian.F1(model.TeSeFilePath, 640, 400, model.XianLuId) + "\" />";

                lbl_routeName.Text = Utils.ConverToStringByHtml(model.RouteName);
                lblJiHeDi.Text = model.JiHeFangShi;
                lblSongTuanRen.Text = model.LxrName;

                EyouSoft.Model.SystemStructure.MFeeSettings bilv = new EyouSoft.Model.SystemStructure.MFeeSettings();
                if (routeType == 3)
                {
                    WapHeader1.HeadText = EyouSoft.Model.Enum.FeeTypes.周边线路.ToString();
                    PriceInfo1.FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
                }
                if (routeType == 1)
                {
                    WapHeader1.HeadText = EyouSoft.Model.Enum.FeeTypes.国内线路.ToString();
                    PriceInfo1.FeeType = EyouSoft.Model.Enum.FeeTypes.国内线路;
                }
                if (routeType == 2)
                {
                    WapHeader1.HeadText = EyouSoft.Model.Enum.FeeTypes.国际线路.ToString();
                    PriceInfo1.FeeType = EyouSoft.Model.Enum.FeeTypes.国际线路;
                }


                var chufadi = new EyouSoft.BLL.OtherStructure.BSysAreaInfo().GetSysCityModel(model.DepCityId);


                if (chufadi == null)//出发地
                {
                    cfd.Text = "杭州出发";
                }
                else
                {
                    cfd.Text = chufadi.Name + "出发";
                }
                cfd.Text += string.Format("<span class=\"gys_code\">{0}</span>", getSourceJP(model.Line_Source));

                if (model.FuWu != null)//服务
                {
                    if (model.Line_Source == EyouSoft.Model.XianLuStructure.LineSource.光大 || model.Line_Source == EyouSoft.Model.XianLuStructure.LineSource.旅游圈)
                    {
                        if (string.IsNullOrEmpty(model.FuWu.GouWuAnPai)) div_gouwu.Visible = false;
                        litGouWu.Text = Utils.ConverToHtml(model.FuWu.GouWuAnPai);

                        if (string.IsNullOrEmpty(model.FuWu.FuWuBiaoZhun)) div_baohan.Visible = false;
                        litBaoHan.Text = Utils.ConverToHtml(model.FuWu.FuWuBiaoZhun);

                        if (string.IsNullOrEmpty(model.FuWu.BuHanXiangMu)) div_buhan.Visible = false;
                        litBuHan.Text = Utils.ConverToHtml(model.FuWu.BuHanXiangMu);

                        if (string.IsNullOrEmpty(model.FuWu.ErTongAnPai)) div_ertong.Visible = false;
                        litErTong.Text = Utils.ConverToHtml(model.FuWu.ErTongAnPai);

                        if (string.IsNullOrEmpty(model.FuWu.ZiFeiXiangMu)) div_zifei.Visible = false;
                        litZiFei.Text = Utils.ConverToHtml(model.FuWu.ZiFeiXiangMu);

                        if (string.IsNullOrEmpty(model.FuWu.WenXinTiXing)) div_tishi.Visible = false;
                        litTiShi.Text = Utils.ConverToHtml(model.FuWu.WenXinTiXing);

                        if (string.IsNullOrEmpty(model.FuWu.ZhuYiShiXiang)) div_zhuyi.Visible = false;
                        litZhuYi.Text = Utils.ConverToHtml(model.FuWu.ZhuYiShiXiang);

                        if (string.IsNullOrEmpty(model.FuWu.BaoMingXuZhi)) div_baoming.Visible = false;
                        litBaoMing.Text = Utils.ConverToHtml(model.FuWu.BaoMingXuZhi);

                        if (string.IsNullOrEmpty(model.FuWu.ZengSongXiangMu)) div_zengsong.Visible = false;
                        litZengSong.Text = Utils.ConverToHtml(model.FuWu.ZengSongXiangMu);

                        if (string.IsNullOrEmpty(model.FuWu.QiTaShiXiang)) div_qita.Visible = false;
                        litQiTa.Text = Utils.ConverToHtml(model.FuWu.QiTaShiXiang);

                        if (string.IsNullOrEmpty(model.TeSe)) div_shuoming.Visible = false;
                        litMiaoShu.Text = Utils.ConverToHtml(model.TeSe);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(model.FuWu.GouWuAnPai)) div_gouwu.Visible = false;
                        litGouWu.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.GouWuAnPai));

                        if (string.IsNullOrEmpty(model.FuWu.FuWuBiaoZhun)) div_baohan.Visible = false;
                        litBaoHan.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.FuWuBiaoZhun));

                        if (string.IsNullOrEmpty(model.FuWu.BuHanXiangMu)) div_buhan.Visible = false;
                        litBuHan.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.BuHanXiangMu));

                        if (string.IsNullOrEmpty(model.FuWu.ErTongAnPai)) div_ertong.Visible = false;
                        litErTong.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.ErTongAnPai));

                        if (string.IsNullOrEmpty(model.FuWu.ZiFeiXiangMu)) div_zifei.Visible = false;
                        litZiFei.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.ZiFeiXiangMu));

                        if (string.IsNullOrEmpty(model.FuWu.WenXinTiXing)) div_tishi.Visible = false;
                        litTiShi.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.WenXinTiXing));

                        if (string.IsNullOrEmpty(model.FuWu.ZhuYiShiXiang)) div_zhuyi.Visible = false;
                        litZhuYi.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.ZhuYiShiXiang));

                        if (string.IsNullOrEmpty(model.FuWu.BaoMingXuZhi)) div_baoming.Visible = false;
                        litBaoMing.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.BaoMingXuZhi));

                        if (string.IsNullOrEmpty(model.FuWu.ZengSongXiangMu)) div_zengsong.Visible = false;
                        litZengSong.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.ZengSongXiangMu));

                        if (string.IsNullOrEmpty(model.FuWu.QiTaShiXiang)) div_qita.Visible = false;
                        litQiTa.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.QiTaShiXiang));

                        if (string.IsNullOrEmpty(model.TeSe)) div_shuoming.Visible = false;
                        litMiaoShu.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.TeSe));
                    }
                }

                //显示选择航班
                if (!string.IsNullOrEmpty(defaultHBID) && defaultHBID != "-1")
                {
                    var defaultHangBan = model.TourTraffice.Where(i => i.TrafficId == defaultHBID).ToList().First(); ;
                    ltrFlight.Text = string.Format("<li data-id='{0}'>{1}</li>", defaultHangBan.TrafficId, defaultHangBan.Traffic_01);
                    isNoFlight.Visible = true;
                }

                //线路广告

                var lineadv = new EyouSoft.BLL.OtherStructure.BSysAreaInfo().GetSysAreaModel(model.AreaId);
                if (!string.IsNullOrEmpty(lineadv.AdvLink))
                {
                    phLineAdv.Visible = true;
                    hrfLineAdv.NavigateUrl = "http://m." + lineadv.AdvLink;
                    hrfLineAdv.Text = lineadv.AdvTitle;
                    imgLineAdv.Src = lineadv.ImgPath;
                }

                //初始化航班
                initFlight(model);

                //绑定形成列表
                if (model.XingChengs != null && model.XingChengs.Count > 0)
                {
                    rptJourneies.DataSource = model.XingChengs;
                    rptJourneies.DataBind();
                }

                //初始化团期
                initTours(model);

                #region 设置微信分享链接
                //设置图片链接
                FenXiangTuPianFilepath = string.IsNullOrEmpty(model.TeSeFilePath) ? "http://" + Request.Url.Host + " /images/line_xx001.jpg" : "http://" + Request.Url.Host + TuPian.F1(model.TeSeFilePath, 640, 400, model.XianLuId);
                FenXiangBiaoTi = model.RouteName;
                FenXiangMiaoShu = Utils.InputText(model.Description);
                #endregion

            }
            FenXiangLianJie =  Utils.redirectUrl(HttpContext.Current.Request.Url.ToString());
        }

        #region 获取团期和航班信息
        /// <summary>
        /// 初始化发班日期
        /// </summary>
        /// <param name="model"></param>
        void initTours(EyouSoft.Model.XianLuStructure.MXianLuInfo model)
        {

            tid = Utils.GetQueryStringValue("tid");

            string strScript = string.Empty;

            string boxString = "dataBox={}";


            EyouSoft.Model.SystemStructure.MFeeSettings bilv = new EyouSoft.Model.SystemStructure.MFeeSettings();

            EyouSoft.Model.Enum.FeeTypes FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
            if (routeType == 3) FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
            if (routeType == 1) FeeType = EyouSoft.Model.Enum.FeeTypes.国内线路;
            if (routeType == 2) FeeType = EyouSoft.Model.Enum.FeeTypes.国际线路;

            if (model.Tours != null && model.Tours.Count > 0)
            {
                var items = model.Tours.Where(m => m.LDate >= DateTime.Now).ToList();
                //默认第一个航班
                if (!string.IsNullOrEmpty(defaultHBID) || defaultHBID != "-1")
                {
                    items = model.Tours.Where(m => m.LDate >= DateTime.Now && m.TrafficId == defaultHBID).ToList();
                }

                IsoDateTimeConverter isDate = new IsoDateTimeConverter() { DateTimeFormat = "yyyy-M-d" };

                List<seraModel> nlist = new List<seraModel>();
                if (items != null && items.Count > 0)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        nlist.Add(new seraModel()
                        {
                            xid = items[i].XianLuID,
                            tid = items[i].TourId,
                            hyj = UtilsCommons.GetGYStijia(FeeType, items[i].JSJCR, items[i].CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0"),
                            ldate = items[i].LDate,
                            msj = items[i].CRSCJ.ToString("F0"),
                            yw = items[i].SYRS
                        });
                        //if (items[i].TrafficId != defaultHBID && defaultHBID != "-1") continue;//只取一个航班号

                    }
                }
                boxString = string.Format("dataBox={0}", Newtonsoft.Json.JsonConvert.SerializeObject(nlist, isDate));
                strScript = boxString;


                //是否选中发班日期
                if (string.IsNullOrEmpty(tid))
                {
                    items = items.Where(i => i.TrafficId == items[0].TrafficId).ToList();
                    tid = items[0].TourId;
                }
                else
                {
                    items = items.Where(i => i.TourId == tid).ToList();
                }

                if (items != null && items.Any())
                {
                    PriceInfo1.CRSCJ = items[0].CRSCJ;
                    PriceInfo1.ETSCJ = items[0].ETSCJ;
                    PriceInfo1.JSJCR = items[0].JSJCR;
                    PriceInfo1.JSJET = items[0].JSJET;
                    price_ul.InnerHtml = string.Format("<li>成人：<span class=\"floatR\">¥{0}x1人</span></li><li>儿童：<span class=\"floatR\">¥{1}x0人</span></li>",
                                                                                    UtilsCommons.GetGYStijia(FeeType, items[0].JSJCR, items[0].CRSCJ).ToString("F0"),
                                                                                    UtilsCommons.GetGYStijia(FeeType, items[0].JSJET, items[0].ETSCJ).ToString("F0"));

                    span_price.InnerText = UtilsCommons.GetGYStijia(FeeType, items[0].JSJCR, items[0].CRSCJ).ToString("F0");

                    rptTours.DataSource = items;
                    rptTours.DataBind();
                }





            }


            RegisterScript(boxString);//输出发班信息


        }

        /// <summary>
        /// 初始化航班信息
        /// </summary>
        void initFlight(EyouSoft.Model.XianLuStructure.MXianLuInfo model)
        {

            if (model != null)
            {

                if (model.TourTraffice != null && model.TourTraffice.Count > 0)
                {
                    rptHangBanList.DataSource = model.TourTraffice;
                    rptHangBanList.DataBind();
                }
            }

        }

        #endregion

        /// <summary>
        /// 计算价格
        /// </summary>
        protected void getSumMoney()
        {
            string xianluid = Utils.GetQueryStringValue("id");
            int routeType = Utils.GetInt(Utils.GetQueryStringValue("type"));
            string tourid = Utils.GetQueryStringValue("tid");
            string hangban = Utils.GetQueryStringValue("hangban");
            int peopleNum = Utils.GetInt(Utils.GetQueryStringValue("crs"));
            int childNum = Utils.GetInt(Utils.GetQueryStringValue("ets"));


            EyouSoft.Model.Enum.FeeTypes FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
            if (routeType == 3) FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
            if (routeType == 1) FeeType = EyouSoft.Model.Enum.FeeTypes.国内线路;
            if (routeType == 2) FeeType = EyouSoft.Model.Enum.FeeTypes.国际线路;

            var xianlu = new EyouSoft.BLL.XianLuStructure.BXianLu().GetInfo(xianluid);
            if (xianlu == null) RCWE(UtilsCommons.AjaxReturnJson("0", "0"));
            if (!xianlu.Tours.Any() || xianlu.Tours.Count == 0) RCWE(UtilsCommons.AjaxReturnJson("0", "0"));
            MXianLuTourInfo tour = new MXianLuTourInfo();
            var tours = xianlu.Tours.Where(m => m.LDate >= DateTime.Now && m.TrafficId == hangban).ToList();
            if (tours == null || tours.Count == 0) RCWE(UtilsCommons.AjaxReturnJson("0", "0"));

            tour = tours.First();//默认取获取有效发班日期第一个
            if (!string.IsNullOrEmpty(tourid) || !string.IsNullOrEmpty(hangban))
            {
                if (!string.IsNullOrEmpty(hangban)) tour = tours.Where(i => i.TrafficId == hangban).First();//如果选取航班，取航班第一个
                if (!string.IsNullOrEmpty(tourid)) tour = tours.Where(i => i.TourId == tourid).First();//如果选中发班日期，取发班日期的团
            }

            var CRJ = UtilsCommons.GetGYStijia(FeeType, tour.JSJCR, tour.CRSCJ);
            var ETJ = UtilsCommons.GetGYStijia(FeeType, tour.JSJET, tour.ETSCJ);
            decimal sum = CRJ * peopleNum + ETJ * childNum;
            string getPriceInfo = string.Format("<li>成人：<span class=\"floatR\">¥{0}x{1}人</span></li><li>儿童：<span class=\"floatR\">¥{2}x{3}人</span></li>",
                                                                             CRJ.ToString("F0"), peopleNum
                                                                             , ETJ.ToString("F0"), childNum);
            //decimal CRSCJ = tour.CRSCJ * peopleNum;
            //decimal ETSCJ = tour.ETSCJ * childNum;
            //decimal JSJCR = tour.JSJCR * peopleNum;
            //decimal JSJET = tour.JSJET * childNum;
            StringBuilder strbu = new StringBuilder();
            //{

            //    Model.SSOStructure.MUserInfo userInfo = null;
            //    bool isLogin = Security.Membership.UserProvider.IsLogin(out userInfo);
            //    if (isLogin)
            //    {

            //        if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.普通会员)
            //        {
            //            strbu.AppendFormat("<li><span class=\"font_yellow\">会员：</span>成人{0}元  儿童{1}元 </li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.普通会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.普通会员).ToString("F0"));
            //            strbu.AppendFormat("<li><a href=\"\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">贵宾：</span>成人{0}元 儿童{1}元</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.贵宾会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.贵宾会员).ToString("F0"));
            //            strbu.AppendFormat("<li><a href=\"\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理：</span>成人{0}元 儿童{1}元</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.代理).ToString("F0"));

            //        }
            //        if (isDisplay)
            //        {
            //            if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
            //            {
            //                strbu.AppendFormat("<li><span class=\"font_yellow\">会员：</span>成人{0}元 儿童{1}元</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.普通会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.普通会员).ToString("F0"));
            //                strbu.AppendFormat("<li><span class=\"font_yellow\">贵宾：</span>成人{0}元 儿童{1}元</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.贵宾会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.贵宾会员).ToString("F0"));
            //                strbu.AppendFormat("<li><a href=\"\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理：</span>成人{0}元 儿童{1}元</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.代理).ToString("F0"));
            //            }
            //            if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理)
            //            {
            //                strbu.AppendFormat("<li><span class=\"font_yellow\">会员：</span>成人{0}元 儿童{1}元</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.普通会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.普通会员).ToString("F0"));
            //                strbu.AppendFormat("<li><span class=\"font_yellow\">贵宾：</span>成人{0}元 儿童{1}元</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.贵宾会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.贵宾会员).ToString("F0"));
            //                strbu.AppendFormat("<li><span class=\"font_yellow\">代理：</span>成人{0}元 儿童{1}元</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.代理).ToString("F0"));
            //            }
            //        }
            //    }
            //    else
            //    {

            //        strbu.AppendFormat("<li><a href=\"\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">会员：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.普通会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.普通会员).ToString("F0"));
            //        if (isDisplay)
            //        {
            //            strbu.AppendFormat("<li><a href=\"\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">贵宾：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.贵宾会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.贵宾会员).ToString("F0"));
            //            strbu.AppendFormat("<li><a href=\"\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, JSJET, ETSCJ, MemberTypes.代理).ToString("F0"));
            //        }


            //    }


            //}
            var retObj = new retObj() { YH = strbu.ToString(), PRICE = getPriceInfo };
            RCWE(UtilsCommons.AjaxReturnJson("1", sum.ToString("F0"), retObj));


        }
        /// <summary>
        /// 填充数据类
        /// </summary>
        class retObj
        {
            public string YH { get; set; }
            public string PRICE { get; set; }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="lineType"></param>
        /// <returns></returns>
        string getSourceJP(object lineType)
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
