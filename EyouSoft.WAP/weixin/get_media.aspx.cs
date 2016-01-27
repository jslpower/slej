using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.WAP.weixin
{
    public partial class get_media : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string media_id = Utils.GetFormValue("media_id");

            string url = string.Format("http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", Utils.get_weixin_access_token(), media_id);

            string filename = string.Empty;

            bool xiaZaiRetCode = EyouSoft.Toolkit.request.weixin_media_xiazai(url, "/ufiles/weixin/", out filename);

            if (xiaZaiRetCode)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "", filename));
            }

            Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "图片上传失败"));
        }
    }
}
