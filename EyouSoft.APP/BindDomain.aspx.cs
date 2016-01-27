using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.IDAL.AccountStructure;
using System.Configuration;

namespace EyouSoft.WebApp
{
    public partial class BindDomain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var allDomain = new BSellers().GetAllList();
            foreach (var item in allDomain)
            {
                try
                {
                    new BSellers().addAppDomain(item.Website);
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message + "<br/>");
                }
            }


        }
    }
}
