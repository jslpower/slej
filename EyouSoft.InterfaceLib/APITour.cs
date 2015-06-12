using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.XianLuStructure;
using System.Xml.Linq;
using EyouSoft.InterfaceLib.Attributes;
using EyouSoft.InterfaceLib.Models.Bok;
using EyouSoft.InterfaceLib.Common;
using EyouSoft.Model;
using EyouSoft.InterfaceLib.Common.StringHelper;
using EyouSoft.InterfaceLib;
using System.Configuration;
using EyouSoft.InterfaceLib.Request.ZL;
using EyouSoft.InterfaceLib.Request.GDWX;
using EyouSoft.InterfaceLib.Models.LYQ;

namespace EyouSoft.InterfaceLib
{
    public class APITour
    {
        BokServiceSeeker bokService = new BokServiceSeeker();
        ZLCommonServiceSeeker zlService = new ZLCommonServiceSeeker();
        EyouSoft.InterfaceLib.GDWX.Lib.GDWXSeeker gdService = new EyouSoft.InterfaceLib.GDWX.Lib.GDWXSeeker();
        List<BusinessProductXmlEntity> LyProducts = new List<BusinessProductXmlEntity>();
        List<MXianLuTourInfo> TourTime = new List<MXianLuTourInfo>();
        List<MXianLuTourTraffice> TrafficeList = new List<MXianLuTourTraffice>();

        public EyouSoft.Model.XianLuStructure.MXianLuInfo SyncTour(EyouSoft.Model.XianLuStructure.MXianLuInfo tinfo)
        {


            switch (tinfo.Line_Source)
            {
                case EyouSoft.Model.XianLuStructure.LineSource.博客:

                    if (tinfo.LineType == LineType.长线)
                    {
                        var Detail = bokService.GetLineDetail(tinfo.LineID.ToString());
                        if (Detail.LineID == "0" || Detail.Tours == null || Detail.Tours.Count <= 0)
                        {
                            foreach (MXianLuTourInfo t in tinfo.Tours)
                            {
                                t.Status = EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收;
                            }
                            new EyouSoft.DAL.XianLuStructure.DXianLu().UpdateToursDataLS(tinfo);
                            return tinfo;
                        }

                        MXianLuInfo model = new MXianLuInfo()
                        {
                            XianLuId = "",
                            RouteName = Detail.RouteName,
                            TianShu = Detail.TianShu,
                            SCJCR = Detail.SCJCR,
                            SCJET = Detail.SCJET,
                            JSJCR = Detail.JSJCR,
                            JSJET = Detail.JSJET,
                            JiHeFangShi = Detail.JiHeFangShi,
                            LxrName = Detail.LxrName,
                            LxrTelephone = Detail.LxrTelephone,
                            XingChengs = Detail.XingChengs != null && Detail.XingChengs.Count > 0 ? Detail.XingChengs.Select(x => x.ConvertTo<MXianLuXingChengInfo>()).ToList() : null,
                            FuWu = Detail.FuWu.ConvertTo<MXianLuFuWuInfo>(),

                            TourTraffice = Detail.TrafficeList != null && Detail.TrafficeList.Count > 0 ? Detail.TrafficeList.Select(x => x.ConvertTo<MXianLuTourTraffice>()).ToList() : null,
                            AreaName = Detail.AreaName,
                            OperatorId = 1,
                            LineID = Detail.LineID.ToString(),
                            LineType = LineType.长线,
                            Line_Source = LineSource.博客,
                            CFCS = Detail.CFCS,
                            TingTianShu = Detail.TingTianShu
                        };

                        if (Detail.Tours != null && Detail.Tours.Count > 0)
                        {
                            model.Tours = new List<MXianLuTourInfo>();
                            foreach (MXianLuTourInfo_BokServcice bTI in Detail.Tours)
                            {
                                MXianLuTourInfo mTI = new MXianLuTourInfo();
                                mTI.CRSCJ = bTI.CRSCJ;
                                mTI.DingDanShu = bTI.DingDanShu;
                                mTI.ETSCJ = bTI.ETSCJ;
                                mTI.JSJCR = bTI.JSJCR;
                                mTI.JSJET = bTI.JSJET;
                                mTI.LDate = bTI.LDate;
                                mTI.RDate = bTI.RDate;
                                mTI.ShiShouRenShu = bTI.ShiShouRenShu;
                                mTI.Status = bTI.Status == ShouKeZhuangTai.停收 ? EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收 : EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.正常;
                                mTI.SYRS = bTI.SYRS;
                                mTI.TourId = bTI.TourId;
                                mTI.TrafficId = bTI.TrafficId;
                                mTI.YiShouRenShu = bTI.YiShouRenShu;
                                mTI.XianLuID = tinfo.XianLuId;
                                model.Tours.Add(mTI);
                            }

                        }

                        if (model.LineID == "0" || model.Tours == null || model.Tours.Count <= 0)
                        {
                            foreach (MXianLuTourInfo t in tinfo.Tours)
                            {
                                t.Status = EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收;
                            }
                            new EyouSoft.DAL.XianLuStructure.DXianLu().UpdateToursDataLS(tinfo);
                            return tinfo;
                        }
                        else
                        {
                            int i = 0;
                            foreach (MXianLuTourInfo t in tinfo.Tours)
                            {
                                if (model.Tours.Where(x => x.LDate == t.LDate && x.TrafficId == t.TrafficId).ToList().Count <= 0)
                                {
                                    i++;
                                    t.Status = EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收;

                                }
                                else if (DateTime.Today.AddDays(model.TingTianShu) >= t.LDate && t.Status == EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.正常)
                                {
                                    i++;
                                    t.Status = EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收;
                                }
                            }
                            if (i > 0)
                                new EyouSoft.DAL.XianLuStructure.DXianLu().UpdateToursDataLS(tinfo);
                        }

                        tinfo.Tours = model.Tours;
                        tinfo.TourTraffice = model.TourTraffice;


                    }
                    else
                    {
                        var Detail = bokService.GetShortDetail(tinfo.LineID.ToString());
                        if (Detail.LineID == "0" || Detail.Tours == null || Detail.Tours.Count <= 0)
                        {
                            foreach (MXianLuTourInfo t in tinfo.Tours)
                            {
                                t.Status = EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收;
                            }
                            new EyouSoft.DAL.XianLuStructure.DXianLu().UpdateToursDataLS(tinfo);
                            return tinfo;
                        }
                        MXianLuInfo model = new MXianLuInfo()
                        {
                            XianLuId = "",
                            RouteName = Detail.RouteName,
                            TianShu = Detail.TianShu,
                            SCJCR = Detail.SCJCR,
                            SCJET = Detail.SCJET,
                            JSJCR = Detail.JSJCR,
                            JSJET = Detail.JSJET,
                            JiHeFangShi = Detail.JiHeFangShi,
                            LxrName = Detail.LxrName,
                            LxrTelephone = Detail.LxrTelephone,
                            XingChengs = Detail.XingChengs.Select(x => x.ConvertTo<MXianLuXingChengInfo>()).ToList(),
                            FuWu = Detail.FuWu.ConvertTo<MXianLuFuWuInfo>(),

                            AreaName = Detail.AreaName,
                            OperatorId = 1,
                            LineID = Detail.LineID.ToString(),
                            LineType = LineType.短线,
                            Line_Source = LineSource.博客,
                            CFCS = Detail.CFCS,
                            TingTianShu = Detail.TingTianShu
                        };

                        if (Detail.Tours != null && Detail.Tours.Count > 0)
                        {
                            model.Tours = new List<MXianLuTourInfo>();

                            foreach (MXianLuTourInfo_BokServcice bTI in Detail.Tours)
                            {
                                MXianLuTourInfo mTI = new MXianLuTourInfo();
                                mTI.CRSCJ = bTI.CRSCJ;
                                mTI.DingDanShu = bTI.DingDanShu;
                                mTI.ETSCJ = bTI.ETSCJ;
                                mTI.JSJCR = bTI.JSJCR;
                                mTI.JSJET = bTI.JSJET;
                                mTI.LDate = bTI.LDate;
                                mTI.RDate = bTI.RDate;
                                mTI.ShiShouRenShu = bTI.ShiShouRenShu;
                                mTI.Status = bTI.Status == ShouKeZhuangTai.停收 ? EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收 : EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.正常;
                                mTI.SYRS = bTI.SYRS;
                                mTI.TourId = bTI.TourId;
                                mTI.TrafficId = bTI.TrafficId;
                                mTI.YiShouRenShu = bTI.YiShouRenShu;
                                mTI.XianLuID = tinfo.XianLuId;
                                model.Tours.Add(mTI);
                            }
                        }
                        if (model.LineID == "0" || model.Tours == null || model.Tours.Count <= 0)
                        {
                            foreach (MXianLuTourInfo t in tinfo.Tours)
                            {
                                t.Status = EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收;
                            }
                            new EyouSoft.DAL.XianLuStructure.DXianLu().UpdateToursDataLS(tinfo);
                            return tinfo;
                        }
                        else
                        {

                            int i = 0;
                            foreach (MXianLuTourInfo t in tinfo.Tours)
                            {
                                if (DateTime.Today.AddDays(model.TingTianShu) >= t.LDate && t.Status == EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.正常)
                                {
                                    i++;
                                    t.Status = EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收;
                                }
                            }

                            if (i > 0)
                                new EyouSoft.DAL.XianLuStructure.DXianLu().UpdateToursDataLS(tinfo);
                        }


                        tinfo.Tours = model.Tours;
                    }



                    break;
                case EyouSoft.Model.XianLuStructure.LineSource.光大:


                    GetXianLuXiangXiRequest postInit = new GetXianLuXiangXiRequest()
                    {
                        usercd = ConfigurationManager.AppSettings["GDWXLoginName"],
                        authno = ConfigurationManager.AppSettings["GDWXPassword"],
                        querytype = EyouSoft.InterfaceLib.GDWX.Interface.Enums.QueryTypes.lineinfo.ToString(),
                        lineids = tinfo.LineID.ToString()
                    };
                    var LineInfo = gdService.GetXianLuXiangXi(postInit);
                    if (LineInfo.data == null || LineInfo.data.Length <= 0)
                    {
                        foreach (MXianLuTourInfo t in tinfo.Tours)
                        {
                            t.Status = EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收;
                        }
                        new EyouSoft.DAL.XianLuStructure.DXianLu().UpdateToursDataLS(tinfo);
                        return tinfo;
                    };


                    #region 发班周期
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
                            LDate = EyouSoft.InterfaceLib.Common.Utils.GetDateTime(itemFaBan.dates_str),
                            RDate = EyouSoft.InterfaceLib.Common.Utils.GetDateTime(itemFaBan.dates_str).AddDays(LineInfo.data[0].days),
                            DingDanShu = itemFaBan.state2_num,
                            YiShouRenShu = 0,
                            ShiShouRenShu = 0,
                            Status = itemFaBan.is_lock == EyouSoft.InterfaceLib.Enums.GDWX.BaoMingJiHua.不可报名 ? EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收 : EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.正常,
                            JSJCR = EyouSoft.InterfaceLib.Common.Utils.GetDecimal(itemFaBan.agent_price1.ToString()),
                            JSJET = EyouSoft.InterfaceLib.Common.Utils.GetDecimal(itemFaBan.agent_price2.ToString()),
                            SYRS = EyouSoft.InterfaceLib.Common.Utils.GetInt(itemFaBan.yu_num.ToString()),
                            CRSCJ = EyouSoft.InterfaceLib.Common.Utils.GetDecimal(itemFaBan.market_price1.ToString()),
                            ETSCJ = EyouSoft.InterfaceLib.Common.Utils.GetDecimal(itemFaBan.market_price2.ToString()),
                            TrafficId = itemFaBan.id.ToString()
                        };
                        if (DateTime.Today.AddDays(itemFaBan.advan_order_days) >= TourModel.LDate)
                        {
                            TourModel.Status = EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收;
                        }
                        TourTime.Add(TourModel);
                    }

                    int li = 0;
                    foreach (MXianLuTourInfo t in tinfo.Tours)
                    {
                        if (TourTime.Where(x => x.LDate == t.LDate).ToList().Count <= 0)
                        {
                            li++;
                            t.Status = EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收;
                        }
                    }

                    if (li > 0)
                        new EyouSoft.DAL.XianLuStructure.DXianLu().UpdateToursDataLS(tinfo);
                    #endregion


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
                        Tours = TourTime,
                        AreaName = LineInfo.data[0].area_parent_title,
                        OperatorId = 1,
                        LineID = LineInfo.data[0].id.ToString(),
                        Line_Source = LineSource.光大,
                        TeSeFilePath = string.Empty,
                        TourTraffice = TrafficeList,
                        CFCS = LineInfo.data[0].city_title
                    };

                    tinfo.Tours = TourTime;
                    tinfo.TourTraffice = TrafficeList;

                    break;
                case EyouSoft.Model.XianLuStructure.LineSource.省中旅:

                    #region 请求
                    get_obd_group_detailRequest request = new get_obd_group_detailRequest()
                    {
                        user_key = ConfigurationManager.AppSettings["ZLCommonLoginName"],
                        password = ConfigurationManager.AppSettings["ZLCommonPassword"],
                        sid = Utils.GetInt(tinfo.LineID)
                    };
                    #endregion

                    var DetailZL = zlService.get_obd_group_detail(request);
                    if (DetailZL == null || DetailZL.result_id != 0)
                    {
                        foreach (MXianLuTourInfo t in tinfo.Tours)
                        {
                            t.Status = EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收;
                        }
                        new EyouSoft.DAL.XianLuStructure.DXianLu().UpdateToursDataLS(tinfo);
                        return tinfo;
                    }

                    if (EyouSoft.InterfaceLib.Common.Utils.GetDateTime(DetailZL.group_header.ShutDate) < DateTime.Today)
                    {
                        foreach (MXianLuTourInfo t in tinfo.Tours)
                        {
                            t.Status = EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收;
                        }
                        new EyouSoft.DAL.XianLuStructure.DXianLu().UpdateToursDataLS(tinfo);
                        return tinfo;
                    }




                    #region 发班周期
                    MXianLuTourInfo Tours = new MXianLuTourInfo()
                    {
                        LDate = EyouSoft.InterfaceLib.Common.Utils.GetDateTime(DetailZL.group_header.LeftDate),
                        RDate = EyouSoft.InterfaceLib.Common.Utils.GetDateTime(DetailZL.group_header.BackDate),
                        DingDanShu = 0,
                        YiShouRenShu = 0,
                        ShiShouRenShu = 0,
                        Status = DetailZL.group_header.StepID == EyouSoft.InterfaceLib.Models.ZL.Steps.收客中 ? EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.正常 : EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收,
                        JSJCR = EyouSoft.InterfaceLib.Common.Utils.GetDecimal(DetailZL.group_header.AdultPriceI.ToString()),
                        JSJET = EyouSoft.InterfaceLib.Common.Utils.GetDecimal(DetailZL.group_header.ChildPriceI.ToString()),
                        CRSCJ = EyouSoft.InterfaceLib.Common.Utils.GetDecimal(DetailZL.group_header.AdultPrice.ToString()),
                        ETSCJ = EyouSoft.InterfaceLib.Common.Utils.GetDecimal(DetailZL.group_header.ChildPrice.ToString()),

                        SYRS = DetailZL.group_header.LeftNum
                    };
                    TourTime.Add(Tours);
                    #endregion

                    tinfo.Tours = TourTime;

                    break;

                case LineSource.旅游圈:
                    var get_lyq_xianlu = new LYQ_Services().GetModels(tinfo.LineID);
                    foreach (MXianLuTourInfo t in tinfo.Tours)
                    {
                        if (t.LDate.AddDays(-tinfo.TingTianShu) < DateTime.Now)
                            t.Status = EyouSoft.Model.Enum.XianLuStructure.ShouKeZhuangTai.停收;
                    }
                    new EyouSoft.DAL.XianLuStructure.DXianLu().UpdateToursDataLS(tinfo);
                    return tinfo;
                    break;

            }
            new EyouSoft.DAL.XianLuStructure.DXianLu().UpdateToursTra(tinfo);
            new EyouSoft.DAL.XianLuStructure.DXianLu().UpdateToursDataLS(tinfo);
            return tinfo;
        }
    }
}
