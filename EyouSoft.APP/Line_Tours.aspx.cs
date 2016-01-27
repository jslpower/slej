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
using Newtonsoft.Json.Converters;

namespace EyouSoft.WAP
{
    public partial class Line_Tours : Common.Page.WebPageBase
    {
        protected string defaultHBID = "-1";//航班ID
        protected int routeType = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("getSum") == "1") getSumMoney();
            initData();
        }
        void initData()
        {
            //#region 判断登陆
            //Model.SSOStructure.MUserInfo userInfo = null;
            //bool islogin = Security.Membership.UserProvider.IsLogin(out userInfo);
            //#endregion
            string xianluid = Utils.GetQueryStringValue("xianluid");
            //string TourId = Utils.GetQueryStringValue("tid");
            string hangban = Utils.GetQueryStringValue("hasFlightNO");
            string strScript = string.Empty;
            var model = new EyouSoft.BLL.XianLuStructure.BXianLu().GetInfo(xianluid);

            string boxString = "dataBox={}";
            if (model != null)
            {
                var areaType = new BLL.OtherStructure.BSysAreaInfo().GetSysAreaModel(model.AreaId);
                if (areaType != null)
                {
                    routeType = (int)areaType.RouteType;
                    WapHeader1.HeadText = areaType.RouteType == EyouSoft.Model.Enum.AreaType.出境线路 ? "国际线路" : areaType.RouteType.ToString();
                }
                if (model.Line_Source != EyouSoft.Model.XianLuStructure.LineSource.系统) model = new EyouSoft.InterfaceLib.APITour().SyncTour(model);
                bool isxianshi = (model.Line_Source == EyouSoft.Model.XianLuStructure.LineSource.博客 && model.LineType == EyouSoft.Model.XianLuStructure.LineType.长线);
                if (isxianshi)
                {
                    defaultHBID = hangban;
                }



                EyouSoft.Model.SystemStructure.MFeeSettings bilv = new EyouSoft.Model.SystemStructure.MFeeSettings();


                EyouSoft.Model.Enum.FeeTypes FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
                if (routeType == 3)
                {
                    WapHeader1.HeadText = EyouSoft.Model.Enum.FeeTypes.周边线路.ToString();
                    FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
                }
                if (routeType == 1)
                {
                    WapHeader1.HeadText = EyouSoft.Model.Enum.FeeTypes.国内线路.ToString();
                    FeeType = EyouSoft.Model.Enum.FeeTypes.国内线路;
                }
                if (routeType == 2)
                {
                    WapHeader1.HeadText = EyouSoft.Model.Enum.FeeTypes.国际线路.ToString();
                    FeeType = EyouSoft.Model.Enum.FeeTypes.国际线路;
                }

                StringBuilder strJGlevel = new StringBuilder();//显示价格等级信息

                #region 发班信息
                int yiShouRenShu = 0;

                if (model.Tours != null && model.Tours.Count > 0)
                {
                    var items = model.Tours.Where(m => m.LDate >= DateTime.Now).ToList();
                    foreach (var item in items)
                    {
                        yiShouRenShu += item.YiShouRenShu;
                        if (item.LDate <= DateTime.Today) continue;
                        if (item.TrafficId != defaultHBID && isxianshi) continue;//只取一个航班号
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
                            nlist.Add(new seraModel() { xid = olist[i].XianLuID, tid = olist[i].TourId, hyj = UtilsCommons.GetGYStijia(FeeType, olist[i].JSJCR, olist[i].CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0"), ldate = olist[i].LDate, msj = olist[i].CRSCJ.ToString("F0"), yw = olist[i].SYRS });

                        }
                    }
                    boxString = string.Format("dataBox={0}", Newtonsoft.Json.JsonConvert.SerializeObject(nlist, isDate));
                    strScript = boxString;


                    #region

                    decimal CRSCJ = model.Tours[0].CRSCJ;
                    decimal ETSCJ = model.Tours[0].ETSCJ;
                    decimal JSJCR = model.Tours[0].JSJCR;
                    decimal JSJET = model.Tours[0].JSJET;
                    StringBuilder strbu = new StringBuilder();
                    {

                        isDisplay = new EyouSoft.IDAL.AccountStructure.BSellers().WebSiteShowOrHidden(System.Web.HttpContext.Current.Request.Url.Host.ToLower()) == EyouSoft.Model.Enum.ShowHidden.显示 ? true : false;
                        litHtml.Visible = isDisplay;

                        if (isDisplay)
                        {
                            Model.SSOStructure.MUserInfo userInfo = null;
                            bool isLogin = Security.Membership.UserProvider.IsLogin(out userInfo);
                            if (isLogin)
                            {

                                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.普通会员)
                                {
                                    strbu.AppendFormat("<li><span class=\"font_yellow\">会员：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.普通会员).ToString("F0"), 0);
                                    strbu.AppendFormat("<li><a href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">贵宾：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.贵宾会员).ToString("F0"), 0);
                                    strbu.AppendFormat("<li><a href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.代理).ToString("F0"), 0);

                                }
                                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                                {
                                    strbu.AppendFormat("<li><span class=\"font_yellow\">会员：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.普通会员).ToString("F0"), 0);
                                    strbu.AppendFormat("<li><span class=\"font_yellow\">贵宾：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.贵宾会员).ToString("F0"), 0);
                                    strbu.AppendFormat("<li><a href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.代理).ToString("F0"), 0);
                                }
                                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理)
                                {
                                    strbu.AppendFormat("<li><span class=\"font_yellow\">会员：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.普通会员).ToString("F0"), 0);
                                    strbu.AppendFormat("<li><span class=\"font_yellow\">贵宾：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.贵宾会员).ToString("F0"), 0);
                                    strbu.AppendFormat("<li><span class=\"font_yellow\">代理：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.代理).ToString("F0"), 0);
                                }
                            }
                            else
                            {

                                strbu.AppendFormat("<li><span class=\"font_yellow\">会员：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.普通会员).ToString("F0"), 0);
                                strbu.AppendFormat("<li><a href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">贵宾：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.贵宾会员).ToString("F0"), 0);
                                strbu.AppendFormat("<li><a href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理：</span>成人{0}元/人 儿童{1}元/人</li>", UtilsCommons.GetGYStijia(FeeType, JSJCR, CRSCJ, MemberTypes.代理).ToString("F0"), 0);


                            }
                            litHtml.Text = strbu.ToString();
                        }
                    }
                    #endregion

                }

                #endregion
            }


            RegisterScript(boxString);//输出发班信息



        }

        protected void getSumMoney()
        {
            int routeType = Utils.GetInt(Utils.GetQueryStringValue("type"));


            EyouSoft.Model.Enum.FeeTypes FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
            if (routeType == 3) FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
            if (routeType == 1) FeeType = EyouSoft.Model.Enum.FeeTypes.国内线路;
            if (routeType == 2) FeeType = EyouSoft.Model.Enum.FeeTypes.国际线路;


            int peopleNum = Utils.GetInt(Utils.GetQueryStringValue("crs"));
            int childNum = Utils.GetInt(Utils.GetQueryStringValue("ets"));

            var tour = new EyouSoft.BLL.XianLuStructure.BXianLu().GetTourInfo(Utils.GetQueryStringValue("id"));
            if (tour == null) RCWE(UtilsCommons.AjaxReturnJson("0", "0")); ;
            var CRJ = UtilsCommons.GetGYStijia(FeeType, tour.JSJCR, tour.CRSCJ);
            var ETJ = UtilsCommons.GetGYStijia(FeeType, tour.JSJET, tour.ETSCJ);
            decimal sum = CRJ * peopleNum + ETJ * childNum;
            string getPriceInfo = string.Format("<li>成人：<span class=\"floatR\">¥{0}x{1}人</span></li><li>儿童：<span class=\"floatR\">¥{2}x{3}人</span></li>", CRJ.ToString("F0"), peopleNum, ETJ.ToString("F0"), childNum);
            decimal CRSCJ = tour.CRSCJ * peopleNum;
            decimal ETSCJ = tour.ETSCJ * childNum;
            decimal JSJCR = tour.JSJCR * peopleNum;
            decimal JSJET = tour.JSJET * childNum;

            var retObj = new retObj() { YH = getPriceInfo, PRICE = "" };
            RCWE(UtilsCommons.AjaxReturnJson("1", sum.ToString("F0"), retObj));


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

        /// <summary>
        /// 填充数据类
        /// </summary>
        class retObj
        {
            public string YH { get; set; }
            public string PRICE { get; set; }
        }


    }
}
