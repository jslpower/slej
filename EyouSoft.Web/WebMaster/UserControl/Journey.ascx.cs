using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.XianLuStructure;
using System.Text;

namespace Web.UserControl
{
    /// <summary>
    /// 行程安排
    /// 修改人：刘飞 创建日期:2013.3.15
    /// </summary>
    public partial class Journey : System.Web.UI.UserControl
    {
        private IList<MXianLuXingChengInfo> _setPlanList;
        public IList<MXianLuXingChengInfo> SetPlanList
        {
            get { return _setPlanList; }
            set { _setPlanList = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SetPlanList != null && SetPlanList.Count > 0)
                {
                    this.rptJourney.DataSource = SetPlanList;
                    this.rptJourney.DataBind();
                }
            }
            if (SetPlanList != null && SetPlanList.Count > 0)
            {
                phdefaultTr.Visible = false;
            }
        }

        public string GetPath(string path)
        {
            StringBuilder s = new StringBuilder();
            if (!string.IsNullOrEmpty(path))
            {
                //string n = path.Substring(path.LastIndexOf(".")).Trim();
                //if (n.ToLower() == "bmp" || n.ToLower() == "jpg" || n.ToLower() == "gif" || n.ToLower() == "jpeg" || n.ToLower() == "png")
                //{
                //    s.Append("<div data-class='span_journey_file' class='upload_filename'><a target='_blank' href='" + path + "'><img height='75' width='100' alt='' class='addpic img' style='vertical-align:bottom' src='" + path + "' /></a><a href='javascript:void(0);' title='删除附件' onclick='Journey.RemoveFile(this);'><img src='/images/webmaster/cha.gif' border='0'></a> </div>");
                //}
                //else
                //{
                //    s.Append("<div data-class='span_journey_file' class='upload_filename'><a target='_blank' href='" + path + "'>查看附件</a><a href='javascript:void(0);' title='删除附件' onclick='Journey.RemoveFile(this);'><img src='/images/webmaster/cha.gif' border='0'></a> </div>");
                //}
                s.Append("<div data-class='span_journey_file' class='upload_filename'><a target='_blank' href='" + path + "'><img height='75' width='100' alt='' class='addpic img' style='vertical-align:bottom' src='" + path + "' /></a><a href='javascript:void(0);' title='删除附件' onclick='Journey.RemoveFile(this);'><img src='/images/webmaster/cha.gif' border='0'></a> </div>");
            }
            return s.ToString();
        }
    }
}