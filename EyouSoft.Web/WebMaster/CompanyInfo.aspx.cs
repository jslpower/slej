using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    /// <summary>
    /// 公司信息
    /// </summary>
    public partial class CompanyInfo : EyouSoft.Common.Page.WebmasterPageBase
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

            //txtCompanyIntroduce.Text = model.CompanyIntroduce;
            //txtAboutUs.Text = model.About;
            //txtContact.Text = model.Contact;
            txtCopyright.Text = model.Copyright;
            //txtJoinUs.Text = model.Join;
            //txtLegalDisclaimer.Text = model.LegalNotices;
            //txtStatistical.Text = model.Code;
            txtFenXiao.Text = model.MakeFenXiao;
            txtGongYing.Text = model.MakeGongYing;
            txtGuiBin.Text = model.MakeGuiBin;
            txtPuTong.Text = model.MakePuTong;
            txtYingPin.Text = model.MakeYingPing;
            txtEbao.Text = model.EBao;
            txtSLEJ.Text = model.SLEJText;
            MoblieEBao.Text = model.MoblieEBao;
            MoblieSLEJ.Text = model.MoblieSLEJText;
            DaiLiTiaoKuan.Text = model.DaiLiTiaoKuan;
            WapSet.Text = model.WapSet;

            txtWapFenXiao.Text = model.WapMakeFenXiao;
            txtWapGongYing.Text = model.WapMakeGongYing;
            txtWapGuiBin.Text = model.WapMakeGuiBin;
            txtWapPuTong.Text = model.WapMakePuTong;
            txtWapYingPin.Text = model.WapMakeYingPing;


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

            //model.About = Utils.EditInputText(txtAboutUs.Text);
            //model.Code = txtStatistical.Text;
            //model.CompanyIntroduce = Utils.EditInputText(txtCompanyIntroduce.Text);
            //model.Contact = Utils.EditInputText(txtContact.Text);
            model.Copyright = Utils.EditInputText(txtCopyright.Text);
            //model.Join = Utils.EditInputText(txtJoinUs.Text);
            //model.LegalNotices = Utils.EditInputText(txtLegalDisclaimer.Text);
            model.MakeFenXiao = Utils.EditInputText(txtFenXiao.Text);
            model.MakeGongYing = Utils.EditInputText(txtGongYing.Text);
            model.MakeGuiBin = Utils.EditInputText(txtGuiBin.Text);
            model.MakePuTong = Utils.EditInputText(txtPuTong.Text);
            model.MakeYingPing = Utils.EditInputText(txtYingPin.Text);
            model.EBao = Utils.EditInputText(txtEbao.Text);
            model.SLEJText = Utils.EditInputText(txtSLEJ.Text);
            model.MoblieEBao = Utils.EditInputText(MoblieEBao.Text);
            model.MoblieSLEJText = Utils.EditInputText(MoblieSLEJ.Text);
            model.DaiLiTiaoKuan = Utils.EditInputText(DaiLiTiaoKuan.Text);
            model.WapSet = Utils.EditInputText(WapSet.Text);

            model.WapMakeFenXiao = Utils.EditInputText(txtWapFenXiao.Text);
            model.WapMakeGongYing = Utils.EditInputText(txtWapGongYing.Text);
            model.WapMakeGuiBin = Utils.EditInputText(txtWapGuiBin.Text);
            model.WapMakePuTong = Utils.EditInputText(txtWapPuTong.Text);
            model.WapMakeYingPing = Utils.EditInputText(txtWapYingPin.Text);
            return model;
        }
    }
}
