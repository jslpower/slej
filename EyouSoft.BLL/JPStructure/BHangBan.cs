//机票航班信息相关BLL 汪奇志 2014-11-13
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit;
using System.Xml.Linq;
using System.IO;

namespace EyouSoft.BLL.JPStructure
{
    /// <summary>
    /// 机票航班信息相关BLL
    /// </summary>
    public class BHangBan
    {
        #region static constants
        //static constants
        const string JinRi_Api_HangBan_Ws = "http://ws.jinri.cn/JinRiFlightServer.asmx";
        const string JinRi_Api_TuiGaiQian_Ws = "http://ws.jinri.cn/JinRiFlightServer.asmx";
        /// <summary>
        /// 今日天下通API-主账号
        /// </summary>
        public const string JinRi_Api_Username = "hzja88888";
        /// <summary>
        /// 今日天下通API-子账号
        /// </summary>
        public const string JinRi_Api_Username01 = "hzja8888801";
        #endregion

        #region private members

        /// <summary>
        /// 今日天下通API-获取response xml
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        internal static string JinRi_Api_GetReponseXml(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            var xstring = XElement.Parse(s);
            if (xstring == null) return string.Empty;
            string xstringValue = Utils.GetXElementValue(xstring);
            if (string.IsNullOrEmpty(xstringValue)) return string.Empty;

            return xstringValue;
        }

        /// <summary>
        /// 今日天下通API-获取航班信息集合
        /// </summary>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.JPStructure.MHangBanInfo> JinRi_Api_GetHangBans(EyouSoft.Model.JPStructure.MHangBanChaXunInfo chaXun)
        {
            if (string.IsNullOrEmpty(chaXun.ChuFaChengShiSanZiMa)
                || string.IsNullOrEmpty(chaXun.DaoDaChengShiSanZiMa)
                || chaXun.HangBanRiQi < DateTime.Today)
                return null;

            IList<EyouSoft.Model.JPStructure.MHangBanInfo> items = new List<EyouSoft.Model.JPStructure.MHangBanInfo>();
            string requestUrl = JinRi_Api_HangBan_Ws + "/GetFlightList";

            StringBuilder apiChaXunXml = new StringBuilder();
            apiChaXunXml.Append("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
            apiChaXunXml.Append("<JIT-Flight-Request>");
            apiChaXunXml.AppendFormat("<Request ");
            apiChaXunXml.AppendFormat(" Username=\"{0}\" ", JinRi_Api_Username);
            apiChaXunXml.AppendFormat(" Scity=\"{0}\" ", chaXun.ChuFaChengShiSanZiMa);
            apiChaXunXml.AppendFormat(" Ecity=\"{0}\" ", chaXun.DaoDaChengShiSanZiMa);
            apiChaXunXml.AppendFormat(" Date=\"{0}\" ", chaXun.HangBanRiQi.ToString("yyyy-MM-dd"));
            apiChaXunXml.AppendFormat(" Cabin=\"{0}\" ", (chaXun.CangWei == "Y" || chaXun.CangWei == "C" || chaXun.CangWei == "F") ? chaXun.CangWei : "A");
            apiChaXunXml.AppendFormat(" IsShowSpecial=\"{0}\" ", chaXun.ShiFouTeJia == "T" ? "T" : "F");
            apiChaXunXml.AppendFormat("  SystemId=\"\" ");
            apiChaXunXml.AppendFormat("/>");
            apiChaXunXml.Append("</JIT-Flight-Request>");

            string requestXml = "xml=" + System.Web.HttpUtility.UrlEncode(apiChaXunXml.ToString());

            var responseString = EyouSoft.Toolkit.request.post(requestUrl, requestXml, "application/x-www-form-urlencoded");

            string responseXml = JinRi_Api_GetReponseXml(responseString);

#if DEBUG
            Utils.WLog("requesturi:" + requestUrl, "/jinrilog/hangban.log");
            Utils.WLog("request:" + apiChaXunXml.ToString(), "/jinrilog/hangban.log");
            Utils.WLog("response:" + responseXml, "/jinrilog/hangban.log");
#endif

            if (string.IsNullOrEmpty(responseXml)) return null;

            if (responseXml.Length < 10 || Utils.GetInt(responseXml) > 0) return null;

            var xJIT_Flight_Response = XElement.Parse(responseXml);
            var xResponse = Utils.GetXElements(xJIT_Flight_Response, "Response");

            foreach (var xitem in xResponse)
            {
                var item = new EyouSoft.Model.JPStructure.MHangBanInfo();
                item.HangBanRiQi = Utils.GetDateTime(Utils.GetXAttributeValue(xitem, "Sdate"));
                item.ChuFaChengShiSanZiMa = Utils.GetXAttributeValue(xitem, "Scity");
                item.DaoDaChengShiSanZiMa = Utils.GetXAttributeValue(xitem, "Ecity");
                item.HangBanHao = Utils.GetXAttributeValue(xitem, "FlightNo");
                item.HangKongGongSiErZiMa = Utils.GetXAttributeValue(xitem, "AirLine");
                item.JiXing = Utils.GetXAttributeValue(xitem, "FlightType");
                item.QiFeiShiJian = Utils.GetXAttributeValue(xitem, "Stime");
                item.DaoDaShiJian = Utils.GetXAttributeValue(xitem, "Etime");
                item.ShiFouJingTing = Utils.GetXAttributeValue(xitem, "Stop");
                item.DianZiKePiao = Utils.GetXAttributeValue(xitem, "EPiao");
                item.ShuiFeiJinE = Utils.GetDecimal(Utils.GetXAttributeValue(xitem, "Tax"));
                item.JiJianJinE = Utils.GetDecimal(Utils.GetXAttributeValue(xitem, "AirTax"));
                item.RanYouJinE = Utils.GetDecimal(Utils.GetXAttributeValue(xitem, "Fees"));
                string hangZhanLou = Utils.GetXAttributeValue(xitem, "AirTerminal");
                if (!string.IsNullOrEmpty(hangZhanLou))
                {
                    var hangZhanLouItems = hangZhanLou.Split(',');
                    if (hangZhanLouItems != null && hangZhanLouItems.Length > 1)
                    {
                        item.ChuFaHangZhanLou = hangZhanLouItems[0];
                        item.DaoDaHangZhanLou = hangZhanLouItems[1];
                    }
                }
                item.CangWeis = new List<EyouSoft.Model.JPStructure.MCangWeiInfo>();

                var xCabin = Utils.GetXElements(xitem, "Cabin");

                foreach (var xitem1 in xCabin)
                {
                    var item1 = new EyouSoft.Model.JPStructure.MCangWeiInfo();

                    item1.CangWei = Utils.GetXAttributeValue(xitem1, "C");
                    item1.CangWeiShu = Utils.GetXAttributeValue(xitem1, "N");
                    item1.ZheKouLv = Utils.GetInt(Utils.GetXAttributeValue(xitem1, "D"));
                    item1.PiaoMianJiaGe = Utils.GetDecimal(Utils.GetXAttributeValue(xitem1, "P"));
                    item1.FanDian = Utils.GetDecimal(Utils.GetXAttributeValue(xitem1, "K"));
                    item1.GongYingShangId = Utils.GetXAttributeValue(xitem1, "ID");
                    item1.ShiFouTeShu = Utils.GetXAttributeValue(xitem1, "T");
                    item1.PingTaiGuanLiFei = Utils.GetDecimal(Utils.GetXAttributeValue(xitem1, "XF"));
                    item1.GongPiaoShiJian = Utils.GetXAttributeValue(xitem1, "PI");
                    item1.ZhengCeLeiXing = (EyouSoft.Model.JPStructure.ZhengCeLeiXing)Utils.GetInt(Utils.GetXAttributeValue(xitem1, "RT"));
                    item1.ZhengCeBeiZhu = Utils.GetXAttributeValue(xitem1, "RM");
                    item1.ZhengCeId = Utils.GetXAttributeValue(xitem1, "RID");
                    item1.GongYingShangOfficeId = Utils.GetXAttributeValue(xitem1, "OfficeNum");
                    item1.GaiQianGuiDing = Utils.GetXAttributeValue(xitem1, "Change");
                    item1.TuiPiaoGuiDing = Utils.GetXAttributeValue(xitem1, "Return");

                    if (string.IsNullOrEmpty(item1.ZhengCeId)) continue;

                    item.CangWeis.Add(item1);
                }

                items.Add(item);
            }

            return items;
        }

        /// <summary>
        /// 今日天下通API-获取舱位特价信息
        /// </summary>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        EyouSoft.Model.JPStructure.MCangWeiTeJiaInfo JinRi_Api_GetCangWeiTeJiaInfo(EyouSoft.Model.JPStructure.MCangWeiTeJiaChaXunInfo chaXun)
        {
            if (string.IsNullOrEmpty(chaXun.ChuFaChengShiSanZiMa)
                || string.IsNullOrEmpty(chaXun.DaoDaChengShiSanZiMa)
                || chaXun.HangBanRiQi < DateTime.Today
                || string.IsNullOrEmpty(chaXun.HangBanHao)
                || string.IsNullOrEmpty(chaXun.CangWei))
                return null;
            var info = new EyouSoft.Model.JPStructure.MCangWeiTeJiaInfo();
            string requestUrl = JinRi_Api_HangBan_Ws + "/GetSpecialCabinPrice";
            StringBuilder apiChaXunXml = new StringBuilder();
            apiChaXunXml.Append("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
            apiChaXunXml.Append("<JIT-Cabin-Request>");
            apiChaXunXml.AppendFormat("<Request ");
            apiChaXunXml.AppendFormat(" Username=\"{0}\" ", JinRi_Api_Username);
            apiChaXunXml.AppendFormat(" DepartureCity=\"{0}\" ", chaXun.ChuFaChengShiSanZiMa);
            apiChaXunXml.AppendFormat(" ArrivalCity=\"{0}\" ", chaXun.DaoDaChengShiSanZiMa);
            apiChaXunXml.AppendFormat(" FlightDate=\"{0}\" ", chaXun.HangBanRiQi.ToString("yyyy-MM-dd"));
            apiChaXunXml.AppendFormat(" Cabin=\"{0}\" ", chaXun.CangWei);
            apiChaXunXml.AppendFormat(" FlightNo=\"{0}\" ", chaXun.HangBanHao);
            apiChaXunXml.AppendFormat("  SystemId=\"\" ");
            apiChaXunXml.AppendFormat("/>");
            apiChaXunXml.Append("</JIT-Cabin-Request>");

            string requestXml = "xml=" + System.Web.HttpUtility.UrlEncode(apiChaXunXml.ToString());

            var responseString = EyouSoft.Toolkit.request.post(requestUrl, requestXml, "application/x-www-form-urlencoded");
            string responseXml = JinRi_Api_GetReponseXml(responseString);

#if DEBUG
            Utils.WLog("requesturi:" + requestUrl, "/jinrilog/hangban.log");
            Utils.WLog("request:" + apiChaXunXml.ToString(), "/jinrilog/hangban.log");
            Utils.WLog("response:" + responseXml, "/jinrilog/hangban.log");
#endif

            if (string.IsNullOrEmpty(responseXml)) return null;

            if (responseXml.Length < 10 || Utils.GetInt(responseXml) > 0) return null;

            var xJIT_Cabin_Response = XElement.Parse(responseXml);

            if (xJIT_Cabin_Response == null) return null;

            var xResponse = Utils.GetXElement(xJIT_Cabin_Response, "Response");


            info.RetCode = Utils.GetXAttributeValue(xResponse, "Result");

            if (info.RetCode == "success")
            {
                info.JiaGe = Utils.GetDecimal(Utils.GetXAttributeValue(xResponse, "Price"));
            }

            return info;
        }

        /// <summary>
        /// 今日天下通API-获取退改签说明信息
        /// </summary>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        EyouSoft.Model.JPStructure.MTuiGaiQianShuoMingInfo JinRi_Api_GetTuiGaiQianShuoMingInfo(EyouSoft.Model.JPStructure.MTuiGaiQianShuoMingChaXunInfo chaXun)
        {
            if (string.IsNullOrEmpty(chaXun.CangWei)
                || string.IsNullOrEmpty(chaXun.HangKongGongSiErZiMa)
                || chaXun.HangBanRiQi < DateTime.Today)
                return null;

            string requestUrl = JinRi_Api_TuiGaiQian_Ws + "/GetRestrictions";

            StringBuilder apiChaXunXml = new StringBuilder();
            apiChaXunXml.Append("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
            apiChaXunXml.Append("<JinRiRuleRequest>");
            apiChaXunXml.AppendFormat("<Request ");
            apiChaXunXml.AppendFormat(" Username=\"{0}\" ", JinRi_Api_Username);
            apiChaXunXml.AppendFormat(" AirLine=\"{0}\" ", chaXun.HangKongGongSiErZiMa);
            apiChaXunXml.AppendFormat(" Cabin=\"{0}\" ", chaXun.CangWei);
            apiChaXunXml.AppendFormat(" Sdate=\"{0}\" ", chaXun.HangBanRiQi.ToString("yyyy-MM-dd"));
            apiChaXunXml.AppendFormat("  SystemId=\"\" ");
            apiChaXunXml.AppendFormat("/>");
            apiChaXunXml.Append("</JinRiRuleRequest>");

            string requestXml = "xml=" + System.Web.HttpUtility.UrlEncode(apiChaXunXml.ToString());

            var responseString = EyouSoft.Toolkit.request.post(requestUrl, requestXml, "application/x-www-form-urlencoded");

            string responseXml = JinRi_Api_GetReponseXml(responseString);
            if (string.IsNullOrEmpty(responseXml)) return null;

            if (responseXml.Length < 10 || Utils.GetInt(responseXml) > 0) return null;

            var info = new EyouSoft.Model.JPStructure.MTuiGaiQianShuoMingInfo();

            var xJinRiRuleResponse = XElement.Parse(responseXml);
            var xResponse = Utils.GetXElement(xJinRiRuleResponse, "Response");
            var xRules = Utils.GetXElement(xResponse, "Rules");
            var xAirline = Utils.GetXElement(xRules, "Airline");
            var xCabin = Utils.GetXElement(xRules, "Cabin");
            var xChangeSdate = Utils.GetXElement(xRules, "ChangeSdate");
            var xChangeEdate = Utils.GetXElement(xRules, "ChangeEdate");
            var xRefundSdate = Utils.GetXElement(xRules, "RefundSdate");
            var xRefundEdate = Utils.GetXElement(xRules, "RefundEdate");
            var xChange = Utils.GetXElement(xRules, "Change");
            var xRefund = Utils.GetXElement(xRules, "Refund");
            var xRemark = Utils.GetXElement(xRules, "Remark");

            info.CangWei = Utils.GetXElementValue(xCabin);
            info.GaiQianShiJian1 = Utils.GetXElementValue(xChangeSdate);
            info.GaiQianShiJian2 = Utils.GetXElementValue(xChangeEdate);
            info.GaiQianShuoMing = Utils.GetXElementValue(xChange);
            info.HangKongGongSiErZiMa = Utils.GetXElementValue(xAirline);
            info.QiTaShuoMing = Utils.GetXElementValue(xRemark);
            info.TuiFeiShiJian1 = Utils.GetXElementValue(xRefundSdate);
            info.TuiFeiShiJian2 = Utils.GetXElementValue(xRefundEdate);
            info.TuiFeiShuoMing = Utils.GetXElementValue(xRefund);

            return info;
        }
        #endregion

        #region public members
        /// <summary>
        /// 获取航班信息集合
        /// </summary>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.JPStructure.MHangBanInfo> GetHangBans(EyouSoft.Model.JPStructure.MHangBanChaXunInfo chaXun)
        {
            var items = JinRi_Api_GetHangBans(chaXun);

            return items;
        }

        /// <summary>
        /// 获取舱位特价信息
        /// </summary>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public EyouSoft.Model.JPStructure.MCangWeiTeJiaInfo GetCangWeiTeJiaInfo(EyouSoft.Model.JPStructure.MCangWeiTeJiaChaXunInfo chaXun)
        {
            var info = JinRi_Api_GetCangWeiTeJiaInfo(chaXun);

            if (info == null)
            {
                info = new EyouSoft.Model.JPStructure.MCangWeiTeJiaInfo();
                info.RetCode = "未知异常";
            }

            return info;
        }

        /// <summary>
        /// 获取退改签说明信息
        /// </summary>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public EyouSoft.Model.JPStructure.MTuiGaiQianShuoMingInfo GetTuiGaiQianShuoMingInfo(EyouSoft.Model.JPStructure.MTuiGaiQianShuoMingChaXunInfo chaXun)
        {
            var info = JinRi_Api_GetTuiGaiQianShuoMingInfo(chaXun);

            return info;
        }
        #endregion
    }
}
