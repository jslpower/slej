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
using EyouSoft.BLL.ScenicStructure;
using EyouSoft.BLL.XianLuStructure;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.BLL.ZuCheStructure;
using EyouSoft.BLL.MallStructure;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.BLL.QianZhengStructure;

namespace EyouSoft.WAP.tenPay
{
    public partial class czSend : HuiYuanWapPageBase
    {
        protected TenPayTrade TenPayTradeModel = new TenPayTrade();
        protected PrePay _TenPayTradeModel = new PrePay();
        protected string weixin_jsapi_config = string.Empty;
        protected int DDLX = 0;
        protected EyouSoft.Common.Utils.weixin_oauth2_access_token_info wxModel = new Utils.weixin_oauth2_access_token_info();
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
            wxModel.openid = Utils.GetQueryStringValue("openid");

            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "1")
            {
                var order = GetXuLuModel();
                if (Request.UserAgent.ToLower().Contains("micromessenger"))
                {
                    #region 初始化支付信息
                    Tenpay pay = new Tenpay();
                    TenPayTradeModel.OPENID = wxModel.openid;
                    TenPayTradeModel.Totalfee = order.JinE;
                    TenPayTradeModel.UserIP = Utils.GetRemoteIP();
                    TenPayTradeModel.OutTradeNo = order.OrderCode;
                    TenPayTradeModel.OrderInfo.Body = "支付金额:" + order.JinE.ToString("F2") + "元";

                    _TenPayTradeModel = pay.Create_url(TenPayTradeModel);
                    if (!_TenPayTradeModel.IsSuccess)
                        plaIsWxBow.Visible = false;
                    #endregion
                }
                DDLX = (int)EyouSoft.Model.OtherStructure.DingDanType.长线订单;
            }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "8")
            {
                var order = GetXuLuModel();
                if (Request.UserAgent.ToLower().Contains("micromessenger"))
                {
                    #region 初始化支付信息
                    Tenpay pay = new Tenpay();
                    TenPayTradeModel.OPENID = wxModel.openid;
                    TenPayTradeModel.Totalfee = order.JinE;
                    TenPayTradeModel.UserIP = Utils.GetRemoteIP();
                    TenPayTradeModel.OutTradeNo = order.OrderCode;
                    TenPayTradeModel.OrderInfo.Body = "支付金额:" + order.JinE.ToString("F2") + "元";

                    _TenPayTradeModel = pay.Create_url(TenPayTradeModel);

                    if (!_TenPayTradeModel.IsSuccess)
                        plaIsWxBow.Visible = false;
                    #endregion
                }
                DDLX = (int)EyouSoft.Model.OtherStructure.DingDanType.出境订单;
            }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "9")
            {
                var order = GetXuLuModel();
                if (Request.UserAgent.ToLower().Contains("micromessenger"))
                {
                    #region 初始化支付信息
                    Tenpay pay = new Tenpay();
                    TenPayTradeModel.OPENID = wxModel.openid;
                    TenPayTradeModel.Totalfee = order.JinE;
                    TenPayTradeModel.UserIP = Utils.GetRemoteIP();
                    TenPayTradeModel.OutTradeNo = order.OrderCode;
                    TenPayTradeModel.OrderInfo.Body = "支付金额:" + order.JinE.ToString("F2") + "元";

                    _TenPayTradeModel = pay.Create_url(TenPayTradeModel);

                    if (!_TenPayTradeModel.IsSuccess)
                        plaIsWxBow.Visible = false;
                    #endregion
                }
                DDLX = (int)EyouSoft.Model.OtherStructure.DingDanType.短线订单;
            }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "2")
            {
                var order = GetHotelModel();
                if (Request.UserAgent.ToLower().Contains("micromessenger"))
                {
                    #region 初始化支付信息
                    Tenpay pay = new Tenpay();
                    TenPayTradeModel.OPENID = wxModel.openid;
                    TenPayTradeModel.Totalfee = order.TotalAmount;
                    TenPayTradeModel.UserIP = Utils.GetRemoteIP();
                    TenPayTradeModel.OutTradeNo = order.OrderCode;
                    TenPayTradeModel.OrderInfo.Body = "支付金额:" + order.TotalAmount.ToString("F2") + "元";

                    _TenPayTradeModel = pay.Create_url(TenPayTradeModel);

                    if (!_TenPayTradeModel.IsSuccess)
                        plaIsWxBow.Visible = false;
                    #endregion
                }
                DDLX = (int)EyouSoft.Model.OtherStructure.DingDanType.酒店订单;
            }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "3")
            {
                var order = GetJingquModel();
                if (Request.UserAgent.ToLower().Contains("micromessenger"))
                {
                    #region 初始化支付信息
                    Tenpay pay = new Tenpay();
                    TenPayTradeModel.OPENID = wxModel.openid;
                    TenPayTradeModel.Totalfee = order.Price;
                    TenPayTradeModel.UserIP = Utils.GetRemoteIP();
                    TenPayTradeModel.OutTradeNo = order.OrderCode;
                    TenPayTradeModel.OrderInfo.Body = "支付金额:" + order.Price.ToString("F2") + "元";

                    _TenPayTradeModel = pay.Create_url(TenPayTradeModel);

                    if (!_TenPayTradeModel.IsSuccess)
                        plaIsWxBow.Visible = false;
                    #endregion
                }
                DDLX = (int)EyouSoft.Model.OtherStructure.DingDanType.门票订单;
            }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "4")
            {
                var order = GetZucheModel();
                if (Request.UserAgent.ToLower().Contains("micromessenger"))
                {
                    #region 初始化支付信息
                    Tenpay pay = new Tenpay();
                    TenPayTradeModel.OPENID = wxModel.openid;
                    TenPayTradeModel.Totalfee = order.ZuJin.Value;
                    TenPayTradeModel.UserIP = Utils.GetRemoteIP();
                    TenPayTradeModel.OutTradeNo = order.OrderCode;
                    TenPayTradeModel.OrderInfo.Body = "支付金额:" + order.ZuJin.Value.ToString("F2") + "元";

                    _TenPayTradeModel = pay.Create_url(TenPayTradeModel);

                    if (!_TenPayTradeModel.IsSuccess)
                        plaIsWxBow.Visible = false;
                    #endregion
                }
                DDLX = (int)EyouSoft.Model.OtherStructure.DingDanType.租车订单;
            }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "5")
            {
                var order = GetShangChengModel();
                if (Request.UserAgent.ToLower().Contains("micromessenger"))
                {
                    #region 初始化支付信息
                    Tenpay pay = new Tenpay();
                    TenPayTradeModel.OPENID = wxModel.openid;
                    TenPayTradeModel.Totalfee = order.OrderPrice;
                    TenPayTradeModel.UserIP = Utils.GetRemoteIP();
                    TenPayTradeModel.OutTradeNo = order.OrderCode;
                    TenPayTradeModel.OrderInfo.Body = "支付金额:" + order.OrderPrice.ToString("F2") + "元";

                    _TenPayTradeModel = pay.Create_url(TenPayTradeModel);

                    if (!_TenPayTradeModel.IsSuccess)
                        plaIsWxBow.Visible = false;
                    #endregion
                }
                DDLX = (int)EyouSoft.Model.OtherStructure.DingDanType.商城订单;
            }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "6")
            {
                var order = GetTuanGouModel();
                if (Request.UserAgent.ToLower().Contains("micromessenger"))
                {
                    #region 初始化支付信息
                    Tenpay pay = new Tenpay();
                    TenPayTradeModel.OPENID = wxModel.openid;
                    TenPayTradeModel.Totalfee = order.OrderPrice;
                    TenPayTradeModel.UserIP = Utils.GetRemoteIP();
                    TenPayTradeModel.OutTradeNo = order.OrderCode;
                    TenPayTradeModel.OrderInfo.Body = "支付金额:" + order.OrderPrice.ToString("F2") + "元";

                    _TenPayTradeModel = pay.Create_url(TenPayTradeModel);

                    if (!_TenPayTradeModel.IsSuccess)
                        plaIsWxBow.Visible = false;
                    #endregion
                }
                DDLX = (int)EyouSoft.Model.OtherStructure.DingDanType.团购订单;
            }
            //if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "7") { GetQianZhengModel();DDLX= EyouSoft.Model.OtherStructure.DingDanType.签证订单 }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "10")
            {
                var order = GetZuTuanModel();
                if (Request.UserAgent.ToLower().Contains("micromessenger"))
                {
                    #region 初始化支付信息
                    Tenpay pay = new Tenpay();
                    TenPayTradeModel.OPENID = wxModel.openid;
                    TenPayTradeModel.Totalfee = order.ZongJinE.Value;
                    TenPayTradeModel.UserIP = Utils.GetRemoteIP();
                    TenPayTradeModel.OutTradeNo = order.OrderCode;
                    TenPayTradeModel.OrderInfo.Body = "支付金额:" + order.ZongJinE.Value.ToString("F2") + "元";

                    _TenPayTradeModel = pay.Create_url(TenPayTradeModel);

                    if (!_TenPayTradeModel.IsSuccess)
                        plaIsWxBow.Visible = false;
                    #endregion
                }
                DDLX = (int)EyouSoft.Model.OtherStructure.DingDanType.单团订单;
            }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "11")
            {
                var order = GeJiPiaoModel();
                if (Request.UserAgent.ToLower().Contains("micromessenger"))
                {
                    #region 初始化支付信息
                    Tenpay pay = new Tenpay();
                    TenPayTradeModel.OPENID = wxModel.openid;
                    TenPayTradeModel.Totalfee = order.JinE;
                    TenPayTradeModel.UserIP = Utils.GetRemoteIP();
                    TenPayTradeModel.OutTradeNo = order.DingDanId;
                    TenPayTradeModel.OrderInfo.Body = "支付金额:" + order.JinE.ToString("F2") + "元";

                    _TenPayTradeModel = pay.Create_url(TenPayTradeModel);

                    if (!_TenPayTradeModel.IsSuccess)
                        plaIsWxBow.Visible = false;
                    #endregion
                }
                DDLX = (int)EyouSoft.Model.OtherStructure.DingDanType.机票订单;
            }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "12")
            {
                phChongZhi.Visible = true;
                phOrderPay.Visible = true;

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

                if (!_TenPayTradeModel.IsSuccess)
                    plaIsWxBow.Visible = false;
            }


        }

        public EyouSoft.Model.XianLuStructure.MOrderInfo GetXuLuModel()
        {
            BOrder bll = new BOrder();
            string orderid = Utils.GetQueryStringValue("orderid");
            var list = bll.GetInfo(orderid);
            
            
            lblchanpinmingcheng.Text = list.XianLuName;
            lblJinE.Text =  list.JinE.ToString("F2");
            return list;
        }
        public EyouSoft.Model.HotelStructure.MHotelOrder GetHotelModel()
        {
            BHotelOrder bll = new BHotelOrder();
            string orderid = Utils.GetQueryStringValue("orderid");
            var list = bll.GetModel(orderid);
            lblchanpinmingcheng.Text = list.HotelName;
            lblJinE.Text =  list.TotalAmount.ToString("F2");
            return list;
        }
        public EyouSoft.Model.ScenicStructure.MScenicAreaOrder GetJingquModel()
        {
            BScenicArea bll = new BScenicArea();
            string orderid = Utils.GetQueryStringValue("orderid");
            var list = bll.GetScenicAreaOrderModel(orderid);
            lblchanpinmingcheng.Text = list.ScenicName;
            lblJinE.Text =  list.Price.ToString("F2");
            return list;
        }
        public EyouSoft.Model.ZuCheStructure.MZuCheOrder GetZucheModel()
        {
            BZuCheOrder bll = new BZuCheOrder();
            string orderid = Utils.GetQueryStringValue("orderid");
            var list = bll.GetModel(orderid);
            
            lblchanpinmingcheng.Text = list.CarName;
            lblJinE.Text =  list.ZuJin.Value.ToString("F2");
            return list;
        }
        public EyouSoft.Model.MallStructure.MShangChengDingDan GetShangChengModel()
        {
            BShangChengDingDan bll = new BShangChengDingDan();
            string orderid = Utils.GetQueryStringValue("orderid");
            var list = bll.GetModel(orderid);
            
            lblchanpinmingcheng.Text = list.ProductName;
            lblJinE.Text =  list.OrderPrice.ToString("F2");
            return list;
        }
        public EyouSoft.Model.OtherStructure.MTuanGouDingDan GetTuanGouModel()
        {
            BTuanGouDingDan bll = new BTuanGouDingDan();
            string orderid = Utils.GetQueryStringValue("orderid");
            var list = bll.GetModel(int.Parse(orderid));
            
            lblchanpinmingcheng.Text = list.ProductName;
            lblJinE.Text =  list.OrderPrice.ToString("F2");
            return list;
        }
        public EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo GetQianZhengModel()
        {
            BQianZhengDingDan bll = new BQianZhengDingDan();
            string orderid = Utils.GetQueryStringValue("orderid");
            var list = bll.GetInfo(orderid);            
            
            lblchanpinmingcheng.Text = list.QianZhengName;
            lblJinE.Text =  list.JinE.ToString("F2");
            return list;
        }
        public EyouSoft.Model.XianLuStructure.MZiZuTuan GetZuTuanModel()
        {
            BZiZuTuan bll = new BZiZuTuan();
            string orderid = Utils.GetQueryStringValue("orderid");
            var list = bll.GetInfo(orderid);
            
            lblchanpinmingcheng.Text = list.XianLuName;
            lblJinE.Text =  Convert.ToDecimal(list.ZongJinE).ToString("F2");
            return list;
        }
        public EyouSoft.Model.JPStructure.MDingDanInfo GeJiPiaoModel()
        {
            EyouSoft.BLL.JPStructure.BDingDan bll = new EyouSoft.BLL.JPStructure.BDingDan();
            string orderid = Utils.GetQueryStringValue("orderid");
            var list = bll.GetInfo(orderid);
            
            
            lblchanpinmingcheng.Text = list.ChuFaChengShiSanZiMa + "-" + list.DaoDaChengShiSanZiMa;
            lblJinE.Text =  Convert.ToDecimal(list.JinE).ToString("F2");
            return list;
        }



    }

}
