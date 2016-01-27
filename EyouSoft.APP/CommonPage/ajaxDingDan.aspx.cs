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
using EyouSoft.Model.Enum;

namespace EyouSoft.WAP.CommonPage
{
    public partial class ajaxDingDan : HuiYuanWapPageBase
    {
        BZuCheOrder bll = new BZuCheOrder();
        BSellers bsells = new BSellers();
        MSearchDingDan Model = new MSearchDingDan();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        int isAgency = 0;//判断是否为分销商、免费分销商、员工，1为true
        string AgencyId = "";
        protected int PageNum = 8;//每页显示条数
        protected int orderleibie = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            EyouSoft.Model.OtherStructure.DingDanType OrderType = (EyouSoft.Model.OtherStructure.DingDanType)Utils.GetInt(Utils.GetQueryStringValue("OrderType"));
            int pageindex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"));
            mseller = bsells.Get(HuiYuanInfo.UserId);
            if (mseller != null)
            {
                AgencyId = mseller.ID;
                isAgency = 1;
            }
            if (OrderType == EyouSoft.Model.OtherStructure.DingDanType.租车订单)
            {
                orderleibie = (int)EyouSoft.Model.OtherStructure.DingDanType.租车订单;
            }
            if (OrderType == EyouSoft.Model.OtherStructure.DingDanType.酒店订单)
            {
                orderleibie = (int)EyouSoft.Model.OtherStructure.DingDanType.酒店订单;
            }
            if (OrderType == EyouSoft.Model.OtherStructure.DingDanType.门票订单)
            {
                orderleibie = (int)EyouSoft.Model.OtherStructure.DingDanType.门票订单;
            }
            if (OrderType == EyouSoft.Model.OtherStructure.DingDanType.商城订单)
            {
                orderleibie = (int)EyouSoft.Model.OtherStructure.DingDanType.商城订单;
            }
            if (OrderType == EyouSoft.Model.OtherStructure.DingDanType.团购订单)
            {
                orderleibie = (int)EyouSoft.Model.OtherStructure.DingDanType.团购订单;
            }
            if (OrderType == EyouSoft.Model.OtherStructure.DingDanType.机票订单)
            {
                orderleibie = (int)EyouSoft.Model.OtherStructure.DingDanType.机票订单;
            }

            Model.xiadanrenid = HuiYuanInfo.UserId;
            if (AgencyId != "")
            {
                Model.fenxiaoid = AgencyId;
            }
            Model.dingdantype = (DingDanType)orderleibie;
            int TotalCount = 0;
            var list = new EyouSoft.BLL.OtherStructure.BDingDan().GetOrders(PageNum, pageindex, ref TotalCount, Model);
            if (list != null && list.Count > 0)
            {
                if (TotalCount > (pageindex - 1) * PageNum)
                {
                    Repeater1.DataSource = list;
                }
                else
                {
                    Repeater1.DataSource = null;
                }
            }
            else
            {
                Repeater1.DataSource = null;
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
                    return string.Format("<a href=\"javascript:;\" onclick=\"javascript:pageData.setOrder('{0}','{1}');\"  ><span class=\"font_red\">取消订单</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单);
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                    if ((DingDanType)(int)ordertype == DingDanType.门票订单)
                    {
                        return string.Format("<a href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  ><span class=\"bg_zi\">马上付款</span></a> <a href=\"javascript:;\" onclick=\"javascript:pageData.setOrder('{0}','{3}');\"  ><span class=\"font_red\">取消订单</span></a>", orderid, (int)ordertype, HuiYuanInfo.UserId, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单);
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
                        return string.Format("<a href='/Default.aspx'><span class=\"bg_yellow\">继续采购</span></a>");
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
                    return string.Format("<a href='/Default.aspx'><span class=\"bg_yellow\">继续采购</span></a>");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单:
                    return string.Format("<a href='/Default.aspx'><span class=\"bg_yellow\">继续采购</span></a>");
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

    }
}
