using System;
using Common.page;
using Linq.Web;
using EyouSoft.Model.ScenicStructure.WebModel;
using EyouSoft.BLL.ScenicStructure;
using EyouSoft.Model;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.Model.Enum.ScenicStructure;
using EyouSoft.Model.Enum;
using EyouSoft.BLL.SystemStructure;
using Common;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.WAP
{
    public partial class JingQuOrder : WebPageBase
    {
        BScenicArea2 bll = new BScenicArea2();
        BFeeSettings feeSettingBll = new BFeeSettings();
        BSellers bseller = new BSellers();
        MScenicAreaTicketsOrderWebBindModel Model = new MScenicAreaTicketsOrderWebBindModel();
        protected string ScenicName = "";
        protected decimal OrderPrice = 0;
        protected decimal HuiYuanDanJia = 0;
        protected decimal GuiBingDanJia = 0;
        protected decimal DaiLiDanJia = 0;
        protected decimal DaiXiaoDanJia = 0;
        protected int usercate = 0;//会员级别0-未登录及未注册用户
        protected bool isShow = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "景区订单";
            if (Request.QueryString["dotype"] == "save")
            {
                Model.OperatorId = m.UserId;
                Model.OperatorName = m.MemberName;
                Model.OperatorMobile = m.Mobile;
                Model.Num = Convert.ToInt32(Utils.GetFormValue("TickNum"));
                Model.Price = Convert.ToDecimal(Utils.GetFormValue("DanJia")) * Model.Num;
                Model.TicketsId = Utils.GetQueryStringValue("TicketsId");

                Model.ChuFaRiQi = Convert.ToDateTime(Utils.GetFormValue("riqi"));
                Model.IssueTime = DateTime.Now;
                Model.ContactName = Utils.GetFormValue("QuPiaoName");
                Model.ContactTel = Utils.GetFormValue("QuPiaoMobile");
                Model.OrderSite = OrderSite.WAP;

                string msg = "";
                bool i = bll.SubmitOrder(Model,  m.UserType, out msg);
                if (i) msg = "下单成功，请前往订单中心查看";
                RCWE(UtilsCommons.AjaxReturnJson(i ? "1" : "0", msg));
            }
            else
            {
                getHtmlStr();
                Model.TicketsId = Utils.GetQueryStringValue("TicketsId");
                if (!string.IsNullOrEmpty(Model.TicketsId))
                {

                    Model.TicketInfo = bll.GetTicketInfo(Model.TicketsId);
                    Model.AreaInfo = bll.GetScenicAreaInfo(Model.TicketInfo.ScenicId);
                    Model.FeeSetting = feeSettingBll.GetByType(FeeTypes.门票);
                    Model.Num = 1;
                    

                    if (DateTime.Now.Hour < 12)
                    {
                        Model.ChuFaRiQi = DateTime.Now;
                    }
                    else
                    {
                        Model.ChuFaRiQi = DateTime.Now.AddDays(1);
                    }
                    if (isLogin)
                    {
                        usercate = (int)m.UserType;
                        Model.CurrentPrice = Math.Round(BHotel2.CalculateFee(Model.TicketInfo.DistributionPrice, Model.TicketInfo.WebsitePrices, m.UserType, Model.FeeSetting, FeeTypes.门票));
                    }
                    else
                    {
                        Model.CurrentPrice = Math.Round(BHotel2.CalculateFee(Model.TicketInfo.DistributionPrice, Model.TicketInfo.WebsitePrices, MemberTypes.普通会员, Model.FeeSetting, FeeTypes.门票));
                    }
                    Model.Price = Model.CurrentPrice * Model.Num;
                    OrderPrice = Model.Price;
                    HuiYuanDanJia = Model.CurrentPrice = Math.Round(BHotel2.CalculateFee(Model.TicketInfo.DistributionPrice, Model.TicketInfo.WebsitePrices, MemberTypes.普通会员, Model.FeeSetting, FeeTypes.门票));
                    GuiBingDanJia = Model.CurrentPrice = Math.Round(BHotel2.CalculateFee(Model.TicketInfo.DistributionPrice, Model.TicketInfo.WebsitePrices, MemberTypes.贵宾会员, Model.FeeSetting, FeeTypes.门票));
                    DaiLiDanJia = Model.CurrentPrice = Math.Round(BHotel2.CalculateFee(Model.TicketInfo.DistributionPrice, Model.TicketInfo.WebsitePrices, MemberTypes.代理, Model.FeeSetting, FeeTypes.门票));
                    DaiXiaoDanJia = Model.CurrentPrice = Math.Round(BHotel2.CalculateFee(Model.TicketInfo.DistributionPrice, Model.TicketInfo.WebsitePrices, MemberTypes.免费代理, Model.FeeSetting, FeeTypes.门票));
                    Model.IsShowFenXiaoShenQing = (bseller.WebSiteShowOrHidden(Request.Url.Host) == ShowHidden.显示);
                    if (bseller.WebSiteShowOrHidden(Request.Url.Host.ToLower().Replace("m.", "")) == ShowHidden.隐藏)
                    {
                        isShow = false;
                    }
                    ScenicName = Model.TicketInfo.EnName;
                }
                else
                {
                    Response.End();
                }
            }
        }
        /// <summary>
        /// 获取最近六个月的日期
        /// </summary>
        void getHtmlStr()
        {
            StringBuilder strMonthHtml = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                DateTime dt = DateTime.Now.AddMonths(i);
                if (i == 0)
                {
                    strMonthHtml.Append("<div class=\"riqi_box\">");
                }
                else
                {
                    strMonthHtml.Append("<div class=\"riqi_box mt10\">");
                }
                strMonthHtml.AppendFormat("<div class=\"riqi_month\">{0}</div>", dt.ToString("yyyy年MM月"));
                strMonthHtml.Append("<div class=\"riqi_week\">");
                strMonthHtml.Append("<ul>");
                strMonthHtml.Append("<li>日</li>");
                strMonthHtml.Append("<li>一</li>");
                strMonthHtml.Append("<li>二</li>");
                strMonthHtml.Append("<li>三</li>");
                strMonthHtml.Append("<li>四</li>");
                strMonthHtml.Append("<li>五</li>");
                strMonthHtml.Append("<li>六</li>");
                strMonthHtml.Append("</ul>");
                strMonthHtml.Append("</div>");
                strMonthHtml.Append("<div class=\"riqi_day\">");
                strMonthHtml.Append("<ul class=\"clearfix\">");

                int days = DateTime.DaysInMonth(dt.Year, dt.Month);
                int firstLi = (int)Utils.GetDateTime(string.Format("{0}-{1}-{2}", dt.Year, dt.Month, 1)).DayOfWeek;
                for (int j = 0; j < firstLi; j++)
                {
                    strMonthHtml.Append("<li></li>");//补全空白
                }
                for (int m = 1; m <= days; m++)
                {
                    strMonthHtml.Append(getMonthStr(string.Format("{0}-{1}-{2}", dt.Year, dt.Month, m)));
                }
                strMonthHtml.Append("</ul></div></div>");
            }
            litMonth.Text = strMonthHtml.ToString();
        }
        /// <summary>
        /// 返回表格样式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        string getMonthStr(string dataStr)
        {
            DateTime dt = Utils.GetDateTime(dataStr);
            if (dt < DateTime.Now)
            {
                return string.Format("<li da class=\"riqi_day_pass\" >{0}</li>", dt.Day);
            }
            else
            {
                return string.Format("<li class=\"riqi_day_select\" data-date=\"{1}\" data-week=\"{2}\">{0}</li>", dt.Day, dt.ToString("yyyy-MM-dd"), dt.DayOfWeek);
            }
        }
    }
}

