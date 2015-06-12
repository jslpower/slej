using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web.WebMaster
{
    public partial class Default : Common.Page.WebmasterPageBase
    {
        protected string rightUrl = "/WebMaster/UntreatedOrders.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (UserInfo.LeiXing == EyouSoft.Model.Enum.WebmasterUserType.代理商用户)
                {
                    rightUrl = "/webmaster/shangcheng/productlist.aspx";
                }
                else if (UserInfo.LeiXing == EyouSoft.Model.Enum.WebmasterUserType.供应商用户)
                {
                    rightUrl = "/WebMaster/Supplier/SupplierEdit.aspx?type=left";
                }
            }
        }
    }
}
