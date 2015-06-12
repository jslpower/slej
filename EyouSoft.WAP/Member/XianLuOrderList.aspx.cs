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

namespace EyouSoft.WAP.Member
{
    public partial class XianLuOrderList : HuiYuanWapPageBase
    {
        BLL.XianLuStructure.BOrder bll = new EyouSoft.BLL.XianLuStructure.BOrder();
        BSellers bsells = new BSellers();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        public int PageIndex = 1;
        public int TotalCount = 0;
        public int isAgency = 0;//判断是否为分销商、免费分销商、员工，1为true
        string AgencyId = "";
        protected int ordertype = 0;
        protected int payclass = 0;
        protected override int PageSize
        {
            get
            {
                return 10;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("setState") == "1") setOrderState();
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
            PageIndex = 1;
            EyouSoft.Model.XianLuStructure.MOrderChaXunInfo Model = new EyouSoft.Model.XianLuStructure.MOrderChaXunInfo();

            if (AgencyId != "")
            {
                Model.AgencyId = AgencyId;
            }
            Model.HuiYuanId = HuiYuanInfo.UserId;
            ordertype = Utils.GetInt(Utils.GetQueryStringValue("type"));
            Model.RouteType = (EyouSoft.Model.Enum.AreaType)ordertype;
            if (Model.RouteType == EyouSoft.Model.Enum.AreaType.出境线路)
            {
                payclass = 8;
                WapHeader1.HeadText = "出境线路";
            }
            else if (Model.RouteType == EyouSoft.Model.Enum.AreaType.国内长线)
            {
                payclass = 1;
                WapHeader1.HeadText = "国内长线";
            }
            else if (Model.RouteType == EyouSoft.Model.Enum.AreaType.周边短线)
            {
                payclass = 9;
                WapHeader1.HeadText = "周边短线";
            }
            var list = bll.GetOrders(PageSize, PageIndex, ref TotalCount, Model);
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
                    return string.Format("<a href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  ><span class=\"bg_zi\">马上付款</span></a>", orderid, (int)ordertype, HuiYuanInfo.UserId);
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

            int result = 0;
            result = new EyouSoft.BLL.XianLuStructure.BOrder().SheZhiOrderStatus(orderid, state, new EyouSoft.Model.XianLuStructure.MOrderHistoryInfo() { OperatorId = HuiYuanInfo.UserId });
            RCWE(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "操作成功" : "操作失败"));
        }
    }
}
