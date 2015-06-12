using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Common;
using Linq.Bussiness;
using Common.page;

namespace EyouSoft.Web.WebMaster.MemberCenter
{
    public partial class ApplyUserList : ModelViewPageBase<EyouSoft.Model.OtherStructure.MSearchApplyUser>
    {
        BApply bll = new BApply();
        public int PageIndex = 1;
        public int TotalCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.))
            //{
            //    ToUrl("/webmaster/default.aspx");
            //}
            if (!IsPostBack)
            {
                GetApplyUser();
            }
        }
        /// <summary>
        /// 获取申请列表
        /// </summary>
        public void GetApplyUser()
        {
            if (Request.QueryString["page"] != null && Request.QueryString["page"] != "")
            {
                PageIndex = Convert.ToInt32(Common.Utils.GetQueryStringValue("page"));
            }
            if (StartTime.Value.Trim() != "")
            {
                if (EndTime.Value.Trim() != "")
                {
                    if (Convert.ToDateTime(EndTime.Value.Trim()) > Convert.ToDateTime(StartTime.Value.Trim()))
                    {
                        Model.startime = Convert.ToDateTime(StartTime.Value.Trim());
                        Model.endtime = Convert.ToDateTime(EndTime.Value.Trim());
                    }
                    else if (Convert.ToDateTime(EndTime.Value.Trim()) == Convert.ToDateTime(StartTime.Value.Trim()))
                    {
                        Model.startime = Convert.ToDateTime(StartTime.Value.Trim());
                        Model.endtime = Convert.ToDateTime(EndTime.Value.Trim()).AddDays(1);
                    }
                    else
                    {
                        Model.startime = Convert.ToDateTime(EndTime.Value.Trim());
                        Model.endtime = Convert.ToDateTime(StartTime.Value.Trim());
                    }
                }
                else
                {
                    Model.startime = Convert.ToDateTime(StartTime.Value.Trim());
                    Model.endtime = DateTime.Now;
                }
            }
            PageInfo.PageSize = 20;
            Model.SearchInfo.PageInfo = PageInfo;
            Model.ucompany = UCompany.Value.Trim();
            Model.umoblie = UMoblie.Value.Trim();
            Model.uname = UName.Value.Trim();
            var list = bll.GetApplyList(Model);
            Repeater1.DataSource = list;
            Repeater1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetApplyUser();
        }
    }
}
