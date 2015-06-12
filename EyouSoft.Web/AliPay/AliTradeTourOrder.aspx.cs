/*using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using EyouSoft.Common;

namespace WEB.AliPay
{
    /// <summary>
    /// 支付宝支付的页面
    /// </summary>
    public partial class AliTradeTourOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tmpOrderId = Request.QueryString["OrderId"];  //若为多个订单ID,则以逗号分隔            
            var orderType = (EyouSoft.Model.OrderType)Utils.GetInt(Utils.GetQueryStringValue("OrderType"));   //订单类型
            string Pay = "alipay";

            string[] arrstrOrderId = tmpOrderId.Split(',');

            decimal totalfee = 0.0m;
            string subject = "";  //标题
            string body = ""; //描述
            var orderList = new List<string>();

            string strErr;

            switch (orderType)
            {
                case EyouSoft.Model.OrderType.Tour://线路订单
                    strErr = this.GetXianLuDingDan(arrstrOrderId, ref subject, ref body, ref totalfee, orderList);
                    break;
                case EyouSoft.Model.OrderType.Spot://景区订单
                    strErr = this.GetJingQuDingDan(arrstrOrderId, ref subject, ref body, ref totalfee, orderList);
                    break;
                case EyouSoft.Model.OrderType.Hotel://酒店订单
                    strErr = this.GetJiuDianDingDan(arrstrOrderId, ref subject, ref body, ref totalfee, orderList);
                    break;
                case EyouSoft.Model.OrderType.QianZheng://签证订单
                    strErr = this.GetQianZhengDingDan(arrstrOrderId, ref subject, ref body, ref totalfee, orderList);
                    break;
                case EyouSoft.Model.OrderType.JiPiao:
                    strErr = GetJiPiaoDingDan(arrstrOrderId, ref subject, ref body, ref totalfee, orderList);
                    break;
                default:
                    strErr = "订单类型错误！";
                    break;
            }

            if (!string.IsNullOrEmpty(strErr))
            {
                Response.Write(strErr);
                Response.End();
            }
            if (totalfee <= 0)
            {
                Response.Write("支付金额必须大于0才能支付！");
                Response.End();
            }
            if (arrstrOrderId.Length > 1)  //数量大于1时，已省略号显示
            {
                subject += "......";
                body += "......";
            }

            //开始支付
            string url = "";
            switch (Pay)
            {
                case "alipay":
                    url = this.InitAliPay(orderList, subject, body, totalfee, (int)orderType);
                    break;
            }
            if (!string.IsNullOrEmpty(url))
                Response.Redirect(url);
        }

        /// <summary>
        /// 构造酒店订单支付信息
        /// </summary>
        /// <param name="arrstrOrderId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        private string GetJiuDianDingDan(string[] arrstrOrderId, ref string subject, ref string body, ref decimal totalfee
            , List<string> orderList)
        {
            if (arrstrOrderId == null || arrstrOrderId.Length <= 0) return "要支付的订单不存在！";

            if (orderList == null) orderList = new List<string>();

            foreach (string strId in arrstrOrderId)
            {
                if (string.IsNullOrEmpty(strId)) continue;

                var info = new EyouSoft.BLL.HotelStructure.BHotelOrder().GetModel(strId);

                if (info == null) continue;

                if (info.PaymentState != EyouSoft.Model.Enum.PaymentState.未支付) continue;

                if (string.IsNullOrEmpty(subject))
                {
                    subject = "酒店名称：" + info.HotelName + " " + info.RoomName;
                    body = "酒店名称：" + info.HotelName + " " + info.RoomName + "，总金额：" + info.TotalAmount + " 元";
                }

                totalfee += info.TotalAmount;

                orderList.Add(strId);  //订单ID
            }

            return string.Empty;
        }

        /// <summary>
        /// 构造景区订单支付信息
        /// </summary>
        /// <param name="arrstrOrderId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        private string GetJingQuDingDan(string[] arrstrOrderId, ref string subject, ref string body, ref decimal totalfee
            , List<string> orderList)
        {
            if (arrstrOrderId == null || arrstrOrderId.Length <= 0) return "要支付的订单不存在！";

            if (orderList == null) orderList = new List<string>();

            foreach (string strId in arrstrOrderId)
            {
                if (string.IsNullOrEmpty(strId)) continue;

                var info = new EyouSoft.BLL.ScenicStructure.BScenicArea().GetScenicAreaOrderModel(strId);

                if (info == null) continue;

                if (info.FuKuanStatus != EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款) continue;

                if (string.IsNullOrEmpty(subject))
                {
                    subject = "景区名称：" + info.ScenicName + " " + info.TypeName;
                    body = "景区名称：" + info.ScenicName + " " + info.TypeName + "，总金额：" + info.Price + " 元";
                }

                totalfee += info.Price;

                orderList.Add(strId);  //订单ID
            }

            return string.Empty;
        }

        /// <summary>
        /// 构造线路订单支付信息
        /// </summary>
        /// <param name="arrstrOrderId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        private string GetXianLuDingDan(string[] arrstrOrderId, ref string subject, ref string body, ref decimal totalfee
            , List<string> orderList)
        {
            if (arrstrOrderId == null || arrstrOrderId.Length <= 0) return "要支付的订单不存在！";

            if (orderList == null) orderList = new List<string>();

            foreach (string strId in arrstrOrderId)
            {
                if (string.IsNullOrEmpty(strId)) continue;

                EyouSoft.Model.XianLuStructure.MOrderInfo info = new EyouSoft.BLL.XianLuStructure.BOrder().GetInfo(strId);

                if (info == null) continue;

                if (info.FuKuanStatus != EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款) continue;

                if (string.IsNullOrEmpty(subject))
                {
                    subject = "线路名称：" + info.XianLuName;
                    body = "线路名称：" + info.XianLuName + "，总金额：" + info.JinE + " 元";
                }

                totalfee += info.JinE;

                orderList.Add(strId);  //订单ID
            }

            return string.Empty;
        }

        /// <summary>
        /// 构造签证订单支付信息
        /// </summary>
        /// <param name="arrstrOrderId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        private string GetQianZhengDingDan(string[] arrstrOrderId, ref string subject, ref string body, ref decimal totalfee
            , List<string> orderList)
        {
            if (arrstrOrderId == null || arrstrOrderId.Length <= 0) return "要支付的订单不存在！";

            if (orderList == null) orderList = new List<string>();

            foreach (string strId in arrstrOrderId)
            {
                if (string.IsNullOrEmpty(strId)) continue;

                var info = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().GetInfo(strId);

                if (info == null) continue;

                var guoJiaInfo = new EyouSoft.BLL.QianZhengStructure.BQianZhengGuoJia().GetInfo(info.QianZhengGuoJiaId);
                if (guoJiaInfo == null) continue;

                if (info.FuKuanStatus != EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款) continue;

                if (string.IsNullOrEmpty(subject))
                {
                    subject = "签证名称：" + info.QianZhengName + "，国家：" + guoJiaInfo.Name1 + "，订单号：" + info.DingDanHao;
                    body = "签证名称：" + info.QianZhengName + "，国家：" + guoJiaInfo.Name1 + "，订单号：" + info.DingDanHao + "，总金额：" + info.JinE + " 元";
                }

                totalfee += info.JinE;

                orderList.Add(strId);  //订单ID
            }

            return string.Empty;
        }

        /// <summary>
        /// 构造机票订单支付信息
        /// </summary>
        /// <param name="arrstrOrderId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        private string GetJiPiaoDingDan(string[] arrstrOrderId, ref string subject, ref string body, ref decimal totalfee
            , List<string> orderList)
        {
            if (arrstrOrderId == null || arrstrOrderId.Length <= 0) return "要支付的订单不存在！";

            if (orderList == null) orderList = new List<string>();

            foreach (string strId in arrstrOrderId)
            {
                if (string.IsNullOrEmpty(strId)) continue;

                var info = new EyouSoft.BLL.JiPiaoStructure.BJiPiaoDingDan().GetInfo(strId);

                if (info == null) continue;

                var hangBanInfo = new EyouSoft.BLL.JiPiaoStructure.BJiPiaoDingDan().GetHangBanInfo(info.HangBanId);
                if (hangBanInfo == null) continue;
                var depcity = new EyouSoft.BLL.JiPiaoStructure.BJiPiaoSanZiMa().GetSanZiMaInfo(hangBanInfo.DepAirportCode);
                var arrcity = new EyouSoft.BLL.JiPiaoStructure.BJiPiaoSanZiMa().GetSanZiMaInfo(hangBanInfo.ArrAirportCode);
                if (depcity == null || arrcity == null) continue;

                if (info.FuKuanStatus != EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款) continue;

                if (string.IsNullOrEmpty(subject))
                {
                    subject = "" + depcity.CityName + "→" + arrcity.CityName + "，订单号：" + info.DingDanHao;
                    body = "" + depcity.CityName + "→" + arrcity.CityName + "，订单号：" + info.DingDanHao + "，总金额：" + info.JinE + " 元";
                }

                totalfee += info.JinE;

                orderList.Add(strId);  //订单ID
            }

            return string.Empty;
        }

        /// <summary>
        /// 初始化支付宝支付url
        /// </summary>
        /// <param name="orderList">订单idlist</param>
        /// <param name="Subject">标题</param>
        /// <param name="Body">描述</param>
        /// <param name="Totalfee">总金额</param>
        /// <param name="OrderType">订单类型</param>
        /// <returns></returns>
        private string InitAliPay(List<string> orderList, string Subject, string Body, decimal Totalfee, int OrderType)
        {
            PayAPI.Model.Ali.AliPayTrade trade = new PayAPI.Model.Ali.AliPayTrade();
            trade.OrderInfo.OrderID = orderList;
            trade.OrderInfo.Subject = Subject;
            trade.OrderInfo.Body = Body;
            trade.Totalfee = Totalfee;
            trade.IsRoyalty = false;
            trade.RoyaltyType = PayAPI.Model.Ali.RoyaltyType.平级分润;

            //PayAPI.Model.Ali.Royalty roy1 = new PayAPI.Model.Ali.Royalty();
            //roy1.Account = PayAPI.Ali.Core.AliPaySystem.Account;  //分润账号
            //if ((decimal)PayAPI.Ali.Core.AliPaySystem.ServiceFeePercent == 0)
            //    roy1.Price = trade.Totalfee * 0.005m;
            //else
            //    roy1.Price = trade.Totalfee * (decimal)PayAPI.Ali.Core.AliPaySystem.ServiceFeePercent;
            //roy1.Remark = "收取的手续费";
            //trade.RoyaltyList.Add(roy1);
            trade.SellerAccount = new EyouSoft.BLL.OtherStructure.BOnLinePay().GetAlipayAccount();   //卖家账号           
            trade.ShowUrl = "";  //展示页面
            PayAPI.Model.Attach attach = new PayAPI.Model.Attach();
            attach.Key = "OrderType";
            attach.Value = OrderType.ToString();
            trade.AttachList.Add(attach);
            //构造url
            return PayAPI.Ali.Alipay.Create.Create_url(trade);
        }
    }
}
*/