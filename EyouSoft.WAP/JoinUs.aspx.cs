using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.WAP
{
    public partial class JoinUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "加入我们";
            if (!Page.IsPostBack)
            {
                GetAbout();
            }
        }
        protected void GetAbout()
        {
            EyouSoft.BLL.OtherStructure.BKV BLL = new EyouSoft.BLL.OtherStructure.BKV();
            EyouSoft.Model.MCompanySetting model = BLL.GetCompanySetting();
            if (model == null) return;
            FenXiao.Text = model.MakeFenXiao;
            Gongying.Text = model.MakeGongYing;
            GuiBing.Text = model.MakeGuiBin;
            PuTong.Text = model.MakePuTong;
            YingPing.Text = model.MakeYingPing;

        }
    }
}
