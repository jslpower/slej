using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model;
using EyouSoft.Model.Enum;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.WAP
{
    public partial class Hotel : System.Web.UI.Page
    {
        protected string toplist = string.Empty;
        protected string dianlist = string.Empty;//确认个数
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "酒店预订";
            InitAd();
            getHtmlStr();

            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }
        /// <summary>
        /// 绑定页面广告
        /// </summary>
        private void InitAd()
        {
            EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv();
            //首页轮播图
            List<MSysAdv> imgList = new List<MSysAdv>(bll.GetList(5, AdvArea.酒店首页轮换广告));
            FenXiangBiaoTi = "酒店预订";
            FenXiangMiaoShu = "酒店预订";
            if (imgList != null && imgList.Count > 0)
            {
                FenXiangTuPianFilepath = "http://" + Request.Url.Host + TuPian.F1(imgList[0].ImgPath, 640, 200);
            }
            FenXiangLianJie = Utils.redirectUrl(HttpContext.Current.Request.Url.ToString());

            #region 图片处理
            List<string> files = new List<string>();
            List<string> hrefs = new List<string>();
            if (imgList != null && imgList.Count > 0)
            {
                foreach (var item in imgList)
                {
                    files.Add(TuPian.F1(item.ImgPath, 640, 200));
                    hrefs.Add(item.AdvLink);
                }

            }
            ScrollImg1.ImgUrl = files;
            ScrollImg1.HrefUrl = hrefs;
            ScrollImg1.ImgGth = 200;
            ScrollImg1.ImgWid = 640;
            #endregion
        }
        /// <summary>
        /// 获取最近六个月的日期
        /// </summary>
        void getHtmlStr()
        {
            StringBuilder strMonthHtml = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                DateTime dt = DateTime.Now.AddMonths(i);
                if (i == 0)
                {
                    strMonthHtml.Append("<div class=\"riqi_box\">");
                }
                else
                {
                    strMonthHtml.Append("<div class=\"riqi_box mt10\">");
                }
                strMonthHtml.AppendFormat("<div class=\"riqi_month\">{0}</div>", dt.ToString("yyyy年MM月"));
                strMonthHtml.Append("<div class=\"riqi_week\">");
                strMonthHtml.Append("<ul>");
                strMonthHtml.Append("<li>日</li>");
                strMonthHtml.Append("<li>一</li>");
                strMonthHtml.Append("<li>二</li>");
                strMonthHtml.Append("<li>三</li>");
                strMonthHtml.Append("<li>四</li>");
                strMonthHtml.Append("<li>五</li>");
                strMonthHtml.Append("<li>六</li>");
                strMonthHtml.Append("</ul>");
                strMonthHtml.Append("</div>");
                strMonthHtml.Append("<div class=\"riqi_day\">");
                strMonthHtml.Append("<ul class=\"clearfix\">");

                int days = DateTime.DaysInMonth(dt.Year, dt.Month);
                int firstLi = (int)Utils.GetDateTime(string.Format("{0}-{1}-{2}", dt.Year, dt.Month, 1)).DayOfWeek;
                for (int j = 0; j < firstLi; j++)
                {
                    strMonthHtml.Append("<li></li>");//补全空白
                }
                for (int m = 1; m <= days; m++)
                {
                    strMonthHtml.Append(getMonthStr(string.Format("{0}-{1}-{2}", dt.Year, dt.Month, m)));
                }
                strMonthHtml.Append("</ul></div></div>");
            }
            litMonth.Text = strMonthHtml.ToString();
        }
        /// <summary>
        /// 返回表格样式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        string getMonthStr(string dataStr)
        {
            DateTime dt = Utils.GetDateTime(dataStr);
            if (dt < DateTime.Now)
            {
                return string.Format("<li da class=\"riqi_day_pass\" >{0}</li>", dt.Day);
            }
            else
            {
                return string.Format("<li class=\"riqi_day_select\" data-date=\"{1}\" data-week=\"{2}\">{0}</li>", dt.Day, dt.ToString("yyyy-MM-dd"), dt.DayOfWeek);
            }
        }
    }
}
