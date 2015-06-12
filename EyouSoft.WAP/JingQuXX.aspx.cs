using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Model.ScenicStructure.WebModel;
using EyouSoft.BLL.ScenicStructure;
using EyouSoft.Model.ScenicStructure;
using EyouSoft.Model;
using Linq.Bussiness;
using EyouSoft.Common;
using Linq.Web;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.Enum;
using Linq.Common;
using EyouSoft.Common.Page;
using EyouSoft.Model.SystemStructure;
using EyouSoft.BLL.SystemStructure;

namespace EyouSoft.WAP
{
    [NoCache]
    public partial class JingQuXX : WebPageBase
    {

        BScenicArea2 bll = new BScenicArea2();
        protected string toplist = string.Empty;
        protected string dianlist = string.Empty;//确认个数
        protected decimal WebsitePrices = 0;
        protected decimal RetailPrice = 0;
        protected decimal DistributionPrice = 0;
        protected string ScenicName = null;
        protected MFeeSettings FeeSettings = null;
        protected string Description = null;
        protected string Traffic = null;
        protected bool UIsLogin = false;
        protected MemberTypes HUserType = MemberTypes.普通会员;
        int cityid = 0;
        ScenicTicketXiangQingSearchModel Model = new ScenicTicketXiangQingSearchModel();
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            XiangGuanMenPiao();
            InitMenPiao();
            if (isLogin)
            {
                UIsLogin = true;
                HUserType = m.UserType;
            }

            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }
        private void XiangGuanMenPiao()
        {
            Model.ScenicId = Utils.GetQueryStringValue("ScenicId");
            Model.TicketsId = Utils.GetQueryStringValue("TicketsId");
            MScenicAreaWebSearchModel area = bll.GetScenicTicketsInfo(Model.ScenicId);
            if (area == null)
            {
                return;
            }
            else
            {
                JingQuTel.Text = area.ServiceTel;
                JingQuLv.Text = area.ScenicLevel.ToString();
                JingQuAddress.Text = area.CnAddress;
                ScenicName = area.ScenicName;
                cityid = Convert.ToInt32(area.CityId);
                WapHeader1.HeadText = EyouSoft.Common.Utils.GetText2(ScenicName.ToString(), 9, true);
                Description = area.Description;
                Traffic = area.Traffic;
                FeeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.门票);
                while (area.ImgList.Count < 3)
                {
                    area.ImgList.Add(new MScenicAreaImg { Address = "/Images/NoPic.jpg" });
                }
                using (var t = new timerRecorder())
                {
                    #region 图片处理
                    List<string> files = new List<string>();
                    List<string> hrefs = new List<string>();
                    if (area.ImgList != null && area.ImgList.Count > 0)
                    {
                        foreach (var item in area.ImgList)
                        {
                            files.Add(TuPian.F1(item.Address,640,400));
                            hrefs.Add("javascript:;");
                        }

                    }
                    ScrollImg1.ImgUrl = files;
                    ScrollImg1.HrefUrl = hrefs;
                    ScrollImg1.ImgGth = 400;
                    ScrollImg1.ImgWid = 640;
                    #endregion
                }

                if (area.TicketInfo != null || area.TicketInfo.Count > 0)
                {
                    if (Model.IsShowShenQing && !string.IsNullOrEmpty(Model.TicketsId))
                    {
                        var currentTicket = area.TicketInfo.FirstOrDefault(x => x.TicketsId == Model.TicketsId);
                        ticklist.DataSource = area.TicketInfo.Where(x => x != currentTicket).OrderBy(x => x.DistributionPrice).ToArray();
                        MScenicTicketsWebBindModel TModel = new MScenicTicketsWebBindModel();
                        currentTicket.UpdateTo(TModel);
                    }
                    else
                    {
                        MScenicTicketsWebBindModel TModel = new MScenicTicketsWebBindModel();
                        area.TicketInfo.OrderBy(x => x.DistributionPrice).First().UpdateTo(TModel);
                        ticklist.DataSource = area.TicketInfo.OrderBy(x => x.DistributionPrice).ToArray();
                    }
                    WebsitePrices = area.TicketInfo.Last().WebsitePrices;
                    RetailPrice = area.TicketInfo.Last().RetailPrice;
                    DistributionPrice = area.TicketInfo.Last().DistributionPrice;
                    ticklist.DataBind();
                }
                FenXiangBiaoTi = area.ScenicName;
                FenXiangMiaoShu = Utils.GetText2(area.Description, 30, true);
                FenXiangTuPianFilepath = "http://" + Request.Url.Host + TuPian.F1(area.ImgList[0].Address, 640, 400);
                FenXiangLianJie = HttpContext.Current.Request.Url.ToString();
            }
        }
        /// <summary>
        /// 景区门票初始化
        /// </summary>
        private void InitMenPiao()
        {
            EyouSoft.Model.ScenicStructure.WebModel.MScenicAreaSearchModel model = new EyouSoft.Model.ScenicStructure.WebModel.MScenicAreaSearchModel();
            if (cityid > 0)
            {
                model.CityId = cityid;
            }
            model.ProductSort = 0;
            var list = new BLL.ScenicStructure.BScenicArea().GetScenicAreaList(4, model);

            if (list != null && list.Count > 0)
            {
                MFeeSettings feesetting = new BFeeSettings().GetByType(FeeTypes.门票);
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].FeeSetting = feesetting;
                }
                Repeater1.DataSource = list;
                Repeater1.DataBind();
            }

        }
        /// <summary>
        /// 生成景区形象图片Html
        /// </summary>
        /// <param name="imgList"></param>
        /// <returns></returns>
        protected string GetScenicImg(object imgList)
        {
            if (imgList == null) return "<img alt=\"暂无图片\" src=\"/images/NoPic.jpg\" />";

            var list = (IList<Model.ScenicStructure.MScenicAreaImg>)imgList;

            if (!list.Any()) return "<img alt=\"暂无图片\" src=\"/images/NoPic.jpg\" />";

            var tmp = list[0];
            if (tmp == null || string.IsNullOrEmpty(tmp.Address)) return "<img alt=\"暂无图片\" src=\"/images/NoPic.jpg\" />";

            return string.Format("<img alt=\"{0}\" src=\"{1}\" />", tmp.Description, TuPian.F1(tmp.Address, 320, 240));
        }
    }
}
