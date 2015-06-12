using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.Web.WebMaster.HotelManage
{
    /// <summary>
    /// 刘飞
    /// 2013-4-27
    /// 日历显示房型所以的时间段价格
    /// </summary>
    public partial class RoomPriceAll : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected string strScript = string.Empty;
        protected DateTime startMonth = DateTime.Now;
        protected DateTime endMonth = DateTime.Now.AddMonths(3);
        protected int AddMonth = 3;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                TimeSpan ts = new TimeSpan();
                StringBuilder str = new StringBuilder();
                IList<EyouSoft.Model.HotelStructure.MHotelRoomRate> newlist = new List<EyouSoft.Model.HotelStructure.MHotelRoomRate>();
                str.Append("[");
                startMonth = list[0].StartDate;
                endMonth = list[0].EndDate;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].StartDate < startMonth)
                        startMonth = list[i].StartDate;
                    if (list[i].EndDate > endMonth)
                        endMonth = list[i].EndDate;
                    ts = endMonth - startMonth;
                    days = ts.Days;
                    AddMonth = (endMonth.Year - startMonth.Year) * 12 + (endMonth.Month - startMonth.Month);
                    if (AddMonth == 0)
                        AddMonth = 1;

                    for (int l = 0; l < days; l++)
                    {
                        if (list[i].StartDate.AddDays(l) <= list[i].EndDate)
                        {
                            newlist.Add(new EyouSoft.Model.HotelStructure.MHotelRoomRate { AmountPrice = list[i].AmountPrice, SettlementPrice = list[i].SettlementPrice, StartDate = list[i].StartDate.AddDays(l) });
                        }
                    }
                }
                for (int k = 0; k < newlist.Count; k++)
                {
                    if (k == newlist.Count - 1)
                    {
                        str.AppendFormat("{{\"StartDate\":\"{0}\",\"AmountPrice\":\"{1}\",\"SettlementPrice\":\"{2}\"}}", newlist[k].StartDate.ToString("yyyy-MM-dd"), newlist[k].AmountPrice.ToString("f0"), newlist[k].SettlementPrice.ToString("f0"));
                    }
                    else
                    {
                        str.AppendFormat("{{\"StartDate\":\"{0}\",\"AmountPrice\":\"{1}\",\"SettlementPrice\":\"{2}\"}},", newlist[k].StartDate.ToString("yyyy-MM-dd"), newlist[k].AmountPrice.ToString("f0"), newlist[k].SettlementPrice.ToString("f0"));
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
