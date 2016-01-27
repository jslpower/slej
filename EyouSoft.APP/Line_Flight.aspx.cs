using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using Newtonsoft.Json.Converters;

namespace EyouSoft.WAP
{
    public partial class Line_Flight : Common.Page.WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            initData();
        }
        /// <summary>
        /// 初始化航班信息
        /// </summary>
        void initData()
        {
            string xianluid = Utils.GetQueryStringValue("xianluid");
            var model = new EyouSoft.BLL.XianLuStructure.BXianLu().GetInfo(xianluid);
            if (model != null)
            {

                if (model.Line_Source != EyouSoft.Model.XianLuStructure.LineSource.系统) model = new EyouSoft.InterfaceLib.APITour().SyncTour(model);
                if (model.TourTraffice != null && model.TourTraffice.Count > 0)
                {
                    rptFlights.DataSource = model.TourTraffice;
                    rptFlights.DataBind();
                }
            }

        }
    }
}
