using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace EyouSoft.WAP
{
    public partial class yaoqing : WebPageBase
    {
        protected string yuMing = "m.slej.cn";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var uid = Utils.GetQueryStringValue("uid");
                if (!string.IsNullOrEmpty(uid))
                {
                    liteyqm.Value = uid;

                    yuMing = "m." + new EyouSoft.BLL.MemberStructure.BMember().GetYuMing_YaoQingMa(uid);
                }
                //string str = EyouSoft.Toolkit.request.create("http://50r.cn/short_url.json", "url=" + Request.Url);
                //if (!string.IsNullOrEmpty(str))
                //{
                //    var model = JsonConvert.DeserializeObject<DuanDiZhiUrl>(str);
                //    if (model != null && string.IsNullOrEmpty(model.error))
                //    {
                //        txturl.Value = model.url;
                //    }
                //}
            }
        }
       
        private class DuanDiZhiUrl
        {            
            public string url
            {
                get;
                set;
            }
            public string error
            {
                get;
                set;
            }
        }
    }
}
