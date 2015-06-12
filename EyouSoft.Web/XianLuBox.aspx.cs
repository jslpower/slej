using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.Web
{
    public partial class XianLuBox : Common.Page.HuiYuanPageBase
    {
        protected string crj, etj, userTp;
        protected decimal jsjcr, jsjet;
        protected decimal gbcrj, gbetj;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Utils.GetQueryStringValue("id"))
                || string.IsNullOrEmpty(Utils.GetQueryStringValue("tourid"))) Utils.RCWE("错误请求");
            if (Utils.GetQueryStringValue("save") == "save") BaoCun();
            initPage();
            userTp = HuiYuanInfo.UserType.ToString();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void initPage()
        {
            string xianluid = Utils.GetQueryStringValue("id");
            string tid = Utils.GetQueryStringValue("tourid");
            var tour = new EyouSoft.BLL.XianLuStructure.BXianLu().GetInfo(xianluid);
            if (tour != null)
            {
                if (tour.Line_Source != EyouSoft.Model.XianLuStructure.LineSource.系统) tour = new EyouSoft.InterfaceLib.APITour().SyncTour(tour);
                lblxianlu.Text = Utils.ConverToStringByHtml(tour.RouteName);
                EyouSoft.Model.SystemStructure.MFeeSettings bilv = new EyouSoft.Model.SystemStructure.MFeeSettings();
                EyouSoft.Model.Enum.FeeTypes FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
                if (Utils.GetInt(Utils.GetQueryStringValue("type")) == 3) FeeType = EyouSoft.Model.Enum.FeeTypes.周边线路;
                if (Utils.GetInt(Utils.GetQueryStringValue("type")) == 1) FeeType = EyouSoft.Model.Enum.FeeTypes.国内线路;
                if (Utils.GetInt(Utils.GetQueryStringValue("type")) == 2) FeeType = EyouSoft.Model.Enum.FeeTypes.国际线路;
                bilv = new EyouSoft.BLL.SystemStructure.BFeeSettings().GetByType(FeeType);

                var tuan = tour.Tours.Where(i => i.TourId == tid).First();
                if (tuan == null) tuan = new EyouSoft.Model.XianLuStructure.MXianLuTourInfo();

                #region 表头
                StringBuilder strHead = new StringBuilder();
                strHead.AppendFormat("<tr><th class=\"Rline\"> &nbsp; </th> <th class=\"Rline\"> 门市价</th> ");
                strHead.AppendFormat("  <th class=\"Rline\" {0}> 会员价 </th> ", (int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.普通会员 ? string.Empty : "style='display:none'");
                strHead.AppendFormat("<th class=\"Rline\" {0}> 代销价 </th>", (int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员 ? string.Empty : "style='display:none'");

                if (HuiYuanInfo.UserType != EyouSoft.Model.Enum.MemberTypes.免费代理)
                {
                    strHead.AppendFormat("<th class=\"Rline\" {0}> 贵宾价 </th>", (int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 && HuiYuanInfo.UserType != EyouSoft.Model.Enum.MemberTypes.免费代理 ? string.Empty : "style='display:none'");
                }
                strHead.AppendFormat(" <th class=\"Rline\" {0}> 代理价 </th>", (int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.代理 ? string.Empty : "style='display:none'");
                strHead.AppendFormat("  <th {0}> 员工价 </th>", (int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.员工 ? string.Empty : "style='display:none'");
                if ((int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.普通会员)
                {
                }
                if ((int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                {
                }
                if ((int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.代理)
                {
                }
                if ((int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.员工)
                {
                }
                strHead.Append("</tr>");
                litHeadHtml.Text = strHead.ToString();
                #endregion
                #region 成人价
                StringBuilder strCR = new StringBuilder();
                strCR.AppendFormat("<tr><td>成人价</td><td><b class=\"fontblue\"><span id=\"lblmscrj\" class=\"hline\">{0}</span></b></td> ", tuan.CRSCJ.ToString("F2"));
                strCR.AppendFormat(" <td {1}><b class=\"fontblue\"><span id=\"lblhycrj\">{0}</span></b></td> ", UtilsCommons.GetGYStijia(FeeType, tuan.JSJCR, tuan.CRSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F2"),
                    (int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.普通会员 ? string.Empty : "style='display:none'");

                strCR.AppendFormat(" <td {1}><b class=\"fontblue\"><span id=\"lblejcrj\">{0}</span></b></td> ", UtilsCommons.GetGYStijia(FeeType, tuan.JSJCR, tuan.CRSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F2"),
    (int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员 ? string.Empty : "style='display:none'");
                if (HuiYuanInfo.UserType != EyouSoft.Model.Enum.MemberTypes.免费代理)
                {
                    strCR.AppendFormat(" <td {1}><b class=\"fontblue\"><span id=\"lblgbcrj\">{0}</span></b></td> ", UtilsCommons.GetGYStijia(FeeType, tuan.JSJCR, tuan.CRSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F2"),
                        (int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 && HuiYuanInfo.UserType != EyouSoft.Model.Enum.MemberTypes.免费代理 ? string.Empty : "style='display:none'");
                }
                strCR.AppendFormat(" <td {1}><b class=\"fontblue\"><span id=\"lblfxcrj\">{0}</span></b></td> ", UtilsCommons.GetGYStijia(FeeType, tuan.JSJCR, tuan.CRSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F2"),
                    (int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.代理 ? string.Empty : "style='display:none'");
                strCR.AppendFormat(" <td {1}><b class=\"fontblue\"><span id=\"lblygcrj\">{0}</span></b></td> ", UtilsCommons.GetGYStijia(FeeType, tuan.JSJCR, tuan.CRSCJ, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F2"),
                    (int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.员工 ? string.Empty : "style='display:none'");

                strCR.Append("</tr>");
                litCRHtml.Text = strCR.ToString();
                #endregion
                #region 儿童价
                StringBuilder strET = new StringBuilder();
                strET.AppendFormat("<tr><td>儿童价</td><td><b class=\"fontblue\"><span id=\"lblmsetj\" class=\"hline\">{0}</span></b></td> ", tuan.ETSCJ.ToString("F2"));
                strET.AppendFormat(" <td {1}><b class=\"fontblue\"><span id=\"lblhyetj\">{0}</span></b></td> ", UtilsCommons.GetGYStijia(FeeType, tuan.JSJET, tuan.ETSCJ, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F2"),
                    (int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.普通会员 ? string.Empty : "style='display:none'");

                strET.AppendFormat(" <td {1}><b class=\"fontblue\"><span id=\"lblejetj\">{0}</span></b></td> ", UtilsCommons.GetGYStijia(FeeType, tuan.JSJET, tuan.ETSCJ, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F2"),
    (int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员 ? string.Empty : "style='display:none'");
                if (HuiYuanInfo.UserType != EyouSoft.Model.Enum.MemberTypes.免费代理)
                {
                    strET.AppendFormat(" <td {1}><b class=\"fontblue\"><span id=\"lblgbetj\">{0}</span></b></td> ", UtilsCommons.GetGYStijia(FeeType, tuan.JSJET, tuan.ETSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F2"),
                        (int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 && HuiYuanInfo.UserType != EyouSoft.Model.Enum.MemberTypes.免费代理 ? string.Empty : "style='display:none'");
                }
                strET.AppendFormat(" <td {1}><b class=\"fontblue\"><span id=\"lblfxetj\">{0}</span></b></td> ", UtilsCommons.GetGYStijia(FeeType, tuan.JSJET, tuan.ETSCJ, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F2"),
                    (int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.代理 ? string.Empty : "style='display:none'");
                strET.AppendFormat(" <td {1}><b class=\"fontblue\"><span id=\"lblygetj\">{0}</span></b></td> ", UtilsCommons.GetGYStijia(FeeType, tuan.JSJET, tuan.ETSCJ, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F2"),
                    (int)HuiYuanInfo.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.员工 ? string.Empty : "style='display:none'");

                strET.Append("</tr>");
                litETHtml.Text = strET.ToString();
                #endregion
                crj = UtilsCommons.GetGYStijia(FeeType, tuan.JSJCR, tuan.CRSCJ).ToString("F2");
                etj = UtilsCommons.GetGYStijia(FeeType, tuan.JSJET, tuan.ETSCJ).ToString("F2");
                gbcrj = UtilsCommons.GetGYStijia(FeeType, tuan.JSJCR, tuan.CRSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员);
                gbetj = UtilsCommons.GetGYStijia(FeeType, tuan.JSJET, tuan.ETSCJ, EyouSoft.Model.Enum.MemberTypes.贵宾会员);

                jsjcr = tuan.JSJCR;
                jsjet = tuan.JSJET;
                string tourid = Utils.GetQueryStringValue("tourid");
                if (tour.Tours != null && tour.Tours.Count > 0)
                {
                    var s = new StringBuilder();
                    foreach (var item in tour.Tours)
                    {
                        if (item.TourId == tourid)
                        {
                            lblfatuan.Text = item.LDate.ToString("yyyy-MM-dd");
                            lblsy.Text = item.SYRS.ToString();

                        }
                    }

                }
            }



            if (HuiYuanInfo != null)
            {
                lblYRDXM.Text = HuiYuanInfo.MemberName;
                lblYDRSJ.Text = HuiYuanInfo.Username;
                lblYDRSF.Text = HuiYuanInfo.UserType.ToString();
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
            info.OrderSite = EyouSoft.Model.Enum.OrderSite.PC;

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

                if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "预订成功，请等待确认。", info));
                else if (bllRetCode == -99) RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败：线路不存在或已删除。"));
                else if (bllRetCode == -98) RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败：发班信息不存在或已删除。"));
                else if (bllRetCode == -97) RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败：预订人数超过计划人数。"));
                else if (bllRetCode == -94) RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败：团购信息不存在或已删除。"));
                else RCWE(UtilsCommons.AjaxReturnJson("-1", "预订失败，请重试。"));
            }

            else if (new EyouSoft.InterfaceLib.APIOrder().InsertOrder(xianlu, info) > 0)
            {
                int bllRetCode = new EyouSoft.BLL.XianLuStructure.BOrder().Insert(info);

                if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "预订成功，请等待确认。", info));
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
            info.RouteType = (EyouSoft.Model.Enum.AreaType)Utils.GetInt(Utils.GetFormValue("type"), 1);
            info.TrafficId = Utils.GetQueryStringValue("hangban");
            info.ChengRenShu = Utils.GetInt(Utils.GetFormValue("txtcrs"));
            info.ErTongShu = Utils.GetInt(Utils.GetFormValue("txtets"));
            info.TourId = Utils.GetFormValue("hidtourid");
            info.XiaDanBeiZhu = Utils.GetFormValue("txtarea");
            info.XianLuId = Utils.GetFormValue("hidxianlu");
            info.JSJCR = Utils.GetDecimal(Utils.GetFormValue("jsjcr"));
            info.JSJER = Utils.GetDecimal(Utils.GetFormValue("jsjet"));
            info.JinE = Utils.GetDecimal(Utils.GetFormValue("hidzj"));
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
            string[] txtYouKeGender = Utils.GetFormValues("txtYouKeGender");
            string[] txtYouKeLeiXing = Utils.GetFormValues("txtYouKeLeiXing");
            string[] txtYouKeZhengJianLeiXing = Utils.GetFormValues("txtYouKeZhengJianLeiXing");
            string[] txtYouKeZhengJianHao = Utils.GetFormValues("txtYouKeZhengJianHao");
            string[] txtYouKeTelephone = Utils.GetFormValues("txtYouKeTelephone");

            int youKeLength = txtYouKeName.Length;
            if (txtYouKeGender.Length != youKeLength
                || txtYouKeLeiXing.Length != youKeLength
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

                item.Gender = Utils.GetEnumValue<EyouSoft.Model.Enum.Gender>(txtYouKeGender[i], EyouSoft.Model.Enum.Gender.男);
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
