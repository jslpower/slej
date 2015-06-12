using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Xml.Linq;
using EyouSoft.InterfaceLib.Attributes;
using EyouSoft.InterfaceLib.Models.Bok;
using EyouSoft.InterfaceLib.Common;
using EyouSoft.Model;
using EyouSoft.InterfaceLib.Common.StringHelper;

namespace EyouSoft.InterfaceLib
{
    /// <summary>
    /// 博客
    /// </summary>
    public partial class BokServiceSeeker : WebServiceXmlSeekerBase
    {
        protected override string Address
        {
            get
            {
                return ConfigurationManager.AppSettings["BokServiceSeekerAddress"];
            }
        }

        public BokServiceSeeker()
            : base(false)
        {

        }

        string loginName = ConfigurationManager.AppSettings["BokLoginName"];
        string loginPassword = ConfigurationManager.AppSettings["BokPassword"];


        /// <summary>
        /// 周边线路
        /// </summary>
        /// <returns></returns>
        [ContractName("getShortList")]
        public IList<MXianLuInfo_BokServcice> GetZhouBianLine()
        {
            List<MXianLuInfo_BokServcice> LineList = new List<MXianLuInfo_BokServcice>();
            object[] parameters = new object[] { loginName, loginPassword };
            string xml = this.GetResponseString(parameters);
            System.IO.StringReader tr = new System.IO.StringReader(xml);
            XDocument doc = XDocument.Load(tr);
            var items = from t in doc.Descendants("item")
                        select new
                        {
                            RouteName = t.Element("title").Value,
                            UpdateTime = t.Element("UPDATETIME").Value,
                            LineType = t.Element("LINETYPE") == null ? string.Empty : t.Element("LINETYPE").Value,
                            LineId = t.Element("LINE_ID").Value,
                            TourDays = t.Element("TOURDAYS").Value,
                            LeaveDate = t.Element("DATE1").Value,
                            ComeBackDate = t.Element("DATE2").Value,
                            MarketPersonalPrice = t.Element("MS_PRICE_01").Value,
                            MarketChildPrice = t.Element("MS_PRICE_02").Value,
                            AgencyPersonalPrice = t.Element("JS_PRICE_01").Value,
                            AgencyChildPrice = t.Element("JS_PRICE_02").Value,
                            CFCS = t.Element("SETOUTCITY").Value
                        };

            foreach (var item in items)
            {
                try
                {

                    //XDocument tdoc = XDocument.Load(@"d:\logtext\log.xml");
                    MXianLuInfo_BokServcice TourModel = new MXianLuInfo_BokServcice();
                    string XianLuID = "";
                    TourModel.LineID = item.LineId;
                    TourModel.XianLuId = XianLuID;
                    TourModel.AreaId = 0;//线路区域
                    TourModel.RouteName = item.RouteName;
                    TourModel.TianShu = int.Parse(item.TourDays);
                    TourModel.CFCS = item.CFCS;

                    TourModel.DepProvinceId = 0;//出发地省份编号
                    TourModel.DepCityId = 0;//出发地城市编号
                    TourModel.ArrProvinceId = 0;//目的地省份编号
                    TourModel.ArrCityId = 0;//目的地城市编号
                    TourModel.AreaType = 1;//周边线

                    TourModel.JiHuaRenShu = 0;//计划人数


                    TourModel.JSJCR = int.Parse(item.AgencyPersonalPrice);
                    TourModel.JSJET = int.Parse(item.AgencyChildPrice);
                    TourModel.SCJCR = int.Parse(item.MarketPersonalPrice);
                    TourModel.SCJET = int.Parse(item.MarketChildPrice);

                    TourModel.TingTianShu = 0;//提前X天报名
                    TourModel.ChuFaJiaoTong = "";//出发交通
                    TourModel.FanChengJiaoTong = "";//返程交通

                    TourModel.TeSe = "";//特色描述文字
                    TourModel.TeSeFilePath = "";//特色描述图片
                    TourModel.TuJing = "";//途径
                    TourModel.QianZheng = "";//签证资料
                    TourModel.QianZhengFilePath = "";//签证说明
                    TourModel.GuanZhuShu = 0;//关注数
                    TourModel.AreaName = item.LineType;

                    TourModel.LxrName = "";
                    TourModel.LxrTelephone = "";
                    TourModel.LxrMobile = string.Empty;
                    TourModel.LxrQQ = string.Empty;


                    TourModel.Description = "";//description
                    TourModel.Keywords = "";//Keywords
                    TourModel.IssueTime = DateTime.Now;



                    LineList.Add(TourModel);
                }
                catch
                {

                }
            }

            return LineList;

        }
        /// <summary>
        /// 国内线路
        /// </summary>
        /// <returns></returns>
        [ContractName("getLineList")]
        public IList<MXianLuInfo_BokServcice> GetGuoNeiLine()
        {
            List<MXianLuInfo_BokServcice> LineList = new List<MXianLuInfo_BokServcice>();

            object[] parameters = new object[] { loginName, loginPassword };
            string xml = this.GetResponseString(parameters);
            System.IO.StringReader tr = new System.IO.StringReader(xml);
            XDocument doc = XDocument.Load(tr);
            var items = from t in doc.Descendants("item")
                        select new
                           {
                               RouteName = t.Element("title").Value,
                               UpdateTime = t.Element("UPDATETIME").Value,
                               LineType = t.Element("LINETYPE") == null ? string.Empty : t.Element("LINETYPE").Value,
                               LineId = t.Element("LINE_ID").Value,
                               TourDays = t.Element("TOURDAYS").Value,
                               LeaveDate = t.Element("DATE1").Value,
                               ComeBackDate = t.Element("DATE2").Value,
                               MarketPersonalPrice = t.Element("MS_PRICE_01").Value,
                               MarketChildPrice = t.Element("MS_PRICE_02").Value,
                               AgencyPersonalPrice = t.Element("JS_PRICE_01").Value,
                               AgencyChildPrice = t.Element("JS_PRICE_02").Value,
                               CFCS = t.Element("SETOUTCITY").Value
                           };

            foreach (var item in items)
            {
                try
                {

                    //XDocument tdoc = XDocument.Load(@"d:\logtext\log.xml");
                    MXianLuInfo_BokServcice TourModel = new MXianLuInfo_BokServcice();
                    string XianLuID = "";
                    TourModel.LineID = item.LineId;
                    TourModel.XianLuId = XianLuID;
                    TourModel.AreaId = 0;//线路区域
                    TourModel.RouteName = item.RouteName;
                    TourModel.TianShu = int.Parse(item.TourDays);
                    TourModel.CFCS = item.CFCS;

                    TourModel.DepProvinceId = 0;//出发地省份编号
                    TourModel.DepCityId = 0;//出发地城市编号
                    TourModel.ArrProvinceId = 0;//目的地省份编号
                    TourModel.ArrCityId = 0;//目的地城市编号

                    TourModel.JiHuaRenShu = 0;//计划人数


                    TourModel.JSJCR = int.Parse(item.AgencyPersonalPrice);
                    TourModel.JSJET = int.Parse(item.AgencyChildPrice);
                    TourModel.SCJCR = int.Parse(item.MarketPersonalPrice);
                    TourModel.SCJET = int.Parse(item.MarketChildPrice);

                    TourModel.TingTianShu = 0;//提前X天报名
                    TourModel.ChuFaJiaoTong = "";//出发交通
                    TourModel.FanChengJiaoTong = "";//返程交通

                    TourModel.TeSe = "";//特色描述文字
                    TourModel.TeSeFilePath = "";//特色描述图片
                    TourModel.TuJing = "";//途径
                    TourModel.QianZheng = "";//签证资料
                    TourModel.QianZhengFilePath = "";//签证说明
                    TourModel.GuanZhuShu = 0;//关注数
                    TourModel.AreaName = item.LineType;

                    TourModel.LxrName = "";
                    TourModel.LxrTelephone = "";
                    TourModel.LxrMobile = string.Empty;
                    TourModel.LxrQQ = string.Empty;


                    TourModel.Description = "";//description
                    TourModel.Keywords = "";//Keywords
                    TourModel.IssueTime = DateTime.Now;


                    LineList.Add(TourModel);
                }
                catch
                {

                }
            }
            return LineList;
        }

        /// <summary>
        /// 线路详情
        /// </summary>
        /// <param name="LineID"></param>
        /// <returns></returns>
        [ContractName("getLineDetail")]
        public MXianLuInfo_BokServcice GetLineDetail(string LineID)
        {
            MXianLuInfo_BokServcice LineList = new MXianLuInfo_BokServcice();
            try
            {
                object[] parameters = new object[] { loginName, loginPassword, LineID };
                string xml = this.GetResponseString(parameters);

                System.IO.StringReader tr1 = new System.IO.StringReader(xml);

                XDocument tdoc = XDocument.Load(tr1);
                //XDocument tdoc = XDocument.Load(@"d:\logtext\log.xml");
                var model = from t1 in tdoc.Descendants("item")
                            select new
                            {
                                TourDays = t1.Element("TOURDAYS").Value,
                                LineId = LineID,
                                ServiceStandard = t1.Element("PRICEBH_01").Value,
                                ExpenseItem = t1.Element("ITEM").Value,
                                NoticeProceeding = t1.Element("PROCEEDING_01").Value,
                                RouteRemark = t1.Element("LINE_CHARA").Value,
                                IssueCompany = t1.Element("SUPPLIER").Element("COMPNAME").Value,
                                ContactName = t1.Element("SUPPLIER").Element("LINKMAN").Value,
                                ContactPhone = t1.Element("SUPPLIER").Element("TEL").Value,
                                CORPS_MAN = t1.Element("CORPS_MAN").Value,
                                AreaName = t1.Element("LINETYPE").Value,
                                MarketPersonalPrice = t1.Element("MS_PRICE_01").Value,
                                MarketChildPrice = t1.Element("MS_PRICE_02").Value,
                                AgencyPersonalPrice = t1.Element("JS_PRICE_01").Value,
                                AgencyChildPrice = t1.Element("JS_PRICE_02").Value,
                                MUSTER = t1.Element("MUSTER_ADDR").Value,
                                t = from a1 in t1.Element("TRIP").Elements("DATE")
                                    select new
                                    {
                                        DAYS = a1.Element("DAYS").Value,
                                        JOURNEY = a1.Element("JOURNEY").Value,
                                        HOTEL = a1.Element("HOTEL").Value,
                                        EAT = a1.Element("EAT").Value,
                                        PIC = a1.Element("PIC").Value
                                    },
                                PRICE = from a2 in t1.Document.Descendants("PRICE")
                                        select new
                                        {
                                            DATE = a2.Element("DATE").Value,
                                            MarketPersonalPrice = a2.Element("MS_PRICE_01").Value,
                                            MarketChildPrice = a2.Element("MS_PRICE_02").Value,
                                            AgencyPersonalPrice = a2.Element("JS_PRICE_01").Value,
                                            AgencyChildPrice = a2.Element("JS_PRICE_02").Value,
                                            TourManRemnant = a2.Element("NUM").Value,
                                        },
                                TRAFFIC = from a3 in t1.Elements("TRAFFIC")
                                          select new
                                          {
                                              TRAFFIC_ID = a3.Element("TRAFFIC_ID").Value,
                                              TRAFFIC_01 = a3.Element("TRAFFIC_01").Value,
                                              TRAFFIC_02 = a3.Element("TRAFFIC_02").Value,

                                              TRAFFIC_PRICE = from p in a3.Elements("TRAFFIC_PRICE").Elements("PRICE")
                                                              select new
                                                              {
                                                                  DATE = p.Element("DATE").Value,
                                                                  MarketPersonalPrice = p.Element("MS_PRICE_01").Value,
                                                                  MarketChildPrice = p.Element("MS_PRICE_02").Value,
                                                                  AgencyPersonalPrice = p.Element("JS_PRICE_01").Value,
                                                                  AgencyChildPrice = p.Element("JS_PRICE_02").Value,
                                                                  TourManRemnant = p.Element("NUM").Value,
                                                                  TourState = p.Element("STATUS").Value,
                                                              }
                                          },
                                LINE_CHARA = t1.Element("LINE_CHARA").Value,
                                SERVICES = t1.Element("SERVICES").Value,
                                ITEM = t1.Element("ITEM").Value,
                                PROCEEDING_01 = t1.Element("PROCEEDING_01").Value,
                                PROCEEDING_02 = t1.Element("PROCEEDING_02").Value,
                                PRICEBH_01 = t1.Element("PRICEBH_01").Value,
                                PRICEBH_02 = t1.Element("PRICEBH_02").Value,
                                SHOP = t1.Element("SHOP").Value,
                                ERTONG = t1.Element("ERTONG").Value,
                                ZSONG = t1.Element("ZSONG").Value,
                                QIJIA = t1.Element("QIJIA").Value,
                                CLOSEDAYS = t1.Element("CLOSEDAYS").Value
                            };
                
                foreach (var a1 in model)
                {

                    MXianLuInfo_BokServcice TourModel = new MXianLuInfo_BokServcice();
                    string XianLuID = "";
                    if (a1.LineId == "0")
                        break;
                    TourModel.LineID = a1.LineId;
                    TourModel.XianLuId = XianLuID;
                    TourModel.AreaId = 0;//线路区域
                    //TourModel.RouteName = "";
                    //TourModel.TianShu ="";

                    TourModel.DepProvinceId = 0;//出发地省份编号
                    TourModel.DepCityId = 0;//出发地城市编号
                    TourModel.ArrProvinceId = 0;//目的地省份编号
                    TourModel.ArrCityId = 0;//目的地城市编号

                    TourModel.JiHuaRenShu = 0;//计划人数


                    //TourModel.JSJCR = int.Parse(a1.AgencyPersonalPrice);
                    //TourModel.JSJET = int.Parse(a1.AgencyPersonalPrice);
                    //TourModel.SCJCR = int.Parse(a1.MarketPersonalPrice);
                    //TourModel.SCJET = int.Parse(a1.MarketChildPrice);

                    TourModel.TingTianShu = int.Parse(a1.CLOSEDAYS);//提前X天报名
                    TourModel.ChuFaJiaoTong = "";//出发交通
                    TourModel.FanChengJiaoTong = "";//返程交通
                    TourModel.JiHeFangShi = a1.MUSTER;
                    TourModel.TeSe = a1.RouteRemark; //特色描述文字
                    TourModel.TeSeFilePath = "";//特色描述图片
                    TourModel.TuJing = "";//途径
                    TourModel.QianZheng = "";//签证资料
                    TourModel.QianZhengFilePath = "";//签证说明
                    TourModel.GuanZhuShu = 0;//关注数
                    //TourModel.AreaName = a1.AreaName;

                    #region 行程安排
                    List<MXianLuXingChengInfo_BokServcice> Ixingcheng = new List<MXianLuXingChengInfo_BokServcice>();
                    foreach (var t in a1.t)
                    {
                        MXianLuXingChengInfo_BokServcice XingCheng = new MXianLuXingChengInfo_BokServcice();
                        XingCheng.QuJian = "";
                        XingCheng.JiaoTong = "";
                        XingCheng.XingCheng = t.JOURNEY;
                        XingCheng.ZhuSu = t.HOTEL;
                        XingCheng.YongCan = t.EAT;
                        XingCheng.FilePath = t.PIC;
                        Ixingcheng.Add(XingCheng);
                    }
                    #endregion
                    TourModel.XingChengs = Ixingcheng;

                    #region 发班信息集合
                    List<MXianLuTourInfo_BokServcice> XianLuList = new List<MXianLuTourInfo_BokServcice>();
                    List<MXianLuTourTraffice_BokServcice> TrafficeList = new List<MXianLuTourTraffice_BokServcice>();
                    foreach (var b1 in a1.TRAFFIC)
                    {
                        MXianLuTourTraffice_BokServcice t = new MXianLuTourTraffice_BokServcice()
                        {
                            TrafficId = b1.TRAFFIC_ID,
                            Traffic_01 = b1.TRAFFIC_01,
                            Traffic_02 = b1.TRAFFIC_02
                        };
                        TrafficeList.Add(t);
                        foreach (var c1 in b1.TRAFFIC_PRICE)
                        {
                            MXianLuTourInfo_BokServcice info = new MXianLuTourInfo_BokServcice()
                            {
                                TourId = XianLuID,
                                LDate = DateTime.Parse(c1.DATE),
                                RDate = DateTime.Parse(c1.DATE).AddDays(int.Parse(a1.TourDays)),
                                DingDanShu = 0,
                                YiShouRenShu = 0,
                                ShiShouRenShu = 0,
                                Status = c1.TourState == "N" ? ShouKeZhuangTai.停收 : ShouKeZhuangTai.正常,
                                JSJCR = int.Parse(c1.AgencyPersonalPrice),
                                JSJET = int.Parse(c1.AgencyChildPrice),
                                SYRS = int.Parse(c1.TourManRemnant),
                                CRSCJ = int.Parse(c1.MarketPersonalPrice),
                                ETSCJ = int.Parse(c1.MarketChildPrice),
                                TrafficId = b1.TRAFFIC_ID,
                            };
                            if (DateTime.Today.AddDays(int.Parse(a1.CLOSEDAYS)) >= info.LDate)
                            {
                                info.Status = ShouKeZhuangTai.停收;
                            }
                            XianLuList.Add(info);
                        }
                    }
                    #endregion
                    TourModel.TrafficeList = TrafficeList;
                    TourModel.Tours = XianLuList;

                    TourModel.LxrName = a1.CORPS_MAN;
                    TourModel.LxrTelephone = string.Empty;
                    TourModel.LxrMobile = a1.CORPS_MAN;
                    TourModel.LxrQQ = string.Empty;


                    TourModel.Description = "";//description
                    TourModel.Keywords = "";//Keywords
                    TourModel.IssueTime = DateTime.Now;

                    MXianLuFuWuInfo_BokServcice FuWuInfo = new MXianLuFuWuInfo_BokServcice()
                    {
                        FuWuBiaoZhun = a1.PRICEBH_01,
                        BuHanXiangMu = a1.PRICEBH_02,
                        GouWuAnPai = a1.SHOP,
                        ErTongAnPai = a1.ERTONG,
                        ZiFeiXiangMu = a1.ITEM,
                        ZhuYiShiXiang = a1.PROCEEDING_01,
                        WenXinTiXing = a1.SERVICES,
                        BaoMingXuZhi = a1.QIJIA,
                        ZengSongXiangMu = a1.ZSONG,
                        QiTaShiXiang = a1.PROCEEDING_02
                    };
                    TourModel.FuWu = FuWuInfo;
                    LineList = TourModel;
                }
            }
            catch
            {
                return LineList;
            }
            return LineList;
        }

        /// <summary>
        /// 线路详情
        /// </summary>
        /// <param name="LineID"></param>
        /// <returns></returns>
        [ContractName("getShortDetail")]
        public MXianLuInfo_BokServcice GetShortDetail(string LineID)
        {
            MXianLuInfo_BokServcice LineList = new MXianLuInfo_BokServcice();
            try
            {
                object[] parameters = new object[] { loginName, loginPassword, LineID };
                string xml = this.GetResponseString(parameters);

                System.IO.StringReader tr1 = new System.IO.StringReader(xml);

                XDocument tdoc = XDocument.Load(tr1);
                //XDocument tdoc = XDocument.Load(@"d:\logtext\log.xml");
                var model = from t1 in tdoc.Descendants("item")
                            select new
                            {
                                TourDays = t1.Element("TOURDAYS").Value,
                                LineId = LineID,
                                ServiceStandard = t1.Element("PRICEBH_01").Value,
                                ExpenseItem = t1.Element("ITEM").Value,
                                NoticeProceeding = t1.Element("PROCEEDING_01").Value,
                                RouteRemark = t1.Element("LINE_CHARA").Value,
                                IssueCompany = t1.Element("SUPPLIER").Element("COMPNAME").Value,
                                ContactName = t1.Element("SUPPLIER").Element("LINKMAN").Value,
                                ContactPhone = t1.Element("SUPPLIER").Element("TEL").Value,
                                CORPS_MAN = t1.Element("CORPS_MAN").Value,
                                AreaName = t1.Element("LINETYPE").Value,
                                MarketPersonalPrice = t1.Element("MS_PRICE_01").Value,
                                MarketChildPrice = t1.Element("MS_PRICE_02").Value,
                                AgencyPersonalPrice = t1.Element("JS_PRICE_01").Value,
                                AgencyChildPrice = t1.Element("JS_PRICE_02").Value,
                                MUSTER = t1.Element("MUSTER_ADDR").Value,
                                t = from a1 in t1.Element("TRIP").Elements("DATE")
                                    select new
                                    {
                                        DAYS = a1.Element("DAYS").Value,
                                        JOURNEY = a1.Element("JOURNEY").Value,
                                        HOTEL = a1.Element("HOTEL").Value,
                                        EAT = a1.Element("EAT").Value,
                                        PIC = a1.Element("PIC").Value
                                    },
                                PRICE = from a2 in t1.Document.Descendants("PRICE")
                                        select new
                                        {
                                            DATE = a2.Element("DATE").Value,
                                            MarketPersonalPrice = a2.Element("MS_PRICE_01").Value,
                                            MarketChildPrice = a2.Element("MS_PRICE_02").Value,
                                            AgencyPersonalPrice = a2.Element("JS_PRICE_01").Value,
                                            AgencyChildPrice = a2.Element("JS_PRICE_02").Value,
                                            TourManRemnant = a2.Element("NUM").Value,
                                        },
                                LINE_CHARA = t1.Element("LINE_CHARA").Value,
                                SERVICES = t1.Element("SERVICES").Value,
                                ITEM = t1.Element("ITEM").Value,
                                PROCEEDING_01 = t1.Element("PROCEEDING_01").Value,
                                PROCEEDING_02 = t1.Element("PROCEEDING_02").Value,
                                PRICEBH_01 = t1.Element("PRICEBH_01").Value,
                                PRICEBH_02 = t1.Element("PRICEBH_02").Value,
                                SHOP = t1.Element("SHOP").Value,
                                ERTONG = t1.Element("ERTONG").Value,
                                ZSONG = t1.Element("ZSONG").Value,
                                QIJIA = t1.Element("QIJIA").Value,
                                CLOSEDAYS = t1.Element("CLOSEDAYS").Value
                            };
                foreach (var a1 in model)
                {

                    MXianLuInfo_BokServcice TourModel = new MXianLuInfo_BokServcice();
                    string XianLuID = "";
                    TourModel.LineID = a1.LineId;
                    TourModel.XianLuId = XianLuID;
                    TourModel.AreaId = 0;//线路区域
                    //TourModel.RouteName = "";
                    //TourModel.TianShu ="";

                    TourModel.DepProvinceId = 0;//出发地省份编号
                    TourModel.DepCityId = 0;//出发地城市编号
                    TourModel.ArrProvinceId = 0;//目的地省份编号
                    TourModel.ArrCityId = 0;//目的地城市编号

                    TourModel.JiHuaRenShu = 0;//计划人数


                    //TourModel.JSJCR = int.Parse(a1.AgencyPersonalPrice);
                    //TourModel.JSJET = int.Parse(a1.AgencyPersonalPrice);
                    //TourModel.SCJCR = int.Parse(a1.MarketPersonalPrice);
                    //TourModel.SCJET = int.Parse(a1.MarketChildPrice);

                    TourModel.TingTianShu = int.Parse(a1.CLOSEDAYS);//提前X天报名
                    TourModel.ChuFaJiaoTong = "";//出发交通
                    TourModel.FanChengJiaoTong = "";//返程交通
                    TourModel.JiHeFangShi = a1.MUSTER;
                    TourModel.TeSe = a1.RouteRemark;//特色描述文字
                    TourModel.TeSeFilePath = "";//特色描述图片
                    TourModel.TuJing = "";//途径
                    TourModel.QianZheng = "";//签证资料
                    TourModel.QianZhengFilePath = "";//签证说明
                    TourModel.GuanZhuShu = 0;//关注数
                    //TourModel.AreaName = a1.AreaName;

                    #region 行程安排
                    List<MXianLuXingChengInfo_BokServcice> Ixingcheng = new List<MXianLuXingChengInfo_BokServcice>();
                    foreach (var t in a1.t)
                    {
                        MXianLuXingChengInfo_BokServcice XingCheng = new MXianLuXingChengInfo_BokServcice();
                        XingCheng.QuJian = "";
                        XingCheng.JiaoTong = "";
                        XingCheng.XingCheng = t.JOURNEY;
                        XingCheng.ZhuSu = t.HOTEL;
                        XingCheng.YongCan = t.EAT;
                        XingCheng.FilePath = t.PIC;
                        Ixingcheng.Add(XingCheng);
                    }
                    #endregion
                    TourModel.XingChengs = Ixingcheng;

                    #region 发班信息集合
                    List<MXianLuTourInfo_BokServcice> XianLuList = new List<MXianLuTourInfo_BokServcice>();
                    foreach (var b1 in a1.PRICE)
                    {
                        MXianLuTourInfo_BokServcice info = new MXianLuTourInfo_BokServcice()
                        {
                            TourId = XianLuID,
                            LDate = DateTime.Parse(b1.DATE),
                            RDate = DateTime.Parse(b1.DATE).AddDays(int.Parse(a1.TourDays)),
                            DingDanShu = 0,
                            YiShouRenShu = 0,
                            ShiShouRenShu = 0,
                            Status = ShouKeZhuangTai.正常,
                            SYRS = int.Parse(b1.TourManRemnant),
                            JSJCR = int.Parse(b1.AgencyPersonalPrice),
                            JSJET = int.Parse(b1.AgencyChildPrice),
                            CRSCJ = int.Parse(b1.MarketPersonalPrice),
                            ETSCJ = int.Parse(b1.MarketChildPrice),
                        };

                        if (DateTime.Today.AddDays(int.Parse(a1.CLOSEDAYS)) >= info.LDate)
                        {
                            info.Status = ShouKeZhuangTai.停收;
                        }
                        XianLuList.Add(info);
                    }
                    #endregion
                    TourModel.Tours = XianLuList;

                    TourModel.LxrName = a1.CORPS_MAN;
                    TourModel.LxrTelephone = string.Empty;
                    TourModel.LxrMobile = a1.CORPS_MAN;
                    TourModel.LxrQQ = string.Empty;


                    TourModel.Description = "";//description
                    TourModel.Keywords = "";//Keywords
                    TourModel.IssueTime = DateTime.Now;

                    MXianLuFuWuInfo_BokServcice FuWuInfo = new MXianLuFuWuInfo_BokServcice()
                    {
                        FuWuBiaoZhun = a1.PRICEBH_01,
                        BuHanXiangMu = a1.PRICEBH_02,
                        GouWuAnPai = a1.SHOP,
                        ErTongAnPai = a1.ERTONG,
                        ZiFeiXiangMu = a1.ITEM,
                        ZhuYiShiXiang = a1.PROCEEDING_01,
                        WenXinTiXing = a1.SERVICES,
                        BaoMingXuZhi = a1.QIJIA,
                        ZengSongXiangMu = a1.ZSONG,
                        QiTaShiXiang = a1.PROCEEDING_02
                    };
                    TourModel.FuWu = FuWuInfo;
                    LineList = TourModel;
                }
            }
            catch
            {

            }
            return LineList;
        }

        /// <summary>
        /// 博客下单
        /// </summary>
        [ContractName("setLineOrder")]
        public int SetLineOrder(EyouSoft.Model.XianLuStructure.MXianLuInfo tinfo, EyouSoft.Model.XianLuStructure.MOrderInfo OrderInfo)
        {
            string youke = string.Empty;//格式” AAA,1,1,111|BBB,2,2,222” 从左至右依次为”姓名,性别,成人/儿童,证件号码”

            if (OrderInfo.YouKes != null && OrderInfo.YouKes.Count > 0)
            {
                foreach (var item in OrderInfo.YouKes)
                {
                    youke += item.Name + ",";
                    youke += (item.Gender == EyouSoft.Model.Enum.Gender.男 ? "1" : "2") + ",";
                    youke += ",";
                    youke += item.ZhengJianCode + "|";
                }

                if (!string.IsNullOrEmpty(youke))
                {
                    youke = youke.TrimEnd('|');
                    youke = System.Web.HttpContext.Current.Server.UrlEncode(youke);
                }
            }

            object[] parameters = null;

            if (tinfo.LineType == EyouSoft.Model.XianLuStructure.LineType.长线)
            {
                parameters = new object[] { loginName, loginPassword, tinfo.LineID.ToString(), OrderInfo.TrafficId, OrderInfo.LDate.ToString("yyyy-MM-dd"), OrderInfo.ChengRenShu.ToString(), OrderInfo.ErTongShu.ToString(), youke };
            }
            else if (tinfo.LineType == EyouSoft.Model.XianLuStructure.LineType.短线)
            {
                parameters = new object[] { loginName, loginPassword, tinfo.LineID.ToString(), OrderInfo.LDate.ToString("yyyy-MM-dd"), OrderInfo.ChengRenShu.ToString(), OrderInfo.ErTongShu.ToString(), youke };
            }

            string xml = this.GetResponseString(parameters);

            if (string.IsNullOrEmpty(xml)) return 0;

            var xrss = XElement.Parse(xml);

            var xERRORS = StringExtensions.GetXElement(xrss, "ERRORS");
            var xERROR = StringExtensions.GetXElement(xERRORS, "ERROR");
            string errorCode = StringExtensions.GetXAttributeValue(xERROR, "ERRORCODE");

            if (!string.IsNullOrEmpty(errorCode))
            {
                if (errorCode == "50") return -1;//客满

                return 0;
            }

            var xORDER = StringExtensions.GetXElement(xrss, "ORDER");
            var xORDER_ID = StringExtensions.GetXElement(xORDER, "ORDER_ID");
            var xLINENAME = StringExtensions.GetXElement(xORDER, "LINENAME");
            var xTRAFFIC_01 = StringExtensions.GetXElement(xORDER, "TRAFFIC_01");
            var xTRAFFIC_02 = StringExtensions.GetXElement(xORDER, "TRAFFIC_02");
            var xTOURDATE = StringExtensions.GetXElement(xORDER, "TOURDATE");
            var xAMOUNT_01 = StringExtensions.GetXElement(xORDER, "AMOUNT_01");
            var xAMOUNT_02 = StringExtensions.GetXElement(xORDER, "AMOUNT_02");
            var xPRICE_01 = StringExtensions.GetXElement(xORDER, "PRICE_01");
            var xPRICE_02 = StringExtensions.GetXElement(xORDER, "PRICE_02");
            var xPRICE_ALL = StringExtensions.GetXElement(xORDER, "PRICE_ALL");
            var xINTRO = StringExtensions.GetXElement(xORDER, "INTRO");
            var xSTATUS = StringExtensions.GetXElement(xORDER, "STATUS");
            var xGUEST = StringExtensions.GetXElements(xORDER, "GUEST");

            OrderInfo.Api_OrderId = StringExtensions.GetXElementValue(xORDER_ID);

            return Convert.ToInt32(OrderInfo.Api_OrderId);
        }

        /// <summary>
        /// 博客下单
        /// </summary>
        [ContractName("setShortOrder")]
        public int SetShortOrder(EyouSoft.Model.XianLuStructure.MXianLuInfo tinfo, EyouSoft.Model.XianLuStructure.MOrderInfo OrderInfo)
        {
            string youke = string.Empty;//格式” AAA,1,1,111|BBB,2,2,222” 从左至右依次为”姓名,性别,成人/儿童,证件号码”

            if (OrderInfo.YouKes != null && OrderInfo.YouKes.Count > 0)
            {
                foreach (var item in OrderInfo.YouKes)
                {
                    youke += item.Name + ",";
                    youke += (item.Gender == EyouSoft.Model.Enum.Gender.男 ? "1" : "2") + ",";
                    youke += ",";
                    youke += item.ZhengJianCode + "|";
                }

                if (!string.IsNullOrEmpty(youke))
                {
                    youke = youke.TrimEnd('|');
                    youke = System.Web.HttpContext.Current.Server.UrlEncode(youke);
                }
            }

            object[] parameters = null;

            if (tinfo.LineType == EyouSoft.Model.XianLuStructure.LineType.长线)
            {
                parameters = new object[] { loginName, loginPassword, tinfo.LineID.ToString(), OrderInfo.TrafficId, OrderInfo.LDate.ToString("yyyy-MM-dd"), OrderInfo.ChengRenShu.ToString(), OrderInfo.ErTongShu.ToString(), youke };
            }
            else if (tinfo.LineType == EyouSoft.Model.XianLuStructure.LineType.短线)
            {
                parameters = new object[] { loginName, loginPassword, tinfo.LineID.ToString(), OrderInfo.LDate.ToString("yyyy-MM-dd"), OrderInfo.ChengRenShu.ToString(), OrderInfo.ErTongShu.ToString(), youke };
            }

            string xml = this.GetResponseString(parameters);

            if (string.IsNullOrEmpty(xml)) return 0;

            var xrss = XElement.Parse(xml);

            var xERRORS = StringExtensions.GetXElement(xrss, "ERRORS");
            var xERROR = StringExtensions.GetXElement(xERRORS, "ERROR");
            string errorCode = StringExtensions.GetXAttributeValue(xERROR, "ERRORCODE");

            if (!string.IsNullOrEmpty(errorCode))
            {
                if (errorCode == "50") return -1;//客满

                return 0;
            }

            var xORDER = StringExtensions.GetXElement(xrss, "ORDER");
            var xORDER_ID = StringExtensions.GetXElement(xORDER, "ORDER_ID");
            var xLINENAME = StringExtensions.GetXElement(xORDER, "LINENAME");
            var xTRAFFIC_01 = StringExtensions.GetXElement(xORDER, "TRAFFIC_01");
            var xTRAFFIC_02 = StringExtensions.GetXElement(xORDER, "TRAFFIC_02");
            var xTOURDATE = StringExtensions.GetXElement(xORDER, "TOURDATE");
            var xAMOUNT_01 = StringExtensions.GetXElement(xORDER, "AMOUNT_01");
            var xAMOUNT_02 = StringExtensions.GetXElement(xORDER, "AMOUNT_02");
            var xPRICE_01 = StringExtensions.GetXElement(xORDER, "PRICE_01");
            var xPRICE_02 = StringExtensions.GetXElement(xORDER, "PRICE_02");
            var xPRICE_ALL = StringExtensions.GetXElement(xORDER, "PRICE_ALL");
            var xINTRO = StringExtensions.GetXElement(xORDER, "INTRO");
            var xSTATUS = StringExtensions.GetXElement(xORDER, "STATUS");
            var xGUEST = StringExtensions.GetXElements(xORDER, "GUEST");

            OrderInfo.Api_OrderId = StringExtensions.GetXElementValue(xORDER_ID);

            return Convert.ToInt32(OrderInfo.Api_OrderId);
        }
    }
}
