using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.Member
{
    public partial class ZuCheDetails : System.Web.UI.Page
    {
        protected string StrOrderStatus = string.Empty;
        protected string StrPayState = string.Empty;
        /// <summary>
        /// 订单编号
        /// </summary>
        string OrderId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PageInit();
            }
        }
        private void PageInit()
        {
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
            PayState.Text = (order.FuKuanStatus).ToString();
            orderstatus.Text = (order.Status).ToString();
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
        }
        protected void RCWE(string s)
        {
            Response.Clear();
            Response.Write(s);
            Response.End();
        }
    }
}
