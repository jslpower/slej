using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using System.Data;
using EyouSoft.Common;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.SystemStructure;
using EyouSoft.BLL.SystemStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.WAP.CommonPage
{
    public partial class ajaxXianLuOrder : HuiYuanWapPageBase
    {
        BLL.XianLuStructure.BOrder bll = new EyouSoft.BLL.XianLuStructure.BOrder();
        BSellers bsells = new BSellers();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        public int PageIndex = 1;
        public int TotalCount = 0;
        public int isAgency = 0;//判断是否为分销商、免费分销商、员工，1为true
        string AgencyId = "";
        protected int ordertype = 0;
        protected override int PageSize
        {
            get
            {
                return 10;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            mseller = bsells.Get(HuiYuanInfo.UserId);
            if (mseller != null)
            {
                AgencyId = mseller.ID;
                isAgency = 1;
            }
            else
            {
                AgencyId = "";
            }
            //if (Utils.GetQueryStringValue("setState") == "1") setOrderState();
            GetOrderList(AgencyId);
        }
        public void GetOrderList(string AgencyId)
        {
            PageIndex = Utils.GetInt(Utils.GetQueryStringValue("pageindex")); ;
            EyouSoft.Model.XianLuStructure.MOrderChaXunInfo Model = new EyouSoft.Model.XianLuStructure.MOrderChaXunInfo();

            if (AgencyId != "")
            {
                Model.AgencyId = AgencyId;
            }
            Model.HuiYuanId = HuiYuanInfo.UserId;
            ordertype = Utils.GetInt(Utils.GetQueryStringValue("OrderType"));
            Model.RouteType = (EyouSoft.Model.Enum.AreaType)ordertype;
            var list = bll.GetOrders(PageSize, PageIndex, ref TotalCount, Model);
            if (list != null && list.Count > 0)
            {
                if (TotalCount > (PageIndex - 1) * PageSize)
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
                    return string.Format("<a href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  ><span class=\"bg_zi\">马上付款</span></a>", orderid, (int)ordertype, HuiYuanInfo.UserId);
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

