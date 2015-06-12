using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.OtherStructure;


namespace EyouSoft.WAP.Member
{
    public partial class ZuCheOrderXX : HuiYuanWapPageBase
    {
        BSellers bsells = new BSellers();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        protected bool isAgency = false;//判断是否为分销商、免费分销商、员工，1为true
        protected string StrOrderStatus = string.Empty;
        protected string StrPayState = string.Empty;
        /// <summary>
        /// 订单编号
        /// </summary>
        string OrderId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "租车订单";
            if (!Page.IsPostBack)
            {
                PageInit();
            }
        }
        private void PageInit()
        {
            if (HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
            {
                isAgency = true;
            }
            OrderId = Utils.GetQueryStringValue("orderid");
            if (string.IsNullOrEmpty(OrderId)) RCWE("请求异常");
            string type = Utils.GetQueryStringValue("type");
            var order = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().GetModel(OrderId);
            if (order == null) RCWE("请求异常");
            ltrCarName.Text = order.CarName;
            ZuCheType.Text = order.ZuCheType == 1 ? "同城往返包租车" : "单接单送租车";
            ltrOrderCode.Text = order.OrderCode;
            ltrGongLiShu.Text = order.GongLiShu.ToString();
            txtContact.Text = order.LxrName;
            txtContactTel.Text = order.LxrTelephone;
            litInTime.Text = order.IssueTime.ToString("yyyy-MM-dd");
            litLDate.Text = order.LDate.Value.ToString("yyyy-MM-dd HH:mm");
            ltrEDate.Text = order.EDate != null ? order.EDate.Value.ToString("yyyy-MM-dd") : "";
            litJinE.Text = order.ZuJin.Value.ToString("C2");
            ltrTianShu.Text = order.ZuCheTianShu.ToString();
            AgencyJinE.Text = order.AgencyJinE.ToString("f2");
            AgencyLiRui.Text = (Convert.ToDecimal(order.ZuJin) - order.AgencyJinE).ToString("f2");
            if (order.FuKuanStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款)
            {
                PayState.Text = "<i class=\"font_red\">"+(order.FuKuanStatus).ToString()+"</i>";
            }
            else if (order.FuKuanStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款)
            {
                PayState.Text = "<i class=\"font_green\">" + (order.FuKuanStatus).ToString() + "</i>";
            }
            if (order.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理)
            {
                orderstatus.Text = "<i class=\"font_blue\">" + (order.Status).ToString() + "</i>";
            }
            else if (order.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
            {
                orderstatus.Text = "<i class=\"font_z\">" + (order.Status).ToString() + "</i>";
            }
            else if (order.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
            {
                orderstatus.Text = "<i class=\"font_green\">" + (order.Status).ToString() + "</i>";
            }
            else if (order.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货)
            {
                orderstatus.Text = "<i class=\"font_green\">" + (order.Status).ToString() + "</i>";
            }
            else if (order.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成 || order.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利)
            {
                if (HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                {
                    orderstatus.Text = "<i class=\"font_yellow\">" + (order.Status).ToString() + "</i>";
                }
                else
                {
                    orderstatus.Text = "<i class=\"font_yellow\">交易成功</i>";
                }
            }
            else if (order.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单)
            {
                orderstatus.Text = "<i class=\"font_red\">继续采购</i>";
            }

            ltrNumber.Text = order.Number.ToString() + "辆";
            txtYContact.Text = order.YuDingRName;
            txtYContactTel.Text = order.YuDingRTelephone;
            txtBeiZhu.Text = order.XiaDanBeiZhu;
            if (order.Xingcheng != null && order.Xingcheng.Count > 0)
            {
                rptlist.DataSource = order.Xingcheng;
                rptlist.DataBind();
            }
            else
            {
                lbemptymsg.Text = "<tr><td colspan='4' align='center' height='30px'>暂无数据!</td></tr>";
            }
            AnNiu.Text = getZhiFuURL(OrderId, order.Status, order.AgencyId, order.OperatorId);
        }
        /// <summary>
        /// 获取支付链接
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        protected string getZhiFuURL(string orderid, object state, object AgencyId, object xdrid)
        {
            mseller = bsells.Get(HuiYuanInfo.UserId);
            string FenXiaoId = "";
            if (mseller != null)
            {
                FenXiaoId = mseller.ID;
                isAgency = true;
            }
            if (string.IsNullOrEmpty(AgencyId.ToString())) { AgencyId = ""; }
            EyouSoft.Model.Enum.XianLuStructure.OrderStatus type = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)state;
            switch (type)
            {
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
                    return string.Format("<a href='javascript:;' class=\"y_btn\">等待审核</a>");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                    return string.Format("<a class=\"y_btn\" href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  >马上付款</a>", orderid, (int)DingDanType.租车订单, HuiYuanInfo.UserId);
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
                    if (isAgency == true && FenXiaoId.ToString() == AgencyId.ToString())
                    {
                        return string.Format("  <a class=\"y_btn\" href='javascript:;' onclick=\"javascript:pageData.setOrder('{0}','{1}');\"  >订单出货</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货);
                    }
                    else
                    {
                        return string.Format("<a href='javascript:;' class=\"y_btn\">继续采购</a>");
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                    if (isAgency == true && FenXiaoId.ToString() == AgencyId.ToString() && xdrid.ToString() != HuiYuanInfo.UserId)
                    {
                        return string.Format("<a href='javascript:;' class=\"y_btn\">确认出行</a>");
                    }
                    else
                    {
                        return string.Format("  <a class=\"y_btn\" href='javascript:;' onclick=\"javascript:pageData.setOrder('{0}','{1}');\"  >确认出行</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利);
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
                    return string.Format("<a class=\"y_btn\" href='/Default.aspx'>继续采购</a>");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单:
                    return string.Format("<a class=\"y_btn\" href='/Default.aspx'>继续采购</a>");
                default:
                    break;
            }
            return "";
        }
    }
}
