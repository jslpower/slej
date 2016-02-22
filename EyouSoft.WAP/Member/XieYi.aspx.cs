using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.BLL.XianLuStructure;
using EyouSoft.BLL.ScenicStructure;
using EyouSoft.BLL.ZuCheStructure;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.BLL.MallStructure;
using EyouSoft.BLL.QianZhengStructure;
using Common.page;

namespace EyouSoft.WAP.Member
{
    public partial class XieYi : HuiYuanWapPageBase
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
            if (Utils.GetQueryStringValue("Pay") == "1" && Utils.GetQueryStringValue("Classid") == "11") { GeJiPiaoModel(); if (model != null) { txtXieYi.Text = model.JiPiaoXieYi; } }
        }
        public EyouSoft.Model.XianLuStructure.MOrderInfo GetXuLuModel()
        {
            BOrder bll = new BOrder();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetInfo(orderid);
            if (list == null) Utils.RCWE("参数异常");
            // ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            var item = new EyouSoft.IDAL.MemberStructure.BMember2().GetByAccount(list.OperatorId);
            if (list.RouteType == EyouSoft.Model.Enum.AreaType.出境线路)
            {
                TradeMoney.Text = list.ChengRenShu + "成人 * " + list.JiaoYiCR.ToString("f2") + "元/人 + " + list.ErTongShu + "儿童 * " + list.JiaoYiET.ToString("f2") + "元/人 = " + list.JinE.ToString("f2") + "元";
            }
            else if (list.RouteType == EyouSoft.Model.Enum.AreaType.国内长线)
            {
                TradeMoney.Text = list.ChengRenShu + "成人 * " + list.JiaoYiCR.ToString("f2") + "元/人 + " + list.ErTongShu + "儿童 * " + list.JiaoYiET.ToString("f2") + "元/人 = " + list.JinE.ToString("f2") + "元";
            }
            else if (list.RouteType == EyouSoft.Model.Enum.AreaType.周边短线)
            {
                TradeMoney.Text = list.ChengRenShu + "成人 * " + list.JiaoYiCR.ToString("f2") + "元/人 + " + list.ErTongShu + "儿童 * " + list.JiaoYiET.ToString("f2") + "元/人 = " + list.JinE.ToString("f2") + "元";
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
            if (list == null) Utils.RCWE("参数异常");
            // ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
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
            if (list == null) Utils.RCWE("参数异常");
            // ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
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
            if (list == null) Utils.RCWE("参数异常");
            // ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
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
            if (list == null) Utils.RCWE("参数异常");
            // ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
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
            if (list == null) Utils.RCWE("参数异常");
            // ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
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
            if (list == null) Utils.RCWE("参数异常");
            // ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
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
            if (list == null) Utils.RCWE("参数异常");
            // ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = list.RenShu + "成人 * " + Convert.ToDecimal(list.CRJiage).ToString("f2") + "元/人 + " + list.ErTongNum + "儿童 * " + Convert.ToDecimal(list.ETJiage).ToString("f2") + "元/人 = " + Convert.ToDouble(list.ZongJinE).ToString("f2") + "元";
            //TradeMoney.Text = Convert.ToDouble(list.ZongJinE).ToString("f2");
            lblchanpinmingcheng.Text = list.XianLuName;
            ZhiFuJinE = Convert.ToDecimal(list.ZongJinE).ToString("F2");
            return list;
        }
        public EyouSoft.Model.JPStructure.MDingDanInfo GeJiPiaoModel()
        {
            EyouSoft.BLL.JPStructure.BDingDan bll = new EyouSoft.BLL.JPStructure.BDingDan();
            string orderid = Utils.GetQueryStringValue("id");
            var list = bll.GetInfo(orderid);
            if (list == null) Utils.RCWE("参数异常");
            //ShengYuJinE = MyMoney.Text = Convert.ToDouble(HuiYuanInfo.TotalMoney).ToString("f2");
            TradeMoney.Text = Convert.ToDouble(list.JinE).ToString("f2");
            lblchanpinmingcheng.Text = list.ChuFaChengShiSanZiMa + "-" + list.DaoDaChengShiSanZiMa;
            ZhiFuJinE = Convert.ToDecimal(list.JinE).ToString("F2");
            return list;
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
