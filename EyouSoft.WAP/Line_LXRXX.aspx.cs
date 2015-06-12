using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using System.Text;

namespace EyouSoft.WAP
{
    public partial class Line_LXRXX : HuiYuanWapPageBase
    {
        protected decimal crj, etj, userTp;
        protected decimal jsjcr, jsjet;
        protected decimal gbcrj, gbetj;
        protected string Ldate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("save") == "save") BaoCun();
            initPage();
        }
        void initPage()
        {
            int peopleNum = 1, childrenNum = 0;
            peopleNum = Utils.GetInt(Utils.GetQueryStringValue("crs"), 1);
            childrenNum = Utils.GetInt(Utils.GetQueryStringValue("ets"), 0);
            lblPeopleNum.Text = string.Format("{0}成人，{1}儿童", peopleNum, childrenNum);


            string xianluid = Utils.GetQueryStringValue("xianluid");
            string tid = Utils.GetQueryStringValue("tid");
            var tour = new EyouSoft.BLL.XianLuStructure.BXianLu().GetInfo(xianluid);
            if (tour != null)
            {
                if (tour.Line_Source != EyouSoft.Model.XianLuStructure.LineSource.系统) tour = new EyouSoft.InterfaceLib.APITour().SyncTour(tour);
                EyouSoft.Model.SystemStructure.MFeeSettings bilv = new EyouSoft.Model.SystemStructure.MFeeSettings();
                EyouSoft.Model.Enum.FeeTypes FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
                if (Utils.GetInt(Utils.GetQueryStringValue("type")) == 3) FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
                if (Utils.GetInt(Utils.GetQueryStringValue("type")) == 1) FeeType = EyouSoft.Model.Enum.FeeTypes.国内线路;
                if (Utils.GetInt(Utils.GetQueryStringValue("type")) == 2) FeeType = EyouSoft.Model.Enum.FeeTypes.国际线路;
                bilv = new EyouSoft.BLL.SystemStructure.BFeeSettings().GetByType(FeeType);
                if (string.IsNullOrEmpty(tid))
                {
                    RCWE("参数错误");
                }
                var tuan = tour.Tours.Where(i => i.TourId == tid).First();
                if (tuan == null) tuan = new EyouSoft.Model.XianLuStructure.MXianLuTourInfo();
                crj = UtilsCommons.GetGYStijia(FeeType, tuan.JSJCR, tuan.CRSCJ);
                etj = UtilsCommons.GetGYStijia(FeeType, tuan.JSJET, tuan.ETSCJ);
                //gbcrj = UtilsCommons.GetGYStijia(FeeType, tuan.JSJCR, tuan.CRSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员);
                //gbetj = UtilsCommons.GetGYStijia(FeeType, tuan.JSJET, tuan.ETSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员);

                jsjcr = tuan.JSJCR;
                jsjet = tuan.JSJET;

                lblZJ.Text = (crj * peopleNum + etj * childrenNum).ToString("F0");
                price_ul.InnerHtml = string.Format("<li>成人：<span class=\"floatR\">¥{0}x{1}人</span></li><li>儿童：<span class=\"floatR\">¥{2}x{3}人</span></li>", crj.ToString("F0"), peopleNum, etj.ToString("F0"), childrenNum);

                if (tour.Tours != null && tour.Tours.Count > 0)
                {
                    Ldate = tour.Tours.Where(x => x.TourId == tid).First().LDate.ToString("yyyy-MM-dd");
                }


            }

        }
        /// <summary>
        /// 保存
        /// </summary>
        void BaoCun()
        {
            var info = GetYuDingInfo();
            var xianlu = new EyouSoft.BLL.XianLuStructure.BXianLu().GetInfo(info.XianLuId);
            var yuming = EyouSoft.Common.Page.HuiYuanPageBase.GetYuMingInfo();

            var fee = (EyouSoft.Model.Enum.FeeTypes)Utils.GetInt(Utils.GetQueryStringValue("type"), 1);//产品类型
            bool canSale = new EyouSoft.IDAL.AccountStructure.BSellers().JudgeAuthor(HttpContext.Current.Request.Url.Host, fee);
            info.OrderSite = EyouSoft.Model.Enum.OrderSite.WAP;
            if (canSale)
            {
                info.AgencyId = yuming.GYSID;
            }
            else
            {
                info.AgencyId = "-1";
            }
            var tourinfo = new EyouSoft.BLL.XianLuStructure.BXianLu().GetTourInfo(info.TourId);
            if (tourinfo == null)
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败：数据错误，请从新操作。"));
            }
            else
            {
                #region  计算代理价格
                var crjsj = tourinfo.JSJCR;
                var etjsj = tourinfo.JSJET;
                decimal crj = UtilsCommons.GetGYStijia(fee, crjsj, tourinfo.CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理);
                decimal etj = UtilsCommons.GetGYStijia(fee, etjsj, tourinfo.ETSCJ, EyouSoft.Model.Enum.MemberTypes.代理);
                decimal dingdanjine = ((crj * info.ChengRenShu) + (etj * info.ErTongShu));
                info.AgencyJinE = dingdanjine;
                if (info.JinE < dingdanjine)
                {
                    decimal crj1 = UtilsCommons.GetGYStijia(fee, crjsj, tourinfo.CRSCJ, EyouSoft.Model.Enum.MemberTypes.员工);
                    decimal etj1 = UtilsCommons.GetGYStijia(fee, etjsj, tourinfo.ETSCJ, EyouSoft.Model.Enum.MemberTypes.员工);
                    decimal dingdanjine1 = ((crj1 * info.ChengRenShu) + (etj1 * info.ErTongShu));
                    info.AgencyJinE = UtilsCommons.GetGYStijia(fee, dingdanjine1, EyouSoft.Model.Enum.MemberTypes.员工);
                }

                #endregion
            }

            if (xianlu.Line_Source == EyouSoft.Model.XianLuStructure.LineSource.系统 || xianlu.Line_Source == EyouSoft.Model.XianLuStructure.LineSource.旅游圈)
            {
                int bllRetCode = new EyouSoft.BLL.XianLuStructure.BOrder().Insert(info);

                if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "预订成功，请前往订单中心查看。", info));
                else if (bllRetCode == -99) RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败：线路不存在或已删除。"));
                else if (bllRetCode == -98) RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败：发班信息不存在或已删除。"));
                else if (bllRetCode == -97) RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败：预订人数超过计划人数。"));
                else if (bllRetCode == -94) RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败：团购信息不存在或已删除。"));
                else RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败，请重试。"));
            }

            else if (new EyouSoft.InterfaceLib.APIOrder().InsertOrder(xianlu, info) > 0)
            {
                int bllRetCode = new EyouSoft.BLL.XianLuStructure.BOrder().Insert(info);

                if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "预订成功，请前往订单中心查看。", info));
                else if (bllRetCode == -99) RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败：线路不存在或已删除。"));
                else if (bllRetCode == -98) RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败：发班信息不存在或已删除。"));
                else if (bllRetCode == -97) RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败：预订人数超过计划人数。"));
                else if (bllRetCode == -94) RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败：团购信息不存在或已删除。"));
                else RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败，请重试。"));
            }
            else
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败，请联系我们。"));
            }
        }
        /// <summary>
        /// 获取预订的表单信息
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.XianLuStructure.MOrderInfo GetYuDingInfo()
        {
            EyouSoft.Model.SSOStructure.MUserInfo m = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);

            var info = new EyouSoft.Model.XianLuStructure.MOrderInfo();
            info.TrafficId = Utils.GetQueryStringValue("hasFlightNO");
            info.ChengRenShu = Utils.GetInt(Utils.GetQueryStringValue("crs"));
            info.ErTongShu = Utils.GetInt(Utils.GetQueryStringValue("ets"));
            info.TourId = Utils.GetQueryStringValue("tourid");
            info.XiaDanBeiZhu = "";// Utils.GetFormValue("txtarea");
            info.XianLuId = Utils.GetQueryStringValue("xianluid");
            info.JSJCR = Utils.GetDecimal(Utils.GetFormValue("jsc"));
            info.JSJER = Utils.GetDecimal(Utils.GetFormValue("jse"));
            info.JinE = Utils.GetDecimal(Utils.GetFormValue("zj"));
            info.LxrName = Utils.GetFormValue("yklxr");
            info.LxrTelephone = Utils.GetFormValue("yksj");
            info.LDate = Utils.GetDateTime(Utils.GetFormValue("hidLDate"));
            bool isHasPriv = new EyouSoft.IDAL.AccountStructure.BSellers().JudgeAuthor(Request.Url.Host.ToLower(), (EyouSoft.Model.Enum.FeeTypes)Utils.GetInt(Utils.GetQueryStringValue("type")));
            if (isLogin)
            {
                info.OperatorId = m.UserId;
            }
            else
            {
                info.OperatorId = "-1";
            }

            info.YouKes = new List<EyouSoft.Model.XianLuStructure.MOrderYouKeInfo>();

            string[] txtYouKeName = Utils.GetFormValues("txtYouKeName");
            //string[] txtYouKeGender = Utils.GetFormValues("txtYouKeGender");
            string[] txtYouKeLeiXing = Utils.GetFormValues("txtYouKeLeiXing");
            string[] txtYouKeZhengJianLeiXing = Utils.GetFormValues("txtYouKeZhengJianLeiXing");
            string[] txtYouKeZhengJianHao = Utils.GetFormValues("txtYouKeZhengJianHao");
            string[] txtYouKeTelephone = Utils.GetFormValues("txtYouKeTelephone");

            int youKeLength = txtYouKeName.Length;
            if (txtYouKeLeiXing.Length != youKeLength
                || txtYouKeZhengJianLeiXing.Length != youKeLength
                || txtYouKeZhengJianHao.Length != youKeLength
                || txtYouKeTelephone.Length != youKeLength)
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1", "请求异常，请重试。"));
            }

            for (int i = 0; i < youKeLength; i++)
            {
                if (string.IsNullOrEmpty(txtYouKeName[i])) continue;
                var item = new EyouSoft.Model.XianLuStructure.MOrderYouKeInfo();

                item.Gender = EyouSoft.Model.Enum.Gender.男;// Utils.GetEnumValue<EyouSoft.Model.Enum.Gender>(txtYouKeGender[i], EyouSoft.Model.Enum.Gender.男);
                item.LeiXing = Utils.GetEnumValue<EyouSoft.Model.Enum.YouKeType>(txtYouKeLeiXing[i], EyouSoft.Model.Enum.YouKeType.成人);
                item.Name = txtYouKeName[i];
                item.ZhengJianType = Utils.GetEnumValue<EyouSoft.Model.Enum.CardType>(txtYouKeLeiXing[i], EyouSoft.Model.Enum.CardType.身份证);
                item.ZhengJianCode = txtYouKeZhengJianHao[i];
                item.Telephone = txtYouKeTelephone[i];

                info.YouKes.Add(item);
            }

            return info;
        }

    }
}
