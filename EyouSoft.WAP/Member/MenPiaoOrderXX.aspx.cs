using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Model.ScenicStructure.WebModel;
using EyouSoft.Model.OtherStructure;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.WAP.Member
{
    public partial class MenPiaoOrderXX : HuiYuanWapPageBase
    {
        BSellers bsells = new BSellers();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        protected bool isAgency = false;//判断是否为分销商、免费分销商、员工，1为true
        BLL.ScenicStructure.BScenicArea bll = new EyouSoft.BLL.ScenicStructure.BScenicArea();
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "门票订单";
            GetOrderList();
        }
        public void GetOrderList()
        {
            if (HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
            {
                isAgency = true;
            }
            MScenicAreaOrderSearchModel Model = new MScenicAreaOrderSearchModel();
            Model.UserId = HuiYuanInfo.UserId;
            Model.OrderId = Common.Utils.GetQueryStringValue("orderid");
            if (!string.IsNullOrEmpty(Model.OrderId))
            {
                var list = bll.GetScenicAreaOrderModel(Model.OrderId);
                if (list != null)
                {
                    ltrJingQuName.Text = list.ScenicName;
                    ltrOrderCode.Text = list.OrderCode;
                    litInTime.Text = list.IssueTime.ToString();
                    litJinE.Text = list.Price.ToString("f2");
                    litLDate.Text = list.ChuFaRiQi.ToString("yyyy-MM-dd");
                    ltrShuLiang.Text = list.Num.ToString();
                    txtYContactTel.Text = list.OperatorMobile;
                    txtYContact.Text = list.OperatorName;
                    txtContact.Text = list.ContactName;
                    txtContactTel.Text = list.ContactTel;
                    AgencyJinE.Text = list.AgencyJinE.ToString("f2");
                    AgencyLiRui.Text = (list.Price - list.AgencyJinE).ToString("f2");
                    if (list.FuKuanStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款)
                    {
                        PayState.Text = "<i class=\"font_red\">" + (list.FuKuanStatus).ToString() + "</i>";
                    }
                    else if (list.FuKuanStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款)
                    {
                        PayState.Text = "<i class=\"font_green\">" + (list.FuKuanStatus).ToString() + "</i>";
                    }
                    if (list.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理)
                    {
                        orderstatus.Text = "<i class=\"font_blue\">" + (list.Status).ToString() + "</i>";
                    }
                    else if (list.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
                    {
                        orderstatus.Text = "<i class=\"font_z\">" + (list.Status).ToString() + "</i>";
                    }
                    else if (list.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
                    {
                        orderstatus.Text = "<i class=\"font_green\">" + (list.Status).ToString() + "</i>";
                    }
                    else if (list.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货)
                    {
                        orderstatus.Text = "<i class=\"font_green\">" + (list.Status).ToString() + "</i>";
                    }
                    else if (list.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成 || list.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利)
                    {
                        if (HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                        {
                            orderstatus.Text = "<i class=\"font_yellow\">" + (list.Status).ToString() + "</i>";
                        }
                        else
                        {
                            orderstatus.Text = "<i class=\"font_yellow\">交易成功</i>";
                        }
                    }
                    else if (list.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单)
                    {
                        orderstatus.Text = "<i class=\"font_red\">继续采购</i>";
                    }
                    AnNiu.Text = getZhiFuURL(list.OrderId, list.Status, list.SellerID, list.OperatorId);
                } 
            }
            else
            {
                //Literal1.Text = "<div style='padding-top:80px; text-align:center;'><span style='font-size:20px; color:red; font-weight:bolder;'>暂无该订单信息，请核对订单号是否正确!</span></div>";
            }
            
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
                    return string.Format("<a class=\"y_btn\" href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  >马上付款</a>", orderid, (int)DingDanType.门票订单, HuiYuanInfo.UserId);
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
