using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.WAP
{
    public partial class ShenQing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var model = new BLL.OtherStructure.BKV().GetCompanySetting();
            if (model == null) return;
            tiaokuan.Text = model.DaiLiTiaoKuan;
        }
    }
}
