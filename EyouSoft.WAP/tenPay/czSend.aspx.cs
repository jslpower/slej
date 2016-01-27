using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayAPI.Model.Tencent;
using Common.page;
using EyouSoft.Common;
using PayAPI.Tencent;

namespace EyouSoft.WAP.tenPay
{
    public partial class czSend : HuiYuanWapPageBase
    {
        protected TenPayTrade TenPayTradeModel = new TenPayTrade();
        protected PrePay _TenPayTradeModel = new PrePay();
        protected string weixin_jsapi_config = string.Empty;
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            initOrderInfo();
            var weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("chooseWXPay");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);

            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }
        /// <summary>
        /// 确认充值订单
        /// </summary>
        void initOrderInfo()
        {
            var czOrder = new EyouSoft.BLL.OtherStructure.BChongZhi().GetInfo(Utils.GetQueryStringValue("orderid"));
            if (czOrder == null)
            {
                plaIsWxBow.Visible = false;
                return;
            }
            lblCode.Text = czOrder.JiaoYiHao;
            lblJinE.Text = czOrder.JinE.ToString("f2");
            lblName.Text = czOrder.HuiYuanName;
            lblAccount.Text = czOrder.HuiYuanYongHuMing;
            lblTime.Text = czOrder.Issuetime.ToString("yyyy-MM-dd hh:mm");

            Tenpay pay = new Tenpay();
            TenPayTradeModel.OPENID = Utils.GetQueryStringValue("openid");
            TenPayTradeModel.Totalfee = czOrder.JinE;
            TenPayTradeModel.UserIP = Utils.GetRemoteIP();
            TenPayTradeModel.OutTradeNo = czOrder.JiaoYiHao;
            TenPayTradeModel.OrderInfo.Body = "充值金额:" + czOrder.JinE.ToString("F2") + "元";

            _TenPayTradeModel = pay.Create_url(TenPayTradeModel);


        }



    }

}
