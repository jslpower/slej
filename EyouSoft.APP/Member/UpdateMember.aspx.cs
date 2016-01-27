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
    public partial class UpdateMember : HuiYuanWapPageBase
    {
        BMember2 bll = new BMember2();
        public int IsFenXiao = 0;//0-不是，1-是分销商
        public int DaiLiNavNum = 0;
        public MemberTypes UType = MemberTypes.普通会员;
        EyouSoft.BLL.MemberStructure.BMember membll = new EyouSoft.BLL.MemberStructure.BMember();
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "资料修改";
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
                UType = model.UserType;
                txtmoblie.Text = model.Mobile;
                Literal1.Text = (model.UserType).ToString();
                if (model.BirthDate != null && model.BirthDate.ToString() != "")
                {
                    txtBirthDate.Text = Convert.ToDateTime(model.BirthDate).ToString("yyyy-MM-dd");
                }
                if (model.Gender == null || (int)model.Gender == 0)
                {
                    Gender.SelectedIndex = 0;
                }
                else
                {
                    Gender.SelectedIndex = 1;
                }
                if (model.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || model.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || model.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                {
                    IsFenXiao = 1;
                    EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.IDAL.AccountStructure.BSellers().Get(HuiYuanInfo.UserId);
                    DaiLiNavNum = (int)mseller.NavNum;
                    txtComanyName.Text = mseller.CompanyName;
                    txtCompanyJC.Text = mseller.CompanyJC;
                    txtCompanyJC.Enabled = false;
                    txtComanyName.Enabled = false;
                    //ddlNav.SelectedIndex = DaiLiNavNum;
                }

                if (model.UserType == MemberTypes.贵宾会员 || model.UserType == MemberTypes.代理 || model.UserType == MemberTypes.员工)
                {
                    FenXiao.Visible = true;
                }
                else
                {
                    FenXiao.Visible = false;
                }


                txtContact.Text = model.Contact;
                txtEmail.Text = model.Email;
                txtmember.Text = model.MemberName;
                txtqq.Text = model.qq;
                //txtnickname.Text = model.NickName;
                txtAddress.Value = model.Address;
                
                if (model.ValidDate.HasValue)
                {
                    lbl_validDate.Text = Convert.ToDateTime(model.ValidDate).ToString("yyyy-MM-dd");
                    TimeSpan span = model.ValidDate.Value - DateTime.Now;
                    if (span.Days < 10)
                    {
                        switch (model.UserType)
                        {
                            case EyouSoft.Model.Enum.MemberTypes.贵宾会员:
                                litNoticeMsg.Text = "<a target=\"_blank\" href=\"/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"btn001\"><span>马上续费</span></a>    <a target=\"_blank\" href=\"/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"btn001\" ><span>申请代理</span></a>";
                                break;
                            case EyouSoft.Model.Enum.MemberTypes.代理:
                                litNoticeMsg.Text = "<a target=\"_blank\" href=\"/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"btn001\" ><span>马上续费</span></a>";
                                break;
                            case EyouSoft.Model.Enum.MemberTypes.免费代理:
                            case EyouSoft.Model.Enum.MemberTypes.未注册用户:
                            case EyouSoft.Model.Enum.MemberTypes.普通会员:
                            case EyouSoft.Model.Enum.MemberTypes.员工:
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        private string UpdateUserInfo()
        {
            string msg = "";
            bool iscount = false;
            MMember2 Model = new MMember2();
            if (txtBirthDate.Text != "")
            {
                Model.BirthDate = Convert.ToDateTime(txtBirthDate.Text);
            }
            Model.MemberID = HuiYuanInfo.UserId;
            Model.Gender = (EyouSoft.Model.Enum.Gender)Gender.SelectedIndex;
            Model.Contact = txtContact.Text;
            Model.Email = txtEmail.Text;
            Model.MemberName = txtmember.Text;
            Model.qq = txtqq.Text;
            Model.Mobile = txtmoblie.Text;
            Model.NickName = null;
            Model.Address = txtAddress.Value;
            //membll.UpdateShowOrHidden((EyouSoft.Model.Enum.ShowHidden)ShowHidden.SelectedIndex, (NavNum)ddlNav.SelectedIndex, Model.MemberID);
            iscount = membll.UpdateMemberInfo(Model);
            if (iscount)
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
