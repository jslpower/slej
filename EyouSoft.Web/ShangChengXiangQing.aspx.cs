using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using EyouSoft.Model.SSOStructure;

namespace EyouSoft.Web
{
    public partial class ShangChengXiangQing : Common.Page.WebPageBase
    {
        protected string thisurl = "";
        protected bool ksisbool = false;//false为显示-款式
        protected bool ysisbool = false;//false为显示-颜色
        protected bool xhisbool = false;//false为显示-型号
        protected void Page_Load(object sender, EventArgs e)
        {
            string hosturl = Request.Url.Host.ToLower();
            if (hosturl.IndexOf("www") >= 0)
            {
                hosturl = "slej.cn";
            }
            thisurl = "http://m."+hosturl+"/Mall/MoDetail.aspx?ID=" + Utils.GetQueryStringValue("ID");
            if (Utils.GetQueryStringValue("url") == "1") getLoginState();
            MUserInfo m = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);
            if (isLogin)
            {
                planologin.Visible = planologin1.Visible = stro.Visible = false;
            }
            initPage();
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
                lblChanPinMingCheng.Text = model.ProductName;
                lblXiaoShou.Text = model.SaleNum.ToString();
                lblShangJia.Text = model.IssueTime.ToString("yyyy-MM-dd");
                lblShengChanRiQi.Text = model.ProductionDate != null ? model.ProductionDate.Value.ToString("yyyy-MM-dd") : "";
                lblBaoZhiQi.Text = model.ShelfDate.ToString();

                var gys =  new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(model.GYSid);
                if (gys != null)
                {
                    var memodel = new EyouSoft.IDAL.MemberStructure.BMember2().Get(gys.MemberID);
                    lblGYSNAME.Text = string.Format("<a href=\"/ShangCheng.aspx?gid={1}\" class=fontblue>{0}</a>", gys.CompanyName,model.GYSid);
                    lblLXFS.Text = memodel.Contact + "&nbsp;&nbsp;" + memodel.Mobile;
                    if (!string.IsNullOrEmpty(memodel.qq)) lblQQ.Text = string.Format("<a target=\"_blank\" href=\"tencent://message/?uin={0}&amp;Site=&amp;Menu=yes\"><img src=\"http://wpa.qq.com/pa?p=1:{0}:51\" alt=\"和我联系吧\" border=\"0\"></a>", memodel.qq);
                }


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
                            strbuXingHao.AppendFormat("<label> <input type=\"radio\" name=\"radXingHao\" value=\"{0}\" /> {0}</label>", xinghaos[i]);
                        }
                    }
                }
                lblXingHao.Text = strbuXingHao.ToString();

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
                            strbuYanSe.AppendFormat("<label> <input type=\"radio\" name=\"radYanSe\" value=\"{0}\" /> {0}</label>", yanses[i]);
                        }
                    }
                }
                lblYanSe.Text = strbuYanSe.ToString();

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
                            strbuKuanShi.AppendFormat("<label> <input type=\"radio\" name=\"radKuanShi\" value=\"{0}\" /> {0}</label>", kuanshis[i]);
                        }
                    }
                }
                lblKuanShi.Text = strbuKuanShi.ToString();
                #endregion

                lblLeiXing.Text = model.TypeName;
                lblMenShiJia.Text = model.MarketPrice.ToString("F0") + model.Unit; ;
                lblHuiYuanJia.Text = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0") + model.Unit;
                lblMFDL.Text = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.免费代理).ToString("F0") + model.Unit;
                lblGuiBinJia.Text = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.贵宾会员).ToString("F0") + model.Unit;
                lblDaiLiJia.Text = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.代理).ToString("F0") + model.Unit;
                lblYuanGongJia.Text = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.员工).ToString("F0") + model.Unit;
                if (isLogin && ((int)m.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.免费代理 || m.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员))
                {
                    pla_ejdl.Visible = true;
                }

                if (isLogin && (int)m.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 && m.UserType != EyouSoft.Model.Enum.MemberTypes.免费代理)
                {
                    pla_gb.Visible = true;
                }
                if (isLogin && (int)m.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.代理)
                {
                    pla_dl.Visible = true;
                }
                if (isLogin && (int)m.UserType >= (int)EyouSoft.Model.Enum.MemberTypes.员工)
                {
                    pla_yg.Visible = true;
                }
                if (model.StockNum > 0)
                {
                    lblKuCun.Text = model.StockNum + "件";
                }
                else 
                {
                    lblKuCun.Text = "暂时缺货！";
                }
                litJieShao.Text = model.Remark;
                litBuBaoHan.Text = model.UnContentService;
                litBaoHan.Text = model.ContentService;
                litShiYong.Text = model.UseRule;
                litZhuYi.Text = model.NoticeKnow;
                litYouJi.Text = model.MailWay;

                #region 图片处理
                if (model.ProductImgs != null && model.ProductImgs.Count > 0)
                {
                    lblZhuTu.Text = string.Format("<img src=\"{0}\" />", model.ProductImgs[0].FilePath);
                    StringBuilder strbuImg = new StringBuilder();
                    strbuImg.AppendFormat("<li><a class=\"on\"><img  name=\"smallA\" src=\"{0}\" /></a></li>", model.ProductImgs[0].FilePath);
                    lblZhuTu.Text = string.Format("<a><img src=\"{0}\" /></a>", model.ProductImgs[0].FilePath);
                    for (int i = 1; i < model.ProductImgs.Count; i++)
                    {
                        strbuImg.AppendFormat("<li><a  ><img name=\"smallA\" src=\"{0}\" /></a></li>", model.ProductImgs[i].FilePath);
                        lblZhuTu.Text += string.Format("<a><img src=\"{0}\" /></a>", model.ProductImgs[i].FilePath);
                    }
                    litFuTu.Text = strbuImg.ToString();
                }
                #endregion

                #region 优惠信息
                decimal yhxxHYJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.普通会员);
                StringBuilder strHY = new StringBuilder();
                strHY.AppendFormat("<div class=\"tixing\"><b>优惠价总金额：</b><br><font class=\"fontyellow\"><b class=\"font14\"><span id='hydj'>{0}</span></b>{1} x <b class=\"font14\"><span class='ts'>1</span></b> =</font><font class=\"fontblue\"><b class=\"font14\"><span id='hyzj'>{0}</span></b>元</font></div>"
                    , yhxxHYJ.ToString("F0")
                    , model.Unit);
                if (isDisplay)
                {
                    lit_hy.Text = strHY.ToString();
                }
                StringBuilder strGB = new StringBuilder();
                decimal yhxxGBJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.贵宾会员);
                strGB.AppendFormat("<div class=\"tixing\"><b>{4}：</b><br><font class=\"fontyellow\"><b class=\"font14\"><span id='gbdj'>{0}</span></b>{1} x <b class=\"font14\"><span class='ts'>1</span></b> =</font><font class=\"fontblue\"><b class=\"font14\"><span id='gbzj'>{0}</span></b>元</font>&nbsp;&nbsp;&nbsp;&nbsp;{3}<br /><b class=\"fontblue\">立省<span id='gbjs'>{2}</span>元</b></div>"
                    , yhxxGBJ.ToString("F0")
                    , model.Unit
                    , (yhxxHYJ - yhxxGBJ).ToString("F0")
                    , (m != null && (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 > (int)m.UserType && m.UserType != EyouSoft.Model.Enum.MemberTypes.免费代理) || m == null ? "<a   target=\"_blank\"  class=\"btn001 huiyuan\" href=\"/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\"><span>马上申请</span></a>" : ""
                     , (m != null && (int)EyouSoft.Model.Enum.MemberTypes.贵宾会员 > (int)m.UserType) || m == null ? "申请贵宾身份" : "贵宾价总金额");
                if (isDisplay)
                {
                    lit_gb.Text = strGB.ToString();
                }
                StringBuilder strDL = new StringBuilder();
                decimal yhxxDLJ = UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城, model.SalePrice, model.MarketPrice, EyouSoft.Model.Enum.MemberTypes.代理);
                strDL.AppendFormat("<div class=\"tixing\"><b>{4}：</b><br><font class=\"fontyellow\"><b class=\"font14\"><span id='dldj'>{0}</span></b>{1} x <b class=\"font14\"><span class='ts'>1</span></b> =</font><font class=\"fontblue\"><b class=\"font14\"><span id='dlzj'>{0}</span></b>元</font>&nbsp;&nbsp;&nbsp;&nbsp;{3}<br /><b class=\"fontblue\">立省<span id='dljs'>{2}</span>元</b></div>"
                    , yhxxDLJ.ToString("F0")
                    , model.Unit
                    , (yhxxHYJ - yhxxDLJ).ToString("F0")
                    , (m != null && (int)EyouSoft.Model.Enum.MemberTypes.代理 > (int)m.UserType) || m == null ? "<a   target=\"_blank\"  class=\"btn001 huiyuan\" href=\"/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\"><span>马上申请</span></a>" : ""
                     , (m != null && (int)EyouSoft.Model.Enum.MemberTypes.代理 > (int)m.UserType) || m == null ? "申请代理身份" : "代理价总金额");

                if (isDisplay)
                {
                    lit_dl.Text = strDL.ToString();
                }
                #endregion

            }
        }
        #region 私有方法
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
        #endregion
    }


}
