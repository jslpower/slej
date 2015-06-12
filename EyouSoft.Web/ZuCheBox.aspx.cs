using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web
{
    public partial class ZuCheBox : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "tj")
            {
                
            }
        }
    }
}
