using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.WAP
{
    public partial class EBao : System.Web.UI.Page
    {
        string yue = "/Login.aspx";
        string fanli = "/Login.aspx";
        string chongzhi = "/Login.aspx";
        string tixian = "/Login.aspx";
        string jifen = "/Login.aspx";
        string zonghe = "/Login.aspx";
        string fenxiao = "/Login.aspx";
        string mingxi = "/Login.aspx";
        string ebao = "/Login.aspx";
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
            WapHeader1.HeadText = "E额宝";
            GetAbout();
            GetUrl();
            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
            WapHeader1.FenXiangBiaoTi = "E额宝";

            WapHeader1.FenXiangMiaoShu = "E额宝";
            WapHeader1.FenXiangTuPianFilepath = "http://" + Request.Url.Host + "/images/logo.jpg";
            WapHeader1.FenXiangLianJie = Utils.redirectUrl(HttpContext.Current.Request.Url.ToString().Replace("p.", "m."));
        }
        protected void GetAbout()
        {
            EyouSoft.BLL.OtherStructure.BKV BLL = new EyouSoft.BLL.OtherStructure.BKV();
            EyouSoft.Model.MCompanySetting model = BLL.GetCompanySetting();
            if (model == null) return;
            txtEbao.Text = model.MoblieEBao;

        }

        protected void GetUrl()
        {
             Model.SSOStructure.MUserInfo userInfo = null;
            bool islogin = Security.Membership.UserProvider.IsLogin(out userInfo);
            if (islogin)
            {
                ebao = "/Member/UserCenter.aspx";
                yue = "/Member/YuEGuanLi.aspx";
                chongzhi = "/Member/ChongZhiList.aspx";
                tixian = "/Member/TiXianList.aspx";
                jifen = "/Member/ZengZhi.aspx";
                zonghe = "/Member/ZongHeMingXi.aspx?type=1";
                mingxi = "/Member/ZongHeMingXi.aspx";
                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                {
                    fanli = "/Member/FanLiList.aspx";
                    fenxiao = "/Member/XiaJiFenXiao.aspx";
                }
            }
            LinkList.Text += "<li class=\"R_jiantou\" data-url=\"" + ebao + "\"><span class=\"label_name\"><s class=\"ico_e02\"></s>进入我的E额宝</span></li><li class=\"R_jiantou\" data-url=\"" + yue + "\"><span class=\"label_name\"><s class=\"ico_e02\"></s>E额宝余额管理</span></li><li class=\"R_jiantou\" data-url=\"" + chongzhi + "\"><span class=\"label_name\"><s class=\"ico_e03\"></s>E额宝充值明细</span></li><li class=\"R_jiantou\" data-url=\"" + fanli + "\"><span class=\"label_name\"><s class=\"ico_e03\"></s>E额宝返利明细</span></li><li class=\"R_jiantou\" data-url=\"" + tixian + "\"><span class=\"label_name\"><s class=\"ico_e03\"></s>E额宝提现明细</span></li><li class=\"R_jiantou\" data-url=\"" + jifen + "\"><span class=\"label_name\"><s class=\"ico_e04\"></s>E额宝积分增值</span></li><li class=\"R_jiantou\" data-url=\"" + fenxiao + "\"><span class=\"label_name\"><s class=\"ico_e05\"></s>我的下级分销奖</span></li><li class=\"R_jiantou\" data-url=\"" + zonghe + "\"><span class=\"label_name\"><s class=\"ico_e03\"></s>E额宝综合明细</span></li><li class=\"R_jiantou\" data-url=\"" + mingxi + "\"><span class=\"label_name\"><s class=\"ico_e03\"></s>系统交易总明细</span></li>";
        }
    }
}
