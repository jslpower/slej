using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web.UserControl
{
    public partial class uploadFile : System.Web.UI.UserControl
    {
        public string ClientHideID { get { return this.ClientID + "hidFileName"; } }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}