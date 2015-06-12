using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.TuanGou
{
    public partial class TuanGouEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected string CxType = string.Empty, CpType = string.Empty, CpWeiZhi = "0";
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
            int id = Utils.GetInt(Utils.GetQueryStringValue("id"));
            var model = new EyouSoft.BLL.OtherStructure.BTuanGou().GetModel(id);
            if (model != null)
            {
                CxType = ((int)model.SaleType).ToString();
                CpType = ((int)model.ProductType).ToString();
                CpWeiZhi = ((int)model.WeiZhi).ToString();
                txtChanPinMingCheng.Text = model.ProductName;
                txtShuLiang.Text = model.ProductNum.ToString();
                txtShiChangJia.Text = model.MarketPrice.ToString("F2");
                txtCuXiaoJia.Text = model.GroupPrice.ToString("F2"); ;
                txtYouXiaoQi.Text = model.ValiDate.ToString("yyyy-MM-dd");
                txtJieShao.Text = model.SimpleInfo;
                txtJieShaoXX.Text = model.DetailInfo;
                if (model.ProductSort >= 0)
                {
                    txtSort.Text = model.ProductSort.ToString();
                }
                if (!string.IsNullOrEmpty(model.ProductImg)) lblFiles.Text = string.Format("<span style='vertical-align: bottom;'><a href=\"{0}\" target=\"_blank\">查看图片</a><img alt='' class='pand4' style='vertical-align: bottom;' onclick=\"pageData.DelImg(this)\" src='/images/webmaster/cha.gif' /><input type='hidden' name='hideimg' value='{0}' /></span>", model.ProductImg);
            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        void pageSave()
        {
            var model = new EyouSoft.Model.OtherStructure.MTuanGouChanPin();
            model.ProductName = Utils.GetFormValue(txtChanPinMingCheng.UniqueID);
            model.SaleType = (EyouSoft.Model.Enum.CuXiaoLeiXing)Utils.GetInt(Utils.GetFormValue("ddlCxType"));
            model.ProductType = (EyouSoft.Model.Enum.ChanPinLeiXing)Utils.GetInt(Utils.GetFormValue("ddlCpType"));
            if (UserInfo.LeiXing == EyouSoft.Model.Enum.WebmasterUserType.代理商用户)
            {
                model.WeiZhi = EyouSoft.Model.Enum.XianShiWeiZhi.网站首页;
            }
            else
            {
                model.WeiZhi = (EyouSoft.Model.Enum.XianShiWeiZhi)Utils.GetInt(Utils.GetFormValue("ddlweizhi"));
            }
            model.ProductNum = Utils.GetInt(Utils.GetFormValue(txtShuLiang.UniqueID));
            model.MarketPrice = Utils.GetDecimal(Utils.GetFormValue(txtShiChangJia.UniqueID));
            model.GroupPrice = Utils.GetDecimal(Utils.GetFormValue(txtCuXiaoJia.UniqueID));
            model.ValiDate = Utils.GetDateTime(Utils.GetFormValue(txtYouXiaoQi.UniqueID));
            model.SimpleInfo = Utils.GetFormValue(txtJieShao.UniqueID);
            model.DetailInfo = Utils.EditInputText(txtJieShaoXX.Text);
            if (!string.IsNullOrEmpty(Utils.GetFormValue(txtSort.UniqueID)))
            {
                model.ProductSort = Utils.GetInt(Utils.GetFormValue(txtSort.UniqueID));
            }
            else
            {
                model.ProductSort = 0;
            }
            model.OperatorID = UserInfo.UserId.ToString();
            model.OperatorName = UserInfo.Username;


            if (UserInfo.LeiXing == EyouSoft.Model.Enum.WebmasterUserType.代理商用户)
            {
                model.SupplierID = UserInfo.GysId;
            }
            else
            {
                model.SupplierID = "-1";
            }


            string imgUpload = Utils.GetFormValue(upImg.ClientHideID);
            string oldimgUpload = Utils.GetFormValue("hideimg");
            if (imgUpload.Split('|').Length > 1)
            {
                model.ProductImg = imgUpload.Split('|')[1];
            }
            else
            {
                model.ProductImg = oldimgUpload;
            }



            if (string.IsNullOrEmpty(model.ProductImg)) RCWE(UtilsCommons.AjaxReturnJson("0", "请上传产品图片！"));



            int result = 0;
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "add")
            {
                result = new EyouSoft.BLL.OtherStructure.BTuanGou().Add(model);
            }
            else
            {
                model.ID = Utils.GetInt(Utils.GetQueryStringValue("id"));
                result = new EyouSoft.BLL.OtherStructure.BTuanGou().Update(model);
            }
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", dotype == "add" ? "添加" + (result == 1 ? "成功" : "失败") : "修改" + (result == 1 ? "成功" : "失败")));
            Response.End();
        }
    }
}
