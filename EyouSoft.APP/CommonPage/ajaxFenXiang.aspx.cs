using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.WeiXin;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Common;

namespace EyouSoft.WAP.CommonPage
{
    public partial class ajaxFenXiang : System.Web.UI.Page
    {
        protected int pageindex = 1, pagesize = 8, recordCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("isGet") == "1") BindInte();
        }
        /// <summary>
        /// 绑定数据行
        /// </summary>
        void BindInte()
        {
            pageindex = UtilsCommons.GetPagingIndex();
            string sellerid = string.Empty;
            string url = HttpContext.Current.Request.Url.Host.Replace("m.", "");
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
            seller = bsells.GetMSellersByWebSite(url);
            if (seller != null) sellerid = seller.MemberID;

            MYouJiSer YouJiS = new MYouJiSer();
            YouJiS.HuiYuanId = sellerid;
            YouJiS.XianShiGuanLi = true;
            var list = new BYouJi().GetList(pagesize, pageindex, ref recordCount, YouJiS);
            int isPage = 0;
            if (recordCount % pagesize != 0)
            {
                isPage = recordCount / pagesize + 1;
            }
            else
            {
                isPage = recordCount / pagesize;
            }
            if (list != null && list.Count > 0)
            {

                if (isPage >= pageindex)
                {
                    rptlist.DataSource = list;
                    rptlist.DataBind();
                }

            }

        }

    }
}
