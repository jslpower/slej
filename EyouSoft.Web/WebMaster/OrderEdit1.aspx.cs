using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using EyouSoft.Common;
using System.Text;
using System.Collections.Generic;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.Model.XianLuStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.Web.WebMaster
{
    public partial class OrderEdit1 : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region attributes
        /// <summary>
        /// 订单编号
        /// </summary>
        string OrderId = string.Empty;
        /// <summary>
        /// 线路编号
        /// </summary>
        protected string XianLuId = string.Empty;
        protected string StrOrderStatus = string.Empty;
        protected string StrPayState = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            OrderId = Utils.GetQueryStringValue("order");

            string dotype = Utils.GetQueryStringValue("dotype");

            if (string.IsNullOrEmpty(OrderId)) RCWE("请求异常");

            if (dotype == "xiugai") XiuGai();

            if (dotype == "quxiao") QuXiao();

            InitInfo();
        }

        #region private members

        /// <summary>
        /// 初始化信息
        /// </summary>
        void InitInfo()
        {
            var order = new EyouSoft.BLL.XianLuStructure.BOrder().GetInfo(OrderId);
            if (order == null) RCWE("请求异常");
            hidMemberId.Value = order.OperatorId;
            XianLuId = order.XianLuId;
            txtChengRenShu.Value = order.ChengRenShu.ToString();
            txtErTongShu.Value = order.ErTongShu.ToString();
            txtBeiZhu.Value = order.XiaDanBeiZhu;
            txtContact.Value = order.LxrName;
            txtContactTel.Value = order.LxrTelephone;
            StrPayState = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)), ((int)order.FuKuanStatus).ToString(), false);
            StrOrderStatus = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(OrderStatus)), ((int)order.Status).ToString(), false);
            if (order.YouKes != null && order.YouKes.Count > 0)
            {
                rptYouKes.DataSource = order.YouKes;
                rptYouKes.DataBind();

                phEmptyYouKe.Visible = false;
            }
            else
            {
                phEmptyYouKe.Visible = true;
            }

            decimal crj, etj;
            var xianlu = new EyouSoft.BLL.XianLuStructure.BXianLu().GetInfo(order.XianLuId);
            if (xianlu == null) RCWE("请求异常");

            crj = xianlu.JSJCR;
            etj = xianlu.JSJET;
            var tuan = new EyouSoft.BLL.XianLuStructure.BXianLu().GetTuanGouInfo(order.TuanGouId);
            if (tuan != null)
            {
                if (xianlu.XianLuId != tuan.XianLuId) RCWE("请求异常");

                crj = tuan.JSJCR;
                etj = tuan.JSJET;
            }


            if (xianlu.Tours != null && xianlu.Tours.Count > 0)
            {
                var s = new StringBuilder();
                foreach (var item in xianlu.Tours)
                {
                    if (item.TourId != order.TourId && item.LDate < DateTime.Today) continue;

                    if (item.TourId == order.TourId)
                    {
                        s.AppendFormat("<option value=\"{0}\"  selected=\"selected\" ", item.TourId);
                    }
                    else
                    {
                        s.AppendFormat("<option value=\"{0}\"", item.TourId);
                    }
                    s.AppendFormat(" i_crj=\"{0}\" ", crj);
                    s.AppendFormat(" i_etj=\"{0}\" ", etj);
                    s.Append(">");

                    s.AppendFormat("{0}({1})", item.LDate.ToString("yyyy-MM-dd"), Utils.ConvertWeekDayToChinese(item.LDate));
                    s.AppendFormat(" 成人价：{0}/人", crj.ToString("C2"));
                    s.AppendFormat(" 儿童价：{0}/人", etj.ToString("C2"));
                    s.Append("</option>");
                }

                if (s.Length > 0) ltrFaBanOptions.Text = s.ToString();
            }

            if (order.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
            {
                if (this.CheckGrantPrivs(EyouSoft.Model.Enum.Privs.Privs.订单取消))
                {
                    ltrOperatorHTML.Text = " <a href=\"javascript:void(0)\" id=\"i_a_quxiao\">订单取消</a>";
                }
                else
                {
                    ltrOperatorHTML.Text = "订单状态为<b>" + order.Status + "</b>，不能修改。";
                }
            }
            else
            {
                ltrOperatorHTML.Text = " <a href=\"javascript:void(0)\" id=\"i_a_xiugai\">提交修改</a>";
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        void XiuGai()
        {
            var info = GetFromInfo();

            var info1 = new EyouSoft.BLL.XianLuStructure.BOrder().GetInfo(info.OrderId);

            if (info1.Status == OrderStatus.订单出货) RCWE(UtilsCommons.AjaxReturnJson("0", "订单状态为已成交，不能修改。"));

            int bllRetCode = new EyouSoft.BLL.XianLuStructure.BOrder().Update(info);

            if (info.Status != info1.Status)
            {
                int resultstatus = 0;

                MOrderHistoryInfo modelhistory = new MOrderHistoryInfo();
                modelhistory.LeiXing = OrderHistoryLeiXing.设置状态;
                modelhistory.IssueTime = DateTime.Now;
                modelhistory.OperatorId = info.OperatorId;
                modelhistory.OperatorLeiXing = OperatorLeiXing.管理;
                modelhistory.OperatorName = UserInfo.Username;
                modelhistory.OrderId = info.OrderId;
                modelhistory.Status = info.Status;
                resultstatus = new EyouSoft.BLL.XianLuStructure.BOrder().SheZhiOrderStatus(info.OrderId, info.Status, modelhistory);
            }

            if (info.FuKuanStatus != info1.FuKuanStatus)
            {
                int resultstatus = 0;

                MOrderHistoryInfo modelhistory = new MOrderHistoryInfo();
                modelhistory.LeiXing = OrderHistoryLeiXing.设置付款状态;
                modelhistory.IssueTime = DateTime.Now;
                modelhistory.OperatorId = info.OperatorId;
                modelhistory.OperatorLeiXing = OperatorLeiXing.管理;
                modelhistory.OperatorName = UserInfo.Username;
                modelhistory.OrderId = info.OrderId;
                modelhistory.Status = info.Status;
                resultstatus = new EyouSoft.BLL.XianLuStructure.BOrder().SheZhiFuKuanStatus(info.OrderId, info1.OperatorId, info.FuKuanStatus, modelhistory);
            }

            if (bllRetCode == 1)
            {
                if (info.Status == OrderStatus.订单出货)
                {
                    if (!(new EyouSoft.BLL.OtherStructure.BTatolProduct().ExistsMemberTotal(OrderId, Utils.GetFormValue("txtMem"))))
                        SaveTotal(info);
                }
                RCWE(UtilsCommons.AjaxReturnJson("1", "订单修改成功。"));
            }
            else if (bllRetCode == -99) RCWE(UtilsCommons.AjaxReturnJson("-1", "订单修改失败：线路不存在或已删除。"));
            else if (bllRetCode == -98) RCWE(UtilsCommons.AjaxReturnJson("-1", "订单修改失败：发班信息不存在或已删除。"));
            else if (bllRetCode == -97) RCWE(UtilsCommons.AjaxReturnJson("-1", "订单修改失败：预订人数超过计划人数。"));
            else if (bllRetCode == -94) RCWE(UtilsCommons.AjaxReturnJson("-1", "订单修改失败：团购信息不存在或已删除。"));
            else RCWE(UtilsCommons.AjaxReturnJson("-1", "订单修改失败，请重试。"));
        }

        /// <summary>
        /// 取消
        /// </summary>
        void QuXiao()
        {
            MOrderHistoryInfo modelhistory = new MOrderHistoryInfo();
            modelhistory.LeiXing = OrderHistoryLeiXing.设置状态;
            modelhistory.IssueTime = DateTime.Now;
            modelhistory.OperatorId = UserInfo.UserId.ToString();
            modelhistory.OperatorLeiXing = OperatorLeiXing.管理;
            modelhistory.OperatorName = UserInfo.Username;
            modelhistory.OrderId = OrderId;
            modelhistory.Status = OrderStatus.未处理;
            modelhistory.BeiZhu = "取消订单";
            string m = Utils.GetFormValue("hidMemberId");

            int resultstatus = new EyouSoft.BLL.XianLuStructure.BOrder().SheZhiOrderStatus(OrderId, OrderStatus.未处理, modelhistory);

            if (resultstatus == 1)
            {
                if (new EyouSoft.BLL.OtherStructure.BTatolProduct().ExistsMemberTotal(OrderId, m))
                    new EyouSoft.BLL.OtherStructure.BTatolProduct().DeleteMemberTotal(m, OrderId);
                RCWE(UtilsCommons.AjaxReturnJson("1", "订单取消成功,请登陆支付宝手动转账进行退款操作。"));
            }
            else
                RCWE(UtilsCommons.AjaxReturnJson("-1", "订单取消失败，请重试。"));
        }

        /// <summary>
        /// 订单获取积分
        /// </summary>
        bool SaveTotal(MOrderInfo info)
        {
            var model = new BLL.OtherStructure.BKV().GetCompanySetting();
            int tatol = 0;
            if (model == null)
                tatol = Convert.ToInt32(Math.Round(info.JinE));
            else
                tatol = Convert.ToInt32(Math.Round(info.JinE / (Utils.GetInt(model.RouteTatol.Trim()) == 0 ? 1 : Utils.GetInt(model.RouteTatol.Trim()))));
            if (tatol > 0)
            {
                EyouSoft.Model.OtherStructure.MMemberTotal addTotal = new EyouSoft.Model.OtherStructure.MMemberTotal();
                addTotal.MemberID = Utils.GetFormValue("txtMem");
                addTotal.OrderId = info.OrderId;
                addTotal.OrderType = OrderClass.线路;
                addTotal.Total = tatol;
                return new EyouSoft.BLL.OtherStructure.BTatolProduct().AddMemberTotal(addTotal);
            }
            else
                return false;
        }

        /// <summary>
        /// 获取表单信息
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.XianLuStructure.MOrderInfo GetFromInfo()
        {
            var info = new EyouSoft.Model.XianLuStructure.MOrderInfo();
            info.OrderId = OrderId;
            info.ChengRenShu = Utils.GetInt(Utils.GetFormValue("txtCRS"));
            info.ErTongShu = Utils.GetInt(Utils.GetFormValue("txtETS"));
            info.TourId = Utils.GetFormValue("txtTourId");
            info.XiaDanBeiZhu = Utils.GetFormValue("txtBeiZhu");
            //info.JSJCR = Utils.GetDecimal(Utils.GetFormValue("txtCRJ"));
            //info.JSJER = Utils.GetDecimal(Utils.GetFormValue("txtETJ"));
            info.JinE = Utils.GetDecimal(Utils.GetFormValue("txtJinE"));
            info.YouKes = new List<EyouSoft.Model.XianLuStructure.MOrderYouKeInfo>();
            info.OperatorId = UserInfo.UserId.ToString();
            info.XianLuId = Utils.GetFormValue("txtXianLuId");
            info.Status = (OrderStatus)Utils.GetInt(Utils.GetFormValue("orderstatus"));
            info.LxrTelephone = Utils.GetFormValue("txtContactTel");
            info.LxrName = Utils.GetFormValue("txtContact");
            info.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)Utils.GetInt(Utils.GetFormValue("sel_PayState"));
            string[] txtYouKeName = Utils.GetFormValues("txtYouKeName[]");
            string[] txtYouKeGender = Utils.GetFormValues("txtYouKeGender[]");
            string[] txtYouKeLeiXing = Utils.GetFormValues("txtYouKeLeiXing[]");
            string[] txtYouKeZhengJianLeiXing = Utils.GetFormValues("txtYouKeZhengJianLeiXing[]");
            string[] txtYouKeZhengJianHao = Utils.GetFormValues("txtYouKeZhengJianHao[]");
            string[] txtYouKeTelephone = Utils.GetFormValues("txtYouKeTelephone[]");

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
                item.ZhengJianType = Utils.GetEnumValue<EyouSoft.Model.Enum.CardType>(txtYouKeZhengJianLeiXing[i], EyouSoft.Model.Enum.CardType.身份证);
                item.ZhengJianCode = txtYouKeZhengJianHao[i];
                item.Telephone = txtYouKeTelephone[i];

                info.YouKes.Add(item);
            }

            return info;
        }
        #endregion
    }
}
