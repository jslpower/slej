using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.Web.WebMaster.ShangCheng
{
    public partial class ProductEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected string SelctType = "-1";
        protected decimal hybl = 0, gbbl = 0, dlbl = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("save") == "save") BaoCun();
            initDDL();
            InitPage();
        }
        void BaoCun()
        {
            var model = new EyouSoft.Model.MallStructure.MShangChengShangPin();

            model.ProductName = Utils.GetFormValue(txtChanPinMingCheng.UniqueID);
            model.EffectDate = Utils.GetDateTimeNullable(Utils.GetFormValue(txtYouXiaoQi.UniqueID));
            model.ProductionDate = Utils.GetDateTimeNullable(Utils.GetFormValue(txtShengChanRiQi.UniqueID));
            model.ShelfDate = Utils.GetInt(Utils.GetFormValue(txtBaoZhiQi.UniqueID));
            model.ModelDesc = Utils.GetFormValue(txtXingHao.UniqueID);
            model.ColorDesc = Utils.GetFormValue(txtYanSe.UniqueID);
            model.MarketPrice = Utils.GetDecimal(Utils.GetFormValue(txtMenShiJia.UniqueID));
            model.SalePrice = Utils.GetDecimal(Utils.GetFormValue(txtYouHuiJia.UniqueID));
            model.Remark = Utils.EditInputText(Request.Form[txtChanPinJieShao.UniqueID]);
            model.ContentService = Utils.EditInputText(Request.Form[txtBaoHanFW.UniqueID]);
            model.UnContentService = Utils.EditInputText(Request.Form[txtBuBaoHanFW.UniqueID]);
            model.UseRule = Utils.EditInputText(Request.Form[txtShiYong.UniqueID]);
            model.NoticeKnow = Utils.EditInputText(Request.Form[txtZhuYi.UniqueID]);
            model.MailWay = Utils.EditInputText(Request.Form[txtYouJi.UniqueID]);
            
            model.StylesDesc = Utils.GetFormValue(txtKuanShi.UniqueID);
            model.ProductNum = Utils.GetInt(Utils.GetFormValue(txtShuLiang.UniqueID));
            model.Unit = Utils.GetFormValue(txtDanWei.UniqueID);
            model.GYSid = UserInfo.GysId;
            if (!string.IsNullOrEmpty(Utils.GetFormValue("ddlLeiBie2")) && Utils.GetInt(Utils.GetFormValue("ddlLeiBie2"))>0)
            {
                model.TypeID = Utils.GetInt(Utils.GetFormValue("ddlLeiBie2"));
            }
            else
            {
                Response.Write(UtilsCommons.AjaxReturnJson("0", "请选择2级类别！"));
                Response.End();
            }
            
            List<EyouSoft.Model.MallStructure.MChanPinTuPian> imgs = new List<EyouSoft.Model.MallStructure.MChanPinTuPian>();
            string[] imgArr = Utils.GetFormValues("UploadControl1hidFileName");
            if (imgArr != null && imgArr.Length > 0)
            {
                for (int i = 0; i < imgArr.Length; i++)
                {
                    EyouSoft.Model.MallStructure.MChanPinTuPian img = new EyouSoft.Model.MallStructure.MChanPinTuPian();
                    img.FileDesc = imgArr[0].Split('|').Length > 0 ? imgArr[i].Split('|')[0] : "";
                    img.FilePath = imgArr[0].Split('|').Length > 0 ? imgArr[i].Split('|')[1] : "";
                    imgs.Add(img);
                }
            }
            model.ProductImgs = imgs;
            if (model.ProductImgs.Count==0)
            {
                Response.Write(UtilsCommons.AjaxReturnJson("0", "请上传产品图片"));
                Response.End();
            }
            int result = 0;
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "add")
            {
                result = new EyouSoft.BLL.MallStructure.BShangChengShangPin().Insert(model);
            }
            else
            {
                model.ProductID = Utils.GetQueryStringValue("id");
                result = new EyouSoft.BLL.MallStructure.BShangChengShangPin().Update(model);
            }
            Response.Clear();
            if (result == 1)
            {
                Response.Write(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", dotype == "add" ? "添加成功" : "修改成功"));
            }
            else
            {
                Response.Write(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", dotype == "add" ? "添加失败" : "修改失败"));
            }
            Response.End();

        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void InitPage()
        {
            var model = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetModel(Utils.GetQueryStringValue("id"));
            if (model != null)
            {
                txtChanPinMingCheng.Text = model.ProductName;
                txtShengChanRiQi.Text = model.ProductionDate == null ? "" : model.ProductionDate.Value.ToString("yyyy-MM-dd");
                txtYouXiaoQi.Text = model.EffectDate == null ? "" : model.EffectDate.Value.ToString("yyyy-MM-dd");
                txtBaoZhiQi.Text = model.ShelfDate.ToString();
                SelctType = model.TypeID.ToString();
                txtKuanShi.Text = model.StylesDesc;
                txtXingHao.Text = model.ModelDesc;
                txtYanSe.Text = model.ColorDesc;
                txtMenShiJia.Text = model.MarketPrice.ToString("F2");
                txtYouHuiJia.Text = model.SalePrice.ToString("F2");
                txtShuLiang.Text = model.ProductNum.ToString();
                txtChanPinJieShao.Text = model.Remark;
                txtBaoHanFW.Text = model.ContentService;
                txtBuBaoHanFW.Text = model.UnContentService;
                txtShiYong.Text = model.UseRule;
                txtZhuYi.Text = model.NoticeKnow;
                txtYouJi.Text = model.MailWay;
                txtDanWei.Text = model.Unit;
                IList<EyouSoft.Web.UserControl.MFileInfo> imgs = new List<EyouSoft.Web.UserControl.MFileInfo>();
                StringBuilder uploadstr = new StringBuilder();
                if (model.ProductImgs != null && model.ProductImgs.Count > 0)
                {
                    for (int i = 0; i < model.ProductImgs.Count; i++)
                    {
                        uploadstr.AppendFormat("<span style='vertical-align: bottom;'><a href='{1}' target='_blank'>查看图片</a><img alt='' class='pand4' onclick=\"pageData.DelFile(this)\" style='vertical-align: bottom;' src='/images/webmaster/cha.gif' /><input type='hidden' name='UploadControl1hidFileName' value='{0}|{1}' /></span>", model.ProductImgs[i].FileDesc, model.ProductImgs[i].FilePath);
                    }
                }
                lbUploadInfo.Text = uploadstr.ToString();
            }
        }

        /// <summary>
        /// 绑定分类
        /// </summary>
        void initDDL()
        {
            var typeList = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetList(new EyouSoft.Model.MallStructure.MShangChengLeiBieSer() { }, false);
            string strChildsOpt = "[";
            if (typeList != null && typeList.Count > 0)
            {
                for (int i = 0; i < typeList.Count; i++)
                {
                    strChildsOpt += "{\"tid\":\"" + typeList[i].TypeID + "\",\"tname\":\"" + typeList[i].TypeName + "\",\"pid\":\"" + typeList[i].ParentID + "\"},";
                }
            }
            strChildsOpt.ToString().TrimEnd(',');
            strChildsOpt += "]";
            RegisterScript(string.Format("var selectChild={0}", strChildsOpt.ToString()));
        }

    }
}
