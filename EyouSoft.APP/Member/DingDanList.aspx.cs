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

namespace EyouSoft.WAP.Member
{
    public partial class DingDanList : HuiYuanWapPageBase
    {
        BZuCheOrder bll = new BZuCheOrder();
        BSellers bsells = new BSellers();
        MSearchDingDan Model = new MSearchDingDan();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        protected int isAgency = 0;//判断是否为分销商、免费分销商、员工，1为true
        string AgencyId = "";
        protected int PageNum = 8;//每页显示条数
        protected int orderleibie = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("setState") == "1") setOrderState();
            EyouSoft.Model.OtherStructure.DingDanType OrderType = (EyouSoft.Model.OtherStructure.DingDanType)Utils.GetInt(Utils.GetQueryStringValue("OrderType"));
            mseller = bsells.Get(HuiYuanInfo.UserId);
            if (mseller != null)
            {
                AgencyId = mseller.ID;
                isAgency = 1;
            }
            if (OrderType == EyouSoft.Model.OtherStructure.DingDanType.租车订单)
            {
                orderleibie = (int)EyouSoft.Model.OtherStructure.DingDanType.租车订单;
                WapHeader1.HeadText = "租车订单";
            }
            if (OrderType == EyouSoft.Model.OtherStructure.DingDanType.酒店订单)
            {
                orderleibie = (int)EyouSoft.Model.OtherStructure.DingDanType.酒店订单;
                WapHeader1.HeadText = "酒店订单";
            }
            if (OrderType == EyouSoft.Model.OtherStructure.DingDanType.门票订单)
            {
                orderleibie = (int)EyouSoft.Model.OtherStructure.DingDanType.门票订单;
                WapHeader1.HeadText = "门票订单";
            }
            if (OrderType == EyouSoft.Model.OtherStructure.DingDanType.商城订单)
            {
                orderleibie = (int)EyouSoft.Model.OtherStructure.DingDanType.商城订单;
                WapHeader1.HeadText = "商城订单";
            }
            if (OrderType == DingDanType.团购订单)
            {
                orderleibie = (int)EyouSoft.Model.OtherStructure.DingDanType.团购订单;
                WapHeader1.HeadText = "团购订单";
            }
            if (OrderType == DingDanType.机票订单)
            {
                orderleibie = (int)EyouSoft.Model.OtherStructure.DingDanType.机票订单;
                WapHeader1.HeadText = "机票订单";
            }
            if (OrderType == DingDanType.单团订单)
            {
                orderleibie = (int)EyouSoft.Model.OtherStructure.DingDanType.单团订单;
                WapHeader1.HeadText = "单团订单";
            }

            Model.xiadanrenid = HuiYuanInfo.UserId;
            if (AgencyId != "")
            {
                Model.fenxiaoid = AgencyId;
            }
            Model.dingdantype = (DingDanType)orderleibie;
            int TotalCount = 0;
            var list = new EyouSoft.BLL.OtherStructure.BDingDan().GetOrders(PageNum, 1, ref TotalCount, Model);
            if (list != null && list.Count > 0)
            {
                Repeater1.DataSource = list;
                XianShi.Text = "";
            }
            else
            {
                Repeater1.DataSource = null;
                XianShi.Text = "暂无数据！";
            }
            Repeater1.DataBind();
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
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
                    return string.Format("<a href=\"javascript:;\" onclick=\"javascript:pageData.setOrder('{0}','{1}');\"  ><span class=\"bg_red\">取消订单</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单);
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                    if ((DingDanType)(int)ordertype == DingDanType.门票订单)
                    {
                        return string.Format("<a href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  ><span class=\"bg_zi\">马上付款</span></a> <a href=\"javascript:;\" onclick=\"javascript:pageData.setOrder('{0}','{3}');\"  ><span class=\"bg_red\">取消订单</span></a>", orderid, (int)ordertype, HuiYuanInfo.UserId, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单);
                    }
                    else
                    {
                        return string.Format("<a href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  ><span class=\"bg_zi\">马上付款</span></a>", orderid, (int)ordertype, HuiYuanInfo.UserId);
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
                    if (isAgency == 1 && FenXiaoId.ToString() == AgencyId.ToString())
                    {
                        return string.Format("  <a href='javascript:;' onclick=\"javascript:pageData.setOrder('{0}','{1}');\"  ><span class=\"bg_green2\">订单出货</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货);
                    }
                    else
                    {
                        return string.Format("");
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                    if (isAgency == 1 && FenXiaoId.ToString() == AgencyId.ToString() && xdrid.ToString() != HuiYuanInfo.UserId)
                    {
                        return string.Format("  <span  class=\"bg_green\">确认出行</span>");
                    }
                    else
                    {
                        return string.Format("  <a href='javascript:;' onclick=\"javascript:pageData.setOrder('{0}','{1}');\"  ><span class=\"bg_green\">确认出行</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利);
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
                    return string.Format("");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单:
                    return string.Format("");
                default:
                    break;
            }
            return "";
        }

        /// <summary>
        /// 转换订单状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        protected string getHuiYuanState(object state)
        {
            EyouSoft.Model.Enum.XianLuStructure.OrderStatus type = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)state;
            switch (type)
            {
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
                    return "<span style='color:rgb(0, 0, 255)'>" + ((DingDanStatusMiaoShu)0).ToString().Replace("oo", "，") + "</span>";
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                    return "<span style='color:rgb(0, 128, 0)'>" + ((DingDanStatusMiaoShu)1).ToString().Replace("oo", "，") + "</span>";
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
                    return "<span style='color:rgb(0, 128, 0)'>" + ((DingDanStatusMiaoShu)2).ToString().Replace("oo", "，") + "</span>";
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                    return "<span style='color:rgb(0, 128, 0)'>" + ((DingDanStatusMiaoShu)3).ToString().Replace("oo", "，") + "</span>";
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
                    if (isAgency == 1)
                    {
                        return "<span style='color:rgb(0, 128, 0)'>" + ((DingDanStatusMiaoShu)4).ToString().Replace("oo", "，") + "</span>";
                    }
                    else
                    {
                        return "<span style='color:rgb(0, 128, 0)'>" + ((DingDanStatusMiaoShu)5).ToString().Replace("oo", "，") + "</span>";
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
                    if (isAgency == 1)
                    {
                        return "<span style='color:rgb(0, 128, 0)'>" + ((DingDanStatusMiaoShu)6).ToString().Replace("oo", "，") + "</span>";
                    }
                    else
                    {
                        return "<span style='color:rgb(0, 128, 0)'>" + ((DingDanStatusMiaoShu)5).ToString().Replace("oo", "，") + "</span>";
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单:
                    return "<span  style='color:rgb(255, 0, 0)'>" + ((DingDanStatusMiaoShu)7).ToString().Replace("oo", "，") + "</span>";
                default:
                    break;
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
