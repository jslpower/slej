using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.OtherStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.Web.Member
{
    public partial class JiFenDuiHuan : EyouSoft.Common.Page.HuiYuanPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HuiYuanInfo.UserId == "Guest" || HuiYuanInfo.UserId == "")
            {
                Response.Redirect("/Default.aspx");
            }
            decimal leijijifen = new EyouSoft.BLL.OtherStructure.BPayMents().GetHistoryRate(HuiYuanInfo.UserId);
            int xiaohaojifen = (new EyouSoft.BLL.OtherStructure.BJiFen().GetSumJiFen(HuiYuanInfo.UserId, EyouSoft.Model.Enum.JiFenDuiHuanStatus.审核通过) + new EyouSoft.BLL.OtherStructure.BJiFen().GetSumJiFen(HuiYuanInfo.UserId, EyouSoft.Model.Enum.JiFenDuiHuanStatus.未审核));
           
            JiFenTop.Value = JiFen.Text = (leijijifen-xiaohaojifen).ToString();
            string type = Utils.GetQueryStringValue("type").Trim();

            if (type == "add")
            {
                Response.Clear();
                Response.Write(AddJiLu());
                Response.End();
            }
        }
        private string AddJiLu()
        {
            string msg = "";
            bool iscount = false;
            MJiFen Model = new MJiFen();

            
            Model.DuiHuanJinE = Utils.GetInt(Utils.GetFormValue("JiFenNum"));
            if (Model.DuiHuanJinE > 0)
            {
                decimal leijijifen = new EyouSoft.BLL.OtherStructure.BPayMents().GetHistoryRate(HuiYuanInfo.UserId);
                int xiaohaojifen = (new EyouSoft.BLL.OtherStructure.BJiFen().GetSumJiFen(HuiYuanInfo.UserId, EyouSoft.Model.Enum.JiFenDuiHuanStatus.审核通过) + new EyouSoft.BLL.OtherStructure.BJiFen().GetSumJiFen(HuiYuanInfo.UserId, EyouSoft.Model.Enum.JiFenDuiHuanStatus.未审核));
                if (Model.DuiHuanJinE > (leijijifen - xiaohaojifen))
                {
                    msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "您输入的兑换积分超过您所拥有的积分，请重新核对！");
                }
                else
                {
                    Model.DuiHuanId = Guid.NewGuid().ToString();
                    Model.DuiHuanStatus = JiFenDuiHuanStatus.未审核;
                    Model.IssueTime = DateTime.Now;
                    Model.ShengYuJinE = leijijifen - xiaohaojifen - Model.DuiHuanJinE;
                    Model.UserId = HuiYuanInfo.UserId;
                    iscount = new EyouSoft.BLL.OtherStructure.BJiFen().Add(Model);
                    if (iscount)
                    {
                        msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "提交成功，请等待审核！");
                    }
                    else
                    {
                        msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "提交失败，请重试！");
                    }
                }
            }
            else
            {
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "0积分不能兑换，请重新输入兑换积分！");
            }
            return msg;
        }
    }
}
