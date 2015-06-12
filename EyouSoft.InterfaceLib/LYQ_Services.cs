using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Models.LYQ;
using System.Configuration;
using EyouSoft.InterfaceLib.Common;
using EyouSoft.Model.XianLuStructure;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.InterfaceLib
{
    public class LYQ_Services
    {
        string lyq_BusinessKey = ConfigurationManager.AppSettings["lyqKey"];
        string lyq_BusinessAddress = ConfigurationManager.AppSettings["lyqAddress"];
        string lyq_BusinessAddressNoXML = ConfigurationManager.AppSettings["lyqAddressNoXML"];
        /// <summary>
        /// 更新产品信息
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public MXianLuInfo GetModels(string productID)
        {
            MXianLuInfo retModel = new MXianLuInfo();
            string url = string.Format("{0}/BusinessOpenAPIService.svc/GetProduct", lyq_BusinessAddressNoXML);
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            //设置ContentType为Xml
            req.ContentType = "application/xml";
            //设置为POST请求
            req.Method = "POST";
            //拼接请求XML字符串
            StringBuilder sb = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.Append("<GetProductRequest xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            sb.AppendFormat("<SecretKey>{0}</SecretKey>", lyq_BusinessKey);
            sb.Append("<ProductIDs>");
            sb.AppendFormat("<ProductID>{0}</ProductID>", productID);
            sb.Append("</ProductIDs>");
            sb.Append("<Type>0</Type>");
            sb.Append("</GetProductRequest>");
            //将XML字符写入请求流中
            byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
            req.ContentLength = bytes.Length;
            Stream stream = req.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            //获取请求结果
            HttpWebResponse rep = req.GetResponse() as HttpWebResponse;
            //解析响应流
            StreamReader reader = new StreamReader(rep.GetResponseStream(), Encoding.UTF8);
            string str = reader.ReadToEnd().Trim();
            BusinessOpenAPIGetProductRepDTO pModel = new BusinessOpenAPIGetProductRepDTO();
            XmlSerializer serializer = new XmlSerializer(typeof(BusinessOpenAPIGetProductRepDTO));
            pModel = Utils.Deserialize<BusinessOpenAPIGetProductRepDTO>(str, Encoding.UTF8);
            reader.Close();
            List<BusinessProductXmlEntity> models = new List<BusinessProductXmlEntity>();
            models = pModel.ProductXmlEntityList;
            foreach (BusinessProductXmlEntity item in models)
            {
                if (!item.IsOnline) continue;
                if (item.ProductName.IndexOf("台湾") >= 0) continue;

                #region 航班信息
                List<MXianLuTourTraffice> tourTraffices = new List<MXianLuTourTraffice>();
                //List<MXianLuTourTraffice> TrafficeList = new List<MXianLuTourTraffice>();
                foreach (var itemTraffice in item.ProductCabinTypeList)
                {
                    MXianLuTourTraffice traffice = new MXianLuTourTraffice()
                    {
                        TourId = item.ProductID,
                        Traffic_01 = "待定",
                        Traffic_02 = "待定",
                        TrafficId = itemTraffice.CabinTypeID

                    };
                    tourTraffices.Add(traffice);
                }
                #endregion

                #region 服务
                MXianLuFuWuInfo xianluFuWu = new MXianLuFuWuInfo()
                {
                    FuWuBiaoZhun = "",
                    BuHanXiangMu = item.PriceNotInclude,
                    GouWuAnPai = "",
                    ErTongAnPai = "",
                    ZiFeiXiangMu = "",
                    ZhuYiShiXiang = "",
                    WenXinTiXing = "",
                    BaoMingXuZhi = item.BookMustKnow
                };
                #endregion

                #region  行程
                List<MXianLuXingChengInfo> XingChengs = new List<MXianLuXingChengInfo>();
                foreach (var itemXingCheng in item.ProductJourneyList)
                {
                    MXianLuXingChengInfo XingChengInfo = new MXianLuXingChengInfo();
                    if (itemXingCheng.JourneyImageList.Any() && itemXingCheng.JourneyImageList.Count > 0)
                    {
                        XingChengInfo.FilePath = itemXingCheng.JourneyImageList[0].Url;
                    }
                    XingChengInfo.JiaoTong = item.TrafficType;
                    XingChengInfo.QuJian = itemXingCheng.JourneyRang;
                    XingChengInfo.XingCheng = itemXingCheng.JourneyDetail;
                    if (itemXingCheng.IsHaveBreakfast)
                        XingChengInfo.YongCan += "早";
                    if (itemXingCheng.IsHaveLunch)
                        XingChengInfo.YongCan += "中";
                    if (itemXingCheng.IsHaveDinner)
                        XingChengInfo.YongCan += "晚";
                    if (itemXingCheng.IsHaveStay)
                        XingChengInfo.ZhuSu = itemXingCheng.StayDesc;
                    XingChengs.Add(XingChengInfo);
                }
                #endregion

                #region 发班周期
                List<MXianLuTourInfo> TourTime = new List<MXianLuTourInfo>();
                //List<MXianLuTourTraffice> TrafficeList = new List<MXianLuTourTraffice>();
                foreach (var itemFaBan in item.ProductScheduleList)
                {
                    if (!tourTraffices.Any() || tourTraffices.Count == 0)
                    {
                        MXianLuTourInfo TourModel = new MXianLuTourInfo()
                        {
                            LDate = itemFaBan.ScheduleDate,
                            RDate = itemFaBan.ScheduleDate.AddDays(item.JourneyDays),
                            DingDanShu = 0,
                            YiShouRenShu = 0,
                            ShiShouRenShu = 0,
                            Status = itemFaBan.ScheduleDate.AddDays(-item.SignUpEndDays) > DateTime.Today ? ShouKeZhuangTai.正常 : ShouKeZhuangTai.停收,
                            JSJCR = itemFaBan.PersonPeerPrice,
                            JSJET = itemFaBan.ChildPeerPrice,
                            SYRS = 99,//itemFaBan.StockCount,
                            CRSCJ = itemFaBan.PersonPrice,
                            ETSCJ = itemFaBan.ChildPrice
                        };
                        TourTime.Add(TourModel);
                    }
                    else
                    {
                        foreach (var tourTraffice in item.ProductCabinTypeList)
                        {


                            MXianLuTourInfo TourModel = new MXianLuTourInfo()
                            {
                                LDate = itemFaBan.ScheduleDate,
                                RDate = itemFaBan.ScheduleDate.AddDays(item.JourneyDays),
                                DingDanShu = 0,
                                YiShouRenShu = 0,
                                ShiShouRenShu = 0,
                                Status = itemFaBan.ScheduleDate.AddDays(-item.SignUpEndDays) > DateTime.Today ? ShouKeZhuangTai.正常 : ShouKeZhuangTai.停收,
                                JSJCR = tourTraffice.FirstAndSecondPeerPrice,
                                JSJET = tourTraffice.ThirdAndFourthPeerPrice,
                                SYRS = 99,//itemFaBan.StockCount,
                                CRSCJ = tourTraffice.FirstAndSecondPrice,
                                ETSCJ = tourTraffice.ThirdAndFourthPrice,
                                TrafficId = tourTraffice.CabinTypeID
                            };
                            TourTime.Add(TourModel);
                        }
                    }
                }



                #endregion

                #region 特色图片
                List<MFileInfo> TeSeFilesList = new List<MFileInfo>();
                foreach (var itemTeSe in item.PicList)
                {
                    TeSeFilesList.Add(new MFileInfo()
                    {
                        FilePath = itemTeSe
                    });
                }
                #endregion

                #region  线路

                var lowModel = TourTime.OrderBy(x => x.CRSCJ).First();
                MXianLuInfo xianlu = new MXianLuInfo()
                {
                    RouteName = item.ProductName,
                    TianShu = item.JourneyDays,
                    SCJCR = lowModel.CRSCJ,
                    SCJET = lowModel.ETSCJ,
                    JSJCR = lowModel.JSJCR,
                    JSJET = lowModel.JSJET,
                    JiHeFangShi = "",
                    LxrName = "",
                    LxrTelephone = "",
                    XingChengs = XingChengs,
                    FuWu = xianluFuWu,
                    Tours = TourTime,
                    AreaName = item.SecondLevelArea,
                    OperatorId = 1,
                    LineID = item.ProductID,
                    Line_Source = LineSource.旅游圈,
                    TeSeFilePath = string.Empty,
                    LineType = getType(item.TravelType),
                    TeSeFiles = TeSeFilesList,
                    TourTraffice = tourTraffices,
                    CFCS = item.StartCity,
                    TingTianShu = item.SignUpEndDays,
                    QianZheng = item.VisaInfo,
                    TeSe = ""
                };
                #endregion
                retModel = xianlu;
            }
            return retModel;
        }
        /// <summary>
        /// 获取下单结果
        /// </summary>
        /// <param name="tinfo"></param>
        /// <param name="OrderInfo"></param>
        /// <returns></returns>
        public bool getRequest(EyouSoft.Model.XianLuStructure.MXianLuInfo tinfo, EyouSoft.Model.XianLuStructure.MOrderInfo OrderInfo)
        {
            string url = "http://servicetest.lvyouquan.cn/BusinessOpenAPIService.svc/CreateOrder";
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            //设置ContentType为Xml
            req.ContentType = "application/xml";
            //设置为POST请求
            req.Method = "POST";
            //拼接请求XML字符串
            StringBuilder sb = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.Append("<CreateOrderRequest xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            sb.AppendFormat("<SecretKey>{0}</SecretKey>", lyq_BusinessKey);
            sb.AppendFormat("<ProductID>{0}</ProductID>", tinfo.XianLuId);
            sb.AppendFormat("<ScheduleID>{0}</ScheduleID>", OrderInfo.TourId);
            sb.AppendFormat("<PersonCount>{0}</PersonCount>", OrderInfo.ChengRenShu);
            sb.AppendFormat("<ChildCount>{0}</ChildCount>", OrderInfo.ErTongShu);
            sb.AppendFormat("<ContactName>{0}</ContactName>", OrderInfo.MemberName);
            sb.AppendFormat("<ContactTel>{0}</ContactTel>", OrderInfo.Mobile);
            sb.AppendFormat("<Remark>{0}</Remark>", OrderInfo.XiaDanBeiZhu);
            sb.Append("</CreateOrderRequest>");
            //将XML字符写入请求流中
            byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
            req.ContentLength = bytes.Length;
            Stream stream = req.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            //获取请求结果
            HttpWebResponse rep = req.GetResponse() as HttpWebResponse;
            //解析响应流
            StreamReader reader = new StreamReader(rep.GetResponseStream(), Encoding.UTF8);
            //str为返回的xml字符串
            string str = reader.ReadToEnd().Trim();
            //解析TotalXml
            //resultXML.DescendantNodes("XmlFileCount").First().V

            XDocument docXML = XDocument.Parse(str);
            //获取Xml文件个数
            bool resultXML = Convert.ToBoolean(docXML.Descendants("IsSuccess").First().Value);
            //string orderCode = string.Empty;
            //if (resultXML) orderCode = docXML.Descendants("OrderCode").First().Value;
            reader.Close();
            return resultXML;
        }

        /// <summary>
        /// 获取线路类型
        /// </summary>
        /// <param name="typeStr"></param>
        /// <returns></returns>
        LineType getType(string typeStr)
        {
            LineType reType;
            switch (typeStr)
            {
                case "出境游":
                    reType = LineType.出境;
                    break;
                case "国内游":
                    reType = LineType.长线;
                    break;
                case "周边游":
                    reType = LineType.短线;
                    break;
                default:
                    reType = LineType.长线;
                    break;
            }
            return reType;
        }

    }
}
