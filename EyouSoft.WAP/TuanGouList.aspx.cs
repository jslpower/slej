using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Common;

namespace EyouSoft.WAP
{
    public partial class TuanGouList : System.Web.UI.Page
    {
        protected int type = 0;
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] != "")
            {
                type = Convert.ToInt32(Request.QueryString["type"]);
                if (type == 3)
                {
                    WapHeader1.HeadText = "促销列表";
                }
                else
                {
                    WapHeader1.HeadText = "秒杀列表";
                }
            }
            if (!IsPostBack)
            {
                initList(type);
            }
            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initList(int type)
        {
            string orderby = "IssueTime desc";
            if (type == 0 || type >= 3)
            {
                type = 2;
            }
            var serchModel = new EyouSoft.Model.OtherStructure.MTuanGouChanPinSer();
            string website = HttpContext.Current.Request.Url.Host.ToLower().Replace("m.","");
            //string website = "m.slej.cn".ToLower().Replace("m.", "");
            if (website.IndexOf("slej.cn") > 1)
            {
                BSellers bsells = new BSellers();
                var Daimodel = bsells.GetMSellersByWebSite(website);
                if (Daimodel.NavNum == EyouSoft.Model.Enum.NavNum.代理商导航)
                {
                    serchModel.SupplierID = Daimodel.ID;
                }
            }
            serchModel.SaleType = (EyouSoft.Model.Enum.CuXiaoLeiXing)type;
            serchModel.ValiDate = DateTime.Now.AddDays(-1);
            serchModel.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            int recordCount = 0;
            var list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetList(8, 1, orderby, ref recordCount, serchModel);
            if (list != null && list.Count > 0)
            {
                Repeater1.DataSource = list;
                Repeater1.DataBind();
            }
            else
            {
                XianShi.Text = "<div class=\"user_dindan_xx\" style=\"margin-top:40px;\"><ul><li class=\"cent font_red\">暂无数据！</li></ul></div>";
            }
            FenXiangBiaoTi = "促销秒杀";
            FenXiangMiaoShu = "促销秒杀";
            if (list[0].ProductImg != null)
            {
                if (TuPian.F1(list[0].ProductImg, 320, 200) != "")
                {
                    FenXiangTuPianFilepath = "http://" + Request.Url.Host + TuPian.F1(list[0].ProductImg, 320, 200);
                }
            }
            FenXiangLianJie = HttpContext.Current.Request.Url.ToString();

        }
    }
}
