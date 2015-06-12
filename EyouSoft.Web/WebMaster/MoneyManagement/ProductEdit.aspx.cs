using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.OtherStructure;
using EyouSoft.BLL.OtherStructure;

namespace EyouSoft.Web.WebMaster.TatolProduct
{
    public partial class ProductEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Utils.GetQueryStringValue("tid");
            string dotype = Utils.GetQueryStringValue("dotype").Trim();
            string type = Utils.GetQueryStringValue("type").Trim();

            //Ajax
            switch (type)
            {
                case "save":
                    Response.Clear();
                    Response.Write(PageSave(Utils.GetInt(id), dotype));
                    Response.End();
                    break;
                default:
                    break;
            }

            if (!IsPostBack)
            {
                PageInit(Utils.GetInt(id), dotype);
            }
        }

        private void PageInit(int id, string dotype)
        {
            if (id > 0 && dotype != "add")
            {
                EyouSoft.BLL.OtherStructure.BTravelArticle bll = new EyouSoft.BLL.OtherStructure.BTravelArticle();
                MTatolProduct model = new BTatolProduct().GetProductModel(id, null);
                if (model != null)
                {
                    this.txtProductName.Text = model.ProductName;
                    this.txtNum.Text = model.Num.ToString();
                    this.txtTotal.Text = model.Total.ToString();
                    this.txtPrice.Text = model.Price.ToString("F2");
                    this.txtProductInfo.Text = model.ProductInfo;

                    IList<EyouSoft.Web.UserControl.MFileInfo> picList = new List<EyouSoft.Web.UserControl.MFileInfo>();
                    if (model.PicList != null && model.PicList.Count > 0)
                    {
                        for (int i = 0; i < model.PicList.Count; i++)
                        {
                            picList.Add(new EyouSoft.Web.UserControl.MFileInfo() { FileName = model.PicList[i].Desc, FilePath = model.PicList[i].FilePath, FileId = model.PicList[i].PicID.ToString() });
                        }
                    }
                    //upload1.YuanFiles = new List<EyouSoft.Web.UserControl.MFileInfo>() { new EyouSoft.Web.UserControl.MFileInfo() { FileName = "图片", FilePath = model.ImgPath } };
                    upload1.YuanFiles = picList;

                    this.litExchangeNum.Text = model.ExchangeNum.ToString();
                    this.plhExchangeNum.Visible = true;
                    if (dotype.Equals("show"))
                    {
                        this.btn.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// 保存或修改信息
        /// </summary>
        private string PageSave(int id, string dotype)
        {
            //t为true 新增，false 修改
            bool t = id==0 && dotype == "add";
            string msg = string.Empty;

            BTatolProduct bll = new BTatolProduct();
            MTatolProduct model = new MTatolProduct();
            model.ProductName = Utils.GetFormValue(this.txtProductName.UniqueID);
            model.Num = Utils.GetInt(Utils.GetFormValue(this.txtNum.UniqueID));
            model.Total = Utils.GetInt(Utils.GetFormValue(this.txtTotal.UniqueID));
            model.Price = Utils.GetDecimal(Utils.GetFormValue(this.txtPrice.UniqueID));
            //model.ProductInfo = Utils.GetFormValue(this.txtProductInfo.UniqueID);
            model.ProductInfo = Request.Form[this.txtProductInfo.UniqueID];

            var newFiles = upload1.Files;
            if (newFiles == null || !newFiles.Any())
            {
                var oldFiles = upload1.YuanFiles;
                if (oldFiles != null && oldFiles.Any())
                {
                    model.PicList = new List<MTatolProductPic>();
                    for (int i = 0; i < oldFiles.Count; i++)
                    {
                        model.PicList.Add(new MTatolProductPic() { ProductID = id, FilePath = oldFiles[i].FilePath, Desc = oldFiles[i].FileName });
                    }
                }
            }
            else
            {
                model.PicList = new List<MTatolProductPic>();
                for (int i = 0; i < newFiles.Count; i++)
                {
                    model.PicList.Add(new MTatolProductPic() { ProductID = id, FilePath = newFiles[i].FilePath, Desc = newFiles[i].FileName });
                }
            }
            model.IssueTime = DateTime.Now;
            model.OperatorId = UserInfo.UserId.ToString();

            bool result = false;
            if (t)
            {
                result = bll.AddProduct(model);
            }
            else
            {
                model.ProductID = id;
                result = bll.UpdateProduct(model);
            }
            switch (result)
            {
                case true:
                    msg = Utils.AjaxReturnJson("1", (t ? "新增" : "修改") + "成功");
                    break;
                case false:
                    msg = Utils.AjaxReturnJson("0", (t ? "新增" : "修改") + "失败");
                    break;
                default:
                    break;
            }
            return msg;
        }
    }
}
