using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.MallStructure;
using EyouSoft.Common;

namespace EyouSoft.WAP.Mall
{
    public partial class ModList : System.Web.UI.Page
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 12;
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
            string url = HttpContext.Current.Request.Url.Host.Replace("m.", "");
            //string url = "8766.slej.cn";
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.IDAL.AccountStructure.BSellers().GetMSellersByWebSite(url);
            string sqlwhere="";
            if (seller != null)
            {
                sqlwhere = seller.ID;
            }

            IList<MShangChengShangPin> list = new List<MShangChengShangPin>();
            var serchModel = new EyouSoft.Model.MallStructure.MShangChengShangPinSer() { isGetTrue = true, sqlWhere = sqlwhere, ProductName = cName, TypeID = Utils.GetInt(Utils.GetQueryStringValue("lid")), isTrue = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 }, GYSName = Utils.GetQueryStringValue("g"), GYSid = Utils.GetQueryStringValue("gid") };

            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("t")))
            {
                    EyouSoft.Model.MallStructure.MDaiLiShangChanPinSer model = new EyouSoft.Model.MallStructure.MDaiLiShangChanPinSer();
                    model.ProductStatus = new[] { EyouSoft.Model.Enum.ProductZT.首页推荐 };
                    if (seller != null)
                    {
                        model.MemberId = seller.ID;
                    }
                    list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetDaiLiList(pageSize, pageIndex, ref recordCount, model);
               
                lblTypeName.Text = "热销宝贝";
            }
            else
            {
                list = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetList(pageSize, pageIndex, ref recordCount, serchModel);
            }

            if (list != null && list.Count > 0)
            {

                if (recordCount < pageSize)
                    PlaceHolder1.Visible = false;

                #region 设置微信分享链接
                //设置图片链接
                FenXiangTuPianFilepath = "http://" + Request.Url.Host + retuImgUrl(list[0].ProductImgs);
                FenXiangBiaoTi = string.IsNullOrEmpty(cName) ? "e家商城" : string.Format("{0}-{1}-e家商城", cName, list[0].TypeName);

                if (leibie != 0)
                {
                    var leibieModel = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetModel(leibie);
                    if (leibieModel != null)
                    {

                        FenXiangBiaoTi = string.Format("{0}-e家商城", leibieModel.TypeName);
                    }
                }
                FenXiangMiaoShu = Utils.InputText(list[0].Remark);
                #endregion

                rptlist.DataSource = list;
                rptlist.DataBind();

            }


            var menus = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetList(new EyouSoft.Model.MallStructure.MShangChengLeiBieSer() { }, false);
            if (serchModel != null && serchModel.TypeID > 0)
            {
                lblTypeName.Text = menus.Where(i => i.TypeID == serchModel.TypeID).First().TypeName;
            }
            if (serchModel != null && !string.IsNullOrEmpty(serchModel.GYSid))
            {
                var item = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(serchModel.GYSid);
                lblTypeName.Text = item.CompanyName;
            }
            FenXiangLianJie =  Utils.redirectUrl(HttpContext.Current.Request.Url.ToString());

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
