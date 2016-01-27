using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.HotelStructure;
using Common.page;
using EyouSoft.Model.OtherStructure;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Common;

namespace EyouSoft.WAP.Member
{
    public partial class HotelOrderXX : HuiYuanWapPageBase
    {
        BLL.HotelStructure.BHotelOrder bll = new EyouSoft.BLL.HotelStructure.BHotelOrder();
        BSellers bsells = new BSellers();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        protected bool isAgency = false;//判断是否为分销商、免费分销商、员工
        protected int RoomNum = 1;//预订房间数
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "酒店订单";
            GetOrderList();
        }
        public void GetOrderList()
        {
            if (HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
            {
                isAgency = true;
            }
            string orderid = Common.Utils.GetQueryStringValue("orderid");
            MHotelOrder ormodel = new MHotelOrder();
            ormodel = bll.GetModel(orderid);
            if (ormodel != null)
            {
                RoomNum = ormodel.RoomCount;
                ltrHotelName.Text = ormodel.HotelName;
                LitRoomName.Text = ormodel.RoomName;
                ltrOrderCode.Text = ormodel.OrderCode;
                litInTime.Text = ormodel.IssueTime.ToString("yyyy-MM-dd HH:mm:ss");
                litJinE.Text = ormodel.TotalAmount.ToString("f2");
                PayState.Text = ormodel.PaymentState.ToString();
                orderstatus.Text = ormodel.OrderState.ToString();
                StarNum.Text = ormodel.Star.ToString();
                litLDate.Text = ormodel.CheckInDate.ToString("yyyy-MM-dd");
                ltrEDate.Text = ormodel.CheckOutDate.ToString("yyyy-MM-dd");
                ltrTianShu.Text = ormodel.RoomCount.ToString();
                txtBeiZhu.Text = ormodel.Remark;
                txtYContact.Text = ormodel.ContactName;
                txtYContactTel.Text = ormodel.ContactMobile;
                AgencyJinE.Text = ormodel.AgencyJinE.ToString("f2");
                AgencyLiRui.Text = (ormodel.TotalAmount - ormodel.AgencyJinE).ToString("f2");
                if (ormodel.PaymentState == EyouSoft.Model.Enum.PaymentState.未支付)
                {
                    PayState.Text = "<i class=\"font_red\">" + (ormodel.PaymentState).ToString() + "</i>";
                }
                else if (ormodel.PaymentState == EyouSoft.Model.Enum.PaymentState.已支付)
                {
                    PayState.Text = "<i class=\"font_green\">" + (ormodel.PaymentState).ToString() + "</i>";
                }
                if (ormodel.OrderState == EyouSoft.Model.Enum.OrderState.未处理)
                {
                    orderstatus.Text = "<i class=\"font_blue\">" + (ormodel.OrderState).ToString() + "</i>";
                }
                else if (ormodel.OrderState == EyouSoft.Model.Enum.OrderState.待付款)
                {
                    orderstatus.Text = "<i class=\"font_zi\">" + (ormodel.OrderState).ToString() + "</i>";
                }
                else if (ormodel.OrderState ==  EyouSoft.Model.Enum.OrderState.订单出货)
                {
                    orderstatus.Text = "<i class=\"font_green\">" + (ormodel.OrderState).ToString() + "</i>";
                }
                else if (ormodel.OrderState ==  EyouSoft.Model.Enum.OrderState.确认收货)
                {
                    orderstatus.Text = "<i class=\"font_green\">" + (ormodel.OrderState).ToString() + "</i>";
                }
                else if (ormodel.OrderState == EyouSoft.Model.Enum.OrderState.交易完成 || ormodel.OrderState == EyouSoft.Model.Enum.OrderState.待返利)
                {
                    if (HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                    {
                        orderstatus.Text = "<i class=\"font_yellow\">" + (ormodel.OrderState).ToString() + "</i>";
                    }
                    else
                    {
                        orderstatus.Text = "<i class=\"font_yellow\">交易成功</i>";
                    }
                }

                if (ormodel.HotelXC != null)
                {
                    IList<HotelXingCheng> xcmodel = Utils.JsonDeserialize<HotelXingCheng>(ormodel.HotelXC);
                    if (xcmodel != null && xcmodel.Count > 0)
                    {
                        JiageList.DataSource = xcmodel;
                        JiageList.DataBind();
                    }
                }



                if (ormodel != null && ormodel.OrderContact.Count > 0)
                {
                    rptlist.DataSource = ormodel.OrderContact;
                }
                else
                {
                    rptlist.DataSource = null;
                }
                rptlist.DataBind();
            }
            else
            {
                //hotelhtml = "<div style='padding-top:80px; text-align:center;'><span style='font-size:20px; color:red; font-weight:bolder;'>暂无该订单信息，请核对订单号是否正确!</span></div>";
            }
            AnNiu.Text = getZhiFuURL(orderid, ormodel.OrderState, ormodel.SellerID, ormodel.OperatorId);
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
                    return string.Format("<span class=\"y_btn\">等待审核</span>");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                    return string.Format("<a class=\"y_btn\" href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  >马上付款</a>", orderid, (int)DingDanType.酒店订单, HuiYuanInfo.UserId);
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
