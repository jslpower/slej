using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using Newtonsoft.Json.Converters;

namespace EyouSoft.Web.WebMaster.HotelManage
{
    /// <summary>
    /// 刘飞
    /// 2013-4-25
    /// 日历显示特定时间段的房型价格
    /// </summary>
    public partial class RoomPrice : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected string strScript = string.Empty;
        protected DateTime startMonth = DateTime.Now;
        protected DateTime endMonth = DateTime.Now.AddMonths(3);
        protected int AddMonth = 3;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sdate = Utils.GetQueryStringValue("startMonth");
            string edate = Utils.GetQueryStringValue("endMonth");
            if (!string.IsNullOrEmpty(sdate) && !string.IsNullOrEmpty(edate))
            {
                startMonth = Utils.GetDateTime(sdate);
                endMonth = Utils.GetDateTime(edate);
                AddMonth = (endMonth.Year - startMonth.Year) * 12 + (endMonth.Month - startMonth.Month);
                if (AddMonth == 0)
                    AddMonth = 1;
            }

            string roomtypeid = Utils.GetQueryStringValue("roomtypeid");
            string hotelid = Utils.GetQueryStringValue("hotelid");
            if (!IsPostBack)
            {
                PageInit(roomtypeid, hotelid);
            }
        }
        /// <summary>
        /// 初始化日历包（注册前台js 填充价格--JSON格式）
        /// </summary>
        /// <param name="roomrateid"></param>
        /// <param name="hotelid"></param>
        /// <param name="hotelid"></param>
        private void PageInit(string roomtypeid, string hotelid)
        {
            EyouSoft.BLL.HotelStructure.BHotelRoomType bll = new EyouSoft.BLL.HotelStructure.BHotelRoomType();
            IList<EyouSoft.Model.HotelStructure.MHotelRoomRate> list = bll.GetHotelRoomRateList(hotelid, roomtypeid);
            if (list != null && list.Count > 0)
            {
                int days = 0;
                TimeSpan ts = endMonth - startMonth;
                days = ts.Days;
                StringBuilder str = new StringBuilder();
                str.Append("[");
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].StartDate != startMonth) continue;
                    for (int j = 0; j <= days; j++)
                    {
                        if (j == days)
                        {
                            str.AppendFormat("{{\"StartDate\":\"{0}\",\"AmountPrice\":\"{1}\",\"SettlementPrice\":\"{2}\"}}", list[i].StartDate.AddDays(j).ToString("yyyy-MM-dd"), list[i].AmountPrice.ToString("f0"), list[i].SettlementPrice.ToString("f0"));
                        }
                        else
                        {
                            str.AppendFormat("{{\"StartDate\":\"{0}\",\"AmountPrice\":\"{1}\",\"SettlementPrice\":\"{2}\"}},", list[i].StartDate.AddDays(j).ToString("yyyy-MM-dd"), list[i].AmountPrice.ToString("f0"), list[i].SettlementPrice.ToString("f0"));
                        }
                    }

                }
                str.Append("]");
                string scripts = string.Format("var PriceList={0};", str.ToString());
                strScript = scripts;
            }
            else
            {
                strScript = "var PriceList=[];";
            }
        }
    }
}
