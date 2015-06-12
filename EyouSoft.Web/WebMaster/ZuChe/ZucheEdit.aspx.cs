using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.ZuCheStructure;

namespace EyouSoft.Web.WebMaster.ZuChe
{
    public partial class ZucheEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Utils.GetQueryStringValue("dotype");
            if (type == "sava") Sava();
            if (!Page.IsPostBack)
            {
                InitInfo();
            }
        }
        protected void InitInfo()
        {
            string type = Utils.GetQueryStringValue("type");
            string id = Utils.GetQueryStringValue("id");
            if (type == "add") return;
            if (!string.IsNullOrEmpty(id) && type == "update")
            {
                EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
                var model = bll.GetModel(id);
                if (model == null) Utils.RCWE("异常请求");
                txtName.Text = model.CarName;
                txtChengZuo.Text = model.XianZuoRenShu.ToString();
                txtMenShiJia.Text = model.MenShiJia.ToString("f2");
                txtMenShiJiaGeZuChe.Text = model.MenShiJiaGeZuChe.ToString("f2");
                txtTianShuMenShi.Text = model.MenShiChaoShi.ToString("f2");
                txtMenShiJiaGeChaoShi.Text = model.MenShiJiaGeChaoShi.ToString("f2");
                txtChaoCMenShi.Text = model.MenShiChaoCheng.ToString("f2");
                txtMenShiJiaGeChaoCheng.Text = model.MenShiJiaGeChaoCheng.ToString("f2");
                txtYouHuiJia.Text = model.YouHuiJia.ToString("f2");
                txtYouHuiJiaGeZuChe.Text = model.YouHuiJiaGeZuChe.ToString("f2");
                txtYouHuiChaoShiMenShi.Text = model.YouHuiChaoShi.ToString("f2");
                txtYouHuiChaoShi.Text = model.YouHuiJiaGeChaoShi.ToString("f2");
                //txtYouHuiJiaGeChaoShi.Text = model.YouHuiJiaGeChaoShi.ToString("f2");
                txtYouHuiChaoCMenShi.Text = model.YouHuiChaoCheng.ToString("f2");
                txtYouHuiJiaGeChaoCheng.Text = model.YouHuiJiaGeChaoCheng.ToString("f2");
                txtYouHuiDanCheng.Text = model.YouHuiJiaGeDanCheng.ToString("f2");
                txtMenShiDanCheng.Text = model.MenShiJiaGeDanCheng.ToString("f2");
                txtShuoMing.Text = model.Remark;
                if (model.ZucheInfoImg != null && model.ZucheInfoImg.Count > 0)
                {
                    UploadFile.YuanFiles = new List<EyouSoft.Web.UserControl.MFileInfo> { new EyouSoft.Web.UserControl.MFileInfo { FilePath = model.ZucheInfoImg[0].FilePath, FileId = "-1", FileName = "已上传的图片" } };
                    UploadControl4.YuanFiles = new List<EyouSoft.Web.UserControl.MFileInfo> { new EyouSoft.Web.UserControl.MFileInfo { FilePath = model.ZucheInfoImg[1].FilePath, FileId = "-1", FileName = "已上传的图片" } };
                    UploadControl8.YuanFiles = new List<EyouSoft.Web.UserControl.MFileInfo> { new EyouSoft.Web.UserControl.MFileInfo { FilePath = model.ZucheInfoImg[2].FilePath, FileId = "-1", FileName = "已上传的图片" } };
                }
            }
            else Utils.RCWE("异常请求");
        }

        protected void Sava()
        {
            string type = Utils.GetQueryStringValue("type");
            string id = Utils.GetQueryStringValue("id");
            EyouSoft.Model.ZuCheStructure.MZuCheInfo model = new EyouSoft.Model.ZuCheStructure.MZuCheInfo();
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            model.CarName = Utils.GetFormValue(txtName.UniqueID);
            model.XianZuoRenShu = Utils.GetInt(Utils.GetFormValue(txtChengZuo.UniqueID));
            model.MenShiJia = Utils.GetDecimal(Utils.GetFormValue(txtMenShiJia.UniqueID));
            model.MenShiJiaGeZuChe = Utils.GetDecimal(Utils.GetFormValue(txtMenShiJiaGeZuChe.UniqueID));
            model.MenShiChaoShi = Utils.GetDecimal(Utils.GetFormValue(txtTianShuMenShi.UniqueID));
            model.MenShiJiaGeChaoShi = Utils.GetDecimal(Utils.GetFormValue(txtMenShiJiaGeChaoShi.UniqueID));
            model.MenShiChaoCheng = Utils.GetDecimal(Utils.GetFormValue(txtChaoCMenShi.UniqueID));
            model.MenShiJiaGeChaoCheng = Utils.GetDecimal(Utils.GetFormValue(txtMenShiJiaGeChaoCheng.UniqueID));
            model.YouHuiJia = Utils.GetDecimal(Utils.GetFormValue(txtYouHuiJia.UniqueID));
            model.YouHuiJiaGeZuChe = Utils.GetDecimal(Utils.GetFormValue(txtYouHuiJiaGeZuChe.UniqueID));
            model.YouHuiJiaGeChaoShi = Utils.GetDecimal(Utils.GetFormValue(txtYouHuiChaoShi.UniqueID));
            model.YouHuiChaoShi = Utils.GetDecimal(Utils.GetFormValue(txtYouHuiChaoShiMenShi.UniqueID));
            model.YouHuiChaoCheng = Utils.GetDecimal(Utils.GetFormValue(txtYouHuiChaoCMenShi.UniqueID));
            model.YouHuiJiaGeChaoCheng = Utils.GetDecimal(Utils.GetFormValue(txtYouHuiJiaGeChaoCheng.UniqueID));
            model.MenShiJiaGeDanCheng = Utils.GetDecimal(Utils.GetFormValue(txtMenShiDanCheng.UniqueID));
            model.YouHuiJiaGeDanCheng = Utils.GetDecimal(Utils.GetFormValue(txtYouHuiDanCheng.UniqueID));
            model.Remark = Utils.EditInputText(txtShuoMing.Text);
            model.OperatorId = UserInfo.UserId;
            IList<ZuCheImg> IMG = new List<ZuCheImg>();
            ZuCheImg IMG_model = null;

            #region 图片
            var newFiles = UploadFile.Files;
            if (newFiles == null || !newFiles.Any())
            {
                IMG_model = new ZuCheImg();
                IMG_model.Desc = "";
                IMG_model.OperatorId = UserInfo.UserId.ToString();
                IMG_model.IssueTime = DateTime.Now;
                var oldFiles = UploadFile.YuanFiles;
                if (oldFiles != null && oldFiles.Any())
                {


                    IMG_model.FilePath = oldFiles[0].FilePath;


                    //model.FilePath = oldFiles[0].FilePath;

                }
                else
                {
                    IMG_model.FilePath = string.Empty;
                }
                IMG.Add(IMG_model);
            }
            else
            {
                IMG_model = new ZuCheImg();
                IMG_model.Desc = "";
                IMG_model.FilePath = newFiles[0].FilePath;
                IMG_model.OperatorId = UserInfo.UserId.ToString();
                IMG_model.IssueTime = DateTime.Now;
                IMG.Add(IMG_model);
                //model.FilePath = newFiles[0].FilePath;
            }
            var newFiles1 = UploadControl4.Files;
            if (newFiles1 == null || !newFiles1.Any())
            {
                IMG_model = new ZuCheImg();
                IMG_model.Desc = "";
                IMG_model.OperatorId = UserInfo.UserId.ToString();
                IMG_model.IssueTime = DateTime.Now;
                var oldFiles1 = UploadControl4.YuanFiles;
                if (oldFiles1 != null && oldFiles1.Any())
                {


                    IMG_model.FilePath = oldFiles1[0].FilePath;



                    //model.FilePath = oldFiles1[0].FilePath;
                }
                else
                {
                    IMG_model.FilePath = string.Empty;
                }
                IMG.Add(IMG_model);
            }
            else
            {
                IMG_model = new ZuCheImg();
                IMG_model.Desc = "";
                IMG_model.FilePath = newFiles1[0].FilePath;
                IMG_model.OperatorId = UserInfo.UserId.ToString();
                IMG_model.IssueTime = DateTime.Now;
                IMG.Add(IMG_model);
                //model.FilePath = newFiles[0].FilePath;
            }
            var newFiles2 = UploadControl8.Files;
            if (newFiles2 == null || !newFiles2.Any())
            {
                IMG_model = new ZuCheImg();
                IMG_model.Desc = "";
                IMG_model.OperatorId = UserInfo.UserId.ToString();
                IMG_model.IssueTime = DateTime.Now;
                var oldFiles2 = UploadControl8.YuanFiles;
                if (oldFiles2 != null && oldFiles2.Any())
                {


                    IMG_model.FilePath = oldFiles2[0].FilePath;



                    //model.FilePath = oldFiles2[0].FilePath;
                }
                else
                {
                    IMG_model.FilePath = string.Empty;
                }
                IMG.Add(IMG_model);
            }
            else
            {
                IMG_model = new ZuCheImg();
                IMG_model.Desc = "";
                IMG_model.FilePath = newFiles2[0].FilePath;
                IMG_model.OperatorId = UserInfo.UserId.ToString();
                IMG_model.IssueTime = DateTime.Now;
                IMG.Add(IMG_model);
                //model.FilePath = newFiles[0].FilePath;
            }

            #endregion

            model.ZucheInfoImg = IMG;

            bool ret = false;
            if (type == "add")
                ret = bll.Add(model);
            if (type == "update" && !string.IsNullOrEmpty(id))
            {
                model.ZuCheID = id;
                ret = bll.Update(model);
            }
            Utils.RCWE(UtilsCommons.AjaxReturnJson(ret ? "1" : "0", ret ? "操作成功！" : "操作失败，重新操作！"));
        }
    }
}
