using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;


namespace EyouSoft.Web
{
    public partial class ApplyUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userType = (EyouSoft.Model.Enum.MemberTypes)Utils.GetEnumValue(typeof(EyouSoft.Model.Enum.MemberTypes), Utils.GetQueryStringValue("Classid"), 4);
            switch (userType)
            {
                //case EyouSoft.Model.Enum.MemberTypes.普通会员:
                //    break;
                case EyouSoft.Model.Enum.MemberTypes.贵宾会员:
                    litApplyType.Text = "贵宾会员";
                    break;
                case EyouSoft.Model.Enum.MemberTypes.未注册用户:
                case EyouSoft.Model.Enum.MemberTypes.免费代理:
                case EyouSoft.Model.Enum.MemberTypes.代理:
                case EyouSoft.Model.Enum.MemberTypes.员工:
                    litApplyType.Text = "代理商";
                    break;
                default:
                    litApplyType.Text = "代理商";
                    break;
            }
            if (Utils.GetQueryStringValue("type") == "Apply")
            {
                AddModel();
            }
        }
        public void AddModel()
        {
            string msg = "";
            EyouSoft.BLL.OtherStructure.BApply bll = new EyouSoft.BLL.OtherStructure.BApply();
            EyouSoft.Model.OtherStructure.MApply model = new EyouSoft.Model.OtherStructure.MApply();
            model.MemberName = Utils.GetFormValue("MyName");
            model.MemberMoblie = Utils.GetFormValue("MyMobile");
            model.CompanyName = Utils.GetFormValue("CompanyName");
            model.ApplyTime = DateTime.Now;
            int classid = Convert.ToInt32(Utils.GetQueryStringValue("Classid"));
            model.UserCate = (EyouSoft.Model.Enum.MemberTypes)classid;
            bool success = bll.Add(model);
            if (success)
            {
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "提交成功！");
            }
            else
            {
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "提交失败！");
            }
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }


    }
}
