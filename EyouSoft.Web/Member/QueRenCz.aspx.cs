using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.Member
{
    public partial class QueRenCz : EyouSoft.Common.Page.HuiYuanPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Utils.GetQueryStringValue("iframeId"))) RCWE("请求错误！");
            getZFinfo();
        }

        void getZFinfo()
        {
            var info = new EyouSoft.BLL.OtherStructure.BChongZhi().GetInfo(Utils.GetQueryStringValue("id"));
            if (info == null) RCWE("数据异常！");
            lblchongzhijine.Text = info.JinE.ToString("C2");
            lblzhifuURL.Text = string.Format("<a  target=\"_blank\" href=\"/99bill/send.aspx?orderid={0}&type={1}&token={2}\">充值</a>", info.DingDanId, (int)EyouSoft.Model.Enum.DingDanLeiBie.充值订单, HuiYuanInfo.UserId);
        }
    }
}
