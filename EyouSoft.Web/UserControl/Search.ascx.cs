using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EyouSoft.Common;

namespace EyouSoft.Web.UserControl
{
    public partial class Search : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string GetCarHtml()
        {
            StringBuilder strHtml = new StringBuilder();
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun model = new EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun()
            {
                State = EyouSoft.Model.Enum.ZuCheStates.启用,
                CarName = Utils.GetQueryStringValue("carname")
            };
            var list = bll.GetList(1000000, model);
            if (list.Count == 0)
            {
                model.State = EyouSoft.Model.Enum.ZuCheStates.启用;
                model.CarName = null;
            }
            list = bll.GetList(1000000, model);
            strHtml.Append("<select  name=\"CarSeaName\" style=\"width:150px\"> ");
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    strHtml.AppendFormat("<option value=\"{0}\" >{1}</option>",
                        item.ZuCheID, item.CarName);
                }
            }
            strHtml.Append(" </select> ");
            return strHtml.ToString();
        }
    }
}