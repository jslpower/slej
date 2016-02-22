using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class XieYi : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_网站协议))
            {
                ToUrl("/webmaster/default.aspx");
            }

            if (!IsPostBack)
            {
                this.InitPage();
            }
        }

        private void InitPage()
        {
            var model = new BLL.OtherStructure.BKV().GetCompanySetting();
            if (model == null) return;

            txtXieYi.Text = model.XieYi;
            txtVisa.Text = model.VisaXieYi;
            txtTicket.Text = model.TicketXieYi;
            txtDuanXian.Text = model.DuanXianXieYi;
            txtChuJing.Text = model.ChuJingXieYi;
            txtHotel.Text = model.HotelXieYi;
            txtZuChe.Text = model.ZuCheXieyi;
            txtShop.Text = model.ShopXieYi;
            txtTuanGou.Text = model.TuanGouXieYi;
            txtBaoJia.Text = model.BaoJiaXieYi;
            txtJiPiao.Text = model.JiPiaoXieYi;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool r = new BLL.OtherStructure.BKV().SetCompanySetting(this.GetFormValue());

            EyouSoft.Common.Function.MessageBox.ShowAndRedirect(
                this, string.Format("保存{0}！", r ? "成功" : "失败"), "/WebMaster/CompanyInfo.aspx");
        }

        private EyouSoft.Model.MCompanySetting GetFormValue()
        {
            var model = new BLL.OtherStructure.BKV().GetCompanySetting() ?? new EyouSoft.Model.MCompanySetting();

            model.XieYi = Utils.EditInputText(txtXieYi.Text);
            model.VisaXieYi = Utils.EditInputText(txtVisa.Text);
            model.TicketXieYi = Utils.EditInputText(txtTicket.Text);
            model.HotelXieYi = Utils.EditInputText(txtHotel.Text);
            model.ZuCheXieyi = Utils.EditInputText(txtZuChe.Text);
            model.ShopXieYi = Utils.EditInputText(txtShop.Text);
            model.ChuJingXieYi = Utils.EditInputText(txtChuJing.Text);
            model.DuanXianXieYi = Utils.EditInputText(txtDuanXian.Text);
            model.TuanGouXieYi = Utils.EditInputText(txtTuanGou.Text);
            model.BaoJiaXieYi = Utils.EditInputText(txtBaoJia.Text);
            model.JiPiaoXieYi = Utils.EditInputText(txtJiPiao.Text);
            return model;
        }
    }
}
