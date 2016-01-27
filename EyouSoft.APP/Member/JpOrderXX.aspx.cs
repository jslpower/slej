using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Model.JPStructure;
using EyouSoft.Common;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.OtherStructure;
using System.Web.Script.Serialization;
using System.IO;

namespace EyouSoft.WAP.Member
{
    public partial class JpOrderXX : HuiYuanWapPageBase
    {
        BSellers bsells = new BSellers();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        int isAgency = 0;//判断是否为分销商、免费分销商、员工，1为true
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "机票订单";
            GetOrderList();
        }
        public void GetOrderList()
        {
            string orderid = Common.Utils.GetQueryStringValue("orderid");
            MDingDanInfo ormodel = new MDingDanInfo();
            ormodel = new EyouSoft.BLL.JPStructure.BDingDan().GetInfo(orderid);
            if (ormodel != null && ormodel.HuiYuanId == HuiYuanInfo.UserId)
            {

                ltrOrderCode.Text = ormodel.ApiDingDanId;
                ltrFlightName.Text = CityNameBySZM.GetCityNameBySZM(ormodel.ChuFaChengShiSanZiMa) + "-" + CityNameBySZM.GetCityNameBySZM(ormodel.DaoDaChengShiSanZiMa);
                litLDate.Text = ormodel.ChuFaRiQi.ToString("yyyy-MM-dd");
                litJinE.Text = (ormodel.JinE + ormodel.ShuiFeiJinE).ToString("f2");

                if (ormodel.FuKuanStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款)
                {
                    PayState.Text = "<i class=\"font_red\">" + (ormodel.FuKuanStatus).ToString() + "</i>";
                }
                else if (ormodel.FuKuanStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款)
                {
                    PayState.Text = "<i class=\"font_green\">" + (ormodel.FuKuanStatus).ToString() + "</i>";
                }
                if (ormodel.DingDanStatus == DingDanStatus.等待支付)
                {
                    orderstatus.Text = "<i class=\"font_z\">" + (ormodel.DingDanStatus).ToString() + "</i>";
                }
                else if (ormodel.DingDanStatus == DingDanStatus.支付成功)
                {
                    orderstatus.Text = "<i class=\"font_green\">" + (ormodel.DingDanStatus).ToString() + "</i>";
                }
                else if (ormodel.DingDanStatus == DingDanStatus.出票成功)
                {
                    orderstatus.Text = "<i class=\"font_yellow\">" + (ormodel.DingDanStatus).ToString() + "</i>";
                }
                ltrNumber.Text = ormodel.DingPiaoRenShu + "位";
                litInTime.Text = ormodel.XiaDanShiJian.ToString("yyyy-MM-dd HH:mm:ss");

                if (ormodel.ChengKes != null && ormodel.ChengKes.Count > 0)
                {
                    Repeater1.DataSource = ormodel.ChengKes;
                    Repeater1.DataBind();
                }
                EyouSoft.Model.MMember model = new EyouSoft.Model.MMember();
                model = new EyouSoft.BLL.OtherStructure.BMember().GetModel(ormodel.HuiYuanId);
                txtYContact.Text = model.MemberName;
                txtYContactTel.Text = model.Mobile;






                if (ormodel.FuKuanStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款)
                {



                    if (ormodel.GouMaiCangWei != null)
                    {
                        ltrTuiPiao.Text = ormodel.GouMaiCangWei.TuiPiaoGuiDing;
                        ltrGaiQian.Text = ormodel.GouMaiCangWei.GaiQianGuiDing;
                    }

                    plaZhiFu.Visible = true;
                    return;
                }
                AnNiu.Text = getZhiFuURL(orderid, ormodel.DingDanStatus, "", ormodel.HuiYuanId);

            }
        }
        /// <summary>
        /// 获取支付链接
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        protected string getZhiFuURL(string orderid, object state, object AgencyId, object xdrid)
        {
            mseller = bsells.Get(HuiYuanInfo.UserId);
            string FenXiaoId = "";
            if (mseller != null)
            {
                FenXiaoId = mseller.ID;
                isAgency = 1;
            }
            if (string.IsNullOrEmpty(AgencyId.ToString())) { AgencyId = ""; }
            DingDanStatus type = (DingDanStatus)state;
            switch (type)
            {
                case DingDanStatus.等待支付:
                    return string.Format("<a class=\"y_btn\" href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  >马上付款</a>", orderid, (int)DingDanType.机票订单, HuiYuanInfo.UserId);
                case DingDanStatus.支付成功:
                    return string.Format("<span class=\"y_btn\">等待出票</span>");
                case DingDanStatus.出票成功:
                    return string.Format("<a class=\"y_btn\" href='/Default.aspx'>准备出行</a>");
                default:
                    break;
            }
            return "";
        }


    }
}
