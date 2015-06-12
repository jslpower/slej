using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web
{
    /// <summary>
    /// jipiao ceshi
    /// </summary>
    public partial class __JiPiaoCeShi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string q = Utils.GetQueryStringValue("q");

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
                default: ltrXinXi.Text = "无对应测试指令"; break;
            }
            
        }

        #region private members
        /// <summary>
        /// 获取航班信息集合
        /// </summary>
        void HuoQuHangBans()
        {
            var chaXun = new EyouSoft.Model.JPStructure.MHangBanChaXunInfo();
            chaXun.ChuFaChengShiSanZiMa = "CAN";
            chaXun.DaoDaChengShiSanZiMa = "HGH";
            chaXun.HangBanRiQi = new DateTime(2014, 12, 10);
            var items=new EyouSoft.BLL.JPStructure.BHangBan().GetHangBans(chaXun);
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
            var info=new EyouSoft.BLL.JPStructure.BHangBan().GetCangWeiTeJiaInfo(chaXun);
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

            var items=new EyouSoft.BLL.JPStructure.BZhengCe().GetZhengCes(chaXun);
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
            ck2.ChuShengRiQi = new DateTime(2008,08,01);
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


    }
}
