using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web.UserControl
{
   public partial class XianLu : System.Web.UI.UserControl
   {
       EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
      protected void Page_Load(object sender, EventArgs e)
      {
          var chaxun = new EyouSoft.Model.XianLuStructure.MXianLuChaXunInfo();
          chaxun.isNoTour = true;
          var list = bll.GetXianLus(15, chaxun);
          Repeater1.DataSource = list;
          Repeater1.DataBind();
      }
   }
}