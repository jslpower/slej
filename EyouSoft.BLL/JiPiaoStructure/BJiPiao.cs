/*//机票-机票信息 汪奇志 2013-11-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit;
using System.Xml.Linq;

namespace EyouSoft.BLL.JiPiaoStructure
{
    /// <summary>
    /// 机票-机票信息
    /// </summary>
    public class BJiPiao
    {
        #region static constants
        //static constants
        const string DAILISHANGCODE = "QX";//代理商编码
        const string HANGBANREQUESTURI = "http://b.100ticket.com:8080/Platform/airflight!SearchAirFlight.action";//请求航班信息URI
        const string XIADANREQUESTURI = "http://b.100ticket.com:8080/Platform/airflight! CreateOrderBySeginfo.action";//下单请求URI
        const string XIADANREQUESTURI_TEST = "http://192.168.1.254:2769/jipiao/xunijipiaoapi.aspx";
        #endregion

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BJiPiao() { }
        #endregion

        #region private members
        /// <summary>
        /// 获取API乘机人证件类型
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        string GetApiCjrZhengJianLeiXing(EyouSoft.Model.Enum.CardType t)
        {
            string s = "1";

            switch (t)
            {
                case EyouSoft.Model.Enum.CardType.港澳通行证: s = "3"; break;
                case EyouSoft.Model.Enum.CardType.护照: s = "2"; break;
                case EyouSoft.Model.Enum.CardType.身份证: s = "1"; break;
                case EyouSoft.Model.Enum.CardType.台胞证: s = "5"; break;
                default: s = "1"; break;
            }

            return s;
        }
        #endregion

        #region public members
        /// <summary>
        /// 获取航班信息集合
        /// </summary>
        /// <param name="depAirportCode">出发机场三字码</param>
        /// <param name="arrAirportCode">到达机场三字码</param>
        /// <param name="depRiQi">出发日期</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.JiPiaoStructure.MHangBanInfo> GetHangBans(string depAirportCode, string arrAirportCode, DateTime depRiQi)
        {
            IList<EyouSoft.Model.JiPiaoStructure.MHangBanInfo> items = new List<EyouSoft.Model.JiPiaoStructure.MHangBanInfo>();
            if (string.IsNullOrEmpty(depAirportCode) 
                || string.IsNullOrEmpty(arrAirportCode) 
                || depRiQi < DateTime.Today 
                || depRiQi > DateTime.Today.AddYears(1))
                return null;

            string _data = string.Format("StartAirportCode={0}&EndAirportCode={1}&depDate={2}&AgentCode={3}"
                , depAirportCode
                , arrAirportCode
                , depRiQi.ToString("yyyy-MM-dd")
                , DAILISHANGCODE);

            string xml = EyouSoft.Toolkit.request.create(HANGBANREQUESTURI, _data);

            if (string.IsNullOrEmpty(xml)) return null;

            var xDataList = XElement.Parse(xml);
            var xFlights = Utils.GetXElements(xDataList, "Flight");

            foreach (var _item1 in xFlights)
            {
                var item = new EyouSoft.Model.JiPiaoStructure.MHangBanInfo();

                item.ArrAirportCode = Utils.GetXAttributeValue(_item1, "ArrAirport");
                item.ArrHangZhanLou = Utils.GetXAttributeValue(_item1, "ArrTerminal");
                item.ArrTime = Utils.GetXAttributeValue(_item1, "ArrTime");
                item.BanCi = Utils.GetXAttributeValue(_item1, "Code");
                item.CangWeis = new List<EyouSoft.Model.JiPiaoStructure.MCangWeiInfo>();
                item.DepAirportCode = Utils.GetXAttributeValue(_item1, "DptAirport");
                item.DepHangZhanLou = Utils.GetXAttributeValue(_item1, "DptTerminal");
                item.DepTime = Utils.GetXAttributeValue(_item1, "DptTime");
                item.HangKongGongSiCode = Utils.GetXAttributeValue(_item1, "Carrier");
                item.IsHanCan = Utils.GetXAttributeValue(_item1, "Meal") == "true";
                item.JiaGe =Utils.GetDecimal( Utils.GetXAttributeValue(_item1, "Price"));
                item.JiJianFei = Utils.GetDecimal(Utils.GetXAttributeValue(_item1, "Tax"));
                item.JiXing = Utils.GetXAttributeValue(_item1, "Plantype");
                //item.RanYouFei = Utils.GetDecimal(Utils.GetXAttributeValue(_item1, "Fule"));
                item.RanYouFei = Utils.GetDecimal(Utils.GetXAttributeValue(_item1, "Fuel"));               

                var xCabin = Utils.GetXElement(_item1, "Cabins");
                var xCabins = Utils.GetXElements(xCabin, "Cabin");

                foreach (var _item2 in xCabins)
                {
                    var item1 = new EyouSoft.Model.JiPiaoStructure.MCangWeiInfo();

                    item1.CangWeiCode = Utils.GetXAttributeValue(_item2, "Code");
                    item1.JiaGe = Utils.GetDecimal(Utils.GetXAttributeValue(_item2, "Price"));
                    item1.ShengYuShuLiang = Utils.GetInt(Utils.GetXAttributeValue(_item2, "Status"));
                    item1.TeXuZhengCe = Utils.GetDecimal(Utils.GetXAttributeValue(_item2, "ZrateValue"));
                    item1.ZheKou = Utils.GetDecimal(Utils.GetXAttributeValue(_item2, "Discount"));

                    item.CangWeis.Add(item1);
                }

                items.Add(item);
            }

            return items;
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="hangBanInfo">航班实体</param>
        /// <param name="dingDanInfo">订单实体</param>
        /// <returns></returns>
        public EyouSoft.Model.JiPiaoStructure.MApiXiaDanInfo XiaDan(EyouSoft.Model.JiPiaoStructure.MHangBanInfo hangBanInfo, EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo dingDanInfo)
        {
            var retinfo = new EyouSoft.Model.JiPiaoStructure.MApiXiaDanInfo();

            retinfo.RetCode = 0;

            string cjrXingMing=string.Empty;
            string cjrZhengJianLeiXing=string.Empty;
            string cjrZhengJianHaoMa = string.Empty;

            foreach (var item in dingDanInfo.ChengJiRens)
            {
                cjrXingMing += "," + item.XingMing;
                cjrZhengJianLeiXing += "," + GetApiCjrZhengJianLeiXing(item.ZhengJianLeiXing);
                cjrZhengJianHaoMa += "," + item.ZhengJianHaoMa;
            }

            StringBuilder data=new StringBuilder();
            data.AppendFormat("StartAirportCode={0}",hangBanInfo.DepAirportCode);
            data.AppendFormat("&EndAirportCode={0}", hangBanInfo.ArrAirportCode);
            data.AppendFormat("&depDate={0}", dingDanInfo.ChuFaRiQi);
            data.AppendFormat("&arrtime={0}", dingDanInfo.ChuFaRiQi);
            data.AppendFormat("&AgentCode={0}", DAILISHANGCODE);
            data.AppendFormat("&FlightNO={0}", hangBanInfo.BanCi);
            data.AppendFormat("&CabinCode={0}", hangBanInfo.CangWeis[0].CangWeiCode);
            data.AppendFormat("&Flightmodel={0}", hangBanInfo.JiXing);
            data.AppendFormat("&PassName={0}", cjrXingMing.Trim(','));
            data.AppendFormat("&IdType={0}", cjrZhengJianLeiXing.Trim(','));
            data.AppendFormat("&IdNo={0}", cjrZhengJianHaoMa.Trim(','));
            data.AppendFormat("&Price={0}",hangBanInfo.JiaGe);
            data.AppendFormat("&Portfee={0}", hangBanInfo.JiJianFei);
            data.AppendFormat("&Fuelfee={0}", hangBanInfo.RanYouFei);
            data.AppendFormat("&Linkname={0}", dingDanInfo.LxrXingMing);
            data.AppendFormat("&Linktel={0}", dingDanInfo.LxrDianHua);
            data.AppendFormat("&ZrateID={0}", string.Empty);
            data.AppendFormat("&ZrateValue={0}", hangBanInfo.CangWeis[0].TeXuZhengCe);

            string xml = EyouSoft.Toolkit.request.create(XIADANREQUESTURI_TEST, data.ToString());
            if (string.IsNullOrEmpty(xml))
            {
                retinfo.RetCode = -1;
                retinfo.CuoWuTiShi = "API返回空值";
                return retinfo;
            }

            var xorder = XElement.Parse(xml);
            var xorderno = Utils.GetXElement(xorder, "orderno");
            var xzratevalue = Utils.GetXElement(xorder, "zratevalue");
            var xpayprice = Utils.GetXElement(xorder, "payprice");
            var xsegs = Utils.GetXElement(xorder, "segs");
            var xseg = Utils.GetXElement(xsegs, "seg");
            var xscitycode = Utils.GetXElement(xseg, "scitycode");
            var xendcitycode = Utils.GetXElement(xseg, "endcitycode");
            var xpass = Utils.GetXElement(xorder, "pass");
            var xpa = Utils.GetXElements(xpass, "pa");

            string apiDingDanHao = xorderno.Value;

            if (!string.IsNullOrEmpty(apiDingDanHao))
            {
                retinfo.RetCode = 1;
                retinfo.ApiDingDanHao = apiDingDanHao;
                retinfo.ApiFaDianJinE = Utils.GetDecimal(xzratevalue.Value);
                retinfo.ApiJinE = Utils.GetDecimal(xpayprice.Value);
            }
            else
            {
                retinfo.RetCode = -2;
                retinfo.CuoWuTiShi = "API返回异常";
            }

            return retinfo;
        }
        #endregion
    }
}
*/