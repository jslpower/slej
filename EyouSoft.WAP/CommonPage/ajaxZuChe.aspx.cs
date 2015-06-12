using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.ZuCheStructure;
using System.Text;

namespace EyouSoft.WAP.CommonPage
{
    public partial class ajaxZuChe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
        }
        private void InitPage()
        {
            int _pageIndex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"), 1);


            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun model = new EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun()
            {
                State = EyouSoft.Model.Enum.ZuCheStates.启用,
                CarName = Utils.GetQueryStringValue("carname")
            };
            int _recordCount = 0;
            var list = bll.GetList(8, _pageIndex, ref _recordCount, model);
            if (list != null && list.Count > 0)
            {
                if (_recordCount > (_pageIndex - 1) * 8)
                {
                    rpt_ZuChe.DataSource = list;
                }
                else
                {
                    rpt_ZuChe.DataSource = null;
                }
                rpt_ZuChe.DataBind();
            }
        }
        protected string IMGhtml(object obj, object CarName)
        {
            var list = (IList<ZuCheImg>)obj;
            StringBuilder sb = new StringBuilder();
            if (list != null && list.Count > 0)
            {
                sb.AppendFormat("<img src='{0}' alt='{1}'>", TuPian.F1(list[0].FilePath,320,240), CarName.ToString());
            }
            return sb.ToString();
        }
    }
}
