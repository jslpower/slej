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
            string gysType = "0";
            string id = Utils.GetQueryStringValue("id");

            if (Utils.GetQueryStringValue("type") == "left")
            {
                id = UserInfo.GysId;
            }
            var model = new EyouSoft.BLL.SystemStructure.BSupplier().GetModel(id);
            if (model != null)
            {
                txtSuppName.ReadOnly = true;
                txtSuppName.Text = model.SuppName;
                txtSuppPwd.Text = model.SuppPwd;
                txtDanWeiMingCheng.Text = model.SupplierName;
                if (Utils.GetQueryStringValue("type") == "left")
                {
                    txtDanWeiMingCheng.ReadOnly = true;
                }
                gysType = ((int)model.SupplierType).ToString();
                txtZiZhi.Text = model.Qualifications;
                txtLianXiRen.Text = model.ContactName;
                txtDianHua.Text = model.ContactPhone;
                txtShouJi.Text = model.ContactMobile;
                txtQQ.Text = model.ContactQQ;
                txtYouXiang.Text = model.ContactMail;
                txtWangZhi.Text = model.SuppULR;
                txtDiZhi.Text = model.SuppAddress;
                X.InnerText = jingdu.Value = model.MapX;
                Y.InnerText = weidu.Value = model.MapY;

                if (!string.IsNullOrEmpty(model.CardPath)) litShenFenZheng.Text = string.Format("<span style='vertical-align: bottom;'><a href='{0}' target='_blank'>查看图片</a><img alt='' class='pand4' onclick=\"pageData.DelFile(this)\" style='vertical-align: bottom;' src='/images/webmaster/cha.gif' /><input type='hidden' name='upShenFenZhenghidFileName' value='1|{0}' /></span>", model.CardPath);
                if (!string.IsNullOrEmpty(model.AccountPaht)) litHuKouBu.Text = string.Format("<span style='vertical-align: bottom;'><a href='{0}' target='_blank'>查看图片</a><img alt='' class='pand4' onclick=\"pageData.DelFile(this)\" style='vertical-align: bottom;' src='/images/webmaster/cha.gif' /><input type='hidden' name='upHuKouBuhidFileName' value='1|{0}' /></span>", model.AccountPaht);
                if (!string.IsNullOrEmpty(model.VisitPath)) litMingPian.Text = string.Format("<span style='vertical-align: bottom;'><a href='{0}' target='_blank'>查看图片</a><img alt='' class='pand4' onclick=\"pageData.DelFile(this)\" style='vertical-align: bottom;' src='/images/webmaster/cha.gif' /><input type='hidden' name='upMingPianhidFileName' value='1|{0}' /></span>", model.VisitPath);
                if (!string.IsNullOrEmpty(model.OtherPath)) litQiTaZhengJian.Text = string.Format("<span style='vertical-align: bottom;'><a href='{0}' target='_blank'>查看图片</a><img alt='' class='pand4' onclick=\"pageData.DelFile(this)\" style='vertical-align: bottom;' src='/images/webmaster/cha.gif' /><input type='hidden' name='upQiTaZhengJianhidFileName' value='1|{0}' /></span>", model.OtherPath);
                if (!string.IsNullOrEmpty(model.FormPath)) litBiaoGe.Text = string.Format("<span style='vertical-align: bottom;'><a href='{0}' target='_blank'>查看图片</a><img alt='' class='pand4' onclick=\"pageData.DelFile(this)\" style='vertical-align: bottom;' src='/images/webmaster/cha.gif' /><input type='hidden' name='upBiaoGehidFileName' value='1|{0}' /></span>", model.FormPath);
            }
            strGYSType = Utils.GetEnumDDL(EnumObj.GetList(typeof(EyouSoft.Model.Enum.SupplierType)), gysType, false);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        void pageSave()
        {
            var model = new EyouSoft.Model.SystemStructure.MSupplier();
            model.SuppName = Utils.GetFormValue(txtSuppName.UniqueID);
            model.SuppPwd = Utils.GetFormValue(txtSuppPwd.UniqueID);
            model.SupplierName = Utils.GetFormValue(txtDanWeiMingCheng.UniqueID);
            model.SupplierType = (EyouSoft.Model.Enum.SupplierType)Utils.GetInt(Utils.GetFormValue("ddlGYSType"));
            model.Qualifications = Utils.GetFormValue(txtZiZhi.UniqueID);
            model.ContactName = Utils.GetFormValue(txtLianXiRen.UniqueID);
            model.ContactPhone = Utils.GetFormValue(txtDianHua.UniqueID);
            model.ContactMobile = Utils.GetFormValue(txtShouJi.UniqueID);
            model.ContactQQ = Utils.GetFormValue(txtQQ.UniqueID);
            model.ContactMail = Utils.GetFormValue(txtYouXiang.UniqueID);
            model.SuppULR = Utils.GetFormValue(txtWangZhi.UniqueID);
            model.SuppAddress = Utils.GetFormValue(txtDiZhi.UniqueID);
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

            model.OperatorID = UserInfo.UserId.ToString();
            model.OperatorName = UserInfo.Username;

            #region 写入后台用户
            var webUser = new Model.MWebmaster
            {
                Fax = model.ContactQQ,//传真字段保存QQ信息。
                Mobile = model.ContactMobile,
                Telephone = model.ContactPhone,
                Realname = model.ContactName,
                Username = model.SuppName,
                IsEnable = 1,
                LeiXing = 1
            };

            if (!string.IsNullOrEmpty(model.SuppPwd))
            {
                webUser.Password = model.SuppPwd;
                webUser.MD5Password = new EyouSoft.Toolkit.DataProtection.HashCrypto().MD5Encrypt(model.SuppPwd);
            }


            #endregion

            int result = 0;
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "add")
            {
                model.SuppName = "G" + model.SuppName;
                webUser.Username = model.SuppName;
                if (!new EyouSoft.BLL.SystemStructure.BSupplier().ExistsName(model.SuppName))
                {

                    model.ID = Guid.NewGuid().ToString();
                    webUser.GysId = model.ID;
                    webUser.CreateTime = DateTime.Now;
                    webUser.IsAdmin = (int)EyouSoft.Model.Enum.Is.是;
                    webUser.Permissions = string.Empty;
                    if (!new BLL.OtherStructure.BWebmaster().ExistsUserName(model.SuppName, -1))
                    {
                        result = new EyouSoft.BLL.SystemStructure.BSupplier().Insert(model);
                        new BLL.OtherStructure.BWebmaster().Add(webUser);
                    }
                    else
                    {
                        result = 3;
                    }
                }
                else
                {
                    result = 3;
                }
            }
            else
            {
                model.ID = Utils.GetQueryStringValue("id");
                if (Utils.GetQueryStringValue("domark") == "left")
                {
                    model.ID = UserInfo.GysId;
                }
                result = new EyouSoft.BLL.SystemStructure.BSupplier().Update(model);
            }
            Response.Clear();
            if (result == 1 || result == 2)
            {
                Response.Write(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", dotype == "add" ? "添加成功" : "修改成功"));
            }
            else if (result == 3)
            {
                Response.Write(UtilsCommons.AjaxReturnJson("0", "用户名重复"));
            }
            else
            {
                Response.Write(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", dotype == "add" ? "添加失败" : "修改失败"));
            }
            Response.End();
        }
    }
}
