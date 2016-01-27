using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using EyouSoft.Common.Function;
using EyouSoft.Common;

namespace EyouSoft.Web.print
{
    public partial class xingchengdan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Init();
        }

        void Init()
        {
            var m = new BLL.XianLuStructure.BXianLu().GetInfo(Common.Utils.GetQueryStringValue("routeid"));

            if (m == null) Common.Utils.ShowAndRedirect("请求异常！", "/");

            RouteName.Text = Utils.ConverToStringByHtml(m.RouteName);
            var b = new BLL.OtherStructure.BSysAreaInfo();
            var p = b.GetSysProvinceModel(m.DepProvinceId);
            if (p != null) chufadi.Text = p.Name;
            var c = b.GetSysCityModel(m.DepCityId);
            if (c != null) chufadi.Text = chufadi.Text + " " + c.Name;
            TianShu.Text = m.TianShu.ToString();
            if (!string.IsNullOrEmpty(Common.Utils.GetQueryStringValue("tourid")))
            {
                if (m.Tours != null)
                {
                    var f = m.Tours.Where(l => l.TourId == Common.Utils.GetQueryStringValue("tourid")).ToList();
                    if (f != null && f.Count > 0) { LDate.Text = f[0].LDate.ToShortDateString(); RDate.Text = f[0].RDate.ToShortDateString(); }
                }
            }
            else if (m.LatestTour != null)
            {
                LDate.Text = m.LatestTour.LDate.ToShortDateString();
                RDate.Text = m.LatestTour.RDate.ToShortDateString();
            }
            ChuFaJiaoTong.Text = m.ChuFaJiaoTong;
            FanChengJiaoTong.Text = m.FanChengJiaoTong;
            JiHeFangShi.Text = m.JiHeFangShi;
            LxrName.Text = m.LxrName;
            LxrMobile.Text = m.LxrMobile;
            Description.Text = m.Description;
            SCJCR.Text = m.SCJCR.ToString("F2");
            SCJET.Text = m.SCJET.ToString("F2");
            if (m.Line_Source != EyouSoft.Model.XianLuStructure.LineSource.光大)
            {
                TeSe.Text = StringValidate.TextToHtml(m.TeSe);
            }
            else
            {
                TeSe.Text = m.TeSe;
            }
            if (m.XingChengs != null && m.XingChengs.Count > 0) { rpt.DataSource = m.XingChengs; rpt.DataBind(); }
            if (m.FuWu != null)
            {
                if (m.Line_Source == EyouSoft.Model.XianLuStructure.LineSource.光大 || m.Line_Source == EyouSoft.Model.XianLuStructure.LineSource.旅游圈)
                {
                    FuWuBiaoZhun.Text = Utils.ConverToHtml(m.FuWu.FuWuBiaoZhun);
                    BuHanXiangMu.Text = Utils.ConverToHtml(m.FuWu.BuHanXiangMu);
                    ErTongAnPai.Text = Utils.ConverToHtml(m.FuWu.ErTongAnPai);
                    GouWuAnPai.Text = Utils.ConverToHtml(m.FuWu.GouWuAnPai);
                    ZiFeiXiangMu.Text = Utils.ConverToHtml(m.FuWu.ZiFeiXiangMu);
                    ZhuYiShiXiang.Text = Utils.ConverToHtml(m.FuWu.ZhuYiShiXiang);
                    WenXinTiXing.Text = Utils.ConverToHtml(m.FuWu.WenXinTiXing);
                    QiTaShiXiang.Text = Utils.ConverToHtml(m.FuWu.QiTaShiXiang);
                    BaoMingXuZhi.Text = Utils.ConverToHtml(m.FuWu.BaoMingXuZhi);
                    ZengSongXiangMu.Text = Utils.ConverToHtml(m.FuWu.ZengSongXiangMu);
                }
                else
                {
                    FuWuBiaoZhun.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(m.FuWu.FuWuBiaoZhun));
                    BuHanXiangMu.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(m.FuWu.BuHanXiangMu));
                    ErTongAnPai.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(m.FuWu.ErTongAnPai));
                    GouWuAnPai.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(m.FuWu.GouWuAnPai));
                    ZiFeiXiangMu.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(m.FuWu.ZiFeiXiangMu));
                    ZhuYiShiXiang.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(m.FuWu.ZhuYiShiXiang));
                    WenXinTiXing.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(m.FuWu.WenXinTiXing));
                    QiTaShiXiang.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(m.FuWu.QiTaShiXiang));
                    BaoMingXuZhi.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(m.FuWu.BaoMingXuZhi));
                    ZengSongXiangMu.Text = Utils.ConverToHtml(EyouSoft.Common.Function.StringValidate.TextToHtml(m.FuWu.ZengSongXiangMu));
                }
            }
            string website = HttpContext.Current.Request.Url.Host.ToLower();
            if (website.IndexOf("slej.cn") > -1 && website.IndexOf("www") < 0)
            {
                var seller = new EyouSoft.IDAL.AccountStructure.BSellers().GetMSellersByWebSite(website);
                if (seller != null)
                {
                    MMember2 model = new EyouSoft.IDAL.MemberStructure.BMember2().Get(seller.MemberID);
                    if (model != null)
                    {
                        litWL.Text = string.Format(" 业务外联：{0} &nbsp; &nbsp; &nbsp; &nbsp;{1} &nbsp; &nbsp; &nbsp; &nbsp;{2}  &nbsp; &nbsp;  &nbsp; &nbsp;微信：{3} &nbsp; &nbsp;&nbsp; &nbsp;QQ号:{4}<br />", model.MemberName, model.Contact, model.Mobile, model.WeiXin, model.qq);
                        litKW.Text = string.Format("客户服务：{0}  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;{1} &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;{2}  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; 微信：{3} &nbsp; &nbsp;&nbsp; &nbsp;QQ号:{4}<br />", seller.JinAoLXR, seller.JinAoTel, seller.JinAoMobile, seller.JinAoWeiXin, seller.JinAoQQ);

                    }
                }
            }


        }
    }
}
