using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.Supplier
{
    public partial class SupplierEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected string strGYSType = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initPage();
            }
            if (Utils.GetQueryStringValue("save") == "save") pageSave();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        void initPage()
        {
            int gysType = 0;
            string id = UserInfo.GysId;
            var model = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(id);
            if (model != null)
            {
                var memberModel = new EyouSoft.IDAL.MemberStructure.BMember2().Get(model.MemberID);
                txtDanWeiMingCheng.Text = model.CompanyName;
                txtJC.Text = model.CompanyJC;
                gysType = (int)model.SupplierType;
                txtZiZhi.Text = model.Qualifications;
                txtLianXiRen.Text = memberModel.MemberName;
                txtDianHua.Text = memberModel.Contact;
                txtShouJi.Text = memberModel.Mobile;
                txtQQ.Text = memberModel.qq;
                txtYouXiang.Text = memberModel.Email;
                //txtWangZhi.Text = model.SuppULR;
                txtDiZhi.Text = memberModel.Address;
                X.InnerText = jingdu.Value = model.MapX;
                Y.InnerText = weidu.Value = model.MapY;

                if (!string.IsNullOrEmpty(model.CardPath)) litShenFenZheng.Text = string.Format("<span style='vertical-align: bottom;'><a href='{0}' target='_blank'>查看图片</a><img alt='' class='pand4' onclick=\"pageData.DelFile(this)\" style='vertical-align: bottom;' src='/images/webmaster/cha.gif' /><input type='hidden' name='upShenFenZhenghidFileName' value='1|{0}' /></span>", model.CardPath);
                if (!string.IsNullOrEmpty(model.AccountPaht)) litHuKouBu.Text = string.Format("<span style='vertical-align: bottom;'><a href='{0}' target='_blank'>查看图片</a><img alt='' class='pand4' onclick=\"pageData.DelFile(this)\" style='vertical-align: bottom;' src='/images/webmaster/cha.gif' /><input type='hidden' name='upHuKouBuhidFileName' value='1|{0}' /></span>", model.AccountPaht);
                if (!string.IsNullOrEmpty(model.VisitPath)) litMingPian.Text = string.Format("<span style='vertical-align: bottom;'><a href='{0}' target='_blank'>查看图片</a><img alt='' class='pand4' onclick=\"pageData.DelFile(this)\" style='vertical-align: bottom;' src='/images/webmaster/cha.gif' /><input type='hidden' name='upMingPianhidFileName' value='1|{0}' /></span>", model.VisitPath);
                if (!string.IsNullOrEmpty(model.OtherPath)) litQiTaZhengJian.Text = string.Format("<span style='vertical-align: bottom;'><a href='{0}' target='_blank'>查看图片</a><img alt='' class='pand4' onclick=\"pageData.DelFile(this)\" style='vertical-align: bottom;' src='/images/webmaster/cha.gif' /><input type='hidden' name='upQiTaZhengJianhidFileName' value='1|{0}' /></span>", model.OtherPath);
                if (!string.IsNullOrEmpty(model.FormPath)) litBiaoGe.Text = string.Format("<span style='vertical-align: bottom;'><a href='{0}' target='_blank'>查看图片</a><img alt='' class='pand4' onclick=\"pageData.DelFile(this)\" style='vertical-align: bottom;' src='/images/webmaster/cha.gif' /><input type='hidden' name='upBiaoGehidFileName' value='1|{0}' /></span>", model.FormPath);
            }
            strGYSType = Utils.GetEnumDDL(EnumObj.GetList(typeof(EyouSoft.Model.Enum.SupplierType)), gysType.ToString(), false);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        void pageSave()
        {
            var Sellermodel = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(UserInfo.GysId);
            var model = new EyouSoft.Model.AccountStructure.MSellers();
            var memberModel = new MMember2();
            model.ID = Sellermodel.ID;
            memberModel.MemberID = Sellermodel.MemberID;
            model.CompanyName = Utils.GetFormValue(txtDanWeiMingCheng.UniqueID);
            model.CompanyJC = Utils.GetFormValue(txtJC.UniqueID);
            model.SupplierType = (EyouSoft.Model.Enum.SupplierType)Utils.GetInt(Utils.GetFormValue("ddlGYSType"));
            model.Qualifications = Utils.GetFormValue(txtZiZhi.UniqueID);
            memberModel.MemberName = Utils.GetFormValue(txtLianXiRen.UniqueID);
            memberModel.Contact = Utils.GetFormValue(txtDianHua.UniqueID);
            memberModel.Mobile = Utils.GetFormValue(txtShouJi.UniqueID);
            memberModel.qq = Utils.GetFormValue(txtQQ.UniqueID);
            memberModel.Email = Utils.GetFormValue(txtYouXiang.UniqueID);
            //model.SuppULR = Utils.GetFormValue(txtWangZhi.UniqueID);
            memberModel.Address = Utils.GetFormValue(txtDiZhi.UniqueID);
            model.MapX = Utils.GetFormValue(jingdu.UniqueID);
            model.MapY = Utils.GetFormValue(weidu.UniqueID);


            string[] cards = Utils.GetFormValue("upShenFenZhenghidFileName").Split('|');
            string[] accounts = Utils.GetFormValue("upHuKouBuhidFileName").Split('|');
            string[] visits = Utils.GetFormValue("upMingPianhidFileName").Split('|');
            string[] others = Utils.GetFormValue("upQiTaZhengJianhidFileName").Split('|');
            string[] forms = Utils.GetFormValue("upBiaoGehidFileName").Split('|');

            if (cards.Length > 1) model.CardPath = cards[1];
            if (accounts.Length > 1) model.AccountPaht = accounts[1];
            if (visits.Length > 1) model.VisitPath = visits[1];
            if (others.Length > 1) model.OtherPath = others[1];
            if (forms.Length > 1) model.FormPath = forms[1];

            Response.Clear();
            if (new EyouSoft.BLL.MemberStructure.BMember().UpdateDaiLiMemberInfo(memberModel) == true && new EyouSoft.BLL.MemberStructure.BMember().UpdateDaiLiSellerInfo(model) == true)
            {
                Response.Write(UtilsCommons.AjaxReturnJson("1" , "修改成功！"));
            }
            else
            {
                Response.Write(UtilsCommons.AjaxReturnJson("0", "修改失败！"));
            }
            Response.End();

        }
    }
}
