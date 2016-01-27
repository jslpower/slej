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

namespace EyouSoft.Web.WebMaster.Supplier
{
    public partial class SupplierD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(EyouSoft.Common.Utils.GetQueryStringValue("dlsid")))
                {
                    initPage();
                }
            }
        }
        void initPage()
        {
            int gysType = 0;
            string id = EyouSoft.Common.Utils.GetQueryStringValue("dlsid");
            var model = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(id);
            if (model != null)
            {
                var memberModel = new EyouSoft.IDAL.MemberStructure.BMember2().Get(model.MemberID);
                txtDanWeiMingCheng.Text = model.CompanyName;
                txtJC.Text = model.CompanyJC;
                gysType = (int)model.SupplierType;
                txtZiZhi.Text = model.Qualifications;
                txtLianXiRen.Text = memberModel.MemberName;
                txtDianHua.Text = memberModel.Contact;
                txtShouJi.Text = memberModel.Mobile;
                txtQQ.Text = memberModel.qq;
                txtYouXiang.Text = memberModel.Email;
                //txtWangZhi.Text = model.SuppULR;
                txtDiZhi.Text = memberModel.Address;
            }
        }
    }
}
