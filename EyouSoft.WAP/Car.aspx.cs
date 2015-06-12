using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using EyouSoft.Model.SystemStructure;
using EyouSoft.BLL.SystemStructure;
using EyouSoft.Model.ZuCheStructure;
using EyouSoft.Common.Page;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.WAP
{
    public partial class Car : WebPageBase
    {
        protected string CarName = "";//汽车名称
        protected string CarImg = "";//汽车图片
        /// <summary>
        /// 车型ID
        /// </summary>
        public MZuCheInfo ZuChe { get; set; }
        protected int usercate = 0;//会员级别0-未登录及未注册用户
        protected string carid = "";
        protected string shijian = DateTime.Now.AddDays(4).ToString("yyyy-MM-dd");
        protected bool isShow = true;
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["dotype"] == "save") OrderSub();
            WapHeader1.HeadText = "汽车包租";
            if (isLogin)
            {
                usercate = (int)m.UserType;
            }
            InitInfo();
            getHtmlStr();
            if (new EyouSoft.IDAL.AccountStructure.BSellers().WebSiteShowOrHidden(Request.Url.Host.ToLower().Replace("m.", "")) == ShowHidden.隐藏)
            {
                isShow = false;
            }


            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }
        protected void InitInfo()
        {
            carid = Utils.GetQueryStringValue("id");
            if (string.IsNullOrEmpty(carid)) Utils.RCWE("异常请求！");
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            var model = bll.GetModel(carid);
            if (model == null) Utils.RCWE("异常请求");
            ZuChe = model;
            CarName = FenXiangBiaoTi = model.CarName;
            FenXiangMiaoShu = Utils.GetText2(model.Remark, 30, true);
            FenXiangTuPianFilepath = "http://" + Request.Url.Host + TuPian.F1(model.ZucheInfoImg[0].FilePath, 640, 400);
            FenXiangLianJie = HttpContext.Current.Request.Url.ToString();
            CarImg = "<img width='390' height='220' src='" + TuPian.F1(model.ZucheInfoImg[0].FilePath, 640, 400) + "' alt='" + model.CarName + "'>";
            //IMGHTML(model.ZucheInfoImg, model.CarName); 照片
        }
        protected string JSON()
        {
            StringBuilder sb = new StringBuilder();
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

            return sb.ToString();
        }

        private void OrderSub()
        {
            var Ordermodel = ExperienceInfo();
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            var newmodel = bll.GetModel(Ordermodel.ZuCheID);
            if (newmodel == null) RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求的数据不存在！"));
            Ordermodel.CarName = newmodel.CarName;

            string url = HttpContext.Current.Request.Url.Host;
            //string url = "8191.slej.cn";
            url = url.Replace("m.", "");
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
            seller = bsells.GetMSellersByWebSite(url);
            if (seller != null)
            {
                if (bsells.JudgeAuthor(url, EyouSoft.Model.Enum.FeeTypes.租车))
                {
                    Ordermodel.AgencyId = seller.ID;
                }
            }

            #region 金额
            decimal JinE = 0;
            decimal FenXiaoJia = 0;
            MFeeSettings feeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.租车);

            Model.SSOStructure.MUserInfo userInfo = null;
            if (!Security.Membership.UserProvider.IsLogin(out userInfo)) RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求错误重新操作！"));
            if (userInfo == null) RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求错误重新操作！"));
            var userType = userInfo.UserType;
            Ordermodel.OperatorId = userInfo.UserId;
            Ordermodel.YuDingRName = userInfo.MemberName;
            Ordermodel.YuDingRTelephone = userInfo.Mobile;




            decimal discount = 0;//该用户提价比
            decimal fenxiao = 0;//分销商提交比
            switch (userType)
            {
                case EyouSoft.Model.Enum.MemberTypes.未注册用户:
                    break;
                case EyouSoft.Model.Enum.MemberTypes.员工:
                    discount = feeSettings.YuanGongJia;
                    break;
                case EyouSoft.Model.Enum.MemberTypes.普通会员:
                    discount = feeSettings.PuTongHuiYuanJia;
                    break;
                case EyouSoft.Model.Enum.MemberTypes.贵宾会员:
                    discount = feeSettings.GuiBinJia;
                    break;
                case EyouSoft.Model.Enum.MemberTypes.代理:
                    discount = feeSettings.FenXiaoJia;
                    break;
                default:
                    break;
            }
            if (seller != null)
            {
                if (seller.DengJi == EyouSoft.Model.Enum.MemberTypes.代理)
                {
                    fenxiao = feeSettings.FenXiaoJia;
                }
                else if (seller.DengJi == EyouSoft.Model.Enum.MemberTypes.免费代理)
                {
                    fenxiao = feeSettings.FreeFenXiaoJia;
                }
                else if (seller.DengJi == EyouSoft.Model.Enum.MemberTypes.员工)
                {
                    fenxiao = feeSettings.YuanGongJia;
                }
            }


            if (Ordermodel.ZuCheType == (int)EyouSoft.Model.Enum.ZhuCheType.同城往返带司机包租车)
            {
                var YouHuiJiaG = newmodel.MenShiJiaGeDanCheng + (newmodel.MenShiJia - newmodel.MenShiJiaGeDanCheng) * discount / 100;
                FenXiaoJia = newmodel.MenShiJiaGeDanCheng + (newmodel.MenShiJia - newmodel.MenShiJiaGeDanCheng) * fenxiao / 100;
                JinE += YouHuiJiaG * Ordermodel.Number;
                FenXiaoJia = FenXiaoJia * Ordermodel.Number;
                TimeSpan ts = Ordermodel.EDate.Value.Subtract(Convert.ToDateTime(Ordermodel.LDate.Value.ToShortDateString()));
                Ordermodel.ZuCheTianShu = ts.Days;
                if (ts.Days > 0)
                {
                    JinE += ts.Days * (newmodel.MenShiJiaGeChaoShi + (newmodel.MenShiChaoShi - newmodel.MenShiJiaGeChaoShi) * discount / 100);
                    FenXiaoJia += ts.Days * (newmodel.MenShiJiaGeChaoShi + (newmodel.MenShiChaoShi - newmodel.MenShiJiaGeChaoShi) * fenxiao / 100);

                }
                if (Ordermodel.GongLiShu > newmodel.MenShiJiaGeZuChe)
                {
                    JinE += ((Ordermodel.GongLiShu - newmodel.MenShiJiaGeZuChe) * (newmodel.MenShiJiaGeChaoCheng + (newmodel.MenShiChaoCheng - newmodel.MenShiJiaGeChaoCheng) * discount / 100)).Value;
                    FenXiaoJia += ((Ordermodel.GongLiShu - newmodel.MenShiJiaGeZuChe) * (newmodel.MenShiJiaGeChaoCheng + (newmodel.MenShiChaoCheng - newmodel.MenShiJiaGeChaoCheng) * fenxiao / 100)).Value;
                }
            }
            else
            {
                var YouHuiJiaG = newmodel.MenShiJiaGeDanCheng + (newmodel.MenShiJia - newmodel.MenShiJiaGeDanCheng) * discount / 100;
                FenXiaoJia = newmodel.MenShiJiaGeDanCheng + (newmodel.MenShiJia - newmodel.MenShiJiaGeDanCheng) * fenxiao / 100;
                JinE += YouHuiJiaG * Ordermodel.Number;
                FenXiaoJia = FenXiaoJia * Ordermodel.Number;
                TimeSpan ts = Ordermodel.EDate.Value.Subtract(Ordermodel.LDate.Value);
                Ordermodel.ZuCheTianShu = ts.Days;
                if (ts.Days > 0)
                {
                    JinE += ts.Days * (newmodel.YouHuiJiaGeChaoShi + (newmodel.YouHuiChaoShi - newmodel.YouHuiJiaGeChaoShi) * discount / 100);
                    FenXiaoJia += ts.Days * (newmodel.YouHuiJiaGeChaoShi + (newmodel.YouHuiChaoShi - newmodel.YouHuiJiaGeChaoShi) * fenxiao / 100);

                }
                Ordermodel.GongLiShu = Ordermodel.GongLiShu * 2;
                if (Ordermodel.GongLiShu > newmodel.YouHuiJiaGeZuChe)
                {

                    JinE += ((Ordermodel.GongLiShu - newmodel.YouHuiJiaGeZuChe * 2) * (newmodel.YouHuiJiaGeChaoCheng + (newmodel.YouHuiChaoCheng - newmodel.YouHuiJiaGeChaoCheng) * discount / 100)).Value;
                    FenXiaoJia += ((Ordermodel.GongLiShu - newmodel.YouHuiJiaGeZuChe * 2) * (newmodel.YouHuiJiaGeChaoCheng + (newmodel.YouHuiChaoCheng - newmodel.YouHuiJiaGeChaoCheng) * fenxiao / 100)).Value;
                }
            }
            Ordermodel.ZuJin = JinE;
            Ordermodel.AgencyJinE = FenXiaoJia;


            if (FenXiaoJia - JinE > 0)
            {
                Ordermodel.AgencyJinE = JinE;
            }
            if (seller == null)
            {
                Ordermodel.AgencyJinE = JinE;
            }

            #endregion
            Ordermodel.OrderId = Guid.NewGuid().ToString();
            Ordermodel.OrderSite = EyouSoft.Model.Enum.OrderSite.WAP;
            EyouSoft.BLL.ZuCheStructure.BZuCheOrder orderBll = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder();
            var r = orderBll.Add(Ordermodel);
            string strReturn;
            if (r == 1)
            {
                int code = new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(Ordermodel.OrderId, EyouSoft.Model.Enum.DingDanLeiBie.租车订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.下单);
                strReturn = "提交成功，请前往订单中心查看";

                //返联盟推广
                var flmtgInfo = new EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo();
                flmtgInfo.DingDanId = Ordermodel.OrderId;
                flmtgInfo.DingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.租车订单;
                flmtgInfo.FanLiBiLi = 0;
                flmtgInfo.XiaDanRenId = Ordermodel.OperatorId;
                new EyouSoft.BLL.OtherStructure.BTuiGuang().TuiGuangFanLi_C(flmtgInfo);
            }
            else
            {
                strReturn = "提交失败";
            }
            RECW(UtilsCommons.AjaxReturnJson(r.ToString(), strReturn));
        }

        public MZuCheOrder ExperienceInfo()
        {
            MZuCheOrder list = new MZuCheOrder();
            list.Number = Convert.ToInt32(Utils.GetFormValue("WFCheNum"));
            list.ZuCheType = Convert.ToInt32(Utils.GetFormValue("WForDC"));
            if (list.ZuCheType == 1)
            {
                list.ZuCheType = 2;
            }
            else
            {
                list.ZuCheType = 1;
            }
            list.ZuCheID = Utils.GetQueryStringValue("id");
            //string[] txtInTime = HttpContext.Current.Request.Form.GetValues("txtInTime");
            //string[] txtBackTime = HttpContext.Current.Request.Form.GetValues("txtBackTime");
            string[] txtfirstPlace = HttpContext.Current.Request.Form.GetValues("txtfirstPlace");
            string[] txtlastPlace = HttpContext.Current.Request.Form.GetValues("txtlastPlace");
            string[] txtGongli = HttpContext.Current.Request.Form.GetValues("txtGongli");

            list.LxrName = Utils.GetFormValue("LxrName");
            list.LxrTelephone = Utils.GetFormValue("LxrMoblie");
            list.GongLiShu = Convert.ToDecimal(Utils.GetFormValue("WangFanGongLi"));
            list.XiaDanBeiZhu = Utils.GetFormValue("BeiZhu");
            int shike = Convert.ToInt32(Utils.GetFormValue("ShiKe"));

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
                    if (!string.IsNullOrEmpty(txtlastPlace[i]) && model.EPlace != "请详细正确填写市县区和道路名称" && model.LPlace != "请详细正确填写市县区和道路名称" && model.GongLiShu > 0)
                    {
                        gongli.Add(model);
                    }
                }
            }
            list.LDate = Utils.GetDateTime(Utils.GetFormValue("chufatime")).AddHours(shike);
            list.EDate = Utils.GetDateTime(Utils.GetFormValue("huiguitime"));
            list.Xingcheng = gongli;
            if (list.GongLiShu > 500 && list.ZuCheType == 2)
            {
                RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "您的公里数大于500公里，请选择包租车！"));
            }
            return list;

        }
        private void RECW(string msg)
        {
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }

        /// <summary>
        /// 获取最近六个月的日期
        /// </summary>
        void getHtmlStr()
        {
            StringBuilder strMonthHtml = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                DateTime dt = DateTime.Now.AddMonths(i);
                if (i == 0)
                {
                    strMonthHtml.Append("<div class=\"riqi_box\">");
                }
                else
                {
                    strMonthHtml.Append("<div class=\"riqi_box mt10\">");
                }
                strMonthHtml.AppendFormat("<div class=\"riqi_month\">{0}</div>", dt.ToString("yyyy年MM月"));
                strMonthHtml.Append("<div class=\"riqi_week\">");
                strMonthHtml.Append("<ul>");
                strMonthHtml.Append("<li>日</li>");
                strMonthHtml.Append("<li>一</li>");
                strMonthHtml.Append("<li>二</li>");
                strMonthHtml.Append("<li>三</li>");
                strMonthHtml.Append("<li>四</li>");
                strMonthHtml.Append("<li>五</li>");
                strMonthHtml.Append("<li>六</li>");
                strMonthHtml.Append("</ul>");
                strMonthHtml.Append("</div>");
                strMonthHtml.Append("<div class=\"riqi_day\">");
                strMonthHtml.Append("<ul class=\"clearfix\">");

                int days = DateTime.DaysInMonth(dt.Year, dt.Month);
                int firstLi = (int)Utils.GetDateTime(string.Format("{0}-{1}-{2}", dt.Year, dt.Month, 1)).DayOfWeek;
                for (int j = 0; j < firstLi; j++)
                {
                    strMonthHtml.Append("<li></li>");//补全空白
                }
                for (int m = 1; m <= days; m++)
                {
                    strMonthHtml.Append(getMonthStr(string.Format("{0}-{1}-{2}", dt.Year, dt.Month, m)));
                }
                strMonthHtml.Append("</ul></div></div>");
            }
            litMonth.Text = strMonthHtml.ToString();
        }
        /// <summary>
        /// 返回表格样式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        string getMonthStr(string dataStr)
        {
            DateTime dt = Utils.GetDateTime(dataStr);
            if (dt < DateTime.Now)
            {
                return string.Format("<li da class=\"riqi_day_pass\" >{0}</li>", dt.Day);
            }
            else
            {
                return string.Format("<li class=\"riqi_day_select\" data-date=\"{1}\" data-week=\"{2}\">{0}</li>", dt.Day, dt.ToString("yyyy-MM-dd"), dt.DayOfWeek);
            }
        }

        protected string GetCarHtml()
        {
            StringBuilder strHtml = new StringBuilder();
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun model = new EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun();
            model.State = EyouSoft.Model.Enum.ZuCheStates.启用;
            model.PSort = 0;
            var list = bll.GetList(1000000, model);
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    if (!string.IsNullOrEmpty(carid))
                    {
                        if (item.ZuCheID == carid)
                        {
                            strHtml.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</option>",
                            item.ZuCheID, item.CarName);
                        }
                        else
                        {
                            strHtml.AppendFormat("<option value=\"{0}\" >{1}</option>",
                            item.ZuCheID, item.CarName);
                        }
                    }
                    else
                    {
                        strHtml.AppendFormat("<option value=\"{0}\" >{1}</option>",
                            item.ZuCheID, item.CarName);
                    }
                }
            }
            return strHtml.ToString();
        }
    }
}
