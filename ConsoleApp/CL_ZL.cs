using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib;
using EyouSoft.InterfaceLib.Request.ZL;
using System.Configuration;
using EyouSoft.Model.XianLuStructure;
using EyouSoft.Common;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.BLL.XianLuStructure;

namespace ConsoleApp
{
    class CL_ZL
    {
        string[] 港澳 = new string[] { "香港", "澳门" };

        string[] 台湾 = new string[] { "台湾" };

        string[] 澳新 = new string[] { "澳大利亚", "新西兰", "库克群岛", "大溪地", "汤加", "新喀里多尼亚", "瓦努阿图", "瑙鲁共和国", "所罗门群岛", "萨摩亚", "巴布亚新几内亚", "图瓦卢", "斐济" };


        string[] 日韩 = new string[] { "日本", "北海道", "冲绳", "九洲", "韩国", "济州岛", "朝鲜", "首尔" };

        string[] 美洲 = new string[] { "美国", "夏威夷", "关岛", "加拿大", "巴西", "阿根廷", "智利", "秘鲁", "古巴", "墨西哥" };

        string[] 东南亚 = new string[] { "泰国", "泰新马", "马来西亚", "新加坡", "越南", "柬埔寨", "菲律宾", "尼泊尔", "印度", "斯里兰卡", "文莱", "清迈" };

        string[] 中东 = new string[] { "阿联酋", "以色列", "约旦", "土耳其", "伊朗" };

        string[] 欧洲 = new string[] { "英国", "爱尔兰", "法国", "意大利", "德国", "瑞士", "荷兰", "希腊", "丹麦", "比利时", "奥地利", "西班牙", "葡萄牙", "捷克", "波兰", "俄罗斯", "斯洛伐克", "冰岛", "挪威", "芬兰", "瑞典", "克罗地亚", "爱沙尼亚", "匈牙利", "马耳他" };


        string[] 非洲 = new string[] { "埃及", "肯尼亚", "南非", "突尼斯", "马达加斯加", "埃塞俄比亚", "博茨瓦纳", "津巴布韦", "坦桑尼亚" };

        string[] 海岛线 = new string[] { "巴厘岛", "普吉岛", "马尔代夫", "长滩岛", "宿雾", "岘港", "沙巴", "兰卡威", "毛里求斯", "塞班", "塞舌尔", " 斐济", "苏梅岛", "民丹岛", "巴淡岛", "越南芽庄" };

        string[] 出发城市 = new string[] { "", "杭州市", "宁波市", "温州市", "嘉兴市", "湖州市", "绍兴市", "金华市", "衢州市", "舟山市", "台州市", "丽水市", "上海市" };

        ZLCommonServiceSeeker zlService = new ZLCommonServiceSeeker();

        public int GetLine()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Environment.CurrentDirectory + @"\log\srlog_zl_" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", true);
            int c = 0;
            try
            {
                var pageindex = 1;
                var pagecount = 0;
                var pagesize = 20;
                var recordercount = 0;
                var x = zlService.get_obd_group_list(RequestInfo(pageindex, pagesize));
                if (x.result_id > 0)
                {
                    Console.WriteLine(x.error_desc);
                    return c;
                }
                else
                {
                    pagecount = x.page_count;
                    recordercount = x.total_count;
                }

                if (recordercount <= 0) return c;
                Console.WriteLine(pagecount);
                for (; pageindex <= pagecount; pageindex++)
                {
                    x = zlService.get_obd_group_list(RequestInfo(pageindex, pagesize));
                    if (x.result_id > 0)
                    {
                        Console.WriteLine(x.error_desc);
                        continue;
                    }
                    if (x == null || x.group_headers.Count <= 0) continue;

                    foreach (var m in x.group_headers)
                    {
                        var item = m.SID;

                        if (m.Name.IndexOf("台湾") >= 0)
                            continue;

                        #region 请求
                        get_obd_group_detailRequest model = new get_obd_group_detailRequest()
                        {
                            user_key = ConfigurationManager.AppSettings["ZLCommonLoginName"],
                            password = ConfigurationManager.AppSettings["ZLCommonPassword"],
                            sid = item
                        };
                        #endregion

                        var Detail = zlService.get_obd_group_detail(model);
                        if (Detail == null || Detail.result_id != 0) continue;

                        #region 服务
                        MXianLuFuWuInfo xianluFuWu = new MXianLuFuWuInfo()
                        {
                            FuWuBiaoZhun = Detail.group_header.Contain,
                            BuHanXiangMu = Detail.group_header.UnContain,
                            GouWuAnPai = "",
                            ErTongAnPai = "",
                            ZiFeiXiangMu = "",
                            ZhuYiShiXiang = Detail.group_header.Attention,
                            WenXinTiXing = "",
                            BaoMingXuZhi = ""
                        };
                        #endregion

                        #region 行程
                        List<MXianLuXingChengInfo> XingChengs = new List<MXianLuXingChengInfo>();
                        foreach (var itemXingCheng in Detail.group_journeys)
                        {
                            MXianLuXingChengInfo XingChengInfo = new MXianLuXingChengInfo();
                            XingChengInfo.FilePath = Detail.group_header.MainPic;
                            XingChengInfo.JiaoTong = itemXingCheng.Traffic;
                            XingChengInfo.QuJian = "";
                            XingChengInfo.XingCheng = itemXingCheng.Content;
                            XingChengInfo.YongCan = itemXingCheng.Dining;
                            XingChengInfo.ZhuSu = itemXingCheng.Lodging;
                            XingChengs.Add(XingChengInfo);
                        }
                        #endregion

                        #region 发班周期
                        List<MXianLuTourInfo> TourTime = new List<MXianLuTourInfo>();
                        MXianLuTourInfo TourModel = new MXianLuTourInfo()
                        {
                            LDate = Utils.GetDateTime(Detail.group_header.LeftDate),
                            RDate = Utils.GetDateTime(Detail.group_header.BackDate),
                            DingDanShu = 0,
                            YiShouRenShu = 0,
                            ShiShouRenShu = 0,
                            Status = Detail.group_header.StepID == EyouSoft.InterfaceLib.Models.ZL.Steps.收客中 ? ShouKeZhuangTai.正常 : ShouKeZhuangTai.停收,
                            JSJCR = Utils.GetDecimal(Detail.group_header.AdultPriceI.ToString()),
                            JSJET = Utils.GetDecimal(Detail.group_header.ChildPriceI.ToString()),
                            CRSCJ = Utils.GetDecimal(Detail.group_header.AdultPrice.ToString()),
                            ETSCJ = Utils.GetDecimal(Detail.group_header.ChildPrice.ToString()),
                            SYRS = Detail.group_header.LeftNum
                        };
                        TourTime.Add(TourModel);
                        #endregion

                        var areaname = string.Empty;
                        string[] areanames = this.港澳.Where(v => Detail.group_header.Keyword.IndexOf(v) >= 0).ToArray();
                        if (string.IsNullOrEmpty(areaname)) if (areanames.Length == 0) areanames = this.台湾.Where(v => Detail.group_header.Keyword.IndexOf(v) >= 0).ToArray(); else areaname = "港澳";
                        if (string.IsNullOrEmpty(areaname)) if (areanames.Length == 0) areanames = this.澳新.Where(v => Detail.group_header.Keyword.IndexOf(v) >= 0).ToArray(); else areaname = "台湾";
                        if (string.IsNullOrEmpty(areaname)) if (areanames.Length == 0) areanames = this.日韩.Where(v => Detail.group_header.Keyword.IndexOf(v) >= 0).ToArray(); else areaname = "澳新";
                        if (string.IsNullOrEmpty(areaname)) if (areanames.Length == 0) areanames = this.美洲.Where(v => Detail.group_header.Keyword.IndexOf(v) >= 0).ToArray(); else areaname = "日韩";
                        if (string.IsNullOrEmpty(areaname)) if (areanames.Length == 0) areanames = this.东南亚.Where(v => Detail.group_header.Keyword.IndexOf(v) >= 0).ToArray(); else areaname = "美洲";
                        if (string.IsNullOrEmpty(areaname)) if (areanames.Length == 0) areanames = this.中东.Where(v => Detail.group_header.Keyword.IndexOf(v) >= 0).ToArray(); else areaname = "东南亚";
                        if (string.IsNullOrEmpty(areaname)) if (areanames.Length == 0) areanames = this.欧洲.Where(v => Detail.group_header.Keyword.IndexOf(v) >= 0).ToArray(); else areaname = "中东";
                        if (string.IsNullOrEmpty(areaname)) if (areanames.Length == 0) areanames = this.非洲.Where(v => Detail.group_header.Keyword.IndexOf(v) >= 0).ToArray(); else areaname = "欧洲";
                        if (string.IsNullOrEmpty(areaname)) if (areanames.Length == 0) areanames = this.海岛线.Where(v => Detail.group_header.Keyword.IndexOf(v) >= 0).ToArray(); else areaname = "非洲";

                        MXianLuInfo xianlu = new MXianLuInfo()
                        {
                            RouteName = Detail.group_header.Name,
                            TianShu = Detail.group_header.Days,
                            SCJCR = Utils.GetDecimal(Detail.group_header.AdultPrice.ToString()),
                            SCJET = Utils.GetDecimal(Detail.group_header.ChildPrice.ToString()),
                            JSJCR = Utils.GetDecimal(Detail.group_header.AdultPriceI.ToString()),
                            JSJET = Utils.GetDecimal(Detail.group_header.ChildPriceI.ToString()),
                            JiHeFangShi = "",
                            LxrName = Detail.group_header.CaptainName,
                            LxrTelephone = Detail.group_header.LinkInfo,
                            XingChengs = XingChengs,
                            FuWu = xianluFuWu,
                            TeSe = Detail.group_header.Feature,
                            Tours = TourTime,
                            AreaName = !string.IsNullOrEmpty(areaname) ? areaname : (areanames.Length > 0 ? "海岛线" : areaname),
                            OperatorId = 1,
                            LineID = Detail.group_header.SID.ToString(),
                            Line_Source = LineSource.省中旅,
                            CFCS = (Detail.group_header.LeftCityID < 出发城市.Length ? 出发城市[Detail.group_header.LeftCityID] : string.Empty)

                        };
                        BXianLu bll = new BXianLu();
                        string ID = bll.ExistsInterfaceID(xianlu.LineID.ToString(), LineSource.省中旅);
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
                        Console.WriteLine(m.Name);
                        Console.WriteLine(m.SID.ToString());


                        sw.WriteLine(m.Name);
                        sw.WriteLine(m.SID.ToString());
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

        get_obd_group_listRequest RequestInfo(int pageIndex, int pageSize)
        {
            get_obd_group_listRequest model = new get_obd_group_listRequest()
            {
                user_key = ConfigurationManager.AppSettings["ZLCommonLoginName"],
                password = ConfigurationManager.AppSettings["ZLCommonPassword"],
                condition_exp = string.Format("leftdate>to_date('" + DateTime.Now.ToShortDateString() + "','YYYY-MM-DD')"),
                sort_exp = "",
                page_index = pageIndex,
                page_size = pageSize
            };
            return model;
        }
    }
}
