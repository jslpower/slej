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

namespace EyouSoft.Web
{
    public partial class ZiZhuTuan : Common.Page.WebPageBase
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
        protected int usertp=1;//会员类型
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("islogin") == "1") getLoginState();
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "save")
            {
                OrderSub();
            }
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("id")) && !string.IsNullOrEmpty(Utils.GetQueryStringValue("type")))
            {
                initPage();
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
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
                    if (model.TourTraffice != null && model.TourTraffice.Count > 0)
                    {
                        //GDSelect.Text = string.Format("<input id=\"GDhid\" value=\"{0}\" type=hidden />", model.Tours[0].TrafficId);
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
                                defaultHBID = item.TrafficId;
                            }
                            else
                            {
                                strHB.AppendFormat("<option value=\"{0}\"  >{1}-{2}</option>", item.TrafficId, item.Traffic_01, item.Traffic_02);
                            }

                        }
                        if (string.IsNullOrEmpty(hangban))
                        {
                            defaultHBID = model.TourTraffice[0].TrafficId;
                        }
                    }
                    litHangBan.Text = strHB.ToString();
                    #endregion
                    PlaceHolder1.Visible = true;
                    PlaceHolder2.Visible = false;
                }

                lblXLMC.Text = Utils.ConverToStringByHtml(model.RouteName);
                XianLuName.Value = Utils.ConverToStringByHtml(model.RouteName);

                EyouSoft.Model.SystemStructure.MFeeSettings bilv = new EyouSoft.Model.SystemStructure.MFeeSettings();


                EyouSoft.Model.Enum.FeeTypes FeeType = EyouSoft.Model.Enum.FeeTypes.组团;
                if (routeType == 3)
                {
                    ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 12;
                }
                if (routeType == 1)
                {
                    ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 2;
                }
                if (routeType == 2)
                {
                    ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 3;
                }
                StringBuilder strJGlevel = new StringBuilder();//显示价格等级信息
                decimal crMsj = 0;
                decimal etMsj = 0;
                
                #region 价格等级显示

                string JiageDengji = "";
                JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                    + "门市价：成人价<input type=\"text\" data-name=\"MenShiMoney\" class=\"bj_input formsize80 fontred16\" value=\"" + model.SCJCR.ToString("F0") + "\" />元/人"
                    + "</th><th align=\"right\" width=\"33%\">"
                    + "优惠价：成人价<input type=\"text\" data-name=\"HuiYuanMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, model.JSJCR, model.SCJCR, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "\" />元/人"
                    +"</th>";
                crjiage =model.SCJCR;
                etjiage = model.SCJET;
                crjiesuan = model.JSJCR;
                etjiesuan = model.JSJET;
                if (userInfo != null)
                {
                    if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                    {
                        JiageDengji += "<th align=\"right\" width=\"33%\">贵宾价：成人价<input type=\"text\" data-name=\"GuiBingMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, model.JSJCR, model.SCJCR, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "\" />元/人</th>";
                    }
                    else if (userInfo.UserType == MemberTypes.免费代理)
                    {
                        JiageDengji += "<th align=\"right\" width=\"33%\">代销价：成人价<input type=\"text\" data-name=\"DaiXiaoMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, model.JSJCR, model.SCJCR, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + "\" />元/人</th>";
                    }
                    else
                    {
                        JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                    }
                }
                else
                {
                    JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                }
                JiageDengji += "</tr><tr><th align=\"right\" width=\"33%\">"
                    + "儿童价<input type=\"text\" data-name=\"MenShiMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + model.SCJET.ToString("F0") + "\" />元/人"
                    + "</th><th align=\"right\" width=\"33%\">"
                    + "儿童价<input type=\"text\" data-name=\"HuiYuanMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, model.JSJET, model.SCJET, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "\" />元/人</th>";
                if(userInfo != null)
                    {
                        if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                        {
                            JiageDengji += "<th align=\"right\" width=\"33%\">儿童价<input type=\"text\"  data-name=\"GuiBingMoney\" class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, model.JSJET, model.SCJET, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "\" />元/人</th>";
                        }
                        else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                        {
                            JiageDengji += "<th align=\"right\" width=\"33%\">儿童价<input type=\"text\"  data-name=\"DaiXiaoMoney\" class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, model.JSJET, model.SCJET, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + "\" />元/人</th>";
                        }
                        else
                        {
                            JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                        }
                    }
                    else
                    {
                        JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                    }
                   JiageDengji += "</tr>";
                   JiageDengji += "<tr><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongMenShiMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                   JiageDengji += "<th align=\"right\">总　价<input type=\"text\" data-name=\"ZongHuiYuanMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                if (userInfo != null)
                {
                    if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                    {
                        JiageDengji += "<th align=\"right\">总　价<input type=\"text\" data-name=\"ZongGuiBingMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                    }
                    else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                    {
                        JiageDengji += "<th align=\"right\">总　价<input type=\"text\" data-name=\"ZongDaiXiaoMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                    }
                    else
                    {
                        JiageDengji += "<th align=\"right\">&nbsp;</th>";
                    }
                }
                 JiageDengji += "</tr>";
                   if(userInfo != null)
                   {
                        if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理)
                        {
                            JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                        + "代理价：成人价<input type=\"text\" data-name=\"DaiLiMoney\"  class=\"bj_input formsize80 fontred16\" value=\""+UtilsCommons.GetGYStijia(FeeType, model.JSJCR, model.SCJCR, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0")+"\" />元/人</th><th align=\"right\">&nbsp;</th><th align=\"right\">&nbsp;</th></tr>";
                            JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                        + "儿童价<input type=\"text\" data-name=\"DaiLiMoney\"  class=\"bj_input formsize80 fontred16\" value=\""+UtilsCommons.GetGYStijia(FeeType, model.JSJET, model.SCJET, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0")+"\" />元/人</th><th align=\"right\">&nbsp;</th><th align=\"right\">&nbsp;</th></tr>";
                            JiageDengji += "<tr><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongDaiLiMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th><th align=\"right\">&nbsp;</th><th align=\"right\">&nbsp;</th></tr>";

                        }
                       if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                        {
                            JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                        + "代理价：成人价<input type=\"text\"  data-name=\"DaiLiMoney\" class=\"bj_input formsize80 fontred16\" value=\""+UtilsCommons.GetGYStijia(FeeType, model.JSJCR, model.SCJCR, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0")+"\" />元/人</th><th align=\"right\">员工价：成人价<input type=\"text\" data-name=\"YuanGongMoney\"  class=\"bj_input formsize80 fontred16\" value=\""+UtilsCommons.GetGYStijia(FeeType, model.JSJCR, model.SCJCR, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0")+"\" />元/人</th><th align=\"right\">&nbsp;</th></tr>";
                            JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                        + "儿童价<input type=\"text\" data-name=\"DaiLiMoney\"  class=\"bj_input formsize80 fontred16\" value=\""+UtilsCommons.GetGYStijia(FeeType, model.JSJET, model.SCJET, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0")+"\" />元/人</th><th align=\"right\">儿童价<input type=\"text\" data-name=\"YuanGongMoney\"  class=\"bj_input formsize80 fontred16\" value=\""+UtilsCommons.GetGYStijia(FeeType, model.JSJET, model.SCJET, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0")+"\" />元/人</th><th align=\"right\">&nbsp;</th></tr>";
                            JiageDengji += "<tr><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongDailiMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongYuanGongMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" /></th><th align=\"right\">&nbsp;</th></tr>";

                        }
                   }
                   
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
                    foreach (var item in items)
                    {
                        yiShouRenShu += item.YiShouRenShu;
                        if (item.LDate <= DateTime.Today) continue;
                        if (item.TrafficId != defaultHBID && isxianshi) continue;//只取一个航班号
                        if (item.TourId == TourId)
                        {
                            s.AppendFormat("<option value=\"{0}\"  data-riqi={1}  selected=\"selected\">", item.TourId, item.LDate.ToString("yyyy-MM-dd"));

                            #region  如果选择游发班日期 刷新页面价格信息
                            JiageDengji = "<tr><th align=\"right\" width=\"33%\">"
                   + "门市价：成人价<input type=\"text\" data-name=\"MenShiMoney\" class=\"bj_input formsize80 fontred16\" value=\"" + item.CRSCJ.ToString("F0") + "\" />元/人"
                   + "</th><th align=\"right\" width=\"33%\">"
                   + "优惠价：成人价<input type=\"text\" data-name=\"HuiYuanMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "\" />元/人"
                   + "</th>";
                            crjiage =item.CRSCJ;
                            etjiage = item.ETSCJ;
                            crjiesuan = item.JSJCR;
                            etjiesuan = item.JSJET;
                            if (userInfo != null)
                            {
                                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                {
                                    JiageDengji += "<th align=\"right\" width=\"33%\">贵宾价：成人价<input type=\"text\" data-name=\"GuiBingMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "\" />元/人</th>";

                                }
                                else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                                {
                                    JiageDengji += "<th align=\"right\" width=\"33%\">代销价：成人价<input type=\"text\" data-name=\"DaiXiaoMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + "\" />元/人</th>";

                                }
                                else
                                {
                                    JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                                }
                            }
                            else
                            {
                                JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                            }
                            JiageDengji += "</tr><tr><th align=\"right\" width=\"33%\">"
                                + "儿童价<input type=\"text\" data-name=\"MenShiMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + item.ETSCJ.ToString("F0") + "\" />元/人"
                                + "</th><th align=\"right\" width=\"33%\">"
                                + "儿童价<input type=\"text\" data-name=\"HuiYuanMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "\" />元/人</th>";
                            if (userInfo != null)
                            {
                                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                {
                                    JiageDengji += "<th align=\"right\" width=\"33%\">儿童价<input type=\"text\"  data-name=\"GuiBingMoney\" class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "\" />元/人</th>";
                                }
                                else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                                {
                                    JiageDengji += "<th align=\"right\" width=\"33%\">儿童价<input type=\"text\"  data-name=\"DaiXiaoMoney\" class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + "\" />元/人</th>";
                                }
                                else
                                {
                                    JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                                }
                            }
                            else
                            {
                                JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                            }
                            JiageDengji += "</tr>";
                            JiageDengji += "<tr><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongMenShiMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                            JiageDengji += "<th align=\"right\">总　价<input type=\"text\" data-name=\"ZongHuiYuanMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                            if (userInfo != null)
                            {
                                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                {
                                    JiageDengji += "<th align=\"right\">总　价<input type=\"text\" data-name=\"ZongGuiBingMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                                }
                                else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                                {
                                    JiageDengji += "<th align=\"right\">总　价<input type=\"text\" data-name=\"ZongDaiXiaoMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                                }
                                else
                                {
                                    JiageDengji += "<th align=\"right\">&nbsp;</th>";
                                }
                            }
                            JiageDengji += "</tr>";
                            if (userInfo != null)
                            {
                                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理)
                                {
                                    JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                                + "代理价：成人价<input type=\"text\" data-name=\"DaiLiMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "\" />元/人</th><th align=\"right\">&nbsp;</th><th align=\"right\">&nbsp;</th></tr>";
                                    JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                                + "儿童价<input type=\"text\" data-name=\"DaiLiMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "\" />元/人</th><th align=\"right\">&nbsp;</th><th align=\"right\">&nbsp;</th></tr>";
                                    JiageDengji += "<tr><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongDaiLiMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th><th align=\"right\">&nbsp;</th><th align=\"right\">&nbsp;</th></tr>";

                                }
                                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                {
                                    JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                                + "代理价：成人价<input type=\"text\"  data-name=\"DaiLiMoney\" class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "\" />元/人</th><th align=\"right\">员工价：成人价<input type=\"text\" data-name=\"YuanGongMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0") + "\" />元/人</th><th align=\"right\">&nbsp;</th></tr>";
                                    JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                                + "儿童价<input type=\"text\" data-name=\"DaiLiMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "\" />元/人</th><th align=\"right\">儿童价<input type=\"text\" data-name=\"YuanGongMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0") + "\" />元/人</th><th align=\"right\">&nbsp;</th></tr>";
                                    JiageDengji += "<tr><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongDailiMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongYuanGongMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" /></th><th align=\"right\">&nbsp;</th></tr>";

                                }
                            }


                            #endregion

                        }
                        else
                        {
                            s.AppendFormat("<option data-riqi={1} value=\"{0}\">", item.TourId, item.LDate.ToString("yyyy-MM-dd"));
                            #region  如果选择游发班日期 刷新页面价格信息
                            JiageDengji = "<tr><th align=\"right\" width=\"33%\">"
                   + "门市价：成人价<input type=\"text\" data-name=\"MenShiMoney\" class=\"bj_input formsize80 fontred16\" value=\"" + item.CRSCJ.ToString("F0") + "\" />元/人"
                   + "</th><th align=\"right\" width=\"33%\">"
                   + "优惠价：成人价<input type=\"text\" data-name=\"HuiYuanMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "\" />元/人"
                   + "</th>";
                            crjiage = item.CRSCJ;
                            crjiesuan = item.JSJCR;
                            etjiage = item.ETSCJ;
                            etjiesuan = item.JSJET;
                            if (userInfo != null)
                            {
                                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                {
                                    JiageDengji += "<th align=\"right\" width=\"33%\">贵宾价：成人价<input type=\"text\" data-name=\"GuiBingMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "\" />元/人</th>";

                                }
                                else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                                {
                                    JiageDengji += "<th align=\"right\" width=\"33%\">代销价：成人价<input type=\"text\" data-name=\"DaiXiaoMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + "\" />元/人</th>";

                                }
                                else
                                {
                                    JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                                }
                            }
                            else
                            {
                                JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                            }
                            JiageDengji += "</tr><tr><th align=\"right\" width=\"33%\">"
                                + "儿童价<input type=\"text\" data-name=\"MenShiMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + item.ETSCJ.ToString("F0") + "\" />元/人"
                                + "</th><th align=\"right\" width=\"33%\">"
                                + "儿童价<input type=\"text\" data-name=\"HuiYuanMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "\" />元/人</th>";
                            if (userInfo != null)
                            {
                                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                {
                                    JiageDengji += "<th align=\"right\" width=\"33%\">儿童价<input type=\"text\"  data-name=\"GuiBingMoney\" class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "\" />元/人</th>";
                                }
                                else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                                {
                                    JiageDengji += "<th align=\"right\" width=\"33%\">儿童价<input type=\"text\"  data-name=\"DaiXiaoMoney\" class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "\" />元/人</th>";
                                }
                                else
                                {
                                    JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                                }
                            }
                            else
                            {
                                JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                            }
                            JiageDengji += "</tr>";
                            JiageDengji += "<tr><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongMenShiMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                            JiageDengji += "<th align=\"right\">总　价<input type=\"text\" data-name=\"ZongHuiYuanMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                            if (userInfo != null)
                            {
                                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                {
                                    JiageDengji += "<th align=\"right\">总　价<input type=\"text\" data-name=\"ZongGuiBingMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                                }
                                else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                                {
                                    JiageDengji += "<th align=\"right\">总　价<input type=\"text\" data-name=\"ZongDaiXiaoMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                                }
                                else
                                {
                                    JiageDengji += "<th align=\"right\">&nbsp;</th>";
                                }
                            }
                            JiageDengji += "</tr>";
                            if (userInfo != null)
                            {
                                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理)
                                {
                                    JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                                + "代理价：成人价<input type=\"text\" data-name=\"DaiLiMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "\" />元/人</th><th align=\"right\">&nbsp;</th><th align=\"right\">&nbsp;</th></tr>";
                                    JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                                + "儿童价<input type=\"text\" data-name=\"DaiLiMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "\" />元/人</th><th align=\"right\">&nbsp;</th><th align=\"right\">&nbsp;</th></tr>";
                                    JiageDengji += "<tr><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongDaiLiMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th><th align=\"right\">&nbsp;</th><th align=\"right\">&nbsp;</th></tr>";

                                }
                                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                {
                                    JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                                + "代理价：成人价<input type=\"text\"  data-name=\"DaiLiMoney\" class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "\" />元/人</th><th align=\"right\">员工价：成人价<input type=\"text\" data-name=\"YuanGongMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0") + "\" />元/人</th><th align=\"right\">&nbsp;</th></tr>";
                                    JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                                + "儿童价<input type=\"text\" data-name=\"DaiLiMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "\" />元/人</th><th align=\"right\">儿童价<input type=\"text\" data-name=\"YuanGongMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0") + "\" />元/人</th><th align=\"right\">&nbsp;</th></tr>";
                                    JiageDengji += "<tr><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongDailiMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongYuanGongMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" /></th><th align=\"right\">&nbsp;</th></tr>";

                                }
                            }


                            #endregion

                        }

                        s.AppendFormat("{0}({1})  (拼团价", item.LDate.ToString("MM-dd"), Utils.ConvertWeekDayToChinese(item.LDate));
                        s.AppendFormat(" 成人:{0}/人",  item.CRSCJ.ToString("F0"));
                        s.AppendFormat(" 儿童:{0}/人)", item.ETSCJ.ToString("F0"));
                        s.Append("</option>");
                    }
                    if (string.IsNullOrEmpty(TourId))
                    {
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

                                    strJGlevel = new StringBuilder("");
                                    strJGlevel.AppendFormat("<li><strong>门市价：</strong>成人价：<b class=\"fontblue font14 hline\">¥<span id=\"s_crmsj\">{0}</span></b>元/人 儿童价：<b class=\"fontred font14 hline\">¥<span id=\"s_etmsj\">{1}</span></b>元/人</li>"
                            , item.CRSCJ.ToString("F0")
                            , item.ETSCJ.ToString("F0"));
                                    XianLuMonth.Value = (Convert.ToDateTime(item.LDate).Month).ToString();
                                    XianLuYear.Value = (Convert.ToDateTime(item.LDate).Year).ToString();
                                    XianLuDay.Value = (Convert.ToDateTime(item.LDate).Day).ToString();
                                    XLTourId.Value = item.TourId;


                                    JiageDengji = "<tr><th align=\"right\" width=\"33%\">"
                               + "门市价：成人价<input type=\"text\" data-name=\"MenShiMoney\" class=\"bj_input formsize80 fontred16\" value=\"" + item.CRSCJ.ToString("F0") + "\" />元/人"
                               + "</th><th align=\"right\" width=\"33%\">"
                               + "优惠价：成人价<input type=\"text\" data-name=\"HuiYuanMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "\" />元/人"
                               + "</th>";
                                    crjiage = item.CRSCJ;
                                    etjiage = item.ETSCJ;
                                    crjiesuan = item.JSJCR;
                                    etjiesuan = item.JSJET;
                                    if (userInfo != null)
                                    {
                                        if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                        {
                                            JiageDengji += "<th align=\"right\" width=\"33%\">贵宾价：成人价<input type=\"text\" data-name=\"GuiBingMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "\" />元/人</th>";

                                        }
                                        else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                                        {
                                            JiageDengji += "<th align=\"right\" width=\"33%\">代销价：成人价<input type=\"text\" data-name=\"DaiXiaoMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + "\" />元/人</th>";

                                        }
                                        else
                                        {
                                            JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                                        }
                                    }
                                    else
                                    {
                                        JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                                    }
                                    JiageDengji += "</tr><tr><th align=\"right\" width=\"33%\">"
                                        + "儿童价<input type=\"text\" data-name=\"MenShiMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + item.ETSCJ.ToString("F0") + "\" />元/人"
                                        + "</th><th align=\"right\" width=\"33%\">"
                                        + "儿童价<input type=\"text\" data-name=\"HuiYuanMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + "\" />元/人</th>";
                                    if (userInfo != null)
                                    {
                                        if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                        {
                                            JiageDengji += "<th align=\"right\" width=\"33%\">儿童价<input type=\"text\"  data-name=\"GuiBingMoney\" class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + "\" />元/人</th>";
                                        }
                                        else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                                        {
                                            JiageDengji += "<th align=\"right\" width=\"33%\">儿童价<input type=\"text\"  data-name=\"DaiXiaoMoney\" class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + "\" />元/人</th>";
                                        }
                                        else
                                        {
                                            JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                                        }
                                    }
                                    else
                                    {
                                        JiageDengji += "<th align=\"right\" width=\"33%\">&nbsp;</th>";
                                    }
                                    JiageDengji += "</tr>";
                                    JiageDengji += "<tr><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongMenShiMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                                    JiageDengji += "<th align=\"right\">总　价<input type=\"text\" data-name=\"ZongHuiYuanMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                                    if (userInfo != null)
                                    {
                                        if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                        {
                                            JiageDengji += "<th align=\"right\">总　价<input type=\"text\" data-name=\"ZongGuiBingMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                                        }
                                        else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                                        {
                                            JiageDengji += "<th align=\"right\">总　价<input type=\"text\" data-name=\"ZongDaiXiaoMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th>";
                                        }
                                        else
                                        {
                                            JiageDengji += "<th align=\"right\">&nbsp;</th>";
                                        }
                                    }
                                    JiageDengji += "</tr>";
                                    if (userInfo != null)
                                    {
                                        if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理)
                                        {
                                            JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                                        + "代理价：成人价<input type=\"text\" data-name=\"DaiLiMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "\" />元/人</th><th align=\"right\">&nbsp;</th><th align=\"right\">&nbsp;</th></tr>";
                                            JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                                        + "儿童价<input type=\"text\" data-name=\"DaiLiMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "\" />元/人</th><th align=\"right\">&nbsp;</th><th align=\"right\">&nbsp;</th></tr>";
                                            JiageDengji += "<tr><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongDaiLiMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th><th align=\"right\">&nbsp;</th><th align=\"right\">&nbsp;</th></tr>";

                                        }
                                        if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                        {
                                            JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                                        + "代理价：成人价<input type=\"text\"  data-name=\"DaiLiMoney\" class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "\" />元/人</th><th align=\"right\">员工价：成人价<input type=\"text\" data-name=\"YuanGongMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJCR, item.CRSCJ, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0") + "\" />元/人</th><th align=\"right\">&nbsp;</th></tr>";
                                            JiageDengji += "<tr><th align=\"right\" width=\"33%\">"
                                                        + "儿童价<input type=\"text\" data-name=\"DaiLiMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + "\" />元/人</th><th align=\"right\">儿童价<input type=\"text\" data-name=\"YuanGongMoney\"  class=\"bj_input formsize80 fontred16\" value=\"" + UtilsCommons.GetGYStijia(FeeType, item.JSJET, item.ETSCJ, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0") + "\" />元/人</th><th align=\"right\">&nbsp;</th></tr>";
                                            JiageDengji += "<tr><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongDailiMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" />元</th><th align=\"right\">总　价<input type=\"text\" data-name=\"ZongYuanGongMoney\" class=\"bj_input formsize100 fontred16\" value=\"0\" /></th><th align=\"right\">&nbsp;</th></tr>";

                                        }
                                    }

                                    //litJGlevel.Text = strJGlevel.ToString();//发团日期
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
                XianLuMonth.Value = (Ldate.Month).ToString();
                XianLuYear.Value = (Ldate.Year).ToString();
                XianLuDay.Value = (Ldate.Day).ToString();
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
                for (int i = 0; i < zaocanmenshi.Length; i++)
                {
                    //decimal jiage = Convert.ToDecimal(zaocanjia[i]) + (Convert.ToDecimal(zaocanmenshi[i]) - Convert.ToDecimal(zaocanjia[i])) * discount / 100;
                    ZaoCanList += "<option value=\"" + zaocanmenshi[i] + "\" data-cb=\"" + zaocanjia[i] + "\" >" + zaocanmenshi[i] + "</option>";
                }
                string[] wucanjia = zutuanmodel.WuCanMoney.Split(',');
                string[] wucanmenshi = zutuanmodel.MSWuCanMoney.Split(',');
                for (int i = 0; i < wucanmenshi.Length; i++)
                {
                    //decimal jiage = Convert.ToDecimal(wucanjia[i]) + (Convert.ToDecimal(wucanmenshi[i]) - Convert.ToDecimal(wucanjia[i])) * discount / 100;
                    WuCanList += "<option value=\"" + wucanmenshi[i] + "\" data-cb=\"" + wucanjia[i] + "\" >" + wucanmenshi[i] + "</option>";
                }
                string[] wancanjia = zutuanmodel.WanCanMoney.Split(',');
                string[] wancanmenshi = zutuanmodel.MSWanCanMoney.Split(',');
                for (int i = 0; i < wancanmenshi.Length; i++)
                {
                    //decimal jiage = Convert.ToDecimal(wancanjia[i]) + (Convert.ToDecimal(wancanmenshi[i]) - Convert.ToDecimal(wancanjia[i])) * discount / 100;
                    WanCanList += "<option value=\"" + wancanmenshi[i] + "\" data-cb=\"" + wancanjia[i] + "\" >" + wancanmenshi[i] + "</option>";
                }
                string[] renshenjia = zutuanmodel.RSYiWai.Split(',');
                string[] renshenmenshi = zutuanmodel.MSRSYiWai.Split(',');
                for (int i = 0; i < renshenmenshi.Length; i++)
                {
                    //decimal jiage = Convert.ToDecimal(renshenjia[i]) + (Convert.ToDecimal(renshenmenshi[i]) - Convert.ToDecimal(renshenjia[i])) * discount / 100;
                    RSBXList += "<option value=\"" + renshenmenshi[i] + "\" data-cb=\"" + renshenjia[i] + "\">" + renshenmenshi[i] + "</option>";
                }
                string[] jiaotongjia = zutuanmodel.JTYiWai.Split(',');
                string[] jiaotongmenshi = zutuanmodel.MSJTYiWai.Split(',');
                for (int i = 0; i < jiaotongmenshi.Length; i++)
                {
                    //decimal jiage = Convert.ToDecimal(jiaotongjia[i]) + (Convert.ToDecimal(jiaotongmenshi[i]) - Convert.ToDecimal(jiaotongjia[i])) * discount / 100;
                    JTBXList += "<option value=\"" + jiaotongmenshi[i] + "\" data-cb=\"" + jiaotongjia[i] + "\">" + jiaotongmenshi[i] + "</option>";
                }
                CarFei.Value = Convert.ToDecimal(zutuanmodel.MSCarMoney).ToString("f2");
                CarFeiCB.Value = Convert.ToDecimal(zutuanmodel.CarMoney).ToString("f2");
                RSTianShu.Value = model.TianShu.ToString();
                lvYouTianShu.Text = model.TianShu.ToString();
                decimal jiage1 = Convert.ToDecimal(renshenmenshi[0]);
                RSJiaGe.Value = (jiage1 * model.TianShu).ToString("f2");
                JTTianShu.Value = model.TianShu.ToString();
                decimal jiage2 = Convert.ToDecimal(jiaotongmenshi[0]);
                JTJiaGe.Value = (jiage2 * model.TianShu).ToString("f2");
                ChengRenMS.Value = crjiage.ToString("f2");
                ErTongMS.Value = etjiage.ToString("f2");
                ChengRenJieSuan.Value = crjiesuan.ToString("f2");
                ErTongJieSuan.Value = etjiesuan.ToString("f2");
            }
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
            model.PSort = 0;
            list = bll.GetList(1000000, model);
            strHtml.Append("<select  name=\"ddl_Qucarlist\" style=\"width:283px\"> ");
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    strHtml.AppendFormat("<option value=\"{0}\" >{1}</option>",
                        item.ZuCheID, item.CarName);
                }
            }
            strHtml.Append(" </select> ");

            return strHtml.ToString();
        }
        protected string GetHuiCarHtml()
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
            model.PSort = 0;
            list = bll.GetList(1000000, model);
            strHtml.Append("<select  name=\"ddl_Huicarlist\" style=\"width:283px\"> ");
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    strHtml.AppendFormat("<option value=\"{0}\" >{1}</option>",
                        item.ZuCheID, item.CarName);
                }
            }
            strHtml.Append(" </select> ");

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
            ZuTuanModel.HangBanId = Utils.GetFormValue("hangban");
            if (string.IsNullOrEmpty(ZuTuanModel.BaoXian))
            {
                ZuTuanModel.BaoXianDay = 0;
                ZuTuanModel.BXJiaGe = 0;
            }
            else
            {
                ZuTuanModel.BaoXianDay = Utils.GetInt(Utils.GetFormValue(RSTianShu.UniqueID));
                ZuTuanModel.BXJiaGe = Utils.GetDecimal(Utils.GetFormValue("RJBXF"));
            }
            ZuTuanModel.CanWuJia = Utils.GetDecimal(Utils.GetFormValue("CanWuFei"));
            ZuTuanModel.CarMoney = Utils.GetDecimal(Utils.GetFormValue(CarMoney.UniqueID));
            ZuTuanModel.ChuFaTime = Convert.ToDateTime(Utils.GetFormValue(XianLuYear.UniqueID) + "-" + Utils.GetFormValue(XianLuMonth.UniqueID) + "-" + Utils.GetFormValue(XianLuDay.UniqueID));
            ZuTuanModel.CRJiage = Utils.GetDecimal(Utils.GetFormValue("UChengRenJia"));
            ZuTuanModel.QuanPeiRJJia = Utils.GetDecimal(Utils.GetFormValue("QuanPeiDaoYouFei"));
            ZuTuanModel.DaoYouMoney = Utils.GetDecimal(Utils.GetFormValue(DaoYouFei.UniqueID));
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
            ZuTuanModel.XianLuName = Utils.GetFormValue(XianLuName.UniqueID);
            ZuTuanModel.ZaoCanJia = Utils.GetDecimal(Utils.GetFormValue("ZaoCanMoney"));
            ZuTuanModel.ZaoCanNum = Utils.GetInt(Utils.GetFormValue("ZaoCanNum"));
            ZuTuanModel.ZCMoney = Utils.GetDecimal(Utils.GetFormValue("ZuCheMoney"));
            ZuTuanModel.TourId = Utils.GetFormValue(XLTourId.UniqueID);
            ZuTuanModel.ZuTuanId = Guid.NewGuid().ToString();

            decimal crms = Utils.GetDecimal(Utils.GetFormValue(ChengRenMS.UniqueID));//成人门市价
            decimal etms = Utils.GetDecimal(Utils.GetFormValue(ErTongMS.UniqueID));//儿童门市价
            decimal crjs = Utils.GetDecimal(Utils.GetFormValue(ChengRenJieSuan.UniqueID));//成人结算价
            decimal etjs = Utils.GetDecimal(Utils.GetFormValue(ErTongJieSuan.UniqueID));//儿童结算价
            MFeeSettings feeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.组团);
            EyouSoft.Model.Enum.FeeTypes FeeType = EyouSoft.Model.Enum.FeeTypes.组团;

            string url = HttpContext.Current.Request.Url.Host;
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
            seller = bsells.GetMSellersByWebSite(url);
            decimal zjzms = Utils.GetDecimal(Utils.GetFormValue(ZongMoney.UniqueID));//增加总门市价
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

            

            string[] qucarlist = Utils.GetFormValues("ddl_Qucarlist");
            string[] qucheNum = Utils.GetFormValues("QuZuCheNum");
            string[] quchefei = Utils.GetFormValues("QuCheFei");
            string[] huicarlist = Utils.GetFormValues("ddl_Huicarlist");
            string[] huicheNum = Utils.GetFormValues("HuiZuCheNum");
            string[] huichefei = Utils.GetFormValues("HuiCheFei");
            EyouSoft.Model.XianLuStructure.MZiZuTuanXingCheng ZiZuTuanXC = new EyouSoft.Model.XianLuStructure.MZiZuTuanXingCheng();
            if (quchefei.Length > 0)
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
            if (huichefei.Length > 0)
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
                RECW(UtilsCommons.AjaxReturnJson("1", "报价成功"));
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
}
