using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.ZuCheStructure;
using System.Text;

namespace EyouSoft.WAP
{
    public partial class CarList : System.Web.UI.Page
    {
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "车辆选择";
            InitPage();
            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }
        private void InitPage()
        {
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun model = new EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun()
            {
                State = EyouSoft.Model.Enum.ZuCheStates.启用,
                CarName = Utils.GetQueryStringValue("carname")
            };
            int _recordCount = 0;
            var list = bll.GetList(8, 1, ref _recordCount, model);
            if (list != null && list.Count > 0)
            {
                rpt_ZuChe.DataSource = list;
                rpt_ZuChe.DataBind();
            }
            FenXiangBiaoTi = "客车包租";
            FenXiangMiaoShu = "客车包租";
            if (list[0].ZucheInfoImg != null && list[0].ZucheInfoImg.Count > 0)
            {
                FenXiangTuPianFilepath = "http://" + Request.Url.Host + TuPian.F1(list[0].ZucheInfoImg[0], 320, 240);
            }
            FenXiangLianJie = HttpContext.Current.Request.Url.ToString();
        }
        protected string IMGhtml(object obj, object CarName)
        {
            var list = (IList<ZuCheImg>)obj;
            StringBuilder sb = new StringBuilder();
            if (list != null && list.Count > 0)
            {
                sb.AppendFormat("<img src='{0}' alt='{1}'>", TuPian.F1(list[0].FilePath,320,240), CarName.ToString());
            }
            return sb.ToString();
        }
    }
}
