using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.JPStructure;
using Common.page;

namespace EyouSoft.WAP.Flight
{
    public partial class Flight_Buy : HuiYuanWapPageBase
    {
        protected string sumByOne = "0", modeJson = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "save") CreateDingDan();
            initPage();
        }
        /// <summary>
        /// 初始化页面信息
        /// </summary>
        void initPage()
        {
            string questXML = Utils.GetFormValue("HBbox");
            int questInt = Utils.GetInt(Utils.GetFormValue("JCbox"));
            MCangWeiInfo cangwei = new MCangWeiInfo();
            var queryJpModel = (MHangBanInfo)Newtonsoft.Json.JsonConvert.DeserializeObject(questXML, typeof(MHangBanInfo));
            if (queryJpModel != null)
            {
                cangwei = queryJpModel.CangWeis.Skip(questInt).First();
                IList<MCangWeiInfo> list = new List<MCangWeiInfo>();
                list.Add(cangwei);
                queryJpModel.CangWeis = list;
                modeJson = Newtonsoft.Json.JsonConvert.SerializeObject(queryJpModel);
                var chaXun = new EyouSoft.Model.JPStructure.MZhengCeChaXunInfo1();
                chaXun.ZhengCeId = cangwei.ZhengCeId;
                chaXun.ChuFaChengShiSanZiMa = queryJpModel.ChuFaChengShiSanZiMa;
                chaXun.DaoDaChengShiSanZiMa = queryJpModel.DaoDaChengShiSanZiMa;
                //var ZhengCe = new EyouSoft.BLL.JPStructure.BZhengCe().GetZhengCeInfo(chaXun);
                //if (ZhengCe != null)
                //{


                ltrGaiQian.Text = cangwei.GaiQianGuiDing;
                ltrTui.Text = cangwei.TuiPiaoGuiDing;


                litChuFaRiQi.Text = string.Format("{0} {1}", queryJpModel.HangBanRiQi.ToString("MM-dd"), Utils.ConvertWeekDayToChinese(queryJpModel.HangBanRiQi));
                litChuFaShiJian.Text = string.Format("{0}", queryJpModel.QiFeiShiJian);

                DateTime kaishi = Utils.GetDateTime(queryJpModel.HangBanRiQi.ToString("yyyy-MM-dd") + " " + queryJpModel.QiFeiShiJian);
                DateTime jieshu = Utils.GetDateTime(queryJpModel.HangBanRiQi.ToString("yyyy-MM-dd") + " " + queryJpModel.DaoDaShiJian);
                DateTime daoda = new DateTime();
                if (kaishi > jieshu)
                {
                    daoda = queryJpModel.HangBanRiQi.AddDays(1);
                    jieshu = Utils.GetDateTime(queryJpModel.HangBanRiQi.AddDays(1).ToString("yyyy-MM-dd") + " " + queryJpModel.DaoDaShiJian);
                }
                else
                {
                    daoda = queryJpModel.HangBanRiQi;
                }

                TimeSpan tspan = (jieshu - kaishi);
                litShiChang.Text = string.Format("{0}小时{1}分", tspan.Hours, tspan.Minutes);



                litDaoDaRiQi.Text = string.Format("{0} {1}", daoda.ToString("MM-dd"), Utils.ConvertWeekDayToChinese(daoda));
                litDaoDaShiJian.Text = string.Format("{0}", queryJpModel.DaoDaShiJian);
                litHangban.Text = "(" + EyouSoft.Common.Utils.getCompanyName(queryJpModel.HangKongGongSiErZiMa) + ")" + queryJpModel.HangBanHao;
                decimal piaomian = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.机票, cangwei.XiaoShouJiaGe, cangwei.PiaoMianJiaGe);
                decimal sumRJ = queryJpModel.JiJianJinE + queryJpModel.RanYouJinE;
                sumByOne = (piaomian + sumRJ).ToString("F0");
                litHangBanXX.Text = string.Format(" {4}{0}，<span class=\"font_red\">¥{1}</span> 机/油：<span class=\"font_red\">¥{2}</span> 总计：<span class=\"font_red\">¥<i class=\"font18\" id=\"i_dr\">{3}</i></span>", cangwei.CangWei, piaomian.ToString("F0"), sumRJ.ToString("F0"), sumByOne, cangwei.CangWeiTitle);

                litJingTing.Text = queryJpModel.ShiFouJingTing == "0" ? "否" : queryJpModel.ShiFouJingTing;

                //}

            }
        }

        /// <summary>
        /// 获取政策信息1--按政策编号
        /// </summary>
        EyouSoft.Model.JPStructure.MZhengCeInfo HuoQuZhengCeInfo1(string ChuFaSanZiMa, string DaoDaSanZiMa, string ZhengCeID)
        {
            var chaXun = new EyouSoft.Model.JPStructure.MZhengCeChaXunInfo1();
            chaXun.ZhengCeId = ZhengCeID;
            chaXun.ChuFaChengShiSanZiMa = ChuFaSanZiMa;
            chaXun.DaoDaChengShiSanZiMa = DaoDaSanZiMa;

            return new EyouSoft.BLL.JPStructure.BZhengCe().GetZhengCeInfo(chaXun);
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        void CreateDingDan()
        {

            Model.SSOStructure.MUserInfo userInfo = null;
            bool isLogin = Security.Membership.UserProvider.IsLogin(out userInfo);

            string q = Utils.GetFormValue("i-Model");
            var getModel = (MHangBanInfo)Newtonsoft.Json.JsonConvert.DeserializeObject(q, typeof(MHangBanInfo));
            if (getModel == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "提交失败"));
            MCangWeiInfo cangwei = getModel.CangWeis[0];


            var zhengCe = HuoQuZhengCeInfo1(getModel.ChuFaChengShiSanZiMa, getModel.DaoDaChengShiSanZiMa, cangwei.ZhengCeId);
            if (zhengCe == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "获取政策错误"));


            string[] strTypes = Utils.GetFormValues("u-Type");
            string[] strNames = Utils.GetFormValues("u-Name");
            string[] strCardNos = Utils.GetFormValues("u-CardNo");
            string[] strMobiles = Utils.GetFormValues("u-Mobile");


            var info = new EyouSoft.Model.JPStructure.MDingDanInfo();
            info.ApiJieShouFangShi = EyouSoft.Model.JPStructure.ApiJieShouFangShi.前台;
            info.CaiGouFanDian = cangwei.FanDian;
            info.CangWei = cangwei.CangWei;// "Y";
            info.ChengKeLeiXing = EyouSoft.Model.JPStructure.ChengKeLeiXing.成人;
            info.ChengKes = new List<EyouSoft.Model.JPStructure.MChengKeInfo>();
            info.ChuFaChengShiSanZiMa = getModel.ChuFaChengShiSanZiMa;
            info.ChuFaRiQi = getModel.HangBanRiQi;// new DateTime(2014, 12, 10);
            info.DaoDaChengShiSanZiMa = getModel.DaoDaChengShiSanZiMa;// "HGH";
            info.DingPiaoRenShu = strNames.Length;
            info.GongPiaoShangId = zhengCe.GongPiaoShangId;// "tjDxREhcYk0=";
            info.HangBanHao = getModel.HangBanHao;// "3U8422";
            info.HangXianLeiXing = EyouSoft.Model.JPStructure.HangXianLeiXing.单程;
            info.HuiYuanId = HuiYuanInfo.UserId;// "9b2d3e80-58a1-4e6d-b3b9-b2f518a0da63";
            info.ShiFouYunXuGengHuanPnr = EyouSoft.Model.JPStructure.ShiFouYunXuGengHuanPnr.允许;
            info.ShiFouZiDongDaiKou = EyouSoft.Model.JPStructure.ShiFouZiDongDaiKou.否;
            info.ShiFuDaYinXingChengDan = EyouSoft.Model.JPStructure.ShiFuDaYinXingChengDan.是;
            info.ZhengCeId = cangwei.ZhengCeId; //"Mso5CDQ5Z2UJyipBEib7gg==";
            info.ZhengCeLeiXing = (ZhengCeLeiXing)cangwei.ZhengCeLeiXing;// EyouSoft.Model.JPStructure.ZhengCeLeiXing.普通政策;
            info.QiFeiShiJian = getModel.HangBanRiQi.ToString("yyyy-MM-dd") + " " + getModel.QiFeiShiJian;

            DateTime kaishi = Utils.GetDateTime(getModel.QiFeiShiJian);
            DateTime jieshu = Utils.GetDateTime(getModel.DaoDaShiJian);
            TimeSpan tspan = (jieshu - kaishi);

            if (kaishi > jieshu)
            {
                info.DaoDaShiJian = getModel.HangBanRiQi.AddDays(1).ToString("yyyy-MM-dd") + " " + getModel.DaoDaShiJian;
            }
            else
            {
                info.DaoDaShiJian = getModel.HangBanRiQi.ToString("yyyy-MM-dd") + " " + getModel.DaoDaShiJian;
            }


            if (strNames != null && strNames.Length > 0)
            {
                for (int i = 0; i < strNames.Length; i++)
                {
                    var ck1 = new EyouSoft.Model.JPStructure.MChengKeInfo();
                    ck1.ChengKeLeiXing = (ChengKeLeiXing)Utils.GetInt(strTypes[i]);
                    ck1.ChuShengRiQi = DateTime.Today;
                    ck1.XingMing = strNames[i];
                    ck1.ZhengJianHao = strCardNos[i];
                    if (ck1.ChengKeLeiXing == ChengKeLeiXing.成人)
                    {
                        ck1.ZhengJianLeiXing = EyouSoft.Model.JPStructure.ZhengJianLeiXing.身份证;
                    }
                    else
                    {
                        ck1.ZhengJianLeiXing = EyouSoft.Model.JPStructure.ZhengJianLeiXing.None;
                    }
                    info.ChengKes.Add(ck1);
                }
            }

            var cr = info.ChengKes.Select(x => x.ChengKeLeiXing == ChengKeLeiXing.成人).ToList();
            if (cr == null || cr.Count == 0) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "游客类型不可全部为儿童"));


            string piaomian = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.机票, cangwei.XiaoShouJiaGe, cangwei.PiaoMianJiaGe).ToString("F0");
            decimal sumRJ = getModel.JiJianJinE + getModel.RanYouJinE;
            decimal onePrice = Utils.GetDecimal(piaomian) + sumRJ;

            info.JiLuJiaGe = onePrice * info.ChengKes.Count;
            if (info.JiLuJiaGe == 0) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "信息丢失，请从新操作"));

            #region 添加购票人
            info.AirChangedContact = m.Username;
            #endregion

            info.GouMaiCangWei = cangwei;




            int result = new EyouSoft.BLL.JPStructure.BDingDan().DingDan_C(info);
            if (result == 1) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功，请前往订单中心查看"));
            Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败请核对信息"));
        }
    }
}
