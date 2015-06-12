using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.MoneyManagement
{
    public partial class TiXianEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("type") == "save") ShenHeTiXian();
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("tixianid")))
            {
                InteBind();
            }
            else
            {
                Response.Redirect("/WebMaster/MoneyManagement/TiXianList.aspx");
            }
        }
        void InteBind()
        {
            string TixianId = Utils.GetQueryStringValue("tixianid");
            var list = new EyouSoft.BLL.MoneyStructure.BApplyTiXian().GetInfo(TixianId);
            JiaoYiHao.Text = list.TransactionID;
            TiXianYongHu.Text = GetMemberNameByID(list.UserId);
            TiXianJinE.Text = list.JinE.ToString("f2");
            KaiHuYinHang.Text = list.KaiHuBank;
            KaiHuXingMing.Text = list.KaiHuName;
            YinHangKaHao.Text = list.BankNum;
            TiXianZhuangTai.Text = list.TiXianStatus.ToString();
            ShenHeZhuangTai.Text = list.ApplyStatus.ToString();
            TiXianShiJian.Text = list.TiXianTime.ToString();
            TiXianBeiZhu.Text = list.BeiZhu;
        }
        /// <summary>
        /// 返回下单人姓名
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        string GetMemberNameByID(object memberID)
        {
            string id = "";
            if (memberID != null)
            {
                id = Utils.GetString(memberID.ToString(), "");
            }
            if (id == "" || id == null) return "金奥";
            EyouSoft.BLL.OtherStructure.BMember bll = new EyouSoft.BLL.OtherStructure.BMember();
            EyouSoft.Model.MMember model = new EyouSoft.Model.MMember();
            model = bll.GetModel(memberID.ToString());
            if (model == null) return "金奥";
            return "会员姓名：" + model.MemberName + " &nbsp;&nbsp;&nbsp;&nbsp;会员帐号：" + model.Account;

        }

        void ShenHeTiXian()
        {
            string tixianid = Utils.GetQueryStringValue("shenheid");
            string setstatus = Utils.GetQueryStringValue("setState");
            string ShenHeBeiZhu = Utils.GetFormValue("ShenHeBeiZhu");
            if (setstatus == "1")
            {
                int count = new EyouSoft.BLL.MoneyStructure.BApplyTiXian().SheZhiTiXianShenHeStatus(tixianid, EyouSoft.Model.Enum.TiXianShenHe.未通过, ShenHeBeiZhu);
                
                Utils.RCWE(UtilsCommons.AjaxReturnJson(count == 1 ? "1" : "0", count == 1 ? "提交成功！" : "提现失败，请重试！"));
            }
            else
            {
                int count = new EyouSoft.BLL.MoneyStructure.BApplyTiXian().SheZhiTiXianStatus(tixianid, EyouSoft.Model.Enum.TiXianState.提现失败, ShenHeBeiZhu);
               
                Utils.RCWE(UtilsCommons.AjaxReturnJson(count == 1 ? "1" : "0", count == 1 ? "提交成功！" : "提现失败，请重试！"));
            }
        }
    }
}
