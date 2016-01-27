using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.XianLuStructure;

namespace EyouSoft.Web.WebMaster.UserControl
{
    public partial class FenXiang : System.Web.UI.UserControl
    {
        private IList<EyouSoft.Model.WeiXin.XingCheng> _setPlanList;
        public IList<EyouSoft.Model.WeiXin.XingCheng> SetPlanList
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

                s.Append("<div data-class='span_journey_file' class='upload_filename'><a target='_blank' href='" + path + "'><img height='75' width='100' alt='' class='addpic img' style='vertical-align:bottom' src='" + path + "' /></a><a href='javascript:void(0);' title='删除附件' onclick='Journey.RemoveFile(this);'><img src='/images/webmaster/cha.gif' border='0'></a> </div>");
            }
            return s.ToString();
        }
        /// <summary>
        /// 返回string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string getImg(object obj)
        {
            if (obj == null) return "";
            if (string.IsNullOrEmpty(obj.ToString())) return "";
            return obj.ToString();
        }
    }
}