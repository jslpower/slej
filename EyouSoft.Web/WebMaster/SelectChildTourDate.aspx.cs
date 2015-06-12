using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Web.sanping
{
    /// <summary>
    /// 根据日历选择出发子团，张新兵，2011-02-23
    /// </summary>
    public partial class SelectChildTourDate : System.Web.UI.Page
    {
        protected string CurrentDate = string.Format("new Date(Date.parse('{0:yyyy\\/MM\\/dd}'))", DateTime.Today);
        protected string NextDate = string.Format("new Date(Date.parse('{0:yyyy\\/MM\\/dd}'))", DateTime.Today.AddMonths(1));

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
