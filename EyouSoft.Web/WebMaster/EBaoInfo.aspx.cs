using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class EBaoInfo : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_公司信息))
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

            txtEBaoSSM.Text = model.EBaoSSM;
            txtEBaoYEGL.Text = model.EBaoYEGL;
            txtEBaoCZMX.Text = model.EBaoCZMX;
            txtEBaoGMMX.Text = model.EBaoGMMX;
            txtEBaoFLMX.Text = model.EBaoFLMX;
            txtEBaoTXMX.Text = model.EBaoTXMX;
            txtEBaoFXJ.Text = model.EBaoFXJ;
            txtEBaoZHMX.Text = model.EBaoZHMX;
            txtEBaoZMX.Text = model.EBaoZMX;
            txtEBaoJFZZ.Text = model.EBaoJFZZ;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool r = new BLL.OtherStructure.BKV().SetCompanySetting(this.GetFormValue());

            EyouSoft.Common.Function.MessageBox.ShowAndRedirect(
                this, string.Format("保存{0}！", r ? "成功" : "失败"), "/WebMaster/EBaoInfo.aspx");
        }

        private EyouSoft.Model.MCompanySetting GetFormValue()
        {
            var model = new BLL.OtherStructure.BKV().GetCompanySetting() ?? new EyouSoft.Model.MCompanySetting();


            model.EBaoSSM = Utils.EditInputText(txtEBaoSSM.Text);
            model.EBaoYEGL = Utils.EditInputText(txtEBaoYEGL.Text);
            model.EBaoCZMX = Utils.EditInputText(txtEBaoCZMX.Text);
            model.EBaoGMMX = Utils.EditInputText(txtEBaoGMMX.Text);
            model.EBaoFLMX = Utils.EditInputText(txtEBaoFLMX.Text);
            model.EBaoTXMX = Utils.EditInputText(txtEBaoTXMX.Text);
            model.EBaoFXJ = Utils.EditInputText(txtEBaoFXJ.Text);
            model.EBaoZHMX = Utils.EditInputText(txtEBaoZHMX.Text);
            model.EBaoZMX = Utils.EditInputText(txtEBaoZMX.Text);
            model.EBaoJFZZ = Utils.EditInputText(txtEBaoJFZZ.Text);


            return model;
        }
    }
}
