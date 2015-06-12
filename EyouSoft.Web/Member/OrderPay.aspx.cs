using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.YlWeb.Hangqi
{
    public partial class OrderPay : EyouSoft.Common.Page.HuiYuanPageBase

    {
        protected string DingDanId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            // if (Utils.GetQueryStringValue("send") == "send") { Send(); }

            DingDanId = Utils.GetQueryStringValue("orderid");
            var DingDanLeiXing = (EyouSoft.Model.Enum.DingDanLeiBie?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.Enum.DingDanLeiBie), Utils.GetQueryStringValue("type"));

            if (string.IsNullOrEmpty(DingDanId) || !DingDanLeiXing.HasValue) RCWE("异常请求");

            switch (DingDanLeiXing.Value)
            {
                case EyouSoft.Model.Enum.DingDanLeiBie.线路订单:
                    InitDingDan_XianLu();
                    break;
                case EyouSoft.Model.Enum.DingDanLeiBie.商城订单:
                    InitDingDan_ShangCheng();
                    break;
                default:
                    RCWE("异常请求");
                    break;
            }

            var outputscript = string.Format("var banks={0};", Newtonsoft.Json.JsonConvert.SerializeObject(new MZaiXianZhiFuFangShiInfo().GetZaiXianZhiFuFangShis()));
            RegisterScript(outputscript);
        }

        #region private members
        /// <summary>
        /// init hangqi dingdan
        /// </summary>
        void InitDingDan_ShangCheng()
        {
            var info = new EyouSoft.BLL.MallStructure.BShangChengDingDan().GetModel(DingDanId);
            if (info == null) RCWE("异常请求");
            if (info.OrderState != EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款) RCWE("你不能支付该订单");
            if (info.PayState == EyouSoft.Model.Enum.PaymentState.已支付) RCWE("该订单已支付");

            EyouSoft.Model.SSOStructure.MUserInfo m = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);
            if (info.ContactID != Utils.GetQueryStringValue("token")) RCWE("你不能支付该订单");
            if (isLogin && info.ContactID != m.UserId) RCWE("你不能支付该订单");

            ltrJiaoYiHao.Text = info.OrderCode;
            ltrMingCheng.Text = info.ProductName;
            ltrJinE.Text = info.OrderPrice.ToString("F2");
        }

        /// <summary>
        /// 线路订单
        /// </summary>
        void InitDingDan_XianLu()
        {
            var info = new EyouSoft.BLL.XianLuStructure.BOrder().GetInfo(DingDanId);
            if (info == null) RCWE("异常请求");
            if (info.Status != EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款) RCWE("你不能支付该订单");
            if (info.FuKuanStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款) RCWE("该订单已支付");

            EyouSoft.Model.SSOStructure.MUserInfo m = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);
            if (info.OperatorId != Utils.GetQueryStringValue("token")) RCWE("你不能支付该订单");
            if (isLogin && info.OperatorId != m.UserId) RCWE("你不能支付该订单");

            ltrJiaoYiHao.Text = info.OrderCode;
            ltrMingCheng.Text = info.XianLuName;
            ltrJinE.Text = info.JinE.ToString("F2");
        }

        //void Send()
        //{
        //    string bank_fs = Utils.GetQueryStringValue("bank_fs");
        //    string bank_id = Utils.GetQueryStringValue("bank_id");
        //    string dingdanid = Utils.GetQueryStringValue("dingdanid");
        //    string dingdanleixing = Utils.GetQueryStringValue("dingdanleixing");
        //    string token = Utils.GetQueryStringValue("token");

        //    if (string.IsNullOrEmpty(bank_fs) || string.IsNullOrEmpty(bank_id)) Utils.RCWE("异常请求");
        //    var bankinfo = new MZaiXianZhiFuFangShiInfo().GetZaiXianZhiFuFangShiInfo(bank_id);
        //    if (bankinfo == null) Utils.RCWE("异常请求");
        //    if (bankinfo.fs != bank_fs) Utils.RCWE("异常请求");

        //    string url = "";

        //    if (bankinfo.fs == "0")
        //    {
        //        url = "/99bill/send.aspx?bank_zl=1&bank_id=" + bankinfo.bankid + "&dingdanid=" + dingdanid + "&dingdanleixing=" + dingdanleixing + "&token=" + token;
        //    }
        //    else if (bankinfo.fs == "1")
        //    {
        //        if (bankinfo.bankid == "ALIPAY")
        //        {
        //            url = "/alipay/alipay_trade.aspx?dingdanid=" + dingdanid + "&dingdanleixing=" + dingdanleixing + "&token=" + token;
        //        }
        //        if (bankinfo.bankid == "99BILL")
        //        {
        //            url = "/99bill/send.aspx?dingdanid=" + dingdanid + "&dingdanleixing=" + dingdanleixing + "&token=" + token;
        //        }
        //    }

        //    if (string.IsNullOrEmpty(url)) Utils.RCWE("异常请求");

        //    Response.Redirect(url);
        //    Response.Clear();
        //    Response.End();
        //}
        #endregion
    }

    public class MZaiXianZhiFuFangShiInfo
    {
        public string id { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string bankid { get; set; }
        /// <summary>
        /// 0:快钱银行直连 1:第三方支付
        /// </summary>
        public string fs { get; set; }
        public string logo { get; set; }
        public string name { get; set; }

        public IList<MZaiXianZhiFuFangShiInfo> GetZaiXianZhiFuFangShis()
        {
            var items = new List<MZaiXianZhiFuFangShiInfo>();

            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "D7BBEE89-DC89-4A11-B748-9A3A4EE0AEF0", name = "招商银行", bankid = "CMB", fs = "0", logo = "/images/banklogo/bank_cmb.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "A5783365-2E06-433E-A738-C62E26F106B3", name = "中国工商银行", bankid = "ICBC", fs = "0", logo = "/images/banklogo/bank_ICBC.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "F8A537BA-0B3A-4BE1-B84F-5C0291A00906", name = "中国农业银行", bankid = "ABC", fs = "0", logo = "/images/banklogo/bank_ABC.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "71D956E4-E6C9-4EA8-925A-37C0B729104B", name = "中国建设银行", bankid = "CCB", fs = "0", logo = "/images/banklogo/bank_CCB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "3B63568B-9602-4E21-95A7-55FF00FC81CA", name = "中国银行", bankid = "BOC", fs = "0", logo = "/images/banklogo/bank_BOC.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "C82058F1-48A9-49F8-B764-6065350B18C8", name = "浦发银行", bankid = "SPDB", fs = "0", logo = "/images/banklogo/bank_SPDB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "54192644-AB4D-4245-BCE4-0E150B9E25ED", name = "中国交通银行", bankid = "BCOM", fs = "0", logo = "/images/banklogo/bank_BCOM.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "56E75259-AA18-4ADE-AD4F-C122CBF57108", name = "中国民生银行", bankid = "CMBC", fs = "0", logo = "/images/banklogo/bank_CMBC.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "E298A97F-D88C-42D5-8C11-7C62BCCC8DCE", name = "深圳发展银行", bankid = "SDB", fs = "0", logo = "/images/banklogo/bank_SDB.gif" });
            //items.Add(new MZaiXianZhiFuFangShiInfo() { id = "131D8466-AED1-47D0-BB67-7EDAED4AF1A1", name = "广东发展银行", bankid = "GDB", fs = "0", logo = "/images/banklogo/bank_GDB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "1B691AAB-159A-4AC7-AC2B-01DCD39D2825", name = "中信银行", bankid = "CITIC", fs = "0", logo = "/images/banklogo/bank_CITIC.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "DD8E7500-E2D6-43DF-A05E-D2A3E570689E", name = "华夏银行", bankid = "HXB", fs = "0", logo = "/images/banklogo/bank_HXB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "90057B16-9DD0-4BB9-A75C-BFB4CB0219CB", name = "兴业银行", bankid = "CIB", fs = "0", logo = "/images/banklogo/bank_CIB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "135E7678-5A8C-4C9B-A54C-D5E77EA8D901", name = "广州银行", bankid = "GZCB", fs = "0", logo = "/images/banklogo/bank_GZCB.gif" });
            //items.Add(new MZaiXianZhiFuFangShiInfo() { id = "971FC4D2-C231-459F-9C9C-E3741804C3F2", name = "银联在线支付", bankid = "UPOP", fs = "0", logo = "/images/banklogo/bank_UPOP.gif" });
            //items.Add(new MZaiXianZhiFuFangShiInfo() { id = "A4399B51-74FE-47CB-8937-A706FF5F768E", name = "江苏银行", bankid = "JSB", fs = "0", logo = "/images/banklogo/bank_JSB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "0ED0A421-2B46-43F5-9014-BA9C174B0EA8", name = "上海农村商业银行", bankid = "SRCB", fs = "0", logo = "/images/banklogo/bank_shrcc.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "7DFA5327-8F71-4CDB-9BF7-3C26CF26D87A", name = "北京银行", bankid = "BOB", fs = "0", logo = "/images/banklogo/bank_BOB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "F501184A-9908-4D75-92F8-0D3D41503566", name = "渤海银行", bankid = "CBHB", fs = "0", logo = "/images/banklogo/bank_CBHB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "08AF770A-53BF-479B-8BB4-80F39F9460BF", name = "北京农商银行", bankid = "BJRCB", fs = "0", logo = "/images/banklogo/bank_BJRCB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "4A63042F-E1E8-4289-B91D-6BA138371F38", name = "南京银行", bankid = "NJCB", fs = "0", logo = "/images/banklogo/bank_NJCB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "6286A50E-D00B-49B7-BD05-EA22DFEE3CF6", name = "中国光大银行", bankid = "CEB", fs = "0", logo = "/images/banklogo/bank_CEB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "EB5983D6-8CF2-42B5-83DD-14707C6051FA", name = "东亚银行", bankid = "BEA", fs = "0", logo = "/images/banklogo/bank_BEA.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "24D3CBCE-EA74-4A55-83C8-9577D714B25D", name = "宁波银行", bankid = "NBCB", fs = "0", logo = "/images/banklogo/bank_NBCB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "3CAD5FD2-522B-4734-B338-7F646DCD3338", name = "杭州银行", bankid = "HZB", fs = "0", logo = "/images/banklogo/bank_HZB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "4C77F031-5E85-4135-B4D3-0B3674AAC4C5", name = "平安银行", bankid = "PAB", fs = "0", logo = "/images/banklogo/bank_PAB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "864CD42D-BDCC-49F8-B0C4-057E3AEAC254", name = "徽商银行", bankid = "HSB", fs = "0", logo = "/images/banklogo/bank_HSB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "777EDE9A-E1D0-4D9A-B671-133A299265FE", name = "浙商银行", bankid = "CZB", fs = "0", logo = "/images/banklogo/bank_CZB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "D098A3A4-6BCA-4A70-99A3-9CF70A49B8DB", name = "上海银行", bankid = "SHB", fs = "0", logo = "/images/banklogo/bank_SHB.gif" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "B1566531-62A5-463F-AF9B-AC013BA3D85B", name = "中国邮政储蓄银行", bankid = "PSBC", fs = "0", logo = "/images/banklogo/bank_post.gif" });
            //items.Add(new MZaiXianZhiFuFangShiInfo() { id = "48F6DEB5-7F31-4459-99BD-053A8485B420", name = "大连银行", bankid = "DLB", fs = "0", logo = "/images/banklogo/bank_DLB.gif" });

            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "106EE319-D297-48E9-80E8-A7529F7B89A0", name = "支付宝支付", bankid = "ALIPAY", fs = "1", logo = "/images/banklogo/bank_alipay.jpg" });
            items.Add(new MZaiXianZhiFuFangShiInfo() { id = "1F4A89E4-5622-4E6E-B0C9-D3E06597C947", name = "快钱支付", bankid = "99BILL", fs = "1", logo = "/images/banklogo/bank_99bill.jpg" });

            return items;
        }

        public MZaiXianZhiFuFangShiInfo GetZaiXianZhiFuFangShiInfo(string id)
        {
            var items = GetZaiXianZhiFuFangShis();

            foreach (var item in items)
            {
                if (item.id == id) return item;
            }

            return null;
        }
    }


}
