using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using EyouSoft.Common;
using System.Drawing;
using System.IO;
using ThoughtWorks.QRCode.Codec;
using System.Drawing.Drawing2D;
using EyouSoft.Model.MemberStructure.WebModel;
using EyouSoft.IDAL.MemberStructure;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.Web
{
    public partial class GongYingSetDaiLi : System.Web.UI.Page
    {
        MMember2SubmitModel Model = new MMember2SubmitModel();
        BMember2 bll = new BMember2();
        BSellers bsells = new BSellers();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();

        protected string moblieList = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = GetGongYingShangList();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if ((ds.Tables[0].Rows[i]["ContactMobile"]).ToString().Length > 10)
                    {
                        ZhuCe((ds.Tables[0].Rows[i]["ContactMobile"]).ToString(), (ds.Tables[0].Rows[i]["ContactName"]).ToString(), (ds.Tables[0].Rows[i]["SuppPwd"]).ToString());
                        moblieList += (ds.Tables[0].Rows[i]["ContactMobile"]).ToString() + ",";
                    }
                }
            }
        }

        //获取未注册成为会员的供应商列表
        DataSet GetGongYingShangList()
        {
            string connString = @"Data Source=112.124.27.1;Initial Catalog=hzjalydb;User ID=hzja;Password=hzja;Connect Timeout=300000000;";
            SqlConnection con = new SqlConnection(connString);   //连接到引入的数据库
            //connection.Open();  // 打开数据库连接  
            //string source = System.Configuration.ConfigurationSettings.AppSettings["ConnStrSale"].ToString();   
            //con.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnStrSale"].ToString();  //双引号中的最后一个分号可以去掉  
            con.Open();

            StringBuilder strsql = new StringBuilder();
            strsql.Append("SELECT * FROM tbl_Supplier where MemberId IS NULL");
            SqlCommand cmd = new SqlCommand(strsql.ToString(), con);//查询语句
            SqlDataAdapter s = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            s.Fill(ds);
            con.Close();
            return ds;
        }
        void ZhuCe(string shouji, string xingming, string mima)
        {

            var info = new MMember2();
            info.MemberID = Guid.NewGuid().ToString();
            info.RegisterTime = DateTime.Now;
            info.TotalMoney = 0;
            info.Account = shouji;
            info.MemberName = xingming;
            info.MemberState = EyouSoft.Model.Enum.UserStatus.正常;
            info.Mobile = shouji;
            info.PassWord = mima;
            info.ZhiFuPassword = info.PassWord;
            info.UserType = EyouSoft.Model.Enum.MemberTypes.普通会员;

            var zhuCeResult = new EyouSoft.IDAL.MemberStructure.BMember2().Add(info);

            #region 修改
            bool success = false;

            Model.MemberID = info.MemberID;
            MMember2 memmodel = bll.Get(Model.MemberID);
            Model.Account = memmodel.Account;
            var webmstermodel = new BLL.OtherStructure.BWebmaster().GetModel(Model.Account);//后台表
            Model.LoginNum = 0;
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("cardid")))
            {
                Model.CardType = 1;
                Model.CardNo = Utils.GetQueryStringValue("cardid");
            }
            Model.MemberName = memmodel.MemberName;
            Model.MemberState = EyouSoft.Model.Enum.UserStatus.正常;
            Model.Mobile = memmodel.Mobile;
            Model.PassWord = memmodel.PassWord;
            Model.MD5Password = new EyouSoft.Model.CompanyStructure.PassWord(Model.PassWord).MD5Password;
            Model.RegisterTime = DateTime.Now;
            Model.TotalMoney = memmodel.TotalMoney;
            Model.UserType = EyouSoft.Model.Enum.MemberTypes.免费代理;
            Model.ZhiFuPassword = memmodel.ZhiFuPassword;
            Model.ValidDate = DateTime.Now.AddYears(1);

            mseller.QuanXian = "1,2,3,4,5,6,7,8,9";
            mseller.DengJi = Model.UserType;
            mseller.MemberID = Model.MemberID;
            mseller.WebsiteName = "免费代理网站";
            mseller.JinAoWeiXin = "";
            mseller.JinAoTel = "";
            mseller.JinAoQQ = "";
            mseller.JinAoMobile = "";
            mseller.JinAoLXR = "";
            mseller.XuKeZhengHao = "";
            mseller.CompanyContent = "";
            mseller.CompanyJC = "";
            mseller.CompanyName = "";
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("ShopType")))
            {
                mseller.NavNum = (EyouSoft.Model.Enum.NavNum)Utils.GetInt(Utils.GetQueryStringValue("ShopType"));
            }
            else
            {
                mseller.NavNum = NavNum.主站导航;
            }



            mseller.ShowOrHidden = ShowHidden.隐藏;

            string erweimaname = "";
            mseller.Website = Model.Mobile.Substring(Model.Mobile.Length - 4).ToLower() + ".slej.cn";
            erweimaname = Model.Mobile.Substring(Model.Mobile.Length - 4).ToLower();
            EyouSoft.Model.AccountStructure.MSellers mmseller = bll.Existswebsite(mseller.Website.Trim().Replace(" ", ""));
            if (mmseller != null && mmseller.MemberID != mseller.MemberID)
            {
                Random rmd = new Random();
                mseller.Website = rmd.Next(0, 10) + Model.Mobile.Substring(Model.Mobile.Length - 4).ToLower() + ".slej.cn";
                erweimaname = Model.Mobile.Substring(Model.Mobile.Length - 4).ToLower();
            }
            //mseller.ErWeiMaUrl = AddErWeiMa("http://" + mseller.Website.Trim().Replace(" ", ""), erweimaname, Model.Photo);
            mseller.ErWeiMaUrl = "";


            success = bll.Update(Model, mseller);
            if (success)
            {
                #region 修改后台用户表
                EyouSoft.Model.AccountStructure.MSellers succseller = new BSellers().Get(Model.MemberID);
                Model.MWebmaster webmodel = new EyouSoft.Model.MWebmaster();
                webmodel.Fax = Model.Fax;
                webmodel.GysId = succseller.ID;//分销商id
                webmodel.CreateTime = DateTime.Now;
                if (webmstermodel != null)
                {
                    webmodel.Id = webmstermodel.Id;
                    webmodel.CreateTime = webmstermodel.CreateTime;
                }
                webmodel.IsAdmin = 0;
                webmodel.IsEnable = 1;
                webmodel.LeiXing = (int)WebmasterUserType.代理商用户;
                webmodel.MD5Password = Model.MD5Password;
                webmodel.Mobile = Model.Mobile;
                webmodel.Password = Model.PassWord;
                webmodel.Permissions = "104,508";
                webmodel.Realname = Model.MemberName;
                webmodel.Telephone = Model.Contact;
                webmodel.Username = Model.Account;
                webmodel.Fax = Model.qq;
                Save(webmodel);
                #endregion


            }
            #endregion

        }
        private bool Save(Model.MWebmaster webmodel)
        {

            bool r = false;
            var bll = new BLL.OtherStructure.BWebmaster();
            if (webmodel.Id != 0)
            {
                r = bll.Update(webmodel);
            }
            else
            {
                r = bll.Add(webmodel);
            }
            return r;
        }
        public string AddErWeiMa(string context, string account, string TouXiang)
        {
            if (!string.IsNullOrEmpty(TouXiang))
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 8;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                System.Drawing.Image image = qrCodeEncoder.Encode(context);

                System.IO.MemoryStream MStream = new System.IO.MemoryStream();
                image.Save(MStream, System.Drawing.Imaging.ImageFormat.Png);

                Response.ClearContent();

                Response.ContentType = "image/Png";

                Response.BinaryWrite(MStream.ToArray());

                //FileInfo f = new FileInfo(@"d:\zl.png");

                //string erweimaurl = "\\Images\\Erweima\\" + account + ".png";
                string path = Server.MapPath("/Images/Erweima/");
                //Directory.CreateDirectory("\\Images\\Erweima");
                File.Delete(path + account + ".png");
                System.IO.MemoryStream MStream1 = new System.IO.MemoryStream();
                CombinImage(image, Server.MapPath(TouXiang)).Save(MStream1, System.Drawing.Imaging.ImageFormat.Png);
                FileStream fs = new FileStream(path + account + ".png", FileMode.CreateNew, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs, UTF8Encoding.UTF8);
                byte[] by = MStream1.ToArray();
                for (int i = 0; i < MStream1.ToArray().Length; i++)
                    bw.Write(by[i]);
                fs.Close();
                MStream.Dispose();
                MStream1.Dispose();
                return "/Images/Erweima/" + account + ".png";
            }
            else
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();


                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;

                qrCodeEncoder.QRCodeScale = 4;

                qrCodeEncoder.QRCodeVersion = 8;

                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                //String data = "Hello 二维码！";
                String data = context;
                Response.Write(data);

                System.Drawing.Bitmap image = qrCodeEncoder.Encode(data);

                System.IO.MemoryStream MStream = new System.IO.MemoryStream();

                image.Save(MStream, System.Drawing.Imaging.ImageFormat.Png);

                Response.ClearContent();

                Response.ContentType = "image/Png";

                Response.BinaryWrite(MStream.ToArray());

                //FileInfo f = new FileInfo(@"d:\zl.png");

                //string erweimaurl = "\\Images\\Erweima\\" + account + ".png";
                string path = Server.MapPath("/Images/Erweima/");
                //Directory.CreateDirectory("\\Images\\Erweima");
                File.Delete(path + account + ".png");


                FileStream fs = new FileStream(path + account + ".png", FileMode.CreateNew, FileAccess.ReadWrite);

                BinaryWriter bw = new BinaryWriter(fs, UTF8Encoding.UTF8);
                byte[] by = MStream.ToArray();
                for (int i = 0; i < MStream.ToArray().Length; i++)
                    bw.Write(by[i]);
                fs.Close();


                return "/Images/Erweima/" + account + ".png";
            }
        }
        /// <summary>    
        /// 调用此函数后使此两种图片合并，类似相册，有个    
        /// 背景图，中间贴自己的目标图片    
        /// </summary>    
        /// <param name="imgBack">粘贴的源图片</param>    
        /// <param name="destImg">粘贴的目标图片</param>    
        public static Image CombinImage(Image imgBack, string destImg)
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
        public static Image KiResizeImage(Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量    
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
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
