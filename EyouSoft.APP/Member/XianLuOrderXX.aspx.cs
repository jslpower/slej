using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using System.Data;
using EyouSoft.Common;
using EyouSoft.Model.XianLuStructure;
using EyouSoft.Model.OtherStructure;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.WAP.Member
{
    public partial class XianLuOrderXX : HuiYuanWapPageBase
    {
        BSellers bsells = new BSellers();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        protected bool isAgency = false;//判断是否为分销商、免费分销商、员工，1为true
        BLL.XianLuStructure.BOrder bll = new EyouSoft.BLL.XianLuStructure.BOrder();
        public string xianluhtml = "";//线路
        public string youkehtml = "";//游客
        public string lianxihtml = ""; //联系人
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "线路订单";
            GetOrderList();
        }
        public void GetOrderList()
        {
            if (HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
            {
                isAgency = true;
            }
            string orderid = Common.Utils.GetQueryStringValue("orderid");
            MOrderInfo ormodel = new MOrderInfo();
            ormodel = bll.GetInfo(orderid);
            if (ormodel != null)
            {
                ltrOrderCode.Text = ormodel.OrderCode;
                ltrCarName.Text = ormodel.XianLuName;
                litLDate.Text = ormodel.LDate.ToString("yyyy-MM-dd");
                litJinE.Text = ormodel.JinE.ToString("f2");
                AgencyJinE.Text = ormodel.AgencyJinE.ToString("f2");
                AgencyLiRui.Text = (ormodel.JinE - ormodel.AgencyJinE).ToString("f2");
                if (ormodel.FuKuanStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款)
                {
                    PayState.Text = "<i class=\"font_red\">" + (ormodel.FuKuanStatus).ToString() + "</i>";
                }
                else if (ormodel.FuKuanStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款)
                {
                    PayState.Text = "<i class=\"font_green\">" + (ormodel.FuKuanStatus).ToString() + "</i>";
                }
                if (ormodel.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理)
                {
                    orderstatus.Text = "<i class=\"font_blue\">" + (ormodel.Status).ToString() + "</i>";
                }
                else if (ormodel.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
                {
                    orderstatus.Text = "<i class=\"font_z\">" + (ormodel.Status).ToString() + "</i>";
                }
                else if (ormodel.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
                {
                    orderstatus.Text = "<i class=\"font_green\">" + (ormodel.Status).ToString() + "</i>";
                }
                else if (ormodel.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货)
                {
                    orderstatus.Text = "<i class=\"font_green\">出单成功，请按通知要求出行</i>";
                }
                else if (ormodel.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成 || ormodel.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利)
                {
                    if (HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                    {
                        orderstatus.Text = "<i class=\"font_yellow\">" + (ormodel.Status).ToString() + "</i>";
                    }
                    else
                    {
                        orderstatus.Text = "<i class=\"font_yellow\">交易成功</i>";
                    }
                }
                else if (ormodel.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单)
                {
                    orderstatus.Text = "<i class=\"font_red\">继续采购</i>";
                }
                ltrNumber.Text = "成人" + ormodel.ChengRenShu + "位，儿童" + ormodel.ErTongShu + "位";
                YuDingJiaGe.Text = "成人￥<span style='color:red;'>" + ormodel.JiaoYiCR.ToString("f2") + "</span>/位，儿童￥<span style='color:red;'>" + ormodel.JiaoYiET.ToString("f2") + "</span>/位";
                litInTime.Text = ormodel.IssueTime.ToString("yyyy-MM-dd HH:mm:ss");
                if (ormodel.Traffice.Count > 0)
                {
                    ltrQu.Text = "<p>去程航班：" + ormodel.Traffice[0].Traffic_01.ToString() + "</p>";
                    ltrHui.Text = "<p>回程航班:" + ormodel.Traffice[0].Traffic_02 + "</p>";
                }
                txtBeiZhu.Text = ormodel.XiaDanBeiZhu;
                if (ormodel.YouKes != null && ormodel.YouKes.Count > 0)
                {
                    Repeater1.DataSource = ormodel.YouKes;
                    Repeater1.DataBind();
                }
                txtYContact.Text = ormodel.LxrName;
                txtYContactTel.Text = ormodel.LxrTelephone;
                AnNiu.Text = getZhiFuURL(orderid, ormodel.Status, ormodel.AgencyId, ormodel.OperatorId, (int)ormodel.RouteType);

            }
        }
        /// <summary>
        /// 获取支付链接
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        protected string getZhiFuURL(string orderid, object state, object AgencyId, object xdrid, object ordertype)
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
                    return string.Format("<span class=\"y_btn\">等待审核</span>");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                    return string.Format("<a class=\"y_btn\" href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  >马上付款</a>", orderid, (int)ordertype, HuiYuanInfo.UserId);
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
                    if (isAgency == true && FenXiaoId.ToString() == AgencyId.ToString())
                    {
                        return string.Format("  <a class=\"y_btn\" href='javascript:;' onclick=\"javascript:pageData.setOrder('{0}','{1}');\"  >订单出货</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货);
                    }
                    else
                    {
                        return string.Format("<span class=\"y_btn\">继续采购</span>");
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                    if (isAgency == true && FenXiaoId.ToString() == AgencyId.ToString() && xdrid.ToString() != HuiYuanInfo.UserId)
                    {
                        return string.Format("<span class=\"y_btn\">确认出行</span>");
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
