using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.MallStructure;
using EyouSoft.IDAL.AccountStructure;
namespace EyouSoft.WAP.Mall
{
    public partial class ShangChengLianMeng : System.Web.UI.Page
    {

        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 1000;
        protected string toplist = string.Empty;
        protected string dianlist = string.Empty;//确认个数
        #endregion
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = "购物广场联盟"
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = "http://" + HttpContext.Current.Request.Url.Host + "/images/mall_img001.gif"
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            InitAd();
            initPage();
            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void initPage()
        {

            var serchModel = new EyouSoft.Model.MallStructure.MLianMengSer();
            pageIndex = UtilsCommons.GetPagingIndex();
            string cName = Utils.GetQueryStringValue("cName");
            int leibie = Utils.GetInt(Utils.GetQueryStringValue("lid"));
            serchModel.LeiBieMingCheng = cName;
            serchModel.LieBieID = Utils.GetIntNull(leibie.ToString());
            serchModel.modelTp = EyouSoft.Model.Enum.ModelTypes.购物广场联盟;
            IList<MLianMeng> list = new EyouSoft.BLL.MallStructure.BLianMeng().GetList(pageSize, pageIndex, ref recordCount, serchModel);


            if (list != null && list.Count > 0)
            {
                #region 设置微信分享链接
                //设置图片链接
                FenXiangTuPianFilepath = "http://" + Request.Url.Host + retuImgUrl(list[0].ImgFile);
                FenXiangBiaoTi = string.IsNullOrEmpty(cName) ? "购物广场联盟" : string.Format("{0}-{1}-购物广场联盟", cName, list[0].LeiBieMingCheng);

                if (leibie != 0)
                {
                    var leibieModel = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetModel(leibie);
                    if (leibieModel != null)
                    {

                        FenXiangBiaoTi =   string.Format("{0}-购物广场联盟", leibieModel.TypeName);
                    }
                }
                FenXiangMiaoShu = Utils.InputText(list[0].KeyWord);
                #endregion
                rptlist.DataSource = list;
                rptlist.DataBind();

            }

            int itemCount = 0;
            FenXiangLianJie =  Utils.redirectUrl(HttpContext.Current.Request.Url.ToString());
        }

        /// 绑定页面广告
        /// </summary>
        private void InitAd()
        {
            EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv();
            //首页轮播图
            var top = bll.GetList(5, EyouSoft.Model.Enum.AdvArea.购物广场联盟);
            #region 图片处理

            List<string> files = new List<string>();
            List<string> hrefs = new List<string>();
            if (top != null && top.Count > 0)
            {
                foreach (var item in top)
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
        /// 返回图片路径
        /// </summary>
        /// <param name="imgs"></param>
        /// <returns></returns>
        protected string retuImgUrl(object imgURL)
        {
            string img = imgURL.ToString(); ;
            if (!string.IsNullOrEmpty(img)) return TuPian.F1(img, 640, 200);
            return "/images/mall_img001.gif";
        }

    }
}
