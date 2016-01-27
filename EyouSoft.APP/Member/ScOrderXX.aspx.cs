using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using EyouSoft.Model.OtherStructure;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.WAP.Member
{
    public partial class ScOrderXX : HuiYuanWapPageBase
    {
        BSellers bsells = new BSellers();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        protected bool isAgency = false;//判断是否为分销商、免费分销商、员工，1为true
        BLL.ScenicStructure.BScenicArea2 bll = new EyouSoft.BLL.ScenicStructure.BScenicArea2();
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "商城订单";
            initPage();
        }
        void initPage()
        {
            if (HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
            {
                isAgency = true;
            }
            var model = new EyouSoft.BLL.MallStructure.BShangChengDingDan().GetModel(Utils.GetQueryStringValue("orderid"));
            if (model != null)
            {
                ltrChanPinName.Text = model.ProductName;
                ltrOrderCode.Text = model.OrderCode;
                txtContact.Text = model.ContactName;
                litInTime.Text = model.IssueTime.ToString();
                litJinE.Text = model.OrderPrice.ToString("C2");
                txtContactTel.Text = model.ContactPhone;
                ltrShuLiang.Text = model.ProductNum.ToString();
                txtBeiZhu.Text = model.Remark;
                AgencyJinE.Text = model.SupplierMoney.ToString("f2");
                AgencyLiRui.Text = (model.OrderPrice - model.SupplierMoney).ToString("f2");
                if (model.PayState == EyouSoft.Model.Enum.PaymentState.未支付)
                {
                    PayState.Text = "<i class=\"font_red\">未付款</i>";
                }
                else if (model.PayState == EyouSoft.Model.Enum.PaymentState.已支付)
                {
                    PayState.Text = "<i class=\"font_green\">已付款</i>";
                }
                if (model.OrderState == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理)
                {
                    orderstatus.Text = "<i class=\"font_blue\">" + (model.OrderState).ToString() + "</i>";
                }
                else if (model.OrderState == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款)
                {
                    orderstatus.Text = "<i class=\"font_z\">" + (model.OrderState).ToString() + "</i>";
                }
                else if (model.OrderState == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
                {
                    orderstatus.Text = "<i class=\"font_green\">" + (model.OrderState).ToString() + "</i>";
                }
                else if (model.OrderState == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货)
                {
                    orderstatus.Text = "<i class=\"font_green\">" + (model.OrderState).ToString() + "</i>";
                }
                else if (model.OrderState == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成 || model.OrderState == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利)
                {
                    if (HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                    {
                        orderstatus.Text = "<i class=\"font_yellow\">" + (model.OrderState).ToString() + "</i>";
                    }
                    else
                    {
                        orderstatus.Text = "<i class=\"font_yellow\">交易成功</i>";
                    }
                }
                else if (model.OrderState == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单)
                {
                    orderstatus.Text = "<i class=\"font_red\">继续采购</i>";
                }
               
                if (model.Address != null) ltrDiZhi.Text = string.Format("{0}{1}{2}{3}", model.Address.ProvinceName, model.Address.CityName, model.Address.DistrictName, model.Address.AddressInfo);

                AnNiu.Text = getZhiFuURL(model.OrderID, model.OrderState, model.SupplierID, model.ContactID);
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
                    return string.Format("<a class=\"y_btn\" href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  >马上付款</a>", orderid, (int)DingDanType.商城订单, HuiYuanInfo.UserId);
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
