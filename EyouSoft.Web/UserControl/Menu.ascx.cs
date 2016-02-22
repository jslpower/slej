using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model;
using EyouSoft.BLL.OtherStructure;

namespace EyouSoft.Web.UserControl
{
    public partial class Menu : System.Web.UI.UserControl
    {
        /// <summary>
        /// 主站高亮显示的头部索引值 (首页 = 0，依次+1)
        /// </summary>
        public int HeadMenuIndex { get; set; }
        /// <summary>
        /// 代理高亮显示的头部索引值 (首页 = 0，依次+1)
        /// </summary>
        public int DaiLiMenuIndex { get; set; }
        public string urllist = "";
        public int isfenxiao = 0;//是否是分销商网站
        public string tel = "/images/tel.gif";
        protected string[] menPiaoLinks;
        public string uqq = "";
        public string slqq = "";
        public string utel = "";
        public string img1 = "";
        public string img2 = "";
        public string slweixin = "";
        public string uweixin = "";
        public string slname = "";
        public string companyName = "";
        public int isquanxian = 0;
        public string website = "";
        public string Logourl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //获取分销商的website
            website = HttpContext.Current.Request.Url.Host.ToLower();
          
            //string website = "8191.slej.cn";
            if (website.IndexOf("slej.cn") > -1 && website.IndexOf("www") < 0)
            {
               
                GetQX(website);
                isfenxiao = 1;
            }
            BKV kv = new BKV();
            menPiaoLinks = kv.GetMenPiaoLinks().Split(' ');
        }
     
        /// <summary>
        /// 根据分销商的website获取分销商权限
        /// </summary>
        /// <param name="website"></param>
        public void GetQX(string website)
        {
            isquanxian = 1;
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
            seller = bsells.GetMSellersByWebSite(website);
            if (seller != null)
            {
                if(!string.IsNullOrEmpty(seller.WebLogo))
                    Logourl = "<img src=\"" + seller.WebLogo + "\">";
                if (seller.NavNum == EyouSoft.Model.Enum.NavNum.代理商导航)
                {
                    MainNav.Visible = false;
                    DaiLiNav.Visible = true;
                }
                companyName = seller.CompanyName;
                MMember2 model= new EyouSoft.IDAL.MemberStructure.BMember2().Get(seller.MemberID);
                if (model != null)
                {
                    UName.Text = model.MemberName;
                    if (UName.Text.Length == 2)
                    {
                        UName.Text = model.MemberName + "&nbsp;&nbsp;&nbsp;&nbsp;";
                    }
                    utel = model.Contact;
                    UMoblie.Text = model.Mobile;
                    uweixin = model.WeiXin;
                    Label2.Text = model.WeiXin;
                    img1 = model.Photo;
                    img2 = seller.JinAoPhoto;
                    //UWebName.Text = seller.WebsiteName;
                    uqq = model.qq.Trim();
                    slqq = seller.JinAoQQ.Trim();
                    //SLName.Text = seller.JinAoLXR;
                    slname = seller.JinAoLXR;
                    SLMoblie.Text = seller.JinAoMobile;
                    SLTel.Text = seller.JinAoTel;
                    slweixin = seller.JinAoWeiXin;
                    Label1.Text = seller.JinAoWeiXin;
                }
                if (seller.QuanXian.IndexOf("9") > -1)
                {
                    isquanxian = 0;
                }
                //tel = "/images/tel1.gif";
                //string[] quan = seller.QuanXian.Split(',');
                //for (int i = 0; i < quan.Length; i++)
                //{
                //    switch (quan[i])
                //    {
                //        case "0":
                //            urllist += "<li class='line'></li><li><a data-index='12' href='/XianLu.aspx?type=" + (int)EyouSoft.Model.Enum.AreaType.周边短线 + "'>周边短线</a></li>";
                //            break;
                //        case "1":
                //            urllist += "<li class='line'></li><li><a data-index='2' href='/XianLu.aspx?type=" + (int)EyouSoft.Model.Enum.AreaType.国内长线 + "'>国内长线</a></li>";
                //            break;
                //        case "2":
                //            urllist += "<li class='line'></li><li><a data-index='3' href='/XianLu.aspx?type=" + (int)EyouSoft.Model.Enum.AreaType.出境线路 + "'>国际线路</a></li>";
                //            break;
                //        case "3":
                //            urllist += "<li class='line'></li><li><a data-index='4' href='/QianZheng.aspx'>出国签证</a></li>";
                //            break;
                //        case "4":
                //            urllist += "<li class='line'></li><li><a data-index='5' href='/JiPiao.aspx'>机票预定</a></li>";
                //            break;
                //        case "5":
                //            urllist += "<li class='line'></li><li><a data-index='6' href='/YouHuiMenPiao.aspx'>优惠门票</a></li>";
                //            break;
                //        case "6":
                //            urllist += "<li class='line'></li><li><a data-index='7' href='/Hotel.aspx'>酒店预定</a></li>";
                //            break;
                //        case "7":
                //            urllist += "<li class='line'></li><li><a data-index='8' href='/ZuChe.aspx'>汽车包租</a></li>";
                //            break;
                //        case "8":
                //            urllist += "<li class='line'></li><li><a data-index='9' href='/ShangCheng.aspx'>会员商城</a></li>";
                //            break;
                //    }



                //}
            }
            else
            {
                Response.Redirect("http://www.slej.cn");
                Response.End();
            }
        }



    }
}