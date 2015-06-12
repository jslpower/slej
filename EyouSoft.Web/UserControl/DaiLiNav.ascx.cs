using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web.UserControl
{
    public partial class DaiLiNav : System.Web.UI.UserControl
    {
        /// <summary>
        /// 高亮显示的头部索引值 (首页 = 0，依次+1)
        /// </summary>
        public int HeadMenuIndex { get; set; }
        public int isfenxiao = 0;//是否是分销商网站
        public int isquanxian = 1;
        public string website = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            website = HttpContext.Current.Request.Url.Host.ToLower();

            //string website = "8191.slej.cn";
            if (website.IndexOf("slej.cn") > -1 && website.IndexOf("www") < 0)
            {
                EyouSoft.Model.AccountStructure.MSellers seller = new BSellers().GetMSellersByWebSite(website);
                if (seller != null)
                {
                    if (seller.QuanXian.IndexOf("9") > 0)
                    {
                        isquanxian = 0;
                    }
                    if (!string.IsNullOrEmpty(seller.CompanyName))
                    {
                        isfenxiao = 1;
                    }
                }
            }
        }
    }
}