using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.IO;

namespace EyouSoft.Web.CommonPage
{

    public partial class uploadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            // Get the file data.
            HttpPostedFile image_upload = Request.Files["uploadInput"];

            if (image_upload == null
                       || image_upload.ContentLength <= 0) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "文件为空"));

            if (image_upload.ContentLength > 2097152) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "文件过大"));
            string fileExt = System.IO.Path.GetExtension(image_upload.FileName);

            if (string.IsNullOrEmpty(fileExt)) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "文件格式错误"));

            string fileName = Utils.GenerateFileName(fileExt);
            string[] fileTypeList = new[] { ".xls", ".xlsx", ".rar", ".zip", ".7z", ".pdf", ".doc", ".docx", ".dot", ".swf", ".jpg", ".gif",
                    ".jpeg", ".png", ".bmp" };
            if (!fileTypeList.Contains(fileExt.ToLower())) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "文件格式错误"));


            string relativePath = "/UploadFiles/tmpFile/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + fileName;
            string relativeDirPath = "/UploadFiles/tmpFile/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/";

            string desFilePath = Server.MapPath(relativePath);
            string desDirPath = Server.MapPath(relativeDirPath);

            if (!Directory.Exists(desDirPath))
            {
                Directory.CreateDirectory(desDirPath);
            }
            image_upload.SaveAs(desFilePath);
            Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "上传成功", relativePath));
        }
    }
}
