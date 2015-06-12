using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.WAP.Member
{
    public partial class TiXianXX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            initPage();
            WapHeader1.HeadText = "E额宝提现明细详情";
        }
        void initPage()
        {
            var model = new EyouSoft.BLL.MoneyStructure.BApplyTiXian().GetInfo(Utils.GetQueryStringValue("tixianid"));
            if (model != null)
            {
                JiaoYiHao.Text = model.TransactionID;
                litInTime.Text = model.TiXianTime.ToShortDateString();
                litJinE.Text = model.JinE.ToString("f2");
                BankName.Text = model.KaiHuBank;
                UserName.Text = model.KaiHuName;
                BankNum.Text = model.BankNum;
                TiXianStatus.Text = model.TiXianStatus.ToString();
                ShenHeStatus.Text = model.ApplyStatus.ToString();
                TiXianBZ.Text=model.BeiZhu;
                ShenHeBZ.Text = model.ShenHeBeiZhu;
            }
        }
    }
}
