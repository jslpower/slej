using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.Enum.ScenicStructure;
using EyouSoft.Model.ScenicStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.Web.WebMaster.ScenicAndTicketManage
{
   public partial class SetScenicImg : EyouSoft.Common.Page.WebmasterPageBase
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         string scenicid = Utils.GetQueryStringValue("scenicid");
         string imgid = Utils.GetQueryStringValue("imgid");
         string dotype = Utils.GetQueryStringValue("dotype");
         string scenicname = Utils.GetQueryStringValue("name");
         string imgtype = Utils.GetQueryStringValue("imgtype");
         this.scenicname.Value = scenicname;

         if (UserInfo.LeiXing == WebmasterUserType.供应商用户)
         {
            scenicid = UserInfo.GysId;
         }

         if (dotype == "deleteimg" && imgid != "")
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
      private void PageInit(string scenicid)
      {
         EyouSoft.BLL.ScenicStructure.BScenicArea bll = new EyouSoft.BLL.ScenicStructure.BScenicArea();
         IList<EyouSoft.Model.ScenicStructure.MScenicAreaImg> imglist = bll.GetScenicAreaImgList(scenicid);
         IList<MScenicAreaImg> nlistScenicImg = new List<MScenicAreaImg>();
         if (imglist != null && imglist.Count > 0)
         {
            foreach (var item in imglist)
            {
               switch (item.ImgType)
               {
                  case ScenicImgType.景区形象:
                     if (item != null)
                     {
                        this.Imgscenic.ImageUrl = item.Address;
                        this.txtscenicimgdesc.Text = item.Description;
                        this.hidxingxiangimgid.Value = item.ImgId;
                        this.txtscenicimgdesc.Attributes.Add("readonly", "readonly");

                        //var files=new List<EyouSoft.Web.UserControl.MFileInfo>();
                        //files.Add(new EyouSoft.Web.UserControl.MFileInfo() { FilePath=item.Address });
                        //upload1.YuanFiles = files;
                     }
                     break;
                  case ScenicImgType.景区导游地图:
                     if (item != null)
                     {
                        this.Imgdaolan.ImageUrl = item.Address;
                        this.txtdaolanimgdesc.Text = item.Description;
                        this.hiddaolanimgid.Value = item.ImgId;
                        this.txtdaolanimgdesc.Attributes.Add("readonly", "readonly");
                        this.deldaolan.Visible = true;

                        //var files = new List<EyouSoft.Web.UserControl.MFileInfo>();
                        //files.Add(new EyouSoft.Web.UserControl.MFileInfo() { FilePath = item.Address });
                        //UploadControl2.YuanFiles = files;
                     }
                     break;
                  case ScenicImgType.其他:
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
         this.rptmoreImgList.DataSource = nlistScenicImg;
         this.rptmoreImgList.DataBind();

         var info = bll.GetScenicAreaById(scenicid);
         if (info != null)
         {
            ltrJingDianName.Text = info.ScenicName;
            scenicname.Value = info.ScenicName;
         }
      }

      private string Save(string scenicid, string type)
      {
         string msg = "";
         EyouSoft.BLL.ScenicStructure.BScenicArea bll = new EyouSoft.BLL.ScenicStructure.BScenicArea();
         MScenicAreaImg model = new MScenicAreaImg();
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
                  model.Address = newFiles[0].FilePath;
               }
               model.ImgType = EyouSoft.Model.Enum.ScenicStructure.ScenicImgType.景区形象;
               model.Description = Utils.GetFormValue(this.scenicname.UniqueID) + "_" + EyouSoft.Model.Enum.ScenicStructure.ScenicImgType.景区形象.ToString();
               t = Utils.GetFormValue(this.hidxingxiangimgid.UniqueID) == "" ? true : false;
               if (!t)
                  model.ImgId = Utils.GetFormValue(hidxingxiangimgid.UniqueID);
               break;
            case "daolan":
               var newFilesdaolan = UploadControl2.Files;
               var oldFilesdaolan = UploadControl2.YuanFiles;
               if (oldFilesdaolan != null && oldFilesdaolan.Any())
               {
                  t = false;
               }
               else
               {
                  t = true;
               }

               if (newFilesdaolan != null && newFilesdaolan.Any())
               {
                  model.Address = newFilesdaolan[0].FilePath;
               }
               model.ImgType = EyouSoft.Model.Enum.ScenicStructure.ScenicImgType.景区导游地图;
               model.Description = Utils.GetFormValue(this.scenicname.UniqueID) + "_" + EyouSoft.Model.Enum.ScenicStructure.ScenicImgType.景区导游地图.ToString();
               t = Utils.GetFormValue(this.hiddaolanimgid.UniqueID) == "" ? true : false;
               if (!t)
                  model.ImgId = Utils.GetFormValue(hiddaolanimgid.UniqueID);
               break;
            case "more":
               var newFilesmore = UploadControl3.Files;
               var oldFilesmore = UploadControl3.YuanFiles;
               /*if (oldFilesmore != null && oldFilesmore.Any())
               {
                   t = false;
               }
               else
               {
                   t = true;
               }*/
               if (newFilesmore != null && newFilesmore.Any())
                  model.Address = newFilesmore[0].FilePath;
               model.Description = Utils.GetFormValue(this.txtmoreimgdesc.UniqueID);
               model.ImgType = EyouSoft.Model.Enum.ScenicStructure.ScenicImgType.其他;
               //t = Utils.GetFormValue(this.hidmoreimgid.UniqueID) == "" ? true : false;
               //if (!t)
               model.ImgId = Utils.GetFormValue(hidmoreimgid.UniqueID);
               t = true;
               break;
            default:
               break;
         }
         model.OperatorId = UserInfo.UserId.ToString();
         model.ScenicId = scenicid;
         if (t)
         {
            if (bll.AddScenicAreaImg(model))
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
            if (bll.UpdateScenicAreaImg(model))
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
      private string DeleteImg(string imgid)
      {
         string msg = string.Empty;
         EyouSoft.BLL.ScenicStructure.BScenicArea bll = new EyouSoft.BLL.ScenicStructure.BScenicArea();
         if (bll.DeleteScenicAreaImg(imgid))
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
