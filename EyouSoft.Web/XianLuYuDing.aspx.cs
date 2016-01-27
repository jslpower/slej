using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using Newtonsoft.Json.Converters;

namespace EyouSoft.Web
{
    public partial class XianLuYuDing : Common.Page.WebPageBase
    {

        protected string defaultHBID = "-1";
        protected string defaultHB = "";
        protected int routeType = 0;
        protected int isfenxiao = 0;//是否是分销商网站
        protected string thisurl = "";
        protected EyouSoft.Model.XianLuStructure.LineSource lineSource;
        protected void Page_Load(object sender, EventArgs e)
        {
            string hosturl = Request.Url.Host.ToLower();
            if (hosturl.IndexOf("www") >= 0)
            {
                hosturl = "slej.cn";
            }
            thisurl = "http://m." + hosturl + "/Line_Info.aspx?id=" + Utils.GetQueryStringValue("id") + "&type=" + Utils.GetQueryStringValue("type");
            //获取分销商的website
            string website = HttpContext.Current.Request.Url.Host.ToLower();

            //string website = "8191.slej.cn";
            if (website.IndexOf("slej.cn") > -1 && website.IndexOf("www") < 0)
            {
                isfenxiao = 1;
            }
            if (Utils.GetQueryStringValue("islogin") == "1") getLoginState();
            initPage();
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        void initPage()
        {
            #region 判断登陆
            Model.SSOStructure.MUserInfo userInfo = null;
            bool islogin = Security.Membership.UserProvider.IsLogin(out userInfo);
            if (islogin)
            {
                noLogin.Visible = false;
            }
            else
            {
                Login.Visible = false;
            }
            #endregion
            string xianluid = Utils.GetQueryStringValue("id");
            string TourId = Utils.GetQueryStringValue("tid");
            string hangban = Utils.GetQueryStringValue("hangban");
            string strScript = string.Empty;
            var model = new EyouSoft.BLL.XianLuStructure.BXianLu().GetInfo(xianluid);

            string boxString = "dataBox={}";
            if (model != null)
            {
                lineSource = model.Line_Source;
                //if (model.Line_Source == EyouSoft.Model.XianLuStructure.LineSource.光大)
                //{
                //    lit_Line.Text = "出团编号：";
                //}
                var areaType = new BLL.OtherStructure.BSysAreaInfo().GetSysAreaModel(model.AreaId);
                if (areaType != null)
                {
                    routeType = (int)areaType.RouteType;
                    lblRouteType.Text = areaType.RouteType == EyouSoft.Model.Enum.AreaType.出境线路 ? "国际线路" : areaType.RouteType.ToString();
                }

                if (model.Line_Source != EyouSoft.Model.XianLuStructure.LineSource.系统) model = new EyouSoft.InterfaceLib.APITour().SyncTour(model);
                bool isxianshi = false;
                if (model.TourTraffice.Any() && model.TourTraffice.Count > 0)//光大的线路的话取航班
                {
                    isxianshi = true;
                    if (model.TourTraffice != null && model.TourTraffice.Count > 0)
                    {
                        GDSelect.Text = string.Format("<input id=\"GDhid\" value=\"{0}\" type=hidden />", model.TourTraffice[0].TrafficId);
                    }


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
                                strHB.AppendFormat("<option value=\"{0}\"  selected=\"selected\">{1}{2}</option>", item.TrafficId, item.Traffic_01, item.Traffic_02);
                                litSelectHB.Text = string.Format("{0}<br/>{1}", item.Traffic_01, item.Traffic_02);
                                defaultHBID = item.TrafficId;
                            }
                            else
                            {
                                strHB.AppendFormat("<option value=\"{0}\"  >{1}-{2}</option>", item.TrafficId, item.Traffic_01, item.Traffic_02);
                            }

                        }
                        if (string.IsNullOrEmpty(hangban))
                        {
                            litSelectHB.Text = string.Format("{0}<br/>{1}", model.TourTraffice[0].Traffic_01, model.TourTraffice[0].Traffic_02);
                            defaultHBID = model.TourTraffice[0].TrafficId;
                        }
                    }
                    litHangBan.Text = strHB.ToString();
                    #endregion
                    PlaceHolder1.Visible = true;
                }

                litIMG.Text = string.IsNullOrEmpty(model.TeSeFilePath) ? "<img src=\"/images/line-xx-001.jpg\" />" : "<img src=\"" + model.TeSeFilePath + "\" />";
                lblXLMC.Text = Utils.ConverToStringByHtml(model.RouteName);
                lbljihedi.Text = model.JiHeFangShi;
                lblsongtuan.Text = model.LxrName;

                EyouSoft.Model.SystemStructure.MFeeSettings bilv = new EyouSoft.Model.SystemStructure.MFeeSettings();


                EyouSoft.Model.Enum.FeeTypes FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
                if (routeType == 3)
                {
                    FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
                    ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 12;
                }
                if (routeType == 1)
                {
                    FeeType = EyouSoft.Model.Enum.FeeTypes.国内线路;
                    ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 2;
                }
                if (routeType == 2)
                {
                    FeeType = EyouSoft.Model.Enum.FeeTypes.国际线路;
                    ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 3;
                }
                StringBuilder strJGlevel = new StringBuilder();//显示价格等级信息
                decimal crMsj = 0;
                decimal etMsj = 0;

                #region 服务项目
                if (!isDisplay)
                {
                    pla_none.Visible = false;
                }

                var chufadi = new EyouSoft.BLL.OtherStructure.BSysAreaInfo().GetSysCityModel(model.DepCityId);
                if (chufadi == null)//出发地
                {
                    cfd.Text = "杭州";
                }
                else
                {
                    cfd.Text = chufadi.Name;
                }
                if (model.XingChengs != null && model.XingChengs.Count > 0)
                {
                    rptlist.DataSource = model.XingChengs;
                    rptlist.DataBind();
                }
                if (model.FuWu != null)//服务
                {
                    if (model.Line_Source == EyouSoft.Model.XianLuStructure.LineSource.光大 || model.Line_Source == EyouSoft.Model.XianLuStructure.LineSource.旅游圈)
                    {
                        litGouwu.Text = Utils.ConverToHtml(model.FuWu.GouWuAnPai);
                        litFeiYong.Text = Utils.ConverToHtml(model.FuWu.FuWuBiaoZhun);
                        litBuBaoHan.Text = Utils.ConverToHtml(model.FuWu.BuHanXiangMu);
                        litErTong.Text = Utils.ConverToHtml(model.FuWu.ErTongAnPai);
                        litZiFei.Text = Utils.ConverToHtml(model.FuWu.ZiFeiXiangMu);
                        litTiShi.Text = Utils.ConverToHtml(model.FuWu.WenXinTiXing);
                        litZhuYi.Text = Utils.ConverToHtml(model.FuWu.ZhuYiShiXiang);
                        litBaoMing.Text = Utils.ConverToHtml(model.FuWu.BaoMingXuZhi);
                        litZengSong.Text = Utils.ConverToHtml(model.FuWu.ZengSongXiangMu);
                        litQiTa.Text = Utils.ConverToHtml(model.FuWu.QiTaShiXiang);
                        litShuoMing.Text = Utils.ConverToHtml(model.TeSe);
                    }
                    else
                    {
                        litGouwu.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.GouWuAnPai));
                        litFeiYong.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.FuWuBiaoZhun));
                        litBuBaoHan.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.BuHanXiangMu));
                        litErTong.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.ErTongAnPai));
                        litZiFei.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.ZiFeiXiangMu));
                        litTiShi.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.WenXinTiXing));
                        litZhuYi.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.ZhuYiShiXiang));
                        litBaoMing.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.BaoMingXuZhi));
                        litZengSong.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.ZengSongXiangMu));
                        litQiTa.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.FuWu.QiTaShiXiang));
                        litShuoMing.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(model.TeSe));
                    }
                }
                #endregion


                #region 发班信息
                int yiShouRenShu = 0;

                if (model.Tours != null && model.Tours.Count > 0)
                {
                    var s = new StringBuilder();
                    var items = model.Tours.Where(m => m.LDate >= DateTime.Now).ToList();
                    foreach (var item in items)
                    {
                        yiShouRenShu += item.YiShouRenShu;
                        if (item.LDate <= DateTime.Today) continue;
                        if (item.TrafficId != defaultHBID && isxianshi) continue;//只取一个航班号
                        if (item.TourId == TourId)
                        {
                            s.AppendFormat("<option value=\"{0}\"  data-riqi={1}  selected=\"selected\">", item.TourId, item.LDate.ToString("yyyy-MM-dd"));

                            #region  如果选择游发班日期 刷新页面价格信息
                            strJGlevel = new StringBuilder("");
                            strJGlevel.AppendFormat("<li><strong>门市价：</strong>成人价：<b class=\"fontblue font14 hline\">¥<span id=\"s_crmsj\">{0}</span></b>元/人 儿童价：<b class=\"fontred font14 hline\">¥<span id=\"s_etmsj\">{1}</span></b>元/人</li>"
                    , item.CRSCJ.ToString("F0")
                    , item.ETSCJ.ToString("F0"));

                            strJGlevel.AppendFormat("<li><strong>优惠价：</strong>成人价：<b class=\"fontblue font14\">¥<span id=\"s_hycrj\">{0}</span></b>元/人 儿童价：<b class=\"fontred font14\">¥<span id=\"s_hyet\">{1}</span></b>元/人</li>"
                                , UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0")
                                , UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0"));
                            if (userInfo != null)
                            {
                                if (userInfo.UserType >= EyouSoft.Model.Enum.MemberTypes.免费代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                                {
                                    strJGlevel.AppendFormat("<li><strong>代销价：</strong>成人价：<b class=\"fontblue font14\">¥<span id=\"s_gbcrj\">{0}</span></b>元/人 儿童价：<b class=\"fontred font14\">¥<span id=\"s_gbetj\">{1}</span></b>元/人</li>", UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0"));
                                }
                                if (userInfo.UserType >= EyouSoft.Model.Enum.MemberTypes.贵宾会员 && userInfo.UserType != EyouSoft.Model.Enum.MemberTypes.免费代理)
                                {
                                    strJGlevel.AppendFormat("<li><strong>贵宾价：</strong>成人价：<b class=\"fontblue font14\">¥<span id=\"s_gbcrj\">{0}</span></b>元/人 儿童价：<b class=\"fontred font14\">¥<span id=\"s_gbetj\">{1}</span></b>元/人</li>", UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0"));
                                }
                                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                {
                                    strJGlevel.AppendFormat("<li><strong>代理价：</strong>成人价：<b class=\"fontblue font14\">¥<span id=\"s_dlcrj\">{0}</span></b>元/人 儿童价：<b class=\"fontred font14\">¥<span id=\"s_dletj\">{1}</span></b>元/人</li>", UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0"));
                                }
                            }
                            litJGlevel.Text = strJGlevel.ToString();//发团日期
                            #endregion

                            #region  如果选择发班日期 优惠信息
                            crMsj = item.CRSCJ;
                            etMsj = item.ETSCJ;


                            litHuiYuan.Text = string.Format("<li id=\"hy_li\" class=\"mar5\"><div class=\"tixing\"><b>优惠价总金额：</b><br><font class=\"fontyellow\">成人<b class=\"font14\"><span id=\"hycrj\">{0}</span></b>元/人 x <b class=\"font14\"><span id=\"hycrs\">1</span></b>人+ 儿童<b class=\"font14\"><span id=\"hyetj\">{1}</span></b>元/人 x <b class=\"font14\"><span id=\"hyets\">0</span></b>人 = </font><font class=\"fontblue\"><b class=\"font14\"><span id=\"hyzj\">{0}</span></b>元</font></div></li>"
                                 , UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0")
                                 , UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0")
                              );

                            if (isDisplay)
                            //if (isDisplay && ((userInfo != null && (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 <= (int)userInfo.UserType) || userInfo == null))
                            {
                                litGuiBin.Text = string.Format("<li id=\"gb_li\" class=\"mar5\"><div class=\"tixing\"><b>{3}：</b><br><font class=\"fontyellow\">成人<b class=\"font14\"><span id=\"gbcrj\">{0}</span></b>元/人 x <b class=\"font14\"><span id=\"gbcrs\">1</span></b>人+ 儿童<b class=\"font14\"><span id=\"gbetj\">{1}</span></b>元/人 x <b class=\"font14\"><span id=\"gbets\">0</span></b>人 = </font><font class=\"fontblue\"><b class=\"font14\"><span id=\"gbzj\">{0}</span></b>元</font><br><b class=\"fontblue\">立省<span id=\"gbyhj\">{4}</span>元</b>{2}</div></li>"
                                     , UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0")
                                     , UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0")
                                      , (userInfo != null && (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 > (int)userInfo.UserType) || userInfo == null ? "<a  target=\"_blank\"  class=\"btn001 huiyuan\" href=\"/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\"><span>马上申请</span></a>" : ""
                                      , (userInfo != null && (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 > (int)userInfo.UserType) || userInfo == null ? "申请贵宾身份" : "贵宾价总金额"
                                      , (UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员) - UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员)).ToString("F0"));//贵宾优惠信息
                            }
                            if (isDisplay)
                            //if (isDisplay && ((userInfo != null && (int)EyouSoft.Model.Enum.MemberTypes.分销商 <= (int)userInfo.UserType) || userInfo == null))
                            {
                                litDaiLi.Text = string.Format("<li id=\"dl_li\"><div class=\"tixing\"><b>{3}：</b><br><font class=\"fontyellow\">成人<b class=\"font14\"><span id=\"dlcrj\">{0}</span></b>元/人 x <b class=\"font14\"><span id=\"dlcrs\">1</span></b>人+ 儿童<b class=\"font14\"><span id=\"dletj\">{1}</span></b>元/人 x <b class=\"font14\"><span id=\"dlets\">0</span></b>人 = </font><font class=\"fontblue\"><b class=\"font14\"><span id=\"dlzj\">{0}</span></b>元</font><br><b class=\"fontblue\">立省<span id=\"dlyhj\">{4}</span>元</b>{2}</div></li>"
                                    , UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0")
                                    , UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0")

                                    , (userInfo != null && (int)EyouSoft.Model.Enum.MemberTypes.代理 > (int)userInfo.UserType) || userInfo == null ? "<a  target=\"_blank\" class=\"btn001 huiyuan\" href=\"/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\"><span>马上申请</span></a>" : ""
                                    , (userInfo != null && (int)EyouSoft.Model.Enum.MemberTypes.代理 > (int)userInfo.UserType) || userInfo == null ? "申请代理身份" : "代理价总金额"
                                     , (UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员) - UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理)).ToString("F0"));//代理商优惠信息
                            }
                            #endregion

                        }
                        else
                        {
                            s.AppendFormat("<option data-riqi={1} value=\"{0}\">", item.TourId, item.LDate.ToString("yyyy-MM-dd"));


                        }

                        s.AppendFormat("{0}({1})", item.LDate.ToString("MM-dd"), Utils.ConvertWeekDayToChinese(item.LDate));
                        s.AppendFormat(" 成人:{0}/人", UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ).ToString("F0"));
                        s.AppendFormat(" 儿童:{0}/人", UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ).ToString("F0"));
                        s.Append("</option>");
                    }
                    if (string.IsNullOrEmpty(TourId))
                    {
                        #region  如果没有选择发班日期 默认第一个日期


                        var selectTraffice = items.Where(i => i.TrafficId == defaultHBID).ToList();

                        if (!selectTraffice.Any() || selectTraffice.Count == 0)
                        {
                            selectTraffice = items;
                        }


                        strJGlevel = new StringBuilder("");
                        strJGlevel.AppendFormat("<li><strong>门市价：</strong>成人价：<b class=\"fontblue font14 hline\">¥<span id=\"s_crmsj\">{0}</span></b>元/人 儿童价：<b class=\"fontred font14 hline\">¥<span id=\"s_etmsj\">{1}</span></b>元/人</li>"
                , selectTraffice[0].CRSCJ.ToString("F0")
                , selectTraffice[0].ETSCJ.ToString("F0"));

                        strJGlevel.AppendFormat("<li><strong>优惠价：</strong>成人价：<b class=\"fontblue font14\">¥<span id=\"s_hycrj\">{0}</span></b>元/人 儿童价：<b class=\"fontred font14\">¥<span id=\"s_hyetj\">{1}</span></b>元/人</li>"
                            , UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJCR, selectTraffice[0].CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0")
                            , UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJET, selectTraffice[0].ETSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0"));
                        if (userInfo != null)
                        {
                            if (userInfo.UserType >= EyouSoft.Model.Enum.MemberTypes.免费代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                            {
                                strJGlevel.AppendFormat("<li><strong>代销价：</strong>成人价：<b class=\"fontblue font14\">¥<span id=\"s_gbcrj\">{0}</span></b>元/人 儿童价：<b class=\"fontred font14\">¥<span id=\"s_gbetj\">{1}</span></b>元/人</li>", UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJCR, selectTraffice[0].CRSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJET, selectTraffice[0].ETSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0"));
                            }
                            if (userInfo.UserType >= EyouSoft.Model.Enum.MemberTypes.贵宾会员 && userInfo.UserType != EyouSoft.Model.Enum.MemberTypes.免费代理)
                            {
                                strJGlevel.AppendFormat("<li><strong>贵宾价：</strong>成人价：<b class=\"fontblue font14\">¥<span id=\"s_gbcrj\">{0}</span></b>元/人 儿童价：<b class=\"fontred font14\">¥<span id=\"s_gbetj\">{1}</span></b>元/人</li>", UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJCR, selectTraffice[0].CRSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJET, selectTraffice[0].ETSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0"));
                            }
                            if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                            {
                                strJGlevel.AppendFormat("<li><strong>代理价：</strong>成人价：<b class=\"fontblue font14\">¥<span id=\"s_dlcrj\">{0}</span></b>元/人 儿童价：<b class=\"fontred font14\">¥<span id=\"s_dletj\">{1}</span></b>元/人</li>", UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJCR, selectTraffice[0].CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0"), UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJET, selectTraffice[0].ETSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0"));
                            }
                        }
                        litJGlevel.Text = strJGlevel.ToString();//发团日期
                        #endregion

                        #region  如果没有选择发班日期 优惠信息
                        crMsj = selectTraffice[0].CRSCJ;
                        etMsj = selectTraffice[0].ETSCJ;


                        litHuiYuan.Text = string.Format("<li id=\"hy_li\" class=\"mar5\"><div class=\"tixing\"><b>优惠价总金额：</b><br><font class=\"fontyellow\">成人<b class=\"font14\"><span id=\"hycrj\">{0}</span></b>元/人 x <b class=\"font14\"><span id=\"hycrs\">1</span></b>人+ 儿童<b class=\"font14\"><span id=\"hyetj\">{1}</span></b>元/人 x <b class=\"font14\"><span id=\"hyets\">0</span></b>人 = </font><font class=\"fontblue\"><b class=\"font14\"><span id=\"hyzj\">{0}</span></b>元</font></div></li>"
                             , UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJCR, selectTraffice[0].CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0")
                             , UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJET, selectTraffice[0].ETSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0")
                          );

                        if (isDisplay)
                        //if (isDisplay && ((userInfo != null && (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 <= (int)userInfo.UserType) || userInfo == null))
                        {
                            litGuiBin.Text = string.Format("<li id=\"gb_li\" class=\"mar5\"><div class=\"tixing\"><b>{3}：</b><br><font class=\"fontyellow\">成人<b class=\"font14\"><span id=\"gbcrj\">{0}</span></b>元/人 x <b class=\"font14\"><span id=\"gbcrs\">1</span></b>人+ 儿童<b class=\"font14\"><span id=\"gbetj\">{1}</span></b>元/人 x <b class=\"font14\"><span id=\"gbets\">0</span></b>人 = </font><font class=\"fontblue\"><b class=\"font14\"><span id=\"gbzj\">{0}</span></b>元</font><br><b class=\"fontblue\">立省<span id=\"gbyhj\">{4}</span>元</b>{2}</div></li>"
                                 , UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJCR, selectTraffice[0].CRSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0")
                                 , UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJET, selectTraffice[0].ETSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0")
                                  , (userInfo != null && (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 > (int)userInfo.UserType) || userInfo == null ? "<a target=\"_blank\" class=\"btn001 huiyuan\" href=\"/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\"><span>马上申请</span></a>" : ""
                                   , (userInfo != null && (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 > (int)userInfo.UserType) || userInfo == null ? "申请贵宾身份" : "贵宾价总金额"
                                   , (UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJCR, selectTraffice[0].CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员) - UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJCR, selectTraffice[0].CRSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员)).ToString("F0"));//贵宾优惠信息
                        }
                        if (isDisplay)
                        //if (isDisplay && ((userInfo != null && (int)EyouSoft.Model.Enum.MemberTypes.分销商 <= (int)userInfo.UserType) || userInfo == null))
                        {
                            litDaiLi.Text = string.Format("<li id=\"dl_li\"><div class=\"tixing\"><b>{3}：</b><br><font class=\"fontyellow\">成人<b class=\"font14\"><span id=\"dlcrj\">{0}</span></b>元/人 x <b class=\"font14\"><span id=\"dlcrs\">1</span></b>人+ 儿童<b class=\"font14\"><span id=\"dletj\">{1}</span></b>元/人 x <b class=\"font14\"><span id=\"dlets\">0</span></b>人 = </font><font class=\"fontblue\"><b class=\"font14\"><span id=\"dlzj\">{0}</span></b>元</font><br><b class=\"fontblue\">立省<span id=\"dlyhj\">{4}</span>元</b>{2}</div></li>"
                                , UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJCR, selectTraffice[0].CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0")
                                , UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJET, selectTraffice[0].ETSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0")

                                , (userInfo != null && (int)EyouSoft.Model.Enum.MemberTypes.代理 > (int)userInfo.UserType) || userInfo == null ? "<a  target=\"_blank\"  class=\"btn001 huiyuan\" href=\"/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\"><span>马上申请</span></a>" : ""
                                  , (userInfo != null && (int)EyouSoft.Model.Enum.MemberTypes.代理 > (int)userInfo.UserType) || userInfo == null ? "申请代理身份" : "代理价总金额"
                                  , (UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJCR, selectTraffice[0].CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员) - UtilsCommons.GetGYStijia(FeeType, selectTraffice[0].JSJCR, selectTraffice[0].CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理)).ToString("F0"));//代理商优惠信息
                        }
                        #endregion
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
                    boxString = string.Format("dataBox={0}", Newtonsoft.Json.JsonConvert.SerializeObject(nlist, isDate));
                    strScript = boxString;
                    if (s.Length > 0) ltrFaBanOptions.Text = s.ToString();
                }

                #endregion
            }

            int areatype = routeType;
            EyouSoft.Model.Enum.AreaType[] areaArr = null;
            if (areatype > 0)
            {
                areaArr = new EyouSoft.Model.Enum.AreaType[] { (EyouSoft.Model.Enum.AreaType)areatype };
            }
            var tuijians = new EyouSoft.BLL.XianLuStructure.BXianLu().GetXianLus(20, new EyouSoft.Model.XianLuStructure.MXianLuChaXunInfo() { AreaTypes = areaArr, isNoTour = true });
            if (tuijians != null && tuijians.Count > 0)
            {
                rptLeftList.DataSource = rptRightList.DataSource = tuijians;
                rptLeftList.DataBind();
                rptRightList.DataBind();

            }
            RegisterScript(boxString);//输出发班信息
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

        protected string getXcStr(object xianluSource, object xingChengStr)
        {
            EyouSoft.Model.XianLuStructure.LineSource source = (EyouSoft.Model.XianLuStructure.LineSource)xianluSource;
            if (source == EyouSoft.Model.XianLuStructure.LineSource.光大 || source == EyouSoft.Model.XianLuStructure.LineSource.旅游圈)
            {
                return Utils.ConverToHtml(xingChengStr.ToString());
            }
            else
            {
                return Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(xingChengStr.ToString()));
            }

        }
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
        /// 优惠价
        /// </summary>
        public string hyj { get; set; }
        /// <summary>
        /// 余位
        /// </summary>
        public int yw { get; set; }
    }
}
