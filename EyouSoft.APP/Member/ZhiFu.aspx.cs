using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.BLL.ScenicStructure;
using EyouSoft.Common;
using EyouSoft.BLL.XianLuStructure;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.BLL.ZuCheStructure;
using EyouSoft.BLL.MallStructure;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.BLL.QianZhengStructure;
using PayAPI.Model.Tencent;
using PayAPI.Tencent;

namespace EyouSoft.WAP.Member
{
    public partial class ZhiFu : HuiYuanWapPageBase
    {
        protected string ZhiFuJinE = "0", ShengYuJinE = "0";
        BScenicArea2 bll = new BScenicArea2();
        BZuCheOrder zuchebll = new BZuCheOrder();
        protected int DDLX = 0;
        protected string pid = "";
        protected TenPayTrade TenPayTradeModel = new TenPayTrade();
        protected PrePay _TenPayTradeModel = new PrePay();
        protected string weixin_jsapi_config = "";
        protected EyouSoft.Common.Utils.weixin_oauth2_access_token_info wxModel = new Utils.weixin_oauth2_access_token_info();
        protected string OpenID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            #region
            if (Request.UserAgent.ToLower().Contains("micromessenger"))
            {
                plaIsWxBow.Visible = true;
                var weixin_jsApiList = new List<string>();
                weixin_jsApiList.Add("chooseWXPay");
                var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);

                weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
                OpenID = Utils.getOpenidCookie();
                wxModel.openid = OpenID;  
                if (wxModel == null)
                {
                    plaIsWxBow.Visible = false;
                }
            }
            #endregion

            EyouSoft.Model.SSOStructure.MUserInfo m = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);
            EyouSoft.BLL.OtherStructure.BKV BLL = new EyouSoft.BLL.OtherStructure.BKV();
            EyouSoft.Model.MCompanySetting model = BLL.GetCompanySetting();

            if (!isLogin) Response.Redirect("/default.aspx");
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
                    #endregion
                }
                DDLX = (int)EyouSoft.Model.OtherStructure.DingDanType.机票订单;
            }
            if (Utils.GetQueryStringValue("zhifu") == "1") PayOrder();
        }
        public EyouSoft.Model.XianLuStructure.MOrderInfo GetXuLuModel()
        {
            BOrder bll = new BOrder();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetInfo(orderid);
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = Convert.ToDouble(list.JinE).ToString("f2");
            lblchanpinmingcheng.Text = list.XianLuName;
            ZhiFuJinE = list.JinE.ToString("F2");
            pid = list.XianLuId;
            return list;
        }
        public EyouSoft.Model.HotelStructure.MHotelOrder GetHotelModel()
        {
            BHotelOrder bll = new BHotelOrder();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetModel(orderid);
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = Convert.ToDouble(list.TotalAmount).ToString("f2");
            lblchanpinmingcheng.Text = list.HotelName;
            ZhiFuJinE = list.TotalAmount.ToString("F2");
            pid = list.HotelId;
            return list;
        }
        public EyouSoft.Model.ScenicStructure.MScenicAreaOrder GetJingquModel()
        {
            BScenicArea bll = new BScenicArea();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetScenicAreaOrderModel(orderid);
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = Convert.ToDouble(list.Price).ToString("f2");
            lblchanpinmingcheng.Text = list.ScenicName;
            ZhiFuJinE = list.Price.ToString("F2");
            pid = list.ScenicId;
            return list;
        }
        public EyouSoft.Model.ZuCheStructure.MZuCheOrder GetZucheModel()
        {
            BZuCheOrder bll = new BZuCheOrder();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetModel(orderid);
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = Convert.ToDouble(list.ZuJin).ToString("f2");
            pid = list.ZuCheID;
            lblchanpinmingcheng.Text = list.CarName;
            if (list.ZuJin.HasValue)
                ZhiFuJinE = list.ZuJin.Value.ToString("F2");
            return list;
        }
        public EyouSoft.Model.MallStructure.MShangChengDingDan GetShangChengModel()
        {
            BShangChengDingDan bll = new BShangChengDingDan();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetModel(orderid);
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = Convert.ToDouble(list.OrderPrice).ToString("f2");
            lblchanpinmingcheng.Text = list.ProductName;
            ZhiFuJinE = list.OrderPrice.ToString("F2");
            pid = list.ProductID;
            return list;
        }
        public EyouSoft.Model.OtherStructure.MTuanGouDingDan GetTuanGouModel()
        {
            BTuanGouDingDan bll = new BTuanGouDingDan();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetModel(int.Parse(orderid));
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = Convert.ToDouble(list.OrderPrice).ToString("f2");
            lblchanpinmingcheng.Text = list.ProductName;
            ZhiFuJinE = list.OrderPrice.ToString("F2");
            pid = list.ProductID.ToString();
            return list;
        }
        public EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo GetQianZhengModel()
        {
            BQianZhengDingDan bll = new BQianZhengDingDan();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetInfo(orderid);
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = Convert.ToDouble(list.JinE).ToString("f2");
            lblchanpinmingcheng.Text = list.QianZhengName;
            ZhiFuJinE = list.JinE.ToString("F2");
            pid = list.QianZhengId;
            return list;
        }
        public EyouSoft.Model.XianLuStructure.MZiZuTuan GetZuTuanModel()
        {
            BZiZuTuan bll = new BZiZuTuan();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetInfo(orderid);
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = Convert.ToDouble(list.ZongJinE).ToString("f2");
            lblchanpinmingcheng.Text = list.XianLuName;
            ZhiFuJinE = Convert.ToDecimal(list.ZongJinE).ToString("F2");
            pid = list.XianLuId;
            return list;
        }
        public EyouSoft.Model.JPStructure.MDingDanInfo GeJiPiaoModel()
        {
            EyouSoft.BLL.JPStructure.BDingDan bll = new EyouSoft.BLL.JPStructure.BDingDan();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetInfo(orderid);
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = Convert.ToDouble(list.JinE).ToString("f2");
            lblchanpinmingcheng.Text = list.ChuFaChengShiSanZiMa + "-" + list.DaoDaChengShiSanZiMa;
            ZhiFuJinE = Convert.ToDecimal(list.JinE).ToString("F2");
            return list;
        }
        /// <summary>
        /// 支付操作
        /// </summary>
        public void PayOrder()
        {
            string token = Utils.GetQueryStringValue("token");
            string id = Utils.GetQueryStringValue("id");
            string ViaCode = Utils.GetFormValue("viacode");
            string ViaPwd = Utils.GetFormValue("zhifuPwd");
            decimal memberMoney = 0M;
            var member = new EyouSoft.IDAL.MemberStructure.BMember2().Get(token);
            if (member != null)
            {
                memberMoney = member.TotalMoney.Value;
                var info = new EyouSoft.BLL.OtherStructure.BYanZhengMa().GetInfo(member.Account, ViaCode, EyouSoft.Model.Enum.YanZhengMaLeiXing.余额支付);
                if (info == null || ViaCode != info.YanZhengMa) RCWE(UtilsCommons.AjaxReturnJson("0", "验证码错误！"));
                if (ViaPwd != member.ZhiFuPassword) RCWE(UtilsCommons.AjaxReturnJson("0", "支付密码错误！"));
                new EyouSoft.BLL.OtherStructure.BYanZhengMa().SetYiShiYong(info.IdentityId);//设置验证码已使用

            }
            else
            {
                RCWE(UtilsCommons.AjaxReturnJson("0", "请求错误，请重新登陆！"));
            }
            string Classid = Utils.GetQueryStringValue("Classid");
            #region 处理交易信息
            int result = 0;
            bool isAdd = false;
            switch (Classid)
            {
                case "1":
                case "8":
                case "9":
                    result = new EyouSoft.BLL.XianLuStructure.BOrder().SheZhiZhiFus(new EyouSoft.Model.XianLuStructure.MOrderInfo() { FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, Status = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, OrderId = id });
                    if (result != 1) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    var xianlu = GetXuLuModel();
                    if (xianlu == null) return;
                    isAdd = insertDetial(id, EyouSoft.Model.Enum.DingDanLeiBie.线路订单, xianlu.JinE, member.TotalMoney.Value);
                    if (!isAdd) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(id, EyouSoft.Model.Enum.DingDanLeiBie.线路订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                    SheZhiTuiGuangYiFanLi(id, EyouSoft.Model.OtherStructure.DingDanType.长线订单);
                    RCWE(UtilsCommons.AjaxReturnJson("1", "交易成功"));
                    break;
                case "5":
                    result = new EyouSoft.BLL.MallStructure.BShangChengDingDan().SheZhiZhiFus(new EyouSoft.Model.MallStructure.MShangChengDingDan() { PayState = EyouSoft.Model.Enum.PaymentState.已支付, OrderState = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, OrderID = id });
                    if (result != 1) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    var shangcheng = GetShangChengModel();
                    if (shangcheng == null) return;
                    isAdd = insertDetial(id, EyouSoft.Model.Enum.DingDanLeiBie.商城订单, shangcheng.OrderPrice, member.TotalMoney.Value);
                    if (!isAdd) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(id, EyouSoft.Model.Enum.DingDanLeiBie.商城订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                    SheZhiShangJiDaiLiShang(id);
                    SheZhiTuiGuangYiFanLi(id, EyouSoft.Model.OtherStructure.DingDanType.商城订单);
                    RCWE(UtilsCommons.AjaxReturnJson("1", "交易成功"));
                    break;
                case "3":
                    result = new EyouSoft.BLL.ScenicStructure.BScenicArea().SheZhiZhiFus(new EyouSoft.Model.ScenicStructure.MScenicAreaOrder() { FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, Status = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, OrderId = id });
                    if (result != 1) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    var jingdian = GetJingquModel();
                    if (jingdian == null) return;
                    bll.SubmitTicketsInterface(id);
                    isAdd = insertDetial(id, EyouSoft.Model.Enum.DingDanLeiBie.门票订单, jingdian.Price, member.TotalMoney.Value);
                    if (!isAdd) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(id, EyouSoft.Model.Enum.DingDanLeiBie.门票订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                    SheZhiTuiGuangYiFanLi(id, EyouSoft.Model.OtherStructure.DingDanType.门票订单);
                    RCWE(UtilsCommons.AjaxReturnJson("1", "交易成功"));
                    break;
                case "2":
                    result = new EyouSoft.BLL.HotelStructure.BHotelOrder().SheZhiZhiFus(new EyouSoft.Model.HotelStructure.MHotelOrder() { PaymentState = EyouSoft.Model.Enum.PaymentState.已支付, OrderState = EyouSoft.Model.Enum.OrderState.订单出货, OrderId = id });
                    if (result != 1) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    var jiudian = GetHotelModel();
                    if (jiudian == null) return;
                    isAdd = insertDetial(id, EyouSoft.Model.Enum.DingDanLeiBie.酒店订单, jiudian.TotalAmount, member.TotalMoney.Value);
                    if (!isAdd) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(id, EyouSoft.Model.Enum.DingDanLeiBie.酒店订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                    SheZhiTuiGuangYiFanLi(id, EyouSoft.Model.OtherStructure.DingDanType.酒店订单);
                    RCWE(UtilsCommons.AjaxReturnJson("1", "交易成功"));
                    break;
                case "4":
                    result = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().SheZhiZhiFus(new EyouSoft.Model.ZuCheStructure.MZuCheOrder() { FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, Status = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, OrderId = id });
                    if (result != 1) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    var zuche = GetZucheModel();
                    if (zuche == null) return;
                    isAdd = insertDetial(id, EyouSoft.Model.Enum.DingDanLeiBie.租车订单, zuche.ZuJin.Value, member.TotalMoney.Value);
                    if (!isAdd) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(id, EyouSoft.Model.Enum.DingDanLeiBie.租车订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                    SheZhiTuiGuangYiFanLi(id, EyouSoft.Model.OtherStructure.DingDanType.租车订单);
                    RCWE(UtilsCommons.AjaxReturnJson("1", "交易成功"));
                    break;
                case "6":
                    result = new EyouSoft.BLL.OtherStructure.BTuanGouDingDan().SheZhiZhiFus(new EyouSoft.Model.OtherStructure.MTuanGouDingDan() { PayState = EyouSoft.Model.Enum.PaymentState.已支付, OrderState = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, OrderID = int.Parse(id) });
                    if (result != 1) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    var tuangou = GetTuanGouModel();
                    if (tuangou == null) return;
                    isAdd = insertDetial(id, EyouSoft.Model.Enum.DingDanLeiBie.团购订单, tuangou.OrderPrice, member.TotalMoney.Value);
                    if (!isAdd) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(id, EyouSoft.Model.Enum.DingDanLeiBie.团购订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                    SheZhiTuiGuangYiFanLi(id, EyouSoft.Model.OtherStructure.DingDanType.团购订单);
                    RCWE(UtilsCommons.AjaxReturnJson("1", "交易成功"));
                    break;
                case "7":
                    result = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().SheZhiZhiFus(new EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo() { FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, DingDanStatus = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, DingDanId = id });
                    if (result != 1) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    var qianzheng = GetQianZhengModel();
                    if (qianzheng == null) return;
                    isAdd = insertDetial(id, EyouSoft.Model.Enum.DingDanLeiBie.签证订单, qianzheng.JinE, member.TotalMoney.Value);
                    if (!isAdd) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(id, EyouSoft.Model.Enum.DingDanLeiBie.签证订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                    SheZhiTuiGuangYiFanLi(id, EyouSoft.Model.OtherStructure.DingDanType.签证订单);
                    RCWE(UtilsCommons.AjaxReturnJson("1", "交易成功"));
                    break;
                case "10":
                    result = new EyouSoft.BLL.XianLuStructure.BZiZuTuan().SheZhiZhiFus(new EyouSoft.Model.XianLuStructure.MZiZuTuan() { FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, OrderState = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货, ZuTuanId = id });
                    if (result != 1) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    var zizutuan = GetZuTuanModel();
                    if (zizutuan == null) return;
                    isAdd = insertDetial(id, EyouSoft.Model.Enum.DingDanLeiBie.自组团订单, zizutuan.ZongJinE.Value, member.TotalMoney.Value);
                    if (!isAdd) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(id, EyouSoft.Model.Enum.DingDanLeiBie.自组团订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                    SheZhiTuiGuangYiFanLi(id, EyouSoft.Model.OtherStructure.DingDanType.单团订单);
                    RCWE(UtilsCommons.AjaxReturnJson("1", "交易成功"));
                    break;
                case "11":

                    result = new EyouSoft.BLL.JPStructure.BDingDan().SheZhiDingDanYiZhiFu(id, token);
                    if (result != 1) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    var jipiao = GeJiPiaoModel();
                    if (jipiao == null) return;
                    isAdd = insertDetial(id, EyouSoft.Model.Enum.DingDanLeiBie.机票订单, jipiao.JinE, member.TotalMoney.Value);
                    if (!isAdd) RCWE(UtilsCommons.AjaxReturnJson("0", "交易错误"));
                    new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(id, EyouSoft.Model.Enum.DingDanLeiBie.机票订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.支付);
                    SheZhiTuiGuangYiFanLi(id, EyouSoft.Model.OtherStructure.DingDanType.机票订单);
                    RCWE(UtilsCommons.AjaxReturnJson("1", "交易成功"));
                    break;
                default:
                    break;
            }
            #endregion

        }

        #region 写入交易记录
        /// <summary>
        /// 写入交易记录
        /// </summary>
        /// <param name="orderid">订单编号</param>
        /// <param name="dingdanleixing">订单类型</param>
        /// <param name="jiaoyi"></param>
        bool insertDetial(string orderid, EyouSoft.Model.Enum.DingDanLeiBie dingdanleixing, decimal jiaoyi, decimal huiyuanjine)
        {
            EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out huiYuanInfo);

            var info = new EyouSoft.Model.OtherStructure.MJiaoYiMingXiInfo();
            info.ApiJiaoYiHao = string.Empty;
            info.DingDanId = orderid;
            info.DingDanLeiXing = dingdanleixing;
            info.HuiYuanId = huiYuanInfo.UserId;
            info.JiaoYiHao = string.Empty;
            info.JiaoYiJinE = jiaoyi;
            info.JiaoYiLeiBie = EyouSoft.Model.Enum.JiaoYiLeiBie.消费;
            info.JiaoYiMiaoShu = string.Empty;
            info.JiaoYiShiJian = DateTime.Now;
            info.JiaoYiStatus = EyouSoft.Model.Enum.JiaoYiStatus.交易成功;
            info.MingXiId = string.Empty;
            info.ZhiFuFangShi = EyouSoft.Model.Enum.ZhiFuFangShi.E额宝;

            if (dingdanleixing == EyouSoft.Model.Enum.DingDanLeiBie.机票订单)
            {
                var dingDanInfo = new EyouSoft.BLL.JPStructure.BDingDan().GetInfo(orderid);
                if (dingDanInfo != null)
                {
                    info.JiaoYiHao = dingDanInfo.ApiDingDanId;
                }
            }

            if (dingdanleixing == EyouSoft.Model.Enum.DingDanLeiBie.酒店订单)
            {
                var dingDanInfo = new EyouSoft.BLL.HotelStructure.BHotelOrder().GetModel(orderid);
                if (dingDanInfo != null)
                {
                    info.JiaoYiHao = dingDanInfo.OrderCode;
                }
            }

            if (dingdanleixing == EyouSoft.Model.Enum.DingDanLeiBie.门票订单)
            {
                var dingDanInfo = new EyouSoft.BLL.ScenicStructure.BScenicArea().GetScenicAreaOrderModel(orderid);
                if (dingDanInfo != null)
                {
                    info.JiaoYiHao = dingDanInfo.OrderCode;
                }
            }

            if (dingdanleixing == EyouSoft.Model.Enum.DingDanLeiBie.签证订单)
            {
                var dingDanInfo = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().GetInfo(orderid);
                if (dingDanInfo != null)
                {
                    info.JiaoYiHao = dingDanInfo.DingDanHao;
                }
            }

            if (dingdanleixing == EyouSoft.Model.Enum.DingDanLeiBie.商城订单)
            {
                var dingDanInfo = new EyouSoft.BLL.MallStructure.BShangChengDingDan().GetModel(orderid);
                if (dingDanInfo != null)
                {
                    info.JiaoYiHao = dingDanInfo.OrderCode;
                }
            }

            if (dingdanleixing == EyouSoft.Model.Enum.DingDanLeiBie.团购订单)
            {
                var dingDanInfo = new EyouSoft.BLL.OtherStructure.BTuanGouDingDan().GetModel(int.Parse(orderid));
                if (dingDanInfo != null)
                {
                    info.JiaoYiHao = dingDanInfo.OrderCode;
                }
            }

            if (dingdanleixing == EyouSoft.Model.Enum.DingDanLeiBie.线路订单)
            {
                var dingDanInfo = new EyouSoft.BLL.XianLuStructure.BOrder().GetInfo(orderid);
                if (dingDanInfo != null)
                {
                    info.JiaoYiHao = dingDanInfo.OrderCode;
                }
            }

            if (dingdanleixing == EyouSoft.Model.Enum.DingDanLeiBie.租车订单)
            {
                var dingDanInfo = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder().GetModel(orderid);
                if (dingDanInfo != null)
                {
                    info.JiaoYiHao = dingDanInfo.OrderCode;
                }
            }

            if (dingdanleixing == EyouSoft.Model.Enum.DingDanLeiBie.自组团订单)
            {
                var dingDanInfo = new EyouSoft.BLL.XianLuStructure.BZiZuTuan().GetInfo(orderid);
                if (dingDanInfo != null)
                {
                    info.JiaoYiHao = dingDanInfo.OrderCode;
                }
            }

            return new EyouSoft.BLL.OtherStructure.BJiaoYiMingXi().JiaoYiMingXi_C(info) == 1;
        }

        /// <summary>
        /// 设置上级代理商信息
        /// </summary>
        /// <param name="dingDanId">商城订单编号</param>
        void SheZhiShangJiDaiLiShang(string dingDanId)
        {
            if (string.IsNullOrEmpty(dingDanId)) return;
            var info = new EyouSoft.BLL.MallStructure.BShangChengDingDan().GetModel(dingDanId);
            if (info == null) return;
            if (string.IsNullOrEmpty(info.ProductID) || string.IsNullOrEmpty(info.ProductID.Trim())) return;
            if (string.IsNullOrEmpty(info.SupplierID) || string.IsNullOrEmpty(info.SupplierID.Trim())) return;
            if (string.IsNullOrEmpty(info.ContactID) || string.IsNullOrEmpty(info.ContactID.Trim())) return;

            var daiLiKaiDianShangPinId = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("DaiLiKaiDianShangPinId");
            if (string.IsNullOrEmpty(daiLiKaiDianShangPinId)) return;

            if (info.ProductID != daiLiKaiDianShangPinId) return;

            new EyouSoft.BLL.OtherStructure.BMember().SheZhiShangJiDaiLiShang(info.ContactID, info.SupplierID);
        }

        /// <summary>
        /// 设置返联盟推广返利状态为已返利，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="dingDanLeiXing">订单类型</param>
        /// <returns></returns>
        int SheZhiTuiGuangYiFanLi(string dingDanId, EyouSoft.Model.OtherStructure.DingDanType dingDanLeiXing)
        {
            return new EyouSoft.BLL.OtherStructure.BTuiGuang().SheZhiTuiGuangYiFanLi(dingDanId, dingDanLeiXing);
        }
        #endregion
    }
}
