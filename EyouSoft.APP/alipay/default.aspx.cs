using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eyousoft_yhq.AlipayLibrary;
using System.Text;
using EyouSoft.Common;
using EyouSoft.Model.OtherStructure;

namespace Eyousoft_yhq.Web.Alipay
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 订单信息
            string dingDanId = Request.QueryString["orderid"];
            var dingDanLeiXiang = (DingDanType)Utils.GetEnumValueNull(typeof(DingDanType), Utils.GetQueryStringValue("type"));//订单类型
            if (string.IsNullOrEmpty(dingDanId)) Utils.RCWE("错误的请求");
            string token = Utils.GetQueryStringValue("token");
            if (string.IsNullOrEmpty(token)) Utils.RCWE("错误的请求");
            EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out huiYuanInfo);
            if (isLogin && huiYuanInfo.UserId != token) Utils.RCWE("错误的请求");
            decimal zhiFuJinE = 0.0m;
            string zhiFuBiaoTi = "";  //标题
            string zhiFuMiaoShu = ""; //描述
            string strErr = string.Empty;
            string cpName = "";
            string dingDanHao = string.Empty;

            switch (dingDanLeiXiang)
            {

                case DingDanType.长线订单:
                case DingDanType.短线订单:
                case DingDanType.出境订单:
                    strErr = GetXianLuDingDan(dingDanId, ref zhiFuBiaoTi, ref zhiFuMiaoShu, ref zhiFuJinE, ref cpName, ref dingDanHao);
                    break;
                case DingDanType.商城订单:
                    strErr = GetShangChengDingDan(dingDanId, ref zhiFuBiaoTi, ref zhiFuMiaoShu, ref zhiFuJinE, ref cpName, ref dingDanHao);
                    break;
                case DingDanType.门票订单:
                    strErr = GetMenPiaoDingDan(dingDanId, ref zhiFuBiaoTi, ref zhiFuMiaoShu, ref zhiFuJinE, ref cpName, ref dingDanHao);
                    break;
                case DingDanType.酒店订单:
                    strErr = GetJiuDianDingDan(dingDanId, ref zhiFuBiaoTi, ref zhiFuMiaoShu, ref zhiFuJinE, ref cpName, ref dingDanHao);
                    break;
                case DingDanType.租车订单:
                    strErr = GetZuCheDingDan(dingDanId, ref zhiFuBiaoTi, ref zhiFuMiaoShu, ref zhiFuJinE, ref cpName, ref dingDanHao);
                    break;
                case DingDanType.团购订单:
                    strErr = GetTuanGouDingDan(dingDanId, ref zhiFuBiaoTi, ref zhiFuMiaoShu, ref zhiFuJinE, ref cpName, ref dingDanHao);
                    break;
                case DingDanType.充值订单:
                    strErr = GetChongZhiDingDan(dingDanId, ref zhiFuBiaoTi, ref zhiFuMiaoShu, ref zhiFuJinE, ref cpName, ref dingDanHao);
                    break;

                case DingDanType.签证订单:
                    strErr = GetQianZhengDingDan(dingDanId, ref zhiFuBiaoTi, ref zhiFuMiaoShu, ref zhiFuJinE, ref cpName, ref dingDanHao);
                    break;
                case DingDanType.单团订单:
                    strErr = GetZiZuTuanDingDan(dingDanId, ref zhiFuBiaoTi, ref zhiFuMiaoShu, ref zhiFuJinE, ref cpName, ref dingDanHao);
                    break;
                case DingDanType.机票订单:
                    strErr = GetJIPiaoDingDan(dingDanId, ref zhiFuBiaoTi, ref zhiFuMiaoShu, ref zhiFuJinE, ref cpName, ref dingDanHao);
                    break;
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(strErr)) Utils.RCWE(strErr);

            if (zhiFuJinE <= 0) Utils.RCWE("支付金额必须大于0才能支付！");
            #endregion

            #region 手机支付宝 支付
            //支付宝网关地址
            string GATEWAY_NEW = "http://wappaygw.alipay.com/service/rest.htm?";

            ////////////////////////////////////////////调用授权接口alipay.wap.trade.create.direct获取授权码token////////////////////////////////////////////

            //返回格式
            string format = "xml";
            //必填，不需要修改

            //返回格式
            string v = "2.0";
            //必填，不需要修改

            //请求号
            string req_id = DateTime.Now.ToString("yyyyMMddHHmmss");
            //必填，须保证每次请求都是唯一

            //req_data详细信息

            //服务器异步通知页面路径
            string notify_url = "http://" + Request.Url.Host + AlipayLibrary.Config.GetConfigString("Alipay", "app_notify_url");// "http://www.xxx.com/Alipay/notify_url.aspx";
            //需http://格式的完整路径，不允许加?id=123这类自定义参数

            //页面跳转同步通知页面路径
            string call_back_url = "http://" + Request.Url.Host + AlipayLibrary.Config.GetConfigString("Alipay", "app_callback_url");// "http://127.0.0.1:64704/Alipay/call_back_url.aspx";
            //需http://格式的完整路径，不允许加?id=123这类自定义参数

            //操作中断返回地址
            string merchant_url = "http://" + Request.Url.Host + AlipayLibrary.Config.GetConfigString("Alipay", "app_return_url");
            //用户付款中途退出返回商户的地址。需http://格式的完整路径，不允许加?id=123这类自定义参数

            #region 订单信息|卖家帐号
            //卖家支付宝帐户
            string seller_email = AlipayLibrary.Config.GetConfigString("appSettings", "AlipayAccount");
            //必填

            //商户订单号
            string out_trade_no = dingDanHao;
            //商户网站订单系统中唯一订单号，必填

            //订单名称
            string subject = "产品名称：" + cpName;
            //必填

            //付款金额
            string total_fee = zhiFuJinE.ToString();
            //必填
            #endregion

            //请求业务参数详细
            string req_dataToken = "<direct_trade_create_req><notify_url>" + notify_url + "</notify_url><call_back_url>" + call_back_url + "</call_back_url><seller_account_name>" + seller_email + "</seller_account_name><out_trade_no>" + out_trade_no + "</out_trade_no><subject>" + subject + "</subject><total_fee>" + total_fee + "</total_fee><merchant_url>" + merchant_url + "</merchant_url><agent_id>" + (int)dingDanLeiXiang + "</agent_id></direct_trade_create_req>";
            //必填

            /*
             <direct_trade_create_req><subject>彩票</subject><out_trade_no>1282889603601</out_trade_no><total_fee>10.01</total_fee><seller_account_name>chenf003@yahoo.cn</seller_account_name><call_back_url>http://www.yoursite.com/waptest0504/servlet/CallBack</call_back_url><notify_url>http://www.yoursite.com/waptest0504/servlet/NotifyReceiver</notify_url><out_user>123456789</out_user><merchant_url>http://www.yoursite.com</merchant_url><pay_expire>3600</pay_expire><agent_id>11397568a1</agent_id></direct_trade_create_req>
             */

            //把请求参数打包成数组
            Dictionary<string, string> sParaTempToken = new Dictionary<string, string>();
            sParaTempToken.Add("partner", Config.Partner);
            sParaTempToken.Add("_input_charset", Config.Input_charset.ToLower());
            sParaTempToken.Add("sec_id", Config.Sign_type.ToUpper());
            sParaTempToken.Add("service", "alipay.wap.trade.create.direct");
            sParaTempToken.Add("format", format);
            sParaTempToken.Add("v", v);
            sParaTempToken.Add("req_id", req_id);
            sParaTempToken.Add("req_data", req_dataToken);

            //建立请求
            string sHtmlTextToken = Submit.BuildRequest(GATEWAY_NEW, sParaTempToken);
            //URLDECODE返回的信息
            Encoding code = Encoding.GetEncoding(Config.Input_charset);
            sHtmlTextToken = HttpUtility.UrlDecode(sHtmlTextToken, code);

            //解析远程模拟提交后返回的信息
            Dictionary<string, string> dicHtmlTextToken = Submit.ParseResponse(sHtmlTextToken);

            //获取token
            string request_token = dicHtmlTextToken["request_token"];

            ////////////////////////////////////////////根据授权码token调用交易接口alipay.wap.auth.authAndExecute////////////////////////////////////////////


            //业务详细
            string req_data = "<auth_and_execute_req><request_token>" + request_token + "</request_token></auth_and_execute_req>";
            //必填

            //把请求参数打包成数组
            Dictionary<string, string> sParaTemp = new Dictionary<string, string>();
            sParaTemp.Add("partner", Config.Partner);
            sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
            sParaTemp.Add("sec_id", Config.Sign_type.ToUpper());
            sParaTemp.Add("service", "alipay.wap.auth.authAndExecute");
            sParaTemp.Add("format", format);
            sParaTemp.Add("v", v);
            sParaTemp.Add("req_data", req_data);

            //建立请求
            string sHtmlText = Submit.BuildRequest(GATEWAY_NEW, sParaTemp, "get", "确认");
            Response.Write(sHtmlText);

            #endregion
        }
        /// <summary>
        /// 构造商城订单支付信息
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <returns></returns>
        private string GetShangChengDingDan(string dingDanId, ref string zhiFuBiaoTi, ref string zhiFuMiaoShu, ref decimal zhiFuJinE, ref string cpName, ref string dingDanHao)
        {

            var info = new EyouSoft.BLL.MallStructure.BShangChengDingDan().GetModel(dingDanId);
            string token = Utils.GetQueryStringValue("token");
            if (info == null) Utils.RCWE("错误的请求");

            if (info.ContactID != token) Utils.RCWE("错误的请求");

            EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out huiYuanInfo);

            if (isLogin)
            {
                if (info.ContactID != huiYuanInfo.UserId) Utils.RCWE("错误的请求");
            }

            if (info.PayState != EyouSoft.Model.Enum.PaymentState.未支付) Utils.RCWE("错误的请求");
            if (info.OrderState != EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款) Utils.RCWE("错误的请求");

            if (string.IsNullOrEmpty(zhiFuBiaoTi))
            {
                zhiFuBiaoTi = info.ProductName + "，订单号：" + info.OrderCode;
                zhiFuMiaoShu = "产品名称：" + info.ProductName + "，订单号：" + info.OrderCode + "，总金额：" + info.OrderPrice.ToString("F2") + " 元";
            }

            zhiFuJinE += info.OrderPrice;

            cpName = info.ProductName;
            dingDanHao = info.OrderCode;

            return string.Empty;
        }
        /// <summary>
        /// 构造线路订单支付信息
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <returns></returns>
        private string GetXianLuDingDan(string dingDanId, ref string zhiFuBiaoTi, ref string zhiFuMiaoShu, ref decimal zhiFuJinE, ref string cpName, ref string dingDanHao)
        {

            var info = new EyouSoft.BLL.XianLuStructure.BOrder().GetInfo(dingDanId);
            string token = Utils.GetQueryStringValue("token");
            if (info == null) Utils.RCWE("错误的请求");

            if (info.OperatorId != token) Utils.RCWE("错误的请求");

            EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out huiYuanInfo);

            if (isLogin)
            {
                if (info.OperatorId != huiYuanInfo.UserId) Utils.RCWE("错误的请求");
            }

            if (info.FuKuanStatus != EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款) Utils.RCWE("错误的请求");
            if (info.Status != EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款) Utils.RCWE("错误的请求");

            if (string.IsNullOrEmpty(zhiFuBiaoTi))
            {
                zhiFuBiaoTi = info.XianLuName + "，订单号：" + info.OrderCode;
                zhiFuMiaoShu = "产品名称：" + info.XianLuName + "，订单号：" + info.OrderCode + "，总金额：" + info.JinE.ToString("F2") + " 元";
            }

            zhiFuJinE += info.JinE;

            cpName = info.XianLuName;
            dingDanHao = info.OrderCode;

            return string.Empty;
        }
        /// <summary>
        /// 构造酒店订单支付信息
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <returns></returns>
        private string GetJiuDianDingDan(string dingDanId, ref string zhiFuBiaoTi, ref string zhiFuMiaoShu, ref decimal zhiFuJinE, ref string cpName, ref string dingDanHao)
        {

            var info = new EyouSoft.BLL.HotelStructure.BHotelOrder().GetModel(dingDanId);
            string token = Utils.GetQueryStringValue("token");
            if (info == null) Utils.RCWE("错误的请求");

            if (info.OperatorId != token) Utils.RCWE("错误的请求");

            EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out huiYuanInfo);

            if (isLogin)
            {
                if (info.OperatorId != huiYuanInfo.UserId) Utils.RCWE("错误的请求");
            }

            if (info.PaymentState != EyouSoft.Model.Enum.PaymentState.未支付) Utils.RCWE("错误的请求");
            if (info.OrderState != EyouSoft.Model.Enum.OrderState.待付款) Utils.RCWE("错误的请求");

            if (string.IsNullOrEmpty(zhiFuBiaoTi))
            {
                zhiFuBiaoTi = info.HotelName + "，订单号：" + info.OrderCode;
                zhiFuMiaoShu = "产品名称：" + info.HotelName + "，订单号：" + info.OrderCode + "，总金额：" + info.TotalAmount.ToString("F2") + " 元";
            }

            zhiFuJinE += info.TotalAmount;

            cpName = info.HotelName;
            dingDanHao = info.OrderCode;

            return string.Empty;
        }
        /// <summary>
        /// 构造门票订单支付信息
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <returns></returns>
        private string GetMenPiaoDingDan(string dingDanId, ref string zhiFuBiaoTi, ref string zhiFuMiaoShu, ref decimal zhiFuJinE, ref string cpName, ref string dingDanHao)
        {

            var info = new EyouSoft.BLL.ScenicStructure.BScenicArea().GetScenicAreaOrderModel(dingDanId);
            string token = Utils.GetQueryStringValue("token");
            if (info == null) Utils.RCWE("错误的请求");

            if (info.OperatorId != token) Utils.RCWE("错误的请求");

            EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out huiYuanInfo);

            if (isLogin)
            {
                if (info.OperatorId != huiYuanInfo.UserId) Utils.RCWE("错误的请求");
            }

            if (info.FuKuanStatus != EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款) Utils.RCWE("错误的请求");
            if (info.Status != EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款) Utils.RCWE("错误的请求");

            if (string.IsNullOrEmpty(zhiFuBiaoTi))
            {
                zhiFuBiaoTi = info.ScenicName + "，订单号：" + info.OrderCode;
                zhiFuMiaoShu = "产品名称：" + info.ScenicName + "，订单号：" + info.OrderCode + "，总金额：" + info.Price.ToString("F2") + " 元";
            }

            zhiFuJinE += info.Price;

            cpName = info.ScenicName;
            dingDanHao = info.OrderCode;

            return string.Empty;
        }
        /// <summary>
        /// 构造租车订单支付信息
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <returns></returns>
        private string GetZuCheDingDan(string dingDanId, ref string zhiFuBiaoTi, ref string zhiFuMiaoShu, ref decimal zhiFuJinE, ref string cpName, ref string dingDanHao)
        {

            var info = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().GetModel(dingDanId);
            string token = Utils.GetQueryStringValue("token");
            if (info == null) Utils.RCWE("错误的请求");

            if (info.OperatorId != token) Utils.RCWE("错误的请求");

            EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out huiYuanInfo);

            if (isLogin)
            {
                if (info.OperatorId != huiYuanInfo.UserId) Utils.RCWE("错误的请求");
            }

            if (info.FuKuanStatus != EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款) Utils.RCWE("错误的请求");
            if (info.Status != EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款) Utils.RCWE("错误的请求");

            if (string.IsNullOrEmpty(zhiFuBiaoTi))
            {
                zhiFuBiaoTi = info.CarName + "，订单号：" + info.OrderCode;
                zhiFuMiaoShu = "产品名称：" + info.CarName + "，订单号：" + info.OrderCode + "，总金额：" + info.ZuJin.Value.ToString("F2") + " 元";
            }

            zhiFuJinE += info.ZuJin.Value;

            cpName = info.CarName;
            dingDanHao = info.OrderCode;

            return string.Empty;
        }
        /// <summary>
        /// 构造团购订单支付信息
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <returns></returns>
        private string GetTuanGouDingDan(string dingDanId, ref string zhiFuBiaoTi, ref string zhiFuMiaoShu, ref decimal zhiFuJinE, ref string cpName, ref string dingDanHao)
        {

            var info = new EyouSoft.BLL.OtherStructure.BTuanGouDingDan().GetModel(int.Parse(dingDanId));
            string token = Utils.GetQueryStringValue("token");
            if (info == null) Utils.RCWE("错误的请求");

            if (info.PeopleID != token) Utils.RCWE("错误的请求");

            EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out huiYuanInfo);

            if (isLogin)
            {
                if (info.PeopleID != huiYuanInfo.UserId) Utils.RCWE("错误的请求");
            }

            if (info.PayState != EyouSoft.Model.Enum.PaymentState.未支付) Utils.RCWE("错误的请求");
            if (info.OrderState != EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款) Utils.RCWE("错误的请求");

            if (string.IsNullOrEmpty(zhiFuBiaoTi))
            {
                zhiFuBiaoTi = info.ProductName + "，订单号：" + info.OrderCode;
                zhiFuMiaoShu = "产品名称：" + info.ProductName + "，订单号：" + info.OrderCode + "，总金额：" + info.OrderPrice.ToString("F2") + " 元";
            }

            zhiFuJinE += info.OrderPrice;

            cpName = info.ProductName;
            dingDanHao = info.OrderCode;

            return string.Empty;
        }
        /// <summary>
        /// 构造充值订单支付信息
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <returns></returns>
        private string GetChongZhiDingDan(string dingDanId, ref string zhiFuBiaoTi, ref string zhiFuMiaoShu, ref decimal zhiFuJinE, ref string cpName, ref string dingDanHao)
        {

            var info = new EyouSoft.BLL.OtherStructure.BChongZhi().GetInfo(dingDanId);
            string token = Utils.GetQueryStringValue("token");
            if (info == null) Utils.RCWE("错误的请求");

            if (info.HuiYuanId != token) Utils.RCWE("错误的请求");

            EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out huiYuanInfo);

            if (isLogin)
            {
                if (info.HuiYuanId != huiYuanInfo.UserId) Utils.RCWE("错误的请求");
            }


            if (string.IsNullOrEmpty(zhiFuBiaoTi))
            {
                zhiFuBiaoTi = "E额宝充值";
                zhiFuMiaoShu = "充值账户：" + huiYuanInfo.Username + "，订单号：" + info.JiaoYiHao + "，总金额：" + info.JinE.ToString("F2") + " 元";
            }

            zhiFuJinE += info.JinE;

            cpName = "账户充值";
            dingDanHao = info.JiaoYiHao;

            return string.Empty;
        }
        /// <summary>
        /// 构造签证订单支付信息
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <returns></returns>
        private string GetQianZhengDingDan(string dingDanId, ref string zhiFuBiaoTi, ref string zhiFuMiaoShu, ref decimal zhiFuJinE, ref string cpName, ref string dingDanHao)
        {

            var info = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().GetInfo(dingDanId);
            string token = Utils.GetQueryStringValue("token");
            if (info == null) Utils.RCWE("错误的请求");

            if (info.XiaDanRenId != token) Utils.RCWE("错误的请求");

            EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out huiYuanInfo);

            if (isLogin)
            {
                if (info.XiaDanRenId != huiYuanInfo.UserId) Utils.RCWE("错误的请求");
            }

            if (info.FuKuanStatus != EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款) Utils.RCWE("错误的请求");
            if (info.DingDanStatus != EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款) Utils.RCWE("错误的请求");

            if (string.IsNullOrEmpty(zhiFuBiaoTi))
            {
                zhiFuBiaoTi = info.QianZhengName + "，订单号：" + info.DingDanHao;
                zhiFuMiaoShu = "产品名称：" + info.QianZhengName + "，订单号：" + info.DingDanHao + "，总金额：" + info.JinE.ToString("F2") + " 元";
            }

            zhiFuJinE += info.JinE;

            cpName = info.QianZhengName;
            dingDanHao = info.DingDanHao;

            return string.Empty;
        }
        /// <summary>
        /// 构造单团订单支付信息
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <returns></returns>
        private string GetZiZuTuanDingDan(string dingDanId, ref string zhiFuBiaoTi, ref string zhiFuMiaoShu, ref decimal zhiFuJinE, ref string cpName, ref string dingDanHao)
        {

            var info = new EyouSoft.BLL.XianLuStructure.BZiZuTuan().GetInfo(dingDanId);
            string token = Utils.GetQueryStringValue("token");
            if (info == null) Utils.RCWE("错误的请求");

            if (info.XDRId != token) Utils.RCWE("错误的请求");

            EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out huiYuanInfo);

            if (isLogin)
            {
                if (info.XDRId != huiYuanInfo.UserId) Utils.RCWE("错误的请求");
            }

            if (info.OrderState != EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款) Utils.RCWE("错误的请求");

            if (string.IsNullOrEmpty(zhiFuBiaoTi))
            {
                zhiFuBiaoTi = info.XianLuName + "，订单号：" + info.OrderCode;
                zhiFuMiaoShu = "产品名称：" + info.XianLuName + "，订单号：" + info.OrderCode + "，总金额：" + info.ZongJinE.Value.ToString("F2") + " 元";
            }

            zhiFuJinE += info.ZongJinE.Value;

            cpName = info.XianLuName;
            dingDanHao = info.OrderCode;

            return string.Empty;
        }
        /// <summary>
        /// 构造单团订单支付信息
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <returns></returns>
        private string GetJIPiaoDingDan(string dingDanId, ref string zhiFuBiaoTi, ref string zhiFuMiaoShu, ref decimal zhiFuJinE, ref string cpName, ref string dingDanHao)
        {

            var info = new EyouSoft.BLL.JPStructure.BDingDan().GetInfo(dingDanId);
            string token = Utils.GetQueryStringValue("token");
            if (info == null) Utils.RCWE("错误的请求");

            if (info.HuiYuanId != token) Utils.RCWE("错误的请求");

            EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out huiYuanInfo);

            if (isLogin)
            {
                if (info.HuiYuanId != huiYuanInfo.UserId) Utils.RCWE("错误的请求");
            }

            if (info.DingDanStatus != EyouSoft.Model.JPStructure.DingDanStatus.等待支付) Utils.RCWE("错误的请求");

            if (string.IsNullOrEmpty(zhiFuBiaoTi))
            {
                zhiFuBiaoTi = info.ChuFaChengShiSanZiMa + "-" + info.DaoDaChengShiSanZiMa + "，订单号：" + info.JiaoYiHao;
                zhiFuMiaoShu = "产品名称：" + info.ChuFaChengShiSanZiMa + "-" + info.DaoDaChengShiSanZiMa + "，订单号：" + info.JiaoYiHao + "，总金额：" + info.JinE.ToString("F2") + " 元";
            }

            zhiFuJinE += info.JinE;

            cpName = info.ChuFaChengShiSanZiMa + "-" + info.DaoDaChengShiSanZiMa;
            dingDanHao = info.JiaoYiHao;

            return string.Empty;
        }


    }
}
