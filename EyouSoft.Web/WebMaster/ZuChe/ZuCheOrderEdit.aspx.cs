using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.ZuChe
{
    public partial class ZuCheOrderEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected string StrOrderStatus = string.Empty;
        protected string StrPayState = string.Empty;
        /// <summary>
        /// 订单编号
        /// </summary>
        string OrderId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "sava") RCWE(Update());

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
            ltrNumber.Text = order.Number.ToString()+"辆";
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
            //if (order.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
            //{
            //    if (type == "update")
            //    {
            //        string html = "订单状态为<b>" + order.Status + "</b>，不能修改。";
            //        ltrOperatorHTML.Text = html;
            //    }
            //}
            //else
            //{
            //    if (type == "update")
            //    {
            //        ltrOperatorHTML.Text = " <a href=\"javascript:void(0)\" id=\"i_a_xiugai\">提交修改</a>";
            //    }
            //}
        }

        private string Update()
        {
            string orderid = Utils.GetQueryStringValue("orderid");
            string type = Utils.GetQueryStringValue("type");
            if (string.IsNullOrEmpty(orderid) && type != "update") return Utils.AjaxReturnJson("0", "该数据无效请重新选择!");
            
            var item1 = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().GetModel(orderid);
            if (item1 == null) return Utils.AjaxReturnJson("0", "该数据无效请重新选择!");
            var item = model(item1);
            if (item1.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货) UtilsCommons.AjaxReturnJson("0", "订单状态为已成交，不能修改。");
            
            int bllRetCode = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().Update(item);
            if (bllRetCode == 1)
            {
                return Utils.AjaxReturnJson("1", "订单修改成功!");
            }
            else
            { return Utils.AjaxReturnJson("0", "订单修改失败!"); }
        }

        EyouSoft.Model.ZuCheStructure.MZuCheOrder model(EyouSoft.Model.ZuCheStructure.MZuCheOrder m)
        {
            var item = new EyouSoft.Model.ZuCheStructure.MZuCheOrder();
            item = m;
            item.Status = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)Utils.GetInt(Utils.GetFormValue("orderstatus"));
            item.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)Utils.GetInt(Utils.GetFormValue("sel_PayState"));
            return item;
        }
    }
}
