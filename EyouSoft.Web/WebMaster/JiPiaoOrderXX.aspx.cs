using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class JiPiaoOrderXX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string DingDanId = Utils.GetQueryStringValue("OrderId");
            var list = new EyouSoft.BLL.JPStructure.BDingDan().GetInfo(DingDanId);
            if (list != null)
            {
                ltrOrderCode.Text = list.ApiDingDanId;
                HangBanName.Text = CityNameBySZM.GetCityNameBySZM(list.ChuFaChengShiSanZiMa) + " - " + CityNameBySZM.GetCityNameBySZM(list.DaoDaChengShiSanZiMa);
                HangBanHao.Text = list.HangBanHao;
                CangWei.Text = list.CangWei;
                EyouSoft.BLL.OtherStructure.BMember bll = new EyouSoft.BLL.OtherStructure.BMember();
                EyouSoft.Model.MMember model = new EyouSoft.Model.MMember();
                model = bll.GetModel(list.HuiYuanId);
                txtYContact.Text = model.MemberName;
                txtYContactTel.Text = model.Mobile;
                XiaDanShiJian.Text = list.XiaDanShiJian.ToString();
                litLDate.Text = list.ChuFaRiQi.ToShortDateString();
                PiaoMianJia.Text = list.PiaoMianJiaGe.ToString("f2");
                RenShuNum.Text = list.DingPiaoRenShu.ToString();
                ShuiFei.Text = list.ShuiFeiJinE.ToString("f2");
                litJinE.Text = (list.JinE+list.ShuiFeiJinE).ToString("f2");
                rptlist.DataSource = list.ChengKes;
                rptlist.DataBind();
                orderstatus.Text = list.DingDanStatus.ToString();
                PayState.Text = list.FuKuanStatus.ToString();
                //txtBeiZhu.Text = list.

            }
        }
    }
}
