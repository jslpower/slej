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
using EyouSoft.Model.HotelStructure;

namespace EyouSoft.Web.Member
{
    public partial class HotelDetails : ClientModelViewPageBase<EyouSoft.Model.HotelStructure.MHotelOrderSeach>
    {
        BLL.HotelStructure.BHotelOrder bll = new EyouSoft.BLL.HotelStructure.BHotelOrder();
        public string hotelhtml = "";//酒店
        public string youkehtml = "";//客人
        public string lianxihtml = ""; //联系人
        public string Jiagehtml = "";//酒店价格
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HuiYuanInfo.UserId == "Guest" || HuiYuanInfo.UserId == "")
            {
                Response.Redirect("/Default.aspx");
            }
            GetOrderList();
        }
        public void GetOrderList()
        {
            string orderid = Common.Utils.GetQueryStringValue("orderid");
            MHotelOrder ormodel = new MHotelOrder();
            ormodel = bll.GetModel(orderid);
            if (ormodel != null && ormodel.OperatorId == HuiYuanInfo.UserId)
            {
                hotelhtml = "<div style='padding-top:20px; font-weight:bolder;'>订单信息</div>";
                hotelhtml += "<table width='100%' border='0' class='tableList margin_T10'>"
                    + "<tr><td class='doti' style='width:13%'>订单确认号：</td><td style='width:15%'>" + ormodel.OrderCode + "</td>"
                    + "<td class='doti' style='width:15%'>酒店名称(星级)：</td><td style='width:30%'>" + ormodel.HotelName + " ( "+ ormodel.Star +" )</td>"
                    + "<td class='doti' style='width:12%'>房型名称：</td>"
                    + "<td style='width:15%'>" + ormodel.RoomName + "</td></tr>"
                    + "<tr><td class='doti'>入住时间：</td><td>" + ormodel.CheckInDate.ToString("yyyy-MM-dd") + "</td>"
                    + "<td class='doti'>离店时间：</td><td>" + ormodel.CheckOutDate.ToString("yyyy-MM-dd") + "</td>"
                    + "<td class='doti'>房间数量：</td>"
                    + "<td>" + ormodel.RoomCount + "</td></tr>"
                    + "<tr><td class='doti'>订单金额：</td><td>￥" + ormodel.TotalAmount.ToString("f2") + "</td>"
                    + "<td class='doti'>支付状态：</td><td>" + ormodel.PaymentState + "</td>"
                    + "<td class='doti'>订单状态：</td><td>" + ormodel.OrderState + "</td></tr>"
                    + "<tr><td class='doti'>预定价格：</td><td>￥" + (ormodel.TotalAmount / ormodel.RoomCount).ToString("f2") + "/间</td>"
                    + "<td class='doti'>下单时间：</td><td>" + ormodel.IssueTime.ToString("yyyy-MM-dd HH:mm:ss") + "</td>"
                    + "<td class='doti'></td><td></td></tr>"
                    + "<tr><td class='doti'>备注：</td><td colspan='5'>" + ormodel.Remark + "</td></tr></table>";
                if (ormodel != null && ormodel.OrderContact.Count > 0)
                {
                    youkehtml = "<div style='padding-top:20px; font-weight:bolder;'>游客信息</div>";
                    youkehtml += "<table width='100%' border='0' class='tableList margin_T10'>";
                    for (int i = 0; i < ormodel.OrderContact.Count; i++)
                    {
                        youkehtml += "<tr><td  class='doti' style='text-align:right; width:16%'>入住人姓名：</td><td style='text-align:left; width:34%'>" + ormodel.OrderContact[i].ContactName + "</td><td  class='doti' style='text-align:right; width:16%'>入住人手机：</td><td style='text-align:left; width:34%'>" + ormodel.OrderContact[i].Mobile + "</td></tr>";
                    }
                    youkehtml += "</table>";
                }
                lianxihtml = "<div style='padding-top:20px; font-weight:bolder;'>联系人信息</div>";
                lianxihtml += "<table width='100%' border='0' class='tableList margin_T10'><tr>"
                 + "<td class='doti' style='width:16%'>联系人姓名：</td>"
                  + "<td style='width:34%'>" + ormodel.ContactName + "</td>"
                  + "<td class='doti' style='width:16%'>联系人手机：</td>"
                  + "<td style='width:34%'>" + ormodel.ContactMobile + "</td>"
                  + "</tr></table>";
                if (ormodel.HotelXC != null)
                {
                    IList<HotelXingCheng> xcmodel = Utils.JsonDeserialize<HotelXingCheng>(ormodel.HotelXC);
                    if (xcmodel != null && xcmodel.Count > 0)
                    {
                        Jiagehtml += "<div style='padding-top:20px; font-weight:bolder;'>酒店价格列表</div>";
                        Jiagehtml+= "<table width='100%' border='0' class='tableList margin_T10'><tr>"
                 + "<td class='doti' style='width:30%;text-align:center'>日期</td>"
                  + "<td style='width:35%;text-align:center'>金额</td>"
                  + "<td style='width:35%;text-align:center'>分销金额</td>"
                  + "</tr>";
                        for (int m = 0; m < xcmodel.Count; m++)
                        {
                            string CBJia = xcmodel[m].ChengBenJia == 0 ? "总站交易" : xcmodel[m].ChengBenJia.ToString("f2") + "元/间/天  *  " + ormodel.RoomCount + "间 = " + (xcmodel[m].ChengBenJia * ormodel.RoomCount).ToString("f2") + "元/天";
                            Jiagehtml += "<tr>"
                  + "<td class='doti' style='width:30%;text-align:center'>" + xcmodel[m].ChenkInDate.ToShortDateString() + "</td>"
                   + "<td style='width:35%;text-align:center'>" + xcmodel[m].MenShiJia.ToString("f2") + "元/间/天  *  " + ormodel.RoomCount + "间 = " + (xcmodel[m].MenShiJia * ormodel.RoomCount).ToString("f2") + "元/天</td>"
                   + "<td style='width:35%;text-align:center'>" + CBJia + "</td>"
                   + "</tr>";
                            //XC.Text += "<table width='100%' border='0' class='tableList margin_T10'><tr><th width=\"146\" height=\"28\" style=\"text-align:center\">" + xcmodel[m].ChenkInDate.ToShortDateString() + "</th><td height=\"28\" width=\"300\"  bgcolor=\"#E3F1FC\" style=\"text-align:center\">" + xcmodel[m].MenShiJia.ToString("f2") + "元/间/天</td><td height=\"28\" width=\"307\"   bgcolor=\"#E3F1FC\" style=\"text-align:center\">" + CBJia + "</td></tr>";
                        }
                         Jiagehtml +="</table>";
                    }
                }

            }
            else
            {
                hotelhtml = "<div style='padding-top:80px; text-align:center;'><span style='font-size:20px; color:red; font-weight:bolder;'>暂无该订单信息，请核对订单号是否正确!</span></div>";
            }


            //IList<MOrderInfo> list = new List<MOrderInfo>();
            //list.Add(ormodel);
            //ormodel = bll.GetInfo(orderid);
            //Repeater1.DataSource = list;
            //Repeater1.DataBind();
            //Repeater2.DataSource = list;
            //Repeater2.DataBind();
            //Repeater3.DataSource = list;
            //Repeater3.DataBind();

        }
    }
}
