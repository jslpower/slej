using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.IDAL.MemberStructure;
using EyouSoft.Common;
using System.Text;
using EyouSoft.Model.Enum;

namespace EyouSoft.WAP.Member
{
    public partial class UpdateWebSet : HuiYuanWapPageBase
    {
        BMember2 bll = new BMember2();
        public int DaiLiNavNum = 0;
        public MemberTypes UType = MemberTypes.普通会员;
        EyouSoft.BLL.MemberStructure.BMember membll = new EyouSoft.BLL.MemberStructure.BMember();
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "网站设置";
            string type = Utils.GetQueryStringValue("type").Trim();
            if (type == "update")
            {
                Response.Clear();
                Response.Write(UpdateUserInfo());
                Response.End();
            }
            else
            {
                MMember2 model = bll.Get(HuiYuanInfo.UserId);
                
                if (model.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || model.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || model.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                {
                    EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.IDAL.AccountStructure.BSellers().Get(HuiYuanInfo.UserId);
                    if (mseller.ShowOrHidden == EyouSoft.Model.Enum.ShowHidden.显示)
                    {
                        ShowHidden.SelectedIndex = 0;
                    }
                    else
                    {
                        ShowHidden.SelectedIndex = 1;
                    }
                    DaiLiNavNum = (int)mseller.NavNum;
                    ddlNav.SelectedIndex = DaiLiNavNum;
                }
            }
        }
        private string UpdateUserInfo()
        {
            string msg = "";
            int iscount = membll.UpdateShowOrHidden((EyouSoft.Model.Enum.ShowHidden)ShowHidden.SelectedIndex, (NavNum)ddlNav.SelectedIndex, HuiYuanInfo.UserId);
            if (iscount>0)
            {
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "修改成功！");
            }
            else
            {
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "修改失败！");
            }
            return msg;
        }
    }
}
