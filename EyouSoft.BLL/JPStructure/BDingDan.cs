//机票订单信息相关BLL 汪奇志 2014-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit;
using System.Xml.Linq;

namespace EyouSoft.BLL.JPStructure
{
    /// <summary>
    /// 机票订单信息相关BLL
    /// </summary>
    public class BDingDan
    {
        #region static constants
        //static constants
        const string JinRi_Api_DingDan_Ws = "http://ws.jinri.cn/JinRiOrderServer.asmx";
        const string JinRi_Api_DingDanZhiFu_Ws = "http://ws.jinri.cn/JinRiAutoPayServer.asmx";
        #endregion

        readonly EyouSoft.IDAL.JPStructure.IDingDan dal = new EyouSoft.DAL.JPStructure.DDingDan();

        #region private members
        /// <summary>
        /// 获取儿童政策信息业务实体
        /// </summary>
        /// <param name="info">儿童订单信息业务实体</param>
        /// <returns></returns>
        EyouSoft.Model.JPStructure.MZhengCeInfo GetErTongZhengCeInfo(EyouSoft.Model.JPStructure.MDingDanInfo info)
        {
            var chaXun = new EyouSoft.Model.JPStructure.MZhengCeChaXunInfo3();
            chaXun.ChengKeLeiXing = "C";
            chaXun.HangBanLeiXing = "0";
            chaXun.PNR = info.PNR;
            chaXun.PnrInfo = info.PnrInfo;
            chaXun.ZhengCeLeiXing = string.Empty;
            chaXun.ZhengCeShuLiang = 16;

            var items = new BZhengCe().GetZhengCes(chaXun);
            if (items == null || items.Count == 0) return null;

            return items[0];
        }

        /// <summary>
        /// 获取成人政策信息业务实体
        /// </summary>
        /// <param name="info">成人订单信息业务实体</param>
        /// <returns></returns>
        EyouSoft.Model.JPStructure.MZhengCeInfo GetChengRenZhengCeInfo(EyouSoft.Model.JPStructure.MDingDanInfo info)
        {
            var chaXun = new EyouSoft.Model.JPStructure.MZhengCeChaXunInfo1();
            chaXun.ChuFaChengShiSanZiMa = info.ChuFaChengShiSanZiMa;
            chaXun.DaoDaChengShiSanZiMa = info.DaoDaChengShiSanZiMa;
            chaXun.ZhengCeId = info.ZhengCeId;

            var zhengCeInfo = new BZhengCe().GetZhengCeInfo(chaXun);

            return zhengCeInfo;
        }
        #endregion

        #region private members-jinri api
        /// <summary>
        /// 今日天下通API-创建订单（实时创建），返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int JinRi_Api_CreateDingDan(EyouSoft.Model.JPStructure.MDingDanInfo info)
        {
            #region 创建请求实体
            string xingMing = string.Empty;
            string zhengJianHao = string.Empty;
            string shiFouDaYinXingChengDan = string.Empty;
            string daYinXingChengDan = "0";
            if (info.ShiFuDaYinXingChengDan == EyouSoft.Model.JPStructure.ShiFuDaYinXingChengDan.是) daYinXingChengDan = "1";

            foreach (var item in info.ChengKes)
            {
                xingMing += item.XingMing + "|";
                zhengJianHao += "NI" + item.ZhengJianHao + "|";
                shiFouDaYinXingChengDan += daYinXingChengDan + "|";
            }

            xingMing = xingMing.TrimEnd('|');
            zhengJianHao = zhengJianHao.TrimEnd('|');
            shiFouDaYinXingChengDan = shiFouDaYinXingChengDan.TrimEnd('|');

            var requestInfo = new EyouSoft.Model.JPStructure.MJinRi_Api_XiaDanRequestInfo();
            requestInfo.CaiGouFanDian = info.CaiGouFanDian;
            requestInfo.CangWei = info.CangWei;
            requestInfo.ChengJiRenXingMing = xingMing;
            requestInfo.ChengJiRenZhengJianHao = zhengJianHao;
            string chengKeLeiXing = "A";
            if (info.ChengKeLeiXing == EyouSoft.Model.JPStructure.ChengKeLeiXing.儿童) chengKeLeiXing = "C";
            requestInfo.ChengKeLeiXing = chengKeLeiXing;
            requestInfo.ChuFaChengShiSanZiMa = info.ChuFaChengShiSanZiMa;
            requestInfo.ChuFaRiQi = info.ChuFaRiQi;
            requestInfo.DaoDaChengShiSanZiMa = info.DaoDaChengShiSanZiMa;
            requestInfo.FuWuShangId = string.Empty;
            requestInfo.GongPiaoShangId = info.GongPiaoShangId;
            requestInfo.HangBanHao = info.HangBanHao;
            requestInfo.HangXianLeiXing = ((int)info.HangXianLeiXing).ToString();
            requestInfo.JieShouFangShi = ((int)info.ApiJieShouFangShi).ToString();
            requestInfo.ShiFouYunXuGengHuanPnr = ((int)info.ShiFouYunXuGengHuanPnr).ToString();
            string shiFouZiDongDaiKou = "F";
            if (info.ShiFouZiDongDaiKou == EyouSoft.Model.JPStructure.ShiFouZiDongDaiKou.是) shiFouZiDongDaiKou = "T";
            requestInfo.ShiFouZiDongDaiKou = shiFouZiDongDaiKou;
            requestInfo.ShiFuDaYinXingChengDan = shiFouDaYinXingChengDan;
            requestInfo.ZhengCeId = info.ZhengCeId;
            requestInfo.ZhengCeLeiXing = ((int)info.ZhengCeLeiXing).ToString();
            requestInfo.AirChangedContact = info.AirChangedContact;
            #endregion

            #region 创建请求XML
            string requestUrl = JinRi_Api_DingDan_Ws + "/CreateOrder";
            StringBuilder apiChaXunXml = new StringBuilder();
            apiChaXunXml.Append("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
            apiChaXunXml.Append("<JIT-CreateOrder>");
            apiChaXunXml.AppendFormat("<Request ");
            apiChaXunXml.AppendFormat(" Username=\"{0}\" ", BHangBan.JinRi_Api_Username01);
            apiChaXunXml.AppendFormat(" RateId=\"{0}\" ", requestInfo.GongPiaoShangId);
            apiChaXunXml.AppendFormat(" PolicyId=\"{0}\" ", requestInfo.ZhengCeId);
            apiChaXunXml.AppendFormat(" Name=\"{0}\" ", requestInfo.ChengJiRenXingMing);
            apiChaXunXml.AppendFormat(" IDCard=\"{0}\" ", requestInfo.ChengJiRenZhengJianHao);
            apiChaXunXml.AppendFormat(" Cabins=\"{0}\" ", requestInfo.CangWei);
            apiChaXunXml.AppendFormat(" Airline=\"{0}\" ", requestInfo.HangBanHao);
            apiChaXunXml.AppendFormat(" sCity=\"{0}\" ", requestInfo.ChuFaChengShiSanZiMa);
            apiChaXunXml.AppendFormat(" eCity=\"{0}\" ", requestInfo.DaoDaChengShiSanZiMa);
            apiChaXunXml.AppendFormat(" sDate=\"{0}\" ", requestInfo.ChuFaRiQi.ToString("yyyy-MM-dd"));
            apiChaXunXml.AppendFormat(" dotNum=\"{0}\" ", requestInfo.CaiGouFanDian);
            apiChaXunXml.AppendFormat(" Jounery=\"{0}\" ", requestInfo.ShiFuDaYinXingChengDan);
            apiChaXunXml.AppendFormat(" Isfront=\"{0}\" ", requestInfo.JieShouFangShi);
            apiChaXunXml.AppendFormat(" Rateway=\"{0}\" ", requestInfo.ZhengCeLeiXing);
            apiChaXunXml.AppendFormat(" Voyagetype=\"{0}\" ", requestInfo.HangXianLeiXing);
            apiChaXunXml.AppendFormat(" isallowPnr=\"{0}\" ", requestInfo.ShiFouYunXuGengHuanPnr);
            apiChaXunXml.AppendFormat(" AutoPay=\"{0}\" ", requestInfo.ShiFouZiDongDaiKou);
            apiChaXunXml.AppendFormat(" PassengerType=\"{0}\" ", requestInfo.ChengKeLeiXing);
            apiChaXunXml.AppendFormat("  SystemId=\"\" ");
            apiChaXunXml.AppendFormat("  AirChangedContact=\"{0}\" ", requestInfo.AirChangedContact);

            apiChaXunXml.AppendFormat("/>");
            apiChaXunXml.Append("</JIT-CreateOrder>");
            #endregion

            string requestXml = "xml=" + System.Web.HttpUtility.UrlEncode(apiChaXunXml.ToString());

            var responseString = EyouSoft.Toolkit.request.post(requestUrl, requestXml, "application/x-www-form-urlencoded");

            string responseXml = BHangBan.JinRi_Api_GetReponseXml(responseString);

#if DEBUG
            Utils.WLog("requesturi:" + requestUrl, "/jinrilog/dingdan.log");
            Utils.WLog("request:" + apiChaXunXml.ToString(), "/jinrilog/dingdan.log");
            Utils.WLog("response:" + responseXml, "/jinrilog/dingdan.log");
#endif

            if (string.IsNullOrEmpty(responseXml)) return -1001;

            if (responseXml.Length < 10 || Utils.GetInt(responseXml) > 0) return -10002;

            var xJIT_Order_Response = XElement.Parse(responseXml);
            var xResponse = Utils.GetXElement(xJIT_Order_Response, "Response");
            var xOrderNo = Utils.GetXElement(xResponse, "OrderNo");
            var xPNR = Utils.GetXElement(xResponse, "PNR");

            var xStayDiscount = Utils.GetXElement(xResponse, "StayDiscount");
            var xGrowDiscount = Utils.GetXElement(xResponse, "GrowDiscount");
            var xPayMoney = Utils.GetXElement(xResponse, "PayMoney");
            var xProfit = Utils.GetXElement(xResponse, "Profit");
            var xStatus = Utils.GetXElement(xResponse, "Status");
            var xDate = Utils.GetXElement(xResponse, "Date");
            var xScity = Utils.GetXElement(xResponse, "Scity");
            var xEcity = Utils.GetXElement(xResponse, "Ecity");
            var xFlight = Utils.GetXElement(xResponse, "Flight");
            var xStime = Utils.GetXElement(xResponse, "Stime");
            var xEtime = Utils.GetXElement(xResponse, "Etime");
            var xCabin = Utils.GetXElement(xResponse, "Cabin");
            var xPrice = Utils.GetXElement(xResponse, "Price");
            var xTax = Utils.GetXElement(xResponse, "Tax");
            var xPCount = Utils.GetXElement(xResponse, "PCount");
            var xPName = Utils.GetXElement(xResponse, "PName");
            var xPCard = Utils.GetXElement(xResponse, "PCard");
            var xJouneryInfo = Utils.GetXElement(xResponse, "JouneryInfo");
            var xIsBuyInsurance = Utils.GetXElement(xResponse, "JouneryInfo");

            info.ApiDingDanId = Utils.GetXElementValue(xOrderNo);
            info.JinE = Utils.GetDecimal(Utils.GetXElementValue(xPayMoney));
            info.KeHuYouHuiDian = Utils.GetDecimal(Utils.GetXElementValue(xGrowDiscount));
            info.JingXiaoShangLiRunDian = Utils.GetDecimal(Utils.GetXElementValue(xStayDiscount));
            info.JingXiaoShangLiRun = Utils.GetDecimal(Utils.GetXElementValue(xProfit));
            info.PiaoMianJiaGe = Utils.GetDecimal(Utils.GetXElementValue(xPrice));
            info.ShuiFeiJinE = Utils.GetDecimal(Utils.GetXElementValue(xTax));
            info.PNR = Utils.GetXElementValue(xPNR);

            return 1;
        }

        /// <summary>
        /// 今日天下通API-创建订单（通过PNR），返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int JinRi_Api_CreateDingDanByPnr(EyouSoft.Model.JPStructure.MDingDanInfo info)
        {
            #region 创建请求实体
            string xingMing = string.Empty;
            string zhengJianHao = string.Empty;
            string shiFouDaYinXingChengDan = string.Empty;
            string daYinXingChengDan = "0";
            if (info.ShiFuDaYinXingChengDan == EyouSoft.Model.JPStructure.ShiFuDaYinXingChengDan.是) daYinXingChengDan = "1";

            foreach (var item in info.ChengKes)
            {
                xingMing += item.XingMing + "|";
                zhengJianHao += item.ZhengJianHao + "|";
                shiFouDaYinXingChengDan += daYinXingChengDan + "|";
            }

            xingMing = xingMing.TrimEnd('|');
            zhengJianHao = zhengJianHao.TrimEnd('|');
            shiFouDaYinXingChengDan = shiFouDaYinXingChengDan.TrimEnd('|');

            var requestInfo = new EyouSoft.Model.JPStructure.MJinRi_Api_XiaDanRequestInfo();
            requestInfo.CaiGouFanDian = info.CaiGouFanDian;
            requestInfo.CangWei = info.CangWei;
            requestInfo.ChengJiRenXingMing = xingMing;
            requestInfo.ChengJiRenZhengJianHao = zhengJianHao;
            string chengKeLeiXing = "A";
            if (info.ChengKeLeiXing == EyouSoft.Model.JPStructure.ChengKeLeiXing.儿童) chengKeLeiXing = "C";
            requestInfo.ChengKeLeiXing = chengKeLeiXing;
            requestInfo.ChuFaChengShiSanZiMa = info.ChuFaChengShiSanZiMa;
            requestInfo.ChuFaRiQi = info.ChuFaRiQi;
            requestInfo.DaoDaChengShiSanZiMa = info.DaoDaChengShiSanZiMa;
            requestInfo.FuWuShangId = string.Empty;
            requestInfo.GongPiaoShangId = info.GongPiaoShangId;
            requestInfo.HangBanHao = info.HangBanHao;
            requestInfo.HangXianLeiXing = ((int)info.HangXianLeiXing).ToString();
            requestInfo.JieShouFangShi = ((int)info.ApiJieShouFangShi).ToString();
            requestInfo.ShiFouYunXuGengHuanPnr = ((int)info.ShiFouYunXuGengHuanPnr).ToString();
            string shiFouZiDongDaiKou = "F";
            if (info.ShiFouZiDongDaiKou == EyouSoft.Model.JPStructure.ShiFouZiDongDaiKou.是) shiFouZiDongDaiKou = "T";
            requestInfo.ShiFouZiDongDaiKou = shiFouZiDongDaiKou;
            requestInfo.ShiFuDaYinXingChengDan = shiFouDaYinXingChengDan;
            requestInfo.ZhengCeId = info.ZhengCeId;
            requestInfo.ZhengCeLeiXing = ((int)info.ZhengCeLeiXing).ToString();

            requestInfo.PNR = info.PNR;
            requestInfo.PnrInfo = info.PnrInfo;
            #endregion

            #region 创建请求XML
            string requestUrl = JinRi_Api_DingDan_Ws + "/CreateOrderByPNR";
            StringBuilder apiChaXunXml = new StringBuilder();
            apiChaXunXml.Append("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
            apiChaXunXml.Append("<JIT-OrderByPNR-Request>");
            apiChaXunXml.AppendFormat("<Request ");
            apiChaXunXml.AppendFormat(" Username=\"{0}\" ", BHangBan.JinRi_Api_Username01);
            apiChaXunXml.AppendFormat(" RateId=\"{0}\" ", requestInfo.GongPiaoShangId);
            apiChaXunXml.AppendFormat(" PolicyId=\"{0}\" ", requestInfo.ZhengCeId);
            apiChaXunXml.AppendFormat(" PNR=\"{0}\" ", requestInfo.PNR);
            apiChaXunXml.AppendFormat(" PnrInfo=\"{0}\" ", requestInfo.PnrInfo);
            apiChaXunXml.AppendFormat(" dotNum=\"{0}\" ", requestInfo.CaiGouFanDian);
            apiChaXunXml.AppendFormat(" Jounery=\"{0}\" ", requestInfo.ShiFuDaYinXingChengDan);
            apiChaXunXml.AppendFormat(" Isfront=\"{0}\" ", requestInfo.JieShouFangShi);
            apiChaXunXml.AppendFormat(" Rateway=\"{0}\" ", requestInfo.ZhengCeLeiXing);
            apiChaXunXml.AppendFormat(" Voyagetype=\"{0}\" ", requestInfo.HangXianLeiXing);
            apiChaXunXml.AppendFormat(" isallowPnr=\"{0}\" ", requestInfo.ShiFouYunXuGengHuanPnr);
            apiChaXunXml.AppendFormat(" AutoPay=\"{0}\" ", requestInfo.ShiFouZiDongDaiKou);
            apiChaXunXml.AppendFormat(" PassengerType=\"{0}\" ", requestInfo.ChengKeLeiXing);
            apiChaXunXml.AppendFormat("  SystemId=\"\" ");
            apiChaXunXml.AppendFormat("/>");
            apiChaXunXml.Append("</JIT-OrderByPNR-Request>");
            #endregion

            string requestXml = "xml=" + System.Web.HttpUtility.UrlEncode(apiChaXunXml.ToString());

            var responseString = EyouSoft.Toolkit.request.post(requestUrl, requestXml, "application/x-www-form-urlencoded");

            string responseXml = BHangBan.JinRi_Api_GetReponseXml(responseString);

#if DEBUG
            Utils.WLog("requesturi:" + requestUrl, "/jinrilog/dingdan.log");
            Utils.WLog("request:" + apiChaXunXml.ToString(), "/jinrilog/dingdan.log");
            Utils.WLog("response:" + responseXml, "/jinrilog/dingdan.log");
#endif

            if (string.IsNullOrEmpty(responseXml)) return -1001;

            if (responseXml.Length < 10 || Utils.GetInt(responseXml) > 0) return -10002;

            var xJIT_Order_Response = XElement.Parse(responseXml);
            var xResponse = Utils.GetXElement(xJIT_Order_Response, "Response");
            var xOrderNo = Utils.GetXElement(xResponse, "OrderNo");
            var xPNR = Utils.GetXElement(xResponse, "PNR");

            var xStayDiscount = Utils.GetXElement(xResponse, "StayDiscount");
            var xGrowDiscount = Utils.GetXElement(xResponse, "GrowDiscount");
            var xPayMoney = Utils.GetXElement(xResponse, "PayMoney");
            var xProfit = Utils.GetXElement(xResponse, "Profit");
            var xStatus = Utils.GetXElement(xResponse, "Status");
            var xDate = Utils.GetXElement(xResponse, "Date");
            var xScity = Utils.GetXElement(xResponse, "Scity");
            var xEcity = Utils.GetXElement(xResponse, "Ecity");
            var xFlight = Utils.GetXElement(xResponse, "Flight");
            var xStime = Utils.GetXElement(xResponse, "Stime");
            var xEtime = Utils.GetXElement(xResponse, "Etime");
            var xCabin = Utils.GetXElement(xResponse, "Cabin");
            var xPrice = Utils.GetXElement(xResponse, "Price");
            var xTax = Utils.GetXElement(xResponse, "Tax");
            var xPCount = Utils.GetXElement(xResponse, "PCount");
            var xPName = Utils.GetXElement(xResponse, "PName");
            var xPCard = Utils.GetXElement(xResponse, "PCard");
            var xJouneryInfo = Utils.GetXElement(xResponse, "JouneryInfo");
            var xIsBuyInsurance = Utils.GetXElement(xResponse, "JouneryInfo");

            info.ApiDingDanId = Utils.GetXElementValue(xOrderNo);
            info.JinE = Utils.GetDecimal(Utils.GetXElementValue(xPayMoney));
            info.KeHuYouHuiDian = Utils.GetDecimal(Utils.GetXElementValue(xGrowDiscount));
            info.JingXiaoShangLiRunDian = Utils.GetDecimal(Utils.GetXElementValue(xStayDiscount));
            info.JingXiaoShangLiRun = Utils.GetDecimal(Utils.GetXElementValue(xProfit));
            info.PiaoMianJiaGe = Utils.GetDecimal(Utils.GetXElementValue(xPrice));
            info.ShuiFeiJinE = Utils.GetDecimal(Utils.GetXElementValue(xTax));
            info.PNR = Utils.GetXElementValue(xPNR);

            return 1;
        }

        /// <summary>
        /// 今日天下通API-取消订单，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int JinRi_Api_QuXiao(EyouSoft.Model.JPStructure.MDingDanInfo info)
        {
            #region 创建请求xml
            string requestUrl = JinRi_Api_DingDan_Ws + "/CancelOrder";
            StringBuilder apiChaXunXml = new StringBuilder();
            apiChaXunXml.Append("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
            apiChaXunXml.Append("<JIT-CancelOrder>");
            apiChaXunXml.AppendFormat("<Request ");
            apiChaXunXml.AppendFormat(" Username=\"{0}\" ", BHangBan.JinRi_Api_Username01);
            apiChaXunXml.AppendFormat(" OrderNo=\"{0}\" ", info.ApiDingDanId);
            apiChaXunXml.AppendFormat(" PNR=\"{0}\" ", info.PNR);
            apiChaXunXml.AppendFormat(" PayType=\"{0}\" ", "ZFB");
            apiChaXunXml.AppendFormat(" CanBeizhu=\"{0}\" ", info.QuXiaoBeiZhu);
            apiChaXunXml.AppendFormat("  SystemId=\"\" ");
            apiChaXunXml.AppendFormat("/>");
            apiChaXunXml.Append("</JIT-CancelOrder>");
            #endregion

            string requestXml = "xml=" + System.Web.HttpUtility.UrlEncode(apiChaXunXml.ToString());

            var responseString = EyouSoft.Toolkit.request.post(requestUrl, requestXml, "application/x-www-form-urlencoded");

            string responseXml = BHangBan.JinRi_Api_GetReponseXml(responseString);

#if DEBUG
            Utils.WLog("requesturi:" + requestUrl, "/jinrilog/dingdan.log");
            Utils.WLog("request:" + apiChaXunXml.ToString(), "/jinrilog/dingdan.log");
            Utils.WLog("response:" + responseXml, "/jinrilog/dingdan.log");
#endif

            if (string.IsNullOrEmpty(responseXml)) return -1001;

            if (responseXml.Length < 10 || Utils.GetInt(responseXml) > 0) return -10002;

            var xJIT_Order_Response = XElement.Parse(responseXml);
            var xResponse = Utils.GetXElements(xJIT_Order_Response, "Response");

            return 1;
        }

        /// <summary>
        /// 今日天下通API-退废，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int JinRi_Api_TuiFei(EyouSoft.Model.JPStructure.MDingDanInfo info)
        {
            #region 创建请求xml
            string requestUrl = JinRi_Api_DingDan_Ws + "/TuiFeiOrder";
            StringBuilder apiChaXunXml = new StringBuilder();
            apiChaXunXml.Append("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
            apiChaXunXml.Append("<JIT-CancelOrder>");
            apiChaXunXml.AppendFormat("<Request ");
            apiChaXunXml.AppendFormat(" Username=\"{0}\" ", BHangBan.JinRi_Api_Username01);
            apiChaXunXml.AppendFormat(" OrderNo=\"{0}\" ", info.ApiDingDanId);
            apiChaXunXml.AppendFormat(" PNR=\"{0}\" ", info.PNR);
            apiChaXunXml.AppendFormat(" PayType=\"{0}\" ", "ZFB");
            apiChaXunXml.AppendFormat(" CanBeizhu=\"{0}\" ", info.QuXiaoBeiZhu);
            apiChaXunXml.AppendFormat("  SystemId=\"\" ");
            apiChaXunXml.AppendFormat("/>");
            apiChaXunXml.Append("</JIT-CancelOrder>");




            apiChaXunXml.Append("<JIT-TuiFeiOrder-Request>");
            apiChaXunXml.AppendFormat("<Request name=\"{0}\"", BHangBan.JinRi_Api_Username01);
            apiChaXunXml.AppendFormat("SystemId=\"\"");
            apiChaXunXml.AppendFormat("type=\"B\" ");
            apiChaXunXml.AppendFormat("OrderNo=\"{0}\"", info.ApiDingDanId);
            apiChaXunXml.AppendFormat("Repeal=\"{0}\"", info.DingPiaoRenShu);
            apiChaXunXml.AppendFormat("personName=\"{0}\"", info.HuiYuanId);
            apiChaXunXml.AppendFormat("isCancelSeat=\"是\" ");
            apiChaXunXml.AppendFormat("Cause=\"B\"");
            apiChaXunXml.AppendFormat("Remarks=\"按客规自愿退票\"");
            apiChaXunXml.AppendFormat("Rnum=\"{0}\" ", info.DingPiaoRenShu);
            apiChaXunXml.AppendFormat("TicketNo=\"333333333333333\"", info.DingDanStatus);
            apiChaXunXml.AppendFormat("Ramount=\"{0}\"", info.JinE + info.ShuiFeiJinE);
            apiChaXunXml.AppendFormat("/> ");
            apiChaXunXml.Append("</JIT-TuiFeiOrder-Request>");


            return 0;
            #endregion

            string requestXml = "xml=" + System.Web.HttpUtility.UrlEncode(apiChaXunXml.ToString());

            var responseString = EyouSoft.Toolkit.request.post(requestUrl, requestXml, "application/x-www-form-urlencoded");

            string responseXml = BHangBan.JinRi_Api_GetReponseXml(responseString);

#if DEBUG
            //Utils.WLog("requesturi:" + requestUrl, "/jinrilog/dingdan.log");
            //Utils.WLog("request:" + apiChaXunXml.ToString(), "/jinrilog/dingdan.log");
            //Utils.WLog("response:" + responseXml, "/jinrilog/dingdan.log");
#endif

            if (string.IsNullOrEmpty(responseXml)) return -1001;

            if (responseXml.Length < 10 || Utils.GetInt(responseXml) > 0) return -10002;

            var xJIT_Order_Response = XElement.Parse(responseXml);
            var xResponse = Utils.GetXElements(xJIT_Order_Response, "Response");

            return 1;
        }

        /// <summary>
        /// 今日天下通API-创建儿童PNR
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        EyouSoft.Model.JPStructure.MJinRi_Api_CreateErTongPnrResponseInfo JinRi_Api_CreateErTongPnr(EyouSoft.Model.JPStructure.MDingDanInfo info)
        {
            var retInfo = new EyouSoft.Model.JPStructure.MJinRi_Api_CreateErTongPnrResponseInfo();
            retInfo.RetCode = "-1";

            #region 创建请求xml
            string requestUrl = JinRi_Api_DingDan_Ws + "/CreateChdPNR";

            string xingMing = string.Empty;
            string zhengJianHao = string.Empty;

            foreach (var item in info.ChengKes)
            {
                xingMing += item.XingMing + "CHD|";
                zhengJianHao += item.ChuShengRiQi.ToString("yyyyMMdd") + "|";
            }

            xingMing = xingMing.TrimEnd('|');
            zhengJianHao = zhengJianHao.TrimEnd('|');

            StringBuilder apiChaXunXml = new StringBuilder();
            apiChaXunXml.Append("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
            apiChaXunXml.Append("<JIT-CreateOrder>");
            apiChaXunXml.AppendFormat("<Request ");
            apiChaXunXml.AppendFormat(" Username=\"{0}\" ", BHangBan.JinRi_Api_Username01);
            apiChaXunXml.AppendFormat(" AdultPNR=\"{0}\" ", info.PNR);
            apiChaXunXml.AppendFormat(" Cabin=\"{0}\" ", info.CangWei);
            apiChaXunXml.AppendFormat(" Count=\"{0}\" ", info.DingPiaoRenShu);
            apiChaXunXml.AppendFormat(" ChdNameLst=\"{0}\" ", xingMing);
            apiChaXunXml.AppendFormat("  ChdCardIdLst=\"{0}\" ", zhengJianHao);
            apiChaXunXml.AppendFormat("/>");
            apiChaXunXml.Append("</JIT-CreateOrder>");
            #endregion

            string requestXml = "xml=" + System.Web.HttpUtility.UrlEncode(apiChaXunXml.ToString());

            var responseString = EyouSoft.Toolkit.request.post(requestUrl, requestXml, "application/x-www-form-urlencoded");

            string responseXml = BHangBan.JinRi_Api_GetReponseXml(responseString);

#if DEBUG
            Utils.WLog("requesturi:" + requestUrl, "/jinrilog/dingdan.log");
            Utils.WLog("request:" + apiChaXunXml.ToString(), "/jinrilog/dingdan.log");
            Utils.WLog("response:" + responseXml, "/jinrilog/dingdan.log");
#endif

            if (string.IsNullOrEmpty(responseXml))
            {
                retInfo.RetCode = "-10001";
                return retInfo;
            }

            if (responseXml.Length < 10 || Utils.GetInt(responseXml) > 0)
            {
                retInfo.RetCode = "-10002";
                return retInfo;
            }

            var xJIT_Order_Response = XElement.Parse(responseXml);
            var xResponse = Utils.GetXElement(xJIT_Order_Response, "Response");
            var xPNR = Utils.GetXElement(xResponse, "PNR");
            var xPnrInfo = Utils.GetXElement(xResponse, "PnrInfo");

            retInfo.Pnr = Utils.GetXElementValue(xPNR);
            retInfo.PnrInfo = Utils.GetXElementValue(xPnrInfo);
            retInfo.PnrInfo = retInfo.PnrInfo.TrimEnd('|');

            retInfo.RetCode = "1";

            return retInfo;
        }

        /// <summary>
        /// 今日天下通API-获取订单信息-按Api订单号
        /// </summary>
        /// <param name="apiDingDanId">API订单号</param>
        /// <returns></returns>
        EyouSoft.Model.JPStructure.MJinRi_Api_DingDanInfo JinRi_Api_GetDingDanInfo(string apiDingDanId)
        {
            #region 创建请求xml
            string requestUrl = JinRi_Api_DingDan_Ws + "/GetOrderInfo";
            StringBuilder apiChaXunXml = new StringBuilder();
            apiChaXunXml.Append("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
            apiChaXunXml.Append("<JIT-Order-Request>");
            apiChaXunXml.AppendFormat("<Request ");
            apiChaXunXml.AppendFormat(" Username=\"{0}\" ", BHangBan.JinRi_Api_Username01);
            apiChaXunXml.AppendFormat(" orderno=\"{0}\" ", apiDingDanId);
            apiChaXunXml.AppendFormat("  SystemId=\"\" ");
            apiChaXunXml.AppendFormat("/>");
            apiChaXunXml.Append("</JIT-Order-Request>");
            #endregion

            string requestXml = "xml=" + System.Web.HttpUtility.UrlEncode(apiChaXunXml.ToString());

            var responseString = EyouSoft.Toolkit.request.post(requestUrl, requestXml, "application/x-www-form-urlencoded");

            string responseXml = BHangBan.JinRi_Api_GetReponseXml(responseString);

#if DEBUG
            Utils.WLog("requesturi:" + requestUrl, "/jinrilog/dingdan.log");
            Utils.WLog("request:" + apiChaXunXml.ToString(), "/jinrilog/dingdan.log");
            Utils.WLog("response:" + responseXml, "/jinrilog/dingdan.log");
#endif

            if (string.IsNullOrEmpty(responseXml)) return null;

            if (responseXml.Length < 10 || Utils.GetInt(responseXml) > 0) return null;

            var xJIT_Order_Response = XElement.Parse(responseXml);
            var xResponse = Utils.GetXElement(xJIT_Order_Response, "Response");
            var xOrderNo = Utils.GetXElement(xResponse, "OrderNo");
            var xPNR = Utils.GetXElement(xResponse, "PNR");
            var xGrowDiscount = Utils.GetXElement(xResponse, "GrowDiscount");
            var xStayDiscount = Utils.GetXElement(xResponse, "StayDiscount");
            var xPayMoney = Utils.GetXElement(xResponse, "PayMoney");
            var xProfit = Utils.GetXElement(xResponse, "Profit");
            var xStatus = Utils.GetXElement(xResponse, "Status");
            var xRateID = Utils.GetXElement(xResponse, "RateID");
            var xDate = Utils.GetXElement(xResponse, "Date");
            var xScity = Utils.GetXElement(xResponse, "Scity");
            var xEcity = Utils.GetXElement(xResponse, "Ecity");
            var xFlight = Utils.GetXElement(xResponse, "Flight");
            var xStime = Utils.GetXElement(xResponse, "Stime");
            var xEtime = Utils.GetXElement(xResponse, "Etime");
            var xCabin = Utils.GetXElement(xResponse, "Cabin");
            var xPrice = Utils.GetXElement(xResponse, "Price");
            var xTax = Utils.GetXElement(xResponse, "Tax");
            var xPCount = Utils.GetXElement(xResponse, "PCount");
            var xPName = Utils.GetXElement(xResponse, "PName");
            var xOrderTime = Utils.GetXElement(xResponse, "OrderTime");
            var xPayTime = Utils.GetXElement(xResponse, "PayTime");
            var xCanTime = Utils.GetXElement(xResponse, "CanTime");
            var xRtime = Utils.GetXElement(xResponse, "Rtime");
            var xRepeal = Utils.GetXElement(xResponse, "Repeal");
            var xOutTime = Utils.GetXElement(xResponse, "OutTime");
            var xOverTime = Utils.GetXElement(xResponse, "OverTime");
            var xPayWay = Utils.GetXElement(xResponse, "PayWay");
            var xRCount = Utils.GetXElement(xResponse, "RCount");
            var xRInfo = Utils.GetXElement(xResponse, "RInfo");
            var xRMoney = Utils.GetXElement(xResponse, "RMoney");
            var xTicketNo = Utils.GetXElement(xResponse, "TicketNo");
            var xTicketType = Utils.GetXElement(xResponse, "TicketType");
            var xCardNo = Utils.GetXElement(xResponse, "CardNo");
            var xCause = Utils.GetXElement(xResponse, "Cause");
            var xRemark = Utils.GetXElement(xResponse, "Remark");
            var xExplain = Utils.GetXElement(xResponse, "Explain");
            var xMessage = Utils.GetXElement(xResponse, "Message");
            var xZcpTime = Utils.GetXElement(xResponse, "ZcpTime");
            var xZfpTime = Utils.GetXElement(xResponse, "ZfpTime");
            var xZtpTime = Utils.GetXElement(xResponse, "ZtpTime");
            var xNoCancel = Utils.GetXElement(xResponse, "NoCancel");
            var xRlog = Utils.GetXElement(xResponse, "Rlog");
            var xCheckTime = Utils.GetXElement(xResponse, "CheckTime");
            var xZhuanQianStatus = Utils.GetXElement(xResponse, "ZhuanQianStatus");
            var xZhuanQianStr = Utils.GetXElement(xResponse, "ZhuanQianStr");
            var xZhuanQianReplyStr = Utils.GetXElement(xResponse, "ZhuanQianReplyStr");
            var xFlightDallyTime = Utils.GetXElement(xResponse, "FlightDallyTime");
            var xFlightDallyMark = Utils.GetXElement(xResponse, "FlightDallyMark");
            var xProxyerID = Utils.GetXElement(xResponse, "ProxyerID");
            var xProviderId = Utils.GetXElement(xResponse, "ProviderId");
            var xJourneyTicket = Utils.GetXElement(xResponse, "JourneyTicket");
            var xTradeNo = Utils.GetXElement(xResponse, "TradeNo");
            var xFuelTax = Utils.GetXElement(xResponse, "FuelTax");
            var xAirportTax = Utils.GetXElement(xResponse, "AirportTax");
            var xOfficeNum = Utils.GetXElement(xResponse, "OfficeNum");

            var info = new EyouSoft.Model.JPStructure.MJinRi_Api_DingDanInfo();

            info.ApiDingDanId = Utils.GetXElementValue(xOrderNo);
            info.PNR = Utils.GetXElementValue(xPNR);
            info.KeHuYouHuiDian = Utils.GetDecimal(Utils.GetXElementValue(xGrowDiscount));
            info.JingXiaoShangLiRunDian = Utils.GetDecimal(Utils.GetXElementValue(xStayDiscount));
            info.JinE = Utils.GetDecimal(Utils.GetXElementValue(xPayMoney));
            info.JingXiaoShangLiRun = Utils.GetDecimal(Utils.GetXElementValue(xProfit));
            info.ApiStatus = Utils.GetXElementValue(xStatus);
            info.ZhengCeId = Utils.GetXElementValue(xRateID);
            info.HangBanRiQi = Utils.GetDateTime(Utils.GetXElementValue(xDate));
            info.ChuFaChengShiSanZiMa = Utils.GetXElementValue(xScity);
            info.DaoDaChengShiSanZiMa = Utils.GetXElementValue(xEcity);
            info.HangBanHao = Utils.GetXElementValue(xFlight);
            info.QiFeiShiJian = Utils.GetXElementValue(xStime);
            info.DaoDaShiJian = Utils.GetXElementValue(xEtime);
            info.CangWei = Utils.GetXElementValue(xCabin);
            info.PiaoMianJiaGe = Utils.GetDecimal(Utils.GetXElementValue(xPrice));
            info.ShuiFeiJinE = Utils.GetDecimal(Utils.GetXElementValue(xTax));
            info.DingPiaoRenShu = Utils.GetInt(Utils.GetXElementValue(xPCount));
            info.ChengKeXingMing = Utils.GetXElementValue(xPName);
            info.ApiXiaDanShiJian = Utils.GetDateTime(Utils.GetXElementValue(xOrderTime));
            info.ZhiFuShiJian = Utils.GetDateTime(Utils.GetXElementValue(xPayTime));
            info.QuXiaoShiJian = Utils.GetDateTime(Utils.GetXElementValue(xCanTime));
            info.TuiKuanShiJian = Utils.GetDateTime(Utils.GetXElementValue(xRtime));
            info.TuiKuanShuoMing = Utils.GetXElementValue(xRepeal);
            info.ChuPiaoShiJian = Utils.GetDateTime(Utils.GetXElementValue(xOutTime));
            info.TuiFeiPiaoChuLiShiJian = Utils.GetDateTime(Utils.GetXElementValue(xOverTime));
            info.ApiZhiFuFangShi = Utils.GetXElementValue(xPayWay);
            info.TuiFeiPiaoRenShu = Utils.GetInt(Utils.GetXElementValue(xRCount));
            info.TuiFeiPiaoShuoMing = Utils.GetXElementValue(xRInfo);
            info.ShiJiTuiKuanJinE = Utils.GetDecimal(Utils.GetXElementValue(xRMoney));
            info.PiaoHao = Utils.GetXElementValue(xTicketNo);
            info.KePiaoLeiXing = Utils.GetXElementValue(xTicketType);
            info.ZhengJianHao = Utils.GetXElementValue(xCardNo);
            info.TuiFeiPiaoYuanYin = Utils.GetXElementValue(xCause);
            info.TuiFeiPiaoBeiZhu = Utils.GetXElementValue(xRemark);
            info.BuChuPiaoYuanYin = Utils.GetXElementValue(xExplain);
            info.BuChuPiaoXiaoXi = Utils.GetXElementValue(xMessage);
            info.BuChuPiaoShiJian = Utils.GetXElementValue(xZcpTime);
            info.BuFeiPiaoShiJian = Utils.GetXElementValue(xZfpTime);
            info.BuTuiPiaoShiJian = Utils.GetXElementValue(xZtpTime);
            info.BuNengTuiPiao = Utils.GetXElementValue(xNoCancel);
            info.TuiKuanJiLu = Utils.GetXElementValue(xRlog);
            info.ShenHeShiJian = Utils.GetXElementValue(xCheckTime);
            info.GaiQianStatus = Utils.GetXElementValue(xZhuanQianStatus);
            info.GaiQianShuoMing = Utils.GetXElementValue(xZhuanQianStr);
            info.GaiQianHuiFu = Utils.GetXElementValue(xZhuanQianReplyStr);
            info.HangBanYanWuShiJian = Utils.GetXElementValue(xFlightDallyTime);
            info.HangBanYanWuShuoMing = Utils.GetXElementValue(xFlightDallyMark);
            info.CaiGouShangId = Utils.GetXElementValue(xProxyerID);
            info.GongYingShangId = Utils.GetXElementValue(xProviderId);
            info.XingChengDanXinXi = Utils.GetXElementValue(xJourneyTicket);
            info.ZhiFuBaoJiaoYiHao = Utils.GetXElementValue(xTradeNo);
            info.JiJianJinE = Utils.GetDecimal(Utils.GetXElementValue(xAirportTax));
            info.RanYouJinE = Utils.GetDecimal(Utils.GetXElementValue(xFuelTax));

            return info;
        }

        /// <summary>
        /// 今日天下通API-代扣支付订单，返回1成功，其它失败
        /// </summary>
        /// <param name="apiDingDanId">API订单号</param>
        /// <returns></returns>
        int JinRi_Api_DaiKouZhiFuDingDan(string apiDingDanId)
        {
            #region 创建请求xml
            string requestUrl = JinRi_Api_DingDanZhiFu_Ws + "/AutoPayOrder";
            StringBuilder apiChaXunXml = new StringBuilder();
            apiChaXunXml.Append("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
            apiChaXunXml.Append("<JIT-AutoPay-Request>");
            apiChaXunXml.AppendFormat("<Request ");
            apiChaXunXml.AppendFormat(" Username=\"{0}\" ", BHangBan.JinRi_Api_Username01);
            apiChaXunXml.AppendFormat(" orderno=\"{0}\" ", apiDingDanId);
            apiChaXunXml.AppendFormat("  SystemId=\"\" ");
            apiChaXunXml.AppendFormat("/>");
            apiChaXunXml.Append("</JIT-AutoPay-Request>");
            #endregion

            string requestXml = "xml=" + System.Web.HttpUtility.UrlEncode(apiChaXunXml.ToString());

            var responseString = EyouSoft.Toolkit.request.post(requestUrl, requestXml, "application/x-www-form-urlencoded");

            string responseXml = BHangBan.JinRi_Api_GetReponseXml(responseString);

#if DEBUG
            Utils.WLog("requesturi:" + requestUrl, "/jinrilog/dingdan.log");
            Utils.WLog("request:" + apiChaXunXml.ToString(), "/jinrilog/dingdan.log");
            Utils.WLog("response:" + responseXml, "/jinrilog/dingdan.log");
#endif

            if (string.IsNullOrEmpty(responseXml)) return -10001;

            if (responseXml.Length < 10 || Utils.GetInt(responseXml) > 0) return -10002;

            var xJIT_AutoPay_Order = XElement.Parse(responseXml);
            var xResult = Utils.GetXElement(xJIT_AutoPay_Order, "Result");
            var apiResult = Utils.GetXElementValue(xResult);
            var apiErrMsg = Utils.GetXAttributeValue(xResult, "errMsg");

            if (apiResult == "T")
            {
                return 1;
            }

            return -10003;
        }
        #endregion

        #region public members
        /// <summary>
        /// 创建订单，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int DingDan_C(EyouSoft.Model.JPStructure.MDingDanInfo info)
        {
            if (info == null
                || string.IsNullOrEmpty(info.HuiYuanId)
                || string.IsNullOrEmpty(info.ZhengCeId)
                || string.IsNullOrEmpty(info.GongPiaoShangId)
                || string.IsNullOrEmpty(info.ChuFaChengShiSanZiMa)
                || string.IsNullOrEmpty(info.DaoDaChengShiSanZiMa)
                || string.IsNullOrEmpty(info.HangBanHao)
                || string.IsNullOrEmpty(info.CangWei)
                || info.ChuFaRiQi < DateTime.Today
                || info.CaiGouFanDian < 0) return 0;

            if (info.ChengKes == null || info.ChengKes.Count == 0) return -1;

            IList<EyouSoft.Model.JPStructure.MChengKeInfo> chengRenChengKes = new List<EyouSoft.Model.JPStructure.MChengKeInfo>();
            IList<EyouSoft.Model.JPStructure.MChengKeInfo> erTongChengKes = new List<EyouSoft.Model.JPStructure.MChengKeInfo>();
            foreach (var item in info.ChengKes)
            {
                if (string.IsNullOrEmpty(item.XingMing) || string.IsNullOrEmpty(item.ZhengJianHao)) continue;

                item.ChengKeId = Guid.NewGuid().ToString();

                if (item.ChengKeLeiXing == EyouSoft.Model.JPStructure.ChengKeLeiXing.成人) chengRenChengKes.Add(item);
                if (item.ChengKeLeiXing == EyouSoft.Model.JPStructure.ChengKeLeiXing.儿童) erTongChengKes.Add(item);
            }

            if (chengRenChengKes.Count + erTongChengKes.Count == 0) return -2;
            if (chengRenChengKes.Count == 0 && erTongChengKes.Count > 0) return -3;

            if (erTongChengKes.Count > 0)
            {
                var erTongCangWei = new string[] { "Y", "C", "F" };
                if (!erTongCangWei.Contains(info.CangWei)) return -4;
            }

            info.XiaDanShiJian = info.XiangApiFuKuanShiJian = info.FuKuanShiJian = DateTime.Now;
            info.DingDanStatus = EyouSoft.Model.JPStructure.DingDanStatus.等待支付;
            info.FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款;
            info.XiangApiFuKuanStatus = EyouSoft.Model.JPStructure.XiangApiFuKuanStatus.未支付;

            var chengRenDingDanInfo = (EyouSoft.Model.JPStructure.MDingDanInfo)info.Clone();
            chengRenDingDanInfo.DingDanId = Guid.NewGuid().ToString();
            chengRenDingDanInfo.ChengKeLeiXing = EyouSoft.Model.JPStructure.ChengKeLeiXing.成人;
            chengRenDingDanInfo.ChengKes = chengRenChengKes;
            chengRenDingDanInfo.ChengRenDingDanId = "";
            chengRenDingDanInfo.DingPiaoRenShu = chengRenChengKes.Count;
            chengRenDingDanInfo.ErTongDingDanId = "";

            var erTongDingDanInfo = (EyouSoft.Model.JPStructure.MDingDanInfo)info.Clone();
            erTongDingDanInfo.DingDanId = Guid.NewGuid().ToString();
            erTongDingDanInfo.ChengKeLeiXing = EyouSoft.Model.JPStructure.ChengKeLeiXing.儿童;
            erTongDingDanInfo.ChengKes = erTongChengKes;
            erTongDingDanInfo.ChengRenDingDanId = "";
            erTongDingDanInfo.DingPiaoRenShu = erTongChengKes.Count;
            erTongDingDanInfo.ErTongDingDanId = "";

            //有儿童单设置成人儿童单关系
            if (erTongDingDanInfo.DingPiaoRenShu > 0)
            {
                chengRenDingDanInfo.ErTongDingDanId = erTongDingDanInfo.DingDanId;
                erTongDingDanInfo.ChengRenDingDanId = chengRenDingDanInfo.DingDanId;
            }

            //获取成人政策
            var chengRenZhengCeInfo = GetChengRenZhengCeInfo(chengRenDingDanInfo);
            if (chengRenZhengCeInfo == null) return -5;

            //API创建成人订单
            int chengRenXiaDanApiRetCode = JinRi_Api_CreateDingDan(chengRenDingDanInfo);

            if (chengRenXiaDanApiRetCode != 1) return -6;

            IList<EyouSoft.Model.JPStructure.MDingDanXiangGuanInfo> dingDanXingGuanItems = new List<EyouSoft.Model.JPStructure.MDingDanXiangGuanInfo>();
            dingDanXingGuanItems.Add(new EyouSoft.Model.JPStructure.MDingDanXiangGuanInfo() { DingDanId = chengRenDingDanInfo.DingDanId, LeiXing = "HANGBAN", JSON = Newtonsoft.Json.JsonConvert.SerializeObject(chengRenDingDanInfo.HangBanInfo) });
            dingDanXingGuanItems.Add(new EyouSoft.Model.JPStructure.MDingDanXiangGuanInfo() { DingDanId = chengRenDingDanInfo.DingDanId, LeiXing = "ZHENGCE", JSON = Newtonsoft.Json.JsonConvert.SerializeObject(chengRenZhengCeInfo) });

            //有儿童
            if (erTongDingDanInfo.DingPiaoRenShu > 0)
            {
                //设置儿童订单成人PNR以创建儿童PNR
                erTongDingDanInfo.PNR = chengRenDingDanInfo.PNR;
                //API创建儿童PNR
                var erTongPnrInfo = JinRi_Api_CreateErTongPnr(erTongDingDanInfo);

                if (erTongPnrInfo == null || erTongPnrInfo.RetCode != "1") return -7;

                erTongDingDanInfo.PNR = erTongPnrInfo.Pnr;
                erTongDingDanInfo.PnrInfo = erTongPnrInfo.PnrInfo;

                //获取儿童政策
                var erTongZhengCeInfo = GetErTongZhengCeInfo(erTongDingDanInfo);
                if (erTongZhengCeInfo == null) return -8;

                //
                erTongDingDanInfo.GongPiaoShangId = erTongZhengCeInfo.GongPiaoShangId;
                erTongDingDanInfo.ZhengCeId = erTongZhengCeInfo.ZhengCeId;
                erTongDingDanInfo.CaiGouFanDian = Utils.GetDecimal(erTongZhengCeInfo.ZhengCeFanDian);

                //API创建儿童订单                
                int erTongDingDanApiRetCode = JinRi_Api_CreateDingDanByPnr(erTongDingDanInfo);

                if (erTongDingDanApiRetCode != 1) return -9;

                dingDanXingGuanItems.Add(new EyouSoft.Model.JPStructure.MDingDanXiangGuanInfo() { DingDanId = erTongDingDanInfo.DingDanId, LeiXing = "HANGBAN", JSON = Newtonsoft.Json.JsonConvert.SerializeObject(chengRenDingDanInfo.HangBanInfo) });
                dingDanXingGuanItems.Add(new EyouSoft.Model.JPStructure.MDingDanXiangGuanInfo() { DingDanId = erTongDingDanInfo.DingDanId, LeiXing = "ZHENGCE", JSON = Newtonsoft.Json.JsonConvert.SerializeObject(erTongZhengCeInfo) });
                dingDanXingGuanItems.Add(new EyouSoft.Model.JPStructure.MDingDanXiangGuanInfo() { DingDanId = erTongDingDanInfo.DingDanId, LeiXing = "PNRINFO", JSON = Newtonsoft.Json.JsonConvert.SerializeObject(erTongPnrInfo) });
            }

            //写系统成人订单
            int chengRenXiaDanDalRetCode = dal.DingDan_C(chengRenDingDanInfo);

            //写系统儿童订单
            if (chengRenXiaDanDalRetCode == 1 && erTongDingDanInfo.DingPiaoRenShu > 0)
            {
                erTongDingDanInfo.XiaDanShiJian = DateTime.Now;
                int erTongXiaDanDalRetCode = dal.DingDan_C(erTongDingDanInfo);

                if (erTongXiaDanDalRetCode != 1)
                {
                    dal.DingDan_D(chengRenDingDanInfo.DingDanId);

                    return -10;
                }
            }

            //写订单相关信息
            dal.DingDanXiangGuan_C(dingDanXingGuanItems);

            return 1;
        }

        /// <summary>
        /// 获取订单信息业务实体
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        public EyouSoft.Model.JPStructure.MDingDanInfo GetInfo(string dingDanId)
        {
            if (string.IsNullOrEmpty(dingDanId)) return null;
            var info = dal.GetInfo(dingDanId);

            if (info == null) return null;

            var apiDingDanInfo = JinRi_Api_GetDingDanInfo(info.ApiDingDanId);

            return info;
        }

        /// <summary>
        /// 设置订单付款状态为已支付（只允许传递成人订单编号，儿童订单会根据成人订单一起处理），返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号（成人订单编号）</param>
        /// <param name="huiYuanId">下单人会员编号</param>
        /// <returns></returns>
        public int SheZhiDingDanYiZhiFu(string dingDanId, string huiYuanId)
        {
            if (string.IsNullOrEmpty(dingDanId) || string.IsNullOrEmpty(huiYuanId)) return 0;

            var info = GetInfo(dingDanId);
            if (info == null) return 0;

            if (info.ChengKeLeiXing == EyouSoft.Model.JPStructure.ChengKeLeiXing.儿童) return -1;

            if (info.FuKuanStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款) return 1;

            int dalRetCode = dal.SheZhiDingDanFuKuanStatus(dingDanId, huiYuanId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款, DateTime.Now, EyouSoft.Model.JPStructure.DingDanStatus.支付成功_平台);

            if (dalRetCode == 1)
            {
                var xiangApiFuKuanJieGuoInfo = XiangApiFuKuan(dingDanId, huiYuanId);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 向API付款，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号（成人订单编号）</param>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        public EyouSoft.Model.JPStructure.MXiangApiFuKuanJieGuoInfo XiangApiFuKuan(string dingDanId, string huiYuanId)
        {
            var jieGuoInfo = new EyouSoft.Model.JPStructure.MXiangApiFuKuanJieGuoInfo();
            if (string.IsNullOrEmpty(dingDanId) || string.IsNullOrEmpty(huiYuanId))
            {
                jieGuoInfo.XiaoXi = "参数错误";
                return jieGuoInfo;
            }

            var chengRenDingDanInfo = GetInfo(dingDanId);
            if (chengRenDingDanInfo == null)
            {
                jieGuoInfo.XiaoXi = "参数错误：未找到该订单";
                return jieGuoInfo;
            }

            if (chengRenDingDanInfo.FuKuanStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款)
            {
                jieGuoInfo.XiaoXi = "该订单在平台未付款，暂不能向API申请付款";
                return jieGuoInfo;
            }

            if (chengRenDingDanInfo.ChengKeLeiXing == EyouSoft.Model.JPStructure.ChengKeLeiXing.儿童)
            {
                jieGuoInfo.XiaoXi = "该订单是儿童订单，不能向API申请付款";
                return jieGuoInfo;
            }

            jieGuoInfo.DingDanId1 = chengRenDingDanInfo.DingDanId;

            if (chengRenDingDanInfo.XiangApiFuKuanStatus == EyouSoft.Model.JPStructure.XiangApiFuKuanStatus.已支付)
            {
                jieGuoInfo.XiangApiFuKuanJieGuo1 = "1";
                jieGuoInfo.SheZhiXiangApiFuKuanJieGuo1 = "1";
            }

            if (chengRenDingDanInfo.XiangApiFuKuanStatus == EyouSoft.Model.JPStructure.XiangApiFuKuanStatus.未支付)
            {
                //API成人订单代扣
                int apiChengRenDingDanZhiFuRetCode = JinRi_Api_DaiKouZhiFuDingDan(chengRenDingDanInfo.ApiDingDanId);

                if (apiChengRenDingDanZhiFuRetCode == 1)
                {
                    jieGuoInfo.XiangApiFuKuanJieGuo1 = "1";
                    int sheZhiChengRenDingDanXiangApiFuKuanDalRetCode = dal.SheZhiDingDanXiangApiFuKuanStatus(dingDanId, EyouSoft.Model.JPStructure.XiangApiFuKuanStatus.已支付, DateTime.Now, EyouSoft.Model.JPStructure.DingDanStatus.支付成功);

                    if (sheZhiChengRenDingDanXiangApiFuKuanDalRetCode == 1)
                    {
                        jieGuoInfo.SheZhiXiangApiFuKuanJieGuo1 = "1";
                    }
                    else
                    {
                        jieGuoInfo.SheZhiXiangApiFuKuanJieGuo1 = "-1";
                    }
                }
                else
                {
                    jieGuoInfo.XiangApiFuKuanJieGuo1 = "-2";
                }
            }

            if (string.IsNullOrEmpty(chengRenDingDanInfo.ErTongDingDanId))
            {
                return jieGuoInfo;
            }

            //处理儿童订单
            jieGuoInfo.DingDanId2 = chengRenDingDanInfo.ErTongDingDanId;

            var erTongDingDanInfo = GetInfo(chengRenDingDanInfo.ErTongDingDanId);
            if (erTongDingDanInfo == null)
            {
                jieGuoInfo.XiangApiFuKuanJieGuo2 = "-3";
                jieGuoInfo.SheZhiXiangApiFuKuanJieGuo2 = "-4";
                return jieGuoInfo;
            }

            if (erTongDingDanInfo.XiangApiFuKuanStatus == EyouSoft.Model.JPStructure.XiangApiFuKuanStatus.已支付)
            {
                jieGuoInfo.XiangApiFuKuanJieGuo2 = "1";
                jieGuoInfo.SheZhiXiangApiFuKuanJieGuo2 = "1";
                return jieGuoInfo;
            }

            if (erTongDingDanInfo.XiangApiFuKuanStatus == EyouSoft.Model.JPStructure.XiangApiFuKuanStatus.未支付)
            {
                //API儿童订单代扣
                int apiErTongDingDanZhiFuRetCode = JinRi_Api_DaiKouZhiFuDingDan(erTongDingDanInfo.ApiDingDanId);

                if (apiErTongDingDanZhiFuRetCode == 1)
                {
                    jieGuoInfo.XiangApiFuKuanJieGuo2 = "1";
                    int sheZhiErTongDingDanXiangApiFuKuanDalRetCode = dal.SheZhiDingDanXiangApiFuKuanStatus(erTongDingDanInfo.DingDanId, EyouSoft.Model.JPStructure.XiangApiFuKuanStatus.已支付, DateTime.Now, EyouSoft.Model.JPStructure.DingDanStatus.支付成功);
                    if (sheZhiErTongDingDanXiangApiFuKuanDalRetCode == 1)
                    {
                        jieGuoInfo.SheZhiXiangApiFuKuanJieGuo2 = "1";
                    }
                    else
                    {
                        jieGuoInfo.SheZhiXiangApiFuKuanJieGuo2 = "-5";
                    }
                }
                else
                {
                    jieGuoInfo.XiangApiFuKuanJieGuo2 = "-6";
                    jieGuoInfo.SheZhiXiangApiFuKuanJieGuo2 = "-7";
                }
            }

            return jieGuoInfo;
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="huiYuanId">会员编号</param>
        /// <param name="dingDanStatus">订单状态</param>
        /// <returns></returns>
        public int SheZhiDingDanStatus(string dingDanId, string huiYuanId, EyouSoft.Model.JPStructure.DingDanStatus dingDanStatus)
        {
            if (string.IsNullOrEmpty(dingDanId) || string.IsNullOrEmpty(huiYuanId)) return 0;
            int dalRetCode = dal.SheZhiDingDanStatus(dingDanId, huiYuanId, dingDanStatus);

            return dalRetCode;
        }

        /// <summary>
        /// 获取订单信息业务实体-根据API订单编号
        /// </summary>
        /// <param name="apiDingDanId">API订单编号</param>
        /// <returns></returns>
        public EyouSoft.Model.JPStructure.MDingDanInfo GetInfoByApiDingDanId(string apiDingDanId)
        {
            if (string.IsNullOrEmpty(apiDingDanId)) return null;

            var info = dal.GetInfoByApiDingDanId(apiDingDanId);

            return info;
        }
        #endregion
    }
}
