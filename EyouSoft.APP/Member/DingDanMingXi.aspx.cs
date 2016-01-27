using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Common;

namespace EyouSoft.WAP.Member
{
    public partial class DingDanMingXi : HuiYuanWapPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "订单明细";
            PageInit();
        }
        private void PageInit()
        {
            EyouSoft.Model.OtherStructure.MSearchDingDan Model = new EyouSoft.Model.OtherStructure.MSearchDingDan();
            if (HuiYuanInfo.UserId == "Guest" || HuiYuanInfo.UserId == "")
            {
                Response.Redirect("/Default.aspx");
            }
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("dingdanid")))
            {
                Model.DingDanId = Utils.GetQueryStringValue("dingdanid");
            }
            else
            {
                Response.Redirect("/Member/UserCenter.aspx");
            }
            Model.dingdantype = (EyouSoft.Model.OtherStructure.DingDanType)(-1);
            int recordCount = 0;
            var list = new EyouSoft.BLL.OtherStructure.BDingDan().GetOrders(1, 1, ref recordCount, Model);
            if (list != null && list.Count > 0)
            {
                ltrDingDanName.Text = list[0].OrderName;
                DingDanType.Text = list[0].OrderType.ToString();
                ltrOrderCode.Text = list[0].OrderCode;
                litInTime.Text = list[0].IssueTime.ToString();
                litJinE.Text = list[0].JinE.ToString("f2");
                FenXianJinE.Text = (EyouSoft.Model.OtherStructure.DingDanType)(int)(list[0].OrderType) == EyouSoft.Model.OtherStructure.DingDanType.团购订单 ? "0.00" : list[0].AgencyJinE.ToString("f2");
                FenXiaoLiRun.Text = ((EyouSoft.Model.OtherStructure.DingDanType)(int)(list[0].OrderType)) == EyouSoft.Model.OtherStructure.DingDanType.团购订单 ? "0.00" : (Convert.ToDouble(list[0].JinE) - Convert.ToDouble(list[0].AgencyJinE)).ToString("f2");
                orderstatus.Text = list[0].OrderStatus.ToString();
                YuDingName.Text = list[0].LXRName;
                YuDingMoblie.Text = list[0].LXRMoblie;
                if (!string.IsNullOrEmpty(list[0].XDRId))
                {
                    EyouSoft.BLL.OtherStructure.BMember bll = new EyouSoft.BLL.OtherStructure.BMember();
                    EyouSoft.Model.MMember item = new EyouSoft.Model.MMember();
                    item = bll.GetModel(list[0].XDRId);
                    if (item != null)
                    {
                        txtYContact.Text = item.MemberName;
                        txtYContactTel.Text = item.Mobile;
                    }
                    else
                    {
                        txtYContact.Text = "金奥";
                        txtYContactTel.Text = "";
                    }
                }
                else
                {
                    txtYContact.Text = "金奥";
                    txtYContactTel.Text = "";
                }

            }
            else
            {
                xianshi.Text = "暂无订单记录!";
                //XianShi.Text = "暂无订单记录!";
            }
        }
    }
}
