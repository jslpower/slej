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
    public partial class Default : Common.Page.WebPageBase
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 10000;
        protected string toplist = string.Empty;
        protected string dianlist = string.Empty;//确认个数
        #endregion
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = "e家商城"
                                    , FenXiangMiaoShu = "e家商城"
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.isfx = true;
            initPage();
            InitAd();

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

            string cName = Utils.GetQueryStringValue("cName");
            int leibie = Utils.GetInt(Utils.GetQueryStringValue("lid"));
            pageIndex = UtilsCommons.GetPagingIndex();

            string website = HttpContext.Current.Request.Url.Host.ToLower().Replace("m.", "");
            //string website ="m.6479.slej.cn".ToLower().Replace("m.", "");
            string DaiLiId = "";
            IList<MShangChengShangPin> list = new List<MShangChengShangPin>();
            if (website.IndexOf("slej.cn") > -1 && website.IndexOf("www") < 0)
            {

                BSellers bsells = new BSellers();
                var Daimodel = bsells.GetMSellersByWebSite(website);
                if (Daimodel != null) DaiLiId = Daimodel.ID;
                string sqlwhere = DaiLiId;
                if (Daimodel != null && Daimodel.NavNum == EyouSoft.Model.Enum.NavNum.代理商导航)
                {


                    list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetDaiLiList(pageSize, pageIndex, ref recordCount, new MDaiLiShangChanPinSer() { isGetTrue = true, ProductName = Utils.GetQueryStringValue("cName"), TypeID = Utils.GetInt(Utils.GetQueryStringValue("lid")), ProductStatus = new[] { EyouSoft.Model.Enum.ProductZT.首页推荐 }, MemberId = DaiLiId });
                    #region 设置微信分享链接
                    //设置图片链接
                    if (list.Count > 0)
                    {
                        WapHeader1.FenXiangTuPianFilepath = FenXiangTuPianFilepath = "http://" + Request.Url.Host + retuImgUrl(list[0].ProductImgs);
                        WapHeader1.FenXiangBiaoTi = FenXiangBiaoTi = string.IsNullOrEmpty(cName) ? "e家商城" : string.Format("{0}-{1}-e家商城", cName, list[0].TypeName);

                        if (leibie != 0)
                        {
                            var leibieModel = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetModel(leibie);
                            if (leibieModel != null)
                            {

                                WapHeader1.FenXiangBiaoTi = FenXiangBiaoTi = string.Format("{0}-e家商城", leibieModel.TypeName);
                            }
                        }
                        WapHeader1.FenXiangMiaoShu = FenXiangMiaoShu = Utils.InputText(list[0].Remark);
                    }
                    #endregion

                }
                else
                {

                    list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetList(pageSize, pageIndex, ref recordCount, new EyouSoft.Model.MallStructure.MShangChengShangPinSer() { isGetTrue = true, ProductName = Utils.GetQueryStringValue("cName"), TypeID = Utils.GetInt(Utils.GetQueryStringValue("lid")), isTrue = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐 }, GYSName = Utils.GetQueryStringValue("g") });

                    #region 设置微信分享链接
                    //设置图片链接
                    if (list.Count > 0)
                    {
                        WapHeader1.FenXiangTuPianFilepath = FenXiangTuPianFilepath = "http://" + Request.Url.Host + retuImgUrl(list[0].ProductImgs);
                        WapHeader1.FenXiangBiaoTi = FenXiangBiaoTi = string.IsNullOrEmpty(cName) ? "e家商城" : string.Format("{0}-{1}-e家商城", cName, list[0].TypeName);

                        if (leibie != 0)
                        {
                            var leibieModel = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetModel(leibie);
                            if (leibieModel != null)
                            {

                                WapHeader1.FenXiangBiaoTi = FenXiangBiaoTi = string.Format("{0}-e家商城", leibieModel.TypeName);
                            }
                        }
                        WapHeader1.FenXiangMiaoShu = FenXiangMiaoShu = Utils.InputText(list[0].Remark);
                    }
                    #endregion

                }
            }
            else
            {

                list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetList(pageSize, pageIndex, ref recordCount, new EyouSoft.Model.MallStructure.MShangChengShangPinSer() { isGetTrue = true, ProductName = Utils.GetQueryStringValue("cName"), TypeID = Utils.GetInt(Utils.GetQueryStringValue("lid")), isTrue = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐 }, GYSName = Utils.GetQueryStringValue("g") });

                #region 设置微信分享链接
                //设置图片链接
                if (list.Count > 0)
                {
                    WapHeader1.FenXiangTuPianFilepath = "http://" + Request.Url.Host + retuImgUrl(list[0].ProductImgs);
                    WapHeader1.FenXiangBiaoTi = string.IsNullOrEmpty(cName) ? "e家商城" : string.Format("{0}-{1}-e家商城", cName, list[0].TypeName);

                    if (leibie != 0)
                    {
                        var leibieModel = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetModel(leibie);
                        if (leibieModel != null)
                        {

                            WapHeader1.FenXiangBiaoTi = string.Format("{0}-e家商城", leibieModel.TypeName);
                        }
                    }
                    WapHeader1.FenXiangMiaoShu = Utils.InputText(list[0].Remark);
                }
                #endregion

            }


            if (list != null && list.Count > 0)
            {

                rptlist.DataSource = list;
                rptlist.DataBind();

            }


            WapHeader1.FenXiangLianJie = Utils.redirectUrl(HttpContext.Current.Request.Url.ToString().Replace("p.", "m."));
        }
        /// 绑定页面广告
        /// </summary>
        private void InitAd()
        {
            EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv();
            //首页轮播图
            var top = bll.GetList(5, (EyouSoft.Model.Enum.AdvArea)11);
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
        protected string retuImgUrl(object imgs)
        {
            IList<MChanPinTuPian> tupians = (IList<MChanPinTuPian>)imgs;
            if (tupians != null && tupians.Count > 0) return TuPian.F1(tupians[0].FilePath, 210, 70);
            return "/images/mall_img001.gif";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="youhuijia"></param>
        /// <param name="menshijia"></param>
        /// <returns></returns>
        protected string GetJINE(object youhuijia, object menshijia)
        {
            decimal n = Utils.GetDecimal(youhuijia.ToString());
            decimal m = Utils.GetDecimal(menshijia.ToString());
            return UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, n, m, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0");
        }
    }
}