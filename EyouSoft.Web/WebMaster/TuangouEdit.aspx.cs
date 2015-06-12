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
using EyouSoft.Model.XianLuStructure;
using System.Text;
using System.Collections.Generic;

namespace EyouSoft.Web.WebMaster
{
    /// <summary>
    /// 团购
    /// </summary>
    public partial class TuangouEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string id = Utils.GetQueryStringValue("id");
            string type = Utils.GetQueryStringValue("type");
            if (type == "save")
            {
                Response.Clear();
                Response.Write(PageSave(dotype, id));
                Response.End();
            }
            if (!IsPostBack)
            {
                PageInit(dotype, id);
            }
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <param name="dotype"></param>
        /// <param name="id"></param>
        private void PageInit(string dotype, string id)
        {
            //t 为ture 新增，false 修改
            bool t = string.IsNullOrEmpty(id) && dotype == "add";
            if (!t)
            {
                EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
                MXianLuTuanGouInfo model = bll.GetTuanGouInfo(id);
                if (model != null)
                {
                    this.txtDesc.Text = model.JianYaoMiaoShu;
                    this.txtEndTime.Text = model.ETime.ToString("yyyy-MM-dd");
                    this.txtStartTime.Text = model.STime.ToString("yyyy-MM-dd");
                    this.txttuangouname.Text = model.TuanName;
                    this.SelectRoute1.Name = model.RouteName;
                    this.SelectRoute1.HideID = model.XianLuId;
                    this.txtSCCRPrice.Text = model.SCJCR.ToString("F2");
                    this.txtSCETPrice.Text = model.SCJET.ToString("F2");
                    this.txtJSCRPrice.Text = model.JSJCR.ToString("F2");
                    this.txtJSETPrice.Text = model.JSJET.ToString("F2");

                    if (model.FilePath != "")
                    {
                        StringBuilder uploadstr = new StringBuilder();
                        uploadstr.AppendFormat("<img height='75' width='100' alt='' class='addpic img' style='vertical-align:bottom' src='{0}' /><span style='vertical-align: bottom;'><img alt='' class='pand4' onclick=\"TuanGou.DelImg(this)\" style='vertical-align: bottom;' src='/images/webmaster/cha.gif' /><input type='hidden' name='hideimg' value='|{0}' /></span>", model.FilePath);
                        this.lbUploadInfo.Text = uploadstr.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="dotype"></param>
        /// <param name="id"></param>
        private string PageSave(string dotype, string id)
        {
            string msg = string.Empty;
            bool t = string.IsNullOrEmpty(id) && dotype == "add";
            string tuanname = Utils.GetFormValue(this.txttuangouname.UniqueID);
            string routename = Utils.GetFormValue(this.SelectRoute1.ClientText);
            string routeid = Utils.GetFormValue(this.SelectRoute1.ClientValue);
            string desc = Utils.GetFormValue(this.txtDesc.UniqueID);
            DateTime stime = Utils.GetDateTime(Utils.GetFormValue(this.txtStartTime.UniqueID));
            DateTime etime = Utils.GetDateTime(Utils.GetFormValue(this.txtEndTime.UniqueID));
            EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
            MXianLuTuanGouInfo model = new MXianLuTuanGouInfo();
            model.ETime = etime;
            model.STime = stime;
            model.RouteName = routename;
            model.TuanName = tuanname;
            model.XianLuId = routeid;
            model.JianYaoMiaoShu = desc;
            model.IssueTime = DateTime.Now;
            model.OperatorId = this.UserInfo.UserId;

            model.JSJCR = Utils.GetDecimal(Utils.GetFormValue(txtJSCRPrice.UniqueID));
            model.JSJET = Utils.GetDecimal(Utils.GetFormValue(txtJSETPrice.UniqueID));
            model.SCJCR = Utils.GetDecimal(Utils.GetFormValue(txtSCCRPrice.UniqueID));
            model.SCJET = Utils.GetDecimal(Utils.GetFormValue(txtSCETPrice.UniqueID));

            #region 特色图片上传
            string[] imgUpload = Utils.GetFormValues(this.UploadControl1.ClientHideID);
            string[] oldimgUpload = Utils.GetFormValues("hideimg");
            List<MFileInfo> imglist = null;
            if (oldimgUpload.Length > 0)
            {
                if (imglist == null)
                {
                    imglist = new List<MFileInfo>();
                }
                for (int i = 0; i < oldimgUpload.Length; i++)
                {
                    if (oldimgUpload[i].Trim() != "")
                    {
                        MFileInfo oldfilemodel = new MFileInfo();
                        oldfilemodel.FilePath = oldimgUpload[i].Split('|')[1];
                        imglist.Add(oldfilemodel);
                    }
                }
            }
            if (imgUpload.Length > 0)
            {
                imglist = new List<MFileInfo>();
                for (int i = 0; i < imgUpload.Length; i++)
                {
                    if (imgUpload[i].ToString() != "")
                    {
                        if (imgUpload[i].Split('|').Length > 1)
                        {
                            MFileInfo filemodel = new MFileInfo();
                            filemodel.FilePath = imgUpload[i].Split('|')[1];
                            imglist.Add(filemodel);
                        }
                    }
                }
            }

            #endregion

            model.Files = imglist;

            int result = 0;
            if (t)
            {
                result = bll.InsertTuanGou(model);
            }
            else
            {
                model.TuanGouId = id;
                model.LatestId = this.UserInfo.UserId;
                result = bll.UpdateTuanGou(model);
            }
            switch (result)
            {
                case 1:
                    msg = Utils.AjaxReturnJson("1", (t ? "新增" : "修改") + "成功!");
                    break;
                case -98:
                    msg = Utils.AjaxReturnJson("0", "不允许相同线路产品的团购时间有重叠!");
                    break;
                default:
                    msg = Utils.AjaxReturnJson("0", (t ? "新增" : "修改") + "失败!");
                    break;
            }
            return msg;
        }
    }
}
