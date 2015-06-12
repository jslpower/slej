using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EyouSoft.Toolkit;

namespace EyouSoft.BLL.JPStructure
{
    public class BZhengCe
    {
        #region static constants
        //static constants
        const string JinRi_Api_ZhengCe_Ws = "http://ws.jinri.cn/JinRiRateServer.asmx";
        #endregion

        #region private members
        /// <summary>
        /// 今日天下通API-获取政策信息-按政策编号查询
        /// </summary>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        EyouSoft.Model.JPStructure.MZhengCeInfo JinRi_Api_GetZhengCeInfo(EyouSoft.Model.JPStructure.MZhengCeChaXunInfo1 chaXun)
        {
            if (chaXun == null 
                || string.IsNullOrEmpty(chaXun.ChuFaChengShiSanZiMa) 
                || string.IsNullOrEmpty(chaXun.DaoDaChengShiSanZiMa) 
                || string.IsNullOrEmpty(chaXun.ZhengCeId)) return null;

            string requestUrl = JinRi_Api_ZhengCe_Ws + "/GetRateByPolicyID";

            StringBuilder apiChaXunXml = new StringBuilder();
            apiChaXunXml.Append("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
            apiChaXunXml.Append("<JIT-Policy-Request>");
            apiChaXunXml.AppendFormat("<Request ");
            apiChaXunXml.AppendFormat(" Username=\"{0}\" ", BHangBan.JinRi_Api_Username);
            apiChaXunXml.AppendFormat(" scity=\"{0}\" ", chaXun.ChuFaChengShiSanZiMa);
            apiChaXunXml.AppendFormat(" ecity=\"{0}\" ", chaXun.DaoDaChengShiSanZiMa);
            apiChaXunXml.AppendFormat(" PolicyID=\"{0}\" ", chaXun.ZhengCeId);
            apiChaXunXml.AppendFormat("  SystemId=\"\" ");
            apiChaXunXml.AppendFormat("/>");
            apiChaXunXml.Append("</JIT-Policy-Request>");

            string requestXml = "data=" + System.Web.HttpUtility.UrlEncode(apiChaXunXml.ToString());

            var responseString = EyouSoft.Toolkit.request.post(requestUrl, requestXml, "application/x-www-form-urlencoded");

            string responseXml = BHangBan.JinRi_Api_GetReponseXml(responseString);

#if DEBUG
            Utils.WLog("requesturi:" + requestUrl, "/jinrilog/zhengce.log");
            Utils.WLog("request:" + apiChaXunXml.ToString(), "/jinrilog/zhengce.log");
            Utils.WLog("response:" + responseXml, "/jinrilog/zhengce.log");
#endif

            if (string.IsNullOrEmpty(responseXml)) return null;

            if (responseXml.Length < 10 || Utils.GetInt(responseXml) > 0) return null;

            var xJIT_Policy_Response = XElement.Parse(responseXml);
            var xResponse = Utils.GetXElement(xJIT_Policy_Response, "Response");

            var info = new EyouSoft.Model.JPStructure.MZhengCeInfo();

            info.ZhengCeId = Utils.GetXAttributeValue(xResponse, "PolicyId");
            info.GongPiaoShangId = Utils.GetXAttributeValue(xResponse, "RateId");
            info.ChuFaChengShi = Utils.GetXAttributeValue(xResponse, "ScityE");
            info.DaoDaChengShi = Utils.GetXAttributeValue(xResponse, "EcityE");
            info.ShiYongHangKongGongSiErZiMa = Utils.GetXAttributeValue(xResponse, "AirComE");
            info.BuShiYongHangKongGongSiErZiMa = Utils.GetXAttributeValue(xResponse, "NoAirComE");
            info.DiQuXianZhi = Utils.GetXAttributeValue(xResponse, "PolicyType");
            info.CangWei = Utils.GetXAttributeValue(xResponse, "Cabin");
            info.HangXianLeiXing = Utils.GetXAttributeValue(xResponse, "VoyageType");
            info.ChengKeLeiXing = Utils.GetXAttributeValue(xResponse, "UserType");
            info.ZhengCeLeiXing = Utils.GetXAttributeValue(xResponse, "RateType");
            info.ZhengCeFanDian = Utils.GetXAttributeValue(xResponse, "Discounts");
            info.KaiShiRiQi = Utils.GetXAttributeValue(xResponse, "Sdate");
            info.JieShuRiQi = Utils.GetXAttributeValue(xResponse, "Edate");
            info.ShangBanShiJian = Utils.GetXAttributeValue(xResponse, "WorkTimBegin");
            info.XiaBanShiJian = Utils.GetXAttributeValue(xResponse, "WorkTImeEnd");
            info.JiangLiDian = Utils.GetXAttributeValue(xResponse, "Rewards");
            info.ZhengCeBeiZhu = Utils.GetXAttributeValue(xResponse, "Remark");
            info.ChuPiaoLeiXing = Utils.GetXAttributeValue(xResponse, "ET");
            info.XingQi = Utils.GetXAttributeValue(xResponse, "WP");
            info.ChuPiaoSuDu = Utils.GetXAttributeValue(xResponse, "SP");
            info.PingTaiGuanLiFei = Utils.GetXAttributeValue(xResponse, "XF");
            info.CuXiaoFanDian = Utils.GetXAttributeValue(xResponse, "PromotionDiscount");
            info.XinPingTaiZhengCeId = Utils.GetXAttributeValue(xResponse, "NewRateNo");
            info.GongPiaoShangGongZuoHao = Utils.GetXAttributeValue(xResponse, "OfficeNum");
            info.TuiFeiPiaoShangBanShiJian = Utils.GetXAttributeValue(xResponse, "RefundTimeBegin");
            info.TuiFeiPiaoXiaBanShiJian = Utils.GetXAttributeValue(xResponse, "RefundTimeEnd");
            info.ZuiHouGengXinShiJian = Utils.GetXAttributeValue(xResponse, "LastModifyTime");

            return info;
        }

        /// <summary>
        /// 今日天下通API-获取政策信息-按航班查询
        /// </summary>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.JPStructure.MZhengCeInfo> JinRi_Api_GetZhengCes(EyouSoft.Model.JPStructure.MZhengCeChaXunInfo2 chaXun)
        {
            if (chaXun == null
               || string.IsNullOrEmpty(chaXun.ChuFaChengShiSanZiMa)
               || string.IsNullOrEmpty(chaXun.DaoDaChengShiSanZiMa)
               || chaXun.QiFeiRiQi < DateTime.Today
               || chaXun.ZhengCeShuLiang < 1) return null;

            string requestUrl = JinRi_Api_ZhengCe_Ws + "/GetRateList";

            StringBuilder apiChaXunXml = new StringBuilder();
            apiChaXunXml.Append("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
            apiChaXunXml.Append("<JIT-Policy-Request>");
            apiChaXunXml.AppendFormat("<Request ");
            apiChaXunXml.AppendFormat(" Username=\"{0}\" ", BHangBan.JinRi_Api_Username);
            apiChaXunXml.AppendFormat(" sCity=\"{0}\" ", chaXun.ChuFaChengShiSanZiMa);
            apiChaXunXml.AppendFormat(" eCity=\"{0}\" ", chaXun.DaoDaChengShiSanZiMa);
            apiChaXunXml.AppendFormat(" Date=\"{0}\" ", chaXun.QiFeiRiQi.ToString("yyyy-MM-dd"));
            apiChaXunXml.AppendFormat(" Aircome=\"{0}\" ", chaXun.HangKongGongSiErZiMa);
            apiChaXunXml.AppendFormat(" Amount=\"{0}\" ", chaXun.ZhengCeShuLiang);
            apiChaXunXml.AppendFormat(" Cabin=\"{0}\" ", (chaXun.CangWei == "Y" || chaXun.CangWei == "C" || chaXun.CangWei == "F") ? chaXun.CangWei : "A");
            apiChaXunXml.AppendFormat(" Rateway=\"{0}\" ", chaXun.ZhengCeLeiXing);
            apiChaXunXml.AppendFormat(" UserType=\"{0}\" ", chaXun.ChengKeLeiXing);
            apiChaXunXml.AppendFormat(" VoyageType=\"{0}\" ", chaXun.HangXianLeiXing);
            apiChaXunXml.AppendFormat(" FlightNo=\"{0}\" ", chaXun.HangBanHao);
            apiChaXunXml.AppendFormat("  SystemId=\"\" ");
            apiChaXunXml.AppendFormat("/>");
            apiChaXunXml.Append("</JIT-Policy-Request>");

            string requestXml = "data=" + System.Web.HttpUtility.UrlEncode(apiChaXunXml.ToString());

            var responseString = EyouSoft.Toolkit.request.post(requestUrl, requestXml, "application/x-www-form-urlencoded");

            string responseXml = BHangBan.JinRi_Api_GetReponseXml(responseString);

#if DEBUG
            Utils.WLog("requesturi:" + requestUrl, "/jinrilog/zhengce.log");
            Utils.WLog("request:" + apiChaXunXml.ToString(), "/jinrilog/zhengce.log");
            Utils.WLog("response:" + responseXml, "/jinrilog/zhengce.log");
#endif

            if (string.IsNullOrEmpty(responseXml)) return null;

            if (responseXml.Length < 10 || Utils.GetInt(responseXml) > 0) return null;

            var xJIT_Policy_Response = XElement.Parse(responseXml);
            var xResponse = Utils.GetXElements(xJIT_Policy_Response, "Response");

            IList<EyouSoft.Model.JPStructure.MZhengCeInfo> items = new List<EyouSoft.Model.JPStructure.MZhengCeInfo>();

            foreach (var item in xResponse)
            {
                var info = new EyouSoft.Model.JPStructure.MZhengCeInfo();

                info.ZhengCeId = Utils.GetXAttributeValue(item, "PolicyId");
                info.GongPiaoShangId = Utils.GetXAttributeValue(item, "RateId");
                info.ChuFaChengShi = Utils.GetXAttributeValue(item, "ScityE");
                info.DaoDaChengShi = Utils.GetXAttributeValue(item, "EcityE");
                info.ShiYongHangKongGongSiErZiMa = Utils.GetXAttributeValue(item, "AirComE");
                info.BuShiYongHangKongGongSiErZiMa = Utils.GetXAttributeValue(item, "NoAirComE");
                info.DiQuXianZhi = Utils.GetXAttributeValue(item, "PolicyType");
                info.CangWei = Utils.GetXAttributeValue(item, "Cabin");
                info.HangXianLeiXing = Utils.GetXAttributeValue(item, "VoyageType");
                info.ChengKeLeiXing = Utils.GetXAttributeValue(item, "UserType");
                info.ZhengCeLeiXing = Utils.GetXAttributeValue(item, "RateType");
                info.ZhengCeFanDian = Utils.GetXAttributeValue(item, "Discounts");
                info.KaiShiRiQi = Utils.GetXAttributeValue(item, "Sdate");
                info.JieShuRiQi = Utils.GetXAttributeValue(item, "Edate");
                info.ShangBanShiJian = Utils.GetXAttributeValue(item, "WorkTimBegin");
                info.XiaBanShiJian = Utils.GetXAttributeValue(item, "WorkTImeEnd");
                info.JiangLiDian = Utils.GetXAttributeValue(item, "Rewards");
                info.ZhengCeBeiZhu = Utils.GetXAttributeValue(item, "Remark");
                info.ChuPiaoLeiXing = Utils.GetXAttributeValue(item, "ET");
                info.XingQi = Utils.GetXAttributeValue(item, "WP");
                info.ChuPiaoSuDu = Utils.GetXAttributeValue(item, "SP");
                info.PingTaiGuanLiFei = Utils.GetXAttributeValue(item, "XF");
                info.CuXiaoFanDian = Utils.GetXAttributeValue(item, "PromotionDiscount");
                info.XinPingTaiZhengCeId = Utils.GetXAttributeValue(item, "NewRateNo");
                info.GongPiaoShangGongZuoHao = Utils.GetXAttributeValue(item, "OfficeNum");
                info.TuiFeiPiaoShangBanShiJian = Utils.GetXAttributeValue(item, "RefundTimeBegin");
                info.TuiFeiPiaoXiaBanShiJian = Utils.GetXAttributeValue(item, "RefundTimeEnd");
                info.ZuiHouGengXinShiJian = Utils.GetXAttributeValue(item, "LastModifyTime");

                items.Add(info);
            }            

            return items;
        }

        /// <summary>
        /// 今日天下通API-获取政策信息-按PNR查询
        /// </summary>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.JPStructure.MZhengCeInfo> JinRi_Api_GetZhengCes(EyouSoft.Model.JPStructure.MZhengCeChaXunInfo3 chaXun)
        {
            if (chaXun == null
               || string.IsNullOrEmpty(chaXun.PNR)
               || string.IsNullOrEmpty(chaXun.PnrInfo)
               || string.IsNullOrEmpty(chaXun.ChengKeLeiXing)
               || chaXun.ZhengCeShuLiang < 1) return null;

            string requestUrl = JinRi_Api_ZhengCe_Ws + "/GetRateListByPNR";

            StringBuilder apiChaXunXml = new StringBuilder();
            apiChaXunXml.Append("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
            apiChaXunXml.Append("<JIT-Policy-Request>");
            apiChaXunXml.AppendFormat("<Request ");
            apiChaXunXml.AppendFormat(" Username=\"{0}\" ", BHangBan.JinRi_Api_Username);
            apiChaXunXml.AppendFormat(" pnr=\"{0}\" ", chaXun.PNR);
            apiChaXunXml.AppendFormat(" PnrInfo=\"{0}\" ", chaXun.PnrInfo);
            apiChaXunXml.AppendFormat(" Rateway=\"{0}\" ", chaXun.ZhengCeLeiXing);
            apiChaXunXml.AppendFormat(" VoyageType=\"{0}\" ", chaXun.HangBanLeiXing);
            apiChaXunXml.AppendFormat(" PassengerType=\"{0}\" ", chaXun.ChengKeLeiXing);
            apiChaXunXml.AppendFormat(" Amount=\"{0}\" ", chaXun.ZhengCeShuLiang);
            apiChaXunXml.AppendFormat("  SystemId=\"\" ");
            apiChaXunXml.AppendFormat("/>");
            apiChaXunXml.Append("</JIT-Policy-Request>");

            string requestXml = "data=" + System.Web.HttpUtility.UrlEncode(apiChaXunXml.ToString());

            var responseString = EyouSoft.Toolkit.request.post(requestUrl, requestXml, "application/x-www-form-urlencoded");

            string responseXml = BHangBan.JinRi_Api_GetReponseXml(responseString);

#if DEBUG
            Utils.WLog("requesturi:" + requestUrl, "/jinrilog/zhengce.log");
            Utils.WLog("request:" + apiChaXunXml.ToString(), "/jinrilog/zhengce.log");
            Utils.WLog("response:" + responseXml, "/jinrilog/zhengce.log");
#endif

            if (string.IsNullOrEmpty(responseXml)) return null;

            if (responseXml.Length < 10 || Utils.GetInt(responseXml) > 0) return null;

            IList<EyouSoft.Model.JPStructure.MZhengCeInfo> items = new List<EyouSoft.Model.JPStructure.MZhengCeInfo>();

            var xJIT_Policy_Response = XElement.Parse(responseXml);
            var xResponse = Utils.GetXElements(xJIT_Policy_Response, "Response");

            foreach (var item in xResponse)
            {
                var info = new EyouSoft.Model.JPStructure.MZhengCeInfo();

                info.ZhengCeId = Utils.GetXAttributeValue(item, "PolicyId");
                info.GongPiaoShangId = Utils.GetXAttributeValue(item, "RateId");
                info.ChuFaChengShi = Utils.GetXAttributeValue(item, "ScityE");
                info.DaoDaChengShi = Utils.GetXAttributeValue(item, "EcityE");
                info.ShiYongHangKongGongSiErZiMa = Utils.GetXAttributeValue(item, "AirComE");
                info.BuShiYongHangKongGongSiErZiMa = Utils.GetXAttributeValue(item, "NoAirComE");
                info.DiQuXianZhi = Utils.GetXAttributeValue(item, "PolicyType");
                info.CangWei = Utils.GetXAttributeValue(item, "Cabin");
                info.HangXianLeiXing = Utils.GetXAttributeValue(item, "VoyageType");
                info.ChengKeLeiXing = Utils.GetXAttributeValue(item, "UserType");
                info.ZhengCeLeiXing = Utils.GetXAttributeValue(item, "RateType");
                info.ZhengCeFanDian = Utils.GetXAttributeValue(item, "Discounts");
                info.KaiShiRiQi = Utils.GetXAttributeValue(item, "Sdate");
                info.JieShuRiQi = Utils.GetXAttributeValue(item, "Edate");
                info.ShangBanShiJian = Utils.GetXAttributeValue(item, "WorkTimBegin");
                info.XiaBanShiJian = Utils.GetXAttributeValue(item, "WorkTImeEnd");
                info.JiangLiDian = Utils.GetXAttributeValue(item, "Rewards");
                info.ZhengCeBeiZhu = Utils.GetXAttributeValue(item, "Remark");
                info.ChuPiaoLeiXing = Utils.GetXAttributeValue(item, "ET");
                info.XingQi = Utils.GetXAttributeValue(item, "WP");
                info.ChuPiaoSuDu = Utils.GetXAttributeValue(item, "SP");
                info.PingTaiGuanLiFei = Utils.GetXAttributeValue(item, "XF");
                info.CuXiaoFanDian = Utils.GetXAttributeValue(item, "PromotionDiscount");
                info.XinPingTaiZhengCeId = Utils.GetXAttributeValue(item, "NewRateNo");
                info.GongPiaoShangGongZuoHao = Utils.GetXAttributeValue(item, "OfficeNum");
                info.TuiFeiPiaoShangBanShiJian = Utils.GetXAttributeValue(item, "RefundTimeBegin");
                info.TuiFeiPiaoXiaBanShiJian = Utils.GetXAttributeValue(item, "RefundTimeEnd");
                info.ZuiHouGengXinShiJian = Utils.GetXAttributeValue(item, "LastModifyTime");

                items.Add(info);
            }

            return items;
        }
        #endregion

        #region public members
        /// <summary>
        /// 获取政策信息-按政策编号查询
        /// </summary>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public EyouSoft.Model.JPStructure.MZhengCeInfo GetZhengCeInfo(EyouSoft.Model.JPStructure.MZhengCeChaXunInfo1 chaXun)
        {
            var info = JinRi_Api_GetZhengCeInfo(chaXun);

            return info;
        }

        /// <summary>
        /// 获取政策信息-按航班查询
        /// </summary>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.JPStructure.MZhengCeInfo> GetZhengCes(EyouSoft.Model.JPStructure.MZhengCeChaXunInfo2 chaXun)
        {
            if (chaXun == null) return null;
            if (chaXun.ZhengCeShuLiang <= 0) chaXun.ZhengCeShuLiang = 16;
            var items = JinRi_Api_GetZhengCes(chaXun);

            return items;
        }

        /// <summary>
        /// 获取政策信息-按航班查询
        /// </summary>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.JPStructure.MZhengCeInfo> GetZhengCes(EyouSoft.Model.JPStructure.MZhengCeChaXunInfo3 chaXun)
        {
            if (chaXun == null) return null;
            if (chaXun.ZhengCeShuLiang <= 0) chaXun.ZhengCeShuLiang = 16;
            if (string.IsNullOrEmpty(chaXun.HangBanLeiXing)) chaXun.HangBanLeiXing = "0";
            if (string.IsNullOrEmpty(chaXun.ChengKeLeiXing)) chaXun.ChengKeLeiXing = "A";

            var items = JinRi_Api_GetZhengCes(chaXun);

            return items;
        }
        #endregion
    }
}
