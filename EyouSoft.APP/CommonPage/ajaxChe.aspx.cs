using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.SystemStructure;
using EyouSoft.BLL.SystemStructure;


namespace EyouSoft.WAP.CommonPage
{
    public partial class ajaxChe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "select")
            {
                selectInfo();
            }
        }
        private void selectInfo()
        {
            string zucheID = Utils.GetFormValue("id");
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            string json = "";
            var m = bll.GetModel(zucheID); ZuCheNewInfo model = new ZuCheNewInfo();
            if (m != null)
            {

                model.MenShiJia = m.MenShiJia;
                model.MenShiJiaGeDanCheng = m.MenShiJiaGeDanCheng;
                model.MenShiJiaGeChaoCheng = m.MenShiJiaGeChaoCheng;
                model.MenShiJiaGeZuChe = m.MenShiJiaGeZuChe;
                model.MenShiJiaGeChaoShi = m.MenShiJiaGeChaoShi;
                model.YouHuiJia = m.YouHuiJia;
                model.YouHuiJiaGeDanCheng = m.YouHuiJiaGeDanCheng;
                model.YouHuiJiaGeChaoCheng = m.YouHuiJiaGeChaoCheng;
                model.YouHuiJiaGeZuChe = m.YouHuiJiaGeZuChe;

                MFeeSettings feeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.租车);

                model.QHuiYuanJieE = feeSettings.PuTongHuiYuanJia > 0 ? model.MenShiJiaGeDanCheng + (model.MenShiJia - model.MenShiJiaGeDanCheng) * feeSettings.PuTongHuiYuanJia / 100 : model.MenShiJiaGeDanCheng;
                model.DHuiYuanJieE = feeSettings.PuTongHuiYuanJia > 0 ? model.YouHuiJiaGeDanCheng + (model.YouHuiJia - model.YouHuiJiaGeDanCheng) * feeSettings.PuTongHuiYuanJia / 100 : model.YouHuiJiaGeDanCheng;

                model.QGuiBingJieE = feeSettings.GuiBinJia > 0 ? model.MenShiJiaGeDanCheng + (model.MenShiJia - model.MenShiJiaGeDanCheng) * feeSettings.GuiBinJia / 100 : model.MenShiJiaGeDanCheng;
                model.DGuiBingJieE = feeSettings.GuiBinJia > 0 ? model.YouHuiJiaGeDanCheng + (model.YouHuiJia - model.YouHuiJiaGeDanCheng) * feeSettings.GuiBinJia / 100 : model.YouHuiJiaGeDanCheng;

                model.QFreeFenXiaoShangJieE = feeSettings.FreeFenXiaoJia > 0 ? model.MenShiJiaGeDanCheng + (model.MenShiJia - model.MenShiJiaGeDanCheng) * feeSettings.FreeFenXiaoJia / 100 : model.MenShiJiaGeDanCheng;
                model.DFreeFenXiaoShangJieE = feeSettings.FreeFenXiaoJia > 0 ? model.YouHuiJiaGeDanCheng + (model.YouHuiJia - model.YouHuiJiaGeDanCheng) * feeSettings.FreeFenXiaoJia / 100 : model.YouHuiJiaGeDanCheng;

                model.QFenXiaoShangJieE = feeSettings.FenXiaoJia > 0 ? model.MenShiJiaGeDanCheng + (model.MenShiJia - model.MenShiJiaGeDanCheng) * feeSettings.FenXiaoJia / 100 : model.MenShiJiaGeDanCheng;
                model.DFenXiaoShangJieE = feeSettings.FenXiaoJia > 0 ? model.YouHuiJiaGeDanCheng + (model.YouHuiJia - model.YouHuiJiaGeDanCheng) * feeSettings.FenXiaoJia / 100 : model.YouHuiJiaGeDanCheng;

                model.QYuanGongJieE = feeSettings.YuanGongJia > 0 ? model.MenShiJiaGeDanCheng + (model.MenShiJia - model.MenShiJiaGeDanCheng) * feeSettings.YuanGongJia / 100 : model.MenShiJiaGeDanCheng;
                model.DYuanGongJieE = feeSettings.YuanGongJia > 0 ? model.YouHuiJiaGeDanCheng + (model.YouHuiJia - model.YouHuiJiaGeDanCheng) * feeSettings.YuanGongJia / 100 : model.YouHuiJiaGeDanCheng;

                model.DChengBenJieE = model.YouHuiJiaGeDanCheng;

                model.QCMenShi = m.MenShiChaoCheng;
                model.QCHuiYuan = feeSettings.PuTongHuiYuanJia > 0 ? model.MenShiJiaGeChaoCheng + (model.QCMenShi - model.MenShiJiaGeChaoCheng) * feeSettings.PuTongHuiYuanJia / 100 : model.MenShiJiaGeChaoCheng;
                model.QCGuiBing = feeSettings.GuiBinJia > 0 ? model.MenShiJiaGeChaoCheng + (model.QCMenShi - model.MenShiJiaGeChaoCheng) * feeSettings.GuiBinJia / 100 : model.MenShiJiaGeChaoCheng;
                model.QCFreeFenXiaoShang = feeSettings.FreeFenXiaoJia > 0 ? model.MenShiJiaGeChaoCheng + (model.QCMenShi - model.MenShiJiaGeChaoCheng) * feeSettings.FreeFenXiaoJia / 100 : model.MenShiJiaGeChaoCheng;
                model.QCFenXiaoShang = feeSettings.FenXiaoJia > 0 ? model.MenShiJiaGeChaoCheng + (model.QCMenShi - model.MenShiJiaGeChaoCheng) * feeSettings.FenXiaoJia / 100 : model.MenShiJiaGeChaoCheng;
                model.QCYuanGong = feeSettings.YuanGongJia > 0 ? model.MenShiJiaGeChaoCheng + (model.QCMenShi - model.MenShiJiaGeChaoCheng) * feeSettings.YuanGongJia / 100 : model.MenShiJiaGeChaoCheng;

                model.DCChengBen = model.YouHuiJiaGeChaoCheng;
                model.DCMenShi = m.YouHuiChaoCheng;
                model.DCHuiYuan = feeSettings.PuTongHuiYuanJia > 0 ? model.YouHuiJiaGeChaoCheng + (model.DCMenShi - model.YouHuiJiaGeChaoCheng) * feeSettings.PuTongHuiYuanJia / 100 : model.YouHuiJiaGeChaoCheng;
                model.DCGuiBing = feeSettings.GuiBinJia > 0 ? model.YouHuiJiaGeChaoCheng + (model.DCMenShi - model.YouHuiJiaGeChaoCheng) * feeSettings.GuiBinJia / 100 : model.MenShiJiaGeChaoCheng;
                model.DCFreeFenXiaoShang = feeSettings.FreeFenXiaoJia > 0 ? model.YouHuiJiaGeChaoCheng + (model.DCMenShi - model.YouHuiJiaGeChaoCheng) * feeSettings.FreeFenXiaoJia / 100 : model.YouHuiJiaGeChaoCheng;
                model.DCFenXiaoShang = feeSettings.FenXiaoJia > 0 ? model.YouHuiJiaGeChaoCheng + (model.DCMenShi - model.YouHuiJiaGeChaoCheng) * feeSettings.FenXiaoJia / 100 : model.YouHuiJiaGeChaoCheng;
                model.DCYuanGong = feeSettings.YuanGongJia > 0 ? model.YouHuiJiaGeChaoCheng + (model.DCMenShi - model.YouHuiJiaGeChaoCheng) * feeSettings.YuanGongJia / 100 : model.YouHuiJiaGeChaoCheng;


                model.QSMenShi = m.MenShiChaoShi;
                model.QSHuiYuan = feeSettings.PuTongHuiYuanJia > 0 ? model.MenShiJiaGeChaoShi + (model.QSMenShi - model.MenShiJiaGeChaoShi) * feeSettings.PuTongHuiYuanJia / 100 : model.MenShiJiaGeChaoShi;
                model.QSGuiBing = feeSettings.GuiBinJia > 0 ? model.MenShiJiaGeChaoShi + (model.QSMenShi - model.MenShiJiaGeChaoShi) * feeSettings.GuiBinJia / 100 : model.MenShiJiaGeChaoShi;
                model.QSFreeFenXiaoShang = feeSettings.FreeFenXiaoJia > 0 ? model.MenShiJiaGeChaoShi + (model.QSMenShi - model.MenShiJiaGeChaoShi) * feeSettings.FreeFenXiaoJia / 100 : model.MenShiJiaGeChaoShi;
                model.QSFenXiaoShang = feeSettings.FenXiaoJia > 0 ? model.MenShiJiaGeChaoShi + (model.QSMenShi - model.MenShiJiaGeChaoShi) * feeSettings.FenXiaoJia / 100 : model.MenShiJiaGeChaoShi;
                model.QSYuanGong = feeSettings.YuanGongJia > 0 ? model.MenShiJiaGeChaoShi + (model.QSMenShi - model.MenShiJiaGeChaoShi) * feeSettings.YuanGongJia / 100 : model.MenShiJiaGeChaoShi;

                model.DSMenShi = m.YouHuiChaoShi;
                model.DSHuiYuan = feeSettings.PuTongHuiYuanJia > 0 ? model.YouHuiJiaGeChaoCheng + (model.YouHuiChaoShi - model.YouHuiJiaGeChaoShi) * feeSettings.PuTongHuiYuanJia / 100 : model.YouHuiJiaGeChaoShi;
                model.DSGuiBing = feeSettings.GuiBinJia > 0 ? model.YouHuiJiaGeChaoCheng + (model.YouHuiChaoShi - model.YouHuiJiaGeChaoShi) * feeSettings.GuiBinJia / 100 : model.YouHuiJiaGeChaoShi; ;
                model.DSFreeFenXiaoShang = feeSettings.FreeFenXiaoJia > 0 ? model.YouHuiJiaGeChaoCheng + (model.YouHuiChaoShi - model.YouHuiJiaGeChaoShi) * feeSettings.FreeFenXiaoJia / 100 : model.YouHuiJiaGeChaoShi; ;
                model.DSFenXiaoShang = feeSettings.FenXiaoJia > 0 ? model.YouHuiJiaGeChaoCheng + (model.YouHuiChaoShi - model.YouHuiJiaGeChaoShi) * feeSettings.FenXiaoJia / 100 : model.YouHuiJiaGeChaoShi; ;
                model.DSYuanGong = feeSettings.YuanGongJia > 0 ? model.YouHuiJiaGeChaoCheng + (model.YouHuiChaoShi - model.YouHuiJiaGeChaoShi) * feeSettings.YuanGongJia / 100 : model.YouHuiJiaGeChaoShi; ;





                RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "成功！", Newtonsoft.Json.JsonConvert.SerializeObject(model)));
            }
            else
            {
                model.MenShiJia = 0;
                model.MenShiJiaGeDanCheng = 0;
                model.MenShiJiaGeChaoCheng = 0;
                model.MenShiJiaGeZuChe = 0;
                model.MenShiJiaGeChaoShi = 0;
                model.YouHuiJia = 0;
                model.YouHuiJiaGeDanCheng = 0;
                model.YouHuiJiaGeChaoCheng = 0;
                model.YouHuiJiaGeZuChe = 0;

                model.QHuiYuanJieE = 0;
                model.DHuiYuanJieE = 0;
                model.QGuiBingJieE = 0;
                model.DGuiBingJieE = 0;

                model.QFreeFenXiaoShangJieE = 0;
                model.DFreeFenXiaoShangJieE = 0;

                model.QFenXiaoShangJieE = 0;
                model.DFenXiaoShangJieE = 0;

                model.QYuanGongJieE = 0;
                model.DYuanGongJieE = 0;

                model.DChengBenJieE = 0;

                model.QCMenShi = 0;
                model.QCHuiYuan = 0;
                model.QCGuiBing = 0;
                model.QCFreeFenXiaoShang = 0;
                model.QCFenXiaoShang = 0;
                model.QCYuanGong = 0;

                model.DCChengBen = 0;
                model.DCMenShi = 0;
                model.DCHuiYuan = 0;
                model.DCGuiBing = 0;
                model.DCFreeFenXiaoShang = 0;
                model.DCFenXiaoShang = 0;
                model.DCYuanGong = 0;


                model.QSMenShi = 0;
                model.QSHuiYuan = 0;
                model.QSGuiBing = 0;
                model.QSFreeFenXiaoShang = 0;
                model.QSFenXiaoShang = 0;
                model.QSYuanGong = 0;

                model.DSMenShi = 0;
                model.DSHuiYuan = 0;
                model.DSGuiBing = 0;
                model.DSFreeFenXiaoShang = 0;
                model.DSFenXiaoShang = 0;
                model.DSYuanGong = 0;


                RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("-1", "请求的数据不存在！", Newtonsoft.Json.JsonConvert.SerializeObject(model)));
            }

        }

        private void RECW(string msg)
        {
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }
    }

    public class ZuCheNewInfo : EyouSoft.Model.ZuCheStructure.MZuCheInfo
    {
        public decimal QHuiYuanJieE { get; set; }

        public decimal QGuiBingJieE { get; set; }

        public decimal QFreeFenXiaoShangJieE { get; set; }

        public decimal QFenXiaoShangJieE { get; set; }

        public decimal QYuanGongJieE { get; set; }

        public decimal DHuiYuanJieE { get; set; }

        public decimal DGuiBingJieE { get; set; }

        public decimal DFreeFenXiaoShangJieE { get; set; }

        public decimal DFenXiaoShangJieE { get; set; }

        public decimal DYuanGongJieE { get; set; }

        public decimal DChengBenJieE { get; set; }


        public decimal QCMenShi { get; set; }

        public decimal QCHuiYuan { get; set; }

        public decimal QCGuiBing { get; set; }

        public decimal QCFreeFenXiaoShang { get; set; }

        public decimal QCFenXiaoShang { get; set; }

        public decimal QCYuanGong { get; set; }

        public decimal DCChengBen { get; set; }

        public decimal DCMenShi { get; set; }

        public decimal DCHuiYuan { get; set; }

        public decimal DCGuiBing { get; set; }

        public decimal DCFreeFenXiaoShang { get; set; }

        public decimal DCFenXiaoShang { get; set; }

        public decimal DCYuanGong { get; set; }



        public decimal QSMenShi { get; set; }

        public decimal QSHuiYuan { get; set; }

        public decimal QSGuiBing { get; set; }

        public decimal QSFreeFenXiaoShang { get; set; }

        public decimal QSFenXiaoShang { get; set; }

        public decimal QSYuanGong { get; set; }

        public decimal DSMenShi { get; set; }

        public decimal DSHuiYuan { get; set; }

        public decimal DSGuiBing { get; set; }

        public decimal DSFreeFenXiaoShang { get; set; }

        public decimal DSFenXiaoShang { get; set; }

        public decimal DSYuanGong { get; set; }

    }
}
