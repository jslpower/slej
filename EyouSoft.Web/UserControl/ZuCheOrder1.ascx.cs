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
using System.Text.RegularExpressions;


namespace EyouSoft.Web.UserControl
{
    public partial class ZuCheOrder1 : System.Web.UI.UserControl
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

        public int usertype = 1;

        public int ShowOrHidden = 0;//0-显示，1-隐藏
        public int isguibin = 0;//0-未登录，1-已登录
        public int isdaili = 0;//0-不是代理，1-是代理
        protected void Page_Load(object sender, EventArgs e)
        {
            Key = BaiDuMapKey; IsJSON = Iscarlist.ToString();
            Model.SSOStructure.MUserInfo userInfo = null;
            if (Security.Membership.UserProvider.IsLogin(out userInfo))
            {
                if (userInfo != null)
                {
                    isguibin = 1;
                    usertype = (int)userInfo.UserType;
                }

            }
            string url = HttpContext.Current.Request.Url.Host.ToLower();

            ShowOrHidden = (int)new EyouSoft.IDAL.AccountStructure.BSellers().WebSiteShowOrHidden(url);
            //if (userInfo != null)
            //{
            //    if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
            //    {
            //        ShowOrHidden = 1;
            //    }
            //}
        }


        protected string GetCarHtml()
        {
            StringBuilder strHtml = new StringBuilder();
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            if (Iscarlist)
            {
                EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun model = new EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun()
                {
                    State = EyouSoft.Model.Enum.ZuCheStates.启用,
                    CarName = Utils.GetQueryStringValue("carname")
                };
                var list = bll.GetList(1000000, model);
                if (list.Count == 0)
                {
                    model.State = EyouSoft.Model.Enum.ZuCheStates.启用;
                    model.CarName = null;
                }
                list = bll.GetList(1000000, model);
                strHtml.Append("<select  name=\"ddl_carlist\" id=\"ddl_carlist\" style=\"width:395px\"> ");
                if (list != null && list.Count > 0)
                {
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
                sb.Append("var jsonJE = { Qjc: 0, Qgl: 0, Qcc: 0, Qcs: 0, Djc: 0, Dgl: 0, Dcc: 0 };var jsonTJ = { Qhy: 0, Qgb: 0, Qmfx:0, Qfx: 0, Qyg: 0, Dhy: 0, Dgb: 0, Dmfx:0, Dfx: 0, Dyg: 0 };"
                    + "var jsonCC = { QCms:0, QChy: 0, QCgb: 0, QCmfx:0, QCfx: 0, QCyg: 0, DCms:0, DChy: 0, DCgb: 0, DCmfx:0, DCfx: 0, DCyg: 0 };var jsonCS = { QSms:0, QShy: 0, QSgb: 0, QSmfx:0, QSfx: 0, QSyg: 0, DSms:0, DShy: 0, DSgb: 0, DSmfx:0, DSfx: 0, DSyg: 0 }");
            }
            else
            {
                MFeeSettings feeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.租车);
                sb.Append("var jsonJE = { Qjc: " + ZuChe.MenShiJia + "," +
                                         "Qgl:" + ZuChe.MenShiJiaGeZuChe + "," +
                                         " Qcc: " + ZuChe.MenShiJiaGeChaoCheng + "," +
                                         " Qcs: " + ZuChe.MenShiJiaGeChaoShi + "," +
                                         " Djc: " + ZuChe.YouHuiJia + "," +
                                         " Dgl: " + ZuChe.YouHuiJiaGeZuChe + "," +
                                         " Dcc: " + ZuChe.YouHuiJiaGeZuChe + " };");

                sb.Append("var jsonTJ = { Qhy: " +
                    (feeSettings.PuTongHuiYuanJia > 0 ? ZuChe.MenShiJiaGeDanCheng + (ZuChe.MenShiJia - ZuChe.MenShiJiaGeDanCheng) * feeSettings.PuTongHuiYuanJia / 100 : ZuChe.MenShiJiaGeDanCheng) + "," +
                    "Qgb:" +
                    (feeSettings.GuiBinJia > 0 ? ZuChe.MenShiJiaGeDanCheng + (ZuChe.MenShiJia - ZuChe.MenShiJiaGeDanCheng) * feeSettings.GuiBinJia / 100 : ZuChe.MenShiJiaGeDanCheng) + "," +
                    "Qmfx:" +
                    (feeSettings.FreeFenXiaoJia > 0 ? ZuChe.MenShiJiaGeDanCheng + (ZuChe.MenShiJia - ZuChe.MenShiJiaGeDanCheng) * feeSettings.FreeFenXiaoJia / 100 : ZuChe.MenShiJiaGeDanCheng) + "," +
                    "Qfx:" +
                    (feeSettings.FenXiaoJia > 0 ? ZuChe.MenShiJiaGeDanCheng + (ZuChe.MenShiJia - ZuChe.MenShiJiaGeDanCheng) * feeSettings.FenXiaoJia / 100 : ZuChe.MenShiJiaGeDanCheng) + "," +
                    "Qyg:" +
                    (feeSettings.YuanGongJia > 0 ? ZuChe.MenShiJiaGeDanCheng + (ZuChe.MenShiJia - ZuChe.MenShiJiaGeDanCheng) * feeSettings.YuanGongJia / 100 : ZuChe.MenShiJiaGeDanCheng) + "," +
                    "Dhy:" +
                    (feeSettings.PuTongHuiYuanJia > 0 ? ZuChe.YouHuiJiaGeDanCheng + (ZuChe.YouHuiJia - ZuChe.YouHuiJiaGeDanCheng) * feeSettings.PuTongHuiYuanJia / 100 : ZuChe.YouHuiJiaGeDanCheng) + "," +
                    "Dgb:" +
                    (feeSettings.GuiBinJia > 0 ? ZuChe.YouHuiJiaGeDanCheng + (ZuChe.YouHuiJia - ZuChe.YouHuiJiaGeDanCheng) * feeSettings.GuiBinJia / 100 : ZuChe.YouHuiJiaGeDanCheng) + "," +
                    "Dmfx:" +
                (feeSettings.FreeFenXiaoJia > 0 ? ZuChe.YouHuiJiaGeDanCheng + (ZuChe.YouHuiJia - ZuChe.YouHuiJiaGeDanCheng) * feeSettings.FreeFenXiaoJia / 100 : ZuChe.YouHuiJiaGeDanCheng) + "," +
                        "Dfx:" +
                (feeSettings.FenXiaoJia > 0 ? ZuChe.YouHuiJiaGeDanCheng + (ZuChe.YouHuiJia - ZuChe.YouHuiJiaGeDanCheng) * feeSettings.FenXiaoJia / 100 : ZuChe.YouHuiJiaGeDanCheng) + "," +
                 "Dyg:" +
                (feeSettings.YuanGongJia > 0 ? ZuChe.YouHuiJiaGeDanCheng + (ZuChe.YouHuiJia - ZuChe.YouHuiJiaGeDanCheng) * feeSettings.YuanGongJia / 100 : ZuChe.YouHuiJiaGeDanCheng) + "};");



                sb.Append("var jsonCC = { QCms:" +
                    ZuChe.MenShiChaoCheng + "," +
                    "QChy: " +
                    (feeSettings.PuTongHuiYuanJia > 0 ? ZuChe.MenShiJiaGeChaoCheng + (ZuChe.MenShiChaoCheng - ZuChe.MenShiJiaGeChaoCheng) * feeSettings.PuTongHuiYuanJia / 100 : ZuChe.MenShiJiaGeChaoCheng) + "," +
                    "QCgb:" +
                    (feeSettings.GuiBinJia > 0 ? ZuChe.MenShiJiaGeChaoCheng + (ZuChe.MenShiChaoCheng - ZuChe.MenShiJiaGeChaoCheng) * feeSettings.GuiBinJia / 100 : ZuChe.MenShiJiaGeChaoCheng) + "," +
                    "QCmfx:" +
                    (feeSettings.FreeFenXiaoJia > 0 ? ZuChe.MenShiJiaGeChaoCheng + (ZuChe.MenShiChaoCheng - ZuChe.MenShiJiaGeChaoCheng) * feeSettings.FreeFenXiaoJia / 100 : ZuChe.MenShiJiaGeChaoCheng) + "," +
                    "QCfx:" +
                    (feeSettings.FenXiaoJia > 0 ? ZuChe.MenShiJiaGeChaoCheng + (ZuChe.MenShiChaoCheng - ZuChe.MenShiJiaGeChaoCheng) * feeSettings.FenXiaoJia / 100 : ZuChe.MenShiJiaGeChaoCheng) + "," +
                    "QCyg:" +
                    (feeSettings.YuanGongJia > 0 ? ZuChe.MenShiJiaGeChaoCheng + (ZuChe.MenShiChaoCheng - ZuChe.MenShiJiaGeChaoCheng) * feeSettings.YuanGongJia / 100 : ZuChe.MenShiJiaGeChaoCheng) + "," +
                    "DCms:" +
                    ZuChe.YouHuiChaoCheng + "," +
                    "DChy:" +
                    (feeSettings.PuTongHuiYuanJia > 0 ? ZuChe.YouHuiJiaGeChaoCheng + (ZuChe.YouHuiChaoCheng - ZuChe.YouHuiJiaGeChaoCheng) * feeSettings.PuTongHuiYuanJia / 100 : ZuChe.YouHuiJiaGeChaoCheng) + "," +
                    "DCgb:" +
                    (feeSettings.GuiBinJia > 0 ? ZuChe.YouHuiJiaGeChaoCheng + (ZuChe.YouHuiChaoCheng - ZuChe.YouHuiJiaGeChaoCheng) * feeSettings.GuiBinJia / 100 : ZuChe.YouHuiJiaGeChaoCheng) + "," +
                    "DCmfx:" +
                (feeSettings.FreeFenXiaoJia > 0 ? ZuChe.YouHuiJiaGeChaoCheng + (ZuChe.YouHuiChaoCheng - ZuChe.YouHuiJiaGeChaoCheng) * feeSettings.FreeFenXiaoJia / 100 : ZuChe.YouHuiJiaGeChaoCheng) + "," +
                        "DCfx:" +
                (feeSettings.FenXiaoJia > 0 ? ZuChe.YouHuiJiaGeChaoCheng + (ZuChe.YouHuiChaoCheng - ZuChe.YouHuiJiaGeChaoCheng) * feeSettings.FenXiaoJia / 100 : ZuChe.YouHuiJiaGeChaoCheng) + "," +
                 "DCyg:" +
                (feeSettings.YuanGongJia > 0 ? ZuChe.YouHuiJiaGeChaoCheng + (ZuChe.YouHuiChaoCheng - ZuChe.YouHuiJiaGeChaoCheng) * feeSettings.YuanGongJia / 100 : ZuChe.YouHuiJiaGeChaoCheng) + "};");



                sb.Append("var jsonCS = { QSms:" +
                    ZuChe.MenShiChaoShi + "," + 
                    "QShy: " +
                    (feeSettings.PuTongHuiYuanJia > 0 ? ZuChe.MenShiJiaGeChaoShi + (ZuChe.MenShiChaoShi - ZuChe.MenShiJiaGeChaoShi) * feeSettings.PuTongHuiYuanJia / 100 : ZuChe.MenShiJiaGeChaoShi) + "," +
                    "QSgb:" +
                    (feeSettings.GuiBinJia > 0 ? ZuChe.MenShiJiaGeChaoShi + (ZuChe.MenShiChaoShi - ZuChe.MenShiJiaGeChaoShi) * feeSettings.GuiBinJia / 100 : ZuChe.MenShiJiaGeChaoShi) + "," +
                    "QSmfx:" +
                    (feeSettings.FreeFenXiaoJia > 0 ? ZuChe.MenShiJiaGeChaoShi + (ZuChe.MenShiChaoShi - ZuChe.MenShiJiaGeChaoShi) * feeSettings.FreeFenXiaoJia / 100 : ZuChe.MenShiJiaGeChaoShi) + "," +
                    "QSfx:" +
                    (feeSettings.FenXiaoJia > 0 ? ZuChe.MenShiJiaGeChaoShi + (ZuChe.MenShiChaoShi - ZuChe.MenShiJiaGeChaoShi) * feeSettings.FenXiaoJia / 100 : ZuChe.MenShiJiaGeChaoShi) + "," +
                    "QSyg:" +
                    (feeSettings.YuanGongJia > 0 ? ZuChe.MenShiJiaGeChaoShi + (ZuChe.MenShiChaoShi - ZuChe.MenShiJiaGeChaoShi) * feeSettings.YuanGongJia / 100 : ZuChe.MenShiJiaGeChaoShi) + "," +
                    "DSms:" +
                    ZuChe.YouHuiChaoShi + "," + 
                    "DShy:" +
                    (feeSettings.PuTongHuiYuanJia > 0 ? ZuChe.YouHuiJiaGeChaoCheng + (ZuChe.YouHuiChaoShi - ZuChe.YouHuiJiaGeChaoShi) * feeSettings.PuTongHuiYuanJia / 100 : ZuChe.YouHuiJiaGeChaoShi) + "," +
                    "DSgb:" +
                    (feeSettings.GuiBinJia > 0 ? ZuChe.YouHuiJiaGeChaoCheng + (ZuChe.YouHuiChaoShi - ZuChe.YouHuiJiaGeChaoShi) * feeSettings.GuiBinJia / 100 : ZuChe.YouHuiJiaGeChaoShi) + "," +
                    "DSmfx:" +
                    (feeSettings.FreeFenXiaoJia > 0 ? ZuChe.YouHuiJiaGeChaoCheng + (ZuChe.YouHuiChaoShi - ZuChe.YouHuiJiaGeChaoShi) * feeSettings.FreeFenXiaoJia / 100 : ZuChe.YouHuiJiaGeChaoShi) + "," +
                    "DSfx:" +
                    (feeSettings.FenXiaoJia > 0 ? ZuChe.YouHuiJiaGeChaoCheng + (ZuChe.YouHuiChaoShi - ZuChe.YouHuiJiaGeChaoShi) * feeSettings.FenXiaoJia / 100 : ZuChe.YouHuiJiaGeChaoShi) + "," +
                    "DSyg:" +
                    (feeSettings.YuanGongJia > 0 ? ZuChe.YouHuiJiaGeChaoCheng + (ZuChe.YouHuiChaoShi - ZuChe.YouHuiJiaGeChaoShi) * feeSettings.YuanGongJia / 100 : ZuChe.YouHuiJiaGeChaoShi) + "}");





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
            string[] txtGongLiZong = HttpContext.Current.Request.Form.GetValues("wangfan");
            string[] txtBeiZhu = HttpContext.Current.Request.Form.GetValues("txtBeiZhu");
            string[] SelectShiKe = HttpContext.Current.Request.Form.GetValues("SelectShiKe");

            IList<ZuCheXingCheng> gongli = new List<ZuCheXingCheng>();
            if (txtGongli.Length > 0 && txtfirstPlace.Length > 0 && txtlastPlace.Length > 0)
            {

                for (int i = 0; i < txtGongli.Length; i++)
                {
                    ZuCheXingCheng model = new ZuCheXingCheng();
                    if (i == 0)
                    {
                        if (!string.IsNullOrEmpty(txtfirstPlace[i]))
                        {
                            model.LPlace = txtfirstPlace[i];
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(txtlastPlace[i - 1]))
                        {
                            model.LPlace = txtlastPlace[i - 1];
                        }
                    }
                    model.EPlace = txtlastPlace[i];
                    model.GongLiShu = Utils.GetDecimal(txtGongli[i]);
                    if (!string.IsNullOrEmpty(txtlastPlace[i]) && model.EPlace != "请详细正确填写市县区和道路名称" && model.LPlace != "请详细正确填写市县区和道路名称" && model.GongLiShu>0)
                    {
                        gongli.Add(model);
                    }
                }
            }
            list.Number = Utils.GetInt(txtCarNumber[0].ToString());
            int shike = Utils.GetInt(SelectShiKe[0].ToString());
            list.LDate = Utils.GetDateTime(txtInTime[0]).AddHours(shike);
            list.EDate = Utils.GetDateTime(txtBackTime[0]);
            if (Iscarlist && ddl_carlist != null)
            {
                list.ZuCheID = ddl_carlist[0];
            }
            list.ZuCheType = Utils.GetInt(radioSelect[0]);
            list.Xingcheng = gongli;
            list.LxrName = txtChengCheName[0];
            list.LxrTelephone = txtChengCheTel[0];
            if (list.LxrTelephone.Length != 11 && IsNumAndEnCh(list.LxrTelephone))
            {
                RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "您填写的联系人手机有问题，请重新填写！"));
            }
            list.GongLiShu = Utils.GetDecimal(txtGongLiZong[0]);
            if (list.GongLiShu > 500 && list.ZuCheType==2)
            {
                RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "您的公里数大于500公里，请选择包租车！"));
            }
            list.XiaDanBeiZhu = txtBeiZhu[0];
            return list;

        }
        private void RECW(string msg)
        {
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }
        public static bool IsNumAndEnCh(string input)
        {
            string pattern = @"^[0-9]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
    }
}