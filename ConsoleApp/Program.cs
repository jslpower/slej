using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EyouSoft.InterfaceLib.Attributes;
using EyouSoft.InterfaceLib.Models.Bok;
using EyouSoft.InterfaceLib.Common;
using EyouSoft.Model;
using EyouSoft.InterfaceLib.Common.StringHelper;
using EyouSoft.InterfaceLib;
using EyouSoft.Model.XianLuStructure;
using EyouSoft.BLL.XianLuStructure;

namespace ConsoleApp
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("boktour begin");
            bokLine bk = new bokLine();
            int i = bk.GetLine();
            int i1 = bk.GetShortLine();

            Console.WriteLine("boktour 合计:" + (i + i1));


            ////中旅旅业线路
            Console.WriteLine("中旅旅业线路导入-------------------------开始---------------");
            Console.WriteLine("中旅旅业线路导入合计：{0}----------------结束---------------", new CL_ZL().GetLine());


            ////广大微信线路
            Console.WriteLine("光大微信线路导入-------------------------开始---------------");
            Console.WriteLine("光大微信线路导入合计：{0}----------------结束---------------", new CL_GD().GetLine());



            //旅游圈
            Console.WriteLine("旅游圈线路导入-------------------------开始---------------");
            Console.WriteLine("旅游圈线路导入合计：{0}----------------结束---------------", new CL_LYQ().GetModels());

            //////美景天下景点接口
            //Console.WriteLine("美景天下景点导入-------------------------开始---------------");
            //Console.WriteLine("美景天下景点导入合计：{0}----------------结束---------------", new CL_JQ().AutoTongBuJingQu());

            //Console.ReadKey();

        }
    }

    class bokLine
    {

        BokServiceSeeker bokService = new BokServiceSeeker();

        public int GetLine()
        {
            List<MXianLuInfo> XianLuList = new List<MXianLuInfo>();

            XianLuList = bokService.GetGuoNeiLine().Select(x => x.ConvertTo<MXianLuInfo>()).ToList();

            int num = 0;
            System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Environment.CurrentDirectory + @"\log\srlog_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", true);

            for (int i = 0; i < XianLuList.Count; i++)
            {
                try
                {
                    num++;
                    var item = XianLuList[i];
                    var Detail = bokService.GetLineDetail(item.LineID.ToString());
                    MXianLuInfo model = new MXianLuInfo()
                    {
                        XianLuId = "",
                        RouteName = item.RouteName,
                        TianShu = item.TianShu,
                        SCJCR = item.SCJCR,
                        SCJET = item.SCJET,
                        JSJCR = item.JSJCR,
                        JSJET = item.JSJET,
                        JiHeFangShi = Detail.JiHeFangShi,
                        LxrName = Detail.LxrName,
                        LxrTelephone = Detail.LxrTelephone,
                        XingChengs = Detail.XingChengs != null && Detail.XingChengs.Count > 0 ? Detail.XingChengs.Select(x => x.ConvertTo<MXianLuXingChengInfo>()).ToList() : null,
                        FuWu = Detail.FuWu.ConvertTo<MXianLuFuWuInfo>(),
                        Tours = Detail.Tours != null && Detail.Tours.Count > 0 ? Detail.Tours.Select(x => x.ConvertTo<MXianLuTourInfo>()).ToList() : null,
                        TourTraffice = Detail.TrafficeList != null && Detail.TrafficeList.Count > 0 ? Detail.TrafficeList.Select(x => x.ConvertTo<MXianLuTourTraffice>()).ToList() : null,
                        AreaName = item.AreaName,
                        OperatorId = 1,
                        LineID = item.LineID,
                        LineType = LineType.长线,
                        Line_Source = LineSource.博客,
                        CFCS = item.CFCS,
                        TeSe = Detail.TeSe

                    };
                    BXianLu bll = new BXianLu();
                    string ID = bll.ExistsInterfaceID(model.LineID.ToString(), LineSource.博客);
                    if (!string.IsNullOrEmpty(ID))
                    {
                        model.XianLuId = ID;
                        model.LatestId = 1;
                        model.IssueTime = DateTime.Now;
                        bll.OutUpdate(model);
                    }
                    else
                    {
                        bll.Insert(model);
                    }

                    Console.WriteLine(model.RouteName);
                    Console.WriteLine(model.LineID.ToString());
                    Console.WriteLine(model.Tours != null && model.Tours.Count > 0 ? model.Tours[0].LDate.ToShortDateString() : "");


                    sw.WriteLine(model.RouteName);
                    sw.WriteLine(model.LineID.ToString());
                    sw.WriteLine(model.Tours != null && model.Tours.Count > 0 ? model.Tours[0].LDate.ToShortDateString() : "");
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
            return num;
        }

        public int GetShortLine()
        {

            List<MXianLuInfo> XianLuList = new List<MXianLuInfo>();

            XianLuList = bokService.GetZhouBianLine().Select(x => x.ConvertTo<MXianLuInfo>()).ToList();

            int num = 0;
            System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Environment.CurrentDirectory + @"\log\srlog_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", true);

            for (int i = 0; i < XianLuList.Count; i++)
            {
                try
                {
                    num++;
                    var item = XianLuList[i];
                    var Detail = bokService.GetShortDetail(item.LineID.ToString());
                    MXianLuInfo model = new MXianLuInfo()
                    {
                        XianLuId = "",
                        RouteName = item.RouteName,
                        TianShu = item.TianShu,
                        SCJCR = item.SCJCR,
                        SCJET = item.SCJET,
                        JSJCR = item.JSJCR,
                        JSJET = item.JSJET,
                        JiHeFangShi = Detail.JiHeFangShi,
                        LxrName = Detail.LxrName,
                        LxrTelephone = Detail.LxrTelephone,
                        XingChengs = Detail.XingChengs.Select(x => x.ConvertTo<MXianLuXingChengInfo>()).ToList(),
                        FuWu = Detail.FuWu.ConvertTo<MXianLuFuWuInfo>(),
                        Tours = Detail.Tours.Select(x => x.ConvertTo<MXianLuTourInfo>()).ToList(),
                        AreaName = item.AreaName,
                        OperatorId = 1,
                        LineID = item.LineID,
                        LineType = LineType.短线,
                        Line_Source = LineSource.博客,
                        CFCS = item.CFCS,
                        TeSe = Detail.TeSe
                    };
                    BXianLu bll = new BXianLu();
                    string ID = bll.ExistsInterfaceID(model.LineID.ToString(), LineSource.博客);
                    if (!string.IsNullOrEmpty(ID))
                    {
                        //model.XianLuId = ID;
                        //model.LatestId = 1;
                        //model.IssueTime = DateTime.Now;
                        //bll.Update(model);
                    }
                    else
                    {
                        bll.Insert(model);
                    }

                    Console.WriteLine(model.RouteName);
                    Console.WriteLine(model.LineID.ToString());
                    Console.WriteLine(model.Tours != null && model.Tours.Count > 0 ? model.Tours[0].LDate.ToShortDateString() : "");


                    sw.WriteLine(model.RouteName);
                    sw.WriteLine(model.LineID.ToString());
                    sw.WriteLine(model.Tours != null && model.Tours.Count > 0 ? model.Tours[0].LDate.ToShortDateString() : "");
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

            return num;
        }
    }

    class GDWXLine
    {

    }
}
