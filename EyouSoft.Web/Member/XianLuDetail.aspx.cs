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

namespace EyouSoft.Web.Member
{
    public partial class XianLuDetail : ClientModelViewPageBase<EyouSoft.Model.XianLuStructure.MOrderChaXunInfo>
    {
        BLL.XianLuStructure.BOrder bll = new EyouSoft.BLL.XianLuStructure.BOrder();
        public string xianluhtml ="";//线路
        public string youkehtml ="";//游客
        public string lianxihtml =""; //联系人
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
            MOrderInfo ormodel = new MOrderInfo();
            ormodel = bll.GetInfo(orderid);
            if (ormodel !=null && ormodel.OperatorId == HuiYuanInfo.UserId)
            {
                string ChengRenJia ="0.00";
                string ErTongJia ="0.00";
                if(ormodel.RouteType == EyouSoft.Model.Enum.AreaType.周边短线)
                {
                    ChengRenJia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.周边线路, ormodel.JSJCR, ormodel.SCJCR, ormodel.UserType).ToString("f2");
                    ErTongJia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.周边线路, ormodel.JSJER, ormodel.SCJET, ormodel.UserType).ToString("f2");
                }
                else if(ormodel.RouteType == EyouSoft.Model.Enum.AreaType.国内长线)
                {
                    ChengRenJia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.国内线路, ormodel.JSJCR, ormodel.SCJCR, ormodel.UserType).ToString("f2");
                    ErTongJia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.国内线路, ormodel.JSJER, ormodel.SCJET, ormodel.UserType).ToString("f2");
                }
                else if(ormodel.RouteType == EyouSoft.Model.Enum.AreaType.出境线路)
                {
                    ChengRenJia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.国际线路, ormodel.JSJCR, ormodel.SCJCR, ormodel.UserType).ToString("f2");
                    ErTongJia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.国际线路, ormodel.JSJER, ormodel.SCJET, ormodel.UserType).ToString("f2");
                }
                
                xianluhtml = "<div style='padding-top:20px; font-weight:bolder;'>订单信息</div>";
                xianluhtml += "<table width='100%' border='0' class='tableList margin_T10'>"
                    + "<tr><td class='doti' style='width:10%'>订单确认号：</td><td style='width:15%'>" + ormodel.OrderCode + "</td>"
                    + "<td class='doti' style='width:10%'>线路名称：</td><td style='width:40%'>" + ormodel.XianLuName + "</td>"
                    + "<td class='doti' style='width:10%'>发团时间：</td>"
                    + "<td style='width:15%'>" + ormodel.LDate.ToString("yyyy-MM-dd") + "</td></tr>"
                    + "<tr><td class='doti'>总金额：</td><td>￥" + ormodel.JinE.ToString("f2") + "</td>"
                    + "<td class='doti'>支付状态：</td><td>" + ormodel.FuKuanStatus + "</td>"
                    + "<td class='doti'>订单状态：</td><td>" + ormodel.Status + "</td></tr>"
                    + "<tr><td class='doti'>预定数量：</td><td>成人" + ormodel.ChengRenShu + "位，儿童" + ormodel.ErTongShu + "位</td>"
                    + "<td class='doti'>预定价格：</td><td>成人￥<span style='color:red;'>" + ChengRenJia + "</span>/位，儿童￥<span style='color:red;'>" + ErTongJia + "</span>/位</td>"
                    + "<td class='doti'>下单时间：</td>"
                    + "<td>" + ormodel.IssueTime.ToString("yyyy-MM-dd HH:mm:ss") + "</td></tr>";
                if (ormodel.Traffice.Count > 0)
                {
                    xianluhtml += "<tr><td class='doti'>去程航班：</td><td>" + ormodel.Traffice[0].Traffic_01.ToString() + "</td><td class='doti'>回程航班：</td><td>" + ormodel.Traffice[0].Traffic_02 + "</td><td class='doti'></td><td></td></tr>";
                }
                xianluhtml += "<tr><td class='doti'>备注：</td><td colspan='5'>" + ormodel.XiaDanBeiZhu + "</td></tr></table>";
                if (ormodel.YouKes != null && ormodel.YouKes.Count>0)
                {
                    youkehtml = "<div style='padding-top:20px; font-weight:bolder;'>游客信息</div>";
                    youkehtml += "<table width='100%' border='0' class='tableList margin_T10'>";
                    youkehtml += "<th class='doti' style='width:15%;text-align:center;'>游客姓名</th><th class='doti' style='width:10%;text-align:center;'>游客性别</th>";
                    youkehtml += "<th class='doti' style='width:10%;text-align:center;'>游客类型</th><th class='doti' style='width:15%;text-align:center;'>证件类型</th>";
                    youkehtml += "<th class='doti' style='width:25%;text-align:center;'>证件号码</th><th class='doti' style='width:25%;text-align:center;'>联系方式</th>";
                    for (int i = 0; i < ormodel.YouKes.Count; i++)
                    {
                        youkehtml += "<tr><td style='text-align:center;'>" + ormodel.YouKes[i].Name + "</td><td style='text-align:center;'>" + ormodel.YouKes[i].Gender + "</td>"
                          + "<td style='text-align:center;'>" + ormodel.YouKes[i].LeiXing + "</td><td style='text-align:center;'>" + ormodel.YouKes[i].ZhengJianType + "</td>"
                          + "<td style='text-align:center;'>" + ormodel.YouKes[i].ZhengJianCode + "</td><td style='text-align:center;'>" + ormodel.YouKes[i].Mobile + "</td></tr>";
                    }
                    youkehtml += "</table>";
                }
                lianxihtml = "<div style='padding-top:20px; font-weight:bolder;'>联系人信息</div>";
                lianxihtml += "<table width='100%' border='0' class='tableList margin_T10'><tr>"
                 + "<td class='doti' style='width:16%'>联系人姓名：</td>"
                  + "<td style='width:34%'>" + ormodel.LxrName + "</td>"
                  + "<td class='doti' style='width:16%'>联系人手机：</td>"
                  + "<td style='width:34%'>" + ormodel.LxrTelephone + "</td>"
                  + "</tr></table>";


            }
            else
            {
                xianluhtml = "<div style='padding-top:80px; text-align:center;'><span style='font-size:20px; color:red; font-weight:bolder;'>暂无该订单信息，请核对订单号是否正确!</span></div>";
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
