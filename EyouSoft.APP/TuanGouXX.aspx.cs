using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.WAP
{
    public partial class TuanGouXX : System.Web.UI.Page
    {
        public int TotalSeconds = 0;
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.isfx = true;
            WapHeader1.HeadText = "团购详情";
            if (!IsPostBack)
            {
                initPage();
            }
            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }
        void initPage()
        {
            int id = Utils.GetInt(Utils.GetQueryStringValue("id"));
            var model = new EyouSoft.BLL.OtherStructure.BTuanGou().GetModel(id);
            if (model != null)
            {
                //CxType = ((int)model.SaleType).ToString();
                //CpType = ((int)model.ProductType).ToString();
                int count = model.Salevolume;
                if (count == 0)
                {
                    goumaishu.Text = "还未有人购买";
                }
                else
                {
                    goumaishu.Text = "<b class='fontred font16'>" + count + "</b> 人已购买";
                }
                int shengyuNum = model.ProductNum - model.Salevolume;//剩余数量
                shengyushu.Text = shengyuNum.ToString();
                ProductName.Text = model.ProductName;
                if (Convert.ToDateTime(model.ValiDate).AddDays(1) > DateTime.Now)
                {
                    TotalSeconds = Convert.ToInt32((Convert.ToDateTime(model.ValiDate).AddDays(1) - DateTime.Now).TotalSeconds);
                    if (shengyuNum > 0)
                    {
                        ydbtn.Text = "<a href='javascript:void(0);' id='QGbtn' class='yudin_btn'>立即抢</a>";
                    }
                    else
                    {
                        ydbtn.Text = "<span class='yudin_graybtn'>已结束</span>";
                    }
                }
                else
                {
                    ydbtn.Text = "<span class='yudin_graybtn'>已结束</span>";
                }
                jianjie.Text = model.SimpleInfo;
                yuanjia.Text = Convert.ToInt32(model.MarketPrice).ToString();
                qianggoujia.Text = Convert.ToInt32(model.GroupPrice).ToString();
                jieshao.Text = model.DetailInfo;
                if (!string.IsNullOrEmpty(model.ProductImg)) ProductImg.Text = "<img src='" + TuPian.F1(model.ProductImg, 640, 400) + "' />";
                WapHeader1.FenXiangBiaoTi = model.ProductName.Trim();
                WapHeader1.FenXiangMiaoShu = Utils.GetText2(model.SimpleInfo, 30, true).Trim();
                WapHeader1.FenXiangTuPianFilepath = "http://" + Request.Url.Host + TuPian.F1(model.ProductImg, 100, 35);
                WapHeader1.FenXiangLianJie = Utils.redirectUrl(HttpContext.Current.Request.Url.ToString());
            }


        }
    }
}
