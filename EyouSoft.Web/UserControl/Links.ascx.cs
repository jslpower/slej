using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web.UserControl
{
    public partial class Links : System.Web.UI.UserControl
    {
        public string urllist = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.OtherStructure.BLink bll = new EyouSoft.BLL.OtherStructure.BLink();
            var list = bll.GetList();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count-1)
                {
                    urllist += "<a href='" + list[i].LinkAddre + "' target='_blank'>" + list[i].LinkText + "</a>";
                }
                else
                {
                    urllist += "<a href='" + list[i].LinkAddre + "' target='_blank'>" + list[i].LinkText + "</a> | ";
                }
            }
        }
    }
}