using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;

namespace EyouSoft.Common
{
    public class TuPian
    {
        const string DIRPATH = "/ufiles/";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static byte[] ImgInfo(string url, int width, int height)
        {
            if (string.IsNullOrEmpty(url))
                return null;
            string filename = System.IO.Path.GetFileName(url);
            if (string.IsNullOrEmpty(filename)) return null;
            string filepath = DIRPATH + filename;
            string tofilepath = DIRPATH + System.IO.Path.GetFileNameWithoutExtension(filepath) + "_" + width + "_" + height + System.IO.Path.GetExtension(filepath);
            string destofilepath = HttpContext.Current.Server.MapPath(tofilepath);
            //如果缩略图文件不存在            
            if (!System.IO.File.Exists(destofilepath))
            {
                //下载图片并返回
                tofilepath = F1(url, width, height);
                destofilepath = HttpContext.Current.Server.MapPath(tofilepath);
                return ImgFile(destofilepath);
            }
            else
            {
                return ImgFile(destofilepath);
            }
        }
        /// <summary>
        /// 返回图片信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static byte[] ImgFile(string filePath)
        {
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open);
            byte[] byData = new byte[fs.Length];
            fs.Read(byData, 0, byData.Length);
            fs.Close();
            return byData;
        }
        /// <summary>
        /// 按指定宽高裁剪远程图片，返回文件相对路径
        /// </summary>
        /// <param name="filepath">远程图片路径</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <returns></returns>
        public static string F1(object filepath, int width, int height)
        {
            //string filepath1 = F2(filepath);
            if (filepath != null && !string.IsNullOrEmpty(filepath.ToString()))
            {
                if (filepath.ToString().IndexOf(".com") <= 0 && filepath.ToString().IndexOf(".cn") <= 0 && filepath.ToString().IndexOf("http") < 0)
                {
                    filepath = GetImgFileXml() + filepath;
                }
                return F2(filepath.ToString(), width, height);
            }
            else
            {
                return "/images/NoPic.jpg";
            }
        }
        /// <summary>
        /// 按指定宽高裁剪远程图片，返回文件相对路径
        /// </summary>
        /// <param name="filepath">远程图片路径</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <returns></returns>
        public static string F1(object filepath, int width, int height, string picid)
        {
            //string filepath1 = F2(filepath);
            if (filepath != null && !string.IsNullOrEmpty(filepath.ToString()))
            {
                if (filepath.ToString().IndexOf(".com") <= 0 && filepath.ToString().IndexOf(".cn") <= 0 && filepath.ToString().IndexOf("http") < 0)
                {
                    filepath = GetImgFileXml() + filepath;
                }
                return F2(filepath.ToString(), width, height, picid);
            }
            else
            {
                return "/images/NoPic.jpg";
            }
        }

        /// <summary>
        /// 下载远程图片，返回本地相对路径
        /// </summary>
        /// <param name="url">远程图片路径</param>
        /// <returns></returns>
        static string F2(string url)
        {
            if (string.IsNullOrEmpty(url)) return DIRPATH;
            string filename = System.IO.Path.GetFileName(url);
            if (string.IsNullOrEmpty(filename)) return DIRPATH;

            string filepath = DIRPATH + filename;

            string desfilepath = HttpContext.Current.Server.MapPath(filepath);
            string desdirpath = HttpContext.Current.Server.MapPath(DIRPATH);

            if (!System.IO.File.Exists(desfilepath))
            {
                try
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFile(url, desfilepath);
                    wc.Dispose();
                }
                catch
                {
                    filepath = DIRPATH;
                }
            }

            return filepath;
        }
        /// <summary>
        /// 下载远程图片，返回本地相对路径
        /// </summary>
        /// <param name="url">远程图片路径</param>
        /// <returns></returns>
        static string F2(string url, int width, int height)
        {
            if (string.IsNullOrEmpty(url)) return DIRPATH;
            string filename = System.IO.Path.GetFileName(url);
            if (string.IsNullOrEmpty(filename)) return DIRPATH;

            string filepath = DIRPATH + filename;
            string tofilepath = DIRPATH + System.IO.Path.GetFileNameWithoutExtension(filepath) + "_" + width + "_" + height + System.IO.Path.GetExtension(filepath);
            string destofilepath = HttpContext.Current.Server.MapPath(tofilepath);
            //如果缩略图文件不存在            
            if (System.IO.File.Exists(destofilepath))
            {
                return tofilepath;
            }
            else
            {

                string desfilepath = HttpContext.Current.Server.MapPath(filepath);
                string desdirpath = HttpContext.Current.Server.MapPath(DIRPATH);
                if (!System.IO.Directory.Exists(desdirpath))
                {
                    System.IO.Directory.CreateDirectory(desdirpath);
                }
                if (!System.IO.File.Exists(desfilepath))
                {
                    try
                    {
                        WebClient wc = new WebClient();
                        wc.DownloadFile(url, desfilepath);
                        wc.Dispose();
                    }
                    catch
                    {
                        filepath = "/images/NoPic.jpg";
                    }
                }

                return F3(filepath, width, height);
            }
        }
        /// <summary>
        /// 下载远程图片，返回本地相对路径
        /// </summary>
        /// <param name="url">远程图片路径</param>
        /// <returns></returns>
        static string F2(string url, int width, int height, string picid)
        {
            if (string.IsNullOrEmpty(url)) return DIRPATH;
            string filename = picid + System.IO.Path.GetFileName(url);
            if (string.IsNullOrEmpty(filename)) return DIRPATH;

            string filepath = DIRPATH + filename;
            string tofilepath = DIRPATH + picid + System.IO.Path.GetFileNameWithoutExtension(filepath) + "_" + width + "_" + height + System.IO.Path.GetExtension(filepath);
            string destofilepath = HttpContext.Current.Server.MapPath(tofilepath);
            //如果缩略图文件不存在            
            if (System.IO.File.Exists(destofilepath))
            {
                return tofilepath;
            }
            else
            {

                string desfilepath = HttpContext.Current.Server.MapPath(filepath);
                string desdirpath = HttpContext.Current.Server.MapPath(DIRPATH);
                if (!System.IO.Directory.Exists(desdirpath))
                {
                    System.IO.Directory.CreateDirectory(desdirpath);
                }
                if (!System.IO.File.Exists(desfilepath))
                {
                    try
                    {
                        WebClient wc = new WebClient();
                        wc.DownloadFile(url, desfilepath);
                        wc.Dispose();
                    }
                    catch
                    {
                        filepath = "/images/NoPic.jpg";
                    }
                }

                return F3(filepath, width, height, picid);
            }
        }
        /// <summary>
        /// 裁剪图片，返回裁剪后的文件路径
        /// </summary>
        /// <param name="filepath">文件相对路径</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        static string F3(string filepath, int width, int height)
        {
            if (string.IsNullOrEmpty(filepath)) return DIRPATH;

            string filename = System.IO.Path.GetFileName(filepath);
            if (string.IsNullOrEmpty(filename)) return DIRPATH;

            string desfilepath = HttpContext.Current.Server.MapPath(filepath);
            if (!System.IO.File.Exists(desfilepath)) return DIRPATH;

            string tofilepath = DIRPATH + System.IO.Path.GetFileNameWithoutExtension(filepath) + "_" + width + "_" + height + System.IO.Path.GetExtension(filepath);

            string destofilepath = HttpContext.Current.Server.MapPath(tofilepath);

            if (System.IO.File.Exists(destofilepath)) return tofilepath;

            Image img = null;

            try
            {
                img = System.Drawing.Image.FromFile(desfilepath);
            }
            catch { }

            if (img == null) return DIRPATH;

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = img.Width;
            int oh = img.Height;

            if (img.Width == width && img.Height == height)
            {
                return filepath;
            }

            if ((double)img.Width / (double)img.Height > (double)towidth / (double)toheight)
            {
                oh = img.Height;
                ow = img.Height * towidth / toheight;
                y = 0;
                x = (img.Width - ow) / 2;
            }
            else
            {
                ow = img.Width;
                oh = img.Width * height / towidth;
                x = 0;
                y = (img.Height - oh) / 2;
            }

            //新建一个bmp图片
            Bitmap bitmap = new System.Drawing.Bitmap(towidth, toheight, PixelFormat.Format24bppRgb);
            //设置分辨率
            bitmap.SetResolution(img.HorizontalResolution, img.VerticalResolution);
            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度 消除锯齿
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            //g.DrawImage(img, new Rectangle(0, 0, towidth, toheight),
            //    new Rectangle(x, y, ow, oh),
            //    GraphicsUnit.Pixel);
            Rectangle rect = new Rectangle(0, 0, towidth, toheight);
            g.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
            //#region 水印
            ////获得水印图像
            //Image markImg = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("/images/WaterMark.png")); ;
            ////创建颜色矩阵
            //float[][] ptsArray ={
            //                                                      new float[] {1, 0, 0, 0, 0},
            //                                                      new float[] {0, 1, 0, 0, 0},
            //                                                      new float[] {0, 0, 1, 0, 0},
            //                                                      new float[] {0, 0, 0, 0.2f, 0}, //注意：此处为0.0f为完全透明，1.0f为完全不透明
            //                                                      new float[] {0, 0, 0, 0, 1}};
            //ColorMatrix colorMatrix = new ColorMatrix(ptsArray);
            ////新建一个Image属性
            //ImageAttributes imageAttributes = new ImageAttributes();
            ////将颜色矩阵添加到属性
            //imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default,
            //      ColorAdjustType.Default);
            ////如果原图过小
            //if (markImg.Width > towidth || markImg.Height > toheight)
            //{
            //    int newimgWidth = towidth / 4;
            //    int newimgHeight = markImg.Height * towidth / markImg.Width / 4;
            //    System.Drawing.Image.GetThumbnailImageAbort callb = null;
            //    //对水印图片生成缩略图,缩小到原图得1/4
            //    System.Drawing.Image new_img = markImg.GetThumbnailImage(newimgWidth, newimgHeight, callb, new System.IntPtr());
            //    //添加水印
            //    g.DrawImage(new_img, new Rectangle(10, toheight - newimgHeight - 10, new_img.Width, new_img.Height), 0, 0, new_img.Width, new_img.Height, GraphicsUnit.Pixel, imageAttributes);
            //    //释放缩略图
            //    new_img.Dispose();
            //    //释放Graphics
            //    g.Dispose();
            //}
            ////原图足够大
            //else
            //{
            //    //添加水印
            //    g.DrawImage(markImg, new Rectangle(10, toheight - markImg.Height - 10, markImg.Width, markImg.Height), 0, 0, markImg.Width, markImg.Height, GraphicsUnit.Pixel, imageAttributes);
            //    //释放Graphics
            //    g.Dispose();
            //} 
            //#endregion

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(destofilepath, ImageFormat.Jpeg);
            }
            catch
            {
                tofilepath = DIRPATH;
            }
            finally
            {
                img.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }

            return tofilepath;
        }
        /// <summary>
        /// 裁剪图片，返回裁剪后的文件路径
        /// </summary>
        /// <param name="filepath">文件相对路径</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        static string F3(string filepath, int width, int height, string picid)
        {
            if (string.IsNullOrEmpty(filepath)) return DIRPATH;

            string filename = System.IO.Path.GetFileName(filepath);
            if (string.IsNullOrEmpty(filename)) return DIRPATH;

            string desfilepath = HttpContext.Current.Server.MapPath(filepath);
            if (!System.IO.File.Exists(desfilepath)) return DIRPATH;

            string tofilepath = DIRPATH + picid + System.IO.Path.GetFileNameWithoutExtension(filepath) + "_" + width + "_" + height + System.IO.Path.GetExtension(filepath);

            string destofilepath = HttpContext.Current.Server.MapPath(tofilepath);

            if (System.IO.File.Exists(destofilepath)) return tofilepath;

            Image img = null;

            try
            {
                img = System.Drawing.Image.FromFile(desfilepath);
            }
            catch { }

            if (img == null) return DIRPATH;

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = img.Width;
            int oh = img.Height;

            if (img.Width == width && img.Height == height)
            {
                return filepath;
            }

            if ((double)img.Width / (double)img.Height > (double)towidth / (double)toheight)
            {
                oh = img.Height;
                ow = img.Height * towidth / toheight;
                y = 0;
                x = (img.Width - ow) / 2;
            }
            else
            {
                ow = img.Width;
                oh = img.Width * height / towidth;
                x = 0;
                y = (img.Height - oh) / 2;
            }

            //新建一个bmp图片
            Bitmap bitmap = new System.Drawing.Bitmap(towidth, toheight, PixelFormat.Format24bppRgb);
            //设置分辨率
            bitmap.SetResolution(img.HorizontalResolution, img.VerticalResolution);
            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度 消除锯齿
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            //g.DrawImage(img, new Rectangle(0, 0, towidth, toheight),
            //    new Rectangle(x, y, ow, oh),
            //    GraphicsUnit.Pixel);
            Rectangle rect = new Rectangle(0, 0, towidth, toheight);
            g.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
            //#region 水印
            ////获得水印图像
            //Image markImg = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("/images/WaterMark.png")); ;
            ////创建颜色矩阵
            //float[][] ptsArray ={
            //                                                      new float[] {1, 0, 0, 0, 0},
            //                                                      new float[] {0, 1, 0, 0, 0},
            //                                                      new float[] {0, 0, 1, 0, 0},
            //                                                      new float[] {0, 0, 0, 0.2f, 0}, //注意：此处为0.0f为完全透明，1.0f为完全不透明
            //                                                      new float[] {0, 0, 0, 0, 1}};
            //ColorMatrix colorMatrix = new ColorMatrix(ptsArray);
            ////新建一个Image属性
            //ImageAttributes imageAttributes = new ImageAttributes();
            ////将颜色矩阵添加到属性
            //imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default,
            //      ColorAdjustType.Default);
            ////如果原图过小
            //if (markImg.Width > towidth || markImg.Height > toheight)
            //{
            //    int newimgWidth = towidth / 4;
            //    int newimgHeight = markImg.Height * towidth / markImg.Width / 4;
            //    System.Drawing.Image.GetThumbnailImageAbort callb = null;
            //    //对水印图片生成缩略图,缩小到原图得1/4
            //    System.Drawing.Image new_img = markImg.GetThumbnailImage(newimgWidth, newimgHeight, callb, new System.IntPtr());
            //    //添加水印
            //    g.DrawImage(new_img, new Rectangle(10, toheight - newimgHeight - 10, new_img.Width, new_img.Height), 0, 0, new_img.Width, new_img.Height, GraphicsUnit.Pixel, imageAttributes);
            //    //释放缩略图
            //    new_img.Dispose();
            //    //释放Graphics
            //    g.Dispose();
            //}
            ////原图足够大
            //else
            //{
            //    //添加水印
            //    g.DrawImage(markImg, new Rectangle(10, toheight - markImg.Height - 10, markImg.Width, markImg.Height), 0, 0, markImg.Width, markImg.Height, GraphicsUnit.Pixel, imageAttributes);
            //    //释放Graphics
            //    g.Dispose();
            //} 
            //#endregion

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(destofilepath, ImageFormat.Jpeg);
            }
            catch
            {
                tofilepath = DIRPATH;
            }
            finally
            {
                img.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }

            return tofilepath;
        }
        /// <summary>
        /// 从配置文件中获取图片路径
        /// </summary>
        /// <returns>Google Map Key</returns>
        public static string GetImgFileXml()
        {
            return GetConfigString("appSettings", "ImgFile");
        }
        /// <summary>
        /// 取得配置文件中的字符串KEY
        /// </summary>
        /// <param name="sectionName">节点名称</param>
        /// <param name="key">KEY名</param>
        /// <returns>返回KEY值</returns>
        public static string GetConfigString(string sectionName, string key)
        {
            if (string.IsNullOrEmpty(sectionName))
            {
                var cfgName = (System.Collections.Specialized.NameValueCollection)System.Configuration.ConfigurationManager.GetSection("appSettings");
                if (cfgName[key] == null || cfgName[key] == "")
                {
                    //throw (new System.Exception("在Web.config文件中未发现配置项: \"" + key.ToString() + "\""));
                    return "";
                }
                else
                {
                    return cfgName[key];
                }
            }
            else
            {
                var cfgName = (System.Collections.Specialized.NameValueCollection)System.Configuration.ConfigurationManager.GetSection(sectionName);
                if (cfgName[key] == null || cfgName[key] == "")
                {
                    //throw (new System.Exception("在Web.config文件中未发现配置项: \"" + key.ToString() + "\""));
                    return "";
                }
                else
                {
                    return cfgName[key];
                }
            }
        }
    }
}
