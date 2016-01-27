using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EyouSoft.Common;

namespace EyouSoft.WAP.CommonPage
{
    public partial class SelectDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getHtmlStr();
        }
        /// <summary>
        /// 获取最近六个月的日期
        /// </summary>
        void getHtmlStr()
        {
            StringBuilder strMonthHtml = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                DateTime dt = DateTime.Now.AddMonths(i);
                if (i == 0)
                {
                    strMonthHtml.Append("<div class=\"riqi_box\">");
                }
                else
                {
                    strMonthHtml.Append("<div class=\"riqi_box mt10\">");
                }
                strMonthHtml.AppendFormat("<div class=\"riqi_month\">{0}</div>", dt.ToString("yyyy年MM月"));
                strMonthHtml.Append("<div class=\"riqi_week\">");
                strMonthHtml.Append("<ul>");
                strMonthHtml.Append("<li>日</li>");
                strMonthHtml.Append("<li>一</li>");
                strMonthHtml.Append("<li>二</li>");
                strMonthHtml.Append("<li>三</li>");
                strMonthHtml.Append("<li>四</li>");
                strMonthHtml.Append("<li>五</li>");
                strMonthHtml.Append("<li>六</li>");
                strMonthHtml.Append("</ul>");
                strMonthHtml.Append("</div>");
                strMonthHtml.Append("<div class=\"riqi_day\">");
                strMonthHtml.Append("<ul class=\"clearfix\">");

                int days = DateTime.DaysInMonth(dt.Year, dt.Month);
                int firstLi = (int)Utils.GetDateTime(string.Format("{0}-{1}-{2}", dt.Year, dt.Month, 1)).DayOfWeek;
                for (int j = 0; j < firstLi; j++)
                {
                    strMonthHtml.Append("<li></li>");//补全空白
                }
                for (int m = 1; m <= days; m++)
                {
                    strMonthHtml.Append(getMonthStr(string.Format("{0}-{1}-{2}", dt.Year, dt.Month, m)));
                }
                strMonthHtml.Append("</ul></div></div>");
            }
            litMonth.Text = strMonthHtml.ToString();
        }
        /// <summary>
        /// 返回表格样式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        string getMonthStr(string dataStr)
        {
            DateTime dt = Utils.GetDateTime(dataStr);
            if (dt < DateTime.Now)
            {
                return string.Format("<li da class=\"riqi_day_pass\" >{0}</li>", dt.Day);
            }
            else
            {
                return string.Format("<li class=\"riqi_day_select\" data-date=\"{1}\">{0}</li>", dt.Day, dt.ToString("yyyy-MM-dd"));
            }
        }
    }
}
