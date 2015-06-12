using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.HotelStructure;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.Web.WebMaster.HotelManage
{
    public partial class SetHotelImg : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string scenicid = Utils.GetQueryStringValue("hotelid");
            int imgid = Utils.GetInt(Utils.GetQueryStringValue("imgid"));
            string dotype = Utils.GetQueryStringValue("dotype");
            string scenicname = Utils.GetQueryStringValue("name");
            string imgtype = Utils.GetQueryStringValue("imgtype");
            this.scenicname.Value = scenicname;

            if (UserInfo.LeiXing == WebmasterUserType.供应商用户)
            {
                scenicid = UserInfo.GysId;
            }

            if (dotype == "deleteimg" && imgid != 0)
            {
                Response.Clear();
                Response.Write(DeleteImg(imgid));
                Response.End();
            }
            if (dotype == "save")
            {
                Response.Clear();
                Response.Write(Save(scenicid, imgtype));
                Response.End();
            }
            if (!IsPostBack)
            {
                PageInit(scenicid);
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="scenicid"></param>
        private void PageInit(string id)
        {
            EyouSoft.BLL.HotelStructure.BHotel bll = new EyouSoft.BLL.HotelStructure.BHotel();
            MHotel model = bll.GetModel(id);
            IList<MHotelImg> imglist = model.ImgList;
            IList<MHotelImg> nlistScenicImg = new List<MHotelImg>();
            if (imglist != null && imglist.Count > 0)
            {
                foreach (var item in imglist)
                {
                    switch (item.ImgCategory)
                    {
                        case EyouSoft.Model.Enum.HotelImgType.酒店形象照片:
                            if (item != null)
                            {
                                this.Imgscenic.ImageUrl = item.FilePath;
                                this.txtscenicimgdesc.Text = item.Desc;
                                this.hidxingxiangimgid.Value = item.ImgId.ToString();
                                this.txtscenicimgdesc.Attributes.Add("readonly", "readonly");
                            }
                            break;
                        case EyouSoft.Model.Enum.HotelImgType.其他:
                            if (item != null)
                            {
                                nlistScenicImg.Add(item);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            if (nlistScenicImg != null && nlistScenicImg.Count > 0)
            {
                this.rptmoreImgList.DataSource = nlistScenicImg;
                this.rptmoreImgList.DataBind();
            }

            if (model != null)
            {
                ltrJiuDianName.Text = model.HotelName;
                scenicname.Value = model.HotelName;
            }
        }

        private string Save(string scenicid, string type)
        {
            string msg = "";
            BHotel bll = new BHotel();
            MHotelImg model = new MHotelImg();
            //用来标识新增/修改图片
            bool t = false;
            switch (type)
            {
                case "xingxiang":
                    var newFiles = upload1.Files;
                    var oldFiles = upload1.YuanFiles;
                    if (oldFiles != null && oldFiles.Any())
                    {
                        t = false;
                    }
                    else
                    {
                        t = true;
                    }

                    if (newFiles != null && newFiles.Any())
                    {
                        model.FilePath = newFiles[0].FilePath;
                    }
                    model.ImgCategory = EyouSoft.Model.Enum.HotelImgType.酒店形象照片;
                    model.Desc = Utils.GetFormValue(this.scenicname.UniqueID) + "_" + EyouSoft.Model.Enum.HotelImgType.酒店形象照片.ToString();
                    t = Utils.GetFormValue(this.hidxingxiangimgid.UniqueID) == "" ? true : false;
                    if (!t)
                        model.ImgId = Utils.GetInt(Utils.GetFormValue(hidxingxiangimgid.UniqueID));
                    break;
                case "more":
                    var newFilesmore = UploadControl3.Files;
                    var oldFilesmore = UploadControl3.YuanFiles;
                    if (oldFilesmore != null && oldFilesmore.Any())
                    {
                        t = false;
                    }
                    else
                    {
                        t = true;
                    }
                    if (newFilesmore != null && newFilesmore.Any())
                        model.FilePath = newFilesmore[0].FilePath;
                    model.Desc = Utils.GetFormValue(this.txtmoreimgdesc.UniqueID);
                    model.ImgCategory = EyouSoft.Model.Enum.HotelImgType.其他;
                    if (!t)
                        model.ImgId = Utils.GetInt(Utils.GetFormValue(hidmoreimgid.UniqueID));
                    break;
                default:
                    break;
            }
            model.OperatorId = UserInfo.UserId.ToString();
            model.HotelId = scenicid;
            if (t)
            {
                if (bll.AddHotelImg(model))
                {
                    msg = Utils.AjaxReturnJson("1", "上传成功!");
                }
                else
                {
                    msg = Utils.AjaxReturnJson("0", "上传失败!");
                }
            }
            else
            {
                if (bll.UpdateHotelImg(model))
                {
                    msg = Utils.AjaxReturnJson("1", "上传成功!");
                }
                else
                {
                    msg = Utils.AjaxReturnJson("0", "上传失败!");
                }
            }
            return msg;
        }
        /// <summary>
        /// 删除更多图片
        /// </summary>
        /// <param name="imgid"></param>
        /// <returns></returns>
        private string DeleteImg(int imgid)
        {
            string msg = string.Empty;
            EyouSoft.BLL.HotelStructure.BHotel bll = new EyouSoft.BLL.HotelStructure.BHotel();
            if (bll.DeleteHotelImg(imgid))
            {
                msg = Utils.AjaxReturnJson("1", "删除成功!");
            }
            else
            {
                msg = Utils.AjaxReturnJson("0", "删除失败");
            }
            return msg;
        }
    }
}
