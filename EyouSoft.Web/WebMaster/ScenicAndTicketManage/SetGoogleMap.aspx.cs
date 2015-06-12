using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.ScenicAndTicketManage
{
    /// <summary>
    /// 刘飞
    /// 2013-4-11
    /// 设置经纬度
    /// </summary>
    public partial class SetGoogleMap : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected double Longitude = 120.091887;
        protected double Latitude = 30.286442;
        protected string BaiduMapKey = string.Empty;
        protected int ZoomLevel = 15;
        protected void Page_Load(object sender, EventArgs e)
        {
            BaiduMapKey = Utils.GetBaiduMapKeyByXml();
            if (Utils.GetQueryStringValue("weidu") != "")
                Latitude = Convert.ToDouble(Utils.GetQueryStringValue("weidu"));
            if (Utils.GetQueryStringValue("jindu") != "")
                Longitude = Convert.ToDouble(Utils.GetQueryStringValue("jindu"));
        }
    }
}
