using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using System.Data;
using EyouSoft.Common;

namespace EyouSoft.Web.Member
{
    public partial class ScenicDetails : ClientModelViewPageBase<EyouSoft.Model.ScenicStructure.WebModel.MScenicAreaOrderSearchModel>
    {
        BLL.ScenicStructure.BScenicArea bll = new EyouSoft.BLL.ScenicStructure.BScenicArea();
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
            Model.UserId = HuiYuanInfo.UserId;
            Model.OrderId = Common.Utils.GetQueryStringValue("orderid");
            if (!string.IsNullOrEmpty(Model.OrderId))
            {
                var list = bll.GetScenicAreaOrderModel(Model.OrderId);

                if (list == null)
                {
                    Literal1.Text = "<div style='padding-top:80px; text-align:center;'><span style='font-size:20px; color:red; font-weight:bolder;'>暂无该订单信息，请核对订单号是否正确!</span></div>";
                }
                else
                {
                    ltrJingQuName.Text = list.ScenicName;
                    ltrOrderCode.Text = list.OrderCode;
                    litInTime.Text = list.IssueTime.ToString();
                    litJinE.Text = list.Price.ToString("f2");
                    litLDate.Text = list.ChuFaRiQi.ToString("yyyy-MM-dd");
                    ltrShuLiang.Text = list.Num.ToString();
                    txtContact.Text = list.ContactName;
                    txtContactTel.Text = list.ContactTel;
                    PayState.Text = list.FuKuanStatus.ToString();
                    orderstatus.Text = list.Status.ToString();
                }
            }
            else
            {
                Literal1.Text = "<div style='padding-top:80px; text-align:center;'><span style='font-size:20px; color:red; font-weight:bolder;'>暂无该订单信息，请核对订单号是否正确!</span></div>";
            }

        }
    }
}
