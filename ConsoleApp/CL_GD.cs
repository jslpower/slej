using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.GDWX.Lib;
using EyouSoft.InterfaceLib.Request.GDWX;
using EyouSoft.Model.XianLuStructure;
using EyouSoft.BLL.XianLuStructure;
using EyouSoft.Common;
using EyouSoft.Model.Enum.XianLuStructure;
using System.Configuration;

namespace ConsoleApp
{
    class CL_GD
    {
        GDWXSeeker gdService = new GDWXSeeker();

        public int GetLine()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Environment.CurrentDirectory + @"\log\srlog_gd_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", true);
            int c = 0;
            try
            {
                var pageindex = 1;
                var pagecount = 0;
                var pagesize = 20;
                var recordercount = 0;
                var x = gdService.GetXianLuList(postInfo(pageindex, pagesize));

                //初始化获取总记录数
                if (x.success == EyouSoft.InterfaceLib.Enums.GDWX.Success.成功 && x != null)
                {
                    recordercount = x.num_rows;
                    pagesize = x.pagesize;
                    pagecount = x.page_count;
                    pageindex = x.page;
                }

                if (recordercount <= 0) return c;

                for (; pageindex <= pagecount; pageindex++)
                {
                    //获取光大微信线路列表
                    x = gdService.GetXianLuList(postInfo(pageindex, pagesize));

                    if (x.success != EyouSoft.InterfaceLib.Enums.GDWX.Success.成功 || x == null || x.data.Count <= 0) continue;

                    foreach (var m in x.data)
                    {
                        if (m.title.IndexOf("台湾") >= 0)
                            continue;
                        GetXianLuXiangXiRequest postInit = new GetXianLuXiangXiRequest()
                        {
                            usercd = ConfigurationManager.AppSettings["GDWXLoginName"],
                            authno = ConfigurationManager.AppSettings["GDWXPassword"],
                            querytype = EyouSoft.InterfaceLib.GDWX.Interface.Enums.QueryTypes.lineinfo.ToString(),
                            lineids = m.id.ToString()
                        };
                        var LineInfo = gdService.GetXianLuXiangXi(postInit);
                        if (LineInfo.data == null || LineInfo.data.Length <= 0) continue;

                        #region 服务
                        MXianLuFuWuInfo xianluFuWu = new MXianLuFuWuInfo()
                        {
                            FuWuBiaoZhun = LineInfo.data[0].test_contains,
                            BuHanXiangMu = LineInfo.data[0].test_exclude,
                            GouWuAnPai = LineInfo.data[0].test_shop,
                            ErTongAnPai = LineInfo.data[0].test_children,
                            ZiFeiXiangMu = "",
                            ZhuYiShiXiang = LineInfo.data[0].test_attention,
                            WenXinTiXing = LineInfo.data[0].test_tips,
                            BaoMingXuZhi = LineInfo.data[0].test_sale
                        };
                        #endregion

                        #region  行程
                        List<MXianLuXingChengInfo> XingChengs = new List<MXianLuXingChengInfo>();
                        foreach (var itemXingCheng in LineInfo.data[0].itinerary)
                        {
                            MXianLuXingChengInfo XingChengInfo = new MXianLuXingChengInfo();
                            XingChengInfo.FilePath = "";
                            switch (itemXingCheng.transport)
                            {
                                case 1:
                                    XingChengInfo.JiaoTong = "火车";
                                    break;
                                case 2:
                                    XingChengInfo.JiaoTong = "轮船";
                                    break;
                                case 3:
                                    XingChengInfo.JiaoTong = "汽车";
                                    break;
                                case 4:
                                    XingChengInfo.JiaoTong = "飞机";
                                    break;
                                default:
                                    XingChengInfo.JiaoTong = "";
                                    break;
                            }
                            XingChengInfo.QuJian = "";
                            XingChengInfo.XingCheng = itemXingCheng.content;
                            if (itemXingCheng.zaocan == 1)
                                XingChengInfo.YongCan += "早";
                            if (itemXingCheng.wucan == 1)
                                XingChengInfo.YongCan += "中";
                            if (itemXingCheng.wancan == 1)
                                XingChengInfo.YongCan += "晚";
                            XingChengInfo.ZhuSu = itemXingCheng.hotel;
                            XingChengs.Add(XingChengInfo);
                        }
                        #endregion

                        #region 发班周期
                        List<MXianLuTourInfo> TourTime = new List<MXianLuTourInfo>();
                        List<MXianLuTourTraffice> TrafficeList = new List<MXianLuTourTraffice>();
                        var tour = LineInfo.data[0].tour.GroupBy(i => i.id).ToArray();
                        for (int i = 0; i < tour.Length; i++)
                        {
                            var item = LineInfo.data[0].tour.Where(p => p.id == tour[i].Key).ToList();
                            foreach (EyouSoft.InterfaceLib.Models.GDWX.FaBan item1 in item)
                            {
                                MXianLuTourTraffice mt = new MXianLuTourTraffice();
                                mt.TrafficId = tour[i].Key.ToString();
                                mt.Traffic_01 = item1.number;
                                TrafficeList.Add(mt);
                            }
                        }

                        foreach (var itemFaBan in LineInfo.data[0].tour)
                        {
                            MXianLuTourInfo TourModel = new MXianLuTourInfo()
                            {
                                LDate = Utils.GetDateTime(itemFaBan.dates_str),
                                RDate = Utils.GetDateTime(itemFaBan.dates_str).AddDays(LineInfo.data[0].days),
                                DingDanShu = itemFaBan.state2_num,
                                YiShouRenShu = 0,
                                ShiShouRenShu = 0,
                                Status = Utils.GetDateTime(itemFaBan.dates_str).AddDays(-itemFaBan.advan_order_days) > DateTime.Today ? (itemFaBan.is_lock == EyouSoft.InterfaceLib.Enums.GDWX.BaoMingJiHua.不可报名 ? ShouKeZhuangTai.停收 : ShouKeZhuangTai.正常) : ShouKeZhuangTai.停收,
                                JSJCR = Utils.GetDecimal(itemFaBan.agent_price1.ToString()),
                                JSJET = Utils.GetDecimal(itemFaBan.agent_price2.ToString()),
                                SYRS = Utils.GetInt(itemFaBan.yu_num.ToString()),
                                CRSCJ = Utils.GetDecimal(itemFaBan.market_price1.ToString()),
                                ETSCJ = Utils.GetDecimal(itemFaBan.market_price2.ToString()),
                                TrafficId = itemFaBan.id.ToString()
                            };
                            TourTime.Add(TourModel);
                        }
                        #endregion

                        List<MFileInfo> TeSeFilesList = new List<MFileInfo>();
                        foreach (var photo in LineInfo.data[0].photo)
                        {
                            MFileInfo file = new MFileInfo() { FilePath = "http://www.gly999.com/" + photo.full_path };
                            TeSeFilesList.Add(file);
                        }


                        MXianLuInfo xianlu = new MXianLuInfo()
                        {
                            RouteName = LineInfo.data[0].title,
                            TianShu = LineInfo.data[0].days,
                            SCJCR = LineInfo.data[0].tour[0].market_price1,
                            SCJET = LineInfo.data[0].tour[0].market_price2,
                            JSJCR = LineInfo.data[0].tour[0].agent_price1,
                            JSJET = LineInfo.data[0].tour[0].agent_price2,
                            JiHeFangShi = "",
                            LxrName = LineInfo.data[0].nickname,
                            LxrTelephone = LineInfo.data[0].tel,
                            XingChengs = XingChengs,
                            FuWu = xianluFuWu,
                            Tours = TourTime,
                            AreaName = LineInfo.data[0].area_parent_title,
                            OperatorId = 1,
                            LineID = LineInfo.data[0].id.ToString(),
                            Line_Source = LineSource.光大,
                            TeSeFilePath = string.Empty,
                            TeSeFiles = TeSeFilesList,
                            TourTraffice = TrafficeList,
                            CFCS = LineInfo.data[0].city_title,
                            TeSe = LineInfo.data[0].test_special
                        };
                        BXianLu bll = new BXianLu();
                        string ID = bll.ExistsInterfaceID(xianlu.LineID.ToString(), LineSource.光大);
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
                        Console.WriteLine(LineInfo.data[0].title);
                        Console.WriteLine(LineInfo.data[0].id.ToString());


                        sw.WriteLine(LineInfo.data[0].title);
                        sw.WriteLine(LineInfo.data[0].id.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                System.IO.StreamWriter swe = new System.IO.StreamWriter(System.Environment.CurrentDirectory + @"\log\" + DateTime.Now.ToFileTime().ToString() + ".log");
                swe.WriteLine(e.Message);
                swe.WriteLine(e.Source);
                swe.WriteLine(e.StackTrace);
                swe.Close();
            }
            finally
            {
                sw.Close();
            }
            return c;
        }

        GetXianLuListRequest postInfo(int PageIndex, int PageSize)
        {
            GetXianLuListRequest model = new GetXianLuListRequest()
            {
                pagesize = PageSize,
                page = PageIndex,
                has_tour = EyouSoft.InterfaceLib.Enums.GDWX.Is.是,
                has_itinerary = EyouSoft.InterfaceLib.Enums.GDWX.Is.否,
                usercd = ConfigurationManager.AppSettings["GDWXLoginName"],
                authno = ConfigurationManager.AppSettings["GDWXPassword"],
                querytype = EyouSoft.InterfaceLib.GDWX.Interface.Enums.QueryTypes.linelist.ToString(),
                type = "1,2,3"
            };

            return model;
        }
    }
}
