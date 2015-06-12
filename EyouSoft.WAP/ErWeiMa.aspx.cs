using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using EyouSoft.Common.Page;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web
{
    public partial class ErWeiMa : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string uTouXiang = "";
            string url = EyouSoft.Common.Utils.GetQueryStringValue("codeurl");
            if (isfenxiao)
            {
                string website = HttpContext.Current.Request.Url.Host.ToLower().Replace("m.", "");
                //string website = "m.1234.slej.cn".Replace("m.", "");
                BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
            seller = bsells.GetMSellersByWebSite(website);
            if (seller != null)
            {
                MMember2 model = new EyouSoft.IDAL.MemberStructure.BMember2().Get(seller.MemberID);
                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.Photo))
                    {
                        uTouXiang = EyouSoft.Common.TuPian.F1(model.Photo, 31, 31);
                    }
                }
            }
                
            }
            GetDimensionalCode(url,uTouXiang);
        }
        /// <summary>
        /// 根据链接获取二维码
        /// </summary>
        /// <param name="link">链接</param>
        /// <returns>返回二维码图片</returns>
        private void GetDimensionalCode(string link,string uTouXiang)
        {
            Bitmap bmp = null;
            try
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 4;
                //int version = Convert.ToInt16(cboVersion.Text);
                qrCodeEncoder.QRCodeVersion = 7;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                bmp = qrCodeEncoder.Encode(link);
            }
            catch
            {

            }
            if (!string.IsNullOrEmpty(uTouXiang))
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                System.IO.MemoryStream MStream1 = new System.IO.MemoryStream();
                CombinImage(bmp, Server.MapPath(uTouXiang)).Save(MStream1, System.Drawing.Imaging.ImageFormat.Bmp);
                Response.ContentType = "image/bmp";
                MStream1.WriteTo(Response.OutputStream);
                MStream1.Close();
                ms.Close();
            }
            else
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                Response.ContentType = "image/bmp";
                ms.WriteTo(Response.OutputStream);
                ms.Close();
            }
        }
        /// <summary>    
        /// 调用此函数后使此两种图片合并，类似相册，有个    
        /// 背景图，中间贴自己的目标图片    
        /// </summary>    
        /// <param name="imgBack">粘贴的源图片</param>    
        /// <param name="destImg">粘贴的目标图片</param>    
        public Image CombinImage(Image imgBack, string destImg)
        {
            Image img = Image.FromFile(destImg);        //照片图片      
            if (img.Height != 42 || img.Width != 42)
            {
                img = KiResizeImage(img, 42, 42, 0);
            }

            if (imgBack.Height != 145 || imgBack.Width != 145)
            {
                imgBack = KiResizeImage(imgBack, 145, 145, 0);
            }

            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, 145, 145);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);     

            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框    

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);    

            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
            GC.Collect();
            return imgBack;
        }


        /// <summary>    
        /// Resize图片    
        /// </summary>    
        /// <param name="bmp">原始Bitmap</param>    
        /// <param name="newW">新的宽度</param>    
        /// <param name="newH">新的高度</param>    
        /// <param name="Mode">保留着，暂时未用</param>    
        /// <returns>处理以后的图片</returns>    
        public Image KiResizeImage(Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量    
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }
    }
}
