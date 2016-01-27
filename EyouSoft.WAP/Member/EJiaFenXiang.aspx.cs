using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.WeiXin;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Common;

namespace EyouSoft.WAP.Member
{
    public partial class EJiaFenXiang : System.Web.UI.Page
    {
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            BindInte();
            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }
        /// <summary>
        /// 绑定数据行
        /// </summary>
        void BindInte()
        {
            string sellerid = string.Empty;
            string url = HttpContext.Current.Request.Url.Host.Replace("m.", "");
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
            seller = bsells.GetMSellersByWebSite(url);
            if (seller != null) sellerid = seller.MemberID;

            MYouJiSer YouJiS = new MYouJiSer();
            YouJiS.HuiYuanId = sellerid;
            YouJiS.XianShiGuanLi = true;
            //YouJiS.YouJiType = YouJiLeiXing.图文游记;
            int count = 0;
            var list = new BYouJi().GetList(8, 1, ref count, YouJiS);
            if (list != null && list.Count > 0)
            {
                rptlist.DataSource = list;
                rptlist.DataBind();
            }
            else
            {
                ltrNoMsg.Visible = true;
                PlaceHolder1.Visible = false;
            }
            FenXiangTuPianFilepath = "http://" + Request.Url.Host + "/images/2.jpg";
            FenXiangLianJie =  Utils.redirectUrl(HttpContext.Current.Request.Url.ToString());
        }
    }
}
