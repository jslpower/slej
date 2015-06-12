using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web.UserControl
{
    public partial class Footer : System.Web.UI.UserControl
    {
        public int isquanxian = 0;
        public string address = "杭州市西湖区文三路569号康新商务大厦17楼1号厅";
        public string Tel = "400-6588-180";
        public string Xuke = "L-ZJ01409";
        public int isfenxiao = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取分销商的website
            string website = HttpContext.Current.Request.Url.Host.ToLower();

            //string website = "8191.slej.cn";
            if (website.IndexOf("slej.cn") > -1 && website.IndexOf("www") < 0)
            {
                isfenxiao = 1;
                GetQX(website);
            }
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
                MMember2 model= new EyouSoft.IDAL.MemberStructure.BMember2().Get(seller.MemberID);
                if (model != null)
                {
                    address = model.Address;
                    Tel = model.Contact;
                }
                if (seller.QuanXian.IndexOf("9") > -1)
                {
                    isquanxian = 0;
                }
                Xuke = seller.XuKeZhengHao;
            }
            else
            {
                Response.Redirect("http://www.slej.cn");
                Response.End();
            }
        }
    }
}