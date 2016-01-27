using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using EyouSoft.Model.SSOStructure;
using EyouSoft.Model.MallStructure;

namespace EyouSoft.WAP.Mall
{
    public partial class MoDetail : Common.Page.WebPageBase
    {
        protected int KuCunNum = 0;
        protected bool ksisbool = false;//true为显示-款式
        protected bool ysisbool = false;//true为显示-颜色
        protected bool xhisbool = false;//true为显示-型号
        protected bool kdisbool = false;//true为显示-快递方式
        protected string gysid = "";
        protected decimal pjiage = 0;
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
            if (Utils.GetQueryStringValue("url") == "1") getLoginState();
            MUserInfo m = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);
            if (Utils.GetQueryStringValue("getSum") == "1") getSumMoney();
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
        /// <summary>
        /// 初始化页面
        /// </summary>
        void initPage()
        {
            MUserInfo m = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);
            var model = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetModel(Utils.GetQueryStringValue("id"));
            if (model != null)
            {


                lblName.Text = model.ProductName;
                //lblSellCount.Text = model.SaleNum.ToString();
                // lblShangJia.Text = model.IssueTime.ToString("yyyy-MM-dd");
                //lblShengChanRiQi.Text = model.ProductionDate != null ? model.ProductionDate.Value.ToString("yyyy-MM-dd") : "";
                // lblBaoZhiQi.Text = model.ShelfDate.ToString();

                var gys = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(model.GYSid);
                if (gys != null)
                {
                    var memodel = new EyouSoft.IDAL.MemberStructure.BMember2().Get(gys.MemberID);
                    lblSupplier.Text = gys.CompanyName;
                    MemberName.Text = memodel.MemberName;
                    MemberMoblie.Text = memodel.Mobile;
                    gysid = gys.ID;
                }

                KuCunNum = model.StockNum;

                #region 颜色 型号 款式
                string XingHao = model.ModelDesc;
                StringBuilder strbuXingHao = new StringBuilder();
                if (!string.IsNullOrEmpty(XingHao))
                {
                    xhisbool = true;
                    string[] xinghaos = XingHao.Split(',');
                    if (xinghaos != null && xinghaos.Length > 0)
                    {
                        for (int i = 0; i < xinghaos.Length; i++)
                        {
                            strbuXingHao.AppendFormat("<a href=\"javascript:;\" class=\"type_a\">{0}</a>", xinghaos[i]);
                        }
                    }
                }
                lblTypes.Text = strbuXingHao.ToString();

                string YanSe = model.ColorDesc;
                StringBuilder strbuYanSe = new StringBuilder();
                if (!string.IsNullOrEmpty(YanSe))
                {
                    ysisbool = true;
                    string[] yanses = YanSe.Split(',');
                    if (yanses != null && yanses.Length > 0)
                    {
                        for (int i = 0; i < yanses.Length; i++)
                        {
                            strbuYanSe.AppendFormat("<a href=\"javascript:;\" class=\"color_a\">{0}</a>", yanses[i]);
                        }
                    }
                }
                lblColors.Text = strbuYanSe.ToString();

                string KuanShi = model.StylesDesc;
                StringBuilder strbuKuanShi = new StringBuilder();
                if (!string.IsNullOrEmpty(KuanShi))
                {
                    ksisbool = true;
                    string[] kuanshis = KuanShi.Split(',');
                    if (kuanshis != null && kuanshis.Length > 0)
                    {
                        for (int i = 0; i < kuanshis.Length; i++)
                        {
                            strbuKuanShi.AppendFormat("<a href=\"javascript:;\" class=\"model_a\">{0}</a>", kuanshis[i]);
                        }
                    }
                }
                lblModel.Text = strbuKuanShi.ToString();
                #endregion

                litNotice.Text = model.NoticeKnow;
                litMailWay.Text = model.MailWay;
                if (!string.IsNullOrEmpty(model.MailWay.Trim()))
                {
                    kdisbool = true;
                }
                StringBuilder strInfoStr = new StringBuilder();
                strInfoStr.AppendFormat("产品描述：<br/>{0}<br/>", model.Remark);
                strInfoStr.AppendFormat("包含服务：<br/>{0}<br/>", model.ContentService);
                strInfoStr.AppendFormat("不含服务：<br/>{0}<br/>", model.UnContentService);
                strInfoStr.AppendFormat("使用方法：<br/>{0}<br/>", model.UseRule);
                litInfo.Text = strInfoStr.ToString();
                //lblLeiXing.Text = model.TypeName;
                lblMarketPrice.Text = model.MarketPrice.ToString("F2") + model.Unit;
                if (m == null)
                {
                    lblMemberType.Text = "优惠：";
                }
                else
                {
                    lblMemberType.Text = getMemberStr(m.UserType) + "：";
                }

                lblMemberPrice.Text = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice).ToString("F2") + model.Unit;
                pjiage = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice);




                #region 图片处理


                List<string> files = new List<string>();
                List<string> hrefs = new List<string>();
                if (model.ProductImgs != null && model.ProductImgs.Count > 0)
                {
                    foreach (var item in model.ProductImgs)
                    {
                        files.Add(TuPian.F1(item.FilePath, 640, 400));
                        hrefs.Add("javascript:;");
                    }

                }
                ScrollImg1.ImgUrl = files;
                ScrollImg1.HrefUrl = hrefs;
                ScrollImg1.ImgGth = 400;
                ScrollImg1.ImgWid = 640;
                #endregion

                #region 优惠信息
                decimal yhxxHYJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.普通会员);
                StringBuilder strHY = new StringBuilder();
                if (m != null)
                {
                    strHY.AppendFormat("<li><span class=\"font_yellow\">优惠价：</span>{0} x 1 = <span class=\"font_yellow\">{0}</span>元</li>", yhxxHYJ.ToString("F2"));
                    if (isDisplay)
                    {

                        if (m.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                        {
                            decimal yhxxDXJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.免费代理);
                            strHY.AppendFormat("<li><span class=\"font_yellow\">代销价：</span>{0} x 1 = <span class=\"font_yellow\">{0}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxDXJ.ToString("F2"), (yhxxHYJ - yhxxDXJ).ToString("F2"));
                        }
                        decimal yhxxGBJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.贵宾会员);
                        strHY.AppendFormat("<li><a style=\"display:{2}\" href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">贵宾价：</span>{0} x 1 = <span class=\"font_yellow\">{0}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxGBJ.ToString("F2"), (yhxxHYJ - yhxxGBJ).ToString("F2"), (int)m.UserType < (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 ? "" : "none");

                        decimal yhxxDLJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.代理);
                        strHY.AppendFormat("<li><a style=\"display:{2}\"  href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理价：</span>{0} x 1 = <span class=\"font_yellow\">{0}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxDLJ.ToString("F2"), (yhxxHYJ - yhxxDLJ).ToString("F2"), (int)m.UserType < (int)EyouSoft.Model.Enum.MemberTypes.代理 ? "" : "none");

                        if (m.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                        {
                            decimal yhxxYGJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.员工);
                            strHY.AppendFormat("<li><span class=\"font_yellow\">员工价：</span>{0} x 1 = <span class=\"font_yellow\">{0}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxYGJ.ToString("F2"), (yhxxHYJ - yhxxYGJ).ToString("F2"));
                        }
                    }
                    else
                    {
                        if (m.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                        {
                            decimal yhxxDXJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.免费代理);
                            strHY.AppendFormat("<li><span class=\"font_yellow\">代销价：</span>{0} x 1 = <span class=\"font_yellow\">{0}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxDXJ.ToString("F2"), (yhxxHYJ - yhxxDXJ).ToString("F2"));
                        }
                        if (m.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                        {
                            decimal yhxxGBJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.贵宾会员);
                            strHY.AppendFormat("<li><span class=\"font_yellow\">贵宾价：</span>{0} x 1 = <span class=\"font_yellow\">{0}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxGBJ.ToString("F2"), (yhxxHYJ - yhxxGBJ).ToString("F2"));
                        }

                        if (m.UserType == EyouSoft.Model.Enum.MemberTypes.代理)
                        {
                            decimal yhxxDLJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.代理);
                            strHY.AppendFormat("<li><span class=\"font_yellow\">代理价：</span>{0} x 1 = <span class=\"font_yellow\">{0}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxDLJ.ToString("F2"), (yhxxHYJ - yhxxDLJ).ToString("F2"));
                        }
                        if (m.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                        {
                            decimal yhxxYGJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.员工);
                            strHY.AppendFormat("<li><span class=\"font_yellow\">员工价：</span>{0} x 1 = <span class=\"font_yellow\">{0}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxYGJ.ToString("F2"), (yhxxHYJ - yhxxYGJ).ToString("F2"));
                        }

                    }
                }
                else
                {
                    strHY.AppendFormat("<li><span class=\"font_yellow\">优惠价：</span>{0} x 1 = <span class=\"font_yellow\">{0}</span>元</li>", yhxxHYJ.ToString("F2"));
                    if (isDisplay)
                    {
                        decimal yhxxGBJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.贵宾会员);
                        strHY.AppendFormat("<li><a  href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">贵宾价：</span>{0} x 1 = <span class=\"font_yellow\">{0}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxGBJ.ToString("F2"), (yhxxHYJ - yhxxGBJ).ToString("F2"));

                        decimal yhxxDLJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.代理);
                        strHY.AppendFormat("<li><a    href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理价：</span>{0} x 1 = <span class=\"font_yellow\">{0}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxDLJ.ToString("F2"), (yhxxHYJ - yhxxDLJ).ToString("F2"));
                    }

                }


                litYouHui.Text = strHY.ToString();

                #endregion


                #region 设置微信分享链接
                //设置图片链接
                WapHeader1.FenXiangTuPianFilepath = "http://" + Request.Url.Host + retuImgUrl(model.ProductImgs);
                WapHeader1.FenXiangBiaoTi = Utils.InputText(model.ProductName);
                WapHeader1.FenXiangMiaoShu = Utils.InputText(model.Remark);
                #endregion

                WapHeader1.FenXiangLianJie = Utils.redirectUrl(HttpContext.Current.Request.Url.ToString());
            }
        }
        #region 私有方法

        void getSumMoney()
        {
            var model = new EyouSoft.BLL.MallStructure.BShangChengShangPin().GetModel(Utils.GetQueryStringValue("id"));
            int sl = Utils.GetInt(Utils.GetQueryStringValue("sl"));
            if (model != null)
            {
                #region 优惠信息
                decimal yhxxHYJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.普通会员);
                StringBuilder strHY = new StringBuilder();
                if (m != null)
                {
                    strHY.AppendFormat("<li><span class=\"font_yellow\">优惠价：</span>{0} x {1} = <span class=\"font_yellow\">{2}</span>元</li>", yhxxHYJ.ToString("F2"), sl, (yhxxHYJ * sl).ToString("F2"));
                    if (isDisplay)
                    {
                        if (m.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                        {
                            decimal yhxxDXJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.免费代理);
                            strHY.AppendFormat("<li><span class=\"font_yellow\">代销价：</span>{0} x {2} = <span class=\"font_yellow\">{3}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxDXJ.ToString("F2"), (yhxxHYJ * sl - yhxxDXJ * sl).ToString("F2"), sl, (yhxxDXJ * sl).ToString("F2"));
                        }
                        decimal yhxxGBJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.贵宾会员);
                        strHY.AppendFormat("<li><a style=\"display:{3}\" href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">贵宾价：</span>{0} x {2} = <span class=\"font_yellow\">{4}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxGBJ.ToString("F2"), (yhxxHYJ * sl - yhxxGBJ * sl).ToString("F2"), sl, (int)m.UserType < (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 ? "" : "none", (yhxxGBJ * sl).ToString("F2"));

                        decimal yhxxDLJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.代理);
                        strHY.AppendFormat("<li><a style=\"display:{3}\"  href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理价：</span>{0} x {2} = <span class=\"font_yellow\">{4}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxDLJ.ToString("F2"), (yhxxHYJ * sl - yhxxDLJ * sl).ToString("F2"), sl, (int)m.UserType < (int)EyouSoft.Model.Enum.MemberTypes.代理 ? "" : "none", (yhxxDLJ * sl).ToString("F2"));
                    }
                    else
                    {
                        if (m.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理)
                        {
                            decimal yhxxDXJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.免费代理);
                            strHY.AppendFormat("<li><span class=\"font_yellow\">代销价：</span>{0} x {2} = <span class=\"font_yellow\">{3}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxDXJ.ToString("F2"), (yhxxHYJ * sl - yhxxDXJ * sl).ToString("F2"), sl, (yhxxDXJ * sl).ToString("F2"));
                        }
                        if (m.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                        {
                            decimal yhxxGBJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.贵宾会员);
                            strHY.AppendFormat("<li><a style=\"display:{3}\" href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">贵宾价：</span>{0} x {2} = <span class=\"font_yellow\">{4}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxGBJ.ToString("F2"), (yhxxHYJ * sl - yhxxGBJ * sl).ToString("F2"), sl, (int)m.UserType < (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 ? "" : "none", (yhxxGBJ * sl).ToString("F2"));
                        }
                        if (m.UserType == EyouSoft.Model.Enum.MemberTypes.代理)
                        {
                            decimal yhxxDLJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.代理);
                            strHY.AppendFormat("<li><a style=\"display:{3}\"  href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理价：</span>{0} x {2} = <span class=\"font_yellow\">{4}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxDLJ.ToString("F2"), (yhxxHYJ * sl - yhxxDLJ * sl).ToString("F2"), sl, (int)m.UserType < (int)EyouSoft.Model.Enum.MemberTypes.代理 ? "" : "none", (yhxxDLJ * sl).ToString("F2"));
                        }
                        if (m.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                        {
                            decimal yhxxYGJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.员工);
                            strHY.AppendFormat("<li><span class=\"font_yellow\">员工价：</span>{0} x {2} = <span class=\"font_yellow\">{3}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxYGJ.ToString("F2"), (yhxxHYJ * sl - yhxxYGJ * sl).ToString("F2"), sl, (yhxxYGJ * sl).ToString("F2"));
                        }
                    }
                }
                else
                {

                    strHY.AppendFormat("<li> <span class=\"font_yellow\">优惠价：</span>{0} x {1} = <span class=\"font_yellow\">{2}</span>元</li>", yhxxHYJ.ToString("F2"), sl, (yhxxHYJ * sl).ToString("F2"));
                    if (isDisplay)
                    {
                        decimal yhxxGBJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.贵宾会员);
                        strHY.AppendFormat("<li><a href=\"/Mall/MoDetail.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">贵宾价：</span>{0} x {2} = <span class=\"font_yellow\">{3}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxGBJ.ToString("F2"), (yhxxHYJ * sl - yhxxGBJ * sl).ToString("F2"), sl, (yhxxGBJ * sl).ToString("F2"));

                        decimal yhxxDLJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.代理);
                        strHY.AppendFormat("<li><a href=\"/Mall/MoDetail.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"yudin_btn\">申请</a><span class=\"font_yellow\">代理价：</span>{0} x {2} = <span class=\"font_yellow\">{3}</span>元 立省<span class=\"font_yellow\">{1}</span>元</li>", yhxxDLJ.ToString("F2"), (yhxxHYJ * sl - yhxxDLJ * sl).ToString("F2"), sl, (yhxxDLJ * sl).ToString("F2"));

                    }

                }


                Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "", strHY.ToString()));
                #endregion
            }
        }

        /// <summary>
        /// 判断登陆状态
        /// </summary>
        void getLoginState()
        {
            Response.Clear();

            Model.SSOStructure.MUserInfo userInfo = null;
            if (Security.Membership.UserProvider.IsLogin(out userInfo))
            {
                Response.Write(UtilsCommons.AjaxReturnJson("1", "login"));
            }
            else
            {
                Response.Write(UtilsCommons.AjaxReturnJson("0", "unlogin"));

            }
            Response.End();
        }
        /// <summary>
        /// 根据身份获取简称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        string getMemberStr(EyouSoft.Model.Enum.MemberTypes type)
        {
            switch (type)
            {
                case EyouSoft.Model.Enum.MemberTypes.未注册用户:
                case EyouSoft.Model.Enum.MemberTypes.普通会员:
                    return "会员";
                case EyouSoft.Model.Enum.MemberTypes.贵宾会员:
                    return "贵宾";
                case EyouSoft.Model.Enum.MemberTypes.免费代理:
                    return "代销";
                case EyouSoft.Model.Enum.MemberTypes.代理:
                    return "代理";
                case EyouSoft.Model.Enum.MemberTypes.员工:
                    return "员工";
                    break;
                default:
                    break;
            }
            return "";
        }

        /// <summary>
        /// 返回图片路径
        /// </summary>
        /// <param name="imgs"></param>
        /// <returns></returns>
        protected string retuImgUrl(object imgs)
        {
            IList<MChanPinTuPian> tupians = (IList<MChanPinTuPian>)imgs;
            if (tupians != null && tupians.Count > 0) return TuPian.F1(tupians[0].FilePath, 105, 35);
            return "/images/mall_img001.gif";
        }
        #endregion
    }
}
