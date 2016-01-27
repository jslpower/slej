using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.JPStructure;
using System.Data;
using System.Text;

namespace EyouSoft.WAP.Flight
{
    public partial class Flight_List : Common.Page.WebPageBase
    {
        protected string st = string.Empty, et = string.Empty, cssDisable = string.Empty;
        const string none = "display:none";
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            string q = Utils.GetQueryStringValue("q");

            //if (q == "HuoQuHangBans") HuoQuHangBans();
            switch (q)
            {
                case "HuoQuHangBans": HuoQuHangBans(); break;
                case "HuoQuCangWeiTeJiaInfo": HuoQuCangWeiTeJiaInfo(); break;
                case "HuoQuTuiGaiQianShuoMingInfo": HuoQuTuiGaiQianShuoMingInfo(); break;
                case "HuoQuZhengCeInfo1": HuoQuZhengCeInfo1(); break;
                case "HuoQuZhengCeInfo2": HuoQuZhengCeInfo2(); break;
                case "CreateDingDan": CreateDingDan(); break;
                case "HuoQuDingDanInfo": HuoQuDingDanInfo(); break;
                case "ZhiFuDingDan": ZhiFuDingDan(); break;
                case "XiangApiFuKuan": XiaoApiFuKuan(); break;
                default: Utils.RCWE("无对应测试指令"); break;
            }


            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);

        }

        #region private members
        /// <summary>
        /// 获取航班信息集合
        /// </summary>
        void HuoQuHangBans()
        {
            string[] chufa = Utils.GetQueryStringValue("s").Split('-');
            string[] daoda = Utils.GetQueryStringValue("e").Split('-');
            var chaXun = new EyouSoft.Model.JPStructure.MHangBanChaXunInfo();
            chaXun.ChuFaChengShiSanZiMa = chufa[1];
            chaXun.DaoDaChengShiSanZiMa = daoda[1];
            chaXun.HangBanRiQi = Utils.GetDateTime(Utils.GetQueryStringValue("t"));
            st = chaXun.HangBanRiQi.AddDays(-1).ToString("yyyy-MM-dd");
            if (chaXun.HangBanRiQi <= DateTime.Now) cssDisable = "flight_disable";
            et = chaXun.HangBanRiQi.AddDays(1).ToString("yyyy-MM-dd");
            var items = new EyouSoft.BLL.JPStructure.BHangBan().GetHangBans(chaXun);
            litQuJian.Text = string.Format("{0} - {1}", chufa[0], daoda[0]);
            if (items != null && items.Count > 0)
            {
                litCount.Text = string.Format(" {0} 共{1}条", chaXun.HangBanRiQi.ToString("MM月dd日"), items.Count);
                rptlist.DataSource = items;
                rptlist.DataBind();
            }
            else
            {
                litCount.Text = string.Format(" {0} 暂无航班", chaXun.HangBanRiQi.ToString("MM月dd日"));
            }


            FenXiangBiaoTi = !string.IsNullOrEmpty(chufa[0]) && !string.IsNullOrEmpty(daoda[0]) ? string.Format("{0}-{1}-{2}机票", chaXun.HangBanRiQi.ToString("MM月dd日"), chufa[0], daoda[0]) : "机票预订";
            FenXiangMiaoShu = "机票预订";
            FenXiangLianJie = Utils.redirectUrl( HttpContext.Current.Request.Url.ToString());

        }

        /// <summary>
        /// 获取舱位特价信息
        /// </summary>
        void HuoQuCangWeiTeJiaInfo()
        {
            var chaXun = new EyouSoft.Model.JPStructure.MCangWeiTeJiaChaXunInfo();
            chaXun.ChuFaChengShiSanZiMa = "PEK";
            chaXun.DaoDaChengShiSanZiMa = "SHA";
            chaXun.HangBanRiQi = new DateTime(2014, 11, 15);
            chaXun.CangWei = "Y";
            chaXun.HangBanHao = "HO1252";
            var info = new EyouSoft.BLL.JPStructure.BHangBan().GetCangWeiTeJiaInfo(chaXun);
        }

        /// <summary>
        /// 获取退改签说明信息
        /// </summary>
        void HuoQuTuiGaiQianShuoMingInfo()
        {
            var chaXun = new EyouSoft.Model.JPStructure.MTuiGaiQianShuoMingChaXunInfo();
            chaXun.CangWei = "R";
            chaXun.HangBanRiQi = new DateTime(2014, 11, 15);
            chaXun.HangKongGongSiErZiMa = "HO";
            var info = new EyouSoft.BLL.JPStructure.BHangBan().GetTuiGaiQianShuoMingInfo(chaXun);
        }

        /// <summary>
        /// 获取政策信息1--按政策编号
        /// </summary>
        void HuoQuZhengCeInfo1()
        {
            var chaXun = new EyouSoft.Model.JPStructure.MZhengCeChaXunInfo1();
            chaXun.ZhengCeId = "n0tX0gtee78wyqu1gndf9A==";
            chaXun.ChuFaChengShiSanZiMa = "PEK";
            chaXun.DaoDaChengShiSanZiMa = "SHA";

            new EyouSoft.BLL.JPStructure.BZhengCe().GetZhengCeInfo(chaXun);
        }

        /// <summary>
        /// 获取政策信息2--按航班信息
        /// </summary>
        void HuoQuZhengCeInfo2()
        {
            var chaXun = new EyouSoft.Model.JPStructure.MZhengCeChaXunInfo2();
            chaXun.ChuFaChengShiSanZiMa = "PEK";
            chaXun.DaoDaChengShiSanZiMa = "SHA";
            chaXun.ZhengCeShuLiang = 10;
            chaXun.QiFeiRiQi = DateTime.Today.AddDays(3);

            var items = new EyouSoft.BLL.JPStructure.BZhengCe().GetZhengCes(chaXun);
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        void CreateDingDan()
        {
            var info = new EyouSoft.Model.JPStructure.MDingDanInfo();
            info.ApiJieShouFangShi = EyouSoft.Model.JPStructure.ApiJieShouFangShi.前台;
            info.CaiGouFanDian = 1.0M;
            info.CangWei = "Y";
            info.ChengKeLeiXing = EyouSoft.Model.JPStructure.ChengKeLeiXing.成人;
            info.ChengKes = new List<EyouSoft.Model.JPStructure.MChengKeInfo>();
            info.ChuFaChengShiSanZiMa = "CAN";
            info.ChuFaRiQi = new DateTime(2014, 12, 10);
            info.DaoDaChengShiSanZiMa = "HGH";
            info.DingPiaoRenShu = 2;
            info.GongPiaoShangId = "tjDxREhcYk0=";
            info.HangBanHao = "3U8422";
            info.HangXianLeiXing = EyouSoft.Model.JPStructure.HangXianLeiXing.单程;
            info.HuiYuanId = "9b2d3e80-58a1-4e6d-b3b9-b2f518a0da63";
            info.ShiFouYunXuGengHuanPnr = EyouSoft.Model.JPStructure.ShiFouYunXuGengHuanPnr.允许;
            info.ShiFouZiDongDaiKou = EyouSoft.Model.JPStructure.ShiFouZiDongDaiKou.否;
            info.ShiFuDaYinXingChengDan = EyouSoft.Model.JPStructure.ShiFuDaYinXingChengDan.是;
            info.ZhengCeId = "Mso5CDQ5Z2UJyipBEib7gg==";
            info.ZhengCeLeiXing = EyouSoft.Model.JPStructure.ZhengCeLeiXing.普通政策;

            var ck1 = new EyouSoft.Model.JPStructure.MChengKeInfo();
            ck1.ChengKeLeiXing = EyouSoft.Model.JPStructure.ChengKeLeiXing.成人;
            ck1.ChuShengRiQi = DateTime.Today;
            ck1.XingMing = "薛梦菲";
            ck1.ZhengJianHao = "NI44090119760311922X";
            ck1.ZhengJianLeiXing = EyouSoft.Model.JPStructure.ZhengJianLeiXing.身份证;
            info.ChengKes.Add(ck1);

            var ck2 = new EyouSoft.Model.JPStructure.MChengKeInfo();
            ck2.ChengKeLeiXing = EyouSoft.Model.JPStructure.ChengKeLeiXing.儿童;
            ck2.ChuShengRiQi = new DateTime(2008, 08, 01);
            ck2.XingMing = "殷若兰";
            ck2.ZhengJianHao = "NI130821196503055217";
            ck2.ZhengJianLeiXing = EyouSoft.Model.JPStructure.ZhengJianLeiXing.身份证;
            info.ChengKes.Add(ck2);

            new EyouSoft.BLL.JPStructure.BDingDan().DingDan_C(info);
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        void HuoQuDingDanInfo()
        {
            var info = new EyouSoft.BLL.JPStructure.BDingDan().GetInfo("11844a99-3c54-4f18-8e82-16e75ea8c84a");
        }

        /// <summary>
        /// 支付订单
        /// </summary>
        void ZhiFuDingDan()
        {
            int bllRetCode = new EyouSoft.BLL.JPStructure.BDingDan().SheZhiDingDanYiZhiFu("a12a1078-666c-40a9-8d02-0638a85badb9", "9b2d3e80-58a1-4e6d-b3b9-b2f518a0da63");

        }

        /// <summary>
        /// 向API付款
        /// </summary>
        void XiaoApiFuKuan()
        {
            var bllRetInfo = new EyouSoft.BLL.JPStructure.BDingDan().XiangApiFuKuan("11844a99-3c54-4f18-8e82-16e75ea8c84a", "9b2d3e80-58a1-4e6d-b3b9-b2f518a0da63");
        }
        #endregion

        /// <summary>
        /// 获取最低价格
        /// </summary>
        /// <param name="jiages"></param>
        /// <returns></returns>
        protected string getMinPrice(object jiages)
        {
            IList<MCangWeiInfo> CangWeis = (IList<MCangWeiInfo>)jiages;
            if (CangWeis == null || CangWeis.Count == 0) return "0";
            decimal menshi = CangWeis.Select(i => i.PiaoMianJiaGe).Min();
            return menshi.ToString("F0");
        }
        /// <summary>
        /// 获取最低折扣
        /// </summary>
        /// <param name="jiages"></param>
        /// <returns></returns>
        protected string getMinZK(object jiages)
        {
            IList<MCangWeiInfo> CangWeis = (IList<MCangWeiInfo>)jiages;
            if (CangWeis == null || CangWeis.Count == 0) return "0";
            int minZK = CangWeis.Select(i => i.ZheKouLv).Min();
            var retStr = minZK / 10M;
            if (retStr >= 10) return "";
            return retStr.ToString();

        }
        /// <summary>
        /// 输出舱位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("rptJiCang") as Repeater;
                MHangBanInfo HangBan = (MHangBanInfo)e.Item.DataItem;
                string strJsonHB = Newtonsoft.Json.JsonConvert.SerializeObject(HangBan);
                Literal litJsonHB = e.Item.FindControl("litJsonHB") as Literal;
                litJsonHB.Text = string.Format("<span style=\"display:none\" >{0}</span>", strJsonHB);

                Literal litYouhui = e.Item.FindControl("litYouHui") as Literal;




                if (HangBan.CangWeis != null && HangBan.CangWeis.Count > 0)
                {

                    var index = 0;
                    foreach (var item in HangBan.CangWeis)
                    {

                        item.XianShiJiaGe = EyouSoft.Common.UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.机票, item.XiaoShouJiaGe, item.PiaoMianJiaGe);
                        item.FuJiaFei = HangBan.JiJianJinE + HangBan.RanYouJinE;
                        StringBuilder strbu = new StringBuilder();
                        decimal huiyuanjia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.机票, item.XiaoShouJiaGe, item.PiaoMianJiaGe, EyouSoft.Model.Enum.MemberTypes.普通会员);
                        decimal daixiaojia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.机票, item.XiaoShouJiaGe, item.PiaoMianJiaGe, EyouSoft.Model.Enum.MemberTypes.免费代理);
                        decimal guibinjia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.机票, item.XiaoShouJiaGe, item.PiaoMianJiaGe, EyouSoft.Model.Enum.MemberTypes.贵宾会员);
                        decimal dailijia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.机票, item.XiaoShouJiaGe, item.PiaoMianJiaGe, EyouSoft.Model.Enum.MemberTypes.代理);
                        decimal yuangongjia = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.机票, item.XiaoShouJiaGe, item.PiaoMianJiaGe, EyouSoft.Model.Enum.MemberTypes.员工);




                        if (m != null)
                        {

                            strbu.Append(" <div class=\"youhui_box font12\">");
                            strbu.Append(" <ul>");
                            strbu.AppendFormat("<li><span class=\"font_yellow\">优惠：</span>成人{0}元/人 x 1人  = <span class=\"font_yellow\">{0}</span>元</li>", huiyuanjia.ToString("F0"));
                            if (isDisplay)
                            {
                                if (m.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                                {
                                    strbu.AppendFormat("<li><span class=\"font_yellow\">代销：</span>成人{0}元/人 x 1人 = <span class=\"font_yellow\">{0}</span>元  立省<span class=\"font_yellow\">{1}</span></li>", daixiaojia.ToString("F0"), (huiyuanjia - daixiaojia).ToString("F0"));
                                }

                                strbu.AppendFormat("<li><a  style=\"{2}\" href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">贵宾：</span>成人{0}元/人 x 1人 = <span class=\"font_yellow\">{0}</span>元  立省<span class=\"font_yellow\">{1}</span></li>", guibinjia.ToString("F0"), (huiyuanjia - guibinjia).ToString("F0"), (int)m.UserType < (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 ? "" : "display:none");
                                strbu.AppendFormat(" <li><a  style=\"{2}\" href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理：</span>成人{0}元/人 x 1人 = <span class=\"font_yellow\">{0}</span>元  立省<span class=\"font_yellow\">{1}</span></li>", dailijia.ToString("F0"), (huiyuanjia - dailijia).ToString("F0"), (int)m.UserType < (int)EyouSoft.Model.Enum.MemberTypes.代理 ? "" : "display:none");
                                if (m.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                {
                                    strbu.AppendFormat("<li><span class=\"font_yellow\">员工：</span>成人{0}元/人 x 1人 = <span class=\"font_yellow\">{0}</span>元  立省<span class=\"font_yellow\">{1}</span></li>", yuangongjia.ToString("F0"), (huiyuanjia - yuangongjia).ToString("F0"));
                                }
                            }
                            else
                            {
                                if (m.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                                {
                                    strbu.AppendFormat("<li><span class=\"font_yellow\">代销：</span>成人{0}元/人 x 1人 = <span class=\"font_yellow\">{0}</span>元  立省<span class=\"font_yellow\">{1}</span></li>", daixiaojia.ToString("F0"), (huiyuanjia - daixiaojia).ToString("F0"));
                                }

                                if (m.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                                {
                                    strbu.AppendFormat("<li><span class=\"font_yellow\">贵宾：</span>成人{0}元/人 x 1人 = <span class=\"font_yellow\">{0}</span>元  立省<span class=\"font_yellow\">{1}</span></li>", guibinjia.ToString("F0"), (huiyuanjia - guibinjia).ToString("F0"));
                                }
                                if (m.UserType == EyouSoft.Model.Enum.MemberTypes.代理)
                                {
                                    strbu.AppendFormat(" <li><span class=\"font_yellow\">代理：</span>成人{0}元/人 x 1人 = <span class=\"font_yellow\">{0}</span>元  立省<span class=\"font_yellow\">{1}</span></li>", dailijia.ToString("F0"), (huiyuanjia - dailijia).ToString("F0"));
                                }
                                if (m.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                                {
                                    strbu.AppendFormat(" <li><span class=\"font_yellow\">员工：</span>成人{0}元/人 x 1人 = <span class=\"font_yellow\">{0}</span>元  立省<span class=\"font_yellow\">{1}</span></li>", yuangongjia.ToString("F0"), (huiyuanjia - yuangongjia).ToString("F0"));
                                }

                            }
                            strbu.Append(" </ul>");
                            strbu.Append(" </div>");

                            strbu.AppendFormat("<div class=\"padd10 fhui_btn\"><a data-identity={1} href=\"javascript:;\" class=\"yudingbtn radius4 floatR\">立即预订</a>合计：<em class=\"font_yellow\">¥ {0}</em></div>", (UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.机票, item.XiaoShouJiaGe, item.PiaoMianJiaGe) + HangBan.RanYouJinE + HangBan.JiJianJinE).ToString("F0"), index);
                        }
                        else//未登录
                        {
                            strbu.Append(" <div class=\"youhui_box font12\">");
                            strbu.Append(" <ul>");
                            strbu.AppendFormat("<li><span class=\"font_yellow\">优惠：</span>成人{0}元/人 x 1人  = <span class=\"font_yellow\">{0}</span>元</li>", huiyuanjia.ToString("F0"));
                            if (isDisplay)
                            {
                                strbu.AppendFormat("<li><a  style=\"{2}\" href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">贵宾：</span>成人{0}元/人 x 1人 = <span class=\"font_yellow\">{0}</span>元  立省<span class=\"font_yellow\">{1}</span></li>", guibinjia.ToString("F0"), (huiyuanjia - guibinjia).ToString("F0"), "");
                                strbu.AppendFormat(" <li><a  style=\"{2}\" href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理：</span>成人{0}元/人 x 1人 = <span class=\"font_yellow\">{0}</span>元  立省<span class=\"font_yellow\">{1}</span></li>", dailijia.ToString("F0"), (huiyuanjia - dailijia).ToString("F0"), "");
                            }

                            strbu.Append(" </ul>");
                            strbu.Append(" </div>");
                            strbu.AppendFormat("<div class=\"padd10 fhui_btn\"><a  data-identity={2} href=\"javascript:;\" class=\"yudingbtn radius4 floatR\">立即预订</a><a  href=\"javascript:;\" class=\"gray_btn radius4 floatR BtnLogin\" style=\"color:#fff; margin-right:3px;{1}\">非会员预订</a>合计：<em class=\"font_yellow\">¥ {0}</em></div>", (UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.机票, item.XiaoShouJiaGe, item.PiaoMianJiaGe) + HangBan.RanYouJinE + HangBan.JiJianJinE).ToString("F0"), isLogin ? none : "", index);
                        }
                        //}
                        //else
                        //{
                        //    strbu.AppendFormat("<div class=\"padd10 fhui_btn\"><a href=\"javascript:;\" class=\"yudingbtn radius4 floatR\">立即预订</a>合计：<em class=\"font_yellow\">¥ {0}</em></div>", (UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.机票, item.XiaoShouJiaGe, item.PiaoMianJiaGe) + HangBan.RanYouJinE + HangBan.JiJianJinE).ToString("F0"));
                        //}





                        //strbu.Append("<div class=\"youhui_box\">");

                        //strbu.Append("<ul>");
                        //strbu.AppendFormat("<li><span class=\"font_yellow\">会员：</span>成人{0}元/人x 1人= <span class=\"font_yellow\">{0}</span>元</li>", huiyuanjia.ToString("F0"));
                        //strbu.AppendFormat("<li><a style=\"{2}\"  href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">贵宾：</span>成人{0}元/人x 1人 = <span class=\"font_yellow\">{0}</span>元 立省<span class=\"font_yellow\">{1}</span></li>", guibinjia.ToString("F0"), (huiyuanjia - guibinjia).ToString("F0"), m != null && (int)m.UserType < (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 ? "" : "display:none");

                        //strbu.AppendFormat("<li><a style=\"{2}\" href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理：</span>成人{0}元/人x 1人 = <span class=\"font_yellow\">{0}</span>元 立省<span class=\"font_yellow\">{1}</span></li>", dailijia.ToString("F0"), (huiyuanjia - dailijia).ToString("F0"), m != null && (int)m.UserType < (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 ? "" : "display:none");
                        //strbu.Append("");
                        //strbu.Append("</ul>");
                        //strbu.Append("</div>");






                        item.YouHuiXinXi = strbu.ToString();
                        index++;

                    }

                    rep.DataSource = HangBan.CangWeis;
                    rep.DataBind();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CangWei"></param>
        /// <param name="ZheKouLv"></param>
        /// <returns></returns>
        protected string getZK(object ZheKouLv)
        {
            var zhekou = Utils.GetInt(ZheKouLv.ToString()) / 10M;
            if (zhekou >= 10) return "无折";
            return zhekou.ToString() + "折";
        }
        /// <summary>
        /// 返回基建燃油费
        /// </summary>
        /// <param name="ranyou"></param>
        /// <param name="jijian"></param>
        /// <returns></returns>
        protected string getRJ(object ranyou, object jijian)
        {
            decimal r = Utils.GetDecimal(ranyou.ToString());
            decimal j = Utils.GetDecimal(jijian.ToString());

            return (r + j).ToString("F0");


        }



    }
}
