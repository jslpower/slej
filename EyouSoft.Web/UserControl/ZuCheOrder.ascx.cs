using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EyouSoft.Model.ZuCheStructure;
using EyouSoft.Common;
using EyouSoft.Model.SystemStructure;
using EyouSoft.BLL.SystemStructure;

namespace EyouSoft.Web.UserControl
{
    public partial class ZuCheOrder : System.Web.UI.UserControl
    {
        /// <summary>
        /// 车型是否列表显示
        /// </summary>
        private bool _iscarlist = true;
        /// <summary>
        /// 车型是否列表显示(默认：true)
        /// </summary>
        public bool Iscarlist
        {
            get { return _iscarlist; }
            set { _iscarlist = value; }
        }
        /// <summary>
        /// 车型ID
        /// </summary>
        public MZuCheInfo ZuChe { get; set; }
        /// <summary>
        /// 百度地图KEY
        /// </summary>
        public string BaiDuMapKey { get; set; }

        public string Key;

        protected string IsJSON;

        protected void Page_Load(object sender, EventArgs e)
        {
            Key = BaiDuMapKey; IsJSON = Iscarlist.ToString();
        }


        protected string GetCarHtml()
        {
            StringBuilder strHtml = new StringBuilder();
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            if (Iscarlist)
            {
                EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun model = new EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun()
                {
                    State = EyouSoft.Model.Enum.ZuCheStates.启用
                };
                var list = bll.GetList(1000000, model);

                strHtml.Append("<select  name=\"ddl_carlist\" id=\"ddl_carlist\" > ");
                if (list != null && list.Count > 0)
                {
                    strHtml.Append("<option value=\"-1\" >请选择</option>");
                    foreach (var item in list)
                    {
                        strHtml.AppendFormat("<option value=\"{0}\" >{1}</option>",
                            item.ZuCheID, item.CarName);
                    }
                }
                strHtml.Append(" </select> ");
            }
            else
            {
                var m = ZuChe;
                strHtml.AppendFormat("{0}", m.CarName);
            }

            return strHtml.ToString();
        }

        protected string JSON()
        {
            StringBuilder sb = new StringBuilder();
            if (Iscarlist)
            {
                sb.Append("var jsonJE = { Qjc: 0, Qgl: 0, Qcc: 0, Qcs: 0, Djc: 0, Dgl: 0, Dcc: 0 };var jsonTJ = { Qhy: 0, Qgb: 0, Qfx: 0, Qyg: 0, Dhy: 0, Dgb: 0, Dfx: 0, Dyg: 0 }");
            }
            else
            {
                MFeeSettings feeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.租车);
                sb.Append("var jsonJE = { Qjc: " + ZuChe.MenShiJiaGeDanCheng + "," +
                                         "Qgl:" + ZuChe.MenShiJiaGeZuChe + "," +
                                         " Qcc: " + ZuChe.MenShiJiaGeChaoCheng + "," +
                                         " Qcs: " + ZuChe.MenShiJiaGeChaoShi + "," +
                                         " Djc: " + ZuChe.YouHuiJiaGeDanCheng + "," +
                                         " Dgl: " + ZuChe.YouHuiJiaGeZuChe + "," +
                                         " Dcc: " + ZuChe.YouHuiJiaGeZuChe + " };");

                sb.Append("var jsonTJ = { Qhy: " +
                    (feeSettings.PuTongHuiYuanJia > 0 ? ZuChe.MenShiJiaGeDanCheng * feeSettings.PuTongHuiYuanJia : ZuChe.MenShiJiaGeDanCheng) + "," +
                    "Qgb:" +
                    (feeSettings.GuiBinJia > 0 ? ZuChe.MenShiJiaGeDanCheng * feeSettings.GuiBinJia : ZuChe.MenShiJiaGeDanCheng) + "," +
                    "Qfx:" +
                    (feeSettings.FenXiaoJia > 0 ? ZuChe.MenShiJiaGeDanCheng * feeSettings.FenXiaoJia : ZuChe.MenShiJiaGeDanCheng) + "," +
                    "Qyg:" +
                    (feeSettings.YuanGongJia > 0 ? ZuChe.MenShiJiaGeDanCheng * feeSettings.YuanGongJia : ZuChe.MenShiJiaGeDanCheng) + "," +
                    "Dhy:" +
                    (feeSettings.PuTongHuiYuanJia > 0 ? ZuChe.YouHuiJiaGeDanCheng * feeSettings.PuTongHuiYuanJia : ZuChe.YouHuiJiaGeDanCheng) + "," +
                    "Dgb:" +
                    (feeSettings.GuiBinJia > 0 ? ZuChe.YouHuiJiaGeDanCheng * feeSettings.GuiBinJia : ZuChe.YouHuiJiaGeDanCheng) + "," +
                        "Dfx:" +
                (feeSettings.FenXiaoJia > 0 ? ZuChe.YouHuiJiaGeDanCheng * feeSettings.FenXiaoJia : ZuChe.YouHuiJiaGeDanCheng) + "," +
                 "Dyg:" +
                (feeSettings.YuanGongJia > 0 ? ZuChe.YouHuiJiaGeDanCheng * feeSettings.YuanGongJia : ZuChe.YouHuiJiaGeDanCheng) + "};");







            }
            return sb.ToString();
        }

        public MZuCheOrder ExperienceInfo()
        {
            MZuCheOrder list = new MZuCheOrder();
            string[] txtCarNumber = HttpContext.Current.Request.Form.GetValues("txtCarNumber");
            string[] radioSelect = HttpContext.Current.Request.Form.GetValues("radioSelect");
            string[] ddl_carlist = HttpContext.Current.Request.Form.GetValues("ddl_carlist");
            string[] txtInTime = HttpContext.Current.Request.Form.GetValues("txtInTime");
            string[] txtBackTime = HttpContext.Current.Request.Form.GetValues("txtBackTime");
            string[] txtfirstPlace = HttpContext.Current.Request.Form.GetValues("txtfirstPlace");
            string[] txtlastPlace = HttpContext.Current.Request.Form.GetValues("txtlastPlace");
            string[] txtGongli = HttpContext.Current.Request.Form.GetValues("txtGongli");

            string[] txtChengCheName = HttpContext.Current.Request.Form.GetValues("txtChengCheName");
            string[] txtChengCheTel = HttpContext.Current.Request.Form.GetValues("txtChengCheTel");
            string[] txtGongLiZong = HttpContext.Current.Request.Form.GetValues("txtGongLiZong");

            IList<ZuCheXingCheng> gongli = new List<ZuCheXingCheng>();
            if (txtGongli.Length > 0 && txtfirstPlace.Length > 0 && txtlastPlace.Length > 0)
            {

                for (int i = 0; i < txtGongli.Length; i++)
                {
                    if (!string.IsNullOrEmpty(txtfirstPlace[i]))
                    {
                        ZuCheXingCheng model = new ZuCheXingCheng();
                        model.LPlace = txtfirstPlace[i];
                        model.EPlace = txtlastPlace[i];
                        model.GongLiShu = Utils.GetDecimal(txtGongli[i]);
                        gongli.Add(model);
                    }
                }
            }
            list.Number = Utils.GetInt(txtCarNumber[0].ToString());
            list.LDate = Utils.GetDateTime(txtInTime[0]);
            list.EDate = Utils.GetDateTime(txtBackTime[0]);
            if (Iscarlist)
            {
                list.ZuCheID = ddl_carlist[0];
            }
            list.ZuCheType = Utils.GetInt(radioSelect[0]);
            list.Xingcheng = gongli;
            list.LxrName = txtChengCheName[0];
            list.LxrTelephone = txtChengCheTel[0];
            list.GongLiShu = Utils.GetDecimal(txtGongLiZong[0]);
            return list;

        }
    }
}