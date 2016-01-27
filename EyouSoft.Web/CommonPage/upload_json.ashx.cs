using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;
using EyouSoft.Common;
using System.Collections;

namespace EyouSoft.Web.CommonPage
{
    public class upload_json : IHttpHandler
    {
        private HttpContext context;

        public void ProcessRequest(HttpContext context)
        {
            // Get the file data.
            HttpPostedFile image_upload = context.Request.Files["imgFile"];

            if (image_upload == null || image_upload.ContentLength <= 0)
            {
                context.Response.Clear();
                context.Response.StatusCode = 200;

                context.Response.Write("{error:'上传的文件为空'}");
                context.Response.End();
            }

            else if (image_upload.ContentLength > 2097152)
            {
                context.Response.Clear();
                context.Response.StatusCode = 200;

                context.Response.Write("{error:'上传的文件超过了指定的大小'}");
                context.Response.End();
            }

            string tmpPath = "tmpFile";
            this.context = context;

            //if (EyouSoft.Security.Membership.WebmasterProvider.IsLogin())
            //{
            //    tmpPath = "WebMasterFile";
            //}
            //else
            //{
            //用户登录实现后 加入用户编号
            tmpPath = "UserFile";
            //}

            string fileExt = System.IO.Path.GetExtension(image_upload.FileName);
            if (string.IsNullOrEmpty(fileExt))
            {
                context.Response.Clear();
                context.Response.StatusCode = 200;

                context.Response.Write("{error:'文件格式错误!'}");
                context.Response.End();
            }
            string fileName = Utils.GenerateFileName(fileExt);
            // 允许上传的文件格式
            string[] fileTypeList = new[] { ".xls", ".xlsx", ".rar", ".zip", ".7z", ".pdf", ".doc", ".docx", ".dot", ".swf", ".jpg", ".gif",
                    ".jpeg", ".png", ".bmp" };
            if (!fileTypeList.Contains(fileExt.ToLower()))
            {
                context.Response.Clear();
                context.Response.StatusCode = 200;

                context.Response.Write("{error:'文件格式错误!'}");
                context.Response.End();
            }


            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            //原图完整路径
            string relativePath = "/UploadFiles/" + tmpPath + "/" + year + "/" + month + "/" + fileName;
            //原图文件夹
            string relativeDirPath = "/UploadFiles/" + tmpPath + "/" + year + "/" + month + "/";

            string desFilePath = context.Server.MapPath(relativePath);
            string desDirPath = context.Server.MapPath(relativeDirPath);

            if (!Directory.Exists(desDirPath))
            {
                Directory.CreateDirectory(desDirPath);
            }
            image_upload.SaveAs(desFilePath);
            context.Response.Clear();

            context.Response.StatusCode = 200;

            Hashtable hash = new Hashtable();
            hash["error"] = 0;
            hash["url"] = relativePath;
            context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject((hash)));
            context.Response.End();


        }

        private void showError(string message)
        {
            Hashtable hash = new Hashtable();
            hash["error"] = 1;
            hash["message"] = message;
            context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(hash));
            context.Response.End();
        }



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
