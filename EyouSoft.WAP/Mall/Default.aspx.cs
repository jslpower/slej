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
        protected int pageSize = 1000;
        protected string toplist = string.Empty;
        protected string dianlist = string.Empty;//确认个数
        #endregion
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
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


            pageIndex = UtilsCommons.GetPagingIndex();

            var list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetList(pageSize, pageIndex, ref recordCount, new EyouSoft.Model.MallStructure.MShangChengShangPinSer() { isGetTrue = true, ProductName = Utils.GetQueryStringValue("cName"), TypeID = Utils.GetInt(Utils.GetQueryStringValue("lid")), isTrue = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐 } });



            if (list != null && list.Count > 0)
            {
                #region 设置微信分享链接
                //设置图片链接
                FenXiangTuPianFilepath = "http://" + Request.Url.Host + retuImgUrl(list[0].ProductImgs);
                FenXiangBiaoTi = list[0].ProductName;
                FenXiangMiaoShu = list[0].Remark;
                #endregion

                rptlist.DataSource = list;
                rptlist.DataBind();

            }
            var menus = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetList(new EyouSoft.Model.MallStructure.MShangChengLeiBieSer() { }, false);
            var menuList = menus.Where(i => i.ParentID == 0).ToList();
            if (menuList != null && menuList.Count > 0)
            {
                rptMenu.DataSource = menuList;
                rptMenu.DataBind();
            }

            FenXiangLianJie = HttpContext.Current.Request.Url.ToString();
        }
        /// <summary>
        /// 获取二级目录
        /// </summary>
        /// <param name="id">父节点</param>
        /// <returns></returns>
        protected string getMenu(object id)
        {
            int pid = Utils.GetInt(id.ToString());
            System.Text.StringBuilder strbu = new System.Text.StringBuilder();
            var list = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetList(new EyouSoft.Model.MallStructure.MShangChengLeiBieSer() { ParentID = pid }, false);
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    strbu.AppendFormat(" <a href=\"ShangCheng.aspx?lid={0}\">{1}</a>", item.TypeID, item.TypeName);
                }
            }

            return strbu.ToString();
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
            if (tupians != null && tupians.Count > 0) return TuPian.F1(tupians[0].FilePath, 640, 200);
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