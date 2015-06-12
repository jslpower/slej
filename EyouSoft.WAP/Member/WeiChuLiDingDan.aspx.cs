using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using EyouSoft.BLL.ZuCheStructure;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.OtherStructure;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.BLL.ScenicStructure;
using EyouSoft.Model.JPStructure;
using EyouSoft.Model.Enum;
using System.Text;

namespace EyouSoft.WAP.Member
{
    public partial class WeiChuLiDingDan : HuiYuanWapPageBase
    {
        BZuCheOrder bll = new BZuCheOrder();
        BSellers bsells = new BSellers();
        MSearchDingDan Model = new MSearchDingDan();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        protected int isAgency = 0;//判断是否为分销商、免费分销商、员工，1为true
        string AgencyId = "";
        protected int PageNum = 8;//每页显示条数
        protected StringBuilder OrderList = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("setState") == "1") setOrderState();
            mseller = bsells.Get(HuiYuanInfo.UserId);
            if (mseller != null)
            {
                AgencyId = mseller.ID;
                isAgency = 1;
            }
            WapHeader1.HeadText = "未处理订单";

            Model.xiadanrenid = HuiYuanInfo.UserId;
            Model.OrderStatus = new List<EyouSoft.Model.Enum.XianLuStructure.OrderStatus> { EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款, EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货};
            if (AgencyId != "")
            {
                Model.fenxiaoid = AgencyId;
                Model.OrderStatus = new List<EyouSoft.Model.Enum.XianLuStructure.OrderStatus> { EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款, EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货, EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货 };
            }
            Model.dingdantype = (DingDanType)(-1);
            int TotalCount = 0;
            var list = new EyouSoft.BLL.OtherStructure.BDingDan().GetOrders(PageNum, 1, ref TotalCount, Model);
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    switch (list[i].OrderType)
                    {
                        case DingDanType.长线订单:
                            #region  长线订单
                            OrderList.Append("<div class=\"user_dindan wcl_dindan\"><ul><li>");
                            OrderList.Append("<s class=\"ico_dxian\"></s><span class=\"biaoti\">国内游</span>");
                            OrderList.Append("<span class=\"yd_time\">预订时间：" + list[i].IssueTime + "</span><span class=\"zt_y\">" + list[i].DingDanZT + "</span></li>");
                            OrderList.Append("<li><p class=\"font16\" data-id=\"" + list[i].ProductID + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"Oname\">" + list[i].OrderName + "</p><p class=\"color_9\" data-orderid=\"" + list[i].OrderId + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"code\">订单编号：" + list[i].OrderCode + "</p>");
                            OrderList.Append("<p class=\"color_9\">出行时间：" + list[i].ChuFaShiJian.ToShortDateString() + "</p>");
                            OrderList.Append("<p class=\"color_9\">出行人数：" + list[i].OrderNum + "</p>");
                            OrderList.Append("<p class=\"color_9 clearfix\"><span class=\"price floatR\">¥<em>" + list[i].JinE.ToString("f2") + "</em></span></p>");
                            if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul><div class=\"dindan_tx\">您已成功提交订单，请在45分之内完成付款！</div></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            #endregion
                            break;
                        case DingDanType.短线订单:
                            #region 短线订单
                            OrderList.Append("<div class=\"user_dindan wcl_dindan\"><ul><li><s class=\"ico_chxian\"></s><span class=\"biaoti\">周边游</span>");
                            OrderList.Append("<span class=\"yd_time\">预订时间：" + list[i].IssueTime + "</span><span class=\"zt_y\">" + list[i].DingDanZT + "</span></li>");
                            OrderList.Append("<li><p class=\"font16\" data-id=\"" + list[i].ProductID + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"Oname\">" + list[i].OrderName + "</p>");
                            OrderList.Append("<p class=\"color_9\" data-orderid=\"" + list[i].OrderId + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"code\">订单编号：" + list[i].OrderCode + "</p><p class=\"color_9\">出行时间：" + list[i].ChuFaShiJian.ToShortDateString() + "</p>");
                            OrderList.Append("<p class=\"color_9\">出行人数：" + list[i].OrderNum + "</p><p class=\"color_9 clearfix\"><span class=\"price floatR\">¥<em>" + list[i].JinE.ToString("f2") + "</em></span></p>");
                            if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul><div class=\"dindan_tx\">您已成功提交订单，请在45分之内完成付款！</div></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            #endregion
                            break;
                        case DingDanType.出境订单:
                            #region 出境订单
                            OrderList.Append("<div class=\"user_dindan wcl_dindan\"><ul><li> <s class=\"ico_chujin\"></s><span class=\"biaoti\">出境游</span>");
                            OrderList.Append("<span class=\"yd_time\">预订时间：" + list[i].IssueTime + "</span><span class=\"zt_y\">" + list[i].DingDanZT + "</span></li>");
                            OrderList.Append("<li><p class=\"font16\" data-id=\"" + list[i].ProductID + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"Oname\">" + list[i].OrderName + "</p>");
                            OrderList.Append("<p class=\"color_9\" data-orderid=\"" + list[i].OrderId + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"code\">订单编号：" + list[i].OrderCode + "</p>");
                            OrderList.Append("<p class=\"color_9\">出行时间：" + list[i].ChuFaShiJian.ToShortDateString() + "</p><p class=\"color_9\">出行人数：" + list[i].OrderNum + "</p>");
                            OrderList.Append("<p class=\"color_9 clearfix\"><span class=\"price floatR\">¥<em>" + list[i].JinE.ToString("f2") + "</em></span></p>");
                            if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul><div class=\"dindan_tx\">您已成功提交订单，请在45分之内完成付款！</div></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            #endregion
                            break;
                        case DingDanType.酒店订单:
                            #region 酒店订单
                            OrderList.Append("<div class=\"user_dindan wcl_dindan\"><ul><li><s class=\"ico_hotel\"></s>");
                            OrderList.Append("<span class=\"biaoti\">酒店预订</span>");
                            OrderList.Append("<span class=\"yd_time\">预订时间：" + list[i].IssueTime + "</span><span class=\"zt_y\">" + list[i].DingDanZT + "</span></li>");
                            OrderList.Append("<li><p class=\"font16\" data-id=\"" + list[i].ProductID + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"Oname\">" + list[i].OrderName + "</p>");
                            OrderList.Append("<p class=\"color_9\" data-orderid=\"" + list[i].OrderId + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"code\">订单编号：" + list[i].OrderCode + "</p> <p class=\"color_9\">入住时间：" + list[i].ChuFaShiJian.ToShortDateString() + "</p>");
                            OrderList.Append("<p class=\"color_9\">入住天数：" + (list[i].HuiGuiShiJian - list[i].ChuFaShiJian) + "天</p><p class=\"color_9 clearfix\"><span class=\"price floatR\">¥<em>" + list[i].JinE.ToString("f2") + "</em></span>入住人数：" + list[i].OrderNum + "</p>");

                            if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul><div class=\"dindan_tx\">您已成功提交订单，请在45分之内完成付款！</div></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            #endregion
                            break;
                        case DingDanType.门票订单:
                            #region 门票订单
                            OrderList.Append("<div class=\"user_dindan wcl_dindan\"><ul><li><s class=\"ico_jinqu\"></s>");
                            OrderList.Append("<span class=\"biaoti\">景点门票</span>");
                            OrderList.Append("<span class=\"yd_time\">预订时间：" + list[i].IssueTime + "</span>");
                            OrderList.Append("<span class=\"zt_y\">" + list[i].DingDanZT + "</span></li>");

                            OrderList.Append("<li><p class=\"font16\" data-id=\"" + list[i].ProductID + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"Oname\">" + list[i].OrderName + "</p>");
                            OrderList.Append("<p class=\"color_9\" data-orderid=\"" + list[i].OrderId + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"code\">订单编号：" + list[i].OrderCode + "</p>");
                            OrderList.Append("<p class=\"color_9\">游玩时间：" + list[i].ChuFaShiJian.ToShortDateString() + "</p><p class=\"color_9\">出行人数：" + list[i].OrderNum + "</p>");
                            OrderList.Append("<p class=\"color_9 clearfix\"><span class=\"price floatR\">¥<em>" + list[i].JinE.ToString("f2") + "</em></span></p>");
                            if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul><div class=\"dindan_tx\">您已成功提交订单，请在45分之内完成付款！</div></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }

                            #endregion
                            break;
                        case DingDanType.机票订单:
                            #region 机票订单
                            OrderList.Append("<div class=\"user_dindan wcl_dindan\"><ul><li><s class=\"ico_jinqu\"></s>");
                            OrderList.Append("<span class=\"biaoti\">机票</span><span class=\"yd_time\">预订时间：" + list[i].IssueTime + "</span>");
                            OrderList.Append("<span class=\"zt_y\">" + list[i].DingDanZT + "</span></li>");

                            OrderList.Append("<li><p class=\"font16\" data-id=\"" + list[i].ProductID + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"Oname\">" + list[i].OrderName + "</p>");
                            OrderList.Append("<p class=\"color_9\" data-orderid=\"" + list[i].OrderId + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"code\">订单编号：" + list[i].OrderCode + "</p>");
                            OrderList.Append("<p class=\"color_9\">起飞时间：" + list[i].ChuFaShiJian + "</p>");
                            OrderList.Append("<p class=\"color_9\">到达时间：" + list[i].HuiGuiShiJian + " </p>");
                            OrderList.Append("<p class=\"color_9\">出行人数：" + list[i].OrderNum + "</p><p class=\"color_9 clearfix\"><span class=\"price floatR\">¥<em>" + list[i].JinE.ToString("f2") + "</em></span></p>");
                            if (list[i].DingDanZT == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul><div class=\"dindan_tx\">您已成功提交订单，请在45分之内完成付款！</div></div>");
                            }
                            #endregion
                            break;
                        case DingDanType.单团订单:
                            #region 单团订单
                            OrderList.Append("<div class=\"user_dindan wcl_dindan\"><ul><li><s class=\"ico_dantuan\"></s>");
                            OrderList.Append("<span class=\"biaoti\">单团订单</span><span class=\"yd_time\">预订时间：" + list[i].IssueTime + "</span>");
                            OrderList.Append("<span class=\"zt_y\">" + list[i].DingDanZT + "</span></li>");

                            OrderList.Append("<li><p class=\"font16\" data-id=\"" + list[i].ProductID + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"Oname\">" + list[i].OrderName + "</p>");
                            OrderList.Append("<p class=\"color_9\" data-orderid=\"" + list[i].OrderId + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"code\">订单编号：" + list[i].OrderCode + "</p><p class=\"color_9\">出行时间：" + list[i].ChuFaShiJian.ToShortDateString() + "</p>");
                            OrderList.Append("<p class=\"color_9\">出行人数：" + list[i].OrderNum + "</p><p class=\"color_9 clearfix\"><span class=\"price floatR\">¥<em>" + list[i].JinE.ToString("f2") + "</em></span></p>");
                            if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul><div class=\"dindan_tx\">您已成功提交订单，请在45分之内完成付款！</div></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            #endregion
                            break;
                        case DingDanType.租车订单:
                            #region 租车订单
                            OrderList.Append("<div class=\"user_dindan wcl_dindan\"><ul><li><s class=\"ico_car\"></s>");
                            OrderList.Append("<span class=\"biaoti\">汽车包租</span><span class=\"yd_time\">预订时间：" + list[i].IssueTime + "</span>");
                            OrderList.Append("<span class=\"zt_y\">" + list[i].DingDanZT + "</span></li>");
                            OrderList.Append("<li><p class=\"font16\" data-id=\"" + list[i].ProductID + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"Oname\">" + list[i].OrderName + "</p>");
                            OrderList.Append("<p class=\"color_9\" data-orderid=\"" + list[i].OrderId + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"code\">订单编号：" + list[i].OrderCode + "</p>");
                            OrderList.Append("<p class=\"color_9\">取车时间：" + list[i].ChuFaShiJian + "</p><p class=\"color_9 clearfix\"><span class=\"price floatR\">¥<em>" + list[i].JinE.ToString("f2") + "</em></span>还车时间：" + list[i].HuiGuiShiJian + "</p>");
                            if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul><div class=\"dindan_tx\">您已成功提交订单，请在45分之内完成付款！</div></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            #endregion
                            break;
                        case DingDanType.商城订单:
                            #region 商城订单
                            OrderList.Append("<div class=\"user_dindan wcl_dindan\"><ul><li><s class=\"ico_mall\"></s>");
                            OrderList.Append("<span class=\"biaoti\">商城订单</span><span class=\"yd_time\">预订时间：" + list[i].IssueTime + "</span>");
                            OrderList.Append("<span class=\"zt_y\">" + list[i].DingDanZT + "</span></li>");

                            OrderList.Append("<li><p class=\"font16\" data-id=\"" + list[i].ProductID + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"Oname\">" + list[i].OrderName + "</p>");
                            OrderList.Append("<p class=\"color_9\" data-orderid=\"" + list[i].OrderId + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"code\">订单编号：" + list[i].OrderCode + "</p>");
                            OrderList.Append("<p class=\"color_9 clearfix\"><span class=\"price floatR\">¥<em>" + list[i].JinE.ToString("f2") + "</em></span>购买数量：" + list[i].OrderNum + "</p>");
                            if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul><div class=\"dindan_tx\">您已成功提交订单，请在45分之内完成付款！</div></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            #endregion
                            break;
                        case DingDanType.团购订单:
                            #region 团购订单
                            OrderList.Append("<div class=\"user_dindan wcl_dindan\"><ul><li><s class=\"ico_tg\"></s>");
                            OrderList.Append("<span class=\"biaoti\">团购订单</span><span class=\"yd_time\">预订时间：" + list[i].IssueTime + "</span>");
                            OrderList.Append("<span class=\"zt_y\">" + list[i].DingDanZT + "</span></li>");
                            OrderList.Append("<li><p class=\"font16\" data-id=\"" + list[i].ProductID + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"Oname\">" + list[i].OrderName + "</p>");
                            OrderList.Append("<p class=\"color_9\" data-orderid=\"" + list[i].OrderId + "\" data-leibie=\"" + (int)list[i].OrderType + "\" data-name=\"code\">订单编号：" + list[i].OrderCode + "</p><p class=\"color_9\">出行时间：" + list[i].ChuFaShiJian.ToShortDateString() + "</p>");
                            OrderList.Append("<p class=\"color_9\">出行人数：" + list[i].OrderNum + "</p><p class=\"color_9 clearfix\"><span class=\"price floatR\">¥<em>" + list[i].JinE.ToString("f2") + "</em></span></p>");
                            if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId,list[i].DingDanZT,list[i].AgencyId,list[i].OrderType,list[i].XDRId) + "</p></li></ul><div class=\"dindan_tx\">您已成功提交订单，请在45分之内完成付款！</div></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            else if (list[i].OrderStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货)
                            {
                                OrderList.Append("<p class=\"clearfix\">" + getZhiFuURL(list[i].OrderId, list[i].DingDanZT, list[i].AgencyId, list[i].OrderType, list[i].XDRId) + "</p></li></ul></div>");
                            }
                            #endregion
                            break;
                    }
                }
            }
            else
            {
                XianShi.Text = "暂无相关数据";
            }
        }

        /// <summary>
        /// 获取支付链接
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        protected string getZhiFuURL(string orderid, object state, object AgencyId, object ordertype, object xdrid)
        {
            mseller = bsells.Get(HuiYuanInfo.UserId);
            string FenXiaoId = "";
            if (mseller != null)
            {
                FenXiaoId = mseller.ID;
            }
            if (string.IsNullOrEmpty(AgencyId.ToString())) { AgencyId = ""; }

            EyouSoft.Model.Enum.XianLuStructure.OrderStatus type = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)state;
            switch (type)
            {
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                    return string.Format("<a href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\" class=\"yellow_btn floatR\">立即支付</a>", orderid, (int)ordertype, HuiYuanInfo.UserId);
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
                    if (isAgency == 1 && FenXiaoId.ToString() == AgencyId.ToString())
                    {
                        return string.Format("  <a href='javascript:;' onclick=\"javascript:pageData.setOrder('{0}','{1}','{2}');\" class=\"yellow_btn floatR\">订单出货</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货,(int)ordertype);
                    }
                    else
                    {
                        return string.Format("");
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                    return string.Format("  <a href='javascript:;' onclick=\"javascript:pageData.setOrder('{0}','{1}','{2}');\" class=\"yellow_btn floatR\">确认出行</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利,(int)ordertype);
            }
            return "";
        }

        /// <summary>
        /// 设置订单状态
        /// </summary>
        void setOrderState()
        {
            string orderid = Utils.GetQueryStringValue("id");
            EyouSoft.Model.Enum.XianLuStructure.OrderStatus state = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)Utils.GetInt(Utils.GetQueryStringValue("state"));


            EyouSoft.Model.OtherStructure.DingDanType OrderLeiBie = (EyouSoft.Model.OtherStructure.DingDanType)Utils.GetInt(Utils.GetQueryStringValue("ordertype"));
            int result = 0;
            if (OrderLeiBie == DingDanType.租车订单)
            {
                BZuChe zubll = new BZuChe();
                result = zubll.SheZhiOrderStatus(orderid, state);
            }
            else if (OrderLeiBie == DingDanType.酒店订单)
            {
                BHotel bll = new BHotel();
                result = bll.SheZhiOrderStatus(orderid, state);
            }
            else if (OrderLeiBie == DingDanType.门票订单)
            {
                BScenicArea bll = new BScenicArea();
                result = bll.SheZhiOrderStatus(orderid, state);
            }
            else if (OrderLeiBie == DingDanType.商城订单)
            {
                result = new EyouSoft.BLL.MallStructure.BShangChengDingDan().SheZhiOrderStatus(orderid, state);
            }
            else if (OrderLeiBie == DingDanType.团购订单)
            {
                result = new EyouSoft.BLL.OtherStructure.BTuanGouDingDan().SheZhiOrderStatus(orderid, state);
            }
            else if (OrderLeiBie == DingDanType.单团订单)
            {
                result = new EyouSoft.BLL.XianLuStructure.BZiZuTuan().SheZhiOrderStatus(orderid, state);
            }
            RCWE(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "操作成功" : "操作失败"));
        }
    }
}
