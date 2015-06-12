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
using EyouSoft.Model.XianLuStructure;
using EyouSoft.Common;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.BLL.XianLuStructure;

namespace ConsoleApp
{
    class CL_LYQ
    {
        string lyq_BusinessKey = ConfigurationManager.AppSettings["lyqKey"];
        string lyq_BusinessAddress = ConfigurationManager.AppSettings["lyqAddress"];

        public int GetModels()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Environment.CurrentDirectory + @"\log\srlog_lyq_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", true);
            int c = 0;

            BusinessProductListXmlEntity modellist = new BusinessProductListXmlEntity();
            string url = string.Format("{0}/BusinessXml/{1}/Product/Total.xml", lyq_BusinessAddress, lyq_BusinessKey);
            string requrl = string.Format("{0}/BusinessXml/{1}/Product", lyq_BusinessAddress, lyq_BusinessKey);
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            req.Method = "GET";
            HttpWebResponse rep = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(rep.GetResponseStream(), Encoding.UTF8);
            //获取TotalXml的内容
            string totlXmlStr = reader.ReadToEnd().Trim();
            reader.Close();
            rep.Close();
            reader.Close();
            //解析TotalXml
            XDocument totalXml = XDocument.Parse(totlXmlStr);
            //获取Xml文件个数
            int xmlFileCount = Convert.ToInt32(totalXml.Descendants("XmlFileCount").First().Value);
            if (xmlFileCount <= 0) return 0;
            //获取产品总数
            int productCount = Convert.ToInt32(totalXml.Descendants("ProductCount").First().Value);
            //从1开始，循环获取xml文件
            for (int i = 1; i <= xmlFileCount; i++)
            {
                try
                {
                    //获取每个XML文件
                    req = WebRequest.Create(requrl + "/Detail" + i + ".xml") as HttpWebRequest;
                    req.Method = "GET";
                    rep = req.GetResponse() as HttpWebResponse;
                    reader = new StreamReader(rep.GetResponseStream(), Encoding.UTF8);
                    string strXML = reader.ReadToEnd();
                    XmlSerializer serializer = new XmlSerializer(typeof(BusinessProductListXmlEntity));
                    modellist = Utils.Deserialize<BusinessProductListXmlEntity>(strXML, Encoding.UTF8);
                    if (modellist.ProductList.Any())
                    {
                        foreach (BusinessProductXmlEntity item in modellist.ProductList)
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
                                    Traffic_01 = itemTraffice.CabinName,
                                    Traffic_02 = string.Empty,
                                    TrafficId = itemTraffice.CabinTypeID

                                };
                                tourTraffices.Add(traffice);
                            }
                            #endregion

                            #region 服务
                            MXianLuFuWuInfo xianluFuWu = new MXianLuFuWuInfo()
                            {
                                FuWuBiaoZhun = item.PriceInclude,
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
                                XingChengInfo.FilePath = itemXingCheng.JourneyImageList.Count > 0 ? itemXingCheng.JourneyImageList[0].Url : "";

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
                            StringBuilder strshuoming = new StringBuilder();
                            if (item.SellPointList.Any())
                            {
                                for (int k = 0; k < item.SellPointList.Count; k++)
                                {
                                    strshuoming.Append(item.SellPointList[k]);
                                }
                            }

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
                                TeSe = strshuoming.ToString()
                            };
                            #endregion

                            BXianLu bll = new BXianLu();

                            string ID = bll.ExistsInterfaceID(xianlu.LineID, LineSource.旅游圈);
                            if (!string.IsNullOrEmpty(ID))
                            {
                                xianlu.XianLuId = ID;
                                xianlu.LatestId = 1;
                                xianlu.IssueTime = DateTime.Now;
                                c += bll.OutUpdate(xianlu);
                            }
                            else
                            {
                                c += bll.Insert(xianlu);
                            }
                            Console.WriteLine(item.ProductName);
                            //Console.WriteLine(item.ProductID.ToString());


                            sw.WriteLine(item.ProductName);
                            sw.WriteLine(item.ProductID.ToString());
                        }


                    }
                    reader.Close();
                    rep.Close();
                }
                catch (Exception e)
                {
                    System.IO.StreamWriter swe = new System.IO.StreamWriter(System.Environment.CurrentDirectory + @"\log\" + DateTime.Now.ToFileTime().ToString() + ".log");
                    swe.WriteLine(e.Message);
                    swe.WriteLine(e.Source);
                    swe.WriteLine(e.StackTrace);
                    swe.Close();
                }
            }
            sw.Close();
            return c;
            //if (modellist.ProductList.Any()) return modellist.ProductList;


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
