using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.Enum;
using EyouSoft.IDAL.MemberStructure;
using EyouSoft.Model.MemberStructure;

namespace EyouSoft.Web.WebMaster
{
    public partial class UntreatedOrders : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (UserInfo.LeiXing == WebmasterUserType.后台用户)
            {
                int weichuli = 0;
                int weifukuan = 0;
                int weifanli = 0;
                //线路订单
                weichuli = new EyouSoft.BLL.XianLuStructure.BOrder().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理);
                weifukuan = new EyouSoft.BLL.XianLuStructure.BOrder().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款);
                weifanli = new EyouSoft.BLL.XianLuStructure.BOrder().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利);
                Literal1.Text = "<tr class='even' style='line-height:35px'><td style='font-size:18px; text-align:center'>线路订单</td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weichuli + "条</span></td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weifukuan + "条</span></td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weifanli + "条</span></td><td style='font-size:18px; text-align:center'><a href='OrderList.aspx'>立即去处理</a></td></tr>";
                //签证订单
                weichuli = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理);
                weifukuan = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款);
                weifanli = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利);
                Literal1.Text += "<tr class='odd' style='line-height:35px'><td style='font-size:18px; text-align:center'>签证订单</td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weichuli + "条</span></td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weifukuan + "条</span></td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weifanli + "条</span></td><td style='font-size:18px; text-align:center'><a href='QianZheng/DingDan.aspx'>立即去处理</a></td></tr>";
                //门票订单
                weichuli = new EyouSoft.BLL.ScenicStructure.BScenicArea().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理);
                weifukuan = new EyouSoft.BLL.ScenicStructure.BScenicArea().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款);
                weifanli = new EyouSoft.BLL.ScenicStructure.BScenicArea().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利);
                Literal1.Text += "<tr class='even' style='line-height:35px'><td style='font-size:18px; text-align:center'>门票订单</td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weichuli + "条</span></td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weifukuan + "条</span></td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weifanli + "条</span></td><td style='font-size:18px; text-align:center'><a href='ScenicAndTicketManage/ScenicOrderList.aspx'>立即去处理</a></td></tr>";
                //酒店订单
                weichuli = new EyouSoft.BLL.HotelStructure.BHotelOrder().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理);
                weifukuan = new EyouSoft.BLL.HotelStructure.BHotelOrder().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款);
                weifanli = new EyouSoft.BLL.HotelStructure.BHotelOrder().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利);
                Literal1.Text += "<tr class='odd' style='line-height:35px'><td style='font-size:18px; text-align:center'>酒店订单</td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weichuli + "条</span></td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weifukuan + "条</span></td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weifanli + "条</span></td><td style='font-size:18px; text-align:center'><a href='HotelManage/HotelOrderList.aspx'>立即去处理</a></td></tr>";
                //租车订单
                weichuli = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理);
                weifukuan = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款);
                weifanli = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利);
                Literal1.Text += "<tr class='even' style='line-height:35px'><td style='font-size:18px; text-align:center'>租车订单</td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weichuli + "条</span></td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weifukuan + "条</span></td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weifanli + "条</span></td><td style='font-size:18px; text-align:center'><a href='ZuChe/ZuCheOrderList.aspx'>立即去处理</a></td></tr>";
                //商城订单
                weichuli = new EyouSoft.BLL.MallStructure.BShangChengDingDan().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理);
                weifukuan = new EyouSoft.BLL.MallStructure.BShangChengDingDan().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款);
                weifanli = new EyouSoft.BLL.MallStructure.BShangChengDingDan().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利);
                Literal1.Text += "<tr class='odd' style='line-height:35px'><td style='font-size:18px; text-align:center'>商城订单</td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weichuli + "条</span></td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weifukuan + "条</span></td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weifanli + "条</span></td><td style='font-size:18px; text-align:center'><a href='ShangCheng/OrderList.aspx'>立即去处理</a></td></tr>";
                //团购订单
                weichuli = new EyouSoft.BLL.OtherStructure.BTuanGouDingDan().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理);
                weifukuan = new EyouSoft.BLL.OtherStructure.BTuanGouDingDan().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款);
                weifanli = new EyouSoft.BLL.OtherStructure.BTuanGouDingDan().GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利);
                Literal1.Text += "<tr class='even' style='line-height:35px'><td style='font-size:18px; text-align:center'>团购订单</td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weichuli + "条</span></td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weifukuan + "条</span></td><td style='font-size:18px; text-align:center'><span style='color:red;'>" + weifanli + "条</span></td><td style='font-size:18px; text-align:center'><a href='TuanGou/TuanGouDingDans.aspx'>立即去处理</a></td></tr>";
            }
            else
            {
                form1.Visible = false;
            }
            BindValidUserCount();
        }


        protected void BindValidUserCount()
        {

            BMember2 bll = new BMember2();
            EyouSoft.Model.MemberStructure.WebModel.MMember2SearchModel SearchModel = new EyouSoft.Model.MemberStructure.WebModel.MMember2SearchModel();
           SearchModel.IsPage = false;
            SearchModel.ValidDate = DateTime.Now;
            var list = bll.GetMemberList(SearchModel);
            lblCount.Text = list.Count.ToString();

        }
    }
}
