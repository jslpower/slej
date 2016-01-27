using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.Enum;
using EyouSoft.Model.XianLuStructure;
using System.Text;

namespace EyouSoft.WebApp.CommonPage
{
    public partial class SelectSYCity : System.Web.UI.Page
    {
        protected StringBuilder strChuFa = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var CityNames = Utils.GetQueryStringValue("CityName");
                GetCity(CityNames);
            }
        }
        protected void GetCity(string CityName)
        {
            var chufalist = new EyouSoft.BLL.XianLuStructure.BXianLu().getChuFaCitys(CityName);
            if (chufalist.Any())
            {
                foreach (var item in chufalist)
                {
                    strChuFa.AppendFormat("<li class=\"ckLi\"><a href=\"/../default.aspx?CityId={0}\">{1}</a></li>", item.Id, item.Name);
                }
            }
        }
    }
}
