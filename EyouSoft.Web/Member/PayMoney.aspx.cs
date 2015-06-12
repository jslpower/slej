using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.BLL.ZuCheStructure;
using Common.page;
using EyouSoft.BLL.XianLuStructure;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.BLL.ScenicStructure;
using EyouSoft.BLL.MallStructure;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.BLL.QianZhengStructure;

namespace EyouSoft.Web.Member
{
    public partial class PayMoney : ClientModelViewPageBase<EyouSoft.Model.ZuCheStructure.MZuCheOrderChaXun>
    {
        protected string ZhiFuJinE = "0", ShengYuJinE = "0";
        BScenicArea2 bll = new BScenicArea2();
        BZuCheOrder zuchebll = new BZuCheOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            EyouSoft.Model.SSOStructure.MUserInfo m = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);
            EyouSoft.BLL.OtherStructure.BKV BLL = new EyouSoft.BLL.OtherStructure.BKV();
            EyouSoft.Model.MCompanySetting model = BLL.GetCompanySetting();
            if (model != null)
            {
                txtXieYi.Text = model.XieYi;
            }
            if (!isLogin) Response.Redirect("/default.aspx");
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "1") { GetXuLuModel(); if (model != null) { txtXieYi.Text = model.XieYi; } }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "8") { GetXuLuModel(); if (model != null) { txtXieYi.Text = model.ChuJingXieYi; } }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "9") { GetXuLuModel(); if (model != null) { txtXieYi.Text = model.DuanXianXieYi; } }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "2") { GetHotelModel(); if (model != null) { txtXieYi.Text = model.HotelXieYi; } }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "3") { GetJingquModel(); if (model != null) { txtXieYi.Text = model.TicketXieYi; } }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "4") { GetZucheModel(); if (model != null) { txtXieYi.Text = model.ZuCheXieyi; } }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "5") { GetShangChengModel(); if (model != null) { txtXieYi.Text = model.ShopXieYi; } }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "6") { GetTuanGouModel(); if (model != null) { txtXieYi.Text = model.TuanGouXieYi; } }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "7") { GetQianZhengModel(); if (model != null) { txtXieYi.Text = model.VisaXieYi; } }
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "10") { GetZuTuanModel(); if (model != null) { txtXieYi.Text = model.BaoJiaXieYi; } }
            if (Utils.GetQueryStringValue("zhifu") == "1") PayOrder();
            if (Convert.ToDouble(ZhiFuJinE) > Convert.ToDouble(ShengYuJinE))
            {
                PlaceHolder1.Visible = true;
            }
        }
        public EyouSoft.Model.XianLuStructure.MOrderInfo GetXuLuModel()
        {
            BOrder bll = new BOrder();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetInfo(orderid);
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            var item = new EyouSoft.IDAL.MemberStructure.BMember2().GetByAccount(list.OperatorId);
            if (list.RouteType == EyouSoft.Model.Enum.AreaType.出境线路)
            {
                TradeMoney.Text = list.ChengRenShu + "成人 * " + UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.国际线路, Convert.ToDecimal(list.JSJCR), Convert.ToDecimal(list.SCJCR), list.UserType).ToString("f2") + "元/人 + " + list.ErTongShu + "儿童 * " + UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.国际线路, Convert.ToDecimal(list.JSJER), Convert.ToDecimal(list.SCJET), list.UserType).ToString("f2") + "元/人 = " + Convert.ToDouble(list.JinE).ToString("f2") + "元";
            }
            else if (list.RouteType == EyouSoft.Model.Enum.AreaType.国内长线)
            {
                TradeMoney.Text = list.ChengRenShu + "成人 * " + UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.国内线路, Convert.ToDecimal(list.JSJCR), Convert.ToDecimal(list.SCJCR), list.UserType).ToString("f2") + "元/人 + " + list.ErTongShu + "儿童 * " + UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.国内线路, Convert.ToDecimal(list.JSJER), Convert.ToDecimal(list.SCJET), list.UserType).ToString("f2") + "元/人 = " + Convert.ToDouble(list.JinE).ToString("f2") + "元";
            }
            else if (list.RouteType == EyouSoft.Model.Enum.AreaType.周边短线)
            {
                TradeMoney.Text = list.ChengRenShu + "成人 * " + UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.周边线路, Convert.ToDecimal(list.JSJCR), Convert.ToDecimal(list.SCJCR), list.UserType).ToString("f2") + "元/人 + " + list.ErTongShu + "儿童 * " + UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.周边线路, Convert.ToDecimal(list.JSJER), Convert.ToDecimal(list.SCJET), list.UserType).ToString("f2") + "元/人 = " + Convert.ToDouble(list.JinE).ToString("f2") + "元";
            }
            //TradeMoney.Text =  Convert.ToDouble(list.JinE).ToString("f2");
            lblchanpinmingcheng.Text = list.XianLuName;
            ZhiFuJinE = list.JinE.ToString("F2");
            return list;
        }
        public EyouSoft.Model.HotelStructure.MHotelOrder GetHotelModel()
        {
            BHotelOrder bll = new BHotelOrder();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetModel(orderid);
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = list.RoomCount + "间 * " + Convert.ToDouble(list.TotalAmount / list.RoomCount) + "元/间 =" + Convert.ToDouble(list.TotalAmount).ToString("f2") + "元";
            lblchanpinmingcheng.Text = list.HotelName;
            ZhiFuJinE = list.TotalAmount.ToString("F2");
            return list;
        }
        public EyouSoft.Model.ScenicStructure.MScenicAreaOrder GetJingquModel()
        {
            BScenicArea bll = new BScenicArea();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetScenicAreaOrderModel(orderid);
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = list.Num + "份 * " + Convert.ToDouble(list.Price / list.Num) + "元/份 =" + Convert.ToDouble(list.Price).ToString("f2") + "元";
            lblchanpinmingcheng.Text = list.ScenicName;
            ZhiFuJinE = list.Price.ToString("F2");
            return list;
        }
        public EyouSoft.Model.ZuCheStructure.MZuCheOrder GetZucheModel()
        {
            BZuCheOrder bll = new BZuCheOrder();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetModel(orderid);
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = list.Number + "辆 * " + Convert.ToDouble(list.ZuJin / list.Number) + "元/辆 =" + Convert.ToDouble(list.ZuJin).ToString("f2") + "元";
            //TradeMoney.Text = Convert.ToDouble(list.ZuJin).ToString("f2");
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
            TradeMoney.Text = list.ProductNum + "份 * " + Convert.ToDouble(list.OrderPrice / list.ProductNum) + "元/份 =" + Convert.ToDouble(list.OrderPrice).ToString("f2") + "元";
            //TradeMoney.Text = Convert.ToDouble(list.OrderPrice).ToString("f2");
            lblchanpinmingcheng.Text = list.ProductName;
            ZhiFuJinE = list.OrderPrice.ToString("F2");
            return list;
        }
        public EyouSoft.Model.OtherStructure.MTuanGouDingDan GetTuanGouModel()
        {
            BTuanGouDingDan bll = new BTuanGouDingDan();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetModel(int.Parse(orderid));
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = list.ProductNum + "份 * " + Convert.ToDouble(list.OrderPrice / list.ProductNum) + "元/份 =" + Convert.ToDouble(list.OrderPrice).ToString("f2") + "元";
            //TradeMoney.Text = Convert.ToDouble(list.OrderPrice).ToString("f2");
            lblchanpinmingcheng.Text = list.ProductName;
            ZhiFuJinE = list.OrderPrice.ToString("F2");
            return list;
        }
        public EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo GetQianZhengModel()
        {
            BQianZhengDingDan bll = new BQianZhengDingDan();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetInfo(orderid);
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            //TradeMoney.Text = Convert.ToDouble(list.JinE).ToString("f2");
            TradeMoney.Text = list.YuDingShuLiang + "份 * " + Convert.ToDouble(list.JinE / list.YuDingShuLiang) + "元/份 =" + Convert.ToDouble(list.JinE).ToString("f2") + "元";
            lblchanpinmingcheng.Text = list.QianZhengName;
            ZhiFuJinE = list.JinE.ToString("F2");
            return list;
        }
        public EyouSoft.Model.XianLuStructure.MZiZuTuan GetZuTuanModel()
        {
            BZiZuTuan bll = new BZiZuTuan();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetInfo(orderid);
            ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = list.RenShu + "成人 * " + Convert.ToDecimal(list.CRJiage).ToString("f2") + "元/人 + " + list.ErTongNum + "儿童 * " + Convert.ToDecimal(list.ETJiage).ToString("f2") + "元/人 = " + Convert.ToDouble(list.ZongJinE).ToString("f2") + "元";
            //TradeMoney.Text = Convert.ToDouble(list.ZongJinE).ToString("f2");
            lblchanpinmingcheng.Text = list.XianLuName;
            ZhiFuJinE = Convert.ToDecimal(list.ZongJinE).ToString("F2");
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
                //case EyouSoft.Model.Enum.DingDanLeiBie.机票订单:
                //break;
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
