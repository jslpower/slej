using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.WAP.Member
{
    public partial class MoblieSheZhi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "手机网站设置";
            var model = new BLL.OtherStructure.BKV().GetCompanySetting();
            if (model == null) return;
            WapSet.Text = model.WapSet;
        }
    }
}
